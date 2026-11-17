using System;
using Memory.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Physics_Data_Debug
{
    class MemoryReader
    {
        private readonly Process process;
        private readonly IntPtr processHandle;
        private readonly ulong moduleBase;
        public Process TargetProcess => process;

        public MemoryReader(Process targetProcess)
        {
            process = targetProcess ?? throw new ArgumentNullException(nameof(targetProcess));
            // Cache module base/handle once per connection, rather than retrieving
            // MainModule for every one of the many memory chunks per sample.
            processHandle = process.Handle;
            moduleBase = unchecked((ulong)process.MainModule.BaseAddress.ToInt64());
        }

        public ulong GetBaseAddress(ulong startingAddress) => unchecked(moduleBase + startingAddress);

        public byte[] ReadMemoryBytes(ulong MemoryAddress, int Bytes)
        {
            byte[] data = new byte[Bytes];
            if (Bytes == 0) return data;
            IntPtr bytesRead;
            if (!ReadProcessMemory(processHandle, new IntPtr(unchecked((long)MemoryAddress)),
                    data, data.Length, out bytesRead) || bytesRead.ToInt64() != Bytes)
                throw new Win32Exception(Marshal.GetLastWin32Error(),
                    "Unable to read " + Bytes + " bytes from game memory at 0x" + MemoryAddress.ToString("X") + ".");
            return data;
        }

        public byte[] ReadMemoryBytesArray(ulong MemoryAddress, int Bytes, int byteArraySize)
        {
            // Keep the existing signature for callers that supply the element count.
            return ReadMemoryBytes(MemoryAddress, Bytes);
        }
        public T ReadMemory<T>(ulong MemoryAddress)
        {
            byte[] data = ReadMemoryBytes(MemoryAddress, Marshal.SizeOf(typeof(T)));

            T t;
            GCHandle PinnedStruct = GCHandle.Alloc(data, GCHandleType.Pinned);
            try { t = (T)Marshal.PtrToStructure(PinnedStruct.AddrOfPinnedObject(), typeof(T)); }
            finally { PinnedStruct.Free(); }

            return t;
        }
        public bool WriteMemory<T>(ulong MemoryAddress, T Value)
        {
            IntPtr bw = IntPtr.Zero;

            int sz = ObjectType.GetSize<T>();
            byte[] data = ObjectType.GetBytes<T>(Value);
            bool result = WriteProcessMemory(processHandle, new IntPtr(unchecked((long)MemoryAddress)), data, sz, out bw);
            return result && bw != IntPtr.Zero;
        }
        // ADDED array reader, since tons of stuff are at that and can that way just read a bigger array of data.
        // Need to at some point use just the ReadMemoryBytesArray() and convert the byte arrays somewhere else to the certain type.
        //Removed <T> and made size always 4, because all the values are 4 byte arrays like Int32 or floats
        public List<byte[]> ReadMemoryArray(ulong MemoryAddress, int byteArraySize)
        {
            return ConvertToArray(ReadMemoryBytes(MemoryAddress, byteArraySize));
        }
        #region Conversion
        // taken from https://stackoverflow.com/questions/50672268/c-sharp-reading-another-process-memory

        //float[] to object[] and 4 bytes length always
        public static List<byte[]> ConvertToArray(byte[] bytes)
        {
            if (bytes.Length % 4 != 0)
                throw new ArgumentException("Memory data must consist of four-byte values.", nameof(bytes));
            var list = new List<byte[]>(bytes.Length / sizeof(float));
            // Preserve the original bits: chunks may be Int32 values (e.g. RaceTime),
            // NaNs, or floating-point numbers. No float round-trip is necessary.
            for (int offset = 0; offset < bytes.Length; offset += sizeof(float))
            {
                var value = new byte[sizeof(float)];
                Buffer.BlockCopy(bytes, offset, value, 0, value.Length);
                list.Add(value);
            }
            return list;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }

        private static byte[] StructureToByteArray(object obj)
        {
            var length = Marshal.SizeOf(obj);

            var array = new byte[length];

            var pointer = Marshal.AllocHGlobal(length);

            Marshal.StructureToPtr(obj, pointer, true);
            Marshal.Copy(pointer, array, 0, length);
            Marshal.FreeHGlobal(pointer);

            return array;
        }

        #endregion

        /// <summary>
        /// Read a configured 4-byte-aligned chunk after following the game's pointer chain.
        /// Side and chunk offsets are applied in exactly the same order as the original reader.
        /// </summary>
        public List<byte[]> ReadConfiguredChunk(ulong baseAddress, long versionShift,
            int sideOffset, int[] extraOffsets, int chunkStart, int chunkSize)
        {
            if (chunkSize <= 0 || chunkSize % sizeof(float) != 0)
                throw new ArgumentOutOfRangeException(nameof(chunkSize), "Chunk size must be a positive multiple of four.");
            if (extraOffsets == null) extraOffsets = Array.Empty<int>();
            int[] pointerOffsets = new int[extraOffsets.Length + 1];
            Array.Copy(extraOffsets, pointerOffsets, extraOffsets.Length);
            pointerOffsets[pointerOffsets.Length - 1] = checked(chunkStart + sideOffset);
            ulong moduleBase = GetBaseAddress(unchecked((ulong)((long)baseAddress + versionShift)));
            return ReadMemoryArray(ResolvePointer(moduleBase, pointerOffsets), chunkSize);
        }

        // Fast path for the two pointer-chain forms used by Wreckfest telemetry:
        // base -> chunk + side, or base -> extra -> chunk + side.
        // Avoid allocating offset arrays for every one of the 20+ reads per tick.
        public List<byte[]> ReadConfiguredChunk(ulong baseAddress, long versionShift,
            int sideOffset, int chunkStart, int chunkSize, int? extraPointerOffset = null)
        {
            if (chunkSize <= 0 || chunkSize % sizeof(float) != 0)
                throw new ArgumentOutOfRangeException(nameof(chunkSize), "Chunk size must be a positive multiple of four.");

            ulong address = GetBaseAddress(unchecked((ulong)((long)baseAddress + versionShift)));
            if (extraPointerOffset.HasValue)
                address = unchecked(ReadMemory<ulong>(address) + (ulong)unchecked((uint)extraPointerOffset.Value));
            address = unchecked(ReadMemory<ulong>(address) +
                (ulong)unchecked((uint)checked(chunkStart + sideOffset)));
            return ReadMemoryArray(address, chunkSize);
        }

        private List<byte[]> ReadChunk(string baseName, long versionShift,
            string sideGroup, string sideName, string chunkGroup, string extraPointerName = null)
        {
            int sideOffset = sideGroup == null ? 0 : GameMemoryConfig.Int(sideGroup, sideName);
            int start = GameMemoryConfig.Int(chunkGroup, "DataStart");
            int size = GameMemoryConfig.Int(chunkGroup, "ChunkSize");
            int? extra = extraPointerName == null ? (int?)null : GameMemoryConfig.Int(chunkGroup, extraPointerName);
            return ReadConfiguredChunk(GameMemoryConfig.Address(baseName), versionShift,
                sideOffset, start, size, extra);
        }

        public ulong ResolvePointer(ulong address, IReadOnlyList<int> offsets)
        {
            if (offsets == null) throw new ArgumentNullException(nameof(offsets));
            for (int i = 0; i < offsets.Count; i++)
                address = unchecked(ReadMemory<ulong>(address) + (ulong)unchecked((uint)offsets[i]));
            return address;
        }

        public T ReadConfiguredValue<T>(ulong baseAddress, long versionShift, int[] offsets)
        {
            ulong start = GetBaseAddress(unchecked((ulong)((long)baseAddress + versionShift)));
            return ReadMemory<T>(ResolvePointer(start, offsets ?? Array.Empty<int>()));
        }

        /// <summary>Capture all configured raw chunks once, without calculating any derived telemetry.</summary>
        public TelemetryMemorySnapshot ReadSample(long baseShift)
        {
            var sample = new TelemetryMemorySnapshot();
            GetTimingSpan(out int timingStart, out int timingSize);
            sample.TimingStart = timingStart;
            sample.Timing = ReadConfiguredChunk(GameMemoryConfig.Address("RaceTime"), baseShift,
                0, timingStart, timingSize);

            sample.BodyMass = ReadChunk("Suspension2", baseShift,
                "WF_BodyMassSide", "AllSides", "WF_MassDataChunks");
            sample.BodyRotation = ReadChunk("BodyLocationHeading", baseShift,
                "WF_BodyRotationSide", "AllSides", "WF_BodyRotationChunks", "Offset1");
            sample.BodyAcceleration = ReadChunk("Acceleration", baseShift,
                "WF_BodyAccelSide", "AllSides", "WF_BodyAccelDataChunks");
            sample.BodyAero = ReadChunk("Aero", baseShift,
                "WF_AeroSide", "AllSides", "WF_AeroDataChunks");
            sample.Engine = ReadChunk("Engine", baseShift,
                "WF_EngineSide", "AllSides", "WF_EngineDataChunks");
            sample.Differential = ReadChunk("Differential", baseShift,
                "WF_DifferentialSide", "Left", "WF_DifferentialDataChunks");

            sample.FrontLeft = ReadWheel("FL", baseShift);
            sample.FrontRight = ReadWheel("FR", baseShift);
            sample.RearLeft = ReadWheel("RL", baseShift);
            sample.RearRight = ReadWheel("RR", baseShift);
            return sample;
        }

        private WheelMemoryBlock ReadWheel(string wheel, long versionShift)
        {
            return new WheelMemoryBlock
            {
                Tire = ReadChunk("Tire", versionShift,
                    "WF_TireSide", wheel, "WF_TireDataChunks", "Offset1"),
                Suspension = ReadChunk("Suspension1", versionShift,
                    "WF_Suspension1DataSideOffset", wheel, "WF_Suspension1DataChunks"),
                Geometry = ReadChunk("SuspensionGeometry", versionShift,
                    "WF_SuspensionGeometrySideOffsets", wheel, "WF_SuspensionGeometryDataChunks"),
                Suspension2 = ReadChunk("Suspension2", versionShift,
                    "WF_Suspension2DataSideOffset", wheel, "WF_Suspension2DataChunks")
            };
        }

        private static void GetTimingSpan(out int dataStart, out int byteCount)
        {
            const string group = "WF_TimeDataOffset";
            IReadOnlyList<string> names = GameMemoryConfig.Members(group);
            if (names.Count == 0)
                throw new InvalidOperationException("No timing fields configured in " + group + ".");
            int first = int.MaxValue, last = int.MinValue;
            foreach (string name in names)
            {
                int offset = GameMemoryConfig.Int(group, name);
                first = Math.Min(first, offset);
                last = Math.Max(last, offset);
            }
            long size = (long)last - first + sizeof(int);
            if (size <= 0 || size > 1024 * 1024 || size % sizeof(int) != 0)
                throw new InvalidOperationException("Invalid timing field offsets in " + group + ".");
            dataStart = first;
            byteCount = (int)size;
        }

        /// <summary>Find and take ownership of the first matching process, disposing unused Process objects.</summary>
        public static MemoryReader TryAttach(string executableName)
        {
            Process[] candidates = Process.GetProcessesByName(executableName);
            Process selected = null;
            foreach (Process candidate in candidates)
            {
                bool running;
                try { running = !candidate.HasExited; }
                catch (InvalidOperationException) { running = false; }
                if (running && selected == null) selected = candidate;
                else candidate.Dispose();
            }
            if (selected == null) return null;
            try { return new MemoryReader(selected); }
            catch { selected.Dispose(); throw; }
        }

        // The Process instance owns the SafeHandle. Never call CloseHandle on process.Handle.
        public void Close() => process.Dispose();

        #region PInvoke
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out IntPtr lpNumberOfBytesWritten
            );

        #endregion
    }

    /// <summary>Raw 4-byte telemetry chunks belonging to one memory sample. No derived values are computed.</summary>
    internal sealed class TelemetryMemorySnapshot
    {
        public int TimingStart;
        public List<byte[]> Timing;
        public List<byte[]> BodyRotation, BodyAcceleration, BodyAero, BodyMass;
        public List<byte[]> Engine, Differential;
        public WheelMemoryBlock FrontLeft, FrontRight, RearLeft, RearRight;
    }

    internal sealed class WheelMemoryBlock
    {
        public List<byte[]> Tire, Suspension, Geometry, Suspension2;
    }
}

