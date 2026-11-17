using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Finds the build number and the Tire global-variable RVA from the x64
    /// Wreckfest executable. File offsets are converted using the PE section
    /// table; a change in code layout therefore does not affect address math.
    /// Detection is intentionally strict: a missing/ambiguous signature is an
    /// error, not permission to read memory using a guessed address.
    /// </summary>
    internal static class WreckfestVersionDetector
    {
        // mov r8d, imm32 ; cmove rax, rdx ; following REX prefix.
        private static readonly byte[] VersionBefore = { 0x41, 0xB8 };
        private static readonly byte[] VersionAfter = { 0x48, 0x0F, 0x44, 0xC2, 0x48 };

        // Prologue and LEA rip-relative reference to the tire global.
        // The four displacement bytes following this prefix are variable.
        private static readonly byte[] TireBefore =
        {
            0x48, 0x8B, 0xC4, 0x53, 0x57, 0x48, 0x81, 0xEC,
            0xC8, 0x00, 0x00, 0x00, 0x0F, 0x29, 0x70, 0xD8,
            0x48, 0x8D, 0x1D
        };
        private static readonly byte[] TireAfter =
        {
            0x0F, 0x29, 0x78, 0xC8, 0x48, 0x8B, 0xFA,
            0x44, 0x0F, 0x29, 0x40, 0xB8
        };

        public static WreckfestDetectedVersion Detect(string executablePath)
        {
            if (string.IsNullOrWhiteSpace(executablePath))
                throw new ArgumentException("No executable path was supplied.", nameof(executablePath));

            byte[] image = File.ReadAllBytes(executablePath);
            var sections = ReadPeSections(image);

            int versionOffset = FindUnique(image, VersionBefore, sizeof(int), VersionAfter,
                "Wreckfest build-number instruction");
            int build = BitConverter.ToInt32(image, versionOffset + VersionBefore.Length);
            if (build <= 0)
                throw new InvalidDataException("Invalid Wreckfest build number in the executable.");

            int tireOffset = FindUnique(image, TireBefore, sizeof(int), TireAfter,
                "Wreckfest tire-base instruction");
            int displacementOffset = tireOffset + TireBefore.Length;
            long instructionRva = FileOffsetToRva(tireOffset + 16, sections);
            long displacement = BitConverter.ToInt32(image, displacementOffset);
            long tireRva = checked(instructionRva + 7 + displacement);
            if (tireRva <= 0 || !IsInSection(tireRva, ".data", sections))
                throw new InvalidDataException("Detected tire pointer is outside the executable's .data section.");

            return new WreckfestDetectedVersion(build, tireRva, executablePath,
                versionOffset + VersionBefore.Length, tireOffset + 16);
        }

        private static int FindUnique(byte[] data, byte[] before, int gap, byte[] after, string purpose)
        {
            int first = -1;
            int count = 0;
            int required = before.Length + gap + after.Length;
            for (int offset = 0; offset <= data.Length - required; offset++)
            {
                if (data[offset] != before[0]) continue;
                bool match = true;
                for (int j = 1; j < before.Length; j++)
                    if (data[offset + j] != before[j]) { match = false; break; }
                if (!match) continue;
                int afterOffset = offset + before.Length + gap;
                for (int j = 0; j < after.Length; j++)
                    if (data[afterOffset + j] != after[j]) { match = false; break; }
                if (!match) continue;
                if (++count == 1) first = offset;
                if (count > 1) break;
            }
            if (count != 1)
                throw new InvalidDataException(purpose + " was found " + count +
                    " times (expected exactly one). Select a manual JSON version instead.");
            return first;
        }

        private sealed class PeSection
        {
            internal string Name;
            internal long Rva;
            internal long VirtualSize;
            internal long RawOffset;
            internal long RawSize;
        }

        private static List<PeSection> ReadPeSections(byte[] data)
        {
            if (data.Length < 0x100 || data[0] != 'M' || data[1] != 'Z')
                throw new InvalidDataException("Not a PE executable.");
            int header = BitConverter.ToInt32(data, 0x3C);
            if (header < 0 || (long)header + 24 > data.Length ||
                data[header] != 'P' || data[header + 1] != 'E' ||
                data[header + 2] != 0 || data[header + 3] != 0)
                throw new InvalidDataException("Invalid PE headers.");
            if (BitConverter.ToUInt16(data, header + 4) != 0x8664)
                throw new InvalidDataException("Automatic detection requires Wreckfest_x64.exe (PE x64).");
            int count = BitConverter.ToUInt16(data, header + 6);
            int sizeOfOptionalHeader = BitConverter.ToUInt16(data, header + 20);
            long table = (long)header + 24 + sizeOfOptionalHeader;
            if (count < 1 || count > 96 || table + 40L * count > data.Length)
                throw new InvalidDataException("Invalid PE section table.");
            var sections = new List<PeSection>(count);
            for (int i = 0; i < count; i++)
            {
                int offset = checked((int)(table + 40L * i));
                int length = 0;
                while (length < 8 && data[offset + length] != 0) length++;
                sections.Add(new PeSection
                {
                    Name = Encoding.ASCII.GetString(data, offset, length),
                    VirtualSize = BitConverter.ToUInt32(data, offset + 8),
                    Rva = BitConverter.ToUInt32(data, offset + 12),
                    RawSize = BitConverter.ToUInt32(data, offset + 16),
                    RawOffset = BitConverter.ToUInt32(data, offset + 20)
                });
            }
            return sections;
        }

        private static long FileOffsetToRva(long fileOffset, IEnumerable<PeSection> sections)
        {
            foreach (PeSection section in sections)
                if (fileOffset >= section.RawOffset && fileOffset < section.RawOffset + section.RawSize)
                    return section.Rva + fileOffset - section.RawOffset;
            throw new InvalidDataException("Matched instruction is not inside a PE section.");
        }

        private static bool IsInSection(long rva, string name, IEnumerable<PeSection> sections)
        {
            foreach (PeSection section in sections)
                if (string.Equals(section.Name, name, StringComparison.Ordinal) &&
                    rva >= section.Rva && rva < section.Rva + Math.Max(section.VirtualSize, section.RawSize))
                    return true;
            return false;
        }
    }

    internal sealed class WreckfestDetectedVersion
    {
        public int BuildNumber { get; }
        public string VersionId => "V1_" + BuildNumber;
        public long TireBaseRva { get; }
        public string ExecutablePath { get; }
        public long VersionFileOffset { get; }
        public long TireInstructionFileOffset { get; }

        internal WreckfestDetectedVersion(int build, long tireRva, string path,
            long versionFileOffset, long tireInstructionFileOffset)
        {
            BuildNumber = build;
            TireBaseRva = tireRva;
            ExecutablePath = path;
            VersionFileOffset = versionFileOffset;
            TireInstructionFileOffset = tireInstructionFileOffset;
        }
    }
}
