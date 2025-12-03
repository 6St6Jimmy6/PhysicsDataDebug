using Memory.Utils;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

//Taken from https://pastebin.com/0nCpkrit by NATANM. Check his github https://github.com/N4T4NM even though he doesn't have this anymore in there.
//Usage tutorial https://www.youtube.com/watch?v=aXKEWa0_YJg but not used for malicious intents in this program.
namespace Memory.Win32
{
    class MemoryHelper32
    {
        readonly Process process;
        public MemoryHelper32(Process TargetProcess)
        {
            process = TargetProcess;
        }

        public uint GetBaseAddress(uint StartingAddress)
        {
            return (uint)process.MainModule.BaseAddress + StartingAddress;
        }

        public byte[] ReadMemoryBytes(uint MemoryAddress, uint Bytes)
        {
            byte[] data = new byte[Bytes];
            ReadProcessMemory(process.Handle, MemoryAddress, data, data.Length, IntPtr.Zero);
            return data;
        }

        public T ReadMemory<T>(uint MemoryAddress)
        {
            byte[] data = ReadMemoryBytes(MemoryAddress, (uint)Marshal.SizeOf(typeof(T)));

            T t;
            GCHandle PinnedStruct = GCHandle.Alloc(data, GCHandleType.Pinned);
            try { t = (T)Marshal.PtrToStructure(PinnedStruct.AddrOfPinnedObject(), typeof(T)); }
            catch (Exception ex) { throw ex; }
            finally { PinnedStruct.Free(); }

            return t;
        }

        public bool WriteMemory<T>(uint MemoryAddress, T Value)
        {
            IntPtr bw = IntPtr.Zero;

            int sz = ObjectType.GetSize<T>();
            byte[] data = ObjectType.GetBytes<T>(Value);
            bool result = WriteProcessMemory(process.Handle, MemoryAddress, data, sz, out bw);
            return result && bw != IntPtr.Zero;
        }

        public void Close()
        {
            CloseHandle(process.Handle);
        }

        #region PInvoke
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(
            IntPtr hProcess,
            uint lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess,
            uint lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out IntPtr lpNumberOfBytesWritten
            );

        [DllImport("kernel32.dll")]
        private static extern Int32 CloseHandle(IntPtr hProcess);
        #endregion
    }
}

namespace Memory.Win64
{
    class MemoryHelper64
    {
        readonly Process process;

        public MemoryHelper64(Process TargetProcess)
        {
            process = TargetProcess;
        }

        public ulong GetBaseAddress(ulong StartingAddress)
        {
            return (ulong)process.MainModule.BaseAddress.ToInt64() + StartingAddress;
        }

        public byte[] ReadMemoryBytes(ulong MemoryAddress, int Bytes)
        {
            byte[] data = new byte[Bytes];
            ReadProcessMemory(process.Handle, MemoryAddress, data, data.Length, IntPtr.Zero);
            return data;
        }

        public byte[] ReadMemoryBytesArray(ulong MemoryAddress, int Bytes, int byteArraySize)
        {
            byte[] data = new byte[Bytes];
            ReadProcessMemory(process.Handle, MemoryAddress, data, data.Length, IntPtr.Zero);
            return data;
        }
        public T ReadMemory<T>(ulong MemoryAddress)
        {
            byte[] data = ReadMemoryBytes(MemoryAddress, Marshal.SizeOf(typeof(T)));

            T t;
            GCHandle PinnedStruct = GCHandle.Alloc(data, GCHandleType.Pinned);
            try { t = (T)Marshal.PtrToStructure(PinnedStruct.AddrOfPinnedObject(), typeof(T)); }
            catch (Exception ex) { throw ex; }
            finally { PinnedStruct.Free(); }

            return t;
        }
        public bool WriteMemory<T>(ulong MemoryAddress, T Value)
        {
            IntPtr bw = IntPtr.Zero;

            int sz = ObjectType.GetSize<T>();
            byte[] data = ObjectType.GetBytes<T>(Value);
            bool result = WriteProcessMemory(process.Handle, MemoryAddress, data, sz, out bw);
            return result && bw != IntPtr.Zero;
        }
        // ADDED array reader, since tons of stuff are at that and can that way just read a bigger array of data.
        // Need to at some point use just the ReadMemoryBytesArray() and convert the byte arrays somewhere else to the certain type.
        public object[] ReadMemoryArray<T>(ulong MemoryAddress, int byteArraySize)
        {
            int f = new T[byteArraySize].Length;
            byte[] data = ReadMemoryBytesArray(MemoryAddress, f, byteArraySize);
            return ConvertToFloatArray(data).Cast<object>().ToArray();
        }
        #region Conversion
        // taken from https://stackoverflow.com/questions/50672268/c-sharp-reading-another-process-memory
        public static float[] ConvertToFloatArray(byte[] bytes)
        {
            if (bytes.Length % 4 != 0)
                throw new ArgumentException();

            var floats = new float[bytes.Length / 4];

            for (var i = 0; i < floats.Length; i++)
                floats[i] = BitConverter.ToSingle(bytes, i * 4);

            return floats;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            catch (Exception ex) { throw ex; }
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
        public void Close()
        {
            CloseHandle(process.Handle);
        }

        #region PInvoke
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(
            IntPtr hProcess,
            ulong lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess,
            ulong lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out IntPtr lpNumberOfBytesWritten
            );

        [DllImport("kernel32.dll")]
        private static extern Int32 CloseHandle(IntPtr hProcess);
        #endregion
    }
}

namespace Memory.Utils
{
    static class MemoryUtils
    {
        public static uint OffsetCalculator(Win32.MemoryHelper32 TargetMemory, uint BaseAddress, int[] Offsets)
        {
            var address = BaseAddress;
            foreach (uint offset in Offsets)
            {
                address = TargetMemory.ReadMemory<uint>(address) + offset;
            }
            return address;
        }

        public static ulong OffsetCalculator(Win64.MemoryHelper64 TargetMemory, ulong BaseAddress, int[] Offsets)
        {
            var address = BaseAddress;
            foreach (uint offset in Offsets)
            {
                address = TargetMemory.ReadMemory<ulong>(address) + offset;
            }
            return address;
        }
    }

    public static class ObjectType
    {
        public static int GetSize<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        public static byte[] GetBytes<T>(T Value)
        {
            string typename = typeof(T).ToString();
            Console.WriteLine(typename);
            switch (typename)
            {
                case "System.Single":
                    return BitConverter.GetBytes((float)Convert.ChangeType(Value, typeof(float)));
                case "System.Int32":
                    return BitConverter.GetBytes((int)Convert.ChangeType(Value, typeof(int)));
                case "System.Int64":
                    return BitConverter.GetBytes((long)Convert.ChangeType(Value, typeof(long)));
                case "System.Double":
                    return BitConverter.GetBytes((double)Convert.ChangeType(Value, typeof(double)));
                case "System.Byte":
                    return BitConverter.GetBytes((byte)Convert.ChangeType(Value, typeof(byte)));
                case "System.String":
                    return Encoding.Unicode.GetBytes((string)Convert.ChangeType(Value, typeof(string)));
                default:
                    return new byte[0];
            }
        }
    }
}
