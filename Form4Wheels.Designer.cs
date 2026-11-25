
namespace Physics_Data_Debug
{
    partial class Form4Wheels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.refreshAndClearButton = new System.Windows.Forms.Button();
            this.toSettingsButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.GradientChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.filterActionsPanel = new System.Windows.Forms.Panel();
            this.actionColumns = new System.Windows.Forms.TableLayoutPanel();
            this.actionButtonsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.chartAndLegend = new System.Windows.Forms.SplitContainer();
            this.chartScrollPanel = new System.Windows.Forms.Panel();
            this.chartStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.filterActionsPanel.SuspendLayout();
            this.actionColumns.SuspendLayout();
            this.actionButtonsFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAndLegend)).BeginInit();
            this.chartAndLegend.Panel1.SuspendLayout();
            this.chartAndLegend.Panel2.SuspendLayout();
            this.chartAndLegend.SuspendLayout();
            this.chartScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshAndClearButton
            // 
            this.refreshAndClearButton.AutoSize = true;
            this.refreshAndClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.refreshAndClearButton.ForeColor = System.Drawing.Color.White;
            this.refreshAndClearButton.Location = new System.Drawing.Point(76, 5);
            this.refreshAndClearButton.MinimumSize = new System.Drawing.Size(105, 21);
            this.refreshAndClearButton.Name = "refreshAndClearButton";
            this.refreshAndClearButton.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.refreshAndClearButton.Size = new System.Drawing.Size(113, 25);
            this.refreshAndClearButton.TabIndex = 294;
            this.refreshAndClearButton.Text = "Clear / Refresh All";
            this.refreshAndClearButton.UseVisualStyleBackColor = false;
            this.refreshAndClearButton.Click += new System.EventHandler(this.refreshAndApplyButton_Click);
            // 
            // toSettingsButton
            // 
            this.toSettingsButton.AutoSize = true;
            this.toSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.toSettingsButton.ForeColor = System.Drawing.Color.White;
            this.toSettingsButton.Location = new System.Drawing.Point(5, 5);
            this.toSettingsButton.MinimumSize = new System.Drawing.Size(58, 21);
            this.toSettingsButton.Name = "toSettingsButton";
            this.toSettingsButton.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.toSettingsButton.Size = new System.Drawing.Size(65, 25);
            this.toSettingsButton.TabIndex = 293;
            this.toSettingsButton.Text = "Settings";
            this.toSettingsButton.UseVisualStyleBackColor = false;
            this.toSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.AutoSize = true;
            this.buttonPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonPause.ForeColor = System.Drawing.Color.White;
            this.buttonPause.Location = new System.Drawing.Point(195, 5);
            this.buttonPause.MinimumSize = new System.Drawing.Size(52, 21);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.buttonPause.Size = new System.Drawing.Size(57, 25);
            this.buttonPause.TabIndex = 299;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // GradientChart
            // 
            this.GradientChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Maroon;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 1D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.AxisX.Maximum = 1D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "phat";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.Title = "jou";
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.MajorGrid.Interval = 1D;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = -10D;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.GradientChart.ChartAreas.Add(chartArea1);
            this.GradientChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.GradientChart.Legends.Add(legend1);
            this.GradientChart.Location = new System.Drawing.Point(0, 0);
            this.GradientChart.Margin = new System.Windows.Forms.Padding(0);
            this.GradientChart.MinimumSize = new System.Drawing.Size(5, 5);
            this.GradientChart.Name = "GradientChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.IsValueShownAsLabel = false;
            dataPoint1.LabelForeColor = System.Drawing.Color.White;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            this.GradientChart.Series.Add(series1);
            this.GradientChart.Size = new System.Drawing.Size(120, 486);
            this.GradientChart.TabIndex = 304;
            this.GradientChart.Text = "chart5";
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "ZColorHeading";
            title1.Text = "Z axis";
            this.GradientChart.Titles.Add(title1);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.Title = "X1 1";
            chartArea2.AxisX2.Title = "X2";
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.Title = "Y1 1";
            chartArea2.AxisY2.Title = "Y2";
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 50F;
            chartArea2.Position.Width = 100F;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.Title = "X1 2";
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.Title = "Y1 2";
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.Name = "ChartArea2";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 50F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Y = 50F;
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.MinimumSize = new System.Drawing.Size(5, 5);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(831, 486);
            this.chart1.TabIndex = 308;
            this.chart1.Text = "chart1";
            title2.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title2.DockedToChartArea = "ChartArea1";
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            title2.Text = "Front Tires";
            title3.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title3.DockedToChartArea = "ChartArea2";
            title3.ForeColor = System.Drawing.Color.White;
            title3.Name = "Title2";
            title3.Text = "Rear Tires";
            this.chart1.Titles.Add(title2);
            this.chart1.Titles.Add(title3);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.filterActionsPanel, 0, 0);
            this.mainLayout.Controls.Add(this.chartAndLegend, 0, 1);
            this.mainLayout.Controls.Add(this.chartStatusLabel, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(2);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.mainLayout.Size = new System.Drawing.Size(962, 552);
            this.mainLayout.TabIndex = 0;
            // 
            // filterActionsPanel
            // 
            this.filterActionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.filterActionsPanel.Controls.Add(this.actionColumns);
            this.filterActionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterActionsPanel.Location = new System.Drawing.Point(4, 5);
            this.filterActionsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.filterActionsPanel.Name = "filterActionsPanel";
            this.filterActionsPanel.Size = new System.Drawing.Size(954, 35);
            this.filterActionsPanel.TabIndex = 351;
            // 
            // actionColumns
            // 
            this.actionColumns.ColumnCount = 1;
            this.actionColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.actionColumns.Controls.Add(this.actionButtonsFlow, 0, 0);
            this.actionColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionColumns.Location = new System.Drawing.Point(0, 0);
            this.actionColumns.Margin = new System.Windows.Forms.Padding(2);
            this.actionColumns.Name = "actionColumns";
            this.actionColumns.RowCount = 1;
            this.actionColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionColumns.Size = new System.Drawing.Size(954, 35);
            this.actionColumns.TabIndex = 0;
            // 
            // actionButtonsFlow
            // 
            this.actionButtonsFlow.AutoScroll = true;
            this.actionButtonsFlow.Controls.Add(this.toSettingsButton);
            this.actionButtonsFlow.Controls.Add(this.refreshAndClearButton);
            this.actionButtonsFlow.Controls.Add(this.buttonPause);
            this.actionButtonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtonsFlow.Location = new System.Drawing.Point(2, 2);
            this.actionButtonsFlow.Margin = new System.Windows.Forms.Padding(2);
            this.actionButtonsFlow.Name = "actionButtonsFlow";
            this.actionButtonsFlow.Padding = new System.Windows.Forms.Padding(2);
            this.actionButtonsFlow.Size = new System.Drawing.Size(950, 31);
            this.actionButtonsFlow.TabIndex = 0;
            this.actionButtonsFlow.WrapContents = false;
            // 
            // chartAndLegend
            // 
            this.chartAndLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAndLegend.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.chartAndLegend.Location = new System.Drawing.Point(4, 44);
            this.chartAndLegend.Margin = new System.Windows.Forms.Padding(2);
            this.chartAndLegend.Name = "chartAndLegend";
            // 
            // chartAndLegend.Panel1
            // 
            this.chartAndLegend.Panel1.Controls.Add(this.chartScrollPanel);
            this.chartAndLegend.Panel1MinSize = 180;
            // 
            // chartAndLegend.Panel2
            // 
            this.chartAndLegend.Panel2.Controls.Add(this.GradientChart);
            this.chartAndLegend.Panel2MinSize = 60;
            this.chartAndLegend.Size = new System.Drawing.Size(954, 486);
            this.chartAndLegend.SplitterDistance = 831;
            this.chartAndLegend.SplitterWidth = 3;
            this.chartAndLegend.TabIndex = 354;
            // 
            // chartScrollPanel
            // 
            this.chartScrollPanel.BackColor = System.Drawing.Color.Black;
            this.chartScrollPanel.Controls.Add(this.chart1);
            this.chartScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartScrollPanel.Location = new System.Drawing.Point(0, 0);
            this.chartScrollPanel.Margin = new System.Windows.Forms.Padding(2);
            this.chartScrollPanel.Name = "chartScrollPanel";
            this.chartScrollPanel.Size = new System.Drawing.Size(831, 486);
            this.chartScrollPanel.TabIndex = 350;
            // 
            // chartStatusLabel
            // 
            this.chartStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartStatusLabel.ForeColor = System.Drawing.Color.White;
            this.chartStatusLabel.Location = new System.Drawing.Point(4, 532);
            this.chartStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.chartStatusLabel.Name = "chartStatusLabel";
            this.chartStatusLabel.Size = new System.Drawing.Size(954, 17);
            this.chartStatusLabel.TabIndex = 355;
            this.chartStatusLabel.Text = "Live four-wheel telemetry  •  Chart Settings to change X / Y / Z and layout";
            this.chartStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form4Wheels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(962, 552);
            this.Controls.Add(this.mainLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(448, 372);
            this.Name = "Form4Wheels";
            this.Text = "Form4Wheels";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4Wheels_FormClosed);
            this.Load += new System.EventHandler(this.Form4Wheels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.filterActionsPanel.ResumeLayout(false);
            this.actionColumns.ResumeLayout(false);
            this.actionButtonsFlow.ResumeLayout(false);
            this.actionButtonsFlow.PerformLayout();
            this.chartAndLegend.Panel1.ResumeLayout(false);
            this.chartAndLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAndLegend)).EndInit();
            this.chartAndLegend.ResumeLayout(false);
            this.chartScrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshAndClearButton;
        private System.Windows.Forms.Button toSettingsButton;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonPause;
        public System.Windows.Forms.DataVisualization.Charting.Chart GradientChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel actionColumns;
        private System.Windows.Forms.FlowLayoutPanel actionButtonsFlow;
        private System.Windows.Forms.SplitContainer chartAndLegend;
        private System.Windows.Forms.Label chartStatusLabel;
        private System.Windows.Forms.Panel chartScrollPanel;
        private System.Windows.Forms.Panel filterActionsPanel;
    }
}
