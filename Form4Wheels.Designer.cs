
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
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
            chartArea7.AxisX.Interval = 1D;
            chartArea7.AxisX.LabelStyle.Enabled = false;
            chartArea7.AxisX.LineColor = System.Drawing.Color.Maroon;
            chartArea7.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea7.AxisX.MajorGrid.Enabled = false;
            chartArea7.AxisX.MajorGrid.Interval = 1D;
            chartArea7.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea7.AxisX.MajorTickMark.Enabled = false;
            chartArea7.AxisX.MajorTickMark.Interval = 1D;
            chartArea7.AxisX.Maximum = 1D;
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.AxisX.Title = "phat";
            chartArea7.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            chartArea7.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea7.AxisX2.Title = "jou";
            chartArea7.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea7.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.Interval = 1D;
            chartArea7.AxisY.IsLabelAutoFit = false;
            chartArea7.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea7.AxisY.MajorGrid.Interval = 1D;
            chartArea7.AxisY.MajorTickMark.Enabled = false;
            chartArea7.AxisY.Maximum = 10D;
            chartArea7.AxisY.Minimum = -10D;
            chartArea7.BackColor = System.Drawing.Color.Transparent;
            chartArea7.Name = "ChartArea1";
            this.GradientChart.ChartAreas.Add(chartArea7);
            this.GradientChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.GradientChart.Legends.Add(legend5);
            this.GradientChart.Location = new System.Drawing.Point(0, 0);
            this.GradientChart.Margin = new System.Windows.Forms.Padding(0);
            this.GradientChart.MinimumSize = new System.Drawing.Size(5, 5);
            this.GradientChart.Name = "GradientChart";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            dataPoint5.IsValueShownAsLabel = false;
            dataPoint5.LabelForeColor = System.Drawing.Color.White;
            series3.Points.Add(dataPoint5);
            series3.Points.Add(dataPoint6);
            this.GradientChart.Series.Add(series3);
            this.GradientChart.Size = new System.Drawing.Size(121, 486);
            this.GradientChart.TabIndex = 304;
            this.GradientChart.Text = "chart5";
            title7.ForeColor = System.Drawing.Color.White;
            title7.Name = "ZColorHeading";
            title7.Text = "Z axis";
            this.GradientChart.Titles.Add(title7);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea8.AxisX.LabelStyle.Enabled = false;
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.Title = "X1 1";
            chartArea8.AxisX2.Title = "X2";
            chartArea8.AxisY.LabelStyle.Enabled = false;
            chartArea8.AxisY.MajorGrid.Enabled = false;
            chartArea8.AxisY.Title = "Y1 1";
            chartArea8.AxisY2.Title = "Y2";
            chartArea8.BackColor = System.Drawing.Color.Black;
            chartArea8.Name = "ChartArea1";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 50F;
            chartArea8.Position.Width = 100F;
            chartArea9.AxisX.LabelStyle.Enabled = false;
            chartArea9.AxisX.MajorGrid.Enabled = false;
            chartArea9.AxisX.Title = "X1 2";
            chartArea9.AxisY.LabelStyle.Enabled = false;
            chartArea9.AxisY.MajorGrid.Enabled = false;
            chartArea9.AxisY.Title = "Y1 2";
            chartArea9.BackColor = System.Drawing.Color.Black;
            chartArea9.Name = "ChartArea2";
            chartArea9.Position.Auto = false;
            chartArea9.Position.Height = 50F;
            chartArea9.Position.Width = 100F;
            chartArea9.Position.Y = 50F;
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.ChartAreas.Add(chartArea9);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.MinimumSize = new System.Drawing.Size(5, 5);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(830, 486);
            this.chart1.TabIndex = 308;
            this.chart1.Text = "chart1";
            title8.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title8.DockedToChartArea = "ChartArea1";
            title8.ForeColor = System.Drawing.Color.White;
            title8.Name = "Title1";
            title8.Text = "Front Tires";
            title9.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title9.DockedToChartArea = "ChartArea2";
            title9.ForeColor = System.Drawing.Color.White;
            title9.Name = "Title2";
            title9.Text = "Rear Tires";
            this.chart1.Titles.Add(title8);
            this.chart1.Titles.Add(title9);
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
            this.actionButtonsFlow.Controls.Add(this.SettingsProfilesHost);
            this.actionButtonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtonsFlow.Location = new System.Drawing.Point(2, 2);
            this.actionButtonsFlow.Margin = new System.Windows.Forms.Padding(2);
            this.actionButtonsFlow.Name = "actionButtonsFlow";
            this.actionButtonsFlow.Padding = new System.Windows.Forms.Padding(2);
            this.actionButtonsFlow.Size = new System.Drawing.Size(950, 31);
            this.actionButtonsFlow.TabIndex = 0;
            this.actionButtonsFlow.WrapContents = false;
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsProfilesHost.Location = new System.Drawing.Point(257, 2);
            this.SettingsProfilesHost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Size = new System.Drawing.Size(146, 26);
            this.SettingsProfilesHost.TabIndex = 1;
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
            this.chartAndLegend.SplitterDistance = 830;
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
            this.chartScrollPanel.Size = new System.Drawing.Size(830, 486);
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
        private System.Windows.Forms.Panel SettingsProfilesHost;
    }
}
