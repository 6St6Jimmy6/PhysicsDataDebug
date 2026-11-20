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
        private readonly List<TreeNode> loggingLeaves = new List<TreeNode>();

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
            logFieldsTreeView.BeginUpdate();
            try
            {
                BuildLoggingHierarchy(columns);
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
            finally { logFieldsTreeView.EndUpdate(); updatingSelections = false; }
            ComboBoxBehaviors.EnableSearch(this);
            logFieldsTreeView.AfterCheck += LogFieldsTreeView_AfterCheck;
            UpdateSelectionCounter();
            JsonFormSettings.AttachProfileButton(this, () =>
            {
                updatingSelections = false;
                RefreshLoggingTree();
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
                settings.RefreshLoggingTree();
                settings.ApplyControlsToSettings(false);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LiveData.LogSettingsOpen = true;
            updatingSelections = true;
            try { JsonFormSettings.LoadAllSettings(this); }
            finally { updatingSelections = false; }
            RefreshLoggingTree();
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
            foreach (TreeNode leaf in loggingLeaves)
                if (leaf.Checked)
                    enabled.Add(((LogData.Column)leaf.Tag).Key);
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

        /// <summary>
        /// Category -> measurement -> FL/FR/RL/RR leaves. Shared fields
        /// have one leaf under their category rather than four duplicates.
        /// All leaves carry the canonical LogData.Column used by the logger.
        /// </summary>
        private void BuildLoggingHierarchy(IReadOnlyList<LogData.Column> columns)
        {
            loggingLeaves.Clear();
            logFieldsTreeView.Nodes.Clear();
            var categories = new Dictionary<string, TreeNode>(StringComparer.Ordinal);
            var measurements = new Dictionary<string, TreeNode>(StringComparer.Ordinal);

            foreach (LogData.Column column in columns)
            {
                if (!categories.TryGetValue(column.Group, out TreeNode category))
                {
                    string display = column.OldDisplay;
                    int divider = display.IndexOf(" / ", StringComparison.Ordinal);
                    if (divider >= 0) display = display.Substring(0, divider);
                    category = new TreeNode(display) { Tag = display };
                    logFieldsTreeView.Nodes.Add(category);
                    categories.Add(column.Group, category);
                }

                TreeNode container = category;
                if (column.Wheel != null)
                {
                    string key = column.Group + "." + column.Member;
                    if (!measurements.TryGetValue(key, out container))
                    {
                        string name = column.Header.Substring(column.Wheel.Length + 1);
                        container = new TreeNode(name) { Tag = name };
                        category.Nodes.Add(container);
                        measurements.Add(key, container);
                    }
                }

                var leaf = new TreeNode(column.Header)
                {
                    Tag = column,
                    Checked = LogSettings.IsEnabled(column.Key, column.Member)
                };
                container.Nodes.Add(leaf);
                loggingLeaves.Add(leaf);
            }

            // Show measurements immediately, but keep their four wheel
            // children collapsed until the user wants to edit individual wheels.
            foreach (TreeNode category in logFieldsTreeView.Nodes)
                category.Expand();
            RefreshLoggingTree();
        }

        private void LogFieldsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (updatingSelections) return;
            updatingSelections = true;
            logFieldsTreeView.BeginUpdate();
            try
            {
                // A parent click means select/deselect the whole subtree.
                // A leaf click changes ONLY that wheel, never its siblings.
                if (!(e.Node.Tag is LogData.Column))
                    SetDescendantChecked(e.Node, e.Node.Checked);
                RefreshLoggingTreeCore();
            }
            finally
            {
                logFieldsTreeView.EndUpdate();
                updatingSelections = false;
            }
        }

        private static void SetDescendantChecked(TreeNode node, bool value)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = value;
                SetDescendantChecked(child, value);
            }
        }

        private void RefreshLoggingTree()
        {
            bool previous = updatingSelections;
            updatingSelections = true;
            logFieldsTreeView.BeginUpdate();
            try { RefreshLoggingTreeCore(); }
            finally
            {
                logFieldsTreeView.EndUpdate();
                updatingSelections = previous;
            }
        }

        private void RefreshLoggingTreeCore()
        {
            foreach (TreeNode category in logFieldsTreeView.Nodes)
                RefreshParent(category);
            UpdateSelectionCounter();
        }

        // Returns (selected leaf count, total leaf count). Parent checkboxes
        // are checked only when all their descendants are selected; partial
        // selections stay visible as (3/4), without affecting the other wheels.
        private static (int Selected, int Total) RefreshParent(TreeNode node)
        {
            if (node.Tag is LogData.Column)
                return (node.Checked ? 1 : 0, 1);

            int selected = 0;
            int total = 0;
            foreach (TreeNode child in node.Nodes)
            {
                var counts = RefreshParent(child);
                selected += counts.Selected;
                total += counts.Total;
            }
            node.Checked = total > 0 && selected == total;
            string label = node.Tag as string ?? node.Text;
            // Counts clarify partial selections at both group and category levels.
            node.Text = label + " (" + selected.ToString(CultureInfo.InvariantCulture) +
                "/" + total.ToString(CultureInfo.InvariantCulture) + ")";
            return (selected, total);
        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (updatingSelections) return;
            updatingSelections = true;
            logFieldsTreeView.BeginUpdate();
            try
            {
                foreach (TreeNode leaf in loggingLeaves)
                    leaf.Checked = selectAll.Checked;
                RefreshLoggingTreeCore();
            }
            finally { logFieldsTreeView.EndUpdate(); updatingSelections = false; }
        }

        private void UpdateSelectionCounter()
        {
            if (rows == null) return;
            int selected = loggingLeaves.Count(leaf => leaf.Checked);
            selectionCountLabel.Text = selected.ToString(CultureInfo.InvariantCulture) + " / " +
                loggingLeaves.Count.ToString(CultureInfo.InvariantCulture) + " selected";
            bool previous = updatingSelections;
            updatingSelections = true;
            try { selectAll.Checked = loggingLeaves.Count > 0 && selected == loggingLeaves.Count; }
            finally { updatingSelections = previous; }
        }
    }
}
