
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.actionButtonsFlow.SuspendLayout();
            this.chartAndBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.Interval = 90D;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorGrid.Interval = 90D;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.Maximum = 360D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.Interval = 2D;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LabelStyle.Interval = 2D;
            chartArea3.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea3.AxisY.LineColor = System.Drawing.Color.Maroon;
            chartArea3.AxisY.MajorGrid.Interval = 1D;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorTickMark.Size = 2F;
            chartArea3.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea3.AxisY.Maximum = 7D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.BorderColor = System.Drawing.Color.Maroon;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.Enabled = false;
            legend3.ForeColor = System.Drawing.Color.White;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            legend3.Position.Auto = false;
            legend3.Position.Height = 8.026756F;
            legend3.Position.Width = 29.43144F;
            legend3.Position.X = 67.56856F;
            legend3.Position.Y = 10.4837F;
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.MinimumSize = new System.Drawing.Size(5, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series3.Color = System.Drawing.Color.Transparent;
            series3.CustomProperties = "LabelStyle=Right";
            series3.LabelBackColor = System.Drawing.Color.Black;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.MarkerBorderWidth = 0;
            series3.MarkerColor = System.Drawing.Color.Maroon;
            series3.MarkerSize = 3;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Series1";
            series3.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series3.SmartLabelStyle.Enabled = false;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(486, 378);
            this.chart1.TabIndex = 288;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.Interval = 1D;
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.LineColor = System.Drawing.Color.Maroon;
            chartArea4.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorGrid.Interval = 1D;
            chartArea4.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Interval = 1D;
            chartArea4.AxisX.Maximum = 1D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.Title = "phat";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Arial", 26F);
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX2.Title = "jou";
            chartArea4.AxisX2.TitleFont = new System.Drawing.Font("Arial", 10F);
            chartArea4.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.Interval = 1D;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisY.MajorGrid.Interval = 1D;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.AxisY.Maximum = 10D;
            chartArea4.AxisY.Minimum = -10D;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(486, 0);
            this.chart2.Margin = new System.Windows.Forms.Padding(0);
            this.chart2.MinimumSize = new System.Drawing.Size(5, 5);
            this.chart2.Name = "chart2";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(60, 378);
            this.chart2.TabIndex = 289;
            this.chart2.Text = "chart2";
            title2.ForeColor = System.Drawing.Color.Transparent;
            title2.Name = "Title1";
            title2.Text = "jou";
            this.chart2.Titles.Add(title2);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // toSettingsButton
            // 
            this.toSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.toSettingsButton.ForeColor = System.Drawing.Color.White;
            this.toSettingsButton.Location = new System.Drawing.Point(5, 4);
            this.toSettingsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toSettingsButton.Name = "toSettingsButton";
            this.toSettingsButton.Size = new System.Drawing.Size(95, 23);
            this.toSettingsButton.TabIndex = 290;
            this.toSettingsButton.Text = "Settings";
            this.toSettingsButton.UseVisualStyleBackColor = false;
            this.toSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // refreshAndClearButton
            // 
            this.refreshAndClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.refreshAndClearButton.ForeColor = System.Drawing.Color.White;
            this.refreshAndClearButton.Location = new System.Drawing.Point(106, 4);
            this.refreshAndClearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshAndClearButton.Name = "refreshAndClearButton";
            this.refreshAndClearButton.Size = new System.Drawing.Size(112, 23);
            this.refreshAndClearButton.TabIndex = 291;
            this.refreshAndClearButton.Text = "Clear Charts";
            this.refreshAndClearButton.UseVisualStyleBackColor = false;
            this.refreshAndClearButton.Click += new System.EventHandler(this.refreshAndApplyButton_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.Black;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.toolbarPanel, 0, 0);
            this.mainLayout.Controls.Add(this.chartAndBar, 0, 1);
            this.mainLayout.Controls.Add(this.chartStatusLabel, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.mainLayout.Size = new System.Drawing.Size(550, 440);
            this.mainLayout.TabIndex = 0;
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.toolbarPanel.Controls.Add(this.actionButtonsFlow);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarPanel.Location = new System.Drawing.Point(4, 5);
            this.toolbarPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(542, 35);
            this.toolbarPanel.TabIndex = 0;
            // 
            // actionButtonsFlow
            // 
            this.actionButtonsFlow.AutoScroll = true;
            this.actionButtonsFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.actionButtonsFlow.Controls.Add(this.toSettingsButton);
            this.actionButtonsFlow.Controls.Add(this.refreshAndClearButton);
            this.actionButtonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtonsFlow.Location = new System.Drawing.Point(0, 0);
            this.actionButtonsFlow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.actionButtonsFlow.Name = "actionButtonsFlow";
            this.actionButtonsFlow.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.actionButtonsFlow.Size = new System.Drawing.Size(542, 35);
            this.actionButtonsFlow.TabIndex = 0;
            this.actionButtonsFlow.WrapContents = false;
            // 
            // chartAndBar
            // 
            this.chartAndBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.chartAndBar.ColumnCount = 2;
            this.chartAndBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartAndBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.chartAndBar.Controls.Add(this.chart1, 0, 0);
            this.chartAndBar.Controls.Add(this.chart2, 1, 0);
            this.chartAndBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAndBar.Location = new System.Drawing.Point(2, 42);
            this.chartAndBar.Margin = new System.Windows.Forms.Padding(0);
            this.chartAndBar.Name = "chartAndBar";
            this.chartAndBar.RowCount = 1;
            this.chartAndBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartAndBar.Size = new System.Drawing.Size(546, 378);
            this.chartAndBar.TabIndex = 1;
            // 
            // chartStatusLabel
            // 
            this.chartStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartStatusLabel.ForeColor = System.Drawing.Color.White;
            this.chartStatusLabel.Location = new System.Drawing.Point(4, 420);
            this.chartStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.chartStatusLabel.Name = "chartStatusLabel";
            this.chartStatusLabel.Size = new System.Drawing.Size(542, 17);
            this.chartStatusLabel.TabIndex = 2;
            this.chartStatusLabel.Text = "G-force telemetry  •  Polar G-force and vertical acceleration";
            this.chartStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(550, 440);
            this.Controls.Add(this.mainLayout);
            this.MinimumSize = new System.Drawing.Size(328, 268);
            this.Name = "FormGForce";
            this.Text = "FormGForce";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGForce_FormClosed);
            this.Load += new System.EventHandler(this.FormGForce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.toolbarPanel.ResumeLayout(false);
            this.actionButtonsFlow.ResumeLayout(false);
            this.chartAndBar.ResumeLayout(false);
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