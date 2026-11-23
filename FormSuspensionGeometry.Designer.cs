namespace Physics_Data_Debug
{
    partial class FormSuspensionGeometry
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.settingsToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.xMinimumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.xMinimumLabel = new System.Windows.Forms.Label();
            this.axisXMinimumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xMaximumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.xMaximumLabel = new System.Windows.Forms.Label();
            this.axisXMaximumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yMinimumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.yMinimumLabel = new System.Windows.Forms.Label();
            this.axisYMinimumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yMaximumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.yMaximumLabel = new System.Windows.Forms.Label();
            this.axisYMaximumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalGroup = new System.Windows.Forms.TableLayoutPanel();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.updateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.settingsToolbar.SuspendLayout();
            this.xMinimumGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMinimumNumericUpDown)).BeginInit();
            this.xMaximumGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMaximumNumericUpDown)).BeginInit();
            this.yMinimumGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMinimumNumericUpDown)).BeginInit();
            this.yMaximumGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMaximumNumericUpDown)).BeginInit();
            this.intervalGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea3.AxisX.Maximum = 1.5D;
            chartArea3.AxisX.Minimum = -1.5D;
            chartArea3.AxisY.Maximum = 1.5D;
            chartArea3.AxisY.Minimum = -0.5D;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "FrontSuspension";
            chartArea4.AxisX.Maximum = 1.5D;
            chartArea4.AxisX.Minimum = -1.5D;
            chartArea4.AxisY.Maximum = 1.5D;
            chartArea4.AxisY.Minimum = -0.5D;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "RearSuspension";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 37);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(840, 597);
            this.chart1.TabIndex = 1;
            // 
            // settingsToolbar
            // 
            this.settingsToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.settingsToolbar.ColumnCount = 5;
            this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsToolbar.Controls.Add(this.xMinimumGroup, 0, 0);
            this.settingsToolbar.Controls.Add(this.xMaximumGroup, 1, 0);
            this.settingsToolbar.Controls.Add(this.yMinimumGroup, 2, 0);
            this.settingsToolbar.Controls.Add(this.yMaximumGroup, 3, 0);
            this.settingsToolbar.Controls.Add(this.intervalGroup, 4, 0);
            this.settingsToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsToolbar.Location = new System.Drawing.Point(0, 0);
            this.settingsToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.settingsToolbar.Name = "settingsToolbar";
            this.settingsToolbar.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingsToolbar.RowCount = 1;
            this.settingsToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsToolbar.Size = new System.Drawing.Size(840, 37);
            this.settingsToolbar.TabIndex = 0;
            // 
            // xMinimumGroup
            // 
            this.xMinimumGroup.ColumnCount = 2;
            this.xMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.xMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMinimumGroup.Controls.Add(this.xMinimumLabel, 0, 0);
            this.xMinimumGroup.Controls.Add(this.axisXMinimumNumericUpDown, 1, 0);
            this.xMinimumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinimumGroup.Location = new System.Drawing.Point(5, 4);
            this.xMinimumGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xMinimumGroup.Name = "xMinimumGroup";
            this.xMinimumGroup.RowCount = 1;
            this.xMinimumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMinimumGroup.Size = new System.Drawing.Size(162, 29);
            this.xMinimumGroup.TabIndex = 0;
            // 
            // xMinimumLabel
            // 
            this.xMinimumLabel.AutoSize = true;
            this.xMinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinimumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.xMinimumLabel.Location = new System.Drawing.Point(2, 0);
            this.xMinimumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xMinimumLabel.Name = "xMinimumLabel";
            this.xMinimumLabel.Size = new System.Drawing.Size(64, 29);
            this.xMinimumLabel.TabIndex = 0;
            this.xMinimumLabel.Text = "X minimum";
            this.xMinimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axisXMinimumNumericUpDown
            // 
            this.axisXMinimumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.axisXMinimumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisXMinimumNumericUpDown.DecimalPlaces = 3;
            this.axisXMinimumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisXMinimumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisXMinimumNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.axisXMinimumNumericUpDown.Location = new System.Drawing.Point(70, 2);
            this.axisXMinimumNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.axisXMinimumNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.axisXMinimumNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.axisXMinimumNumericUpDown.Name = "axisXMinimumNumericUpDown";
            this.axisXMinimumNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.axisXMinimumNumericUpDown.TabIndex = 1;
            this.axisXMinimumNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            -2147418112});
            this.axisXMinimumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            // 
            // xMaximumGroup
            // 
            this.xMaximumGroup.ColumnCount = 2;
            this.xMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.xMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMaximumGroup.Controls.Add(this.xMaximumLabel, 0, 0);
            this.xMaximumGroup.Controls.Add(this.axisXMaximumNumericUpDown, 1, 0);
            this.xMaximumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMaximumGroup.Location = new System.Drawing.Point(171, 4);
            this.xMaximumGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xMaximumGroup.Name = "xMaximumGroup";
            this.xMaximumGroup.RowCount = 1;
            this.xMaximumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMaximumGroup.Size = new System.Drawing.Size(162, 29);
            this.xMaximumGroup.TabIndex = 1;
            // 
            // xMaximumLabel
            // 
            this.xMaximumLabel.AutoSize = true;
            this.xMaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMaximumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.xMaximumLabel.Location = new System.Drawing.Point(2, 0);
            this.xMaximumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xMaximumLabel.Name = "xMaximumLabel";
            this.xMaximumLabel.Size = new System.Drawing.Size(64, 29);
            this.xMaximumLabel.TabIndex = 0;
            this.xMaximumLabel.Text = "X maximum";
            this.xMaximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axisXMaximumNumericUpDown
            // 
            this.axisXMaximumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.axisXMaximumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisXMaximumNumericUpDown.DecimalPlaces = 3;
            this.axisXMaximumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisXMaximumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisXMaximumNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.axisXMaximumNumericUpDown.Location = new System.Drawing.Point(70, 2);
            this.axisXMaximumNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.axisXMaximumNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.axisXMaximumNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.axisXMaximumNumericUpDown.Name = "axisXMaximumNumericUpDown";
            this.axisXMaximumNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.axisXMaximumNumericUpDown.TabIndex = 1;
            this.axisXMaximumNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.axisXMaximumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            // 
            // yMinimumGroup
            // 
            this.yMinimumGroup.ColumnCount = 2;
            this.yMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.yMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMinimumGroup.Controls.Add(this.yMinimumLabel, 0, 0);
            this.yMinimumGroup.Controls.Add(this.axisYMinimumNumericUpDown, 1, 0);
            this.yMinimumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinimumGroup.Location = new System.Drawing.Point(337, 4);
            this.yMinimumGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yMinimumGroup.Name = "yMinimumGroup";
            this.yMinimumGroup.RowCount = 1;
            this.yMinimumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMinimumGroup.Size = new System.Drawing.Size(162, 29);
            this.yMinimumGroup.TabIndex = 2;
            // 
            // yMinimumLabel
            // 
            this.yMinimumLabel.AutoSize = true;
            this.yMinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinimumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.yMinimumLabel.Location = new System.Drawing.Point(2, 0);
            this.yMinimumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yMinimumLabel.Name = "yMinimumLabel";
            this.yMinimumLabel.Size = new System.Drawing.Size(64, 29);
            this.yMinimumLabel.TabIndex = 0;
            this.yMinimumLabel.Text = "Y minimum";
            this.yMinimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axisYMinimumNumericUpDown
            // 
            this.axisYMinimumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.axisYMinimumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisYMinimumNumericUpDown.DecimalPlaces = 3;
            this.axisYMinimumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisYMinimumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisYMinimumNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.axisYMinimumNumericUpDown.Location = new System.Drawing.Point(70, 2);
            this.axisYMinimumNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.axisYMinimumNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.axisYMinimumNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.axisYMinimumNumericUpDown.Name = "axisYMinimumNumericUpDown";
            this.axisYMinimumNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.axisYMinimumNumericUpDown.TabIndex = 1;
            this.axisYMinimumNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            this.axisYMinimumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            // 
            // yMaximumGroup
            // 
            this.yMaximumGroup.ColumnCount = 2;
            this.yMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.yMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMaximumGroup.Controls.Add(this.yMaximumLabel, 0, 0);
            this.yMaximumGroup.Controls.Add(this.axisYMaximumNumericUpDown, 1, 0);
            this.yMaximumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMaximumGroup.Location = new System.Drawing.Point(503, 4);
            this.yMaximumGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yMaximumGroup.Name = "yMaximumGroup";
            this.yMaximumGroup.RowCount = 1;
            this.yMaximumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMaximumGroup.Size = new System.Drawing.Size(162, 29);
            this.yMaximumGroup.TabIndex = 3;
            // 
            // yMaximumLabel
            // 
            this.yMaximumLabel.AutoSize = true;
            this.yMaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMaximumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.yMaximumLabel.Location = new System.Drawing.Point(2, 0);
            this.yMaximumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yMaximumLabel.Name = "yMaximumLabel";
            this.yMaximumLabel.Size = new System.Drawing.Size(64, 29);
            this.yMaximumLabel.TabIndex = 0;
            this.yMaximumLabel.Text = "Y maximum";
            this.yMaximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axisYMaximumNumericUpDown
            // 
            this.axisYMaximumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.axisYMaximumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisYMaximumNumericUpDown.DecimalPlaces = 3;
            this.axisYMaximumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisYMaximumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisYMaximumNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.axisYMaximumNumericUpDown.Location = new System.Drawing.Point(70, 2);
            this.axisYMaximumNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.axisYMaximumNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.axisYMaximumNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.axisYMaximumNumericUpDown.Name = "axisYMaximumNumericUpDown";
            this.axisYMaximumNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.axisYMaximumNumericUpDown.TabIndex = 1;
            this.axisYMaximumNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.axisYMaximumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            // 
            // intervalGroup
            // 
            this.intervalGroup.ColumnCount = 2;
            this.intervalGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.intervalGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.intervalGroup.Controls.Add(this.intervalLabel, 0, 0);
            this.intervalGroup.Controls.Add(this.updateIntervalNumericUpDown, 1, 0);
            this.intervalGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intervalGroup.Location = new System.Drawing.Point(669, 4);
            this.intervalGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.intervalGroup.Name = "intervalGroup";
            this.intervalGroup.RowCount = 1;
            this.intervalGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.intervalGroup.Size = new System.Drawing.Size(166, 29);
            this.intervalGroup.TabIndex = 4;
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.intervalLabel.Location = new System.Drawing.Point(2, 0);
            this.intervalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(64, 29);
            this.intervalLabel.TabIndex = 0;
            this.intervalLabel.Text = "Update (ms)";
            this.intervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateIntervalNumericUpDown
            // 
            this.updateIntervalNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.updateIntervalNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.updateIntervalNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateIntervalNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.updateIntervalNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Location = new System.Drawing.Point(70, 2);
            this.updateIntervalNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.updateIntervalNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Name = "updateIntervalNumericUpDown";
            this.updateIntervalNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.updateIntervalNumericUpDown.TabIndex = 1;
            this.updateIntervalNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            // 
            // FormSuspensionGeometry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(840, 634);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.settingsToolbar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(642, 414);
            this.Name = "FormSuspensionGeometry";
            this.Text = "Suspension Geometry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuspensionGeometry_FormClosing);
            this.Load += new System.EventHandler(this.FormSuspensionGeometry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.settingsToolbar.ResumeLayout(false);
            this.xMinimumGroup.ResumeLayout(false);
            this.xMinimumGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMinimumNumericUpDown)).EndInit();
            this.xMaximumGroup.ResumeLayout(false);
            this.xMaximumGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMaximumNumericUpDown)).EndInit();
            this.yMinimumGroup.ResumeLayout(false);
            this.yMinimumGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMinimumNumericUpDown)).EndInit();
            this.yMaximumGroup.ResumeLayout(false);
            this.yMaximumGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMaximumNumericUpDown)).EndInit();
            this.intervalGroup.ResumeLayout(false);
            this.intervalGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel settingsToolbar;
        private System.Windows.Forms.TableLayoutPanel xMinimumGroup;
        private System.Windows.Forms.TableLayoutPanel xMaximumGroup;
        private System.Windows.Forms.TableLayoutPanel yMinimumGroup;
        private System.Windows.Forms.TableLayoutPanel yMaximumGroup;
        private System.Windows.Forms.TableLayoutPanel intervalGroup;
        private System.Windows.Forms.Label xMinimumLabel;
        private System.Windows.Forms.Label xMaximumLabel;
        private System.Windows.Forms.Label yMinimumLabel;
        private System.Windows.Forms.Label yMaximumLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown axisXMinimumNumericUpDown;
        private System.Windows.Forms.NumericUpDown axisXMaximumNumericUpDown;
        private System.Windows.Forms.NumericUpDown axisYMinimumNumericUpDown;
        private System.Windows.Forms.NumericUpDown axisYMaximumNumericUpDown;
        private System.Windows.Forms.NumericUpDown updateIntervalNumericUpDown;
    }
}
