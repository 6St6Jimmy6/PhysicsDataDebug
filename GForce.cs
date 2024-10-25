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

        private readonly static int alpha = 255;
        private readonly static int divider = 2;
        private readonly static int historyalpha = 255;
        private readonly static int historycolordivider = 2;
        private readonly static int steps = 10;


        private static double[] X1ValuesPolarChartArray = new double[GForceSettings.HistoryAmountPoints];
        private static double[] Y1ValuesPolarChartArray = new double[GForceSettings.HistoryAmountPoints];
        private static double[] X1ValuesChart2Array = new double[2];
        private static double[] Y1ValuesChart2Array = new double[2];


        private static int u = 2;

        private void HistoryPointsColorFromMarkerColor() // Not used
        {
            int a = GForceSettings.MarkerColor.A;
            int r = GForceSettings.MarkerColor.R;
            int g = GForceSettings.MarkerColor.G;
            int B = GForceSettings.MarkerColor.B;

        }

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

            //X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            //Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues()
            if (GForceSettings.X1AngleType == "Degrees")
            {
                X1ValuesPolarChartArray[X1ValuesPolarChartArray.Length - 1] = LiveData.XZGAngleDeg;
            }
            else//radians
            {
                X1ValuesPolarChartArray[X1ValuesPolarChartArray.Length - 1] = LiveData.XZGAngleRad;
            }
            Y1ValuesPolarChartArray[Y1ValuesPolarChartArray.Length - 1] = Math.Round(LiveData.XZG, 2);

            // Test for total friction values
            /*
            X1ValuesChart1Array[X1ValuesChart1Array.Length - 1] = LiveData.RL_TotalFrictionAngle;
            Y1ValuesChart1Array[Y1ValuesChart1Array.Length - 1] = Math.Round(LiveData.RL_TotalFriction, 2);
            */

            Array.Copy(X1ValuesPolarChartArray, 1, X1ValuesPolarChartArray, 0, X1ValuesPolarChartArray.Length - 1);
            Array.Copy(Y1ValuesPolarChartArray, 1, Y1ValuesPolarChartArray, 0, Y1ValuesPolarChartArray.Length - 1);

            if (GForceSettings.Scheme == "Green Red")
            {
                for (int i = 0; i < X1ValuesPolarChartArray.Length - 1; ++i)
                {
                    double minus = GForceSettings.Y1Max / steps;
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
                    chartName.Series["Series1"].Points.AddXY(X1ValuesPolarChartArray[i], Y1ValuesPolarChartArray[i]);
                    if (Y1ValuesPolarChartArray[i] >= ten)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < ten && Y1ValuesPolarChartArray[i] >= nine)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < nine && Y1ValuesPolarChartArray[i] >= eight)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < eight && Y1ValuesPolarChartArray[i] >= seven)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < seven && Y1ValuesPolarChartArray[i] >= six)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < six && Y1ValuesPolarChartArray[i] >= five)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < five && Y1ValuesPolarChartArray[i] >= four)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < four && Y1ValuesPolarChartArray[i] >= three)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < three && Y1ValuesPolarChartArray[i] >= two)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < two && Y1ValuesPolarChartArray[i] >= one)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < one && Y1ValuesPolarChartArray[i] >= zero)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                    }
                    else
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                    }
                }
            }
            else
            {
                for (int i = 0; i < X1ValuesPolarChartArray.Length - 1; ++i)
                {
                    double minus = GForceSettings.Y1Max / steps;
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
                    chartName.Series["Series1"].Points.AddXY(X1ValuesPolarChartArray[i], Y1ValuesPolarChartArray[i]);
                    if (Y1ValuesPolarChartArray[i] >= ten)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < ten && Y1ValuesPolarChartArray[i] >= nine)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < nine && Y1ValuesPolarChartArray[i] >= eight)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < eight && Y1ValuesPolarChartArray[i] >= seven)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < seven && Y1ValuesPolarChartArray[i] >= six)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 64 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < six && Y1ValuesPolarChartArray[i] >= five)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 128 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < five && Y1ValuesPolarChartArray[i] >= four)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < four && Y1ValuesPolarChartArray[i] >= three)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < three && Y1ValuesPolarChartArray[i] >= two)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < two && Y1ValuesPolarChartArray[i] >= one)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                    }
                    else if (Y1ValuesPolarChartArray[i] < one && Y1ValuesPolarChartArray[i] >= zero)
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                    }
                    else
                    {
                        chartName.Series["Series1"].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                    }
                }
            }

            chartName.Series["Series1"].Points.Last().MarkerSize = 10;
            chartName.Series["Series1"].Points.Last().MarkerColor = GForceSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = true;
            /*
            X1ValuesChart1Array[0] = 0;
            X1ValuesChart1Array[1] = 45;
            List<double> X1ValuesChart1List = new List<double>(X1ValuesChart1Array);
            //X1ValuesChart1List.AddRange(X1ValuesChart1Array);
            Y1ValuesChart1Array[0] = 1.5;
            Y1ValuesChart1Array[1] = 3;
            List<double> Y1ValuesChart1List = new List<double>(Y1ValuesChart1Array);
            //Y1ValuesChart1List.AddRange(Y1ValuesChart1Array);
            chart1.Series["Series1"].Points.DataBindXY(X1ValuesChart1List, Y1ValuesChart1List);*/
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

                if (GForceSettings.Scheme == "Green Red")
                {
                    for (int i = 0; i < X1ValuesPolarChartArray.Length - 1; ++i)
                    {
                        double minus = GForceSettings.Y1Max / steps;
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

                        chartName.Series["Series" + u.ToString()].Points.AddXY(X1ValuesPolarChartArray[i], Y1ValuesPolarChartArray[i]);
                        if (Y1ValuesPolarChartArray[i] >= ten)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < ten && Y1ValuesPolarChartArray[i] >= nine)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < nine && Y1ValuesPolarChartArray[i] >= eight)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < eight && Y1ValuesPolarChartArray[i] >= seven)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < seven && Y1ValuesPolarChartArray[i] >= six)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 64 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < six && Y1ValuesPolarChartArray[i] >= five)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 128 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < five && Y1ValuesPolarChartArray[i] >= four)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < four && Y1ValuesPolarChartArray[i] >= three)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < three && Y1ValuesPolarChartArray[i] >= two)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < two && Y1ValuesPolarChartArray[i] >= one)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < one && Y1ValuesPolarChartArray[i] >= zero)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                        }
                        else
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 192 / historycolordivider, 0 / historycolordivider);
                        }
                    }
                    u++;
                }
                else
                {
                    for (int i = 0; i < X1ValuesPolarChartArray.Length - 1; ++i)
                    {
                        double minus = GForceSettings.Y1Max / steps;
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

                        chartName.Series["Series" + u.ToString()].Points.AddXY(X1ValuesPolarChartArray[i], Y1ValuesPolarChartArray[i]);
                        if (Y1ValuesPolarChartArray[i] >= ten)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < ten && Y1ValuesPolarChartArray[i] >= nine)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < nine && Y1ValuesPolarChartArray[i] >= eight)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < eight && Y1ValuesPolarChartArray[i] >= seven)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 0 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < seven && Y1ValuesPolarChartArray[i] >= six)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 64 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < six && Y1ValuesPolarChartArray[i] >= five)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 128 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < five && Y1ValuesPolarChartArray[i] >= four)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 255 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < four && Y1ValuesPolarChartArray[i] >= three)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 192 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < three && Y1ValuesPolarChartArray[i] >= two)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 128 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < two && Y1ValuesPolarChartArray[i] >= one)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 64 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                        }
                        else if (Y1ValuesPolarChartArray[i] < one && Y1ValuesPolarChartArray[i] >= zero)
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                        }
                        else
                        {
                            chartName.Series["Series" + u.ToString()].Points[i].MarkerColor = Color.FromArgb(historyalpha, 0 / historycolordivider, 0 / historycolordivider, 192 / historycolordivider);
                        }
                    }
                    u++;
                }

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
            if (GForceSettings.Scheme == "Green Red")
            {
                for (double i = -GForceSettings.Y1Max * steps; i <= GForceSettings.Y1Max * steps; i += GForceSettings.Y1Max)
                {

                    StripLine sl = new StripLine();
                    if (Math.Abs(i) == GForceSettings.Y1Max * 10)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 9)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 8)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 7)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 64 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 6)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 128 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 5)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 4)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 3)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 2)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 64 / divider, 192 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 1)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 0 / divider, 192 / divider, 0 / divider);
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
            else
            {
                for (double i = -GForceSettings.Y1Max * steps; i <= GForceSettings.Y1Max * steps; i += GForceSettings.Y1Max)
                {

                    StripLine sl = new StripLine();
                    if (Math.Abs(i) == GForceSettings.Y1Max * 10)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 9)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 8)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 0 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 7)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 64 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 6)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 128 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 5)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 255 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 4)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 192 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 3)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 128 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 2)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 64 / divider, 0 / divider, 192 / divider);
                    }
                    if (Math.Abs(i) == GForceSettings.Y1Max * 1)
                    {
                        sl.BackColor = Color.FromArgb(alpha, 0 / divider, 0 / divider, 192 / divider);
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

        }
        public static void PlotUpDownChart(Chart chartName)
        {
            chartName.Series["Series1"].Points.Clear();
            chartName.Series["Series1"].Color = GForceSettings.MarkerColor;
            X1ValuesChart2Array[0] = 0.3;
            X1ValuesChart2Array[1] = 0.7;
            List<double> X1ValuesChart2List = new List<double>(X1ValuesChart2Array);
            //X1ValuesChart1List.AddRange(X1ValuesChart1Array);
            Y1ValuesChart2Array[0] = Math.Round(LiveData.YG, 2);
            Y1ValuesChart2Array[1] = Y1ValuesChart2Array[0];
            List<double> Y1ValuesChart2List = new List<double>(Y1ValuesChart2Array);
            //Y1ValuesChart1List.AddRange(Y1ValuesChart1Array);
            chartName.Series["Series1"].Points.DataBindXY(X1ValuesChart2List, Y1ValuesChart2List);
            chartName.Series["Series1"].Points.Last().IsValueShownAsLabel = true;
        }
    }
}
