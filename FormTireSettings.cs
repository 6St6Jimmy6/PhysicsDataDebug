using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Physics_Data_Debug
{
    public partial class FormTireSettings : Form
    {
        public FormTireSettings()
        {
            InitializeComponent();
        }
        private void TireSettings_Load(object sender, EventArgs e)
        {
            LiveData.TireSettingsOpen = true;
            timer1.Enabled = true;
            ReadData();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReadData()
        {
            textBoxTireWrite(WF_Prefix.FL, textBox_FL_Radius, textBox_FL_Width, textBox_FL_ThermalAirTransfer, textBox_FL_ThermalInnerTransfer, textBox_FL_SpringRate, textBox_FL_DamperRate, textBox_FL_MaxDeflection, textBox_FL_Mass, textBox_FL_MomentOfInertia);
            textBoxTireWrite(WF_Prefix.FR, textBox_FR_Radius, textBox_FR_Width, textBox_FR_ThermalAirTransfer, textBox_FR_ThermalInnerTransfer, textBox_FR_SpringRate, textBox_FR_DamperRate, textBox_FR_MaxDeflection, textBox_FR_Mass, textBox_FR_MomentOfInertia);
            textBoxTireWrite(WF_Prefix.RL, textBox_RL_Radius, textBox_RL_Width, textBox_RL_ThermalAirTransfer, textBox_RL_ThermalInnerTransfer, textBox_RL_SpringRate, textBox_RL_DamperRate, textBox_RL_MaxDeflection, textBox_RL_Mass, textBox_RL_MomentOfInertia);
            textBoxTireWrite(WF_Prefix.RR, textBox_RR_Radius, textBox_RR_Width, textBox_RR_ThermalAirTransfer, textBox_RR_ThermalInnerTransfer, textBox_RR_SpringRate, textBox_RR_DamperRate, textBox_RR_MaxDeflection, textBox_RR_Mass, textBox_RR_MomentOfInertia);
        }
        private void textBoxTireWrite(Enum prefix,  
            TextBox radius, TextBox width, TextBox thermalAirTransfer, TextBox thermalInnerTransfer, TextBox springRate, TextBox damperRate, TextBox maxDeflection, TextBox mass, TextBox momentOfInertia)
        {
            //int index = tireDataList.FindIndex(r => r.Name == s + WF_TireDataOffset.TireRadius);
            radius.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.TireRadius).ToString(CultureInfo.GetCultureInfo("en-US"));
            width.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.TireWidth).ToString(CultureInfo.GetCultureInfo("en-US"));
            thermalAirTransfer.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.ThermalAirTransfer).ToString(CultureInfo.GetCultureInfo("en-US"));
            thermalInnerTransfer.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.ThermalInnerTransfer).ToString(CultureInfo.GetCultureInfo("en-US"));
            springRate.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.TireSpringRate).ToString(CultureInfo.GetCultureInfo("en-US"));
            damperRate.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.TireDamperRate).ToString(CultureInfo.GetCultureInfo("en-US"));
            maxDeflection.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.TireMaxDeflection).ToString(CultureInfo.GetCultureInfo("en-US"));
            mass.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.TireMass).ToString(CultureInfo.GetCultureInfo("en-US"));
            momentOfInertia.Text = LiveData.GetFullListDataValue(prefix, WF_TireDataOffset.MomentOfInertia).ToString(CultureInfo.GetCultureInfo("en-US"));
        }
        private void CheckKeyIsNumberOrDecimalPoint(KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if (!Char.IsDigit(ch1) && ch1 != 8 && ch1 != 46/* && ch1 != 44*/)
            {
                e.Handled = true;
            }
        }
        private void TireSettings_Close(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            LiveData.TireSettingsOpen = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadData();
        }
        #region FL TextBoxes
        private void textBox_FL_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FL_Radius_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_Width_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_ThermalAirTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_ThermalInnerTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_SpringRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_DamperRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_MaxDeflection_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_Mass_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FL_MomentOfInertia_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion
        #region FR TextBoxes
        private void textBox_FR_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_FR_Radius_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_Width_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_ThermalAirTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_ThermalInnerTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_SpringRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_DamperRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_MaxDeflection_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_Mass_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_FR_MomentOfInertia_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion
        #region RL TextBoxes
        private void textBox_RL_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RL_Radius_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_Width_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_ThermalAirTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_ThermalInnerTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_SpringRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_DamperRate_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void textBox_RL_MaxDeflection_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_Mass_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RL_MomentOfInertia_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion
        #region RR TextBoxes
        private void textBox_RR_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }
        private void textBox_RR_Radius_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_Width_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_ThermalAirTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_ThermalInnerTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_SpringRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_DamperRate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_MaxDeflection_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_Mass_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void textBox_RR_MomentOfInertia_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion
    }
}
