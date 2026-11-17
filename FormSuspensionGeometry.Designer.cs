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
            System.Windows.Forms.DataVisualization.Charting.ChartArea frontArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea rearArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.settingsToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.xMinimumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.xMaximumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.yMinimumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.yMaximumGroup = new System.Windows.Forms.TableLayoutPanel();
            this.intervalGroup = new System.Windows.Forms.TableLayoutPanel();
            this.xMinimumLabel = new System.Windows.Forms.Label();
            this.xMaximumLabel = new System.Windows.Forms.Label();
            this.yMinimumLabel = new System.Windows.Forms.Label();
            this.yMaximumLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.axisXMinimumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.axisXMaximumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.axisYMinimumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.axisYMaximumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.updateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMinimumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMaximumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMinimumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMaximumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).BeginInit();
            this.settingsToolbar.SuspendLayout();
            this.SuspendLayout();
            //
            // timer1
            //
            this.timer1.Interval = 100;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //
            // chart1 — fills the space below the toolbar (no form scrollbars)
            //
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.TabIndex = 1;
            frontArea.Name = "FrontSuspension";
            frontArea.BackColor = System.Drawing.Color.Transparent;
            frontArea.AxisX.Minimum = -1.5D;
            frontArea.AxisX.Maximum = 1.5D;
            frontArea.AxisY.Minimum = -0.5D;
            frontArea.AxisY.Maximum = 1.5D;
            rearArea.Name = "RearSuspension";
            rearArea.BackColor = System.Drawing.Color.Transparent;
            rearArea.AxisX.Minimum = -1.5D;
            rearArea.AxisX.Maximum = 1.5D;
            rearArea.AxisY.Minimum = -0.5D;
            rearArea.AxisY.Maximum = 1.5D;
            this.chart1.ChartAreas.Add(frontArea);
            this.chart1.ChartAreas.Add(rearArea);
            //
            // settingsToolbar — five independent Designer-editable groups
            //
            this.settingsToolbar.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.settingsToolbar.ColumnCount = 5;
            for (int i = 0; i < 5; i++)
                this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsToolbar.Controls.Add(this.xMinimumGroup, 0, 0);
            this.settingsToolbar.Controls.Add(this.xMaximumGroup, 1, 0);
            this.settingsToolbar.Controls.Add(this.yMinimumGroup, 2, 0);
            this.settingsToolbar.Controls.Add(this.yMaximumGroup, 3, 0);
            this.settingsToolbar.Controls.Add(this.intervalGroup, 4, 0);
            this.settingsToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsToolbar.Height = 46;
            this.settingsToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.settingsToolbar.Name = "settingsToolbar";
            this.settingsToolbar.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.settingsToolbar.RowCount = 1;
            this.settingsToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsToolbar.TabIndex = 0;
            //
            // xMinimumGroup
            //
            this.xMinimumGroup.ColumnCount = 2;
            this.xMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.xMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMinimumGroup.Controls.Add(this.xMinimumLabel, 0, 0);
            this.xMinimumGroup.Controls.Add(this.axisXMinimumNumericUpDown, 1, 0);
            this.xMinimumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinimumGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.xMinimumGroup.Name = "xMinimumGroup";
            this.xMinimumGroup.RowCount = 1;
            this.xMinimumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // xMinimumLabel
            //
            this.xMinimumLabel.AutoSize = true;
            this.xMinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinimumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.xMinimumLabel.Name = "xMinimumLabel";
            this.xMinimumLabel.Text = "X minimum";
            this.xMinimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // axisXMinimumNumericUpDown
            //
            this.axisXMinimumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.axisXMinimumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisXMinimumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisXMinimumNumericUpDown.DecimalPlaces = 3;
            this.axisXMinimumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisXMinimumNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.axisXMinimumNumericUpDown.Name = "axisXMinimumNumericUpDown";
            this.axisXMinimumNumericUpDown.Minimum = -100000M;
            this.axisXMinimumNumericUpDown.Maximum = 100000M;
            this.axisXMinimumNumericUpDown.Increment = 0.05M;
            this.axisXMinimumNumericUpDown.Value = -1.5M;
            this.axisXMinimumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            //
            // xMaximumGroup
            //
            this.xMaximumGroup.ColumnCount = 2;
            this.xMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.xMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMaximumGroup.Controls.Add(this.xMaximumLabel, 0, 0);
            this.xMaximumGroup.Controls.Add(this.axisXMaximumNumericUpDown, 1, 0);
            this.xMaximumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMaximumGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.xMaximumGroup.Name = "xMaximumGroup";
            this.xMaximumGroup.RowCount = 1;
            this.xMaximumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // xMaximumLabel
            //
            this.xMaximumLabel.AutoSize = true;
            this.xMaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMaximumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.xMaximumLabel.Name = "xMaximumLabel";
            this.xMaximumLabel.Text = "X maximum";
            this.xMaximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // axisXMaximumNumericUpDown
            //
            this.axisXMaximumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.axisXMaximumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisXMaximumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisXMaximumNumericUpDown.DecimalPlaces = 3;
            this.axisXMaximumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisXMaximumNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.axisXMaximumNumericUpDown.Name = "axisXMaximumNumericUpDown";
            this.axisXMaximumNumericUpDown.Minimum = -100000M;
            this.axisXMaximumNumericUpDown.Maximum = 100000M;
            this.axisXMaximumNumericUpDown.Increment = 0.05M;
            this.axisXMaximumNumericUpDown.Value = 1.5M;
            this.axisXMaximumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            //
            // yMinimumGroup
            //
            this.yMinimumGroup.ColumnCount = 2;
            this.yMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.yMinimumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMinimumGroup.Controls.Add(this.yMinimumLabel, 0, 0);
            this.yMinimumGroup.Controls.Add(this.axisYMinimumNumericUpDown, 1, 0);
            this.yMinimumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinimumGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.yMinimumGroup.Name = "yMinimumGroup";
            this.yMinimumGroup.RowCount = 1;
            this.yMinimumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // yMinimumLabel
            //
            this.yMinimumLabel.AutoSize = true;
            this.yMinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinimumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.yMinimumLabel.Name = "yMinimumLabel";
            this.yMinimumLabel.Text = "Y minimum";
            this.yMinimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // axisYMinimumNumericUpDown
            //
            this.axisYMinimumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.axisYMinimumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisYMinimumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisYMinimumNumericUpDown.DecimalPlaces = 3;
            this.axisYMinimumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisYMinimumNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.axisYMinimumNumericUpDown.Name = "axisYMinimumNumericUpDown";
            this.axisYMinimumNumericUpDown.Minimum = -100000M;
            this.axisYMinimumNumericUpDown.Maximum = 100000M;
            this.axisYMinimumNumericUpDown.Increment = 0.05M;
            this.axisYMinimumNumericUpDown.Value = -0.5M;
            this.axisYMinimumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            //
            // yMaximumGroup
            //
            this.yMaximumGroup.ColumnCount = 2;
            this.yMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.yMaximumGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMaximumGroup.Controls.Add(this.yMaximumLabel, 0, 0);
            this.yMaximumGroup.Controls.Add(this.axisYMaximumNumericUpDown, 1, 0);
            this.yMaximumGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMaximumGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.yMaximumGroup.Name = "yMaximumGroup";
            this.yMaximumGroup.RowCount = 1;
            this.yMaximumGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // yMaximumLabel
            //
            this.yMaximumLabel.AutoSize = true;
            this.yMaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMaximumLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.yMaximumLabel.Name = "yMaximumLabel";
            this.yMaximumLabel.Text = "Y maximum";
            this.yMaximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // axisYMaximumNumericUpDown
            //
            this.axisYMaximumNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.axisYMaximumNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.axisYMaximumNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisYMaximumNumericUpDown.DecimalPlaces = 3;
            this.axisYMaximumNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisYMaximumNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.axisYMaximumNumericUpDown.Name = "axisYMaximumNumericUpDown";
            this.axisYMaximumNumericUpDown.Minimum = -100000M;
            this.axisYMaximumNumericUpDown.Maximum = 100000M;
            this.axisYMaximumNumericUpDown.Increment = 0.05M;
            this.axisYMaximumNumericUpDown.Value = 1.5M;
            this.axisYMaximumNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            //
            // intervalGroup
            //
            this.intervalGroup.ColumnCount = 2;
            this.intervalGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.intervalGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.intervalGroup.Controls.Add(this.intervalLabel, 0, 0);
            this.intervalGroup.Controls.Add(this.updateIntervalNumericUpDown, 1, 0);
            this.intervalGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intervalGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.intervalGroup.Name = "intervalGroup";
            this.intervalGroup.RowCount = 1;
            this.intervalGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // intervalLabel
            //
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Text = "Update (ms)";
            this.intervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // updateIntervalNumericUpDown
            //
            this.updateIntervalNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.updateIntervalNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.updateIntervalNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.updateIntervalNumericUpDown.DecimalPlaces = 0;
            this.updateIntervalNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateIntervalNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.updateIntervalNumericUpDown.Name = "updateIntervalNumericUpDown";
            this.updateIntervalNumericUpDown.Minimum = 10M;
            this.updateIntervalNumericUpDown.Maximum = 10000M;
            this.updateIntervalNumericUpDown.Increment = 10M;
            this.updateIntervalNumericUpDown.Value = 100M;
            this.updateIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.SuspensionGeometrySetting_ValueChanged);
            //
            // FormSuspensionGeometry
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1120, 780);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.settingsToolbar);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "FormSuspensionGeometry";
            this.Text = "Suspension Geometry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuspensionGeometry_FormClosing);
            this.Load += new System.EventHandler(this.FormSuspensionGeometry_Load);
            this.settingsToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMinimumNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisXMaximumNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMinimumNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisYMaximumNumericUpDown)).EndInit();
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
