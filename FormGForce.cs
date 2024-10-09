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
    public partial class FormGForce : Form
    {
        private readonly RectangleF[] rectfGArray = new RectangleF[100];

        public static int GScale = 25;

        private static int xy = 197;
        private float xzG = xy;
        public FormGForce()
        {
            InitializeComponent();
            timer1.Interval = 100;
            //panel3.Paint += new PaintEventHandler(panel3_Paint);
            //panel4.Paint += new PaintEventHandler(panel4_Paint);
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel2.Paint += new PaintEventHandler(panel2_Paint);
        }

        private void FormGForce_Load(object sender, EventArgs e)
        {
            LiveData.GForceOpen = true;
            //panel3.Refresh();
            //panel4.Refresh();
            //Label Locations
            float heightG0 = 2;
            float yG0 = (panel2.Size.Height / 2 - heightG0 / 2);
            G0.Location = new Point(0, Convert.ToInt32(yG0) - 7);
            float heightG1 = GScale * 2;
            float yG1 = (panel2.Size.Height / 2 - heightG1 / 2);
            float yG1b = (panel2.Size.Height / 2 + heightG1 / 2);
            G1.Location = new Point(0, Convert.ToInt32(yG1) - 7);
            G1m.Location = new Point(0, Convert.ToInt32(yG1b) - 7);
            float heightG2 = heightG1 * 2;
            float yG2 = (panel2.Size.Height / 2 - heightG2 / 2);
            float yG2b = (panel2.Size.Height / 2 + heightG2 / 2);
            G2.Location = new Point(0, Convert.ToInt32(yG2) - 7);
            G2m.Location = new Point(0, Convert.ToInt32(yG2b) - 7);
            float heightG3 = heightG1 * 3;
            float yG3 = (panel2.Size.Height / 2 - heightG3 / 2);
            float yG3b = (panel2.Size.Height / 2 + heightG3 / 2);
            G3.Location = new Point(0, Convert.ToInt32(yG3) - 7);
            G3m.Location = new Point(0, Convert.ToInt32(yG3b) - 7);
            float heightG4 = heightG1 * 4;
            float yG4 = (panel2.Size.Height / 2 - heightG4 / 2);
            float yG4b = (panel2.Size.Height / 2 + heightG4 / 2);
            G4.Location = new Point(0, Convert.ToInt32(yG4) - 7);
            G4m.Location = new Point(0, Convert.ToInt32(yG4b) - 7);
            float heightG5 = heightG1 * 5;
            float yG5 = (panel2.Size.Height / 2 - heightG5 / 2);
            float yG5b = (panel2.Size.Height / 2 + heightG5 / 2);
            G5.Location = new Point(0, Convert.ToInt32(yG5) - 7);
            G5m.Location = new Point(0, Convert.ToInt32(yG5b) - 7);
            float heightG6 = heightG1 * 6;
            float yG6 = (panel2.Size.Height / 2 - heightG6 / 2);
            float yG6b = (panel2.Size.Height / 2 + heightG6 / 2);
            G6.Location = new Point(0, Convert.ToInt32(yG6) - 7);
            G6m.Location = new Point(0, Convert.ToInt32(yG6b) - 7);
            float heightG7 = heightG1 * 7;
            float yG7 = (panel2.Size.Height / 2 - heightG7 / 2);
            float yG7b = (panel2.Size.Height / 2 + heightG7 / 2);
            G7.Location = new Point(0, Convert.ToInt32(yG7) - 7);
            G7m.Location = new Point(0, Convert.ToInt32(yG7b) - 7);
        }
        private void pictureBoxMove()
        {
            int x = xy;
            int y = xy;
            int x2 = 192;
            int y2 = 208;
            int x3 = 60;
            int y3 = 208;

            /*
            if(LiveData.XZGAngleDeg <= 90d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }
            else if(LiveData.XZGAngleDeg <= 180d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }
            else if (LiveData.XZGAngleDeg <= 270d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }
            else if (LiveData.XZGAngleDeg <= 360d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }*/
            if ((LiveData.XZG >= -0.001 && LiveData.XZG <= 0.001) || LiveData.XZG == double.NaN)
            {
                x = xy;
                y = xy;
                x2 = 192;
                y2 = 208;
            }
            else
            {
                x = xy + Convert.ToInt32(Math.Round(LiveData.XGRotated * GScale, 0));
                y = xy - Convert.ToInt32(Math.Round(LiveData.ZGRotated * GScale, 0));
                x2 = 192 + Convert.ToInt32(Math.Round(LiveData.XGRotated * GScale, 0));
                y2 = 208 - Convert.ToInt32(Math.Round(LiveData.ZGRotated * GScale, 0));
            }
            y3 = 193 - Convert.ToInt32(Math.Round(LiveData.YG * GScale, 0));

            //pictureBox1.Location = new Point(x, y);
            CurrentGForceXZMoving.Location = new Point(x2, y2);
            CurrentGForceXZMoving.Text = Math.Round(LiveData.XZG, 2).ToString() + " G";
            //textBox7.Text = "x: " + x.ToString() +"\r\n" + "y: " + y.ToString();
            CurrentGForceYMoving.Location = new Point(x3, y3);
            CurrentGForceYMoving.Text = Math.Round(Math.Abs(LiveData.YGRotated), 2).ToString() + " G";
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            float xG = xzG;
            float zG = xzG;
            Color gColor = Color.White;
            Pen myPenG = new Pen(gColor, 1);
            Brush brush = new SolidBrush(gColor);
            float widthG = 6;
            float heightG = 6;

            if ((LiveData.XZG >= -0.001 && LiveData.XZG <= 0.001) || LiveData.XZG == double.NaN)
            {
                xG = xzG;
                zG = xzG;
            }
            else
            {
                xG = xzG + Convert.ToSingle(LiveData.XGRotated * GScale);
                zG = xzG - Convert.ToSingle(LiveData.ZGRotated * GScale);
            }
            // Array of points before the current one
            // Too slow to be used well like this. Lags the page. Need to later see what's better way.
            /*
            Color gArrayColor = Color.DarkGray;
            Pen myPenGArray = new Pen(gArrayColor, 1);
            Brush brushArray = new SolidBrush(gArrayColor);
            float widthGArray = 2;
            float heightGArray = 2;
            RectangleF rectfGSmall = new RectangleF(xG+2, zG+2, widthGArray, heightGArray);
            rectfGArray[rectfGArray.Length - 1] = rectfGSmall;
            Array.Copy(rectfGArray, 1, rectfGArray, 0, rectfGArray.Length - 1);
            for (int i = 0; i < rectfGArray.Length - 1; ++i)
            {
                //temperaturesFL.Series["Tread °C"].Points.AddY(flsTempArray[i]);
                e.Graphics.DrawEllipse(myPenGArray, rectfGArray[i]);
                e.Graphics.FillEllipse(brushArray, rectfGArray[i]);
            }
            */
            // The current point
            RectangleF rectfG = new RectangleF(xG, zG, widthG, heightG);
            e.Graphics.DrawEllipse(myPenG, rectfG);
            e.Graphics.FillEllipse(brush, rectfG);
            //textBox7.Text = "x: " + xG.ToString() + "\r\n" + "y: " + zG.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // YG location
            float x1 = 12f;
            float x2 = 55f;
            float yG = 199f;
            Color gColor = Color.Gray;
            Pen myPenG = new Pen(gColor, 3);
            Brush brush = new SolidBrush(gColor);

            yG = 199f - Convert.ToSingle(LiveData.YGRotated * GScale);
            e.Graphics.DrawLine(myPenG, x1, yG, x2, yG);
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
            pictureBoxMove();
            panel1.Refresh();
            panel2.Refresh();
        }


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
    }
}
