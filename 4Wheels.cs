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


        private static double[] FL_X1ValuesChartArray = new double[_4WheelsSettings.FL_HistoryAmountPoints];
        private static double[] FL_Y1ValuesChartArray = new double[_4WheelsSettings.FL_HistoryAmountPoints];
        private static double[] FL_Z1ValuesChartArray = new double[_4WheelsSettings.FL_HistoryAmountPoints];

        private static double[] FR_X1ValuesChartArray = new double[_4WheelsSettings.FR_HistoryAmountPoints];
        private static double[] FR_Y1ValuesChartArray = new double[_4WheelsSettings.FR_HistoryAmountPoints];

        private static double[] RL_X1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
        private static double[] RL_Y1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];

        private static double[] RR_X1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
        private static double[] RR_Y1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];

        //private static double[] X1ValuesChart2Array = new double[2];
        //private static double[] Y1ValuesChart2Array = new double[2];


        private static int u = 2;

        private void HistoryPointsColorFromMarkerColor() // Not used
        {
            int a = _4WheelsSettings.MarkerColor.A;
            int r = _4WheelsSettings.MarkerColor.R;
            int g = _4WheelsSettings.MarkerColor.G;
            int B = _4WheelsSettings.MarkerColor.B;

        }

        public static void SetArrays()
        {
            FL_X1ValuesChartArray = new double[_4WheelsSettings.FL_HistoryAmountPoints];
            FL_Y1ValuesChartArray = new double[_4WheelsSettings.FL_HistoryAmountPoints];
            FL_Z1ValuesChartArray = new double[_4WheelsSettings.FL_HistoryAmountPoints];
            FR_X1ValuesChartArray = new double[_4WheelsSettings.FR_HistoryAmountPoints];
            FR_Y1ValuesChartArray = new double[_4WheelsSettings.FR_HistoryAmountPoints];
            RL_X1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
            RL_Y1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
            RR_X1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
            RR_Y1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
            //X1ValuesChart2Array = new double[2];
            //Y1ValuesChart2Array = new double[2];

        }
        private static void X1AxisDefaults()
        {

            if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                _4WheelsSettings.X1DefaultMax = double.NaN;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 1000;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = false;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 60;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                _4WheelsSettings.X1DefaultMax = 400;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax / 2;
                _4WheelsSettings.X1DefaultMajorInterval = 100;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                _4WheelsSettings.X1DefaultMax = 400;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax / 2;
                _4WheelsSettings.X1DefaultMajorInterval = 100;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                _4WheelsSettings.X1DefaultMax = 10000;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 1000;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                _4WheelsSettings.X1DefaultMax = 0.15;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 0.03;
                _4WheelsSettings.X1DefaultMajorDecimals = 3;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                _4WheelsSettings.X1DefaultMax = 0.5;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 0.1;
                _4WheelsSettings.X1DefaultMajorDecimals = 3;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                _4WheelsSettings.X1DefaultMax = 0.5;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 0.1;
                _4WheelsSettings.X1DefaultMajorDecimals = 3;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                _4WheelsSettings.X1DefaultMax = 0.5;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 0.1;
                _4WheelsSettings.X1DefaultMajorDecimals = 3;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                _4WheelsSettings.X1DefaultMax = 5000;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 500;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                _4WheelsSettings.X1DefaultMax = 5000;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 500;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                // Default Axis values
                _4WheelsSettings.X1DefaultMax = 45;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 15;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                _4WheelsSettings.X1DefaultMax = 10;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 4;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                _4WheelsSettings.X1DefaultMax = 10000;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 1000;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                _4WheelsSettings.X1DefaultMax = 45;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 15;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                _4WheelsSettings.X1DefaultMax = 2;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 0.5;
                _4WheelsSettings.X1DefaultMajorDecimals = 2;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                _4WheelsSettings.X1DefaultMax = 20;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 5;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                _4WheelsSettings.X1DefaultMax = 10000;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 1000;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                _4WheelsSettings.X1DefaultMax = 1;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 0.2;
                _4WheelsSettings.X1DefaultMajorDecimals = 2;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                _4WheelsSettings.X1DefaultMax = 2;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 0.5;
                _4WheelsSettings.X1DefaultMajorDecimals = 2;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                _4WheelsSettings.X1DefaultMax = 20;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 5;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                _4WheelsSettings.X1DefaultMax = 380;
                _4WheelsSettings.X1DefaultMin = -20;
                _4WheelsSettings.X1DefaultMajorInterval = 20;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                _4WheelsSettings.X1DefaultMax = 380;
                _4WheelsSettings.X1DefaultMin = -20;
                _4WheelsSettings.X1DefaultMajorInterval = 20;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                _4WheelsSettings.X1DefaultMax = 2;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 0.5;
                _4WheelsSettings.X1DefaultMajorDecimals = 2;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                _4WheelsSettings.X1DefaultMax = 360;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 90;
                _4WheelsSettings.X1DefaultMajorDecimals = 0;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                _4WheelsSettings.X1DefaultMax = 1;
                _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 0.1;
                _4WheelsSettings.X1DefaultMajorDecimals = 4;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                _4WheelsSettings.X1DefaultMax = 10;
                _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                _4WheelsSettings.X1DefaultMajorInterval = 2;
                _4WheelsSettings.X1DefaultMajorDecimals = 4;
                _4WheelsSettings.X1DefaultMinorEnabled = true;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.X1Defaults == true)
                {
                    _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;
                    _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                    _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                    _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                    _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                    _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                }
            }
            /*
            else if (comboBox1.Text == "")
            {

            }*/

            else
            {
                // Defaults auto scale
                _4WheelsSettings.X1DefaultMax = double.NaN;
                _4WheelsSettings.X1DefaultMin = double.NaN;
                _4WheelsSettings.X1DefaultMajorInterval = 0;
                _4WheelsSettings.X1DefaultMajorDecimals = 2;
                _4WheelsSettings.X1DefaultMinorEnabled = false;
                _4WheelsSettings.X1DefaultMinorIntervalFraction = 2;
            }
        }
        private static void Y1AxisDefaults()
        {

            if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                _4WheelsSettings.Y1DefaultMax = 100000;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 1000;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = false;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 1;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                _4WheelsSettings.Y1DefaultMax = 400;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax / 2;
                _4WheelsSettings.Y1DefaultMajorInterval = 100;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                _4WheelsSettings.Y1DefaultMax = 400;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax / 2;
                _4WheelsSettings.Y1DefaultMajorInterval = 100;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                _4WheelsSettings.Y1DefaultMax = 10000;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 1000;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                _4WheelsSettings.Y1DefaultMax = 0.15;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.03;
                _4WheelsSettings.Y1DefaultMajorDecimals = 3;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                _4WheelsSettings.Y1DefaultMax = 0.5;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.1;
                _4WheelsSettings.Y1DefaultMajorDecimals = 3;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                _4WheelsSettings.Y1DefaultMax = 0.5;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.1;
                _4WheelsSettings.Y1DefaultMajorDecimals = 3;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                _4WheelsSettings.Y1DefaultMax = 0.5;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.1;
                _4WheelsSettings.Y1DefaultMajorDecimals = 3;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                _4WheelsSettings.Y1DefaultMax = 5000;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 500;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                _4WheelsSettings.Y1DefaultMax = 5000;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 500;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                // Default Axis values
                _4WheelsSettings.Y1DefaultMax = 45;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 15;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                _4WheelsSettings.Y1DefaultMax = 10;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 4;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                _4WheelsSettings.Y1DefaultMax = 10000;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 1000;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                _4WheelsSettings.Y1DefaultMax = 45;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 15;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                _4WheelsSettings.Y1DefaultMax = 2;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.5;
                _4WheelsSettings.Y1DefaultMajorDecimals = 2;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                _4WheelsSettings.Y1DefaultMax = 20;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 5;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                _4WheelsSettings.Y1DefaultMax = 10000;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 1000;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                _4WheelsSettings.Y1DefaultMax = 1;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.2;
                _4WheelsSettings.Y1DefaultMajorDecimals = 2;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                _4WheelsSettings.Y1DefaultMax = 2;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.5;
                _4WheelsSettings.Y1DefaultMajorDecimals = 2;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                _4WheelsSettings.Y1DefaultMax = 20;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 5;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                _4WheelsSettings.Y1DefaultMax = 380;
                _4WheelsSettings.Y1DefaultMin = -20;
                _4WheelsSettings.Y1DefaultMajorInterval = 20;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                _4WheelsSettings.Y1DefaultMax = 380;
                _4WheelsSettings.Y1DefaultMin = -20;
                _4WheelsSettings.Y1DefaultMajorInterval = 20;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                _4WheelsSettings.Y1DefaultMax = 2;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.5;
                _4WheelsSettings.Y1DefaultMajorDecimals = 2;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                _4WheelsSettings.Y1DefaultMax = 360;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 90;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 5;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                _4WheelsSettings.Y1DefaultMax = 1;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.1;
                _4WheelsSettings.Y1DefaultMajorDecimals = 4;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 5;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                _4WheelsSettings.Y1DefaultMax = 10;
                _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                _4WheelsSettings.Y1DefaultMajorInterval = 2;
                _4WheelsSettings.Y1DefaultMajorDecimals = 4;
                _4WheelsSettings.Y1DefaultMinorEnabled = true;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 5;

                if (_4WheelsSettings.Y1Defaults == true)
                {
                    _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;
                    _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                    _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                    _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                    _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                    _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            /*
            else if (comboBox2.Text == "")
            {

            }*/

            else
            {
                // Defaults auto scale
                _4WheelsSettings.Y1DefaultMax = double.NaN;
                _4WheelsSettings.Y1DefaultMin = double.NaN;
                _4WheelsSettings.Y1DefaultMajorInterval = 0;
                _4WheelsSettings.Y1DefaultMajorDecimals = 2;
                _4WheelsSettings.Y1DefaultMinorEnabled = false;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 2;
            }

        }
        public static void ClearSeriesHistory(Chart chartName)
        {
            while (chartName.Series.Count > 1) { chartName.Series.RemoveAt(0); }
        }
        public static void SetChart(Chart chartName)
        {
            X1AxisDefaults();
            Y1AxisDefaults();
            chartName.Series["Series1"].ChartType = SeriesChartType.Point;
            chartName.Series["Series1"].MarkerStyle = MarkerStyle.Circle;

            chartName.ChartAreas["ChartArea1"].BackColor = _4WheelsSettings.BackgroundColor;

            // X Axis
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = _4WheelsSettings.X1Max;
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = _4WheelsSettings.X1Min;

            chartName.ChartAreas["ChartArea1"].AxisX.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F" + _4WheelsSettings.X1MajorDecimals;// decimals

            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = _4WheelsSettings.X1MajorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Transparent;// Need to do this for this specific line, because it's over the X axis lines.

            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = _4WheelsSettings.X1MinorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = _4WheelsSettings.X1MinorDashStyle;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineWidth = _4WheelsSettings.X1MinorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = chartName.ChartAreas["ChartArea1"].AxisX.Interval / _4WheelsSettings.X1MinorIntervalFraction;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = _4WheelsSettings.X1MinorColor;

            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonColor =_4WheelsSettings.X1MajorColor;
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
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = _4WheelsSettings.Y1Min;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = _4WheelsSettings.Y1Max;

            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = _4WheelsSettings.Y1FontColor;

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
            chartName.Series["Series1"].MarkerSize = 4;
            chartName.Series["Series1"].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
            chartName.Series["Series1"].SmartLabelStyle.Enabled = false;
            chartName.Series["Series1"].LabelBackColor = chartName.ChartAreas["ChartArea1"].BackColor;
        }
        private static void FL_XYArraySelections()
        {
            //X
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_TravelSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_AngularVelocity;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_VerticalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_VerticalDeflection;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LoadedRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_EffectiveRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_ContactLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_SteerAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_CamberAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LateralLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_SlipAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LateralFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_SlipRatio;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_TreadTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_InnerTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_TotalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_SuspensionLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                FL_X1ValuesChartArray[FL_X1ValuesChartArray.Length - 1] = LiveData.FL_SlipAngleDeg;
            }
            //Y
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_TravelSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_AngularVelocity;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_VerticalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_VerticalDeflection;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LoadedRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_EffectiveRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_ContactLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_SteerAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_CamberAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LateralLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_SlipAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LateralFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_SlipRatio;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_TreadTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_InnerTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_TotalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_SuspensionLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = LiveData.FL_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                FL_Y1ValuesChartArray[FL_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.FL_LateralFriction, 2);
            }
            //Z
            if (_4WheelsSettings.Z1Selection == LiveData.sTireTravelSpeed)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_TravelSpeed;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sAngularVelocity)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_AngularVelocity;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalLoad)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_VerticalLoad;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalDeflection)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_VerticalDeflection;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLoadedRadius)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LoadedRadius;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sEffectiveRadius)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_EffectiveRadius;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sContactLength)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_ContactLength;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sBrakeTorque)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sMaxBrakeTorque)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSteerAngle)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_SteerAngleDeg;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sCamberAngle)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_CamberAngleDeg;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralLoad)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LateralLoad;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipAngle)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_SlipAngleDeg;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralFriction)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LateralFriction;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralSlipSpeed)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalLoad)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalLoad;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipRatio)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_SlipRatio;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalFriction)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalFriction;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTreadTemperature)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_TreadTemperature;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sInnerTemperature)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_InnerTemperature;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sRaceTime)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFriction)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_TotalFriction;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFrictionAngle)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionLength)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_SuspensionLength;
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionVelocity)
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                FL_Z1ValuesChartArray[FL_Z1ValuesChartArray.Length - 1] = LiveData.FL_VerticalLoad;
            }
        }
        private static void FR_XYArraySelections()
        {
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_TravelSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_AngularVelocity;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_VerticalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_VerticalDeflection;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_LoadedRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_EffectiveRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_ContactLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_SteerAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_CamberAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_LateralLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_SlipAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LateralFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_LongitudinalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_SlipRatio;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LongitudinalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_TreadTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_InnerTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_TotalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_SuspensionLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                FR_X1ValuesChartArray[FR_X1ValuesChartArray.Length - 1] = LiveData.FR_SlipAngleDeg;
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.FR_LateralFriction, 2);
            }
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_TravelSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_AngularVelocity;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_VerticalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_VerticalDeflection;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LoadedRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_EffectiveRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_ContactLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_SteerAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_CamberAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LateralLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_SlipAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LateralFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LongitudinalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_SlipRatio;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LongitudinalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_TreadTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_InnerTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_TotalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_SuspensionLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = LiveData.FR_SlipAngleDeg;
                FR_Y1ValuesChartArray[FR_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.FR_LateralFriction, 2);
            }
        }
        private static void RL_XYArraySelections()
        {
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_TravelSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_AngularVelocity;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_VerticalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_VerticalDeflection;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_LoadedRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_EffectiveRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_ContactLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_SteerAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_CamberAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_LateralLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_SlipAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LateralFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_LongitudinalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_SlipRatio;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LongitudinalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_TreadTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_InnerTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_TotalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_SuspensionLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                RL_X1ValuesChartArray[RL_X1ValuesChartArray.Length - 1] = LiveData.RL_SlipAngleDeg;
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.RL_LateralFriction, 2);
            }
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_TravelSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_AngularVelocity;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_VerticalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_VerticalDeflection;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LoadedRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_EffectiveRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_ContactLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_SteerAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_CamberAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LateralLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_SlipAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LateralFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LongitudinalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_SlipRatio;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LongitudinalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_TreadTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_InnerTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_TotalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_SuspensionLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = LiveData.RL_SlipAngleDeg;
                RL_Y1ValuesChartArray[RL_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.RL_LateralFriction, 2);
            }
        }
        private static void RR_XYArraySelections()
        {
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_TravelSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_AngularVelocity;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_VerticalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_VerticalDeflection;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_LoadedRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_EffectiveRadius;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_ContactLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_SteerAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_CamberAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_LateralLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_SlipAngleDeg;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LateralFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_LongitudinalLoad;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_SlipRatio;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LongitudinalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_TreadTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_InnerTemperature;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_TotalFriction;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_SuspensionLength;
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                RR_X1ValuesChartArray[RR_X1ValuesChartArray.Length - 1] = LiveData.RR_SlipAngleDeg;
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.RR_LateralFriction, 2);
            }
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_TravelSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_AngularVelocity;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_VerticalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_VerticalDeflection;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LoadedRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_EffectiveRadius;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_ContactLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_CurrentContactBrakeTorque;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_CurrentContactBrakeTorqueMax;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_SteerAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_CamberAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LateralLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_SlipAngleDeg;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LateralFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LateralSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LongitudinalLoad;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_SlipRatio;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LongitudinalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_LongitudinalSlipSpeed;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_TreadTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_InnerTemperature;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RaceTime;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_TotalFriction;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_TotalFrictionAngle;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_SuspensionLength;
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_SuspensionVelocity;
            }
            else//fallback to slip angle
            {
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = LiveData.RR_SlipAngleDeg;
                RR_Y1ValuesChartArray[RR_Y1ValuesChartArray.Length - 1] = Math.Round(LiveData.RR_LateralFriction, 2);
            }
        }
        private static void ColorGradientRG(Chart chartName, double array, int i, int u)
        {
            double minus = _4WheelsSettings.Y1Max / steps;
            double ten = _4WheelsSettings.Y1Max;
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
            if (_4WheelsSettings.InfiniteHistoryEnabled == false)
            {
                if (array >= ten)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < ten && array >= nine)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < nine && array >= eight)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < eight && array >= seven)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < seven && array >= six)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < six && array >= five)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < five && array >= four)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < four && array >= three)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < three && array >= two)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < two && array >= one)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < one && array >= zero)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
            }
            else
            {
                if (array >= ten)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < ten && array >= nine)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < nine && array >= eight)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < eight && array >= seven)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < seven && array >= six)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < six && array >= five)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < five && array >= four)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < four && array >= three)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < three && array >= two)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < two && array >= one)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < one && array >= zero)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
            }
        }
        private static void ZColorGradientRG(Chart chartName, double array, int i, int u)
        {
            double minus = _4WheelsSettings.Z1Max / steps;
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
            if (_4WheelsSettings.InfiniteHistoryEnabled == false)
            {
                if (array >= ten)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < ten && array >= nine)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < nine && array >= eight)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < eight && array >= seven)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < seven && array >= six)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < six && array >= five)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < five && array >= four)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < four && array >= three)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < three && array >= two)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < two && array >= one)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < one && array >= zero)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
            }
            else
            {
                if (array >= ten)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < ten && array >= nine)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < nine && array >= eight)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < eight && array >= seven)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < seven && array >= six)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < six && array >= five)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < five && array >= four)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < four && array >= three)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < three && array >= two)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < two && array >= one)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < one && array >= zero)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
                else
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                }
            }
        }
        private static void ColorGradientRB(Chart chartName, double array, int i, int u)
        {
            double minus = _4WheelsSettings.Y1Max / steps;
            double ten = _4WheelsSettings.Y1Max;
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
            if (_4WheelsSettings.InfiniteHistoryEnabled == false)
            {
                if (array >= ten)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < ten && array >= nine)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < nine && array >= eight)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < eight && array >= seven)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < seven && array >= six)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 64 / historycolordivider);
                }
                else if (array < six && array >= five)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 128 / historycolordivider);
                }
                else if (array < five && array >= four)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < four && array >= three)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < three && array >= two)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < two && array >= one)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < one && array >= zero)
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else
                {
                    chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
            }
            else
            {
                if (array >= ten)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < ten && array >= nine)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < nine && array >= eight)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < eight && array >= seven)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                }
                else if (array < seven && array >= six)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 64 / historycolordivider);
                }
                else if (array < six && array >= five)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 128 / historycolordivider);
                }
                else if (array < five && array >= four)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < four && array >= three)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < three && array >= two)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < two && array >= one)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else if (array < one && array >= zero)
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
                else
                {
                    chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                }
            }
        }
        private static void FL_ColorGradientRG(Chart chartName, int i, int u)
        {
            double array = Math.Abs(FL_Z1ValuesChartArray[i]);
            //ColorGradientRG(chartName, array, i, u);
            ZColorGradientRG(chartName, array, i, u);
        }
        private static void FL_ColorGradientRB(Chart chartName, int i, int u)
        {
            double array = Math.Abs(FL_Y1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void FR_ColorGradientRG(Chart chartName, int i, int u)
        {
            double array = Math.Abs(FR_Y1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void FR_ColorGradientRB(Chart chartName, int i, int u)
        {

            double array = Math.Abs(FR_Y1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void RL_ColorGradientRG(Chart chartName, int i, int u)
        {
            double array = Math.Abs(RL_Y1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void RL_ColorGradientRB(Chart chartName, int i, int u)
        {

            double array = Math.Abs(RL_Y1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void RR_ColorGradientRG(Chart chartName, int i, int u)
        {
            double array = Math.Abs(RR_Y1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void RR_ColorGradientRB(Chart chartName, int i, int u)
        {

            double array = Math.Abs(RR_Y1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        public static void PlotFLChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();

            FL_XYArraySelections();

            Array.Copy(FL_X1ValuesChartArray, 1, FL_X1ValuesChartArray, 0, FL_X1ValuesChartArray.Length - 1);
            Array.Copy(FL_Y1ValuesChartArray, 1, FL_Y1ValuesChartArray, 0, FL_Y1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                    FL_ColorGradientRG(chartName, i, 1);
                }
            }
            else
            {
                for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                    FL_ColorGradientRB(chartName, i, 1);
                }
            }

            chartName.Series["Series1"].Points.Last().MarkerSize = 8;
            chartName.Series["Series1"].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = false;//true;
        }
        public static void PlotFRChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();

            FR_XYArraySelections();

            Array.Copy(FR_X1ValuesChartArray, 1, FR_X1ValuesChartArray, 0, FR_X1ValuesChartArray.Length - 1);
            Array.Copy(FR_Y1ValuesChartArray, 1, FR_Y1ValuesChartArray, 0, FR_Y1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                    FR_ColorGradientRG(chartName, i, 1);
                }
            }
            else
            {
                for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                    FR_ColorGradientRB(chartName, i, 1);
                }
            }

            chartName.Series["Series1"].Points.Last().MarkerSize = 8;
            chartName.Series["Series1"].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = false;//true;
        }
        public static void PlotRLChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();

            RL_XYArraySelections();

            Array.Copy(RL_X1ValuesChartArray, 1, RL_X1ValuesChartArray, 0, RL_X1ValuesChartArray.Length - 1);
            Array.Copy(RL_Y1ValuesChartArray, 1, RL_Y1ValuesChartArray, 0, RL_Y1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                    RL_ColorGradientRG(chartName, i, 1);
                }
            }
            else
            {
                for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                    RL_ColorGradientRB(chartName, i, 1);
                }
            }

            chartName.Series["Series1"].Points.Last().MarkerSize = 8;
            chartName.Series["Series1"].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.RLomArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = false;//true;
        }
        public static void PlotRRChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();

            RR_XYArraySelections();

            Array.Copy(RR_X1ValuesChartArray, 1, RR_X1ValuesChartArray, 0, RR_X1ValuesChartArray.Length - 1);
            Array.Copy(RR_Y1ValuesChartArray, 1, RR_Y1ValuesChartArray, 0, RR_Y1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                    RR_ColorGradientRG(chartName, i, 1);
                }
            }
            else
            {
                for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                    RR_ColorGradientRB(chartName, i, 1);
                }
            }

            chartName.Series["Series1"].Points.Last().MarkerSize = 8;
            chartName.Series["Series1"].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.RRomArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = false;//true;
        }
        public static void InfiniteHistoryFLChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + u.ToString()));
                chartName.Series["Series" + u].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + u.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + u.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + u.ToString()].MarkerSize = 4;
                chartName.Series["Series" + u.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + u.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + u.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + u.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                        FL_ColorGradientRG(chartName, i, u);
                    }
                    u++;
                }
                else
                {
                    for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                        FL_ColorGradientRB(chartName, i, u);
                    }
                    u++;
                }

            }
        }
        public static void InfiniteHistoryFRChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + u.ToString()));
                chartName.Series["Series" + u].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + u.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + u.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + u.ToString()].MarkerSize = 4;
                chartName.Series["Series" + u.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + u.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + u.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + u.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                        FR_ColorGradientRG(chartName, i, u);
                    }
                    u++;
                }
                else
                {
                    for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                        FR_ColorGradientRB(chartName, i, u);
                    }
                    u++;
                }

            }
        }
        public static void InfiniteHistoryRLChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + u.ToString()));
                chartName.Series["Series" + u].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + u.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + u.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + u.ToString()].MarkerSize = 4;
                chartName.Series["Series" + u.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + u.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + u.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + u.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                        RL_ColorGradientRG(chartName, i, u);
                    }
                    u++;
                }
                else
                {
                    for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                        RL_ColorGradientRB(chartName, i, u);
                    }
                    u++;
                }

            }
        }
        public static void InfiniteHistoryRRChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + u.ToString()));
                chartName.Series["Series" + u].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + u.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + u.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + u.ToString()].MarkerSize = 4;
                chartName.Series["Series" + u.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + u.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + u.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + u.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                        RR_ColorGradientRG(chartName, i, u);
                    }
                    u++;
                }
                else
                {
                    for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + u.ToString()].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                        RR_ColorGradientRB(chartName, i, u);
                    }
                    u++;
                }

            }
        }
    }
}
