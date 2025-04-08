
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea91 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend37 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series91 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint37 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint38 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.5D);
            System.Windows.Forms.DataVisualization.Charting.Title title19 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea92 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea93 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea94 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea95 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend38 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series92 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series93 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series94 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series95 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.refreshAndClearButton = new System.Windows.Forms.Button();
            this.toSettingsButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.xMinLimitTextBox = new System.Windows.Forms.TextBox();
            this.xMaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.yMaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.yMinLimitTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.zMaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.zMinLimitTextBox = new System.Windows.Forms.TextBox();
            this.enableLimitersCheckBox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.xLimiterComboBox = new System.Windows.Forms.ComboBox();
            this.yLimiterComboBox = new System.Windows.Forms.ComboBox();
            this.zLimiterComboBox = new System.Windows.Forms.ComboBox();
            this.customChoiceCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshAndClearButton
            // 
            this.refreshAndClearButton.Location = new System.Drawing.Point(9, 42);
            this.refreshAndClearButton.Name = "refreshAndClearButton";
            this.refreshAndClearButton.Size = new System.Drawing.Size(68, 39);
            this.refreshAndClearButton.TabIndex = 294;
            this.refreshAndClearButton.Text = "Clear / Refresh";
            this.refreshAndClearButton.UseVisualStyleBackColor = true;
            this.refreshAndClearButton.Click += new System.EventHandler(this.refreshAndApplyButton_Click);
            // 
            // toSettingsButton
            // 
            this.toSettingsButton.Location = new System.Drawing.Point(9, 12);
            this.toSettingsButton.Name = "toSettingsButton";
            this.toSettingsButton.Size = new System.Drawing.Size(68, 23);
            this.toSettingsButton.TabIndex = 293;
            this.toSettingsButton.Text = "Settings";
            this.toSettingsButton.UseVisualStyleBackColor = true;
            this.toSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(9, 87);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(68, 39);
            this.buttonPause.TabIndex = 299;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 300;
            this.label1.Text = "Front Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(679, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 301;
            this.label2.Text = "Front Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(292, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 302;
            this.label3.Text = "Rear Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(680, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 303;
            this.label4.Text = "Rear Right";
            // 
            // GradientChart
            // 
            this.GradientChart.BackColor = System.Drawing.Color.Transparent;
            chartArea91.AxisX.Interval = 1D;
            chartArea91.AxisX.LabelStyle.Enabled = false;
            chartArea91.AxisX.LineColor = System.Drawing.Color.Maroon;
            chartArea91.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea91.AxisX.MajorGrid.Enabled = false;
            chartArea91.AxisX.MajorGrid.Interval = 1D;
            chartArea91.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea91.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea91.AxisX.MajorTickMark.Enabled = false;
            chartArea91.AxisX.MajorTickMark.Interval = 1D;
            chartArea91.AxisX.Maximum = 1D;
            chartArea91.AxisX.Minimum = 0D;
            chartArea91.AxisX.Title = "phat";
            chartArea91.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            chartArea91.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea91.AxisX2.Title = "jou";
            chartArea91.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea91.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea91.AxisY.Interval = 1D;
            chartArea91.AxisY.IsLabelAutoFit = false;
            chartArea91.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea91.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea91.AxisY.MajorGrid.Interval = 1D;
            chartArea91.AxisY.MajorTickMark.Enabled = false;
            chartArea91.AxisY.Maximum = 10D;
            chartArea91.AxisY.Minimum = -10D;
            chartArea91.BackColor = System.Drawing.Color.Transparent;
            chartArea91.Name = "ChartArea1";
            this.GradientChart.ChartAreas.Add(chartArea91);
            legend37.Enabled = false;
            legend37.Name = "Legend1";
            this.GradientChart.Legends.Add(legend37);
            this.GradientChart.Location = new System.Drawing.Point(9, 129);
            this.GradientChart.Margin = new System.Windows.Forms.Padding(0);
            this.GradientChart.Name = "GradientChart";
            series91.BorderWidth = 3;
            series91.ChartArea = "ChartArea1";
            series91.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series91.Color = System.Drawing.Color.Red;
            series91.LabelForeColor = System.Drawing.Color.White;
            series91.Legend = "Legend1";
            series91.Name = "Series1";
            dataPoint37.IsValueShownAsLabel = false;
            dataPoint37.LabelForeColor = System.Drawing.Color.White;
            series91.Points.Add(dataPoint37);
            series91.Points.Add(dataPoint38);
            this.GradientChart.Series.Add(series91);
            this.GradientChart.Size = new System.Drawing.Size(68, 758);
            this.GradientChart.TabIndex = 304;
            this.GradientChart.Text = "chart5";
            title19.ForeColor = System.Drawing.Color.Transparent;
            title19.Name = "Title1";
            title19.Text = "jou";
            this.GradientChart.Titles.Add(title19);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(417, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 306;
            this.label5.Text = "All Wheels In One Chart";
            // 
            // labelUpDownChart
            // 
            this.labelUpDownChart.ForeColor = System.Drawing.Color.White;
            this.labelUpDownChart.Location = new System.Drawing.Point(12, 151);
            this.labelUpDownChart.Name = "labelUpDownChart";
            this.labelUpDownChart.Size = new System.Drawing.Size(65, 31);
            this.labelUpDownChart.TabIndex = 307;
            this.labelUpDownChart.Text = "Z axis selection";
            // 
            // chart1
            // 
            chartArea92.AxisX.Title = "X1 1";
            chartArea92.AxisX2.Title = "X2";
            chartArea92.AxisY.Title = "Y1 1";
            chartArea92.AxisY2.Title = "Y2";
            chartArea92.Name = "ChartArea1";
            chartArea93.AxisX.Title = "X1 2";
            chartArea93.AxisY.Title = "Y1 2";
            chartArea93.Name = "ChartArea2";
            chartArea94.AxisX.Title = "X1 3";
            chartArea94.AxisY.Title = "Y1 3";
            chartArea94.Name = "ChartArea3";
            chartArea95.AxisX.Title = "X1 4";
            chartArea95.AxisY.Title = "Y1 4";
            chartArea95.Name = "ChartArea4";
            this.chart1.ChartAreas.Add(chartArea92);
            this.chart1.ChartAreas.Add(chartArea93);
            this.chart1.ChartAreas.Add(chartArea94);
            this.chart1.ChartAreas.Add(chartArea95);
            legend38.Enabled = false;
            legend38.Name = "Legend1";
            this.chart1.Legends.Add(legend38);
            this.chart1.Location = new System.Drawing.Point(83, 87);
            this.chart1.Name = "chart1";
            series92.ChartArea = "ChartArea1";
            series92.Legend = "Legend1";
            series92.Name = "Series1";
            series93.ChartArea = "ChartArea2";
            series93.Legend = "Legend1";
            series93.Name = "Series2";
            series94.ChartArea = "ChartArea3";
            series94.Legend = "Legend1";
            series94.Name = "Series3";
            series95.ChartArea = "ChartArea4";
            series95.Legend = "Legend1";
            series95.Name = "Series4";
            this.chart1.Series.Add(series92);
            this.chart1.Series.Add(series93);
            this.chart1.Series.Add(series94);
            this.chart1.Series.Add(series95);
            this.chart1.Size = new System.Drawing.Size(800, 800);
            this.chart1.TabIndex = 308;
            this.chart1.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(91, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 309;
            this.label6.Text = "Front Tires";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(91, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 310;
            this.label7.Text = "Rear Tires";
            // 
            // xMinLimitTextBox
            // 
            this.xMinLimitTextBox.Location = new System.Drawing.Point(227, 35);
            this.xMinLimitTextBox.Name = "xMinLimitTextBox";
            this.xMinLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.xMinLimitTextBox.TabIndex = 311;
            // 
            // xMaxLimitTextBox
            // 
            this.xMaxLimitTextBox.Location = new System.Drawing.Point(227, 61);
            this.xMaxLimitTextBox.Name = "xMaxLimitTextBox";
            this.xMaxLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.xMaxLimitTextBox.TabIndex = 313;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(193, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 314;
            this.label9.Text = "Min:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(193, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 315;
            this.label10.Text = "Max:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(325, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 320;
            this.label11.Text = "Max:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(325, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 319;
            this.label12.Text = "Min:";
            // 
            // yMaxLimitTextBox
            // 
            this.yMaxLimitTextBox.Location = new System.Drawing.Point(359, 61);
            this.yMaxLimitTextBox.Name = "yMaxLimitTextBox";
            this.yMaxLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.yMaxLimitTextBox.TabIndex = 318;
            // 
            // yMinLimitTextBox
            // 
            this.yMinLimitTextBox.Location = new System.Drawing.Point(359, 35);
            this.yMinLimitTextBox.Name = "yMinLimitTextBox";
            this.yMinLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.yMinLimitTextBox.TabIndex = 316;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(457, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 325;
            this.label14.Text = "Max:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(457, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 324;
            this.label15.Text = "Min:";
            // 
            // zMaxLimitTextBox
            // 
            this.zMaxLimitTextBox.Location = new System.Drawing.Point(491, 61);
            this.zMaxLimitTextBox.Name = "zMaxLimitTextBox";
            this.zMaxLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.zMaxLimitTextBox.TabIndex = 323;
            // 
            // zMinLimitTextBox
            // 
            this.zMinLimitTextBox.Location = new System.Drawing.Point(491, 35);
            this.zMinLimitTextBox.Name = "zMinLimitTextBox";
            this.zMinLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.zMinLimitTextBox.TabIndex = 321;
            // 
            // enableLimitersCheckBox
            // 
            this.enableLimitersCheckBox.ForeColor = System.Drawing.Color.White;
            this.enableLimitersCheckBox.Location = new System.Drawing.Point(83, 35);
            this.enableLimitersCheckBox.Name = "enableLimitersCheckBox";
            this.enableLimitersCheckBox.Size = new System.Drawing.Size(104, 46);
            this.enableLimitersCheckBox.TabIndex = 326;
            this.enableLimitersCheckBox.Text = "Enable Min/Max limiters";
            this.enableLimitersCheckBox.UseVisualStyleBackColor = true;
            this.enableLimitersCheckBox.CheckedChanged += new System.EventHandler(this.enableLimitersCheckBox_CheckedChanged);
            this.enableLimitersCheckBox.Click += new System.EventHandler(this.enableLimitersCheckBox_Click);
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(599, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(284, 73);
            this.label17.TabIndex = 327;
            this.label17.Text = "Use only positive values on X/Y/Z. They get automatically also negative opposite." +
    " On X/Y/Z the limit works normally.";
            // 
            // xLimiterComboBox
            // 
            this.xLimiterComboBox.FormattingEnabled = true;
            this.xLimiterComboBox.Location = new System.Drawing.Point(196, 8);
            this.xLimiterComboBox.Name = "xLimiterComboBox";
            this.xLimiterComboBox.Size = new System.Drawing.Size(123, 21);
            this.xLimiterComboBox.TabIndex = 328;
            this.xLimiterComboBox.SelectionChangeCommitted += new System.EventHandler(this.xLimiterComboBox_SelectionChangeCommitted);
            this.xLimiterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xLimiterComboBox_KeyDown);
            // 
            // yLimiterComboBox
            // 
            this.yLimiterComboBox.FormattingEnabled = true;
            this.yLimiterComboBox.Location = new System.Drawing.Point(328, 8);
            this.yLimiterComboBox.Name = "yLimiterComboBox";
            this.yLimiterComboBox.Size = new System.Drawing.Size(123, 21);
            this.yLimiterComboBox.TabIndex = 329;
            this.yLimiterComboBox.SelectionChangeCommitted += new System.EventHandler(this.yLimiterComboBox_SelectionChangeCommitted);
            this.yLimiterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yLimiterComboBox_KeyDown);
            // 
            // zLimiterComboBox
            // 
            this.zLimiterComboBox.FormattingEnabled = true;
            this.zLimiterComboBox.Location = new System.Drawing.Point(460, 8);
            this.zLimiterComboBox.Name = "zLimiterComboBox";
            this.zLimiterComboBox.Size = new System.Drawing.Size(123, 21);
            this.zLimiterComboBox.TabIndex = 330;
            this.zLimiterComboBox.SelectionChangeCommitted += new System.EventHandler(this.zLimiterComboBox_SelectionChangeCommitted);
            this.zLimiterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zLimiterComboBox_KeyDown);
            // 
            // customChoiceCheckBox
            // 
            this.customChoiceCheckBox.ForeColor = System.Drawing.Color.White;
            this.customChoiceCheckBox.Location = new System.Drawing.Point(83, 8);
            this.customChoiceCheckBox.Name = "customChoiceCheckBox";
            this.customChoiceCheckBox.Size = new System.Drawing.Size(104, 21);
            this.customChoiceCheckBox.TabIndex = 331;
            this.customChoiceCheckBox.Text = "Custom choice";
            this.customChoiceCheckBox.UseVisualStyleBackColor = true;
            this.customChoiceCheckBox.Click += new System.EventHandler(this.customChoiceCheckBox_Click);
            // 
            // Form4Wheels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(918, 942);
            this.Controls.Add(this.customChoiceCheckBox);
            this.Controls.Add(this.zLimiterComboBox);
            this.Controls.Add(this.yLimiterComboBox);
            this.Controls.Add(this.xLimiterComboBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.enableLimitersCheckBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.zMaxLimitTextBox);
            this.Controls.Add(this.zMinLimitTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.yMaxLimitTextBox);
            this.Controls.Add(this.yMinLimitTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.xMaxLimitTextBox);
            this.Controls.Add(this.xMinLimitTextBox);
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
            this.Controls.Add(this.chart1);
            this.Name = "Form4Wheels";
            this.Text = "Form4Wheels";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4Wheels_FormClosed);
            this.Load += new System.EventHandler(this.Form4Wheels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshAndClearButton;
        private System.Windows.Forms.Button toSettingsButton;
        public System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.TextBox xMinLimitTextBox;
        private System.Windows.Forms.TextBox xMaxLimitTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox yMaxLimitTextBox;
        private System.Windows.Forms.TextBox yMinLimitTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox zMaxLimitTextBox;
        private System.Windows.Forms.TextBox zMinLimitTextBox;
        private System.Windows.Forms.CheckBox enableLimitersCheckBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox xLimiterComboBox;
        private System.Windows.Forms.ComboBox yLimiterComboBox;
        private System.Windows.Forms.ComboBox zLimiterComboBox;
        private System.Windows.Forms.CheckBox customChoiceCheckBox;
    }
}