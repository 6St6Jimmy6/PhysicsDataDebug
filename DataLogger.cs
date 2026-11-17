using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Four wheel-specific files per session, one common start timestamp.
    /// Both limits are global to the session: wall-clock elapsed time and total
    /// UTF-8 bytes written to all four logs (including their headers).
    /// </summary>
    public sealed class DataLogger : IDisposable
    {
        private static readonly string[] WheelPrefixes =
            { TelemetryPrefix.FL, TelemetryPrefix.FR, TelemetryPrefix.RL, TelemetryPrefix.RR };
        private static readonly string[] WheelFileNames =
            { "FrontLeft", "FrontRight", "RearLeft", "RearRight" };
        private readonly Dictionary<string, StreamWriter> writers =
            new Dictionary<string, StreamWriter>(StringComparer.Ordinal);
        private readonly Stopwatch timer = new Stopwatch();
        private LogData.Column[] columns;
        private LogRangeFilter[] filters;
        private char delimiter;
        private int limitSeconds;
        private long limitBytes;
        private long writtenBytes;
        public string LastStopReason { get; private set; } = "";
        public bool IsRunning => timer.IsRunning;

        public void StartSession()
        {
            StopSession();
            columns = LogData.SelectedColumns();
            if (columns.Length == 0)
                throw new InvalidOperationException("Select at least one telemetry parameter to log.");
            var active = new List<LogRangeFilter>();
            foreach (LogRangeFilter setting in LogSettings.Filters.Where(f => f.Enabled))
            {
                if (LogData.FindDisplay(setting.Field) == null)
                    throw new InvalidOperationException("Unknown log filter field: " + setting.Field);
                if (setting.Minimum > setting.Maximum || double.IsNaN(setting.Minimum) ||
                    double.IsNaN(setting.Maximum) || double.IsInfinity(setting.Minimum) ||
                    double.IsInfinity(setting.Maximum))
                    throw new InvalidOperationException("Invalid range for " + setting.Field);
                active.Add(setting.Copy());
            }
            filters = active.ToArray();
            delimiter = LogSettings.Delimiter;
            limitSeconds = LogSettings.TimeLimitSeconds;
            limitBytes = LogSettings.TotalSizeLimitBytes;
            writtenBytes = 0;
            LastStopReason = "";

            string folder = LogSettings.LogFileSaveLocationFolder;
            if (string.IsNullOrWhiteSpace(folder))
                throw new InvalidOperationException("Select a log output folder.");
            Directory.CreateDirectory(folder);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
            string suffix = "";
            int counter = 2;
            while (WheelFileNames.Any(name => File.Exists(Path.Combine(folder,
                       name + "_" + timestamp + suffix + ".txt"))))
                suffix = "_" + (counter++).ToString(CultureInfo.InvariantCulture);

            try
            {
                string header = LogData.HeaderLine(columns, delimiter);
                foreach (string wheel in WheelPrefixes)
                {
                    int i = Array.IndexOf(WheelPrefixes, wheel);
                    string path = Path.Combine(folder, WheelFileNames[i] + "_" + timestamp + suffix + ".txt");
                    // CreateNew protects existing logs even if another process races us.
                    var writer = new StreamWriter(new FileStream(path, FileMode.CreateNew,
                        FileAccess.Write, FileShare.Read), new UTF8Encoding(false)) { AutoFlush = true };
                    writers.Add(wheel, writer);
                    writer.WriteLine(header);
                    writtenBytes += LineBytes(header);
                }
                LiveData.Logging = true;
                timer.Start();
                CheckLimits();
            }
            catch
            {
                StopSession();
                throw;
            }
        }

        public void StopSession(string reason = null)
        {
            timer.Stop();
            foreach (StreamWriter writer in writers.Values) writer.Dispose();
            writers.Clear();
            LiveData.Logging = false;
            if (!string.IsNullOrEmpty(reason)) LastStopReason = reason;
        }

        private long LineBytes(string line) => Encoding.UTF8.GetByteCount(line) + Encoding.UTF8.GetByteCount(Environment.NewLine);

        private void CheckLimits()
        {
            if (limitSeconds > 0 && timer.Elapsed.TotalSeconds >= limitSeconds)
                StopSession("Time limit reached");
            else if (limitBytes > 0 && writtenBytes >= limitBytes)
                StopSession("Combined file size limit reached");
        }

        public void LogToFile()
        {
            if (!LiveData.Logging || !timer.IsRunning) return;
            CheckLimits();
            if (!timer.IsRunning) return;
            foreach (string wheel in WheelPrefixes)
            {
                if (!PassesFilters(wheel)) continue;
                string line = LogData.ValuesLine(wheel, columns, delimiter);
                long size = LineBytes(line);
                if (limitBytes > 0 && writtenBytes + size > limitBytes)
                {
                    StopSession("Combined file size limit reached");
                    return;
                }
                writers[wheel].WriteLine(line);
                writtenBytes += size;
                CheckLimits();
                if (!timer.IsRunning) return;
            }
        }

        private bool PassesFilters(string wheel)
        {
            foreach (LogRangeFilter filter in filters)
            {
                LogData.Column field = LogData.FindDisplay(filter.Field);
                double value = field.ReadDouble(wheel);
                if (filter.Absolute) value = Math.Abs(value);
                bool inside = !double.IsNaN(value) && value >= filter.Minimum && value <= filter.Maximum;
                if (double.IsNaN(value) || double.IsInfinity(value) ||
                    (filter.Outside ? inside : !inside)) return false;
            }
            return true;
        }

        public void Dispose() => StopSession();
    }
}
