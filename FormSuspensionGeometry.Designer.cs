namespace Physics_Data_Debug
{
    partial class FormSuspensionGeometry
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.settingsToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.cameraFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.azimuthLabel = new System.Windows.Forms.Label();
            this.azimuthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.elevationLabel = new System.Windows.Forms.Label();
            this.elevationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.updateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.resetViewButton = new System.Windows.Forms.Button();
            this.displayFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.perspectiveCheckBox = new System.Windows.Forms.CheckBox();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.labelsCheckBox = new System.Windows.Forms.CheckBox();
            this.legendCheckBox = new System.Windows.Forms.CheckBox();
            this.rotateSpindleCheckBox = new System.Windows.Forms.CheckBox();
            this.frontViewButton = new System.Windows.Forms.Button();
            this.sideViewButton = new System.Windows.Forms.Button();
            this.topViewButton = new System.Windows.Forms.Button();
            this.isometricViewButton = new System.Windows.Forms.Button();
            this.sceneLayout = new System.Windows.Forms.TableLayoutPanel();
            this.front3DView = new Physics_Data_Debug.Suspension3DView();
            this.rear3DView = new Physics_Data_Debug.Suspension3DView();
            this.settingsToolbar.SuspendLayout();
            this.cameraFlow.SuspendLayout();
            this.displayFlow.SuspendLayout();
            this.sceneLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azimuthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 100;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // settingsToolbar
            // 
            this.settingsToolbar.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.settingsToolbar.ColumnCount = 1;
            this.settingsToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsToolbar.Controls.Add(this.cameraFlow, 0, 0);
            this.settingsToolbar.Controls.Add(this.displayFlow, 0, 1);
            this.settingsToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsToolbar.Location = new System.Drawing.Point(0, 0);
            this.settingsToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.settingsToolbar.Name = "settingsToolbar";
            this.settingsToolbar.RowCount = 2;
            this.settingsToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.settingsToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.settingsToolbar.Size = new System.Drawing.Size(940, 80);
            this.settingsToolbar.TabIndex = 0;
            // 
            // cameraFlow
            // 
            this.cameraFlow.AutoScroll = true;
            this.cameraFlow.BackColor = System.Drawing.Color.FromArgb(34, 34, 34);
            this.cameraFlow.Controls.Add(this.azimuthLabel);
            this.cameraFlow.Controls.Add(this.azimuthNumericUpDown);
            this.cameraFlow.Controls.Add(this.elevationLabel);
            this.cameraFlow.Controls.Add(this.elevationNumericUpDown);
            this.cameraFlow.Controls.Add(this.zoomLabel);
            this.cameraFlow.Controls.Add(this.zoomNumericUpDown);
            this.cameraFlow.Controls.Add(this.intervalLabel);
            this.cameraFlow.Controls.Add(this.updateIntervalNumericUpDown);
            this.cameraFlow.Controls.Add(this.resetViewButton);
            this.cameraFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraFlow.Location = new System.Drawing.Point(0, 0);
            this.cameraFlow.Margin = new System.Windows.Forms.Padding(0);
            this.cameraFlow.Name = "cameraFlow";
            this.cameraFlow.Padding = new System.Windows.Forms.Padding(5, 6, 4, 1);
            this.cameraFlow.Size = new System.Drawing.Size(940, 40);
            this.cameraFlow.TabIndex = 0;
            this.cameraFlow.WrapContents = false;
            // 
            // azimuthLabel
            // 
            this.azimuthLabel.AutoSize = true;
            this.azimuthLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.azimuthLabel.Margin = new System.Windows.Forms.Padding(4, 6, 2, 0);
            this.azimuthLabel.Name = "azimuthLabel";
            this.azimuthLabel.Text = "Azimuth";
            // 
            // azimuthNumericUpDown
            // 
            this.azimuthNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.azimuthNumericUpDown.DecimalPlaces = 1;
            this.azimuthNumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.azimuthNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.azimuthNumericUpDown.Location = new System.Drawing.Point(64, 7);
            this.azimuthNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 9, 2);
            this.azimuthNumericUpDown.Maximum = new decimal(new int[] { 359, 0, 0, 0 });
            this.azimuthNumericUpDown.Name = "azimuthNumericUpDown";
            this.azimuthNumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.azimuthNumericUpDown.TabIndex = 1;
            this.azimuthNumericUpDown.Value = new decimal(new int[] { 32, 0, 0, 0 });
            this.azimuthNumericUpDown.ValueChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // elevationLabel
            // 
            this.elevationLabel.AutoSize = true;
            this.elevationLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.elevationLabel.Margin = new System.Windows.Forms.Padding(4, 6, 2, 0);
            this.elevationLabel.Name = "elevationLabel";
            this.elevationLabel.Text = "Elevation";
            // 
            // elevationNumericUpDown
            // 
            this.elevationNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.elevationNumericUpDown.DecimalPlaces = 1;
            this.elevationNumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.elevationNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.elevationNumericUpDown.Location = new System.Drawing.Point(211, 7);
            this.elevationNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 9, 2);
            this.elevationNumericUpDown.Maximum = new decimal(new int[] { 89, 0, 0, 0 });
            this.elevationNumericUpDown.Minimum = new decimal(new int[] { 89, 0, 0, -2147483648 });
            this.elevationNumericUpDown.Name = "elevationNumericUpDown";
            this.elevationNumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.elevationNumericUpDown.TabIndex = 3;
            this.elevationNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.elevationNumericUpDown.ValueChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.zoomLabel.Margin = new System.Windows.Forms.Padding(4, 6, 2, 0);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Text = "Zoom %";
            // 
            // zoomNumericUpDown
            // 
            this.zoomNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.zoomNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.zoomNumericUpDown.Location = new System.Drawing.Point(345, 7);
            this.zoomNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 9, 2);
            this.zoomNumericUpDown.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            this.zoomNumericUpDown.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            this.zoomNumericUpDown.Name = "zoomNumericUpDown";
            this.zoomNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.zoomNumericUpDown.TabIndex = 5;
            this.zoomNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            this.zoomNumericUpDown.ValueChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.intervalLabel.Margin = new System.Windows.Forms.Padding(4, 6, 2, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Text = "Update ms";
            // 
            // updateIntervalNumericUpDown
            // 
            this.updateIntervalNumericUpDown.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            this.updateIntervalNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.updateIntervalNumericUpDown.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.updateIntervalNumericUpDown.Location = new System.Drawing.Point(512, 7);
            this.updateIntervalNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 9, 2);
            this.updateIntervalNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.updateIntervalNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.updateIntervalNumericUpDown.Name = "updateIntervalNumericUpDown";
            this.updateIntervalNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.updateIntervalNumericUpDown.TabIndex = 7;
            this.updateIntervalNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            this.updateIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // resetViewButton
            // 
            this.resetViewButton.BackColor = System.Drawing.Color.FromArgb(52, 52, 52);
            this.resetViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetViewButton.ForeColor = System.Drawing.Color.White;
            this.resetViewButton.Location = new System.Drawing.Point(605, 6);
            this.resetViewButton.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.resetViewButton.Name = "resetViewButton";
            this.resetViewButton.Size = new System.Drawing.Size(105, 27);
            this.resetViewButton.TabIndex = 8;
            this.resetViewButton.Text = "Reset view";
            this.resetViewButton.UseVisualStyleBackColor = false;
            this.resetViewButton.Click += new System.EventHandler(this.ViewPreset_Click);
            // 
            // displayFlow
            // 
            this.displayFlow.AutoScroll = true;
            this.displayFlow.BackColor = System.Drawing.Color.FromArgb(27, 27, 27);
            this.displayFlow.Controls.Add(this.perspectiveCheckBox);
            this.displayFlow.Controls.Add(this.gridCheckBox);
            this.displayFlow.Controls.Add(this.labelsCheckBox);
            this.displayFlow.Controls.Add(this.legendCheckBox);
            this.displayFlow.Controls.Add(this.rotateSpindleCheckBox);
            this.displayFlow.Controls.Add(this.frontViewButton);
            this.displayFlow.Controls.Add(this.sideViewButton);
            this.displayFlow.Controls.Add(this.topViewButton);
            this.displayFlow.Controls.Add(this.isometricViewButton);
            this.displayFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayFlow.Location = new System.Drawing.Point(0, 40);
            this.displayFlow.Margin = new System.Windows.Forms.Padding(0);
            this.displayFlow.Name = "displayFlow";
            this.displayFlow.Padding = new System.Windows.Forms.Padding(7, 4, 4, 1);
            this.displayFlow.Size = new System.Drawing.Size(940, 40);
            this.displayFlow.TabIndex = 1;
            this.displayFlow.WrapContents = false;
            // 
            // perspectiveCheckBox
            // 
            this.perspectiveCheckBox.AutoSize = true;
            this.perspectiveCheckBox.ForeColor = System.Drawing.Color.White;
            this.perspectiveCheckBox.Location = new System.Drawing.Point(10, 11);
            this.perspectiveCheckBox.Margin = new System.Windows.Forms.Padding(3, 7, 10, 0);
            this.perspectiveCheckBox.Name = "perspectiveCheckBox";
            this.perspectiveCheckBox.Text = "Perspective";
            this.perspectiveCheckBox.Checked = true;
            this.perspectiveCheckBox.UseVisualStyleBackColor = true;
            this.perspectiveCheckBox.CheckedChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.ForeColor = System.Drawing.Color.White;
            this.gridCheckBox.Location = new System.Drawing.Point(115, 11);
            this.gridCheckBox.Margin = new System.Windows.Forms.Padding(3, 7, 10, 0);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Text = "Grid";
            this.gridCheckBox.Checked = true;
            this.gridCheckBox.UseVisualStyleBackColor = true;
            this.gridCheckBox.CheckedChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // labelsCheckBox
            // 
            this.labelsCheckBox.AutoSize = true;
            this.labelsCheckBox.ForeColor = System.Drawing.Color.White;
            this.labelsCheckBox.Location = new System.Drawing.Point(173, 11);
            this.labelsCheckBox.Margin = new System.Windows.Forms.Padding(3, 7, 10, 0);
            this.labelsCheckBox.Name = "labelsCheckBox";
            this.labelsCheckBox.Text = "Point names";
            this.labelsCheckBox.UseVisualStyleBackColor = true;
            this.labelsCheckBox.CheckedChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // legendCheckBox
            // 
            this.legendCheckBox.AutoSize = true;
            this.legendCheckBox.ForeColor = System.Drawing.Color.White;
            this.legendCheckBox.Location = new System.Drawing.Point(277, 11);
            this.legendCheckBox.Margin = new System.Windows.Forms.Padding(3, 7, 10, 0);
            this.legendCheckBox.Name = "legendCheckBox";
            this.legendCheckBox.Text = "Legend";
            this.legendCheckBox.Checked = true;
            this.legendCheckBox.UseVisualStyleBackColor = true;
            this.legendCheckBox.CheckedChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // rotateSpindleCheckBox
            // 
            this.rotateSpindleCheckBox.AutoSize = true;
            this.rotateSpindleCheckBox.ForeColor = System.Drawing.Color.White;
            this.rotateSpindleCheckBox.Location = new System.Drawing.Point(356, 11);
            this.rotateSpindleCheckBox.Margin = new System.Windows.Forms.Padding(3, 7, 10, 0);
            this.rotateSpindleCheckBox.Name = "rotateSpindleCheckBox";
            this.rotateSpindleCheckBox.Text = "Rotate spindle offsets";
            this.rotateSpindleCheckBox.Checked = true;
            this.rotateSpindleCheckBox.UseVisualStyleBackColor = true;
            this.rotateSpindleCheckBox.CheckedChanged += new System.EventHandler(this.SettingsValueChanged);
            // 
            // frontViewButton
            // 
            this.frontViewButton.BackColor = System.Drawing.Color.FromArgb(52, 52, 52);
            this.frontViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frontViewButton.ForeColor = System.Drawing.Color.White;
            this.frontViewButton.Location = new System.Drawing.Point(542, 4);
            this.frontViewButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.frontViewButton.Name = "frontViewButton";
            this.frontViewButton.Size = new System.Drawing.Size(65, 28);
            this.frontViewButton.TabIndex = 4;
            this.frontViewButton.Text = "Front";
            this.frontViewButton.UseVisualStyleBackColor = false;
            this.frontViewButton.Click += new System.EventHandler(this.ViewPreset_Click);
            // 
            // sideViewButton
            // 
            this.sideViewButton.BackColor = System.Drawing.Color.FromArgb(52, 52, 52);
            this.sideViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sideViewButton.ForeColor = System.Drawing.Color.White;
            this.sideViewButton.Location = new System.Drawing.Point(613, 4);
            this.sideViewButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.sideViewButton.Name = "sideViewButton";
            this.sideViewButton.Size = new System.Drawing.Size(65, 28);
            this.sideViewButton.TabIndex = 5;
            this.sideViewButton.Text = "Side";
            this.sideViewButton.UseVisualStyleBackColor = false;
            this.sideViewButton.Click += new System.EventHandler(this.ViewPreset_Click);
            // 
            // topViewButton
            // 
            this.topViewButton.BackColor = System.Drawing.Color.FromArgb(52, 52, 52);
            this.topViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topViewButton.ForeColor = System.Drawing.Color.White;
            this.topViewButton.Location = new System.Drawing.Point(684, 4);
            this.topViewButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.topViewButton.Name = "topViewButton";
            this.topViewButton.Size = new System.Drawing.Size(65, 28);
            this.topViewButton.TabIndex = 6;
            this.topViewButton.Text = "Top";
            this.topViewButton.UseVisualStyleBackColor = false;
            this.topViewButton.Click += new System.EventHandler(this.ViewPreset_Click);
            // 
            // isometricViewButton
            // 
            this.isometricViewButton.BackColor = System.Drawing.Color.FromArgb(52, 52, 52);
            this.isometricViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.isometricViewButton.ForeColor = System.Drawing.Color.White;
            this.isometricViewButton.Location = new System.Drawing.Point(755, 4);
            this.isometricViewButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.isometricViewButton.Name = "isometricViewButton";
            this.isometricViewButton.Size = new System.Drawing.Size(88, 28);
            this.isometricViewButton.TabIndex = 7;
            this.isometricViewButton.Text = "Isometric";
            this.isometricViewButton.UseVisualStyleBackColor = false;
            this.isometricViewButton.Click += new System.EventHandler(this.ViewPreset_Click);
            // 
            // sceneLayout
            // 
            this.sceneLayout.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.sceneLayout.ColumnCount = 1;
            this.sceneLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sceneLayout.Controls.Add(this.front3DView, 0, 0);
            this.sceneLayout.Controls.Add(this.rear3DView, 0, 1);
            this.sceneLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneLayout.Location = new System.Drawing.Point(0, 80);
            this.sceneLayout.Margin = new System.Windows.Forms.Padding(0);
            this.sceneLayout.Name = "sceneLayout";
            this.sceneLayout.Padding = new System.Windows.Forms.Padding(3);
            this.sceneLayout.RowCount = 2;
            this.sceneLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sceneLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sceneLayout.Size = new System.Drawing.Size(940, 620);
            this.sceneLayout.TabIndex = 1;
            // 
            // front3DView
            // 
            this.front3DView.BackColor = System.Drawing.Color.FromArgb(12, 14, 18);
            this.front3DView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.front3DView.ForeColor = System.Drawing.Color.Gainsboro;
            this.front3DView.Location = new System.Drawing.Point(5, 5);
            this.front3DView.Margin = new System.Windows.Forms.Padding(2);
            this.front3DView.Name = "front3DView";
            this.front3DView.Size = new System.Drawing.Size(930, 304);
            this.front3DView.TabIndex = 0;
            this.front3DView.ViewTitle = "FRONT SUSPENSION — FL / FR";
            // 
            // rear3DView
            // 
            this.rear3DView.BackColor = System.Drawing.Color.FromArgb(12, 14, 18);
            this.rear3DView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rear3DView.ForeColor = System.Drawing.Color.Gainsboro;
            this.rear3DView.Location = new System.Drawing.Point(5, 313);
            this.rear3DView.Margin = new System.Windows.Forms.Padding(2);
            this.rear3DView.Name = "rear3DView";
            this.rear3DView.Size = new System.Drawing.Size(930, 302);
            this.rear3DView.TabIndex = 1;
            this.rear3DView.ViewTitle = "REAR SUSPENSION — RL / RR";
            // 
            // FormSuspensionGeometry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(940, 700);
            this.Controls.Add(this.sceneLayout);
            this.Controls.Add(this.settingsToolbar);
            this.MinimumSize = new System.Drawing.Size(700, 490);
            this.Name = "FormSuspensionGeometry";
            this.Text = "Suspension Geometry — 3D";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuspensionGeometry_FormClosing);
            this.Load += new System.EventHandler(this.FormSuspensionGeometry_Load);
            this.settingsToolbar.ResumeLayout(false);
            this.cameraFlow.ResumeLayout(false);
            this.cameraFlow.PerformLayout();
            this.displayFlow.ResumeLayout(false);
            this.displayFlow.PerformLayout();
            this.sceneLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.azimuthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel settingsToolbar;
        private System.Windows.Forms.FlowLayoutPanel cameraFlow;
        private System.Windows.Forms.FlowLayoutPanel displayFlow;
        private System.Windows.Forms.TableLayoutPanel sceneLayout;
        private Suspension3DView front3DView;
        private Suspension3DView rear3DView;
        private System.Windows.Forms.Label azimuthLabel;
        private System.Windows.Forms.Label elevationLabel;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown azimuthNumericUpDown;
        private System.Windows.Forms.NumericUpDown elevationNumericUpDown;
        private System.Windows.Forms.NumericUpDown zoomNumericUpDown;
        private System.Windows.Forms.NumericUpDown updateIntervalNumericUpDown;
        private System.Windows.Forms.Button resetViewButton;
        private System.Windows.Forms.Button frontViewButton;
        private System.Windows.Forms.Button sideViewButton;
        private System.Windows.Forms.Button topViewButton;
        private System.Windows.Forms.Button isometricViewButton;
        private System.Windows.Forms.CheckBox perspectiveCheckBox;
        private System.Windows.Forms.CheckBox gridCheckBox;
        private System.Windows.Forms.CheckBox labelsCheckBox;
        private System.Windows.Forms.CheckBox legendCheckBox;
        private System.Windows.Forms.CheckBox rotateSpindleCheckBox;
    }
}
