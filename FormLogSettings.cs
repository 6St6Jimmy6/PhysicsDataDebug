using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLogSettings : Form
    {
        private bool updatingSelections;
        private LogFilterBinding[] rows;

        public FormLogSettings()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;

            rows = new[]
            {
                new LogFilterBinding(logFilter01Heading, logFilter01Enabled, logFilter01Field, logFilter01Mode,
                    logFilter01Absolute, logFilter01Minimum, logFilter01Maximum),
                new LogFilterBinding(logFilter02Heading, logFilter02Enabled, logFilter02Field, logFilter02Mode,
                    logFilter02Absolute, logFilter02Minimum, logFilter02Maximum),
                new LogFilterBinding(logFilter03Heading, logFilter03Enabled, logFilter03Field, logFilter03Mode,
                    logFilter03Absolute, logFilter03Minimum, logFilter03Maximum),
                new LogFilterBinding(logFilter04Heading, logFilter04Enabled, logFilter04Field, logFilter04Mode,
                    logFilter04Absolute, logFilter04Minimum, logFilter04Maximum),
                new LogFilterBinding(logFilter05Heading, logFilter05Enabled, logFilter05Field, logFilter05Mode,
                    logFilter05Absolute, logFilter05Minimum, logFilter05Maximum),
                new LogFilterBinding(logFilter06Heading, logFilter06Enabled, logFilter06Field, logFilter06Mode,
                    logFilter06Absolute, logFilter06Minimum, logFilter06Maximum),
                new LogFilterBinding(logFilter07Heading, logFilter07Enabled, logFilter07Field, logFilter07Mode,
                    logFilter07Absolute, logFilter07Minimum, logFilter07Maximum),
                new LogFilterBinding(logFilter08Heading, logFilter08Enabled, logFilter08Field, logFilter08Mode,
                    logFilter08Absolute, logFilter08Minimum, logFilter08Maximum),
                new LogFilterBinding(logFilter09Heading, logFilter09Enabled, logFilter09Field, logFilter09Mode,
                    logFilter09Absolute, logFilter09Minimum, logFilter09Maximum),
                new LogFilterBinding(logFilter10Heading, logFilter10Enabled, logFilter10Field, logFilter10Mode,
                    logFilter10Absolute, logFilter10Minimum, logFilter10Maximum),
            };
            IReadOnlyList<LogData.Column> columns = LogData.AllColumns;
            updatingSelections = true;
            checkedListBoxLogging.BeginUpdate();
            try
            {
                foreach (LogData.Column column in columns)
                {
                    int index = checkedListBoxLogging.Items.Add(column);
                    checkedListBoxLogging.SetItemChecked(index, LogSettings.IsEnabled(column.Key, column.Member));
                }
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Configure(i, columns);
                    rows[i].FillFrom(LogSettings.Filters[i]);
                }
                LogFolderTextBox.Text = LogSettings.LogFileSaveLocationFolder;
                DelimiterTextBox.Text = LogSettings.Delimiter.ToString();
                TimeLimitSecondsNumericUpDown.Value = Math.Min(TimeLimitSecondsNumericUpDown.Maximum,
                    Math.Max(0, LogSettings.TimeLimitSeconds));
                TotalSizeMiBNumericUpDown.Value = Math.Min(TotalSizeMiBNumericUpDown.Maximum,
                    Math.Max(0, (decimal)LogSettings.TotalSizeLimitBytes / 1048576m));
            }
            finally { checkedListBoxLogging.EndUpdate(); updatingSelections = false; }
            checkedListBoxLogging.ItemCheck += CheckedListBoxLogging_ItemCheck;
            UpdateSelectionCounter();
            JsonFormSettings.AttachProfileButton(this, () =>
            {
                updatingSelections = false;
                UpdateSelectionCounter();
                ApplyControlsToSettings(true);
            }, () => updatingSelections = true, () => updatingSelections = false);
        }

        public static void RestoreSavedModel()
        {
            using (var settings = new FormLogSettings())
            {
                settings.updatingSelections = true;
                try { JsonFormSettings.LoadAllSettings(settings); }
                finally { settings.updatingSelections = false; }
                settings.ApplyControlsToSettings(false);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LiveData.LogSettingsOpen = true;
            updatingSelections = true;
            try { JsonFormSettings.LoadAllSettings(this); }
            finally { updatingSelections = false; }
            UpdateSelectionCounter();
            ApplyControlsToSettings(false);
        }

        private void Settings_Closing(object sender, FormClosingEventArgs e)
        {
            // Keep invalid edits from replacing the currently valid configuration.
            if (ApplyControlsToSettings(true)) JsonFormSettings.SaveAllSettings(this);
            else e.Cancel = true;
        }

        private void Settings_Closed(object sender, FormClosedEventArgs e) => LiveData.LogSettingsOpen = false;

        private void ApplyLogSettings_Click(object sender, EventArgs e)
        {
            if (ApplyControlsToSettings(true)) JsonFormSettings.SaveAllSettings(this);
        }

        private bool ApplyControlsToSettings(bool showErrors)
        {
            string path = LogFolderTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(path) || path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                return Error("Choose a valid log output folder.", showErrors);
            string delimiter = DelimiterTextBox.Text;
            if (delimiter.Length != 1 || delimiter[0] == '\n' || delimiter[0] == '\r' || delimiter[0] == '"')
                return Error("Delimiter must be one character other than a quote or newline.", showErrors);

            var newFilters = new LogRangeFilter[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                if (!rows[i].TryRead(out newFilters[i], out string problem))
                    return Error(problem, showErrors);
            }

            var enabled = new List<string>();
            for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
                if (checkedListBoxLogging.GetItemChecked(i))
                    enabled.Add(((LogData.Column)checkedListBoxLogging.Items[i]).Key);
            if (enabled.Count == 0)
                return Error("Select at least one telemetry field.", showErrors);

            LogSettings.SetSelected(enabled);
            LogSettings.Filters = newFilters;
            LogSettings.Delimiter = delimiter[0];
            LogSettings.LogFileSaveLocationFolder = path;
            LogSettings.TimeLimitSeconds = decimal.ToInt32(TimeLimitSecondsNumericUpDown.Value);
            LogSettings.TotalSizeLimitBytes = decimal.ToInt64(TotalSizeMiBNumericUpDown.Value * 1048576m);
            return true;
        }

        private bool Error(string description, bool showErrors)
        {
            if (showErrors)
                MessageBox.Show(this, description, "Logging settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            return false;
        }

        private void BrowseLogFolderButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog
            {
                Description = "Choose folder for the combined telemetry log file",
                ShowNewFolderButton = true
            })
            {
                if (Directory.Exists(LogFolderTextBox.Text))
                    dialog.SelectedPath = LogFolderTextBox.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                    LogFolderTextBox.Text = dialog.SelectedPath;
            }
        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (updatingSelections) return;
            updatingSelections = true;
            try
            {
                for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
                    checkedListBoxLogging.SetItemChecked(i, selectAll.Checked);
            }
            finally { updatingSelections = false; }
            UpdateSelectionCounter();
        }

        private void CheckedListBoxLogging_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (updatingSelections) return;
            BeginInvoke(new Action(UpdateSelectionCounter));
        }

        private void UpdateSelectionCounter()
        {
            if (rows == null) return;
            int selected = checkedListBoxLogging.CheckedItems.Count;
            selectionCountLabel.Text = selected.ToString(CultureInfo.InvariantCulture) + " / " +
                checkedListBoxLogging.Items.Count.ToString(CultureInfo.InvariantCulture) + " selected";
            updatingSelections = true;
            try { selectAll.Checked = checkedListBoxLogging.Items.Count > 0 &&
                    selected == checkedListBoxLogging.Items.Count; }
            finally { updatingSelections = false; }
        }
    }
}
