using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace Physics_Data_Debug
{
    public partial class Log_Settings : Form
    {
        public Log_Settings()
        {
            InitializeComponent();
            // Sets up the initial objects in the CheckedListBox.
            //string[] loggedParameters = { };//"Apples", "Oranges", "Tomato" };
            //checkedListBoxFLLogging.Items.AddRange(loggedParameters);

            // Changes the selection mode from double-click to single click.
            checkedListBoxLogging.CheckOnClick = true;
        }
        /*
        public static bool TireTravelSpeedLogEnabled;//0
        public static bool AngularVelocityLogEnabled;//1
        public static bool VerticalLoadLogEnabled;//2
        public static bool VerticalDeflectionLogEnabled;//3
        public static bool LoadedRadiusLogEnabled;//4
        public static bool EffectiveRadiusLogEnabled;//5
        public static bool ContactLengthLogEnabled;//6
        public static bool BrakeTorqueLogEnabled;//7
        public static bool SteerAngleLogEnabled;//8
        public static bool CamberAngleLogEnabled;//9
        public static bool LateralLoadLogEnabled;//10
        public static bool SlipAngleLogEnabled;//11
        public static bool LateralFrictionLogEnabled;//12
        public static bool LateralSlipSpeedLogEnabled;//13
        public static bool LongitudinalLoadLogEnabled;//14
        public static bool SlipRatioLogEnabled;//15
        public static bool LongitudinalFrictionLogEnabled;//16
        public static bool LongitudinalSlipSpeedLogEnabled;//17
        public static bool TreadTemperatureLogEnabled;//18
        public static bool InnerTemperatureLogEnabled;//19
        public static bool RaceTimeLogEnabled;//20
        public static bool TotalFrictionLogEnabled;//21
        public static bool TotalFrictionAngleLogEnabled;//22

        public static string sTireTravelSpeed = "Tire Travel Speed";
        public static string sAngularVelocity = "Angular Velocity";
        public static string sVerticalLoad = "Vertical Load";
        public static string sVerticalDeflection = "Vertical Deflection";
        public static string sLoadedRadius = "Loaded Radius";
        public static string sEffectiveRadius = "Effective Radius";
        public static string sContactLength = "Contact Length";
        public static string sBrakeTorque = "Brake Torque";
        public static string sMaxBrakeTorque = "Max Brake Torque";
        public static string sSteerAngle = "Steer Angle";
        public static string sCamberAngle = "Camber Angle";
        public static string sLateralLoad = "Lateral Load";
        public static string sSlipAngle = "Slip Angle";
        public static string sLateralFriction = "Lateral Friction";
        public static string sLateralSlipSpeed = "Lateral Slip Speed";
        public static string sLongitudinalLoad = "Longitudinal Load";
        public static string sSlipRatio = "Slip Ratio";
        public static string sLongitudinalFriction = "Longitudinal Friction";
        public static string sLongitudinalSlipSpeed = "Longitudinal Slip Speed";
        public static string sTreadTemperature = "Tread Temperature";
        public static string sInnerTemperature = "Inner Temperature";
        public static string sRaceTime = "Race Time";
        public static string sTotalFriction = "Total Friction";
        public static string sTotalFrictionAngle = "Total Friction Angle";
        */

        public static double Z1 = 1d; // +/- from W1 slip ratio
        public static double W1 = 0d;

        public static double Z2 = 45d; // +/- from W2 slip angle degrees
        public static double W2 = 0d;

        public static double Z3 = 0d; // +/- from W3 speed filtered off (m/s)
        //public static double W3 = 0d;

        public static double Z4 = 500; // +/- from W4
        public static double W4 = 2500d; // vertical load filter

        //public static float Z5; // camber angle when finding the actual camber angle related to the ground

        private void Settings_Closing(object sender, FormClosingEventArgs e)
        {
            RegistryTools.SaveAllSettings(Application.ProductName, this);
        }

        private void Settings_Closed(object sender, FormClosedEventArgs e)
        {
            Live_Data.SettingsOpen = false;
        }

        private void ChecklistBoxLoggingCheckedCheck()
        {
            if (checkedListBoxLogging.GetItemChecked(0) == true)
            {
                Live_Data.TireTravelSpeedLogEnabled = true;
            }
            else
            {
                Live_Data.TireTravelSpeedLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(1) == true)
            {
                Live_Data.AngularVelocityLogEnabled = true;
            }
            else
            {
                Live_Data.AngularVelocityLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(2) == true)
            {
                Live_Data.VerticalLoadLogEnabled = true;
            }
            else
            {
                Live_Data.VerticalLoadLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(3) == true)
            {
                Live_Data.VerticalDeflectionLogEnabled = true;
            }
            else
            {
                Live_Data.VerticalDeflectionLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(4) == true)
            {
                Live_Data.LoadedRadiusLogEnabled = true;
            }
            else
            {
                Live_Data.LoadedRadiusLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(5) == true)
            {
                Live_Data.EffectiveRadiusLogEnabled = true;
            }
            else
            {
                Live_Data.EffectiveRadiusLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(6) == true)
            {
                Live_Data.ContactLengthLogEnabled = true;
            }
            else
            {
                Live_Data.ContactLengthLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(7) == true)
            {
                Live_Data.BrakeTorqueLogEnabled = true;
            }
            else
            {
                Live_Data.BrakeTorqueLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(8) == true)
            {
                Live_Data.SteerAngleLogEnabled = true;
            }
            else
            {
                Live_Data.SteerAngleLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(9) == true)
            {
                Live_Data.CamberAngleLogEnabled = true;
            }
            else
            {
                Live_Data.CamberAngleLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(10) == true)
            {
                Live_Data.LateralLoadLogEnabled = true;
            }
            else
            {
                Live_Data.LateralLoadLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(11) == true)
            {
                Live_Data.SlipAngleLogEnabled = true;
            }
            else
            {
                Live_Data.SlipAngleLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(12) == true)
            {
                Live_Data.LateralFrictionLogEnabled = true;
            }
            else
            {
                Live_Data.LateralFrictionLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(13) == true)
            {
                Live_Data.LateralSlipSpeedLogEnabled = true;
            }
            else
            {
                Live_Data.LateralSlipSpeedLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(14) == true)
            {
                Live_Data.LongitudinalLoadLogEnabled = true;
            }
            else
            {
                Live_Data.LongitudinalLoadLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(15) == true)
            {
                Live_Data.SlipRatioLogEnabled = true;
            }
            else
            {
                Live_Data.SlipRatioLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(16) == true)
            {
                Live_Data.LongitudinalFrictionLogEnabled = true;
            }
            else
            {
                Live_Data.LongitudinalFrictionLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(17) == true)
            {
                Live_Data.LongitudinalSlipSpeedLogEnabled = true;
            }
            else
            {
                Live_Data.LongitudinalSlipSpeedLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(18) == true)
            {
                Live_Data.TreadTemperatureLogEnabled = true;
            }
            else
            {
                Live_Data.TreadTemperatureLogEnabled = false;
            }

            if (checkedListBoxLogging.GetItemChecked(19) == true)
            {
                Live_Data.InnerTemperatureLogEnabled = true;
            }
            else
            {
                Live_Data.InnerTemperatureLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(20) == true)
            {
                Live_Data.RaceTimeLogEnabled = true;
            }
            else
            {
                Live_Data.RaceTimeLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(21) == true)
            {
                Live_Data.TotalFrictionLogEnabled = true;
            }
            else
            {
                Live_Data.TotalFrictionLogEnabled = false;
            }
            if (checkedListBoxLogging.GetItemChecked(22) == true)
            {
                Live_Data.TotalFrictionAngleLogEnabled = true;
            }
            else
            {
                Live_Data.TotalFrictionAngleLogEnabled = false;
            }
            if (checkBoxFiltersOn.Checked == true)
            {
                Live_Data.FiltersOn = true;
            }
            else
            {
                Live_Data.FiltersOn = false;
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

        private void TextBoxesToString()
        {
            textBox_Z1.Text = Z1.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_W1.Text = W1.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_Z2.Text = Z2.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_W2.Text = W2.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_Z3.Text = Z3.ToString(CultureInfo.GetCultureInfo("en-US"));
            //textBox_W3.Text = W3.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_Z4.Text = Z4.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_W4.Text = W4.ToString(CultureInfo.GetCultureInfo("en-US"));
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            SelectedListBox.Visible = false;
            SelectedIndeciesListBox.Visible = false;

            Live_Data.SettingsOpen = true;
            // Load saved settings
            RegistryTools.LoadAllSettings(Application.ProductName, this);

            ChecklistBoxLoggingCheckedCheck();
            //ListBoxClearAndWriters();

            TextBoxesToString();
        }

        private void selectFLAll_CheckedChanged(object sender, EventArgs e)
        {
            
            if (selectAll.Checked == true)
            {
                for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
                {
                    checkedListBoxLogging.SetItemChecked(i, selectAll.Checked);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBoxLogging.Items.Count; i++)
                {
                    checkedListBoxLogging.SetItemChecked(i, selectAll.Checked);
                }
            }
            
        }

        private void backToFirstAllDataLoggerPage_Click(object sender, EventArgs e)
        {
            //First_All_Data_Logger_Page fadlp = new First_All_Data_Logger_Page();
            //fadlp.Show();
            this.Close();
        }

        private void checkedListBoxFLLogging_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ReadTextBoxes()
        {
            double z1;
            double z2;
            double z3;
            double z4;

            double w1;
            double w2;
            //double W3;
            double w4;

            if (double.TryParse(textBox_Z1.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out z1) == true
                && double.TryParse(textBox_W1.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out w1) == true
                && double.TryParse(textBox_Z2.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out z2) == true
                && double.TryParse(textBox_W2.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out w2) == true
                && double.TryParse(textBox_Z3.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out z3) == true
                //&& double.TryParse(textBox_W3.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out w3) == true
                && double.TryParse(textBox_Z4.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out z4) == true
                && double.TryParse(textBox_W4.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out w4) == true)
            {
                Z1 = double.Parse(textBox_Z1.Text, CultureInfo.GetCultureInfo("en-US") );
                Z2 = double.Parse(textBox_Z2.Text, CultureInfo.GetCultureInfo("en-US") );
                Z3 = double.Parse(textBox_Z3.Text, CultureInfo.GetCultureInfo("en-US") );
                Z4 = double.Parse(textBox_Z4.Text, CultureInfo.GetCultureInfo("en-US") );
                W4 = double.Parse(textBox_W4.Text, CultureInfo.GetCultureInfo("en-US") );
            }

            
        }

       

        private void ApplyLogSettings_Click(object sender, EventArgs e)
        {
            ChecklistBoxLoggingCheckedCheck();
            //ListBoxClearAndWriters();

            ReadTextBoxes();

            TextBoxesToString();
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
                Live_Data.FiltersOn = true;
            }
            else
            {
                Live_Data.FiltersOn = false;
            }
        }
    }
}
