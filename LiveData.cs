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
            public Dictionary<string, DataItem> Fields;
            public Dictionary<string, DataItem> ChartFields;
        }
        private static readonly DataListLookup[] FieldLookups = new DataListLookup[TelemetryPrefix.Order.Length];
        private static readonly int[] SharedChartPrefixes = { 0, 5, 6 };
        private static readonly CultureInfo TelemetryTextCulture = CultureInfo.GetCultureInfo("en-US");
        private static int PrefixIndex(string prefix)
        {
            int index = Array.IndexOf(TelemetryPrefix.Order, prefix);
            if (index < 0) throw new ArgumentException("Unknown data prefix", nameof(prefix));
            return index;
        }

        private static DataListLookup BuildLookup(List<DataItem> fields, string prefix)
        {
            var raw = new Dictionary<string, DataItem>(StringComparer.Ordinal);
            var chart = new Dictionary<string, DataItem>(StringComparer.Ordinal);
            bool wheel = TelemetryNames.Wheels.Contains(prefix);
            string prefixName = prefix + "_";
            // Canonical logger headers disambiguate duplicated suspension members.
            var canonicalByMember = wheel ? LogData.AllColumns.Where(c => c.Wheel == prefix)
                .ToDictionary(c => c.Group + "." + c.Member, c => c.Header, StringComparer.Ordinal) : null;
            foreach (DataItem item in fields)
            {
                if (!raw.ContainsKey(item.Name)) raw.Add(item.Name, item);
                if (item.SourceGroup != null) raw[item.SourceGroup + "." + item.Name] = item;
                if (!item.Name.StartsWith(prefixName, StringComparison.Ordinal)) continue;
                string member = item.Name.Substring(prefixName.Length);
                if (!chart.ContainsKey(member)) chart.Add(member, item);
                if (item.SourceGroup == null) continue;
                if (wheel)
                {
                    if (canonicalByMember.TryGetValue(item.SourceGroup + "." + member, out string canonical))
                    {
                        chart[canonical] = item;
                        chart[TelemetryNames.RelativeWheelName(canonical)] = item;
                    }
                }
                else
                {
                    string canonical = TelemetryNames.Name(item.SourceGroup, member);
                    if (!chart.ContainsKey(canonical)) chart.Add(canonical, item);
                }
            }
            return new DataListLookup
            {
                Source = fields, Count = fields.Count, First = fields.Count == 0 ? null : fields[0],
                Fields = raw, ChartFields = chart
            };
        }

        private static DataListLookup GetLookup(int index)
        {
            List<DataItem> fields = FullDataList[index];
            DataListLookup lookup = FieldLookups[index];
            if (lookup == null || !ReferenceEquals(lookup.Source, fields) || lookup.Count != fields.Count ||
                (fields.Count > 0 && !ReferenceEquals(lookup.First, fields[0])))
                FieldLookups[index] = lookup = BuildLookup(fields, TelemetryPrefix.Order[index]);
            return lookup;
        }

        public static dynamic GetFullListDataValue(string prefix, GameMemoryField dataValueToFind) =>
            GetFullListObjectValue(prefix, dataValueToFind);

        internal static object GetFullListObjectValue(string prefix, GameMemoryField dataValueToFind)
        {
            var fields = GetLookup(PrefixIndex(prefix)).Fields;
            string name = prefix + "_" + dataValueToFind;
            if (!fields.TryGetValue(dataValueToFind.Group + "." + name, out DataItem item) &&
                !fields.TryGetValue(name, out item))
                throw new KeyNotFoundException("Telemetry value not found: " + name);
            return item.Value;
        }

        private static bool TrySharedChartField(string name, out DataItem item)
        {
            if (name != null)
                foreach (int index in SharedChartPrefixes)
                    if (GetLookup(index).ChartFields.TryGetValue(name, out item)) return true;
            item = null;
            return false;
        }

        internal readonly struct ChartValueReader
        {
            private readonly Dictionary<string, DataItem> wheelFields;
            internal ChartValueReader(Dictionary<string, DataItem> fields) { wheelFields = fields; }

            internal float Read(string selected, int none)
            {
                string relative = TelemetryNames.RelativeWheelName(selected);
                DataItem item;
                if ((relative != null && wheelFields.TryGetValue(relative, out item)) ||
                    TrySharedChartField(selected, out item) ||
                    (relative != selected && TrySharedChartField(relative, out item)))
                    return Convert.ToSingle(item.Value);
                return none;
            }
        }

        internal static ChartValueReader GetChartReader(string prefix) =>
            new ChartValueReader(GetLookup(PrefixIndex(prefix)).ChartFields);

        // The historical getter returns dynamic because source fields can be
        // float32 or int32. At call sites that need a specific numeric type,
        // explicitly convert rather than letting the runtime binder decide.
        // In particular, an unavailable raw field must never turn a chart
        // update into a RuntimeBinderException (double -> float).
        public static float GetFullListFloatValue(string prefix, GameMemoryField field)
        {
            object value = GetFullListObjectValue(prefix, field);
            if (value == null) return float.NaN;
            try { return Convert.ToSingle(value, CultureInfo.InvariantCulture); }
            catch (InvalidCastException) { return float.NaN; }
            catch (FormatException) { return float.NaN; }
            catch (OverflowException) { return float.NaN; }
        }

        public static double GetFullListDoubleValue(string prefix, GameMemoryField field)
        {
            object value = GetFullListObjectValue(prefix, field);
            if (value == null) return double.NaN;
            try { return Convert.ToDouble(value, CultureInfo.InvariantCulture); }
            catch (InvalidCastException) { return double.NaN; }
            catch (FormatException) { return double.NaN; }
            catch (OverflowException) { return double.NaN; }
        }
        private readonly struct RawFieldRead
        {
            internal readonly int Position, ByteIndex;
            internal readonly bool IsInt32;
            internal readonly string Name;
            internal RawFieldRead(int position, int byteIndex, bool isInt32, string name)
            { Position = position; ByteIndex = byteIndex; IsInt32 = isInt32; Name = name; }
        }

        private sealed class FieldReadPlan
        {
            internal int DataStart, MemberCount;
            internal RawFieldRead[] Reads;
        }

        private static readonly Dictionary<string, FieldReadPlan> ReadPlans =
            new Dictionary<string, FieldReadPlan>(StringComparer.Ordinal);
        private static int readPlanRevision = -1;

        private static FieldReadPlan GetReadPlan(string group, int dataStart)
        {
            if (readPlanRevision != GameMemoryConfig.MemoryLayoutRevision)
            {
                ReadPlans.Clear();
                readPlanRevision = GameMemoryConfig.MemoryLayoutRevision;
            }
            if (ReadPlans.TryGetValue(group, out FieldReadPlan plan) && plan.DataStart == dataStart)
                return plan;
            var members = GameMemoryConfig.Members(group);
            var reads = new List<RawFieldRead>(members.Count);
            for (int i = 0; i < members.Count; i++)
            {
                string member = members[i];
                if (CalculatedTelemetry.IsCalculated(group, member)) continue;
                int distance = checked(GameMemoryConfig.Int(group, member) - dataStart);
                if (distance < 0 || distance % sizeof(float) != 0)
                    throw new InvalidOperationException("Invalid configured 4-byte data offset: " + group + "." + member);
                reads.Add(new RawFieldRead(i, distance / sizeof(float), GameMemoryConfig.IsInt32Field(group, member), member));
            }
            plan = new FieldReadPlan { DataStart = dataStart, MemberCount = members.Count, Reads = reads.ToArray() };
            ReadPlans[group] = plan;
            return plan;
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
            Array.Clear(FieldLookups, 0, FieldLookups.Length);
        }

        /// <summary>
        /// A different game-memory profile can add or reorder raw fields.
        /// Rebuild the data layout only while live memory reads are stopped.
        /// </summary>
        public static void ReinitializeDataLists()
        {
            FullDataList.Clear();
            Array.Clear(FieldLookups, 0, FieldLookups.Length);
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
            // The plan is shared by all four wheels and rebuilt only when the
            // active config/version (or chunk start) changes. Lazy calculations
            // have no entry in the raw-memory read plan.
            FieldReadPlan plan = GetReadPlan(group, dataStart);
            foreach (RawFieldRead read in plan.Reads)
            {
                if (read.ByteIndex < 0 || read.ByteIndex >= byteData.Count)
                    throw new InvalidOperationException("Configured offset for " + group + "." + read.Name + " is outside its memory chunk.");
                byte[] bytes = byteData[read.ByteIndex];
                DataItem item = target[ii + read.Position];
                if (ReferenceEquals(bytes, MemoryReader.UnavailableFourBytes))
                    item.Value = float.NaN;
                else if (read.IsInt32)
                    item.Value = BitConverter.ToInt32(bytes, 0);
                else
                    item.Value = BitConverter.ToSingle(bytes, 0);
            }
            return ii + plan.MemberCount;
        }
        private static void AddConfiguredItems(string prefix, List<DataItem> list, string group)
        {
            foreach (string name in GameMemoryConfig.Members(group))
            {
                var field = new DataItem { Name = prefix + "_" + name, SourceGroup = group };
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
