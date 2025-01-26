
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
            this.textBox_FL_InnerTemperature = new System.Windows.Forms.TextBox();
            this.textBox_FL_TreadTemperature = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_FR_InnerTemperature = new System.Windows.Forms.TextBox();
            this.textBox_FR_TreadTemperature = new System.Windows.Forms.TextBox();
            this.textBox_RL_InnerTemperature = new System.Windows.Forms.TextBox();
            this.textBox_RL_TreadTemperature = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox_RR_InnerTemperature = new System.Windows.Forms.TextBox();
            this.textBox_RR_TreadTemperature = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.chartRR.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
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
            this.chartRR.Size = new System.Drawing.Size(314, 228);
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
            this.chartRL.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
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
            this.chartRL.Size = new System.Drawing.Size(314, 228);
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
            this.chartFR.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
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
            this.chartFR.Size = new System.Drawing.Size(314, 228);
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
            this.chartFL.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
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
            this.chartFL.Size = new System.Drawing.Size(314, 228);
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
            // textBox_FL_InnerTemperature
            // 
            this.textBox_FL_InnerTemperature.Location = new System.Drawing.Point(133, 289);
            this.textBox_FL_InnerTemperature.Name = "textBox_FL_InnerTemperature";
            this.textBox_FL_InnerTemperature.ReadOnly = true;
            this.textBox_FL_InnerTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_FL_InnerTemperature.TabIndex = 177;
            this.textBox_FL_InnerTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_FL_TreadTemperature
            // 
            this.textBox_FL_TreadTemperature.Location = new System.Drawing.Point(51, 289);
            this.textBox_FL_TreadTemperature.Name = "textBox_FL_TreadTemperature";
            this.textBox_FL_TreadTemperature.ReadOnly = true;
            this.textBox_FL_TreadTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_FL_TreadTemperature.TabIndex = 176;
            this.textBox_FL_TreadTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 273);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(126, 13);
            this.label18.TabIndex = 178;
            this.label18.Text = "Tread °C             Inner °C";
            // 
            // textBox_FR_InnerTemperature
            // 
            this.textBox_FR_InnerTemperature.Location = new System.Drawing.Point(454, 289);
            this.textBox_FR_InnerTemperature.Name = "textBox_FR_InnerTemperature";
            this.textBox_FR_InnerTemperature.ReadOnly = true;
            this.textBox_FR_InnerTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_FR_InnerTemperature.TabIndex = 192;
            this.textBox_FR_InnerTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_FR_TreadTemperature
            // 
            this.textBox_FR_TreadTemperature.Location = new System.Drawing.Point(372, 289);
            this.textBox_FR_TreadTemperature.Name = "textBox_FR_TreadTemperature";
            this.textBox_FR_TreadTemperature.ReadOnly = true;
            this.textBox_FR_TreadTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_FR_TreadTemperature.TabIndex = 191;
            this.textBox_FR_TreadTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_RL_InnerTemperature
            // 
            this.textBox_RL_InnerTemperature.Location = new System.Drawing.Point(133, 562);
            this.textBox_RL_InnerTemperature.Name = "textBox_RL_InnerTemperature";
            this.textBox_RL_InnerTemperature.ReadOnly = true;
            this.textBox_RL_InnerTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_RL_InnerTemperature.TabIndex = 207;
            this.textBox_RL_InnerTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_RL_TreadTemperature
            // 
            this.textBox_RL_TreadTemperature.Location = new System.Drawing.Point(51, 562);
            this.textBox_RL_TreadTemperature.Name = "textBox_RL_TreadTemperature";
            this.textBox_RL_TreadTemperature.ReadOnly = true;
            this.textBox_RL_TreadTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_RL_TreadTemperature.TabIndex = 206;
            this.textBox_RL_TreadTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(48, 546);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(126, 13);
            this.label36.TabIndex = 208;
            this.label36.Text = "Tread °C             Inner °C";
            // 
            // textBox_RR_InnerTemperature
            // 
            this.textBox_RR_InnerTemperature.Location = new System.Drawing.Point(454, 562);
            this.textBox_RR_InnerTemperature.Name = "textBox_RR_InnerTemperature";
            this.textBox_RR_InnerTemperature.ReadOnly = true;
            this.textBox_RR_InnerTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_RR_InnerTemperature.TabIndex = 222;
            this.textBox_RR_InnerTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_RR_TreadTemperature
            // 
            this.textBox_RR_TreadTemperature.Location = new System.Drawing.Point(372, 562);
            this.textBox_RR_TreadTemperature.Name = "textBox_RR_TreadTemperature";
            this.textBox_RR_TreadTemperature.ReadOnly = true;
            this.textBox_RR_TreadTemperature.Size = new System.Drawing.Size(76, 20);
            this.textBox_RR_TreadTemperature.TabIndex = 221;
            this.textBox_RR_TreadTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(369, 546);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(126, 13);
            this.label51.TabIndex = 223;
            this.label51.Text = "Tread °C             Inner °C";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 224;
            this.label1.Text = "Tread °C             Inner °C";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(133, 14);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 225;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Visible = false;
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
            this.stopButton.Visible = false;
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_RR_InnerTemperature);
            this.Controls.Add(this.textBox_RR_TreadTemperature);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.textBox_RL_InnerTemperature);
            this.Controls.Add(this.textBox_RL_TreadTemperature);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.textBox_FR_InnerTemperature);
            this.Controls.Add(this.textBox_FR_TreadTemperature);
            this.Controls.Add(this.textBox_FL_InnerTemperature);
            this.Controls.Add(this.textBox_FL_TreadTemperature);
            this.Controls.Add(this.label18);
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
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chartRR;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartRL;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartFR;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartFL;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox textBox_FL_InnerTemperature;
        private System.Windows.Forms.TextBox textBox_FL_TreadTemperature;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_FR_InnerTemperature;
        private System.Windows.Forms.TextBox textBox_FR_TreadTemperature;
        private System.Windows.Forms.TextBox textBox_RL_InnerTemperature;
        private System.Windows.Forms.TextBox textBox_RL_TreadTemperature;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBox_RR_InnerTemperature;
        private System.Windows.Forms.TextBox textBox_RR_TreadTemperature;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Timer timer1;
    }
}