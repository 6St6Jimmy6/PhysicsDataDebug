using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

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
        private int rawColumnCount;
        public int RawColumnCount => rawColumnCount;

        private DelimitedTelemetryFile() { }

        // The index may refer to a physical column or a virtual, calculated
        // column. Virtual columns are never stored in Rows.
        public bool TryIndex(string field, out int index) => indices.TryGetValue(field ?? "", out index);

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
                    result = TelemetryFormulas.Calculate(file.Headers[index], name =>
                    {
                        if (!file.TryIndex(name, out int dependency)) return double.NaN;
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
                for (int i = 0; i < names.Length; i++)
                {
                    string name = headerCells[i].Trim().TrimStart('\uFEFF');
                    if (name.Length == 0) name = "Column " + (i + 1).ToString(CultureInfo.InvariantCulture);
                    string baseName = name;
                    int suffix = 2;
                    while (indices.ContainsKey(name)) name = baseName + " (" + suffix++ + ")";
                    names[i] = name;
                    indices.Add(name, i);
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
                foreach (string formula in TelemetryFormulas.Names)
                {
                    if (indices.ContainsKey(formula)) continue;
                    if (!TelemetryFormulas.CanResolve(formula,
                        candidate => indices.ContainsKey(candidate))) continue;
                    indices.Add(formula, allNames.Count);
                    allNames.Add(formula);
                }
                return new DelimitedTelemetryFile
                {
                    Path = System.IO.Path.GetFullPath(path),
                    Separator = separator,
                    Headers = allNames.ToArray(),
                    Rows = rows,
                    rawColumnCount = names.Length,
                    indices = indices
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
