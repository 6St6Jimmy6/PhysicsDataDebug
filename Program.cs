using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;



namespace Physics_Data_Debug
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.AddMessageFilter(new ComboBoxWheelFilter());
            try
            {
                GameMemoryConfig.Load();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Game memory configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(GameMemoryConfig.LoadWarning))
                MessageBox.Show(GameMemoryConfig.LoadWarning, "Game memory configuration",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FormLiveData main = new FormLiveData();
            // Capture actual initialized defaults before importing or restoring
            // any user's saved settings. Profiles are generated only if missing,
            // so customized profiles remain untouched across app upgrades.
            JsonFormSettings.EnsureFactoryDefaults(main);
            // Chart forms must not be constructed invisibly for profile capture.
            // Their constructors initialize WinForms Chart controls, which can
            // receive a zero-width layout before the form is shown and throw.
            // Each chart captures its factory defaults when really opened.
            JsonFormSettings.EnsureFactoryDefaults<Form4WheelsSettings>();
            // Offline Chart Settings has no chart of its own: initialize its
            // empty-column defaults before any CSV headers are imported.
            JsonFormSettings.EnsureFactoryDefaults<FormOfflineChartSettings>();
            JsonFormSettings.EnsureFactoryDefaults<FormGForceSettings>();
            JsonFormSettings.EnsureFactoryDefaults<FormLogSettings>();
            FormLogSettings.RestoreSavedModel();
            Form4WheelsSettings.RestoreSavedModel();
            FormGForceSettings.RestoreSavedModel();
            Application.Run(main);

        }
    }
}
