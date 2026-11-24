using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    partial class FormLiveTimeChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
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
            this.toolbarLayout.Location = new System.Drawing.Point(4, 4);
            this.toolbarLayout.Margin = new System.Windows.Forms.Padding(0);
            this.toolbarLayout.Name = "toolbarLayout";
            this.toolbarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.toolbarLayout.Size = new System.Drawing.Size(1252, 37);
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
            this.actionsPanel.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.actionsPanel.Size = new System.Drawing.Size(1246, 47);
            this.actionsPanel.TabIndex = 0;
            this.actionsPanel.WrapContents = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(7, 3);
            this.startButton.Margin = new System.Windows.Forms.Padding(1, 1, 7, 1);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 30);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Resume";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.stopButton.ForeColor = System.Drawing.Color.White;
            this.stopButton.Location = new System.Drawing.Point(160, 3);
            this.stopButton.Margin = new System.Windows.Forms.Padding(1, 1, 7, 1);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(98, 30);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Pause";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(266, 3);
            this.clearButton.Margin = new System.Windows.Forms.Padding(1, 1, 7, 1);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(142, 30);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear History";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(416, 3);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(1, 1, 7, 1);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(155, 30);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Chart Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // trackLayout
            // 
            this.trackLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.trackLayout.ColumnCount = 6;
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.trackLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
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
            this.trackLayout.Location = new System.Drawing.Point(7, 44);
            this.trackLayout.Name = "trackLayout";
            this.trackLayout.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackLayout.RowCount = 6;
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.trackLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.trackLayout.Size = new System.Drawing.Size(1246, 161);
            this.trackLayout.TabIndex = 1;
            // 
            // header0
            // 
            this.header0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header0.ForeColor = System.Drawing.Color.Gainsboro;
            this.header0.Location = new System.Drawing.Point(7, 3);
            this.header0.Name = "header0";
            this.header0.Size = new System.Drawing.Size(46, 26);
            this.header0.TabIndex = 0;
            this.header0.Text = "Plot";
            this.header0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header1
            // 
            this.header1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header1.ForeColor = System.Drawing.Color.Gainsboro;
            this.header1.Location = new System.Drawing.Point(59, 3);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(980, 26);
            this.header1.TabIndex = 1;
            this.header1.Text = "Y measurement (X always RaceTime)";
            this.header1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header2
            // 
            this.header2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header2.ForeColor = System.Drawing.Color.LimeGreen;
            this.header2.Location = new System.Drawing.Point(1045, 3);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(44, 26);
            this.header2.TabIndex = 2;
            this.header2.Text = "FL";
            this.header2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // header3
            // 
            this.header3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.header3.Location = new System.Drawing.Point(1095, 3);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(44, 26);
            this.header3.TabIndex = 3;
            this.header3.Text = "FR";
            this.header3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // header4
            // 
            this.header4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header4.ForeColor = System.Drawing.Color.Gold;
            this.header4.Location = new System.Drawing.Point(1145, 3);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(44, 26);
            this.header4.TabIndex = 4;
            this.header4.Text = "RL";
            this.header4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // header5
            // 
            this.header5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header5.ForeColor = System.Drawing.Color.MediumOrchid;
            this.header5.Location = new System.Drawing.Point(1195, 3);
            this.header5.Name = "header5";
            this.header5.Size = new System.Drawing.Size(44, 26);
            this.header5.TabIndex = 5;
            this.header5.Text = "RR";
            this.header5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // track1Enabled
            // 
            this.track1Enabled.Checked = true;
            this.track1Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1Enabled.ForeColor = System.Drawing.Color.White;
            this.track1Enabled.Location = new System.Drawing.Point(8, 31);
            this.track1Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track1Enabled.Name = "track1Enabled";
            this.track1Enabled.Size = new System.Drawing.Size(46, 22);
            this.track1Enabled.TabIndex = 6;
            this.track1Enabled.Text = "1";
            // 
            // track1Field
            // 
            this.track1Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track1Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track1Field.ForeColor = System.Drawing.Color.White;
            this.track1Field.Items.AddRange(new object[] {
            "None",
            "TreadTemperature",
            "InnerTemperature",
            "SlipRatio",
            "VerticalLoad",
            "SlipAngleDeg"});
            this.track1Field.Location = new System.Drawing.Point(58, 31);
            this.track1Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track1Field.Name = "track1Field";
            this.track1Field.Size = new System.Drawing.Size(979, 23);
            this.track1Field.TabIndex = 7;
            // 
            // track1FL
            // 
            this.track1FL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track1FL.Checked = true;
            this.track1FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1FL.ForeColor = System.Drawing.Color.White;
            this.track1FL.Location = new System.Drawing.Point(1044, 31);
            this.track1FL.Margin = new System.Windows.Forms.Padding(2);
            this.track1FL.Name = "track1FL";
            this.track1FL.Size = new System.Drawing.Size(46, 22);
            this.track1FL.TabIndex = 8;
            // 
            // track1FR
            // 
            this.track1FR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track1FR.Checked = true;
            this.track1FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1FR.ForeColor = System.Drawing.Color.White;
            this.track1FR.Location = new System.Drawing.Point(1094, 31);
            this.track1FR.Margin = new System.Windows.Forms.Padding(2);
            this.track1FR.Name = "track1FR";
            this.track1FR.Size = new System.Drawing.Size(46, 22);
            this.track1FR.TabIndex = 9;
            // 
            // track1RL
            // 
            this.track1RL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track1RL.Checked = true;
            this.track1RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1RL.ForeColor = System.Drawing.Color.White;
            this.track1RL.Location = new System.Drawing.Point(1144, 31);
            this.track1RL.Margin = new System.Windows.Forms.Padding(2);
            this.track1RL.Name = "track1RL";
            this.track1RL.Size = new System.Drawing.Size(46, 22);
            this.track1RL.TabIndex = 10;
            // 
            // track1RR
            // 
            this.track1RR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track1RR.Checked = true;
            this.track1RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track1RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track1RR.ForeColor = System.Drawing.Color.White;
            this.track1RR.Location = new System.Drawing.Point(1194, 31);
            this.track1RR.Margin = new System.Windows.Forms.Padding(2);
            this.track1RR.Name = "track1RR";
            this.track1RR.Size = new System.Drawing.Size(46, 22);
            this.track1RR.TabIndex = 11;
            // 
            // track2Enabled
            // 
            this.track2Enabled.Checked = true;
            this.track2Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2Enabled.ForeColor = System.Drawing.Color.White;
            this.track2Enabled.Location = new System.Drawing.Point(8, 57);
            this.track2Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track2Enabled.Name = "track2Enabled";
            this.track2Enabled.Size = new System.Drawing.Size(46, 22);
            this.track2Enabled.TabIndex = 12;
            this.track2Enabled.Text = "2";
            // 
            // track2Field
            // 
            this.track2Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track2Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track2Field.ForeColor = System.Drawing.Color.White;
            this.track2Field.Items.AddRange(new object[] {
            "None",
            "TreadTemperature",
            "InnerTemperature",
            "SlipRatio",
            "VerticalLoad",
            "SlipAngleDeg"});
            this.track2Field.Location = new System.Drawing.Point(58, 57);
            this.track2Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track2Field.Name = "track2Field";
            this.track2Field.Size = new System.Drawing.Size(979, 23);
            this.track2Field.TabIndex = 13;
            // 
            // track2FL
            // 
            this.track2FL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track2FL.Checked = true;
            this.track2FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2FL.ForeColor = System.Drawing.Color.White;
            this.track2FL.Location = new System.Drawing.Point(1044, 57);
            this.track2FL.Margin = new System.Windows.Forms.Padding(2);
            this.track2FL.Name = "track2FL";
            this.track2FL.Size = new System.Drawing.Size(46, 22);
            this.track2FL.TabIndex = 14;
            // 
            // track2FR
            // 
            this.track2FR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track2FR.Checked = true;
            this.track2FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2FR.ForeColor = System.Drawing.Color.White;
            this.track2FR.Location = new System.Drawing.Point(1094, 57);
            this.track2FR.Margin = new System.Windows.Forms.Padding(2);
            this.track2FR.Name = "track2FR";
            this.track2FR.Size = new System.Drawing.Size(46, 22);
            this.track2FR.TabIndex = 15;
            // 
            // track2RL
            // 
            this.track2RL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track2RL.Checked = true;
            this.track2RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2RL.ForeColor = System.Drawing.Color.White;
            this.track2RL.Location = new System.Drawing.Point(1144, 57);
            this.track2RL.Margin = new System.Windows.Forms.Padding(2);
            this.track2RL.Name = "track2RL";
            this.track2RL.Size = new System.Drawing.Size(46, 22);
            this.track2RL.TabIndex = 16;
            // 
            // track2RR
            // 
            this.track2RR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track2RR.Checked = true;
            this.track2RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track2RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track2RR.ForeColor = System.Drawing.Color.White;
            this.track2RR.Location = new System.Drawing.Point(1194, 57);
            this.track2RR.Margin = new System.Windows.Forms.Padding(2);
            this.track2RR.Name = "track2RR";
            this.track2RR.Size = new System.Drawing.Size(46, 22);
            this.track2RR.TabIndex = 17;
            // 
            // track3Enabled
            // 
            this.track3Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3Enabled.ForeColor = System.Drawing.Color.White;
            this.track3Enabled.Location = new System.Drawing.Point(8, 83);
            this.track3Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track3Enabled.Name = "track3Enabled";
            this.track3Enabled.Size = new System.Drawing.Size(46, 22);
            this.track3Enabled.TabIndex = 18;
            this.track3Enabled.Text = "3";
            // 
            // track3Field
            // 
            this.track3Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track3Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track3Field.ForeColor = System.Drawing.Color.White;
            this.track3Field.Items.AddRange(new object[] {
            "None",
            "TreadTemperature",
            "InnerTemperature",
            "SlipRatio",
            "VerticalLoad",
            "SlipAngleDeg"});
            this.track3Field.Location = new System.Drawing.Point(58, 83);
            this.track3Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track3Field.Name = "track3Field";
            this.track3Field.Size = new System.Drawing.Size(979, 23);
            this.track3Field.TabIndex = 19;
            // 
            // track3FL
            // 
            this.track3FL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track3FL.Checked = true;
            this.track3FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3FL.ForeColor = System.Drawing.Color.White;
            this.track3FL.Location = new System.Drawing.Point(1044, 83);
            this.track3FL.Margin = new System.Windows.Forms.Padding(2);
            this.track3FL.Name = "track3FL";
            this.track3FL.Size = new System.Drawing.Size(46, 22);
            this.track3FL.TabIndex = 20;
            // 
            // track3FR
            // 
            this.track3FR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track3FR.Checked = true;
            this.track3FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3FR.ForeColor = System.Drawing.Color.White;
            this.track3FR.Location = new System.Drawing.Point(1094, 83);
            this.track3FR.Margin = new System.Windows.Forms.Padding(2);
            this.track3FR.Name = "track3FR";
            this.track3FR.Size = new System.Drawing.Size(46, 22);
            this.track3FR.TabIndex = 21;
            // 
            // track3RL
            // 
            this.track3RL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track3RL.Checked = true;
            this.track3RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3RL.ForeColor = System.Drawing.Color.White;
            this.track3RL.Location = new System.Drawing.Point(1144, 83);
            this.track3RL.Margin = new System.Windows.Forms.Padding(2);
            this.track3RL.Name = "track3RL";
            this.track3RL.Size = new System.Drawing.Size(46, 22);
            this.track3RL.TabIndex = 22;
            // 
            // track3RR
            // 
            this.track3RR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track3RR.Checked = true;
            this.track3RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track3RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track3RR.ForeColor = System.Drawing.Color.White;
            this.track3RR.Location = new System.Drawing.Point(1194, 83);
            this.track3RR.Margin = new System.Windows.Forms.Padding(2);
            this.track3RR.Name = "track3RR";
            this.track3RR.Size = new System.Drawing.Size(46, 22);
            this.track3RR.TabIndex = 23;
            // 
            // track4Enabled
            // 
            this.track4Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4Enabled.ForeColor = System.Drawing.Color.White;
            this.track4Enabled.Location = new System.Drawing.Point(8, 109);
            this.track4Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track4Enabled.Name = "track4Enabled";
            this.track4Enabled.Size = new System.Drawing.Size(46, 22);
            this.track4Enabled.TabIndex = 24;
            this.track4Enabled.Text = "4";
            // 
            // track4Field
            // 
            this.track4Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track4Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track4Field.ForeColor = System.Drawing.Color.White;
            this.track4Field.Items.AddRange(new object[] {
            "None",
            "TreadTemperature",
            "InnerTemperature",
            "SlipRatio",
            "VerticalLoad",
            "SlipAngleDeg"});
            this.track4Field.Location = new System.Drawing.Point(58, 109);
            this.track4Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track4Field.Name = "track4Field";
            this.track4Field.Size = new System.Drawing.Size(979, 23);
            this.track4Field.TabIndex = 25;
            // 
            // track4FL
            // 
            this.track4FL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track4FL.Checked = true;
            this.track4FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4FL.ForeColor = System.Drawing.Color.White;
            this.track4FL.Location = new System.Drawing.Point(1044, 109);
            this.track4FL.Margin = new System.Windows.Forms.Padding(2);
            this.track4FL.Name = "track4FL";
            this.track4FL.Size = new System.Drawing.Size(46, 22);
            this.track4FL.TabIndex = 26;
            // 
            // track4FR
            // 
            this.track4FR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track4FR.Checked = true;
            this.track4FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4FR.ForeColor = System.Drawing.Color.White;
            this.track4FR.Location = new System.Drawing.Point(1094, 109);
            this.track4FR.Margin = new System.Windows.Forms.Padding(2);
            this.track4FR.Name = "track4FR";
            this.track4FR.Size = new System.Drawing.Size(46, 22);
            this.track4FR.TabIndex = 27;
            // 
            // track4RL
            // 
            this.track4RL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track4RL.Checked = true;
            this.track4RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4RL.ForeColor = System.Drawing.Color.White;
            this.track4RL.Location = new System.Drawing.Point(1144, 109);
            this.track4RL.Margin = new System.Windows.Forms.Padding(2);
            this.track4RL.Name = "track4RL";
            this.track4RL.Size = new System.Drawing.Size(46, 22);
            this.track4RL.TabIndex = 28;
            // 
            // track4RR
            // 
            this.track4RR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track4RR.Checked = true;
            this.track4RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track4RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track4RR.ForeColor = System.Drawing.Color.White;
            this.track4RR.Location = new System.Drawing.Point(1194, 109);
            this.track4RR.Margin = new System.Windows.Forms.Padding(2);
            this.track4RR.Name = "track4RR";
            this.track4RR.Size = new System.Drawing.Size(46, 22);
            this.track4RR.TabIndex = 29;
            // 
            // track5Enabled
            // 
            this.track5Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5Enabled.ForeColor = System.Drawing.Color.White;
            this.track5Enabled.Location = new System.Drawing.Point(8, 135);
            this.track5Enabled.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.track5Enabled.Name = "track5Enabled";
            this.track5Enabled.Size = new System.Drawing.Size(46, 21);
            this.track5Enabled.TabIndex = 30;
            this.track5Enabled.Text = "5";
            // 
            // track5Field
            // 
            this.track5Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.track5Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.track5Field.ForeColor = System.Drawing.Color.White;
            this.track5Field.Items.AddRange(new object[] {
            "None",
            "TreadTemperature",
            "InnerTemperature",
            "SlipRatio",
            "VerticalLoad",
            "SlipAngleDeg"});
            this.track5Field.Location = new System.Drawing.Point(58, 135);
            this.track5Field.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.track5Field.Name = "track5Field";
            this.track5Field.Size = new System.Drawing.Size(979, 23);
            this.track5Field.TabIndex = 31;
            // 
            // track5FL
            // 
            this.track5FL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track5FL.Checked = true;
            this.track5FL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5FL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5FL.ForeColor = System.Drawing.Color.White;
            this.track5FL.Location = new System.Drawing.Point(1044, 135);
            this.track5FL.Margin = new System.Windows.Forms.Padding(2);
            this.track5FL.Name = "track5FL";
            this.track5FL.Size = new System.Drawing.Size(46, 21);
            this.track5FL.TabIndex = 32;
            // 
            // track5FR
            // 
            this.track5FR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track5FR.Checked = true;
            this.track5FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5FR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5FR.ForeColor = System.Drawing.Color.White;
            this.track5FR.Location = new System.Drawing.Point(1094, 135);
            this.track5FR.Margin = new System.Windows.Forms.Padding(2);
            this.track5FR.Name = "track5FR";
            this.track5FR.Size = new System.Drawing.Size(46, 21);
            this.track5FR.TabIndex = 33;
            // 
            // track5RL
            // 
            this.track5RL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track5RL.Checked = true;
            this.track5RL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5RL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5RL.ForeColor = System.Drawing.Color.White;
            this.track5RL.Location = new System.Drawing.Point(1144, 135);
            this.track5RL.Margin = new System.Windows.Forms.Padding(2);
            this.track5RL.Name = "track5RL";
            this.track5RL.Size = new System.Drawing.Size(46, 21);
            this.track5RL.TabIndex = 34;
            // 
            // track5RR
            // 
            this.track5RR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.track5RR.Checked = true;
            this.track5RR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track5RR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.track5RR.ForeColor = System.Drawing.Color.White;
            this.track5RR.Location = new System.Drawing.Point(1194, 135);
            this.track5RR.Margin = new System.Windows.Forms.Padding(2);
            this.track5RR.Name = "track5RR";
            this.track5RR.Size = new System.Drawing.Size(46, 21);
            this.track5RR.TabIndex = 35;
            // 
            // chartTimeSeries
            // 
            this.chartTimeSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            chartArea1.AxisX.Interval = 10D;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Maximum = 60D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 79F;
            chartArea1.InnerPlotPosition.Width = 87F;
            chartArea1.InnerPlotPosition.X = 10F;
            chartArea1.InnerPlotPosition.Y = 14F;
            chartArea1.Name = "Plot1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 50F;
            chartArea1.Position.Width = 100F;
            chartArea2.AxisX.Interval = 10D;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea2.AxisX.Maximum = 60D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "RaceTime (seconds)";
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 70F;
            chartArea2.InnerPlotPosition.Width = 87F;
            chartArea2.InnerPlotPosition.X = 10F;
            chartArea2.InnerPlotPosition.Y = 14F;
            chartArea2.Name = "Plot2";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 50F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 50F;
            this.chartTimeSeries.ChartAreas.Add(chartArea1);
            this.chartTimeSeries.ChartAreas.Add(chartArea2);
            this.chartTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTimeSeries.Location = new System.Drawing.Point(4, 211);
            this.chartTimeSeries.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chartTimeSeries.Name = "chartTimeSeries";
            this.chartTimeSeries.Size = new System.Drawing.Size(1252, 653);
            this.chartTimeSeries.TabIndex = 2;
            title1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title1.DockedToChartArea = "Plot1";
            title1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "TreadTemperature";
            title2.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title2.DockedToChartArea = "Plot2";
            title2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title2";
            title2.Text = "InnerTemperature";
            this.chartTimeSeries.Titles.Add(title1);
            this.chartTimeSeries.Titles.Add(title2);
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.statusLabel.Location = new System.Drawing.Point(7, 867);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(1246, 29);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Waiting for telemetry | RaceTime is stored in milliseconds";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // FormLiveTimeChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1260, 900);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(730, 570);
            this.Name = "FormLiveTimeChart";
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
