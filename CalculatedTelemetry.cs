using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Calculations performed in LiveData, not game-memory addresses. Keep the
    /// names in the same order as the bytes appended by GetCalculated*Data.
    /// Chart, logger and label lookups can use these names exactly like raw fields.
    /// </summary>
    internal static class CalculatedTelemetry
    {
        private sealed class Layout
        {
            public string Chunk;
            public string[] Fields;
            public Dictionary<string, int> Indexes;
        }

        private static readonly Dictionary<string, Layout> Layouts =
            new Dictionary<string, Layout>(StringComparer.Ordinal)
            {
                { "WF_TireDataOffset", new Layout { Chunk = "WF_TireDataChunks", Fields = new[] {
                    "CasterAngleRad", "CasterAngleDeg", "CamberAngleRad", "CamberAngleDeg",
                    "SteerAngleRad", "SteerAngleDeg", "LateralFriction", "LongitudinalFriction",
                    "TotalFriction", "TotalFrictionAngleDeg", "SlipAngleDeg", "RollingResistance",
                    "PneumaticTrail", "TreadTemperatureKelvins", "Log10aT", "LateralAdhesionGrip",
                    "LateralMicroGrip", "LateralMacroGrip", "WLF_LateralSlidingFrictionGripMultiplier",
                    "LongitudinalAdhesionGrip", "LongitudinalMicroGrip", "LongitudinalMacroGrip",
                    "WLF_LongitudinalSlidingFrictionGripMultiplier", "LateralLoadSensGripMultiplier",
                    "LongitudinalLoadSensGripMultiplier", "LateralFrictionNoMultis",
                    "LongitudinalFrictionNoMultis", "TotalFrictionNoMultis" } } },
                { "WF_EngineDataOffset", new Layout { Chunk = "WF_EngineDataChunks", Fields = new[] {
                    "EngineTorqueLbFt", "EnginePowerKW", "EnginePowerHP", "EnginePowerPS", "EnginePowerBHP" } } },
                { "WF_BodyRotationDataOffset", new Layout { Chunk = "WF_BodyRotationChunks", Fields = new[] {
                    "PitchRad", "PitchDeg", "YawRad", "YawDeg", "RollRad", "RollDeg" } } },
                { "WF_BodyAccelDataOffset", new Layout { Chunk = "WF_BodyAccelDataChunks", Fields = new[] {
                    "XAccelerationLocal", "YAccelerationLocal", "Body_ZAccelerationLocal",
                    "XZAccelerationAngleRad", "XZAccelerationAngleDeg", "XZAcceleration",
                    "XYZAcceleration", "XG", "YG", "ZG", "XZG", "XYZG", "XZGAngleRad",
                    "Body_XZGAngleDeg" } } },
                { "WF_AeroDataOffset", new Layout { Chunk = "WF_AeroDataChunks", Fields = new[] {
                    "XDragLocal", "YDragLocal", "ZDragLocal" } } }
            };

        private static readonly Dictionary<string, string[]> BuiltInNames =
            new Dictionary<string, string[]>(StringComparer.Ordinal);

        static CalculatedTelemetry()
        {
            foreach (var entry in Layouts)
            {
                Layout layout = entry.Value;
                BuiltInNames.Add(entry.Key, (string[])layout.Fields.Clone());
                layout.Indexes = new Dictionary<string, int>(StringComparer.Ordinal);
                for (int i = 0; i < layout.Fields.Length; i++)
                    layout.Indexes.Add(layout.Fields[i], i);
            }
        }

        /// <summary>Extend the original calculated layouts using JSON field definitions.
        /// Existing built-ins remain available for schema 1 and older schema 2 profiles.</summary>
        public static void Configure(IDictionary<string, List<string>> configured)
        {
            var next = new Dictionary<string, Layout>(StringComparer.Ordinal);
            foreach (var entry in BuiltInNames)
                next.Add(entry.Key, Build(entry.Key, entry.Value));
            if (configured != null)
                foreach (var entry in configured)
                {
                    string[] current = next.TryGetValue(entry.Key, out Layout layout)
                        ? layout.Fields : Array.Empty<string>();
                    string[] merged = current.Concat(entry.Value)
                        .Distinct(StringComparer.Ordinal).ToArray();
                    next[entry.Key] = Build(entry.Key, merged);
                }
            Layouts.Clear();
            foreach (var entry in next) Layouts.Add(entry.Key, entry.Value);
        }

        private static Layout Build(string group, string[] names)
        {
            string chunk = GameMemoryConfig.ChunkForFieldGroup(group);
            var indexes = new Dictionary<string, int>(StringComparer.Ordinal);
            for (int i = 0; i < names.Length; i++) indexes.Add(names[i], i);
            return new Layout { Chunk = chunk, Fields = names, Indexes = indexes };
        }

        public static IEnumerable<string> Groups => Layouts.Keys;

        public static IReadOnlyList<string> Names(string group) =>
            Layouts.TryGetValue(group, out Layout layout) ? layout.Fields : Array.Empty<string>();

        internal static bool IsBuiltIn(string group, string member) =>
            BuiltInNames.TryGetValue(group, out string[] names) &&
            names.Contains(member, StringComparer.Ordinal);

        public static bool IsCalculated(string group, string member) =>
            Layouts.TryGetValue(group, out Layout layout) &&
            layout.Indexes.ContainsKey(member);

        public static bool TryDataIndex(string group, string member, out int index)
        {
            if (Layouts.TryGetValue(group, out Layout layout))
            {
                if (layout.Indexes.TryGetValue(member, out int position))
                {
                    index = layout.Chunk == null ? -1 :
                        checked(GameMemoryConfig.Int(layout.Chunk, "ChunkSize") / sizeof(float) + position);
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}
