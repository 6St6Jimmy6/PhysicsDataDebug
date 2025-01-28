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
            timer2.Interval = timer1.Interval * _4WheelsSettings.FL_HistoryAmountPoints;
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
            timer2.Interval = timer1.Interval * _4WheelsSettings.FL_HistoryAmountPoints;

            if (LiveData.elapsedTime > 0)
            {
                _4Wheels.PlotFLChart(chart1);
                _4Wheels.PlotFRChart(chart2);
                _4Wheels.PlotRLChart(chart3);
                _4Wheels.PlotRRChart(chart4);
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
                _4Wheels.InfiniteHistoryFLChart(chart1);
                _4Wheels.InfiniteHistoryFRChart(chart2);
                _4Wheels.InfiniteHistoryRLChart(chart3);
                _4Wheels.InfiniteHistoryRRChart(chart4);
            }
        }

        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toSettingsButton.Visible = false;
            _4WheelsSettings.SettingsOpen = true;
            Form4WheelsSettings s1 = new Form4WheelsSettings();
            s1.Show();
        }
        #region ignore old drawing
        /*
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Pen myPenWhite = new Pen(Color.White, 1);
            Pen myPenLightBlue = new Pen(Color.LightBlue, 1);
            Pen myPenBlue = new Pen(Color.Blue, 1);
            Pen myPenYellow = new Pen(Color.Yellow, 1);
            Pen myPenOrange = new Pen(Color.Orange, 1);
            Pen myPenOrangeRed = new Pen(Color.OrangeRed, 1);
            Pen myPenRed = new Pen(Color.Red, 1);
            Pen myPenDarkRed = new Pen(Color.DarkRed, 1);


            // 0 G circle
            float widthG0 = 2;
            float heightG0 = 2;
            float xG0 = (panel1.Size.Width / 2 - widthG0 / 2);
            float zG0 = (panel1.Size.Height / 2 - heightG0 / 2);
            RectangleF rectfG0 = new RectangleF(xG0, zG0, widthG0, heightG0);
            e.Graphics.DrawEllipse(myPenWhite, rectfG0);
            // 1 G circle
            float widthG1 = GScale * 2;
            float heightG1 = GScale * 2;
            float xG1 = (panel1.Size.Width / 2 - widthG1 / 2);
            float zG1 = (panel1.Size.Height / 2 - heightG1 / 2);
            RectangleF rectfG1 = new RectangleF(xG1, zG1, widthG1, heightG1);
            e.Graphics.DrawEllipse(myPenLightBlue, rectfG1);
            // 2 G circle
            float widthG2 = widthG1 * 2;
            float heightG2 = heightG1 * 2;
            float xG2 = (panel1.Size.Width / 2 - widthG2 / 2);
            float zG2 = (panel1.Size.Height / 2 - heightG2 / 2);
            RectangleF rectfG2 = new RectangleF(xG2, zG2, widthG2, heightG2);
            e.Graphics.DrawEllipse(myPenBlue, rectfG2);
            // 3 G circle
            float widthG3 = widthG1 * 3;
            float heightG3 = heightG1 * 3;
            float xG3 = (panel1.Size.Width / 2 - widthG3 / 2);
            float zG3 = (panel1.Size.Height / 2 - heightG3 / 2);
            RectangleF rectfG3 = new RectangleF(xG3, zG3, widthG3, heightG3);
            e.Graphics.DrawEllipse(myPenYellow, rectfG3);
            // 4 G circle
            float widthG4 = widthG1 * 4;
            float heightG4 = heightG1 * 4;
            float xG4 = (panel1.Size.Width / 2 - widthG4 / 2);
            float zG4 = (panel1.Size.Height / 2 - heightG4 / 2);
            RectangleF rectfG4 = new RectangleF(xG4, zG4, widthG4, heightG4);
            e.Graphics.DrawEllipse(myPenOrange, rectfG4);
            // 5 G circle
            float widthG5 = widthG1 * 5;
            float heightG5 = heightG1 * 5;
            float xG5 = (panel1.Size.Width / 2 - widthG5 / 2);
            float zG5 = (panel1.Size.Height / 2 - heightG5 / 2);
            RectangleF rectfG5 = new RectangleF(xG5, zG5, widthG5, heightG5);
            e.Graphics.DrawEllipse(myPenOrangeRed, rectfG5);
            // 6 G circle
            float widthG6 = widthG1 * 6;
            float heightG6 = heightG1 * 6;
            float xG6 = (panel1.Size.Width / 2 - widthG6 / 2);
            float zG6 = (panel1.Size.Height / 2 - heightG6 / 2);
            RectangleF rectfG6 = new RectangleF(xG6, zG6, widthG6, heightG6);
            e.Graphics.DrawEllipse(myPenRed, rectfG6);
            // 7 G circle
            float widthG7 = widthG1 * 7;
            float heightG7 = heightG1 * 7;
            float xG7 = (panel1.Size.Width / 2 - widthG7 / 2);
            float zG7 = (panel1.Size.Height / 2 - heightG7 / 2);
            RectangleF rectfG7 = new RectangleF(xG7, zG7, widthG7, heightG7);
            e.Graphics.DrawEllipse(myPenDarkRed, rectfG7);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Pen myPenWhite = new Pen(Color.White, 3);
            Pen myPenLightBlue = new Pen(Color.LightBlue, 3);
            Pen myPenBlue = new Pen(Color.Blue, 3);
            Pen myPenYellow = new Pen(Color.Yellow, 3);
            Pen myPenOrange = new Pen(Color.Orange, 3);
            Pen myPenOrangeRed = new Pen(Color.OrangeRed, 3);
            Pen myPenRed = new Pen(Color.Red, 3);
            Pen myPenDarkRed = new Pen(Color.DarkRed, 3);


            // 0 G Line
            float xStart = 12;
            float xEnd = (50);
            float heightG0 = 2;
            float yG0 = (panel2.Size.Height / 2 - heightG0 / 2);
            e.Graphics.DrawLine(myPenWhite, xStart, yG0, xEnd, yG0);
            // 1 G Line
            float heightG1 = GScale * 2;
            float yG1 = (panel2.Size.Height / 2 - heightG1 / 2);
            float yG1b = (panel2.Size.Height / 2 + heightG1 / 2);
            e.Graphics.DrawLine(myPenLightBlue, xStart, yG1, xEnd, yG1);
            e.Graphics.DrawLine(myPenLightBlue, xStart, yG1b, xEnd, yG1b);
            // 2 G Line
            float heightG2 = heightG1 * 2;
            float yG2 = (panel2.Size.Height / 2 - heightG2 / 2);
            float yG2b = (panel2.Size.Height / 2 + heightG2 / 2);
            e.Graphics.DrawLine(myPenBlue, xStart, yG2, xEnd, yG2);
            e.Graphics.DrawLine(myPenBlue, xStart, yG2b, xEnd, yG2b);
            // 3 G Line
            float heightG3 = heightG1 * 3;
            float yG3 = (panel2.Size.Height / 2 - heightG3 / 2);
            float yG3b = (panel2.Size.Height / 2 + heightG3 / 2);
            e.Graphics.DrawLine(myPenYellow, xStart, yG3, xEnd, yG3);
            e.Graphics.DrawLine(myPenYellow, xStart, yG3b, xEnd, yG3b);
            // 4 G Line
            float heightG4 = heightG1 * 4;
            float yG4 = (panel2.Size.Height / 2 - heightG4 / 2);
            float yG4b = (panel2.Size.Height / 2 + heightG4 / 2);
            e.Graphics.DrawLine(myPenOrange, xStart, yG4, xEnd, yG4);
            e.Graphics.DrawLine(myPenOrange, xStart, yG4b, xEnd, yG4b);
            // 5 G Line
            float heightG5 = heightG1 * 5;
            float yG5 = (panel2.Size.Height / 2 - heightG5 / 2);
            float yG5b = (panel2.Size.Height / 2 + heightG5 / 2);
            e.Graphics.DrawLine(myPenOrangeRed, xStart, yG5, xEnd, yG5);
            e.Graphics.DrawLine(myPenOrangeRed, xStart, yG5b, xEnd, yG5b);
            // 6 G Line
            float heightG6 = heightG1 * 6;
            float yG6 = (panel2.Size.Height / 2 - heightG6 / 2);
            float yG6b = (panel2.Size.Height / 2 + heightG6 / 2);
            e.Graphics.DrawLine(myPenRed, xStart, yG6, xEnd, yG6);
            e.Graphics.DrawLine(myPenRed, xStart, yG6b, xEnd, yG6b);
            // 7 G Line
            float heightG7 = heightG1 * 7;
            float yG7 = (panel2.Size.Height / 2 - heightG7 / 2);
            float yG7b = (panel2.Size.Height / 2 + heightG7 / 2);
            e.Graphics.DrawLine(myPenDarkRed, xStart, yG7, xEnd, yG7);
            e.Graphics.DrawLine(myPenDarkRed, xStart, yG7b, xEnd, yG7b);
        }
        */
        #endregion

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
                timer1.Stop();
                timer2.Stop();
                PauseUpdate = true;
                buttonPause.Text = "Continue Update";
            }
            else
            {
                timer1.Start();
                timer2.Start();
                PauseUpdate = false;
                buttonPause.Text = "Pause Update";
            }
        }
    }
}
