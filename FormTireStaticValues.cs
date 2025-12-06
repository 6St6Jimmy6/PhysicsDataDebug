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

            textBox_FL_Radius.ReadOnly = true; textBox_FL_Width.ReadOnly = true; textBox_FL_ThermalAirTransfer.ReadOnly = true; textBox_FL_ThermalInnerTransfer.ReadOnly = true; textBox_FL_SpringRate.ReadOnly = true; textBox_FL_DamperRate.ReadOnly = true; textBox_FL_MaxDeflection.ReadOnly = true; textBox_FL_Mass.ReadOnly = true; textBox_FL_MomentOfInertia.ReadOnly = true;
            textBox_FR_Radius.ReadOnly = true; textBox_FR_Width.ReadOnly = true; textBox_FR_ThermalAirTransfer.ReadOnly = true; textBox_FR_ThermalInnerTransfer.ReadOnly = true; textBox_FR_SpringRate.ReadOnly = true; textBox_FR_DamperRate.ReadOnly = true; textBox_FR_MaxDeflection.ReadOnly = true; textBox_FR_Mass.ReadOnly = true; textBox_FR_MomentOfInertia.ReadOnly = true;
            textBox_RL_Radius.ReadOnly = true; textBox_RL_Width.ReadOnly = true; textBox_RL_ThermalAirTransfer.ReadOnly = true; textBox_RL_ThermalInnerTransfer.ReadOnly = true; textBox_RL_SpringRate.ReadOnly = true; textBox_RL_DamperRate.ReadOnly = true; textBox_RL_MaxDeflection.ReadOnly = true; textBox_RL_Mass.ReadOnly = true; textBox_RL_MomentOfInertia.ReadOnly = true;
            textBox_RR_Radius.ReadOnly = true; textBox_RR_Width.ReadOnly = true; textBox_RR_ThermalAirTransfer.ReadOnly = true; textBox_RR_ThermalInnerTransfer.ReadOnly = true; textBox_RR_SpringRate.ReadOnly = true; textBox_RR_DamperRate.ReadOnly = true; textBox_RR_MaxDeflection.ReadOnly = true; textBox_RR_Mass.ReadOnly = true; textBox_RR_MomentOfInertia.ReadOnly = true;
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
            textBoxTireWrite(WF_Prefix.FL, textBox_FL_Radius, textBox_FL_Width, textBox_FL_ThermalAirTransfer, textBox_FL_ThermalInnerTransfer, textBox_FL_SpringRate, textBox_FL_DamperRate, textBox_FL_MaxDeflection, textBox_FL_Mass, textBox_FL_MomentOfInertia);
            textBoxTireWrite(WF_Prefix.FR, textBox_FR_Radius, textBox_FR_Width, textBox_FR_ThermalAirTransfer, textBox_FR_ThermalInnerTransfer, textBox_FR_SpringRate, textBox_FR_DamperRate, textBox_FR_MaxDeflection, textBox_FR_Mass, textBox_FR_MomentOfInertia);
            textBoxTireWrite(WF_Prefix.RL, textBox_RL_Radius, textBox_RL_Width, textBox_RL_ThermalAirTransfer, textBox_RL_ThermalInnerTransfer, textBox_RL_SpringRate, textBox_RL_DamperRate, textBox_RL_MaxDeflection, textBox_RL_Mass, textBox_RL_MomentOfInertia);
            textBoxTireWrite(WF_Prefix.RR, textBox_RR_Radius, textBox_RR_Width, textBox_RR_ThermalAirTransfer, textBox_RR_ThermalInnerTransfer, textBox_RR_SpringRate, textBox_RR_DamperRate, textBox_RR_MaxDeflection, textBox_RR_Mass, textBox_RR_MomentOfInertia);
        }
        private void textBoxTireWrite(Enum prefix,  
            TextBox radius, TextBox width, TextBox thermalAirTransfer, TextBox thermalInnerTransfer, TextBox springRate, TextBox damperRate, TextBox maxDeflection, TextBox mass, TextBox momentOfInertia)
        {
            LiveData.SetValueInTB(radius, prefix, WF_TireDataOffset.TireRadius);
            LiveData.SetValueInTB(width, prefix, WF_TireDataOffset.TireWidth);
            LiveData.SetValueInTB(thermalAirTransfer, prefix, WF_TireDataOffset.ThermalAirTransfer);
            LiveData.SetValueInTB(thermalInnerTransfer, prefix, WF_TireDataOffset.ThermalInnerTransfer);
            LiveData.SetValueInTB(springRate, prefix, WF_TireDataOffset.TireSpringRate);
            LiveData.SetValueInTB(damperRate, prefix, WF_TireDataOffset.TireDamperRate);
            LiveData.SetValueInTB(maxDeflection, prefix, WF_TireDataOffset.TireMaxDeflection);
            LiveData.SetValueInTB(mass, prefix, WF_TireDataOffset.TireMass);
            LiveData.SetValueInTB(momentOfInertia, prefix, WF_TireDataOffset.MomentOfInertia);
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
