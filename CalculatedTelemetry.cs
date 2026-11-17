using System;
using System.Collections.Generic;

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

        static CalculatedTelemetry()
        {
            foreach (Layout layout in Layouts.Values)
            {
                layout.Indexes = new Dictionary<string, int>(StringComparer.Ordinal);
                for (int i = 0; i < layout.Fields.Length; i++)
                    layout.Indexes.Add(layout.Fields[i], i);
            }
        }

        public static IEnumerable<string> Groups => Layouts.Keys;

        public static IReadOnlyList<string> Names(string group) =>
            Layouts.TryGetValue(group, out Layout layout) ? layout.Fields : Array.Empty<string>();

        public static bool IsCalculated(string group, string member) =>
            Layouts.TryGetValue(group, out Layout layout) &&
            layout.Indexes.ContainsKey(member);

        public static bool TryDataIndex(string group, string member, out int index)
        {
            if (Layouts.TryGetValue(group, out Layout layout))
            {
                if (layout.Indexes.TryGetValue(member, out int position))
                {
                    index = checked(GameMemoryConfig.Int(layout.Chunk, "ChunkSize") / sizeof(float) + position);
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}
