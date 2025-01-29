using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class Form4Wheels : Form
    {
        bool PauseUpdate;

        public Form4Wheels()
        {
            InitializeComponent();
            PauseUpdate = false;
            timer1.Interval = 100;
            timer2.Interval = timer1.Interval * _4WheelsSettings.HistoryAmountPoints;
            _4Wheels.SetChart(chart1);
            _4Wheels.SetChart(chart2);
            _4Wheels.SetChart(chart3);
            _4Wheels.SetChart(chart4);
            _4Wheels.SetUpDownChart(GradientChart);
        }
        private void ButtonVisibilities()
        {
            if (_4WheelsSettings.SettingsOpen == true)
            {
                toSettingsButton.Visible = false;
            }
            if (_4WheelsSettings.SettingsOpen == false)
            {
                toSettingsButton.Visible = true;
            }
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonVisibilities();
            timer2.Interval = timer1.Interval * _4WheelsSettings.HistoryAmountPoints;

            if (LiveData.elapsedTime > 0 && PauseUpdate == false)
            {
                _4Wheels.PlotChart(chart1, _4Wheels.FL_X1ValuesChartArray, _4Wheels.FL_Y1ValuesChartArray, _4Wheels.FL_Z1ValuesChartArray);
                _4Wheels.PlotChart(chart2, _4Wheels.FR_X1ValuesChartArray, _4Wheels.FR_Y1ValuesChartArray, _4Wheels.FR_Z1ValuesChartArray);
                _4Wheels.PlotChart(chart3, _4Wheels.RL_X1ValuesChartArray, _4Wheels.RL_Y1ValuesChartArray, _4Wheels.RL_Z1ValuesChartArray);
                _4Wheels.PlotChart(chart4, _4Wheels.RR_X1ValuesChartArray, _4Wheels.RR_Y1ValuesChartArray, _4Wheels.RR_Z1ValuesChartArray);
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
                _4Wheels.InfiniteHistoryChart(chart1, _4Wheels.FL_X1ValuesChartArray, _4Wheels.FL_Y1ValuesChartArray, _4Wheels.FL_Z1ValuesChartArray);
                _4Wheels.InfiniteHistoryChart(chart2, _4Wheels.FR_X1ValuesChartArray, _4Wheels.FR_Y1ValuesChartArray, _4Wheels.FR_Z1ValuesChartArray);
                _4Wheels.InfiniteHistoryChart(chart3, _4Wheels.RL_X1ValuesChartArray, _4Wheels.RL_Y1ValuesChartArray, _4Wheels.RL_Z1ValuesChartArray);
                _4Wheels.InfiniteHistoryChart(chart4, _4Wheels.RR_X1ValuesChartArray, _4Wheels.RR_Y1ValuesChartArray, _4Wheels.RR_Z1ValuesChartArray);
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
            timer2.Enabled = false;
            _4Wheels.ClearSeriesHistory(chart1);
            _4Wheels.ClearSeriesHistory(chart2);
            _4Wheels.ClearSeriesHistory(chart3);
            _4Wheels.ClearSeriesHistory(chart4);
            _4Wheels.SetArrays();
            _4Wheels.SetUpDownChart(GradientChart);

            if (PauseUpdate == false)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
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
