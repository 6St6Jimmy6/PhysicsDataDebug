using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public partial class FormSuspensionGeometry : Form
    {
        // Both charts use the same coordinate limits. The values and update interval
        // are edited in the Designer-owned top toolbar and persisted with the form.
        private bool chartInitialized;
        private bool isRestoringSettings;

        public FormSuspensionGeometry()
        {
            InitializeComponent();
            timer1.Enabled = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            // Save untouched controls as factory defaults before restoring autosaved values.
            JsonFormSettings.EnsureFactoryDefaults(this);
            Shown += FormSuspensionGeometry_Shown;
        }

        private void FormSuspensionGeometry_Shown(object sender, EventArgs e)
        {
            if (chartInitialized) return;
            SetChart(chart1);
            chartInitialized = true;
            ApplyAxisSettings();
            ApplyUpdateInterval();
            timer1.Enabled = true;
        }

        private void SuspensionGeometrySetting_ValueChanged(object sender, EventArgs e)
        {
            if (isRestoringSettings) return;
            ApplyUpdateInterval();
            if (chartInitialized) ApplyAxisSettings();
        }

        private void ApplyUpdateInterval()
        {
            int interval = Decimal.ToInt32(updateIntervalNumericUpDown.Value);
            if (interval > 0) timer1.Interval = interval;
        }

        private void ApplyAxisSettings()
        {
            double xMin = (double)axisXMinimumNumericUpDown.Value;
            double xMax = (double)axisXMaximumNumericUpDown.Value;
            double yMin = (double)axisYMinimumNumericUpDown.Value;
            double yMax = (double)axisYMaximumNumericUpDown.Value;
            bool xValid = xMin < xMax;
            bool yValid = yMin < yMax;
            axisXMinimumNumericUpDown.BackColor = xValid ? Color.FromArgb(38, 38, 38) : Color.FromArgb(105, 35, 35);
            axisXMaximumNumericUpDown.BackColor = xValid ? Color.FromArgb(38, 38, 38) : Color.FromArgb(105, 35, 35);
            axisYMinimumNumericUpDown.BackColor = yValid ? Color.FromArgb(38, 38, 38) : Color.FromArgb(105, 35, 35);
            axisYMaximumNumericUpDown.BackColor = yValid ? Color.FromArgb(38, 38, 38) : Color.FromArgb(105, 35, 35);
            if (!chartInitialized || !xValid || !yValid) return;
            foreach (string name in new[] { "FrontSuspension", "RearSuspension" })
            {
                ChartArea area = chart1.ChartAreas.FindByName(name);
                if (area == null) continue;
                // Order can matter when replacing an existing scale with a new
                // range entirely outside it. Auto first, then apply the pair.
                area.AxisX.Minimum = double.NaN;
                area.AxisX.Maximum = double.NaN;
                area.AxisY.Minimum = double.NaN;
                area.AxisY.Maximum = double.NaN;
                area.AxisX.Minimum = xMin;
                area.AxisX.Maximum = xMax;
                area.AxisY.Minimum = yMin;
                area.AxisY.Maximum = yMax;
                area.AxisX.Interval = NiceAxisInterval(xMax - xMin);
                area.AxisY.Interval = NiceAxisInterval(yMax - yMin);
            }
        }

        private static double NiceAxisInterval(double range)
        {
            double desired = range / 6d;
            if (!IsFinite(desired) || desired <= 0d) return 0.5d;
            double magnitude = Math.Pow(10d, Math.Floor(Math.Log10(desired)));
            double fraction = desired / magnitude;
            return (fraction <= 1d ? 1d : fraction <= 2d ? 2d : fraction <= 5d ? 5d : 10d) * magnitude;
        }

        void FrontRearChartSet(Chart chartName, string sideName, string suspension, string legendName, Color textColor, Color chartLineColors)
        {
            #region ChartAreas
            chartName.ChartAreas.Add(sideName + suspension);
            chartName.ChartAreas[sideName + suspension].BackColor = Color.Transparent;

            #region AxisX
            chartName.ChartAreas[sideName + suspension].AxisX.TitleForeColor = textColor;
            chartName.ChartAreas[sideName + suspension].AxisX.LabelStyle.ForeColor = textColor;
            chartName.ChartAreas[sideName + suspension].AxisX.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisX.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisX.MajorGrid.Enabled = true;
            chartName.ChartAreas[sideName + suspension].AxisX.MajorGrid.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisX.MajorTickMark.Enabled = true;
            chartName.ChartAreas[sideName + suspension].AxisX.MajorTickMark.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisX.MajorTickMark.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisX.MinorGrid.Enabled = true;
            chartName.ChartAreas[sideName + suspension].AxisX.MinorGrid.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;

            chartName.ChartAreas[sideName + suspension].AxisX.MinorGrid.Enabled = false;
            chartName.ChartAreas[sideName + suspension].AxisX.MinorTickMark.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisX.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisX.Crossing = double.NaN;
            chartName.ChartAreas[sideName + suspension].AxisX.Interval = 0.5d;
            chartName.ChartAreas[sideName + suspension].AxisX.Maximum = 1.5;
            chartName.ChartAreas[sideName + suspension].AxisX.Minimum = -1.5;
            #endregion

            #region AxisY
            chartName.ChartAreas[sideName + suspension].AxisY.TitleForeColor = textColor;
            chartName.ChartAreas[sideName + suspension].AxisY.LabelStyle.ForeColor = textColor;
            chartName.ChartAreas[sideName + suspension].AxisY.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisY.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisY.MajorGrid.Enabled = true;
            chartName.ChartAreas[sideName + suspension].AxisY.MajorGrid.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisY.MajorTickMark.Enabled = true;
            chartName.ChartAreas[sideName + suspension].AxisY.MajorTickMark.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisY.MajorTickMark.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisY.MinorGrid.Enabled = true;
            chartName.ChartAreas[sideName + suspension].AxisY.MinorGrid.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;

            chartName.ChartAreas[sideName + suspension].AxisY.MinorGrid.Enabled = false;
            chartName.ChartAreas[sideName + suspension].AxisY.MinorTickMark.LineColor = chartLineColors;
            chartName.ChartAreas[sideName + suspension].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas[sideName + suspension].AxisY.Crossing = double.NaN;
            chartName.ChartAreas[sideName + suspension].AxisY.Interval = 0.5d;
            chartName.ChartAreas[sideName + suspension].AxisY.Maximum = 1.5;
            chartName.ChartAreas[sideName + suspension].AxisY.Minimum = -0.5;
            #endregion
            #endregion

            #region Titles
            chartName.Titles.Add(sideName + suspension).Name = sideName + suspension;//Why the hell this needs to be done this way?
            chartName.Titles[sideName + suspension].ForeColor = textColor;
            chartName.Titles[sideName + suspension].Text = sideName + " " + suspension;
            chartName.Titles[sideName + suspension].DockedToChartArea = sideName + suspension;
            chartName.Titles[sideName + suspension].IsDockedInsideChartArea = false;
            #endregion

            #region Series
            string seriesName = "";
            string legendText = "";
            #region CenterOfMassHeight
            seriesName = "CenterOfMassHeight";
            legendText = "CenterOfMassHeight";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            { 
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            { 
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false; 
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 255, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(0, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 10;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion

            #region RollCenterXY
            legendText = "RollCenterXY";
            seriesName = "RollCenterXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
        }
            else
            { 
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false; 
            }
    chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 6;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion

            #region RideHeight
            legendText = "RideHeight";
            seriesName = "RideHeight";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(64, 64, 255);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(64, 64, 255);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(64, 64, 255);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 6;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion
            FLRRSeriesChartSet(chartName, sideName, suspension, legendName, textColor);
            /*
            #region FL

            #region FLTirePivotXY
            legendText = "TirePivotXY";
            seriesName = "FLTirePivotXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 2;
            chartName.Series[sideName + seriesName].MarkerSize = 8;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion

            #region FLUpperFrontArmXY
            legendText = "UpperFrontArmXY";
            seriesName = "FLUpperFrontArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FLUpperRearArmXY
            legendText = "UpperRearArmXY";
            seriesName = "FLUpperRearArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FLUpperArmMidpointXY
            legendText = "UpperArmMidpointXY";
            seriesName = "FLUpperArmMidpointXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FLLowerFrontArmXY
            legendText = "LowerFrontArmXY";
            seriesName = "FLLowerFrontArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FLLowerRearArmXY
            legendText = "LowerRearArmXY";
            seriesName = "FLLowerRearArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FLLowerArmMidpointXY
            legendText = "LowerArmMidpointXY";
            seriesName = "FLLowerArmMidpointXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FLSteeringRodXY
            legendText = "SteeringRodXY";
            seriesName = "FLSteeringRodXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FLInstantCenterXY
            legendText = "InstantCenterXY";
            seriesName = "FLInstantCenterXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            chartName.Series[sideName + seriesName].Points[1].MarkerSize = 10;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[2].IsValueShownAsLabel = false;
            #endregion

            #region FLRollCenterLine
            legendText = "RollCenterLine";
            seriesName = "FLRollCenterLine";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            #endregion
            #endregion

            #region FR
            #region FRTirePivotXY
            legendText = "TirePivotXY";
            seriesName = "FRTirePivotXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 2;
            chartName.Series[sideName + seriesName].MarkerSize = 8;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion

            #region FRUpperFrontArmXY
            legendText = "UpperFrontArmXY";
            seriesName = "FRUpperFrontArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FRUpperRearArmXY
            legendText = "UpperRearArmXY";
            seriesName = "FRUpperRearArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FRUpperArmMidpointXY
            legendText = "UpperArmMidpointXY";
            seriesName = "FRUpperArmMidpointXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FRLowerFrontArmXY
            legendText = "LowerFrontArmXY";
            seriesName = "FRLowerFrontArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FRLowerRearArmXY
            legendText = "LowerRearArmXY";
            seriesName = "FRLowerRearArmXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FRLowerArmMidpointXY
            legendText = "LowerArmMidpointXY";
            seriesName = "FRLowerArmMidpointXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FRSteeringRodXY
            legendText = "SteeringRodXY";
            seriesName = "FRSteeringRodXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FRInstantCenterXY
            legendText = "InstantCenterXY";
            seriesName = "FRInstantCenterXY";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            chartName.Series[sideName + seriesName].Points[1].MarkerSize = 10;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[2].IsValueShownAsLabel = false;
            #endregion

            #region FRRollCenterLine
            legendText = "RollCenterLine";
            seriesName = "FRRollCenterLine";
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
{
    chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
}
chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            #endregion
            #endregion
            */
            #endregion

        }
        void FLRRSeriesChartSet(Chart chartName, string sideName, string suspension, string legendName, Color textColor)
        {
            string cornerNameLeft;
            string cornerNameRight;
            string seriesName;
            string legendText;

            if (sideName == "Front")
            {
                cornerNameLeft = "FL";
                cornerNameRight = "FR";
            }
            else
            {
                cornerNameLeft = "RL";
                cornerNameRight = "RR";
            }

            #region FL

            #region FLTirePivotXY
            legendText = "TirePivotXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 2;
            chartName.Series[sideName + seriesName].MarkerSize = 8;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion

            #region FLUpperFrontArmXY
            legendText = "UpperFrontArmXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FLUpperRearArmXY
            legendText = "UpperRearArmXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FLUpperArmMidpointXY
            legendText = "UpperArmMidpointXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FLLowerFrontArmXY
            legendText = "LowerFrontArmXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FLLowerRearArmXY
            legendText = "LowerRearArmXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FLLowerArmMidpointXY
            legendText = "LowerArmMidpointXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FLSteeringRodXY
            legendText = "SteeringRodXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FLInstantCenterXY
            legendText = "InstantCenterXY";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            chartName.Series[sideName + seriesName].Points[1].MarkerSize = 10;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[2].IsValueShownAsLabel = false;
            #endregion

            #region FLRollCenterLine
            legendText = "RollCenterLine";
            seriesName = cornerNameLeft + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            #endregion
            #endregion

            #region FR
            #region FRTirePivotXY
            legendText = "TirePivotXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Point;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 2;
            chartName.Series[sideName + seriesName].MarkerSize = 8;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            #endregion

            #region FRUpperFrontArmXY
            legendText = "UpperFrontArmXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FRUpperRearArmXY
            legendText = "UpperRearArmXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 0, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FRUpperArmMidpointXY
            legendText = "UpperArmMidpointXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FRLowerFrontArmXY
            legendText = "LowerFrontArmXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = false;
            #endregion

            #region FRLowerRearArmXY
            legendText = "LowerRearArmXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(255, 255, 0);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FRLowerArmMidpointXY
            legendText = "LowerArmMidpointXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 3;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[1].Color = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.Transparent;
            #endregion

            #region FRSteeringRodXY
            legendText = "SteeringRodXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.FromArgb(0, 255, 255);
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 4;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            #endregion

            #region FRInstantCenterXY
            legendText = "InstantCenterXY";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(128, 128, 128);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            chartName.Series[sideName + seriesName].Points[0].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].Points[1].IsValueShownAsLabel = true;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.Circle;
            chartName.Series[sideName + seriesName].Points[1].MarkerSize = 10;
            chartName.Series[sideName + seriesName].Points[1].MarkerColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[1].MarkerBorderColor = Color.FromArgb(128, 0, 0);
            chartName.Series[sideName + seriesName].Points[2].IsValueShownAsLabel = false;
            #endregion

            #region FRRollCenterLine
            legendText = "RollCenterLine";
            seriesName = cornerNameRight + legendText;
            chartName.Series.Add(sideName + seriesName);
            chartName.Series[sideName + seriesName].ChartArea = sideName + suspension;
            chartName.Series[sideName + seriesName].ChartType = SeriesChartType.Line;
            chartName.Series[sideName + seriesName].LabelForeColor = textColor;
            chartName.Series[sideName + seriesName].IsValueShownAsLabel = false;
            chartName.Series[sideName + seriesName].LabelFormat = "{0:N3}";
            chartName.Series[sideName + seriesName].SmartLabelStyle.CalloutLineColor = textColor;
            chartName.Series[sideName + seriesName].Legend = legendName;
            if (sideName == "Front")
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            else
            {
                chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
            }
            chartName.Series[sideName + seriesName].LegendText = legendText;
            chartName.Series[sideName + seriesName].Color = Color.FromArgb(0, 64, 0);
            chartName.Series[sideName + seriesName].MarkerColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderColor = Color.Transparent;
            chartName.Series[sideName + seriesName].MarkerBorderWidth = 0;
            chartName.Series[sideName + seriesName].MarkerSize = 5;
            chartName.Series[sideName + seriesName].MarkerStyle = MarkerStyle.None;
            if (chartName.Series[sideName + seriesName].Points.Count == 0)
            {
                chartName.Series[sideName + seriesName].Points.Add();
                chartName.Series[sideName + seriesName].Points.Add();
            }
            #endregion
            #endregion
        }
        void SetChart(Chart chartName)
        {
            chartName.BackColor = Color.Transparent;

            chartName.Series.Clear();
            chartName.ChartAreas.Clear();
            chartName.Titles.Clear();
            chartName.Legends.Clear();

            string sideName;
            string suspension;
            string legendName = "Legend1";
            Color textColor = Color.Gainsboro;
            Color chartLineColors = Color.FromArgb(85, 85, 85);
            #region Legends
            chartName.Legends.Add(legendName);
            chartName.Legends[legendName].ForeColor = textColor;
            chartName.Legends[legendName].BackColor = Color.Transparent;
            chartName.Legends[legendName].Docking = Docking.Bottom;
            #endregion

            #region Front Suspension
            sideName = "Front";
            suspension = "Suspension";
            FrontRearChartSet(chart1, sideName, suspension, legendName, textColor, chartLineColors);
            #endregion

            #region Rear Suspension
            sideName = "Rear";
            suspension = "Suspension";
            FrontRearChartSet(chart1, sideName, suspension, legendName, textColor, chartLineColors);
            #endregion



        }
        Vector4 SuspensionGeometry(string chartSideName, string side, bool isStatic, Chart chart)
        {
            float rideHeight = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_Suspension2DataOffset", "RideHeight"));
            SetGeometryPoint(chart.Series[chartSideName + "RideHeight"].Points[0], 0.000000000000000000000000000000000000001d, 0.000000000000000000000000000000000000001d + rideHeight);

            float centerOfMassHeight = LiveData.GetFullListDataValue(TelemetryPrefix.Body, GameMemoryConfig.Field("WF_MassDataOffset", "CenterOfMassHeight"));
            SetGeometryPoint(chart.Series[chartSideName + "CenterOfMassHeight"].Points[0], 0.000000000000000000000000000000000000001d, 0.000000000000000000000000000000000000001d + centerOfMassHeight);

            #region TirePivot
            Vector4 staticTirePivot = StaticTirePivot(side, rideHeight, centerOfMassHeight);
            Vector4 dynamicTirePivot = DynamicTirePivot(side, rideHeight, centerOfMassHeight);
            TirePivotChartPoints(chartSideName, side, staticTirePivot, dynamicTirePivot, chart, "TirePivotXY", isStatic);
            #endregion

            #region UpperFront
            Vector4 staticBodyUpperFrontArm = StaticBodyArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperFrontArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperFrontArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperFrontArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperFrontArmW"),
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleUpperFrontArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmW"),
                staticTirePivot);
            Vector4 dynamicSpindleUpperFrontArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperFrontArmW"),
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyUpperFrontArm, staticSpindleUpperFrontArm, dynamicSpindleUpperFrontArm, chart, "UpperFrontArmXY", isStatic);
            #endregion

            #region UpperRear
            Vector4 staticBodyUpperRearArm = StaticBodyArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperRearArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperRearArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperRearArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyUpperRearArmW"),
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleUpperRearArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmW"),
                staticTirePivot);
            Vector4 dynamicSpindleUpperRearArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleUpperRearArmW"),
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyUpperRearArm, staticSpindleUpperRearArm, dynamicSpindleUpperRearArm, chart, "UpperRearArmXY", isStatic);
            #endregion

            #region LowerFront
            Vector4 staticBodyLowerFrontArm = StaticBodyArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerFrontArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerFrontArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerFrontArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerFrontArmW"),
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleLowerFrontArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmW"),
                staticTirePivot);
            Vector4 dynamicSpindleLowerFrontArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerFrontArmW"),
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyLowerFrontArm, staticSpindleLowerFrontArm, dynamicSpindleLowerFrontArm, chart, "LowerFrontArmXY", isStatic);
            #endregion

            #region LowerRear
            Vector4 staticBodyLowerRearArm = StaticBodyArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerRearArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerRearArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerRearArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodyLowerRearArmW"),
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleLowerRearArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmW"),
                staticTirePivot);
            Vector4 dynamicSpindleLowerRearArm = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleLowerRearArmW"),
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyLowerRearArm, staticSpindleLowerRearArm, dynamicSpindleLowerRearArm, chart, "LowerRearArmXY", isStatic);
            #endregion

            #region SteeringRod
            Vector4 staticBodySteeringRod = StaticBodyArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodySteeringRodX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodySteeringRodY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodySteeringRodZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "BodySteeringRodW"),
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleSteeringRod = SpindleArmPivot(side,
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodX"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodY"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodZ"),
                GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodW"),
                staticTirePivot);
            Vector4 dynamicSpindleSteeringRod = new Vector4
            {
                X = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodX")) + dynamicTirePivot.X,//?? Needs also to + tire X rotation and offset the offset with that
                Y = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodY")) + dynamicTirePivot.Y,// Needs also to + tire Y rotation and offset the offset with that
                Z = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodZ")) + dynamicTirePivot.Z,//?? Needs also to + tire Z rotation and offset the offset with that
                W = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_SuspensionGeometryDataOffset", "SpindleSteeringRodW")) + dynamicTirePivot.W
            };
            ArmChartPoints(chartSideName, side, staticBodySteeringRod, staticSpindleSteeringRod, dynamicSpindleSteeringRod, chart, "SteeringRodXY", isStatic);
            #endregion

            #region InstantCenter

            #region UpperArmMidpoint
            Vector4 bodyUpperArmMidpoint = MidPointArm(staticBodyUpperFrontArm, staticBodyUpperRearArm);
            ArmMidpointChartPoints(chartSideName, side, bodyUpperArmMidpoint, staticSpindleUpperFrontArm, dynamicSpindleUpperFrontArm, chart, "UpperArmMidpointXY", isStatic);
            #endregion
            #region LowerArmMidpoint
            Vector4 bodyLowerArmMidpoint = MidPointArm(staticBodyLowerFrontArm, staticBodyLowerRearArm);
            ArmMidpointChartPoints(chartSideName, side, bodyLowerArmMidpoint, staticSpindleLowerFrontArm, dynamicSpindleLowerFrontArm, chart, "LowerArmMidpointXY", isStatic);
            #endregion

            #region InstantCenter
            //https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
            Vector4 instantCenter = XYLineIntersectionVector(
            dynamicSpindleLowerFrontArm,
            bodyLowerArmMidpoint,
            dynamicSpindleUpperFrontArm,
            bodyUpperArmMidpoint);

            string InstantCenterXY = chartSideName + side + "InstantCenterXY";
            SetGeometryPoint(chart.Series[InstantCenterXY].Points[0], bodyUpperArmMidpoint.X, bodyUpperArmMidpoint.Y);
            SetGeometryPoint(chart.Series[InstantCenterXY].Points[1], instantCenter.X, instantCenter.Y);
            SetGeometryPoint(chart.Series[InstantCenterXY].Points[2], bodyLowerArmMidpoint.X, bodyLowerArmMidpoint.Y);
            #endregion

            #endregion
            return instantCenter;
        }
        Vector4 StaticTirePivot(string side, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireStaticPivotX")),
                Y = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireStaticPivotY")) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireStaticPivotZ")),
                W = 1,
            };
        }
        Vector4 DynamicTirePivot(string side, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireM41")),
                Y = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireM42")) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireM43")),
                W = LiveData.GetFullListDataValue(side, GameMemoryConfig.Field("WF_TireDataOffset", "TireM44"))
            };
        }
        void TirePivotChartPoints(string chartSideName, string side, Vector4 staticTirePivot, Vector4 dynamicTirePivot, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = chartSideName + side + seriesName;
            if (isStatic == true)
            {
                SetGeometryPoint(chart.Series[fullSeriesName].Points[0], staticTirePivot.X, staticTirePivot.Y);
            }
            else
            {
                SetGeometryPoint(chart.Series[fullSeriesName].Points[0], dynamicTirePivot.X, dynamicTirePivot.Y);
            }
        }
        Vector4 StaticBodyArmPivot(string side, GameMemoryField x, GameMemoryField y, GameMemoryField z, GameMemoryField w, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, x),
                Y = LiveData.GetFullListDataValue(side, y) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, z),
                W = LiveData.GetFullListDataValue(side, w)
            };
        }
        Vector4 SpindleArmPivot(string side, GameMemoryField x, GameMemoryField y, GameMemoryField z, GameMemoryField w, Vector4 tirePivot)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, x) + tirePivot.X,
                Y = LiveData.GetFullListDataValue(side, y) + tirePivot.Y,
                Z = LiveData.GetFullListDataValue(side, z) + tirePivot.Z,
                W = LiveData.GetFullListDataValue(side, w)/* + tirePivot.W*///??
            };
        }
        void ArmChartPoints(string chartSideName, string side, Vector4 staticBodyArm, Vector4 staticSpindleArm, Vector4 dynamicSpindleArm, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = chartSideName + side + seriesName;
            SetGeometryPoint(chart.Series[fullSeriesName].Points[0], staticBodyArm.X, staticBodyArm.Y);
            if (isStatic == true)
            {
                SetGeometryPoint(chart.Series[fullSeriesName].Points[1], staticSpindleArm.X, staticSpindleArm.Y);
            }
            else
            {
                SetGeometryPoint(chart.Series[fullSeriesName].Points[1], dynamicSpindleArm.X, dynamicSpindleArm.Y);
            }
        }
        void ArmMidpointChartPoints(string chartSideName, string side, Vector4 bodyArmMidpoint, Vector4 staticSpindleArm, Vector4 dynamicSpindleArm, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = chartSideName + side + seriesName;
            SetGeometryPoint(chart1.Series[fullSeriesName].Points[0], bodyArmMidpoint.X, bodyArmMidpoint.Y);

            if (isStatic == true)
            {
                SetGeometryPoint(chart1.Series[fullSeriesName].Points[1], staticSpindleArm.X, staticSpindleArm.Y);
            }
            else
            {
                SetGeometryPoint(chart1.Series[fullSeriesName].Points[1], dynamicSpindleArm.X, dynamicSpindleArm.Y);
            }
        }
        void SuspensionRollCenter(string chartSideName, bool isStatic, Chart chart, Vector4 instantCenterFL, Vector4 instantCenterFR)
        {
            string cornerNameLeft;
            string cornerNameRight;
            float rideHeightLeft;
            float rideHeightRight;

            if (chartSideName == "Front")
            {
                cornerNameLeft = "FL";
                rideHeightLeft = LiveData.GetFullListDataValue(TelemetryPrefix.FL, GameMemoryConfig.Field("WF_Suspension2DataOffset", "RideHeight"));
                cornerNameRight = "FR";
                rideHeightRight = LiveData.GetFullListDataValue(TelemetryPrefix.FR, GameMemoryConfig.Field("WF_Suspension2DataOffset", "RideHeight"));
            }
            else
            {
                cornerNameLeft = "RL";
                rideHeightLeft = LiveData.GetFullListDataValue(TelemetryPrefix.RL, GameMemoryConfig.Field("WF_Suspension2DataOffset", "RideHeight"));
                cornerNameRight = "RR";
                rideHeightRight = LiveData.GetFullListDataValue(TelemetryPrefix.RR, GameMemoryConfig.Field("WF_Suspension2DataOffset", "RideHeight"));
            }

            float centerOfMassHeight = LiveData.GetFullListDataValue(TelemetryPrefix.Body, GameMemoryConfig.Field("WF_MassDataOffset", "CenterOfMassHeight"));
            Vector4 dynamicTirePivotFL = DynamicTirePivot(TelemetryPrefix.FL, rideHeightLeft, centerOfMassHeight);

            #region Left
            Vector4 tireMiddleContactPointFL = new Vector4
            {
                X = dynamicTirePivotFL.X,
                Y = dynamicTirePivotFL.Y - LiveData.GetFullListDataValue(TelemetryPrefix.FL, GameMemoryConfig.Field("WF_TireDataOffset", "TireRadius"))/* - LiveData.GetFullListDataValue(TelemetryPrefix.FL, GameMemoryConfig.Field("WF_TireDataOffset", "LoadedRadius"))*/,
                Z = dynamicTirePivotFL.Z,
                W = dynamicTirePivotFL.W,
            };
            Vector4 dynamicTirePivotFR = DynamicTirePivot(TelemetryPrefix.FR, rideHeightRight, centerOfMassHeight);
            #endregion
            #region Right
            Vector4 tireMiddleContactPointFR = new Vector4
            {
                X = dynamicTirePivotFR.X,
                Y = dynamicTirePivotFR.Y - LiveData.GetFullListDataValue(TelemetryPrefix.FR, GameMemoryConfig.Field("WF_TireDataOffset", "TireRadius"))/* - LiveData.GetFullListDataValue(TelemetryPrefix.FR, GameMemoryConfig.Field("WF_TireDataOffset", "LoadedRadius"))*/,
                Z = dynamicTirePivotFR.Z,
                W = dynamicTirePivotFR.W,
            };
            #endregion
            #region RollCenter
            Vector4 rollCenter = XYLineIntersectionVector(
                instantCenterFL,
                tireMiddleContactPointFL,
                instantCenterFR,
                tireMiddleContactPointFR);
            string rollCenterXY = chartSideName + "RollCenterXY";
            SetGeometryPoint(chart.Series[rollCenterXY].Points[0], rollCenter.X, rollCenter.Y);

            string FLRCLine = chartSideName + cornerNameLeft + "RollCenterLine";
            SetGeometryPoint(chart.Series[FLRCLine].Points[0], instantCenterFL.X, instantCenterFL.Y);
            SetGeometryPoint(chart.Series[FLRCLine].Points[1], tireMiddleContactPointFL.X, tireMiddleContactPointFL.Y);

            string FRRCLine = chartSideName + cornerNameRight + "RollCenterLine";
            SetGeometryPoint(chart.Series[FRRCLine].Points[0], instantCenterFR.X, instantCenterFR.Y);
            SetGeometryPoint(chart.Series[FRRCLine].Points[1], tireMiddleContactPointFR.X, tireMiddleContactPointFR.Y);

            #endregion
        }
        Vector4 MidPointArm(Vector4 frontArm, Vector4 rearArm)
        {
            return new Vector4
            {
                X = (frontArm.X + rearArm.X) / 2,
                Y = (frontArm.Y + rearArm.Y) / 2,
                Z = 0,
                W = 1,
            };
        }
        // Use a determinant instead of slope division: vertical arm lines are
        // valid geometry, while parallel/coincident lines have NO finite point
        // of intersection. The previous m=(dy/dx) calculation could produce
        // Infinity/NaN and crash System.Windows.Forms.DataVisualization during paint.
        private static Vector4 XYLineIntersectionVector(
            Vector4 vector1, Vector4 vector2, Vector4 vector3, Vector4 vector4)
        {
            double dx1 = (double)vector2.X - vector1.X;
            double dy1 = (double)vector2.Y - vector1.Y;
            double dx2 = (double)vector4.X - vector3.X;
            double dy2 = (double)vector4.Y - vector3.Y;
            double len1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);
            double len2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);
            double determinant = dx1 * dy2 - dy1 * dx2;
            if (!IsFinite(len1) || !IsFinite(len2) ||
                len1 < 1e-7 || len2 < 1e-7 ||
                !IsFinite(determinant) ||
                Math.Abs(determinant) <= 1e-7 * len1 * len2)
                return new Vector4(float.NaN, float.NaN, 0f, 1f);

            double xOffset = (double)vector3.X - vector1.X;
            double yOffset = (double)vector3.Y - vector1.Y;
            double t = (xOffset * dy2 - yOffset * dx2) / determinant;
            double x = vector1.X + t * dx1;
            double y = vector1.Y + t * dy1;
            if (!IsFinite(x) || !IsFinite(y) ||
                Math.Abs(x) > 1000000d || Math.Abs(y) > 1000000d)
                return new Vector4(float.NaN, float.NaN, 0f, 1f);
            return new Vector4((float)x, (float)y, 0f, 1f);
        }

        private static bool IsFinite(double value) =>
            !double.IsNaN(value) && !double.IsInfinity(value);

        // Never submit NaN/Infinity or extreme intersection coordinates to
        // WinForms Chart. An invalid geometric point is omitted, not drawn at
        // (0, 0). A later valid sample restores it automatically.
        private static void SetGeometryPoint(DataPoint point, double x, double y)
        {
            bool valid = IsFinite(x) && IsFinite(y) &&
                         Math.Abs(x) <= 1000000d && Math.Abs(y) <= 1000000d;
            if (!valid)
            {
                point.XValue = 0d;
                point.YValues = new double[] { 0d };
                point.IsEmpty = true;
                return;
            }
            point.XValue = x;
            point.YValues = new double[] { y };
            point.IsEmpty = false;
        }
        private void FormSuspensionGeometry_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
            isRestoringSettings = true;
            try { JsonFormSettings.LoadAllSettings(this); }
            finally { isRestoringSettings = false; }
            ApplyUpdateInterval();
            LiveData.FormSuspensionGeometryOpen = true;
        }
        private void FormSuspensionGeometry_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            JsonFormSettings.SaveAllSettings(this);
            LiveData.FormSuspensionGeometryOpen = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process == null || !FormLiveData.ProcessGet ||
                !FormLiveData.FirstTimeLoad || LiveData.FullDataList.Count == 0 ||
                !FormLiveData.ValuesGet) return;

            try
            {
                Vector4 instantCenterFL = SuspensionGeometry("Front", TelemetryPrefix.FL, false, chart1);
                Vector4 instantCenterFR = SuspensionGeometry("Front", TelemetryPrefix.FR, false, chart1);
                SuspensionRollCenter("Front", false, chart1, instantCenterFL, instantCenterFR);

                Vector4 instantCenterRL = SuspensionGeometry("Rear", TelemetryPrefix.RL, false, chart1);
                Vector4 instantCenterRR = SuspensionGeometry("Rear", TelemetryPrefix.RR, false, chart1);
                SuspensionRollCenter("Rear", false, chart1, instantCenterRL, instantCenterRR);
            }
            catch (OverflowException ex)
            {
                timer1.Enabled = false;
                MessageBox.Show(this,
                    "A numeric overflow occurred while updating suspension geometry. " +
                    "This chart's timer has been stopped.\n\n" + ex.ToString(),
                    "Suspension geometry update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
