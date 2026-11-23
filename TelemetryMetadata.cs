using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Presentation metadata from schema 2. Neither names nor units change the
    /// canonical telemetry headers or the memory offsets used by the reader.
    /// All parsing is staged before replacing the active metadata cache.
    /// </summary>
    internal static class TelemetryMetadata
    {
        internal sealed class FieldInfo
        {
            internal string DisplayName;
            internal string Unit;
            internal string UnitName;
        }
        private static Dictionary<string, FieldInfo> fields =
            new Dictionary<string, FieldInfo>(StringComparer.Ordinal);

        private static readonly Dictionary<string, string> UnitNames =
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { "N", "newtons" }, { "Nm", "newton metres" },
                { "kg", "kilograms" }, { "kg·m²", "kilogram square metres" },
                { "m", "metres" }, { "m²", "square metres" },
                { "m/s", "metres per second" },
                { "m/s²", "metres per second squared" },
                { "rad", "radians" }, { "deg", "degrees" },
                { "rad/s", "radians per second" },
                { "rpm", "revolutions per minute" },
                { "W", "watts" }, { "kW", "kilowatts" },
                { "hp", "horsepower" }, { "PS", "metric horsepower" },
                { "°C", "degrees Celsius" }, { "K", "kelvin" },
                { "ms", "milliseconds" },
                { "g", "multiples of standard gravity" },
                { "N/m", "newtons per metre" },
                { "N·s/m", "newton seconds per metre" },
                { "lb·ft", "pound-feet" }
            };

        internal static FieldInfo Get(string group, string member)
        {
            if (fields.TryGetValue(group + "." + member, out FieldInfo info)) return info;
            return new FieldInfo { DisplayName = SplitName(member), Unit = "", UnitName = "" };
        }

        private static string SplitName(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return Regex.Replace(Regex.Replace(text.Replace('_', ' '),
                "([a-z0-9])([A-Z])", "$1 $2"), "([A-Z])([A-Z][a-z])", "$1 $2");
        }

        internal static void LoadFromFile(string fileName)
        {
            var staged = new Dictionary<string, FieldInfo>(StringComparer.Ordinal);
            if (File.Exists(fileName))
            {
                var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                var root = serializer.DeserializeObject(File.ReadAllText(fileName)) as IDictionary<string, object>;
                if (root != null && root.TryGetValue("categories", out object allCategories) &&
                    allCategories is IDictionary<string, object> categories)
                {
                    foreach (var category in categories)
                    {
                        var section = category.Value as IDictionary<string, object>;
                        if (section == null) continue;
                        // Use the exact category -> stable data-group mapping.
                        string group = GroupName(category.Key);
                        if (group == null) continue;
                        foreach (string kind in new[] { "fields", "calculated" })
                        {
                            if (!section.TryGetValue(kind, out object membersRaw) ||
                                !(membersRaw is IDictionary<string, object> members)) continue;
                            foreach (var member in members)
                            {
                                var value = member.Value as IDictionary<string, object>;
                                var info = new FieldInfo { DisplayName = SplitName(member.Key), Unit = "", UnitName = "" };
                                if (value != null)
                                {
                                    if (value.TryGetValue("displayName", out object display) && display != null &&
                                        !string.IsNullOrWhiteSpace(Convert.ToString(display)))
                                        info.DisplayName = Convert.ToString(display);
                                    if (value.TryGetValue("unit", out object unit) && unit != null)
                                        info.Unit = Convert.ToString(unit);
                                    if (value.TryGetValue("unitName", out object full) && full != null)
                                        info.UnitName = Convert.ToString(full);
                                    else if (UnitNames.TryGetValue(info.Unit, out string expanded))
                                        info.UnitName = expanded;
                                }
                                staged[group + "." + member.Key] = info;
                            }
                        }
                    }
                }
            }
            fields = staged;
        }

        private static string GroupName(string category)
        {
            switch (category)
            {
                case "tire": return "WF_TireDataOffset";
                case "suspension1": return "WF_Suspension1DataOffset";
                case "suspension2": return "WF_Suspension2DataOffset";
                case "suspensionGeometry": return "WF_SuspensionGeometryDataOffset";
                case "bodyMass": return "WF_MassDataOffset";
                case "bodyRotation": return "WF_BodyRotationDataOffset";
                case "bodyAcceleration": return "WF_BodyAccelDataOffset";
                case "aerodynamics": return "WF_AeroDataOffset";
                case "engine": return "WF_EngineDataOffset";
                case "differential": return "WF_DifferentialDataOffset";
                case "timing": return "WF_TimeDataOffset";
                default: return null;
            }
        }
    }
}
