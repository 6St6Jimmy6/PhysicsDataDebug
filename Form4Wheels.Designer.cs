
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
            System.Windows.Forms.DataVisualization.Charting.Title frontPreviewTitle = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title rearPreviewTitle = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.noTireContactLimiterEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.axisFiltersGroup = new System.Windows.Forms.GroupBox();
            this.axisFiltersFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.axisXFilterHost = new System.Windows.Forms.Panel();
            this.axisYFilterHost = new System.Windows.Forms.Panel();
            this.axisZFilterHost = new System.Windows.Forms.Panel();
            this.extraFiltersGroup = new System.Windows.Forms.GroupBox();
            this.extraFiltersFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.extraFilterHost01 = new System.Windows.Forms.Panel();
            this.extraFilterHost02 = new System.Windows.Forms.Panel();
            this.extraFilterHost03 = new System.Windows.Forms.Panel();
            this.extraFilterHost04 = new System.Windows.Forms.Panel();
            this.extraFilterHost05 = new System.Windows.Forms.Panel();
            this.extraFilterHost06 = new System.Windows.Forms.Panel();
            this.extraFilterHost07 = new System.Windows.Forms.Panel();
            this.extraFilterHost08 = new System.Windows.Forms.Panel();
            this.extraFilterHost09 = new System.Windows.Forms.Panel();
            this.extraFilterHost10 = new System.Windows.Forms.Panel();
            this.chartAndLegend = new System.Windows.Forms.SplitContainer();
            this.chartScrollPanel = new System.Windows.Forms.Panel();
            this.chartStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.filterActionsPanel.SuspendLayout();
            this.actionColumns.SuspendLayout();
            this.actionButtonsFlow.SuspendLayout();
            this.axisFiltersGroup.SuspendLayout();
            this.axisFiltersFlow.SuspendLayout();
            this.extraFiltersGroup.SuspendLayout();
            this.extraFiltersFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAndLegend)).BeginInit();
            this.chartAndLegend.Panel1.SuspendLayout();
            this.chartAndLegend.Panel2.SuspendLayout();
            this.chartAndLegend.SuspendLayout();
            this.chartScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshAndClearButton
            // 
            this.refreshAndClearButton.Location = new System.Drawing.Point(130, 9);
            this.refreshAndClearButton.Margin = new System.Windows.Forms.Padding(6);
            this.refreshAndClearButton.Name = "refreshAndClearButton";
            this.refreshAndClearButton.AutoSize = true;
            this.refreshAndClearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.refreshAndClearButton.MinimumSize = new System.Drawing.Size(210, 40);
            this.refreshAndClearButton.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.refreshAndClearButton.Size = new System.Drawing.Size(140, 40);
            this.refreshAndClearButton.TabIndex = 294;
            this.refreshAndClearButton.Text = "Clear / Refresh All";
            this.refreshAndClearButton.UseVisualStyleBackColor = false;
            this.refreshAndClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.refreshAndClearButton.ForeColor = System.Drawing.Color.White;
            this.refreshAndClearButton.Click += new System.EventHandler(this.refreshAndApplyButton_Click);
            // 
            // toSettingsButton
            // 
            this.toSettingsButton.Location = new System.Drawing.Point(10, 9);
            this.toSettingsButton.Margin = new System.Windows.Forms.Padding(6);
            this.toSettingsButton.Name = "toSettingsButton";
            this.toSettingsButton.AutoSize = true;
            this.toSettingsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.toSettingsButton.MinimumSize = new System.Drawing.Size(115, 40);
            this.toSettingsButton.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.toSettingsButton.Size = new System.Drawing.Size(108, 40);
            this.toSettingsButton.TabIndex = 293;
            this.toSettingsButton.Text = "Settings";
            this.toSettingsButton.UseVisualStyleBackColor = false;
            this.toSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.toSettingsButton.ForeColor = System.Drawing.Color.White;
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
            this.buttonPause.Location = new System.Drawing.Point(282, 9);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.AutoSize = true;
            this.buttonPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.buttonPause.MinimumSize = new System.Drawing.Size(105, 40);
            this.buttonPause.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.buttonPause.Size = new System.Drawing.Size(110, 40);
            this.buttonPause.TabIndex = 299;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.buttonPause.ForeColor = System.Drawing.Color.White;
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
            this.GradientChart.MinimumSize = new System.Drawing.Size(10, 10);
            this.GradientChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.GradientChart.Legends.Add(legend1);
            this.GradientChart.Location = new System.Drawing.Point(0, 0);
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
            this.GradientChart.Size = new System.Drawing.Size(120, 810);
            this.GradientChart.TabIndex = 304;
            this.GradientChart.Text = "chart5";
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "ZColorHeading";
            title1.Text = "Z axis";
            this.GradientChart.Titles.Add(title1);
            // 
            // chart1
            // 
            chartArea2.AxisX.Title = "X1 1";
            chartArea2.AxisX2.Title = "X2";
            chartArea2.AxisY.Title = "Y1 1";
            chartArea2.AxisY2.Title = "Y2";
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Black;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Black;
            chartArea2.Position.Auto = false;
            chartArea2.Position.X = 0F;
            chartArea2.Position.Y = 0F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Height = 50F;
            chartArea2.Name = "ChartArea1";
            chartArea3.AxisX.Title = "X1 2";
            chartArea3.AxisY.Title = "Y1 2";
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisX.LineColor = System.Drawing.Color.Black;
            chartArea3.AxisY.LineColor = System.Drawing.Color.Black;
            chartArea3.Position.Auto = false;
            chartArea3.Position.X = 0F;
            chartArea3.Position.Y = 50F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Height = 50F;
            chartArea3.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.ChartAreas.Add(chartArea3);
            // Preview the default Front/Rear chart layout in the Designer.
            // Runtime clears these Titles and builds the selected dataset layout.
            frontPreviewTitle.Text = "Front Tires";
            frontPreviewTitle.DockedToChartArea = "ChartArea1";
            frontPreviewTitle.IsDockedInsideChartArea = true;
            frontPreviewTitle.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            frontPreviewTitle.Alignment = System.Drawing.ContentAlignment.TopCenter;
            frontPreviewTitle.ForeColor = System.Drawing.Color.White;
            rearPreviewTitle.Text = "Rear Tires";
            rearPreviewTitle.DockedToChartArea = "ChartArea2";
            rearPreviewTitle.IsDockedInsideChartArea = true;
            rearPreviewTitle.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            rearPreviewTitle.Alignment = System.Drawing.ContentAlignment.TopCenter;
            rearPreviewTitle.ForeColor = System.Drawing.Color.White;
            this.chart1.Titles.Add(frontPreviewTitle);
            this.chart1.Titles.Add(rearPreviewTitle);
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.MinimumSize = new System.Drawing.Size(10, 10);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(6);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(2125, 810);
            this.chart1.TabIndex = 308;
            this.chart1.Text = "chart1";
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.filterActionsPanel, 0, 0);
            this.mainLayout.Controls.Add(this.axisFiltersGroup, 0, 1);
            this.mainLayout.Controls.Add(this.extraFiltersGroup, 0, 2);
            this.mainLayout.Controls.Add(this.chartAndLegend, 0, 3);
            this.mainLayout.Controls.Add(this.chartStatusLabel, 0, 4);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(5);
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayout.Size = new System.Drawing.Size(2267, 1393);
            this.mainLayout.TabIndex = 0;
            // 
            // filterActionsPanel
            // 
            this.filterActionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.filterActionsPanel.Controls.Add(this.actionColumns);
            this.filterActionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterActionsPanel.Location = new System.Drawing.Point(8, 8);
            this.filterActionsPanel.Name = "filterActionsPanel";
            this.filterActionsPanel.Size = new System.Drawing.Size(2251, 69);
            this.filterActionsPanel.TabIndex = 351;
            // 
            // actionColumns
            // 
            this.actionColumns.ColumnCount = 2;
            this.actionColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.actionColumns.Controls.Add(this.actionButtonsFlow, 0, 0);
            this.actionColumns.Controls.Add(this.SettingsProfilesHost, 1, 0);
            this.actionColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionColumns.Location = new System.Drawing.Point(0, 0);
            this.actionColumns.Name = "actionColumns";
            this.actionColumns.RowCount = 1;
            this.actionColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionColumns.Size = new System.Drawing.Size(2251, 69);
            this.actionColumns.TabIndex = 0;
            // 
            // actionButtonsFlow
            // 
            this.actionButtonsFlow.AutoScroll = true;
            this.actionButtonsFlow.Controls.Add(this.toSettingsButton);
            this.actionButtonsFlow.Controls.Add(this.refreshAndClearButton);
            this.actionButtonsFlow.Controls.Add(this.buttonPause);
            this.actionButtonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtonsFlow.Location = new System.Drawing.Point(3, 3);
            this.actionButtonsFlow.Name = "actionButtonsFlow";
            this.actionButtonsFlow.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.actionButtonsFlow.Size = new System.Drawing.Size(1945, 63);
            this.actionButtonsFlow.TabIndex = 0;
            this.actionButtonsFlow.WrapContents = false;
            // 
            // noTireContactLimiterEnabledCheckBox
            // 
            this.noTireContactLimiterEnabledCheckBox.ForeColor = System.Drawing.Color.White;
            this.noTireContactLimiterEnabledCheckBox.Location = new System.Drawing.Point(552, 9);
            this.noTireContactLimiterEnabledCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.noTireContactLimiterEnabledCheckBox.Name = "noTireContactLimiterEnabledCheckBox";
            this.noTireContactLimiterEnabledCheckBox.Size = new System.Drawing.Size(245, 28);
            this.noTireContactLimiterEnabledCheckBox.TabIndex = 332;
            this.noTireContactLimiterEnabledCheckBox.Text = "No tire contact limiter";
            this.noTireContactLimiterEnabledCheckBox.UseVisualStyleBackColor = true;
            this.noTireContactLimiterEnabledCheckBox.CheckedChanged += new System.EventHandler(this.noTireContactLimiterEnabledCheckBox_CheckedChanged);
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesHost.Location = new System.Drawing.Point(1954, 3);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Size = new System.Drawing.Size(294, 63);
            this.SettingsProfilesHost.TabIndex = 1;
            // 
            // axisFiltersGroup
            // 
            this.axisFiltersGroup.BackColor = System.Drawing.Color.Black;
            this.axisFiltersGroup.Controls.Add(this.axisFiltersFlow);
            this.axisFiltersGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisFiltersGroup.ForeColor = System.Drawing.Color.White;
            this.axisFiltersGroup.Location = new System.Drawing.Point(8, 83);
            this.axisFiltersGroup.Name = "axisFiltersGroup";
            this.axisFiltersGroup.Padding = new System.Windows.Forms.Padding(8, 8, 8, 15);
            this.axisFiltersGroup.Size = new System.Drawing.Size(2251, 224);
            this.axisFiltersGroup.TabIndex = 352;
            this.axisFiltersGroup.TabStop = false;
            this.axisFiltersGroup.Text = "Current chart axes — each follows its selected X / Y / Z field";
            this.axisFiltersGroup.Visible = false;
            // 
            // axisFiltersFlow
            // 
            this.axisFiltersFlow.AutoScroll = true;
            this.axisFiltersFlow.Controls.Add(this.axisXFilterHost);
            this.axisFiltersFlow.Controls.Add(this.axisYFilterHost);
            this.axisFiltersFlow.Controls.Add(this.axisZFilterHost);
            this.axisFiltersFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisFiltersFlow.Location = new System.Drawing.Point(8, 46);
            this.axisFiltersFlow.Name = "axisFiltersFlow";
            this.axisFiltersFlow.Size = new System.Drawing.Size(2235, 173);
            this.axisFiltersFlow.TabIndex = 0;
            // 
            // axisXFilterHost
            // 
            this.axisXFilterHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.axisXFilterHost.Location = new System.Drawing.Point(5, 5);
            this.axisXFilterHost.Margin = new System.Windows.Forms.Padding(5);
            this.axisXFilterHost.Name = "axisXFilterHost";
            this.axisXFilterHost.Size = new System.Drawing.Size(710, 163);
            this.axisXFilterHost.TabIndex = 0;
            this.axisXFilterHost.Tag = "X axis (follows chart)";
            // 
            // axisYFilterHost
            // 
            this.axisYFilterHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.axisYFilterHost.Location = new System.Drawing.Point(725, 5);
            this.axisYFilterHost.Margin = new System.Windows.Forms.Padding(5);
            this.axisYFilterHost.Name = "axisYFilterHost";
            this.axisYFilterHost.Size = new System.Drawing.Size(710, 163);
            this.axisYFilterHost.TabIndex = 1;
            this.axisYFilterHost.Tag = "Y axis (follows chart)";
            // 
            // axisZFilterHost
            // 
            this.axisZFilterHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.axisZFilterHost.Location = new System.Drawing.Point(1445, 5);
            this.axisZFilterHost.Margin = new System.Windows.Forms.Padding(5);
            this.axisZFilterHost.Name = "axisZFilterHost";
            this.axisZFilterHost.Size = new System.Drawing.Size(710, 163);
            this.axisZFilterHost.TabIndex = 2;
            this.axisZFilterHost.Tag = "Z axis (follows chart)";
            // 
            // extraFiltersGroup
            // 
            this.extraFiltersGroup.BackColor = System.Drawing.Color.Black;
            this.extraFiltersGroup.Controls.Add(this.extraFiltersFlow);
            this.extraFiltersGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extraFiltersGroup.ForeColor = System.Drawing.Color.White;
            this.extraFiltersGroup.Location = new System.Drawing.Point(8, 313);
            this.extraFiltersGroup.Name = "extraFiltersGroup";
            this.extraFiltersGroup.Padding = new System.Windows.Forms.Padding(8, 8, 8, 15);
            this.extraFiltersGroup.Size = new System.Drawing.Size(2251, 224);
            this.extraFiltersGroup.TabIndex = 353;
            this.extraFiltersGroup.TabStop = false;
            this.extraFiltersGroup.Text = "Additional telemetry filters — choose up to 10 measurements";
            this.extraFiltersGroup.Visible = false;
            // 
            // extraFiltersFlow
            // 
            this.extraFiltersFlow.AutoScroll = true;
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost01);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost02);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost03);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost04);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost05);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost06);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost07);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost08);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost09);
            this.extraFiltersFlow.Controls.Add(this.extraFilterHost10);
            this.extraFiltersFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extraFiltersFlow.Location = new System.Drawing.Point(8, 46);
            this.extraFiltersFlow.Name = "extraFiltersFlow";
            this.extraFiltersFlow.Size = new System.Drawing.Size(2235, 173);
            this.extraFiltersFlow.TabIndex = 0;
            // 
            // extraFilterHost01
            // 
            this.extraFilterHost01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost01.Location = new System.Drawing.Point(5, 5);
            this.extraFilterHost01.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost01.Name = "extraFilterHost01";
            this.extraFilterHost01.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost01.TabIndex = 0;
            this.extraFilterHost01.Tag = "Extra 1";
            // 
            // extraFilterHost02
            // 
            this.extraFilterHost02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost02.Location = new System.Drawing.Point(725, 5);
            this.extraFilterHost02.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost02.Name = "extraFilterHost02";
            this.extraFilterHost02.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost02.TabIndex = 1;
            this.extraFilterHost02.Tag = "Extra 2";
            // 
            // extraFilterHost03
            // 
            this.extraFilterHost03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost03.Location = new System.Drawing.Point(1445, 5);
            this.extraFilterHost03.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost03.Name = "extraFilterHost03";
            this.extraFilterHost03.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost03.TabIndex = 2;
            this.extraFilterHost03.Tag = "Extra 3";
            // 
            // extraFilterHost04
            // 
            this.extraFilterHost04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost04.Location = new System.Drawing.Point(5, 178);
            this.extraFilterHost04.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost04.Name = "extraFilterHost04";
            this.extraFilterHost04.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost04.TabIndex = 3;
            this.extraFilterHost04.Tag = "Extra 4";
            // 
            // extraFilterHost05
            // 
            this.extraFilterHost05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost05.Location = new System.Drawing.Point(725, 178);
            this.extraFilterHost05.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost05.Name = "extraFilterHost05";
            this.extraFilterHost05.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost05.TabIndex = 4;
            this.extraFilterHost05.Tag = "Extra 5";
            // 
            // extraFilterHost06
            // 
            this.extraFilterHost06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost06.Location = new System.Drawing.Point(1445, 178);
            this.extraFilterHost06.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost06.Name = "extraFilterHost06";
            this.extraFilterHost06.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost06.TabIndex = 5;
            this.extraFilterHost06.Tag = "Extra 6";
            // 
            // extraFilterHost07
            // 
            this.extraFilterHost07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost07.Location = new System.Drawing.Point(5, 351);
            this.extraFilterHost07.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost07.Name = "extraFilterHost07";
            this.extraFilterHost07.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost07.TabIndex = 6;
            this.extraFilterHost07.Tag = "Extra 7";
            // 
            // extraFilterHost08
            // 
            this.extraFilterHost08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost08.Location = new System.Drawing.Point(725, 351);
            this.extraFilterHost08.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost08.Name = "extraFilterHost08";
            this.extraFilterHost08.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost08.TabIndex = 7;
            this.extraFilterHost08.Tag = "Extra 8";
            // 
            // extraFilterHost09
            // 
            this.extraFilterHost09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost09.Location = new System.Drawing.Point(1445, 351);
            this.extraFilterHost09.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost09.Name = "extraFilterHost09";
            this.extraFilterHost09.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost09.TabIndex = 8;
            this.extraFilterHost09.Tag = "Extra 9";
            // 
            // extraFilterHost10
            // 
            this.extraFilterHost10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterHost10.Location = new System.Drawing.Point(5, 524);
            this.extraFilterHost10.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterHost10.Name = "extraFilterHost10";
            this.extraFilterHost10.Size = new System.Drawing.Size(710, 163);
            this.extraFilterHost10.TabIndex = 9;
            this.extraFilterHost10.Tag = "Extra 10";
            // 
            // chartAndLegend
            // 
            this.chartAndLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAndLegend.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.chartAndLegend.Location = new System.Drawing.Point(8, 543);
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
            this.chartAndLegend.Size = new System.Drawing.Size(2251, 810);
            this.chartAndLegend.SplitterDistance = 2125;
            this.chartAndLegend.SplitterWidth = 6;
            this.chartAndLegend.TabIndex = 354;
            // 
            // chartScrollPanel
            // 
            this.chartScrollPanel.BackColor = System.Drawing.Color.Black;
            this.chartScrollPanel.Controls.Add(this.chart1);
            this.chartScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartScrollPanel.Location = new System.Drawing.Point(0, 0);
            this.chartScrollPanel.Name = "chartScrollPanel";
            this.chartScrollPanel.Size = new System.Drawing.Size(2125, 810);
            this.chartScrollPanel.TabIndex = 350;
            // 
            // chartStatusLabel
            // 
            this.chartStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartStatusLabel.ForeColor = System.Drawing.Color.White;
            this.chartStatusLabel.Location = new System.Drawing.Point(8, 1356);
            this.chartStatusLabel.Name = "chartStatusLabel";
            this.chartStatusLabel.Size = new System.Drawing.Size(2251, 32);
            this.chartStatusLabel.TabIndex = 355;
            this.chartStatusLabel.Text = "Live four-wheel telemetry  •  Chart Settings to change X / Y / Z and layout";
            this.chartStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form4Wheels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(2267, 1393);
            this.Controls.Add(this.mainLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(880, 680);
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
            this.axisFiltersGroup.ResumeLayout(false);
            this.axisFiltersFlow.ResumeLayout(false);
            this.extraFiltersGroup.ResumeLayout(false);
            this.extraFiltersFlow.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox axisFiltersGroup;
        private System.Windows.Forms.FlowLayoutPanel axisFiltersFlow;
        private System.Windows.Forms.GroupBox extraFiltersGroup;
        private System.Windows.Forms.FlowLayoutPanel extraFiltersFlow;
        private System.Windows.Forms.Panel axisXFilterHost;
        private System.Windows.Forms.Panel axisYFilterHost;
        private System.Windows.Forms.Panel axisZFilterHost;
        private System.Windows.Forms.Panel extraFilterHost01;
        private System.Windows.Forms.Panel extraFilterHost02;
        private System.Windows.Forms.Panel extraFilterHost03;
        private System.Windows.Forms.Panel extraFilterHost04;
        private System.Windows.Forms.Panel extraFilterHost05;
        private System.Windows.Forms.Panel extraFilterHost06;
        private System.Windows.Forms.Panel extraFilterHost07;
        private System.Windows.Forms.Panel extraFilterHost08;
        private System.Windows.Forms.Panel extraFilterHost09;
        private System.Windows.Forms.Panel extraFilterHost10;
        private System.Windows.Forms.CheckBox noTireContactLimiterEnabledCheckBox;
    }
}
