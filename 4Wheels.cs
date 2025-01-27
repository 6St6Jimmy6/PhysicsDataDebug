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
        private static double[] FR_Z1ValuesChartArray = new double[_4WheelsSettings.FR_HistoryAmountPoints];

        private static double[] RL_X1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
        private static double[] RL_Y1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
        private static double[] RL_Z1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];

        private static double[] RR_X1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
        private static double[] RR_Y1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
        private static double[] RR_Z1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];

        //private static double[] X1ValuesChart2Array = new double[2];
        //private static double[] Y1ValuesChart2Array = new double[2];


        private static int uHistoryHelper = 2;

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
            FR_Z1ValuesChartArray = new double[_4WheelsSettings.FR_HistoryAmountPoints];

            RL_X1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
            RL_Y1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];
            RL_Z1ValuesChartArray = new double[_4WheelsSettings.RL_HistoryAmountPoints];

            RR_X1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
            RR_Y1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
            RR_Z1ValuesChartArray = new double[_4WheelsSettings.RR_HistoryAmountPoints];
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
                if(_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax / 2;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax / 2;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -20;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -20;
                }
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
                 _4WheelsSettings.X1DefaultMin = 0;
                _4WheelsSettings.X1DefaultMajorInterval = 0.25;
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.X1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.X1DefaultMin = -_4WheelsSettings.X1DefaultMax;
                }
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
                _4WheelsSettings.Y1DefaultMax = double.NaN;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 1000;
                _4WheelsSettings.Y1DefaultMajorDecimals = 0;
                _4WheelsSettings.Y1DefaultMinorEnabled = false;
                _4WheelsSettings.Y1DefaultMinorIntervalFraction = 60;

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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax / 2;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax / 2;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -20;
                }
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
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -20;
                }
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
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.25;
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
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                _4WheelsSettings.Y1DefaultMax = 1;
                _4WheelsSettings.Y1DefaultMin = 0;
                _4WheelsSettings.Y1DefaultMajorInterval = 0.1;
                _4WheelsSettings.Y1DefaultMajorDecimals = 4;
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
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                _4WheelsSettings.Y1DefaultMax = 10;
                if (_4WheelsSettings.AbsoluteValues == true)
                {
                    _4WheelsSettings.Y1DefaultMin = 0;
                }
                else
                {
                    _4WheelsSettings.Y1DefaultMin = -_4WheelsSettings.Y1DefaultMax;
                }
                _4WheelsSettings.Y1DefaultMajorInterval = 2;
                _4WheelsSettings.Y1DefaultMajorDecimals = 4;
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
            /*
            else if (comboBox1.Text == "")
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
        private static void Z1AxisDefaults()
        {

            if (_4WheelsSettings.Z1Selection == LiveData.sRaceTime)
            {
                _4WheelsSettings.Z1DefaultMax = 100000;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTireTravelSpeed)
            {
                _4WheelsSettings.Z1DefaultMax = 400;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sAngularVelocity)
            {
                _4WheelsSettings.Z1DefaultMax = 400;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalLoad)
            {
                _4WheelsSettings.Z1DefaultMax = 10000;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalDeflection)
            {
                _4WheelsSettings.Z1DefaultMax = 0.15;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLoadedRadius)
            {
                _4WheelsSettings.Z1DefaultMax = 0.5;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sEffectiveRadius)
            {
                _4WheelsSettings.Z1DefaultMax = 0.5;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sContactLength)
            {
                _4WheelsSettings.Z1DefaultMax = 0.5;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sBrakeTorque)
            {
                _4WheelsSettings.Z1DefaultMax = 5000;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sMaxBrakeTorque)
            {
                _4WheelsSettings.Z1DefaultMax = 5000;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSteerAngle)
            {
                // Default Axis values
                _4WheelsSettings.Z1DefaultMax = 45;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sCamberAngle)
            {
                _4WheelsSettings.Z1DefaultMax = 10;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralLoad)
            {
                _4WheelsSettings.Z1DefaultMax = 10000;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipAngle)
            {
                _4WheelsSettings.Z1DefaultMax = 45;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralFriction)
            {
                _4WheelsSettings.Z1DefaultMax = 2;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralSlipSpeed)
            {
                _4WheelsSettings.Z1DefaultMax = 20;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalLoad)
            {
                _4WheelsSettings.Z1DefaultMax = 10000;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipRatio)
            {
                _4WheelsSettings.Z1DefaultMax = 1;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalFriction)
            {
                _4WheelsSettings.Z1DefaultMax = 2;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                _4WheelsSettings.Z1DefaultMax = 20;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTreadTemperature)
            {
                _4WheelsSettings.Z1DefaultMax = 425;
                _4WheelsSettings.Z1DefaultMin = 25;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sInnerTemperature)
            {
                _4WheelsSettings.Z1DefaultMax = 425;
                _4WheelsSettings.Z1DefaultMin = 25;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFriction)
            {
                _4WheelsSettings.Z1DefaultMax = 2;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFrictionAngle)
            {
                _4WheelsSettings.Z1DefaultMax = 360;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionLength)
            {
                _4WheelsSettings.Z1DefaultMax = 1;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionVelocity)
            {
                _4WheelsSettings.Z1DefaultMax = 10;
                _4WheelsSettings.Z1DefaultMin = 0;

                if (_4WheelsSettings.Z1Defaults == true)
                {
                    _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;
                    _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                }
            }
            /*
            else if (comboBox2.Text == "")
            {

            }*/

            else
            {
                // Defaults auto scale
                _4WheelsSettings.Z1DefaultMax = double.NaN;
                _4WheelsSettings.Z1DefaultMin = double.NaN;
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
            Z1AxisDefaults();
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
            chartName.Series["Series1"].MarkerSize = 2;
            chartName.Series["Series1"].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
            chartName.Series["Series1"].SmartLabelStyle.Enabled = false;
            chartName.Series["Series1"].LabelBackColor = chartName.ChartAreas["ChartArea1"].BackColor;
        }
        private static void AbsoluteValuesFloat(double[] array, float data)
        {
            if (_4WheelsSettings.AbsoluteValues == true)
            {
                array[array.Length - 1] = Math.Abs(data);
            }
            else
            {
                array[array.Length - 1] = data;
            }
        }
        private static void FL_XYZArraySelections()
        {
            //X
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_TravelSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_AngularVelocity);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_VerticalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_VerticalDeflection);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LoadedRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_EffectiveRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_ContactLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_SteerAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_CamberAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LateralLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_SlipAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LateralFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LongitudinalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_SlipRatio);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LongitudinalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_TreadTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_InnerTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_TotalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_SuspensionLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_SuspensionVelocity);
            }
            else//fallback to slip angle
            {
                AbsoluteValuesFloat(FL_X1ValuesChartArray, LiveData.FL_SlipAngleDeg);
            }
            //Y
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_TravelSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_AngularVelocity);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_VerticalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_VerticalDeflection);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LoadedRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_EffectiveRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_ContactLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LateralLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LateralFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_SlipRatio);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_TreadTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_InnerTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_TotalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_SuspensionLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_SuspensionVelocity);
            }
            else//fallback to lateral friction
            {
                AbsoluteValuesFloat(FL_Y1ValuesChartArray, LiveData.FL_LateralFriction);
            }
            //Z
            if (_4WheelsSettings.Z1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_TravelSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_AngularVelocity);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_VerticalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_VerticalDeflection);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LoadedRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_EffectiveRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_ContactLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LateralLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LateralFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_SlipRatio);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_TreadTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_InnerTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_TotalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_SuspensionLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_SuspensionVelocity);
            }
            else//fallback to vertical load
            {
                AbsoluteValuesFloat(FL_Z1ValuesChartArray, LiveData.FL_VerticalLoad);
            }
        }
        private static void FR_XYZArraySelections()
        {
            //X
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_TravelSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_AngularVelocity);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_VerticalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_VerticalDeflection);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LoadedRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_EffectiveRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_ContactLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_SteerAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_CamberAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LateralLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_SlipAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LateralFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LongitudinalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_SlipRatio);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LongitudinalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_TreadTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_InnerTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_TotalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_SuspensionLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_SuspensionVelocity);
            }
            else//fallback to slip angle
            {
                AbsoluteValuesFloat(FR_X1ValuesChartArray, LiveData.FR_SlipAngleDeg);
            }
            //Y
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_TravelSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_AngularVelocity);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_VerticalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_VerticalDeflection);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LoadedRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_EffectiveRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_ContactLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LateralLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LateralFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_SlipRatio);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_TreadTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_InnerTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_TotalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_SuspensionLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_SuspensionVelocity);
            }
            else//fallback to lateral friction
            {
                AbsoluteValuesFloat(FR_Y1ValuesChartArray, LiveData.FR_LateralFriction);
            }
            //Z
            if (_4WheelsSettings.Z1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_TravelSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_AngularVelocity);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_VerticalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_VerticalDeflection);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LoadedRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_EffectiveRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_ContactLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LateralLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LateralFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_SlipRatio);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_TreadTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_InnerTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_TotalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_SuspensionLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_SuspensionVelocity);
            }
            else//fallback to vertical load
            {
                AbsoluteValuesFloat(FR_Z1ValuesChartArray, LiveData.FR_VerticalLoad);
            }
        }
        private static void RL_XYZArraySelections()
        {
            //X
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_TravelSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_AngularVelocity);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_VerticalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_VerticalDeflection);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LoadedRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_EffectiveRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_ContactLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_SteerAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_CamberAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LateralLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_SlipAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LateralFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LongitudinalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_SlipRatio);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LongitudinalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_TreadTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_InnerTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_TotalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_SuspensionLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_SuspensionVelocity);
            }
            else//fallback to slip angle
            {
                AbsoluteValuesFloat(RL_X1ValuesChartArray, LiveData.RL_SlipAngleDeg);
            }
            //Y
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_TravelSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_AngularVelocity);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_VerticalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_VerticalDeflection);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LoadedRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_EffectiveRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_ContactLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LateralLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LateralFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_SlipRatio);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_TreadTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_InnerTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_TotalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_SuspensionLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_SuspensionVelocity);
            }
            else//fallback to lateral friction
            {
                AbsoluteValuesFloat(RL_Y1ValuesChartArray, LiveData.RL_LateralFriction);
            }
            //Z
            if (_4WheelsSettings.Z1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_TravelSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_AngularVelocity);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_VerticalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_VerticalDeflection);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LoadedRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_EffectiveRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_ContactLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LateralLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LateralFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_SlipRatio);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_TreadTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_InnerTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_TotalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_SuspensionLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_SuspensionVelocity);
            }
            else//fallback to vertical load
            {
                AbsoluteValuesFloat(RL_Z1ValuesChartArray, LiveData.RL_VerticalLoad);
            }
        }
        private static void RR_XYZArraySelections()
        {
            //X
            if (_4WheelsSettings.X1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_TravelSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_AngularVelocity);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_VerticalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_VerticalDeflection);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LoadedRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_EffectiveRadius);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_ContactLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_SteerAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_CamberAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LateralLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_SlipAngleDeg);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LateralFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LongitudinalLoad);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_SlipRatio);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LongitudinalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_TreadTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_InnerTemperature);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_TotalFriction);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_SuspensionLength);
            }
            else if (_4WheelsSettings.X1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_SuspensionVelocity);
            }
            else//fallback to slip angle
            {
                AbsoluteValuesFloat(RR_X1ValuesChartArray, LiveData.RR_SlipAngleDeg);
            }
            //Y
            if (_4WheelsSettings.Y1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_TravelSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_AngularVelocity);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_VerticalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_VerticalDeflection);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LoadedRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_EffectiveRadius);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_ContactLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LateralLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LateralFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_SlipRatio);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_TreadTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_InnerTemperature);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_TotalFriction);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_SuspensionLength);
            }
            else if (_4WheelsSettings.Y1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_SuspensionVelocity);
            }
            else//fallback to lateral friction
            {
                AbsoluteValuesFloat(RR_Y1ValuesChartArray, LiveData.RR_LateralFriction);
            }
            //Z
            if (_4WheelsSettings.Z1Selection == LiveData.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_TravelSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sAngularVelocity)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_AngularVelocity);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalLoad)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_VerticalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sVerticalDeflection)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_VerticalDeflection);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLoadedRadius)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LoadedRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sEffectiveRadius)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_EffectiveRadius);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sContactLength)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_ContactLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sBrakeTorque)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_CurrentContactBrakeTorque);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_CurrentContactBrakeTorqueMax);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSteerAngle)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_SteerAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sCamberAngle)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_CamberAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralLoad)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LateralLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipAngle)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_SlipAngleDeg);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralFriction)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LateralFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LateralSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LongitudinalLoad);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSlipRatio)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_SlipRatio);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LongitudinalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_LongitudinalSlipSpeed);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTreadTemperature)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_TreadTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sInnerTemperature)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_InnerTemperature);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sRaceTime)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RaceTime);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFriction)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_TotalFriction);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_TotalFrictionAngle);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionLength)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_SuspensionLength);
            }
            else if (_4WheelsSettings.Z1Selection == LiveData.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_SuspensionVelocity);
            }
            else//fallback to vertical load
            {
                AbsoluteValuesFloat(RR_Z1ValuesChartArray, LiveData.RR_VerticalLoad);
            }
        }
        private static void ColorGradientRG(Chart chartName, double array, int i, int u)
        {
            //double minus = _4WheelsSettings.Y1Max / steps;
            //double ten = _4WheelsSettings.Y1Max;
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

            /*if (array >= ten)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
            }
            else if (array < ten && array >= nine)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
            }*/
            if (array >= nine)
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
        private static void ColorGradientRB(Chart chartName, double array, int i, int u)
        {
            //double minus = _4WheelsSettings.Y1Max / steps;
            //double ten = _4WheelsSettings.Y1Max;
            double minus = (_4WheelsSettings.Z1Max - _4WheelsSettings.Z1Max) / steps;
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

            /*if (array >= ten)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
            }
            else if (array < ten && array >= nine)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
            }*/
            if (array >= nine)
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
        private static void ColorGradientSet1(Chart chartName, double array, int i, int u)
        {
            //double minus = _4WheelsSettings.Y1Max / steps;
            //double ten = _4WheelsSettings.Y1Max;
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
            // Colors from https://jacksonlab.agronomy.wisc.edu/2016/05/23/15-level-colorblind-friendly-palette/
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

            /*if (array >= ten)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color13;
            }
            else if (array < ten && array >= nine)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color14;
            }*/
            if (array >= nine)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color13;
            }
            else if (array < nine && array >= eight)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color14;
            }
            else if (array < eight && array >= seven)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color15;
            }
            else if (array < seven && array >= six)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color9;
            }
            else if (array < six && array >= five)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color8;
            }
            else if (array < five && array >= four)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color7;
            }
            else if (array < four && array >= three)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color6;
            }
            else if (array < three && array >= two)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color4;
            }
            else if (array < two && array >= one)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color3;
            }
            else if (array < one && array >= zero)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color2;
            }
            else
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color2;
            }
        }
        private static void FL_ColorGradientRG(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(FL_Y1ValuesChartArray[i]);
            double array = Math.Abs(FL_Z1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void FR_ColorGradientRG(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(FR_Y1ValuesChartArray[i]);
            double array = Math.Abs(FR_Z1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void RL_ColorGradientRG(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(RL_Y1ValuesChartArray[i]);
            double array = Math.Abs(RL_Z1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void RR_ColorGradientRG(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(RR_Y1ValuesChartArray[i]);
            double array = Math.Abs(RR_Z1ValuesChartArray[i]);
            ColorGradientRG(chartName, array, i, u);
        }
        private static void FL_ColorGradientRB(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(FL_Y1ValuesChartArray[i]);
            double array = Math.Abs(FL_Z1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void FR_ColorGradientRB(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(FR_Y1ValuesChartArray[i]);
            double array = Math.Abs(FR_Z1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void RL_ColorGradientRB(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(RL_Y1ValuesChartArray[i]);
            double array = Math.Abs(RL_Z1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void RR_ColorGradientRB(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(RR_Y1ValuesChartArray[i]);
            double array = Math.Abs(RR_Z1ValuesChartArray[i]);
            ColorGradientRB(chartName, array, i, u);
        }
        private static void FL_ColorGradientSet1(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(FL_Y1ValuesChartArray[i]);
            double array = Math.Abs(FL_Z1ValuesChartArray[i]);
            ColorGradientSet1(chartName, array, i, u);
        }
        private static void FR_ColorGradientSet1(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(FR_Y1ValuesChartArray[i]);
            double array = Math.Abs(FR_Z1ValuesChartArray[i]);
            ColorGradientSet1(chartName, array, i, u);
        }
        private static void RL_ColorGradientSet1(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(RL_Y1ValuesChartArray[i]);
            double array = Math.Abs(RL_Z1ValuesChartArray[i]);
            ColorGradientSet1(chartName, array, i, u);
        }
        private static void RR_ColorGradientSet1(Chart chartName, int i, int u)
        {
            //double array = Math.Abs(RR_Y1ValuesChartArray[i]);
            double array = Math.Abs(RR_Z1ValuesChartArray[i]);
            ColorGradientSet1(chartName, array, i, u);
        }
        public static void PlotFLChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();

            FL_XYZArraySelections();

            Array.Copy(FL_X1ValuesChartArray, 1, FL_X1ValuesChartArray, 0, FL_X1ValuesChartArray.Length - 1);
            Array.Copy(FL_Y1ValuesChartArray, 1, FL_Y1ValuesChartArray, 0, FL_Y1ValuesChartArray.Length - 1);
            Array.Copy(FL_Z1ValuesChartArray, 1, FL_Z1ValuesChartArray, 0, FL_Z1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                    FL_ColorGradientRG(chartName, i, 1);
                }
            }
            else if(_4WheelsSettings.Scheme == "Colorblind")
            {
                for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                    FL_ColorGradientSet1(chartName, i, 1);
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

            FR_XYZArraySelections();

            Array.Copy(FR_X1ValuesChartArray, 1, FR_X1ValuesChartArray, 0, FR_X1ValuesChartArray.Length - 1);
            Array.Copy(FR_Y1ValuesChartArray, 1, FR_Y1ValuesChartArray, 0, FR_Y1ValuesChartArray.Length - 1);
            Array.Copy(FR_Z1ValuesChartArray, 1, FR_Z1ValuesChartArray, 0, FR_Z1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                    FR_ColorGradientRG(chartName, i, 1);
                }
            }
            else if (_4WheelsSettings.Scheme == "Colorblind")
            {
                for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                    FR_ColorGradientSet1(chartName, i, 1);
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

            RL_XYZArraySelections();

            Array.Copy(RL_X1ValuesChartArray, 1, RL_X1ValuesChartArray, 0, RL_X1ValuesChartArray.Length - 1);
            Array.Copy(RL_Y1ValuesChartArray, 1, RL_Y1ValuesChartArray, 0, RL_Y1ValuesChartArray.Length - 1);
            Array.Copy(RL_Z1ValuesChartArray, 1, RL_Z1ValuesChartArray, 0, RL_Z1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                    RL_ColorGradientRG(chartName, i, 1);
                }
            }
            else if (_4WheelsSettings.Scheme == "Colorblind")
            {
                for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                    RL_ColorGradientSet1(chartName, i, 1);
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

            RR_XYZArraySelections();

            Array.Copy(RR_X1ValuesChartArray, 1, RR_X1ValuesChartArray, 0, RR_X1ValuesChartArray.Length - 1);
            Array.Copy(RR_Y1ValuesChartArray, 1, RR_Y1ValuesChartArray, 0, RR_Y1ValuesChartArray.Length - 1);
            Array.Copy(RR_Z1ValuesChartArray, 1, RR_Z1ValuesChartArray, 0, RR_Z1ValuesChartArray.Length - 1);

            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                    RR_ColorGradientRG(chartName, i, 1);
                }
            }
            else if (_4WheelsSettings.Scheme == "Colorblind")
            {
                for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                {
                    chartName.Series["Series1"].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                    RR_ColorGradientSet1(chartName, i, 1);
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
                chartName.Series.Insert(0, new Series("Series" + uHistoryHelper.ToString()));
                chartName.Series["Series" + uHistoryHelper].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + uHistoryHelper.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerSize = 2;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + uHistoryHelper.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                        FL_ColorGradientRG(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else if (_4WheelsSettings.Scheme == "Colorblind")
                {
                    for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                        FL_ColorGradientSet1(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else
                {
                    for (int i = 0; i < FL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(FL_X1ValuesChartArray[i], FL_Y1ValuesChartArray[i]);
                        FL_ColorGradientRB(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }

            }
        }
        public static void InfiniteHistoryFRChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + uHistoryHelper.ToString()));
                chartName.Series["Series" + uHistoryHelper].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + uHistoryHelper.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerSize = 2;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + uHistoryHelper.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                        FR_ColorGradientRG(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else if (_4WheelsSettings.Scheme == "Colorblind")
                {
                    for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                        FR_ColorGradientSet1(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else
                {
                    for (int i = 0; i < FR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(FR_X1ValuesChartArray[i], FR_Y1ValuesChartArray[i]);
                        FR_ColorGradientRB(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }

            }
        }
        public static void InfiniteHistoryRLChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + uHistoryHelper.ToString()));
                chartName.Series["Series" + uHistoryHelper].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + uHistoryHelper.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerSize = 2;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + uHistoryHelper.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                        RL_ColorGradientRG(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else if (_4WheelsSettings.Scheme == "Colorblind")
                {
                    for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                        RL_ColorGradientSet1(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else
                {
                    for (int i = 0; i < RL_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(RL_X1ValuesChartArray[i], RL_Y1ValuesChartArray[i]);
                        RL_ColorGradientRB(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }

            }
        }
        public static void InfiniteHistoryRRChart(Chart chartName)
        {
            if (_4WheelsSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + uHistoryHelper.ToString()));
                chartName.Series["Series" + uHistoryHelper].ChartType = SeriesChartType.Point;
                chartName.Series["Series" + uHistoryHelper.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerSize = 2;
                chartName.Series["Series" + uHistoryHelper.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + uHistoryHelper.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + uHistoryHelper.ToString()].LabelBackColor = Color.Transparent;

                if (_4WheelsSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                        RR_ColorGradientRG(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else if (_4WheelsSettings.Scheme == "Colorblind")
                {
                    for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                        RR_ColorGradientSet1(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }
                else
                {
                    for (int i = 0; i < RR_X1ValuesChartArray.Length - 1; ++i)
                    {
                        chartName.Series["Series" + uHistoryHelper.ToString()].Points.AddXY(RR_X1ValuesChartArray[i], RR_Y1ValuesChartArray[i]);
                        RR_ColorGradientRB(chartName, i, uHistoryHelper);
                    }
                    uHistoryHelper++;
                }

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
