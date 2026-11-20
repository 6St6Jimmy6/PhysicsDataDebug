using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Public names for logging, CSV headers and chart selectors. Never rename
    /// Wreckfest memory-offset keys: those are stable identifiers used by the reader.
    /// In schema 2, category prefixes and per-field aliases customize these names;
    /// schema 1 still accepts telemetryPrefixes/telemetryAliases.
    /// </summary>
    internal static class TelemetryNames
    {
        internal static readonly string[] Wheels = { "FL", "FR", "RL", "RR" };
        private static readonly string[] ExplicitPrefixes =
            { "FL_", "FR_", "RL_", "RR_", "ENG_", "GBX_", "DIFF_",
              "BODY_", "ACC_", "AERO_", "VEH_", "ENV_", "TIME_" };
        /// <summary>Only names with a complete public prefix select a different
        /// source. Formula names such as WLF_LateralGrip and Body_ZAccelerationLocal
        /// are local member names, not category selectors.</summary>
        internal static bool HasExplicitPrefix(string name) =>
            name != null && ExplicitPrefixes.Any(prefix =>
                name.StartsWith(prefix, StringComparison.Ordinal));
        internal static bool IsWheelGroup(string group) =>
            group == "WF_TireDataOffset" || group == "WF_Suspension1DataOffset" ||
            group == "WF_SuspensionGeometryDataOffset" || group == "WF_Suspension2DataOffset";

        internal static string PrefixForGroup(string group)
        {
            if (GameMemoryConfig.TelemetryPrefixes.TryGetValue(group, out string prefix)) return prefix;
            switch (group)
            {
                case "WF_TimeDataOffset": return "TIME";
                case "WF_EngineDataOffset": return "ENG";
                case "WF_DifferentialDataOffset": return "DIFF";
                case "WF_BodyRotationDataOffset": return "BODY";
                case "WF_BodyAccelDataOffset": return "ACC";
                case "WF_AeroDataOffset": return "AERO";
                case "WF_MassDataOffset": return "VEH";
                default: return IsWheelGroup(group) ? "WHEEL" : "VEH";
            }
        }

        internal static string MemberAlias(string group, string member)
        {
            if (GameMemoryConfig.TelemetryAliases.TryGetValue(group + "." + member,
                out string alias)) return alias;
            if (group == "WF_EngineDataOffset" && member == "EngineRPM") return "RPM";
            if (group == "WF_EngineDataOffset" && member == "Speed") return "TravelSpeed";
            if (group == "WF_BodyRotationDataOffset" && member.StartsWith("BodyM", StringComparison.Ordinal))
                return member.Substring(4);
            if (group == "WF_DifferentialDataOffset" && member.StartsWith("Differential", StringComparison.Ordinal))
                return member.Substring("Differential".Length);
            if (group == "WF_BodyAccelDataOffset" && member.StartsWith("Body_", StringComparison.Ordinal))
                return member.Substring(5);
            return member;
        }

        internal static string Name(string group, string member, string wheel = null)
        {
            string category = PrefixForGroup(group);
            // Speed is exposed in the engine memory chunk, but it describes the vehicle.
            if (group == "WF_EngineDataOffset" && member == "Speed") category = "VEH";
            if (category == "WHEEL")
            {
                if (string.IsNullOrEmpty(wheel) || !Wheels.Contains(wheel))
                    throw new ArgumentException("Wheel field requires FL, FR, RL or RR.", nameof(wheel));
                category = wheel;
            }
            return category + "_" + MemberAlias(group, member);
        }

        /// <summary>
        /// Return the one public, category-prefixed name for a field. This is a
        /// display/import migration layer, not a renaming of memory offset keys.
        /// Old separate-wheel logs infer the wheel from their filename.
        /// Unknown third-party CSV fields use VEH_ instead of appearing unprefixed.
        /// </summary>
        internal static string Canonicalize(string field, string sourceWheel = "FL")
        {
            if (string.IsNullOrWhiteSpace(field)) return field;
            field = field.Trim();
            if (string.Equals(field, "None", StringComparison.OrdinalIgnoreCase)) return "None";
            if (string.IsNullOrEmpty(sourceWheel) || !Wheels.Contains(sourceWheel)) sourceWheel = "FL";

            // Match an existing public name first. This also preserves the
            // longer disambiguated names of colliding suspension measurements.
            foreach (LogData.Column column in LogData.AllColumns)
                if (string.Equals(column.Header, field, StringComparison.OrdinalIgnoreCase))
                    return column.Header;

            // Handle explicit wheel names from logs and old saved settings,
            // including older aliases such as FL_TireDataMember.
            foreach (string wheel in Wheels)
                if (field.StartsWith(wheel + "_", StringComparison.OrdinalIgnoreCase))
                    return FromMember(field.Substring(wheel.Length + 1), wheel, true);

            // Other already-prefixed fields remain namespaced (even if a
            // user-provided JSON adds a field this version doesn't know).
            foreach (string prefix in new[] { "ENG", "GBX", "DIFF", "BODY", "ACC", "AERO", "VEH", "ENV", "TIME" })
                if (field.StartsWith(prefix + "_", StringComparison.OrdinalIgnoreCase))
                {
                    string suffix = field.Substring(prefix.Length + 1);
                    foreach (LogData.Column column in LogData.AllColumns)
                        if (column.Wheel == null &&
                            string.Equals(column.Member, suffix, StringComparison.OrdinalIgnoreCase) &&
                            column.Header.StartsWith(prefix + "_", StringComparison.OrdinalIgnoreCase))
                            return column.Header;
                    return prefix + "_" + suffix;
                }

            return FromMember(field, sourceWheel, false);
        }

        private static string FromMember(string member, string wheel, bool requireWheel)
        {
            // Prefer an exact raw-name match. A global field is never repeated
            // once per wheel; old wheel data must retain its source channel.
            foreach (LogData.Column column in LogData.AllColumns)
                if (string.Equals(column.Member, member, StringComparison.OrdinalIgnoreCase) &&
                    ((requireWheel && column.Wheel == wheel) ||
                     (!requireWheel && column.Wheel == null)))
                    return column.Header;

            foreach (LogData.Column column in LogData.AllColumns)
                if (string.Equals(column.Member, member, StringComparison.OrdinalIgnoreCase) &&
                    column.Wheel == wheel) return column.Header;
            // A few old logs already used the post-alias suffix without a
            // category. Accept those when it identifies one field.
            foreach (LogData.Column column in LogData.AllColumns)
                if (string.Equals(column.Header.Substring(column.Header.IndexOf('_') + 1),
                    member, StringComparison.OrdinalIgnoreCase) &&
                    ((requireWheel && column.Wheel == wheel) ||
                     (!requireWheel && column.Wheel == null)))
                    return column.Header;
            foreach (LogData.Column column in LogData.AllColumns)
                if (string.Equals(column.Header.Substring(column.Header.IndexOf('_') + 1),
                    member, StringComparison.OrdinalIgnoreCase) && column.Wheel == wheel)
                    return column.Header;
            return (requireWheel ? wheel : "VEH") + "_" + member;
        }

        internal static string WheelFromFilename(string path)
        {
            string file = System.IO.Path.GetFileNameWithoutExtension(path) ?? "";
            if (file.StartsWith("FrontLeft", StringComparison.OrdinalIgnoreCase) ||
                file.StartsWith("FL_", StringComparison.OrdinalIgnoreCase)) return "FL";
            if (file.StartsWith("FrontRight", StringComparison.OrdinalIgnoreCase) ||
                file.StartsWith("FR_", StringComparison.OrdinalIgnoreCase)) return "FR";
            if (file.StartsWith("RearLeft", StringComparison.OrdinalIgnoreCase) ||
                file.StartsWith("RL_", StringComparison.OrdinalIgnoreCase)) return "RL";
            if (file.StartsWith("RearRight", StringComparison.OrdinalIgnoreCase) ||
                file.StartsWith("RR_", StringComparison.OrdinalIgnoreCase)) return "RR";
            return "FL";
        }

        internal static string RelativeWheelName(string field)
        {
            if (field != null)
                foreach (string wheel in Wheels)
                    if (field.StartsWith(wheel + "_", StringComparison.OrdinalIgnoreCase))
                        return field.Substring(wheel.Length + 1);
            return field;
        }

        internal static string CollisionGroup(string group)
        {
            switch (group)
            {
                case "WF_TireDataOffset": return "Tire";
                case "WF_Suspension1DataOffset": return "Suspension1";
                case "WF_Suspension2DataOffset": return "Suspension2";
                case "WF_SuspensionGeometryDataOffset": return "Geometry";
                case "WF_EngineDataOffset": return "Engine";
                case "WF_DifferentialDataOffset": return "Differential";
                case "WF_MassDataOffset": return "Mass";
                default: return "Source";
            }
        }
    }
}
