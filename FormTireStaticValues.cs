using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Physics_Data_Debug
{
    public partial class FormTireStaticValues : Form
    {
        public FormTireStaticValues()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 100;
        }
        private void FormTireStaticValues_Load(object sender, EventArgs e)
        {
            LiveData.FormTireStaticValues = true;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ReadData()
        {
            labelTireWrite(WF_PrefixMain.FL, label_FL_Radius, label_FL_Width, label_FL_ThermalAirTransfer, label_FL_ThermalInnerTransfer, label_FL_SpringRate, label_FL_DamperRate, label_FL_MaxDeflection, label_FL_Mass, label_FL_MomentOfInertia);
            labelTireWrite(WF_PrefixMain.FR, label_FR_Radius, label_FR_Width, label_FR_ThermalAirTransfer, label_FR_ThermalInnerTransfer, label_FR_SpringRate, label_FR_DamperRate, label_FR_MaxDeflection, label_FR_Mass, label_FR_MomentOfInertia);
            labelTireWrite(WF_PrefixMain.RL, label_RL_Radius, label_RL_Width, label_RL_ThermalAirTransfer, label_RL_ThermalInnerTransfer, label_RL_SpringRate, label_RL_DamperRate, label_RL_MaxDeflection, label_RL_Mass, label_RL_MomentOfInertia);
            labelTireWrite(WF_PrefixMain.RR, label_RR_Radius, label_RR_Width, label_RR_ThermalAirTransfer, label_RR_ThermalInnerTransfer, label_RR_SpringRate, label_RR_DamperRate, label_RR_MaxDeflection, label_RR_Mass, label_RR_MomentOfInertia);
        }
        private void labelTireWrite(Enum prefix,
            Label radius, Label width, Label thermalAirTransfer, Label thermalInnerTransfer, Label springRate, Label damperRate, Label maxDeflection, Label mass, Label momentOfInertia)
        {
            LiveData.SetValueInLabel(radius, prefix, WF_TireDataOffset.TireRadius);
            LiveData.SetValueInLabel(width, prefix, WF_TireDataOffset.TireWidth);
            LiveData.SetValueInLabel(thermalAirTransfer, prefix, WF_TireDataOffset.ThermalAirTransfer);
            LiveData.SetValueInLabel(thermalInnerTransfer, prefix, WF_TireDataOffset.ThermalInnerTransfer);
            LiveData.SetValueInLabel(springRate, prefix, WF_TireDataOffset.TireSpringRate);
            LiveData.SetValueInLabel(damperRate, prefix, WF_TireDataOffset.TireDamperRate);
            LiveData.SetValueInLabel(maxDeflection, prefix, WF_TireDataOffset.TireMaxDeflection);
            LiveData.SetValueInLabel(mass, prefix, WF_TireDataOffset.TireMass);
            LiveData.SetValueInLabel(momentOfInertia, prefix, WF_TireDataOffset.MomentOfInertia);
        }
        private void CheckKeyIsNumberOrDecimalPoint(KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if (!Char.IsDigit(ch1) && ch1 != 8 && ch1 != 46/* && ch1 != 44*/)
            {
                e.Handled = true;
            }
        }
        private void FormTireStaticValues_Close(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            LiveData.FormTireStaticValues = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process != null && FormLiveData.ProcessGet == true && FormLiveData.FirstTimeLoad == true && LiveData.FullDataList.Count > 0 && FormLiveData.ValuesGet == true)
            {
                ReadData();
            }
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
