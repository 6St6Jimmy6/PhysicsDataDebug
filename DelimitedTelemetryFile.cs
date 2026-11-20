using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Linq;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Immutable imported telemetry table. All original numeric samples are kept;
    /// filtering and changing chart axes never mutates this data.
    /// </summary>
    internal sealed class DelimitedTelemetryFile
    {
        private static readonly CultureInfo CommaDecimal = CultureInfo.GetCultureInfo("fi-FI");
        private static readonly CultureInfo DotDecimal = CultureInfo.InvariantCulture;
        private const NumberStyles NumericStyle = NumberStyles.Float;

        public string Path { get; private set; }
        public string Name => System.IO.Path.GetFileName(Path);
        public char Separator { get; private set; }
        public string[] Headers { get; private set; }
        public IReadOnlyList<double[]> Rows { get; private set; }
        private Dictionary<string, int> indices;
        private Dictionary<int, LogData.Column> virtualFields;
        private int rawColumnCount;
        public int RawColumnCount => rawColumnCount;

        private DelimitedTelemetryFile() { }

        // The index may refer to a physical column or a virtual, calculated
        // column. Virtual columns are never stored in Rows.
        public bool TryIndex(string field, out int index)
        {
            if (indices.TryGetValue(field ?? "", out index)) return true;
            // Compatibility: older chart profiles stored wheel-relative axes.
            // Resolve them to FL when a single value is requested. Redraw can
            // separately expand relative axes across all available wheels.
            if (!string.IsNullOrWhiteSpace(field) &&
                !TelemetryNames.Wheels.Any(w => field.StartsWith(w + "_", StringComparison.OrdinalIgnoreCase)))
                return indices.TryGetValue("FL_" + field, out index);
            return false;
        }

        internal bool TryWheelIndex(string field, string wheel, out int index)
        {
            // An explicitly prefixed field always refers to exactly that source.
            if (wheel != null && !string.IsNullOrWhiteSpace(field) &&
                !TelemetryNames.Wheels.Any(w => field.StartsWith(w + "_", StringComparison.OrdinalIgnoreCase)))
            {
                // Don't silently substitute FL values into a missing FR/RL/RR
                // channel; shared columns are allowed as-is.
                return indices.TryGetValue(wheel + "_" + field, out index) ||
                    indices.TryGetValue(field, out index);
            }
            return TryIndex(field, out index);
        }

        internal IReadOnlyList<string> AvailableWheels(params string[] fields)
        {
            if (fields == null || fields.Length == 0) return new string[0];
            // Explicitly prefixed legacy choices still select exactly one
            // channel. The current UI uses only relative wheel measurements.
            if (fields.Any(field => TelemetryNames.Wheels.Any(w =>
                field != null && field.StartsWith(w + "_", StringComparison.OrdinalIgnoreCase))))
                return new string[0];

            bool wheelMeasurement = fields.Any(field =>
                !string.IsNullOrWhiteSpace(field) && TelemetryNames.Wheels.Any(w =>
                    indices.ContainsKey(w + "_" + field)));
            if (!wheelMeasurement) return new string[0]; // shared dataset

            // Include one-wheel CSVs too (e.g. an old FrontRight log). Never
            // silently substitute FL data for an absent wheel.
            return TelemetryNames.Wheels.Where(w =>
                fields.All(field => TryWheelIndex(field, w, out int ignored))).ToArray();
        }

        private static bool TryDependencyIndex(Dictionary<string, int> lookup,
            LogData.Column column, string dependency, out int index)
        {
            // A formula may use another field in the same source group, or
            // (e.g. acceleration) a shared field in a different source group.
            // A fully qualified reference (ENG_RPM, FR_SlipRatio) has priority.
            if (lookup.TryGetValue(dependency, out index)) return true;
            string sameGroup = TelemetryNames.Name(column.Group, dependency, column.Wheel);
            if (lookup.TryGetValue(sameGroup, out index)) return true;
            string canonical = TelemetryNames.Canonicalize(dependency, column.Wheel);
            return lookup.TryGetValue(canonical, out index);
        }

        private bool TryDependencyIndex(LogData.Column column, string dependency, out int index) =>
            TryDependencyIndex(indices, column, dependency, out index);

        internal RowReader CreateReader() => new RowReader(this);

        /// <summary>
        /// Lightweight cursor reused across rows. Only requested virtual values
        /// are calculated, once per row; native values are read unchanged.
        /// </summary>
        internal sealed class RowReader
        {
            private readonly DelimitedTelemetryFile file;
            private readonly double[] cache;
            private readonly int[] computedAt;
            private readonly int[] workingAt;
            private double[] row;
            private int stamp;

            internal RowReader(DelimitedTelemetryFile source)
            {
                file = source;
                cache = new double[source.Headers.Length];
                computedAt = new int[cache.Length];
                workingAt = new int[cache.Length];
            }

            internal void SetRow(double[] nextRow)
            {
                row = nextRow;
                if (stamp == int.MaxValue)
                {
                    Array.Clear(computedAt, 0, computedAt.Length);
                    Array.Clear(workingAt, 0, workingAt.Length);
                    stamp = 0;
                }
                stamp++;
            }

            internal double Value(int index)
            {
                if (index < file.rawColumnCount) return row[index];
                if (computedAt[index] == stamp) return cache[index];
                if (workingAt[index] == stamp) return double.NaN; // cyclic formula
                workingAt[index] = stamp;
                double result;
                try
                {
                    if (!file.virtualFields.TryGetValue(index, out LogData.Column field))
                        return double.NaN;
                    result = TelemetryFormulas.Calculate(field.Group, field.Member, dependencyName =>
                    {
                        if (!file.TryDependencyIndex(field, dependencyName, out int dependency))
                            return double.NaN;
                        return Value(dependency);
                    });
                }
                finally { workingAt[index] = 0; }
                if (double.IsInfinity(result)) result = double.NaN;
                cache[index] = result;
                computedAt[index] = stamp;
                return result;
            }
        }

        public static DelimitedTelemetryFile Load(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Telemetry file does not exist.", path);
            using (var reader = new StreamReader(path, Encoding.UTF8, true))
            {
                string headerLine = ReadRecord(reader);
                while (headerLine != null && headerLine.Trim().Length == 0)
                    headerLine = ReadRecord(reader);
                if (headerLine == null) throw new InvalidDataException("The selected file is empty.");

                char separator = DetectSeparator(headerLine);
                var headerCells = ParseRecord(headerLine, separator);
                // Wreckfest logs have a semicolon after the last header and row.
                while (headerCells.Count > 0 && string.IsNullOrWhiteSpace(headerCells[headerCells.Count - 1]))
                    headerCells.RemoveAt(headerCells.Count - 1);
                if (headerCells.Count < 2)
                    throw new InvalidDataException("No delimited column headers found. Choose a file with a header row.");

                var names = new string[headerCells.Count];
                var indices = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                string sourceWheel = TelemetryNames.WheelFromFilename(path);
                for (int i = 0; i < names.Length; i++)
                {
                    string original = headerCells[i].Trim().TrimStart('\uFEFF');
                    if (original.Length == 0) original = "Column" + (i + 1).ToString(CultureInfo.InvariantCulture);
                    string name = TelemetryNames.Canonicalize(original, sourceWheel);
                    names[i] = name;
                    // If a file contains both old and new headers, show only
                    // one canonical field. Prefer the actual prefixed column.
                    if (!indices.ContainsKey(name) ||
                        string.Equals(original, name, StringComparison.OrdinalIgnoreCase))
                        indices[name] = i;
                }

                var rows = new List<double[]>();
                string record;
                while ((record = ReadRecord(reader)) != null)
                {
                    if (string.IsNullOrWhiteSpace(record)) continue;
                    List<string> cells = ParseRecord(record, separator);
                    var numbers = new double[names.Length];
                    bool anyNumber = false;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (i < cells.Count && TryNumber(cells[i], out double value))
                        {
                            numbers[i] = value;
                            anyNumber = true;
                        }
                        else numbers[i] = double.NaN;
                    }
                    if (anyNumber) rows.Add(numbers);
                }
                // Add formula names only when every required input is present.
                // If the original CSV already has that field, its values win.
                // Formulas stay virtual; this does not modify the imported rows.
                var allNames = new List<string>(names);
                var virtualFields = new Dictionary<int, LogData.Column>();
                // Generate derived fields with the same public names as live
                // telemetry and the logger, including shared ENG_/ACC_/BODY_
                // formulas. Only expose those whose dependencies can be read.
                // Iterate to a fixed point so formulas may reference another
                // configured formula regardless of category or JSON order.
                bool discovered;
                do
                {
                    discovered = false;
                    foreach (LogData.Column column in LogData.AllColumns)
                    {
                        if (indices.ContainsKey(column.Header) ||
                            !CalculatedTelemetry.IsCalculated(column.Group, column.Member) ||
                            !TelemetryFormulas.IsCalculated(column.Group, column.Member)) continue;
                        if (!TelemetryFormulas.Dependencies(column.Group, column.Member).All(
                            dependency => TryDependencyIndex(indices, column, dependency, out int ignored))) continue;
                        int at = allNames.Count;
                        indices.Add(column.Header, at);
                        allNames.Add(column.Header);
                        virtualFields.Add(at, column);
                        discovered = true;
                    }
                } while (discovered);
                return new DelimitedTelemetryFile
                {
                    Path = System.IO.Path.GetFullPath(path),
                    Separator = separator,
                    Headers = allNames.ToArray(),
                    Rows = rows,
                    rawColumnCount = names.Length,
                    indices = indices,
                    virtualFields = virtualFields
                };
            }
        }

        private static bool TryNumber(string text, out double value)
        {
            text = text.Trim();
            if (double.TryParse(text, NumericStyle, DotDecimal, out value) ||
                double.TryParse(text, NumericStyle, CommaDecimal, out value))
                return !double.IsNaN(value) && !double.IsInfinity(value);
            value = double.NaN;
            return false;
        }

        private static char DetectSeparator(string header)
        {
            char[] possible = { ';', '\t', '|', ',' };
            char best = ';';
            int maxColumns = 1;
            foreach (char candidate in possible)
            {
                int columns = ParseRecord(header, candidate).Count;
                if (columns > maxColumns) { maxColumns = columns; best = candidate; }
            }
            return best;
        }

        // Supports quoted delimiters, doubled quotes, and quoted line breaks.
        private static string ReadRecord(TextReader reader)
        {
            var text = new StringBuilder();
            bool inQuotes = false;
            int next;
            while ((next = reader.Read()) != -1)
            {
                char c = (char)next;
                if (c == '"')
                {
                    if (inQuotes && reader.Peek() == '"')
                    {
                        text.Append('"'); text.Append((char)reader.Read());
                        continue;
                    }
                    inQuotes = !inQuotes;
                }
                if (!inQuotes && (c == '\r' || c == '\n'))
                {
                    if (c == '\r' && reader.Peek() == '\n') reader.Read();
                    return text.ToString();
                }
                text.Append(c);
            }
            return text.Length == 0 ? null : text.ToString();
        }

        private static List<string> ParseRecord(string text, char separator)
        {
            var cells = new List<string>();
            var part = new StringBuilder();
            bool quoted = false;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '"')
                {
                    if (quoted && i + 1 < text.Length && text[i + 1] == '"')
                    { part.Append('"'); i++; }
                    else quoted = !quoted;
                }
                else if (c == separator && !quoted)
                {
                    cells.Add(part.ToString()); part.Clear();
                }
                else part.Append(c);
            }
            cells.Add(part.ToString());
            return cells;
        }
    }
}
