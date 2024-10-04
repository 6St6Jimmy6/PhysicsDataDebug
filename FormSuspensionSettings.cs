using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormSuspensionSettings : Form
    {
        public FormSuspensionSettings()
        {
            InitializeComponent();
        }

        private void SuspensionSettings_Load(object sender, EventArgs e)
        {
            LiveData.SuspensionSettingsOpen = true;
            //readAndWriteData();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuspensionSettings_Closing(object sender, FormClosingEventArgs e)
        {
            LiveData.SuspensionSettingsOpen = false;
        }
    }
}
