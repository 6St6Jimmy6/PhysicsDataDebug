using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Physics_Data_Debug
{
    internal sealed class LogRangeFilter
    {
        public bool Enabled { get; set; }
        public string Field { get; set; } = "None";
        public bool Outside { get; set; }
        public bool Absolute { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public LogRangeFilter Copy() => (LogRangeFilter)MemberwiseClone();
    }

    /// <summary>Values applied from FormLogSettings; a logging session captures these at Start.</summary>
    internal static class LogSettings
    {
        private static HashSet<string> selectedFields = new HashSet<string>(StringComparer.Ordinal);
        // The original 29-field logger enabled these measurements by default.
        // New JSON-only fields are available for selection, not silently logged.
        private static readonly HashSet<string> initialNames = new HashSet<string>(StringComparer.Ordinal)
        {
            "RaceTime", "TravelSpeed", "AngularVelocity", "VerticalLoad", "VerticalDeflection",
            "LoadedRadius", "EffectiveRadius", "ContactLength", "CurrentContactBrakeTorque",
            "CurrentContactBrakeTorqueMax", "SteerAngleDeg", "CamberAngleDeg", "LateralLoad",
            "SlipAngleDeg", "LateralFriction", "LateralSlipSpeed", "LongitudinalLoad",
            "SlipRatio", "LongitudinalFriction", "LongitudinalSlipSpeed", "TreadTemperature",
            "InnerTemperature", "TotalFriction", "TotalFrictionAngleDeg", "SuspensionLength",
            "SuspensionVelocity", "XG", "YG", "ZG", "XYZG"
        };
        private static bool selectionsLoaded;

        public static bool IsEnabled(string key, string member) => selectionsLoaded
            ? selectedFields.Contains(key) : initialNames.Contains(member);

        public static void SetSelected(IEnumerable<string> keys)
        {
            selectedFields = new HashSet<string>(keys, StringComparer.Ordinal);
            selectionsLoaded = true;
        }

        public static string LogFileSaveLocationFolder { get; set; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PhysicsDataDebug", "Logs");
        public const char DefaultDelimiter = ';';
        public static char Delimiter { get; set; } = DefaultDelimiter;
        public static int TimeLimitSeconds { get; set; } // 0 means unlimited
        public static long TotalSizeLimitBytes { get; set; } // 0 means unlimited; combined across four files
        public static LogRangeFilter[] Filters { get; set; } = Enumerable.Range(0, 10)
            .Select(i => new LogRangeFilter()).ToArray();
        public static string ChartPlotterLocation { get; set; } = "";
    }
}
