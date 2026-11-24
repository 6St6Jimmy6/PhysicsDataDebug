using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Ordered calculated-field names, including legacy built-ins and JSON extensions.
    /// Calculated DataItems are evaluated lazily; they have no raw memory index.
    /// </summary>
    internal static class CalculatedTelemetry
    {
        private static readonly Dictionary<string, string[]> BuiltInNames =
            new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                { "WF_TireDataOffset", new[] {
                    "CasterAngleRad", "CasterAngleDeg", "CamberAngleRad", "CamberAngleDeg",
                    "SteerAngleRad", "SteerAngleDeg", "LateralFriction", "LongitudinalFriction",
                    "TotalFriction", "TotalFrictionAngleDeg", "SlipAngleDeg", "RollingResistance",
                    "PneumaticTrail", "TreadTemperatureKelvins", "Log10aT", "LateralAdhesionGrip",
                    "LateralMicroGrip", "LateralMacroGrip", "WLF_LateralSlidingFrictionGripMultiplier",
                    "LongitudinalAdhesionGrip", "LongitudinalMicroGrip", "LongitudinalMacroGrip",
                    "WLF_LongitudinalSlidingFrictionGripMultiplier", "LateralLoadSensGripMultiplier",
                    "LongitudinalLoadSensGripMultiplier", "LateralFrictionNoMultis",
                    "LongitudinalFrictionNoMultis", "TotalFrictionNoMultis" } },
                { "WF_EngineDataOffset", new[] {
                    "EngineTorqueLbFt", "EnginePowerKW", "EnginePowerHP", "EnginePowerPS", "EnginePowerBHP" } },
                { "WF_BodyRotationDataOffset", new[] {
                    "PitchRad", "PitchDeg", "YawRad", "YawDeg", "RollRad", "RollDeg" } },
                { "WF_BodyAccelDataOffset", new[] {
                    "XAccelerationLocal", "YAccelerationLocal", "Body_ZAccelerationLocal",
                    "XZAccelerationAngleRad", "XZAccelerationAngleDeg", "XZAcceleration",
                    "XYZAcceleration", "XG", "YG", "ZG", "XZG", "XYZG", "XZGAngleRad",
                    "Body_XZGAngleDeg" } },
                { "WF_AeroDataOffset", new[] {
                    "XDragLocal", "YDragLocal", "ZDragLocal" } }
            };

        // Configuration replaces the entire snapshot, so a failed config load
        // can restore the previous reference without copying or rebuilding it.
        private static IReadOnlyDictionary<string, string[]> layouts = BuiltInNames;

        internal static IReadOnlyDictionary<string, string[]> Snapshot() => layouts;
        internal static void Restore(IReadOnlyDictionary<string, string[]> snapshot) => layouts = snapshot;

        public static void Configure(IDictionary<string, List<string>> configured)
        {
            var next = new Dictionary<string, string[]>(BuiltInNames, StringComparer.Ordinal);
            if (configured != null)
                foreach (var entry in configured)
                {
                    string[] current = next.TryGetValue(entry.Key, out string[] names)
                        ? names : Array.Empty<string>();
                    next[entry.Key] = current.Concat(entry.Value).Distinct(StringComparer.Ordinal).ToArray();
                }
            layouts = next;
        }

        public static IEnumerable<string> Groups => layouts.Keys;

        public static IReadOnlyList<string> Names(string group) =>
            layouts.TryGetValue(group, out string[] names) ? names : Array.Empty<string>();

        internal static bool IsBuiltIn(string group, string member) =>
            BuiltInNames.TryGetValue(group, out string[] names) && Array.IndexOf(names, member) >= 0;

        public static bool IsCalculated(string group, string member) =>
            layouts.TryGetValue(group, out string[] names) && Array.IndexOf(names, member) >= 0;
    }
}
