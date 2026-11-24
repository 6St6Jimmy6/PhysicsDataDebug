using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Offline Four Wheels companion. Imported rows are retained unmodified;
    /// all 13 filters and axis/color choices are projections of those rows.
    /// </summary>
    public partial class FormOfflineChart : Form
    {
        private readonly List<DelimitedTelemetryFile> files = new List<DelimitedTelemetryFile>();
        private OfflineChartOptions options = new OfflineChartOptions();
        private ChartLimiterRow[] filters;
        private FormOfflineChartSettings settingsForm;
        internal Control FilterSettingsRoot => settingsForm?.FilterSettingsRoot;
        private bool loadingControls;
        private bool loadedSavedFilters;
        private bool loadedSavedChartOptions;
        private bool importingFiles;
        private readonly ChartPointInspector pointInspector;
        private readonly ChartZoomBehavior chartZoom;
        private static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;

        private sealed class ActiveFilter
        {
            public string Field;
            public double Min;
            public double Max;
            public bool Absolute;
        }

        public FormOfflineChart()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
                return;
            pointInspector = new ChartPointInspector(chart1, FormatPointTooltip);
            pointInspector.HoverDelayMilliseconds = options.PointTooltipDelayMs;
            pointInspector.Enabled = options.ShowPointTooltips;
            chartZoom = new ChartZoomBehavior(chart1, () => options.CursorEnabled && options.CursorZoomable);
            FormClosed += (s,e) => { chartZoom.Dispose(); pointInspector.Dispose(); };
            // The Designer-owned toolbarLayout keeps Profiles pinned at the right,
            // and stretches the file list automatically without manual resizing.
            // Click handlers remain in the .Designer.cs file.
            chartAndLegend.SizeChanged += ChartAndLegend_SizeChanged;
            settingsForm = new FormOfflineChartSettings(this, options);
            InitializeFilters();
            Disposed += (s,e) => settingsForm.Dispose();
            JsonFormSettings.EnsureFactoryDefaults(this);
            JsonFormSettings.AttachProfileButton(this, Redraw);
            ComboBoxBehaviors.EnableSearch(this);
            importedFilesList.ItemCheck += (s,e) => { if (!importingFiles) BeginInvoke(new Action(Redraw)); };
            // Avoid overwriting a valid saved filter profile with empty, not-yet
            // initialized dropdowns when the window closes before importing a file.
            FormClosed += (s,e) =>
            {
                if (loadedSavedFilters && files.Count > 0)
                    JsonFormSettings.SaveAllSettings(this);
            };
            Shown += (s,e) =>
            {
                // The first import populates dropdowns before saved selections are restored.
                if (chartAndLegend.ClientSize.Width > 300)
                    chartAndLegend.SplitterDistance = Math.Max(180,chartAndLegend.ClientSize.Width - 175);
            };
            // Do not rebuild a hidden Chart whose initial layout may be zero
            // pixels wide. The first render happens after WinForms lays it out.
            Shown += (s,e) => Redraw();
        }

        private void ImportFilesButton_Click(object sender, EventArgs e) => ImportFiles();
        private void RemoveFilesButton_Click(object sender, EventArgs e) => RemoveSelectedFiles();
        private void SettingsButton_Click(object sender, EventArgs e) => ShowSettings();

        internal void ApplyFiltersFromSettings() => Redraw();

        private void ChartAndLegend_SizeChanged(object sender, EventArgs e)
        {
            int width = chartAndLegend.ClientSize.Width;
            if (width <= 240) return;
            int target = Math.Max(160,width - 170);
            int max = width - chartAndLegend.Panel2MinSize - chartAndLegend.SplitterWidth;
            if (max < chartAndLegend.Panel1MinSize) return;
            target = Math.Max(chartAndLegend.Panel1MinSize,Math.Min(max,target));
            if (chartAndLegend.SplitterDistance != target) chartAndLegend.SplitterDistance = target;
        }

        private void InitializeFilters()
        {
            filters = settingsForm.FilterRows;
            loadingControls = true;
            for (int i = 0; i < filters.Length; i++)
            {
                int index = i;
                var filter = filters[i];
                filter.ResetButton.Click += (s,e) => ResetFilter(index);
                filter.SelectionBox.SelectionChangeCommitted += (s,e) => ResetFilter(index);
            }
            loadingControls = false;
        }

        private void UpdateChoices()
        {
            loadingControls = true;
            var headers = GetColumnNames().ToList();
            foreach (var filter in filters)
            {
                string old = filter.SelectedField ?? filter.SelectionBox.Text;
                filter.SelectionBox.BeginUpdate();
                try
                {
                    filter.SelectionBox.Items.Clear();
                    filter.SelectionBox.Items.Add("None");
                    foreach (string name in headers) filter.SelectionBox.Items.Add(name);
                    filter.SetField(CanonicalAvailableField(old, headers) ?? "None");
                }
                finally { filter.SelectionBox.EndUpdate(); }
            }
            UpdateFollowedAxes();
            loadingControls = false;
        }

        private void UpdateFollowedAxes()
        {
            if (filters == null) return;
            string[] axes = { options.X, options.Y, options.Z };
            for (int i = 0; i < 3; i++)
            {
                if (!string.Equals(filters[i].SelectedField,axes[i],StringComparison.OrdinalIgnoreCase))
                {
                    filters[i].SetField(axes[i]);
                    ResetFilter(i);
                }
            }
        }

        private void ResetFilter(int index)
        {
            ChartLimiterRow row = filters[index];
            string selected = row.SelectedField ?? row.SelectionBox.Text;
            if (string.IsNullOrWhiteSpace(selected) || selected == "None")
            {
                row.MinimumBox.Text = "";
                row.MaximumBox.Text = "";
                return;
            }
            bool useAbs = GameMemoryConfig.AbsoluteValueFields.Contains(selected);
            if (TryGetFieldRange(selected,useAbs,out double min,out double max))
            {
                row.MinimumBox.Text = min.ToString("G9",Invariant);
                row.MaximumBox.Text = max.ToString("G9",Invariant);
            }
            else
            {
                if (GameMemoryConfig.TryGetWheelAxisDefaults(selected,out WheelAxisProfile defaults))
                {
                    row.MinimumBox.Text = (useAbs ? 0d : defaults.Min).ToString(Invariant);
                    row.MaximumBox.Text = defaults.Max.ToString(Invariant);
                }
                else { row.MinimumBox.Text = ""; row.MaximumBox.Text = ""; }
            }
        }

        internal static string CanonicalAvailableField(string value, IEnumerable<string> available)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            var names = available.ToList();
            string match = names.FirstOrDefault(n =>
                string.Equals(n, value, StringComparison.OrdinalIgnoreCase));
            if (match != null) return match;

            // A saved FR_SlipRatio (or the old raw field name) selects the
            // measurement SlipRatio, not a hardwired FR channel. The dataset
            // layout determines which actual columns are read.
            foreach (string wheel in TelemetryNames.Wheels)
            {
                string candidate = TelemetryNames.RelativeWheelName(
                    TelemetryNames.Canonicalize(value, wheel));
                match = names.FirstOrDefault(n =>
                    string.Equals(n, candidate, StringComparison.OrdinalIgnoreCase));
                if (match != null) return match;
            }
            return null;
        }

        // Imported column headers stay fully prefixed internally. The UI only
        // exposes a wheel measurement once, regardless of the selected layout.
        internal IEnumerable<string> GetColumnNames() => files
            .SelectMany(file => file.Headers)
            .Select(TelemetryNames.RelativeWheelName)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase);

        internal bool TryGetFieldRange(string name, bool absolute, out double minimum, out double maximum)
        {
            minimum = double.PositiveInfinity;
            maximum = double.NegativeInfinity;
            foreach (var file in files)
            {
                var choices = file.AvailableWheels(name, name, name);
                IEnumerable<string> wheelChoices = choices.Count > 0
                    ? choices.Where(w => FourWheelsFieldSelection.IncludesWheel(options.Layout, w))
                    : new string[] { null };
                foreach (string wheel in wheelChoices)
                {
                    if (!file.TryWheelIndex(name, wheel, out int col)) continue;
                    var reader = file.CreateReader();
                    foreach (var row in file.Rows)
                    {
                        reader.SetRow(row);
                        double value = reader.Value(col);
                        if (double.IsNaN(value) || double.IsInfinity(value)) continue;
                        if (absolute) value = Math.Abs(value);
                        if (value < minimum) minimum = value;
                        if (value > maximum) maximum = value;
                    }
                }
            }
            if (double.IsInfinity(minimum) || double.IsInfinity(maximum))
            { minimum = maximum = 0; return false; }
            if (minimum == maximum)
            {
                double expansion = Math.Max(0.01,Math.Abs(minimum) * 0.05);
                minimum -= expansion;
                maximum += expansion;
            }
            return true;
        }

        internal void ApplyOptions(OfflineChartOptions newOptions)
        {
            options = newOptions.Clone();
            pointInspector.HoverDelayMilliseconds = options.PointTooltipDelayMs;
            pointInspector.Enabled = options.ShowPointTooltips;
            UpdateFollowedAxes();
            Redraw();
        }

        private void ImportFiles()
        {
            using (var dialog = new OpenFileDialog
            {
                Title = "Import telemetry files",
                Filter = "Delimited files (*.csv;*.txt;*.log;*.tsv)|*.csv;*.txt;*.log;*.tsv|All files (*.*)|*.*",
                CheckFileExists = true, Multiselect = true
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                var failures = new List<string>();
                bool added = false;
                Cursor = Cursors.WaitCursor;
                importingFiles = true;
                try
                {
                    foreach (string path in dialog.FileNames)
                    {
                        if (files.Any(file => string.Equals(file.Path,path,StringComparison.OrdinalIgnoreCase))) continue;
                        try
                        {
                            var data = DelimitedTelemetryFile.Load(path);
                            files.Add(data);
                            importedFilesList.Items.Add(data.Name + "  (" + data.Rows.Count.ToString("N0") + " rows; " +
                                (data.Separator == '\t' ? "TAB" : data.Separator.ToString()) + ")",true);
                            added = true;
                        }
                        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is FormatException || ex is ArgumentException)
                        { failures.Add(System.IO.Path.GetFileName(path) + ": " + ex.Message); }
                    }
                }
                finally { importingFiles = false; Cursor = Cursors.Default; }
                if (added)
                {
                    // Measurements populate the selectors once per field;
                    // wheel prefixes are resolved only when datasets are drawn.
                    var all = GetColumnNames().ToList();
                    options.X = CanonicalAvailableField(options.X, all) ?? all.FirstOrDefault() ?? "";
                    options.Y = CanonicalAvailableField(options.Y, all) ?? all.Skip(1).FirstOrDefault() ?? options.X;
                    options.Z = CanonicalAvailableField(options.Z, all) ?? all.Skip(2).FirstOrDefault() ?? options.Y;
                    UpdateChoices();
                    if (!loadedSavedFilters)
                    {
                        JsonFormSettings.LoadAllSettings(this);
                        // Restore only once, after the comboboxes contain valid header items.
                        loadedSavedFilters = true;
                        UpdateFollowedAxes();
                    }
                    if (!loadedSavedChartOptions)
                    {
                        // Reading settings during CSV import must NEVER write an
                        // updated profile: this file may have different columns.
                        // The user's saved selections belong to the original file.
                        loadedSavedChartOptions = true;
                        settingsForm.Prepare(options);
                        settingsForm.ApplySavedSettings();
                    }
                    Redraw();
                }
                if (failures.Count > 0)
                    MessageBox.Show(this,string.Join(Environment.NewLine,failures.Take(10)),"Some files could not be loaded",
                        MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void RemoveSelectedFiles()
        {
            int selected = importedFilesList.SelectedIndex;
            if (selected < 0 || selected >= files.Count) return;
            files.RemoveAt(selected);
            importedFilesList.Items.RemoveAt(selected);
            UpdateChoices();
            Redraw();
        }

        private void ShowSettings()
        {
            if (files.Count == 0)
            {
                MessageBox.Show(this,"Load a telemetry file first so its column headers are available.",
                    "Offline chart",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            settingsForm.Prepare(options);
            settingsForm.ShowDialog(this);
        }

        private bool TryCollectFilters(out List<ActiveFilter> active)
        {
            active = new List<ActiveFilter>();
            foreach (var filter in filters)
            {
                // Keep the shared limiter row dark after every filter application.
                filter.MinimumBox.BackColor = Color.FromArgb(42, 42, 42);
                filter.MaximumBox.BackColor = Color.FromArgb(42, 42, 42);
                filter.MinimumBox.ForeColor = Color.White;
                filter.MaximumBox.ForeColor = Color.White;
                if (!filter.EnabledBox.Checked) continue;
                string field = filter.SelectedField ?? filter.SelectionBox.Text;
                if (string.IsNullOrEmpty(field) || field == "None") continue;
                if (!filter.TryGetBounds(out double min, out double max))
                {
                    statusLabel.Text = "Invalid minimum/maximum in " + filter.Title + ". Fix the highlighted values.";
                    return false;
                }
                active.Add(new ActiveFilter { Field = field, Min = min, Max = max,
                    Absolute = GameMemoryConfig.AbsoluteValueFields.Contains(field) });
            }
            return true;
        }

        private static int ColorBand(double value, double min, double max, int bands)
        {
            if (max <= min || double.IsNaN(value)) return 1;
            double t = (value - min) / (max - min);
            return t <= 0 ? 1 : t >= 1 ? bands : Math.Min(bands,(int)Math.Floor(t * bands) + 1);
        }

        private static void SetAxis(Axis axis, string title, double? min, double? max,
            int decimals, double interval, bool minor, bool logarithmic, double logBase,
            string fontFamily, decimal fontSize, Color fontColor,
            Color gridColor, int gridAlpha, decimal gridWidth, ChartDashStyle gridDash,
            Color minorColor, int minorAlpha, decimal minorWidth, ChartDashStyle minorDash,
            bool zoomable)
        {
            axis.Title = title;
            axis.TitleForeColor = fontColor;
            axis.TitleFont = new Font(fontFamily, (float)fontSize, FontStyle.Regular);
            axis.LabelStyle.ForeColor = fontColor;
            axis.LabelStyle.Font = new Font(fontFamily, (float)fontSize, FontStyle.Regular);
            axis.LabelStyle.Format = "F" + decimals.ToString(Invariant);
            ChartAppearance.ConfigureGrid(axis.MajorGrid, gridColor,
                gridAlpha, gridWidth, gridDash);
            axis.MinorGrid.Enabled = minor;
            ChartAppearance.ConfigureGrid(axis.MinorGrid, minorColor,
                minorAlpha, minorWidth, minorDash);
            axis.Minimum = min ?? double.NaN;
            axis.Maximum = max ?? double.NaN;
            axis.Interval = interval > 0 ? interval : 0;
            axis.MajorGrid.Interval = interval > 0 ? interval : 0;
            axis.IsLogarithmic = logarithmic;
            axis.LogarithmBase = logBase;
            axis.ScaleView.Zoomable = zoomable;
        }

        private void ConfigureArea(ChartArea area)
        {
            area.BackColor = options.Background;
            foreach (var cursor in new[] { area.CursorX, area.CursorY })
                ChartAppearance.ConfigureCursor(cursor, options.CursorEnabled,
                    options.CursorZoomable, options.CursorColor, options.CursorAlpha,
                    options.CursorWidth, options.CursorDashStyle);
            SetAxis(area.AxisX, options.X, options.XMinimum, options.XMaximum,
                options.XDecimals, options.XGridInterval, options.XMinorGrid, options.XLogarithmic, options.XLogBase,
                options.XFontFamily, options.XFontSize, options.XFontColor,
                options.XGridColor, options.XGridAlpha, options.XGridWidth, options.XGridDashStyle,
                options.XMinorColor, options.XMinorAlpha, options.XMinorWidth, options.XMinorDashStyle,
                options.CursorEnabled && options.CursorZoomable);
            SetAxis(area.AxisY, options.Y, options.YMinimum, options.YMaximum,
                options.YDecimals, options.YGridInterval, options.YMinorGrid, options.YLogarithmic, options.YLogBase,
                options.YFontFamily, options.YFontSize, options.YFontColor,
                options.YGridColor, options.YGridAlpha, options.YGridWidth, options.YGridDashStyle,
                options.YMinorColor, options.YMinorAlpha, options.YMinorWidth, options.YMinorDashStyle,
                options.CursorEnabled && options.CursorZoomable);
            ChartAppearance.ConfigureCartesianAxisLines(area);
        }

        private void UpdateGradient(double minimum, double maximum, List<Color> palette)
        {
            GradientChart.Visible = true;
            GradientChart.Series.Clear();
            GradientChart.ChartAreas.Clear();
            GradientChart.Legends.Clear();
            GradientChart.BackColor = Color.Black;
            var area = new ChartArea("ZColors") { BackColor = Color.Black };
            GradientChart.ChartAreas.Add(area);
            area.AxisX.Minimum = 0; area.AxisX.Maximum = 1;
            area.AxisX.Enabled = AxisEnabled.False;
            area.AxisY.Minimum = minimum; area.AxisY.Maximum = maximum;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.LineColor = Color.DarkGray;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisY.Title = options.Z;
            area.AxisY.TitleForeColor = Color.White;
            area.AxisY.LabelStyle.Format = "G4";
            var dummy = new Series("Legend") { ChartArea = area.Name, ChartType = SeriesChartType.Line, Color = Color.Transparent };
            dummy.Points.AddXY(0,minimum);
            dummy.Points.AddXY(1,maximum);
            GradientChart.Series.Add(dummy);
            double width = (maximum - minimum) / options.Bands;
            area.AxisY.StripLines.Clear();
            for (int i = 1; i <= options.Bands; i++)
            {
                area.AxisY.StripLines.Add(new StripLine { Interval = 0,
                    IntervalOffset = minimum + (i - 1) * width,
                    StripWidth = width, BackColor = palette[i] });
            }
        }

        private string FormatPointTooltip(Series series, DataPoint point)
        {
            if (!(point.Tag is double)) return null;
            double z = (double)point.Tag;
            string dataset = series.Tag as string ?? series.Name;
            return "File: " + dataset + Environment.NewLine +
                "X (" + options.X + "): " + point.XValue.ToString("G9",Invariant) + Environment.NewLine +
                "Y (" + options.Y + "): " + point.YValues[0].ToString("G9",Invariant) + Environment.NewLine +
                "Z (" + options.Z + "): " + z.ToString("G9",Invariant);
        }

        // Chart types requiring multiple Y values cannot be represented by the
        // chosen single Y field. They remain selectable, with a clear warning.
        internal static bool CanDrawWithXYZ(SeriesChartType type)
        {
            switch (type)
            {
                case SeriesChartType.Bubble:
                case SeriesChartType.Stock:
                case SeriesChartType.Candlestick:
                case SeriesChartType.Range:
                case SeriesChartType.SplineRange:
                case SeriesChartType.RangeBar:
                case SeriesChartType.RangeColumn:
                case SeriesChartType.ErrorBar:
                case SeriesChartType.BoxPlot:
                case SeriesChartType.Renko:
                case SeriesChartType.ThreeLineBreak:
                case SeriesChartType.Kagi:
                case SeriesChartType.PointAndFigure:
                    return false;
                default: return true;
            }
        }

        public void Redraw()
        {
            if (loadingControls || filters == null) return;
            if (!TryCollectFilters(out List<ActiveFilter> active)) return;
            if (!CanDrawWithXYZ(options.ChartType))
            {
                statusLabel.Text = options.ChartType + " needs more than one Y value per point. " +
                    "Choose another chart type, or add extra Y-column mappings in a future version.";
                return;
            }
            pointInspector.Clear(); // No pinned point may reference a replaced series.
            chart1.SuspendLayout();
            try
            {
                chart1.Series.Clear(); chart1.ChartAreas.Clear();
                chart1.Legends.Clear(); chart1.Titles.Clear();
                chart1.BackColor = Color.Black;
                var visible = files.Where((file,index) => index < importedFilesList.Items.Count && importedFilesList.GetItemChecked(index)).ToList();
                if (visible.Count == 0)
                {
                    chart1.ChartAreas.Add(new ChartArea("Empty") { BackColor = options.Background });
                    GradientChart.Series.Clear(); GradientChart.ChartAreas.Clear();
                    GradientChart.Visible = false;
                    statusLabel.Text = files.Count == 0 ? "Load CSV, TXT, TSV or LOG files to begin." : "No files selected for display.";
                    return;
                }
                var palette = GradientPalette.Create(options.Scheme,options.Bands,options.PaletteAlpha,options.PaletteDivider);
                double zMin, zMax;
                if (!options.ZMinimum.HasValue || !options.ZMaximum.HasValue)
                {
                    if (!TryGetFieldRange(options.Z,options.Absolute,out zMin,out zMax)) { zMin = 0; zMax = 1; }
                }
                else { zMin = options.ZMinimum.Value; zMax = options.ZMaximum.Value; }
                if (zMax <= zMin) zMax = zMin + 1;
                chart1.Legends.Add(new Legend("Datasets") { Docking = Docking.Top, ForeColor = Color.White,
                    BackColor = Color.FromArgb(25,25,25) });
                bool circular = options.ChartType == SeriesChartType.Pie ||
                    options.ChartType == SeriesChartType.Doughnut ||
                    options.ChartType == SeriesChartType.Funnel ||
                    options.ChartType == SeriesChartType.Pyramid;
                long matching = 0, skipped = 0;
                for (int index = 0; index < visible.Count; index++)
                {
                    DelimitedTelemetryFile file = visible[index];
                    // Resolve relative fields to each available wheel in this
                    // file. A single-wheel layout selects only that channel;
                    // global-only fields remain one dataset, not four copies.
                    var requestedFields = new[] { options.X, options.Y, options.Z }
                        .Concat(active.Select(filter => filter.Field)).ToArray();
                    var availableWheels = file.AvailableWheels(requestedFields);
                    IEnumerable<string> selectedWheels = availableWheels.Count > 0
                        ? FourWheelsFieldSelection.WheelsForLayout(options.Layout)
                            .Where(w => availableWheels.Contains(w))
                        : new string[] { null };
                    foreach (string wheel in selectedWheels)
                    {
                    string uniqueFileKey = "File" + index + "_" + (wheel ?? "Shared");
                    string areaName = circular ? "Circular_" + uniqueFileKey :
                        wheel == null && options.Layout == "Separate" ? "Shared_" + index :
                        wheel == null ? "ChartAreaShared" :
                        FourWheelsFieldSelection.AreaForLayout(options.Layout, wheel);
                    // Resolve columns before creating areas, otherwise an
                    // incomplete data source leaves empty chart panels behind.
                    if (!file.TryWheelIndex(options.X, wheel, out int xIndex) ||
                        !file.TryWheelIndex(options.Y, wheel, out int yIndex) ||
                        !file.TryWheelIndex(options.Z, wheel, out int zIndex))
                    { skipped += file.Rows.Count; continue; }
                    var indices = new int[active.Count];
                    bool hasAll = true;
                    for (int i = 0; i < active.Count; i++)
                        if (!file.TryWheelIndex(active[i].Field, wheel, out indices[i])) hasAll = false;
                    if (!hasAll) { skipped += file.Rows.Count; continue; }
                    if (chart1.ChartAreas.FindByName(areaName) == null)
                    {
                        var area = new ChartArea(areaName);
                        ConfigureArea(area);
                        chart1.ChartAreas.Add(area);
                        if (!circular && wheel != null)
                        {
                            chart1.Titles.Add(new Title
                            {
                                Name = "Heading_" + areaName,
                                Text = FourWheelsFieldSelection.AreaTitle(options.Layout, wheel),
                                DockedToChartArea = areaName,
                                IsDockedInsideChartArea = false,
                                Docking = Docking.Top,
                                Alignment = ContentAlignment.TopCenter,
                                BackColor = Color.Transparent,
                                ForeColor = Color.White,
                                Font = new Font("Segoe UI", 10f, FontStyle.Bold)
                            });
                        }
                    }

                    var series = new Series[options.Bands + 1];
                    for (int band = 1; band <= (circular ? 1 : options.Bands); band++)
                    {
                        var s = new Series(uniqueFileKey + GradientPalette.SeriesSuffix(band))
                        {
                            ChartArea = areaName,
                            ChartType = options.ChartType,
                            YValuesPerPoint = options.ChartType == SeriesChartType.Bubble ? 2 : 1,
                            Color = palette[band],
                            MarkerStyle = options.Marker,
                            MarkerSize = options.MarkerSize,
                            MarkerColor = palette[band],
                            BorderWidth = Math.Max(1,options.MarkerSize / 2),
                            IsVisibleInLegend = band == 1,
                            Legend = "Datasets",
                            LegendText = file.Name + (wheel == null ? "" : " [" + wheel + "]"),
                            Tag = file.Name + (wheel == null ? "" : " [" + wheel + "]")
                        };
                        chart1.Series.Add(s);
                        series[band] = s;
                    }
                    int priorBand = 0;
                    bool gapPending = false;
                    bool[] bandHasPoints = new bool[options.Bands + 1];
                    bool isLine = options.ChartType == SeriesChartType.Line ||
                        options.ChartType == SeriesChartType.Spline ||
                        options.ChartType == SeriesChartType.StepLine ||
                        options.ChartType == SeriesChartType.FastLine;
                    var reader = file.CreateReader();
                    foreach (double[] row in file.Rows)
                    {
                        reader.SetRow(row);
                        double x = reader.Value(xIndex), y = reader.Value(yIndex), z = reader.Value(zIndex);
                        if (double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(z)) { skipped++; gapPending = true; continue; }
                        bool pass = true;
                        for (int f = 0; f < active.Count; f++)
                        {
                            double value = reader.Value(indices[f]);
                            if (active[f].Absolute) value = Math.Abs(value);
                            if (double.IsNaN(value) || value < active[f].Min || value > active[f].Max)
                            { pass = false; break; }
                        }
                        if (!pass) { skipped++; gapPending = true; continue; }
                        if (options.Absolute) { x = Math.Abs(x); y = Math.Abs(y); z = Math.Abs(z); }
                        if ((options.XLogarithmic && x <= 0) || (options.YLogarithmic && y <= 0))
                        { skipped++; gapPending = true; continue; }
                        if ((options.XMinimum.HasValue && (x < options.XMinimum || x > options.XMaximum)) ||
                            (options.YMinimum.HasValue && (y < options.YMinimum || y > options.YMaximum)))
                        { skipped++; gapPending = true; continue; }
                        int band = ColorBand(z,zMin,zMax,options.Bands);
                        int seriesBand = circular ? 1 : band;
                        // For line styles, filtering and Z-color transitions must
                        // break old segments instead of joining disjoint samples.
                        if (isLine && (gapPending || (priorBand != 0 && priorBand != band)))
                        {
                            if (priorBand != 0)
                                series[priorBand].Points.Add(new DataPoint(x,y) { IsEmpty = true });
                            if (bandHasPoints[band] && priorBand != band)
                                series[band].Points.Add(new DataPoint(x,y) { IsEmpty = true });
                        }
                        var point = new DataPoint(x, y) { Tag = z };
                        if (circular) point.Color = palette[band];
                        if (options.ChartType == SeriesChartType.Bubble)
                            point.YValues = new[] { y, Math.Max(0.000001, Math.Abs(z)) };
                        series[seriesBand].Points.Add(point);
                        bandHasPoints[seriesBand] = true;
                        gapPending = false;
                        priorBand = band;
                        matching++;
                    }
                    } // wheel channel / combined telemetry source
                }
                if (chart1.ChartAreas.Count == 0)
                {
                    chart1.ChartAreas.Add(new ChartArea("Empty") { BackColor = options.Background });
                    GradientChart.Series.Clear(); GradientChart.ChartAreas.Clear();
                    GradientChart.Visible = false;
                }
                else UpdateGradient(zMin,zMax,palette);
                statusLabel.Text = visible.Count + " active file(s); " + matching.ToString("N0") +
                    " displayed points; " + skipped.ToString("N0") + " hidden or unavailable samples. Data retained in memory.";
            }
            finally { chart1.ResumeLayout(true); chart1.Invalidate(); }
        }
    }
}
