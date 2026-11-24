using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>Canonical, uniquely named selectable columns for a single synchronized telemetry file.</summary>
    internal static class LogData
    {
        internal sealed class Column
        {
            public string Key { get; }
            public string DisplayName => Header;
            public string Header { get; internal set; }
            public string Member { get; }
            public string Group { get; }
            public string Wheel { get; }
            public GameMemoryField Field { get; }
            public string OldDisplay { get; }
            private readonly string sourcePrefix;

            internal Column(string group, string label, string member, string wheel)
            {
                Group = group;
                Member = member;
                Wheel = wheel;
                Key = group + "." + member + (wheel == null ? "" : "." + wheel);
                Header = TelemetryNames.Name(group, member, wheel);
                OldDisplay = label + " / " + member;
                Field = GameMemoryConfig.Field(group, member);
                sourcePrefix = wheel ?? (group == "WF_TimeDataOffset" ? TelemetryPrefix.Timing :
                    (group == "WF_EngineDataOffset" || group == "WF_DifferentialDataOffset"
                    ? TelemetryPrefix.Powertrain : TelemetryPrefix.Body));
            }

            public object Read()
            {
                try { return LiveData.GetFullListObjectValue(sourcePrefix, Field); }
                catch (KeyNotFoundException) { return double.NaN; }
                catch (InvalidOperationException) { return double.NaN; }
            }

            public double ReadDouble() => Convert.ToDouble(Read(), CultureInfo.InvariantCulture);
            public override string ToString() => DisplayName;
        }

        private static readonly (string Group, string Label)[] Categories =
        {
            ("WF_TimeDataOffset", "Timing"),
            ("WF_BodyRotationDataOffset", "Body rotation"),
            ("WF_BodyAccelDataOffset", "Body acceleration"),
            ("WF_AeroDataOffset", "Aerodynamics"),
            ("WF_MassDataOffset", "Body mass"),
            ("WF_EngineDataOffset", "Engine"),
            ("WF_DifferentialDataOffset", "Differential"),
            ("WF_TireDataOffset", "Tire"),
            ("WF_Suspension1DataOffset", "Suspension 1"),
            ("WF_SuspensionGeometryDataOffset", "Suspension geometry"),
            ("WF_Suspension2DataOffset", "Suspension 2")
        };
        private static Column[] columns;
        private static Dictionary<string, Column> byDisplay;

        public static IReadOnlyList<Column> AllColumns
        {
            get { if (columns == null) RebuildColumns(); return columns; }
        }

        public static void RebuildColumns()
        {
            var result = new List<Column>();
            foreach (var category in Categories)
                foreach (string member in GameMemoryConfig.Members(category.Group))
                {
                    if (TelemetryNames.IsWheelGroup(category.Group))
                    {
                        foreach (string wheel in TelemetryNames.Wheels)
                            result.Add(new Column(category.Group, category.Label, member, wheel));
                    }
                    else result.Add(new Column(category.Group, category.Label, member, null));
                }
            // The two suspension blocks contain fields with identical names.
            // Disambiguate only collisions; simple names stay FL_SlipRatio etc.
            foreach (var duplicate in result.GroupBy(c => c.Header, StringComparer.Ordinal)
                .Where(g => g.Count() > 1))
                foreach (Column column in duplicate)
                {
                    string prefix = column.Wheel ?? TelemetryNames.PrefixForGroup(column.Group);
                    column.Header = prefix + "_" + TelemetryNames.CollisionGroup(column.Group) +
                        TelemetryNames.MemberAlias(column.Group, column.Member);
                }
            // Custom JSON aliases must not be allowed to create an ambiguous log header.
            var collisions = result.GroupBy(c => c.Header, StringComparer.Ordinal).Where(g => g.Count() > 1).ToList();
            if (collisions.Count > 0)
                throw new InvalidOperationException("Duplicate telemetry header: " + collisions[0].Key +
                    ". Adjust telemetryAliases in WreckfestGameMemoryConfig.json.");
            columns = result.ToArray();
            byDisplay = columns.ToDictionary(c => c.Header, StringComparer.Ordinal);
        }

        public static Column FindDisplay(string display)
        {
            if (columns == null) RebuildColumns();
            if (display != null && byDisplay.TryGetValue(display, out Column column)) return column;
            // Migrates both the old group/field labels and unprefixed names.
            if (!string.IsNullOrWhiteSpace(display))
            {
                string canonical = TelemetryNames.Canonicalize(display);
                if (byDisplay.TryGetValue(canonical, out column)) return column;
            }
            // Upgrade old saved filter labels. Without a wheel name they now
            // resolve to FL_*, as an explicit, predictable migration default.
            return columns.FirstOrDefault(c => c.OldDisplay == display &&
                (c.Wheel == null || c.Wheel == "FL"));
        }

        public static Column[] SelectedColumns() => AllColumns.Where(c =>
            LogSettings.IsEnabled(c.Key, c.Member)).ToArray();

        public static string HeaderLine(IEnumerable<Column> selected, char delimiter) =>
            string.Join(delimiter.ToString(), selected.Select(c => c.Header));

    }
}
