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
    public partial class FormGForceSettings : Form
    {
        private readonly ComboBoxFontStore comboFonts = new ComboBoxFontStore();
        private bool readyForUserEvents;

        // ----- Consolidated chart/settings members -----

        public static bool SettingsOpen { get; set; } = false;
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
        public static Color DefaultBackgroundColor { get; set; } = Color.Black;
        public static Color DefaultLegendColor { get; set; } = Color.White;
        public static bool OtherDefaults { get; set; } = true;

        /// <summary>
        /// Something
        /// </summary>
        public static int DefaultHistoryAmountPoints { get; set; } = 100;
        // Loaded from the active game-memory JSON (gForce), independent of saved UI settings.
        public static int GradientSteps { get; set; } = 10;
        // Zero keeps the full history; a positive value bounds old snapshot points.
        public static int MaxInfiniteHistoryPoints { get; set; } = 0;
        public static bool DefaultInfiniteHistoryEnabled { get; set; } = false;
        public static int DefaultMarkerSize { get; set; } = 5;
        public static string DefaultScheme { get; set; } = "Green Red";
        public static Color DefaultMarkerColor { get; set; } = Color.Red;


        public static readonly int historyalpha = 255;
        public static readonly int historycolordivider = 2;

        /// <summary>
        /// X1 defaults
        /// </summary>
        public static bool X1Defaults { get; set; } = true;
        // Angle Type
        public static string X1DefaultAngleType { get; set; } = "Degrees";
        // Font
        public static FontFamily X1DefaultFontFamily { get; set; } = new FontFamily("Arial");
        public static float X1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle X1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color X1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool X1DefaultIsLog { get; set; } = false;
        public static double X1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color X1DefaultMajorColor { get; set; } = Color.Maroon;
        public static int X1DefaultMajorDecimals { get; set; } = 0;
        public static int X1DefaultMajorIntervalFraction { get; set; } = 4;
        public static int X1DefaultMajorLineWidth { get; set; } = 2;
        public static double X1DefaultMin { get; set; } = 0;//
        public static double X1DefaultMax { get; set; } = 360;//
        // Minor grid
        public static bool X1DefaultMinorEnabled { get; set; } = false;
        public static int X1DefaultMinorIntervalFraction { get; set; } = 2;
        public static int X1DefaultMinorLineWidth { get; set; } = 1;
        public static Color X1DefaultMinorColor { get; set; } = Color.Maroon;
        public static ChartDashStyle X1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dash;

        public static bool Y1Defaults { get; set; } = true;
        /// <summary>
        /// Y1 defaults
        /// </summary>
        // Marker stuff
        public static MarkerStyle Y1DefaultMarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int Y1DefaultMarkerSize { get; set; } = 3;
        public static Color Y1DefaultMarkerColor { get; set; } = Color.Blue;
        public static int Y1DefaultMarkerBorderSize { get; set; } = 1;
        public static Color Y1DefaultMarkerBorderColor { get; set; } = Color.Blue;

        // Font
        public static FontFamily Y1DefaultFontFamily { get; set; } = new FontFamily("Arial");
        public static float Y1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle Y1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color Y1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool Y1DefaultIsLog { get; set; } = false;
        public static double Y1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color Y1DefaultMajorColor { get; set; } = Color.Maroon;
        public static int Y1DefaultMajorDecimals { get; set; } = 2;
        public static int Y1DefaultIntervalDivider { get; set; } = 5;//
        public static int Y1DefaultMajorLineWidth { get; set; } = 2;
        public static double Y1DefaultMin { get; set; } = 0;//
        public static double Y1DefaultMax { get; set; } = 2;//
        // Minor grid
        public static bool Y1DefaultMinorEnabled { get; set; } = false;
        public static int Y1DefaultMinorIntervalFraction { get; set; } = 2;
        public static int Y1DefaultMinorLineWidth { get; set; } = 1;
        public static Color Y1DefaultMinorColor { get; set; } = Color.Maroon;
        public static ChartDashStyle Y1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dash;


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
        public static bool InfiniteHistoryEnabled { get; set; } = DefaultInfiniteHistoryEnabled;
        public static int MarkerSize { get; set; } = DefaultMarkerSize;
        public static string Scheme { get; set; } = DefaultScheme;
        public static Color MarkerColor { get; set; } = DefaultMarkerColor;
        /// <summary>
        /// X1 Axis
        /// </summary>
        /// // Angle Type
        public static string X1AngleType { get; set; } = X1DefaultAngleType;
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
        public static int X1MajorIntervalFraction { get; set; } = X1DefaultMajorIntervalFraction;
        public static int X1MajorLineWidth { get; set; } = X1DefaultMajorLineWidth;
        public static double X1Min { get; set; } = X1DefaultMin;
        public static double X1MaxDegrees { get; set; } = X1DefaultMax;
        // Minor grid
        public static bool X1MinorEnabled { get; set; } = X1DefaultMinorEnabled;
        public static int X1MinorIntervalFraction { get; set; } = X1DefaultMinorIntervalFraction;
        public static int X1MinorLineWidth { get; set; } = X1DefaultMinorLineWidth;
        public static Color X1MinorColor { get; set; } = X1DefaultMinorColor;
        public static ChartDashStyle X1MinorDashStyle { get; set; } = X1DefaultMinorDashStyle;

        /// <summary>
        /// Y1 Axis
        /// </summary>
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
        public static int Y1IntervalDivider { get; set; } = Y1DefaultIntervalDivider;
        public static int Y1MajorLineWidth { get; set; } = Y1DefaultMajorLineWidth;
        public static double Y1Min { get; set; } = Y1DefaultMin;
        public static double Y1Max { get; set; } = Y1DefaultMax;
        // Minor grid
        public static bool Y1MinorEnabled { get; set; } = Y1DefaultMinorEnabled;
        public static int Y1MinorIntervalFraction { get; set; } = Y1DefaultMinorIntervalFraction;
        public static int Y1MinorLineWidth { get; set; } = Y1DefaultMinorLineWidth;
        public static Color Y1MinorColor { get; set; } = Y1DefaultMinorColor;
        public static ChartDashStyle Y1MinorDashStyle { get; set; } = Y1DefaultMinorDashStyle;

        public FormGForceSettings()
        {
            InitializeComponent();
            // Keep all grouped setting rows visible and editable in the Designer.
            // Do not initialize runtime data, font bindings or JSON profiles there.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            Disposed += (sender, args) => comboFonts.Dispose();
            ChartSettingsUi.ConfigureFontFamilies(X1ComboBoxFonts, Y1ComboBoxFonts);
            // Data binding automatically selects the first installed font (often
            // Agency FB). Explicitly choose Arial for BOTH axes before loading
            // their model values, regardless of the Defaults checkboxes.
            ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1DefaultFontFamily);
            ChartSettingsUi.SelectFontFamily(Y1ComboBoxFonts, Y1DefaultFontFamily);
            ChartSettingsUi.ConfigureOwnerDraw(true, MarkerColorComboBox, BackgroundColorComboBox,
                SchemeComboBox, X1FontStyleComboBox, Y1FontStyleComboBox,
                X1FontColorComboBox, Y1FontColorComboBox,
                X1MajorColorComboBox, Y1MajorColorComboBox,
                X1MinorColorComboBox, Y1MinorColorComboBox);
            ChartSettingsUi.ConfigureOwnerDraw(false, X1FontSizeComboBox, Y1FontSizeComboBox);

            AddInComboBoxes();
            LoadX1Defaults();
            LoadY1Defaults();
            LoadOtherDefaults();
            ComboBoxBehaviors.EnableSearch(this);
            // Match Form4WheelsSettings: selecting a profile applies its appearance
            // without discarding accumulated chart data.
            JsonFormSettings.AttachProfileButton(this, () => ApplySettings(clearHistory: false));
            readyForUserEvents = true;
        }

        public static void RestoreSavedModel()
        {
            using (var settings = new FormGForceSettings())
            {
                JsonFormSettings.LoadAllSettings(settings);
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
                Y1MajorLineWidthComboBox, Y1MinorLineWidthComboBox,
                X1MajorIntervalFractionComboBox, Y1MajorIntervalDividerComboBox);
            ChartSettingsUi.AddIntegers(2, 10, X1MinorIntervalComboBox, Y1MinorIntervalComboBox);
            ChartSettingsUi.AddIntegers(0, 10, Y1MajorDecimalsComboBox);
            ChartSettingsUi.AddOptions(SchemeComboBox, "Colorblind", "Green Red", "Blue Red");
            ChartSettingsUi.AddOptions(X1AngleTypeComboBox, "Degrees", "Radians");
        }
        private void LoadOtherDefaults()
        {
            //Default background color
            if (DefaultsCheckBox.Checked == true)
            {
                ChartSettingsUi.SelectColor(BackgroundColorComboBox, DefaultBackgroundColor);
                ChartSettingsUi.SelectColor(MarkerColorComboBox, DefaultMarkerColor);
                HistoryAmountPointsMaskedTextBox.Text = DefaultHistoryAmountPoints.ToString();
                InfiniteHistoryCheckBox.Checked = DefaultInfiniteHistoryEnabled;
                SchemeComboBox.SelectedItem = DefaultScheme;
            }
            else
            {
                ChartSettingsUi.SelectColor(BackgroundColorComboBox, BackgroundColor);
                ChartSettingsUi.SelectColor(MarkerColorComboBox, MarkerColor);
                HistoryAmountPointsMaskedTextBox.Text = HistoryAmountPoints.ToString();
                InfiniteHistoryCheckBox.Checked = InfiniteHistoryEnabled;
                SchemeComboBox.SelectedItem = Scheme;
            }
        }
        private void FormGForceSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsOpen = false;
            JsonFormSettings.SaveAllSettings(this);
        }
        private void FormGForceSettings_Load(object sender, EventArgs e)
        {
            SettingsOpen = true;
            JsonFormSettings.LoadAllSettings(this);
            // The shared JSON loader upgrades the erroneous first-font value
            // in old G-Force autosaves. Current profiles retain an explicitly
            // selected font even when Defaults is unchecked.
            EnsureDefaultFontSelections();
            // Match Form4WheelsSettings: applying saved values on opening Settings
            // must never clear live data or reset the user's history.
            ApplySettings(clearHistory: false);
        }
        private void EnsureDefaultFontSelections()
        {
            // Defaults being OFF must not mean "use the first installed font".
            // In custom mode keep the selected user font, but recover to the
            // configured model font (initially Arial) if the selection is empty.
            if (X1DefaultsCheckBox.Checked)
                ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1DefaultFontFamily);
            else if (!(X1ComboBoxFonts.SelectedItem is FontFamily))
                ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1FontFamily ?? X1DefaultFontFamily);

            if (Y1DefaultsCheckBox.Checked)
                ChartSettingsUi.SelectFontFamily(Y1ComboBoxFonts, Y1DefaultFontFamily);
            else if (!(Y1ComboBoxFonts.SelectedItem is FontFamily))
                ChartSettingsUi.SelectFontFamily(Y1ComboBoxFonts, Y1FontFamily ?? Y1DefaultFontFamily);
        }

        private void LoadX1Defaults()
        {
            // Default X1 selections
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1AngleTypeComboBox.SelectedItem = X1DefaultAngleType;

                ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1DefaultFontFamily);


                X1FontSizeComboBox.SelectedItem = X1DefaultFontSize;

                X1FontStyleComboBox.SelectedItem = X1DefaultFontStyle;

                ChartSettingsUi.SelectColor(X1FontColorComboBox, X1DefaultFontColor);

                ChartSettingsUi.SelectColor(X1MajorColorComboBox, X1DefaultMajorColor);
                //X1MajorDecimalsComboBox.SelectedItem = X1DefaultMajorDecimals;
                X1MajorIntervalFractionComboBox.SelectedItem = X1DefaultMajorIntervalFraction;
                X1MajorLineWidthComboBox.SelectedItem = X1DefaultMajorLineWidth;
                ChartSettingsUi.SelectColor(X1MinorColorComboBox, X1DefaultMinorColor);
                X1MinorDashStyleComboBox.SelectedItem = X1DefaultMinorDashStyle;
                X1MinorEnabledCheckBox.Checked = X1DefaultMinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = X1DefaultMinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = X1DefaultMinorLineWidth;
            }
            else
            {
                X1AngleTypeComboBox.SelectedItem = X1AngleType;

                ChartSettingsUi.SelectFontFamily(X1ComboBoxFonts, X1FontFamily);


                X1FontSizeComboBox.SelectedItem = X1FontSize;

                X1FontStyleComboBox.SelectedItem = X1FontStyle;

                ChartSettingsUi.SelectColor(X1FontColorComboBox, X1FontColor);

                ChartSettingsUi.SelectColor(X1MajorColorComboBox, X1MajorColor);
                //X1MajorDecimalsComboBox.SelectedItem = X1MajorDecimals;
                X1MajorIntervalFractionComboBox.SelectedItem = X1MajorIntervalFraction;
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
            // Default Y1 selections
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1MaxMaskedTextBox.Text = Y1DefaultMax.ToString();
                Y1MinMaskedTextBox.Text = Y1DefaultMin.ToString();

                ChartSettingsUi.SelectFontFamily(Y1ComboBoxFonts, Y1DefaultFontFamily);


                Y1FontSizeComboBox.SelectedItem = Y1DefaultFontSize;

                Y1FontStyleComboBox.SelectedItem = Y1DefaultFontStyle;

                ChartSettingsUi.SelectColor(Y1FontColorComboBox, Y1DefaultFontColor);

                ChartSettingsUi.SelectColor(Y1MajorColorComboBox, Y1DefaultMajorColor);
                Y1MajorDecimalsComboBox.SelectedItem = Y1DefaultMajorDecimals;
                Y1MajorIntervalDividerComboBox.SelectedItem = Y1DefaultIntervalDivider;
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


                Y1FontSizeComboBox.SelectedItem = Y1FontSize;

                Y1FontStyleComboBox.SelectedItem = Y1FontStyle;

                ChartSettingsUi.SelectColor(Y1FontColorComboBox, Y1FontColor);

                ChartSettingsUi.SelectColor(Y1MajorColorComboBox, Y1MajorColor);
                Y1MajorDecimalsComboBox.SelectedItem = Y1MajorDecimals;
                Y1MajorIntervalDividerComboBox.SelectedItem = Y1IntervalDivider;
                Y1MajorLineWidthComboBox.SelectedItem = Y1MajorLineWidth;
                ChartSettingsUi.SelectColor(Y1MinorColorComboBox, Y1MinorColor);
                Y1MinorDashStyleComboBox.SelectedItem = Y1MinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = Y1MinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = Y1MinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = Y1MinorLineWidth;
            }
        }

        private void applyChartSettingsButton_Click(object sender, EventArgs e)
        {
            ApplySettings(clearHistory: false);
        }

        private void applyAndClearButton_Click(object sender, EventArgs e)
        {
            ApplySettings(clearHistory: true);
        }

        /// <summary>
        /// Same Apply/Clear workflow as Form4WheelsSettings. Settings changes
        /// restyle the G-force charts; only the Clear variant discards samples.
        /// Both data timers are paused while chart properties/points are changed.
        /// </summary>
        private void ApplySettings(bool clearHistory)
        {
            FormGForce form = Application.OpenForms["FormGForce"] as FormGForce;
            bool timerWasEnabled = form != null && form.timer1.Enabled;
            bool snapshotWasEnabled = form != null && form.timer2.Enabled;
            if (form != null)
            {
                form.timer1.Enabled = false;
                form.timer2.Enabled = false;
            }
            try
            {
                try
                {
                    ApplyControlsToModel();
                }
                catch (Exception ex) when (ex is ArgumentException ||
                                           ex is InvalidOperationException ||
                                           ex is FormatException)
                {
                    MessageBox.Show(this, ex.Message, "G-force chart settings",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (form != null)
                {
                    if (clearHistory)
                        form.ClearAllSeriesHistory();
                    form.ApplyChartSettings();
                }
                JsonFormSettings.SaveAllSettings(this);
            }
            finally
            {
                if (form != null && !form.IsDisposed)
                {
                    form.timer1.Enabled = timerWasEnabled;
                    form.timer2.Enabled = snapshotWasEnabled;
                }
            }
        }

        private void ApplyControlsToModel()
        {
            // Keep the displayed font and the font passed to FormGForce in
            // agreement. Existing saved profiles may still contain the old
            // first-entry font while the Defaults checkbox is checked.
            EnsureDefaultFontSelections();
            if (DefaultsCheckBox.Checked == true)
            {
                BackgroundColor = DefaultBackgroundColor;
                MarkerColor = DefaultMarkerColor;
                HistoryAmountPoints = DefaultHistoryAmountPoints;
                InfiniteHistoryEnabled = DefaultInfiniteHistoryEnabled;
                Scheme = DefaultScheme;
            }
            else
            {
                BackgroundColor = (Color)BackgroundColorComboBox.SelectedItem;
                MarkerColor = (Color)MarkerColorComboBox.SelectedItem;
                HistoryAmountPoints = (int)TextBoxBaseParsers.HistoryAmountPointsParser(HistoryAmountPointsMaskedTextBox, DefaultHistoryAmountPoints, true);
                InfiniteHistoryEnabled = InfiniteHistoryCheckBox.Checked;
                Scheme = SchemeComboBox.Text;
            }

            // X-Axis
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1AngleType = X1DefaultAngleType;

                X1FontFamily = X1DefaultFontFamily;
                X1FontSize = X1DefaultFontSize;
                X1FontStyle = X1DefaultFontStyle;
                X1FontColor = X1DefaultFontColor;

                X1MajorLineWidth = X1DefaultMajorLineWidth;
                X1MajorIntervalFraction = X1DefaultMajorIntervalFraction;
                X1MajorColor = X1DefaultMajorColor;

                X1MinorEnabled = X1DefaultMinorEnabled;
                X1MinorIntervalFraction = X1DefaultMinorIntervalFraction;
                X1MinorLineWidth = X1DefaultMinorLineWidth;
                X1MinorColor = X1DefaultMinorColor;
                X1MinorDashStyle = X1DefaultMinorDashStyle;
            }
            else
            {
                X1AngleType = X1AngleTypeComboBox.Text;
                X1FontFamily = (FontFamily)X1ComboBoxFonts.SelectedItem;
                X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
                X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
                X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;

                X1MajorLineWidth = (int)X1MajorLineWidthComboBox.SelectedItem;
                X1MajorIntervalFraction = (int)X1MajorIntervalFractionComboBox.SelectedItem;//Parsers.TextBoxParserInt(X1MajorIntervalFractionTextBox, X1MajorIntervalFraction, X1DefaultMajorIntervalFraction, true);
                X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;

                X1MinorEnabled = X1MinorEnabledCheckBox.Checked;
                X1MinorIntervalFraction = (int)X1MinorIntervalComboBox.SelectedItem;
                X1MinorLineWidth = (int)X1MinorLineWidthComboBox.SelectedItem;
                X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
                X1MinorDashStyle = (ChartDashStyle)X1MinorDashStyleComboBox.SelectedItem;
            }

            // Y-Axis
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
                Y1IntervalDivider = Y1DefaultIntervalDivider;
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

                Y1Min = (double)TextBoxBaseParsers.Parser(Y1MinMaskedTextBox, Y1DefaultMin, true);
                Y1Max = (double)TextBoxBaseParsers.Parser(Y1MaxMaskedTextBox, Y1DefaultMax, true);

                Y1MajorLineWidth = (int)Y1MajorLineWidthComboBox.SelectedItem;
                Y1MajorDecimals = (int)Y1MajorDecimalsComboBox.SelectedItem;
                Y1IntervalDivider = (int)Y1MajorIntervalDividerComboBox.SelectedItem;//Parsers.TextBoxParserInt(Y1IntervalDividerTextBox, Y1IntervalDivider, Y1DefaultIntervalDivider, true);
                Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;

                Y1MinorEnabled = Y1MinorEnabledCheckBox.Checked;
                Y1MinorIntervalFraction = (int)Y1MinorIntervalComboBox.SelectedItem;
                Y1MinorLineWidth = (int)Y1MinorLineWidthComboBox.SelectedItem;
                Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
                Y1MinorDashStyle = (ChartDashStyle)Y1MinorDashStyleComboBox.SelectedItem;
            }
        }

        private void LoadCurrentValuesButton_Click(object sender, EventArgs e)
        {
            LoadX1Defaults();
            LoadY1Defaults();
            LoadOtherDefaults();
        }
        private void CheckFontColorAndSetBackGroundColor(ComboBox cb, Color fontColor)
        {
            ChartSettingsUi.SetContrast(cb, fontColor);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        ///OTHER STUFF
        ///
        private void DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OtherDefaults = DefaultsCheckBox.Checked;
            if (readyForUserEvents)
                LoadOtherDefaults();
        }
        private void MarkerColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void MarkerColorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            MarkerColorComboBox.ForeColor = (Color)color;
            comboFonts.SetFont(MarkerColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(MarkerColorComboBox, (Color)color);
        }
        private void BackgroundColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void BackgroundColorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            BackgroundColorComboBox.ForeColor = (Color)color;
            comboFonts.SetFont(BackgroundColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, (Color)color);
        }
        private void SchemeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawScheme((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        #region X1 STUFF
        ///
        private void X1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            X1Defaults = X1DefaultsCheckBox.Checked;
            if (readyForUserEvents)
                LoadX1Defaults();
        }
        private void X1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawFontFamily((ComboBox)sender, e, X1DefaultFontSize, X1DefaultFontStyle);
        }
        private void X1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            comboFonts.SetFont(X1ComboBoxFonts, fontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        private void X1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            comboFonts.SetFont(X1FontStyleComboBox, X1DefaultFontFamily, X1DefaultFontSize, fontStyle);
        }
        private void X1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawFontStyle((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize);
        }
        private void X1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            comboFonts.SetFont(X1FontColorComboBox, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
            X1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, (Color)color);
        }
        private void X1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        private void X1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.SelectedItem;
            //X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
            comboFonts.SetFont(X1FontSizeComboBox, X1DefaultFontFamily, (float)fontSize, X1DefaultFontStyle);
            //textBox8.Text = X1FontSize.ToString();
            //comboBox7.Text = p.GetX1FontSize().ToString();
        }
        private void X1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawFontSize((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        private void X1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            comboFonts.SetFont(X1MajorColorComboBox, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
            X1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, (Color)color);
        }
        private void X1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        private void X1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            comboFonts.SetFont(X1MinorColorComboBox, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
            X1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MinorColorComboBox, (Color)color);
        }
        private void X1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, X1DefaultFontFamily, X1DefaultFontSize, X1DefaultFontStyle);
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////77
        #region Y1 STUFF
        ///
        private void Y1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Y1Defaults = Y1DefaultsCheckBox.Checked;
            if (readyForUserEvents)
                LoadY1Defaults();
        }
        private void Y1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawFontFamily((ComboBox)sender, e, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void Y1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            comboFonts.SetFont(Y1ComboBoxFonts, fontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void Y1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            comboFonts.SetFont(Y1FontStyleComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, fontStyle);
        }
        private void Y1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawFontStyle((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize);
        }
        private void Y1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            comboFonts.SetFont(Y1FontColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            Y1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, (Color)color);
        }
        private void Y1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void Y1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.SelectedItem;
            comboFonts.SetFont(Y1FontSizeComboBox, Y1DefaultFontFamily, (float)fontSize, Y1DefaultFontStyle);
        }
        private void Y1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawFontSize((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void Y1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            comboFonts.SetFont(Y1MajorColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            Y1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, (Color)color);
        }
        private void Y1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        private void Y1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            //Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            comboFonts.SetFont(Y1MinorColorComboBox, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
            Y1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MinorColorComboBox, (Color)color);
        }
        private void Y1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChartSettingsUi.DrawColor((ComboBox)sender, e, Y1DefaultFontFamily, Y1DefaultFontSize, Y1DefaultFontStyle);
        }
        #endregion
        
    }
}
