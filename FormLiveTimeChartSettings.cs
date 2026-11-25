using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>Independent, designer-editable appearance settings for the live
    /// five-lane time chart. All controls use the normal JSON form settings.</summary>
    public partial class FormLiveTimeChartSettings : Form
    {
        internal readonly ComboBox[] ColorChoices;
        internal readonly CheckBox[] AutomaticY;
        internal readonly NumericUpDown[] MinimumY;
        internal readonly NumericUpDown[] MaximumY;

        public FormLiveTimeChartSettings()
        {
            InitializeComponent();
            ColorChoices = new[] { chartBackgroundCombo, plotBackgroundCombo,
                majorGridColorCombo, minorGridColorCombo, fontColorCombo,
                flColorCombo, frColorCombo, rlColorCombo, rrColorCombo, sharedColorCombo };
            AutomaticY = new[] { plot1AutoY, plot2AutoY, plot3AutoY, plot4AutoY, plot5AutoY };
            MinimumY = new[] { plot1YMin, plot2YMin, plot3YMin, plot4YMin, plot5YMin };
            MaximumY = new[] { plot1YMax, plot2YMax, plot3YMax, plot4YMax, plot5YMax };
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            fontNameCombo.Items.Clear(); // Designer includes a small preview list.
            fontNameCombo.Items.AddRange(FontFamily.Families.Select(f => (object)f.Name).ToArray());
            fontNameCombo.SelectedItem = "Arial";
            if (fontNameCombo.SelectedIndex < 0 && fontNameCombo.Items.Count > 0)
                fontNameCombo.SelectedIndex = 0;

            // Replace Designer swatch placeholders with the complete color palette.
            foreach (ComboBox combo in ColorChoices) combo.Items.Clear();
            ChartSettingsUi.AddColors(ColorChoices);
            foreach (ComboBox combo in ColorChoices)
            {
                combo.DrawMode = DrawMode.OwnerDrawFixed;
                combo.DrawItem += (sender, args) => ChartSettingsUi.DrawColor((ComboBox)sender, args);
            }
            Color[] defaults = { Color.FromArgb(28, 28, 28), Color.Black,
                Color.FromArgb(62, 62, 62), Color.FromArgb(42, 42, 42),
                Color.White, Color.LimeGreen, Color.DeepSkyBlue, Color.Gold,
                Color.MediumOrchid, Color.WhiteSmoke };
            for (int i = 0; i < ColorChoices.Length; i++)
                ChartSettingsUi.SelectColor(ColorChoices[i], defaults[i]);
            ComboBoxBehaviors.EnableSearch(this);
            JsonFormSettings.AttachProfileButton(this);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            foreach (ComboBox combo in ColorChoices)
            {
                string entered = combo.Text.Trim();
                if (entered.StartsWith("#", StringComparison.Ordinal) &&
                    !ChartSettingsUi.TryCommitHexColor(combo))
                {
                    MessageBox.Show(this, "Invalid hex color: " + entered +
                        "\nEnter #RRGGBB or #AARRGGBB.", "Invalid color",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo.Focus();
                    return;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (!AutomaticY[i].Checked && MinimumY[i].Value >= MaximumY[i].Value)
                {
                    MessageBox.Show(this, "Plot " + (i + 1) +
                        ": Y maximum must exceed Y minimum.", "Invalid axis range",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MinimumY[i].Focus();
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        internal TimeChartOptions ReadOptions()
        {
            var result = new TimeChartOptions();
            result.HistorySeconds = (double)historyLengthNumeric.Value *
                (historyUnitCombo.Text == "Minutes" ? 60 : 1);
            result.XAxisInMinutes = timeAxisUnitCombo.Text == "Minutes";
            result.UpdateIntervalMs = (int)updateIntervalNumeric.Value;
            result.MaxSamples = (int)maxSamplesNumeric.Value;
            result.LineWidth = (int)lineWidthNumeric.Value;
            result.MarkerSize = (int)markerSizeNumeric.Value;
            result.AxisFontSize = (float)axisFontSizeNumeric.Value;
            result.TitleFontSize = (float)titleFontSizeNumeric.Value;
            result.FontName = string.IsNullOrWhiteSpace(fontNameCombo.Text) ? "Arial" : fontNameCombo.Text;
            result.MajorGridWidth = (int)majorGridWidthNumeric.Value;
            result.MajorGrid = majorGridCheck.Checked;
            result.MinorGrid = minorGridCheck.Checked;
            result.Antialias = antialiasCheck.Checked;
            result.ShowYAxisTitle = yAxisTitleCheck.Checked;
            result.ChartType = plotStyleCombo.Text == "Spline" ? SeriesChartType.Spline :
                plotStyleCombo.Text == "Line" ? SeriesChartType.Line : SeriesChartType.FastLine;
            result.ChartBackground = ChartSettingsUi.ReadColor(chartBackgroundCombo);
            result.PlotBackground = ChartSettingsUi.ReadColor(plotBackgroundCombo);
            result.GridColor = ChartSettingsUi.ReadColor(majorGridColorCombo);
            result.MinorGridColor = ChartSettingsUi.ReadColor(minorGridColorCombo);
            result.FontColor = ChartSettingsUi.ReadColor(fontColorCombo);
            result.SharedColor = ChartSettingsUi.ReadColor(sharedColorCombo);
            ComboBox[] wheels = { flColorCombo, frColorCombo, rlColorCombo, rrColorCombo };
            for (int i = 0; i < 4; i++) result.WheelColors[i] = ChartSettingsUi.ReadColor(wheels[i]);
            for (int i = 0; i < 5; i++)
            {
                result.YAuto[i] = AutomaticY[i].Checked;
                result.YMin[i] = (double)MinimumY[i].Value;
                result.YMax[i] = (double)MaximumY[i].Value;
            }
            return result;
        }
    }

    internal sealed class TimeChartOptions
    {
        internal double HistorySeconds = 60;
        internal bool XAxisInMinutes;
        internal int UpdateIntervalMs = 50;
        internal int MaxSamples = 10000;
        internal int LineWidth = 2;
        internal int MarkerSize = 0;
        internal float AxisFontSize = 9f;
        internal float TitleFontSize = 10f;
        internal int MajorGridWidth = 1;
        internal bool MajorGrid = true;
        internal bool MinorGrid;
        internal bool Antialias = true;
        internal bool ShowYAxisTitle;
        internal string FontName = "Arial";
        internal SeriesChartType ChartType = SeriesChartType.FastLine;
        internal Color ChartBackground = Color.FromArgb(28, 28, 28);
        internal Color PlotBackground = Color.Black;
        internal Color GridColor = Color.FromArgb(62, 62, 62);
        internal Color MinorGridColor = Color.FromArgb(42, 42, 42);
        internal Color FontColor = Color.White;
        internal Color SharedColor = Color.WhiteSmoke;
        internal readonly Color[] WheelColors = {
            Color.LimeGreen, Color.DeepSkyBlue, Color.Gold, Color.MediumOrchid };
        internal readonly bool[] YAuto = { true, true, true, true, true };
        internal readonly double[] YMin = new double[5];
        internal readonly double[] YMax = { 10, 10, 10, 10, 10 };
    }
}
