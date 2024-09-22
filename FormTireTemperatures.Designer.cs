
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.temperaturesRR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.temperaturesRL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.temperaturesFR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.temperaturesFL = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesRR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesRL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesFL)).BeginInit();
            this.SuspendLayout();
            // 
            // temperaturesRR
            // 
            this.temperaturesRR.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.temperaturesRR.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.temperaturesRR.Legends.Add(legend5);
            this.temperaturesRR.Location = new System.Drawing.Point(333, 315);
            this.temperaturesRR.Name = "temperaturesRR";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Tread °C";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Inner °C";
            this.temperaturesRR.Series.Add(series9);
            this.temperaturesRR.Series.Add(series10);
            this.temperaturesRR.Size = new System.Drawing.Size(314, 228);
            this.temperaturesRR.TabIndex = 10;
            this.temperaturesRR.Text = "chart1";
            title5.Name = "RRTempTitle";
            title5.Text = "Rear Right Temperatures";
            this.temperaturesRR.Titles.Add(title5);
            // 
            // temperaturesRL
            // 
            this.temperaturesRL.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            this.temperaturesRL.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.temperaturesRL.Legends.Add(legend6);
            this.temperaturesRL.Location = new System.Drawing.Point(13, 315);
            this.temperaturesRL.Name = "temperaturesRL";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.Name = "Tread °C";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Inner °C";
            this.temperaturesRL.Series.Add(series11);
            this.temperaturesRL.Series.Add(series12);
            this.temperaturesRL.Size = new System.Drawing.Size(314, 228);
            this.temperaturesRL.TabIndex = 9;
            this.temperaturesRL.Text = "chart1";
            title6.Name = "RLTempTitle";
            title6.Text = "Rear Left Temperatures";
            this.temperaturesRL.Titles.Add(title6);
            // 
            // temperaturesFR
            // 
            this.temperaturesFR.BackColor = System.Drawing.Color.Transparent;
            chartArea7.Name = "ChartArea1";
            this.temperaturesFR.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.temperaturesFR.Legends.Add(legend7);
            this.temperaturesFR.Location = new System.Drawing.Point(333, 42);
            this.temperaturesFR.Name = "temperaturesFR";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series13.Legend = "Legend1";
            series13.Name = "Tread °C";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series14.Legend = "Legend1";
            series14.Name = "Inner °C";
            this.temperaturesFR.Series.Add(series13);
            this.temperaturesFR.Series.Add(series14);
            this.temperaturesFR.Size = new System.Drawing.Size(314, 228);
            this.temperaturesFR.TabIndex = 8;
            this.temperaturesFR.Text = "chart1";
            title7.Name = "FRTempTitle";
            title7.Text = "Front Right Temperatures";
            this.temperaturesFR.Titles.Add(title7);
            // 
            // temperaturesFL
            // 
            this.temperaturesFL.BackColor = System.Drawing.Color.Transparent;
            chartArea8.Name = "ChartArea1";
            this.temperaturesFL.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.temperaturesFL.Legends.Add(legend8);
            this.temperaturesFL.Location = new System.Drawing.Point(13, 42);
            this.temperaturesFL.Name = "temperaturesFL";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Legend = "Legend1";
            series15.Name = "Tread °C";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series16.Legend = "Legend1";
            series16.Name = "Inner °C";
            this.temperaturesFL.Series.Add(series15);
            this.temperaturesFL.Series.Add(series16);
            this.temperaturesFL.Size = new System.Drawing.Size(314, 228);
            this.temperaturesFL.TabIndex = 7;
            this.temperaturesFL.Text = "chart1";
            title8.Name = "FLTempTitle";
            title8.Text = "Front Left Temperatures";
            this.temperaturesFL.Titles.Add(title8);
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
            // TireTemperatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.temperaturesRR);
            this.Controls.Add(this.temperaturesRL);
            this.Controls.Add(this.temperaturesFR);
            this.Controls.Add(this.temperaturesFL);
            this.Name = "TireTemperatures";
            this.Text = "TireTemperatures";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TireTemperatures_FormClosing);
            this.Load += new System.EventHandler(this.TireTemperatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesRR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesRL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperaturesFL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart temperaturesRR;
        public System.Windows.Forms.DataVisualization.Charting.Chart temperaturesRL;
        public System.Windows.Forms.DataVisualization.Charting.Chart temperaturesFR;
        public System.Windows.Forms.DataVisualization.Charting.Chart temperaturesFL;
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
    }
}