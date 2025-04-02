using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    class _4Wheels
    {
        private static int Alpha { get; set; } = 255;
        private static int Divider { get; set; } = 2;
        private static int HistoryAlpha { get; set; } = 255;
        private static int HistoryColorDivider { get; set; } = 2;
        private static int Steps { get; set; } = 10;

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

        static SeriesChartType ChartType { get; set; } = _4WheelsSettings.SeriesChartType;
        static MarkerStyle MarkerStyle { get; set; } = MarkerStyle.Circle;
        static int MarkerSizeHistory { get; set; } = 2;
        private static Color Color10 { get; set; }
        private static Color Color9 { get; set; }
        private static Color Color8 { get; set; }
        private static Color Color7 { get; set; }
        private static Color Color6 { get; set; }
        private static Color Color5 { get; set; }
        private static Color Color4 { get; set; }
        private static Color Color3 { get; set; }
        private static Color Color2 { get; set; }
        private static Color Color1 { get; set; }
        private static void XYAxisDefaultsSelected(string XorY, bool dAxis, double dMax, double dMin, double dMajorInterval, int dDecimals, bool dMinorEnabled, int dMinorIntervalFraction)
        {
            if (dAxis == true)
            {
                if (XorY == "X")
                {
                    _4WheelsSettings.X1Max = dMax;
                    _4WheelsSettings.X1Min = dMin;
                    _4WheelsSettings.X1MajorInterval = dMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = dDecimals;
                    _4WheelsSettings.X1MinorEnabled = dMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = dMinorIntervalFraction;
                }
                else
                {
                    _4WheelsSettings.Y1Max = dMax;
                    _4WheelsSettings.Y1Min = dMin;
                    _4WheelsSettings.Y1MajorInterval = dMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = dDecimals;
                    _4WheelsSettings.Y1MinorEnabled = dMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = dMinorIntervalFraction;
                }
            }
        }
        private static void XYAxisDefaults(string XorY, string axisSelection, bool dAxis)
        {
            double dMax; double dMin; double dMajorInterval; int dDecimals; bool dMinorEnabled; int dMinorIntervalFraction;
            if (axisSelection == LogSettings.sRaceTime)
            {
                dMax = double.NaN;
                dMin = 0;
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = false;
                dMinorIntervalFraction = 60;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sTireTravelSpeed)
            {
                dMax = 400;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax / 2;
                }
                dMajorInterval = 100;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sAngularVelocity)
            {
                dMax = 400;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax / 2;
                }
                dMajorInterval = 100;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sVerticalLoad)
            {
                dMax = 10000;
                dMin = 0;
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sVerticalDeflection)
            {
                dMax = 0.15;
                dMin = 0;
                dMajorInterval = 0.03;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLoadedRadius)
            {
                dMax = 0.5;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sEffectiveRadius)
            {
                dMax = 0.5;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sContactLength)
            {
                dMax = 0.5;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;
                dMajorInterval = 500;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sMaxBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;
                dMajorInterval = 500;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sSteerAngle)
            {
                dMax = 45;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 15;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sCamberAngle)
            {
                dMax = 10;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 4;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLateralLoad)
            {
                dMax = 10000;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sSlipAngle)
            {
                dMax = 45;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 15;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLateralFriction)
            {
                dMax = 2;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.5;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLateralSlipSpeed)
            {
                dMax = 20;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 5;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLongitudinalLoad)
            {
                dMax = 10000;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sSlipRatio)
            {
                dMax = 1;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.2;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLongitudinalFriction)
            {
                dMax = 2;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.5;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                dMax = 20;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 5;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sTreadTemperature)
            {
                dMax = 380;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -20;
                }
                dMajorInterval = 20;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sInnerTemperature)
            {
                dMax = 380;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -20;
                }
                dMajorInterval = 20;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sTotalFriction)
            {
                dMax = 2;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.5;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sTotalFrictionAngle)
            {
                dMax = 360;
                dMin = 0;
                dMajorInterval = 90;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sSuspensionLength)
            {
                dMax = 1;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 4;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else if (axisSelection == LogSettings.sSuspensionVelocity)
            {
                dMax = 10;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 2;
                dDecimals = 4;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;

                XYAxisDefaultsSelected(XorY, dAxis, dMax, dMin, dMajorInterval, dDecimals, dMinorEnabled, dMinorIntervalFraction);
            }
            else
            {
                // Defaults auto scale
                dMax = double.NaN;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = double.NaN;
                }
                dMajorInterval = 0;
                dDecimals = 2;
                dMinorEnabled = false;
                dMinorIntervalFraction = 2;
            }
            //The most important part at the end
            if (XorY == "X")
            {
                _4WheelsSettings.X1Selection = axisSelection;
                _4WheelsSettings.X1DefaultMax = dMax;
                _4WheelsSettings.X1DefaultMin = dMin;
                _4WheelsSettings.X1DefaultMajorInterval = dMajorInterval;
                _4WheelsSettings.X1DefaultMajorDecimals = dDecimals;
                _4WheelsSettings.X1DefaultMinorEnabled = dMinorEnabled;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = dMinorIntervalFraction;
            }
            else
            {
                _4WheelsSettings.Y1Selection = axisSelection;
                _4WheelsSettings.Y1DefaultMax = dMax;
                _4WheelsSettings.Y1DefaultMin = dMin;
                _4WheelsSettings.Y1DefaultMajorInterval = dMajorInterval;
                _4WheelsSettings.Y1DefaultMajorDecimals = dDecimals;
                _4WheelsSettings.Y1DefaultMinorEnabled = dMinorEnabled;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = dMinorIntervalFraction;
            }
        }
        private static void ZAxisDefaultsSelected(bool dAxis, double dMax, double dMin)
        {
            if (dAxis == true)
            {
                _4WheelsSettings.Z1Max = dMax;
                _4WheelsSettings.Z1Min = dMin;
            }
        }
        private static void ZAxisDefaults(string axisSelection, bool dAxis)
        {
            double dMax; double dMin;

            if (axisSelection == LogSettings.sRaceTime)
            {
                dMax = double.NaN;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sTireTravelSpeed)
            {
                dMax = 400;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sAngularVelocity)
            {
                dMax = 400;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sVerticalLoad)
            {
                dMax = 10000;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sVerticalDeflection)
            {
                dMax = 0.15;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLoadedRadius)
            {
                dMax = 0.5;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sEffectiveRadius)
            {
                dMax = 0.5;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sContactLength)
            {
                dMax = 0.5;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sMaxBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSteerAngle)
            {
                dMax = 45;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sCamberAngle)
            {
                dMax = 10;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLateralLoad)
            {
                dMax = 10000;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSlipAngle)
            {
                dMax = 45;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLateralFriction)
            {
                dMax = 2;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLateralSlipSpeed)
            {
                dMax = 20;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLongitudinalLoad)
            {
                dMax = 10000;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSlipRatio)
            {
                dMax = 1;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLongitudinalFriction)
            {
                dMax = 2;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                dMax = 20;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sTreadTemperature)
            {
                dMax = 380;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sInnerTemperature)
            {
                dMax = 380;
                dMin = 0;


                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sTotalFriction)
            {
                dMax = 2;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sTotalFrictionAngle)
            {
                dMax = 360;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSuspensionLength)
            {
                dMax = 1;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSuspensionVelocity)
            {
                dMax = 10;
                dMin = 0;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else
            {
                // Defaults auto scale
                dMax = double.NaN;
                dMin = double.NaN;
            }

            //The most important part at the end
            _4WheelsSettings.Z1DefaultMax = dMax;
            _4WheelsSettings.Z1DefaultMin = dMin;
        }
        public static void ClearSeriesHistory(Chart chartName)
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
        public static void AddChart(Chart chartName, string chartAreaName)
        {
            if (chartName.ChartAreas.IsUniqueName(chartAreaName))
            {
                chartName.ChartAreas.Add(chartAreaName);
            }

            chartName.ChartAreas[chartAreaName].BackColor = _4WheelsSettings.BackgroundColor;

            // X Axis
            chartName.ChartAreas[chartAreaName].AxisX.Maximum = _4WheelsSettings.X1Max;
            chartName.ChartAreas[chartAreaName].AxisX.Minimum = _4WheelsSettings.X1Min;

            chartName.ChartAreas[chartAreaName].AxisX.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.Format = "F" + _4WheelsSettings.X1MajorDecimals;// decimals

            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.Font = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.ForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas[chartAreaName].AxisX.Title = _4WheelsSettings.X1Selection;
            chartName.ChartAreas[chartAreaName].AxisX.TitleFont = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisX.TitleForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.LineWidth = _4WheelsSettings.X1MajorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.LineColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.LineColor = Color.Transparent;// Need to do this for this specific line, because it's over the X axis lines.

            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.Enabled = _4WheelsSettings.X1MinorEnabled;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineDashStyle = _4WheelsSettings.X1MinorDashStyle;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineWidth = _4WheelsSettings.X1MinorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.Interval = chartName.ChartAreas[chartAreaName].AxisX.Interval / _4WheelsSettings.X1MinorIntervalFraction;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineColor = _4WheelsSettings.X1MinorColor;

            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.ButtonColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.LineColor = _4WheelsSettings.X1FontColor;
            chartName.ChartAreas[chartAreaName].AxisX.ScaleView.Zoomable = true;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.Enabled = true;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartName.ChartAreas[chartAreaName].CursorX.AutoScroll = true;
            chartName.ChartAreas[chartAreaName].CursorX.IsUserEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorX.IsUserSelectionEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorX.Interval = 0.01;
            chartName.ChartAreas[chartAreaName].CursorX.LineColor = _4WheelsSettings.MarkerColor;

            // Y Axis
            chartName.ChartAreas[chartAreaName].AxisY.Title = _4WheelsSettings.Y1Selection;
            chartName.ChartAreas[chartAreaName].AxisY.Minimum = _4WheelsSettings.Y1Min;
            chartName.ChartAreas[chartAreaName].AxisY.Maximum = _4WheelsSettings.Y1Max;

            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.Font = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.ForeColor = _4WheelsSettings.Y1FontColor;

            chartName.ChartAreas[chartAreaName].AxisY.Title = _4WheelsSettings.Y1Selection;
            chartName.ChartAreas[chartAreaName].AxisY.TitleFont = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisY.TitleForeColor = _4WheelsSettings.Y1FontColor;

            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.LineWidth = _4WheelsSettings.Y1MajorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.Format = "F" + _4WheelsSettings.Y1MajorDecimals;// decimals
            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.LineColor = _4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.Interval = _4WheelsSettings.Y1MajorInterval; // TickMark Interval
            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.Interval = _4WheelsSettings.Y1MajorInterval; // Major Grid Interval
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.Interval = _4WheelsSettings.Y1MajorInterval; // Major Grid Label Interval
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.IntervalOffset = 0;

            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.Enabled = _4WheelsSettings.Y1MinorEnabled;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineDashStyle = _4WheelsSettings.Y1MinorDashStyle;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineWidth = _4WheelsSettings.Y1MinorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.Interval = chartName.ChartAreas[chartAreaName].AxisY.Interval / _4WheelsSettings.Y1MinorIntervalFraction;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineColor = _4WheelsSettings.Y1MinorColor;

            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.ButtonColor = _4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.LineColor = _4WheelsSettings.Y1FontColor;
            chartName.ChartAreas[chartAreaName].AxisY.ScaleView.Zoomable = true;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.Enabled = true;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartName.ChartAreas[chartAreaName].CursorY.AutoScroll = true;
            chartName.ChartAreas[chartAreaName].CursorY.IsUserEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorY.IsUserSelectionEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorY.Interval = 0.01;
            chartName.ChartAreas[chartAreaName].CursorY.LineColor = _4WheelsSettings.MarkerColor;

            // Series marker stuff

        }
        private static void AddHistoryColorSeries(Chart chartName, string chartAreaName, string seriesName, Color color)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].ChartArea = chartAreaName;
            chartName.Series[seriesName].MarkerColor = color;
            chartName.Series[seriesName].ChartType = ChartType;
            chartName.Series[seriesName].MarkerStyle = MarkerStyle;
            chartName.Series[seriesName].MarkerSize = MarkerSizeHistory;
        }
        private static void AddSeries(Chart chartName, string chartAreaName, string seriesName)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].ChartArea = chartAreaName;
            chartName.Series[seriesName].MarkerColor = Color.FromArgb(HistoryAlpha, 128, 0, 0);//Color.Transparent;//
            chartName.Series[seriesName].ChartType = ChartType;
            chartName.Series[seriesName].MarkerStyle = MarkerStyle;
            chartName.Series[seriesName].MarkerSize = MarkerSizeHistory;
            chartName.Series[seriesName].SmartLabelStyle.Enabled = false;
            chartName.Series[seriesName].LabelBackColor = chartName.ChartAreas[chartAreaName].BackColor;
        }
        public static void SetChart(Chart chartName, string seriesName, string chartAreaName)
        {
            // New Marker color stuff
            chartName.BackColor = Color.Transparent;

            GetColorSchemeColors();

            XYAxisDefaults("X",
                         _4WheelsSettings.X1Selection,
                         _4WheelsSettings.X1Defaults);

            XYAxisDefaults("Y",
                         _4WheelsSettings.Y1Selection,
                         _4WheelsSettings.Y1Defaults);

            ZAxisDefaults(_4WheelsSettings.Z1Selection,
                          _4WheelsSettings.Z1Defaults);

            AddChart(chartName, chartAreaName);
            // New Marker color stuff
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor10, Color10);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor9, Color9);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor8, Color8);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor7, Color7);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor6, Color6);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor5, Color5);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor4, Color4);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor3, Color3);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor2, Color2);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + seriesColor1, Color1);

            AddSeries(chartName, chartAreaName, seriesName);
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
            return xyzValues;
        }
        private static void GetColorSchemeColors()
        {

            if (_4WheelsSettings.Scheme == "Colorblind")
            {
                // Colors from https://jacksonlab.agronomy.wisc.edu/2016/05/23/15-level-colorblind-friendly-palette/
                //Color color5 = Color.FromArgb(historyalpha, 255, 182, 219);// color5
                Color10 = Color.FromArgb(HistoryAlpha, 219, 109, 0);// color 13
                Color9 = Color.FromArgb(HistoryAlpha, 36, 255, 36);// color 14
                Color8 = Color.FromArgb(HistoryAlpha, 255, 255, 109);// color 15
                Color7 = Color.FromArgb(HistoryAlpha, 109, 182, 255);// color 9
                Color6 = Color.FromArgb(HistoryAlpha, 182, 109, 255);// color 8
                Color5 = Color.FromArgb(HistoryAlpha, 0, 109, 219);// color 7
                Color4 = Color.FromArgb(HistoryAlpha, 73, 0, 146);// color 6
                Color3 = Color.FromArgb(HistoryAlpha, 255, 109, 182);// color 4
                Color2 = Color.FromArgb(HistoryAlpha, 0, 146, 146);// color 3
                Color1 = Color.FromArgb(HistoryAlpha, 0, 73, 73);// color 2
            }
            else if (_4WheelsSettings.Scheme == "Green Red")
            {
                Color10 = Color.FromArgb(HistoryAlpha, 128 / HistoryColorDivider, 0 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color9 = Color.FromArgb(HistoryAlpha, 192 / HistoryColorDivider, 0 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color8 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 0 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color7 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 64 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color6 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 128 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color5 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 192 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color4 = Color.FromArgb(HistoryAlpha, 192 / HistoryColorDivider, 192 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color3 = Color.FromArgb(HistoryAlpha, 128 / HistoryColorDivider, 192 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color2 = Color.FromArgb(HistoryAlpha, 64 / HistoryColorDivider, 192 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color1 = Color.FromArgb(HistoryAlpha, 0 / HistoryColorDivider, 192 / HistoryColorDivider, 0 / HistoryColorDivider);
            }
            else
            {
                Color10 = Color.FromArgb(HistoryAlpha, 128 / HistoryColorDivider, 0 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color9 = Color.FromArgb(HistoryAlpha, 192 / HistoryColorDivider, 0 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color8 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 0 / HistoryColorDivider, 0 / HistoryColorDivider);
                Color7 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 0 / HistoryColorDivider, 64 / HistoryColorDivider);
                Color6 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 0 / HistoryColorDivider, 128 / HistoryColorDivider);
                Color5 = Color.FromArgb(HistoryAlpha, 255 / HistoryColorDivider, 0 / HistoryColorDivider, 192 / HistoryColorDivider);
                Color4 = Color.FromArgb(HistoryAlpha, 192 / HistoryColorDivider, 0 / HistoryColorDivider, 192 / HistoryColorDivider);
                Color3 = Color.FromArgb(HistoryAlpha, 128 / HistoryColorDivider, 0 / HistoryColorDivider, 192 / HistoryColorDivider);
                Color2 = Color.FromArgb(HistoryAlpha, 64 / HistoryColorDivider, 0 / HistoryColorDivider, 192 / HistoryColorDivider);
                Color1 = Color.FromArgb(HistoryAlpha, 0 / HistoryColorDivider, 0 / HistoryColorDivider, 192 / HistoryColorDivider);
            }
        }
        private static void ColorGradient(double dataX, double dataY, double dataZ,
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

            double Xdata = Math.Abs(dataX);
            double Ydata = Math.Abs(dataY);
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor10.Add(Math.Abs(Xdata));
                    yValuesColor10.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor10.Add(dataX);
                    yValuesColor10.Add(dataY);
                }
                if (xValuesColor10.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor10.RemoveAt(0);
                }
                if (yValuesColor10.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor10.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor10].MarkerColor = color10;
            }
            else if (Zdata < nine && Zdata >= eight)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor9.Add(Math.Abs(Xdata));
                    yValuesColor9.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor9.Add(dataX);
                    yValuesColor9.Add(dataY);
                }
                if (xValuesColor9.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor9.RemoveAt(0);
                }
                if (yValuesColor9.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor9.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor9].MarkerColor = color9;
            }
            else if (Zdata < eight && Zdata >= seven)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor8.Add(Math.Abs(Xdata));
                    yValuesColor8.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor8.Add(dataX);
                    yValuesColor8.Add(dataY);
                }
                if (xValuesColor8.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor8.RemoveAt(0);
                }
                if (yValuesColor8.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor8.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor8].MarkerColor = color8;
            }
            else if (Zdata < seven && Zdata >= six)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor7.Add(Math.Abs(Xdata));
                    yValuesColor7.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor7.Add(dataX);
                    yValuesColor7.Add(dataY);
                }
                if (xValuesColor7.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor7.RemoveAt(0);
                }
                if (yValuesColor7.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor7.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor7].MarkerColor = color7;
            }
            else if (Zdata < six && Zdata >= five)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor6.Add(Math.Abs(Xdata));
                    yValuesColor6.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor6.Add(dataX);
                    yValuesColor6.Add(dataY);
                }
                if (xValuesColor6.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor6.RemoveAt(0);
                }
                if (yValuesColor6.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor6.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor6].MarkerColor = color6;
            }
            else if (Zdata < five && Zdata >= four)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor5.Add(Math.Abs(Xdata));
                    yValuesColor5.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor5.Add(dataX);
                    yValuesColor5.Add(dataY);
                }
                if (xValuesColor5.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor5.RemoveAt(0);
                }
                if (yValuesColor5.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor5.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor5].MarkerColor = color5;
            }
            else if (Zdata < four && Zdata >= three)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor4.Add(Math.Abs(Xdata));
                    yValuesColor4.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor4.Add(dataX);
                    yValuesColor4.Add(dataY);
                }
                if (xValuesColor4.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor4.RemoveAt(0);
                }
                if (yValuesColor4.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor4.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor4].MarkerColor = color4;
            }
            else if (Zdata < three && Zdata >= two)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor3.Add(Math.Abs(Xdata));
                    yValuesColor3.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor3.Add(dataX);
                    yValuesColor3.Add(dataY);
                }
                if (xValuesColor3.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor3.RemoveAt(0);
                }
                if (yValuesColor3.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor3.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor3].MarkerColor = color3;
            }
            else if (Zdata < two && Zdata >= one)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor2.Add(Math.Abs(Xdata));
                    yValuesColor2.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor2.Add(dataX);
                    yValuesColor2.Add(dataY);
                }
                if (xValuesColor2.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor2.RemoveAt(0);
                }
                if (yValuesColor2.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor2.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor2].MarkerColor = color2;
            }
            else if (Zdata < one && Zdata >= zero)
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor1.Add(Math.Abs(Xdata));
                    yValuesColor1.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor1.Add(dataX);
                    yValuesColor1.Add(dataY);
                }
                if (xValuesColor1.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor1.RemoveAt(0);
                }
                if (yValuesColor1.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor1.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor1].MarkerColor = color1;
            }
            else
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValuesColor1.Add(Math.Abs(Xdata));
                    yValuesColor1.Add(Math.Abs(Ydata));
                }
                else
                {
                    xValuesColor1.Add(dataX);
                    yValuesColor1.Add(dataY);
                }
                if (xValuesColor1.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    xValuesColor1.RemoveAt(0);
                }
                if (yValuesColor1.Count > _4WheelsSettings.HistoryAmountPoints)
                {
                    yValuesColor1.RemoveAt(0);
                }
                //chartName.Series[seriesNameColor1].MarkerColor = color1;
            }
        }
        public static void ListSeries(Chart chartName, float noTireContactLimiter,
            string seriesName, double dataX, List<double> xValues, double dataY, List<double> yValues, double dataZ, List<double> zValues,
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
            // No tire contact, no data added
            if (noTireContactLimiter == 0)
            {
                return;
            }
            // Maybe some more filters here or do it somewhere else
            else// add data
            {
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    xValues.Add(Math.Abs(dataX));
                    yValues.Add(Math.Abs(dataY));
                    zValues.Add(Math.Abs(dataZ));
                }
                else
                {
                    xValues.Add(dataX);
                    yValues.Add(dataY);
                    zValues.Add(dataZ);
                }
                if (xValues.Count > 1)
                {
                    xValues.RemoveAt(0);
                    yValues.RemoveAt(0);
                    zValues.RemoveAt(0);
                }
            }
            ColorGradient(dataX, dataY, dataZ,
            xValuesColor1, yValuesColor1,
            xValuesColor2, yValuesColor2,
            xValuesColor3, yValuesColor3,
            xValuesColor4, yValuesColor4,
            xValuesColor5, yValuesColor5,
            xValuesColor6, yValuesColor6,
            xValuesColor7, yValuesColor7,
            xValuesColor8, yValuesColor8,
            xValuesColor9, yValuesColor9,
            xValuesColor10, yValuesColor10);
            chartName.Series[seriesName].Points.DataBindXY(xValues, yValues);
            chartName.Series[seriesName + seriesColor1].Points.DataBindXY(xValuesColor1, yValuesColor1);
            chartName.Series[seriesName + seriesColor2].Points.DataBindXY(xValuesColor2, yValuesColor2);
            chartName.Series[seriesName + seriesColor3].Points.DataBindXY(xValuesColor3, yValuesColor3);
            chartName.Series[seriesName + seriesColor4].Points.DataBindXY(xValuesColor4, yValuesColor4);
            chartName.Series[seriesName + seriesColor5].Points.DataBindXY(xValuesColor5, yValuesColor5);
            chartName.Series[seriesName + seriesColor6].Points.DataBindXY(xValuesColor6, yValuesColor6);
            chartName.Series[seriesName + seriesColor7].Points.DataBindXY(xValuesColor7, yValuesColor7);
            chartName.Series[seriesName + seriesColor8].Points.DataBindXY(xValuesColor8, yValuesColor8);
            chartName.Series[seriesName + seriesColor9].Points.DataBindXY(xValuesColor9, yValuesColor9);
            chartName.Series[seriesName + seriesColor10].Points.DataBindXY(xValuesColor10, yValuesColor10);

            //ForLoopAxisList(chartName, 1, xValues, yValues, zValues);
            chartName.Series[seriesName].Points.Last().MarkerSize = 8;
            chartName.Series[seriesName].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesName].Points.Last().IsValueShownAsLabel = false;//true;
        }
        public static void SetUpDownChart(Chart chartName)
        {

            double maxmin = _4WheelsSettings.Z1Max - _4WheelsSettings.Z1Min;
            double interval = maxmin / Steps;
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = _4WheelsSettings.Z1Min;

            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = 1;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = _4WheelsSettings.Z1Max;
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = interval;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = interval;
            chartName.Series["Series1"].Color = Color.Transparent;
            chartName.Series["Series1"].LabelBackColor = Color.Transparent;

            chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Clear();
            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (double i = _4WheelsSettings.Z1Min * Steps; i <= _4WheelsSettings.Z1Max * Steps; i += maxmin)
                {

                    double iminsteps = i - _4WheelsSettings.Z1Min * Steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == maxmin * 10)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 128 / Divider, 0 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 192 / Divider, 0 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 0 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 64 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 128 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 192 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 192 / Divider, 192 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 128 / Divider, 192 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 64 / Divider, 192 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 0 / Divider, 192 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / Steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / Steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }
            else if (_4WheelsSettings.Scheme == "Colorblind")
            {
                Color color2 = Color.FromArgb(HistoryAlpha, 0, 73, 73);
                Color color3 = Color.FromArgb(HistoryAlpha, 0, 146, 146);
                Color color4 = Color.FromArgb(HistoryAlpha, 255, 109, 182);
                //Color color5 = Color.FromArgb(historyalpha, 255, 182, 219);
                Color color6 = Color.FromArgb(HistoryAlpha, 73, 0, 146);
                Color color7 = Color.FromArgb(HistoryAlpha, 0, 109, 219);
                Color color8 = Color.FromArgb(HistoryAlpha, 182, 109, 255);
                Color color9 = Color.FromArgb(HistoryAlpha, 109, 182, 255);
                Color color15 = Color.FromArgb(HistoryAlpha, 255, 255, 109);
                Color color14 = Color.FromArgb(HistoryAlpha, 36, 255, 36);
                Color color13 = Color.FromArgb(HistoryAlpha, 219, 109, 0);

                for (double i = _4WheelsSettings.Z1Min * Steps; i <= _4WheelsSettings.Z1Max * Steps; i += maxmin)
                {

                    double iminsteps = i - _4WheelsSettings.Z1Min * Steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == maxmin * 10)
                    {
                        sl.BackColor = color13;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = color14;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = color15;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = color9;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = color8;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = color7;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = color6;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = color4;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = color3;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = color2;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / Steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / Steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }
            else
            {
                for (double i = _4WheelsSettings.Z1Min * Steps; i <= _4WheelsSettings.Z1Max * Steps; i += maxmin)
                {
                    double iminsteps = i - _4WheelsSettings.Z1Min * Steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == _4WheelsSettings.Z1Max * 10)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 128 / Divider, 0 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 192 / Divider, 0 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 0 / Divider, 0 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 0 / Divider, 64 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 0 / Divider, 128 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 255 / Divider, 0 / Divider, 192 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 192 / Divider, 0 / Divider, 192 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 128 / Divider, 0 / Divider, 192 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 64 / Divider, 0 / Divider, 192 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = Color.FromArgb(Alpha, 0 / Divider, 0 / Divider, 192 / Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / Steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / Steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }

        }
    }
}
