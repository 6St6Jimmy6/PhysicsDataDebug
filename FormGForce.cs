using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public partial class FormGForce : Form
    {
        public FormGForce()
        {
            InitializeComponent();
            // Like Form4Wheels, do not initialize a visible Chart until its
            // containing form has finished layout. The model is restored by
            // Program.Main before the user opens either live chart.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                return;
            }

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer1.Interval = 100;
            Shown += (sender, args) =>
            {
                ApplyChartSettings();
                // Start acquisition only after the chart has its final size
                // and saved appearance is in place.
                timer1.Enabled = true;
                timer2.Enabled = true;
            };
        }

        private string lastAppliedAngleType;

        /// <summary>
        /// Refresh chart appearance and sampling cadence without changing data.
        /// Called by both Apply buttons in FormGForceSettings.
        /// </summary>
        public void ApplyChartSettings()
        {
            UpdateSnapshotInterval();
            string angleType = FormGForceSettings.X1AngleType;
            // A polar point stores its X angle in the selected unit. When the
            // user switches Degrees/Radians via Apply (without Clear), retain
            // the history but convert its X coordinates to the new unit.
            if (!string.IsNullOrEmpty(lastAppliedAngleType) &&
                !string.Equals(lastAppliedAngleType, angleType, StringComparison.Ordinal))
            {
                double factor = angleType == "Radians"
                    ? Math.PI / 180.0 : 180.0 / Math.PI;
                foreach (Series series in chart1.Series)
                    foreach (DataPoint point in series.Points)
                        point.XValue *= factor;
            }
            lastAppliedAngleType = angleType;
            SetPolarChart(chart1);
            SetUpDownChart(chart2);
        }

        /// <summary>Clear both displayed G-force charts and infinite history.</summary>
        public void ClearAllSeriesHistory()
        {
            ClearSeriesHistory(chart1);
            foreach (Series series in chart2.Series)
                series.Points.Clear();
        }
        private void UpdateSnapshotInterval()
        {
            // A large history selection must not overflow the WinForms timer.
            long interval = (long)timer1.Interval * Math.Max(2, FormGForceSettings.HistoryAmountPoints);
            int requested = (int)Math.Min(int.MaxValue, interval);
            if (timer2.Interval != requested)
                timer2.Interval = requested;
        }
        private void ButtonVisibilities()
        {
            toSettingsButton.Visible = !FormGForceSettings.SettingsOpen;
        }
        private void FormGForce_Load(object sender, EventArgs e)
        {

            LiveData.GForceOpen = true;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormGForce_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiveData.GForceOpen = false;
        }
        private int lastChartTelemetryGeneration = -1;
        private int lastHistoryTelemetryGeneration = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonVisibilities();
            UpdateSnapshotInterval();
            if (LiveData.RaceTimeAdvanced &&
                lastChartTelemetryGeneration != LiveData.TelemetryGeneration)
            {
                lastChartTelemetryGeneration = LiveData.TelemetryGeneration;
                PlotPolarChart(chart1);
                PlotUpDownChart(chart2);
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (LiveData.RaceTimeAdvanced &&
                lastHistoryTelemetryGeneration != LiveData.TelemetryGeneration)
            {
                lastHistoryTelemetryGeneration = LiveData.TelemetryGeneration;
                InfiniteHistoryPolarChart(chart1);
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toSettingsButton.Visible = false;
            FormGForceSettings.SettingsOpen = true;
            FormGForceSettings s1 = new FormGForceSettings();
            s1.Show();
        }
        private void refreshAndApplyButton_Click(object sender, EventArgs e)
        {
            bool updateWasEnabled = timer1.Enabled;
            bool snapshotWasEnabled = timer2.Enabled;
            timer1.Enabled = false;
            timer2.Enabled = false;
            try
            {
                ClearAllSeriesHistory();
            }
            finally
            {
                timer1.Enabled = updateWasEnabled;
                timer2.Enabled = snapshotWasEnabled;
            }
        }
        // ----- Consolidated chart/settings members -----

        private const string CurrentSeriesName = "Series1";
        private const string HistorySeriesName = "SeriesHistory";

        public static void SetArrays()
        {
            // Kept for existing callers. Chart points now hold the live history,
            // eliminating the two arrays and their per-frame copies.
        }

        public static void ClearSeriesHistory(Chart chart)
        {
            for (int i = chart.Series.Count - 1; i >= 0; i--)
            {
                if (chart.Series[i].Name != CurrentSeriesName)
                    chart.Series.RemoveAt(i);
            }
            Series current = chart.Series.FindByName(CurrentSeriesName);
            if (current != null) current.Points.Clear();
        }

        // Avoid rebuilding all gradient colors at every 100 ms chart update.
        // Settings changes still take effect on the next paint or Apply.
        private static List<Color> cachedPalette;
        private static string cachedScheme;
        private static int cachedSteps;
        private static int cachedAlpha;
        private static int cachedDivider;

        private static List<Color> Palette
        {
            get
            {
                string scheme = FormGForceSettings.Scheme;
                int steps = FormGForceSettings.GradientSteps;
                int alpha = FormGForceSettings.historyalpha;
                int divider = FormGForceSettings.historycolordivider;
                if (cachedPalette == null || cachedScheme != scheme || cachedSteps != steps ||
                    cachedAlpha != alpha || cachedDivider != divider)
                {
                    cachedPalette = GradientPalette.Create(scheme, steps, alpha, divider);
                    cachedScheme = scheme;
                    cachedSteps = steps;
                    cachedAlpha = alpha;
                    cachedDivider = divider;
                }
                return cachedPalette;
            }
        }

        private static Color HistoryColor(double value, System.Collections.Generic.List<Color> colors)
        {
            int band = GradientPalette.GetBand((float)Math.Abs(value),
                (float)FormGForceSettings.Y1Min, (float)FormGForceSettings.Y1Max,
                FormGForceSettings.GradientSteps);
            return colors[band];
        }

        private static void StyleHistoryPoints(Series series,
                                               System.Collections.Generic.List<Color> colors)
        {
            foreach (DataPoint point in series.Points)
            {
                point.MarkerSize = 2;
                point.MarkerColor = HistoryColor(point.YValues[0], colors);
                point.IsValueShownAsLabel = false;
            }
        }

        private static void StyleCurrentPoint(Series series)
        {
            if (series.Points.Count == 0) return;
            DataPoint current = series.Points[series.Points.Count - 1];
            current.MarkerSize = Math.Max(1, FormGForceSettings.MarkerSize);
            current.MarkerColor = FormGForceSettings.MarkerColor;
            current.IsValueShownAsLabel = true;
        }

        public static void SetPolarChart(Chart chart)
        {
            var area = chart.ChartAreas["ChartArea1"];
            var series = chart.Series[CurrentSeriesName];
            while (series.Points.Count > Math.Max(2, FormGForceSettings.HistoryAmountPoints))
                series.Points.RemoveAt(0);
            series.ChartType = SeriesChartType.Polar;
            series.Color = Color.Transparent;
            series.MarkerStyle = MarkerStyle.Circle;
            series.SmartLabelStyle.Enabled = false;
            series.LabelBackColor = FormGForceSettings.BackgroundColor;
            area.BackColor = FormGForceSettings.BackgroundColor;

            var x = area.AxisX;
            x.Minimum = FormGForceSettings.X1Min;
            x.Maximum = FormGForceSettings.X1AngleType == "Degrees"
                ? FormGForceSettings.X1MaxDegrees
                : FormGForceSettings.X1MaxDegrees * Math.PI / 180.0;
            if (x.Maximum <= x.Minimum) x.Maximum = x.Minimum + 1;
            x.Interval = x.Maximum / Math.Max(1, FormGForceSettings.X1MajorIntervalFraction);
            x.MajorGrid.Interval = x.Interval;
            x.LabelStyle.Format = FormGForceSettings.X1AngleType == "Degrees" ? "F0" : "F2";
            x.LabelStyle.Font = new Font(FormGForceSettings.X1FontFamily, FormGForceSettings.X1FontSize,
                                         FormGForceSettings.X1FontStyle);
            x.LabelStyle.ForeColor = FormGForceSettings.X1FontColor;
            x.MajorGrid.LineWidth = FormGForceSettings.X1MajorLineWidth;
            x.MajorGrid.LineColor = FormGForceSettings.X1MajorColor;
            x.MinorGrid.Enabled = FormGForceSettings.X1MinorEnabled;
            x.MinorGrid.LineDashStyle = FormGForceSettings.X1MinorDashStyle;
            x.MinorGrid.LineWidth = FormGForceSettings.X1MinorLineWidth;
            x.MinorGrid.Interval = x.Interval / Math.Max(1, FormGForceSettings.X1MinorIntervalFraction);
            x.MinorGrid.LineColor = FormGForceSettings.X1MinorColor;

            var y = area.AxisY;
            y.Minimum = FormGForceSettings.Y1Min;
            y.Maximum = FormGForceSettings.Y1Max;
            if (y.Maximum <= y.Minimum) y.Maximum = y.Minimum + 1;
            y.LineColor = Color.Transparent;
            y.LabelStyle.Font = new Font(FormGForceSettings.Y1FontFamily, FormGForceSettings.Y1FontSize,
                                         FormGForceSettings.Y1FontStyle);
            y.LabelStyle.ForeColor = FormGForceSettings.Y1FontColor;
            y.LabelStyle.Format = "F" + FormGForceSettings.Y1MajorDecimals;
            y.MajorGrid.LineWidth = FormGForceSettings.Y1MajorLineWidth;
            y.MajorGrid.LineColor = FormGForceSettings.Y1MajorColor;
            double interval = (y.Maximum - y.Minimum) / Math.Max(1, FormGForceSettings.GradientSteps)
                * FormGForceSettings.Y1IntervalDivider;
            y.Interval = interval;
            y.MajorGrid.Interval = interval;
            y.LabelStyle.Interval = interval;
            y.LabelStyle.IntervalOffset = 0;
            y.MinorGrid.Enabled = FormGForceSettings.Y1MinorEnabled;
            y.MinorGrid.LineDashStyle = FormGForceSettings.Y1MinorDashStyle;
            y.MinorGrid.LineWidth = FormGForceSettings.Y1MinorLineWidth;
            y.MinorGrid.Interval = interval / Math.Max(1, FormGForceSettings.Y1MinorIntervalFraction);
            y.MinorGrid.LineColor = FormGForceSettings.Y1MinorColor;

            var colors = Palette;
            foreach (Series existing in chart.Series)
                StyleHistoryPoints(existing, colors);
            StyleCurrentPoint(series);
        }

        public static void PlotPolarChart(Chart chart)
        {
            Series series = chart.Series[CurrentSeriesName];
            int limit = Math.Max(2, FormGForceSettings.HistoryAmountPoints);
            var colors = Palette;
            double angle = FormGForceSettings.X1AngleType == "Degrees"
                ? LiveData.GetFullListDoubleValue(TelemetryPrefix.Body, GameMemoryConfig.Field("WF_BodyAccelDataOffset", "Body_XZGAngleDeg"))
                : LiveData.GetFullListDoubleValue(TelemetryPrefix.Body, GameMemoryConfig.Field("WF_BodyAccelDataOffset", "XZGAngleRad"));
            double magnitude = Math.Round(
                LiveData.GetFullListDoubleValue(TelemetryPrefix.Body, GameMemoryConfig.Field("WF_BodyAccelDataOffset", "XZG")), 2);
            if (double.IsNaN(angle) || double.IsInfinity(angle) ||
                double.IsNaN(magnitude) || double.IsInfinity(magnitude)) return;
            // Preserve the last good live marker if the new sample is missing.
            if (series.Points.Count > 0)
            {
                DataPoint previous = series.Points[series.Points.Count - 1];
                previous.MarkerSize = 2;
                previous.MarkerColor = HistoryColor(previous.YValues[0], colors);
                previous.IsValueShownAsLabel = false;
            }
            series.Points.AddXY(angle, magnitude);
            while (series.Points.Count > limit)
                series.Points.RemoveAt(0);
            StyleCurrentPoint(series);
        }

        public static void InfiniteHistoryPolarChart(Chart chart)
        {
            if (!FormGForceSettings.InfiniteHistoryEnabled) return;
            Series current = chart.Series[CurrentSeriesName];
            if (current.Points.Count == 0) return;

            Series history = chart.Series.FindByName(HistorySeriesName);
            if (history == null)
            {
                history = new Series(HistorySeriesName)
                {
                    ChartArea = current.ChartArea,
                    ChartType = SeriesChartType.Polar,
                    Color = Color.Transparent,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 2,
                    IsValueShownAsLabel = false
                };
                history.SmartLabelStyle.Enabled = false;
                chart.Series.Insert(0, history);
            }

            var colors = Palette;
            foreach (DataPoint point in current.Points)
            {
                int index = history.Points.AddXY(point.XValue, point.YValues[0]);
                history.Points[index].MarkerColor = HistoryColor(point.YValues[0], colors);
            }
            int maxPoints = FormGForceSettings.MaxInfiniteHistoryPoints;
            if (maxPoints > 0)
            {
                while (history.Points.Count > maxPoints)
                    history.Points.RemoveAt(0);
            }
        }

        public static void SetUpDownChart(Chart chart)
        {
            var area = chart.ChartAreas["ChartArea1"];
            // Reserve about 45% of the narrow 72px chart for Y tick labels.
            // Without explicit plot bounds, Chart automatically reserves large
            // horizontal margins and can squeeze the gradient to nothing.
            area.Position.Auto = false;
            area.Position = new ElementPosition(0f, 0f, 100f, 100f);
            area.InnerPlotPosition.Auto = false;
            area.InnerPlotPosition = new ElementPosition(45f, 4f, 53f, 92f);
            double maximum = Math.Max(0.001, FormGForceSettings.Y1Max);
            int steps = FormGForceSettings.GradientSteps;
            double width = maximum / steps;
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 1;
            area.AxisY.Minimum = -maximum;
            area.AxisY.Maximum = maximum;
            area.AxisY.MajorGrid.Interval = width;
            area.AxisY.Interval = width;
            area.AxisY.StripLines.Clear();

            var colors = Palette;
            for (int band = 1; band <= steps; band++)
            {
                Color color = colors[band];
                area.AxisY.StripLines.Add(new StripLine
                {
                    IntervalOffset = (band - 1) * width,
                    StripWidth = width,
                    BackColor = color
                });
                area.AxisY.StripLines.Add(new StripLine
                {
                    IntervalOffset = -band * width,
                    StripWidth = width,
                    BackColor = color
                });
            }

            Series series = chart.Series[CurrentSeriesName];
            series.Color = FormGForceSettings.MarkerColor;
            series.LabelBackColor = FormGForceSettings.BackgroundColor;
        }

        public static void PlotUpDownChart(Chart chart)
        {
            Series series = chart.Series[CurrentSeriesName];
            double value = Math.Round(
                LiveData.GetFullListDoubleValue(TelemetryPrefix.Body, GameMemoryConfig.Field("WF_BodyAccelDataOffset", "YG")), 2);
            if (double.IsNaN(value) || double.IsInfinity(value)) return;
            series.Points.Clear();
            series.Color = FormGForceSettings.MarkerColor;
            series.Points.AddXY(0.3, value);
            series.Points.AddXY(0.7, value);
            series.Points[series.Points.Count - 1].IsValueShownAsLabel = true;
        }
    }
}
