using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public partial class Form4Wheels : Form
    {
        bool PauseUpdate;

        public Form4Wheels()
        {
            InitializeComponent();
            PauseUpdate = false;
            timer1.Interval = 50;
            //timer2.Interval = timer1.Interval * _4WheelsSettings.HistoryAmountPoints;
            SetCharts();
        }
        public void SetCharts()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            // WORKS WRONG! Clears the chart series also
            if (_4WheelsSettings.WheelChartsSelect == "All In One")
            {
                _4Wheels.SetChartAllWheelsInOneChartArea(chart1, _4Wheels.seriesFL, _4Wheels.seriesFR, _4Wheels.seriesRL, _4Wheels.seriesRR, "ChartAreaAllWheels");
            }
            if (_4WheelsSettings.WheelChartsSelect == "Front/Rear")
            {
                // Add first front then rear
                _4Wheels.SetChartFrontWheels(chart1, _4Wheels.seriesFL, _4Wheels.seriesFR, "ChartAreaFront");
                _4Wheels.SetChartRearWheels(chart1, _4Wheels.seriesRL, _4Wheels.seriesRR, "ChartAreaRear");

            }
            if (_4WheelsSettings.WheelChartsSelect == "Separate")
            {
                // Add first left and then right sides because the order of the ChartAreas is like that
                _4Wheels.SetChart(chart1, _4Wheels.seriesFL, "ChartAreaFL");
                _4Wheels.SetChart(chart1, _4Wheels.seriesRL, "ChartAreaRL");
                _4Wheels.SetChart(chart1, _4Wheels.seriesFR, "ChartAreaFR");
                _4Wheels.SetChart(chart1, _4Wheels.seriesRR, "ChartAreaRR");
            }
            _4Wheels.SetUpDownChart(GradientChart);
        }
        public void ClearAllSeriesHistory()
        {
            _4Wheels.ClearSeriesHistory(chart1);
        }
        private void ButtonLabelVisibilities()
        {
            if (_4WheelsSettings.WheelChartsSelect == "Separate")
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
            else if (_4WheelsSettings.WheelChartsSelect == "All In One")
            { 
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
            }
            else if(_4WheelsSettings.WheelChartsSelect == "Front/Rear")
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            if (_4WheelsSettings.SettingsOpen == true)
            {
                toSettingsButton.Visible = false;
            }
            if (_4WheelsSettings.SettingsOpen == false)
            {
                toSettingsButton.Visible = true;
            }
            labelUpDownChart.Text = _4WheelsSettings.Z1Selection;
        }
        private void Form4Wheels_Load(object sender, EventArgs e)
        {

            LiveData._4WheelsOpen = true;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form4Wheels_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiveData._4WheelsOpen = false;
        }
        private float[] FL_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4Wheels.FL_X1ValuesChart, _4WheelsSettings.Y1Selection, _4Wheels.FL_Y1ValuesChart, _4WheelsSettings.Z1Selection, _4Wheels.FL_Z1ValuesChart,
                                                    LiveData.RaceTime, LiveData.FL_TravelSpeed, LiveData.FL_AngularVelocity,
                                                    LiveData.FL_VerticalLoad, LiveData.FL_VerticalDeflection, LiveData.FL_LoadedRadius, LiveData.FL_EffectiveRadius, LiveData.FL_ContactLength,
                                                    LiveData.FL_CurrentContactBrakeTorque, LiveData.FL_CurrentContactBrakeTorqueMax,
                                                    LiveData.FL_SteerAngleDeg, LiveData.FL_CamberAngleDeg,
                                                    LiveData.FL_LateralLoad, LiveData.FL_SlipAngleDeg, LiveData.FL_LateralFriction, LiveData.FL_LateralSlipSpeed,
                                                    LiveData.FL_LongitudinalLoad, LiveData.FL_SlipRatio, LiveData.FL_LongitudinalFriction, LiveData.FL_LongitudinalSlipSpeed,
                                                    LiveData.FL_TreadTemperature, LiveData.FL_InnerTemperature,
                                                    LiveData.FL_TotalFriction, LiveData.FL_TotalFrictionAngle,
                                                    LiveData.FL_SuspensionLength, LiveData.FL_SuspensionVelocity);
        }
        private float[] FR_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4Wheels.FR_X1ValuesChart, _4WheelsSettings.Y1Selection, _4Wheels.FR_Y1ValuesChart, _4WheelsSettings.Z1Selection, _4Wheels.FR_Z1ValuesChart,
                                                    LiveData.RaceTime, LiveData.FR_TravelSpeed, LiveData.FR_AngularVelocity,
                                                    LiveData.FR_VerticalLoad, LiveData.FR_VerticalDeflection, LiveData.FR_LoadedRadius, LiveData.FR_EffectiveRadius, LiveData.FR_ContactLength,
                                                    LiveData.FR_CurrentContactBrakeTorque, LiveData.FR_CurrentContactBrakeTorqueMax,
                                                    LiveData.FR_SteerAngleDeg, LiveData.FR_CamberAngleDeg,
                                                    LiveData.FR_LateralLoad, LiveData.FR_SlipAngleDeg, LiveData.FR_LateralFriction, LiveData.FR_LateralSlipSpeed,
                                                    LiveData.FR_LongitudinalLoad, LiveData.FR_SlipRatio, LiveData.FR_LongitudinalFriction, LiveData.FR_LongitudinalSlipSpeed,
                                                    LiveData.FR_TreadTemperature, LiveData.FR_InnerTemperature,
                                                    LiveData.FR_TotalFriction, LiveData.FR_TotalFrictionAngle,
                                                    LiveData.FR_SuspensionLength, LiveData.FR_SuspensionVelocity);
        }
        private float[] RL_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4Wheels.RL_X1ValuesChart, _4WheelsSettings.Y1Selection, _4Wheels.RL_Y1ValuesChart, _4WheelsSettings.Z1Selection, _4Wheels.RL_Z1ValuesChart,
                                                    LiveData.RaceTime, LiveData.RL_TravelSpeed, LiveData.RL_AngularVelocity,
                                                    LiveData.RL_VerticalLoad, LiveData.RL_VerticalDeflection, LiveData.RL_LoadedRadius, LiveData.RL_EffectiveRadius, LiveData.RL_ContactLength,
                                                    LiveData.RL_CurrentContactBrakeTorque, LiveData.RL_CurrentContactBrakeTorqueMax,
                                                    LiveData.RL_SteerAngleDeg, LiveData.RL_CamberAngleDeg,
                                                    LiveData.RL_LateralLoad, LiveData.RL_SlipAngleDeg, LiveData.RL_LateralFriction, LiveData.RL_LateralSlipSpeed,
                                                    LiveData.RL_LongitudinalLoad, LiveData.RL_SlipRatio, LiveData.RL_LongitudinalFriction, LiveData.RL_LongitudinalSlipSpeed,
                                                    LiveData.RL_TreadTemperature, LiveData.RL_InnerTemperature,
                                                    LiveData.RL_TotalFriction, LiveData.RL_TotalFrictionAngle,
                                                    LiveData.RL_SuspensionLength, LiveData.RL_SuspensionVelocity);
        }
        private float[] RR_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4Wheels.RR_X1ValuesChart, _4WheelsSettings.Y1Selection, _4Wheels.RR_Y1ValuesChart, _4WheelsSettings.Z1Selection, _4Wheels.RR_Z1ValuesChart,
                                                    LiveData.RaceTime, LiveData.RR_TravelSpeed, LiveData.RR_AngularVelocity,
                                                    LiveData.RR_VerticalLoad, LiveData.RR_VerticalDeflection, LiveData.RR_LoadedRadius, LiveData.RR_EffectiveRadius, LiveData.RR_ContactLength,
                                                    LiveData.RR_CurrentContactBrakeTorque, LiveData.RR_CurrentContactBrakeTorqueMax,
                                                    LiveData.RR_SteerAngleDeg, LiveData.RR_CamberAngleDeg,
                                                    LiveData.RR_LateralLoad, LiveData.RR_SlipAngleDeg, LiveData.RR_LateralFriction, LiveData.RR_LateralSlipSpeed,
                                                    LiveData.RR_LongitudinalLoad, LiveData.RR_SlipRatio, LiveData.RR_LongitudinalFriction, LiveData.RR_LongitudinalSlipSpeed,
                                                    LiveData.RR_TreadTemperature, LiveData.RR_InnerTemperature,
                                                    LiveData.RR_TotalFriction, LiveData.RR_TotalFrictionAngle,
                                                    LiveData.RR_SuspensionLength, LiveData.RR_SuspensionVelocity);
        }
        private void ListSeriesFL(Chart chartName, float xyzValuesZero, float xyzValuesOne, float xyzValuesTwo)
        {
            _4Wheels.ListSeries(chartName, 
            _4Wheels.seriesFL, xyzValuesZero, _4Wheels.FL_X1ValuesChart, xyzValuesOne, _4Wheels.FL_Y1ValuesChart, xyzValuesTwo, _4Wheels.FL_Z1ValuesChart,
            _4Wheels.FL_X1ValuesChartColor1, _4Wheels.FL_Y1ValuesChartColor1,
            _4Wheels.FL_X1ValuesChartColor2, _4Wheels.FL_Y1ValuesChartColor2,
            _4Wheels.FL_X1ValuesChartColor3, _4Wheels.FL_Y1ValuesChartColor3,
            _4Wheels.FL_X1ValuesChartColor4, _4Wheels.FL_Y1ValuesChartColor4,
            _4Wheels.FL_X1ValuesChartColor5, _4Wheels.FL_Y1ValuesChartColor5,
            _4Wheels.FL_X1ValuesChartColor6, _4Wheels.FL_Y1ValuesChartColor6,
            _4Wheels.FL_X1ValuesChartColor7, _4Wheels.FL_Y1ValuesChartColor7,
            _4Wheels.FL_X1ValuesChartColor8, _4Wheels.FL_Y1ValuesChartColor8,
            _4Wheels.FL_X1ValuesChartColor9, _4Wheels.FL_Y1ValuesChartColor9,
            _4Wheels.FL_X1ValuesChartColor10, _4Wheels.FL_Y1ValuesChartColor10);
        }
        private void ListSeriesFR(Chart chartName, float xyzValuesZero, float xyzValuesOne, float xyzValuesTwo)
        {
            _4Wheels.ListSeries(chartName, 
            _4Wheels.seriesFR, xyzValuesZero, _4Wheels.FR_X1ValuesChart, xyzValuesOne, _4Wheels.FR_Y1ValuesChart, xyzValuesTwo, _4Wheels.FR_Z1ValuesChart,
            _4Wheels.FR_X1ValuesChartColor1, _4Wheels.FR_Y1ValuesChartColor1,
            _4Wheels.FR_X1ValuesChartColor2, _4Wheels.FR_Y1ValuesChartColor2,
            _4Wheels.FR_X1ValuesChartColor3, _4Wheels.FR_Y1ValuesChartColor3,
            _4Wheels.FR_X1ValuesChartColor4, _4Wheels.FR_Y1ValuesChartColor4,
            _4Wheels.FR_X1ValuesChartColor5, _4Wheels.FR_Y1ValuesChartColor5,
            _4Wheels.FR_X1ValuesChartColor6, _4Wheels.FR_Y1ValuesChartColor6,
            _4Wheels.FR_X1ValuesChartColor7, _4Wheels.FR_Y1ValuesChartColor7,
            _4Wheels.FR_X1ValuesChartColor8, _4Wheels.FR_Y1ValuesChartColor8,
            _4Wheels.FR_X1ValuesChartColor9, _4Wheels.FR_Y1ValuesChartColor9,
            _4Wheels.FR_X1ValuesChartColor10, _4Wheels.FR_Y1ValuesChartColor10);
        }
        private void ListSeriesRL(Chart chartName, float xyzValuesZero, float xyzValuesOne, float xyzValuesTwo)
        {
            _4Wheels.ListSeries(chartName, 
            _4Wheels.seriesRL, xyzValuesZero, _4Wheels.RL_X1ValuesChart, xyzValuesOne, _4Wheels.RL_Y1ValuesChart, xyzValuesTwo, _4Wheels.RL_Z1ValuesChart,
            _4Wheels.RL_X1ValuesChartColor1, _4Wheels.RL_Y1ValuesChartColor1,
            _4Wheels.RL_X1ValuesChartColor2, _4Wheels.RL_Y1ValuesChartColor2,
            _4Wheels.RL_X1ValuesChartColor3, _4Wheels.RL_Y1ValuesChartColor3,
            _4Wheels.RL_X1ValuesChartColor4, _4Wheels.RL_Y1ValuesChartColor4,
            _4Wheels.RL_X1ValuesChartColor5, _4Wheels.RL_Y1ValuesChartColor5,
            _4Wheels.RL_X1ValuesChartColor6, _4Wheels.RL_Y1ValuesChartColor6,
            _4Wheels.RL_X1ValuesChartColor7, _4Wheels.RL_Y1ValuesChartColor7,
            _4Wheels.RL_X1ValuesChartColor8, _4Wheels.RL_Y1ValuesChartColor8,
            _4Wheels.RL_X1ValuesChartColor9, _4Wheels.RL_Y1ValuesChartColor9,
            _4Wheels.RL_X1ValuesChartColor10, _4Wheels.RL_Y1ValuesChartColor10);
        }
        private void ListSeriesRR(Chart chartName, float xyzValuesZero, float xyzValuesOne, float xyzValuesTwo)
        {
            _4Wheels.ListSeries(chartName, 
            _4Wheels.seriesRR, xyzValuesZero, _4Wheels.RR_X1ValuesChart, xyzValuesOne, _4Wheels.RR_Y1ValuesChart, xyzValuesTwo, _4Wheels.RR_Z1ValuesChart,
            _4Wheels.RR_X1ValuesChartColor1, _4Wheels.RR_Y1ValuesChartColor1,
            _4Wheels.RR_X1ValuesChartColor2, _4Wheels.RR_Y1ValuesChartColor2,
            _4Wheels.RR_X1ValuesChartColor3, _4Wheels.RR_Y1ValuesChartColor3,
            _4Wheels.RR_X1ValuesChartColor4, _4Wheels.RR_Y1ValuesChartColor4,
            _4Wheels.RR_X1ValuesChartColor5, _4Wheels.RR_Y1ValuesChartColor5,
            _4Wheels.RR_X1ValuesChartColor6, _4Wheels.RR_Y1ValuesChartColor6,
            _4Wheels.RR_X1ValuesChartColor7, _4Wheels.RR_Y1ValuesChartColor7,
            _4Wheels.RR_X1ValuesChartColor8, _4Wheels.RR_Y1ValuesChartColor8,
            _4Wheels.RR_X1ValuesChartColor9, _4Wheels.RR_Y1ValuesChartColor9,
            _4Wheels.RR_X1ValuesChartColor10, _4Wheels.RR_Y1ValuesChartColor10);
        }
        private void ListSeriesAllWheels(Chart chartName,
            float xyzValuesZeroFL, float xyzValuesOneFL, float xyzValuesTwoFL, 
            float xyzValuesZeroFR, float xyzValuesOneFR, float xyzValuesTwoFR,
            float xyzValuesZeroRL, float xyzValuesOneRL, float xyzValuesTwoRL,
            float xyzValuesZeroRR, float xyzValuesOneRR, float xyzValuesTwoRR)
        {
            _4Wheels.ListSeriesAllWheels(chartName,
                    _4Wheels.seriesFL, xyzValuesZeroFL, _4Wheels.FL_X1ValuesChart, xyzValuesOneFL, _4Wheels.FL_Y1ValuesChart, xyzValuesTwoFL, _4Wheels.FL_Z1ValuesChart,
            _4Wheels.FL_X1ValuesChartColor1, _4Wheels.FL_Y1ValuesChartColor1,
            _4Wheels.FL_X1ValuesChartColor2, _4Wheels.FL_Y1ValuesChartColor2,
            _4Wheels.FL_X1ValuesChartColor3, _4Wheels.FL_Y1ValuesChartColor3,
            _4Wheels.FL_X1ValuesChartColor4, _4Wheels.FL_Y1ValuesChartColor4,
            _4Wheels.FL_X1ValuesChartColor5, _4Wheels.FL_Y1ValuesChartColor5,
            _4Wheels.FL_X1ValuesChartColor6, _4Wheels.FL_Y1ValuesChartColor6,
            _4Wheels.FL_X1ValuesChartColor7, _4Wheels.FL_Y1ValuesChartColor7,
            _4Wheels.FL_X1ValuesChartColor8, _4Wheels.FL_Y1ValuesChartColor8,
            _4Wheels.FL_X1ValuesChartColor9, _4Wheels.FL_Y1ValuesChartColor9,
            _4Wheels.FL_X1ValuesChartColor10, _4Wheels.FL_Y1ValuesChartColor10,
                    _4Wheels.seriesFR, xyzValuesZeroFR, _4Wheels.FR_X1ValuesChart, xyzValuesOneFR, _4Wheels.FR_Y1ValuesChart, xyzValuesTwoFR, _4Wheels.FR_Z1ValuesChart,
            _4Wheels.FR_X1ValuesChartColor1, _4Wheels.FR_Y1ValuesChartColor1,
            _4Wheels.FR_X1ValuesChartColor2, _4Wheels.FR_Y1ValuesChartColor2,
            _4Wheels.FR_X1ValuesChartColor3, _4Wheels.FR_Y1ValuesChartColor3,
            _4Wheels.FR_X1ValuesChartColor4, _4Wheels.FR_Y1ValuesChartColor4,
            _4Wheels.FR_X1ValuesChartColor5, _4Wheels.FR_Y1ValuesChartColor5,
            _4Wheels.FR_X1ValuesChartColor6, _4Wheels.FR_Y1ValuesChartColor6,
            _4Wheels.FR_X1ValuesChartColor7, _4Wheels.FR_Y1ValuesChartColor7,
            _4Wheels.FR_X1ValuesChartColor8, _4Wheels.FR_Y1ValuesChartColor8,
            _4Wheels.FR_X1ValuesChartColor9, _4Wheels.FR_Y1ValuesChartColor9,
            _4Wheels.FR_X1ValuesChartColor10, _4Wheels.FR_Y1ValuesChartColor10,
                    _4Wheels.seriesRL, xyzValuesZeroRL, _4Wheels.RL_X1ValuesChart, xyzValuesOneRL, _4Wheels.RL_Y1ValuesChart, xyzValuesTwoRL, _4Wheels.RL_Z1ValuesChart,
            _4Wheels.RL_X1ValuesChartColor1, _4Wheels.RL_Y1ValuesChartColor1,
            _4Wheels.RL_X1ValuesChartColor2, _4Wheels.RL_Y1ValuesChartColor2,
            _4Wheels.RL_X1ValuesChartColor3, _4Wheels.RL_Y1ValuesChartColor3,
            _4Wheels.RL_X1ValuesChartColor4, _4Wheels.RL_Y1ValuesChartColor4,
            _4Wheels.RL_X1ValuesChartColor5, _4Wheels.RL_Y1ValuesChartColor5,
            _4Wheels.RL_X1ValuesChartColor6, _4Wheels.RL_Y1ValuesChartColor6,
            _4Wheels.RL_X1ValuesChartColor7, _4Wheels.RL_Y1ValuesChartColor7,
            _4Wheels.RL_X1ValuesChartColor8, _4Wheels.RL_Y1ValuesChartColor8,
            _4Wheels.RL_X1ValuesChartColor9, _4Wheels.RL_Y1ValuesChartColor9,
            _4Wheels.RL_X1ValuesChartColor10, _4Wheels.RL_Y1ValuesChartColor10,
                    _4Wheels.seriesRR, xyzValuesZeroRR, _4Wheels.RR_X1ValuesChart, xyzValuesOneRR, _4Wheels.RR_Y1ValuesChart, xyzValuesTwoRR, _4Wheels.RR_Z1ValuesChart,
            _4Wheels.RR_X1ValuesChartColor1, _4Wheels.RR_Y1ValuesChartColor1,
            _4Wheels.RR_X1ValuesChartColor2, _4Wheels.RR_Y1ValuesChartColor2,
            _4Wheels.RR_X1ValuesChartColor3, _4Wheels.RR_Y1ValuesChartColor3,
            _4Wheels.RR_X1ValuesChartColor4, _4Wheels.RR_Y1ValuesChartColor4,
            _4Wheels.RR_X1ValuesChartColor5, _4Wheels.RR_Y1ValuesChartColor5,
            _4Wheels.RR_X1ValuesChartColor6, _4Wheels.RR_Y1ValuesChartColor6,
            _4Wheels.RR_X1ValuesChartColor7, _4Wheels.RR_Y1ValuesChartColor7,
            _4Wheels.RR_X1ValuesChartColor8, _4Wheels.RR_Y1ValuesChartColor8,
            _4Wheels.RR_X1ValuesChartColor9, _4Wheels.RR_Y1ValuesChartColor9,
            _4Wheels.RR_X1ValuesChartColor10, _4Wheels.RR_Y1ValuesChartColor10);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonLabelVisibilities();
            //timer2.Interval = timer1.Interval * _4WheelsSettings.HistoryAmountPoints;

            if (LiveData.elapsedTime > 0 && PauseUpdate == false)
            {
                float[] xyzValuesFL = FL_XYZValues();
                float[] xyzValuesFR = FR_XYZValues();
                float[] xyzValuesRL = RL_XYZValues();
                float[] xyzValuesRR = RR_XYZValues();

                if (_4WheelsSettings.WheelChartsSelect == "Separate")
                {
                    ListSeriesFL(chart1, xyzValuesFL[0], xyzValuesFL[1], xyzValuesFL[2]);
                    ListSeriesFR(chart1, xyzValuesFR[0], xyzValuesFR[1], xyzValuesFR[2]);
                    ListSeriesRL(chart1, xyzValuesRL[0], xyzValuesRL[1], xyzValuesRL[2]);
                    ListSeriesRR(chart1, xyzValuesRR[0], xyzValuesRR[1], xyzValuesRR[2]);
                }
                if (_4WheelsSettings.WheelChartsSelect == "Front/Rear")
                {
                    ListSeriesFL(chart1, xyzValuesFL[0], xyzValuesFL[1], xyzValuesFL[2]);
                    ListSeriesFR(chart1, xyzValuesFR[0], xyzValuesFR[1], xyzValuesFR[2]);
                    ListSeriesRL(chart1, xyzValuesRL[0], xyzValuesRL[1], xyzValuesRL[2]);
                    ListSeriesRR(chart1, xyzValuesRR[0], xyzValuesRR[1], xyzValuesRR[2]);
                }
                if (_4WheelsSettings.WheelChartsSelect == "All In One")
                {
                    ListSeriesAllWheels(chart1, xyzValuesFL[0], xyzValuesFL[1], xyzValuesFL[2], xyzValuesFR[0], xyzValuesFR[1], xyzValuesFR[2], xyzValuesRL[0], xyzValuesRL[1], xyzValuesRL[2], xyzValuesRR[0], xyzValuesRR[1], xyzValuesRR[2]);
                }
            }
        }
        private void Form4Wheels_SizeChanged(object sender, EventArgs e)
        {
            /*
            //16 + 440 + 110;
            int formBorders = 16;
            double sizeWithoutFormBorders = this.Size.Width - formBorders;
            double chart1Multi = 4;
            double chart2Multi = 1;
            double chart1Plu2Multi = chart1Multi + chart2Multi;
            double asd = sizeWithoutFormBorders / chart1Plu2Multi;
            int newHeightWidthChart1 = Convert.ToInt32(asd * chart1Multi);
            int newWidthChart2 = Convert.ToInt32(asd * chart2Multi);

            chart1.Size = new Size(newHeightWidthChart1, newHeightWidthChart1);
            chart2.Size = new Size(newHeightWidthChart1, newHeightWidthChart1);
            chart3.Size = new Size(newHeightWidthChart1, newHeightWidthChart1);
            chart4.Size = new Size(newHeightWidthChart1, newHeightWidthChart1);
            //chart2.Location = new Point(0, 0);
            //chart2.Size = new Size(newWidthChart2, newHeightWidthChart1);
            //chart2.Location = new Point(newHeightWidthChart1, 0);
            */
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (LiveData.elapsedTime > 0)
            {
                //_4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesFL);
                //_4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesFR);
                //_4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesRL);
                //_4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesRR);
                /*if(_4WheelsSettings.WheelChartsSelect == "Separate")
                {
                    _4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesFL);
                    _4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesFR);
                    _4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesRL);
                    _4Wheels.InfiniteHistoryChart(chart1, _4Wheels.seriesRR);
                }
                if(_4WheelsSettings.WheelChartsSelect == "All In One")
                {
                    _4Wheels.InfiniteHistoryChartAllWheels(chart1, _4Wheels.seriesFL, _4Wheels.seriesFR, _4Wheels.seriesRL, _4Wheels.seriesRR);
                }*/
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toSettingsButton.Visible = false;
            _4WheelsSettings.SettingsOpen = true;
            Form4WheelsSettings s1 = new Form4WheelsSettings();
            s1.Show();
        }
        private void refreshAndApplyButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //timer2.Enabled = false;
            _4Wheels.ClearSeriesHistory(chart1);
            _4Wheels.SetArrays();
            _4Wheels.SetUpDownChart(GradientChart);

            if (PauseUpdate == false)
            {
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if(PauseUpdate == false)
            {
                PauseUpdate = true;
                buttonPause.Text = "Continue Update";
            }
            else
            {
                PauseUpdate = false;
                buttonPause.Text = "Pause Update";
            }
        }
    }
}
