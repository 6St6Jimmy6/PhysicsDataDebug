
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.refreshAndClearButton = new System.Windows.Forms.Button();
            this.toSettingsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GradientChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.labelUpDownChart = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshAndClearButton
            // 
            this.refreshAndClearButton.Location = new System.Drawing.Point(12, 42);
            this.refreshAndClearButton.Name = "refreshAndClearButton";
            this.refreshAndClearButton.Size = new System.Drawing.Size(65, 39);
            this.refreshAndClearButton.TabIndex = 294;
            this.refreshAndClearButton.Text = "Clear / Refresh";
            this.refreshAndClearButton.UseVisualStyleBackColor = true;
            this.refreshAndClearButton.Click += new System.EventHandler(this.refreshAndApplyButton_Click);
            // 
            // toSettingsButton
            // 
            this.toSettingsButton.Location = new System.Drawing.Point(12, 12);
            this.toSettingsButton.Name = "toSettingsButton";
            this.toSettingsButton.Size = new System.Drawing.Size(65, 23);
            this.toSettingsButton.TabIndex = 293;
            this.toSettingsButton.Text = "Settings";
            this.toSettingsButton.UseVisualStyleBackColor = true;
            this.toSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 704);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(65, 23);
            this.closeButton.TabIndex = 292;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(12, 87);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(65, 39);
            this.buttonPause.TabIndex = 299;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(286, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 300;
            this.label1.Text = "Front Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(646, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 301;
            this.label2.Text = "Front Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(286, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 302;
            this.label3.Text = "Rear Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(646, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 303;
            this.label4.Text = "Rear Right";
            // 
            // GradientChart
            // 
            this.GradientChart.BackColor = System.Drawing.Color.Transparent;
            chartArea11.AxisX.Interval = 1D;
            chartArea11.AxisX.LabelStyle.Enabled = false;
            chartArea11.AxisX.LineColor = System.Drawing.Color.Maroon;
            chartArea11.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea11.AxisX.MajorGrid.Enabled = false;
            chartArea11.AxisX.MajorGrid.Interval = 1D;
            chartArea11.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea11.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea11.AxisX.MajorTickMark.Enabled = false;
            chartArea11.AxisX.MajorTickMark.Interval = 1D;
            chartArea11.AxisX.Maximum = 1D;
            chartArea11.AxisX.Minimum = 0D;
            chartArea11.AxisX.Title = "phat";
            chartArea11.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            chartArea11.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea11.AxisX2.Title = "jou";
            chartArea11.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea11.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea11.AxisY.Interval = 1D;
            chartArea11.AxisY.IsLabelAutoFit = false;
            chartArea11.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea11.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea11.AxisY.MajorGrid.Interval = 1D;
            chartArea11.AxisY.MajorTickMark.Enabled = false;
            chartArea11.AxisY.Maximum = 10D;
            chartArea11.AxisY.Minimum = -10D;
            chartArea11.BackColor = System.Drawing.Color.Transparent;
            chartArea11.Name = "ChartArea1";
            this.GradientChart.ChartAreas.Add(chartArea11);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.GradientChart.Legends.Add(legend5);
            this.GradientChart.Location = new System.Drawing.Point(12, 129);
            this.GradientChart.Margin = new System.Windows.Forms.Padding(0);
            this.GradientChart.Name = "GradientChart";
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Red;
            series11.LabelForeColor = System.Drawing.Color.White;
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            dataPoint5.IsValueShownAsLabel = false;
            dataPoint5.LabelForeColor = System.Drawing.Color.White;
            series11.Points.Add(dataPoint5);
            series11.Points.Add(dataPoint6);
            this.GradientChart.Series.Add(series11);
            this.GradientChart.Size = new System.Drawing.Size(68, 440);
            this.GradientChart.TabIndex = 304;
            this.GradientChart.Text = "chart5";
            title3.ForeColor = System.Drawing.Color.Transparent;
            title3.Name = "Title1";
            title3.Text = "jou";
            this.GradientChart.Titles.Add(title3);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(421, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 306;
            this.label5.Text = "All Wheels In One Chart";
            // 
            // labelUpDownChart
            // 
            this.labelUpDownChart.ForeColor = System.Drawing.Color.White;
            this.labelUpDownChart.Location = new System.Drawing.Point(12, 138);
            this.labelUpDownChart.Name = "labelUpDownChart";
            this.labelUpDownChart.Size = new System.Drawing.Size(65, 31);
            this.labelUpDownChart.TabIndex = 307;
            this.labelUpDownChart.Text = "Z axis selection";
            // 
            // chart1
            // 
            chartArea12.AxisX.Title = "X1 1";
            chartArea12.AxisX2.Title = "X2";
            chartArea12.AxisY.Title = "Y1 1";
            chartArea12.AxisY2.Title = "Y2";
            chartArea12.Name = "ChartArea1";
            chartArea13.AxisX.Title = "X1 2";
            chartArea13.AxisY.Title = "Y1 2";
            chartArea13.Name = "ChartArea2";
            chartArea14.AxisX.Title = "X1 3";
            chartArea14.AxisY.Title = "Y1 3";
            chartArea14.Name = "ChartArea3";
            chartArea15.AxisX.Title = "X1 4";
            chartArea15.AxisY.Title = "Y1 4";
            chartArea15.Name = "ChartArea4";
            this.chart1.ChartAreas.Add(chartArea12);
            this.chart1.ChartAreas.Add(chartArea13);
            this.chart1.ChartAreas.Add(chartArea14);
            this.chart1.ChartAreas.Add(chartArea15);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(87, 12);
            this.chart1.Name = "chart1";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            series13.ChartArea = "ChartArea2";
            series13.Legend = "Legend1";
            series13.Name = "Series2";
            series14.ChartArea = "ChartArea3";
            series14.Legend = "Legend1";
            series14.Name = "Series3";
            series15.ChartArea = "ChartArea4";
            series15.Legend = "Legend1";
            series15.Name = "Series4";
            this.chart1.Series.Add(series12);
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Size = new System.Drawing.Size(750, 750);
            this.chart1.TabIndex = 308;
            this.chart1.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(95, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 309;
            this.label6.Text = "Front Tires";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(95, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 310;
            this.label7.Text = "Rear Tires";
            // 
            // Form4Wheels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1042, 751);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelUpDownChart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GradientChart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.refreshAndClearButton);
            this.Controls.Add(this.toSettingsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.chart1);
            this.Name = "Form4Wheels";
            this.Text = "Form4Wheels";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4Wheels_FormClosed);
            this.Load += new System.EventHandler(this.Form4Wheels_Load);
            this.SizeChanged += new System.EventHandler(this.Form4Wheels_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshAndClearButton;
        private System.Windows.Forms.Button toSettingsButton;
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataVisualization.Charting.Chart GradientChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelUpDownChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}