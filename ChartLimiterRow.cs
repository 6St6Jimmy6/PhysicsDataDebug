using System;
using System.ComponentModel;
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

        public CheckBox EnabledBox => filterEnabledCheckBox;
        public ComboBox SelectionBox => selectionComboBox;
        public TextBox MinimumBox => minimumTextBox;
        public TextBox MaximumBox => maximumTextBox;
        public Button ResetButton => defaultsButton;

        [Category("Appearance")]
        [Description("The heading visible above the field selection.")]
        public string Title
        {
            get => axisLabel.Text;
            set => axisLabel.Text = value;
        }

        public string SelectedField => selectionComboBox.SelectedItem as string;

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
