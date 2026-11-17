using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Physics_Data_Debug
{
    /// <summary>Every telemetry field exposed by the active game-memory JSON, including calculated fields.</summary>
    internal static class LogData
    {
        internal sealed class Column
        {
            public string Key { get; }
            public string DisplayName { get; }
            public string Header { get; internal set; }
            public string Member { get; }
            public GameMemoryField Field { get; }
            private readonly string prefix;

            public Column(string group, string displayGroup, string member, string targetPrefix)
            {
                Key = group + "." + member;
                Member = member;
                // When JSON exposes a Body_* alias, show that exact selection
                // name; otherwise use the raw or calculated member verbatim.
                string selectionName = targetPrefix == TelemetryPrefix.Body &&
                    GameMemoryConfig.TelemetrySelections.Contains("Body_" + member)
                    ? "Body_" + member : member;
                DisplayName = displayGroup + " / " + selectionName;
                Header = selectionName;
                Field = GameMemoryConfig.Field(group, member);
                prefix = targetPrefix;
            }

            public object Read(string wheel)
            {
                try { return LiveData.GetFullListDataValue(prefix == null ? wheel : prefix, Field); }
                catch (KeyNotFoundException) { return double.NaN; }
                catch (InvalidOperationException) { return double.NaN; }
            }

            public double ReadDouble(string wheel) => Convert.ToDouble(Read(wheel), CultureInfo.InvariantCulture);
            public override string ToString() => DisplayName;
        }

        private static readonly (string Group, string Label, string Prefix)[] Categories =
        {
            ("WF_TimeDataOffset", "Timing", TelemetryPrefix.Timing),
            ("WF_BodyRotationDataOffset", "Body rotation", TelemetryPrefix.Body),
            ("WF_BodyAccelDataOffset", "Body acceleration", TelemetryPrefix.Body),
            ("WF_AeroDataOffset", "Aerodynamics", TelemetryPrefix.Body),
            ("WF_MassDataOffset", "Body mass", TelemetryPrefix.Body),
            ("WF_EngineDataOffset", "Engine", TelemetryPrefix.Powertrain),
            ("WF_DifferentialDataOffset", "Differential", TelemetryPrefix.Powertrain),
            ("WF_TireDataOffset", "Tire", null),
            ("WF_Suspension1DataOffset", "Suspension 1", null),
            ("WF_SuspensionGeometryDataOffset", "Suspension geometry", null),
            ("WF_Suspension2DataOffset", "Suspension 2", null)
        };

        private static Column[] columns;
        private static Dictionary<string, Column> byDisplay;

        public static IReadOnlyList<Column> AllColumns
        {
            get
            {
                if (columns == null) RebuildColumns();
                return columns;
            }
        }

        // Call after a game-memory JSON profile is switched, while sampling is stopped.
        public static void RebuildColumns()
        {
            var result = new List<Column>();
            foreach (var category in Categories)
                foreach (string member in GameMemoryConfig.Members(category.Group))
                    result.Add(new Column(category.Group, category.Label, member, category.Prefix));
            foreach (var group in result.GroupBy(c => c.Header, StringComparer.Ordinal))
                if (group.Count() > 1)
                    foreach (Column col in group)
                        col.Header = col.DisplayName.Substring(0, col.DisplayName.IndexOf(" / ", StringComparison.Ordinal))
                            .Replace(" ", "") + "_" + col.Member;
            columns = result.ToArray();
            byDisplay = columns.ToDictionary(c => c.DisplayName, StringComparer.Ordinal);
        }

        public static Column FindDisplay(string display)
        {
            if (columns == null) RebuildColumns();
            return display != null && byDisplay.TryGetValue(display, out Column col) ? col : null;
        }

        public static Column[] SelectedColumns() => AllColumns.Where(c =>
            LogSettings.IsEnabled(c.Key, c.Member)).ToArray();

        public static string HeaderLine(IEnumerable<Column> selected, char delimiter) =>
            string.Join(delimiter.ToString(), selected.Select(c => c.Header));

        public static string ValuesLine(string wheel, IEnumerable<Column> selected, char delimiter) =>
            string.Join(delimiter.ToString(), selected.Select(c =>
                Convert.ToString(c.Read(wheel), CultureInfo.InvariantCulture)));
    }
}
