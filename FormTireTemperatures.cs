using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Collections.Generic;

namespace Physics_Data_Debug
{
    public partial class FormTireTemperatures : Form
    {
        #region Fields variables
        //private readonly Thread update;
        private bool updatedEnabled;
        #endregion

        public FormTireTemperatures()
        {
            InitializeComponent();
            timer1.Interval = 94;
            updatedEnabled = false;
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
        private int historyPoints = 101;
        private void TemperatureSeries(Chart chartName, string seriesName, double dataY, TextBox txtBox, List<double> yValues)
        {
            yValues.Add(dataY);
            if (yValues.Count > historyPoints)
            {
                    yValues.RemoveAt(0);
            }
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = racetime;
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = racetime - (historyPoints - 1)/10;
            chartName.Series[seriesName].Points.DataBindXY(XValues, yValues);
            double roundedDataY = Math.Round(dataY, 2);
            txtBox.Text = roundedDataY.ToString();
        }
        private void SetChart(Chart chartName)
        {
            chartName.Series["Tread °C"].ChartType = SeriesChartType.FastLine;
            chartName.Series["Inner °C"].ChartType = SeriesChartType.FastLine;
            chartName.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F" + 0;// decimals
        }
        #endregion

        #region Form buttons etc
        private void TireTemperatures_Load(object sender, EventArgs e)
        {
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
            updatedEnabled = false;

        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            if (updatedEnabled == false)
            {
                updatedEnabled = true;
                timer1.Enabled = true;
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (updatedEnabled == true)
            {
                updatedEnabled = false;
                timer1.Enabled = false;
            }
        }
        private double RaceTimeToSeconds(int raceTime)
        {
            return Convert.ToDouble(raceTime)/1000;
        }
        private double racetime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.elapsedTime > 0 && updatedEnabled == true)
            {
                double raceTime = RaceTimeToSeconds(LiveData.RaceTime);
                racetime = raceTime;
                if (XValues.Contains<double>(racetime) == false)
                {
                    XValues.Add(racetime);
                    if (XValues.Count > historyPoints)
                    {
                        XValues.RemoveAt(0);
                    }
                    TemperatureSeries(chartFL, "Tread °C", LiveData.FL_TreadTemperature, textBox_FL_TreadTemperature, FL_TreadYValues);
                    TemperatureSeries(chartFL, "Inner °C", LiveData.FL_InnerTemperature, textBox_FL_InnerTemperature, FL_InnerYValues);
                    TemperatureSeries(chartFR, "Tread °C", LiveData.FR_TreadTemperature, textBox_FR_TreadTemperature, FR_TreadYValues);
                    TemperatureSeries(chartFR, "Inner °C", LiveData.FR_InnerTemperature, textBox_FR_InnerTemperature, FR_InnerYValues);
                    TemperatureSeries(chartRL, "Tread °C", LiveData.RL_TreadTemperature, textBox_RL_TreadTemperature, RL_TreadYValues);
                    TemperatureSeries(chartRL, "Inner °C", LiveData.RL_InnerTemperature, textBox_RL_InnerTemperature, RL_InnerYValues);
                    TemperatureSeries(chartRR, "Tread °C", LiveData.RR_TreadTemperature, textBox_RR_TreadTemperature, RR_TreadYValues);
                    TemperatureSeries(chartRR, "Inner °C", LiveData.RR_InnerTemperature, textBox_RR_InnerTemperature, RR_InnerYValues);
                }
            }
        }
        #endregion
    }
}
