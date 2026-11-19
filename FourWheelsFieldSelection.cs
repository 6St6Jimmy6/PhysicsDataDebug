using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Four Wheels axes and filters choose a measurement, not four separate
    /// series. Multiple-wheel layouts display one relative wheel field;
    /// a single-wheel layout identifies its selected wheel explicitly.
    /// Logged/CSV columns still retain their permanent FL_/FR_/RL_/RR_ names.
    /// </summary>
    internal static class FourWheelsFieldSelection
    {
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

        internal static IEnumerable<string> Options(string layout)
        {
            string onlyWheel = WheelForLayout(layout);
            yield return "None";

            var encountered = new HashSet<string>(StringComparer.Ordinal);
            foreach (LogData.Column column in LogData.AllColumns)
            {
                // Global values are plotted identically for each wheel.
                if (column.Wheel != null && onlyWheel != null &&
                    column.Wheel != onlyWheel)
                    continue;

                string display = column.Wheel == null || onlyWheel != null
                    ? column.Header
                    : TelemetryNames.RelativeWheelName(column.Header);

                if (encountered.Add(display))
                    yield return display;
            }
        }

        /// <summary>
        /// Migrate a previous UI selection to the visible choices. In a
        /// multi-wheel view FL_SlipRatio becomes SlipRatio; in an FR-only
        /// view it becomes FR_SlipRatio. Shared names stay namespaced.
        /// </summary>
        internal static string MatchAvailable(string saved, IEnumerable<string> options)
        {
            var available = new HashSet<string>(options, StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(saved)) return "None";

            saved = saved.Trim();
            if (available.Contains(saved))
                return available.First(name => string.Equals(name, saved, StringComparison.OrdinalIgnoreCase));

            string canonical = TelemetryNames.Canonicalize(saved);
            if (available.Contains(canonical))
                return available.First(name => string.Equals(name, canonical, StringComparison.OrdinalIgnoreCase));

            string relative = TelemetryNames.RelativeWheelName(canonical);
            if (!string.Equals(relative, canonical, StringComparison.Ordinal))
            {
                if (available.Contains(relative))
                    return available.First(name => string.Equals(name, relative, StringComparison.OrdinalIgnoreCase));
                foreach (string wheel in TelemetryNames.Wheels)
                {
                    string candidate = wheel + "_" + relative;
                    if (available.Contains(candidate))
                        return available.First(name => string.Equals(name, candidate, StringComparison.OrdinalIgnoreCase));
                }
            }

            return "None";
        }
    }
}
