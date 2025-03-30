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

        private readonly static int alpha = 255;
        private readonly static int divider = 2;
        private readonly static int historyalpha = 255;
        private readonly static int historycolordivider = 2;
        private readonly static int steps = 10;

        public static string seriesFL { get; set; } = "SeriesFL";
        public static string seriesFR { get; set; } = "SeriesFR";
        public static string seriesRL { get; set; } = "SeriesRL";
        public static string seriesRR { get; set; } = "SeriesRR";

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

        public static double[] FL_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] FL_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] FL_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

        public static double[] FR_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] FR_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] FR_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

        public static double[] RL_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] RL_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] RL_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

        public static double[] RR_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] RR_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        public static double[] RR_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

        private static int uHistoryHelper = 2;

        public static void SetArrays()
        {
            FL_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            FL_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            FL_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

            FR_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            FR_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            FR_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

            RL_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            RL_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            RL_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];

            RR_X1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            RR_Y1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
            RR_Z1ValuesChartArray = new double[_4WheelsSettings.HistoryAmountPoints];
        }
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
        public static void SetChartBasics(Chart chartName)
        {
            chartName.ChartAreas["ChartArea1"].BackColor = _4WheelsSettings.BackgroundColor;

            // X Axis
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = _4WheelsSettings.X1Max;
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = _4WheelsSettings.X1Min;

            chartName.ChartAreas["ChartArea1"].AxisX.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F" + _4WheelsSettings.X1MajorDecimals;// decimals

            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisX.Title = _4WheelsSettings.X1Selection;
            chartName.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisX.TitleForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = _4WheelsSettings.X1MajorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Transparent;// Need to do this for this specific line, because it's over the X axis lines.

            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = _4WheelsSettings.X1MinorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = _4WheelsSettings.X1MinorDashStyle;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineWidth = _4WheelsSettings.X1MinorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = chartName.ChartAreas["ChartArea1"].AxisX.Interval / _4WheelsSettings.X1MinorIntervalFraction;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = _4WheelsSettings.X1MinorColor;

            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.LineColor = _4WheelsSettings.X1FontColor;
            chartName.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartName.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
            chartName.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            chartName.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            chartName.ChartAreas["ChartArea1"].CursorX.Interval = 0.01;
            chartName.ChartAreas["ChartArea1"].CursorX.LineColor = _4WheelsSettings.MarkerColor;

            // Y Axis
            chartName.ChartAreas["ChartArea1"].AxisY.Title = _4WheelsSettings.Y1Selection;
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = _4WheelsSettings.Y1Min;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = _4WheelsSettings.Y1Max;

            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = _4WheelsSettings.Y1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisY.Title = _4WheelsSettings.Y1Selection;
            chartName.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisY.TitleForeColor = _4WheelsSettings.Y1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = _4WheelsSettings.Y1MajorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "F" + _4WheelsSettings.Y1MajorDecimals;// decimals
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = _4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = _4WheelsSettings.Y1MajorInterval; // TickMark Interval
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = _4WheelsSettings.Y1MajorInterval; // Major Grid Interval
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Interval = _4WheelsSettings.Y1MajorInterval; // Major Grid Label Interval
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.IntervalOffset = 0;

            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = _4WheelsSettings.Y1MinorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = _4WheelsSettings.Y1MinorDashStyle;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineWidth = _4WheelsSettings.Y1MinorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chartName.ChartAreas["ChartArea1"].AxisY.Interval / _4WheelsSettings.Y1MinorIntervalFraction;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = _4WheelsSettings.Y1MinorColor;

            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.ButtonColor = _4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.LineColor = _4WheelsSettings.Y1FontColor;
            chartName.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.Enabled = true;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartName.ChartAreas["ChartArea1"].CursorY.AutoScroll = true;
            chartName.ChartAreas["ChartArea1"].CursorY.IsUserEnabled = true;
            chartName.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;
            chartName.ChartAreas["ChartArea1"].CursorY.Interval = 0.01;
            chartName.ChartAreas["ChartArea1"].CursorY.LineColor = _4WheelsSettings.MarkerColor;

            // Series marker stuff

        }
        private static void AddColorSeries(Chart chartName, string seriesName, Color color)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].MarkerColor = color;
            chartName.Series[seriesName].ChartType = chartType;
            chartName.Series[seriesName].MarkerStyle = markerStyle;
            chartName.Series[seriesName].MarkerSize = markerSize;
        }
        private static void AddSeries(Chart chartName, string seriesName)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);//Color.Transparent;//
            chartName.Series[seriesName].ChartType = chartType;
            chartName.Series[seriesName].MarkerStyle = markerStyle;
            chartName.Series[seriesName].MarkerSize = markerSize;
            chartName.Series[seriesName].SmartLabelStyle.Enabled = false;
            chartName.Series[seriesName].LabelBackColor = chartName.ChartAreas["ChartArea1"].BackColor;
        }
        public static void SetChart(Chart chartName, string seriesName)
        {
            // New Marker color stuff
            chartName.Series.Clear();
            chartName.BackColor = Color.Transparent;

            Colors();

            XYAxisDefaults("X",
                         _4WheelsSettings.X1Selection,
                         _4WheelsSettings.X1Defaults);

            XYAxisDefaults("Y",
                         _4WheelsSettings.Y1Selection,
                         _4WheelsSettings.Y1Defaults);

            ZAxisDefaults(_4WheelsSettings.Z1Selection, _4WheelsSettings.Z1Defaults);

            // New Marker color stuff
            AddColorSeries(chartName, seriesColor10, color10);
            AddColorSeries(chartName, seriesColor9, color9);
            AddColorSeries(chartName, seriesColor8, color8);
            AddColorSeries(chartName, seriesColor7, color7);
            AddColorSeries(chartName, seriesColor6, color6);
            AddColorSeries(chartName, seriesColor5, color5);
            AddColorSeries(chartName, seriesColor4, color4);
            AddColorSeries(chartName, seriesColor3, color3);
            AddColorSeries(chartName, seriesColor2, color2);
            AddColorSeries(chartName, seriesColor1, color1);

            AddSeries(chartName, seriesName);

            SetChartBasics(chartName);
        }
        public static void SetChartAllWheels(Chart chartName, string seriesNameFL, string seriesNameFR, string seriesNameRL, string seriesNameRR)
        {
            // New Marker color stuff
            chartName.Series.Clear();

            chartName.BackColor = Color.Transparent;

            Colors();

            XYAxisDefaults("X",
                         _4WheelsSettings.X1Selection,
                         _4WheelsSettings.X1Defaults);

            XYAxisDefaults("Y",
                         _4WheelsSettings.Y1Selection,
                         _4WheelsSettings.Y1Defaults);

            ZAxisDefaults(_4WheelsSettings.Z1Selection, _4WheelsSettings.Z1Defaults);

            // New Marker color stuff

            //FL
            AddColorSeries(chartName, seriesNameFL + seriesColor10, color10);
            AddColorSeries(chartName, seriesNameFL + seriesColor9, color9);
            AddColorSeries(chartName, seriesNameFL + seriesColor8, color8);
            AddColorSeries(chartName, seriesNameFL + seriesColor7, color7);
            AddColorSeries(chartName, seriesNameFL + seriesColor6, color6);
            AddColorSeries(chartName, seriesNameFL + seriesColor5, color5);
            AddColorSeries(chartName, seriesNameFL + seriesColor4, color4);
            AddColorSeries(chartName, seriesNameFL + seriesColor3, color3);
            AddColorSeries(chartName, seriesNameFL + seriesColor2, color2);
            AddColorSeries(chartName, seriesNameFL + seriesColor1, color1);

            AddSeries(chartName, seriesNameFL);

            //FR
            AddColorSeries(chartName, seriesNameFR + seriesColor10, color10);
            AddColorSeries(chartName, seriesNameFR + seriesColor9, color9);
            AddColorSeries(chartName, seriesNameFR + seriesColor8, color8);
            AddColorSeries(chartName, seriesNameFR + seriesColor7, color7);
            AddColorSeries(chartName, seriesNameFR + seriesColor6, color6);
            AddColorSeries(chartName, seriesNameFR + seriesColor5, color5);
            AddColorSeries(chartName, seriesNameFR + seriesColor4, color4);
            AddColorSeries(chartName, seriesNameFR + seriesColor3, color3);
            AddColorSeries(chartName, seriesNameFR + seriesColor2, color2);
            AddColorSeries(chartName, seriesNameFR + seriesColor1, color1);

            AddSeries(chartName, seriesNameFR);

            //RL
            AddColorSeries(chartName, seriesNameRL + seriesColor10, color10);
            AddColorSeries(chartName, seriesNameRL + seriesColor9, color9);
            AddColorSeries(chartName, seriesNameRL + seriesColor8, color8);
            AddColorSeries(chartName, seriesNameRL + seriesColor7, color7);
            AddColorSeries(chartName, seriesNameRL + seriesColor6, color6);
            AddColorSeries(chartName, seriesNameRL + seriesColor5, color5);
            AddColorSeries(chartName, seriesNameRL + seriesColor4, color4);
            AddColorSeries(chartName, seriesNameRL + seriesColor3, color3);
            AddColorSeries(chartName, seriesNameRL + seriesColor2, color2);
            AddColorSeries(chartName, seriesNameRL + seriesColor1, color1);

            AddSeries(chartName, seriesNameRL);

            //RR
            AddColorSeries(chartName, seriesNameRR + seriesColor10, color10);
            AddColorSeries(chartName, seriesNameRR + seriesColor9, color9);
            AddColorSeries(chartName, seriesNameRR + seriesColor8, color8);
            AddColorSeries(chartName, seriesNameRR + seriesColor7, color7);
            AddColorSeries(chartName, seriesNameRR + seriesColor6, color6);
            AddColorSeries(chartName, seriesNameRR + seriesColor5, color5);
            AddColorSeries(chartName, seriesNameRR + seriesColor4, color4);
            AddColorSeries(chartName, seriesNameRR + seriesColor3, color3);
            AddColorSeries(chartName, seriesNameRR + seriesColor2, color2);
            AddColorSeries(chartName, seriesNameRR + seriesColor1, color1);

            AddSeries(chartName, seriesNameRR);

            //Set basics of the chart
            SetChartBasics(chartName);
        }

        public static float[] XYZListSelections(string xAxisSelection, List<double> xValues,
                                                string yAxisSelection, List<double> yValues,
                                                string zAxisSelection, List<double> zValues,

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
        private static Color color10;
        private static Color color9;
        private static Color color8;
        private static Color color7;
        private static Color color6;
        private static Color color5;
        private static Color color4;
        private static Color color3;
        private static Color color2;
        private static Color color1;
        private static void Colors()
        {

            if (_4WheelsSettings.Scheme == "Colorblind")
            {
                // Colors from https://jacksonlab.agronomy.wisc.edu/2016/05/23/15-level-colorblind-friendly-palette/
                //Color color5 = Color.FromArgb(historyalpha, 255, 182, 219);// color5
                color10 = Color.FromArgb(historyalpha, 219, 109, 0);// color 13
                color9 = Color.FromArgb(historyalpha, 36, 255, 36);// color 14
                color8 = Color.FromArgb(historyalpha, 255, 255, 109);// color 15
                color7 = Color.FromArgb(historyalpha, 109, 182, 255);// color 9
                color6 = Color.FromArgb(historyalpha, 182, 109, 255);// color 8
                color5 = Color.FromArgb(historyalpha, 0, 109, 219);// color 7
                color4 = Color.FromArgb(historyalpha, 73, 0, 146);// color 6
                color3 = Color.FromArgb(historyalpha, 255, 109, 182);// color 4
                color2 = Color.FromArgb(historyalpha, 0, 146, 146);// color 3
                color1 = Color.FromArgb(historyalpha, 0, 73, 73);// color 2
            }
            else if (_4WheelsSettings.Scheme == "Green Red")
            {
                color10 = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                color9 = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                color8 = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                color7 = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                color6 = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                color5 = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                color4 = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                color3 = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                color2 = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                color1 = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
            }
            else
            {
                color10 = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                color9 = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                color8 = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                color7 = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 64 / historycolordivider);
                color6 = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 128 / historycolordivider);
                color5 = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                color4 = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                color3 = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                color2 = Color.FromArgb(historyalpha, 64 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                color1 = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
            }
        }
        private static void ColorGradientSuper(double dataX, double dataY, double dataZ,
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

            double minus = (_4WheelsSettings.Z1Max - _4WheelsSettings.Z1Min) / steps;
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
        public static void ListSeries(Chart chartName, string seriesName, double dataX, List<double> xValues, double dataY, List<double> yValues, double dataZ, List<double> zValues,
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
            ColorGradientSuper(dataX, dataY, dataZ,
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
            chartName.Series[seriesColor1].Points.DataBindXY(xValuesColor1, yValuesColor1);
            chartName.Series[seriesColor2].Points.DataBindXY(xValuesColor2, yValuesColor2);
            chartName.Series[seriesColor3].Points.DataBindXY(xValuesColor3, yValuesColor3);
            chartName.Series[seriesColor4].Points.DataBindXY(xValuesColor4, yValuesColor4);
            chartName.Series[seriesColor5].Points.DataBindXY(xValuesColor5, yValuesColor5);
            chartName.Series[seriesColor6].Points.DataBindXY(xValuesColor6, yValuesColor6);
            chartName.Series[seriesColor7].Points.DataBindXY(xValuesColor7, yValuesColor7);
            chartName.Series[seriesColor8].Points.DataBindXY(xValuesColor8, yValuesColor8);
            chartName.Series[seriesColor9].Points.DataBindXY(xValuesColor9, yValuesColor9);
            chartName.Series[seriesColor10].Points.DataBindXY(xValuesColor10, yValuesColor10);

            //ForLoopAxisList(chartName, 1, xValues, yValues, zValues);
            chartName.Series[seriesName].Points.Last().MarkerSize = 8;
            chartName.Series[seriesName].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesName].Points.Last().IsValueShownAsLabel = false;//true;
        }

        public static void ListSeriesAllWheels(Chart chartName, 
            string seriesNameFL, double dataXFL, List<double> xValuesFL, double dataYFL, List<double> yValuesFL, double dataZFL, List<double> zValuesFL,
            List<double> xValuesFLColor1, List<double> yValuesFLColor1,
            List<double> xValuesFLColor2, List<double> yValuesFLColor2,
            List<double> xValuesFLColor3, List<double> yValuesFLColor3,
            List<double> xValuesFLColor4, List<double> yValuesFLColor4,
            List<double> xValuesFLColor5, List<double> yValuesFLColor5,
            List<double> xValuesFLColor6, List<double> yValuesFLColor6,
            List<double> xValuesFLColor7, List<double> yValuesFLColor7,
            List<double> xValuesFLColor8, List<double> yValuesFLColor8,
            List<double> xValuesFLColor9, List<double> yValuesFLColor9,
            List<double> xValuesFLColor10, List<double> yValuesFLColor10,
            string seriesNameFR, double dataXFR, List<double> xValuesFR, double dataYFR, List<double> yValuesFR, double dataZFR, List<double> zValuesFR,
            List<double> xValuesFRColor1, List<double> yValuesFRColor1,
            List<double> xValuesFRColor2, List<double> yValuesFRColor2,
            List<double> xValuesFRColor3, List<double> yValuesFRColor3,
            List<double> xValuesFRColor4, List<double> yValuesFRColor4,
            List<double> xValuesFRColor5, List<double> yValuesFRColor5,
            List<double> xValuesFRColor6, List<double> yValuesFRColor6,
            List<double> xValuesFRColor7, List<double> yValuesFRColor7,
            List<double> xValuesFRColor8, List<double> yValuesFRColor8,
            List<double> xValuesFRColor9, List<double> yValuesFRColor9,
            List<double> xValuesFRColor10, List<double> yValuesFRColor10,
            string seriesNameRL, double dataXRL, List<double> xValuesRL, double dataYRL, List<double> yValuesRL, double dataZRL, List<double> zValuesRL,
            List<double> xValuesRLColor1, List<double> yValuesRLColor1,
            List<double> xValuesRLColor2, List<double> yValuesRLColor2,
            List<double> xValuesRLColor3, List<double> yValuesRLColor3,
            List<double> xValuesRLColor4, List<double> yValuesRLColor4,
            List<double> xValuesRLColor5, List<double> yValuesRLColor5,
            List<double> xValuesRLColor6, List<double> yValuesRLColor6,
            List<double> xValuesRLColor7, List<double> yValuesRLColor7,
            List<double> xValuesRLColor8, List<double> yValuesRLColor8,
            List<double> xValuesRLColor9, List<double> yValuesRLColor9,
            List<double> xValuesRLColor10, List<double> yValuesRLColor10,
            string seriesNameRR, double dataXRR, List<double> xValuesRR, double dataYRR, List<double> yValuesRR, double dataZRR, List<double> zValuesRR,
            List<double> xValuesRRColor1, List<double> yValuesRRColor1,
            List<double> xValuesRRColor2, List<double> yValuesRRColor2,
            List<double> xValuesRRColor3, List<double> yValuesRRColor3,
            List<double> xValuesRRColor4, List<double> yValuesRRColor4,
            List<double> xValuesRRColor5, List<double> yValuesRRColor5,
            List<double> xValuesRRColor6, List<double> yValuesRRColor6,
            List<double> xValuesRRColor7, List<double> yValuesRRColor7,
            List<double> xValuesRRColor8, List<double> yValuesRRColor8,
            List<double> xValuesRRColor9, List<double> yValuesRRColor9,
            List<double> xValuesRRColor10, List<double> yValuesRRColor10)
        {

            if (_4WheelsSettings.AbsoluteValues == true)
            {
                xValuesFL.Add(Math.Abs(dataXFL));
                yValuesFL.Add(Math.Abs(dataYFL));
                zValuesFL.Add(Math.Abs(dataZFL));

                xValuesFR.Add(Math.Abs(dataXFR));
                yValuesFR.Add(Math.Abs(dataYFR));
                zValuesFR.Add(Math.Abs(dataZFR));

                xValuesRL.Add(Math.Abs(dataXRL));
                yValuesRL.Add(Math.Abs(dataYRL));
                zValuesRL.Add(Math.Abs(dataZRL));

                xValuesRR.Add(Math.Abs(dataXRR));
                yValuesRR.Add(Math.Abs(dataYRR));
                zValuesRR.Add(Math.Abs(dataZRR));
            }
            else
            {
                xValuesFL.Add(dataXFL);
                yValuesFL.Add(dataYFL);
                zValuesFL.Add(dataZFL);

                xValuesFR.Add(dataXFR);
                yValuesFR.Add(dataYFR);
                zValuesFR.Add(dataZFR);

                xValuesRL.Add(dataXRL);
                yValuesRL.Add(dataYRL);
                zValuesRL.Add(dataZRL);

                xValuesRR.Add(dataXRR);
                yValuesRR.Add(dataYRR);
                zValuesRR.Add(dataZRR);
            }
            if (xValuesFL.Count > 1)
            {
                xValuesFL.RemoveAt(0);
                yValuesFL.RemoveAt(0);
                zValuesFL.RemoveAt(0);

                xValuesFR.RemoveAt(0);
                yValuesFR.RemoveAt(0);
                zValuesFR.RemoveAt(0);

                xValuesRL.RemoveAt(0);
                yValuesRL.RemoveAt(0);
                zValuesRL.RemoveAt(0);

                xValuesRR.RemoveAt(0);
                yValuesRR.RemoveAt(0);
                zValuesRR.RemoveAt(0);
            }
            ColorGradientSuper(dataXFL, dataYFL, dataZFL,
            xValuesFLColor1, yValuesFLColor1,
            xValuesFLColor2, yValuesFLColor2,
            xValuesFLColor3, yValuesFLColor3,
            xValuesFLColor4, yValuesFLColor4,
            xValuesFLColor5, yValuesFLColor5,
            xValuesFLColor6, yValuesFLColor6,
            xValuesFLColor7, yValuesFLColor7,
            xValuesFLColor8, yValuesFLColor8,
            xValuesFLColor9, yValuesFLColor9,
            xValuesFLColor10, yValuesFLColor10);
            chartName.Series[seriesNameFL].Points.DataBindXY(xValuesFL, yValuesFL);
            chartName.Series[seriesNameFL+seriesColor1].Points.DataBindXY(xValuesFLColor1, yValuesFLColor1);
            chartName.Series[seriesNameFL + seriesColor2].Points.DataBindXY(xValuesFLColor2, yValuesFLColor2);
            chartName.Series[seriesNameFL + seriesColor3].Points.DataBindXY(xValuesFLColor3, yValuesFLColor3);
            chartName.Series[seriesNameFL + seriesColor4].Points.DataBindXY(xValuesFLColor4, yValuesFLColor4);
            chartName.Series[seriesNameFL + seriesColor5].Points.DataBindXY(xValuesFLColor5, yValuesFLColor5);
            chartName.Series[seriesNameFL + seriesColor6].Points.DataBindXY(xValuesFLColor6, yValuesFLColor6);
            chartName.Series[seriesNameFL + seriesColor7].Points.DataBindXY(xValuesFLColor7, yValuesFLColor7);
            chartName.Series[seriesNameFL + seriesColor8].Points.DataBindXY(xValuesFLColor8, yValuesFLColor8);
            chartName.Series[seriesNameFL + seriesColor9].Points.DataBindXY(xValuesFLColor9, yValuesFLColor9);
            chartName.Series[seriesNameFL + seriesColor10].Points.DataBindXY(xValuesFLColor10, yValuesFLColor10);

            ColorGradientSuper(dataXFR, dataYFR, dataZFR,
            xValuesFRColor1, yValuesFRColor1,
            xValuesFRColor2, yValuesFRColor2,
            xValuesFRColor3, yValuesFRColor3,
            xValuesFRColor4, yValuesFRColor4,
            xValuesFRColor5, yValuesFRColor5,
            xValuesFRColor6, yValuesFRColor6,
            xValuesFRColor7, yValuesFRColor7,
            xValuesFRColor8, yValuesFRColor8,
            xValuesFRColor9, yValuesFRColor9,
            xValuesFRColor10, yValuesFRColor10);
            chartName.Series[seriesNameFR].Points.DataBindXY(xValuesFR, yValuesFR);
            chartName.Series[seriesNameFR + seriesColor1].Points.DataBindXY(xValuesFRColor1, yValuesFRColor1);
            chartName.Series[seriesNameFR + seriesColor2].Points.DataBindXY(xValuesFRColor2, yValuesFRColor2);
            chartName.Series[seriesNameFR + seriesColor3].Points.DataBindXY(xValuesFRColor3, yValuesFRColor3);
            chartName.Series[seriesNameFR + seriesColor4].Points.DataBindXY(xValuesFRColor4, yValuesFRColor4);
            chartName.Series[seriesNameFR + seriesColor5].Points.DataBindXY(xValuesFRColor5, yValuesFRColor5);
            chartName.Series[seriesNameFR + seriesColor6].Points.DataBindXY(xValuesFRColor6, yValuesFRColor6);
            chartName.Series[seriesNameFR + seriesColor7].Points.DataBindXY(xValuesFRColor7, yValuesFRColor7);
            chartName.Series[seriesNameFR + seriesColor8].Points.DataBindXY(xValuesFRColor8, yValuesFRColor8);
            chartName.Series[seriesNameFR + seriesColor9].Points.DataBindXY(xValuesFRColor9, yValuesFRColor9);
            chartName.Series[seriesNameFR + seriesColor10].Points.DataBindXY(xValuesFRColor10, yValuesFRColor10);

            ColorGradientSuper(dataXRL, dataYRL, dataZRL,
            xValuesRLColor1, yValuesRLColor1,
            xValuesRLColor2, yValuesRLColor2,
            xValuesRLColor3, yValuesRLColor3,
            xValuesRLColor4, yValuesRLColor4,
            xValuesRLColor5, yValuesRLColor5,
            xValuesRLColor6, yValuesRLColor6,
            xValuesRLColor7, yValuesRLColor7,
            xValuesRLColor8, yValuesRLColor8,
            xValuesRLColor9, yValuesRLColor9,
            xValuesRLColor10, yValuesRLColor10);
            chartName.Series[seriesNameRL].Points.DataBindXY(xValuesRL, yValuesRL);
            chartName.Series[seriesNameRL + seriesColor1].Points.DataBindXY(xValuesRLColor1, yValuesRLColor1);
            chartName.Series[seriesNameRL + seriesColor2].Points.DataBindXY(xValuesRLColor2, yValuesRLColor2);
            chartName.Series[seriesNameRL + seriesColor3].Points.DataBindXY(xValuesRLColor3, yValuesRLColor3);
            chartName.Series[seriesNameRL + seriesColor4].Points.DataBindXY(xValuesRLColor4, yValuesRLColor4);
            chartName.Series[seriesNameRL + seriesColor5].Points.DataBindXY(xValuesRLColor5, yValuesRLColor5);
            chartName.Series[seriesNameRL + seriesColor6].Points.DataBindXY(xValuesRLColor6, yValuesRLColor6);
            chartName.Series[seriesNameRL + seriesColor7].Points.DataBindXY(xValuesRLColor7, yValuesRLColor7);
            chartName.Series[seriesNameRL + seriesColor8].Points.DataBindXY(xValuesRLColor8, yValuesRLColor8);
            chartName.Series[seriesNameRL + seriesColor9].Points.DataBindXY(xValuesRLColor9, yValuesRLColor9);
            chartName.Series[seriesNameRL + seriesColor10].Points.DataBindXY(xValuesRLColor10, yValuesRLColor10);

            ColorGradientSuper(dataXRR, dataYRR, dataZRR,
            xValuesRRColor1, yValuesRRColor1,
            xValuesRRColor2, yValuesRRColor2,
            xValuesRRColor3, yValuesRRColor3,
            xValuesRRColor4, yValuesRRColor4,
            xValuesRRColor5, yValuesRRColor5,
            xValuesRRColor6, yValuesRRColor6,
            xValuesRRColor7, yValuesRRColor7,
            xValuesRRColor8, yValuesRRColor8,
            xValuesRRColor9, yValuesRRColor9,
            xValuesRRColor10, yValuesRRColor10);
            chartName.Series[seriesNameRR].Points.DataBindXY(xValuesRR, yValuesRR);
            chartName.Series[seriesNameRR + seriesColor1].Points.DataBindXY(xValuesRRColor1, yValuesRRColor1);
            chartName.Series[seriesNameRR + seriesColor2].Points.DataBindXY(xValuesRRColor2, yValuesRRColor2);
            chartName.Series[seriesNameRR + seriesColor3].Points.DataBindXY(xValuesRRColor3, yValuesRRColor3);
            chartName.Series[seriesNameRR + seriesColor4].Points.DataBindXY(xValuesRRColor4, yValuesRRColor4);
            chartName.Series[seriesNameRR + seriesColor5].Points.DataBindXY(xValuesRRColor5, yValuesRRColor5);
            chartName.Series[seriesNameRR + seriesColor6].Points.DataBindXY(xValuesRRColor6, yValuesRRColor6);
            chartName.Series[seriesNameRR + seriesColor7].Points.DataBindXY(xValuesRRColor7, yValuesRRColor7);
            chartName.Series[seriesNameRR + seriesColor8].Points.DataBindXY(xValuesRRColor8, yValuesRRColor8);
            chartName.Series[seriesNameRR + seriesColor9].Points.DataBindXY(xValuesRRColor9, yValuesRRColor9);
            chartName.Series[seriesNameRR + seriesColor10].Points.DataBindXY(xValuesRRColor10, yValuesRRColor10);

            //ForLoopAxisList(chartName, 1, xValues, yValues, zValues);
            chartName.Series[seriesNameFL].Points.Last().MarkerSize = 8;
            chartName.Series[seriesNameFL].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesNameFL].Points.Last().IsValueShownAsLabel = false;//true;

            chartName.Series[seriesNameFR].Points.Last().MarkerSize = 8;
            chartName.Series[seriesNameFR].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesNameFR].Points.Last().IsValueShownAsLabel = false;//true;

            chartName.Series[seriesNameRL].Points.Last().MarkerSize = 8;
            chartName.Series[seriesNameRL].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesNameRL].Points.Last().IsValueShownAsLabel = false;//true;

            chartName.Series[seriesNameRR].Points.Last().MarkerSize = 8;
            chartName.Series[seriesNameRR].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesNameRR].Points.Last().IsValueShownAsLabel = false;//true;
        }

        static SeriesChartType chartType = _4WheelsSettings.SeriesChartType;
        static Color color = Color.Transparent;
        static MarkerStyle markerStyle = MarkerStyle.Circle;
        static int markerSize = 2;
        static Color markerColor = Color.FromArgb(historyalpha, 128, 0, 0);
        static bool valueShownAsLabelAndSmartLabelStyle = false;

        public static void InfiniteHistoryChart(Chart chartName, string seriesName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series(seriesName + uHistoryHelper.ToString()));
                chartName.Series[seriesName + uHistoryHelper].ChartType = chartType;
                chartName.Series[seriesName + uHistoryHelper.ToString()].Color = color;
                chartName.Series[seriesName + uHistoryHelper.ToString()].MarkerStyle = markerStyle;
                chartName.Series[seriesName + uHistoryHelper.ToString()].MarkerSize = markerSize;
                chartName.Series[seriesName + uHistoryHelper.ToString()].MarkerColor = markerColor;
                chartName.Series[seriesName + uHistoryHelper.ToString()].IsValueShownAsLabel = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesName + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesName + uHistoryHelper.ToString()].LabelBackColor = color;

                uHistoryHelper++;
            }
        }
        public static void InfiniteHistoryChartAllWheels(Chart chartName, string seriesNameFL, string seriesNameFR, string seriesNameRL, string seriesNameRR)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series(seriesNameFL + uHistoryHelper.ToString()));
                chartName.Series[seriesNameFL + uHistoryHelper].ChartType = chartType;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].Color = color;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].MarkerStyle = markerStyle;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].MarkerSize = markerSize;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].MarkerColor = markerColor;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].IsValueShownAsLabel = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameFL + uHistoryHelper.ToString()].LabelBackColor = color;

                chartName.Series.Insert(0, new Series(seriesNameFR + uHistoryHelper.ToString()));
                chartName.Series[seriesNameFR + uHistoryHelper].ChartType = chartType;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].Color = color;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].MarkerStyle = markerStyle;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].MarkerSize = markerSize;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].MarkerColor = markerColor;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].IsValueShownAsLabel = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameFR + uHistoryHelper.ToString()].LabelBackColor = color;

                chartName.Series.Insert(0, new Series(seriesNameRL + uHistoryHelper.ToString()));
                chartName.Series[seriesNameRL + uHistoryHelper].ChartType = chartType;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].Color = color;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].MarkerStyle = markerStyle;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].MarkerSize = markerSize;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].MarkerColor = markerColor;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].IsValueShownAsLabel = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameRL + uHistoryHelper.ToString()].LabelBackColor = color;

                chartName.Series.Insert(0, new Series(seriesNameRR + uHistoryHelper.ToString()));
                chartName.Series[seriesNameRR + uHistoryHelper].ChartType = chartType;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].Color = color;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].MarkerStyle = markerStyle;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].MarkerSize = markerSize;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].MarkerColor = markerColor;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].IsValueShownAsLabel = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = valueShownAsLabelAndSmartLabelStyle;
                chartName.Series[seriesNameRR + uHistoryHelper.ToString()].LabelBackColor = color;
                uHistoryHelper++;
            }
        }
        public static void SetUpDownChart(Chart chartName)
        {

            double maxmin = _4WheelsSettings.Z1Max - _4WheelsSettings.Z1Min;
            double interval = maxmin / steps;
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
                for (double i = _4WheelsSettings.Z1Min * steps; i <= _4WheelsSettings.Z1Max * steps; i += maxmin)
                {

                    double iminsteps = i - _4WheelsSettings.Z1Min * steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == maxmin * 10)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 64 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 128 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 64 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 0 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }
            else if (_4WheelsSettings.Scheme == "Colorblind")
            {
                Color color2 = Color.FromArgb(historyalpha, 0, 73, 73);
                Color color3 = Color.FromArgb(historyalpha, 0, 146, 146);
                Color color4 = Color.FromArgb(historyalpha, 255, 109, 182);
                //Color color5 = Color.FromArgb(historyalpha, 255, 182, 219);
                Color color6 = Color.FromArgb(historyalpha, 73, 0, 146);
                Color color7 = Color.FromArgb(historyalpha, 0, 109, 219);
                Color color8 = Color.FromArgb(historyalpha, 182, 109, 255);
                Color color9 = Color.FromArgb(historyalpha, 109, 182, 255);
                Color color15 = Color.FromArgb(historyalpha, 255, 255, 109);
                Color color14 = Color.FromArgb(historyalpha, 36, 255, 36);
                Color color13 = Color.FromArgb(historyalpha, 219, 109, 0);

                for (double i = _4WheelsSettings.Z1Min * steps; i <= _4WheelsSettings.Z1Max * steps; i += maxmin)
                {

                    double iminsteps = i - _4WheelsSettings.Z1Min * steps;
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
                        sl.IntervalOffset = ((double)i) / steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }
            else
            {
                for (double i = _4WheelsSettings.Z1Min * steps; i <= _4WheelsSettings.Z1Max * steps; i += maxmin)
                {
                    double iminsteps = i - _4WheelsSettings.Z1Min * steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == _4WheelsSettings.Z1Max * 10)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 64 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 128 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 64 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 0 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }

        }
    }
}
