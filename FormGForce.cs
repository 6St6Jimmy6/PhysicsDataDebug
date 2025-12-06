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
    public partial class FormGForce : Form
    {
        public FormGForce()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer2.Interval = timer1.Interval * GForceSettings.HistoryAmountPoints;
            GForce.SetPolarChart(chart1);
            GForce.SetUpDownChart(chart2);
        }
        private void ButtonVisibilities()
        {
            if (GForceSettings.SettingsOpen == true)
            {
                toSettingsButton.Visible = false;
            }
            if (GForceSettings.SettingsOpen == false)
            {
                toSettingsButton.Visible = true;
            }
        }
        private void FormGForce_Load(object sender, EventArgs e)
        {

            LiveData.GForceOpen = true;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormGForce_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiveData.GForceOpen = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonVisibilities();
            timer2.Interval = timer1.Interval * GForceSettings.HistoryAmountPoints;
            if (LiveData.ElapsedTime > 0)
            {
                GForce.PlotPolarChart(chart1);
                GForce.PlotUpDownChart(chart2);
            }
        }
        private void FormGForce_SizeChanged(object sender, EventArgs e)
        {
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
            chart2.Location = new Point(0, 0);
            chart2.Size = new Size(newWidthChart2, newHeightWidthChart1);
            chart2.Location = new Point(newHeightWidthChart1, 0);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (LiveData.ElapsedTime > 0)
            {
                GForce.InfiniteHistoryPolarChart(chart1);
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toSettingsButton.Visible = false;
            GForceSettings.SettingsOpen = true;
            FormGForceSettings s1 = new FormGForceSettings();
            s1.Show();
        }
        private void refreshAndApplyButton_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            timer2.Enabled = false;
            GForce.ClearSeriesHistory(chart1);
            GForce.SetArrays();

            timer1.Enabled = true;
            timer2.Enabled = true;
        }
    }
}
