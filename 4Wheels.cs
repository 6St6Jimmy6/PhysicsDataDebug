using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    class _4Wheels
    {
        public static int Alpha { get; set; } = 255;
        public static int Divider { get; set; } = 2;
        public static int HistoryAlpha { get; set; } = 255;
        public static int HistoryColorDivider { get; set; } = 2;
        public static int Steps { get; set; } = 10;

        public static string SeriesFL { get; set; } = "SeriesFL";
        public static string SeriesFR { get; set; } = "SeriesFR";
        public static string SeriesRL { get; set; } = "SeriesRL";
        public static string SeriesRR { get; set; } = "SeriesRR";

        public static List<double> FL_X1ValuesChart { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChart { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChart { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChart { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChart { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChart { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChart { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChart { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChart { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChart { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChart { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChart { get; set; } = new List<double>();
        #region Color Gradient list values.
        public static string seriesColor1 { get; set; } = "Color1";
        public static List<double> FL_X1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor1 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor1 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor1 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor1 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor1 { get; set; } = new List<double>();

        public static string seriesColor2 { get; set; } = "Color2";
        public static List<double> FL_X1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor2 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor2 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor2 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor2 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor2 { get; set; } = new List<double>();

        public static string seriesColor3 { get; set; } = "Color3";
        public static List<double> FL_X1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor3 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor3 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor3 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor3 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor3 { get; set; } = new List<double>();

        public static string seriesColor4 { get; set; } = "Color4";
        public static List<double> FL_X1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor4 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor4 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor4 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor4 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor4 { get; set; } = new List<double>();

        public static string seriesColor5 { get; set; } = "Color5";
        public static List<double> FL_X1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor5 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor5 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor5 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor5 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor5 { get; set; } = new List<double>();

        public static string seriesColor6 { get; set; } = "Color6";
        public static List<double> FL_X1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor6 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor6 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor6 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor6 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor6 { get; set; } = new List<double>();

        public static string seriesColor7 { get; set; } = "Color7";
        public static List<double> FL_X1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor7 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor7 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor7 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor7 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor7 { get; set; } = new List<double>();

        public static string seriesColor8 { get; set; } = "Color8";
        public static List<double> FL_X1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor8 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor8 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor8 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor8 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor8 { get; set; } = new List<double>();

        public static string seriesColor9 { get; set; } = "Color9";
        public static List<double> FL_X1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor9 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor9 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor9 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor9 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor9 { get; set; } = new List<double>();

        public static string seriesColor10 { get; set; } = "Color10";
        public static List<double> FL_X1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> FL_Y1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> FL_Z1ValuesChartColor10 { get; set; } = new List<double>();

        public static List<double> FR_X1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> FR_Y1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> FR_Z1ValuesChartColor10 { get; set; } = new List<double>();

        public static List<double> RL_X1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> RL_Y1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> RL_Z1ValuesChartColor10 { get; set; } = new List<double>();

        public static List<double> RR_X1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> RR_Y1ValuesChartColor10 { get; set; } = new List<double>();
        public static List<double> RR_Z1ValuesChartColor10 { get; set; } = new List<double>();
        #endregion

        public static SeriesChartType ChartType { get; set; } = _4WheelsSettings.SeriesChartType;
        public static MarkerStyle MarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int MarkerSizeHistory { get; set; } = 2;
        public static Color Color10 { get; set; }
        public static Color Color9 { get; set; }
        public static Color Color8 { get; set; }
        public static Color Color7 { get; set; }
        public static Color Color6 { get; set; }
        public static Color Color5 { get; set; }
        public static Color Color4 { get; set; }
        public static Color Color3 { get; set; }
        public static Color Color2 { get; set; }
        public static Color Color1 { get; set; }
        public static bool LimiterSelectionIsAbsoluteValue(string selectedItem)
        {
            if (selectedItem == LogSettings.sTireTravelSpeed ||
                   selectedItem == LogSettings.sAngularVelocity ||
                   selectedItem == LogSettings.sSteerAngle ||
                   selectedItem == LogSettings.sCamberAngle ||
                   selectedItem == LogSettings.sLateralLoad ||
                   selectedItem == LogSettings.sSlipAngle ||
                   selectedItem == LogSettings.sLateralFriction ||
                   selectedItem == LogSettings.sLateralSlipSpeed ||
                   selectedItem == LogSettings.sLongitudinalLoad ||
                   selectedItem == LogSettings.sSlipRatio ||
                   selectedItem == LogSettings.sLongitudinalFriction ||
                   selectedItem == LogSettings.sLongitudinalSlipSpeed ||
                   selectedItem == LogSettings.sSuspensionVelocity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CBLimiterSelectionIsAbsoluteValue(ComboBox cb)
        {
            string selectedItem = (string)cb.SelectedItem;
            if (selectedItem == LogSettings.sTireTravelSpeed ||
                   selectedItem == LogSettings.sAngularVelocity ||
                   selectedItem == LogSettings.sSteerAngle ||
                   selectedItem == LogSettings.sCamberAngle ||
                   selectedItem == LogSettings.sLateralLoad ||
                   selectedItem == LogSettings.sSlipAngle ||
                   selectedItem == LogSettings.sLateralFriction ||
                   selectedItem == LogSettings.sLateralSlipSpeed ||
                   selectedItem == LogSettings.sLongitudinalLoad ||
                   selectedItem == LogSettings.sSlipRatio ||
                   selectedItem == LogSettings.sLongitudinalFriction ||
                   selectedItem == LogSettings.sLongitudinalSlipSpeed ||
                   selectedItem == LogSettings.sSuspensionVelocity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ClearListDataHistory()
        {
            //while (chartName.Series.Count > 1) { chartName.Series.RemoveAt(0); }
            FL_X1ValuesChart.Clear();
            FL_Y1ValuesChart.Clear();
            FL_Z1ValuesChart.Clear();
            FR_X1ValuesChart.Clear();
            FR_Y1ValuesChart.Clear();
            FR_Z1ValuesChart.Clear();
            RL_X1ValuesChart.Clear();
            RL_Y1ValuesChart.Clear();
            RL_Z1ValuesChart.Clear();
            RR_X1ValuesChart.Clear();
            RR_Y1ValuesChart.Clear();
            RR_Z1ValuesChart.Clear();
            
            FL_X1ValuesChartColor1.Clear();
            FL_Y1ValuesChartColor1.Clear();
            FL_Z1ValuesChartColor1.Clear();
            FR_X1ValuesChartColor1.Clear();
            FR_Y1ValuesChartColor1.Clear();
            FR_Z1ValuesChartColor1.Clear();
            RL_X1ValuesChartColor1.Clear();
            RL_Y1ValuesChartColor1.Clear();
            RL_Z1ValuesChartColor1.Clear();
            RR_X1ValuesChartColor1.Clear();
            RR_Y1ValuesChartColor1.Clear();
            RR_Z1ValuesChartColor1.Clear();

            FL_X1ValuesChartColor2.Clear();
            FL_Y1ValuesChartColor2.Clear();
            FL_Z1ValuesChartColor2.Clear();
            FR_X1ValuesChartColor2.Clear();
            FR_Y1ValuesChartColor2.Clear();
            FR_Z1ValuesChartColor2.Clear();
            RL_X1ValuesChartColor2.Clear();
            RL_Y1ValuesChartColor2.Clear();
            RL_Z1ValuesChartColor2.Clear();
            RR_X1ValuesChartColor2.Clear();
            RR_Y1ValuesChartColor2.Clear();
            RR_Z1ValuesChartColor2.Clear();

            FL_X1ValuesChartColor3.Clear();
            FL_Y1ValuesChartColor3.Clear();
            FL_Z1ValuesChartColor3.Clear();
            FR_X1ValuesChartColor3.Clear();
            FR_Y1ValuesChartColor3.Clear();
            FR_Z1ValuesChartColor3.Clear();
            RL_X1ValuesChartColor3.Clear();
            RL_Y1ValuesChartColor3.Clear();
            RL_Z1ValuesChartColor3.Clear();
            RR_X1ValuesChartColor3.Clear();
            RR_Y1ValuesChartColor3.Clear();
            RR_Z1ValuesChartColor3.Clear();

            FL_X1ValuesChartColor4.Clear();
            FL_Y1ValuesChartColor4.Clear();
            FL_Z1ValuesChartColor4.Clear();
            FR_X1ValuesChartColor4.Clear();
            FR_Y1ValuesChartColor4.Clear();
            FR_Z1ValuesChartColor4.Clear();
            RL_X1ValuesChartColor4.Clear();
            RL_Y1ValuesChartColor4.Clear();
            RL_Z1ValuesChartColor4.Clear();
            RR_X1ValuesChartColor4.Clear();
            RR_Y1ValuesChartColor4.Clear();
            RR_Z1ValuesChartColor4.Clear();

            FL_X1ValuesChartColor5.Clear();
            FL_Y1ValuesChartColor5.Clear();
            FL_Z1ValuesChartColor5.Clear();
            FR_X1ValuesChartColor5.Clear();
            FR_Y1ValuesChartColor5.Clear();
            FR_Z1ValuesChartColor5.Clear();
            RL_X1ValuesChartColor5.Clear();
            RL_Y1ValuesChartColor5.Clear();
            RL_Z1ValuesChartColor5.Clear();
            RR_X1ValuesChartColor5.Clear();
            RR_Y1ValuesChartColor5.Clear();
            RR_Z1ValuesChartColor5.Clear();

            FL_X1ValuesChartColor6.Clear();
            FL_Y1ValuesChartColor6.Clear();
            FL_Z1ValuesChartColor6.Clear();
            FR_X1ValuesChartColor6.Clear();
            FR_Y1ValuesChartColor6.Clear();
            FR_Z1ValuesChartColor6.Clear();
            RL_X1ValuesChartColor6.Clear();
            RL_Y1ValuesChartColor6.Clear();
            RL_Z1ValuesChartColor6.Clear();
            RR_X1ValuesChartColor6.Clear();
            RR_Y1ValuesChartColor6.Clear();
            RR_Z1ValuesChartColor6.Clear();

            FL_X1ValuesChartColor7.Clear();
            FL_Y1ValuesChartColor7.Clear();
            FL_Z1ValuesChartColor7.Clear();
            FR_X1ValuesChartColor7.Clear();
            FR_Y1ValuesChartColor7.Clear();
            FR_Z1ValuesChartColor7.Clear();
            RL_X1ValuesChartColor7.Clear();
            RL_Y1ValuesChartColor7.Clear();
            RL_Z1ValuesChartColor7.Clear();
            RR_X1ValuesChartColor7.Clear();
            RR_Y1ValuesChartColor7.Clear();
            RR_Z1ValuesChartColor7.Clear();

            FL_X1ValuesChartColor8.Clear();
            FL_Y1ValuesChartColor8.Clear();
            FL_Z1ValuesChartColor8.Clear();
            FR_X1ValuesChartColor8.Clear();
            FR_Y1ValuesChartColor8.Clear();
            FR_Z1ValuesChartColor8.Clear();
            RL_X1ValuesChartColor8.Clear();
            RL_Y1ValuesChartColor8.Clear();
            RL_Z1ValuesChartColor8.Clear();
            RR_X1ValuesChartColor8.Clear();
            RR_Y1ValuesChartColor8.Clear();
            RR_Z1ValuesChartColor8.Clear();

            FL_X1ValuesChartColor9.Clear();
            FL_Y1ValuesChartColor9.Clear();
            FL_Z1ValuesChartColor9.Clear();
            FR_X1ValuesChartColor9.Clear();
            FR_Y1ValuesChartColor9.Clear();
            FR_Z1ValuesChartColor9.Clear();
            RL_X1ValuesChartColor9.Clear();
            RL_Y1ValuesChartColor9.Clear();
            RL_Z1ValuesChartColor9.Clear();
            RR_X1ValuesChartColor9.Clear();
            RR_Y1ValuesChartColor9.Clear();
            RR_Z1ValuesChartColor9.Clear();

            FL_X1ValuesChartColor10.Clear();
            FL_Y1ValuesChartColor10.Clear();
            FL_Z1ValuesChartColor10.Clear();
            FR_X1ValuesChartColor10.Clear();
            FR_Y1ValuesChartColor10.Clear();
            FR_Z1ValuesChartColor10.Clear();
            RL_X1ValuesChartColor10.Clear();
            RL_Y1ValuesChartColor10.Clear();
            RL_Z1ValuesChartColor10.Clear();
            RR_X1ValuesChartColor10.Clear();
            RR_Y1ValuesChartColor10.Clear();
            RR_Z1ValuesChartColor10.Clear();

        }
        public static float[] XYZListSelections(string xAxisSelection, string yAxisSelection, string zAxisSelection,
                                                int raceTime, float travelSpeed, float angVel,
                                                float verLoad, float verDefl, float loadRadius, float effRadius, float contLength,
                                                float currContBrakeTorq, float currContBrakeTorqMax,
                                                float steerAngDeg, float cambAngDeg,
                                                float latLoad, float slipAngleDeg, float latFrict, float latSlipSpeed,
                                                float lonLoad, float slipRatio, float lonFrict, float lonSlipSpeed,
                                                float treadTemp, float innerTemp,
                                                float totalFrict, float totalFrictAngle,
                                                float suspLength, float suspVel)
        {
            float[] xyzValues = new float[3];
            //X
            if (xAxisSelection == LogSettings.sTireTravelSpeed)
            {
                xyzValues[0] = travelSpeed;
            }
            else if (xAxisSelection == LogSettings.sAngularVelocity)
            {
                xyzValues[0] = angVel;
            }
            else if (xAxisSelection == LogSettings.sVerticalLoad)
            {
                xyzValues[0] = verLoad;
            }
            else if (xAxisSelection == LogSettings.sVerticalDeflection)
            {
                xyzValues[0] = verDefl;
            }
            else if (xAxisSelection == LogSettings.sLoadedRadius)
            {
                xyzValues[0] = loadRadius;
            }
            else if (xAxisSelection == LogSettings.sEffectiveRadius)
            {
                xyzValues[0] = effRadius;
            }
            else if (xAxisSelection == LogSettings.sContactLength)
            {
                xyzValues[0] = contLength;
            }
            else if (xAxisSelection == LogSettings.sBrakeTorque)
            {
                xyzValues[0] = currContBrakeTorq;
            }
            else if (xAxisSelection == LogSettings.sMaxBrakeTorque)
            {
                xyzValues[0] = currContBrakeTorqMax;
            }
            else if (xAxisSelection == LogSettings.sSteerAngle)
            {
                xyzValues[0] = steerAngDeg;
            }
            else if (xAxisSelection == LogSettings.sCamberAngle)
            {
                xyzValues[0] = cambAngDeg;
            }
            else if (xAxisSelection == LogSettings.sLateralLoad)
            {
                xyzValues[0] = latLoad;
            }
            else if (xAxisSelection == LogSettings.sSlipAngle)
            {
                xyzValues[0] = slipAngleDeg;
            }
            else if (xAxisSelection == LogSettings.sLateralFriction)
            {
                xyzValues[0] = latFrict;
            }
            else if (xAxisSelection == LogSettings.sLateralSlipSpeed)
            {
                xyzValues[0] = latSlipSpeed;
            }
            else if (xAxisSelection == LogSettings.sLongitudinalLoad)
            {
                xyzValues[0] = lonLoad;
            }
            else if (xAxisSelection == LogSettings.sSlipRatio)
            {
                xyzValues[0] = slipRatio;
            }
            else if (xAxisSelection == LogSettings.sLongitudinalFriction)
            {
                xyzValues[0] = lonFrict;
            }
            else if (xAxisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                xyzValues[0] = lonSlipSpeed;
            }
            else if (xAxisSelection == LogSettings.sTreadTemperature)
            {
                xyzValues[0] = treadTemp;
            }
            else if (xAxisSelection == LogSettings.sInnerTemperature)
            {
                xyzValues[0] = innerTemp;
            }
            else if (xAxisSelection == LogSettings.sRaceTime)
            {
                xyzValues[0] = raceTime;
            }
            else if (xAxisSelection == LogSettings.sTotalFriction)
            {
                xyzValues[0] = totalFrict;
            }
            else if (xAxisSelection == LogSettings.sTotalFrictionAngle)
            {
                xyzValues[0] = totalFrictAngle;
            }
            else if (xAxisSelection == LogSettings.sSuspensionLength)
            {
                xyzValues[0] = suspLength;
            }
            else if (xAxisSelection == LogSettings.sSuspensionVelocity)
            {
                xyzValues[0] = suspVel;
            }
            else//fallback to slip angle
            {
                xyzValues[0] = slipAngleDeg;
            }
            //Y
            if (yAxisSelection == LogSettings.sTireTravelSpeed)
            {
                xyzValues[1] = travelSpeed;
            }
            else if (yAxisSelection == LogSettings.sAngularVelocity)
            {
                xyzValues[1] = angVel;
            }
            else if (yAxisSelection == LogSettings.sVerticalLoad)
            {
                xyzValues[1] = verLoad;
            }
            else if (yAxisSelection == LogSettings.sVerticalDeflection)
            {
                xyzValues[1] = verDefl;
            }
            else if (yAxisSelection == LogSettings.sLoadedRadius)
            {
                xyzValues[1] = loadRadius;
            }
            else if (yAxisSelection == LogSettings.sEffectiveRadius)
            {
                xyzValues[1] = effRadius;
            }
            else if (yAxisSelection == LogSettings.sContactLength)
            {
                xyzValues[1] = contLength;
            }
            else if (yAxisSelection == LogSettings.sBrakeTorque)
            {
                xyzValues[1] = currContBrakeTorq;
            }
            else if (yAxisSelection == LogSettings.sMaxBrakeTorque)
            {
                xyzValues[1] = currContBrakeTorqMax;
            }
            else if (yAxisSelection == LogSettings.sSteerAngle)
            {
                xyzValues[1] = steerAngDeg;
            }
            else if (yAxisSelection == LogSettings.sCamberAngle)
            {
                xyzValues[1] = cambAngDeg;
            }
            else if (yAxisSelection == LogSettings.sLateralLoad)
            {
                xyzValues[1] = latLoad;
            }
            else if (yAxisSelection == LogSettings.sSlipAngle)
            {
                xyzValues[1] = slipAngleDeg;
            }
            else if (yAxisSelection == LogSettings.sLateralFriction)
            {
                xyzValues[1] = latFrict;
            }
            else if (yAxisSelection == LogSettings.sLateralSlipSpeed)
            {
                xyzValues[1] = latSlipSpeed;
            }
            else if (yAxisSelection == LogSettings.sLongitudinalLoad)
            {
                xyzValues[1] = lonLoad;
            }
            else if (yAxisSelection == LogSettings.sSlipRatio)
            {
                xyzValues[1] = slipRatio;
            }
            else if (yAxisSelection == LogSettings.sLongitudinalFriction)
            {
                xyzValues[1] = lonFrict;
            }
            else if (yAxisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                xyzValues[1] = lonSlipSpeed;
            }
            else if (yAxisSelection == LogSettings.sTreadTemperature)
            {
                xyzValues[1] = treadTemp;
            }
            else if (yAxisSelection == LogSettings.sInnerTemperature)
            {
                xyzValues[1] = innerTemp;
            }
            else if (yAxisSelection == LogSettings.sRaceTime)
            {
                xyzValues[1] = raceTime;
            }
            else if (yAxisSelection == LogSettings.sTotalFriction)
            {
                xyzValues[1] = totalFrict;
            }
            else if (yAxisSelection == LogSettings.sTotalFrictionAngle)
            {
                xyzValues[1] = totalFrictAngle;
            }
            else if (yAxisSelection == LogSettings.sSuspensionLength)
            {
                xyzValues[1] = suspLength;
            }
            else if (yAxisSelection == LogSettings.sSuspensionVelocity)
            {
                xyzValues[1] = suspVel;
            }
            else//fallback to lateral friction
            {
                xyzValues[1] = latFrict;
            }
            //Z
            if (zAxisSelection == LogSettings.sTireTravelSpeed)
            {
                xyzValues[2] = travelSpeed;
            }
            else if (zAxisSelection == LogSettings.sAngularVelocity)
            {
                xyzValues[2] = angVel;
            }
            else if (zAxisSelection == LogSettings.sVerticalLoad)
            {
                xyzValues[2] = verLoad;
            }
            else if (zAxisSelection == LogSettings.sVerticalDeflection)
            {
                xyzValues[2] = verDefl;
            }
            else if (zAxisSelection == LogSettings.sLoadedRadius)
            {
                xyzValues[2] = loadRadius;
            }
            else if (zAxisSelection == LogSettings.sEffectiveRadius)
            {
                xyzValues[2] = effRadius;
            }
            else if (zAxisSelection == LogSettings.sContactLength)
            {
                xyzValues[2] = contLength;
            }
            else if (zAxisSelection == LogSettings.sBrakeTorque)
            {
                xyzValues[2] = currContBrakeTorq;
            }
            else if (zAxisSelection == LogSettings.sMaxBrakeTorque)
            {
                xyzValues[2] = currContBrakeTorqMax;
            }
            else if (zAxisSelection == LogSettings.sSteerAngle)
            {
                xyzValues[2] = steerAngDeg;
            }
            else if (zAxisSelection == LogSettings.sCamberAngle)
            {
                xyzValues[2] = cambAngDeg;
            }
            else if (zAxisSelection == LogSettings.sLateralLoad)
            {
                xyzValues[2] = latLoad;
            }
            else if (zAxisSelection == LogSettings.sSlipAngle)
            {
                xyzValues[2] = slipAngleDeg;
            }
            else if (zAxisSelection == LogSettings.sLateralFriction)
            {
                xyzValues[2] = latFrict;
            }
            else if (zAxisSelection == LogSettings.sLateralSlipSpeed)
            {
                xyzValues[2] = latSlipSpeed;
            }
            else if (zAxisSelection == LogSettings.sLongitudinalLoad)
            {
                xyzValues[2] = lonLoad;
            }
            else if (zAxisSelection == LogSettings.sSlipRatio)
            {
                xyzValues[2] = slipRatio;
            }
            else if (zAxisSelection == LogSettings.sLongitudinalFriction)
            {
                xyzValues[2] = lonFrict;
            }
            else if (zAxisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                xyzValues[2] = lonSlipSpeed;
            }
            else if (zAxisSelection == LogSettings.sTreadTemperature)
            {
                xyzValues[2] = treadTemp;
            }
            else if (zAxisSelection == LogSettings.sInnerTemperature)
            {
                xyzValues[2] = innerTemp;
            }
            else if (zAxisSelection == LogSettings.sRaceTime)
            {
                xyzValues[2] = raceTime;
            }
            else if (zAxisSelection == LogSettings.sTotalFriction)
            {
                xyzValues[2] = totalFrict;
            }
            else if (zAxisSelection == LogSettings.sTotalFrictionAngle)
            {
                xyzValues[2] = totalFrictAngle;
            }
            else if (zAxisSelection == LogSettings.sSuspensionLength)
            {
                xyzValues[2] = suspLength;
            }
            else if (zAxisSelection == LogSettings.sSuspensionVelocity)
            {
                xyzValues[2] = suspVel;
            }
            else//fallback to vertical load
            {
                xyzValues[2] = verLoad;
            }
            //Return the XYZ values array
            return xyzValues;
        }
        public static float[] LimiterListSelections(string limiter1Selection, string limiter2Selection, string limiter3Selection,
                                                int raceTime, float travelSpeed, float angVel,
                                                float verLoad, float verDefl, float loadRadius, float effRadius, float contLength,
                                                float currContBrakeTorq, float currContBrakeTorqMax,
                                                float steerAngDeg, float cambAngDeg,
                                                float latLoad, float slipAngleDeg, float latFrict, float latSlipSpeed,
                                                float lonLoad, float slipRatio, float lonFrict, float lonSlipSpeed,
                                                float treadTemp, float innerTemp,
                                                float totalFrict, float totalFrictAngle,
                                                float suspLength, float suspVel)
        {
            float[] limiters = new float[3];
            //Limiter1
            if (limiter1Selection == LogSettings.sTireTravelSpeed)
            {
                limiters[0] = travelSpeed;
            }
            else if (limiter1Selection == LogSettings.sAngularVelocity)
            {
                limiters[0] = angVel;
            }
            else if (limiter1Selection == LogSettings.sVerticalLoad)
            {
                limiters[0] = verLoad;
            }
            else if (limiter1Selection == LogSettings.sVerticalDeflection)
            {
                limiters[0] = verDefl;
            }
            else if (limiter1Selection == LogSettings.sLoadedRadius)
            {
                limiters[0] = loadRadius;
            }
            else if (limiter1Selection == LogSettings.sEffectiveRadius)
            {
                limiters[0] = effRadius;
            }
            else if (limiter1Selection == LogSettings.sContactLength)
            {
                limiters[0] = contLength;
            }
            else if (limiter1Selection == LogSettings.sBrakeTorque)
            {
                limiters[0] = currContBrakeTorq;
            }
            else if (limiter1Selection == LogSettings.sMaxBrakeTorque)
            {
                limiters[0] = currContBrakeTorqMax;
            }
            else if (limiter1Selection == LogSettings.sSteerAngle)
            {
                limiters[0] = steerAngDeg;
            }
            else if (limiter1Selection == LogSettings.sCamberAngle)
            {
                limiters[0] = cambAngDeg;
            }
            else if (limiter1Selection == LogSettings.sLateralLoad)
            {
                limiters[0] = latLoad;
            }
            else if (limiter1Selection == LogSettings.sSlipAngle)
            {
                limiters[0] = slipAngleDeg;
            }
            else if (limiter1Selection == LogSettings.sLateralFriction)
            {
                limiters[0] = latFrict;
            }
            else if (limiter1Selection == LogSettings.sLateralSlipSpeed)
            {
                limiters[0] = latSlipSpeed;
            }
            else if (limiter1Selection == LogSettings.sLongitudinalLoad)
            {
                limiters[0] = lonLoad;
            }
            else if (limiter1Selection == LogSettings.sSlipRatio)
            {
                limiters[0] = slipRatio;
            }
            else if (limiter1Selection == LogSettings.sLongitudinalFriction)
            {
                limiters[0] = lonFrict;
            }
            else if (limiter1Selection == LogSettings.sLongitudinalSlipSpeed)
            {
                limiters[0] = lonSlipSpeed;
            }
            else if (limiter1Selection == LogSettings.sTreadTemperature)
            {
                limiters[0] = treadTemp;
            }
            else if (limiter1Selection == LogSettings.sInnerTemperature)
            {
                limiters[0] = innerTemp;
            }
            else if (limiter1Selection == LogSettings.sRaceTime)
            {
                limiters[0] = raceTime;
            }
            else if (limiter1Selection == LogSettings.sTotalFriction)
            {
                limiters[0] = totalFrict;
            }
            else if (limiter1Selection == LogSettings.sTotalFrictionAngle)
            {
                limiters[0] = totalFrictAngle;
            }
            else if (limiter1Selection == LogSettings.sSuspensionLength)
            {
                limiters[0] = suspLength;
            }
            else if (limiter1Selection == LogSettings.sSuspensionVelocity)
            {
                limiters[0] = suspVel;
            }
            else//fallback to slip angle
            {
                limiters[0] = slipAngleDeg;
            }
            //Limiter2
            if (limiter2Selection == LogSettings.sTireTravelSpeed)
            {
                limiters[1] = travelSpeed;
            }
            else if (limiter2Selection == LogSettings.sAngularVelocity)
            {
                limiters[1] = angVel;
            }
            else if (limiter2Selection == LogSettings.sVerticalLoad)
            {
                limiters[1] = verLoad;
            }
            else if (limiter2Selection == LogSettings.sVerticalDeflection)
            {
                limiters[1] = verDefl;
            }
            else if (limiter2Selection == LogSettings.sLoadedRadius)
            {
                limiters[1] = loadRadius;
            }
            else if (limiter2Selection == LogSettings.sEffectiveRadius)
            {
                limiters[1] = effRadius;
            }
            else if (limiter2Selection == LogSettings.sContactLength)
            {
                limiters[1] = contLength;
            }
            else if (limiter2Selection == LogSettings.sBrakeTorque)
            {
                limiters[1] = currContBrakeTorq;
            }
            else if (limiter2Selection == LogSettings.sMaxBrakeTorque)
            {
                limiters[1] = currContBrakeTorqMax;
            }
            else if (limiter2Selection == LogSettings.sSteerAngle)
            {
                limiters[1] = steerAngDeg;
            }
            else if (limiter2Selection == LogSettings.sCamberAngle)
            {
                limiters[1] = cambAngDeg;
            }
            else if (limiter2Selection == LogSettings.sLateralLoad)
            {
                limiters[1] = latLoad;
            }
            else if (limiter2Selection == LogSettings.sSlipAngle)
            {
                limiters[1] = slipAngleDeg;
            }
            else if (limiter2Selection == LogSettings.sLateralFriction)
            {
                limiters[1] = latFrict;
            }
            else if (limiter2Selection == LogSettings.sLateralSlipSpeed)
            {
                limiters[1] = latSlipSpeed;
            }
            else if (limiter2Selection == LogSettings.sLongitudinalLoad)
            {
                limiters[1] = lonLoad;
            }
            else if (limiter2Selection == LogSettings.sSlipRatio)
            {
                limiters[1] = slipRatio;
            }
            else if (limiter2Selection == LogSettings.sLongitudinalFriction)
            {
                limiters[1] = lonFrict;
            }
            else if (limiter2Selection == LogSettings.sLongitudinalSlipSpeed)
            {
                limiters[1] = lonSlipSpeed;
            }
            else if (limiter2Selection == LogSettings.sTreadTemperature)
            {
                limiters[1] = treadTemp;
            }
            else if (limiter2Selection == LogSettings.sInnerTemperature)
            {
                limiters[1] = innerTemp;
            }
            else if (limiter2Selection == LogSettings.sRaceTime)
            {
                limiters[1] = raceTime;
            }
            else if (limiter2Selection == LogSettings.sTotalFriction)
            {
                limiters[1] = totalFrict;
            }
            else if (limiter2Selection == LogSettings.sTotalFrictionAngle)
            {
                limiters[1] = totalFrictAngle;
            }
            else if (limiter2Selection == LogSettings.sSuspensionLength)
            {
                limiters[1] = suspLength;
            }
            else if (limiter2Selection == LogSettings.sSuspensionVelocity)
            {
                limiters[1] = suspVel;
            }
            else//fallback to lateral friction
            {
                limiters[1] = latFrict;
            }
            //Limiter3
            if (limiter3Selection == LogSettings.sTireTravelSpeed)
            {
                limiters[2] = travelSpeed;
            }
            else if (limiter3Selection == LogSettings.sAngularVelocity)
            {
                limiters[2] = angVel;
            }
            else if (limiter3Selection == LogSettings.sVerticalLoad)
            {
                limiters[2] = verLoad;
            }
            else if (limiter3Selection == LogSettings.sVerticalDeflection)
            {
                limiters[2] = verDefl;
            }
            else if (limiter3Selection == LogSettings.sLoadedRadius)
            {
                limiters[2] = loadRadius;
            }
            else if (limiter3Selection == LogSettings.sEffectiveRadius)
            {
                limiters[2] = effRadius;
            }
            else if (limiter3Selection == LogSettings.sContactLength)
            {
                limiters[2] = contLength;
            }
            else if (limiter3Selection == LogSettings.sBrakeTorque)
            {
                limiters[2] = currContBrakeTorq;
            }
            else if (limiter3Selection == LogSettings.sMaxBrakeTorque)
            {
                limiters[2] = currContBrakeTorqMax;
            }
            else if (limiter3Selection == LogSettings.sSteerAngle)
            {
                limiters[2] = steerAngDeg;
            }
            else if (limiter3Selection == LogSettings.sCamberAngle)
            {
                limiters[2] = cambAngDeg;
            }
            else if (limiter3Selection == LogSettings.sLateralLoad)
            {
                limiters[2] = latLoad;
            }
            else if (limiter3Selection == LogSettings.sSlipAngle)
            {
                limiters[2] = slipAngleDeg;
            }
            else if (limiter3Selection == LogSettings.sLateralFriction)
            {
                limiters[2] = latFrict;
            }
            else if (limiter3Selection == LogSettings.sLateralSlipSpeed)
            {
                limiters[2] = latSlipSpeed;
            }
            else if (limiter3Selection == LogSettings.sLongitudinalLoad)
            {
                limiters[2] = lonLoad;
            }
            else if (limiter3Selection == LogSettings.sSlipRatio)
            {
                limiters[2] = slipRatio;
            }
            else if (limiter3Selection == LogSettings.sLongitudinalFriction)
            {
                limiters[2] = lonFrict;
            }
            else if (limiter3Selection == LogSettings.sLongitudinalSlipSpeed)
            {
                limiters[2] = lonSlipSpeed;
            }
            else if (limiter3Selection == LogSettings.sTreadTemperature)
            {
                limiters[2] = treadTemp;
            }
            else if (limiter3Selection == LogSettings.sInnerTemperature)
            {
                limiters[2] = innerTemp;
            }
            else if (limiter3Selection == LogSettings.sRaceTime)
            {
                limiters[2] = raceTime;
            }
            else if (limiter3Selection == LogSettings.sTotalFriction)
            {
                limiters[2] = totalFrict;
            }
            else if (limiter3Selection == LogSettings.sTotalFrictionAngle)
            {
                limiters[2] = totalFrictAngle;
            }
            else if (limiter3Selection == LogSettings.sSuspensionLength)
            {
                limiters[2] = suspLength;
            }
            else if (limiter3Selection == LogSettings.sSuspensionVelocity)
            {
                limiters[2] = suspVel;
            }
            else//fallback to vertical load
            {
                limiters[2] = verLoad;
            }
            //Return the XYZ values array
            return limiters;
        }
        private static void AddColorDataAndHandleHistoryBuffer(List<double> colorValues, double data)
        {
            if (_4WheelsSettings.AbsoluteValues == true)
            {
                colorValues.Add(Math.Abs(data));
            }
            else
            {
                colorValues.Add(data);
            }
            if (colorValues.Count > _4WheelsSettings.HistoryAmountPoints)
            {
                colorValues.RemoveAt(0);
            }
        }
        private static void ColorGradient(double dataX, double dataY, 
            double dataZ,
            List<double> xValuesColor1, List<double> yValuesColor1,
            List<double> xValuesColor2, List<double> yValuesColor2,
            List<double> xValuesColor3, List<double> yValuesColor3,
            List<double> xValuesColor4, List<double> yValuesColor4,
            List<double> xValuesColor5, List<double> yValuesColor5,
            List<double> xValuesColor6, List<double> yValuesColor6,
            List<double> xValuesColor7, List<double> yValuesColor7,
            List<double> xValuesColor8, List<double> yValuesColor8,
            List<double> xValuesColor9, List<double> yValuesColor9,
            List<double> xValuesColor10, List<double> yValuesColor10)
        {

            //double Xdata = Math.Abs(dataX);
            //double Ydata = Math.Abs(dataY);
            double Zdata = Math.Abs(dataZ);

            double minus = (_4WheelsSettings.Z1Max - _4WheelsSettings.Z1Min) / Steps;
            double ten = _4WheelsSettings.Z1Max;
            double nine = ten - minus;
            double eight = nine - minus;
            double seven = eight - minus;
            double six = seven - minus;
            double five = six - minus;
            double four = five - minus;
            double three = four - minus;
            double two = three - minus;
            double one = two - minus;
            double zero = one - minus;

            if (Zdata >= nine)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor10, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor10, dataY);
            }
            else if (Zdata < nine && Zdata >= eight)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor9, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor9, dataY);
            }
            else if (Zdata < eight && Zdata >= seven)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor8, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor8, dataY);
            }
            else if (Zdata < seven && Zdata >= six)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor7, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor7, dataY);
            }
            else if (Zdata < six && Zdata >= five)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor6, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor6, dataY);
            }
            else if (Zdata < five && Zdata >= four)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor5, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor5, dataY);
            }
            else if (Zdata < four && Zdata >= three)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor4, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor4, dataY);
            }
            else if (Zdata < three && Zdata >= two)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor3, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor3, dataY);
            }
            else if (Zdata < two && Zdata >= one)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor2, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor2, dataY);
            }
            else if (Zdata < one && Zdata >= zero)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor1, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor1, dataY);
            }
            else
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor1, dataX);
                AddColorDataAndHandleHistoryBuffer(yValuesColor1, dataY);
            }
        }
        public static bool LimiterIsAbsoluteValue(string limiter)
        {
            return LimiterSelectionIsAbsoluteValue(limiter);
        }
        public static bool OverTheChosenLimiter(double limiterData1, double limiterData2, double limiterData3)
        {
            bool limiter1IsAbsoluteValue = LimiterIsAbsoluteValue(Form4Wheels.X1LimiterSelection);
            bool limiter2IsAbsoluteValue = LimiterIsAbsoluteValue(Form4Wheels.Y1LimiterSelection);
            bool limiter3IsAbsoluteValue = LimiterIsAbsoluteValue(Form4Wheels.Z1LimiterSelection);
            if (limiter1IsAbsoluteValue == true)
            {
                if(Math.Abs(limiterData1) > Form4Wheels.X1LimiterMax || Math.Abs(limiterData1) < Form4Wheels.X1LimiterMin)
                {
                    return true;
                }
            }
            else if (limiterData1 > Form4Wheels.X1LimiterMax || limiterData1 < Form4Wheels.X1LimiterMin)
            {
                return true;
            }
            if (limiter2IsAbsoluteValue == true)
            {
                if (Math.Abs(limiterData2) > Form4Wheels.Y1LimiterMax || Math.Abs(limiterData2) < Form4Wheels.Y1LimiterMin)
                {
                    return true;
                }
            }
            else if (limiterData2 > Form4Wheels.Y1LimiterMax || limiterData2 < Form4Wheels.Y1LimiterMin)
            {
                return true;
            }
            if (limiter3IsAbsoluteValue == true)
            {
                if (Math.Abs(limiterData3) > Form4Wheels.Z1LimiterMax || Math.Abs(limiterData3) < Form4Wheels.Z1LimiterMin)
                {
                    return true;
                }
            }
            else if (limiterData3 > Form4Wheels.Z1LimiterMax || limiterData3 < Form4Wheels.Z1LimiterMin)
            {
                return true;
            }
            return false;
        }

        public static void ListSeries(Chart chartName, string seriesName, double dataX, double dataY, double dataZ, double limiter1Data, double limiter2Data, double limiter3Data)
        {
            float noTireContactLimiter;
            List<double> X1Values; List<double> Y1Values; List<double> Z1Values;
            List<double> X1ValuesColor1; List<double> Y1ValuesColor1;
            List< double > X1ValuesColor2; List<double> Y1ValuesColor2;
            List< double > X1ValuesColor3; List<double> Y1ValuesColor3;
            List< double > X1ValuesColor4; List<double> Y1ValuesColor4;
            List< double > X1ValuesColor5; List<double> Y1ValuesColor5;
            List< double > X1ValuesColor6; List<double> Y1ValuesColor6;
            List< double > X1ValuesColor7; List<double> Y1ValuesColor7;
            List< double > X1ValuesColor8; List<double> Y1ValuesColor8;
            List< double > X1ValuesColor9; List<double> Y1ValuesColor9;
            List< double > X1ValuesColor10; List<double> Y1ValuesColor10;

            if (seriesName == _4Wheels.SeriesFL)
            {
                noTireContactLimiter = LiveData.FL_VerticalLoad;
                X1Values = _4Wheels.FL_X1ValuesChart;
                X1ValuesColor1 = _4Wheels.FL_X1ValuesChartColor1;
                X1ValuesColor2 = _4Wheels.FL_X1ValuesChartColor2;
                X1ValuesColor3 = _4Wheels.FL_X1ValuesChartColor3;
                X1ValuesColor4 = _4Wheels.FL_X1ValuesChartColor4;
                X1ValuesColor5 = _4Wheels.FL_X1ValuesChartColor5;
                X1ValuesColor6 = _4Wheels.FL_X1ValuesChartColor6;
                X1ValuesColor7 = _4Wheels.FL_X1ValuesChartColor7;
                X1ValuesColor8 = _4Wheels.FL_X1ValuesChartColor8;
                X1ValuesColor9 = _4Wheels.FL_X1ValuesChartColor9;
                X1ValuesColor10 = _4Wheels.FL_X1ValuesChartColor10;
                Y1Values = _4Wheels.FL_Y1ValuesChart;
                Y1ValuesColor1 = _4Wheels.FL_Y1ValuesChartColor1;
                Y1ValuesColor2 = _4Wheels.FL_Y1ValuesChartColor2;
                Y1ValuesColor3 = _4Wheels.FL_Y1ValuesChartColor3;
                Y1ValuesColor4 = _4Wheels.FL_Y1ValuesChartColor4;
                Y1ValuesColor5 = _4Wheels.FL_Y1ValuesChartColor5;
                Y1ValuesColor6 = _4Wheels.FL_Y1ValuesChartColor6;
                Y1ValuesColor7 = _4Wheels.FL_Y1ValuesChartColor7;
                Y1ValuesColor8 = _4Wheels.FL_Y1ValuesChartColor8;
                Y1ValuesColor9 = _4Wheels.FL_Y1ValuesChartColor9;
                Y1ValuesColor10 = _4Wheels.FL_Y1ValuesChartColor10;
                Z1Values = _4Wheels.FL_Z1ValuesChart;
            }
            else if(seriesName == _4Wheels.SeriesFR)
            {
                noTireContactLimiter = LiveData.FR_VerticalLoad;
                X1Values = _4Wheels.FR_X1ValuesChart;
                X1ValuesColor1 = _4Wheels.FR_X1ValuesChartColor1;
                X1ValuesColor2 = _4Wheels.FR_X1ValuesChartColor2;
                X1ValuesColor3 = _4Wheels.FR_X1ValuesChartColor3;
                X1ValuesColor4 = _4Wheels.FR_X1ValuesChartColor4;
                X1ValuesColor5 = _4Wheels.FR_X1ValuesChartColor5;
                X1ValuesColor6 = _4Wheels.FR_X1ValuesChartColor6;
                X1ValuesColor7 = _4Wheels.FR_X1ValuesChartColor7;
                X1ValuesColor8 = _4Wheels.FR_X1ValuesChartColor8;
                X1ValuesColor9 = _4Wheels.FR_X1ValuesChartColor9;
                X1ValuesColor10 = _4Wheels.FR_X1ValuesChartColor10;
                Y1Values = _4Wheels.FR_Y1ValuesChart;
                Y1ValuesColor1 = _4Wheels.FR_Y1ValuesChartColor1;
                Y1ValuesColor2 = _4Wheels.FR_Y1ValuesChartColor2;
                Y1ValuesColor3 = _4Wheels.FR_Y1ValuesChartColor3;
                Y1ValuesColor4 = _4Wheels.FR_Y1ValuesChartColor4;
                Y1ValuesColor5 = _4Wheels.FR_Y1ValuesChartColor5;
                Y1ValuesColor6 = _4Wheels.FR_Y1ValuesChartColor6;
                Y1ValuesColor7 = _4Wheels.FR_Y1ValuesChartColor7;
                Y1ValuesColor8 = _4Wheels.FR_Y1ValuesChartColor8;
                Y1ValuesColor9 = _4Wheels.FR_Y1ValuesChartColor9;
                Y1ValuesColor10 = _4Wheels.FR_Y1ValuesChartColor10;
                Z1Values = _4Wheels.FR_Z1ValuesChart;
            }
            else if (seriesName == _4Wheels.SeriesRL)
            {
                noTireContactLimiter = LiveData.RL_VerticalLoad;
                X1Values = _4Wheels.RL_X1ValuesChart;
                X1ValuesColor1 = _4Wheels.RL_X1ValuesChartColor1;
                X1ValuesColor2 = _4Wheels.RL_X1ValuesChartColor2;
                X1ValuesColor3 = _4Wheels.RL_X1ValuesChartColor3;
                X1ValuesColor4 = _4Wheels.RL_X1ValuesChartColor4;
                X1ValuesColor5 = _4Wheels.RL_X1ValuesChartColor5;
                X1ValuesColor6 = _4Wheels.RL_X1ValuesChartColor6;
                X1ValuesColor7 = _4Wheels.RL_X1ValuesChartColor7;
                X1ValuesColor8 = _4Wheels.RL_X1ValuesChartColor8;
                X1ValuesColor9 = _4Wheels.RL_X1ValuesChartColor9;
                X1ValuesColor10 = _4Wheels.RL_X1ValuesChartColor10;
                Y1Values = _4Wheels.RL_Y1ValuesChart;
                Y1ValuesColor1 = _4Wheels.RL_Y1ValuesChartColor1;
                Y1ValuesColor2 = _4Wheels.RL_Y1ValuesChartColor2;
                Y1ValuesColor3 = _4Wheels.RL_Y1ValuesChartColor3;
                Y1ValuesColor4 = _4Wheels.RL_Y1ValuesChartColor4;
                Y1ValuesColor5 = _4Wheels.RL_Y1ValuesChartColor5;
                Y1ValuesColor6 = _4Wheels.RL_Y1ValuesChartColor6;
                Y1ValuesColor7 = _4Wheels.RL_Y1ValuesChartColor7;
                Y1ValuesColor8 = _4Wheels.RL_Y1ValuesChartColor8;
                Y1ValuesColor9 = _4Wheels.RL_Y1ValuesChartColor9;
                Y1ValuesColor10 = _4Wheels.RL_Y1ValuesChartColor10;
                Z1Values = _4Wheels.RL_Z1ValuesChart;
            }
            else//RR(seriesName == _4Wheels.SeriesRR)
            {
                noTireContactLimiter = LiveData.RR_VerticalLoad;
                X1Values = _4Wheels.RR_X1ValuesChart;
                X1ValuesColor1 = _4Wheels.RR_X1ValuesChartColor1;
                X1ValuesColor2 = _4Wheels.RR_X1ValuesChartColor2;
                X1ValuesColor3 = _4Wheels.RR_X1ValuesChartColor3;
                X1ValuesColor4 = _4Wheels.RR_X1ValuesChartColor4;
                X1ValuesColor5 = _4Wheels.RR_X1ValuesChartColor5;
                X1ValuesColor6 = _4Wheels.RR_X1ValuesChartColor6;
                X1ValuesColor7 = _4Wheels.RR_X1ValuesChartColor7;
                X1ValuesColor8 = _4Wheels.RR_X1ValuesChartColor8;
                X1ValuesColor9 = _4Wheels.RR_X1ValuesChartColor9;
                X1ValuesColor10 = _4Wheels.RR_X1ValuesChartColor10;
                Y1Values = _4Wheels.RR_Y1ValuesChart;
                Y1ValuesColor1 = _4Wheels.RR_Y1ValuesChartColor1;
                Y1ValuesColor2 = _4Wheels.RR_Y1ValuesChartColor2;
                Y1ValuesColor3 = _4Wheels.RR_Y1ValuesChartColor3;
                Y1ValuesColor4 = _4Wheels.RR_Y1ValuesChartColor4;
                Y1ValuesColor5 = _4Wheels.RR_Y1ValuesChartColor5;
                Y1ValuesColor6 = _4Wheels.RR_Y1ValuesChartColor6;
                Y1ValuesColor7 = _4Wheels.RR_Y1ValuesChartColor7;
                Y1ValuesColor8 = _4Wheels.RR_Y1ValuesChartColor8;
                Y1ValuesColor9 = _4Wheels.RR_Y1ValuesChartColor9;
                Y1ValuesColor10 = _4Wheels.RR_Y1ValuesChartColor10;
                Z1Values = _4Wheels.RR_Z1ValuesChart;
            }
            if (_4WheelsSettings.AbsoluteValues == true)
            {
                dataX = Math.Abs(dataX);
                dataY = Math.Abs(dataY);
                dataZ = Math.Abs(dataZ);
            }
            // No tire contact, no data added
            if (Form4Wheels.NoTireContactLimiterEnabled == true)
            {
                if (noTireContactLimiter == 0)
                {
                    return;
                }
            }
            //Limiter filters
            if (Form4Wheels.LimitersEnabled == true)
            {
                bool isOverTheLimiter = _4Wheels.OverTheChosenLimiter(limiter1Data, limiter2Data, limiter3Data);
                if (/*noTireContactLimiter == 0 || */isOverTheLimiter == true)
                {
                    return;
                }
            }
            // Add data if the previous stuff didn't return back
            X1Values.Add(dataX);
            Y1Values.Add(dataY);
            Z1Values.Add(dataZ);

            if (X1Values.Count > 1)
            {
                X1Values.RemoveAt(0);
                Y1Values.RemoveAt(0);
                Z1Values.RemoveAt(0);
            }

            ColorGradient(dataX, dataY, 
                dataZ,
            X1ValuesColor1, Y1ValuesColor1,
            X1ValuesColor2, Y1ValuesColor2,
            X1ValuesColor3, Y1ValuesColor3,
            X1ValuesColor4, Y1ValuesColor4,
            X1ValuesColor5, Y1ValuesColor5,
            X1ValuesColor6, Y1ValuesColor6,
            X1ValuesColor7, Y1ValuesColor7,
            X1ValuesColor8, Y1ValuesColor8,
            X1ValuesColor9, Y1ValuesColor9,
            X1ValuesColor10, Y1ValuesColor10);
            chartName.Series[seriesName].Points.DataBindXY(X1Values, Y1Values);
            chartName.Series[seriesName + seriesColor1].Points.DataBindXY(X1ValuesColor1, Y1ValuesColor1);
            chartName.Series[seriesName + seriesColor2].Points.DataBindXY(X1ValuesColor2, Y1ValuesColor2);
            chartName.Series[seriesName + seriesColor3].Points.DataBindXY(X1ValuesColor3, Y1ValuesColor3);
            chartName.Series[seriesName + seriesColor4].Points.DataBindXY(X1ValuesColor4, Y1ValuesColor4);
            chartName.Series[seriesName + seriesColor5].Points.DataBindXY(X1ValuesColor5, Y1ValuesColor5);
            chartName.Series[seriesName + seriesColor6].Points.DataBindXY(X1ValuesColor6, Y1ValuesColor6);
            chartName.Series[seriesName + seriesColor7].Points.DataBindXY(X1ValuesColor7, Y1ValuesColor7);
            chartName.Series[seriesName + seriesColor8].Points.DataBindXY(X1ValuesColor8, Y1ValuesColor8);
            chartName.Series[seriesName + seriesColor9].Points.DataBindXY(X1ValuesColor9, Y1ValuesColor9);
            chartName.Series[seriesName + seriesColor10].Points.DataBindXY(X1ValuesColor10, Y1ValuesColor10);

            //ForLoopAxisList(chartName, 1, xValues, yValues, zValues);
            chartName.Series[seriesName].Points.Last().MarkerSize = 8;
            chartName.Series[seriesName].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesName].Points.Last().IsValueShownAsLabel = false;//true;
        }
    }
}
