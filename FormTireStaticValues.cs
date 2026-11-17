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
            labelTireWrite(TelemetryPrefix.FL, label_FL_Radius, label_FL_Width, label_FL_ThermalAirTransfer, label_FL_ThermalInnerTransfer, label_FL_SpringRate, label_FL_DamperRate, label_FL_MaxDeflection, label_FL_Mass, label_FL_MomentOfInertia);
            labelTireWrite(TelemetryPrefix.FR, label_FR_Radius, label_FR_Width, label_FR_ThermalAirTransfer, label_FR_ThermalInnerTransfer, label_FR_SpringRate, label_FR_DamperRate, label_FR_MaxDeflection, label_FR_Mass, label_FR_MomentOfInertia);
            labelTireWrite(TelemetryPrefix.RL, label_RL_Radius, label_RL_Width, label_RL_ThermalAirTransfer, label_RL_ThermalInnerTransfer, label_RL_SpringRate, label_RL_DamperRate, label_RL_MaxDeflection, label_RL_Mass, label_RL_MomentOfInertia);
            labelTireWrite(TelemetryPrefix.RR, label_RR_Radius, label_RR_Width, label_RR_ThermalAirTransfer, label_RR_ThermalInnerTransfer, label_RR_SpringRate, label_RR_DamperRate, label_RR_MaxDeflection, label_RR_Mass, label_RR_MomentOfInertia);
        }
        private void labelTireWrite(string prefix,
            Label radius, Label width, Label thermalAirTransfer, Label thermalInnerTransfer, Label springRate, Label damperRate, Label maxDeflection, Label mass, Label momentOfInertia)
        {
            LiveData.SetValueInLabel(radius, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "TireRadius"));
            LiveData.SetValueInLabel(width, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "TireWidth"));
            LiveData.SetValueInLabel(thermalAirTransfer, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "ThermalAirTransfer"));
            LiveData.SetValueInLabel(thermalInnerTransfer, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "ThermalInnerTransfer"));
            LiveData.SetValueInLabel(springRate, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "TireSpringRate"));
            LiveData.SetValueInLabel(damperRate, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "TireDamperRate"));
            LiveData.SetValueInLabel(maxDeflection, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "TireMaxDeflection"));
            LiveData.SetValueInLabel(mass, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "TireMass"));
            LiveData.SetValueInLabel(momentOfInertia, prefix, GameMemoryConfig.Field("WF_TireDataOffset", "MomentOfInertia"));
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
    }
}
