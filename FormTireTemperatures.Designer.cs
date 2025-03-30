
namespace Physics_Data_Debug
{
    partial class FormTireTemperatures
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartRR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.closeButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartRR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFL)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRR
            // 
            this.chartRR.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 75F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 5F;
            this.chartRR.ChartAreas.Add(chartArea1);
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 10F;
            legend1.Position.Width = 80F;
            legend1.Position.X = 10F;
            legend1.Position.Y = 90F;
            this.chartRR.Legends.Add(legend1);
            this.chartRR.Location = new System.Drawing.Point(333, 315);
            this.chartRR.Name = "chartRR";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Tread °C";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Inner °C";
            this.chartRR.Series.Add(series1);
            this.chartRR.Series.Add(series2);
            this.chartRR.Size = new System.Drawing.Size(314, 261);
            this.chartRR.TabIndex = 10;
            this.chartRR.Text = "chart1";
            title1.Name = "RRTempTitle";
            title1.Text = "Rear Right Temperatures";
            this.chartRR.Titles.Add(title1);
            // 
            // chartRL
            // 
            this.chartRL.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 75F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 5F;
            this.chartRL.ChartAreas.Add(chartArea2);
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 10F;
            legend2.Position.Width = 80F;
            legend2.Position.X = 10F;
            legend2.Position.Y = 90F;
            this.chartRL.Legends.Add(legend2);
            this.chartRL.Location = new System.Drawing.Point(13, 315);
            this.chartRL.Name = "chartRL";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Tread °C";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Inner °C";
            this.chartRL.Series.Add(series3);
            this.chartRL.Series.Add(series4);
            this.chartRL.Size = new System.Drawing.Size(314, 261);
            this.chartRL.TabIndex = 9;
            this.chartRL.Text = "chart1";
            title2.Name = "RLTempTitle";
            title2.Text = "Rear Left Temperatures";
            this.chartRL.Titles.Add(title2);
            // 
            // chartFR
            // 
            this.chartFR.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 80F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Y = 5F;
            this.chartFR.ChartAreas.Add(chartArea3);
            legend3.IsTextAutoFit = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend3.Name = "Legend1";
            legend3.Position.Auto = false;
            legend3.Position.Height = 10F;
            legend3.Position.Width = 80F;
            legend3.Position.X = 10F;
            legend3.Position.Y = 90F;
            this.chartFR.Legends.Add(legend3);
            this.chartFR.Location = new System.Drawing.Point(333, 42);
            this.chartFR.Name = "chartFR";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "Tread °C";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Inner °C";
            this.chartFR.Series.Add(series5);
            this.chartFR.Series.Add(series6);
            this.chartFR.Size = new System.Drawing.Size(314, 267);
            this.chartFR.TabIndex = 8;
            this.chartFR.Text = "chart1";
            title3.Name = "FRTempTitle";
            title3.Text = "Front Right Temperatures";
            this.chartFR.Titles.Add(title3);
            // 
            // chartFL
            // 
            this.chartFL.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 80F;
            chartArea4.Position.Width = 100F;
            chartArea4.Position.Y = 5F;
            this.chartFL.ChartAreas.Add(chartArea4);
            legend4.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend4.Name = "Legend1";
            legend4.Position.Auto = false;
            legend4.Position.Height = 10F;
            legend4.Position.Width = 80F;
            legend4.Position.X = 10F;
            legend4.Position.Y = 90F;
            this.chartFL.Legends.Add(legend4);
            this.chartFL.Location = new System.Drawing.Point(13, 42);
            this.chartFL.Name = "chartFL";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "Tread °C";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Inner °C";
            this.chartFL.Series.Add(series7);
            this.chartFL.Series.Add(series8);
            this.chartFL.Size = new System.Drawing.Size(314, 261);
            this.chartFL.TabIndex = 7;
            this.chartFL.Text = "chart1";
            title4.Name = "FLTempTitle";
            title4.Text = "Front Left Temperatures";
            this.chartFL.Titles.Add(title4);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(13, 13);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 25);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(133, 14);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 225;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(214, 15);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 226;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 94;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTireTemperatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(657, 588);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.chartRR);
            this.Controls.Add(this.chartRL);
            this.Controls.Add(this.chartFR);
            this.Controls.Add(this.chartFL);
            this.Name = "FormTireTemperatures";
            this.Text = "TireTemperatures";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TireTemperatures_FormClosing);
            this.Load += new System.EventHandler(this.TireTemperatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chartRR;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartRL;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartFR;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartFL;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.Timer timer1;
    }
}