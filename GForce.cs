using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public class GForce
    {
        private readonly static int historyalpha = 255;
        private readonly static int historycolordivider = 2;
        private readonly static int steps = 10;

        private static double[] X1ValuesPolarChartArray = new double[GForceSettings.HistoryAmountPoints];
        private static double[] Y1ValuesPolarChartArray = new double[GForceSettings.HistoryAmountPoints];
        private static double[] X1ValuesChart2Array = new double[2];
        private static double[] Y1ValuesChart2Array = new double[2];

        private static int u = 2;

        public static void SetArrays()
        {
            X1ValuesPolarChartArray = new double[GForceSettings.HistoryAmountPoints];
            Y1ValuesPolarChartArray = new double[GForceSettings.HistoryAmountPoints];
            X1ValuesChart2Array = new double[2];
            Y1ValuesChart2Array = new double[2];

        }
        public static void ClearSeriesHistory(Chart chartName)
        {
            while (chartName.Series.Count > 1) { chartName.Series.RemoveAt(0); }
        }
        public static void SetPolarChart(Chart chartName)
        {
            double interval = GForceSettings.Y1Max / steps;
            chartName.Series["Series1"].ChartType = SeriesChartType.Polar;
            chartName.ChartAreas["ChartArea1"].BackColor = GForceSettings.BackgroundColor;

            // X Axis
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = GForceSettings.X1Min;
            if (GForceSettings.X1AngleType == "Degrees")
            {
                chartName.ChartAreas["ChartArea1"].AxisX.Maximum = GForceSettings.X1MaxDegrees;
                chartName.ChartAreas["ChartArea1"].AxisX.Interval = chartName.ChartAreas["ChartArea1"].AxisX.Maximum / GForceSettings.X1MajorIntervalFraction;
                chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = GForceSettings.X1MaxDegrees / GForceSettings.X1MajorIntervalFraction;
                chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F0";// 0 decimal major grid ladels
            }
            else//radians
            {
                chartName.ChartAreas["ChartArea1"].AxisX.Maximum = GForceSettings.X1MaxDegrees * (Math.PI / 180);
                chartName.ChartAreas["ChartArea1"].AxisX.Interval = chartName.ChartAreas["ChartArea1"].AxisX.Maximum / GForceSettings.X1MajorIntervalFraction;
                chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = chartName.ChartAreas["ChartArea1"].AxisX.Maximum / GForceSettings.X1MajorIntervalFraction;
                chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F2";// 2 decimal major grid ladels
            }

            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(GForceSettings.X1FontFamily, GForceSettings.X1FontSize, GForceSettings.X1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = GForceSettings.X1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = GForceSettings.X1MajorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = GForceSettings.X1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Transparent;// Need to do this for this specific line, because it's over the X axis lines.

            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = GForceSettings.X1MinorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = GForceSettings.X1MinorDashStyle;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineWidth = GForceSettings.X1MinorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = chartName.ChartAreas["ChartArea1"].AxisX.Interval / GForceSettings.X1MinorIntervalFraction;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = GForceSettings.X1MinorColor;

            // Y Axis
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = GForceSettings.Y1Min;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = GForceSettings.Y1Max;

            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font(GForceSettings.Y1FontFamily, GForceSettings.Y1FontSize, GForceSettings.Y1FontStyle);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = GForceSettings.Y1FontColor;

            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = GForceSettings.Y1MajorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "F" + GForceSettings.Y1MajorDecimals;// decimals
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = GForceSettings.Y1MajorColor;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = interval * GForceSettings.Y1IntervalDivider; // TickMark Interval
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = interval * GForceSettings.Y1IntervalDivider; // Major Grid Interval
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Interval = interval * GForceSettings.Y1IntervalDivider; // Major Grid Label Interval
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.IntervalOffset = 0;

            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = GForceSettings.Y1MinorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = GForceSettings.Y1MinorDashStyle;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineWidth = GForceSettings.Y1MinorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chartName.ChartAreas["ChartArea1"].AxisY.Interval/GForceSettings.Y1MinorIntervalFraction;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = GForceSettings.Y1MinorColor;


            // Series marker stuff
            chartName.Series["Series1"].MarkerSize = 5;
            chartName.Series["Series1"].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
            chartName.Series["Series1"].SmartLabelStyle.Enabled = false;
            chartName.Series["Series1"].LabelBackColor = chartName.ChartAreas["ChartArea1"].BackColor;
        }
        public static void PlotPolarChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();

            if (GForceSettings.X1AngleType == "Degrees")
            {
                X1ValuesPolarChartArray[X1ValuesPolarChartArray.Length - 1] = LiveData.GetFullListDataValue(WF_Prefix.Body, WF_BodyAccelDataOffset.Body_XZGAngleDeg);
            }
            else//radians
            {
                X1ValuesPolarChartArray[X1ValuesPolarChartArray.Length - 1] = LiveData.GetFullListDataValue(WF_Prefix.Body, WF_BodyAccelDataOffset.XZGAngleRad);
            }
            Y1ValuesPolarChartArray[Y1ValuesPolarChartArray.Length - 1] = Math.Round(LiveData.GetFullListDataValue(WF_Prefix.Body, WF_BodyAccelDataOffset.XZG), 2);

            Array.Copy(X1ValuesPolarChartArray, 1, X1ValuesPolarChartArray, 0, X1ValuesPolarChartArray.Length - 1);
            Array.Copy(Y1ValuesPolarChartArray, 1, Y1ValuesPolarChartArray, 0, Y1ValuesPolarChartArray.Length - 1);

            ForLoopAxisArrays(chartName, 1, X1ValuesPolarChartArray, Y1ValuesPolarChartArray);
            chartName.Series["Series1"].Points.Last().MarkerSize = 10;
            chartName.Series["Series1"].Points.Last().MarkerColor = GForceSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = true;
        }
        private static void ForLoopAxisArrays(Chart chartName, int u, double[] arrayX, double[] arrayY)
        {
            for (int i = 0; i < arrayX.Length - 1; ++i)
            {
                chartName.Series["Series" + u.ToString()].Points.AddXY(arrayX[i], arrayY[i]);
                ColorGradient(chartName, Math.Abs(arrayY[i]), i, u);
            }
        }
        private static void ColorGradient(Chart chartName, double array, int i, int u)
        {
            double minus = (GForceSettings.Y1Max - GForceSettings.Y1Min) / steps;
            double ten = GForceSettings.Y1Max;
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

            if (GForceSettings.Scheme == "Colorblind")
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
            else if (GForceSettings.Scheme == "Green Red")
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
        public static void InfiniteHistoryPolarChart(Chart chartName)
        {
            if (GForceSettings.InfiniteHistoryEnabled == true)
            {
                chartName.Series.Insert(0, new Series("Series" + u.ToString()));
                chartName.Series["Series" + u].ChartType = SeriesChartType.Polar;
                chartName.Series["Series" + u.ToString()].Color = Color.Transparent;
                chartName.Series["Series" + u.ToString()].MarkerStyle = MarkerStyle.Circle;
                chartName.Series["Series" + u.ToString()].MarkerSize = 5;
                chartName.Series["Series" + u.ToString()].MarkerColor = Color.FromArgb(historyalpha, 128, 0, 0);
                chartName.Series["Series" + u.ToString()].IsValueShownAsLabel = false;
                chartName.Series["Series" + u.ToString()].SmartLabelStyle.Enabled = false;
                chartName.Series["Series" + u.ToString()].LabelBackColor = Color.Black;
                ForLoopAxisArrays(chartName, u, X1ValuesPolarChartArray, Y1ValuesPolarChartArray);
                u++;
            }
        }
        private static void UpDownPolarChartGradient(Chart chartName, double interval)
        {
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

            if (GForceSettings.Scheme == "Colorblind")
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
            else if (GForceSettings.Scheme == "Green Red")
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
            for (double i = -GForceSettings.Y1Max * steps; i <= GForceSettings.Y1Max * steps; i += GForceSettings.Y1Max)
            {

                StripLine sl = new StripLine();
                if (Math.Abs(i) == GForceSettings.Y1Max * 10)
                {
                    sl.BackColor = color10;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 9)
                {
                    sl.BackColor = color9;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 8)
                {
                    sl.BackColor = color8;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 7)
                {
                    sl.BackColor = color7;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 6)
                {
                    sl.BackColor = color6;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 5)
                {
                    sl.BackColor = color5;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 4)
                {
                    sl.BackColor = color4;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 3)
                {
                    sl.BackColor = color3;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 2)
                {
                    sl.BackColor = color2;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 1)
                {
                    sl.BackColor = color1;
                }
                if (Math.Abs(i) == GForceSettings.Y1Max * 0)
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
        public static void SetUpDownChart(Chart chartName)
        {
            double interval = GForceSettings.Y1Max / steps;
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = 1;
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = -GForceSettings.Y1Max;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = GForceSettings.Y1Max;
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = interval;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = interval;
            chartName.Series["Series1"].Color = Color.Red;
            chartName.Series["Series1"].LabelBackColor = Color.Black;

            chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Clear();
            UpDownPolarChartGradient(chartName, interval);
        }
        public static void PlotUpDownChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();
            chartName.Series["Series1"].Color = GForceSettings.MarkerColor;
            X1ValuesChart2Array[0] = 0.3;
            X1ValuesChart2Array[1] = 0.7;
            List<double> X1ValuesChart2List = new List<double>(X1ValuesChart2Array);
            Y1ValuesChart2Array[0] = Math.Round(LiveData.GetFullListDataValue(WF_Prefix.Body, WF_BodyAccelDataOffset.YG), 2);
            Y1ValuesChart2Array[1] = Y1ValuesChart2Array[0];
            List<double> Y1ValuesChart2List = new List<double>(Y1ValuesChart2Array);
            chartName.Series["Series1"].Points.DataBindXY(X1ValuesChart2List, Y1ValuesChart2List);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = true;
        }
    }
}
