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
    public partial class Form4WheelsSettings : Form
    {
        // ----- Consolidated chart/settings members -----

        public static bool SettingsOpen { get; set; } = false;
        public static SeriesChartType SeriesChartType { get; set; } = SeriesChartType.FastPoint;
        /// <summary>
        /// Some Font size max mins
        /// </summary>
        public static int FontSizeMin { get; } = 4;
        public static int FontSizeMax { get; } = 28;
        public static int FontSizeDivided { get; } = 4;

        // Default values
        /// <summary>
        /// Background
        /// </summary>
        public static Color DefaultBackgroundColor { get; set; } = Color.Transparent;
        public static Color DefaultLegendColor { get; set; } = Color.White;
        public static bool OtherDefaults { get; set; } = true;
        public static bool AbsoluteValues { get; set; } = true;

        /// <summary>
        /// Something
        /// </summary>
        public static int DefaultHistoryAmountPoints { get; set; } = 1000;
        // Number of Z-value color bands in each wheel plot and the gradient legend.
        // Change the limits here if a later game needs more gradient bands.
        public static int MinimumGradientSteps { get; set; } = 1;
        public static int MaximumGradientSteps { get; set; } = 64;
        public static int DefaultGradientSteps { get; set; } = 10;
        public static int ClampGradientSteps(int count)
        {
            int minimum = Math.Max(1, MinimumGradientSteps);
            int maximum = Math.Max(minimum, MaximumGradientSteps);
            return Math.Max(minimum, Math.Min(maximum, count));
        }
        public static int DefaultMarkerSize { get; set; } = 4;
        public static string DefaultScheme { get; set; } = "Colorblind";
        public static string DefaultWheelChartsSelect { get; set; } = "Separate";
        public static Color DefaultMarkerColor { get; set; } = Color.Red;

        /// <summary>
        /// X1 defaults
        /// </summary>
        public static bool X1Defaults { get; set; } = true;
        // Angle Type
        public static string X1DefaultType { get; set; } = "SlipAngleDeg";//LogSettings.sSlipAngle;
        // Font
        public static FontFamily X1DefaultFontFamily { get; set; } = FontFamily.GenericSansSerif;
        public static float X1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle X1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color X1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool X1DefaultIsLog { get; set; } = false;
        public static double X1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color X1DefaultMajorColor { get; set; } = Color.Maroon;
        public static int X1DefaultMajorDecimals { get; set; } = 0;
        public static double X1DefaultMajorInterval { get; set; } = 1;
        public static int X1DefaultMajorLineWidth { get; set; } = 1;
        public static float X1DefaultMin { get; set; } = -1;//
        public static float X1DefaultMax { get; set; } = 1;//
        // Minor grid
        public static bool X1DefaultMinorEnabled { get; set; } = false;
        public static int X1DefaultMinorIntervalFraction { get; set; } = 1;
        public static int X1DefaultMinorLineWidth { get; set; } = 1;
        public static Color X1DefaultMinorColor { get; set; } = Color.Maroon;
        public static ChartDashStyle X1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dash;

        public static bool Y1Defaults { get; set; } = true;
        /// <summary>
        /// Y1 defaults
        /// </summary>
        // Marker stuff
        // Angle Type
        public static string Y1DefaultType { get; set; } = "LateralFriction";//LogSettings.sLateralFriction;
        public static MarkerStyle Y1DefaultMarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int Y1DefaultMarkerSize { get; set; } = 3;
        public static Color Y1DefaultMarkerColor { get; set; } = Color.Blue;
        public static int Y1DefaultMarkerBorderSize { get; set; } = 1;
        public static Color Y1DefaultMarkerBorderColor { get; set; } = Color.Blue;

        // Font
        public static FontFamily Y1DefaultFontFamily { get; set; } = FontFamily.GenericSansSerif;
        public static float Y1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle Y1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color Y1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool Y1DefaultIsLog { get; set; } = false;
        public static double Y1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color Y1DefaultMajorColor { get; set; } = Color.Maroon;
        public static int Y1DefaultMajorDecimals { get; set; } = 1;
        public static double Y1DefaultMajorInterval { get; set; } = 1;//
        public static int Y1DefaultMajorLineWidth { get; set; } = 1;
        public static float Y1DefaultMin { get; set; } = -2;//
        public static float Y1DefaultMax { get; set; } = 2;//
        // Minor grid
        public static bool Y1DefaultMinorEnabled { get; set; } = false;
        public static int Y1DefaultMinorIntervalFraction { get; set; } = 1;
        public static int Y1DefaultMinorLineWidth { get; set; } = 1;
        public static Color Y1DefaultMinorColor { get; set; } = Color.Maroon;
        public static ChartDashStyle Y1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dash;

        //Z
        public static bool Z1Defaults { get; set; } = true;
        // The Z-color legend is independent of X/Y axis label precision.
        public const int DefaultLegendWidthPixels = 120;
        public const int DefaultZLegendLabelDecimals = 2;
        public static int LegendWidthPixels { get; set; } = DefaultLegendWidthPixels;
        public static int ZLegendLabelDecimals { get; set; } = DefaultZLegendLabelDecimals;
        public static string Z1DefaultType { get; set; } = "VerticalLoad";//LogSettings.sVerticalLoad;
        public static float Z1DefaultMax { get; set; } = 10000;//
        public static float Z1DefaultMin { get; set; } = 0;//
        ///////////////////////////////////////////////////////////////////////////////////

        // Changable values

        /// <summary>
        /// Background
        /// </summary>
        public static Color BackgroundColor { get; set; } = DefaultBackgroundColor;
        public static Color LegendColor { get; set; } = DefaultLegendColor;

        /// <summary>
        /// Something
        /// </summary>
        public static int HistoryAmountPoints { get; set; } = DefaultHistoryAmountPoints;
        private static int gradientSteps = DefaultGradientSteps;
        public static int GradientSteps
        {
            get => gradientSteps;
            set => gradientSteps = ClampGradientSteps(value);
        }
        public static int MarkerSize { get; set; } = DefaultMarkerSize;
        public static string Scheme { get; set; } = DefaultScheme;
        public static string WheelChartsSelect { get; set; } = DefaultWheelChartsSelect;
        public static Color MarkerColor { get; set; } = DefaultMarkerColor;
        /// <summary>
        /// X1 Axis
        /// </summary>
        /// // Angle Type
        public static string X1Selection { get; set; } = X1DefaultType;
        // Font
        public static FontFamily X1FontFamily { get; set; } = X1DefaultFontFamily;
        public static float X1FontSize { get; set; } = X1DefaultFontSize;
        public static FontStyle X1FontStyle { get; set; } = X1DefaultFontStyle;
        public static Color X1FontColor { get; set; } = X1DefaultFontColor;
        // Logaritmic
        public static bool X1IsLog { get; set; } = X1DefaultIsLog;
        public static double X1LogBase { get; set; } = X1DefaultLogBase;
        // Major Grid
        public static Color X1MajorColor { get; set; } = X1DefaultMajorColor;
        public static int X1MajorDecimals { get; set; } = X1DefaultMajorDecimals;
        public static double X1MajorInterval { get; set; } = X1DefaultMajorInterval;
        public static int X1MajorLineWidth { get; set; } = X1DefaultMajorLineWidth;
        public static float X1Min { get; set; } = X1DefaultMin;
        public static float X1Max { get; set; } = X1DefaultMax;
        // Minor grid
        public static bool X1MinorEnabled { get; set; } = X1DefaultMinorEnabled;
        public static int X1MinorIntervalFraction { get; set; } = X1DefaultMinorIntervalFraction;
        public static int X1MinorLineWidth { get; set; } = X1DefaultMinorLineWidth;
        public static Color X1MinorColor { get; set; } = X1DefaultMinorColor;
        public static ChartDashStyle X1MinorDashStyle { get; set; } = X1DefaultMinorDashStyle;

        /// <summary>
        /// Y1 Axis
        /// </summary>
        /// // Angle Type
        public static string Y1Selection { get; set; } = Y1DefaultType;
        // Marker stuff
        public static MarkerStyle Y1MarkerStyle { get; set; } = Y1DefaultMarkerStyle;
        public static int Y1MarkerSize { get; set; } = Y1DefaultMarkerSize;
        public static Color Y1MarkerColor { get; set; } = Y1DefaultMarkerColor;
        public static int Y1MarkerBorderSize { get; set; } = Y1DefaultMarkerBorderSize;
        public static Color Y1MarkerBorderColor { get; set; } = Y1DefaultMarkerBorderColor;

        // Font
        public static FontFamily Y1FontFamily { get; set; } = Y1DefaultFontFamily;
        public static float Y1FontSize { get; set; } = Y1DefaultFontSize;
        public static FontStyle Y1FontStyle { get; set; } = Y1DefaultFontStyle;
        public static Color Y1FontColor { get; set; } = Y1DefaultFontColor;
        // Logaritmic
        public static bool Y1IsLog { get; set; } = Y1DefaultIsLog;
        public static double Y1LogBase { get; set; } = Y1DefaultLogBase;
        // Major Grid
        public static Color Y1MajorColor { get; set; } = Y1DefaultMajorColor;
        public static int Y1MajorDecimals { get; set; } = Y1DefaultMajorDecimals;
        public static double Y1MajorInterval { get; set; } = Y1DefaultMajorInterval;
        public static int Y1MajorLineWidth { get; set; } = Y1DefaultMajorLineWidth;
        public static float Y1Min { get; set; } = Y1DefaultMin;
        public static float Y1Max { get; set; } = Y1DefaultMax;
        // Minor grid
        public static bool Y1MinorEnabled { get; set; } = Y1DefaultMinorEnabled;
        public static int Y1MinorIntervalFraction { get; set; } = Y1DefaultMinorIntervalFraction;
        public static int Y1MinorLineWidth { get; set; } = Y1DefaultMinorLineWidth;
        public static Color Y1MinorColor { get; set; } = Y1DefaultMinorColor;
        public static ChartDashStyle Y1MinorDashStyle { get; set; } = Y1DefaultMinorDashStyle;

        //Z
        public static string Z1Selection { get; set; } = Z1DefaultType;
        public static float Z1Max { get; set; } = Z1DefaultMax;
        public static float Z1Min { get; set; } = Z1DefaultMin;

        private readonly ComboBoxFontStore comboFonts = new ComboBoxFontStore();
        private Form4Wheels filterChart;
        internal ChartLimiterRow[] FilterRows { get; private set; }
        internal Control FilterSettingsRoot => filterSettingsRows;
        internal CheckBox NoContactFilter => noTireContactLimiterEnabledCheckBox;

        internal void BindFilterChart(Form4Wheels owner) => filterChart = owner;
        #region Chart Appearance
        /// <summary>
        /// Live-only chart appearance settings. The setting controls and their rows
        /// are declared in Form4WheelsSettings.Designer.cs, with the same compact
        /// layout as FormOfflineChartSettings. Existing JSON control names remain stable.
        /// </summary>
        /// 
        public static decimal XMajorWidth { get; private set; } = 1m;
        public static decimal XMinorWidth { get; private set; } = 1m;
        public static decimal YMajorWidth { get; private set; } = 1m;
        public static decimal YMinorWidth { get; private set; } = 1m;
        public static ChartDashStyle XMajorDashStyle { get; private set; } = ChartDashStyle.Solid;
        public static ChartDashStyle YMajorDashStyle { get; private set; } = ChartDashStyle.Solid;
        public static int XMajorAlpha { get; private set; } = 255;
        public static int YMajorAlpha { get; private set; } = 255;
        public static int XMinorAlpha { get; private set; } = 255;
        public static int YMinorAlpha { get; private set; } = 255;
        public static bool LiveCursorEnabled { get; private set; } = true;
        public static bool LiveCursorZoomable { get; private set; } = true;
        public static Color CursorColor { get; private set; } = Color.DodgerBlue;
        public static int CursorAlpha { get; private set; } = 160;
        public static decimal CursorWidth { get; private set; } = 1m;
        public static ChartDashStyle CursorDash { get; private set; } = ChartDashStyle.Dash;

        private static void Select(ComboBox box, string value)
        {
            if (box.Items.Contains(value)) box.SelectedItem = value;
            else if (box.Items.Count > 0) box.SelectedIndex = 0;
        }

        private void InitializeLiveAppearance()
        {
            liveChartTypeBox.Items.AddRange(Enum.GetNames(typeof(System.Windows.Forms.DataVisualization.Charting.SeriesChartType)).Cast<object>().ToArray());
            liveHistoryMarkerBox.Items.AddRange(Enum.GetNames(typeof(MarkerStyle)).Cast<object>().ToArray());
            var dashes = Enum.GetNames(typeof(ChartDashStyle)).Cast<object>().ToArray();
            foreach (ComboBox combo in new[] { liveCursorDashBox, liveXMajorDashBox, liveYMajorDashBox })
                combo.Items.AddRange(dashes);
            liveCursorColorBox.Items.AddRange(Enum.GetNames(typeof(KnownColor)).Cast<object>().ToArray());
            ChartSettingsUi.ConfigureNamedColorCombos(liveCursorColorBox);
            Select(liveChartTypeBox, Form4WheelsSettings.SeriesChartType.ToString());
            Select(liveHistoryMarkerBox, Form4Wheels.HistoryMarkerStyle.ToString());
            ChartSettingsUi.SelectColor(liveCursorColorBox, CursorColor);
            Select(liveCursorDashBox, CursorDash.ToString());
            Select(liveXMajorDashBox, XMajorDashStyle.ToString());
            Select(liveYMajorDashBox, YMajorDashStyle.ToString());
            liveHistoryMarkerSize.Value = Math.Max(1, Math.Min(20, Form4Wheels.MarkerSizeHistory));
            livePaletteAlpha.Value = Math.Max(0, Math.Min(255, Form4Wheels.HistoryAlpha));
            livePaletteDivider.Value = Math.Max(1, Math.Min(8, Form4Wheels.HistoryColorDivider));
            liveXMajorWidthBox.Value = Math.Max(.25m, Math.Min(10m, X1MajorLineWidth));
            liveXMinorWidthBox.Value = Math.Max(.25m, Math.Min(10m, X1MinorLineWidth));
            liveYMajorWidthBox.Value = Math.Max(.25m, Math.Min(10m, Y1MajorLineWidth));
            liveYMinorWidthBox.Value = Math.Max(.25m, Math.Min(10m, Y1MinorLineWidth));
        }

        private void ApplyLiveAppearance()
        {
            if (!Enum.TryParse(liveChartTypeBox.Text, out System.Windows.Forms.DataVisualization.Charting.SeriesChartType type))
                type = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            // Live history holds one Y value. Multi-Y chart types cannot draw it.
            if (!ChartAppearance.CanDrawLiveXYZ(type))
                throw new ArgumentException(type + " needs more than one Y value per point.");
            SeriesChartType = type;
            Form4Wheels.ChartType = type;
            if (Enum.TryParse(liveHistoryMarkerBox.Text, out MarkerStyle marker))
                Form4Wheels.HistoryMarkerStyle = marker;
            Form4Wheels.MarkerSizeHistory = (int)liveHistoryMarkerSize.Value;
            Form4Wheels.HistoryAlpha = (int)livePaletteAlpha.Value;
            Form4Wheels.HistoryColorDivider = (int)livePaletteDivider.Value;
            if (Enum.TryParse(liveXMajorDashBox.Text, out ChartDashStyle xd)) XMajorDashStyle = xd;
            if (Enum.TryParse(liveYMajorDashBox.Text, out ChartDashStyle yd)) YMajorDashStyle = yd;
            XMajorWidth = liveXMajorWidthBox.Value;
            XMinorWidth = liveXMinorWidthBox.Value;
            YMajorWidth = liveYMajorWidthBox.Value;
            YMinorWidth = liveYMinorWidthBox.Value;
            X1MajorLineWidth = ChartAppearance.PixelWidth(XMajorWidth);
            X1MinorLineWidth = ChartAppearance.PixelWidth(XMinorWidth);
            Y1MajorLineWidth = ChartAppearance.PixelWidth(YMajorWidth);
            Y1MinorLineWidth = ChartAppearance.PixelWidth(YMinorWidth);
            XMajorAlpha = (int)liveXMajorAlphaBox.Value;
            YMajorAlpha = (int)liveYMajorAlphaBox.Value;
            XMinorAlpha = (int)liveXMinorAlphaBox.Value;
            YMinorAlpha = (int)liveYMinorAlphaBox.Value;
            LiveCursorEnabled = liveCursorEnabledBox.Checked;
            LiveCursorZoomable = liveCursorZoomBox.Checked;
            CursorColor = ChartSettingsUi.ReadColor(liveCursorColorBox);
            CursorAlpha = (int)liveCursorAlphaBox.Value;
            CursorWidth = liveCursorWidthBox.Value;
            if (Enum.TryParse(liveCursorDashBox.Text, out ChartDashStyle cd)) CursorDash = cd;
        }
        #endregion

        private void settingsApplyFiltersButton_Click(object sender, EventArgs e)
        {
            if (filterChart == null) return;
            filterChart.UpdateAllLimiters();
            JsonFormSettings.SaveAllSettings(this);
        }

        public Form4WheelsSettings()
        {
            InitializeComponent();
            // All settings rows are Designer-owned. Avoid game configuration and
            // profile initialization while Visual Studio is rendering the form.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            FilterRows = ChartLimiterRow.ConfigureRows(new[] { axisXFilterRow, axisYFilterRow, axisZFilterRow, extraFilterRow01, extraFilterRow02, extraFilterRow03, extraFilterRow04, extraFilterRow05, extraFilterRow06, extraFilterRow07, extraFilterRow08, extraFilterRow09, extraFilterRow10 }, "ChartFilter");
            Disposed += (sender, args) => comboFonts.Dispose();
            ChartSettingsUi.ConfigureFontFamilies(X1ComboBoxFonts, Y1ComboBoxFonts);
            ChartSettingsUi.ConfigureOwnerDraw(true, MarkerColorComboBox, BackgroundColorComboBox,
                SchemeComboBox, X1FontStyleComboBox, Y1FontStyleComboBox,
                X1FontColorComboBox, Y1FontColorComboBox,
                X1MajorColorComboBox, Y1MajorColorComboBox,
                X1MinorColorComboBox, Y1MinorColorComboBox);
            ChartSettingsUi.ConfigureOwnerDraw(false, X1FontSizeComboBox, Y1FontSizeComboBox);

            AddInComboBoxes();
            LoadX1Defaults();
            LoadY1Defaults();
            LoadZ1Defaults();
            LoadOtherDefaults();
            InitializeLiveAppearance();
            ComboBoxBehaviors.EnableSearch(this);
            // Rebuild the visible axis choices whenever the wheel layout changes.
            // One field represents all plotted wheels in multi-wheel layouts.
            WheelChartsSelectComboBox.SelectedIndexChanged +=
                (sender, args) => RefreshAxisChoices();
            JsonFormSettings.AttachProfileButton(this, () =>
            {
                RefreshAxisChoices();
                AbsoluteValues = AbsoluteValuesCheckBox.Checked;

                ApplySettings(
                    clearHistory: false,
                    saveSettings: false);
            });
        }

        /// <summary>
        /// Initialize the shared four-wheel model before any chart is opened.
        /// The UI controls provide backward-compatible parsing of older saved
        /// JSON settings (with one-time legacy registry import) without displaying
        /// an extra settings window.
        /// </summary>
        public static void RestoreSavedModel()
        {
            using (var settings = new Form4WheelsSettings())
            {
                JsonFormSettings.LoadAllSettings(settings, includeSettingsFilters: false);
                settings.RefreshAxisChoices();
                AbsoluteValues = settings.AbsoluteValuesCheckBox.Checked;
                settings.ApplyControlsToModel();
            }
        }

        private void AddInComboBoxes()
        {
            ChartSettingsUi.AddFontSizes(FontSizeMin, FontSizeMax, FontSizeDivided,
                X1FontSizeComboBox, Y1FontSizeComboBox);
            ChartSettingsUi.AddEnums<FontStyle>(X1FontStyleComboBox, Y1FontStyleComboBox);
            ChartSettingsUi.AddColors(BackgroundColorComboBox, MarkerColorComboBox,
                X1FontColorComboBox, X1MajorColorComboBox, X1MinorColorComboBox,
                Y1FontColorComboBox, Y1MajorColorComboBox, Y1MinorColorComboBox);
            ChartSettingsUi.AddEnums<ChartDashStyle>(X1MinorDashStyleComboBox, Y1MinorDashStyleComboBox);
            ChartSettingsUi.AddIntegers(1, 10, X1MajorLineWidthComboBox, X1MinorLineWidthComboBox,
                Y1MajorLineWidthComboBox, Y1MinorLineWidthComboBox);
            ChartSettingsUi.AddIntegers(2, 10, X1MinorIntervalComboBox, Y1MinorIntervalComboBox);
            ChartSettingsUi.AddIntegers(0, 10, X1MajorDecimalsComboBox, Y1MajorDecimalsComboBox);
            ChartSettingsUi.AddOptions(SchemeComboBox, GradientPalette.AvailableSchemes);
            ChartSettingsUi.AddOptions(WheelChartsSelectComboBox,
                FourWheelsFieldSelection.Layouts);

            AxisSelectionComboboxAdd(X1SelectionComboBox);
            AxisSelectionComboboxAdd(Y1SelectionComboBox);
            AxisSelectionComboboxAdd(Z1SelectionComboBox);
        }
        /// <summary>
        /// Four Wheels selects *measurements* independently of the layout.
        /// Only shared fields retain category prefixes (ENG_, BODY_, etc.).
        /// </summary>
        public static void AxisSelectionComboboxAdd(ComboBox axisSelectionCombobox,
                                                    string wheelLayout = null)
        {
            string saved = axisSelectionCombobox.SelectedItem as string ??
                axisSelectionCombobox.Text;
            string layout = wheelLayout ?? WheelChartsSelect;
            axisSelectionCombobox.BeginUpdate();
            try
            {
                axisSelectionCombobox.Items.Clear();
                axisSelectionCombobox.Items.AddRange(
                    FourWheelsFieldSelection.Options(layout).Cast<object>().ToArray());
                axisSelectionCombobox.SelectedItem =
                    FourWheelsFieldSelection.MatchAvailable(saved,
                        axisSelectionCombobox.Items.Cast<string>());
            }
            finally
            {
                axisSelectionCombobox.EndUpdate();
            }
        }

        private void RefreshAxisChoices()
        {
            string layout = WheelChartsSelectComboBox.Text;
            AxisSelectionComboboxAdd(X1SelectionComboBox, layout);
            AxisSelectionComboboxAdd(Y1SelectionComboBox, layout);
            AxisSelectionComboboxAdd(Z1SelectionComboBox, layout);
        }

        private static void SelectAxis(ComboBox box, string selection)
        {
            box.SelectedItem = FourWheelsFieldSelection.MatchAvailable(
                selection, box.Items.Cast<string>());
        }

        private void LoadOtherDefaults()
        {
            gradientStepsNumericUpDown.Value = ClampGradientSteps(
                DefaultsCheckBox.Checked
                    ? DefaultGradientSteps
                    : GradientSteps);
            //Default background color
            if (DefaultsCheckBox.Checked == true)
            {
                ChartSettingsUi.SelectColor(BackgroundColorComboBox, DefaultBackgroundColor);
                ChartSettingsUi.SelectColor(MarkerColorComboBox, DefaultMarkerColor);
                HistoryAmountPointsMaskedTextBox.Text = DefaultHistoryAmountPoints.ToString();
                SchemeComboBox.SelectedItem = DefaultScheme;
                WheelChartsSelectComboBox.SelectedItem = DefaultWheelChartsSelect;
            }
            else
            {
                ChartSettingsUi.SelectColor(BackgroundColorComboBox, BackgroundColor);
                ChartSettingsUi.SelectColor(MarkerColorComboBox, MarkerColor);
                HistoryAmountPointsMaskedTextBox.Text = HistoryAmountPoints.ToString();
                SchemeComboBox.SelectedItem = Scheme;
                WheelChartsSelectComboBox.SelectedItem = WheelChartsSelect;
            }
            RefreshAxisChoices();
        }
        private void LoadX1Defaults()
        {
            SelectAxis(X1SelectionComboBox, X1Selection);

            // Default X1 selections
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1MaxMaskedTextBox.Text = X1DefaultMax.ToString();
                X1MinMaskedTextBox.Text = X1DefaultMin.ToString();

                ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1DefaultFontFamily);

                //X1DefaultFontString = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = X1DefaultFontSize;

                X1FontStyleComboBox.SelectedItem = X1DefaultFontStyle;

                ChartSettingsUi.SelectColor(X1FontColorComboBox, X1DefaultFontColor);

                ChartSettingsUi.SelectColor(X1MajorColorComboBox, X1DefaultMajorColor);
                X1MajorDecimalsComboBox.SelectedItem = X1DefaultMajorDecimals;
                X1MajorIntervalFractionTextBox.Text = X1DefaultMajorInterval.ToString();
                X1MajorLineWidthComboBox.SelectedItem = X1DefaultMajorLineWidth;
                ChartSettingsUi.SelectColor(X1MinorColorComboBox, X1DefaultMinorColor);
                X1MinorDashStyleComboBox.SelectedItem = X1DefaultMinorDashStyle;
                X1MinorEnabledCheckBox.Checked = X1DefaultMinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = X1DefaultMinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = X1DefaultMinorLineWidth;
            }
            else
            {
                X1MaxMaskedTextBox.Text = X1Max.ToString();
                X1MinMaskedTextBox.Text = X1Min.ToString();

                ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1FontFamily);

                //X1FontFamily = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = X1FontSize;

                X1FontStyleComboBox.SelectedItem = X1FontStyle;

                ChartSettingsUi.SelectColor(X1FontColorComboBox, X1FontColor);

                ChartSettingsUi.SelectColor(X1MajorColorComboBox, X1MajorColor);
                X1MajorDecimalsComboBox.SelectedItem = X1MajorDecimals;
                X1MajorIntervalFractionTextBox.Text = X1MajorInterval.ToString();
                X1MajorLineWidthComboBox.SelectedItem = X1MajorLineWidth;
                ChartSettingsUi.SelectColor(X1MinorColorComboBox, X1MinorColor);
                X1MinorDashStyleComboBox.SelectedItem = X1MinorDashStyle;
                X1MinorEnabledCheckBox.Checked = X1MinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = X1MinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = X1MinorLineWidth;
            }
        }
        private void LoadY1Defaults()
        {
            SelectAxis(Y1SelectionComboBox, Y1Selection);

            // Default Y1 selections
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1MaxMaskedTextBox.Text = Y1DefaultMax.ToString();
                Y1MinMaskedTextBox.Text = Y1DefaultMin.ToString();

                ChartSettingsUi.SelectFontFamily(Y1ComboBoxFonts, Y1DefaultFontFamily);

                //Y1DefaultFontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = Y1DefaultFontSize;

                Y1FontStyleComboBox.SelectedItem = Y1DefaultFontStyle;

                ChartSettingsUi.SelectColor(Y1FontColorComboBox, Y1DefaultFontColor);

                ChartSettingsUi.SelectColor(Y1MajorColorComboBox, Y1DefaultMajorColor);
                Y1MajorDecimalsComboBox.SelectedItem = Y1DefaultMajorDecimals;
                Y1IntervalDividerTextBox.Text = Y1DefaultMajorInterval.ToString();
                Y1MajorLineWidthComboBox.SelectedItem = Y1DefaultMajorLineWidth;
                ChartSettingsUi.SelectColor(Y1MinorColorComboBox, Y1DefaultMinorColor);
                Y1MinorDashStyleComboBox.SelectedItem = Y1DefaultMinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = Y1DefaultMinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = Y1DefaultMinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = Y1DefaultMinorLineWidth;
            }
            else
            {
                Y1MaxMaskedTextBox.Text = Y1Max.ToString();
                Y1MinMaskedTextBox.Text = Y1Min.ToString();

                ChartSettingsUi.SelectFontFamily(Y1ComboBoxFonts, Y1FontFamily);

                //Y1FontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = Y1FontSize;

                Y1FontStyleComboBox.SelectedItem = Y1FontStyle;

                ChartSettingsUi.SelectColor(Y1FontColorComboBox, Y1FontColor);

                ChartSettingsUi.SelectColor(Y1MajorColorComboBox, Y1MajorColor);
                Y1MajorDecimalsComboBox.SelectedItem = Y1MajorDecimals;
                Y1IntervalDividerTextBox.Text = Y1MajorInterval.ToString();
                Y1MajorLineWidthComboBox.SelectedItem = Y1MajorLineWidth;
                ChartSettingsUi.SelectColor(Y1MinorColorComboBox, Y1MinorColor);
                Y1MinorDashStyleComboBox.SelectedItem = Y1MinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = Y1MinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = Y1MinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = Y1MinorLineWidth;
            }
        }
        private void LoadZ1Defaults()
        {
            SelectAxis(Z1SelectionComboBox, Z1Selection);
            ZLegendWidthNumericUpDown.Value = Math.Max(ZLegendWidthNumericUpDown.Minimum,
                Math.Min(ZLegendWidthNumericUpDown.Maximum, LegendWidthPixels));
            ZLegendDecimalsNumericUpDown.Value = Math.Max(ZLegendDecimalsNumericUpDown.Minimum,
                Math.Min(ZLegendDecimalsNumericUpDown.Maximum, ZLegendLabelDecimals));

            // Default Z1 selections
            if (Z1DefaultsCheckBox.Checked == true)
            {
                Z1MaxMaskedTextBox.Text = Z1DefaultMax.ToString();
                Z1MinMaskedTextBox.Text = Z1DefaultMin.ToString();

                //Z1ComboBoxFonts.SelectedItem = Z1DefaultFontFamily;//Z1ComboBoxFonts.Items[Z1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //Z1DefaultFontString = Z1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                //Z1FontSizeComboBox.SelectedItem = Z1DefaultFontSize;

                //Z1FontStyleComboBox.SelectedItem = Z1DefaultFontStyle;

                //Z1FontColorComboBox.SelectedItem = Z1DefaultFontColor;

                //Z1MajorColorComboBox.SelectedItem = Z1DefaultMajorColor;
                //Z1MajorDecimalsComboBox.SelectedItem = Z1DefaultMajorDecimals;
                //Z1IntervalDividerTextBox.Text = Z1DefaultMajorInterval.ToString();
                //Z1MajorLineWidthComboBox.SelectedItem = Z1DefaultMajorLineWidth;
                //Z1MinorColorComboBox.SelectedItem = Z1DefaultMinorColor;
                //Z1MinorDashStyleComboBox.SelectedItem = Z1DefaultMinorDashStyle;
                //Z1MinorEnabledCheckBox.Checked = Z1DefaultMinorEnabled;
                //Z1MinorIntervalComboBox.SelectedItem = Z1DefaultMinorIntervalFraction;
                //Z1MinorLineWidthComboBox.SelectedItem = Z1DefaultMinorLineWidth;
            }
            else
            {
                Z1MaxMaskedTextBox.Text = Z1Max.ToString();
                Z1MinMaskedTextBox.Text = Z1Min.ToString();

                //Z1ComboBoxFonts.SelectedItem = Z1FontFamily;//Z1ComboBoxFonts.Items[Z1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //Z1FontString = Z1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                //Z1FontSizeComboBox.SelectedItem = Z1FontSize;

                //Z1FontStyleComboBox.SelectedItem = Z1FontStyle;

                //Z1FontColorComboBox.SelectedItem = Z1FontColor;

                //Z1MajorColorComboBox.SelectedItem = Z1MajorColor;
                //Z1MajorDecimalsComboBox.SelectedItem = Z1MajorDecimals;
                //Z1IntervalDividerTextBox.Text = Z1MajorInterval.ToString();
                //Z1MajorLineWidthComboBox.SelectedItem = Z1MajorLineWidth;
                //Z1MinorColorComboBox.SelectedItem = Z1MinorColor;
                //Z1MinorDashStyleComboBox.SelectedItem = Z1MinorDashStyle;
                //Z1MinorEnabledCheckBox.Checked = Z1MinorEnabled;
                //Z1MinorIntervalComboBox.SelectedItem = Z1MinorIntervalFraction;
                //Z1MinorLineWidthComboBox.SelectedItem = Z1MinorLineWidth;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        #region  OTHER STUFF
        private void Form_4WheelsSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsOpen = false;

            if (filterChart == null ||
                filterChart.IsDisposed ||
                e.CloseReason == CloseReason.UserClosing)
            {
                JsonFormSettings.SaveAllSettings(this);
            }

            if (filterChart != null && !filterChart.IsDisposed)
            {
                filterChart.UpdateAllLimiters();
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    Hide();
                }
            }
        }
        internal void RestoreForChart()
        {
            JsonFormSettings.LoadAllSettings(this);

            RefreshAxisChoices();

            AbsoluteValues = AbsoluteValuesCheckBox.Checked;

            ApplyControlsToModel();

            filterChart.RefreshFilterFieldChoices();
        }
        internal void PrepareFilterRestore(bool factoryDefaults)
        {
            RefreshAxisChoices();

            filterChart?.PrepareFilterRestore(
                WheelChartsSelectComboBox.Text,
                new[]
                {
            X1SelectionComboBox.Text,
            Y1SelectionComboBox.Text,
            Z1SelectionComboBox.Text
                },
                factoryDefaults);
        }
        internal void SetFastPointAfterFallback()
        {
            Select(liveChartTypeBox, System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint.ToString());
            JsonFormSettings.SaveAllSettings(this);
        }

        internal void PrepareForShow()
        {
            SettingsOpen = true;
            RefreshAxisChoices();
            AbsoluteValues = AbsoluteValuesCheckBox.Checked;
            ApplySettings(clearHistory: false);
        }

        // Adjust chart min/max/lines etc., just not touching and refreshing data.
        private void applyChartSettingsButton_Click(object sender, EventArgs e)
        {
            ApplySettings(clearHistory: false);
        }

        private void applyAndClearButton_Click(object sender, EventArgs e)
        {
            ApplySettings(clearHistory: true);
        }

        /// <summary>
        /// Both Apply buttons use the same settings parser. The Clear variant
        /// differs only in whether it discards the existing wheel histories.
        /// Suspend refreshes while the settings and chart series are changing.
        /// </summary>
        private void ApplySettings(bool clearHistory, bool saveSettings = true)
        {
            Form4Wheels form4Wheels = filterChart;

            if (form4Wheels == null || form4Wheels.IsDisposed)
            {
                ApplyControlsToModel();

                if (saveSettings)
                    JsonFormSettings.SaveAllSettings(this);

                return;
            }
            bool timerWasEnabled = form4Wheels.timer1.Enabled;
            form4Wheels.timer1.Enabled = false;
            try
            {
                try { ApplyControlsToModel(); }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, "Chart settings",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (clearHistory)
                    form4Wheels.ClearAllSeriesHistory();

                form4Wheels.SetChartsForForm();
                form4Wheels.ApplyLegendWidth();
                form4Wheels.RefreshFilterFieldChoices();
                LoadValuesInTextBox();
                if (saveSettings)
                    JsonFormSettings.SaveAllSettings(this);
            }
            finally
            {
                form4Wheels.timer1.Enabled = timerWasEnabled;
            }
        }

        private void ApplyControlsToModel()
        {
            ApplyOtherSettings();
            RefreshAxisChoices();
            ApplyXAxisSettings();
            ApplyYAxisSettings();
            ApplyZAxisSettings();
            ApplyLiveAppearance();
        }
        private void ApplyOtherSettings()
        {
            // Other stuff
            if (DefaultsCheckBox.Checked == true)
            {
                BackgroundColor = DefaultBackgroundColor;
                MarkerColor = DefaultMarkerColor;
                HistoryAmountPoints = DefaultHistoryAmountPoints;
                GradientSteps = DefaultGradientSteps;
                Scheme = DefaultScheme;
            }
            else
            {
                BackgroundColor = (Color)BackgroundColorComboBox.SelectedItem;
                MarkerColor = (Color)MarkerColorComboBox.SelectedItem;
                HistoryAmountPoints = (int)TextBoxBaseParsers.HistoryAmountPointsParser(HistoryAmountPointsMaskedTextBox, DefaultHistoryAmountPoints, true);
                GradientSteps = (int)gradientStepsNumericUpDown.Value;
                Scheme = SchemeComboBox.Text;
            }

            // Chart layout is a viewing choice, not a style default. Respect the
            // tire selected here even when the other chart settings use defaults.
            WheelChartsSelect = WheelChartsSelectComboBox.Text;

        }

        private void ApplyXAxisSettings()
        {
            // X-Axis
            X1Selection = FourWheelsFieldSelection.MatchAvailable(
                X1SelectionComboBox.Text, X1SelectionComboBox.Items.Cast<string>());
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1Min = X1DefaultMin;
                X1Max = X1DefaultMax;

                X1FontFamily = X1DefaultFontFamily;
                X1FontSize = X1DefaultFontSize;
                X1FontStyle = X1DefaultFontStyle;
                X1FontColor = X1DefaultFontColor;

                X1MajorLineWidth = X1DefaultMajorLineWidth;
                X1MajorDecimals = X1DefaultMajorDecimals;
                X1MajorInterval = X1DefaultMajorInterval;
                X1MajorColor = X1DefaultMajorColor;

                X1MinorEnabled = X1DefaultMinorEnabled;
                X1MinorIntervalFraction = X1DefaultMinorIntervalFraction;
                X1MinorLineWidth = X1DefaultMinorLineWidth;
                X1MinorColor = X1DefaultMinorColor;
                X1MinorDashStyle = X1DefaultMinorDashStyle;
            }
            else
            {
                X1FontFamily = (FontFamily)X1ComboBoxFonts.SelectedItem;
                X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
                X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
                X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;

                X1Min = (float)TextBoxBaseParsers.Parser(X1MinMaskedTextBox, X1DefaultMin, AbsoluteValues);
                X1Max = (float)TextBoxBaseParsers.Parser(X1MaxMaskedTextBox, X1DefaultMax, false);

                X1MajorLineWidth = (int)X1MajorLineWidthComboBox.SelectedItem;
                X1MajorDecimals = (int)X1MajorDecimalsComboBox.SelectedItem;
                X1MajorInterval = (double)TextBoxBaseParsers.Parser(X1MajorIntervalFractionTextBox, X1DefaultMajorInterval, false);
                X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;

                X1MinorEnabled = X1MinorEnabledCheckBox.Checked;
                X1MinorIntervalFraction = (int)X1MinorIntervalComboBox.SelectedItem;
                X1MinorLineWidth = (int)X1MinorLineWidthComboBox.SelectedItem;
                X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
                X1MinorDashStyle = (ChartDashStyle)X1MinorDashStyleComboBox.SelectedItem;
            }

        }

        private void ApplyYAxisSettings()
        {
            // Y-Axis
            Y1Selection = FourWheelsFieldSelection.MatchAvailable(
                Y1SelectionComboBox.Text, Y1SelectionComboBox.Items.Cast<string>());
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1Min = Y1DefaultMin;
                Y1Max = Y1DefaultMax;

                Y1FontFamily = Y1DefaultFontFamily;
                Y1FontSize = Y1DefaultFontSize;
                Y1FontStyle = Y1DefaultFontStyle;
                Y1FontColor = Y1DefaultFontColor;


                Y1MajorLineWidth = Y1DefaultMajorLineWidth;
                Y1MajorDecimals = Y1DefaultMajorDecimals;
                Y1MajorInterval = Y1DefaultMajorInterval;
                Y1MajorColor = Y1DefaultMajorColor;

                Y1MinorEnabled = Y1DefaultMinorEnabled;
                Y1MinorIntervalFraction = Y1DefaultMinorIntervalFraction;
                Y1MinorLineWidth = Y1DefaultMinorLineWidth;
                Y1MinorColor = Y1DefaultMinorColor;
                Y1MinorDashStyle = Y1DefaultMinorDashStyle;
            }
            else
            {
                Y1FontFamily = (FontFamily)Y1ComboBoxFonts.SelectedItem;
                Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
                Y1FontSize = (float)Y1FontSizeComboBox.SelectedItem;
                Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;

                Y1Min = (float)TextBoxBaseParsers.Parser(Y1MinMaskedTextBox, Y1DefaultMin, AbsoluteValues);
                Y1Max = (float)TextBoxBaseParsers.Parser(Y1MaxMaskedTextBox, Y1DefaultMax, false);

                Y1MajorLineWidth = (int)Y1MajorLineWidthComboBox.SelectedItem;
                Y1MajorDecimals = (int)Y1MajorDecimalsComboBox.SelectedItem;
                Y1MajorInterval = TextBoxBaseParsers.Parser(Y1IntervalDividerTextBox, Y1DefaultMajorInterval, true);
                Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;

                Y1MinorEnabled = Y1MinorEnabledCheckBox.Checked;
                Y1MinorIntervalFraction = (int)Y1MinorIntervalComboBox.SelectedItem;
                Y1MinorLineWidth = (int)Y1MinorLineWidthComboBox.SelectedItem;
                Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
                Y1MinorDashStyle = (ChartDashStyle)Y1MinorDashStyleComboBox.SelectedItem;
            }
        }

        private void ApplyZAxisSettings()
        {
            LegendWidthPixels = (int)ZLegendWidthNumericUpDown.Value;
            ZLegendLabelDecimals = (int)ZLegendDecimalsNumericUpDown.Value;
            Z1Selection = FourWheelsFieldSelection.MatchAvailable(
                Z1SelectionComboBox.Text, Z1SelectionComboBox.Items.Cast<string>());
            if (Z1DefaultsCheckBox.Checked)
            {
                Z1Min = Z1DefaultMin;
                Z1Max = Z1DefaultMax;
            }
            else
            {
                Z1Min = (float)TextBoxBaseParsers.Parser(Z1MinMaskedTextBox, Z1DefaultMin, true);
                Z1Max = (float)TextBoxBaseParsers.Parser(Z1MaxMaskedTextBox, Z1DefaultMax, true);
            }
        }

        private void LoadValuesInTextBox()
        {
            LoadX1Defaults();
            LoadY1Defaults();
            LoadZ1Defaults();
            LoadOtherDefaults();
        }
        private void LoadCurrentValuesButton_Click(object sender, EventArgs e)
        {
            LoadValuesInTextBox();
        }
        private void CheckFontColorAndSetBackGroundColor(ComboBox cb, Color fontColor)
        {
            ChartSettingsUi.SetContrast(cb, fontColor);
        }

        private static void DrawColorItem(ComboBox combo, DrawItemEventArgs e,
                                           FontFamily family, float size, FontStyle style)
        {
            ChartSettingsUi.DrawColor(combo, e, family, size, style);
        }

        private static void DrawFontFamilyItem(ComboBox combo, DrawItemEventArgs e,
                                                float size, FontStyle style)
        {
            ChartSettingsUi.DrawFontFamily(combo, e, size, style);
        }

        private static void DrawFontStyleItem(ComboBox combo, DrawItemEventArgs e,
                                               FontFamily family, float size)
        {
            ChartSettingsUi.DrawFontStyle(combo, e, family, size);
        }

        private static void DrawFontSizeItem(ComboBox combo, DrawItemEventArgs e,
                                              FontFamily family, float size, FontStyle style)
        {
            ChartSettingsUi.DrawFontSize(combo, e, family, size, style);
        }

        private void SetComboFont(ComboBox combo, FontFamily family, float size, FontStyle style)
        {
            comboFonts.SetFont(combo, family, size, style);
        }

        private void DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultsCheckBox.Checked == true)
            {
                OtherDefaults = true;
            }
            else
            {
                OtherDefaults = false;
            }
        }

        private void BackgroundColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }

        private void BackgroundColorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            BackgroundColorComboBox.ForeColor = (Color)color;
            SetComboFont(BackgroundColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, (Color)color);
        }

        private void MarkerColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void MarkerColorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            MarkerColorComboBox.ForeColor = (Color)color;
            SetComboFont(MarkerColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(MarkerColorComboBox, (Color)color);
        }
        private void GreenRedSchemeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawScheme((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize);
        }
        private void AbsoluteValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AbsoluteValuesCheckBox.Checked == true)
            {
                AbsoluteValues = true;
            }
            else
            {
                AbsoluteValues = false;
            }
        }
        #endregion
        #region X1 STUFF
        private void X1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1Defaults = true;
            }
            else
            {
                X1Defaults = false;
            }
        }
        private void X1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawFontFamilyItem((ComboBox)sender, e, X1DefaultFontSize, X1DefaultFontStyle);
        }

        private void X1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            SetComboFont(X1ComboBoxFonts, fontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }

        private void X1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            SetComboFont(X1FontStyleComboBox, X1DefaultFontFamily, X1DefaultFontSize, fontStyle);
        }

        private void X1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawFontStyleItem((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize);
        }

        private void X1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            SetComboFont(X1FontColorComboBox, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
            X1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, (Color)color);
        }

        private void X1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }

        private void X1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var fontSize = comboBox.SelectedItem;
            //X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
            SetComboFont(X1FontSizeComboBox, X1DefaultFontFamily, (float)fontSize, X1DefaultFontStyle);
            //textBox8.Text = X1FontSize.ToString();
            //comboBox7.Text = p.GetX1FontSize().ToString();
        }

        private void X1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawFontSizeItem((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        private void X1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            SetComboFont(X1MajorColorComboBox, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
            X1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, (Color)color);
        }
        private void X1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1FontStyle);
        }

        private void X1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            SetComboFont(X1MinorColorComboBox, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
            X1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MinorColorComboBox, (Color)color);
        }
        private void X1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        #endregion
        #region Y1 STUFF
        private void Y1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1Defaults = true;
            }
            else
            {
                Y1Defaults = false;
            }
        }
        private void Y1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawFontFamilyItem((ComboBox)sender, e, Y1DefaultFontSize, Y1DefaultFontStyle);
        }

        private void Y1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            SetComboFont(Y1ComboBoxFonts, fontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }

        private void Y1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            SetComboFont(Y1FontStyleComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, fontStyle);
        }

        private void Y1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawFontStyleItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize);
        }

        private void Y1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            SetComboFont(Y1FontColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            Y1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, (Color)color);
        }

        private void Y1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }

        private void Y1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var fontSize = comboBox.SelectedItem;
            SetComboFont(Y1FontSizeComboBox, Y1DefaultFontFamily, (float)fontSize, Y1DefaultFontStyle);
        }

        private void Y1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawFontSizeItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void Y1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            SetComboFont(Y1MajorColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            Y1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, (Color)color);
        }
        private void Y1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }

        private void Y1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            var color = comboBox.SelectedItem;
            SetComboFont(Y1MinorColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            Y1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MinorColorComboBox, (Color)color);
        }
        private void Y1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawColorItem((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        #endregion
        #region Z1 STUFF
        private void Z1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Z1DefaultsCheckBox.Checked == true)
            {
                Z1Defaults = true;
            }
            else
            {
                Z1Defaults = false;
            }
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////
    }
}
