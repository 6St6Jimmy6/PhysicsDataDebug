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
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace Physics_Data_Debug
{
    public partial class Form4Wheels : Form
    {
        bool PauseUpdate;
        private readonly ChartZoomBehavior chartZoom;
        private bool? displayedSettingsOpen;
        private string displayedZSelection;
        private Form4WheelsSettings settingsForm;
        private bool filterMigrationComplete;
        private static bool NoTireContactLimiterEnabled;
        private static readonly List<string> xyzAxisSelection = new List<string> { "", "", "" };

        // ----- Consolidated chart/settings members -----
        public static int Alpha { get; set; } = 255;
        public static int Divider { get; set; } = 2;
        public static int HistoryAlpha { get; set; } = 255;
        public static int HistoryColorDivider { get; set; } = 2;

        public static int Steps
        {
            get => Form4WheelsSettings.GradientSteps;
            set => Form4WheelsSettings.GradientSteps = value;
        }

        public static string FL_SeriesString { get; set; } = "SeriesFL";
        public static string FR_SeriesString { get; set; } = "SeriesFR";
        public static string RL_SeriesString { get; set; } = "SeriesRL";
        public static string RR_SeriesString { get; set; } = "SeriesRR";

        public static SeriesChartType ChartType { get; set; } = Form4WheelsSettings.SeriesChartType;
        public static MarkerStyle HistoryMarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int MarkerSizeHistory { get; set; } = 2;
        public static List<Color> MarkerColors { get; set; } = new List<Color>();

        public Form4Wheels()
        {
            InitializeComponent();
            timer1.Enabled = false;
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
            {
                return;
            }
            chartZoom = new ChartZoomBehavior(chart1, () =>
                Form4WheelsSettings.LiveCursorEnabled && Form4WheelsSettings.LiveCursorZoomable);
            // WinForms Chart cannot resize to zero pixels. Set up chart areas
            // only after this REAL form has been laid out and shown, not while
            // Program.Main is constructing an invisible defaults-only instance.
            Shown += (sender, args) =>
            {
                SetChartsForForm();
                ApplyLegendWidth();
                timer1.Enabled = true;
            };
            PauseUpdate = false;
            timer1.Interval = 50;
            settingsForm = new Form4WheelsSettings();
            settingsForm.BindFilterChart(this);
            InitializeChartFilters();

            FormClosing += (sender, args) =>
            {
                JsonFormSettings.SaveAllSettings(settingsForm);

                if (filterMigrationComplete)
                    JsonFormSettings.SaveAllSettings(this);
            };

            Disposed += (sender, args) => settingsForm.Dispose();

            // Capture untouched controls before Form4Wheels_Load restores JSON.
            ComboBoxBehaviors.EnableSearch(this);
        }

        // Enum for later usage
        public enum ColorScheme
        {
            Default,
            GreenRed,
            Colorblind
        }
        private void GetColorSchemeColors()
        {
            MarkerColors = GradientPalette.Create(
                Form4WheelsSettings.Scheme, Steps,
                HistoryAlpha, HistoryColorDivider);
        }
        // =============================================================
        // New Dictionary Version
        // =============================================================
        // =============================================================
        // Axis configuration
        // =============================================================
        private sealed class AxisDefaults
        {
            public float Max { get; private set; }
            public float Min { get; private set; }
            public double MajorInterval { get; private set; }
            public int Decimals { get; private set; }
            public bool MinorEnabled { get; private set; }
            public int MinorIntervalFraction { get; private set; }

            public AxisDefaults( float max, float min, double majorInterval, int decimals, bool minorEnabled, int minorIntervalFraction)
            {
                Max = max;
                Min = min;
                MajorInterval = majorInterval;
                Decimals = decimals;
                MinorEnabled = minorEnabled;
                MinorIntervalFraction = minorIntervalFraction;
            }
        }
        // =============================================================
        // Shared axis configuration
        //
        // This is the ONLY place where the axis defaults need to be
        // defined.
        //
        // Min is the normal/non-absolute minimum.
        // AbsoluteZAxisSelectionDefaults() always uses 0 as the minimum.
        // =============================================================
        private static readonly Dictionary<string, AxisDefaults> AxisDefaultsMap =
            new Dictionary<string, AxisDefaults>
            {
            // ---------------------------------------------------------
            // Tire values
            // ---------------------------------------------------------
                { "TravelSpeed", new AxisDefaults(400f, -200f, 100d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "AngularVelocity", new AxisDefaults(400f, -200f, 100d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "VerticalLoad", new AxisDefaults(10000f, 0f, 1000d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "VerticalDeflection", new AxisDefaults(0.15f, 0f, 0.03d, 3, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "LoadedRadius", new AxisDefaults(0.5f, 0f, 0.1d, 3, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "EffectiveRadius", new AxisDefaults(0.5f, 0f, 0.1d, 3, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "ContactLength", new AxisDefaults(0.5f, 0f, 0.1d, 3, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "CurrentContactBrakeTorque", new AxisDefaults(5000f, 0f, 500d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "CurrentContactBrakeTorqueMax", new AxisDefaults(5000f, 0f, 500d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Angles
            // ---------------------------------------------------------
                { "SteerAngleDeg", new AxisDefaults(45f, -45f, 15d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "CamberAngleDeg", new AxisDefaults(10f, -10f, 4d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "SlipAngleDeg", new AxisDefaults(45f, -45f, 15d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Loads
            // ---------------------------------------------------------
                { "LateralLoad", new AxisDefaults(10000f, -10000f, 1000d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "LongitudinalLoad", new AxisDefaults(10000f, -10000f, 1000d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Friction
            // ---------------------------------------------------------
                { "LateralFriction", new AxisDefaults(2f, -2f, 0.5d, 2, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "LongitudinalFriction", new AxisDefaults(2f, -2f, 0.5d, 2, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "TotalFriction", new AxisDefaults(2f, -2f, 0.5d, 2, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "TotalFrictionAngleDeg", new AxisDefaults(360f, 0f, 90d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Slip
            // ---------------------------------------------------------
                { "LateralSlipSpeed", new AxisDefaults(20f, -20f, 5d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "LongitudinalSlipSpeed", new AxisDefaults(20f, -20f, 5d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "SlipRatio", new AxisDefaults(1f, -1f, 0.2d, 2, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Moments
            // ---------------------------------------------------------
                { "Mx", new AxisDefaults(1000f, -1000f, 100d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "Mz", new AxisDefaults(1000f, -1000f, 100d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "My", new AxisDefaults(1000f, -1000f, 100d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Temperature
            //
            // Note:
            // The original SelectionDefaults() uses -20 as the
            // normal minimum for temperature.
            // AbsoluteZAxisSelectionDefaults() will use 0.
            // ---------------------------------------------------------
                { "TreadTemperature", new AxisDefaults(380f, -20f, 20d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "InnerTemperature", new AxisDefaults(380f, -20f, 20d, 0, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            // ---------------------------------------------------------
            // Suspension
            // ---------------------------------------------------------
                { "SuspensionLength", new AxisDefaults(1f, 0f, 0.1d, 4, true, 2) }, // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
                { "SuspensionVelocity", new AxisDefaults(10f, -10f, 2d, 4, true, 2) } // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            };

        public List<object> SelectionDefaults(string axisSelection, bool isAbsolute)
        {
            // Existing defaults are keyed by relative/raw JSON members. New
            // global prefixes must resolve to those same settings.
            string rawSelection = GameMemoryConfig.LegacySelectionName(axisSelection);
            if (!string.IsNullOrEmpty(rawSelection)) axisSelection = rawSelection;
            // ---------------------------------------------------------
            // Special case: Race Time
            // ---------------------------------------------------------
            if (axisSelection == "RaceTime")
            {
                return new List<object>{ float.NaN, 0f, 1000d, 0, false, 60 }; // Max, Min, MajorInterval, Decimals, MinorEnabled, MinorIntervalFraction
            }
            // ---------------------------------------------------------
            // Special case: None
            // ---------------------------------------------------------
            if (axisSelection == "None")
            {
                return new List<object>{ 2f, 0f, 0d, 0, false, 1 };
            }
            if (GameMemoryConfig.TryGetWheelAxisDefaults(axisSelection.ToString(), out WheelAxisProfile configured))
                return new List<object> { configured.Max, isAbsolute ? 0f : configured.Min,
                    configured.MajorInterval, configured.Decimals,
                    configured.MinorEnabled, configured.MinorIntervalFraction };
            // ---------------------------------------------------------
            // Dictionary lookup
            // ---------------------------------------------------------
            AxisDefaults defaults;
            if (!AxisDefaultsMap.TryGetValue(axisSelection, out defaults))
            {
                return CreateAutoScaleDefaults(isAbsolute);
            }
            // ---------------------------------------------------------
            // Absolute axes always start at zero.
            //
            // Otherwise use the configured minimum.
            // ---------------------------------------------------------
            float min = isAbsolute
                ? 0f
                : defaults.Min;
            // ---------------------------------------------------------
            // Return values
            // ---------------------------------------------------------
            return new List<object>{ defaults.Max, min, defaults.MajorInterval, defaults.Decimals, defaults.MinorEnabled, defaults.MinorIntervalFraction };
        }

        // =============================================================
        // Auto-scale fallback
        // =============================================================
        private List<object> CreateAutoScaleDefaults(bool isAbsolute)
        {
            return new List<object> { float.NaN, isAbsolute ? 0f : float.NaN, 0d, 2, false, 2 };
        }

        // =============================================================
        // String Compatible
        // =============================================================
        public List<object> AbsoluteZAxisSelectionDefaults(string axisSelection)
        {
            // =============================================================
            // AbsoluteZAxisSelectionDefaults
            //
            // Uses SelectionDefaults() with absolute mode enabled.
            //
            // [0] = defaultMax
            // [1] = defaultMin
            // =============================================================

            var defaults = SelectionDefaults(axisSelection, true);

            return new List<object> { defaults[0], defaults[1] };
        }


        private void X1AxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == true)
            {
                Form4WheelsSettings.X1Max = (float)axisDefaultSelectionDefaults[0];
                Form4WheelsSettings.X1Min = (float)axisDefaultSelectionDefaults[1];
                Form4WheelsSettings.X1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                Form4WheelsSettings.X1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                Form4WheelsSettings.X1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                Form4WheelsSettings.X1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void Y1AxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == true)
            {
                Form4WheelsSettings.Y1Max = (float)axisDefaultSelectionDefaults[0];
                Form4WheelsSettings.Y1Min = (float)axisDefaultSelectionDefaults[1];
                Form4WheelsSettings.Y1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                Form4WheelsSettings.Y1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                Form4WheelsSettings.Y1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                Form4WheelsSettings.Y1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void Z1AxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == true)
            {
                Form4WheelsSettings.Z1Max = (float)axisDefaultSelectionDefaults[0];
                Form4WheelsSettings.Z1Min = (float)axisDefaultSelectionDefaults[1];
                //Form4WheelsSettings.Z1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                //Form4WheelsSettings.Z1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                //Form4WheelsSettings.Z1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                //Form4WheelsSettings.Z1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        public static void AddChart(Chart chartName, string chartAreaName)
        {
            // Shared layouts (All In One / Front-Rear) use the same area for
            // several wheels. Configure it only once per chart rebuild.
            if (!chartName.ChartAreas.IsUniqueName(chartAreaName))
                return;

            chartName.ChartAreas.Add(chartAreaName);
            ChartArea area = chartName.ChartAreas[chartAreaName];

            area.BackColor = Form4WheelsSettings.BackgroundColor;

            // X Axis
            area.AxisX.Maximum = Form4WheelsSettings.X1Max;
            area.AxisX.Minimum = Form4WheelsSettings.X1Min;

            area.AxisX.Interval = Form4WheelsSettings.X1MajorInterval;
            area.AxisX.MajorGrid.Interval = Form4WheelsSettings.X1MajorInterval;
            area.AxisX.LabelStyle.Format = "F" + Form4WheelsSettings.X1MajorDecimals;// decimals

            area.AxisX.LabelStyle.Font = new Font(Form4WheelsSettings.X1FontFamily, Form4WheelsSettings.X1FontSize, Form4WheelsSettings.X1FontStyle);
            area.AxisX.LabelStyle.ForeColor = Form4WheelsSettings.X1FontColor;

            area.AxisX.Title = Form4WheelsSettings.X1Selection;
            area.AxisX.TitleFont = new Font(Form4WheelsSettings.X1FontFamily, Form4WheelsSettings.X1FontSize, Form4WheelsSettings.X1FontStyle);
            area.AxisX.TitleForeColor = Form4WheelsSettings.X1FontColor;

            area.AxisX.MajorGrid.LineWidth = Form4WheelsSettings.X1MajorLineWidth;
            area.AxisX.MajorGrid.LineColor = Form4WheelsSettings.X1MajorColor;

            area.AxisX.MinorGrid.Enabled = Form4WheelsSettings.X1MinorEnabled;
            area.AxisX.MinorGrid.LineDashStyle = Form4WheelsSettings.X1MinorDashStyle;
            area.AxisX.MinorGrid.LineWidth = Form4WheelsSettings.X1MinorLineWidth;
            area.AxisX.MinorGrid.Interval = area.AxisX.Interval / Math.Max(1, Form4WheelsSettings.X1MinorIntervalFraction);
            area.AxisX.MinorGrid.LineColor = Form4WheelsSettings.X1MinorColor;

            area.AxisX.ScrollBar.BackColor = Color.Empty;
            area.AxisX.ScrollBar.ButtonColor = Form4WheelsSettings.X1MajorColor;
            area.AxisX.ScrollBar.LineColor = Form4WheelsSettings.X1FontColor;
            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScrollBar.Enabled = true;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            area.CursorX.AutoScroll = true;
            area.CursorX.IsUserEnabled = true;
            area.CursorX.IsUserSelectionEnabled = true;
            area.CursorX.Interval = 0.01;
            area.CursorX.LineColor = Form4WheelsSettings.MarkerColor;

            // Y Axis
            area.AxisY.Title = Form4WheelsSettings.Y1Selection;
            area.AxisY.Minimum = Form4WheelsSettings.Y1Min;
            area.AxisY.Maximum = Form4WheelsSettings.Y1Max;

            area.AxisY.LabelStyle.Font = new Font(Form4WheelsSettings.Y1FontFamily, Form4WheelsSettings.Y1FontSize, Form4WheelsSettings.Y1FontStyle);
            area.AxisY.LabelStyle.ForeColor = Form4WheelsSettings.Y1FontColor;

            area.AxisY.TitleFont = new Font(Form4WheelsSettings.Y1FontFamily, Form4WheelsSettings.Y1FontSize, Form4WheelsSettings.Y1FontStyle);
            area.AxisY.TitleForeColor = Form4WheelsSettings.Y1FontColor;

            area.AxisY.MajorGrid.LineWidth = Form4WheelsSettings.Y1MajorLineWidth;
            area.AxisY.LabelStyle.Format = "F" + Form4WheelsSettings.Y1MajorDecimals;// decimals
            area.AxisY.MajorGrid.LineColor = Form4WheelsSettings.Y1MajorColor;
            area.AxisY.Interval = Form4WheelsSettings.Y1MajorInterval; // TickMark Interval
            area.AxisY.MajorGrid.Interval = Form4WheelsSettings.Y1MajorInterval; // Major Grid Interval
            area.AxisY.LabelStyle.Interval = Form4WheelsSettings.Y1MajorInterval; // Major Grid Label Interval
            area.AxisY.LabelStyle.IntervalOffset = 0;

            area.AxisY.MinorGrid.Enabled = Form4WheelsSettings.Y1MinorEnabled;
            area.AxisY.MinorGrid.LineDashStyle = Form4WheelsSettings.Y1MinorDashStyle;
            area.AxisY.MinorGrid.LineWidth = Form4WheelsSettings.Y1MinorLineWidth;
            area.AxisY.MinorGrid.Interval = area.AxisY.Interval / Math.Max(1, Form4WheelsSettings.Y1MinorIntervalFraction);
            area.AxisY.MinorGrid.LineColor = Form4WheelsSettings.Y1MinorColor;

            area.AxisY.ScrollBar.BackColor = Color.Empty;
            area.AxisY.ScrollBar.ButtonColor = Form4WheelsSettings.Y1MajorColor;
            area.AxisY.ScrollBar.LineColor = Form4WheelsSettings.Y1FontColor;
            area.AxisY.ScaleView.Zoomable = true;
            area.AxisY.ScrollBar.Enabled = true;
            area.AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            area.CursorY.AutoScroll = true;
            area.CursorY.IsUserEnabled = true;
            area.CursorY.IsUserSelectionEnabled = true;
            area.CursorY.Interval = 0.01;
            area.CursorY.LineColor = Form4WheelsSettings.MarkerColor;

            // Shared styling with the offline chart, including independently
            // configured major/minor alpha and line patterns.
            ChartAppearance.ConfigureGrid(area.AxisX.MajorGrid,
                Form4WheelsSettings.X1MajorColor, Form4WheelsSettings.XMajorAlpha,
                Form4WheelsSettings.XMajorWidth, Form4WheelsSettings.XMajorDashStyle);
            ChartAppearance.ConfigureGrid(area.AxisX.MinorGrid,
                Form4WheelsSettings.X1MinorColor, Form4WheelsSettings.XMinorAlpha,
                Form4WheelsSettings.XMinorWidth, Form4WheelsSettings.X1MinorDashStyle);
            ChartAppearance.ConfigureGrid(area.AxisY.MajorGrid,
                Form4WheelsSettings.Y1MajorColor, Form4WheelsSettings.YMajorAlpha,
                Form4WheelsSettings.YMajorWidth, Form4WheelsSettings.YMajorDashStyle);
            ChartAppearance.ConfigureGrid(area.AxisY.MinorGrid,
                Form4WheelsSettings.Y1MinorColor, Form4WheelsSettings.YMinorAlpha,
                Form4WheelsSettings.YMinorWidth, Form4WheelsSettings.Y1MinorDashStyle);
            ChartAppearance.ConfigureCartesianAxisLines(area);
            ChartAppearance.ConfigureZoom(area, Form4WheelsSettings.LiveCursorEnabled,
                Form4WheelsSettings.LiveCursorZoomable,
                Form4WheelsSettings.CursorColor, Form4WheelsSettings.CursorAlpha,
                Form4WheelsSettings.CursorWidth, Form4WheelsSettings.CursorDash);
        }
        public static void UpdateSeriesColors(Chart chart)
        {
            foreach (Series series in chart.Series)
            {
                if (GradientPalette.TryGetBandFromSeriesName(
                    series.Name, Steps, out int band))
                {
                    Color color = MarkerColors[band];
                    series.Color = color;
                    series.MarkerColor = color;

                    // Data points may retain their own colors after DataBindXY.
                    // Update those too, including points recorded before Apply.
                    foreach (DataPoint point in series.Points)
                    {
                        point.Color = color;
                        point.MarkerColor = color;
                    }
                }
            }
        }
        private static void AddHistoryColorSeries(Chart chartName, string chartAreaName, string seriesName, Color color)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].ChartArea = chartAreaName;
            chartName.Series[seriesName].Color = color;
            chartName.Series[seriesName].MarkerColor = color;
            chartName.Series[seriesName].ChartType = ChartType;
            chartName.Series[seriesName].MarkerStyle = HistoryMarkerStyle;
            chartName.Series[seriesName].MarkerSize = MarkerSizeHistory;
        }
        private static void AddSeries(Chart chartName, string chartAreaName, string seriesName)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].ChartArea = chartAreaName;
            chartName.Series[seriesName].Color = Form4WheelsSettings.MarkerColor;
            chartName.Series[seriesName].MarkerColor = Form4WheelsSettings.MarkerColor;
            chartName.Series[seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[seriesName].MarkerStyle = HistoryMarkerStyle;
            chartName.Series[seriesName].MarkerSize = MarkerSizeHistory;
            chartName.Series[seriesName].SmartLabelStyle.Enabled = false;
            chartName.Series[seriesName].LabelBackColor = chartName.ChartAreas[chartAreaName].BackColor;
        }
        private void ApplyAxisSelectionDefaults()
        {
            // Axis defaults depend on the selected measurements, not the wheel.
            // Calculate them once per chart rebuild instead of four times.
            var x = SelectionDefaults(Form4WheelsSettings.X1Selection, Form4WheelsSettings.AbsoluteValues);
            Form4WheelsSettings.X1DefaultMax = (float)x[0];
            Form4WheelsSettings.X1DefaultMin = (float)x[1];
            Form4WheelsSettings.X1DefaultMajorInterval = (double)x[2];
            Form4WheelsSettings.X1DefaultMajorDecimals = (int)x[3];
            Form4WheelsSettings.X1DefaultMinorEnabled = (bool)x[4];
            Form4WheelsSettings.X1DefaultMinorIntervalFraction = (int)x[5];
            X1AxisToDefaults(Form4WheelsSettings.X1Defaults, x);

            var y = SelectionDefaults(Form4WheelsSettings.Y1Selection, Form4WheelsSettings.AbsoluteValues);
            Form4WheelsSettings.Y1DefaultMax = (float)y[0];
            Form4WheelsSettings.Y1DefaultMin = (float)y[1];
            Form4WheelsSettings.Y1DefaultMajorInterval = (double)y[2];
            Form4WheelsSettings.Y1DefaultMajorDecimals = (int)y[3];
            Form4WheelsSettings.Y1DefaultMinorEnabled = (bool)y[4];
            Form4WheelsSettings.Y1DefaultMinorIntervalFraction = (int)y[5];
            Y1AxisToDefaults(Form4WheelsSettings.Y1Defaults, y);

            var z = AbsoluteZAxisSelectionDefaults(Form4WheelsSettings.Z1Selection);
            Form4WheelsSettings.Z1DefaultMax = (float)z[0];
            Form4WheelsSettings.Z1DefaultMin = (float)z[1];
            Z1AxisToDefaults(Form4WheelsSettings.Z1Defaults, z);
        }

        public void SetChart(Chart chartName, string seriesName, string chartAreaName)
        {
            // Chart and axis defaults are prepared once in SetChartsForForm.
            chartName.BackColor = Color.Transparent;
            AddChart(chartName, chartAreaName);
            // New Marker color stuff
            for (int band = 1; band <= Steps; band++)
            {
                AddHistoryColorSeries(chartName, chartAreaName,
                    seriesName + GradientPalette.SeriesSuffix(band), MarkerColors[band]);
            }
            AddSeries(chartName, chartAreaName, seriesName);
            RebindHistory(chartName, seriesName);
        }
        /// <summary>
        /// Set the Z legend panel to the configured width without changing chart data.
        /// Leave enough room for the main chart when the form is narrow.
        /// </summary>
        public void ApplyLegendWidth()
        {
            int available = chartAndLegend.ClientSize.Width - chartAndLegend.SplitterWidth;
            if (available <= chartAndLegend.Panel1MinSize + chartAndLegend.Panel2MinSize)
                return;

            int width = Math.Max(chartAndLegend.Panel2MinSize,
                Math.Min(Form4WheelsSettings.LegendWidthPixels,
                    available - chartAndLegend.Panel1MinSize));
            int splitterDistance = available - width;
            if (splitterDistance != chartAndLegend.SplitterDistance)
                chartAndLegend.SplitterDistance = splitterDistance;
        }

        public void SetUpDownChart(Chart chartName)
        {
            ChartArea area = chartName.ChartAreas["ChartArea1"];
            Series legendSeries = chartName.Series["Series1"];
            float min = Form4WheelsSettings.Z1Min;
            float max = Form4WheelsSettings.Z1Max;
            int steps = Steps;
            UpdateLegendHeading();

            if (max <= min)
            {
                area.AxisY.StripLines.Clear();
                return;
            }

            double interval = (max - min) / steps;
            area.AxisY.Minimum = min;
            area.AxisY.Maximum = max;
            // The legend must not display unrounded binary floating-point values.
            // Format labels only: retain exact min/max and band calculations.
            area.AxisY.LabelStyle.Format = "F" + Form4WheelsSettings.ZLegendLabelDecimals;
            area.AxisY.MajorGrid.Interval = interval;
            area.AxisY.Interval = interval;
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 1;
            legendSeries.Color = Color.Transparent;
            legendSeries.LabelBackColor = Color.Transparent;
            area.AxisY.StripLines.Clear();

            int alpha = Form4WheelsSettings.Scheme == "Colorblind"
                ? HistoryAlpha : Alpha;
            List<Color> colors = GradientPalette.Create(
                Form4WheelsSettings.Scheme, steps, alpha, Divider);

            for (int step = 0; step <= steps; step++)
            {
                double position = min + step * interval;
                var stripLine = new StripLine
                {
                    StripWidth = interval,
                    // Retain the existing placement convention for negative/positive ranges.
                    IntervalOffset = position < 0 ? position : position - interval,
                    BackColor = step == 0 ? Color.Transparent : colors[step]
                };
                area.AxisY.StripLines.Add(stripLine);
            }
        }
        // Chart-area titles follow their associated area when the chart is resized.
        // Unlike standalone Labels, they also support every wheel layout without
        // hard-coded pixel coordinates.
        private static void AddChartAreaHeading(Chart chart, string areaName, string heading)
        {
            if (chart.ChartAreas.FindByName(areaName) == null)
                return;

            chart.Titles.Add(new Title
            {
                Name = "Heading_" + areaName,
                Text = heading,
                DockedToChartArea = areaName,
                IsDockedInsideChartArea = false,
                Docking = Docking.Top,
                Alignment = ContentAlignment.TopCenter,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold)
            });
        }

        private void UpdateLegendHeading()
        {
            // The legend has only one chart area. Its title belongs to the
            // gradient chart itself rather than to the main wheel plot.
            Title title;
            if (GradientChart.Titles.Count == 0)
            {
                title = new Title { Name = "ZColorHeading" };
                GradientChart.Titles.Add(title);
            }
            else
            {
                title = GradientChart.Titles[0];
            }
            title.Text = Form4WheelsSettings.Z1Selection;
            title.ForeColor = Color.White;
            title.BackColor = Color.Transparent;
            title.Docking = Docking.Top;
            title.Alignment = ContentAlignment.TopCenter;
        }

        private bool recoveringChartType;

        public void SetChartsForForm()
        {
            bool measure = ChartType != SeriesChartType.FastPoint && !recoveringChartType;
            var watch = measure ? System.Diagnostics.Stopwatch.StartNew() : null;
            try
            {
                RebuildCharts();
                if (measure) chart1.Refresh();
            }
            catch (Exception ex) when (measure && (ex is ArgumentException || ex is InvalidOperationException || ex is NotSupportedException || ex is NotImplementedException || ex is System.Runtime.InteropServices.ExternalException))
            {
                FallBackToFastPoint("Chart type could not be rendered: " + ex.Message);
                return;
            }
            if (measure && watch.ElapsedMilliseconds > 5000)
                FallBackToFastPoint("Initial chart loading exceeded 5 seconds.");
        }

        private void FallBackToFastPoint(string reason)
        {
            if (recoveringChartType || ChartType == SeriesChartType.FastPoint) return;
            recoveringChartType = true;
            try
            {
                ChartType = SeriesChartType.FastPoint;
                Form4WheelsSettings.SeriesChartType = SeriesChartType.FastPoint;
                settingsForm.SetFastPointAfterFallback();
                RebuildCharts();
                chart1.Invalidate();
                System.Diagnostics.Debug.WriteLine(reason + " Reverted to FastPoint.");
                Text = "Four Wheels - FastPoint fallback: " + reason;
            }
            finally { recoveringChartType = false; }
        }

        private void RebuildCharts()
        {
            ApplyAxisSelectionDefaults();
            GetColorSchemeColors();
            string selectedLayout = Form4WheelsSettings.WheelChartsSelect;
            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            // Chart placement and wheel selection share one layout definition
            // with the Offline Chart; axis field names never change by layout.
            foreach (string wheel in FourWheelsFieldSelection.WheelsForLayout(selectedLayout))
            {
                string seriesName = wheel == "FL" ? FL_SeriesString :
                    wheel == "FR" ? FR_SeriesString :
                    wheel == "RL" ? RL_SeriesString : RR_SeriesString;
                SetChart(chart1, seriesName,
                    FourWheelsFieldSelection.AreaForLayout(selectedLayout, wheel));
            }
            foreach (ChartArea area in chart1.ChartAreas)
            {
                string areaWheel = FourWheelsFieldSelection.WheelsForLayout(selectedLayout)
                    .FirstOrDefault(w => FourWheelsFieldSelection.AreaForLayout(selectedLayout, w) == area.Name);
                AddChartAreaHeading(chart1, area.Name,
                    FourWheelsFieldSelection.AreaTitle(selectedLayout, areaWheel));
            }

            // Apply the palette to all points restored by RebindHistory, not only
            // to series-level styles or newly incoming points.
            UpdateSeriesColors(chart1);
            chart1.Invalidate();
            SetUpDownChart(GradientChart);
        }
        public void ClearAllSeriesHistory()
        {
            ClearListDataHistory();
        }
        private void ButtonLabelVisibilities()
        {
            bool settingsOpen = Form4WheelsSettings.SettingsOpen;
            if (displayedSettingsOpen != settingsOpen)
            {
                toSettingsButton.Visible = !settingsOpen;
                displayedSettingsOpen = settingsOpen;
            }

            string zSelection = Form4WheelsSettings.Z1Selection;
            if (displayedZSelection != zSelection)
            {
                UpdateLegendHeading();
                displayedZSelection = zSelection;
            }
        }
        private void Form4Wheels_Load(object sender, EventArgs e)
        {
            JsonFormSettings.LoadAllSettings(this);
            filterMigrationComplete = JsonFormSettings.MigrateFourWheelsFilters(settingsForm);

            settingsForm.RestoreForChart();

            UpdateFollowedAxes();
            UpdateAllLimiters();
            LiveData._4WheelsOpen = true;
        }
        private void Form4Wheels_FormClosed(object sender, FormClosedEventArgs e)
        {
            chartZoom.Dispose();
            LiveData._4WheelsOpen = false;
        }
        private int lastPlottedTelemetryGeneration = -1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonLabelVisibilities();
            UpdateFollowedAxes();
            if (LiveData.RaceTimeAdvanced && !PauseUpdate &&
                lastPlottedTelemetryGeneration != LiveData.TelemetryGeneration)
            {
                lastPlottedTelemetryGeneration = LiveData.TelemetryGeneration;
                xyzAxisSelection[0] = Form4WheelsSettings.X1Selection;
                xyzAxisSelection[1] = Form4WheelsSettings.Y1Selection;
                xyzAxisSelection[2] = Form4WheelsSettings.Z1Selection;
                if (ChartType == SeriesChartType.FastPoint)
                    PlotAllWheels(chart1, xyzAxisSelection);
                else
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    try
                    {
                        PlotAllWheels(chart1, xyzAxisSelection);
                        chart1.Refresh();
                    }
                    catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is NotSupportedException || ex is NotImplementedException || ex is System.Runtime.InteropServices.ExternalException)
                    {
                        FallBackToFastPoint("Live chart rendering failed: " + ex.Message);
                        return;
                    }
                    if (watch.ElapsedMilliseconds > timer1.Interval + 1000L)
                        FallBackToFastPoint("Render exceeded update interval by more than 1 second.");
                }
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toSettingsButton.Visible = false;
            settingsForm.PrepareForShow();
            settingsForm.Show(this);
        }

        private void refreshAndApplyButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //timer2.Enabled = false;
            ClearListDataHistory();
            SetUpDownChart(GradientChart);
            UpdateAllLimiters();
            if (PauseUpdate == false)
            {
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
            JsonFormSettings.SaveAllSettings(settingsForm);

            if (filterMigrationComplete)
                JsonFormSettings.SaveAllSettings(this);
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (PauseUpdate == false)
            {
                PauseUpdate = true;
                buttonPause.Text = "Continue Update";
            }
            else
            {
                PauseUpdate = false;
                buttonPause.Text = "Pause Update";
            }
        }
        private static readonly Dictionary<string, WheelPlotHistory> Histories =
            new Dictionary<string, WheelPlotHistory>(StringComparer.Ordinal);
        public static void ClearListDataHistory()
        {
            foreach (WheelPlotHistory history in Histories.Values)
                history.Clear();
        }

        public static void RebindHistory(Chart chart, string seriesName)
        {
            if (Histories.TryGetValue(seriesName, out WheelPlotHistory history))
            {
                // Recalculate old points from their original Z values. This also
                // handles changes to ZMin/ZMax, gradient steps, or history size.
                history = history.Rebucket(Steps, Form4WheelsSettings.Z1Min,
                    Form4WheelsSettings.Z1Max, Form4WheelsSettings.HistoryAmountPoints);
                Histories[seriesName] = history;
                history.BindAll(chart, seriesName, Form4WheelsSettings.MarkerColor);
            }
        }

        private static void PlotAllWheels(Chart chart, List<string> selections)
        {
            // Dataset layout controls which wheels generate history.
            var wheels = FourWheelsFieldSelection.WheelsForLayout(Form4WheelsSettings.WheelChartsSelect);
            if (wheels.Contains("FL")) PlotWheel(chart, TelemetryPrefix.FL, FL_SeriesString, selections);
            if (wheels.Contains("FR")) PlotWheel(chart, TelemetryPrefix.FR, FR_SeriesString, selections);
            if (wheels.Contains("RL")) PlotWheel(chart, TelemetryPrefix.RL, RL_SeriesString, selections);
            if (wheels.Contains("RR")) PlotWheel(chart, TelemetryPrefix.RR, RR_SeriesString, selections);
        }

        private static bool IsFinite(float value) => !float.IsNaN(value) && !float.IsInfinity(value);

        private static void PlotWheel(Chart chart, string wheel, string seriesName, List<string> selections)
        {
            float verticalLoad = LiveData.GetFullListFloatValue(wheel,
                GameMemoryConfig.Field("WF_TireDataOffset", "VerticalLoad"));
            if (!IsFinite(verticalLoad) || (NoTireContactLimiterEnabled && verticalLoad == 0)) return;

            var reader = LiveData.GetChartReader(wheel);
            // Reject filtered samples before reading/evaluating their chart axes.
            foreach (ChartLimit filter in activeChartLimits)
            {
                float value = reader.Read(filter.Selection, LiveData.None);
                if (!IsFinite(value)) return;
                if (filter.Absolute) value = Math.Abs(value);
                if (value < filter.Minimum || value > filter.Maximum) return;
            }

            float x = reader.Read(selections[0], LiveData.None);
            float y = reader.Read(selections[1], LiveData.None);
            float z = reader.Read(selections[2], LiveData.None);
            if (!IsFinite(x) || !IsFinite(y) || !IsFinite(z)) return;
            if (Form4WheelsSettings.AbsoluteValues)
            { x = Math.Abs(x); y = Math.Abs(y); z = Math.Abs(z); }

            if (!Histories.TryGetValue(seriesName, out WheelPlotHistory history))
            {
                history = new WheelPlotHistory(Steps);
                Histories[seriesName] = history;
            }
            else if (history.BandCount != Steps)
            {
                history = history.Rebucket(Steps, Form4WheelsSettings.Z1Min,
                    Form4WheelsSettings.Z1Max, Form4WheelsSettings.HistoryAmountPoints);
                Histories[seriesName] = history;
            }

            history.Add(chart, seriesName, x, y, z,
                Form4WheelsSettings.Z1Min, Form4WheelsSettings.Z1Max,
                Math.Max(0, Form4WheelsSettings.HistoryAmountPoints),
                Form4WheelsSettings.MarkerColor);
        }
    }
}
