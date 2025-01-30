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

        private static void ForLoopAxisArrays(Chart chartName, int u, double[] arrayX, double[] arrayY, double[] arrayZ)
        {
            for (int i = 0; i < arrayX.Length - 1; ++i)
            {
                chartName.Series["Series" + u.ToString()].Points.AddXY(arrayX[i], arrayY[i]);
                ColorGradient(chartName, Math.Abs(arrayZ[i]), i, u);
            }
        }
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
                dMin = -dMax / 2;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sAngularVelocity)
            {
                dMax = 400;
                dMin = -dMax / 2;

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
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sCamberAngle)
            {
                dMax = 10;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLateralLoad)
            {
                dMax = 10000;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSlipAngle)
            {
                dMax = 45;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLateralFriction)
            {
                dMax = 2;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLateralSlipSpeed)
            {
                dMax = 20;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLongitudinalLoad)
            {
                dMax = 10000;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sSlipRatio)
            {
                dMax = 1;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLongitudinalFriction)
            {
                dMax = 2;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                dMax = 20;
                dMin = -dMax;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sTreadTemperature)
            {
                dMax = 380;
                dMin = -20;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sInnerTemperature)
            {
                dMax = 380;
                dMin = -20;

                ZAxisDefaultsSelected(dAxis, dMax, dMin);
            }
            else if (axisSelection == LogSettings.sTotalFriction)
            {
                dMax = 2;
                dMin = -dMax;

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
                dMin = -dMax;

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
            while (chartName.Series.Count > 1) { chartName.Series.RemoveAt(0); }
        }
        public static void SetChart(Chart chartName)
        {
            XYAxisDefaults("X",
                         _4WheelsSettings.X1Selection,
                         _4WheelsSettings.X1Defaults);

            XYAxisDefaults("Y",
                         _4WheelsSettings.Y1Selection,
                         _4WheelsSettings.Y1Defaults);

            ZAxisDefaults(_4WheelsSettings.Z1Selection, _4WheelsSettings.Z1Defaults);

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
        private static void XYZArraySelections(string xAxisSelection, double[] arrayX,
                                                string yAxisSelection, double[] arrayY,
                                                string zAxisSelection, double[] arrayZ,

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
            //X
            if (xAxisSelection == LogSettings.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(arrayX, travelSpeed);
            }
            else if (xAxisSelection == LogSettings.sAngularVelocity)
            {
                AbsoluteValuesFloat(arrayX, angVel);
            }
            else if (xAxisSelection == LogSettings.sVerticalLoad)
            {
                AbsoluteValuesFloat(arrayX, verLoad);
            }
            else if (xAxisSelection == LogSettings.sVerticalDeflection)
            {
                AbsoluteValuesFloat(arrayX, verDefl);
            }
            else if (xAxisSelection == LogSettings.sLoadedRadius)
            {
                AbsoluteValuesFloat(arrayX, loadRadius);
            }
            else if (xAxisSelection == LogSettings.sEffectiveRadius)
            {
                AbsoluteValuesFloat(arrayX, effRadius);
            }
            else if (xAxisSelection == LogSettings.sContactLength)
            {
                AbsoluteValuesFloat(arrayX, contLength);
            }
            else if (xAxisSelection == LogSettings.sBrakeTorque)
            {
                AbsoluteValuesFloat(arrayX, currContBrakeTorq);
            }
            else if (xAxisSelection == LogSettings.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(arrayX, currContBrakeTorqMax);
            }
            else if (xAxisSelection == LogSettings.sSteerAngle)
            {
                AbsoluteValuesFloat(arrayX, steerAngDeg);
            }
            else if (xAxisSelection == LogSettings.sCamberAngle)
            {
                AbsoluteValuesFloat(arrayX, cambAngDeg);
            }
            else if (xAxisSelection == LogSettings.sLateralLoad)
            {
                AbsoluteValuesFloat(arrayX, latLoad);
            }
            else if (xAxisSelection == LogSettings.sSlipAngle)
            {
                AbsoluteValuesFloat(arrayX, slipAngleDeg);
            }
            else if (xAxisSelection == LogSettings.sLateralFriction)
            {
                AbsoluteValuesFloat(arrayX, latFrict);
            }
            else if (xAxisSelection == LogSettings.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(arrayX, latSlipSpeed);
            }
            else if (xAxisSelection == LogSettings.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(arrayX, lonLoad);
            }
            else if (xAxisSelection == LogSettings.sSlipRatio)
            {
                AbsoluteValuesFloat(arrayX, slipRatio);
            }
            else if (xAxisSelection == LogSettings.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(arrayX, lonFrict);
            }
            else if (xAxisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(arrayX, lonSlipSpeed);
            }
            else if (xAxisSelection == LogSettings.sTreadTemperature)
            {
                AbsoluteValuesFloat(arrayX, treadTemp);
            }
            else if (xAxisSelection == LogSettings.sInnerTemperature)
            {
                AbsoluteValuesFloat(arrayX, innerTemp);
            }
            else if (xAxisSelection == LogSettings.sRaceTime)
            {
                AbsoluteValuesFloat(arrayX, raceTime);
            }
            else if (xAxisSelection == LogSettings.sTotalFriction)
            {
                AbsoluteValuesFloat(arrayX, totalFrict);
            }
            else if (xAxisSelection == LogSettings.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(arrayX, totalFrictAngle);
            }
            else if (xAxisSelection == LogSettings.sSuspensionLength)
            {
                AbsoluteValuesFloat(arrayX, suspLength);
            }
            else if (xAxisSelection == LogSettings.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(arrayX, suspVel);
            }
            else//fallback to slip angle
            {
                AbsoluteValuesFloat(arrayX, slipAngleDeg);
            }
            //Y
            if (yAxisSelection == LogSettings.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(arrayY, travelSpeed);
            }
            else if (yAxisSelection == LogSettings.sAngularVelocity)
            {
                AbsoluteValuesFloat(arrayY, angVel);
            }
            else if (yAxisSelection == LogSettings.sVerticalLoad)
            {
                AbsoluteValuesFloat(arrayY, verLoad);
            }
            else if (yAxisSelection == LogSettings.sVerticalDeflection)
            {
                AbsoluteValuesFloat(arrayY, verDefl);
            }
            else if (yAxisSelection == LogSettings.sLoadedRadius)
            {
                AbsoluteValuesFloat(arrayY, loadRadius);
            }
            else if (yAxisSelection == LogSettings.sEffectiveRadius)
            {
                AbsoluteValuesFloat(arrayY, effRadius);
            }
            else if (yAxisSelection == LogSettings.sContactLength)
            {
                AbsoluteValuesFloat(arrayY, contLength);
            }
            else if (yAxisSelection == LogSettings.sBrakeTorque)
            {
                AbsoluteValuesFloat(arrayY, currContBrakeTorq);
            }
            else if (yAxisSelection == LogSettings.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(arrayY, currContBrakeTorqMax);
            }
            else if (yAxisSelection == LogSettings.sSteerAngle)
            {
                AbsoluteValuesFloat(arrayY, steerAngDeg);
            }
            else if (yAxisSelection == LogSettings.sCamberAngle)
            {
                AbsoluteValuesFloat(arrayY, cambAngDeg);
            }
            else if (yAxisSelection == LogSettings.sLateralLoad)
            {
                AbsoluteValuesFloat(arrayY, latLoad);
            }
            else if (yAxisSelection == LogSettings.sSlipAngle)
            {
                AbsoluteValuesFloat(arrayY, slipAngleDeg);
            }
            else if (yAxisSelection == LogSettings.sLateralFriction)
            {
                AbsoluteValuesFloat(arrayY, latFrict);
            }
            else if (yAxisSelection == LogSettings.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(arrayY, latSlipSpeed);
            }
            else if (yAxisSelection == LogSettings.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(arrayY, lonLoad);
            }
            else if (yAxisSelection == LogSettings.sSlipRatio)
            {
                AbsoluteValuesFloat(arrayY, slipRatio);
            }
            else if (yAxisSelection == LogSettings.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(arrayY, lonFrict);
            }
            else if (yAxisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(arrayY, lonSlipSpeed);
            }
            else if (yAxisSelection == LogSettings.sTreadTemperature)
            {
                AbsoluteValuesFloat(arrayY, treadTemp);
            }
            else if (yAxisSelection == LogSettings.sInnerTemperature)
            {
                AbsoluteValuesFloat(arrayY, innerTemp);
            }
            else if (yAxisSelection == LogSettings.sRaceTime)
            {
                AbsoluteValuesFloat(arrayY, raceTime);
            }
            else if (yAxisSelection == LogSettings.sTotalFriction)
            {
                AbsoluteValuesFloat(arrayY, totalFrict);
            }
            else if (yAxisSelection == LogSettings.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(arrayY, totalFrictAngle);
            }
            else if (yAxisSelection == LogSettings.sSuspensionLength)
            {
                AbsoluteValuesFloat(arrayY, suspLength);
            }
            else if (yAxisSelection == LogSettings.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(arrayY, suspVel);
            }
            else//fallback to lateral friction
            {
                AbsoluteValuesFloat(arrayY, latFrict);
            }
            //Z
            if (zAxisSelection == LogSettings.sTireTravelSpeed)
            {
                AbsoluteValuesFloat(arrayZ, travelSpeed);
            }
            else if (zAxisSelection == LogSettings.sAngularVelocity)
            {
                AbsoluteValuesFloat(arrayZ, angVel);
            }
            else if (zAxisSelection == LogSettings.sVerticalLoad)
            {
                AbsoluteValuesFloat(arrayZ, verLoad);
            }
            else if (zAxisSelection == LogSettings.sVerticalDeflection)
            {
                AbsoluteValuesFloat(arrayZ, verDefl);
            }
            else if (zAxisSelection == LogSettings.sLoadedRadius)
            {
                AbsoluteValuesFloat(arrayZ, loadRadius);
            }
            else if (zAxisSelection == LogSettings.sEffectiveRadius)
            {
                AbsoluteValuesFloat(arrayZ, effRadius);
            }
            else if (zAxisSelection == LogSettings.sContactLength)
            {
                AbsoluteValuesFloat(arrayZ, contLength);
            }
            else if (zAxisSelection == LogSettings.sBrakeTorque)
            {
                AbsoluteValuesFloat(arrayZ, currContBrakeTorq);
            }
            else if (zAxisSelection == LogSettings.sMaxBrakeTorque)
            {
                AbsoluteValuesFloat(arrayZ, currContBrakeTorqMax);
            }
            else if (zAxisSelection == LogSettings.sSteerAngle)
            {
                AbsoluteValuesFloat(arrayZ, steerAngDeg);
            }
            else if (zAxisSelection == LogSettings.sCamberAngle)
            {
                AbsoluteValuesFloat(arrayZ, cambAngDeg);
            }
            else if (zAxisSelection == LogSettings.sLateralLoad)
            {
                AbsoluteValuesFloat(arrayZ, latLoad);
            }
            else if (zAxisSelection == LogSettings.sSlipAngle)
            {
                AbsoluteValuesFloat(arrayZ, slipAngleDeg);
            }
            else if (zAxisSelection == LogSettings.sLateralFriction)
            {
                AbsoluteValuesFloat(arrayZ, latFrict);
            }
            else if (zAxisSelection == LogSettings.sLateralSlipSpeed)
            {
                AbsoluteValuesFloat(arrayZ, latSlipSpeed);
            }
            else if (zAxisSelection == LogSettings.sLongitudinalLoad)
            {
                AbsoluteValuesFloat(arrayZ, lonLoad);
            }
            else if (zAxisSelection == LogSettings.sSlipRatio)
            {
                AbsoluteValuesFloat(arrayZ, slipRatio);
            }
            else if (zAxisSelection == LogSettings.sLongitudinalFriction)
            {
                AbsoluteValuesFloat(arrayZ, lonFrict);
            }
            else if (zAxisSelection == LogSettings.sLongitudinalSlipSpeed)
            {
                AbsoluteValuesFloat(arrayZ, lonSlipSpeed);
            }
            else if (zAxisSelection == LogSettings.sTreadTemperature)
            {
                AbsoluteValuesFloat(arrayZ, treadTemp);
            }
            else if (zAxisSelection == LogSettings.sInnerTemperature)
            {
                AbsoluteValuesFloat(arrayZ, innerTemp);
            }
            else if (zAxisSelection == LogSettings.sRaceTime)
            {
                AbsoluteValuesFloat(arrayZ, raceTime);
            }
            else if (zAxisSelection == LogSettings.sTotalFriction)
            {
                AbsoluteValuesFloat(arrayZ, totalFrict);
            }
            else if (zAxisSelection == LogSettings.sTotalFrictionAngle)
            {
                AbsoluteValuesFloat(arrayZ, totalFrictAngle);
            }
            else if (zAxisSelection == LogSettings.sSuspensionLength)
            {
                AbsoluteValuesFloat(arrayZ, suspLength);
            }
            else if (zAxisSelection == LogSettings.sSuspensionVelocity)
            {
                AbsoluteValuesFloat(arrayZ, suspVel);
            }
            else//fallback to vertical load
            {
                AbsoluteValuesFloat(arrayZ, verLoad);
            }
        }
        private static void ColorGradient(Chart chartName, double array, int i, int u)
        {
            array = Math.Abs(array);

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

            Color color10;
            Color color9;
            Color color8;
            Color color7;
            Color color6;
            Color color5;
            Color color4;
            Color color3;
            Color color2;
            Color color1;

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
            if (array >= nine)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color10;
            }
            else if (array < nine && array >= eight)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color9;
            }
            else if (array < eight && array >= seven)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color8;
            }
            else if (array < seven && array >= six)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color7;
            }
            else if (array < six && array >= five)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color6;
            }
            else if (array < five && array >= four)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color5;
            }
            else if (array < four && array >= three)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color4;
            }
            else if (array < three && array >= two)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color3;
            }
            else if (array < two && array >= one)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color2;
            }
            else if (array < one && array >= zero)
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color1;
            }
            else
            {
                chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = color1;
            }
        }
        public static void PlotChart(Chart chartName, double[] arrayX, double[] arrayY, double[] arrayZ)
        {
            chartName.Series["Series1"].Points.Clear();

            XYZArraySelections(_4WheelsSettings.X1Selection, arrayX, _4WheelsSettings.Y1Selection, arrayY, _4WheelsSettings.Z1Selection, arrayZ,
                                                LiveData.RaceTime, LiveData.FL_TravelSpeed, LiveData.FL_AngularVelocity,
                                                LiveData.FL_VerticalLoad, LiveData.FL_VerticalDeflection, LiveData.FL_LoadedRadius, LiveData.FL_EffectiveRadius, LiveData.FL_ContactLength,
                                                LiveData.FL_CurrentContactBrakeTorque, LiveData.FL_CurrentContactBrakeTorqueMax,
                                                LiveData.FL_SteerAngleDeg, LiveData.FL_CamberAngleDeg,
                                                LiveData.FL_LateralLoad, LiveData.FL_SlipAngleDeg, LiveData.FL_LateralFriction, LiveData.FL_LateralSlipSpeed,
                                                LiveData.FL_LongitudinalLoad, LiveData.FL_SlipRatio, LiveData.FL_LongitudinalFriction, LiveData.FL_LongitudinalSlipSpeed,
                                                LiveData.FL_TreadTemperature, LiveData.FL_InnerTemperature,
                                                LiveData.FL_TotalFriction, LiveData.FL_TotalFrictionAngle,
                                                LiveData.FL_SuspensionLength, LiveData.FL_SuspensionVelocity);

            XYZArraySelections(_4WheelsSettings.X1Selection, arrayX, _4WheelsSettings.Y1Selection, arrayY, _4WheelsSettings.Z1Selection, arrayZ,
                                                LiveData.RaceTime, LiveData.FR_TravelSpeed, LiveData.FR_AngularVelocity,
                                                LiveData.FR_VerticalLoad, LiveData.FR_VerticalDeflection, LiveData.FR_LoadedRadius, LiveData.FR_EffectiveRadius, LiveData.FR_ContactLength,
                                                LiveData.FR_CurrentContactBrakeTorque, LiveData.FR_CurrentContactBrakeTorqueMax,
                                                LiveData.FR_SteerAngleDeg, LiveData.FR_CamberAngleDeg,
                                                LiveData.FR_LateralLoad, LiveData.FR_SlipAngleDeg, LiveData.FR_LateralFriction, LiveData.FR_LateralSlipSpeed,
                                                LiveData.FR_LongitudinalLoad, LiveData.FR_SlipRatio, LiveData.FR_LongitudinalFriction, LiveData.FR_LongitudinalSlipSpeed,
                                                LiveData.FR_TreadTemperature, LiveData.FR_InnerTemperature,
                                                LiveData.FR_TotalFriction, LiveData.FR_TotalFrictionAngle,
                                                LiveData.FR_SuspensionLength, LiveData.FR_SuspensionVelocity);

            XYZArraySelections(_4WheelsSettings.X1Selection, arrayX, _4WheelsSettings.Y1Selection, arrayY, _4WheelsSettings.Z1Selection, arrayZ,
                                                LiveData.RaceTime, LiveData.RL_TravelSpeed, LiveData.RL_AngularVelocity,
                                                LiveData.RL_VerticalLoad, LiveData.RL_VerticalDeflection, LiveData.RL_LoadedRadius, LiveData.RL_EffectiveRadius, LiveData.RL_ContactLength,
                                                LiveData.RL_CurrentContactBrakeTorque, LiveData.RL_CurrentContactBrakeTorqueMax,
                                                LiveData.RL_SteerAngleDeg, LiveData.RL_CamberAngleDeg,
                                                LiveData.RL_LateralLoad, LiveData.RL_SlipAngleDeg, LiveData.RL_LateralFriction, LiveData.RL_LateralSlipSpeed,
                                                LiveData.RL_LongitudinalLoad, LiveData.RL_SlipRatio, LiveData.RL_LongitudinalFriction, LiveData.RL_LongitudinalSlipSpeed,
                                                LiveData.RL_TreadTemperature, LiveData.RL_InnerTemperature,
                                                LiveData.RL_TotalFriction, LiveData.RL_TotalFrictionAngle,
                                                LiveData.RL_SuspensionLength, LiveData.RL_SuspensionVelocity);

            XYZArraySelections(_4WheelsSettings.X1Selection, arrayX, _4WheelsSettings.Y1Selection, arrayY, _4WheelsSettings.Z1Selection, arrayZ,
                                                LiveData.RaceTime, LiveData.RR_TravelSpeed, LiveData.RR_AngularVelocity,
                                                LiveData.RR_VerticalLoad, LiveData.RR_VerticalDeflection, LiveData.RR_LoadedRadius, LiveData.RR_EffectiveRadius, LiveData.RR_ContactLength,
                                                LiveData.RR_CurrentContactBrakeTorque, LiveData.RR_CurrentContactBrakeTorqueMax,
                                                LiveData.RR_SteerAngleDeg, LiveData.RR_CamberAngleDeg,
                                                LiveData.RR_LateralLoad, LiveData.RR_SlipAngleDeg, LiveData.RR_LateralFriction, LiveData.RR_LateralSlipSpeed,
                                                LiveData.RR_LongitudinalLoad, LiveData.RR_SlipRatio, LiveData.RR_LongitudinalFriction, LiveData.RR_LongitudinalSlipSpeed,
                                                LiveData.RR_TreadTemperature, LiveData.RR_InnerTemperature,
                                                LiveData.RR_TotalFriction, LiveData.RR_TotalFrictionAngle,
                                                LiveData.RR_SuspensionLength, LiveData.RR_SuspensionVelocity);
            /*if (wheelXY == "FL")
            {
                FL_XYZArraySelections();
            }
            else if (wheelXY == "FR")
            {
                FR_XYZArraySelections();
            }
            else if (wheelXY == "RL")
            {
                RL_XYZArraySelections();
            }
            else if (wheelXY == "RR")
            {
                RR_XYZArraySelections();
            }
            else
            {
                return;
            }
            */
            Array.Copy(arrayX, 1, arrayX, 0, arrayX.Length - 1);
            Array.Copy(arrayY, 1, arrayY, 0, arrayY.Length - 1);
            Array.Copy(arrayZ, 1, arrayZ, 0, arrayZ.Length - 1);

            ForLoopAxisArrays(chartName, 1, arrayX, arrayY, arrayZ);

            chartName.Series["Series1"].Points.Last().MarkerSize = 8;
            chartName.Series["Series1"].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = false;//true;
        }
        public static void InfiniteHistoryChart(Chart chartName, double[] arrayX, double[] arrayY, double[] arrayZ)
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

                ForLoopAxisArrays(chartName, uHistoryHelper, arrayX, arrayY, arrayZ);
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
