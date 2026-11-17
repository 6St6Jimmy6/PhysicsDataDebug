using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>Non-visual read/write adapter for the Designer-owned native filter controls.</summary>
    internal sealed class LogFilterBinding
    {
        private readonly Label filterTitleLabel;
        private readonly CheckBox enabledCheckBox;
        private readonly ComboBox fieldComboBox;
        private readonly ComboBox modeComboBox;
        private readonly CheckBox absoluteCheckBox;
        private readonly TextBox minimumTextBox;
        private readonly TextBox maximumTextBox;

        internal LogFilterBinding(Label heading, CheckBox enabled, ComboBox field,
            ComboBox mode, CheckBox absolute, TextBox minimum, TextBox maximum)
        {
            filterTitleLabel = heading;
            enabledCheckBox = enabled;
            fieldComboBox = field;
            modeComboBox = mode;
            absoluteCheckBox = absolute;
            minimumTextBox = minimum;
            maximumTextBox = maximum;
        }

        public string Heading { get => filterTitleLabel.Text; set => filterTitleLabel.Text = value; }

        internal void Configure(int position, System.Collections.Generic.IReadOnlyList<LogData.Column> fields)
        {
            Heading = "Filter " + (position + 1);
            fieldComboBox.Items.Clear();
            fieldComboBox.Items.Add("None");
            foreach (var field in fields) fieldComboBox.Items.Add(field.DisplayName);
            fieldComboBox.SelectedIndex = 0;
            fieldComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            fieldComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            fieldComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldComboBox.DropDownWidth = Math.Max(425, fieldComboBox.Width);
            modeComboBox.Items.Clear();
            modeComboBox.Items.Add("Inside range");
            modeComboBox.Items.Add("Outside range");
            modeComboBox.SelectedIndex = 0;
        }

        internal void FillFrom(LogRangeFilter setting)
        {
            enabledCheckBox.Checked = setting.Enabled;
            fieldComboBox.Text = fieldComboBox.Items.Contains(setting.Field) ? setting.Field : "None";
            modeComboBox.SelectedIndex = setting.Outside ? 1 : 0;
            absoluteCheckBox.Checked = setting.Absolute;
            minimumTextBox.Text = setting.Minimum.ToString("G17", CultureInfo.InvariantCulture);
            maximumTextBox.Text = setting.Maximum.ToString("G17", CultureInfo.InvariantCulture);
        }

        internal bool TryRead(out LogRangeFilter setting, out string error)
        {
            setting = new LogRangeFilter
            {
                Enabled = enabledCheckBox.Checked,
                Field = fieldComboBox.Text,
                Outside = modeComboBox.SelectedIndex == 1,
                Absolute = absoluteCheckBox.Checked
            };
            error = null;
            if (!setting.Enabled) return true;
            if (LogData.FindDisplay(setting.Field) == null)
            {
                error = Heading + ": choose a valid JSON telemetry field.";
                return false;
            }
            if (!Parse(minimumTextBox.Text, out double min) || !Parse(maximumTextBox.Text, out double max) || min > max)
            {
                error = Heading + ": enter valid Minimum and Maximum values (minimum <= maximum).";
                return false;
            }
            setting.Minimum = min;
            setting.Maximum = max;
            return true;
        }

        private static bool Parse(string text, out double value)
        {
            bool valid = double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
                double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
            return valid && !double.IsInfinity(value) && !double.IsNaN(value);
        }
    }
}
