using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Chart axes and filters select a measurement, not a particular wheel.
    /// The dataset layout alone chooses which wheel channels are displayed and
    /// which chart area receives them. CSV headers and logging remain prefixed.
    /// </summary>
    internal static class FourWheelsFieldSelection
    {
        internal static readonly string[] Layouts =
        {
            "Separate", "Front/Rear", "Left/Right", "All In One",
            "Front Only", "Rear Only", "Left Only", "Right Only",
            "Front Left", "Front Right", "Rear Left", "Rear Right"
        };

        internal static string WheelForLayout(string layout)
        {
            switch (layout)
            {
                case "Front Left": return "FL";
                case "Front Right": return "FR";
                case "Rear Left": return "RL";
                case "Rear Right": return "RR";
                default: return null;
            }
        }

        internal static IEnumerable<string> WheelsForLayout(string layout)
        {
            switch (layout)
            {
                case "Front Left": return new[] { "FL" };
                case "Front Right": return new[] { "FR" };
                case "Rear Left": return new[] { "RL" };
                case "Rear Right": return new[] { "RR" };
                case "Front Only": return new[] { "FL", "FR" };
                case "Rear Only": return new[] { "RL", "RR" };
                case "Left Only": return new[] { "FL", "RL" };
                case "Right Only": return new[] { "FR", "RR" };
                default: return new[] { "FL", "RL", "FR", "RR" };
            }
        }

        internal static bool IncludesWheel(string layout, string wheel) =>
            wheel == null || WheelsForLayout(layout).Contains(wheel);

        internal static string AreaForLayout(string layout, string wheel)
        {
            if (wheel == null) return "ChartAreaShared";
            switch (layout)
            {
                case "Separate": return "ChartArea" + wheel;
                case "Front/Rear": return wheel == "FL" || wheel == "FR" ?
                    "ChartAreaFront" : "ChartAreaRear";
                case "Left/Right": return wheel == "FL" || wheel == "RL" ?
                    "ChartAreaLeft" : "ChartAreaRight";
                default: return "ChartAreaAllWheels";
            }
        }

        internal static string AreaTitle(string layout, string wheel)
        {
            switch (AreaForLayout(layout, wheel))
            {
                case "ChartAreaFL": return "Front Left";
                case "ChartAreaFR": return "Front Right";
                case "ChartAreaRL": return "Rear Left";
                case "ChartAreaRR": return "Rear Right";
                case "ChartAreaFront": return "Front Tires";
                case "ChartAreaRear": return "Rear Tires";
                case "ChartAreaLeft": return "Left Tires";
                case "ChartAreaRight": return "Right Tires";
                case "ChartAreaShared": return "Shared Vehicle Data";
                default:
                    return WheelForLayout(layout) != null ? layout :
                        layout == "Front Only" || layout == "Rear Only" ||
                        layout == "Left Only" || layout == "Right Only" ? layout : "All Wheels";
            }
        }

        // The layout does not change names in the selection list.
        internal static IEnumerable<string> Options(string layout)
        {
            yield return "None";
            var encountered = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (LogData.Column column in LogData.AllColumns)
            {
                string display = column.Wheel == null ? column.Header :
                    TelemetryNames.RelativeWheelName(column.Header);
                if (encountered.Add(display)) yield return display;
            }
        }

        /// <summary>Normalize old FL_/FR_/RL_/RR_ selections to the same
        /// wheel-relative measurement, regardless of the current chart layout.</summary>
        internal static string MatchAvailable(string saved, IEnumerable<string> options)
        {
            var available = new HashSet<string>(options, StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(saved)) return "None";
            saved = saved.Trim();
            string exact = available.FirstOrDefault(name =>
                string.Equals(name, saved, StringComparison.OrdinalIgnoreCase));
            if (exact != null) return exact;

            string canonical = TelemetryNames.Canonicalize(saved);
            string relative = TelemetryNames.RelativeWheelName(canonical);
            exact = available.FirstOrDefault(name =>
                string.Equals(name, relative, StringComparison.OrdinalIgnoreCase));
            return exact ?? "None";
        }
    }
}
