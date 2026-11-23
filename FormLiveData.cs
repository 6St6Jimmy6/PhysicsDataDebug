using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLiveData : Form
    {
        public static bool ProcessGet { get; set; } = false;
        public static bool FirstTimeLoad = false;
        private const string AutomaticVersionOption = "Automatic (Wreckfest_x64.exe)";
        private GameVersionProfile SelectedVersion;
        private long activeBaseAddressShift;
        private readonly DataLogger dataLogger = new DataLogger();
        private readonly string originalWindowTitle;

#if DEBUG
        public static bool debugEnabled = true;
#else
        public static bool debugEnabled = false;
#endif

        public FormLiveData()
        {
            InitializeComponent();
            // The Designer already contains the actual layout and does not
            // need memory configuration, JSON profiles, or runtime bindings.
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            originalWindowTitle = Text;

            // The old dashboard labels were removed from the Designer.
            // Only the six optional debug text boxes remain in the debug workspace.
            foreach (TextBox box in new[] { textBox1, textBox2, textBox3,
                textBox4, textBox5, textBox6 })
            {
                box.Visible = debugEnabled;
                box.Enabled = debugEnabled;
            }

            logInterval_textBox.Text = LiveData.TickInterval.ToString();

            GameVersionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            GameVersionComboBox.Items.Add(AutomaticVersionOption);
            foreach (GameVersionProfile version in GameMemoryConfig.Versions)
                GameVersionComboBox.Items.Add(version);
            // First-run default is automatic. Previously saved manual selections
            // are restored by JsonFormSettings when the form loads.
            GameVersionComboBox.SelectedIndex = 0;
            SelectedVersion = GameMemoryConfig.ActiveVersion;
            activeBaseAddressShift = SelectedVersion.BaseAddressShift;
            ComboBoxBehaviors.EnableSearch(this);
            InitializeGameConfigSelector();
            UpdateGameConfigTitle();
            JsonFormSettings.AttachProfileButton(this, ApplyVersionSelection);
            InitializeDesignerLayoutBehavior();
            InitializeMonitor();


            if (FirstTimeLoad == false)
            {
                LiveData.InitializeDataLists();
                FirstTimeLoad = true;
            }
        }

        private void InitializeGameConfigSelector()
        {
            // The Designer owns the version selector's size and dropdown width.
            // The Config button occupies the next row of the same table.
            var menu = new ContextMenuStrip();
            menu.Items.Add("Load game configuration...", null, (sender, args) => ChooseGameConfiguration());
            menu.Items.Add("Save current configuration as...", null, (sender, args) => SaveGameConfigurationAs());
            menu.Items.Add("Reload current configuration", null, (sender, args) =>
                SwitchGameConfiguration(GameMemoryConfig.ActiveFileName));
            menu.Items.Add("Select Wreckfest configuration", null, (sender, args) =>
                SwitchGameConfiguration(GameMemoryConfig.DefaultFileName));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Open configuration folder", null, (sender, args) => OpenGameConfigurationFolder());

            // The button is Designer-owned. Only its menu and click action
            // are initialized here, so its design-time location is preserved.
            GameConfigurationProfilesButton.ContextMenuStrip = menu;
            GameConfigurationProfilesButton.Click += (sender, args) =>
                menu.Show(GameConfigurationProfilesButton, 0, GameConfigurationProfilesButton.Height);
            var tooltip = new ToolTip(components);
            tooltip.SetToolTip(GameConfigurationProfilesButton, "Load or save a game-memory configuration JSON profile");
            tooltip.SetToolTip(GameVersionComboBox,
                "Automatic: detect build and base shift from the attached Wreckfest_x64.exe. " +
                "Or select a JSON version manually.");
            Disposed += (sender, args) => menu.Dispose();
        }

        private void UpdateGameConfigTitle() =>
            Text = originalWindowTitle + " - " + GameMemoryConfig.ActiveFileName;

        private bool CanSwitchGameConfiguration()
        {
            if (ProcessGet || timer1.Enabled || LiveData.Logging)
            {
                MessageBox.Show("Stop memory sampling and logging before switching game configurations.",
                    "Game configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Application.OpenForms.Cast<Form>().Any(form => !ReferenceEquals(form, this)))
            {
                MessageBox.Show("Close the other chart/settings windows before switching game configurations. " +
                    "Their fields may change with the new JSON.",
                    "Game configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void ChooseGameConfiguration()
        {
            if (!CanSwitchGameConfiguration()) return;
            using (var dialog = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Load game memory configuration",
                Filter = "JSON game configuration (*.json)|*.json",
                InitialDirectory = GameMemoryConfig.SettingsDirectory,
                FileName = GameMemoryConfig.ActiveFileName,
                CheckFileExists = true
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    // External files are copied into the managed Settings
                    // folder, with a unique name to preserve existing files.
                    string name = ImportGameConfiguration(dialog.FileName);
                    SwitchGameConfiguration(name);
                }
                catch (Exception ex) when (IsGameConfigFileError(ex)) { ShowGameConfigError(ex); }
            }
        }

        private static string ImportGameConfiguration(string sourcePath)
        {
            string source = Path.GetFullPath(sourcePath);
            string directory = Path.GetFullPath(GameMemoryConfig.SettingsDirectory);
            string fileName = Path.GetFileName(source);
            if (string.Equals(Path.GetDirectoryName(source), directory, StringComparison.OrdinalIgnoreCase))
                return fileName;

            string stem = Path.GetFileNameWithoutExtension(fileName);
            string target = Path.Combine(directory, fileName);
            int suffix = 2;
            while (File.Exists(target))
                target = Path.Combine(directory, stem + " (" + suffix++ + ").json");
            File.Copy(source, target);
            return Path.GetFileName(target);
        }

        private void SwitchGameConfiguration(string fileName)
        {
            if (!CanSwitchGameConfiguration()) return;
            try
            {
                // Parsing and validation happen before the active config changes.
                bool reloading = string.Equals(fileName, GameMemoryConfig.ActiveFileName,
                    StringComparison.OrdinalIgnoreCase);
                string previousVersionId = SelectedVersion?.Id;
                bool wasAutomatic = IsAutomaticVersionSelected;
                GameMemoryConfig.Load(fileName);
                if (reloading)
                {
                    GameVersionProfile retained = GameMemoryConfig.Versions
                        .FirstOrDefault(version => version.Id == previousVersionId);
                    if (retained != null) GameMemoryConfig.SelectVersion(retained);
                }
                LiveData.ReinitializeDataLists();
                ValuesGet = false;
                GameVersionComboBox.BeginUpdate();
                try
                {
                    GameVersionComboBox.Items.Clear();
                    foreach (GameVersionProfile version in GameMemoryConfig.Versions)
                        GameVersionComboBox.Items.Add(version);
                    GameVersionComboBox.Items.Insert(0, AutomaticVersionOption);
                    SelectedVersion = GameMemoryConfig.ActiveVersion;
                    GameVersionComboBox.SelectedItem = wasAutomatic
                        ? (object)AutomaticVersionOption : SelectedVersion;
                    activeBaseAddressShift = SelectedVersion.BaseAddressShift;
                }
                finally { GameVersionComboBox.EndUpdate(); }
                ApplyVersionSelection();
                UpdateGameConfigTitle();
                RebuildMonitorFields();
                JsonFormSettings.SaveAllSettings(this);
            }
            catch (Exception ex) when (IsGameConfigFileError(ex)) { ShowGameConfigError(ex); }
        }

        private void SaveGameConfigurationAs()
        {
            using (var dialog = new System.Windows.Forms.SaveFileDialog
            {
                Title = "Save a copy of the game memory configuration",
                Filter = "JSON game configuration (*.json)|*.json",
                InitialDirectory = GameMemoryConfig.SettingsDirectory,
                FileName = Path.GetFileNameWithoutExtension(GameMemoryConfig.ActiveFileName) + " Copy.json",
                DefaultExt = "json",
                AddExtension = true,
                OverwritePrompt = true
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    // Keep the original active configuration intact.
                    File.Copy(GameMemoryConfig.FilePath, dialog.FileName, true);
                }
                catch (Exception ex) when (IsGameConfigFileError(ex)) { ShowGameConfigError(ex); }
            }
        }

        private static void OpenGameConfigurationFolder()
        {
            try { Process.Start("explorer.exe", GameMemoryConfig.SettingsDirectory); }
            catch (Exception ex) when (IsGameConfigFileError(ex)) { ShowGameConfigError(ex); }
        }

        private static bool IsGameConfigFileError(Exception ex) =>
            ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException ||
            ex is InvalidOperationException || ex is System.Security.SecurityException ||
            ex is FormatException;

        private static void ShowGameConfigError(Exception ex) =>
            MessageBox.Show(ex.Message, "Game configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        public void ButtonVisibilities()
        {
            toLogSettingsButton.Visible = !LiveData.Logging && !LiveData.LogSettingsOpen;
            startFileLoggingButton.Visible = !LiveData.LogSettingsOpen;
            toTireStaticValues.Visible = !LiveData.FormTireStaticValues;
            OpenTemperaturesChart.Visible = !LiveData.TemperaturesChartOpen;
            toGForceButton.Visible = !LiveData.GForceOpen;
            to4WheelsButton.Visible = !LiveData._4WheelsOpen;
            toSuspensionStaticValues.Visible = !LiveData.FormSuspensionStaticValuesOpen;
            toSuspensionGeometry.Visible = !LiveData.FormSuspensionGeometryOpen;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        //Current slide speed in m/s
        ///double CurrentLateralSlideSpeed = 5.1;

        //Current temperature Kelvins
        //double CurrentSurfaceTempKelvins = 353.15;

        //Glass Transition
        //Glass transition temperature Tg, is rather critical and changes with compound. On the other hand, the remaining (XYZ) variables are pretty much the same for all rubbers, with the exception of butyl rubber (not typically used for tread compounds).
        public static double Tg = 228.15; //Glass Transition Temperature in Kelvins -45C
        public static double TgX = 50;
        public static double TgY = -8.86;
        public static double TgZ = 51.5;
        //The default values fit into the following shift factor WLF equation:
        //log10(aT) = log10(ln(-8.86 ((Tq - Tg - 50) / (51.5 + Tq -Tg))))
        //or
        //log10(aT) = -8.86 ((Tq - Tg - 50) / (51.5 + Tq -Tg))
        //These have different results. WF1 seems to follow the first one.

        //Adhesion
        public static double SlidingAdhesionPointLog10aTv_X = -9.2;
        public static double SlidingAdhesionPointLog10aTv_Y = -5.2;
        public static double SlidingAdhesionPointLog10aTv_Z = -1.2;

        public static double SlidingAdhesionGripX = 0.1;
        public static double SlidingAdhesionGripY = 0.42;
        public static double SlidingAdhesionGripZ = 0.05;

        //Micro
        public static double SlidingMicroPointLog10aTv_X = -5.2;
        public static double SlidingMicroPointLog10aTv_Y = -1.2;
        public static double SlidingMicroPointLog10aTv_Z = 2.5;

        public static double SlidingMicroGripX = 0.15;
        public static double SlidingMicroGripY = 0.9;
        public static double SlidingMicroGripZ = 0.15;

        //Macro
        public static double SlidingMacroPointLog10aTv_X = -1.2;
        public static double SlidingMacroPointLog10aTv_Y = 2.5;
        public static double SlidingMacroPointLog10aTv_Z = 6.0;

        public static double SlidingMacroGripX = 0.05;
        public static double SlidingMacroGripY = 0.5;
        public static double SlidingMacroGripZ = 0.1;

        // Numerical shift/grip curves are now maintained in TireGripMath.cs.

        public static double CurrentSurfaceTempKelvins;

        public static double Log10aT;
        //double Log10aT = TireGripMath.GetShiftFactor_Log10aT(CurrentSurfaceTempKelvins, Tg, TgX, TgY, TgZ)[1];

        public static double CurrentLateralSlideSpeed;
        public static double CurrentLongitudinalSlideSpeed;

        //WLF Lateral Grip multiplier
        public static double LateralAdhesionGrip;
        public static double LateralMicroGrip;
        public static double LateralMacroGrip;
        public static double WLF_LateralSlidingFrictionGripMultiplier;

        //WLF Longitudinal Grip multiplier
        public static double LongitudinalAdhesionGrip;
        public static double LongitudinalMicroGrip;
        public static double LongitudinalMacroGrip;
        public static double WLF_LongitudinalSlidingFrictionGripMultiplier;

        // Load Sens multiplier
        public static double VerticalLoad;
        public static double LateralLoadSensGripMultiplier;
        public static double LongitudinalLoadSensGripMultiplier;

        public static double LateralFrictionNoMultis;
        public static double LongitudinalFrictionNoMultis;
        public static void WLFMultiplier()
        {
            CurrentSurfaceTempKelvins = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "TreadTemperatureKelvins"));

            Log10aT = TireGripMath.GetShiftFactor_Log10aT(CurrentSurfaceTempKelvins, Tg, TgX, TgY, TgZ)[0];
            //double Log10aT = TireGripMath.GetShiftFactor_Log10aT(CurrentSurfaceTempKelvins, Tg, TgX, TgY, TgZ)[1];

            CurrentLateralSlideSpeed = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "LateralSlipSpeed"));
            CurrentLongitudinalSlideSpeed = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "LongitudinalSlipSpeed"));

            //WLF Lateral Grip multiplier
            LateralAdhesionGrip = TireGripMath.CosineFunctionGrip(Log10aT, CurrentLateralSlideSpeed, SlidingAdhesionPointLog10aTv_X, SlidingAdhesionPointLog10aTv_Y, SlidingAdhesionPointLog10aTv_Z, SlidingAdhesionGripX, SlidingAdhesionGripY, SlidingAdhesionGripZ);
            LateralMicroGrip = TireGripMath.CosineFunctionGrip(Log10aT, CurrentLateralSlideSpeed, SlidingMicroPointLog10aTv_X, SlidingMicroPointLog10aTv_Y, SlidingMicroPointLog10aTv_Z, SlidingMicroGripX, SlidingMicroGripY, SlidingMicroGripZ);
            LateralMacroGrip = TireGripMath.CosineFunctionGrip(Log10aT, CurrentLateralSlideSpeed, SlidingMacroPointLog10aTv_X, SlidingMacroPointLog10aTv_Y, SlidingMacroPointLog10aTv_Z, SlidingMacroGripX, SlidingMacroGripY, SlidingMacroGripZ);
            WLF_LateralSlidingFrictionGripMultiplier = LateralAdhesionGrip + LateralMicroGrip + LateralMacroGrip;

            //WLF Longitudinal Grip multiplier
            LongitudinalAdhesionGrip = TireGripMath.CosineFunctionGrip(Log10aT, CurrentLongitudinalSlideSpeed, SlidingAdhesionPointLog10aTv_X, SlidingAdhesionPointLog10aTv_Y, SlidingAdhesionPointLog10aTv_Z, SlidingAdhesionGripX, SlidingAdhesionGripY, SlidingAdhesionGripZ);
            LongitudinalMicroGrip = TireGripMath.CosineFunctionGrip(Log10aT, CurrentLongitudinalSlideSpeed, SlidingMicroPointLog10aTv_X, SlidingMicroPointLog10aTv_Y, SlidingMicroPointLog10aTv_Z, SlidingMicroGripX, SlidingMicroGripY, SlidingMicroGripZ);
            LongitudinalMacroGrip = TireGripMath.CosineFunctionGrip(Log10aT, CurrentLongitudinalSlideSpeed, SlidingMacroPointLog10aTv_X, SlidingMacroPointLog10aTv_Y, SlidingMacroPointLog10aTv_Z, SlidingMacroGripX, SlidingMacroGripY, SlidingMacroGripZ);
            WLF_LongitudinalSlidingFrictionGripMultiplier = LongitudinalAdhesionGrip + LongitudinalMicroGrip + LongitudinalMacroGrip;

            // Load Sens multiplier
            VerticalLoad = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "VerticalLoad"));
            LateralLoadSensGripMultiplier = TireGripMath.LoadSensGrip(VerticalLoad, -0.05, 10300);
            LongitudinalLoadSensGripMultiplier = TireGripMath.LoadSensGrip(VerticalLoad, -0.05, 10300);

            LateralFrictionNoMultis = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "LateralFriction")) / (WLF_LateralSlidingFrictionGripMultiplier * LateralLoadSensGripMultiplier);
            LongitudinalFrictionNoMultis = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "LongitudinalFriction")) / (WLF_LongitudinalSlidingFrictionGripMultiplier * LongitudinalLoadSensGripMultiplier);
        }
        public void WLFMultiplierTBWriter()
        {
            textBox6.Text = "RLLog10(aT): " + Log10aT + "\r\n" + "RLLonWLF: " + WLF_LongitudinalSlidingFrictionGripMultiplier + "\r\n" + "RLLonSens: " + LongitudinalLoadSensGripMultiplier + "\r\n" + "RLLonFric: " + LongitudinalFrictionNoMultis + "\r\n" + "RLLatWLF: " + WLF_LateralSlidingFrictionGripMultiplier + "\r\n" + "RLLatSens: " + LateralLoadSensGripMultiplier + "\r\n" + "RLLatFric: " + LateralFrictionNoMultis;
        }
        
        private void UpdateFormData()
        {
            ButtonVisibilities();
        }

        private void ProcessStart()
        {
            ProcessGet = true;
            getProcessButton.Text = "Refresh Process";
            timer1.Enabled = true;
        }
        
        private void logInterval_textBox_Keypress(object sender, KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if (!Char.IsDigit(ch1) && ch1 != 8)
            {
                e.Handled = true;
            }
        }
        private void logInterval_textBox_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            // Empty box makes it 1 and not 0 or less.
            if (textbox.Text == "")
            {
                LiveData.TickInterval = 1;
                textbox.Text = "1";
            }
            else if (int.TryParse(textbox.Text, out LiveData.TickInterval))
            {
                if (LiveData.TickInterval > 2000)
                {
                    LiveData.TickInterval = 2000;
                    textbox.Text = "2000";
                }
                else if (LiveData.TickInterval < 1 || LiveData.TickInterval == -1)
                {
                    LiveData.TickInterval = 1;
                    textbox.Text = "1";
                }
            }
        }
        private void Start_Log_Click(object sender, EventArgs e)
        {
            if (dataLogger.IsRunning)
            {
                dataLogger.StopSession();
            }
            else
            {
                try { dataLogger.StartSession(); }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                           ex is ArgumentException || ex is InvalidOperationException ||
                                           ex is System.Security.SecurityException)
                {
                    MessageBox.Show(this, ex.Message, "Unable to start logging",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            startFileLoggingButton.Text = dataLogger.IsRunning ? "Stop Logging" : "Start Logging";
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toLogSettingsButton.Visible = false;
            LiveData.LogSettingsOpen = true;
            FormLogSettings s1 = new FormLogSettings();
            s1.Show();
        }
        private void exitApplication_Click(object sender, EventArgs e)
        {
            LiveData.DetachProcess();
            Application.Exit();
        }
        private void toTireStaticValues_Click(object sender, EventArgs e)
        {
            toTireStaticValues.Visible = false;
            LiveData.FormTireStaticValues = true;
            FormTireStaticValues s = new FormTireStaticValues();
            s.Show();
        }
        private void FirstAllDataLoggerPage_Closing(object sender, FormClosingEventArgs e)
        {
            JsonFormSettings.SaveAllSettings(this);
            timer1.Enabled = false;
            dataLogger.StopSession();
            LiveData.DetachProcess();
        }
        private void OpenTemperaturesChart_Click(object sender, EventArgs e)
        {
            OpenTemperaturesChart.Visible = false;
            LiveData.TemperaturesChartOpen = true;
            FormLiveTimeChart s = new FormLiveTimeChart();
            s.Show();
        }
        private void toSuspensionStaticValuesButton_Click(object sender, EventArgs e)
        {
            toSuspensionStaticValues.Visible = false;
            LiveData.FormSuspensionStaticValuesOpen = true;
            FormSuspensionStaticValues s = new FormSuspensionStaticValues();
            s.Show();
        }
        private void toTestChartPageButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = LogSettings.LogFileSaveLocationFolder;
                ofd.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LogSettings.ChartPlotterLocation = ofd.FileName;
                    try { Process.Start(LogSettings.ChartPlotterLocation); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Unable to start chart plotter",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FirstAllDataLoggerPage_Load(object sender, EventArgs e)
        {
            JsonFormSettings.LoadAllSettings(this);
            // Automatic is the first-run default; still honor an explicitly
            // saved manual choice in this form's JSON profile.
            if (GameVersionComboBox.SelectedIndex < 0)
                GameVersionComboBox.SelectedItem = AutomaticVersionOption;
            ApplyVersionSelection();
        }
        private bool IsAutomaticVersionSelected =>
            string.Equals(GameVersionComboBox.SelectedItem as string,
                AutomaticVersionOption, StringComparison.Ordinal);

        private void ApplyVersionSelection()
        {
            if (IsAutomaticVersionSelected)
            {
                if (versionDetectionStatus != null)
                    versionDetectionStatus.Text = "Auto: detect on Get Process";
                UpdateGameConfigTitle();
                // Do not guess a shift before the process executable is known.
                return;
            }
            SelectedVersion = GameVersionComboBox.SelectedItem as GameVersionProfile
                ?? GameMemoryConfig.ActiveVersion;
            GameMemoryConfig.SelectVersion(SelectedVersion);
            activeBaseAddressShift = SelectedVersion.BaseAddressShift;
            if (versionDetectionStatus != null)
                versionDetectionStatus.Text = "Manual: shift " + FormatHexShift(activeBaseAddressShift);
            UpdateGameConfigTitle();
        }

        private static string FormatHexShift(long shift) =>
            (shift < 0 ? "-0x" : "+0x") +
            (shift < 0 ? unchecked((ulong)(-(shift + 1)) + 1) : (ulong)shift).ToString("X");

        private bool TryResolveSelectedVersion()
        {
            if (!IsAutomaticVersionSelected)
            {
                ApplyVersionSelection();
                return true;
            }
            try
            {
                Process process = LiveData.Process;
                if (process == null) throw new InvalidOperationException("No Wreckfest process is attached.");
                string executable = process.MainModule.FileName;
                if (!string.Equals(Path.GetFileName(executable), "Wreckfest_x64.exe",
                    StringComparison.OrdinalIgnoreCase))
                    throw new InvalidDataException("Automatic detection is supported only for Wreckfest_x64.exe.");

                WreckfestDetectedVersion detected = WreckfestVersionDetector.Detect(executable);
                GameVersionProfile profile;
                long shift = GameMemoryConfig.SelectDetectedVersion(detected, out profile);
                SelectedVersion = profile ?? GameMemoryConfig.ActiveVersion;
                activeBaseAddressShift = shift;
                string message = "Detected " + detected.VersionId + " | shift " + FormatHexShift(shift) +
                    (profile == null ? " (unlisted build)" : " (JSON profile)");
                if (versionDetectionStatus != null)
                    versionDetectionStatus.Text = detected.VersionId + " | " + FormatHexShift(shift);
                Text = originalWindowTitle + " - " + GameMemoryConfig.ActiveFileName + " - " + message;
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                       ex is InvalidOperationException || ex is ArgumentException ||
                                       ex is OverflowException || ex is FormatException ||
                                       ex is KeyNotFoundException || ex is System.ComponentModel.Win32Exception ||
                                       ex is System.Security.SecurityException)
            {
                if (versionDetectionStatus != null) versionDetectionStatus.Text = "Auto detection failed";
                MessageBox.Show(this, "Automatic Wreckfest version detection failed:\n" + ex.Message +
                    "\n\nSelect a manual JSON version to continue.", "Wreckfest version",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void StopMemoryCapture()
        {
            timer1.Enabled = false;
            ProcessGet = false;
            ValuesGet = false;
            dataLogger.StopSession();
            startFileLoggingButton.Text = "Start Logging";
            getProcessButton.Text = "Get Process";
            LiveData.DetachProcess();
        }

        private void getProcessButton_Click(object sender, EventArgs e)
        {
            bool attached;
            try
            {
                attached = LiveData.AttachProcess("Wreckfest_x64");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                StopMemoryCapture();
                MessageBox.Show(this, ex.Message, "Unable to attach to Wreckfest",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (attached && !TryResolveSelectedVersion())
            {
                StopMemoryCapture();
                return;
            }
            if (attached && ProcessGet == false)
            {
                ProcessStart();
            }
            else if (attached && ProcessGet == true)
            {
                getProcessButton.Text = "Getting Process";
                timer1.Enabled = false;
                ProcessGet = false;
                ProcessStart();
            }
            else
            {
                StopMemoryCapture();
                return;
            }
        }
        public static bool ValuesGet { get; set; } = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process == null || LiveData.Process.HasExited)
            {
                StopMemoryCapture();
                return;
            }
            try
            {
                LiveData.RefreshTelemetry(activeBaseAddressShift);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                StopMemoryCapture();
                MessageBox.Show(this, ex.Message, "Unable to read game memory",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (OverflowException ex)
            {
                StopMemoryCapture();
                MessageBox.Show(this,
                    "Numeric overflow while reading telemetry. Check the selected " +
                    "Wreckfest version and memory configuration.\n\n" + ex.ToString(),
                    "Unable to read game telemetry", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ValuesGet = true;
            // Continue updating the JSON-driven monitor in the menu. Only
            // record samples when the in-game RaceTime has advanced.
            try { if (LiveData.RaceTimeAdvanced) dataLogger.LogToFile(); }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                       ex is InvalidOperationException || ex is System.Security.SecurityException)
            {
                dataLogger.StopSession("Log write failed");
                MessageBox.Show(this, ex.Message, "Logging stopped", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if (!dataLogger.IsRunning && startFileLoggingButton.Text != "Start Logging")
            {
                startFileLoggingButton.Text = "Start Logging";
                if (!string.IsNullOrEmpty(dataLogger.LastStopReason))
                    startFileLoggingButton.Tag = dataLogger.LastStopReason;
            }
            //ButtonVisibilities();
            // Only update the fields the user chose to monitor. The previous
            // The old fixed-label refresh would have updated unused legacy controls
            // and eagerly calculated values that were not selected.
            UpdateMonitorValues();
            TickTime.Text = LiveData.RaceTimeAdvanced
                ? "Race tick " + LiveData.ElapsedTime + " ms"
                : (LiveData.RaceTimeAvailable ? "RaceTime paused / menu" : "RaceTime unavailable");
            if (LiveData.UnavailableMemorySections > 0)
                TickTime.Text += " | " + LiveData.UnavailableMemorySections +
                    " memory sections unavailable (" + LiveData.FirstUnavailableMemorySection + ")";
            if (!dataLogger.IsRunning && !string.IsNullOrEmpty(dataLogger.LastStopReason))
                TickTime.Text += " | Logging stopped: " + dataLogger.LastStopReason;
            timer1.Interval = LiveData.TickInterval;
        }

        private void buttonUpdates_Tick(object sender, EventArgs e)
        {
            UpdateFormData();
        }
        private void toGForceButton_Click(object sender, EventArgs e)
        {
            toGForceButton.Visible = false;
            LiveData.GForceOpen = true;
            FormGForce s1 = new FormGForce();
            s1.Show();
        }

        private void to4WheelsButton_Click(object sender, EventArgs e)
        {
            to4WheelsButton.Visible = false;
            LiveData._4WheelsOpen = true;
            Form4Wheels s1 = new Form4Wheels();
            s1.Show();
        }
        private void GameVersionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ApplyVersionSelection();
            if (LiveData.Process != null && !TryResolveSelectedVersion())
                StopMemoryCapture();
        }

        private void toSuspensionGeometryOpen_Click(object sender, EventArgs e)
        {
            toSuspensionGeometry.Visible = false;
            LiveData.FormSuspensionGeometryOpen = true;
            FormSuspensionGeometry s = new FormSuspensionGeometry();
            s.Show();
        }
    }
}
