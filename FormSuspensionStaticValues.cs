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
        private Vector4 StaticTirePivot(Enum side, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotX),
                Y = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotY) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotZ),
                W = 1,
            };
        }
        private Vector4 DynamicTirePivot(Enum side, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM41),
                Y = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM42) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM43),
                W = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM44)
            };
        }
        private void TirePivotChartPoints(Enum side, Vector4 staticTirePivot, Vector4 dynamicTirePivot, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = side + seriesName;
            if (isStatic == true)
            {
                chart.Series[fullSeriesName].Points[0].XValue = staticTirePivot.X;
                chart.Series[fullSeriesName].Points[0].YValues = new double[] { staticTirePivot.Y };
            }
            else
            {
                chart.Series[fullSeriesName].Points[0].XValue = dynamicTirePivot.X;
                chart.Series[fullSeriesName].Points[0].YValues = new double[] { dynamicTirePivot.Y };
            }
        }
        private Vector4 StaticBodyArmPivot(Enum side, Enum x, Enum y, Enum z, Enum w, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, x),
                Y = LiveData.GetFullListDataValue(side, y) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, z),
                W = LiveData.GetFullListDataValue(side, w)
            };
        }
        private Vector4 SpindleArmPivot(Enum side, Enum x, Enum y, Enum z, Enum w, Vector4 tirePivot)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, x) + tirePivot.X,
                Y = LiveData.GetFullListDataValue(side, y) + tirePivot.Y,
                Z = LiveData.GetFullListDataValue(side, z) + tirePivot.Z,
                W = LiveData.GetFullListDataValue(side, w)/* + tirePivot.W*///??
            };
        }
        private void ArmChartPoints(Enum side, Vector4 staticBodyArm, Vector4 staticSpindleArm, Vector4 dynamicSpindleArm, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = side + seriesName;
            chart.Series[fullSeriesName].Points[0].XValue = staticBodyArm.X;
            chart.Series[fullSeriesName].Points[0].YValues = new double[] { staticBodyArm.Y };
            if (isStatic == true)
            {
                chart.Series[fullSeriesName].Points[1].XValue = staticSpindleArm.X;
                chart.Series[fullSeriesName].Points[1].YValues = new double[] { staticSpindleArm.Y };
            }
            else
            {
                chart.Series[fullSeriesName].Points[1].XValue = dynamicSpindleArm.X;
                chart.Series[fullSeriesName].Points[1].YValues = new double[] { dynamicSpindleArm.Y };
            }
        }
        private void ArmMidpointChartPoints(Enum side, Vector4 bodyArmMidpoint, Vector4 staticSpindleArm, Vector4 dynamicSpindleArm, Chart chart, string seriesName, bool isStatic)
        {
            string fulSeriesName = side + seriesName;
            chart1.Series[fulSeriesName].Points[0].XValue = bodyArmMidpoint.X;//BodyUpperArmMidpointX
            chart1.Series[fulSeriesName].Points[0].YValues = new double[] { bodyArmMidpoint.Y };//BodyUpperArmMidpointY

            if (isStatic == true)
            {
                chart1.Series[fulSeriesName].Points[1].XValue = staticSpindleArm.X;
                chart1.Series[fulSeriesName].Points[1].YValues = new double[] { staticSpindleArm.Y };
            }
            else
            {
                chart1.Series[fulSeriesName].Points[1].XValue = dynamicSpindleArm.X;//chart.Series[side + "UpperFrontArmXY"].Points[1].XValue;//DynamicSpindleUpperFrontArmX
                chart1.Series[fulSeriesName].Points[1].YValues = new double[] { dynamicSpindleArm.Y };//chart.Series[side + "UpperFrontArmXY"].Points[1].YValues;//DynamicSpindleUpperFrontArmY
            }
        }
        private void SuspensionRollCenter(string side, bool isStatic,Chart chart, Vector4 instantCenterFL, Vector4 instantCenterFR)
        {
            float rideHeightFL = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_Suspension2DataOffset.RideHeight);
            float centerOfMassHeightFL = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            Vector4 dynamicTirePivotFL = DynamicTirePivot(WF_PrefixMain.FL, rideHeightFL, centerOfMassHeightFL);

            #region Left
            Vector4 tireMiddleContactPointFL = new Vector4
            {
                X = dynamicTirePivotFL.X,
                Y = dynamicTirePivotFL.Y - LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TireRadius)/* - LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LoadedRadius)*/,
                Z = dynamicTirePivotFL.Z,
                W = dynamicTirePivotFL.W,
            };

            float rideHeightFR = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_Suspension2DataOffset.RideHeight);
            float centerOfMassHeightFR = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            Vector4 dynamicTirePivotFR = DynamicTirePivot(WF_PrefixMain.FR, rideHeightFR, centerOfMassHeightFR);
            #endregion
            #region Right
            Vector4 tireMiddleContactPointFR = new Vector4
            {
                X = dynamicTirePivotFR.X,
                Y = dynamicTirePivotFR.Y - LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TireRadius)/* - LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LoadedRadius)*/,
                Z = dynamicTirePivotFR.Z,
                W = dynamicTirePivotFR.W,
            };
            #endregion
            #region RollCenter
            Vector4 rollCenter = XYLineIntersectionVector(
                instantCenterFL,
                tireMiddleContactPointFL,
                instantCenterFR,
                tireMiddleContactPointFR);
            string rollCenterXY = "Front" + "RollCenterXY";
            chart.Series[rollCenterXY].Points[0].XValue = rollCenter.X;
            chart.Series[rollCenterXY].Points[0].YValues = new double[] { rollCenter.Y };

            string left = "LeftRCLine";
            chart.Series[left].Points[0].XValue = instantCenterFL.X;
            chart.Series[left].Points[0].YValues = new double[] { instantCenterFL.Y };
            chart.Series[left].Points[1].XValue = tireMiddleContactPointFL.X;
            chart.Series[left].Points[1].YValues = new double[] { tireMiddleContactPointFL.Y };

            string right = "RightRCLine";
            chart.Series[right].Points[0].XValue = instantCenterFR.X;
            chart.Series[right].Points[0].YValues = new double[] { instantCenterFR.Y };
            chart.Series[right].Points[1].XValue = tireMiddleContactPointFR.X;
            chart.Series[right].Points[1].YValues = new double[] { tireMiddleContactPointFR.Y };

            #endregion
        }
        private Vector4 SuspensionGeometry(Enum side, bool isStatic, Chart chart)
        {
            float rideHeight = LiveData.GetFullListDataValue(side, WF_Suspension2DataOffset.RideHeight);
            chart.Series["RideHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart.Series["RideHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + rideHeight };

            float centerOfMassHeight = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            chart.Series["CoMHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart.Series["CoMHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + centerOfMassHeight };

            #region TirePivot
            Vector4 staticTirePivot = StaticTirePivot(side, rideHeight, centerOfMassHeight);
            Vector4 dynamicTirePivot = DynamicTirePivot(side, rideHeight, centerOfMassHeight);
            TirePivotChartPoints(side, staticTirePivot, dynamicTirePivot, chart, "TirePivotXY", isStatic);
            #endregion

            #region UpperFront
            Vector4 staticBodyUpperFrontArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmX,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmY,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmZ,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleUpperFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmW,
                staticTirePivot);
            Vector4 dynamicSpindleUpperFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmW,
                dynamicTirePivot);
            ArmChartPoints(side, staticBodyUpperFrontArm, staticSpindleUpperFrontArm, dynamicSpindleUpperFrontArm, chart, "UpperFrontArmXY", isStatic);
            #endregion

            #region UpperRear
            Vector4 staticBodyUpperRearArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmX,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmY,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmZ,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleUpperRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmW,
                staticTirePivot);
            Vector4 dynamicSpindleUpperRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmW,
                dynamicTirePivot);
            ArmChartPoints(side, staticBodyUpperRearArm, staticSpindleUpperRearArm, dynamicSpindleUpperRearArm, chart, "UpperRearArmXY", isStatic);
            #endregion

            #region LowerFront
            Vector4 staticBodyLowerFrontArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmX,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmY,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmZ,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleLowerFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmW,
                staticTirePivot);
            Vector4 dynamicSpindleLowerFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmW,
                dynamicTirePivot);
            ArmChartPoints(side, staticBodyLowerFrontArm, staticSpindleLowerFrontArm, dynamicSpindleLowerFrontArm, chart, "LowerFrontArmXY", isStatic);
            #endregion

            #region LowerRear
            Vector4 staticBodyLowerRearArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmX,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmY,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmZ,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleLowerRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmW,
                staticTirePivot);
            Vector4 dynamicSpindleLowerRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmW,
                dynamicTirePivot);
            ArmChartPoints(side, staticBodyLowerRearArm, staticSpindleLowerRearArm, dynamicSpindleLowerRearArm, chart, "LowerRearArmXY", isStatic);
            #endregion

            #region SteeringRod
            Vector4 staticBodySteeringRod = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodySteeringRodX,
                WF_SuspensionGeometryDataOffset.BodySteeringRodY,
                WF_SuspensionGeometryDataOffset.BodySteeringRodZ,
                WF_SuspensionGeometryDataOffset.BodySteeringRodW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleSteeringRod = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodX,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodY,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodZ,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodW,
                staticTirePivot);
            Vector4 dynamicSpindleSteeringRod = new Vector4
            {
                X = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodX) + dynamicTirePivot.X,//?? Needs also to + tire X rotation and offset the offset with that
                Y = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodY) + dynamicTirePivot.Y,// Needs also to + tire Y rotation and offset the offset with that
                Z = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodZ) + dynamicTirePivot.Z,//?? Needs also to + tire Z rotation and offset the offset with that
                W = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodW) + dynamicTirePivot.W
            };
            ArmChartPoints(side, staticBodySteeringRod, staticSpindleSteeringRod, dynamicSpindleSteeringRod, chart, "SteeringRodXY", isStatic);
            #endregion

            #region InstantCenter

            #region UpperArmMidpoint
            Vector4 bodyUpperArmMidpoint = MidPointArm(staticBodyUpperFrontArm, staticBodyUpperRearArm);
            ArmMidpointChartPoints(side, bodyUpperArmMidpoint, staticSpindleUpperFrontArm, dynamicSpindleUpperFrontArm, chart, "UpperArmMidpointXY", isStatic);
            #endregion
            #region LowerArmMidpoint
            Vector4 bodyLowerArmMidpoint = MidPointArm(staticBodyLowerFrontArm, staticBodyLowerRearArm);
            ArmMidpointChartPoints(side, bodyLowerArmMidpoint, staticSpindleLowerFrontArm, dynamicSpindleLowerFrontArm, chart, "LowerArmMidpointXY", isStatic);
            #endregion

            #region InstantCenter
            //https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
            Vector4 instantCenter = XYLineIntersectionVector(
            dynamicSpindleLowerFrontArm,
            bodyLowerArmMidpoint,
            dynamicSpindleUpperFrontArm,
            bodyUpperArmMidpoint);

            string InstantCenterXY = side + "InstantCenterXY";
            chart.Series[InstantCenterXY].Points[0].XValue = bodyUpperArmMidpoint.X;
            chart.Series[InstantCenterXY].Points[0].YValues = new double[] { bodyUpperArmMidpoint.Y };
            chart.Series[InstantCenterXY].Points[1].XValue = instantCenter.X;
            chart.Series[InstantCenterXY].Points[1].YValues = new double[] { instantCenter.Y };
            chart.Series[InstantCenterXY].Points[2].XValue = bodyLowerArmMidpoint.X;
            chart.Series[InstantCenterXY].Points[2].YValues = new double[] { bodyLowerArmMidpoint.Y };
            #endregion

            #endregion
            return instantCenter;

            #region Roll Center
            Vector4 tireMiddleContactPoint = new Vector4 
            { 
                X = dynamicTirePivot.X,
                Y = dynamicTirePivot.Y - LiveData.GetFullListDataValue(side, WF_TireDataOffset.LoadedRadius),
                Z = dynamicTirePivot.Z,
                W = dynamicTirePivot.W,
            };
            Vector4 rollCenter = XYLineIntersectionVector(
                instantCenter,
                tireMiddleContactPoint,
                instantCenter,
                tireMiddleContactPoint);
            string rollCenterXY = side + "RollCenterXY";
            #endregion
        }
        Vector4 MidPointArm(Vector4 frontArm, Vector4 rearArm)
        {
            return new Vector4 { 
                X = (frontArm.X + rearArm.X) / 2, 
                Y = (frontArm.Y + rearArm.Y) / 2,
                Z = 0,
                W = 1,
            };
        }
        private float[] XYLineIntersection(
            float x1, float x2,
            float y1, float y2,
            float x3, float x4,
            float y3, float y4)//https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
        {
            float m1 = (y2 - y1) / (x2 - x1);//why one of these needs to be minus instead??
            float c1 = -m1 * x1 + y1;
            float m2 = (y4 - y3) / (x4 - x3);
            float c2 = -m2 * x3 + y3;

            float y;
            float x;
            x = (c2 - c1) / (m1 - m2);
            y = m1 * (c2 - c1) / (m1 - m2) + c1;

            return new float[] { x, y };
        }
        private Vector4 XYLineIntersectionVector(
            Vector4 vector1,
            Vector4 vector2,
            Vector4 vector3,
            Vector4 vector4)//https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
        {
            float m1 = (vector2.Y - vector1.Y) / (vector2.X - vector1.X);//why one of these needs to be minus instead??
            float c1 = - m1 * vector1.X + vector1.Y;
            float m2 = (vector4.Y - vector3.Y) / (vector4.X - vector3.X);
            float c2 = - m2 * vector3.X + vector3.Y;
            return new Vector4 
            { 
                X = (c2 - c1) / (m1 - m2), 
                Y = m1 * (c2 - c1) / (m1 - m2) + c1, 
                Z = 0,
                W = 1,
            };
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
                Vector4 instantCenterFL = SuspensionGeometry(WF_PrefixMain.FL, false, chart1);
                Vector4 instantCenterFR = SuspensionGeometry(WF_PrefixMain.FR, false, chart1);
                SuspensionRollCenter("Front", false, chart1, instantCenterFL, instantCenterFR);
            }
        }
    }
}
