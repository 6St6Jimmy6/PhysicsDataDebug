using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormSuspensionStaticValues : Form
    {
        public FormSuspensionStaticValues()
        {
            InitializeComponent();

            textBox_FL_SpringRate.ReadOnly = true;
            textBox_FL_ProgressiveRate.ReadOnly = true;
            textBox_FL_BumpLimitsX.ReadOnly = true; textBox_FL_BumpLimitsY.ReadOnly = true;
            textBox_FL_ReboundLimitsX.ReadOnly = true; textBox_FL_ReboundLimitsY.ReadOnly = true;
            textBox_FL_BumpDampX.ReadOnly = true; textBox_FL_BumpDampY.ReadOnly = true;
            textBox_FL_ExpansionLimitFromZero.ReadOnly = true; textBox_FL_CompressionLimitFromZero.ReadOnly = true;
            textBox_FL_ReboundRate.ReadOnly = true; textBox_FL_ReboundStartPosition.ReadOnly = true; textBox_FL_ReboundEndPosition.ReadOnly = true;
            textBox_FL_BumpStopLength.ReadOnly = true; textBox_FL_BumpStopRate.ReadOnly = true; textBox_FL_BumpStopRateGainDeflectionSquared.ReadOnly = true; textBox_FL_BumpStopDamp.ReadOnly = true; textBox_FL_BumpStopDampGainDeflectionSquared.ReadOnly = true;

            textBox_FR_SpringRate.ReadOnly = true;
            textBox_FR_ProgressiveRate.ReadOnly = true;
            textBox_FR_BumpLimitsX.ReadOnly = true; textBox_FR_BumpLimitsY.ReadOnly = true;
            textBox_FR_ReboundLimitsX.ReadOnly = true; textBox_FR_ReboundLimitsY.ReadOnly = true;
            textBox_FR_BumpDampX.ReadOnly = true; textBox_FR_BumpDampY.ReadOnly = true;
            textBox_FR_ExpansionLimitFromZero.ReadOnly = true; textBox_FR_CompressionLimitFromZero.ReadOnly = true;
            textBox_FR_ReboundRate.ReadOnly = true; textBox_FR_ReboundStartPosition.ReadOnly = true; textBox_FR_ReboundEndPosition.ReadOnly = true;
            textBox_FR_BumpStopLength.ReadOnly = true; textBox_FR_BumpStopRate.ReadOnly = true; textBox_FR_BumpStopRateGainDeflectionSquared.ReadOnly = true; textBox_FR_BumpStopDamp.ReadOnly = true; textBox_FR_BumpStopDampGainDeflectionSquared.ReadOnly = true;

            textBox_RL_SpringRate.ReadOnly = true;
            textBox_RL_ProgressiveRate.ReadOnly = true;
            textBox_RL_BumpLimitsX.ReadOnly = true; textBox_RL_BumpLimitsY.ReadOnly = true;
            textBox_RL_ReboundLimitsX.ReadOnly = true; textBox_RL_ReboundLimitsY.ReadOnly = true;
            textBox_RL_BumpDampX.ReadOnly = true; textBox_RL_BumpDampY.ReadOnly = true;
            textBox_RL_ExpansionLimitFromZero.ReadOnly = true; textBox_RL_CompressionLimitFromZero.ReadOnly = true;
            textBox_RL_ReboundRate.ReadOnly = true; textBox_RL_ReboundStartPosition.ReadOnly = true; textBox_RL_ReboundEndPosition.ReadOnly = true;
            textBox_RL_BumpStopLength.ReadOnly = true; textBox_RL_BumpStopRate.ReadOnly = true; textBox_RL_BumpStopRateGainDeflectionSquared.ReadOnly = true; textBox_RL_BumpStopDamp.ReadOnly = true; textBox_RL_BumpStopDampGainDeflectionSquared.ReadOnly = true;

            textBox_RR_SpringRate.ReadOnly = true;
            textBox_RR_ProgressiveRate.ReadOnly = true;
            textBox_RR_BumpLimitsX.ReadOnly = true; textBox_RR_BumpLimitsY.ReadOnly = true;
            textBox_RR_ReboundLimitsX.ReadOnly = true; textBox_RR_ReboundLimitsY.ReadOnly = true;
            textBox_RR_BumpDampX.ReadOnly = true; textBox_RR_BumpDampY.ReadOnly = true;
            textBox_RR_ExpansionLimitFromZero.ReadOnly = true; textBox_RR_CompressionLimitFromZero.ReadOnly = true;
            textBox_RR_ReboundRate.ReadOnly = true; textBox_RR_ReboundStartPosition.ReadOnly = true; textBox_RR_ReboundEndPosition.ReadOnly = true;
            textBox_RR_BumpStopLength.ReadOnly = true; textBox_RR_BumpStopRate.ReadOnly = true; textBox_RR_BumpStopRateGainDeflectionSquared.ReadOnly = true; textBox_RR_BumpStopDamp.ReadOnly = true; textBox_RR_BumpStopDampGainDeflectionSquared.ReadOnly = true;

            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void FormSuspensionStaticValues_Load(object sender, EventArgs e)
        {
            LiveData.FormSuspensionStaticValuesOpen = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuspensionStaticValues_Closing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            LiveData.FormSuspensionStaticValuesOpen = false;
        }
        private void textBoxSuspensionWrite(Enum prefix,
            TextBox springRate, 
            TextBox progressiveRate, 
            TextBox bumpLimitsX, TextBox bumpLimitsY, 
            TextBox reboundLimitsX, TextBox reboundLimitsY, 
            TextBox bumbDampX, TextBox bumbDampY, 
            TextBox expansionLimitFromZero, TextBox compressionLimitFromZero, 
            TextBox reboundRate, TextBox reboundStartPos, TextBox reboundEndPos, 
            TextBox bumpStopLength, TextBox bumpStopRate, TextBox bumpStopRateGainDeflectionSquared, TextBox bumpStopDamp, TextBox bumpStopDampGainDeflectionSquared)
        {
            LiveData.SetValueInTB(springRate, prefix, WF_SuspensionDataOffset.SpringRate);
            LiveData.SetValueInTB(progressiveRate, prefix, WF_SuspensionDataOffset.ProgressiveRate);
            LiveData.SetValueInTB(bumpLimitsX, prefix, WF_SuspensionDataOffset.BumpLimitsX);
            LiveData.SetValueInTB(bumpLimitsY, prefix, WF_SuspensionDataOffset.BumpLimitsY);
            LiveData.SetValueInTB(reboundLimitsX, prefix, WF_SuspensionDataOffset.ReboundLimitsX);
            LiveData.SetValueInTB(reboundLimitsY, prefix, WF_SuspensionDataOffset.ReboundLimitsY);
            LiveData.SetValueInTB(bumbDampX, prefix, WF_SuspensionDataOffset.BumpDampX);
            LiveData.SetValueInTB(bumbDampY, prefix, WF_SuspensionDataOffset.BumpDampY);
            LiveData.SetValueInTB(expansionLimitFromZero, prefix, WF_SuspensionDataOffset.ExpansionLimitFromZero);
            LiveData.SetValueInTB(compressionLimitFromZero, prefix, WF_SuspensionDataOffset.CompressionLimitFromZero);
            LiveData.SetValueInTB(reboundRate, prefix, WF_SuspensionDataOffset.ReboundRate);
            LiveData.SetValueInTB(reboundStartPos, prefix, WF_SuspensionDataOffset.ReboundStartPosition);
            LiveData.SetValueInTB(reboundEndPos, prefix, WF_SuspensionDataOffset.ReboundEndPosition);
            LiveData.SetValueInTB(bumpStopLength, prefix, WF_SuspensionDataOffset.BumpStopLength);
            LiveData.SetValueInTB(bumpStopRate, prefix, WF_SuspensionDataOffset.BumpStopRate);
            LiveData.SetValueInTB(bumpStopRateGainDeflectionSquared, prefix, WF_SuspensionDataOffset.BumpStopRateGainDeflectionSquared);
            LiveData.SetValueInTB(bumpStopDamp, prefix, WF_SuspensionDataOffset.BumpStopDamp);
            LiveData.SetValueInTB(bumpStopDampGainDeflectionSquared, prefix, WF_SuspensionDataOffset.BumpStopDampGainDeflectionSquared);
        }
        private void ReadData()
        {
            textBoxSuspensionWrite(WF_Prefix.FL, 
                textBox_FL_SpringRate, 
                textBox_FL_ProgressiveRate, 
                textBox_FL_BumpLimitsX, textBox_FL_BumpLimitsY,
                textBox_FL_ReboundLimitsX, textBox_FL_ReboundLimitsY,
                textBox_FL_BumpDampX, textBox_FL_BumpDampY,
                textBox_FL_ExpansionLimitFromZero, textBox_FL_CompressionLimitFromZero,
                textBox_FL_ReboundRate, textBox_FL_ReboundStartPosition, textBox_FL_ReboundEndPosition,
                textBox_FL_BumpStopLength, textBox_FL_BumpStopRate, textBox_FL_BumpStopRateGainDeflectionSquared, textBox_FL_BumpStopDamp, textBox_FL_BumpStopDampGainDeflectionSquared);
            textBoxSuspensionWrite(WF_Prefix.FR,
                textBox_FR_SpringRate,
                textBox_FR_ProgressiveRate,
                textBox_FR_BumpLimitsX, textBox_FR_BumpLimitsY,
                textBox_FR_ReboundLimitsX, textBox_FR_ReboundLimitsY,
                textBox_FR_BumpDampX, textBox_FR_BumpDampY,
                textBox_FR_ExpansionLimitFromZero, textBox_FR_CompressionLimitFromZero,
                textBox_FR_ReboundRate, textBox_FR_ReboundStartPosition, textBox_FR_ReboundEndPosition,
                textBox_FR_BumpStopLength, textBox_FR_BumpStopRate, textBox_FR_BumpStopRateGainDeflectionSquared, textBox_FR_BumpStopDamp, textBox_FR_BumpStopDampGainDeflectionSquared);
            textBoxSuspensionWrite(WF_Prefix.RL,
                textBox_RL_SpringRate,
                textBox_RL_ProgressiveRate,
                textBox_RL_BumpLimitsX, textBox_RL_BumpLimitsY,
                textBox_RL_ReboundLimitsX, textBox_RL_ReboundLimitsY,
                textBox_RL_BumpDampX, textBox_RL_BumpDampY,
                textBox_RL_ExpansionLimitFromZero, textBox_RL_CompressionLimitFromZero,
                textBox_RL_ReboundRate, textBox_RL_ReboundStartPosition, textBox_RL_ReboundEndPosition,
                textBox_RL_BumpStopLength, textBox_RL_BumpStopRate, textBox_RL_BumpStopRateGainDeflectionSquared, textBox_RL_BumpStopDamp, textBox_RL_BumpStopDampGainDeflectionSquared);
            textBoxSuspensionWrite(WF_Prefix.RR,
                textBox_RR_SpringRate,
                textBox_RR_ProgressiveRate,
                textBox_RR_BumpLimitsX, textBox_RR_BumpLimitsY,
                textBox_RR_ReboundLimitsX, textBox_RR_ReboundLimitsY,
                textBox_RR_BumpDampX, textBox_RR_BumpDampY,
                textBox_RR_ExpansionLimitFromZero, textBox_RR_CompressionLimitFromZero,
                textBox_RR_ReboundRate, textBox_RR_ReboundStartPosition, textBox_RR_ReboundEndPosition,
                textBox_RR_BumpStopLength, textBox_RR_BumpStopRate, textBox_RR_BumpStopRateGainDeflectionSquared, textBox_RR_BumpStopDamp, textBox_RR_BumpStopDampGainDeflectionSquared);
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
