using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    partial class FormTireTemperatures
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private TableLayoutPanel rootLayout, toolbarLayout, trackLayout;
        private FlowLayoutPanel actionsPanel;
        private Chart chartTimeSeries;
        private Button startButton, stopButton, clearButton, settingsButton;
        private Label statusLabel;
        private Timer timer1;
        private CheckBox track1Enabled, track1FL, track1FR, track1RL, track1RR;
        private ComboBox track1Field;
        private CheckBox track2Enabled, track2FL, track2FR, track2RL, track2RR;
        private ComboBox track2Field;
        private CheckBox track3Enabled, track3FL, track3FR, track3RL, track3RR;
        private ComboBox track3Field;
        private CheckBox track4Enabled, track4FL, track4FR, track4RL, track4RR;
        private ComboBox track4Field;
        private CheckBox track5Enabled, track5FL, track5FR, track5RL, track5RR;
        private ComboBox track5Field;

        private Label header0;
        private Label header1;
        private Label header2;
        private Label header3;
        private Label header4;
        private Label header5;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.actionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.trackLayout = new System.Windows.Forms.TableLayoutPanel();
            this.header0 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.header2 = new System.Windows.Forms.Label();
            this.header3 = new System.Windows.Forms.Label();
            this.header4 = new System.Windows.Forms.Label();
            this.header5 = new System.Windows.Forms.Label();
            this.track1Enabled = new System.Windows.Forms.CheckBox();
            this.track1Field = new System.Windows.Forms.ComboBox();
            this.track1FL = new System.Windows.Forms.CheckBox();
            this.track1FR = new System.Windows.Forms.CheckBox();
            this.track1RL = new System.Windows.Forms.CheckBox();
            this.track1RR = new System.Windows.Forms.CheckBox();
            this.track2Enabled = new System.Windows.Forms.CheckBox();
            this.track2Field = new System.Windows.Forms.ComboBox();
            this.track2FL = new System.Windows.Forms.CheckBox();
            this.track2FR = new System.Windows.Forms.CheckBox();
            this.track2RL = new System.Windows.Forms.CheckBox();
            this.track2RR = new System.Windows.Forms.CheckBox();
            this.track3Enabled = new System.Windows.Forms.CheckBox();
            this.track3Field = new System.Windows.Forms.ComboBox();
            this.track3FL = new System.Windows.Forms.CheckBox();
            this.track3FR = new System.Windows.Forms.CheckBox();
            this.track3RL = new System.Windows.Forms.CheckBox();
            this.track3RR = new System.Windows.Forms.CheckBox();
            this.track4Enabled = new System.Windows.Forms.CheckBox();
            this.track4Field = new System.Windows.Forms.ComboBox();
            this.track4FL = new System.Windows.Forms.CheckBox();
            this.track4FR = new System.Windows.Forms.CheckBox();
            this.track4RL = new System.Windows.Forms.CheckBox();
            this.track4RR = new System.Windows.Forms.CheckBox();
            this.track5Enabled = new System.Windows.Forms.CheckBox();
            this.track5Field = new System.Windows.Forms.ComboBox();
            this.track5FL = new System.Windows.Forms.CheckBox();
            this.track5FR = new System.Windows.Forms.CheckBox();
            this.track5RL = new System.Windows.Forms.CheckBox();
            this.track5RR = new System.Windows.Forms.CheckBox();
            this.chartTimeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rootLayout.SuspendLayout();
            this.toolbarLayout.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            this.trackLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.toolbarLayout, 0, 0);
            this.rootLayout.Controls.Add(this.trackLayout, 0, 1);
            this.rootLayout.Controls.Add(this.chartTimeSeries, 0, 2);
            this.rootLayout.Controls.Add(this.statusLabel, 0, 3);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.Padding = new System.Windows.Forms.Padding(4);
            this.rootLayout.RowCount = 4;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.rootLayout.Size = new System.Drawing.Size(1260, 900);
            this.rootLayout.TabIndex = 0;
            // 
            // toolbarLayout
            // 
            this.toolbarLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toolbarLayout.ColumnCount = 1;
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbarLayout.Controls.Add(this.actionsPanel, 0, 0);
            this.toolbarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarLayout.Location = new System.Drawing.Point(7, 7);
            this.toolbarLayout.Name = "toolbarLayout";
            this.toolbarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.toolbarLayout.Size = new System.Drawing.Size(1246, 42);
            this.toolbarLayout.TabIndex = 0;
            // 
            // actionsPanel
            // 
            this.actionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.actionsPanel.Controls.Add(this.startButton);
            this.actionsPanel.Controls.Add(this.stopButton);
            this.actionsPanel.Controls.Add(this.clearButton);
            this.actionsPanel.Controls.Add(this.settingsButton);
            this.actionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsPanel.Location = new System.Drawing.Point(3, 3);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Padding = new System.Windows.Forms.Padding(4, 5, 0, 0);
            this.actionsPanel.Size = new System.Drawing.Size(1240, 36);
            this.actionsPanel.TabIndex = 0;
            this.actionsPanel.WrapContents = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(6, 7);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(130, 31);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start / Resume";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.stopButton.ForeColor = System.Drawing.Color.White;
            this.stopButton.Location = new System.Drawing.Point(145, 7);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(87, 31);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Pause";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(241, 7);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(118, 31);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear History";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(368, 7);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(135, 31);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Chart Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // trackLayout
            // 
            this.trackLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.trackLayout.ColumnCount = 6;
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.trackLayout.Controls.Add(this.header0, 0, 0);
            this.trackLayout.Controls.Add(this.header1, 1, 0);
            this.trackLayout.Controls.Add(this.header2, 2, 0);
            this.trackLayout.Controls.Add(this.header3, 3, 0);
            this.trackLayout.Controls.Add(this.header4, 4, 0);
            this.trackLayout.Controls.Add(this.header5, 5, 0);
            this.trackLayout.Controls.Add(this.track1Enabled, 0, 1);
            this.trackLayout.Controls.Add(this.track1Field, 1, 1);
            this.trackLayout.Controls.Add(this.track1FL, 2, 1);
            this.trackLayout.Controls.Add(this.track1FR, 3, 1);
            this.trackLayout.Controls.Add(this.track1RL, 4, 1);
            this.trackLayout.Controls.Add(this.track1RR, 5, 1);
            this.trackLayout.Controls.Add(this.track2Enabled, 0, 2);
            this.trackLayout.Controls.Add(this.track2Field, 1, 2);
            this.trackLayout.Controls.Add(this.track2FL, 2, 2);
            this.trackLayout.Controls.Add(this.track2FR, 3, 2);
            this.trackLayout.Controls.Add(this.track2RL, 4, 2);
            this.trackLayout.Controls.Add(this.track2RR, 5, 2);
            this.trackLayout.Controls.Add(this.track3Enabled, 0, 3);
            this.trackLayout.Controls.Add(this.track3Field, 1, 3);
            this.trackLayout.Controls.Add(this.track3FL, 2, 3);
            this.trackLayout.Controls.Add(this.track3FR, 3, 3);
            this.trackLayout.Controls.Add(this.track3RL, 4, 3);
            this.trackLayout.Controls.Add(this.track3RR, 5, 3);
            this.trackLayout.Controls.Add(this.track4Enabled, 0, 4);
            this.trackLayout.Controls.Add(this.track4Field, 1, 4);
            this.trackLayout.Controls.Add(this.track4FL, 2, 4);
            this.trackLayout.Controls.Add(this.track4FR, 3, 4);
            this.trackLayout.Controls.Add(this.track4RL, 4, 4);
            this.trackLayout.Controls.Add(this.track4RR, 5, 4);
            this.trackLayout.Controls.Add(this.track5Enabled, 0, 5);
            this.trackLayout.Controls.Add(this.track5Field, 1, 5);
            this.trackLayout.Controls.Add(this.track5FL, 2, 5);
            this.trackLayout.Controls.Add(this.track5FR, 3, 5);
            this.trackLayout.Controls.Add(this.track5RL, 4, 5);
            this.trackLayout.Controls.Add(this.track5RR, 5, 5);
            this.trackLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackLayout.Location = new System.Drawing.Point(7, 55);
            this.trackLayout.Name = "trackLayout";
            this.trackLayout.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.trackLayout.RowCount = 6;
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.trackLayout.Size = new System.Drawing.Size(1246, 185);
            this.trackLayout.TabIndex = 1;
            // 
            // header0
            // 
            this.header0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header0.ForeColor = System.Drawing.Color.Gainsboro;
            this.header0.Location = new System.Drawing.Point(8, 3);
            this.header0.Name = "header0";
            this.header0.Size = new System.Drawing.Size(66, 22);
            this.header0.TabIndex = 0;
            this.header0.Text = "Plot";
            this.header0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header1
            // 
            this.header1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header1.ForeColor = System.Drawing.Color.Gainsboro;
            this.header1.Location = new System.Drawing.Point(80, 3);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(898, 22);
            this.header1.TabIndex = 1;
            this.header1.Text = "Y measurement (X always RaceTime)";
            this.header1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header2
            // 
            this.header2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header2.ForeColor = System.Drawing.Color.Gainsboro;
            this.header2.Location = new System.Drawing.Point(984, 3);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(59, 22);
            this.header2.TabIndex = 2;
            this.header2.Text = "Front L";
            this.header2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header3
            // 
            this.header3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header3.ForeColor = System.Drawing.Color.Gainsboro;
            this.header3.Location = new System.Drawing.Point(1049, 3);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(59, 22);
            this.header3.TabIndex = 3;
            this.header3.Text = "Front R";
            this.header3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header4
            // 
            this.header4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header4.ForeColor = System.Drawing.Color.Gainsboro;
            this.header4.Location = new System.Drawing.Point(1114, 3);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(59, 22);
            this.header4.TabIndex = 4;
            this.header4.Text = "Rear L";
            this.header4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header5
            // 
            this.header5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header5.ForeColor = System.Drawing.Color.Gainsboro;
            this.header5.Location = new System.Drawing.Point(1179, 3);
            this.header5.Name = "header5";
            this.header5.Size = new System.Drawing.Size(59, 22);
            this.header5.TabIndex = 5;
            this.header5.Text = "Rear R";
            this.header5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // track1Enabled
            // 
            this.track1Enabled.Checked = true;
            this.track1Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1Enabled.ForeColor = System.Drawing.Color.White;
            this.track1Enabled.Location = new System.Drawing.Point(9, 27);
            this.track1Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track1Enabled.Name = "track1Enabled";
            this.track1Enabled.Size = new System.Drawing.Size(66, 28);
            this.track1Enabled.TabIndex = 6;
            this.track1Enabled.Text = "1";
            // 
            // track1Field
            // 
            this.track1Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track1Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track1Field.ForeColor = System.Drawing.Color.White;
            this.track1Field.Location = new System.Drawing.Point(79, 27);
            this.track1Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track1Field.Name = "track1Field";
            this.track1Field.Size = new System.Drawing.Size(897, 33);
            this.track1Field.TabIndex = 7;
            // 
            // track1FL
            // 
            this.track1FL.Checked = true;
            this.track1FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1FL.ForeColor = System.Drawing.Color.White;
            this.track1FL.Location = new System.Drawing.Point(983, 27);
            this.track1FL.Margin = new System.Windows.Forms.Padding(2);
            this.track1FL.Name = "track1FL";
            this.track1FL.Size = new System.Drawing.Size(61, 28);
            this.track1FL.TabIndex = 8;
            this.track1FL.Text = "FL";
            // 
            // track1FR
            // 
            this.track1FR.Checked = true;
            this.track1FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1FR.ForeColor = System.Drawing.Color.White;
            this.track1FR.Location = new System.Drawing.Point(1048, 27);
            this.track1FR.Margin = new System.Windows.Forms.Padding(2);
            this.track1FR.Name = "track1FR";
            this.track1FR.Size = new System.Drawing.Size(61, 28);
            this.track1FR.TabIndex = 9;
            this.track1FR.Text = "FR";
            // 
            // track1RL
            // 
            this.track1RL.Checked = true;
            this.track1RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1RL.ForeColor = System.Drawing.Color.White;
            this.track1RL.Location = new System.Drawing.Point(1113, 27);
            this.track1RL.Margin = new System.Windows.Forms.Padding(2);
            this.track1RL.Name = "track1RL";
            this.track1RL.Size = new System.Drawing.Size(61, 28);
            this.track1RL.TabIndex = 10;
            this.track1RL.Text = "RL";
            // 
            // track1RR
            // 
            this.track1RR.Checked = true;
            this.track1RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1RR.ForeColor = System.Drawing.Color.White;
            this.track1RR.Location = new System.Drawing.Point(1178, 27);
            this.track1RR.Margin = new System.Windows.Forms.Padding(2);
            this.track1RR.Name = "track1RR";
            this.track1RR.Size = new System.Drawing.Size(61, 28);
            this.track1RR.TabIndex = 11;
            this.track1RR.Text = "RR";
            // 
            // track2Enabled
            // 
            this.track2Enabled.Checked = true;
            this.track2Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2Enabled.ForeColor = System.Drawing.Color.White;
            this.track2Enabled.Location = new System.Drawing.Point(9, 59);
            this.track2Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track2Enabled.Name = "track2Enabled";
            this.track2Enabled.Size = new System.Drawing.Size(66, 28);
            this.track2Enabled.TabIndex = 12;
            this.track2Enabled.Text = "2";
            // 
            // track2Field
            // 
            this.track2Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track2Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track2Field.ForeColor = System.Drawing.Color.White;
            this.track2Field.Location = new System.Drawing.Point(79, 59);
            this.track2Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track2Field.Name = "track2Field";
            this.track2Field.Size = new System.Drawing.Size(897, 33);
            this.track2Field.TabIndex = 13;
            // 
            // track2FL
            // 
            this.track2FL.Checked = true;
            this.track2FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2FL.ForeColor = System.Drawing.Color.White;
            this.track2FL.Location = new System.Drawing.Point(983, 59);
            this.track2FL.Margin = new System.Windows.Forms.Padding(2);
            this.track2FL.Name = "track2FL";
            this.track2FL.Size = new System.Drawing.Size(61, 28);
            this.track2FL.TabIndex = 14;
            this.track2FL.Text = "FL";
            // 
            // track2FR
            // 
            this.track2FR.Checked = true;
            this.track2FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2FR.ForeColor = System.Drawing.Color.White;
            this.track2FR.Location = new System.Drawing.Point(1048, 59);
            this.track2FR.Margin = new System.Windows.Forms.Padding(2);
            this.track2FR.Name = "track2FR";
            this.track2FR.Size = new System.Drawing.Size(61, 28);
            this.track2FR.TabIndex = 15;
            this.track2FR.Text = "FR";
            // 
            // track2RL
            // 
            this.track2RL.Checked = true;
            this.track2RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2RL.ForeColor = System.Drawing.Color.White;
            this.track2RL.Location = new System.Drawing.Point(1113, 59);
            this.track2RL.Margin = new System.Windows.Forms.Padding(2);
            this.track2RL.Name = "track2RL";
            this.track2RL.Size = new System.Drawing.Size(61, 28);
            this.track2RL.TabIndex = 16;
            this.track2RL.Text = "RL";
            // 
            // track2RR
            // 
            this.track2RR.Checked = true;
            this.track2RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2RR.ForeColor = System.Drawing.Color.White;
            this.track2RR.Location = new System.Drawing.Point(1178, 59);
            this.track2RR.Margin = new System.Windows.Forms.Padding(2);
            this.track2RR.Name = "track2RR";
            this.track2RR.Size = new System.Drawing.Size(61, 28);
            this.track2RR.TabIndex = 17;
            this.track2RR.Text = "RR";
            // 
            // track3Enabled
            // 
            this.track3Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3Enabled.ForeColor = System.Drawing.Color.White;
            this.track3Enabled.Location = new System.Drawing.Point(9, 91);
            this.track3Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track3Enabled.Name = "track3Enabled";
            this.track3Enabled.Size = new System.Drawing.Size(66, 28);
            this.track3Enabled.TabIndex = 18;
            this.track3Enabled.Text = "3";
            // 
            // track3Field
            // 
            this.track3Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track3Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track3Field.ForeColor = System.Drawing.Color.White;
            this.track3Field.Location = new System.Drawing.Point(79, 91);
            this.track3Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track3Field.Name = "track3Field";
            this.track3Field.Size = new System.Drawing.Size(897, 33);
            this.track3Field.TabIndex = 19;
            // 
            // track3FL
            // 
            this.track3FL.Checked = true;
            this.track3FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3FL.ForeColor = System.Drawing.Color.White;
            this.track3FL.Location = new System.Drawing.Point(983, 91);
            this.track3FL.Margin = new System.Windows.Forms.Padding(2);
            this.track3FL.Name = "track3FL";
            this.track3FL.Size = new System.Drawing.Size(61, 28);
            this.track3FL.TabIndex = 20;
            this.track3FL.Text = "FL";
            // 
            // track3FR
            // 
            this.track3FR.Checked = true;
            this.track3FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3FR.ForeColor = System.Drawing.Color.White;
            this.track3FR.Location = new System.Drawing.Point(1048, 91);
            this.track3FR.Margin = new System.Windows.Forms.Padding(2);
            this.track3FR.Name = "track3FR";
            this.track3FR.Size = new System.Drawing.Size(61, 28);
            this.track3FR.TabIndex = 21;
            this.track3FR.Text = "FR";
            // 
            // track3RL
            // 
            this.track3RL.Checked = true;
            this.track3RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3RL.ForeColor = System.Drawing.Color.White;
            this.track3RL.Location = new System.Drawing.Point(1113, 91);
            this.track3RL.Margin = new System.Windows.Forms.Padding(2);
            this.track3RL.Name = "track3RL";
            this.track3RL.Size = new System.Drawing.Size(61, 28);
            this.track3RL.TabIndex = 22;
            this.track3RL.Text = "RL";
            // 
            // track3RR
            // 
            this.track3RR.Checked = true;
            this.track3RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3RR.ForeColor = System.Drawing.Color.White;
            this.track3RR.Location = new System.Drawing.Point(1178, 91);
            this.track3RR.Margin = new System.Windows.Forms.Padding(2);
            this.track3RR.Name = "track3RR";
            this.track3RR.Size = new System.Drawing.Size(61, 28);
            this.track3RR.TabIndex = 23;
            this.track3RR.Text = "RR";
            // 
            // track4Enabled
            // 
            this.track4Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4Enabled.ForeColor = System.Drawing.Color.White;
            this.track4Enabled.Location = new System.Drawing.Point(9, 123);
            this.track4Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track4Enabled.Name = "track4Enabled";
            this.track4Enabled.Size = new System.Drawing.Size(66, 28);
            this.track4Enabled.TabIndex = 24;
            this.track4Enabled.Text = "4";
            // 
            // track4Field
            // 
            this.track4Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track4Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track4Field.ForeColor = System.Drawing.Color.White;
            this.track4Field.Location = new System.Drawing.Point(79, 123);
            this.track4Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track4Field.Name = "track4Field";
            this.track4Field.Size = new System.Drawing.Size(897, 33);
            this.track4Field.TabIndex = 25;
            // 
            // track4FL
            // 
            this.track4FL.Checked = true;
            this.track4FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4FL.ForeColor = System.Drawing.Color.White;
            this.track4FL.Location = new System.Drawing.Point(983, 123);
            this.track4FL.Margin = new System.Windows.Forms.Padding(2);
            this.track4FL.Name = "track4FL";
            this.track4FL.Size = new System.Drawing.Size(61, 28);
            this.track4FL.TabIndex = 26;
            this.track4FL.Text = "FL";
            // 
            // track4FR
            // 
            this.track4FR.Checked = true;
            this.track4FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4FR.ForeColor = System.Drawing.Color.White;
            this.track4FR.Location = new System.Drawing.Point(1048, 123);
            this.track4FR.Margin = new System.Windows.Forms.Padding(2);
            this.track4FR.Name = "track4FR";
            this.track4FR.Size = new System.Drawing.Size(61, 28);
            this.track4FR.TabIndex = 27;
            this.track4FR.Text = "FR";
            // 
            // track4RL
            // 
            this.track4RL.Checked = true;
            this.track4RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4RL.ForeColor = System.Drawing.Color.White;
            this.track4RL.Location = new System.Drawing.Point(1113, 123);
            this.track4RL.Margin = new System.Windows.Forms.Padding(2);
            this.track4RL.Name = "track4RL";
            this.track4RL.Size = new System.Drawing.Size(61, 28);
            this.track4RL.TabIndex = 28;
            this.track4RL.Text = "RL";
            // 
            // track4RR
            // 
            this.track4RR.Checked = true;
            this.track4RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4RR.ForeColor = System.Drawing.Color.White;
            this.track4RR.Location = new System.Drawing.Point(1178, 123);
            this.track4RR.Margin = new System.Windows.Forms.Padding(2);
            this.track4RR.Name = "track4RR";
            this.track4RR.Size = new System.Drawing.Size(61, 28);
            this.track4RR.TabIndex = 29;
            this.track4RR.Text = "RR";
            // 
            // track5Enabled
            // 
            this.track5Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5Enabled.ForeColor = System.Drawing.Color.White;
            this.track5Enabled.Location = new System.Drawing.Point(9, 155);
            this.track5Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track5Enabled.Name = "track5Enabled";
            this.track5Enabled.Size = new System.Drawing.Size(66, 28);
            this.track5Enabled.TabIndex = 30;
            this.track5Enabled.Text = "5";
            // 
            // track5Field
            // 
            this.track5Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track5Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track5Field.ForeColor = System.Drawing.Color.White;
            this.track5Field.Location = new System.Drawing.Point(79, 155);
            this.track5Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track5Field.Name = "track5Field";
            this.track5Field.Size = new System.Drawing.Size(897, 33);
            this.track5Field.TabIndex = 31;
            // 
            // track5FL
            // 
            this.track5FL.Checked = true;
            this.track5FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5FL.ForeColor = System.Drawing.Color.White;
            this.track5FL.Location = new System.Drawing.Point(983, 155);
            this.track5FL.Margin = new System.Windows.Forms.Padding(2);
            this.track5FL.Name = "track5FL";
            this.track5FL.Size = new System.Drawing.Size(61, 28);
            this.track5FL.TabIndex = 32;
            this.track5FL.Text = "FL";
            // 
            // track5FR
            // 
            this.track5FR.Checked = true;
            this.track5FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5FR.ForeColor = System.Drawing.Color.White;
            this.track5FR.Location = new System.Drawing.Point(1048, 155);
            this.track5FR.Margin = new System.Windows.Forms.Padding(2);
            this.track5FR.Name = "track5FR";
            this.track5FR.Size = new System.Drawing.Size(61, 28);
            this.track5FR.TabIndex = 33;
            this.track5FR.Text = "FR";
            // 
            // track5RL
            // 
            this.track5RL.Checked = true;
            this.track5RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5RL.ForeColor = System.Drawing.Color.White;
            this.track5RL.Location = new System.Drawing.Point(1113, 155);
            this.track5RL.Margin = new System.Windows.Forms.Padding(2);
            this.track5RL.Name = "track5RL";
            this.track5RL.Size = new System.Drawing.Size(61, 28);
            this.track5RL.TabIndex = 34;
            this.track5RL.Text = "RL";
            // 
            // track5RR
            // 
            this.track5RR.Checked = true;
            this.track5RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5RR.ForeColor = System.Drawing.Color.White;
            this.track5RR.Location = new System.Drawing.Point(1178, 155);
            this.track5RR.Margin = new System.Windows.Forms.Padding(2);
            this.track5RR.Name = "track5RR";
            this.track5RR.Size = new System.Drawing.Size(61, 28);
            this.track5RR.TabIndex = 35;
            this.track5RR.Text = "RR";
            // 
            // chartTimeSeries
            // 
            this.chartTimeSeries.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "Plot1";
            this.chartTimeSeries.ChartAreas.Add(chartArea1);
            this.chartTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTimeSeries.Location = new System.Drawing.Point(4, 246);
            this.chartTimeSeries.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chartTimeSeries.Name = "chartTimeSeries";
            this.chartTimeSeries.Size = new System.Drawing.Size(1252, 622);
            this.chartTimeSeries.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.statusLabel.Location = new System.Drawing.Point(7, 871);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(1246, 25);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Waiting for telemetry | RaceTime is stored in milliseconds";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // FormTireTemperatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1260, 900);
            this.Controls.Add(this.rootLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(730, 570);
            this.Name = "FormTireTemperatures";
            this.Text = "Live Telemetry Time Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TireTemperatures_FormClosing);
            this.Load += new System.EventHandler(this.TireTemperatures_Load);
            this.rootLayout.ResumeLayout(false);
            this.toolbarLayout.ResumeLayout(false);
            this.actionsPanel.ResumeLayout(false);
            this.trackLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
