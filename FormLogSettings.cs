using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLogSettings : Form
    {
        #region Fields variables

        //public static float Z5; // camber angle when finding the actual camber angle related to the ground
        #endregion
        public FormLogSettings()
        {
            InitializeComponent();
            // Sets up the initial objects in the CheckedListBox.
            //string[] loggedParameters = { };//"Apples", "Oranges", "Tomato" };
            //checkedListBoxFLLogging.Items.AddRange(loggedParameters);
            DelimiterSet();
            // Changes the selection mode from double-click to single click.
            checkedListBoxLogging.CheckOnClick = true;
            DelimiterTextBox.MaxLength = 1;
        }
        #region Methods
        public void CheckedListBoxAdd(CheckedListBox cLB)
        {
            foreach (var arawData in LiveData.FL_RawData)
            {
                cLB.Items.Add(arawData.ToString());
            }
        }
        private void DelimiterSet()
        {
            char[] charArray = DelimiterTextBox.Text.ToCharArray();

            if (DelimiterTextBox.Text == "")
            {
                LogSettings.Delimiter = LogSettings.DefaultDelimiter;
                DelimiterTextBox.Text = LogSettings.Delimiter.ToString();
            }
            else
            {
                LogSettings.Delimiter = charArray[0];
            }
        }
        private void ReadTextBoxes()
        {
            //double W3;
            double w4;// left as an example
            var c = CultureInfo.GetCultureInfo("en-US");
            if (double.TryParse(textBox_Z1.Text, NumberStyles.Any, c, out _) == true
                && double.TryParse(textBox_W1.Text, NumberStyles.Any, c, out _) == true
                && double.TryParse(textBox_Z2.Text, NumberStyles.Any, c, out _) == true
                && double.TryParse(textBox_W2.Text, NumberStyles.Any, c, out _) == true
                && double.TryParse(textBox_Z3.Text, NumberStyles.Any, c, out _) == true
                //&& double.TryParse(textBox_W3.Text, NumberStyles.Any, c, out w3) == true
                && double.TryParse(textBox_Z4.Text, NumberStyles.Any, c, out _) == true
                && double.TryParse(textBox_W4.Text, NumberStyles.Any, c, out w4) == true)
            {
                LogSettings.Z1 = double.Parse(textBox_Z1.Text, c);
                LogSettings.Z2 = double.Parse(textBox_Z2.Text, c);
                LogSettings.Z3 = double.Parse(textBox_Z3.Text, c);
                LogSettings.Z4 = double.Parse(textBox_Z4.Text, c);
                LogSettings.W4 = double.Parse(textBox_W4.Text, c);
            }


        }
        private void ChecklistBoxLoggingCheckedCheck()
        {
            if (checkedListBoxLogging.GetItemChecked(0) == true)
            {
                LogSettings.TireTravelSpeedLogEnabled = true;
            }
            else
            {
                LogSettings.TireTravelSpeedLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(1) == true)
            {
                LogSettings.AngularVelocityLogEnabled = true;
            }
            else
            {
                LogSettings.AngularVelocityLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(2) == true)
            {
                LogSettings.VerticalLoadLogEnabled = true;
            }
            else
            {
                LogSettings.VerticalLoadLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(3) == true)
            {
                LogSettings.VerticalDeflectionLogEnabled = true;
            }
            else
            {
                LogSettings.VerticalDeflectionLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(4) == true)
            {
                LogSettings.LoadedRadiusLogEnabled = true;
            }
            else
            {
                LogSettings.LoadedRadiusLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(5) == true)
            {
                LogSettings.EffectiveRadiusLogEnabled = true;
            }
            else
            {
                LogSettings.EffectiveRadiusLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(6) == true)
            {
                LogSettings.ContactLengthLogEnabled = true;
            }
            else
            {
                LogSettings.ContactLengthLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(7) == true)
            {
                LogSettings.BrakeTorqueLogEnabled = true;
            }
            else
            {
                LogSettings.BrakeTorqueLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(8) == true)
            {
                LogSettings.SteerAngleLogEnabled = true;
            }
            else
            {
                LogSettings.SteerAngleLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(9) == true)
            {
                LogSettings.CamberAngleLogEnabled = true;
            }
            else
            {
                LogSettings.CamberAngleLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(10) == true)
            {
                LogSettings.LateralLoadLogEnabled = true;
            }
            else
            {
                LogSettings.LateralLoadLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(11) == true)
            {
                LogSettings.SlipAngleLogEnabled = true;
            }
            else
            {
                LogSettings.SlipAngleLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(12) == true)
            {
                LogSettings.LateralFrictionLogEnabled = true;
            }
            else
            {
                LogSettings.LateralFrictionLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(13) == true)
            {
                LogSettings.LateralSlipSpeedLogEnabled = true;
            }
            else
            {
                LogSettings.LateralSlipSpeedLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(14) == true)
            {
                LogSettings.LongitudinalLoadLogEnabled = true;
            }
            else
            {
                LogSettings.LongitudinalLoadLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(15) == true)
            {
                LogSettings.SlipRatioLogEnabled = true;
            }
            else
            {
                LogSettings.SlipRatioLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(16) == true)
            {
                LogSettings.LongitudinalFrictionLogEnabled = true;
            }
            else
            {
                LogSettings.LongitudinalFrictionLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(17) == true)
            {
                LogSettings.LongitudinalSlipSpeedLogEnabled = true;
            }
            else
            {
                LogSettings.LongitudinalSlipSpeedLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(18) == true)
            {
                LogSettings.TreadTemperatureLogEnabled = true;
            }
            else
            {
                LogSettings.TreadTemperatureLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(19) == true)
            {
                LogSettings.InnerTemperatureLogEnabled = true;
            }
            else
            {
                LogSettings.InnerTemperatureLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(20) == true)
            {
                LogSettings.RaceTimeLogEnabled = true;
            }
            else
            {
                LogSettings.RaceTimeLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(21) == true)
            {
                LogSettings.TotalFrictionLogEnabled = true;
            }
            else
            {
                LogSettings.TotalFrictionLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(22) == true)
            {
                LogSettings.TotalFrictionAngleLogEnabled = true;
            }
            else
            {
                LogSettings.TotalFrictionAngleLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(23) == true)
            {
                LogSettings.SuspensionLengthLogEnabled = true;
            }
            else
            {
                LogSettings.SuspensionLengthLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(24) == true)
            {
                LogSettings.SuspensionVelocityLogEnabled = true;
            }
            else
            {
                LogSettings.SuspensionVelocityLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(25) == true)
            {
                LogSettings.XGRotatedLogEnabled = true;
            }
            else
            {
                LogSettings.XGRotatedLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(26) == true)
            {
                LogSettings.ZGRotatedLogEnabled = true;
            }
            else
            {
                LogSettings.ZGRotatedLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(27) == true)
            {
                LogSettings.YGRotatedLogEnabled = true;
            }
            else
            {
                LogSettings.YGRotatedLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(28) == true)
            {
                LogSettings.XYZGLogEnabled = true;
            }
            else
            {
                LogSettings.XYZGLogEnabled = false;
            }
            if (checkBoxFiltersOn.Checked == true)
            {
                LogSettings.FiltersOn = true;
            }
            else
            {
                LogSettings.FiltersOn = false;
            }
        }
        private void ListBoxClearAndWriters()
        {
            SelectedListBox.Items.Clear();
            SelectedIndeciesListBox.Items.Clear();

            foreach (string s in checkedListBoxLogging.CheckedItems)
            {
                SelectedListBox.Items.Add(s);
            }
            for (int i = 0; i < checkedListBoxLogging.CheckedIndices.Count; i++)
            {
                SelectedIndeciesListBox.Items.Add(checkedListBoxLogging.CheckedIndices[i]);
            }
        }
        private void CheckAllOffListBoxStates()
        {
            if (selectAll.Checked == false)
            {
                for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
                {
                    checkedListBoxLogging.SetItemChecked(i, selectAll.Checked);
                }
                LogSettings.selectAll = false;
            }
        }
        private void CheckAllOnListBoxStates()
        {
            if (selectAll.Checked == true)
            {
                for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
                {
                    checkedListBoxLogging.SetItemChecked(i, selectAll.Checked);
                }
                LogSettings.selectAll = true;
            }
        }
        private void TextBoxesToString()
        {
            var c = CultureInfo.GetCultureInfo("en-US");
            textBox_Z1.Text = LogSettings.Z1.ToString(c);
            textBox_W1.Text = LogSettings.W1.ToString(c);
            textBox_Z2.Text = LogSettings.Z2.ToString(c);
            textBox_W2.Text = LogSettings.W2.ToString(c);
            textBox_Z3.Text = LogSettings.Z3.ToString(c);
            //textBox_W3.Text = W3.ToString(c);
            textBox_Z4.Text = LogSettings.Z4.ToString(c);
            textBox_W4.Text = LogSettings.W4.ToString(c);
        }
        #endregion
        #region Form Buttons etc.
        private void Settings_Closing(object sender, FormClosingEventArgs e)
        {
            RegistryTools.SaveAllSettings(Application.ProductName, this);
        }

        private void Settings_Closed(object sender, FormClosedEventArgs e)
        {
            LiveData.LogSettingsOpen = false;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            LiveData.LogSettingsOpen = true;

            SelectedListBox.Visible = false;
            SelectedIndeciesListBox.Visible = false;

            // Load saved settings
            RegistryTools.LoadAllSettings(Application.ProductName, this);
            DelimiterSet();
            ChecklistBoxLoggingCheckedCheck();
            //ListBoxClearAndWriters();

            TextBoxesToString();
            CheckAllOnListBoxStates();
        }
        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllOnListBoxStates();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            CheckAllOnListBoxStates();
            CheckAllOffListBoxStates();
        }
        private void backToFirstAllDataLoggerPage_Click(object sender, EventArgs e)
        {
            //First_All_Data_Logger_Page fadlp = new First_All_Data_Logger_Page();
            //fadlp.Show();
            this.Close();
        }
        private void checkedListBoxLogging_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
            {
                if (checkedListBoxLogging.GetItemChecked(i) == false)
                {
                    LogSettings.selectAll = false;
                    selectAll.Checked = false;
                }
            }
        }
        private void ApplyLogSettings_Click(object sender, EventArgs e)
        {
            DelimiterSet();

            ChecklistBoxLoggingCheckedCheck();
            //ListBoxClearAndWriters();

            ReadTextBoxes();

            TextBoxesToString();

            CheckedListBoxAdd(checkedListBox1);
        }
        private void CheckKeyIsNumberOrDecimalPoint(KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if (!Char.IsDigit(ch1) && ch1 != 8 && ch1 != 46/* && ch1 != 44*/)
            {
                e.Handled = true;
            }
        }
        private void textBox_Z1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_W1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_Z2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_W2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_Z3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_W3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_Z4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_W4_Keypress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void checkBoxFiltersOn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFiltersOn.Checked == true)
            {
                LogSettings.FiltersOn = true;
            }
            else
            {
                LogSettings.FiltersOn = false;
            }
        }
        #endregion

    }
}
