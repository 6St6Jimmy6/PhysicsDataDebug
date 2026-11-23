using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    class LiveData
    {
        public static bool Logging { get; set; } = false;
        public static bool LogSettingsOpen { get; set; } = false;
        public static bool FormTireStaticValues { get; set; } = false;
        public static bool TemperaturesChartOpen { get; set; } = false;
        public static bool FormSuspensionStaticValuesOpen { get; set; } = false;
        public static bool FormSuspensionGeometryOpen {  get; set; } = false;
        public static bool GForceOpen { get; set; } = false;
        public static bool _4WheelsOpen { get; set; } = false;
        public static double RadDeg { get; } = 180 / Math.PI;
        public static double KilometersPerHourToMetersPerSec { get; } = 1 / (double)3.6;
        public static float g { get; } = 9.80665f;
        public static int TickInterval = 50;

        #region Data
        public static int None { get; set; } = 1;
        public static int RaceTime { get; set; }
        // The memory reader keeps sampling menu-visible telemetry even when RaceTime
        // is stopped. Only race-scoped charts and logging use this gate.
        public static bool RaceTimeAvailable { get; private set; }
        public static bool RaceTimeAdvanced { get; private set; }
        public static int UnavailableMemorySections { get; private set; }
        public static string FirstUnavailableMemorySection { get; private set; } = "";
        private static bool previousRaceTimeValid;
        private static int previousRaceTime;
        public static List<byte[]> Timing_TimeData { get; set; }
        private static int TimingDataStart;
        public static List<byte[]> Body_RotationData { get; set; }
        public static List<byte[]> Body_AccelData { get; set; }
        public static List<byte[]> Body_AeroData { get; set; }
        public static List<byte[]> Body_MassData {  get; set; }
        public static List<byte[]> Powertrain_EngineData { get; set; }
        public static List<byte[]> Powertrain_DifferentialPrimaryAxleData { get; set; }
        public static List<byte[]> Powertrain_DifferentialSecondaryAxleData { get; set; }
        public static List<byte[]> FL_TireData { get; set; }
        public static List<byte[]> FL_SuspensionData { get; set; }
        public static List<byte[]> FL_SuspensionGeometryData { get; set; }
        public static List<byte[]> FL_Suspension2Data { get; set; }
        public static List<byte[]> FR_TireData { get; set; }
        public static List<byte[]> FR_SuspensionData { get; set; }
        public static List<byte[]> FR_SuspensionGeometryData { get; set; }
        public static List<byte[]> FR_Suspension2Data { get; set; }
        public static List<byte[]> RL_TireData { get; set; }
        public static List<byte[]> RL_SuspensionData { get; set; }
        public static List<byte[]> RL_SuspensionGeometryData { get; set; }
        public static List<byte[]> RL_Suspension2Data { get; set; }
        public static List<byte[]> RR_TireData { get; set; }
        public static List<byte[]> RR_SuspensionData { get; set; }
        public static List<byte[]> RR_SuspensionGeometryData { get; set; }
        public static List<byte[]> RR_Suspension2Data { get; set; }
        #endregion

        // One instance owns each attached Process and is reused for all samples.
        private static MemoryReader reader;
        public static Process Process => reader?.TargetProcess;

        public static bool AttachProcess(string executableName)
        {
            // Release the previous Process object instead of closing its SafeHandle directly.
            DetachProcess();
            reader = MemoryReader.TryAttach(executableName);
            return reader != null;
        }

        public static void DetachProcess()
        {
            reader?.Close();
            reader = null;
            ResetRaceClock();
        }

        private static void ResetRaceClock()
        {
            RaceTime = 0;
            ElapsedTime = 0;
            RaceTimeAvailable = false;
            RaceTimeAdvanced = false;
            previousRaceTimeValid = false;
            previousRaceTime = 0;
            UnavailableMemorySections = 0;
            FirstUnavailableMemorySection = "";
        }

        public static readonly int[] RaceTimeArray = new int[3];
        public static readonly int[] TickTimeArray = new int[3];
        public static int ElapsedTime = 0;

        public static string PathSource = @"F:\Program Files (x86)\Steam\steamapps\common\Wreckfest\Wreckfest_x64.exe";
        public static byte[] PatternToFind = { 0x00, 0x48, 0x0F, 0x44, 0xC2, 0x48 };
        //public static byte[] PatternToFind = { 0x48, 0xC2, 0x44, 0x0F, 0x48, 0x00 };

        //int matchIndex = toBeSearched.AsSpan().IndexOf(pattern);
        public static IEnumerable<int> PatternAt(byte[] source, byte[] pattern)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));
            for (int i = 0; i <= source.Length - pattern.Length; i++)
            {
                int j = 0;
                while (j < pattern.Length && source[i + j] == pattern[j]) j++;
                if (j == pattern.Length) yield return i;
            }
        }
        public static byte[] GetExeBytes(string pathSource)
        {
            return File.ReadAllBytes(pathSource);
        }
        public static List<List<DataItem>> FullDataList { get; set; } = new List<List<DataItem>>();
        // Incremented once for each memory sample; DataItem caches requested
        // calculations until this changes. Unused calculations never run.
        internal static int TelemetryGeneration { get; private set; }

        // Labels, charts and logging all resolve the same field names many
        // times per tick. Cache the DataItem reference, not its changing value.
        private sealed class DataListLookup
        {
            public List<DataItem> Source;
            public int Count;
            public DataItem First;
            public Dictionary<string, DataItem> ByName;
            public Dictionary<string, DataItem> ByQualifiedName;
        }
        private static readonly Dictionary<int, DataListLookup> FieldLookups =
            new Dictionary<int, DataListLookup>();
        private static readonly CultureInfo TelemetryTextCulture = CultureInfo.GetCultureInfo("en-US");
        private static int PrefixIndex(string prefix)
        {
            int index = Array.IndexOf(TelemetryPrefix.Order, prefix);
            if (index < 0) throw new ArgumentException("Unknown data prefix", nameof(prefix));
            return index;
        }

        private static DataListLookup BuildLookup(List<DataItem> fields)
        {
            var byName = new Dictionary<string, DataItem>(StringComparer.Ordinal);
            var byQualifiedName = new Dictionary<string, DataItem>(StringComparer.Ordinal);
            foreach (DataItem item in fields)
            {
                if (!byName.ContainsKey(item.Name))
                    byName.Add(item.Name, item);

                if (item.SourceGroup != null)
                    byQualifiedName[item.SourceGroup + "." + item.Name] = item;
            }
            return new DataListLookup
            {
                Source = fields,
                Count = fields.Count,
                First = fields.Count == 0 ? null : fields[0],
                ByName = byName,
                ByQualifiedName = byQualifiedName
            };
        }

        public static dynamic GetFullListDataValue(string prefix, GameMemoryField dataValueToFind)
        {
            int index = PrefixIndex(prefix);
            List<DataItem> fields = FullDataList[index];
            if (!FieldLookups.TryGetValue(index, out DataListLookup lookup) ||
                !ReferenceEquals(lookup.Source, fields) || lookup.Count != fields.Count ||
                (fields.Count > 0 && !ReferenceEquals(lookup.First, fields[0])))
            {
                lookup = BuildLookup(fields);
                FieldLookups[index] = lookup;
            }
            string name = prefix + "_" + dataValueToFind;
            if (!lookup.ByQualifiedName.TryGetValue(dataValueToFind.Group + "." + name, out DataItem item) &&
                !lookup.ByName.TryGetValue(name, out item))
                throw new KeyNotFoundException("Telemetry value not found: " + name);
            return item.Value;
        }
        private static int GetConfiguredDataIndex(int start, GameMemoryField value)
        {
            // Calculated fields live immediately AFTER the raw bytes, regardless
            // of how large a future game version makes that raw memory chunk.
            if (CalculatedTelemetry.TryDataIndex(value.Group, value.Name, out int calculatedIndex))
                return calculatedIndex;
            int distance = checked(GameMemoryConfig.Int(value) - start);
            if (distance < 0 || distance % sizeof(float) != 0)
                throw new InvalidOperationException("Invalid configured 4-byte data offset: " + value.Group + "." + value.Name);
            return distance / sizeof(float);
        }
        public static string ValueString(string prefix, GameMemoryField dataValue, int roundDigits = 9, string preText = "", string afterText = "")
        {
            return preText + Math.Round(GetFullListDataValue(prefix, dataValue), roundDigits).ToString(TelemetryTextCulture) + afterText;
        }
        public static void SetValueInTB(TextBox tB, string prefix, GameMemoryField dataValue, int roundDigits = 9, string preText = "", string suffText = "")
        {
            string value = ValueString(prefix, dataValue, roundDigits, preText, suffText);
            if (!string.Equals(tB.Text, value, StringComparison.Ordinal))
                tB.Text = value;
        }
        public static void SetValueInLabel(Label l, string prefix, GameMemoryField dataValue, int roundDigits = 9, string preText = "", string suffText = "")
        {
            string value = ValueString(prefix, dataValue, roundDigits, preText, suffText);
            if (!string.Equals(l.Text, value, StringComparison.Ordinal))
                l.Text = value;
        }
        public static int GetElapsedTime()
        {
            // A newly attached, unreadable, paused or reset race clock must not
            // produce a phantom sample. A reset becomes the new baseline.
            long delta = previousRaceTimeValid && RaceTimeAvailable
                ? (long)RaceTime - previousRaceTime : 0L;
            previousRaceTime = RaceTime;
            previousRaceTimeValid = RaceTimeAvailable;
            return delta > 0L ? (int)Math.Min(delta, int.MaxValue) : 0;
        }

        /// <summary>Initialize the telemetry lists in their stable prefix order.</summary>
        public static void InitializeDataLists()
        {
            if (FullDataList.Count > 0) return;
            GenerateBodyDataList(TelemetryPrefix.Body, FullDataList);
            foreach (string wheel in new[]
                { TelemetryPrefix.FL, TelemetryPrefix.FR, TelemetryPrefix.RL, TelemetryPrefix.RR })
                GenerateTireDataList(wheel, FullDataList);
            GeneratePowertrainDataList(TelemetryPrefix.Powertrain, FullDataList);
            GenerateTimingDataList(TelemetryPrefix.Timing, FullDataList);
            FieldLookups.Clear();
        }

        /// <summary>
        /// A different game-memory profile can add or reorder raw fields.
        /// Rebuild the data layout only while live memory reads are stopped.
        /// </summary>
        public static void ReinitializeDataLists()
        {
            FullDataList.Clear();
            FieldLookups.Clear();
            InitializeDataLists();
        }

        /// <summary>Read memory and update all accessible data values once.</summary>
        public static void RefreshTelemetry(long baseAddressShift)
        {
            if (Process == null) return;
            GetData(baseAddressShift);
            UpdateBodyDataValues(TelemetryPrefix.Body, FullDataList,
                GameMemoryConfig.Int("WF_BodyRotationChunks", "DataStart"), Body_RotationData,
                GameMemoryConfig.Int("WF_BodyAccelDataChunks", "DataStart"), Body_AccelData,
                GameMemoryConfig.Int("WF_AeroDataChunks", "DataStart"), Body_AeroData,
                GameMemoryConfig.Int("WF_MassDataChunks", "DataStart"), Body_MassData);
            UpdateTimingDataValues(TelemetryPrefix.Timing, FullDataList, TimingDataStart, Timing_TimeData);
            if (RaceTimeAvailable)
                RaceTime = (int)GetFullListDataValue(TelemetryPrefix.Timing,
                    GameMemoryConfig.Field("WF_TimeDataOffset", "RaceTime"));
            else RaceTime = 0;
            // Paused/menu time does not block refreshing any other measurement.
            ElapsedTime = GetElapsedTime();
            RaceTimeAdvanced = RaceTimeAvailable && ElapsedTime > 0;

            // All four wheels use the same chunk starts. Resolve them once per
            // sample, while still honoring any newly selected game profile.
            int tireStart = GameMemoryConfig.Int("WF_TireDataChunks", "DataStart");
            int suspensionStart = GameMemoryConfig.Int("WF_Suspension1DataChunks", "DataStart");
            int geometryStart = GameMemoryConfig.Int("WF_SuspensionGeometryDataChunks", "DataStart");
            int suspension2Start = GameMemoryConfig.Int("WF_Suspension2DataChunks", "DataStart");
            UpdateTireDataValues(TelemetryPrefix.FL, FullDataList,
                tireStart, FL_TireData, suspensionStart, FL_SuspensionData,
                geometryStart, FL_SuspensionGeometryData, suspension2Start, FL_Suspension2Data);
            UpdateTireDataValues(TelemetryPrefix.FR, FullDataList,
                tireStart, FR_TireData, suspensionStart, FR_SuspensionData,
                geometryStart, FR_SuspensionGeometryData, suspension2Start, FR_Suspension2Data);
            UpdateTireDataValues(TelemetryPrefix.RL, FullDataList,
                tireStart, RL_TireData, suspensionStart, RL_SuspensionData,
                geometryStart, RL_SuspensionGeometryData, suspension2Start, RL_Suspension2Data);
            UpdateTireDataValues(TelemetryPrefix.RR, FullDataList,
                tireStart, RR_TireData, suspensionStart, RR_SuspensionData,
                geometryStart, RR_SuspensionGeometryData, suspension2Start, RR_Suspension2Data);
            UpdatePowertrainDataValues(TelemetryPrefix.Powertrain, FullDataList,
                GameMemoryConfig.Int("WF_EngineDataChunks", "DataStart"), Powertrain_EngineData,
                GameMemoryConfig.Int("WF_DifferentialDataChunks", "DataStart"), Powertrain_DifferentialPrimaryAxleData);
        }

        /// <summary>Store the raw memory snapshot; calculated values stay lazy in DataItem.</summary>
        public static void GetData(long baseAddrUpdt)
        {
            if (reader == null) return;
            TelemetryMemorySnapshot sample = reader.ReadSample(baseAddrUpdt);
            RaceTimeAvailable = sample.TimingAvailable;
            UnavailableMemorySections = sample.UnavailableSections;
            FirstUnavailableMemorySection = sample.FirstUnavailableSection ?? "";
            unchecked { TelemetryGeneration++; }

            TimingDataStart = sample.TimingStart;
            Timing_TimeData = sample.Timing;
            Body_RotationData = sample.BodyRotation;
            Body_AccelData = sample.BodyAcceleration;
            Body_AeroData = sample.BodyAero;
            Body_MassData = sample.BodyMass;
            Powertrain_EngineData = sample.Engine;
            Powertrain_DifferentialPrimaryAxleData = sample.Differential;

            FL_TireData = sample.FrontLeft.Tire;
            FL_SuspensionData = sample.FrontLeft.Suspension;
            FL_SuspensionGeometryData = sample.FrontLeft.Geometry;
            FL_Suspension2Data = sample.FrontLeft.Suspension2;
            FR_TireData = sample.FrontRight.Tire;
            FR_SuspensionData = sample.FrontRight.Suspension;
            FR_SuspensionGeometryData = sample.FrontRight.Geometry;
            FR_Suspension2Data = sample.FrontRight.Suspension2;
            RL_TireData = sample.RearLeft.Tire;
            RL_SuspensionData = sample.RearLeft.Suspension;
            RL_SuspensionGeometryData = sample.RearLeft.Geometry;
            RL_Suspension2Data = sample.RearLeft.Suspension2;
            RR_TireData = sample.RearRight.Tire;
            RR_SuspensionData = sample.RearRight.Suspension;
            RR_SuspensionGeometryData = sample.RearRight.Geometry;
            RR_Suspension2Data = sample.RearRight.Suspension2;
        }


        private static int UpdateConfiguredFields(int ii, string prefix,
            List<List<DataItem>> fullList, List<byte[]> byteData, int dataStart, string group)
        {
            List<DataItem> target = fullList[PrefixIndex(prefix)];
            // Group members are sorted by baseline JSON offsets. Version changes
            // affect where values are read, but not their order in telemetry lists.
            foreach (string memberName in GameMemoryConfig.Members(group))
            {
                if (CalculatedTelemetry.IsCalculated(group, memberName))
                {
                    // The corresponding DataItem computes this value on demand.
                    ii++;
                    continue;
                }
                int index = GetConfiguredDataIndex(dataStart, GameMemoryConfig.Field(group, memberName));
                if (index < 0 || index >= byteData.Count)
                    throw new InvalidOperationException("Configured offset for " + group + "." + memberName + " is outside its memory chunk.");
                byte[] valueByteArray = byteData[index];
                if (ReferenceEquals(valueByteArray, MemoryReader.UnavailableFourBytes))
                {
                    target[ii].Value = double.NaN;
                    ii++;
                    continue;
                }
                if (GameMemoryConfig.IsInt32Field(group, memberName))
                { target[ii].Value = BitConverter.ToInt32(valueByteArray, 0); }
                else
                { target[ii].Value = BitConverter.ToSingle(valueByteArray, 0); }
                ii++;
            }
            return ii;
        }
        private static void AddConfiguredItems(string prefix, List<DataItem> list, string group)
        {
            foreach (string name in GameMemoryConfig.Members(group))
            {
                var field = new DataItem { Id = list.Count, Name = prefix + "_" + name, SourceGroup = group };
                if (CalculatedTelemetry.IsCalculated(group, name))
                {
                    string formulaName = name;
                    field.Calculator = () => TelemetryFormulas.Calculate(group, formulaName,
                        dependency =>
                        {
                            // Fully prefixed fields explicitly identify the source,
                            // including fields belonging to a different category.
                            if (TelemetryNames.HasExplicitPrefix(dependency))
                            {
                                LogData.Column source = LogData.FindDisplay(dependency);
                                if (source != null) return source.ReadDouble();
                            }
                            return Convert.ToDouble(GetFullListDataValue(prefix,
                                new GameMemoryField(group, dependency)));
                        });
                }
                list.Add(field);
            }
        }
        public static void GeneratePowertrainDataList(string prefix, List<List<DataItem>> fullList)
        {
            var fields = new List<DataItem>();
            AddConfiguredItems(prefix, fields, "WF_EngineDataOffset");
            AddConfiguredItems(prefix, fields, "WF_DifferentialDataOffset");
            fullList.Add(fields);
        }
        public static void UpdatePowertrainDataValues(string prefix, List<List<DataItem>> fullList,
            int engineStart, List<byte[]> engineData, int differentialStart, List<byte[]> differentialData)
        {
            int ii = 0;
            ii = UpdateConfiguredFields(ii, prefix, fullList, engineData, engineStart, "WF_EngineDataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, differentialData, differentialStart, "WF_DifferentialDataOffset");
        }
        public static void GenerateBodyDataList(string prefix, List<List<DataItem>> fullList)
        {
            List<DataItem> subList = new List<DataItem>();
            AddConfiguredItems(prefix, subList, "WF_BodyRotationDataOffset");
            AddConfiguredItems(prefix, subList, "WF_BodyAccelDataOffset");
            AddConfiguredItems(prefix, subList, "WF_AeroDataOffset");
            AddConfiguredItems(prefix, subList, "WF_MassDataOffset");
            fullList.Add(subList);
        }
        public static void UpdateBodyDataValues(string prefix, List<List<DataItem>> fullList, int bodyRotationDataStart, List<byte[]> bodyRotationData, int bodyAccelDataStart, List<byte[]> bodyAccelData, int bodyAeroDataStart, List<byte[]> bodyAeroData, int massDataStart, List<byte[]> massData)
        {
            int ii = 0;
            ii = UpdateConfiguredFields(ii, prefix, fullList, bodyRotationData, bodyRotationDataStart, "WF_BodyRotationDataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, bodyAccelData, bodyAccelDataStart, "WF_BodyAccelDataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, bodyAeroData, bodyAeroDataStart, "WF_AeroDataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, massData, massDataStart, "WF_MassDataOffset");
        }
        public static void GenerateTimingDataList(string prefix, List<List<DataItem>> fullList)
        {
            List<DataItem> fields = new List<DataItem>();
            AddConfiguredItems(prefix, fields, "WF_TimeDataOffset");
            fullList.Add(fields);
        }
        public static void UpdateTimingDataValues(string prefix, List<List<DataItem>> fullList, int timeDataStart, List<byte[]> timeData)
        {
            UpdateConfiguredFields(0, prefix, fullList, timeData, timeDataStart, "WF_TimeDataOffset");
        }
        public static void GenerateTireDataList(string prefix, List<List<DataItem>> fullList)
        {
            List<DataItem> subList = new List<DataItem>();
            AddConfiguredItems(prefix, subList, "WF_TireDataOffset");
            AddConfiguredItems(prefix, subList, "WF_Suspension1DataOffset");
            AddConfiguredItems(prefix, subList, "WF_SuspensionGeometryDataOffset");
            AddConfiguredItems(prefix, subList, "WF_Suspension2DataOffset");
            fullList.Add(subList);
        }
        public static void UpdateTireDataValues(string prefix, List<List<DataItem>> fullList, int tireDataStart, List<byte[]> tireData, int suspensionDataStart, List<byte[]> suspensionData, int suspensionGeometryDataStart, List<byte[]>suspensionGeometryData, int suspension2DataStart, List<byte[]> suspension2Data)
        {
            int ii = 0;
            ii = UpdateConfiguredFields(ii, prefix, fullList, tireData, tireDataStart, "WF_TireDataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, suspensionData, suspensionDataStart, "WF_Suspension1DataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, suspensionGeometryData, suspensionGeometryDataStart, "WF_SuspensionGeometryDataOffset");
            ii = UpdateConfiguredFields(ii, prefix, fullList, suspension2Data, suspension2DataStart, "WF_Suspension2DataOffset");
        }
    }
}
