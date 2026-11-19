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
    /// One synchronized telemetry row per memory sample, wheel fields prefixed
    /// FL/FR/RL/RR and shared fields written once. Both stop limits apply to the
    /// single output file (including its header).
    /// </summary>
    public sealed class DataLogger : IDisposable
    {
        private StreamWriter writer;
        private readonly Stopwatch timer = new Stopwatch();
        private LogData.Column[] columns;
        private LogData.Column[] filterColumns;
        private LogRangeFilter[] filters;
        private char delimiter;
        private int limitSeconds;
        private long limitBytes;
        private long writtenBytes;
        public string CurrentFilePath { get; private set; }
        public string LastStopReason { get; private set; } = "";
        public bool IsRunning => timer.IsRunning;

        public void StartSession()
        {
            StopSession();
            columns = LogData.SelectedColumns();
            if (columns.Length == 0)
                throw new InvalidOperationException("Select at least one telemetry parameter to log.");
            var active = new List<LogRangeFilter>();
            var selectedFilterColumns = new List<LogData.Column>();
            foreach (LogRangeFilter setting in LogSettings.Filters.Where(f => f.Enabled))
            {
                LogData.Column column = LogData.FindDisplay(setting.Field);
                if (column == null)
                    throw new InvalidOperationException("Unknown log filter field: " + setting.Field);
                if (setting.Minimum > setting.Maximum || double.IsNaN(setting.Minimum) ||
                    double.IsNaN(setting.Maximum) || double.IsInfinity(setting.Minimum) ||
                    double.IsInfinity(setting.Maximum))
                    throw new InvalidOperationException("Invalid range for " + setting.Field);
                active.Add(setting.Copy());
                selectedFilterColumns.Add(column);
            }
            filters = active.ToArray();
            filterColumns = selectedFilterColumns.ToArray();
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
            string basename = "Telemetry_" + timestamp;
            string path = Path.Combine(folder, basename + ".txt");
            int counter = 2;
            while (File.Exists(path))
                path = Path.Combine(folder, basename + "_" + (counter++).ToString(CultureInfo.InvariantCulture) + ".txt");
            try
            {
                writer = new StreamWriter(new FileStream(path, FileMode.CreateNew,
                    FileAccess.Write, FileShare.Read), new UTF8Encoding(false)) { AutoFlush = true };
                CurrentFilePath = path;
                string header = LogData.HeaderLine(columns, delimiter);
                writer.WriteLine(header);
                writtenBytes = LineBytes(header);
                LiveData.Logging = true;
                timer.Restart();
                CheckLimits();
            }
            catch { StopSession(); throw; }
        }

        public void StopSession(string reason = null)
        {
            timer.Stop();
            if (writer != null) { writer.Dispose(); writer = null; }
            LiveData.Logging = false;
            if (!string.IsNullOrEmpty(reason)) LastStopReason = reason;
        }

        private static long LineBytes(string line) =>
            Encoding.UTF8.GetByteCount(line) + Encoding.UTF8.GetByteCount(Environment.NewLine);

        private void CheckLimits()
        {
            if (limitSeconds > 0 && timer.Elapsed.TotalSeconds >= limitSeconds)
                StopSession("Time limit reached");
            else if (limitBytes > 0 && writtenBytes >= limitBytes)
                StopSession("File size limit reached");
        }

        public void LogToFile()
        {
            if (!LiveData.Logging || !timer.IsRunning || writer == null) return;
            CheckLimits();
            if (!timer.IsRunning) return;
            for (int i = 0; i < filters.Length; i++)
            {
                double value = filterColumns[i].ReadDouble();
                if (filters[i].Absolute) value = Math.Abs(value);
                bool inside = !double.IsNaN(value) && !double.IsInfinity(value) &&
                    value >= filters[i].Minimum && value <= filters[i].Maximum;
                if (double.IsNaN(value) || double.IsInfinity(value) ||
                    (filters[i].Outside ? inside : !inside)) return;
            }
            string line = LogData.ValuesLine(columns, delimiter);
            long size = LineBytes(line);
            if (limitBytes > 0 && writtenBytes + size > limitBytes)
            {
                StopSession("File size limit reached");
                return;
            }
            writer.WriteLine(line);
            writtenBytes += size;
            CheckLimits();
        }

        public void Dispose() => StopSession();
    }
}
