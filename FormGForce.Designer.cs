
namespace Physics_Data_Debug
{
    partial class FormGForce
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toSettingsButton = new System.Windows.Forms.Button();
            this.refreshAndClearButton = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.actionButtonsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.chartAndBar = new System.Windows.Forms.TableLayoutPanel();
            this.chartStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.actionButtonsFlow.SuspendLayout();
            this.chartAndBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 90D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.Interval = 90D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Maximum = 360D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.Interval = 2D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.Interval = 2D;
            chartArea1.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Maroon;
            chartArea1.AxisY.MajorGrid.Interval = 1D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.Size = 2F;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Maximum = 7D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.Maroon;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 8.026756F;
            legend1.Position.Width = 29.43144F;
            legend1.Position.X = 67.56856F;
            legend1.Position.Y = 10.4837F;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.MinimumSize = new System.Drawing.Size(10, 10);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series1.Color = System.Drawing.Color.Transparent;
            series1.CustomProperties = "LabelStyle=Right";
            series1.LabelBackColor = System.Drawing.Color.Black;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 0;
            series1.MarkerColor = System.Drawing.Color.Maroon;
            series1.MarkerSize = 3;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series1.SmartLabelStyle.Enabled = false;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(880, 846);
            this.chart1.TabIndex = 288;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Maroon;
            chartArea2.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorGrid.Interval = 1D;
            chartArea2.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Interval = 1D;
            chartArea2.AxisX.Maximum = 1D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "phat";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Arial", 26F);
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX2.Title = "jou";
            chartArea2.AxisX2.TitleFont = new System.Drawing.Font("Arial", 10F);
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.Interval = 1D;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisY.MajorGrid.Interval = 1D;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.Maximum = 10D;
            chartArea2.AxisY.Minimum = -10D;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.MinimumSize = new System.Drawing.Size(10, 10);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Margin = new System.Windows.Forms.Padding(0);
            this.chart2.Name = "chart2";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(72, 846);
            this.chart2.TabIndex = 289;
            this.chart2.Text = "chart2";
            title1.ForeColor = System.Drawing.Color.Transparent;
            title1.Name = "Title1";
            title1.Text = "jou";
            this.chart2.Titles.Add(title1);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // toSettingsButton
            // 
            this.toSettingsButton.Location = new System.Drawing.Point(0, 0);
            this.toSettingsButton.Name = "toSettingsButton";
            this.toSettingsButton.Size = new System.Drawing.Size(190, 44);
            this.toSettingsButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.toSettingsButton.UseVisualStyleBackColor = false;
            this.toSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.toSettingsButton.ForeColor = System.Drawing.Color.White;
            this.toSettingsButton.TabIndex = 290;
            this.toSettingsButton.Text = "Settings";
            this.toSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // refreshAndClearButton
            // 
            this.refreshAndClearButton.Location = new System.Drawing.Point(0, 58);
            this.refreshAndClearButton.Name = "refreshAndClearButton";
            this.refreshAndClearButton.Size = new System.Drawing.Size(225, 44);
            this.refreshAndClearButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.refreshAndClearButton.UseVisualStyleBackColor = false;
            this.refreshAndClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.refreshAndClearButton.ForeColor = System.Drawing.Color.White;
            this.refreshAndClearButton.TabIndex = 291;
            this.refreshAndClearButton.Text = "Clear Charts";
            this.refreshAndClearButton.Click += new System.EventHandler(this.refreshAndApplyButton_Click);
            // 
            // mainLayout - same chart-first structure as Form4Wheels; no limiter rows.
            //
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.BackColor = System.Drawing.Color.Black;
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayout.Padding = new System.Windows.Forms.Padding(5);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Controls.Add(this.toolbarPanel, 0, 0);
            this.mainLayout.Controls.Add(this.chartAndBar, 0, 1);
            this.mainLayout.Controls.Add(this.chartStatusLabel, 0, 2);
            // toolbarPanel
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarPanel.Controls.Add(this.actionButtonsFlow);
            // actionButtonsFlow
            this.actionButtonsFlow.Name = "actionButtonsFlow";
            this.actionButtonsFlow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.actionButtonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtonsFlow.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.actionButtonsFlow.WrapContents = false;
            this.actionButtonsFlow.AutoScroll = true;
            this.actionButtonsFlow.Controls.Add(this.toSettingsButton);
            this.actionButtonsFlow.Controls.Add(this.refreshAndClearButton);
            // chartAndBar
            this.chartAndBar.Name = "chartAndBar";
            this.chartAndBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAndBar.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            // A fixed-width TableLayoutPanel avoids the SplitContainer's stale
            // SplitterDistance being scaled with the form (which made chart2 huge).
            // The 72-pixel right column is 40% narrower than the 120px Four Wheels legend.
            // Editable directly in Visual Studio Designer under chartAndBar.
            this.chartAndBar.ColumnCount = 2;
            this.chartAndBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartAndBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.chartAndBar.RowCount = 1;
            this.chartAndBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartAndBar.Margin = new System.Windows.Forms.Padding(0);
            this.chartAndBar.Padding = new System.Windows.Forms.Padding(0);
            this.chartAndBar.Controls.Add(this.chart1, 0, 0);
            this.chartAndBar.Controls.Add(this.chart2, 1, 0);
            // chartStatusLabel
            this.chartStatusLabel.Name = "chartStatusLabel";
            this.chartStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartStatusLabel.ForeColor = System.Drawing.Color.White;
            this.chartStatusLabel.Text = "G-force telemetry  •  Polar G-force and vertical acceleration";
            this.chartStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // FormGForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1100, 846);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.mainLayout);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormGForce";
            this.Text = "FormGForce";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGForce_FormClosed);
            this.Load += new System.EventHandler(this.FormGForce_Load);
            // Layout is maintained by the designer-owned TableLayoutPanel and SplitContainer.
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.toolbarPanel.ResumeLayout(false);
            this.actionButtonsFlow.ResumeLayout(false);
            this.chartAndBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button toSettingsButton;
        private System.Windows.Forms.Button refreshAndClearButton;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.FlowLayoutPanel actionButtonsFlow;
        private System.Windows.Forms.TableLayoutPanel chartAndBar;
        private System.Windows.Forms.Label chartStatusLabel;
    }
}