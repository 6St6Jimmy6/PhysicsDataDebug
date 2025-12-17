using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Media3D;

namespace Physics_Data_Debug
{
    public partial class FormSuspensionStaticValues : Form
    {
        public FormSuspensionStaticValues()
        {
            InitializeComponent();
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
            LiveData.FormSuspensionStaticValuesOpen = false;
        }

        private void FormSuspensionStaticValues_Closing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            LiveData.FormSuspensionStaticValuesOpen = false;
        }
        private void labelSuspensionWrite(Enum prefix,
            Label springRate,
            Label progressiveRate,
            Label bumpLimitsX, Label bumpLimitsY,
            Label reboundLimitsX, Label reboundLimitsY,
            Label bumbDampX, Label bumbDampY,
            Label expansionLimitFromZero, Label compressionLimitFromZero,
            Label reboundRate, Label reboundStartPos, Label reboundEndPos,
            Label bumpStopLength, Label bumpStopRate, Label bumpStopRateGainDeflectionSquared, Label bumpStopDamp, Label bumpStopDampGainDeflectionSquared)
        {
            LiveData.SetValueInLabel(springRate, prefix, WF_Suspension1DataOffset.SpringRate);
            LiveData.SetValueInLabel(progressiveRate, prefix, WF_Suspension1DataOffset.ProgressiveRate);
            LiveData.SetValueInLabel(bumpLimitsX, prefix, WF_Suspension1DataOffset.BumpLimitsX);
            LiveData.SetValueInLabel(bumpLimitsY, prefix, WF_Suspension1DataOffset.BumpLimitsY);
            LiveData.SetValueInLabel(reboundLimitsX, prefix, WF_Suspension1DataOffset.ReboundLimitsX);
            LiveData.SetValueInLabel(reboundLimitsY, prefix, WF_Suspension1DataOffset.ReboundLimitsY);
            LiveData.SetValueInLabel(bumbDampX, prefix, WF_Suspension1DataOffset.BumpDampX);
            LiveData.SetValueInLabel(bumbDampY, prefix, WF_Suspension1DataOffset.BumpDampY);
            LiveData.SetValueInLabel(expansionLimitFromZero, prefix, WF_Suspension1DataOffset.ExpansionLimitFromZero);
            LiveData.SetValueInLabel(compressionLimitFromZero, prefix, WF_Suspension1DataOffset.CompressionLimitFromZero);
            LiveData.SetValueInLabel(reboundRate, prefix, WF_Suspension1DataOffset.ReboundRate);
            LiveData.SetValueInLabel(reboundStartPos, prefix, WF_Suspension1DataOffset.ReboundStartPosition);
            LiveData.SetValueInLabel(reboundEndPos, prefix, WF_Suspension1DataOffset.ReboundEndPosition);
            LiveData.SetValueInLabel(bumpStopLength, prefix, WF_Suspension1DataOffset.BumpStopLength);
            LiveData.SetValueInLabel(bumpStopRate, prefix, WF_Suspension1DataOffset.BumpStopRate);
            LiveData.SetValueInLabel(bumpStopRateGainDeflectionSquared, prefix, WF_Suspension1DataOffset.BumpStopRateGainDeflectionSquared);
            LiveData.SetValueInLabel(bumpStopDamp, prefix, WF_Suspension1DataOffset.BumpStopDamp);
            LiveData.SetValueInLabel(bumpStopDampGainDeflectionSquared, prefix, WF_Suspension1DataOffset.BumpStopDampGainDeflectionSquared);
        }
        private void LabelWrites()
        {
            labelSuspensionWrite(WF_PrefixMain.FL,
                label_FL_SpringRate,
                label_FL_ProgressiveRate,
                label_FL_BumpLimitsX, label_FL_BumpLimitsY,
                label_FL_ReboundLimitsX, label_FL_ReboundLimitsY,
                label_FL_BumpDampX, label_FL_BumpDampY,
                label_FL_ExpansionLimitFromZero, label_FL_CompressionLimitFromZero,
                label_FL_ReboundRate, label_FL_ReboundStartPosition, label_FL_ReboundEndPosition,
                label_FL_BumpStopLength, label_FL_BumpStopRate, label_FL_BumpStopRateGainDeflectionSquared, label_FL_BumpStopDamp, label_FL_BumpStopDampGainDeflectionSquared);
            labelSuspensionWrite(WF_PrefixMain.FR,
                label_FR_SpringRate,
                label_FR_ProgressiveRate,
                label_FR_BumpLimitsX, label_FR_BumpLimitsY,
                label_FR_ReboundLimitsX, label_FR_ReboundLimitsY,
                label_FR_BumpDampX, label_FR_BumpDampY,
                label_FR_ExpansionLimitFromZero, label_FR_CompressionLimitFromZero,
                label_FR_ReboundRate, label_FR_ReboundStartPosition, label_FR_ReboundEndPosition,
                label_FR_BumpStopLength, label_FR_BumpStopRate, label_FR_BumpStopRateGainDeflectionSquared, label_FR_BumpStopDamp, label_FR_BumpStopDampGainDeflectionSquared);
            labelSuspensionWrite(WF_PrefixMain.RL,
                label_RL_SpringRate,
                label_RL_ProgressiveRate,
                label_RL_BumpLimitsX, label_RL_BumpLimitsY,
                label_RL_ReboundLimitsX, label_RL_ReboundLimitsY,
                label_RL_BumpDampX, label_RL_BumpDampY,
                label_RL_ExpansionLimitFromZero, label_RL_CompressionLimitFromZero,
                label_RL_ReboundRate, label_RL_ReboundStartPosition, label_RL_ReboundEndPosition,
                label_RL_BumpStopLength, label_RL_BumpStopRate, label_RL_BumpStopRateGainDeflectionSquared, label_RL_BumpStopDamp, label_RL_BumpStopDampGainDeflectionSquared);
            labelSuspensionWrite(WF_PrefixMain.RR,
                label_RR_SpringRate,
                label_RR_ProgressiveRate,
                label_RR_BumpLimitsX, label_RR_BumpLimitsY,
                label_RR_ReboundLimitsX, label_RR_ReboundLimitsY,
                label_RR_BumpDampX, label_RR_BumpDampY,
                label_RR_ExpansionLimitFromZero, label_RR_CompressionLimitFromZero,
                label_RR_ReboundRate, label_RR_ReboundStartPosition, label_RR_ReboundEndPosition,
                label_RR_BumpStopLength, label_RR_BumpStopRate, label_RR_BumpStopRateGainDeflectionSquared, label_RR_BumpStopDamp, label_RR_BumpStopDampGainDeflectionSquared);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process != null && FormLiveData.ProcessGet == true && FormLiveData.FirstTimeLoad == true && LiveData.FullDataList.Count > 0 && FormLiveData.ValuesGet == true)
            {
                LabelWrites();
            }
        }
    }
}
