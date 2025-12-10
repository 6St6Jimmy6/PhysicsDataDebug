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
            textBox_FL_SuspensionGeometry.Visible = true;
            textBox_FR_SuspensionGeometry.Visible = true;
            textBox_RL_SuspensionGeometry.Visible = true;
            textBox_RR_SuspensionGeometry.Visible = true;

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
            LiveData.SetValueInTB(springRate, prefix, WF_Suspension1DataOffset.SpringRate);
            LiveData.SetValueInTB(progressiveRate, prefix, WF_Suspension1DataOffset.ProgressiveRate);
            LiveData.SetValueInTB(bumpLimitsX, prefix, WF_Suspension1DataOffset.BumpLimitsX);
            LiveData.SetValueInTB(bumpLimitsY, prefix, WF_Suspension1DataOffset.BumpLimitsY);
            LiveData.SetValueInTB(reboundLimitsX, prefix, WF_Suspension1DataOffset.ReboundLimitsX);
            LiveData.SetValueInTB(reboundLimitsY, prefix, WF_Suspension1DataOffset.ReboundLimitsY);
            LiveData.SetValueInTB(bumbDampX, prefix, WF_Suspension1DataOffset.BumpDampX);
            LiveData.SetValueInTB(bumbDampY, prefix, WF_Suspension1DataOffset.BumpDampY);
            LiveData.SetValueInTB(expansionLimitFromZero, prefix, WF_Suspension1DataOffset.ExpansionLimitFromZero);
            LiveData.SetValueInTB(compressionLimitFromZero, prefix, WF_Suspension1DataOffset.CompressionLimitFromZero);
            LiveData.SetValueInTB(reboundRate, prefix, WF_Suspension1DataOffset.ReboundRate);
            LiveData.SetValueInTB(reboundStartPos, prefix, WF_Suspension1DataOffset.ReboundStartPosition);
            LiveData.SetValueInTB(reboundEndPos, prefix, WF_Suspension1DataOffset.ReboundEndPosition);
            LiveData.SetValueInTB(bumpStopLength, prefix, WF_Suspension1DataOffset.BumpStopLength);
            LiveData.SetValueInTB(bumpStopRate, prefix, WF_Suspension1DataOffset.BumpStopRate);
            LiveData.SetValueInTB(bumpStopRateGainDeflectionSquared, prefix, WF_Suspension1DataOffset.BumpStopRateGainDeflectionSquared);
            LiveData.SetValueInTB(bumpStopDamp, prefix, WF_Suspension1DataOffset.BumpStopDamp);
            LiveData.SetValueInTB(bumpStopDampGainDeflectionSquared, prefix, WF_Suspension1DataOffset.BumpStopDampGainDeflectionSquared);
        }
        private void SuspensionGeometry(Enum side, bool isStatic, float rideHeight = 0)
        {
            float StaticTirePivotX = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotX);
            float StaticTirePivotY = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotY) + rideHeight;
            float StaticTirePivotZ = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotZ);

            float StaticBodyUpperFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperFrontArmX);
            float StaticBodyUpperFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperFrontArmY) + rideHeight;
            float StaticBodyUpperFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperFrontArmZ);
            float StaticSpindleUpperFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX) + StaticTirePivotX;
            float StaticSpindleUpperFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY) + StaticTirePivotY;
            float StaticSpindleUpperFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ) + StaticTirePivotZ;

            float StaticBodyUpperRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperRearArmX);
            float StaticBodyUpperRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperRearArmY) + rideHeight;
            float StaticBodyUpperRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperRearArmZ);
            float StaticSpindleUpperRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX) + StaticTirePivotX;
            float StaticSpindleUpperRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY) + StaticTirePivotY;
            float StaticSpindleUpperRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ) + StaticTirePivotZ;

            float StaticBodyLowerFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerFrontArmX);
            float StaticBodyLowerFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerFrontArmY) + rideHeight;
            float StaticBodyLowerFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerFrontArmZ);
            float StaticSpindleLowerFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX) + StaticTirePivotX;
            float StaticSpindleLowerFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY) + StaticTirePivotY;
            float StaticSpindleLowerFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ) + StaticTirePivotZ;

            float StaticBodyLowerRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerRearArmX);
            float StaticBodyLowerRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerRearArmY) + rideHeight;
            float StaticBodyLowerRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerRearArmZ);
            float StaticSpindleLowerRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX) + StaticTirePivotX;
            float StaticSpindleLowerRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY) + StaticTirePivotY;
            float StaticSpindleLowerRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ) + StaticTirePivotZ;

            float DynamicTirePivotX = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM41);
            float DynamicTirePivotY = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM42) + rideHeight;
            float DynamicTirePivotZ = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM43);

            float DynamicSpindleUpperFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX) + DynamicTirePivotX;
            float DynamicSpindleUpperFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY) + DynamicTirePivotY;
            float DynamicSpindleUpperFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ) + DynamicTirePivotZ;

            float DynamicSpindleUpperRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX) + DynamicTirePivotX;
            float DynamicSpindleUpperRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY) + DynamicTirePivotY;
            float DynamicSpindleUpperRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ) + DynamicTirePivotZ;

            float DynamicSpindleLowerFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX) + DynamicTirePivotX;
            float DynamicSpindleLowerFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY) + DynamicTirePivotY;
            float DynamicSpindleLowerFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ) + DynamicTirePivotZ;

            float DynamicSpindleLowerRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX) + DynamicTirePivotX;
            float DynamicSpindleLowerRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY) + DynamicTirePivotY;
            float DynamicSpindleLowerRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ) + DynamicTirePivotZ;

            chart1.Series["RideHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart1.Series["RideHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + rideHeight };

            string TirePivotXY = side + "TirePivotXY";
            if (isStatic == true)
            {
                chart1.Series[TirePivotXY].Points[0].XValue = StaticTirePivotX;
                chart1.Series[TirePivotXY].Points[0].YValues = new double[] { StaticTirePivotY };
            }
            else
            {
                chart1.Series[TirePivotXY].Points[0].XValue = DynamicTirePivotX;
                chart1.Series[TirePivotXY].Points[0].YValues = new double[] { DynamicTirePivotY };
            }

            string UpperFrontArmXY = side + "UpperFrontArmXY";
            chart1.Series[UpperFrontArmXY].Points[0].XValue = StaticBodyUpperFrontArmX;
            chart1.Series[UpperFrontArmXY].Points[0].YValues = new double[] { StaticBodyUpperFrontArmY };
            if (isStatic == true)
            {
                chart1.Series[UpperFrontArmXY].Points[1].XValue = StaticSpindleUpperFrontArmX;
                chart1.Series[UpperFrontArmXY].Points[1].YValues = new double[] { StaticSpindleUpperFrontArmY };
            }
            else
            {
                chart1.Series[UpperFrontArmXY].Points[1].XValue = DynamicSpindleUpperFrontArmX;
                chart1.Series[UpperFrontArmXY].Points[1].YValues = new double[] { DynamicSpindleUpperFrontArmY };
            }

            string UpperRearArmXY = side + "UpperRearArmXY";
            chart1.Series[UpperRearArmXY].Points[0].XValue = StaticBodyUpperRearArmX;
            chart1.Series[UpperRearArmXY].Points[0].YValues = new double[] { StaticBodyUpperRearArmY };
            if (isStatic == true)
            {
                chart1.Series[UpperRearArmXY].Points[1].XValue = StaticSpindleUpperRearArmX;
                chart1.Series[UpperRearArmXY].Points[1].YValues = new double[] { StaticSpindleUpperRearArmY };
            }
            else
            {
                chart1.Series[UpperRearArmXY].Points[1].XValue = DynamicSpindleUpperRearArmX;
                chart1.Series[UpperRearArmXY].Points[1].YValues = new double[] { DynamicSpindleUpperRearArmY };
            }

            string LowerFrontArmXY = side + "LowerFrontArmXY";
            chart1.Series[LowerFrontArmXY].Points[0].XValue = StaticBodyLowerFrontArmX;
            chart1.Series[LowerFrontArmXY].Points[0].YValues = new double[] { StaticBodyLowerFrontArmY };
            if (isStatic == true)
            {
                chart1.Series[LowerFrontArmXY].Points[1].XValue = StaticSpindleLowerFrontArmX;
                chart1.Series[LowerFrontArmXY].Points[1].YValues = new double[] { StaticSpindleLowerFrontArmY };
            }
            else
            {
                chart1.Series[LowerFrontArmXY].Points[1].XValue = DynamicSpindleLowerFrontArmX;
                chart1.Series[LowerFrontArmXY].Points[1].YValues = new double[] { DynamicSpindleLowerFrontArmY };
            }

            string LowerRearArmXY = side + "LowerRearArmXY";
            chart1.Series[LowerRearArmXY].Points[0].XValue = StaticBodyLowerRearArmX;
            chart1.Series[LowerRearArmXY].Points[0].YValues = new double[] { StaticBodyLowerRearArmY };
            if (isStatic == true)
            {
                chart1.Series[LowerRearArmXY].Points[1].XValue = StaticSpindleLowerRearArmX;
                chart1.Series[LowerRearArmXY].Points[1].YValues = new double[] { StaticSpindleLowerRearArmY };
            }
            else
            {
                chart1.Series[LowerRearArmXY].Points[1].XValue = DynamicSpindleLowerRearArmX;
                chart1.Series[LowerRearArmXY].Points[1].YValues = new double[] { DynamicSpindleLowerRearArmY };
            }
        }
        private void ReadData()
        {
            textBoxSuspensionWrite(WF_PrefixMain.FL, 
                textBox_FL_SpringRate, 
                textBox_FL_ProgressiveRate, 
                textBox_FL_BumpLimitsX, textBox_FL_BumpLimitsY,
                textBox_FL_ReboundLimitsX, textBox_FL_ReboundLimitsY,
                textBox_FL_BumpDampX, textBox_FL_BumpDampY,
                textBox_FL_ExpansionLimitFromZero, textBox_FL_CompressionLimitFromZero,
                textBox_FL_ReboundRate, textBox_FL_ReboundStartPosition, textBox_FL_ReboundEndPosition,
                textBox_FL_BumpStopLength, textBox_FL_BumpStopRate, textBox_FL_BumpStopRateGainDeflectionSquared, textBox_FL_BumpStopDamp, textBox_FL_BumpStopDampGainDeflectionSquared);
            textBoxSuspensionWrite(WF_PrefixMain.FR,
                textBox_FR_SpringRate,
                textBox_FR_ProgressiveRate,
                textBox_FR_BumpLimitsX, textBox_FR_BumpLimitsY,
                textBox_FR_ReboundLimitsX, textBox_FR_ReboundLimitsY,
                textBox_FR_BumpDampX, textBox_FR_BumpDampY,
                textBox_FR_ExpansionLimitFromZero, textBox_FR_CompressionLimitFromZero,
                textBox_FR_ReboundRate, textBox_FR_ReboundStartPosition, textBox_FR_ReboundEndPosition,
                textBox_FR_BumpStopLength, textBox_FR_BumpStopRate, textBox_FR_BumpStopRateGainDeflectionSquared, textBox_FR_BumpStopDamp, textBox_FR_BumpStopDampGainDeflectionSquared);
            textBoxSuspensionWrite(WF_PrefixMain.RL,
                textBox_RL_SpringRate,
                textBox_RL_ProgressiveRate,
                textBox_RL_BumpLimitsX, textBox_RL_BumpLimitsY,
                textBox_RL_ReboundLimitsX, textBox_RL_ReboundLimitsY,
                textBox_RL_BumpDampX, textBox_RL_BumpDampY,
                textBox_RL_ExpansionLimitFromZero, textBox_RL_CompressionLimitFromZero,
                textBox_RL_ReboundRate, textBox_RL_ReboundStartPosition, textBox_RL_ReboundEndPosition,
                textBox_RL_BumpStopLength, textBox_RL_BumpStopRate, textBox_RL_BumpStopRateGainDeflectionSquared, textBox_RL_BumpStopDamp, textBox_RL_BumpStopDampGainDeflectionSquared);
            textBoxSuspensionWrite(WF_PrefixMain.RR,
                textBox_RR_SpringRate,
                textBox_RR_ProgressiveRate,
                textBox_RR_BumpLimitsX, textBox_RR_BumpLimitsY,
                textBox_RR_ReboundLimitsX, textBox_RR_ReboundLimitsY,
                textBox_RR_BumpDampX, textBox_RR_BumpDampY,
                textBox_RR_ExpansionLimitFromZero, textBox_RR_CompressionLimitFromZero,
                textBox_RR_ReboundRate, textBox_RR_ReboundStartPosition, textBox_RR_ReboundEndPosition,
                textBox_RR_BumpStopLength, textBox_RR_BumpStopRate, textBox_RR_BumpStopRateGainDeflectionSquared, textBox_RR_BumpStopDamp, textBox_RR_BumpStopDampGainDeflectionSquared);

            List<string> FL = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.FL + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.FL, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                FL.Add(s);
            }
            var resultFL = String.Join("", FL.ToArray());
            textBox_FL_SuspensionGeometry.Text = resultFL;

            List<string> RL = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.RL + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.RL, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                RL.Add(s);
            }
            var resultRL = String.Join("", RL.ToArray());
            textBox_RL_SuspensionGeometry.Text = resultRL;

            List<string> FR = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.FR + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.FR, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                FR.Add(s);
            }
            var resultFR = String.Join("", FR.ToArray());
            textBox_FR_SuspensionGeometry.Text = resultFR;

            List<string> RR = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.RR + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.RR, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                RR.Add(s);
            }
            var resultRR = String.Join("", RR.ToArray());
            textBox_RR_SuspensionGeometry.Text = resultRR;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process != null && FormLiveData.ProcessGet == true && FormLiveData.FirstTimeLoad == true && LiveData.FullDataList.Count > 0 && FormLiveData.ValuesGet == true)
            {
                ReadData();
                SuspensionGeometry(WF_PrefixMain.FL, false, 0.16f);
                SuspensionGeometry(WF_PrefixMain.FR, false, 0.16f);
            }
        }
    }
}
