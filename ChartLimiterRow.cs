using System;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// One independently configurable chart filter. The same editable layout is
    /// shared by the three followed axes and the ten optional measurements.
    /// Open ChartLimiterRow in the WinForms designer to change spacing for all rows.
    /// </summary>
    public partial class ChartLimiterRow : UserControl
    {
        public ChartLimiterRow()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckBox EnabledBox => filterEnabledCheckBox;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBox SelectionBox => selectionComboBox;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox MinimumBox => minimumTextBox;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox MaximumBox => maximumTextBox;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Button ResetButton => defaultsButton;

        [Category("Appearance")]
        [Description("The heading visible above the field selection.")]
        public string Title
        {
            get => axisLabel.Text;
            set => axisLabel.Text = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedField => selectionComboBox.SelectedItem as string;

        internal static ChartLimiterRow[] ConfigureRows(ChartLimiterRow[] rows, string prefix)
        {
            for (int i = 0; i < rows.Length; i++)
                rows[i].Configure(prefix + (i + 1).ToString("00", CultureInfo.InvariantCulture),
                    i < 3, rows[i].Title);
            return rows;
        }

        internal static bool TryBound(string text, bool minimum, out double value)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                value = minimum ? double.NegativeInfinity : double.PositiveInfinity;
                return true;
            }
            return (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                    double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value)) &&
                   !double.IsNaN(value);
        }

        internal bool TryGetBounds(out double minimum, out double maximum)
        {
            bool validMin = TryBound(MinimumBox.Text, true, out minimum);
            bool validMax = TryBound(MaximumBox.Text, false, out maximum);
            bool reversed = validMin && validMax && minimum > maximum;
            MinimumBox.BackColor = validMin && !reversed ? Color.FromArgb(42, 42, 42) : Color.FromArgb(110, 35, 35);
            MaximumBox.BackColor = validMax && !reversed ? Color.FromArgb(42, 42, 42) : Color.FromArgb(110, 35, 35);
            return validMin && validMax && !reversed;
        }

        public void Configure(string prefix, bool followsAxis, string description)
        {
            // JSON settings are keyed by child control names. These must be
            // distinct, even though all 13 rows share a designer template.
            filterEnabledCheckBox.Name = prefix + "Enabled";
            selectionComboBox.Name = prefix + "Selection";
            minimumTextBox.Name = prefix + "Minimum";
            maximumTextBox.Name = prefix + "Maximum";
            defaultsButton.Name = prefix + "Defaults";

            Title = description;
            selectionComboBox.Enabled = !followsAxis;
            selectionComboBox.TabStop = !followsAxis;
            selectionComboBox.DropDownStyle = followsAxis
                ? ComboBoxStyle.DropDownList
                : ComboBoxStyle.DropDown;
        }

        public void SetField(string field)
        {
            if (field == null) return;
            if (!selectionComboBox.Items.Contains(field))
            {
                string mapped = TelemetryNames.Canonicalize(field);
                if (selectionComboBox.Items.Contains(mapped)) field = mapped;
                else
                    foreach (string wheel in TelemetryNames.Wheels)
                    {
                        mapped = TelemetryNames.Canonicalize(field, wheel);
                        if (selectionComboBox.Items.Contains(mapped)) { field = mapped; break; }
                    }
            }
            if (selectionComboBox.Items.Contains(field))
                selectionComboBox.SelectedItem = field;
            else if (selectionComboBox.Items.Contains("None"))
                selectionComboBox.SelectedItem = "None";
        }
    }
}
