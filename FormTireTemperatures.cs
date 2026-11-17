using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public partial class FormTireTemperatures : Form
    {
        public FormTireTemperatures()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Enabled = false;
        }

        #region Methods
        public List<double> XValues { get; set; } = new List<double>();
        public List<double> FL_TreadYValues { get; set; } = new List<double>();
        public List<double> FL_InnerYValues { get; set; } = new List<double>();
        public List<double> FR_TreadYValues { get; set; } = new List<double>();
        public List<double> FR_InnerYValues { get; set; } = new List<double>();
        public List<double> RL_TreadYValues { get; set; } = new List<double>();
        public List<double> RL_InnerYValues { get; set; } = new List<double>();
        public List<double> RR_TreadYValues { get; set; } = new List<double>();
        public List<double> RR_InnerYValues { get; set; } = new List<double>();
        private int historyPointsCorrect;
        private int historyPointsOverhead = 1;
        private int historyPoints = 500;
        private int historyPointsDivider = 10;

        private int intervalDivider = 5;
        private void TemperatureSeries(Chart chartName, string seriesName, double dataY, List<double> yValues)
        {
            yValues.Add(dataY);
            if (yValues.Count > historyPointsCorrect)
            {
                    yValues.RemoveAt(0);
            }
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = racetime;
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = racetime - (historyPoints) / historyPointsDivider;
            chartName.Series[seriesName].Points.DataBindXY(XValues, yValues);
            double roundedDataY = Math.Round(dataY, 2);
            chartName.Series["Tread °C"].LegendText = "Tread " + roundedDataY + "°C";
            chartName.Series["Inner °C"].LegendText = "Inner " + roundedDataY + "°C";
        }
        private void SetChart(Chart chartName)
        {
            string chartAreaName = "ChartArea1";
            chartName.ChartAreas[chartAreaName].BackColor = Form4WheelsSettings.BackgroundColor;

            // X Axis
            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.ForeColor = Form4WheelsSettings.X1FontColor;

            chartName.ChartAreas[chartAreaName].AxisX.TitleForeColor = Form4WheelsSettings.X1FontColor;

            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.LineColor = Form4WheelsSettings.X1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineColor = Form4WheelsSettings.X1MinorColor;

            // Y Axis
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.ForeColor = Form4WheelsSettings.Y1FontColor;

            chartName.ChartAreas[chartAreaName].AxisY.TitleForeColor = Form4WheelsSettings.Y1FontColor;

            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.LineColor = Form4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineColor = Form4WheelsSettings.Y1MinorColor;

            chartName.ChartAreas["ChartArea1"].Position.Height = 80;
            chartName.ChartAreas["ChartArea1"].Position.Width = 100;
            chartName.ChartAreas["ChartArea1"].Position.X = 0;
            chartName.ChartAreas["ChartArea1"].Position.Y = 5;
            chartName.Legends["Legend1"].Position.Height = 10;
            chartName.Legends["Legend1"].Position.Width = 80;
            chartName.Legends["Legend1"].Position.X = 10;
            chartName.Legends["Legend1"].Position.Y = 90;
            chartName.Legends["Legend1"].LegendStyle = LegendStyle.Row;
            chartName.Series.Clear();
            chartName.Series.Add("Tread °C");
            chartName.Series.Add("Inner °C");
            chartName.Series["Tread °C"].ChartType = SeriesChartType.FastLine;
            chartName.Series["Inner °C"].ChartType = SeriesChartType.FastLine;
            chartName.ChartAreas["ChartArea1"].AxisX.Interval = (historyPoints / (historyPoints / intervalDivider))/ historyPointsDivider;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = (historyPoints / (historyPoints / intervalDivider))/ historyPointsDivider;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F" + 0;// decimals
        }
        #endregion

        #region Form buttons etc
        private void TireTemperatures_Load(object sender, EventArgs e)
        {
            historyPointsCorrect = historyPoints + historyPointsOverhead;
            SetChart(chartFL);
            SetChart(chartFR);
            SetChart(chartRL);
            SetChart(chartRR);
            LiveData.TemperaturesChartOpen = true;
            //update.Start();
        }
        private void TireTemperatures_FormClosing(object sender, FormClosingEventArgs e)
        {
            LiveData.TemperaturesChartOpen = false;
            timer1.Enabled = false;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        private double RaceTimeToSeconds(int raceTime)
        {
            return raceTime / 1000.0;
        }
        private double racetime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.ElapsedTime > 0)
            {
                int raceTimeMilliseconds = (int)LiveData.GetFullListDataValue(
                    TelemetryPrefix.Timing, GameMemoryConfig.Field("WF_TimeDataOffset", "RaceTime"));
                double raceTime = RaceTimeToSeconds(raceTimeMilliseconds);
                racetime = raceTime;
                if (!XValues.Contains(racetime))
                {
                    XValues.Add(racetime);
                    if (XValues.Count > historyPointsCorrect)
                    {
                        XValues.RemoveAt(0);
                    }
                    TemperatureSeries(chartFL, "Tread °C", LiveData.GetFullListDataValue(TelemetryPrefix.FL, GameMemoryConfig.Field("WF_TireDataOffset", "TreadTemperature")), FL_TreadYValues);
                    TemperatureSeries(chartFL, "Inner °C", LiveData.GetFullListDataValue(TelemetryPrefix.FL, GameMemoryConfig.Field("WF_TireDataOffset", "InnerTemperature")), FL_InnerYValues);
                    TemperatureSeries(chartFR, "Tread °C", LiveData.GetFullListDataValue(TelemetryPrefix.FR, GameMemoryConfig.Field("WF_TireDataOffset", "TreadTemperature")), FR_TreadYValues);
                    TemperatureSeries(chartFR, "Inner °C", LiveData.GetFullListDataValue(TelemetryPrefix.FR, GameMemoryConfig.Field("WF_TireDataOffset", "InnerTemperature")), FR_InnerYValues);
                    TemperatureSeries(chartRL, "Tread °C", LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "TreadTemperature")), RL_TreadYValues);
                    TemperatureSeries(chartRL, "Inner °C", LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_TireDataOffset", "InnerTemperature")), RL_InnerYValues);
                    TemperatureSeries(chartRR, "Tread °C", LiveData.GetFullListDataValue(TelemetryPrefix.RR, GameMemoryConfig.Field("WF_TireDataOffset", "TreadTemperature")), RR_TreadYValues);
                    TemperatureSeries(chartRR, "Inner °C", LiveData.GetFullListDataValue(TelemetryPrefix.RR, GameMemoryConfig.Field("WF_TireDataOffset", "InnerTemperature")), RR_InnerYValues);
                }
            }
        }
        #endregion
    }
}
