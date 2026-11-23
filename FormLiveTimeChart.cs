using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Five synchronized time-series lanes. RaceTime is ALWAYS the X source,
    /// in milliseconds in game memory and seconds internally. Each selected
    /// wheel-relative measurement resolves independently for FL/FR/RL/RR.
    /// The Designer owns the toolbar, five selection rows and chart container.
    /// </summary>
    public partial class FormLiveTimeChart : Form
    {
        private sealed class TimeSample
        {
            internal double Seconds;
            internal double[] Values;
        }

        private sealed class TrackHistory
        {
            internal string Selection;
            internal bool Shared;
            internal readonly LogData.Column[] Sources = new LogData.Column[4];
            internal readonly Queue<TimeSample> Samples = new Queue<TimeSample>();
        }

        private readonly TrackHistory[] tracks = Enumerable.Range(0, 5)
            .Select(index => new TrackHistory()).ToArray();
        private CheckBox[] trackEnabled;
        private ComboBox[] fieldSelections;
        private CheckBox[,] wheelVisible;
        private TimeChartOptions options = new TimeChartOptions();
        private bool initializing;
        private double lastSampleSeconds = double.NaN;
        private static readonly string[] WheelNames = { "FL", "FR", "RL", "RR" };
        private static readonly string[] DefaultSelections =
            { "TreadTemperature", "InnerTemperature", "SlipRatio", "VerticalLoad", "SlipAngleDeg" };

        public FormLiveTimeChart()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            trackEnabled = new[] { track1Enabled, track2Enabled, track3Enabled, track4Enabled, track5Enabled };
            fieldSelections = new[] { track1Field, track2Field, track3Field, track4Field, track5Field };
            wheelVisible = new[,]
            {
                { track1FL, track1FR, track1RL, track1RR },
                { track2FL, track2FR, track2RL, track2RR },
                { track3FL, track3FR, track3RL, track3RR },
                { track4FL, track4FR, track4RL, track4RR },
                { track5FL, track5FR, track5RL, track5RR }
            };
        }

        private void TireTemperatures_Load(object sender, EventArgs e)
        {
            initializing = true;
            try
            {
                string[] choices = FourWheelsFieldSelection.Options("All In One").ToArray();
                for (int track = 0; track < tracks.Length; track++)
                {
                    ComboBox combo = fieldSelections[track];
                    combo.BeginUpdate();
                    combo.Items.Clear();
                    combo.Items.AddRange(choices.Cast<object>().ToArray());
                    combo.SelectedItem = FourWheelsFieldSelection.MatchAvailable(
                        DefaultSelections[track], choices);
                    combo.EndUpdate();
                }
                // Restore track selections and the five sets of independent
                // wheel-visibility checkboxes from the normal JSON settings file.
                JsonFormSettings.LoadAllSettings(this);
                for (int i = 0; i < tracks.Length; i++)
                    SetTrackSource(i, clearHistory: true);
                ReadSavedAppearance();
                UpdateWheelCheckboxColors();
                RebuildChart();
            }
            finally { initializing = false; }

            for (int i = 0; i < tracks.Length; i++)
            {
                int index = i;
                trackEnabled[i].CheckedChanged += (s, a) => OnTrackChanged(index, false);
                fieldSelections[i].SelectedIndexChanged += (s, a) => OnTrackChanged(index, true);
                foreach (int wheel in Enumerable.Range(0, 4))
                    wheelVisible[i, wheel].CheckedChanged += (s, a) => OnTrackChanged(index, false);
            }
            ComboBoxBehaviors.EnableSearch(this);
            LiveData.TemperaturesChartOpen = true;
            timer1.Enabled = true;
            startButton.Text = "Resume";
        }

        private void ReadSavedAppearance()
        {
            // This form is the public chart. The separate Settings form owns the
            // appearance controls and is safe to construct without a Chart handle.
            using (var settings = new FormLiveTimeChartSettings())
            {
                JsonFormSettings.EnsureFactoryDefaults(settings);
                JsonFormSettings.LoadAllSettings(settings);
                options = settings.ReadOptions();
            }
            timer1.Interval = options.UpdateIntervalMs;
        }

        private void OnTrackChanged(int index, bool changedMeasurement)
        {
            if (initializing) return;
            if (changedMeasurement)
                SetTrackSource(index, clearHistory: true);
            else
                UpdateSourceVisibility(index);
            RebuildChart();
        }

        private void SetTrackSource(int index, bool clearHistory)
        {
            TrackHistory track = tracks[index];
            string requested = fieldSelections[index].SelectedItem as string ??
                fieldSelections[index].Text;
            string selected = FourWheelsFieldSelection.MatchAvailable(
                requested, fieldSelections[index].Items.Cast<object>()
                    .Select(fieldSelections[index].GetItemText));
            if (!string.Equals(selected, track.Selection, StringComparison.Ordinal))
            {
                track.Selection = selected;
                if (clearHistory) track.Samples.Clear();
            }
            Array.Clear(track.Sources, 0, track.Sources.Length);
            if (selected == "None") return;
            string canonical = TelemetryNames.Canonicalize(selected);
            LogData.Column shared = LogData.FindDisplay(canonical);
            track.Shared = shared != null && shared.Wheel == null;
            if (track.Shared)
                track.Sources[0] = shared;
            else
                for (int wheel = 0; wheel < 4; wheel++)
                    track.Sources[wheel] = LogData.FindDisplay(WheelNames[wheel] + "_" + selected);
            UpdateSourceVisibility(index);
        }

        private void UpdateSourceVisibility(int index)
        {
            bool shared = tracks[index].Shared;
            for (int wheel = 0; wheel < 4; wheel++)
                wheelVisible[index, wheel].Enabled = !shared;
        }

        private void UpdateWheelCheckboxColors()
        {
            // Color-coded wheel headers are Designer-owned; these values change
            // only when the user applies appearance settings. Checkboxes beneath
            // them have no repeated text, so four columns remain readable at DPI scaling.
            Label[] wheelHeaders = { header2, header3, header4, header5 };
            for (int wheel = 0; wheel < 4; wheel++)
            {
                Color color = options.WheelColors[wheel];
                Color visible = Color.FromArgb(Math.Max((int)color.R, 105),
                    Math.Max((int)color.G, 105), Math.Max((int)color.B, 105));
                wheelHeaders[wheel].ForeColor = visible;
                for (int track = 0; track < 5; track++)
                    wheelVisible[track, wheel].ForeColor = visible;
            }
        }

        private double DisplayX(double seconds) =>
            options.XAxisInMinutes ? seconds / 60.0 : seconds;

        private static double NiceInterval(double span)
        {
            if (span <= 0 || double.IsNaN(span)) return 1;
            double baseTen = Math.Pow(10, Math.Floor(Math.Log10(span / 6.0)));
            double relative = span / (6.0 * baseTen);
            return baseTen * (relative <= 1 ? 1 : relative <= 2 ? 2 : relative <= 5 ? 5 : 10);
        }

        /// <summary>Rebuild only chart objects; track buffers remain intact.</summary>
        private void RebuildChart()
        {
            if (initializing && !IsHandleCreated) return;
            bool running = timer1.Enabled;
            timer1.Enabled = false;
            try
            {
                chartTimeSeries.SuspendLayout();
                chartTimeSeries.Series.Clear();
                chartTimeSeries.Titles.Clear();
                chartTimeSeries.Legends.Clear();
                chartTimeSeries.ChartAreas.Clear();
                chartTimeSeries.BackColor = options.ChartBackground;
                chartTimeSeries.AntiAliasing = options.Antialias ? AntiAliasingStyles.All : AntiAliasingStyles.None;
                chartTimeSeries.TextAntiAliasingQuality = options.Antialias ?
                    TextAntiAliasingQuality.High : TextAntiAliasingQuality.Normal;

                var active = Enumerable.Range(0, 5).Where(i =>
                    trackEnabled[i].Checked && tracks[i].Selection != "None" &&
                    tracks[i].Sources.Any(source => source != null)).ToArray();
                if (active.Length == 0)
                {
                    var emptyArea = new ChartArea("Empty");
                    emptyArea.BackColor = options.PlotBackground;
                    emptyArea.AxisX.Enabled = AxisEnabled.False;
                    emptyArea.AxisY.Enabled = AxisEnabled.False;
                    chartTimeSeries.ChartAreas.Add(emptyArea);
                    statusLabel.Text = "Enable a plot and choose a telemetry field.";
                    return;
                }

                for (int row = 0; row < active.Length; row++)
                {
                    int index = active[row];
                    string areaName = "Plot" + (index + 1).ToString(CultureInfo.InvariantCulture);
                    var area = new ChartArea(areaName);
                    // Each chart area has the same horizontal plot bounds and
                    // X limits; only the lowest shows X tick labels and title.
                    area.Position.Auto = false;
                    area.Position.X = 0;
                    area.Position.Width = 100;
                    area.Position.Y = row * 100f / active.Length;
                    area.Position.Height = 100f / active.Length;
                    area.InnerPlotPosition.Auto = false;
                    area.InnerPlotPosition.X = 10;
                    area.InnerPlotPosition.Y = 14;
                    area.InnerPlotPosition.Width = 87;
                    area.InnerPlotPosition.Height = row == active.Length - 1 ? 70 : 79;
                    area.BackColor = options.PlotBackground;
                    area.BorderColor = Color.FromArgb(64, 64, 64);
                    area.BorderDashStyle = ChartDashStyle.Solid;
                    area.BorderWidth = 1;
                    area.AxisX.LabelStyle.Enabled = row == active.Length - 1;
                    area.AxisX.MajorTickMark.Enabled = row == active.Length - 1;
                    area.AxisX.Title = row == active.Length - 1 ?
                        "RaceTime (" + (options.XAxisInMinutes ? "minutes" : "seconds") + ")" : "";
                    area.AxisX.TitleForeColor = options.FontColor;
                    area.AxisX.LabelStyle.Format = options.XAxisInMinutes ? "0.##" : "0.#";
                    area.AxisX.LabelStyle.ForeColor = options.FontColor;
                    area.AxisX.LineColor = options.GridColor;
                    area.AxisX.MajorGrid.Enabled = options.MajorGrid;
                    area.AxisX.MajorGrid.LineColor = options.GridColor;
                    area.AxisX.MajorGrid.LineWidth = options.MajorGridWidth;
                    area.AxisX.MinorGrid.Enabled = options.MinorGrid;
                    area.AxisX.MinorGrid.LineColor = options.MinorGridColor;
                    area.AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                    area.AxisY.LineColor = options.GridColor;
                    area.AxisY.LabelStyle.ForeColor = options.FontColor;
                    area.AxisY.LabelStyle.Format = "0.###";
                    area.AxisY.MajorGrid.Enabled = options.MajorGrid;
                    area.AxisY.MajorGrid.LineColor = options.GridColor;
                    area.AxisY.MajorGrid.LineWidth = options.MajorGridWidth;
                    area.AxisY.MinorGrid.Enabled = options.MinorGrid;
                    area.AxisY.MinorGrid.LineColor = options.MinorGridColor;
                    area.AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                    area.AxisY.IsStartedFromZero = false;
                    area.AxisY.Title = options.ShowYAxisTitle ? tracks[index].Selection : "";
                    area.AxisY.TitleForeColor = options.FontColor;
                    area.AxisX.LabelStyle.Font = new Font(options.FontName, options.AxisFontSize);
                    area.AxisY.LabelStyle.Font = new Font(options.FontName, options.AxisFontSize);
                    area.AxisX.TitleFont = new Font(options.FontName, options.AxisFontSize);
                    area.AxisY.TitleFont = new Font(options.FontName, options.AxisFontSize);
                    if (!options.YAuto[index] && options.YMax[index] > options.YMin[index])
                    {
                        area.AxisY.Minimum = options.YMin[index];
                        area.AxisY.Maximum = options.YMax[index];
                    }
                    chartTimeSeries.ChartAreas.Add(area);
                    var title = new Title(tracks[index].Selection)
                    {
                        DockedToChartArea = areaName,
                        IsDockedInsideChartArea = true,
                        Docking = Docking.Top,
                        Alignment = ContentAlignment.MiddleLeft,
                        ForeColor = options.FontColor,
                        Font = new Font(options.FontName, options.TitleFontSize, FontStyle.Bold)
                    };
                    chartTimeSeries.Titles.Add(title);

                    int seriesCount = tracks[index].Shared ? 1 : 4;
                    for (int wheel = 0; wheel < seriesCount; wheel++)
                    {
                        if (!tracks[index].Shared && !wheelVisible[index, wheel].Checked)
                            continue;
                        string name = SeriesName(index, wheel);
                        var series = new Series(name)
                        {
                            ChartArea = areaName,
                            ChartType = options.ChartType,
                            Color = tracks[index].Shared ? options.SharedColor : options.WheelColors[wheel],
                            BorderWidth = options.LineWidth,
                            MarkerStyle = options.MarkerSize == 0 ? MarkerStyle.None : MarkerStyle.Circle,
                            MarkerSize = Math.Max(1, options.MarkerSize),
                            IsVisibleInLegend = false,
                            ToolTip = name + "  #VALY{0.###} at #VALX{0.###}"
                        };
                        chartTimeSeries.Series.Add(series);
                        foreach (TimeSample sample in tracks[index].Samples)
                        {
                            double y = sample.Values[wheel];
                            if (IsFinite(y)) series.Points.AddXY(DisplayX(sample.Seconds), y);
                        }
                    }
                }
                UpdateTimeAxis();
            }
            finally
            {
                chartTimeSeries.ResumeLayout();
                timer1.Enabled = running;
            }
        }

        private string SeriesName(int track, int wheel) =>
            "Plot" + (track + 1) + "_" +
            (tracks[track].Shared ? "SHARED" : WheelNames[wheel]);

        private static bool IsFinite(double value) =>
            !double.IsNaN(value) && !double.IsInfinity(value) && Math.Abs(value) < 1e15;

        private void UpdateTimeAxis()
        {
            double now = double.IsNaN(lastSampleSeconds) ? 0 : lastSampleSeconds;
            double low = Math.Max(0, now - options.HistorySeconds);
            double high = Math.Max(options.HistorySeconds, now);
            double interval = NiceInterval((high - low) / (options.XAxisInMinutes ? 60.0 : 1.0));
            foreach (ChartArea area in chartTimeSeries.ChartAreas)
            {
                area.AxisX.Minimum = DisplayX(low);
                area.AxisX.Maximum = DisplayX(high);
                area.AxisX.Interval = interval;
                area.AxisX.MajorGrid.Interval = interval;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process == null || LiveData.FullDataList.Count < TelemetryPrefix.Order.Length)
            {
                statusLabel.Text = "Waiting for Wreckfest telemetry (Get Process in Live Data).";
                return;
            }
            // RaceTime is milliseconds. Do not use a frame counter or wall clock.
            double nowSeconds = LiveData.RaceTime / 1000.0;
            if (!IsFinite(nowSeconds) || nowSeconds < 0) return;
            if (!double.IsNaN(lastSampleSeconds))
            {
                if (nowSeconds < lastSampleSeconds)
                    ClearHistory(); // New race/session: the X axis must not jump backward.
                else if (nowSeconds <= lastSampleSeconds)
                    return; // A paused game must not generate duplicate X values.
            }
            lastSampleSeconds = nowSeconds;
            double cutoff = Math.Max(0, nowSeconds - options.HistorySeconds);
            for (int trackIndex = 0; trackIndex < tracks.Length; trackIndex++)
            {
                TrackHistory track = tracks[trackIndex];
                if (!trackEnabled[trackIndex].Checked || track.Selection == "None") continue;
                var sample = new TimeSample { Seconds = nowSeconds, Values =
                    new[] { double.NaN, double.NaN, double.NaN, double.NaN } };
                for (int wheel = 0; wheel < (track.Shared ? 1 : 4); wheel++)
                {
                    LogData.Column source = track.Sources[wheel];
                    if (source == null) continue;
                    try
                    {
                        double value = source.ReadDouble();
                        if (IsFinite(value)) sample.Values[wheel] = value;
                    }
                    catch (ArithmeticException) { }
                    catch (FormatException) { }
                }
                track.Samples.Enqueue(sample);
                while (track.Samples.Count > 0 &&
                    (track.Samples.Peek().Seconds < cutoff ||
                     track.Samples.Count > options.MaxSamples))
                    track.Samples.Dequeue();

                for (int wheel = 0; wheel < (track.Shared ? 1 : 4); wheel++)
                {
                    Series series = chartTimeSeries.Series.FindByName(SeriesName(trackIndex, wheel));
                    if (series == null) continue;
                    double value = sample.Values[wheel];
                    if (IsFinite(value)) series.Points.AddXY(DisplayX(nowSeconds), value);
                    while (series.Points.Count > 0 &&
                        (series.Points[0].XValue < DisplayX(cutoff) ||
                         series.Points.Count > options.MaxSamples))
                        series.Points.RemoveAt(0);
                }
            }
            UpdateTimeAxis();
            statusLabel.Text = "RaceTime " + TimeSpan.FromSeconds(nowSeconds).ToString(@"hh\:mm\:ss\.fff") +
                "  |  Window " + options.HistorySeconds.ToString("0.#", CultureInfo.InvariantCulture) +
                " s  |  " + chartTimeSeries.ChartAreas.Count + " active plots";
        }

        private void ClearHistory()
        {
            foreach (TrackHistory track in tracks) track.Samples.Clear();
            foreach (Series series in chartTimeSeries.Series) series.Points.Clear();
            lastSampleSeconds = double.NaN;
            UpdateTimeAxis();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            statusLabel.Text = "Paused — stored telemetry remains visible.";
        }

        private void clearButton_Click(object sender, EventArgs e) => ClearHistory();

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (var settings = new FormLiveTimeChartSettings())
            {
                JsonFormSettings.LoadAllSettings(settings);
                if (settings.ShowDialog(this) != DialogResult.OK) return;
                options = settings.ReadOptions();
                JsonFormSettings.SaveAllSettings(settings);
                timer1.Interval = options.UpdateIntervalMs;
                UpdateWheelCheckboxColors();
                foreach (TrackHistory track in tracks)
                {
                    double cutoff = double.IsNaN(lastSampleSeconds) ? 0 :
                        Math.Max(0, lastSampleSeconds - options.HistorySeconds);
                    while (track.Samples.Count > 0 &&
                        (track.Samples.Peek().Seconds < cutoff || track.Samples.Count > options.MaxSamples))
                        track.Samples.Dequeue();
                }
                RebuildChart();
            }
        }

        private void TireTemperatures_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            LiveData.TemperaturesChartOpen = false;
            if (!DesignMode) JsonFormSettings.SaveAllSettings(this);
        }
    }
}
