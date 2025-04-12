
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.X1MinLimitTextBox = new System.Windows.Forms.TextBox();
            this.X1MaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Y1MaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.Y1MinLimitTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Z1MaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.Z1MinLimitTextBox = new System.Windows.Forms.TextBox();
            this.enableLimitersCheckBox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.X1LimiterComboBox = new System.Windows.Forms.ComboBox();
            this.Y1LimiterComboBox = new System.Windows.Forms.ComboBox();
            this.Z1LimiterComboBox = new System.Windows.Forms.ComboBox();
            this.customChoiceCheckBox = new System.Windows.Forms.CheckBox();
            this.noTireContactLimiterEnabledCheckBox = new System.Windows.Forms.CheckBox();
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
            this.label1.Location = new System.Drawing.Point(292, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 300;
            this.label1.Text = "Front Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(679, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 301;
            this.label2.Text = "Front Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(292, 528);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 302;
            this.label3.Text = "Rear Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(680, 528);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 303;
            this.label4.Text = "Rear Right";
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
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.GradientChart.Legends.Add(legend1);
            this.GradientChart.Location = new System.Drawing.Point(9, 132);
            this.GradientChart.Margin = new System.Windows.Forms.Padding(0);
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
            this.GradientChart.Size = new System.Drawing.Size(68, 797);
            this.GradientChart.TabIndex = 304;
            this.GradientChart.Text = "chart5";
            title1.ForeColor = System.Drawing.Color.Transparent;
            title1.Name = "Title1";
            title1.Text = "jou";
            this.GradientChart.Titles.Add(title1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(417, 142);
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
            chartArea2.AxisX.Title = "X1 1";
            chartArea2.AxisX2.Title = "X2";
            chartArea2.AxisY.Title = "Y1 1";
            chartArea2.AxisY2.Title = "Y2";
            chartArea2.Name = "ChartArea1";
            chartArea3.AxisX.Title = "X1 2";
            chartArea3.AxisY.Title = "Y1 2";
            chartArea3.Name = "ChartArea2";
            chartArea4.AxisX.Title = "X1 3";
            chartArea4.AxisY.Title = "Y1 3";
            chartArea4.Name = "ChartArea3";
            chartArea5.AxisX.Title = "X1 4";
            chartArea5.AxisY.Title = "Y1 4";
            chartArea5.Name = "ChartArea4";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.ChartAreas.Add(chartArea5);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(83, 132);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea2";
            series3.Legend = "Legend1";
            series3.Name = "Series2";
            series4.ChartArea = "ChartArea3";
            series4.Legend = "Legend1";
            series4.Name = "Series3";
            series5.ChartArea = "ChartArea4";
            series5.Legend = "Legend1";
            series5.Name = "Series4";
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(800, 800);
            this.chart1.TabIndex = 308;
            this.chart1.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(91, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 309;
            this.label6.Text = "Front Tires";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(91, 528);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 310;
            this.label7.Text = "Rear Tires";
            // 
            // X1MinLimitTextBox
            // 
            this.X1MinLimitTextBox.Location = new System.Drawing.Point(227, 35);
            this.X1MinLimitTextBox.Multiline = true;
            this.X1MinLimitTextBox.Name = "X1MinLimitTextBox";
            this.X1MinLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.X1MinLimitTextBox.TabIndex = 311;
            // 
            // X1MaxLimitTextBox
            // 
            this.X1MaxLimitTextBox.Location = new System.Drawing.Point(227, 61);
            this.X1MaxLimitTextBox.Name = "X1MaxLimitTextBox";
            this.X1MaxLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.X1MaxLimitTextBox.TabIndex = 313;
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
            // Y1MaxLimitTextBox
            // 
            this.Y1MaxLimitTextBox.Location = new System.Drawing.Point(359, 61);
            this.Y1MaxLimitTextBox.Name = "Y1MaxLimitTextBox";
            this.Y1MaxLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.Y1MaxLimitTextBox.TabIndex = 318;
            // 
            // Y1MinLimitTextBox
            // 
            this.Y1MinLimitTextBox.Location = new System.Drawing.Point(359, 35);
            this.Y1MinLimitTextBox.Name = "Y1MinLimitTextBox";
            this.Y1MinLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.Y1MinLimitTextBox.TabIndex = 316;
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
            // Z1MaxLimitTextBox
            // 
            this.Z1MaxLimitTextBox.Location = new System.Drawing.Point(491, 61);
            this.Z1MaxLimitTextBox.Name = "Z1MaxLimitTextBox";
            this.Z1MaxLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.Z1MaxLimitTextBox.TabIndex = 323;
            // 
            // Z1MinLimitTextBox
            // 
            this.Z1MinLimitTextBox.Location = new System.Drawing.Point(491, 35);
            this.Z1MinLimitTextBox.Name = "Z1MinLimitTextBox";
            this.Z1MinLimitTextBox.Size = new System.Drawing.Size(92, 20);
            this.Z1MinLimitTextBox.TabIndex = 321;
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
            // X1LimiterComboBox
            // 
            this.X1LimiterComboBox.FormattingEnabled = true;
            this.X1LimiterComboBox.Location = new System.Drawing.Point(196, 8);
            this.X1LimiterComboBox.Name = "X1LimiterComboBox";
            this.X1LimiterComboBox.Size = new System.Drawing.Size(123, 21);
            this.X1LimiterComboBox.TabIndex = 328;
            this.X1LimiterComboBox.SelectionChangeCommitted += new System.EventHandler(this.xLimiterComboBox_SelectionChangeCommitted);
            this.X1LimiterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xLimiterComboBox_KeyDown);
            // 
            // Y1LimiterComboBox
            // 
            this.Y1LimiterComboBox.FormattingEnabled = true;
            this.Y1LimiterComboBox.Location = new System.Drawing.Point(328, 8);
            this.Y1LimiterComboBox.Name = "Y1LimiterComboBox";
            this.Y1LimiterComboBox.Size = new System.Drawing.Size(123, 21);
            this.Y1LimiterComboBox.TabIndex = 329;
            this.Y1LimiterComboBox.SelectionChangeCommitted += new System.EventHandler(this.yLimiterComboBox_SelectionChangeCommitted);
            this.Y1LimiterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yLimiterComboBox_KeyDown);
            // 
            // Z1LimiterComboBox
            // 
            this.Z1LimiterComboBox.FormattingEnabled = true;
            this.Z1LimiterComboBox.Location = new System.Drawing.Point(460, 8);
            this.Z1LimiterComboBox.Name = "Z1LimiterComboBox";
            this.Z1LimiterComboBox.Size = new System.Drawing.Size(123, 21);
            this.Z1LimiterComboBox.TabIndex = 330;
            this.Z1LimiterComboBox.SelectionChangeCommitted += new System.EventHandler(this.zLimiterComboBox_SelectionChangeCommitted);
            this.Z1LimiterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zLimiterComboBox_KeyDown);
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
            // noTireContactLimiterEnabledCheckBox
            // 
            this.noTireContactLimiterEnabledCheckBox.ForeColor = System.Drawing.Color.White;
            this.noTireContactLimiterEnabledCheckBox.Location = new System.Drawing.Point(83, 87);
            this.noTireContactLimiterEnabledCheckBox.Name = "noTireContactLimiterEnabledCheckBox";
            this.noTireContactLimiterEnabledCheckBox.Size = new System.Drawing.Size(104, 39);
            this.noTireContactLimiterEnabledCheckBox.TabIndex = 332;
            this.noTireContactLimiterEnabledCheckBox.Text = "No tire contact limiter";
            this.noTireContactLimiterEnabledCheckBox.UseVisualStyleBackColor = true;
            this.noTireContactLimiterEnabledCheckBox.CheckedChanged += new System.EventHandler(this.noTireContactLimiterEnabledCheckBox_CheckedChanged);
            // 
            // Form4Wheels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(918, 948);
            this.Controls.Add(this.noTireContactLimiterEnabledCheckBox);
            this.Controls.Add(this.customChoiceCheckBox);
            this.Controls.Add(this.Z1LimiterComboBox);
            this.Controls.Add(this.Y1LimiterComboBox);
            this.Controls.Add(this.X1LimiterComboBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.enableLimitersCheckBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Z1MaxLimitTextBox);
            this.Controls.Add(this.Z1MinLimitTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Y1MaxLimitTextBox);
            this.Controls.Add(this.Y1MinLimitTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.X1MaxLimitTextBox);
            this.Controls.Add(this.X1MinLimitTextBox);
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
        private System.Windows.Forms.TextBox X1MinLimitTextBox;
        private System.Windows.Forms.TextBox X1MaxLimitTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Y1MaxLimitTextBox;
        private System.Windows.Forms.TextBox Y1MinLimitTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Z1MaxLimitTextBox;
        private System.Windows.Forms.TextBox Z1MinLimitTextBox;
        private System.Windows.Forms.CheckBox enableLimitersCheckBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox X1LimiterComboBox;
        private System.Windows.Forms.ComboBox Y1LimiterComboBox;
        private System.Windows.Forms.ComboBox Z1LimiterComboBox;
        private System.Windows.Forms.CheckBox customChoiceCheckBox;
        private System.Windows.Forms.CheckBox noTireContactLimiterEnabledCheckBox;
    }
}