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

namespace Physics_Data_Debug
{
    public partial class FormSuspensionStaticValues : Form
    {
        public FormSuspensionStaticValues()
        {
            InitializeComponent();
            //textBox_FL_SuspensionGeometry.Visible = true;
            //textBox_FR_SuspensionGeometry.Visible = true;
            //textBox_RL_SuspensionGeometry.Visible = true;
            //textBox_RR_SuspensionGeometry.Visible = true;

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
        private void Asdasdasd(Chart chart, Enum side, bool isStatic, string seriesName, float rideHeight,
            float StaticTirePivotX, float StaticTirePivotY, float StaticTirePivotZ, 
            float DynamicTirePivotX, float DynamicTirePivotY, float DynamicTirePivotZ, 
            Enum BodyArmX, Enum BodyArmY, Enum BodyArmZ,
            Enum SpindleArmX, Enum SpindleArmY, Enum SpindleArmZ)
        {

            float StaticBodyFrontArmX = LiveData.GetFullListDataValue(side, BodyArmX);
            float StaticBodyFrontArmY = LiveData.GetFullListDataValue(side, BodyArmY) + rideHeight;
            float StaticBodyFrontArmZ = LiveData.GetFullListDataValue(side, BodyArmZ);
            float StaticSpindleFrontArmX = LiveData.GetFullListDataValue(side, SpindleArmX) + StaticTirePivotX;
            float StaticSpindleFrontArmY = LiveData.GetFullListDataValue(side, SpindleArmY) + StaticTirePivotY;
            float StaticSpindleFrontArmZ = LiveData.GetFullListDataValue(side, SpindleArmZ) + StaticTirePivotZ;
            float DynamicSpindleFrontArmX = StaticSpindleFrontArmX + DynamicTirePivotX;
            float DynamicSpindleFrontArmY = StaticSpindleFrontArmY + DynamicTirePivotY;
            float DynamicSpindleFrontArmZ = StaticSpindleFrontArmZ + DynamicTirePivotZ;
            string stringXY = side + seriesName;
            chart.Series[stringXY].Points[0].XValue = StaticBodyFrontArmX;
            chart.Series[stringXY].Points[0].YValues = new double[] { StaticBodyFrontArmY };
            if (isStatic == true)
            {
                chart.Series[stringXY].Points[1].XValue = StaticSpindleFrontArmX;
                chart.Series[stringXY].Points[1].YValues = new double[] { StaticSpindleFrontArmY };
            }
            else
            {
                chart.Series[stringXY].Points[1].XValue = DynamicSpindleFrontArmX;
                chart.Series[stringXY].Points[1].YValues = new double[] { DynamicSpindleFrontArmY };
            }
        }
        private void SuspensionGeometry(Enum side, bool isStatic)
        {
            float rideHeight = LiveData.GetFullListDataValue(side, WF_Suspension2DataOffset.RideHeight);
            chart1.Series["RideHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart1.Series["RideHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + rideHeight };

            //float CenterOfMassHeight = 0;
            float CenterOfMassHeight = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            chart1.Series["CoMHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart1.Series["CoMHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + CenterOfMassHeight };

            float StaticTirePivotX = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotX);
            float StaticTirePivotY = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotY) + rideHeight + CenterOfMassHeight;
            float StaticTirePivotZ = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotZ);
            float DynamicTirePivotX = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM41);
            float DynamicTirePivotY = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM42) + rideHeight + CenterOfMassHeight;
            float DynamicTirePivotZ = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM43);
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


            float StaticBodyUpperFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperFrontArmX);
            float StaticBodyUpperFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperFrontArmY) + rideHeight + CenterOfMassHeight;
            float StaticBodyUpperFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperFrontArmZ);
            float StaticSpindleUpperFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX) + StaticTirePivotX;
            float StaticSpindleUpperFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY) + StaticTirePivotY;
            float StaticSpindleUpperFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ) + StaticTirePivotZ;
            float DynamicSpindleUpperFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX) + DynamicTirePivotX;
            float DynamicSpindleUpperFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY) + DynamicTirePivotY;
            float DynamicSpindleUpperFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ) + DynamicTirePivotZ;
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


            float StaticBodyUpperRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperRearArmX);
            float StaticBodyUpperRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperRearArmY) + rideHeight + CenterOfMassHeight;
            float StaticBodyUpperRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyUpperRearArmZ);
            float StaticSpindleUpperRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX) + StaticTirePivotX;
            float StaticSpindleUpperRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY) + StaticTirePivotY;
            float StaticSpindleUpperRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ) + StaticTirePivotZ;
            float DynamicSpindleUpperRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX) + DynamicTirePivotX;
            float DynamicSpindleUpperRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY) + DynamicTirePivotY;
            float DynamicSpindleUpperRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ) + DynamicTirePivotZ;
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

            float StaticBodyLowerFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerFrontArmX);
            float StaticBodyLowerFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerFrontArmY) + rideHeight + CenterOfMassHeight;
            float StaticBodyLowerFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerFrontArmZ);
            float StaticSpindleLowerFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX) + StaticTirePivotX;
            float StaticSpindleLowerFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY) + StaticTirePivotY;
            float StaticSpindleLowerFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ) + StaticTirePivotZ;
            float DynamicSpindleLowerFrontArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX) + DynamicTirePivotX;
            float DynamicSpindleLowerFrontArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY) + DynamicTirePivotY;
            float DynamicSpindleLowerFrontArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ) + DynamicTirePivotZ;
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

            float StaticBodyLowerRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerRearArmX);
            float StaticBodyLowerRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerRearArmY) + rideHeight + CenterOfMassHeight;
            float StaticBodyLowerRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodyLowerRearArmZ);
            float StaticSpindleLowerRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX) + StaticTirePivotX;
            float StaticSpindleLowerRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY) + StaticTirePivotY;
            float StaticSpindleLowerRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ) + StaticTirePivotZ;
            float DynamicSpindleLowerRearArmX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX) + DynamicTirePivotX;
            float DynamicSpindleLowerRearArmY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY) + DynamicTirePivotY;
            float DynamicSpindleLowerRearArmZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ) + DynamicTirePivotZ;
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

            float StaticBodySteeringRodX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodySteeringRodX);
            float StaticBodySteeringRodY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodySteeringRodY) + rideHeight + CenterOfMassHeight;
            float StaticBodySteeringRodZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.BodySteeringRodZ);
            float StaticSpindleSteeringRodX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodX) + StaticTirePivotX;
            float StaticSpindleSteeringRodY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodY) + StaticTirePivotY;
            float StaticSpindleSteeringRodZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodX) + StaticTirePivotZ;
            float DynamicSpindleSteeringRodX = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodX) + DynamicTirePivotX;//?? Needs also to + tire X rotation and offset the offset with that
            float DynamicSpindleSteeringRodY = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodY) + DynamicTirePivotY;// Needs also to + tire Y rotation and offset the offset with that
            float DynamicSpindleSteeringRodZ = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodX) + DynamicTirePivotZ;//?? Needs also to + tire Z rotation and offset the offset with that
            string SteeringRodXY = side + "SteeringRodXY";
            chart1.Series[SteeringRodXY].Points[0].XValue = StaticBodySteeringRodX;
            chart1.Series[SteeringRodXY].Points[0].YValues = new double[] { StaticBodySteeringRodY };
            if (isStatic == true)
            {
                chart1.Series[SteeringRodXY].Points[1].XValue = StaticSpindleSteeringRodX;
                chart1.Series[SteeringRodXY].Points[1].YValues = new double[] { StaticSpindleSteeringRodY };
            }
            else
            {
                chart1.Series[SteeringRodXY].Points[1].XValue = DynamicSpindleSteeringRodX;
                chart1.Series[SteeringRodXY].Points[1].YValues = new double[] { DynamicSpindleSteeringRodY };
            }

            string UpperArmMidpointXY = side + "UpperArmMidpointXY";
            float BodyUpperArmMidpointX = (StaticBodyUpperFrontArmX + StaticBodyUpperRearArmX) / 2;
            float BodyUpperArmMidpointY = (StaticBodyUpperFrontArmY + StaticBodyUpperRearArmY) / 2;
            chart1.Series[UpperArmMidpointXY].Points[0].XValue = BodyUpperArmMidpointX;//BodyUpperArmMidpointX
            chart1.Series[UpperArmMidpointXY].Points[0].YValues = new double[] { BodyUpperArmMidpointY };//BodyUpperArmMidpointY
            chart1.Series[UpperArmMidpointXY].Points[1].XValue = chart1.Series[UpperFrontArmXY].Points[1].XValue;//DynamicSpindleUpperFrontArmX
            chart1.Series[UpperArmMidpointXY].Points[1].YValues = chart1.Series[UpperFrontArmXY].Points[1].YValues;//DynamicSpindleUpperFrontArmY

            string LowerArmMidpointXY = side + "LowerArmMidpointXY";
            float BodyLowerArmMidpointX = (StaticBodyLowerFrontArmX + StaticBodyLowerRearArmX) / 2;
            float BodyLowerArmMidpointY = (StaticBodyLowerFrontArmY + StaticBodyLowerRearArmY) / 2;
            chart1.Series[LowerArmMidpointXY].Points[0].XValue = BodyLowerArmMidpointX;
            chart1.Series[LowerArmMidpointXY].Points[0].YValues = new double[] { BodyLowerArmMidpointY };
            chart1.Series[LowerArmMidpointXY].Points[1].XValue = chart1.Series[LowerFrontArmXY].Points[1].XValue;//DynamicSpindleLowerFrontArmX
            chart1.Series[LowerArmMidpointXY].Points[1].YValues = chart1.Series[LowerFrontArmXY].Points[1].YValues;//DynamicSpindleLowerFrontArmY

            //https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
            /*float[] ICXY = XYLineIntersection(
            DynamicSpindleUpperFrontArmX, BodyUpperArmMidpointX,
            DynamicSpindleUpperFrontArmY, BodyUpperArmMidpointY,
            DynamicSpindleLowerFrontArmX, BodyLowerArmMidpointX,
            DynamicSpindleLowerFrontArmY, BodyLowerArmMidpointY);*/

            /*float[] ICXY = XYLineIntersection(
            BodyUpperArmMidpointX, DynamicSpindleUpperFrontArmX,
            BodyUpperArmMidpointY, DynamicSpindleUpperFrontArmY,
            BodyLowerArmMidpointX, DynamicSpindleLowerFrontArmX,
            BodyLowerArmMidpointY, DynamicSpindleLowerFrontArmY);*/

            /*float[] ICXY = XYLineIntersection(
            DynamicSpindleUpperFrontArmX, BodyUpperArmMidpointX,
            BodyUpperArmMidpointY, DynamicSpindleUpperFrontArmY,
            DynamicSpindleLowerFrontArmX, BodyLowerArmMidpointX,
            BodyLowerArmMidpointY, DynamicSpindleLowerFrontArmY);*/

            /*float[] ICXY = XYLineIntersection(
            BodyUpperArmMidpointX, DynamicSpindleUpperFrontArmX,
            DynamicSpindleUpperFrontArmY, BodyUpperArmMidpointY,
            BodyLowerArmMidpointY, DynamicSpindleLowerFrontArmX,
            DynamicSpindleLowerFrontArmY, BodyLowerArmMidpointY);*/

            float[] ICXY = XYLineIntersection(
            DynamicSpindleLowerFrontArmX, BodyLowerArmMidpointX,
            DynamicSpindleLowerFrontArmY, BodyLowerArmMidpointY,
            DynamicSpindleUpperFrontArmX, BodyUpperArmMidpointX,
            DynamicSpindleUpperFrontArmY, BodyUpperArmMidpointY);

            string InstantCenterXY = side + "InstantCenterXY";
            chart1.Series[InstantCenterXY].Points[0].XValue = BodyUpperArmMidpointX;
            chart1.Series[InstantCenterXY].Points[0].YValues = new double[] { BodyUpperArmMidpointY };
            chart1.Series[InstantCenterXY].Points[1].XValue = ICXY[0];
            chart1.Series[InstantCenterXY].Points[1].YValues = new double[] { ICXY[1] };
            chart1.Series[InstantCenterXY].Points[2].XValue = BodyLowerArmMidpointX;
            chart1.Series[InstantCenterXY].Points[2].YValues = new double[] { BodyLowerArmMidpointY };
        }
        private float[] XYLineIntersection(
            float x1, float x2, 
            float y1, float y2,
            float x3, float x4, 
            float y3, float y4)
        {
            float m1 = -((y2 - y1) / (x1 - x2));//why one of these needs to be minus instead??
            float c1 = - m1 * x1 + y1;
            float m2 = (y4 - y3) / (x4 - x3);
            float c2 = - m2 * x3 + y3;

            float y;
            float x;
            /*
            y - y1 = m1 * (x - x1);
            y - y1 = m1 * x - m1 * x1;
            y - y1 + m1 * x1 = m1 * x;
            y = m1 * x - m1 * x1 + y1;
            m1 * x - m1 * x1 + y1 - y = 0;
            m1 * x + c1 - y = 0;
            m1 * x - y + c1 = 0;
            m2 * x -m2 * x3 + y3 - y = 0;
            */
            x = (c2 - c1) / (m1 - m2);
            y = m1 * (c2 - c1) / (m1 - m2) + c1;

            //a1x + b1y + c1 = 0
            //

            return new float[] { x, y };
            /*
            if(
                x1 == 0 && 
                y1 == 0 && 
                x2 == 0 && 
                y2 == 0 && 
                x3 == 0 &&
                y3 == 0 &&
                x4 == 0 &&
                y4 == 0)
            { return new float[] { 0, 0}; }
            float sx = x2 - x1;
            float tx = x4 - x3;
            float stx = x3 - x1;

            float sy = y2 - y1;
            float ty = y4 - y3;
            float sty = y3 - y1;

            float s = (stx + tx) / sx;
            float t0 = (s*sy - sty)/ty;
            float s0 = (stx + t0 * tx)/sx;

            if (0 <= s0)
            {
                return new float[] { x1 + s0 * (x2 - x1), y1 + s0 * (y2 - y1) };
            }
            else if (t0 <= 1)
            {
                return new float[] { x3 + t0 * (x4 - x3), y3 + t0 * (y4 - y3) };
            }
            else
            {
                return new float[] { 0, 0 };
            }*/
            /*
            float t = ( (x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4) ) / ( (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4) );
            float u = ( (x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3) ) / ( (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4) );
            if(0f <= t && t <= 1f)
            {
                return new float[] { x1 + t * ( x2 - x1 ), y1 + t * (y2 - y1) };
            }
            else if (0f <= u && u <= 1f)
            {
                return new float[] { x3 + u * (x4 - x3), y3 + u * (y4 - y3) };
            }
            else
            {
                return new float[] { 0, 0 };
            }*/
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
                SuspensionGeometry(WF_PrefixMain.FL, false);
                SuspensionGeometry(WF_PrefixMain.FR, false);
            }
        }
    }
}
