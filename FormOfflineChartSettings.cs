using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Offline counterpart to Form4WheelsSettings. All fields are independent
    /// from the live settings and persist as FormOfflineChartSettings.json.
    /// </summary>
    public partial class FormOfflineChartSettings : Form
    {
        private readonly FormOfflineChart ownerChart;
        private OfflineChartOptions startingOptions;
        private bool preparing;
        private static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;

        public FormOfflineChartSettings() : this(null, new OfflineChartOptions()) { }

        internal FormOfflineChartSettings(FormOfflineChart chart, OfflineChartOptions options)
        {
            ownerChart = chart;
            startingOptions = options.Clone();
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            FilterRows = ChartLimiterRow.ConfigureRows(new[] { axisXFilterRow, axisYFilterRow, axisZFilterRow, extraFilterRow01, extraFilterRow02, extraFilterRow03, extraFilterRow04, extraFilterRow05, extraFilterRow06, extraFilterRow07, extraFilterRow08, extraFilterRow09, extraFilterRow10 }, "OfflineFilter");
            PopulateOptions();
            DisplayOptions(startingOptions);
            JsonFormSettings.EnsureFactoryDefaults(this);
            JsonFormSettings.LoadAllSettings(this, includeSettingsFilters: false);
            JsonFormSettings.AttachProfileButton(this, ApplyChanges, () => preparing = true, () => { preparing = false; Update3DControls(false); });
            ComboBoxBehaviors.EnableSearch(this);
            xDefaultsButton.Click += (s,e) => ResetAxis(0);
            yDefaultsButton.Click += (s,e) => ResetAxis(1);
            zDefaultsButton.Click += (s,e) => ResetAxis(2);
            xColumnComboBox.SelectionChangeCommitted += (s,e) => ResetAxis(0);
            yColumnComboBox.SelectionChangeCommitted += (s,e) => ResetAxis(1);
            zColumnComboBox.SelectionChangeCommitted += (s,e) => { if (ColorFieldBox == zColumnComboBox) ResetAxis(2); };
            xAutoCheckBox.CheckedChanged += (s,e) => UpdateAutoVisibility();
            yAutoCheckBox.CheckedChanged += (s,e) => UpdateAutoVisibility();
            zAutoCheckBox.CheckedChanged += (s,e) => UpdateAutoVisibility();
            use3DCheckBox.CheckedChanged += (s,e) => Update3DControls(true);
            useFourthColorCheckBox.CheckedChanged += (s,e) => Update3DControls(true);
            fourthColorComboBox.SelectionChangeCommitted += (s,e) => ResetAxis(2);
            Update3DControls(false);
            UpdateAutoVisibility();
            FillMissingAxisBounds();
        }

        internal ChartLimiterRow[] FilterRows { get; private set; }
        internal Control FilterSettingsRoot => filterSettingsRows;

        internal void Prepare(OfflineChartOptions options, bool restoreSaved = false)
        {
            preparing = true;
            try
            {
                startingOptions = options.Clone();
                PopulateColumns();
                DisplayOptions(startingOptions);
                if (restoreSaved) JsonFormSettings.LoadAllSettings(this, includeSettingsFilters: false);
                Update3DControls(false);
                UpdateAutoVisibility();
            }
            finally { preparing = false; }
        }

        private ComboBox ColorFieldBox => use3DCheckBox.Checked && useFourthColorCheckBox.Checked
            ? fourthColorComboBox : zColumnComboBox;

        private void Update3DControls(bool resetColorRange)
        {
            useFourthColorCheckBox.Enabled = use3DCheckBox.Checked;
            fourthColorComboBox.Enabled = use3DCheckBox.Checked && useFourthColorCheckBox.Checked;
            chartTypeComboBox.Enabled = !use3DCheckBox.Checked;
            zAxisGroup.Text = use3DCheckBox.Checked ? "Z / color axis (3D)" : "Z / color axis";
            if (resetColorRange && !preparing) ResetAxis(2);
        }

        private void ApplyButton_Click(object sender, EventArgs e) => ApplyChanges();

        private void ApplyFiltersButton_Click(object sender, EventArgs e)
        {
            if (ownerChart == null) return;
            if (ownerChart.ApplyFiltersFromSettings()) JsonFormSettings.SaveAllSettings(ownerChart);
            else MessageBox.Show(this, "Fix the highlighted filter minimum/maximum before applying.",
                "Offline chart filters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PopulateColumns()
        {
            var columns = ownerChart != null ? ownerChart.GetColumnNames().Cast<object>().ToArray() : Array.Empty<object>();
            foreach (ComboBox box in new[] { xColumnComboBox, yColumnComboBox, zColumnComboBox, fourthColorComboBox })
            {
                box.Items.Clear();
                box.Items.AddRange(columns);
            }
        }

        private void PopulateOptions()
        {
            PopulateColumns();
            schemeComboBox.Items.AddRange(GradientPalette.AvailableSchemes.Cast<object>().ToArray());
            chartTypeComboBox.Items.AddRange(Enum.GetNames(typeof(SeriesChartType)).Cast<object>().ToArray());
            markerComboBox.Items.AddRange(new object[] { "Circle", "Square", "Diamond", "Triangle", "Cross", "Star4", "Star5", "None" });
            backgroundComboBox.Items.AddRange(new object[] { "Black", "White", "DarkGray", "Gray", "MidnightBlue" });
            layoutComboBox.Items.AddRange(
                FourWheelsFieldSelection.Layouts.Cast<object>().ToArray());
            string[] colors = Enum.GetNames(typeof(KnownColor));
            foreach (ComboBox box in new[] { xFontColorComboBox, yFontColorComboBox, xGridColorComboBox, yGridColorComboBox,
                xMinorColorComboBox, yMinorColorComboBox, cursorColorComboBox })
                box.Items.AddRange(colors.Cast<object>().ToArray());
            ChartSettingsUi.ConfigureNamedColorCombos(backgroundComboBox,
                xFontColorComboBox, yFontColorComboBox,
                xGridColorComboBox, yGridColorComboBox, xMinorColorComboBox,
                yMinorColorComboBox, cursorColorComboBox);
            object[] fonts;
            using (var installed = new InstalledFontCollection())
                fonts = installed.Families.Select(font => font.Name).Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(name => name, StringComparer.CurrentCultureIgnoreCase).Cast<object>().ToArray();
            foreach (var box in new[] { xFontComboBox, yFontComboBox })
            {
                box.Items.AddRange(fonts);
                box.DrawMode = DrawMode.OwnerDrawFixed;
                box.ItemHeight = box.Font.Height + 2;
                box.MaxDropDownItems = 16;
                box.DrawItem += DrawFontFamilyItem;
            }
            string[] dashStyles = Enum.GetNames(typeof(ChartDashStyle));
            foreach (ComboBox box in new[] { xGridDashComboBox, yGridDashComboBox,
                xMinorDashComboBox, yMinorDashComboBox, cursorDashComboBox })
                box.Items.AddRange(dashStyles.Cast<object>().ToArray());
        }

        private static void SetColor(ComboBox box, Color color) =>
            ChartSettingsUi.SelectColor(box, color);

        private static Color ReadColor(ComboBox box) =>
            ChartSettingsUi.ReadColor(box);

        private static void DrawFontFamilyItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo == null || e.Index < 0 || e.Index >= combo.Items.Count) return;
            e.DrawBackground();
            string family = combo.GetItemText(combo.Items[e.Index]);
            Font font = null;
            try
            {
                font = new Font(family, combo.Font.Size, FontStyle.Regular, GraphicsUnit.Point);
                using (var ink = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(family, font, ink, e.Bounds.X + 4, e.Bounds.Y);
            }
            catch (ArgumentException)
            {
                using (var ink = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(family, combo.Font, ink, e.Bounds.X + 4, e.Bounds.Y);
            }
            finally { font?.Dispose(); }
            e.DrawFocusRectangle();
        }

        private static void SetCombo(ComboBox box, string name)
        {
            string canonical = FormOfflineChart.CanonicalAvailableField(name,
                box.Items.Cast<object>().Select(item => box.GetItemText(item)));
            if (canonical != null) box.SelectedItem = canonical;
            else if (box.Items.Count > 0) box.SelectedIndex = 0;
        }

        private void DisplayOptions(OfflineChartOptions o)
        {
            SetCombo(xColumnComboBox, o.X);
            SetCombo(yColumnComboBox, o.Y);
            SetCombo(zColumnComboBox, o.Z);
            SetCombo(fourthColorComboBox, o.FourthColor);
            use3DCheckBox.Checked = o.Use3D;
            useFourthColorCheckBox.Checked = o.UseFourthColor;
            Update3DControls(false);
            SetCombo(schemeComboBox, o.Scheme == "Default" ? "Blue Red" : o.Scheme);
            SetCombo(chartTypeComboBox, o.ChartType.ToString());
            SetCombo(markerComboBox, o.Marker.ToString());
            SetCombo(backgroundComboBox, o.Background.Name);
            SetCombo(layoutComboBox, o.Layout);
            tooltipEnableCheckBox.Checked = o.ShowPointTooltips;
            tooltipDelayNumeric.Value = Math.Max(0,Math.Min(10000,o.PointTooltipDelayMs));
            bandsNumeric.Value = Math.Max(1,Math.Min(64,o.Bands));
            markerSizeNumeric.Value = Math.Max(1,Math.Min(20,o.MarkerSize));
            paletteAlphaNumeric.Value = Math.Max(1,Math.Min(255,o.PaletteAlpha));
            paletteDividerNumeric.Value = Math.Max(1,Math.Min(8,o.PaletteDivider));
            absoluteCheckBox.Checked = o.Absolute;
            xAutoCheckBox.Checked = !o.XMinimum.HasValue || !o.XMaximum.HasValue;
            yAutoCheckBox.Checked = !o.YMinimum.HasValue || !o.YMaximum.HasValue;
            zAutoCheckBox.Checked = !o.ZMinimum.HasValue || !o.ZMaximum.HasValue;
            xMinimumBox.Text = Format(o.XMinimum); xMaximumBox.Text = Format(o.XMaximum);
            yMinimumBox.Text = Format(o.YMinimum); yMaximumBox.Text = Format(o.YMaximum);
            zMinimumBox.Text = Format(o.ZMinimum); zMaximumBox.Text = Format(o.ZMaximum);
            xGridIntervalBox.Text = o.XGridInterval.ToString(Invariant);
            yGridIntervalBox.Text = o.YGridInterval.ToString(Invariant);
            xDecimalsNumeric.Value = Math.Max(0,Math.Min(8,o.XDecimals));
            yDecimalsNumeric.Value = Math.Max(0,Math.Min(8,o.YDecimals));
            xMinorCheckBox.Checked = o.XMinorGrid;
            yMinorCheckBox.Checked = o.YMinorGrid;
            xLogCheckBox.Checked = o.XLogarithmic;
            yLogCheckBox.Checked = o.YLogarithmic;
            xLogBaseBox.Text = o.XLogBase.ToString(Invariant);
            yLogBaseBox.Text = o.YLogBase.ToString(Invariant);
            xFontSizeNumeric.Value = Math.Max(0.25m, Math.Min(36m,o.XFontSize));
            yFontSizeNumeric.Value = Math.Max(0.25m, Math.Min(36m,o.YFontSize));
            xGridWidthNumeric.Value = Math.Max(0.25m, Math.Min(8m,o.XGridWidth));
            yGridWidthNumeric.Value = Math.Max(0.25m, Math.Min(8m,o.YGridWidth));
            xMinorWidthNumeric.Value = Math.Max(0.25m, Math.Min(8m,o.XMinorWidth));
            yMinorWidthNumeric.Value = Math.Max(0.25m, Math.Min(8m,o.YMinorWidth));
            SetCombo(xFontComboBox,o.XFontFamily); SetCombo(yFontComboBox,o.YFontFamily);
            SetColor(xFontColorComboBox,o.XFontColor); SetColor(yFontColorComboBox,o.YFontColor);
            SetColor(xGridColorComboBox,o.XGridColor); SetColor(yGridColorComboBox,o.YGridColor);
            SetColor(xMinorColorComboBox,o.XMinorColor); SetColor(yMinorColorComboBox,o.YMinorColor);
            SetCombo(xGridDashComboBox, o.XGridDashStyle.ToString());
            SetCombo(yGridDashComboBox, o.YGridDashStyle.ToString());
            SetCombo(xMinorDashComboBox, o.XMinorDashStyle.ToString());
            SetCombo(yMinorDashComboBox, o.YMinorDashStyle.ToString());
            xGridAlphaNumeric.Value = Math.Max(0,Math.Min(255,o.XGridAlpha));
            yGridAlphaNumeric.Value = Math.Max(0,Math.Min(255,o.YGridAlpha));
            xMinorAlphaNumeric.Value = Math.Max(0,Math.Min(255,o.XMinorAlpha));
            yMinorAlphaNumeric.Value = Math.Max(0,Math.Min(255,o.YMinorAlpha));
            cursorEnabledCheckBox.Checked = o.CursorEnabled;
            cursorZoomCheckBox.Checked = o.CursorZoomable;
            SetColor(cursorColorComboBox,o.CursorColor);
            cursorAlphaNumeric.Value = Math.Max(0,Math.Min(255,o.CursorAlpha));
            cursorWidthNumeric.Value = Math.Max(0.25m, Math.Min(20m,o.CursorWidth));
            SetCombo(cursorDashComboBox,o.CursorDashStyle.ToString());
        }

        private static string Format(double? value) => value?.ToString("G9",Invariant) ?? "";
        private static bool ParseDouble(string text, out double result) =>
            double.TryParse(text,NumberStyles.Float,CultureInfo.CurrentCulture,out result) ||
            double.TryParse(text,NumberStyles.Float,Invariant,out result);

        private void UpdateAutoVisibility()
        {
            xMinimumBox.Enabled = xMaximumBox.Enabled = !xAutoCheckBox.Checked;
            yMinimumBox.Enabled = yMaximumBox.Enabled = !yAutoCheckBox.Checked;
            zMinimumBox.Enabled = zMaximumBox.Enabled = !zAutoCheckBox.Checked;
            FillMissingAxisBounds();
        }

        private void FillMissingAxisBounds()
        {
            FillOneAxis(xColumnComboBox, xMinimumBox, xMaximumBox);
            FillOneAxis(yColumnComboBox, yMinimumBox, yMaximumBox);
            FillOneAxis(ColorFieldBox, zMinimumBox, zMaximumBox);
        }

        private void FillOneAxis(ComboBox field, TextBox minBox, TextBox maxBox)
        {
            if (!string.IsNullOrWhiteSpace(minBox.Text) && !string.IsNullOrWhiteSpace(maxBox.Text)) return;
            if (ownerChart != null && ownerChart.TryGetFieldRange(field.Text,absoluteCheckBox.Checked,
                out double low,out double high))
            {
                if (string.IsNullOrWhiteSpace(minBox.Text)) minBox.Text = Format(low);
                if (string.IsNullOrWhiteSpace(maxBox.Text)) maxBox.Text = Format(high);
            }
            else if (GameMemoryConfig.TryGetWheelAxisDefaults(field.Text,out WheelAxisProfile defaults))
            {
                if (string.IsNullOrWhiteSpace(minBox.Text)) minBox.Text = Format(absoluteCheckBox.Checked ? 0d : defaults.Min);
                if (string.IsNullOrWhiteSpace(maxBox.Text)) maxBox.Text = Format(defaults.Max);
            }
        }

        private void ResetAxis(int axis)
        {
            ComboBox selected = axis == 0 ? xColumnComboBox : axis == 1 ? yColumnComboBox : ColorFieldBox;
            TextBox minimum = axis == 0 ? xMinimumBox : axis == 1 ? yMinimumBox : zMinimumBox;
            TextBox maximum = axis == 0 ? xMaximumBox : axis == 1 ? yMaximumBox : zMaximumBox;
            if (ownerChart != null && ownerChart.TryGetFieldRange(selected.Text, absoluteCheckBox.Checked, out double min, out double max))
            {
                minimum.Text = min.ToString("G9",Invariant);
                maximum.Text = max.ToString("G9",Invariant);
            }
            else
            {
                // Without a loaded file, configured wheel ranges are useful defaults.
                if (GameMemoryConfig.TryGetWheelAxisDefaults(selected.Text, out WheelAxisProfile defaults))
                {
                    minimum.Text = (absoluteCheckBox.Checked ? 0d : defaults.Min).ToString(Invariant);
                    maximum.Text = defaults.Max.ToString(Invariant);
                }
                else { minimum.Text = ""; maximum.Text = ""; }
            }
        }

        private static void ReadBounds(CheckBox automatic, TextBox minimumBox, TextBox maximumBox,
            string label, out double? minimum, out double? maximum)
        {
            minimum = maximum = null;
            if (automatic.Checked) return;
            if (!ParseDouble(minimumBox.Text, out double min) || !ParseDouble(maximumBox.Text, out double max) ||
                double.IsNaN(min) || double.IsNaN(max) || double.IsInfinity(min) || double.IsInfinity(max) || min >= max)
                throw new FormatException(label + " requires numeric minimum and maximum, with minimum < maximum.");
            minimum = min; maximum = max;
        }

        internal void ApplySavedSettings() => ApplyChanges(false);

        private void ApplyChanges() => ApplyChanges(true);

        // Silent startup restore must not rewrite the JSON autosave with
        // fallback fields from an unrelated CSV. Only explicit Apply saves.
        private void ApplyChanges(bool persist)
        {
            try
            {
                var result = startingOptions.Clone();
                result.X = xColumnComboBox.Text;
                result.Y = yColumnComboBox.Text;
                result.Z = zColumnComboBox.Text;
                result.Use3D = use3DCheckBox.Checked;
                result.UseFourthColor = result.Use3D && useFourthColorCheckBox.Checked;
                result.FourthColor = fourthColorComboBox.Text;
                if (result.UseFourthColor && string.IsNullOrWhiteSpace(result.FourthColor))
                    throw new FormatException("Select a fourth field for the color axis.");
                if (string.IsNullOrWhiteSpace(result.X) || string.IsNullOrWhiteSpace(result.Y) || string.IsNullOrWhiteSpace(result.Z))
                    throw new FormatException("Select an X, Y and Z column.");
                result.Scheme = schemeComboBox.Text;
                result.Bands = (int)bandsNumeric.Value;
                result.MarkerSize = (int)markerSizeNumeric.Value;
                result.ShowPointTooltips = tooltipEnableCheckBox.Checked;
                result.PointTooltipDelayMs = (int)tooltipDelayNumeric.Value;
                result.PaletteAlpha = (int)paletteAlphaNumeric.Value;
                result.PaletteDivider = (int)paletteDividerNumeric.Value;
                result.Absolute = absoluteCheckBox.Checked;
                result.Layout = layoutComboBox.Text;
                result.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType),chartTypeComboBox.Text);
                if (!result.Use3D && !FormOfflineChart.CanDrawWithXYZ(result.ChartType))
                    throw new FormatException(result.ChartType + " requires multiple Y fields. " +
                        "It is listed for completeness, but this XY/Z importer cannot draw it from one Y column.");
                result.Marker = (MarkerStyle)Enum.Parse(typeof(MarkerStyle),markerComboBox.Text);
                result.Background = ReadColor(backgroundComboBox);
                FillMissingAxisBounds();
                ReadBounds(xAutoCheckBox,xMinimumBox,xMaximumBox,"X axis",out result.XMinimum,out result.XMaximum);
                ReadBounds(yAutoCheckBox,yMinimumBox,yMaximumBox,"Y axis",out result.YMinimum,out result.YMaximum);
                ReadBounds(zAutoCheckBox,zMinimumBox,zMaximumBox,"Z axis",out result.ZMinimum,out result.ZMaximum);
                if (!ParseDouble(xGridIntervalBox.Text,out result.XGridInterval) || double.IsNaN(result.XGridInterval) || double.IsInfinity(result.XGridInterval) || result.XGridInterval < 0 ||
                    !ParseDouble(yGridIntervalBox.Text,out result.YGridInterval) || double.IsNaN(result.YGridInterval) || double.IsInfinity(result.YGridInterval) || result.YGridInterval < 0)
                    throw new FormatException("Grid intervals must be positive numbers, or zero for automatic intervals.");
                result.XMinorGrid = xMinorCheckBox.Checked;
                result.YMinorGrid = yMinorCheckBox.Checked;
                result.XDecimals = (int)xDecimalsNumeric.Value;
                result.YDecimals = (int)yDecimalsNumeric.Value;
                result.XLogarithmic = xLogCheckBox.Checked;
                result.YLogarithmic = yLogCheckBox.Checked;
                if (!ParseDouble(xLogBaseBox.Text,out result.XLogBase) || double.IsNaN(result.XLogBase) || double.IsInfinity(result.XLogBase) || result.XLogBase <= 1 ||
                    !ParseDouble(yLogBaseBox.Text,out result.YLogBase) || double.IsNaN(result.YLogBase) || double.IsInfinity(result.YLogBase) || result.YLogBase <= 1)
                    throw new FormatException("Logarithmic bases must be greater than 1.");
                if (result.XLogarithmic && result.XMinimum.HasValue && result.XMinimum <= 0)
                    throw new FormatException("The X minimum must be greater than zero when using logarithmic X.");
                if (result.YLogarithmic && result.YMinimum.HasValue && result.YMinimum <= 0)
                    throw new FormatException("The Y minimum must be greater than zero when using logarithmic Y.");
                result.XFontSize = xFontSizeNumeric.Value;
                result.YFontSize = yFontSizeNumeric.Value;
                result.XGridWidth = xGridWidthNumeric.Value;
                result.YGridWidth = yGridWidthNumeric.Value;
                result.XMinorWidth = xMinorWidthNumeric.Value;
                result.YMinorWidth = yMinorWidthNumeric.Value;
                result.XFontFamily = xFontComboBox.Text;
                result.YFontFamily = yFontComboBox.Text;
                result.XFontColor = ReadColor(xFontColorComboBox);
                result.YFontColor = ReadColor(yFontColorComboBox);
                result.XGridColor = ReadColor(xGridColorComboBox);
                result.YGridColor = ReadColor(yGridColorComboBox);
                result.XMinorColor = ReadColor(xMinorColorComboBox);
                result.YMinorColor = ReadColor(yMinorColorComboBox);
                result.XGridAlpha = (int)xGridAlphaNumeric.Value;
                result.YGridAlpha = (int)yGridAlphaNumeric.Value;
                result.XMinorAlpha = (int)xMinorAlphaNumeric.Value;
                result.YMinorAlpha = (int)yMinorAlphaNumeric.Value;
                result.XGridDashStyle = (ChartDashStyle)Enum.Parse(typeof(ChartDashStyle),xGridDashComboBox.Text);
                result.YGridDashStyle = (ChartDashStyle)Enum.Parse(typeof(ChartDashStyle),yGridDashComboBox.Text);
                result.XMinorDashStyle = (ChartDashStyle)Enum.Parse(typeof(ChartDashStyle),xMinorDashComboBox.Text);
                result.YMinorDashStyle = (ChartDashStyle)Enum.Parse(typeof(ChartDashStyle),yMinorDashComboBox.Text);
                result.CursorEnabled = cursorEnabledCheckBox.Checked;
                result.CursorZoomable = cursorZoomCheckBox.Checked;
                result.CursorColor = ReadColor(cursorColorComboBox);
                result.CursorAlpha = (int)cursorAlphaNumeric.Value;
                result.CursorWidth = cursorWidthNumeric.Value;
                result.CursorDashStyle = (ChartDashStyle)Enum.Parse(typeof(ChartDashStyle),cursorDashComboBox.Text);
                ownerChart?.ApplyOptions(result);
                if (persist) JsonFormSettings.SaveAllSettings(this);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException || ex is InvalidOperationException)
            {
                if (persist)
                {
                    MessageBox.Show(this, ex.Message, "Chart settings",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // This form can be constructed invisibly during the first
                    // CSV import. A modal MessageBox owned by a HIDDEN form can
                    // block the application and make all chart buttons appear
                    // unresponsive. Keep the current chart defaults instead.
                    System.Diagnostics.Debug.WriteLine(
                        "Offline chart saved settings could not be applied: " + ex.Message);
                }
            }
        }
    }
}
