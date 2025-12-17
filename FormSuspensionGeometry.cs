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
        public FormSuspensionGeometry()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.AutoScroll = true;
            timer1.Enabled = true;
            timer1.Interval = 100;
            SetChart(chart1);

            textBox_FL_SuspensionGeometry.Visible = true;
            textBox_FL_SuspensionGeometry.ReadOnly = true;
            textBox_FL_SuspensionGeometry.Enabled = false;

            textBox_FR_SuspensionGeometry.Visible = true;
            textBox_FR_SuspensionGeometry.ReadOnly = true;
            textBox_FR_SuspensionGeometry.Enabled = false;

            textBox_RL_SuspensionGeometry.Visible = true;
            textBox_RL_SuspensionGeometry.ReadOnly = true;
            textBox_RL_SuspensionGeometry.Enabled = false;

            textBox_RR_SuspensionGeometry.Visible = true;
            textBox_RR_SuspensionGeometry.ReadOnly = true;
            textBox_RR_SuspensionGeometry.Enabled = false;
        }

        void SetChart(Chart chartName)
        {
            chartName.BackColor = Color.Transparent;

            chartName.Series.Clear();
            chartName.ChartAreas.Clear();

            string sideName = "";
            string suspension = "";
            string legendName = "Legend1";
            Color textColor = Color.White;
            Color chartLineColors = Color.FromArgb(32, 32, 32);
            #region Legends
            chartName.Legends.Clear();
            chartName.Legends.Add(legendName);
            chartName.Legends[legendName].ForeColor = textColor;
            chartName.Legends[legendName].BackColor = Color.Transparent;
            chartName.Legends[legendName].Docking = Docking.Bottom;
            #endregion

            #region Front Suspension
            sideName = "Front";
            suspension = "Suspension";
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
            chartName.ChartAreas[sideName + suspension].AxisX.Maximum = 2;
            chartName.ChartAreas[sideName + suspension].AxisX.Minimum = -2;
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
            chartName.ChartAreas[sideName + suspension].AxisY.Maximum = 2;
            chartName.ChartAreas[sideName + suspension].AxisY.Minimum = -1;
            #endregion

            #region Titles
            chartName.Titles.Clear();
            chartName.Titles.Add(Name = sideName + suspension);
            chartName.Titles[0].ForeColor = textColor;
            chartName.Titles[0].Text = sideName + " " + suspension;
            chartName.Titles[0].DockedToChartArea = sideName + suspension;
            chartName.Titles[0].IsDockedInsideChartArea = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = true;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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
            chartName.Series[sideName + seriesName].IsVisibleInLegend = false;
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

            #endregion

            #endregion

            #region Rear Suspension
            #endregion

        }
        Vector4 SuspensionGeometry(string chartSideName, Enum side, bool isStatic, Chart chart)
        {
            float rideHeight = LiveData.GetFullListDataValue(side, WF_Suspension2DataOffset.RideHeight);
            chart.Series[chartSideName + "RideHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart.Series[chartSideName + "RideHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + rideHeight };

            float centerOfMassHeight = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            chart.Series[chartSideName + "CenterOfMassHeight"].Points[0].XValue = 0.000000000000000000000000000000000000001d;
            chart.Series[chartSideName + "CenterOfMassHeight"].Points[0].YValues = new double[] { 0.000000000000000000000000000000000000001d + centerOfMassHeight };

            #region TirePivot
            Vector4 staticTirePivot = StaticTirePivot(side, rideHeight, centerOfMassHeight);
            Vector4 dynamicTirePivot = DynamicTirePivot(side, rideHeight, centerOfMassHeight);
            TirePivotChartPoints(chartSideName, side, staticTirePivot, dynamicTirePivot, chart, "TirePivotXY", isStatic);
            #endregion

            #region UpperFront
            Vector4 staticBodyUpperFrontArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmX,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmY,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmZ,
                WF_SuspensionGeometryDataOffset.BodyUpperFrontArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleUpperFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmW,
                staticTirePivot);
            Vector4 dynamicSpindleUpperFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperFrontArmW,
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyUpperFrontArm, staticSpindleUpperFrontArm, dynamicSpindleUpperFrontArm, chart, "UpperFrontArmXY", isStatic);
            #endregion

            #region UpperRear
            Vector4 staticBodyUpperRearArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmX,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmY,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmZ,
                WF_SuspensionGeometryDataOffset.BodyUpperRearArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleUpperRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmW,
                staticTirePivot);
            Vector4 dynamicSpindleUpperRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleUpperRearArmW,
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyUpperRearArm, staticSpindleUpperRearArm, dynamicSpindleUpperRearArm, chart, "UpperRearArmXY", isStatic);
            #endregion

            #region LowerFront
            Vector4 staticBodyLowerFrontArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmX,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmY,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmZ,
                WF_SuspensionGeometryDataOffset.BodyLowerFrontArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleLowerFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmW,
                staticTirePivot);
            Vector4 dynamicSpindleLowerFrontArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerFrontArmW,
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyLowerFrontArm, staticSpindleLowerFrontArm, dynamicSpindleLowerFrontArm, chart, "LowerFrontArmXY", isStatic);
            #endregion

            #region LowerRear
            Vector4 staticBodyLowerRearArm = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmX,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmY,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmZ,
                WF_SuspensionGeometryDataOffset.BodyLowerRearArmW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleLowerRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmW,
                staticTirePivot);
            Vector4 dynamicSpindleLowerRearArm = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmX,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmY,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmZ,
                WF_SuspensionGeometryDataOffset.SpindleLowerRearArmW,
                dynamicTirePivot);
            ArmChartPoints(chartSideName, side, staticBodyLowerRearArm, staticSpindleLowerRearArm, dynamicSpindleLowerRearArm, chart, "LowerRearArmXY", isStatic);
            #endregion

            #region SteeringRod
            Vector4 staticBodySteeringRod = StaticBodyArmPivot(side,
                WF_SuspensionGeometryDataOffset.BodySteeringRodX,
                WF_SuspensionGeometryDataOffset.BodySteeringRodY,
                WF_SuspensionGeometryDataOffset.BodySteeringRodZ,
                WF_SuspensionGeometryDataOffset.BodySteeringRodW,
                rideHeight, centerOfMassHeight);
            Vector4 staticSpindleSteeringRod = SpindleArmPivot(side,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodX,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodY,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodZ,
                WF_SuspensionGeometryDataOffset.SpindleSteeringRodW,
                staticTirePivot);
            Vector4 dynamicSpindleSteeringRod = new Vector4
            {
                X = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodX) + dynamicTirePivot.X,//?? Needs also to + tire X rotation and offset the offset with that
                Y = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodY) + dynamicTirePivot.Y,// Needs also to + tire Y rotation and offset the offset with that
                Z = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodZ) + dynamicTirePivot.Z,//?? Needs also to + tire Z rotation and offset the offset with that
                W = LiveData.GetFullListDataValue(side, WF_SuspensionGeometryDataOffset.SpindleSteeringRodW) + dynamicTirePivot.W
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
            chart.Series[InstantCenterXY].Points[0].XValue = bodyUpperArmMidpoint.X;
            chart.Series[InstantCenterXY].Points[0].YValues = new double[] { bodyUpperArmMidpoint.Y };
            chart.Series[InstantCenterXY].Points[1].XValue = instantCenter.X;
            chart.Series[InstantCenterXY].Points[1].YValues = new double[] { instantCenter.Y };
            chart.Series[InstantCenterXY].Points[2].XValue = bodyLowerArmMidpoint.X;
            chart.Series[InstantCenterXY].Points[2].YValues = new double[] { bodyLowerArmMidpoint.Y };
            #endregion

            #endregion
            return instantCenter;
        }
        Vector4 StaticTirePivot(Enum side, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotX),
                Y = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotY) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireStaticPivotZ),
                W = 1,
            };
        }
        Vector4 DynamicTirePivot(Enum side, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM41),
                Y = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM42) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM43),
                W = LiveData.GetFullListDataValue(side, WF_TireDataOffset.TireM44)
            };
        }
        void TirePivotChartPoints(string chartSideName, Enum side, Vector4 staticTirePivot, Vector4 dynamicTirePivot, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = chartSideName + side + seriesName;
            if (isStatic == true)
            {
                chart.Series[fullSeriesName].Points[0].XValue = staticTirePivot.X;
                chart.Series[fullSeriesName].Points[0].YValues = new double[] { staticTirePivot.Y };
            }
            else
            {
                chart.Series[fullSeriesName].Points[0].XValue = dynamicTirePivot.X;
                chart.Series[fullSeriesName].Points[0].YValues = new double[] { dynamicTirePivot.Y };
            }
        }
        Vector4 StaticBodyArmPivot(Enum side, Enum x, Enum y, Enum z, Enum w, float rideHeight, float centerOfMassHeight)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, x),
                Y = LiveData.GetFullListDataValue(side, y) + rideHeight + centerOfMassHeight,
                Z = LiveData.GetFullListDataValue(side, z),
                W = LiveData.GetFullListDataValue(side, w)
            };
        }
        Vector4 SpindleArmPivot(Enum side, Enum x, Enum y, Enum z, Enum w, Vector4 tirePivot)
        {
            return new Vector4
            {
                X = LiveData.GetFullListDataValue(side, x) + tirePivot.X,
                Y = LiveData.GetFullListDataValue(side, y) + tirePivot.Y,
                Z = LiveData.GetFullListDataValue(side, z) + tirePivot.Z,
                W = LiveData.GetFullListDataValue(side, w)/* + tirePivot.W*///??
            };
        }
        void ArmChartPoints(string chartSideName, Enum side, Vector4 staticBodyArm, Vector4 staticSpindleArm, Vector4 dynamicSpindleArm, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = chartSideName + side + seriesName;
            chart.Series[fullSeriesName].Points[0].XValue = staticBodyArm.X;
            chart.Series[fullSeriesName].Points[0].YValues = new double[] { staticBodyArm.Y };
            if (isStatic == true)
            {
                chart.Series[fullSeriesName].Points[1].XValue = staticSpindleArm.X;
                chart.Series[fullSeriesName].Points[1].YValues = new double[] { staticSpindleArm.Y };
            }
            else
            {
                chart.Series[fullSeriesName].Points[1].XValue = dynamicSpindleArm.X;
                chart.Series[fullSeriesName].Points[1].YValues = new double[] { dynamicSpindleArm.Y };
            }
        }
        void ArmMidpointChartPoints(string chartSideName, Enum side, Vector4 bodyArmMidpoint, Vector4 staticSpindleArm, Vector4 dynamicSpindleArm, Chart chart, string seriesName, bool isStatic)
        {
            string fullSeriesName = chartSideName + side + seriesName;
            chart1.Series[fullSeriesName].Points[0].XValue = bodyArmMidpoint.X;//BodyUpperArmMidpointX
            chart1.Series[fullSeriesName].Points[0].YValues = new double[] { bodyArmMidpoint.Y };//BodyUpperArmMidpointY

            if (isStatic == true)
            {
                chart1.Series[fullSeriesName].Points[1].XValue = staticSpindleArm.X;
                chart1.Series[fullSeriesName].Points[1].YValues = new double[] { staticSpindleArm.Y };
            }
            else
            {
                chart1.Series[fullSeriesName].Points[1].XValue = dynamicSpindleArm.X;//chart.Series[side + "UpperFrontArmXY"].Points[1].XValue;//DynamicSpindleUpperFrontArmX
                chart1.Series[fullSeriesName].Points[1].YValues = new double[] { dynamicSpindleArm.Y };//chart.Series[side + "UpperFrontArmXY"].Points[1].YValues;//DynamicSpindleUpperFrontArmY
            }
        }
        void SuspensionRollCenter(string chartSideName, bool isStatic, Chart chart, Vector4 instantCenterFL, Vector4 instantCenterFR)
        {
            float rideHeightFL = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_Suspension2DataOffset.RideHeight);
            float centerOfMassHeightFL = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            Vector4 dynamicTirePivotFL = DynamicTirePivot(WF_PrefixMain.FL, rideHeightFL, centerOfMassHeightFL);

            #region Left
            Vector4 tireMiddleContactPointFL = new Vector4
            {
                X = dynamicTirePivotFL.X,
                Y = dynamicTirePivotFL.Y - LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TireRadius)/* - LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LoadedRadius)*/,
                Z = dynamicTirePivotFL.Z,
                W = dynamicTirePivotFL.W,
            };

            float rideHeightFR = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_Suspension2DataOffset.RideHeight);
            float centerOfMassHeightFR = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_MassDataOffset.CenterOfMassHeight);
            Vector4 dynamicTirePivotFR = DynamicTirePivot(WF_PrefixMain.FR, rideHeightFR, centerOfMassHeightFR);
            #endregion
            #region Right
            Vector4 tireMiddleContactPointFR = new Vector4
            {
                X = dynamicTirePivotFR.X,
                Y = dynamicTirePivotFR.Y - LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TireRadius)/* - LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LoadedRadius)*/,
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
            chart.Series[rollCenterXY].Points[0].XValue = rollCenter.X;
            chart.Series[rollCenterXY].Points[0].YValues = new double[] { rollCenter.Y };

            string FLRCLine = chartSideName + "FL" + "RollCenterLine";
            chart.Series[FLRCLine].Points[0].XValue = instantCenterFL.X;
            chart.Series[FLRCLine].Points[0].YValues = new double[] { instantCenterFL.Y };
            chart.Series[FLRCLine].Points[1].XValue = tireMiddleContactPointFL.X;
            chart.Series[FLRCLine].Points[1].YValues = new double[] { tireMiddleContactPointFL.Y };

            string FRRCLine = chartSideName + "FR" + "RollCenterLine";
            chart.Series[FRRCLine].Points[0].XValue = instantCenterFR.X;
            chart.Series[FRRCLine].Points[0].YValues = new double[] { instantCenterFR.Y };
            chart.Series[FRRCLine].Points[1].XValue = tireMiddleContactPointFR.X;
            chart.Series[FRRCLine].Points[1].YValues = new double[] { tireMiddleContactPointFR.Y };

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
        private Vector4 XYLineIntersectionVector(
            Vector4 vector1,
            Vector4 vector2,
            Vector4 vector3,
            Vector4 vector4)//https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
        {
            float m1 = (vector2.Y - vector1.Y) / (vector2.X - vector1.X);//why one of these needs to be minus instead??
            float c1 = -m1 * vector1.X + vector1.Y;
            float m2 = (vector4.Y - vector3.Y) / (vector4.X - vector3.X);
            float c2 = -m2 * vector3.X + vector3.Y;
            return new Vector4
            {
                X = (c2 - c1) / (m1 - m2),
                Y = m1 * (c2 - c1) / (m1 - m2) + c1,
                Z = 0,
                W = 1,
            };
        }


        private void GeometryTextboxWrites()
        {
            List<string> FL = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.FL + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.FL, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                FL.Add(s);
            }
            var resultFL = String.Join("", FL.ToArray());
            textBox_FL_SuspensionGeometry.Text = resultFL;

            List<string> RL = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.RL + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.RL, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                RL.Add(s);
            }
            var resultRL = String.Join("", RL.ToArray());
            textBox_RL_SuspensionGeometry.Text = resultRL;

            List<string> FR = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.FR + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.FR, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                FR.Add(s);
            }
            var resultFR = String.Join("", FR.ToArray());
            textBox_FR_SuspensionGeometry.Text = resultFR;

            List<string> RR = new List<string>();
            //Write text
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionGeometryDataOffset)))
            {
                string s = "" + WF_PrefixMain.RR + "_" + Enum.GetName(typeof(WF_SuspensionGeometryDataOffset), (WF_SuspensionGeometryDataOffset)i) + ": " + LiveData.GetFullListDataValue(WF_PrefixMain.RR, (WF_SuspensionGeometryDataOffset)i) + "\r\n";
                RR.Add(s);
            }
            var resultRR = String.Join("", RR.ToArray());
            textBox_RR_SuspensionGeometry.Text = resultRR;
        }
        private void FormSuspensionGeometry_Load(object sender, EventArgs e)
        {
            LiveData.FormSuspensionGeometryOpen = true;
        }

        private void FormSuspensionGeometry_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            LiveData.FormSuspensionGeometryOpen = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LiveData.Process != null && FormLiveData.ProcessGet == true && FormLiveData.FirstTimeLoad == true && LiveData.FullDataList.Count > 0 && FormLiveData.ValuesGet == true)
            {
                GeometryTextboxWrites();
                Vector4 instantCenterFL = SuspensionGeometry("Front", WF_PrefixMain.FL, false, chart1);
                Vector4 instantCenterFR = SuspensionGeometry("Front", WF_PrefixMain.FR, false, chart1);
                SuspensionRollCenter("Front", false, chart1, instantCenterFL, instantCenterFR);
            }
        }
    }
}
