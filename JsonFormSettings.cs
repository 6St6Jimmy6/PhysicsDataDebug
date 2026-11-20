using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Per-form JSON autosaves and user-selected, editable JSON profiles.
    /// The registry is only READ once to import settings from older releases.
    /// All new settings are saved to JSON under the user's AppData folder.
    /// </summary>
    internal static class JsonFormSettings
    {
        private const int SchemaVersion = 1;
        private const string FactoryProfileFileName = "Factory Defaults.json";
        // A legacy G-Force font list silently selected its first installed font.
        // Versioned G-Force captures distinguish that old accidental default
        // from an intentionally saved custom selection in newer profiles.
        private const string GForceFontSelectionVersionKey = "__GForceFontSelectionVersion";
        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
        // Prevent forms from saving their old in-memory controls after a reset.
        private static bool suppressAutosavesUntilRestart;
        private static readonly string RegistryImportDisabledFile = Path.Combine(
            DirectoryPath, ".legacy-registry-import-disabled");

        public static string DirectoryPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "PhysicsDataDebug", "Settings");

        internal sealed class FormSnapshot
        {
            public FormSnapshot() { }
            public int SchemaVersion { get; set; } = 1;
            public string FormName { get; set; }
            public int? Left { get; set; }
            public int? Top { get; set; }
            public int? Width { get; set; }
            public int? Height { get; set; }
            public string WindowState { get; set; }
            public Dictionary<string, string> Controls { get; set; } =
                new Dictionary<string, string>(StringComparer.Ordinal);
        }

        private static string FileFor(Form form) =>
            Path.Combine(DirectoryPath, form.Name + ".json");

        private static string ProfilesFor(Form form) =>
            Path.Combine(DirectoryPath, "Profiles", form.Name);

        private static string FactoryProfileFor(string formName) =>
            Path.Combine(DirectoryPath, "Profiles", formName, FactoryProfileFileName);

        private static JavaScriptSerializer Serializer() => new JavaScriptSerializer
        {
            MaxJsonLength = int.MaxValue
        };

        public static void SaveAllSettings(Form form)
        {
            if (suppressAutosavesUntilRestart) return;
            try { WriteFile(FileFor(form), Capture(form)); }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("save", FileFor(form), ex); }
        }

        public static void LoadAllSettings(Form form)
        {
            if (suppressAutosavesUntilRestart) return;
            string path = FileFor(form);
            try
            {
                if (!File.Exists(path) && !File.Exists(RegistryImportDisabledFile))
                    ImportLegacyRegistryOnce(form, path);
                if (File.Exists(path)) Apply(form, ReadFile(path, form.Name));
            }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("load", path, ex); }
        }

        /// <summary>
        /// Create the baseline profile from an initialized form, before saved
        /// settings can modify it. Never overwrite a user's existing baseline.
        /// </summary>
        public static void EnsureFactoryDefaults(Form form)
        {
            if (suppressAutosavesUntilRestart) return;
            string path = FactoryProfileFor(form.Name);
            if (File.Exists(path)) return;
            try { WriteFile(path, Capture(form)); }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("create factory defaults", path, ex); }
        }

        /// <summary>
        /// Capture a settings form on first launch. Do not use for chart forms:
        /// their Chart controls require a displayed window with valid dimensions.
        /// Form4Wheels and FormOfflineChart capture defaults from real instances.
        /// </summary>
        public static void EnsureFactoryDefaults<T>() where T : Form, new()
        {
            // Never construct WinForms Chart windows in the startup/defaults path.
            // These create their profiles when they are actually opened.
            if (typeof(T) == typeof(Form4Wheels) ||
                typeof(T) == typeof(FormOfflineChart)) return;
            if (suppressAutosavesUntilRestart || File.Exists(FactoryProfileFor(typeof(T).Name))) return;
            using (var form = new T()) EnsureFactoryDefaults(form);
        }

        /// <summary>Add an unobtrusive Profiles button without changing Designer files.</summary>
        public static void AttachProfileButton(Form form, Action afterLoad = null,
            Action beforeLoad = null, Action finallyLoad = null)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Save profile as...", null, (sender, args) => SaveProfileAs(form));
            menu.Items.Add("Load profile...", null, (sender, args) =>
                LoadProfile(form, afterLoad, beforeLoad, finallyLoad));
            menu.Items.Add("Restore factory defaults", null, (sender, args) =>
                RestoreFactoryDefaults(form, afterLoad, beforeLoad, finallyLoad));
            menu.Items.Add("Restore previous autosave (.bak)", null, (sender, args) =>
                RestoreAutosaveBackup(form, afterLoad, beforeLoad, finallyLoad));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Reset this form's settings and profiles...", null, (sender, args) =>
                ResetSettings(form, false));
            menu.Items.Add("Reset ALL form settings and profiles...", null, (sender, args) =>
                ResetSettings(form, true));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Open settings folder", null, (sender, args) => OpenSettingsFolder());

            // Put the command beside the Settings dialogs' existing primary
            // button. Their designer sizes exceed some screens, so a control
            // anchored to the far right may otherwise start off-screen.
            Point buttonPosition;
            var profileHost = form.Controls.Find("SettingsProfilesHost", true).FirstOrDefault();
            // Settings panels that formerly held a Close button still provide a
            // reliable, Designer-owned place for Profiles after Close is removed.
            var settingsSidebar = form.Controls.Find("settingsSidebarPanel", true).FirstOrDefault();
            var apply = form.Controls.Find("FLApplyLogSettings", true).FirstOrDefault();
            var buttonHost = profileHost ?? settingsSidebar ?? apply?.Parent ?? (Control)form;
            if (profileHost != null || settingsSidebar != null)
                buttonPosition = new Point(1, 4);
            else if (apply != null)
                buttonPosition = new Point(apply.Right + 10, Math.Max(4, apply.Top - 10));
            else
                buttonPosition = new Point(Math.Max(4, buttonHost.ClientSize.Width - 120), 5);

            var button = new Button
            {
                Name = "SettingsProfilesButton",
                Text = "Profiles ▼",
                Width = 112,
                Height = 28,
                Location = buttonPosition,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                TabStop = false,
                ContextMenuStrip = menu
            };
            button.Click += (sender, args) => menu.Show(button, 0, button.Height);
            buttonHost.Controls.Add(button);
            // Keep Profiles visible inside the Designer-owned Four Wheels settings action bar.
            if (profileHost != null && (form is Form4WheelsSettings ||
                form is FormGForceSettings || form is FormOfflineChartSettings ||
                form is FormLogSettings))
            {
                button.Dock = DockStyle.Fill;
                button.Location = Point.Empty;
            }
            // Live Data uses a dark sidebar; match its other action buttons.
            // Keep the normal Windows styling for light-theme settings forms.
            if (form is FormLiveData || form is Form4WheelsSettings ||
                form is FormOfflineChartSettings || form is FormGForceSettings || form is FormLogSettings ||
                form is Form4Wheels ||
                form is FormOfflineChart)
            {
                button.UseVisualStyleBackColor = false;
                button.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
                button.ForeColor = System.Drawing.Color.White;
            }
            button.BringToFront();
            // Available even when a large, scrollable form has the button
            // outside the currently visible region.
            form.KeyPreview = true;
            form.KeyDown += (sender, args) =>
            {
                if (args.Control && args.Shift && args.KeyCode == Keys.P)
                {
                    menu.Show(form, new Point(20, 35));
                    args.Handled = true;
                    args.SuppressKeyPress = true;
                }
            };
            form.Disposed += (sender, args) => menu.Dispose();
        }

        private static void SaveProfileAs(Form form)
        {
            try
            {
                string directory = ProfilesFor(form);
                Directory.CreateDirectory(directory);
                using (var dialog = new System.Windows.Forms.SaveFileDialog
                {
                    Title = "Save " + form.Text + " settings profile",
                    Filter = "JSON settings (*.json)|*.json",
                    InitialDirectory = directory,
                    FileName = "My Profile.json",
                    DefaultExt = "json",
                    AddExtension = true,
                    OverwritePrompt = true
                })
                {
                    if (dialog.ShowDialog(form) == DialogResult.OK)
                        WriteFile(dialog.FileName, Capture(form));
                }
            }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("save profile", ProfilesFor(form), ex); }
        }

        private static void LoadProfile(Form form, Action afterLoad,
            Action beforeLoad, Action finallyLoad)
        {
            string directory = ProfilesFor(form);
            try
            {
                Directory.CreateDirectory(directory);
                using (var dialog = new System.Windows.Forms.OpenFileDialog
                {
                    Title = "Load " + form.Text + " settings profile",
                    Filter = "JSON settings (*.json)|*.json",
                    InitialDirectory = directory,
                    CheckFileExists = true
                })
                {
                    if (dialog.ShowDialog(form) != DialogResult.OK) return;
                    ApplyProfileFile(form, dialog.FileName, afterLoad, beforeLoad, finallyLoad);
                }
            }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("load profile", directory, ex); }
        }

        private static void RestoreFactoryDefaults(Form form, Action afterLoad,
            Action beforeLoad, Action finallyLoad)
        {
            string path = FactoryProfileFor(form.Name);
            if (!File.Exists(path))
            {
                MessageBox.Show("The factory profile is missing. Restart the app to regenerate it:\n" + path,
                    "Settings profiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try { ApplyProfileFile(form, path, afterLoad, beforeLoad, finallyLoad); }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("restore defaults", path, ex); }
        }

        private static void ApplyProfileFile(Form form, string path, Action afterLoad,
            Action beforeLoad, Action finallyLoad)
        {
            FormSnapshot state = ReadFile(path, form.Name);
            beforeLoad?.Invoke();
            try
            {
                Apply(form, state);
                afterLoad?.Invoke();
            }
            finally { finallyLoad?.Invoke(); }
            // Loading any profile also makes it the form's active autosave.
            SaveAllSettings(form);
        }

        /// <summary>
        /// Archive JSON preferences rather than deleting them. The currently
        /// running controls must not overwrite the reset on FormClosing.
        /// Game-memory configuration files are intentionally not touched.
        /// </summary>
        private static void ResetSettings(Form owner, bool allForms)
        {
            string scope = allForms ? "all forms" : owner.Name;
            if (MessageBox.Show(owner,
                    "Archive and reset settings and named profiles for " + scope + "?\n\n" +
                    "Game-memory configuration files will be preserved.\n" +
                    "Restart the application after resetting. All current windows will keep" +
                    " their displayed settings until then.",
                    "Reset JSON settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;
            try
            {
                Directory.CreateDirectory(DirectoryPath);
                string archive = Path.Combine(DirectoryPath, "ResetBackups",
                    DateTime.UtcNow.ToString("yyyyMMdd_HHmmssfff", Culture));
                Directory.CreateDirectory(archive);
                // Migration must stay disabled after a factory reset, otherwise
                // missing JSON files could silently import old registry values.
                File.WriteAllText(RegistryImportDisabledFile,
                    "Do not reimport obsolete registry settings after JSON reset.");
                suppressAutosavesUntilRestart = true;
                if (allForms)
                {
                    foreach (string path in Directory.GetFiles(DirectoryPath, "Form*.json"))
                        ArchiveFile(path, archive);
                    foreach (string path in Directory.GetFiles(DirectoryPath, "Form*.json.bak"))
                        ArchiveFile(path, archive);
                    string profiles = Path.Combine(DirectoryPath, "Profiles");
                    if (Directory.Exists(profiles))
                        Directory.Move(profiles, Path.Combine(archive, "Profiles"));
                }
                else
                {
                    string path = FileFor(owner);
                    ArchiveFile(path, archive);
                    ArchiveFile(path + ".bak", archive);
                    string profiles = ProfilesFor(owner);
                    if (Directory.Exists(profiles))
                    {
                        string destination = Path.Combine(archive, "Profiles", owner.Name);
                        Directory.CreateDirectory(Path.GetDirectoryName(destination));
                        Directory.Move(profiles, destination);
                    }
                }
                MessageBox.Show(owner,
                    "Settings archived to:\n" + archive + "\n\n" +
                    "Close the application and launch it again to use fresh defaults.\n" +
                    "The original JSON profiles can be recovered from the backup folder.",
                    "Settings reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (IsFileError(ex))
            {
                ShowError("reset", DirectoryPath, ex);
            }
        }

        private static void ArchiveFile(string source, string destinationDirectory)
        {
            if (!File.Exists(source)) return;
            Directory.CreateDirectory(destinationDirectory);
            File.Move(source, Path.Combine(destinationDirectory, Path.GetFileName(source)));
        }

        private static void RestoreAutosaveBackup(Form form, Action afterLoad,
            Action beforeLoad, Action finallyLoad)
        {
            string path = FileFor(form) + ".bak";
            if (!File.Exists(path))
            {
                MessageBox.Show(form, "No previous autosave backup exists for this form.",
                    "Settings profiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try { ApplyProfileFile(form, path, afterLoad, beforeLoad, finallyLoad); }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("restore backup", path, ex); }
        }

        private static void OpenSettingsFolder()
        {
            try
            {
                Directory.CreateDirectory(DirectoryPath);
                Process.Start("explorer.exe", DirectoryPath);
            }
            catch (Exception ex) when (IsFileError(ex)) { ShowError("open folder", DirectoryPath, ex); }
        }

        private static FormSnapshot NewSnapshot(Form form) =>
            new FormSnapshot { FormName = form.Name };

        private static FormSnapshot Capture(Form form)
        {
            FormSnapshot state = NewSnapshot(form);
            Rectangle bounds = form.WindowState == FormWindowState.Normal
                ? form.Bounds : form.RestoreBounds;
            state.Left = bounds.Left;
            state.Top = bounds.Top;
            state.Width = bounds.Width;
            state.Height = bounds.Height;
            state.WindowState = form.WindowState == FormWindowState.Maximized ? "Maximized" : "Normal";
            if (form.Name == "FormLiveData")
            {
                // Everything else on the main window is live telemetry output.
                var version = form.Controls.Find("GameVersionComboBox", true)
                    .OfType<ComboBox>().FirstOrDefault();
                var interval = form.Controls.Find("logInterval_textBox", true)
                    .OfType<TextBox>().FirstOrDefault();
                if (version != null) state.Controls[version.Name] = ComboSelection(version);
                if (interval != null) state.Controls[interval.Name] = interval.Text;
            }
            else CaptureChildren(form, state.Controls);
            if (form is FormGForceSettings)
                state.Controls[GForceFontSelectionVersionKey] = "1";
            return state;
        }

        // Only walk actual UI layout containers. Composite input controls such as
        // NumericUpDown contain implementation-owned child text boxes; those are
        // NOT independently saved settings. Recursing into them can overwrite
        // every numeric input with the same internally named editor text.
        private static bool IsSettingsContainer(Control control) =>
            control is Panel || control is GroupBox || control is TabControl ||
            control is SplitContainer || control is UserControl ||
            control is ToolStripContainer;

        private static void CaptureChildren(Control parent, IDictionary<string, string> values)
        {
            foreach (Control child in parent.Controls)
            {
                // Ignore unnamed implementation-owned children, but still walk
                // unnamed layout containers if they contain named settings.
                if (string.IsNullOrEmpty(child.Name))
                {
                    if (IsSettingsContainer(child)) CaptureChildren(child, values);
                    continue;
                }
                if (child is CheckedListBox checks)
                {
                    for (int i = 0; i < checks.Items.Count; i++)
                        // Save by field name: adding/reordering telemetry fields
                        // must not silently change which ones are enabled.
                        values[CheckedItemKey(checks, i)] =
                            checks.GetItemChecked(i) ? "true" : "false";
                }
                else if (child is TreeView logTree && child.Name == "logFieldsTreeView")
                {
                    // Persist only actual telemetry leaves, by stable internal
                    // field key. Category/measurement parent checks are derived.
                    foreach (TreeNode leaf in LoggingFieldNodes(logTree.Nodes))
                    {
                        var column = (LogData.Column)leaf.Tag;
                        values[logTree.Name + ".Fields." + column.Key] =
                            leaf.Checked ? "true" : "false";
                    }
                }
                else if (child is ComboBox combo) values[child.Name] = ComboSelection(combo);
                else if (child is CheckBox check) values[child.Name] = check.Checked ? "true" : "false";
                else if (child is RadioButton radio) values[child.Name] = radio.Checked ? "true" : "false";
                else if (child is NumericUpDown numeric)
                    values[child.Name] = numeric.Value.ToString(Culture);
                else if (child is ScrollBar scroll)
                    values[child.Name] = scroll.Value.ToString(Culture);
                else if (child is TrackBar track)
                    values[child.Name] = track.Value.ToString(Culture);
                else if (child is TextBoxBase text) values[child.Name] = text.Text;
                else if (child is ListBox list) values[child.Name] = list.Text;

                if (IsSettingsContainer(child)) CaptureChildren(child, values);
            }
        }

        private static void Apply(Form form, FormSnapshot state)
        {
            if (state.Left.HasValue && state.Top.HasValue &&
                state.Width.GetValueOrDefault() > 100 && state.Height.GetValueOrDefault() > 100)
            {
                var bounds = new Rectangle(state.Left.Value, state.Top.Value,
                    state.Width.Value, state.Height.Value);
                // Do not restore a window outside the available monitors.
                if (Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(bounds)))
                    form.SetBounds(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
            }
            // Older G-Force autosaves could record "Agency FB" just because it
            // was the first font in the bound list, even if Defaults was OFF.
            // Convert only that legacy value; any other saved font survives.
            // New profiles include a version marker, so an intentional Agency FB
            // selection made after this fix is preserved too.
            if (form is FormGForceSettings &&
                !state.Controls.ContainsKey(GForceFontSelectionVersionKey))
            {
                RestoreLegacyGForceFont(state.Controls, "X1ComboBoxFonts");
                RestoreLegacyGForceFont(state.Controls, "Y1ComboBoxFonts");
            }
            ApplyChildren(form, state.Controls);
            if (state.WindowState == "Maximized") form.WindowState = FormWindowState.Maximized;
        }

        private static void RestoreLegacyGForceFont(IDictionary<string, string> values, string controlName)
        {
            if (!values.TryGetValue(controlName, out string saved) || saved == null) return;
            if (string.Equals(saved.Trim(), "Agency FB", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(saved.Trim(), "AgencyFB", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(saved.Trim(), "[FontFamily: Name=Agency FB]", StringComparison.OrdinalIgnoreCase))
                values[controlName] = "Arial";
        }

        private static void ApplyChildren(Control parent, IDictionary<string, string> values)
        {
            foreach (Control child in parent.Controls)
            {
                if (string.IsNullOrEmpty(child.Name))
                {
                    if (IsSettingsContainer(child)) ApplyChildren(child, values);
                    continue;
                }
                if (child is CheckedListBox checks)
                {
                    for (int i = 0; i < checks.Items.Count; i++)
                    {
                        // Older registry and early JSON autosaves used indexes.
                        // Continue to read those, but prefer stable named keys.
                        string text;
                        bool hasValue = values.TryGetValue(CheckedItemKey(checks, i), out text);
                        // Migration: the original four-file logger saved one
                        // selection per raw field. Apply that former choice to
                        // all four corresponding wheel columns in the new logger.
                        if (!hasValue && checks.Items[i] is LogData.Column logColumn)
                            hasValue = values.TryGetValue(child.Name + ".Items." + logColumn.OldDisplay, out text);
                        if (!hasValue)
                            hasValue = values.TryGetValue(child.Name + "[" + i.ToString(Culture) + "]", out text);
                        if (hasValue && TryBool(text, out bool selected))
                            checks.SetItemChecked(i, selected);
                    }
                }
                else if (child is TreeView logTree && child.Name == "logFieldsTreeView")
                {
                    int oldIndex = 0;
                    foreach (TreeNode leaf in LoggingFieldNodes(logTree.Nodes))
                    {
                        var column = (LogData.Column)leaf.Tag;
                        string text;
                        // Current schema saves by stable group/member/wheel.
                        bool found = values.TryGetValue(logTree.Name + ".Fields." + column.Key, out text);
                        // Legacy flat CheckedListBox profiles saved a public
                        // header or, before that, source-group / field labels.
                        if (!found)
                            found = values.TryGetValue("checkedListBoxLogging.Items." + column.Header, out text);
                        if (!found)
                            found = values.TryGetValue("checkedListBoxLogging.Items." + column.OldDisplay, out text);
                        if (!found)
                            found = values.TryGetValue("checkedListBoxLogging[" +
                                oldIndex.ToString(Culture) + "]", out text);
                        if (found && TryBool(text, out bool check)) leaf.Checked = check;
                        oldIndex++;
                    }
                    // FormLogSettings refreshes the parent states after loading.
                }
                else if (values.TryGetValue(child.Name, out string saved))
                {
                    if (child is ComboBox combo) RestoreComboBox(combo, saved);
                    else if (child is CheckBox check && TryBool(saved, out bool selected)) check.Checked = selected;
                    else if (child is RadioButton radio && TryBool(saved, out bool selectedRadio)) radio.Checked = selectedRadio;
                    else if (child is NumericUpDown number && TryDecimal(saved, out decimal value))
                        number.Value = Math.Max(number.Minimum, Math.Min(number.Maximum, value));
                    else if (child is ScrollBar scroll && int.TryParse(saved, NumberStyles.Integer, Culture, out int n))
                        scroll.Value = Math.Max(scroll.Minimum, Math.Min(scroll.Maximum - scroll.LargeChange + 1, n));
                    else if (child is TrackBar track && int.TryParse(saved, NumberStyles.Integer, Culture, out int t))
                        track.Value = Math.Max(track.Minimum, Math.Min(track.Maximum, t));
                    else if (child is TextBoxBase text) text.Text = saved;
                    else if (child is ListBox list) list.Text = saved;
                }
                if (IsSettingsContainer(child)) ApplyChildren(child, values);
            }
        }

        // Iterate only concrete telemetry leaves, in the same order as the
        // previous flat list for migration of old index-based profiles.
        private static IEnumerable<TreeNode> LoggingFieldNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is LogData.Column) yield return node;
                foreach (TreeNode leaf in LoggingFieldNodes(node.Nodes)) yield return leaf;
            }
        }

        private static string ComboSelection(ComboBox combo) =>
            combo.SelectedItem is GameVersionProfile version ? version.Id :
            combo.SelectedItem != null ? combo.GetItemText(combo.SelectedItem) : combo.Text;

        private static string CheckedItemKey(CheckedListBox list, int index) =>
            list.Name + ".Items." + list.GetItemText(list.Items[index]);

        private static void RestoreComboBox(ComboBox combo, string saved)
        {
            // Upgrade saved filter choices from the original four-file logger.
            if (combo.Name.StartsWith("logFilter", StringComparison.Ordinal) &&
                combo.Name.EndsWith("Field", StringComparison.Ordinal))
            {
                var canonicalField = LogData.FindDisplay(saved);
                if (canonicalField != null) saved = canonicalField.DisplayName;
            }
            // Both Four Wheels and Offline Chart choose a measurement, while
            // their dataset layout decides which prefixed wheel columns to read.
            bool fourWheelsAxis = combo.FindForm() is Form4WheelsSettings &&
                (combo.Name == "X1SelectionComboBox" ||
                 combo.Name == "Y1SelectionComboBox" ||
                 combo.Name == "Z1SelectionComboBox");
            bool fourWheelsFilter = combo.Name.StartsWith("ChartFilter", StringComparison.Ordinal) &&
                combo.Name.EndsWith("Selection", StringComparison.Ordinal);
            if (fourWheelsAxis || fourWheelsFilter)
                saved = FourWheelsFieldSelection.MatchAvailable(saved,
                    combo.Items.Cast<object>().Select(combo.GetItemText));
            bool offlineAxisOrFilter = combo.FindForm() is FormOfflineChartSettings &&
                (combo.Name == "xColumnComboBox" || combo.Name == "yColumnComboBox" ||
                 combo.Name == "zColumnComboBox") ||
                (combo.Name.StartsWith("OfflineFilter", StringComparison.Ordinal) &&
                 combo.Name.EndsWith("Selection", StringComparison.Ordinal));
            if (offlineAxisOrFilter)
                saved = FormOfflineChart.CanonicalAvailableField(saved,
                    combo.Items.Cast<object>().Select(combo.GetItemText)) ?? saved;

            // Previously saved chart axes/filters may still use old raw
            // telemetry members. Restore a supported item, never add a
            // duplicate legacy choice to the dropdown.
            bool telemetryField = combo.Name == "X1SelectionComboBox" ||
                combo.Name == "Y1SelectionComboBox" ||
                combo.Name == "Z1SelectionComboBox" ||
                combo.Name == "xColumnComboBox" ||
                combo.Name == "yColumnComboBox" ||
                combo.Name == "zColumnComboBox" ||
                combo.Name == "selectionComboBox" ||
                ((combo.Name.StartsWith("ChartFilter", StringComparison.Ordinal) ||
                  combo.Name.StartsWith("OfflineFilter", StringComparison.Ordinal)) &&
                 combo.Name.EndsWith("Selection", StringComparison.Ordinal)) ||
                (combo.Name.StartsWith("logFilter", StringComparison.Ordinal) &&
                 combo.Name.EndsWith("Field", StringComparison.Ordinal));
            if (telemetryField && !combo.Items.Contains(saved))
            {
                string canonical = TelemetryNames.Canonicalize(saved);
                if (combo.Items.Contains(canonical)) saved = canonical;
                else
                    foreach (string wheel in TelemetryNames.Wheels)
                    {
                        canonical = TelemetryNames.Canonicalize(saved, wheel);
                        if (combo.Items.Contains(canonical)) { saved = canonical; break; }
                    }
            }
            // Old "Default" palette is now displayed as "Blue Red".
            if ((combo.Name == "SchemeComboBox" || combo.Name == "schemeComboBox") &&
                string.Equals(saved, "Default", StringComparison.OrdinalIgnoreCase) &&
                combo.Items.Contains("Blue Red"))
                saved = "Blue Red";
            // Older saved form profiles contain the mistyped 1.30 build ID.
            if (combo.Name == "GameVersionComboBox" && saved == "V1_308408")
                saved = "V1_308438";
            for (int i = 0; i < combo.Items.Count; i++)
            {
                object item = combo.Items[i];
                if (string.Equals(saved, combo.GetItemText(item), StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(saved, Convert.ToString(item, Culture), StringComparison.OrdinalIgnoreCase) ||
                    (item is GameVersionProfile version && string.Equals(saved, version.Id, StringComparison.OrdinalIgnoreCase)))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
            // Leave a valid existing selection alone if an item no longer exists.
        }

        private static bool TryBool(string text, out bool result)
        {
            if (bool.TryParse(text, out result)) return true;
            if (text == "1" || text == "0") { result = text == "1"; return true; }
            return false;
        }

        private static bool TryDecimal(string text, out decimal result) =>
            decimal.TryParse(text, NumberStyles.Number, Culture, out result) ||
            decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out result);

        private static FormSnapshot ReadFile(string path, string expectedForm)
        {
            var state = Serializer().Deserialize<FormSnapshot>(File.ReadAllText(path));
            if (state == null || state.SchemaVersion != SchemaVersion ||
                !string.Equals(state.FormName, expectedForm, StringComparison.Ordinal) ||
                state.Controls == null)
                throw new FormatException("This file is not a compatible profile for " + expectedForm + ".");
            return state;
        }

        private static void WriteFile(string path, FormSnapshot state)
        {
            string directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);
            string temp = Path.Combine(directory, Path.GetFileName(path) + "." + Guid.NewGuid().ToString("N") + ".tmp");
            try
            {
                string json = PrettyPrint(Serializer().Serialize(state));
                File.WriteAllText(temp, json + Environment.NewLine, new UTF8Encoding(false));
                if (File.Exists(path)) File.Replace(temp, path, path + ".bak");
                else File.Move(temp, path);
            }
            finally { if (File.Exists(temp)) File.Delete(temp); }
        }

        private static string PrettyPrint(string json)
        {
            var output = new StringBuilder(json.Length + json.Length / 3);
            bool quoted = false, escaped = false;
            int indent = 0;
            foreach (char ch in json)
            {
                if (ch == '\\' && quoted && !escaped) { output.Append(ch); escaped = true; continue; }
                if (ch == '"' && !escaped) quoted = !quoted;
                escaped = false;
                if (quoted || ch == '"') { output.Append(ch); continue; }
                switch (ch)
                {
                    case '{': case '[':
                        output.Append(ch); output.AppendLine(); indent++; AddIndent(output, indent); break;
                    case '}': case ']':
                        output.AppendLine(); indent--; AddIndent(output, indent); output.Append(ch); break;
                    case ',':
                        output.Append(ch); output.AppendLine(); AddIndent(output, indent); break;
                    case ':': output.Append(": "); break;
                    default: output.Append(ch); break;
                }
            }
            return output.ToString();
        }

        private static void AddIndent(StringBuilder builder, int depth) =>
            builder.Append(' ', depth * 2);

        private static bool IsFileError(Exception ex) =>
            ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException ||
            ex is InvalidOperationException || ex is FormatException || ex is System.Security.SecurityException;

        private static void ShowError(string action, string path, Exception ex) =>
            MessageBox.Show("Could not " + action + " settings at:\n" + path + "\n\n" + ex.Message,
                "Settings profiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ImportLegacyRegistryOnce(Form form, string jsonPath)
        {
            // Import once, read-only. We never write to or delete old registry keys.
            try
            {
                string app = Application.ProductName;
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\" + app + @"\Forms\" + form.Name);
                if (key == null)
                {
                    string signature = null;
                    switch (form.Name)
                    {
                        case "Form4WheelsSettings": signature = "WheelChartsSelectComboBox"; break;
                        case "FormGForceSettings": signature = "X1AngleTypeComboBox"; break;
                        case "FormLogSettings": signature = "DelimiterTextBox"; break;
                        case "FormLiveData": signature = "GameVersionComboBox"; break;
                    }
                    if (signature == null) return;
                    key = Registry.CurrentUser.OpenSubKey(@"Software\" + app);
                    if (key != null && key.GetValue(signature) == null) { key.Dispose(); return; }
                }
                if (key == null) return;
                using (key)
                {
                    var state = NewSnapshot(form);
                    foreach (string name in key.GetValueNames())
                    {
                        object value = key.GetValue(name);
                        if (value == null) continue;
                        string text = Convert.ToString(value, Culture);
                        switch (name)
                        {
                            case "FormLeft": if (int.TryParse(text, out int left)) state.Left = left; break;
                            case "FormTop": if (int.TryParse(text, out int top)) state.Top = top; break;
                            case "FormWidth": if (int.TryParse(text, out int width)) state.Width = width; break;
                            case "FormHeight": if (int.TryParse(text, out int height)) state.Height = height; break;
                            case "FormWindowState":
                                state.WindowState = text == "2" ? "Maximized" : "Normal"; break;
                            default:
                                // Convert original checked-list notation to JSON notation.
                                int open = name.LastIndexOf('(');
                                string keyName = open >= 0 && name.EndsWith(")", StringComparison.Ordinal)
                                    ? name.Substring(0, open) + "[" + name.Substring(open + 1, name.Length - open - 2) + "]"
                                    : name;
                                state.Controls[keyName] = text;
                                break;
                        }
                    }
                    WriteFile(jsonPath, state);
                }
            }
            catch (Exception ex) when (IsFileError(ex))
            {
                // A denied/obsolete registry key is not an obstacle to JSON.
                Debug.WriteLine("Legacy settings migration skipped: " + ex.Message);
            }
        }
    }
}
