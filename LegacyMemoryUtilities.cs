// Legacy 32-bit reader and conversion/pointer utilities kept for compatibility.
// Live Wreckfest x64 reads use Physics_Data_Debug.MemoryReader.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Memory.Utils;

//Taken from https://pastebin.com/0nCpkrit by NATANM. Check his github https://github.com/N4T4NM even though he doesn't have this anymore in there.
namespace Memory.Win32
{
    class MemoryReader32
    {
        readonly Process process;
        public MemoryReader32(Process TargetProcess)
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
            process.Close();
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

namespace Memory.Utils
{
    static class MemoryUtils
    {
        public static uint OffsetCalculator(Win32.MemoryReader32 TargetMemory, uint BaseAddress, int[] Offsets)
        {
            var address = BaseAddress;
            foreach (uint offset in Offsets)
            {
                address = TargetMemory.ReadMemory<uint>(address) + offset;
            }
            return address;
        }

        public static ulong OffsetCalculator(Physics_Data_Debug.MemoryReader TargetMemory, ulong BaseAddress, int[] Offsets)
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
