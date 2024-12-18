﻿using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Physics_Data_Debug
{
    public partial class FormTireTemperatures : Form
    {
        #region Fields variables
        //private readonly Thread update;
        private bool updatedStartedOnce = false;


        // How long array is.
        private readonly double[] flsTempArray = new double[300];
        private readonly double[] fliTempArray = new double[300];
        private readonly double[] frsTempArray = new double[300];
        private readonly double[] friTempArray = new double[300];
        private readonly double[] rlsTempArray = new double[300];
        private readonly double[] rliTempArray = new double[300];
        private readonly double[] rrsTempArray = new double[300];
        private readonly double[] rriTempArray = new double[300];
        #endregion

        public FormTireTemperatures()
        {
            InitializeComponent();
            timer1.Interval = 94;
            //update = new Thread(new ThreadStart(getData));
            //update.IsBackground = true;
        }

        #region Methods
        private void TemperatureSeries()
        {
            //temperaturesFL.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            //temperaturesFL.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            //temperaturesFL.ChartAreas["ChartArea1"].AxisX.Interval = 100;
            flsTempArray[flsTempArray.Length - 1] = Math.Round(LiveData.FL_TreadTemperature, 2);// Rounding values to 2 decimals
            fliTempArray[fliTempArray.Length - 1] = Math.Round(LiveData.FL_InnerTemperature, 2);
            frsTempArray[frsTempArray.Length - 1] = Math.Round(LiveData.FR_TreadTemperature, 2);
            friTempArray[friTempArray.Length - 1] = Math.Round(LiveData.FR_InnerTemperature, 2);
            rlsTempArray[rlsTempArray.Length - 1] = Math.Round(LiveData.RL_TreadTemperature, 2);
            rliTempArray[rliTempArray.Length - 1] = Math.Round(LiveData.RL_InnerTemperature, 2);
            rrsTempArray[rrsTempArray.Length - 1] = Math.Round(LiveData.RR_TreadTemperature, 2);
            rriTempArray[rriTempArray.Length - 1] = Math.Round(LiveData.RR_InnerTemperature, 2);

            Array.Copy(flsTempArray, 1, flsTempArray, 0, flsTempArray.Length - 1);
            Array.Copy(fliTempArray, 1, fliTempArray, 0, fliTempArray.Length - 1);
            Array.Copy(frsTempArray, 1, frsTempArray, 0, frsTempArray.Length - 1);
            Array.Copy(friTempArray, 1, friTempArray, 0, friTempArray.Length - 1);
            Array.Copy(rlsTempArray, 1, rlsTempArray, 0, rlsTempArray.Length - 1);
            Array.Copy(rliTempArray, 1, rliTempArray, 0, rliTempArray.Length - 1);
            Array.Copy(rrsTempArray, 1, rrsTempArray, 0, rrsTempArray.Length - 1);
            Array.Copy(rriTempArray, 1, rriTempArray, 0, rriTempArray.Length - 1);

            chartFL.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < flsTempArray.Length - 1; ++i)
            {
                chartFL.Series["Tread °C"].Points.AddY(flsTempArray[i]);
            }

            chartFL.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < fliTempArray.Length - 1; ++i)
            {
                chartFL.Series["Inner °C"].Points.AddY(fliTempArray[i]);
            }

            chartFR.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < frsTempArray.Length - 1; ++i)
            {
                chartFR.Series["Tread °C"].Points.AddY(frsTempArray[i]);
            }

            chartFR.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < friTempArray.Length - 1; ++i)
            {
                chartFR.Series["Inner °C"].Points.AddY(friTempArray[i]);
            }

            chartRL.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < rlsTempArray.Length - 1; ++i)
            {
                chartRL.Series["Tread °C"].Points.AddY(rlsTempArray[i]);
            }

            chartRL.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < rliTempArray.Length - 1; ++i)
            {
                chartRL.Series["Inner °C"].Points.AddY(rliTempArray[i]);
            }

            chartRR.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < rrsTempArray.Length - 1; ++i)
            {
                chartRR.Series["Tread °C"].Points.AddY(rrsTempArray[i]);
            }

            chartRR.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < rriTempArray.Length - 1; ++i)
            {
                chartRR.Series["Inner °C"].Points.AddY(rriTempArray[i]);
            }
            textBox_FL_TreadTemperature.Text = Math.Round(LiveData.FL_TreadTemperature, 2).ToString();
            textBox_FL_InnerTemperature.Text = Math.Round(LiveData.FL_InnerTemperature, 2).ToString();
            textBox_FR_TreadTemperature.Text = Math.Round(LiveData.FR_TreadTemperature, 2).ToString();
            textBox_FR_InnerTemperature.Text = Math.Round(LiveData.FR_InnerTemperature, 2).ToString();
            textBox_RL_TreadTemperature.Text = Math.Round(LiveData.RL_TreadTemperature, 2).ToString();
            textBox_RL_InnerTemperature.Text = Math.Round(LiveData.RL_InnerTemperature, 2).ToString();
            textBox_RR_TreadTemperature.Text = Math.Round(LiveData.RR_TreadTemperature, 2).ToString();
            textBox_RR_InnerTemperature.Text = Math.Round(LiveData.RR_InnerTemperature, 2).ToString();
        }
        private void XYSeries()
        {

        }
        #endregion

        #region Form buttons etc
        private void TireTemperatures_Load(object sender, EventArgs e)
        {
            LiveData.TemperaturesChartOpen = true;
            updatedStartedOnce = false;
            //update.Start();
        }
        private void TireTemperatures_FormClosing(object sender, FormClosingEventArgs e)
        {
            LiveData.TemperaturesChartOpen = false;
            if (updatedStartedOnce == true)
            {
                timer1.Enabled = false;
                //update.Suspend();
            }
            updatedStartedOnce = false;

        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            //First_All_Data_Logger_Page fadlp = new First_All_Data_Logger_Page();
            //fadlp.Show();
            this.Close();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            if (updatedStartedOnce == false)
            {
                timer1.Enabled = true;
                //update.Start();
                updatedStartedOnce = true;
            }
            else
            {
                //update.Resume();
            }

        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (updatedStartedOnce == true)
            {
                //update.Suspend();
            }
            timer1.Enabled = false;
            //update.Abort();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TemperatureSeries();
        }
        #endregion
    }
}
