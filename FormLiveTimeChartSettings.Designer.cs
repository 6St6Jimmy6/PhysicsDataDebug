using System;
using System.Drawing;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    partial class FormLiveTimeChartSettings
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private TableLayoutPanel rootLayout, headerLayout, contentColumns;
        private FlowLayoutPanel actionButtons;
        private Panel leftScroll, rightScroll, SettingsProfilesHost;
        private TableLayoutPanel leftStack, rightStack, generalFields, appearanceFields, wheelColorFields, yRangeFields;
        private GroupBox generalGroup, appearanceGroup, wheelColorGroup, yRangeGroup;
        private Button applyButton, SettingsProfilesButton;
        private NumericUpDown historyLengthNumeric;
        private ComboBox historyUnitCombo;
        private ComboBox timeAxisUnitCombo;
        private NumericUpDown updateIntervalNumeric;
        private NumericUpDown maxSamplesNumeric;
        private ComboBox plotStyleCombo;
        private NumericUpDown lineWidthNumeric;
        private NumericUpDown markerSizeNumeric;
        private ComboBox chartBackgroundCombo;
        private ComboBox plotBackgroundCombo;
        private ComboBox majorGridColorCombo;
        private ComboBox minorGridColorCombo;
        private ComboBox fontColorCombo;
        private ComboBox fontNameCombo;
        private NumericUpDown axisFontSizeNumeric;
        private NumericUpDown titleFontSizeNumeric;
        private NumericUpDown majorGridWidthNumeric;
        private CheckBox majorGridCheck;
        private CheckBox minorGridCheck;
        private CheckBox antialiasCheck;
        private CheckBox yAxisTitleCheck;
        private ComboBox flColorCombo;
        private ComboBox frColorCombo;
        private ComboBox rlColorCombo;
        private ComboBox rrColorCombo;
        private ComboBox sharedColorCombo;
        private CheckBox plot1AutoY;
        private NumericUpDown plot1YMin;
        private NumericUpDown plot1YMax;
        private CheckBox plot2AutoY;
        private NumericUpDown plot2YMin;
        private NumericUpDown plot2YMax;
        private CheckBox plot3AutoY;
        private NumericUpDown plot3YMin;
        private NumericUpDown plot3YMax;
        private CheckBox plot4AutoY;
        private NumericUpDown plot4YMin;
        private NumericUpDown plot4YMax;
        private CheckBox plot5AutoY;
        private NumericUpDown plot5YMin;
        private NumericUpDown plot5YMax;

        private Label historyLengthNumericLabel;
        private Label historyUnitComboLabel;
        private Label timeAxisUnitComboLabel;
        private Label updateIntervalNumericLabel;
        private Label maxSamplesNumericLabel;
        private Label plotStyleComboLabel;
        private Label lineWidthNumericLabel;
        private Label markerSizeNumericLabel;
        private Label chartBackgroundComboLabel;
        private Label plotBackgroundComboLabel;
        private Label majorGridColorComboLabel;
        private Label minorGridColorComboLabel;
        private Label fontColorComboLabel;
        private Label fontNameComboLabel;
        private Label axisFontSizeNumericLabel;
        private Label titleFontSizeNumericLabel;
        private Label majorGridWidthNumericLabel;
        private Label majorGridCheckLabel;
        private Label minorGridCheckLabel;
        private Label antialiasCheckLabel;
        private Label yAxisTitleCheckLabel;
        private Label flColorComboLabel;
        private Label frColorComboLabel;
        private Label rlColorComboLabel;
        private Label rrColorComboLabel;
        private Label sharedColorComboLabel;
        private Label yHeader0;
        private Label yHeader1;
        private Label yHeader2;
        private Label yHeader3;
        private Label plotLabel1;
        private Label plotLabel2;
        private Label plotLabel3;
        private Label plotLabel4;
        private Label plotLabel5;

        private void InitializeComponent()
        {
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.actionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.applyButton = new System.Windows.Forms.Button();
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.SettingsProfilesButton = new System.Windows.Forms.Button();
            this.contentColumns = new System.Windows.Forms.TableLayoutPanel();
            this.leftScroll = new System.Windows.Forms.Panel();
            this.leftStack = new System.Windows.Forms.TableLayoutPanel();
            this.generalGroup = new System.Windows.Forms.GroupBox();
            this.generalFields = new System.Windows.Forms.TableLayoutPanel();
            this.historyLengthNumericLabel = new System.Windows.Forms.Label();
            this.historyLengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.historyUnitComboLabel = new System.Windows.Forms.Label();
            this.historyUnitCombo = new System.Windows.Forms.ComboBox();
            this.timeAxisUnitComboLabel = new System.Windows.Forms.Label();
            this.timeAxisUnitCombo = new System.Windows.Forms.ComboBox();
            this.updateIntervalNumericLabel = new System.Windows.Forms.Label();
            this.updateIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxSamplesNumericLabel = new System.Windows.Forms.Label();
            this.maxSamplesNumeric = new System.Windows.Forms.NumericUpDown();
            this.plotStyleComboLabel = new System.Windows.Forms.Label();
            this.plotStyleCombo = new System.Windows.Forms.ComboBox();
            this.lineWidthNumericLabel = new System.Windows.Forms.Label();
            this.lineWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.markerSizeNumericLabel = new System.Windows.Forms.Label();
            this.markerSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.appearanceGroup = new System.Windows.Forms.GroupBox();
            this.appearanceFields = new System.Windows.Forms.TableLayoutPanel();
            this.chartBackgroundComboLabel = new System.Windows.Forms.Label();
            this.chartBackgroundCombo = new System.Windows.Forms.ComboBox();
            this.plotBackgroundComboLabel = new System.Windows.Forms.Label();
            this.plotBackgroundCombo = new System.Windows.Forms.ComboBox();
            this.majorGridColorComboLabel = new System.Windows.Forms.Label();
            this.majorGridColorCombo = new System.Windows.Forms.ComboBox();
            this.minorGridColorComboLabel = new System.Windows.Forms.Label();
            this.minorGridColorCombo = new System.Windows.Forms.ComboBox();
            this.fontColorComboLabel = new System.Windows.Forms.Label();
            this.fontColorCombo = new System.Windows.Forms.ComboBox();
            this.fontNameComboLabel = new System.Windows.Forms.Label();
            this.fontNameCombo = new System.Windows.Forms.ComboBox();
            this.axisFontSizeNumericLabel = new System.Windows.Forms.Label();
            this.axisFontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.titleFontSizeNumericLabel = new System.Windows.Forms.Label();
            this.titleFontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.majorGridWidthNumericLabel = new System.Windows.Forms.Label();
            this.majorGridWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.majorGridCheckLabel = new System.Windows.Forms.Label();
            this.majorGridCheck = new System.Windows.Forms.CheckBox();
            this.minorGridCheckLabel = new System.Windows.Forms.Label();
            this.minorGridCheck = new System.Windows.Forms.CheckBox();
            this.antialiasCheckLabel = new System.Windows.Forms.Label();
            this.antialiasCheck = new System.Windows.Forms.CheckBox();
            this.yAxisTitleCheckLabel = new System.Windows.Forms.Label();
            this.yAxisTitleCheck = new System.Windows.Forms.CheckBox();
            this.rightScroll = new System.Windows.Forms.Panel();
            this.rightStack = new System.Windows.Forms.TableLayoutPanel();
            this.wheelColorGroup = new System.Windows.Forms.GroupBox();
            this.wheelColorFields = new System.Windows.Forms.TableLayoutPanel();
            this.flColorComboLabel = new System.Windows.Forms.Label();
            this.flColorCombo = new System.Windows.Forms.ComboBox();
            this.frColorComboLabel = new System.Windows.Forms.Label();
            this.frColorCombo = new System.Windows.Forms.ComboBox();
            this.rlColorComboLabel = new System.Windows.Forms.Label();
            this.rlColorCombo = new System.Windows.Forms.ComboBox();
            this.rrColorComboLabel = new System.Windows.Forms.Label();
            this.rrColorCombo = new System.Windows.Forms.ComboBox();
            this.sharedColorComboLabel = new System.Windows.Forms.Label();
            this.sharedColorCombo = new System.Windows.Forms.ComboBox();
            this.yRangeGroup = new System.Windows.Forms.GroupBox();
            this.yRangeFields = new System.Windows.Forms.TableLayoutPanel();
            this.yHeader0 = new System.Windows.Forms.Label();
            this.yHeader1 = new System.Windows.Forms.Label();
            this.yHeader2 = new System.Windows.Forms.Label();
            this.yHeader3 = new System.Windows.Forms.Label();
            this.plotLabel1 = new System.Windows.Forms.Label();
            this.plot1AutoY = new System.Windows.Forms.CheckBox();
            this.plot1YMin = new System.Windows.Forms.NumericUpDown();
            this.plot1YMax = new System.Windows.Forms.NumericUpDown();
            this.plotLabel2 = new System.Windows.Forms.Label();
            this.plot2AutoY = new System.Windows.Forms.CheckBox();
            this.plot2YMin = new System.Windows.Forms.NumericUpDown();
            this.plot2YMax = new System.Windows.Forms.NumericUpDown();
            this.plotLabel3 = new System.Windows.Forms.Label();
            this.plot3AutoY = new System.Windows.Forms.CheckBox();
            this.plot3YMin = new System.Windows.Forms.NumericUpDown();
            this.plot3YMax = new System.Windows.Forms.NumericUpDown();
            this.plotLabel4 = new System.Windows.Forms.Label();
            this.plot4AutoY = new System.Windows.Forms.CheckBox();
            this.plot4YMin = new System.Windows.Forms.NumericUpDown();
            this.plot4YMax = new System.Windows.Forms.NumericUpDown();
            this.plotLabel5 = new System.Windows.Forms.Label();
            this.plot5AutoY = new System.Windows.Forms.CheckBox();
            this.plot5YMin = new System.Windows.Forms.NumericUpDown();
            this.plot5YMax = new System.Windows.Forms.NumericUpDown();
            this.rootLayout.SuspendLayout();
            this.headerLayout.SuspendLayout();
            this.actionButtons.SuspendLayout();
            this.SettingsProfilesHost.SuspendLayout();
            this.contentColumns.SuspendLayout();
            this.leftScroll.SuspendLayout();
            this.leftStack.SuspendLayout();
            this.generalGroup.SuspendLayout();
            this.generalFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyLengthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSamplesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerSizeNumeric)).BeginInit();
            this.appearanceGroup.SuspendLayout();
            this.appearanceFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisFontSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorGridWidthNumeric)).BeginInit();
            this.rightScroll.SuspendLayout();
            this.rightStack.SuspendLayout();
            this.wheelColorGroup.SuspendLayout();
            this.wheelColorFields.SuspendLayout();
            this.yRangeGroup.SuspendLayout();
            this.yRangeFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plot1YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot1YMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot2YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot2YMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot3YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot3YMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot4YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot4YMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot5YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot5YMax)).BeginInit();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.headerLayout, 0, 0);
            this.rootLayout.Controls.Add(this.contentColumns, 0, 1);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 2;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Size = new System.Drawing.Size(720, 760);
            this.rootLayout.TabIndex = 0;
            // 
            // headerLayout
            // 
            this.headerLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.headerLayout.ColumnCount = 1;
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headerLayout.Controls.Add(this.actionButtons, 0, 0);
            this.headerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLayout.Location = new System.Drawing.Point(3, 3);
            this.headerLayout.Name = "headerLayout";
            this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.headerLayout.Size = new System.Drawing.Size(714, 52);
            this.headerLayout.TabIndex = 0;
            // 
            // actionButtons
            // 
            this.actionButtons.Controls.Add(this.applyButton);
            this.actionButtons.Controls.Add(this.SettingsProfilesHost);
            this.actionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtons.Location = new System.Drawing.Point(3, 1);
            this.actionButtons.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.actionButtons.Name = "actionButtons";
            this.actionButtons.Padding = new System.Windows.Forms.Padding(8, 9, 0, 0);
            this.actionButtons.Size = new System.Drawing.Size(708, 50);
            this.actionButtons.TabIndex = 0;
            this.actionButtons.WrapContents = false;
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(10, 10);
            this.applyButton.Margin = new System.Windows.Forms.Padding(2, 1, 8, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(168, 37);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply Settings";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.Controls.Add(this.SettingsProfilesButton);
            this.SettingsProfilesHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesHost.Location = new System.Drawing.Point(186, 9);
            this.SettingsProfilesHost.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Padding = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.SettingsProfilesHost.Size = new System.Drawing.Size(127, 40);
            this.SettingsProfilesHost.TabIndex = 1;
            // 
            // SettingsProfilesButton
            // 
            this.SettingsProfilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.SettingsProfilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesButton.ForeColor = System.Drawing.Color.White;
            this.SettingsProfilesButton.Location = new System.Drawing.Point(0, 1);
            this.SettingsProfilesButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsProfilesButton.Name = "SettingsProfilesButton";
            this.SettingsProfilesButton.Size = new System.Drawing.Size(127, 37);
            this.SettingsProfilesButton.TabIndex = 0;
            this.SettingsProfilesButton.TabStop = false;
            this.SettingsProfilesButton.Text = "Profiles ▼";
            this.SettingsProfilesButton.UseVisualStyleBackColor = false;
            // 
            // contentColumns
            // 
            this.contentColumns.ColumnCount = 2;
            this.contentColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentColumns.Controls.Add(this.leftScroll, 0, 0);
            this.contentColumns.Controls.Add(this.rightScroll, 1, 0);
            this.contentColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentColumns.Location = new System.Drawing.Point(3, 61);
            this.contentColumns.Name = "contentColumns";
            this.contentColumns.Padding = new System.Windows.Forms.Padding(3);
            this.contentColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentColumns.Size = new System.Drawing.Size(714, 696);
            this.contentColumns.TabIndex = 1;
            // 
            // leftScroll
            // 
            this.leftScroll.AutoScroll = true;
            this.leftScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.leftScroll.Controls.Add(this.leftStack);
            this.leftScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftScroll.Location = new System.Drawing.Point(6, 6);
            this.leftScroll.Name = "leftScroll";
            this.leftScroll.Size = new System.Drawing.Size(348, 684);
            this.leftScroll.TabIndex = 0;
            // 
            // leftStack
            // 
            this.leftStack.AutoSize = true;
            this.leftStack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leftStack.ColumnCount = 1;
            this.leftStack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftStack.Controls.Add(this.generalGroup, 0, 0);
            this.leftStack.Controls.Add(this.appearanceGroup, 0, 1);
            this.leftStack.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftStack.Location = new System.Drawing.Point(0, 0);
            this.leftStack.Name = "leftStack";
            this.leftStack.RowCount = 2;
            this.leftStack.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.leftStack.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.leftStack.Size = new System.Drawing.Size(331, 808);
            this.leftStack.TabIndex = 0;
            // 
            // generalGroup
            // 
            this.generalGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.generalGroup.Controls.Add(this.generalFields);
            this.generalGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.generalGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.generalGroup.Location = new System.Drawing.Point(4, 5);
            this.generalGroup.Margin = new System.Windows.Forms.Padding(4, 5, 7, 5);
            this.generalGroup.Name = "generalGroup";
            this.generalGroup.Padding = new System.Windows.Forms.Padding(7, 12, 7, 5);
            this.generalGroup.Size = new System.Drawing.Size(320, 309);
            this.generalGroup.TabIndex = 0;
            this.generalGroup.TabStop = false;
            this.generalGroup.Text = "Time window and series";
            // 
            // generalFields
            // 
            this.generalFields.ColumnCount = 2;
            this.generalFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.generalFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.generalFields.Controls.Add(this.historyLengthNumericLabel, 0, 0);
            this.generalFields.Controls.Add(this.historyLengthNumeric, 1, 0);
            this.generalFields.Controls.Add(this.historyUnitComboLabel, 0, 1);
            this.generalFields.Controls.Add(this.historyUnitCombo, 1, 1);
            this.generalFields.Controls.Add(this.timeAxisUnitComboLabel, 0, 2);
            this.generalFields.Controls.Add(this.timeAxisUnitCombo, 1, 2);
            this.generalFields.Controls.Add(this.updateIntervalNumericLabel, 0, 3);
            this.generalFields.Controls.Add(this.updateIntervalNumeric, 1, 3);
            this.generalFields.Controls.Add(this.maxSamplesNumericLabel, 0, 4);
            this.generalFields.Controls.Add(this.maxSamplesNumeric, 1, 4);
            this.generalFields.Controls.Add(this.plotStyleComboLabel, 0, 5);
            this.generalFields.Controls.Add(this.plotStyleCombo, 1, 5);
            this.generalFields.Controls.Add(this.lineWidthNumericLabel, 0, 6);
            this.generalFields.Controls.Add(this.lineWidthNumeric, 1, 6);
            this.generalFields.Controls.Add(this.markerSizeNumericLabel, 0, 7);
            this.generalFields.Controls.Add(this.markerSizeNumeric, 1, 7);
            this.generalFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalFields.Location = new System.Drawing.Point(7, 28);
            this.generalFields.Name = "generalFields";
            this.generalFields.RowCount = 8;
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.generalFields.Size = new System.Drawing.Size(306, 276);
            this.generalFields.TabIndex = 0;
            // 
            // historyLengthNumericLabel
            // 
            this.historyLengthNumericLabel.AutoEllipsis = true;
            this.historyLengthNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyLengthNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.historyLengthNumericLabel.Location = new System.Drawing.Point(3, 0);
            this.historyLengthNumericLabel.Name = "historyLengthNumericLabel";
            this.historyLengthNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.historyLengthNumericLabel.TabIndex = 0;
            this.historyLengthNumericLabel.Text = "Visible history";
            this.historyLengthNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // historyLengthNumeric
            // 
            this.historyLengthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.historyLengthNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyLengthNumeric.ForeColor = System.Drawing.Color.White;
            this.historyLengthNumeric.Location = new System.Drawing.Point(151, 4);
            this.historyLengthNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.historyLengthNumeric.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.historyLengthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.historyLengthNumeric.Name = "historyLengthNumeric";
            this.historyLengthNumeric.Size = new System.Drawing.Size(153, 23);
            this.historyLengthNumeric.TabIndex = 1;
            this.historyLengthNumeric.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // historyUnitComboLabel
            // 
            this.historyUnitComboLabel.AutoEllipsis = true;
            this.historyUnitComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyUnitComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.historyUnitComboLabel.Location = new System.Drawing.Point(3, 34);
            this.historyUnitComboLabel.Name = "historyUnitComboLabel";
            this.historyUnitComboLabel.Size = new System.Drawing.Size(143, 34);
            this.historyUnitComboLabel.TabIndex = 2;
            this.historyUnitComboLabel.Text = "History unit";
            this.historyUnitComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // historyUnitCombo
            // 
            this.historyUnitCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.historyUnitCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyUnitCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyUnitCombo.ForeColor = System.Drawing.Color.White;
            this.historyUnitCombo.Items.AddRange(new object[] {
            "Seconds",
            "Minutes"});
            this.historyUnitCombo.Location = new System.Drawing.Point(151, 38);
            this.historyUnitCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.historyUnitCombo.Name = "historyUnitCombo";
            this.historyUnitCombo.Size = new System.Drawing.Size(153, 23);
            this.historyUnitCombo.TabIndex = 3;
            // 
            // timeAxisUnitComboLabel
            // 
            this.timeAxisUnitComboLabel.AutoEllipsis = true;
            this.timeAxisUnitComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeAxisUnitComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.timeAxisUnitComboLabel.Location = new System.Drawing.Point(3, 68);
            this.timeAxisUnitComboLabel.Name = "timeAxisUnitComboLabel";
            this.timeAxisUnitComboLabel.Size = new System.Drawing.Size(143, 34);
            this.timeAxisUnitComboLabel.TabIndex = 4;
            this.timeAxisUnitComboLabel.Text = "X axis display";
            this.timeAxisUnitComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeAxisUnitCombo
            // 
            this.timeAxisUnitCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.timeAxisUnitCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeAxisUnitCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeAxisUnitCombo.ForeColor = System.Drawing.Color.White;
            this.timeAxisUnitCombo.Items.AddRange(new object[] {
            "Seconds",
            "Minutes"});
            this.timeAxisUnitCombo.Location = new System.Drawing.Point(151, 72);
            this.timeAxisUnitCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.timeAxisUnitCombo.Name = "timeAxisUnitCombo";
            this.timeAxisUnitCombo.Size = new System.Drawing.Size(153, 23);
            this.timeAxisUnitCombo.TabIndex = 5;
            // 
            // updateIntervalNumericLabel
            // 
            this.updateIntervalNumericLabel.AutoEllipsis = true;
            this.updateIntervalNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateIntervalNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.updateIntervalNumericLabel.Location = new System.Drawing.Point(3, 102);
            this.updateIntervalNumericLabel.Name = "updateIntervalNumericLabel";
            this.updateIntervalNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.updateIntervalNumericLabel.TabIndex = 6;
            this.updateIntervalNumericLabel.Text = "Refresh interval (ms)";
            this.updateIntervalNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateIntervalNumeric
            // 
            this.updateIntervalNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.updateIntervalNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateIntervalNumeric.ForeColor = System.Drawing.Color.White;
            this.updateIntervalNumeric.Location = new System.Drawing.Point(151, 106);
            this.updateIntervalNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.updateIntervalNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updateIntervalNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updateIntervalNumeric.Name = "updateIntervalNumeric";
            this.updateIntervalNumeric.Size = new System.Drawing.Size(153, 23);
            this.updateIntervalNumeric.TabIndex = 7;
            this.updateIntervalNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // maxSamplesNumericLabel
            // 
            this.maxSamplesNumericLabel.AutoEllipsis = true;
            this.maxSamplesNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxSamplesNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.maxSamplesNumericLabel.Location = new System.Drawing.Point(3, 136);
            this.maxSamplesNumericLabel.Name = "maxSamplesNumericLabel";
            this.maxSamplesNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.maxSamplesNumericLabel.TabIndex = 8;
            this.maxSamplesNumericLabel.Text = "Max points per trace";
            this.maxSamplesNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxSamplesNumeric
            // 
            this.maxSamplesNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.maxSamplesNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxSamplesNumeric.ForeColor = System.Drawing.Color.White;
            this.maxSamplesNumeric.Location = new System.Drawing.Point(151, 140);
            this.maxSamplesNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.maxSamplesNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxSamplesNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxSamplesNumeric.Name = "maxSamplesNumeric";
            this.maxSamplesNumeric.Size = new System.Drawing.Size(153, 23);
            this.maxSamplesNumeric.TabIndex = 9;
            this.maxSamplesNumeric.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // plotStyleComboLabel
            // 
            this.plotStyleComboLabel.AutoEllipsis = true;
            this.plotStyleComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotStyleComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotStyleComboLabel.Location = new System.Drawing.Point(3, 170);
            this.plotStyleComboLabel.Name = "plotStyleComboLabel";
            this.plotStyleComboLabel.Size = new System.Drawing.Size(143, 34);
            this.plotStyleComboLabel.TabIndex = 10;
            this.plotStyleComboLabel.Text = "Series type";
            this.plotStyleComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plotStyleCombo
            // 
            this.plotStyleCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plotStyleCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotStyleCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plotStyleCombo.ForeColor = System.Drawing.Color.White;
            this.plotStyleCombo.Items.AddRange(new object[] {
            "FastLine",
            "Line",
            "Spline"});
            this.plotStyleCombo.Location = new System.Drawing.Point(151, 174);
            this.plotStyleCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.plotStyleCombo.Name = "plotStyleCombo";
            this.plotStyleCombo.Size = new System.Drawing.Size(153, 23);
            this.plotStyleCombo.TabIndex = 11;
            // 
            // lineWidthNumericLabel
            // 
            this.lineWidthNumericLabel.AutoEllipsis = true;
            this.lineWidthNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineWidthNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.lineWidthNumericLabel.Location = new System.Drawing.Point(3, 204);
            this.lineWidthNumericLabel.Name = "lineWidthNumericLabel";
            this.lineWidthNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.lineWidthNumericLabel.TabIndex = 12;
            this.lineWidthNumericLabel.Text = "Line thickness (px)";
            this.lineWidthNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineWidthNumeric
            // 
            this.lineWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lineWidthNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.lineWidthNumeric.Location = new System.Drawing.Point(151, 208);
            this.lineWidthNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.lineWidthNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lineWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineWidthNumeric.Name = "lineWidthNumeric";
            this.lineWidthNumeric.Size = new System.Drawing.Size(153, 23);
            this.lineWidthNumeric.TabIndex = 13;
            this.lineWidthNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // markerSizeNumericLabel
            // 
            this.markerSizeNumericLabel.AutoEllipsis = true;
            this.markerSizeNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markerSizeNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.markerSizeNumericLabel.Location = new System.Drawing.Point(3, 238);
            this.markerSizeNumericLabel.Name = "markerSizeNumericLabel";
            this.markerSizeNumericLabel.Size = new System.Drawing.Size(143, 38);
            this.markerSizeNumericLabel.TabIndex = 14;
            this.markerSizeNumericLabel.Text = "Marker diameter (0=off)";
            this.markerSizeNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // markerSizeNumeric
            // 
            this.markerSizeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.markerSizeNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markerSizeNumeric.ForeColor = System.Drawing.Color.White;
            this.markerSizeNumeric.Location = new System.Drawing.Point(151, 242);
            this.markerSizeNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.markerSizeNumeric.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.markerSizeNumeric.Name = "markerSizeNumeric";
            this.markerSizeNumeric.Size = new System.Drawing.Size(153, 23);
            this.markerSizeNumeric.TabIndex = 15;
            // 
            // appearanceGroup
            // 
            this.appearanceGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.appearanceGroup.Controls.Add(this.appearanceFields);
            this.appearanceGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.appearanceGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.appearanceGroup.Location = new System.Drawing.Point(4, 324);
            this.appearanceGroup.Margin = new System.Windows.Forms.Padding(4, 5, 7, 5);
            this.appearanceGroup.Name = "appearanceGroup";
            this.appearanceGroup.Padding = new System.Windows.Forms.Padding(7, 12, 7, 5);
            this.appearanceGroup.Size = new System.Drawing.Size(320, 479);
            this.appearanceGroup.TabIndex = 1;
            this.appearanceGroup.TabStop = false;
            this.appearanceGroup.Text = "Chart appearance and axes";
            // 
            // appearanceFields
            // 
            this.appearanceFields.ColumnCount = 2;
            this.appearanceFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.appearanceFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.appearanceFields.Controls.Add(this.chartBackgroundComboLabel, 0, 0);
            this.appearanceFields.Controls.Add(this.chartBackgroundCombo, 1, 0);
            this.appearanceFields.Controls.Add(this.plotBackgroundComboLabel, 0, 1);
            this.appearanceFields.Controls.Add(this.plotBackgroundCombo, 1, 1);
            this.appearanceFields.Controls.Add(this.majorGridColorComboLabel, 0, 2);
            this.appearanceFields.Controls.Add(this.majorGridColorCombo, 1, 2);
            this.appearanceFields.Controls.Add(this.minorGridColorComboLabel, 0, 3);
            this.appearanceFields.Controls.Add(this.minorGridColorCombo, 1, 3);
            this.appearanceFields.Controls.Add(this.fontColorComboLabel, 0, 4);
            this.appearanceFields.Controls.Add(this.fontColorCombo, 1, 4);
            this.appearanceFields.Controls.Add(this.fontNameComboLabel, 0, 5);
            this.appearanceFields.Controls.Add(this.fontNameCombo, 1, 5);
            this.appearanceFields.Controls.Add(this.axisFontSizeNumericLabel, 0, 6);
            this.appearanceFields.Controls.Add(this.axisFontSizeNumeric, 1, 6);
            this.appearanceFields.Controls.Add(this.titleFontSizeNumericLabel, 0, 7);
            this.appearanceFields.Controls.Add(this.titleFontSizeNumeric, 1, 7);
            this.appearanceFields.Controls.Add(this.majorGridWidthNumericLabel, 0, 8);
            this.appearanceFields.Controls.Add(this.majorGridWidthNumeric, 1, 8);
            this.appearanceFields.Controls.Add(this.majorGridCheckLabel, 0, 9);
            this.appearanceFields.Controls.Add(this.majorGridCheck, 1, 9);
            this.appearanceFields.Controls.Add(this.minorGridCheckLabel, 0, 10);
            this.appearanceFields.Controls.Add(this.minorGridCheck, 1, 10);
            this.appearanceFields.Controls.Add(this.antialiasCheckLabel, 0, 11);
            this.appearanceFields.Controls.Add(this.antialiasCheck, 1, 11);
            this.appearanceFields.Controls.Add(this.yAxisTitleCheckLabel, 0, 12);
            this.appearanceFields.Controls.Add(this.yAxisTitleCheck, 1, 12);
            this.appearanceFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearanceFields.Location = new System.Drawing.Point(7, 28);
            this.appearanceFields.Name = "appearanceFields";
            this.appearanceFields.RowCount = 13;
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.appearanceFields.Size = new System.Drawing.Size(306, 446);
            this.appearanceFields.TabIndex = 0;
            // 
            // chartBackgroundComboLabel
            // 
            this.chartBackgroundComboLabel.AutoEllipsis = true;
            this.chartBackgroundComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBackgroundComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.chartBackgroundComboLabel.Location = new System.Drawing.Point(3, 0);
            this.chartBackgroundComboLabel.Name = "chartBackgroundComboLabel";
            this.chartBackgroundComboLabel.Size = new System.Drawing.Size(143, 34);
            this.chartBackgroundComboLabel.TabIndex = 0;
            this.chartBackgroundComboLabel.Text = "Chart background";
            this.chartBackgroundComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartBackgroundCombo
            // 
            this.chartBackgroundCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.chartBackgroundCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBackgroundCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chartBackgroundCombo.ForeColor = System.Drawing.Color.White;
            this.chartBackgroundCombo.Items.AddRange(new object[] {
            "#1C1C1C"});
            this.chartBackgroundCombo.Location = new System.Drawing.Point(151, 4);
            this.chartBackgroundCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chartBackgroundCombo.Name = "chartBackgroundCombo";
            this.chartBackgroundCombo.Size = new System.Drawing.Size(153, 23);
            this.chartBackgroundCombo.TabIndex = 1;
            // 
            // plotBackgroundComboLabel
            // 
            this.plotBackgroundComboLabel.AutoEllipsis = true;
            this.plotBackgroundComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotBackgroundComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotBackgroundComboLabel.Location = new System.Drawing.Point(3, 34);
            this.plotBackgroundComboLabel.Name = "plotBackgroundComboLabel";
            this.plotBackgroundComboLabel.Size = new System.Drawing.Size(143, 34);
            this.plotBackgroundComboLabel.TabIndex = 2;
            this.plotBackgroundComboLabel.Text = "Plot background";
            this.plotBackgroundComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plotBackgroundCombo
            // 
            this.plotBackgroundCombo.BackColor = System.Drawing.Color.Black;
            this.plotBackgroundCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotBackgroundCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plotBackgroundCombo.ForeColor = System.Drawing.Color.White;
            this.plotBackgroundCombo.Items.AddRange(new object[] {
            "Black"});
            this.plotBackgroundCombo.Location = new System.Drawing.Point(151, 38);
            this.plotBackgroundCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.plotBackgroundCombo.Name = "plotBackgroundCombo";
            this.plotBackgroundCombo.Size = new System.Drawing.Size(153, 23);
            this.plotBackgroundCombo.TabIndex = 3;
            // 
            // majorGridColorComboLabel
            // 
            this.majorGridColorComboLabel.AutoEllipsis = true;
            this.majorGridColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majorGridColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.majorGridColorComboLabel.Location = new System.Drawing.Point(3, 68);
            this.majorGridColorComboLabel.Name = "majorGridColorComboLabel";
            this.majorGridColorComboLabel.Size = new System.Drawing.Size(143, 34);
            this.majorGridColorComboLabel.TabIndex = 4;
            this.majorGridColorComboLabel.Text = "Major grid color";
            this.majorGridColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // majorGridColorCombo
            // 
            this.majorGridColorCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.majorGridColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majorGridColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.majorGridColorCombo.ForeColor = System.Drawing.Color.White;
            this.majorGridColorCombo.Items.AddRange(new object[] {
            "#3E3E3E"});
            this.majorGridColorCombo.Location = new System.Drawing.Point(151, 72);
            this.majorGridColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.majorGridColorCombo.Name = "majorGridColorCombo";
            this.majorGridColorCombo.Size = new System.Drawing.Size(153, 23);
            this.majorGridColorCombo.TabIndex = 5;
            // 
            // minorGridColorComboLabel
            // 
            this.minorGridColorComboLabel.AutoEllipsis = true;
            this.minorGridColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minorGridColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.minorGridColorComboLabel.Location = new System.Drawing.Point(3, 102);
            this.minorGridColorComboLabel.Name = "minorGridColorComboLabel";
            this.minorGridColorComboLabel.Size = new System.Drawing.Size(143, 34);
            this.minorGridColorComboLabel.TabIndex = 6;
            this.minorGridColorComboLabel.Text = "Minor grid color";
            this.minorGridColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minorGridColorCombo
            // 
            this.minorGridColorCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.minorGridColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minorGridColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minorGridColorCombo.ForeColor = System.Drawing.Color.White;
            this.minorGridColorCombo.Items.AddRange(new object[] {
            "#2A2A2A"});
            this.minorGridColorCombo.Location = new System.Drawing.Point(151, 106);
            this.minorGridColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.minorGridColorCombo.Name = "minorGridColorCombo";
            this.minorGridColorCombo.Size = new System.Drawing.Size(153, 23);
            this.minorGridColorCombo.TabIndex = 7;
            // 
            // fontColorComboLabel
            // 
            this.fontColorComboLabel.AutoEllipsis = true;
            this.fontColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.fontColorComboLabel.Location = new System.Drawing.Point(3, 136);
            this.fontColorComboLabel.Name = "fontColorComboLabel";
            this.fontColorComboLabel.Size = new System.Drawing.Size(143, 34);
            this.fontColorComboLabel.TabIndex = 8;
            this.fontColorComboLabel.Text = "Text / axis color";
            this.fontColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontColorCombo
            // 
            this.fontColorCombo.BackColor = System.Drawing.Color.White;
            this.fontColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fontColorCombo.ForeColor = System.Drawing.Color.Black;
            this.fontColorCombo.Items.AddRange(new object[] {
            "White"});
            this.fontColorCombo.Location = new System.Drawing.Point(151, 140);
            this.fontColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fontColorCombo.Name = "fontColorCombo";
            this.fontColorCombo.Size = new System.Drawing.Size(153, 23);
            this.fontColorCombo.TabIndex = 9;
            // 
            // fontNameComboLabel
            // 
            this.fontNameComboLabel.AutoEllipsis = true;
            this.fontNameComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontNameComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.fontNameComboLabel.Location = new System.Drawing.Point(3, 170);
            this.fontNameComboLabel.Name = "fontNameComboLabel";
            this.fontNameComboLabel.Size = new System.Drawing.Size(143, 34);
            this.fontNameComboLabel.TabIndex = 10;
            this.fontNameComboLabel.Text = "Font family";
            this.fontNameComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontNameCombo
            // 
            this.fontNameCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.fontNameCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontNameCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fontNameCombo.ForeColor = System.Drawing.Color.White;
            this.fontNameCombo.Items.AddRange(new object[] {
            "Arial",
            "Calibri",
            "Segoe UI",
            "Tahoma"});
            this.fontNameCombo.Location = new System.Drawing.Point(151, 174);
            this.fontNameCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fontNameCombo.Name = "fontNameCombo";
            this.fontNameCombo.Size = new System.Drawing.Size(153, 23);
            this.fontNameCombo.TabIndex = 11;
            // 
            // axisFontSizeNumericLabel
            // 
            this.axisFontSizeNumericLabel.AutoEllipsis = true;
            this.axisFontSizeNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisFontSizeNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.axisFontSizeNumericLabel.Location = new System.Drawing.Point(3, 204);
            this.axisFontSizeNumericLabel.Name = "axisFontSizeNumericLabel";
            this.axisFontSizeNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.axisFontSizeNumericLabel.TabIndex = 12;
            this.axisFontSizeNumericLabel.Text = "Axis text size";
            this.axisFontSizeNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axisFontSizeNumeric
            // 
            this.axisFontSizeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.axisFontSizeNumeric.DecimalPlaces = 1;
            this.axisFontSizeNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisFontSizeNumeric.ForeColor = System.Drawing.Color.White;
            this.axisFontSizeNumeric.Location = new System.Drawing.Point(151, 208);
            this.axisFontSizeNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.axisFontSizeNumeric.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.axisFontSizeNumeric.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.axisFontSizeNumeric.Name = "axisFontSizeNumeric";
            this.axisFontSizeNumeric.Size = new System.Drawing.Size(153, 23);
            this.axisFontSizeNumeric.TabIndex = 13;
            this.axisFontSizeNumeric.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // titleFontSizeNumericLabel
            // 
            this.titleFontSizeNumericLabel.AutoEllipsis = true;
            this.titleFontSizeNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleFontSizeNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.titleFontSizeNumericLabel.Location = new System.Drawing.Point(3, 238);
            this.titleFontSizeNumericLabel.Name = "titleFontSizeNumericLabel";
            this.titleFontSizeNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.titleFontSizeNumericLabel.TabIndex = 14;
            this.titleFontSizeNumericLabel.Text = "Plot title size";
            this.titleFontSizeNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleFontSizeNumeric
            // 
            this.titleFontSizeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.titleFontSizeNumeric.DecimalPlaces = 1;
            this.titleFontSizeNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleFontSizeNumeric.ForeColor = System.Drawing.Color.White;
            this.titleFontSizeNumeric.Location = new System.Drawing.Point(151, 242);
            this.titleFontSizeNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.titleFontSizeNumeric.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.titleFontSizeNumeric.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.titleFontSizeNumeric.Name = "titleFontSizeNumeric";
            this.titleFontSizeNumeric.Size = new System.Drawing.Size(153, 23);
            this.titleFontSizeNumeric.TabIndex = 15;
            this.titleFontSizeNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // majorGridWidthNumericLabel
            // 
            this.majorGridWidthNumericLabel.AutoEllipsis = true;
            this.majorGridWidthNumericLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majorGridWidthNumericLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.majorGridWidthNumericLabel.Location = new System.Drawing.Point(3, 272);
            this.majorGridWidthNumericLabel.Name = "majorGridWidthNumericLabel";
            this.majorGridWidthNumericLabel.Size = new System.Drawing.Size(143, 34);
            this.majorGridWidthNumericLabel.TabIndex = 16;
            this.majorGridWidthNumericLabel.Text = "Grid line width (px)";
            this.majorGridWidthNumericLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // majorGridWidthNumeric
            // 
            this.majorGridWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.majorGridWidthNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majorGridWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.majorGridWidthNumeric.Location = new System.Drawing.Point(151, 276);
            this.majorGridWidthNumeric.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.majorGridWidthNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.majorGridWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.majorGridWidthNumeric.Name = "majorGridWidthNumeric";
            this.majorGridWidthNumeric.Size = new System.Drawing.Size(153, 23);
            this.majorGridWidthNumeric.TabIndex = 17;
            this.majorGridWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // majorGridCheckLabel
            // 
            this.majorGridCheckLabel.AutoEllipsis = true;
            this.majorGridCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majorGridCheckLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.majorGridCheckLabel.Location = new System.Drawing.Point(3, 306);
            this.majorGridCheckLabel.Name = "majorGridCheckLabel";
            this.majorGridCheckLabel.Size = new System.Drawing.Size(143, 34);
            this.majorGridCheckLabel.TabIndex = 18;
            this.majorGridCheckLabel.Text = "Show major grid";
            this.majorGridCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // majorGridCheck
            // 
            this.majorGridCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.majorGridCheck.Checked = true;
            this.majorGridCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.majorGridCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majorGridCheck.ForeColor = System.Drawing.Color.White;
            this.majorGridCheck.Location = new System.Drawing.Point(151, 310);
            this.majorGridCheck.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.majorGridCheck.Name = "majorGridCheck";
            this.majorGridCheck.Size = new System.Drawing.Size(153, 26);
            this.majorGridCheck.TabIndex = 19;
            this.majorGridCheck.Text = "Enabled";
            this.majorGridCheck.UseVisualStyleBackColor = false;
            // 
            // minorGridCheckLabel
            // 
            this.minorGridCheckLabel.AutoEllipsis = true;
            this.minorGridCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minorGridCheckLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.minorGridCheckLabel.Location = new System.Drawing.Point(3, 340);
            this.minorGridCheckLabel.Name = "minorGridCheckLabel";
            this.minorGridCheckLabel.Size = new System.Drawing.Size(143, 34);
            this.minorGridCheckLabel.TabIndex = 20;
            this.minorGridCheckLabel.Text = "Show minor grid";
            this.minorGridCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minorGridCheck
            // 
            this.minorGridCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.minorGridCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minorGridCheck.ForeColor = System.Drawing.Color.White;
            this.minorGridCheck.Location = new System.Drawing.Point(151, 344);
            this.minorGridCheck.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.minorGridCheck.Name = "minorGridCheck";
            this.minorGridCheck.Size = new System.Drawing.Size(153, 26);
            this.minorGridCheck.TabIndex = 21;
            this.minorGridCheck.Text = "Enabled";
            this.minorGridCheck.UseVisualStyleBackColor = false;
            // 
            // antialiasCheckLabel
            // 
            this.antialiasCheckLabel.AutoEllipsis = true;
            this.antialiasCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.antialiasCheckLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.antialiasCheckLabel.Location = new System.Drawing.Point(3, 374);
            this.antialiasCheckLabel.Name = "antialiasCheckLabel";
            this.antialiasCheckLabel.Size = new System.Drawing.Size(143, 34);
            this.antialiasCheckLabel.TabIndex = 22;
            this.antialiasCheckLabel.Text = "Antialias chart";
            this.antialiasCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // antialiasCheck
            // 
            this.antialiasCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.antialiasCheck.Checked = true;
            this.antialiasCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antialiasCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.antialiasCheck.ForeColor = System.Drawing.Color.White;
            this.antialiasCheck.Location = new System.Drawing.Point(151, 378);
            this.antialiasCheck.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.antialiasCheck.Name = "antialiasCheck";
            this.antialiasCheck.Size = new System.Drawing.Size(153, 26);
            this.antialiasCheck.TabIndex = 23;
            this.antialiasCheck.Text = "Enabled";
            this.antialiasCheck.UseVisualStyleBackColor = false;
            // 
            // yAxisTitleCheckLabel
            // 
            this.yAxisTitleCheckLabel.AutoEllipsis = true;
            this.yAxisTitleCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisTitleCheckLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.yAxisTitleCheckLabel.Location = new System.Drawing.Point(3, 408);
            this.yAxisTitleCheckLabel.Name = "yAxisTitleCheckLabel";
            this.yAxisTitleCheckLabel.Size = new System.Drawing.Size(143, 38);
            this.yAxisTitleCheckLabel.TabIndex = 24;
            this.yAxisTitleCheckLabel.Text = "Show Y-axis title";
            this.yAxisTitleCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yAxisTitleCheck
            // 
            this.yAxisTitleCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.yAxisTitleCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisTitleCheck.ForeColor = System.Drawing.Color.White;
            this.yAxisTitleCheck.Location = new System.Drawing.Point(151, 412);
            this.yAxisTitleCheck.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.yAxisTitleCheck.Name = "yAxisTitleCheck";
            this.yAxisTitleCheck.Size = new System.Drawing.Size(153, 30);
            this.yAxisTitleCheck.TabIndex = 25;
            this.yAxisTitleCheck.Text = "Enabled";
            this.yAxisTitleCheck.UseVisualStyleBackColor = false;
            // 
            // rightScroll
            // 
            this.rightScroll.AutoScroll = true;
            this.rightScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rightScroll.Controls.Add(this.rightStack);
            this.rightScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightScroll.Location = new System.Drawing.Point(360, 6);
            this.rightScroll.Name = "rightScroll";
            this.rightScroll.Size = new System.Drawing.Size(348, 684);
            this.rightScroll.TabIndex = 1;
            // 
            // rightStack
            // 
            this.rightStack.AutoSize = true;
            this.rightStack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rightStack.ColumnCount = 1;
            this.rightStack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightStack.Controls.Add(this.wheelColorGroup, 0, 0);
            this.rightStack.Controls.Add(this.yRangeGroup, 0, 1);
            this.rightStack.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightStack.Location = new System.Drawing.Point(0, 0);
            this.rightStack.Name = "rightStack";
            this.rightStack.RowCount = 2;
            this.rightStack.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rightStack.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rightStack.Size = new System.Drawing.Size(348, 486);
            this.rightStack.TabIndex = 0;
            // 
            // wheelColorGroup
            // 
            this.wheelColorGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.wheelColorGroup.Controls.Add(this.wheelColorFields);
            this.wheelColorGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.wheelColorGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.wheelColorGroup.Location = new System.Drawing.Point(4, 5);
            this.wheelColorGroup.Margin = new System.Windows.Forms.Padding(4, 5, 7, 5);
            this.wheelColorGroup.Name = "wheelColorGroup";
            this.wheelColorGroup.Padding = new System.Windows.Forms.Padding(7, 12, 7, 5);
            this.wheelColorGroup.Size = new System.Drawing.Size(337, 207);
            this.wheelColorGroup.TabIndex = 0;
            this.wheelColorGroup.TabStop = false;
            this.wheelColorGroup.Text = "Trace colors (named or hex)";
            // 
            // wheelColorFields
            // 
            this.wheelColorFields.ColumnCount = 2;
            this.wheelColorFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.wheelColorFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.wheelColorFields.Controls.Add(this.flColorComboLabel, 0, 0);
            this.wheelColorFields.Controls.Add(this.flColorCombo, 1, 0);
            this.wheelColorFields.Controls.Add(this.frColorComboLabel, 0, 1);
            this.wheelColorFields.Controls.Add(this.frColorCombo, 1, 1);
            this.wheelColorFields.Controls.Add(this.rlColorComboLabel, 0, 2);
            this.wheelColorFields.Controls.Add(this.rlColorCombo, 1, 2);
            this.wheelColorFields.Controls.Add(this.rrColorComboLabel, 0, 3);
            this.wheelColorFields.Controls.Add(this.rrColorCombo, 1, 3);
            this.wheelColorFields.Controls.Add(this.sharedColorComboLabel, 0, 4);
            this.wheelColorFields.Controls.Add(this.sharedColorCombo, 1, 4);
            this.wheelColorFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wheelColorFields.Location = new System.Drawing.Point(7, 28);
            this.wheelColorFields.Name = "wheelColorFields";
            this.wheelColorFields.RowCount = 5;
            this.wheelColorFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.wheelColorFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.wheelColorFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.wheelColorFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.wheelColorFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.wheelColorFields.Size = new System.Drawing.Size(323, 174);
            this.wheelColorFields.TabIndex = 0;
            // 
            // flColorComboLabel
            // 
            this.flColorComboLabel.AutoEllipsis = true;
            this.flColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.flColorComboLabel.Location = new System.Drawing.Point(3, 0);
            this.flColorComboLabel.Name = "flColorComboLabel";
            this.flColorComboLabel.Size = new System.Drawing.Size(152, 34);
            this.flColorComboLabel.TabIndex = 0;
            this.flColorComboLabel.Text = "Front left (FL)";
            this.flColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flColorCombo
            // 
            this.flColorCombo.BackColor = System.Drawing.Color.LimeGreen;
            this.flColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flColorCombo.ForeColor = System.Drawing.Color.Black;
            this.flColorCombo.Items.AddRange(new object[] {
            "LimeGreen"});
            this.flColorCombo.Location = new System.Drawing.Point(160, 4);
            this.flColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.flColorCombo.Name = "flColorCombo";
            this.flColorCombo.Size = new System.Drawing.Size(161, 23);
            this.flColorCombo.TabIndex = 1;
            // 
            // frColorComboLabel
            // 
            this.frColorComboLabel.AutoEllipsis = true;
            this.frColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.frColorComboLabel.Location = new System.Drawing.Point(3, 34);
            this.frColorComboLabel.Name = "frColorComboLabel";
            this.frColorComboLabel.Size = new System.Drawing.Size(152, 34);
            this.frColorComboLabel.TabIndex = 2;
            this.frColorComboLabel.Text = "Front right (FR)";
            this.frColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frColorCombo
            // 
            this.frColorCombo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.frColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frColorCombo.ForeColor = System.Drawing.Color.Black;
            this.frColorCombo.Items.AddRange(new object[] {
            "DeepSkyBlue"});
            this.frColorCombo.Location = new System.Drawing.Point(160, 38);
            this.frColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.frColorCombo.Name = "frColorCombo";
            this.frColorCombo.Size = new System.Drawing.Size(161, 23);
            this.frColorCombo.TabIndex = 3;
            // 
            // rlColorComboLabel
            // 
            this.rlColorComboLabel.AutoEllipsis = true;
            this.rlColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rlColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.rlColorComboLabel.Location = new System.Drawing.Point(3, 68);
            this.rlColorComboLabel.Name = "rlColorComboLabel";
            this.rlColorComboLabel.Size = new System.Drawing.Size(152, 34);
            this.rlColorComboLabel.TabIndex = 4;
            this.rlColorComboLabel.Text = "Rear left (RL)";
            this.rlColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rlColorCombo
            // 
            this.rlColorCombo.BackColor = System.Drawing.Color.Gold;
            this.rlColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rlColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rlColorCombo.ForeColor = System.Drawing.Color.Black;
            this.rlColorCombo.Items.AddRange(new object[] {
            "Gold"});
            this.rlColorCombo.Location = new System.Drawing.Point(160, 72);
            this.rlColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.rlColorCombo.Name = "rlColorCombo";
            this.rlColorCombo.Size = new System.Drawing.Size(161, 23);
            this.rlColorCombo.TabIndex = 5;
            // 
            // rrColorComboLabel
            // 
            this.rrColorComboLabel.AutoEllipsis = true;
            this.rrColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rrColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.rrColorComboLabel.Location = new System.Drawing.Point(3, 102);
            this.rrColorComboLabel.Name = "rrColorComboLabel";
            this.rrColorComboLabel.Size = new System.Drawing.Size(152, 34);
            this.rrColorComboLabel.TabIndex = 6;
            this.rrColorComboLabel.Text = "Rear right (RR)";
            this.rrColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rrColorCombo
            // 
            this.rrColorCombo.BackColor = System.Drawing.Color.MediumOrchid;
            this.rrColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rrColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rrColorCombo.ForeColor = System.Drawing.Color.Black;
            this.rrColorCombo.Items.AddRange(new object[] {
            "MediumOrchid"});
            this.rrColorCombo.Location = new System.Drawing.Point(160, 106);
            this.rrColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.rrColorCombo.Name = "rrColorCombo";
            this.rrColorCombo.Size = new System.Drawing.Size(161, 23);
            this.rrColorCombo.TabIndex = 7;
            // 
            // sharedColorComboLabel
            // 
            this.sharedColorComboLabel.AutoEllipsis = true;
            this.sharedColorComboLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sharedColorComboLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.sharedColorComboLabel.Location = new System.Drawing.Point(3, 136);
            this.sharedColorComboLabel.Name = "sharedColorComboLabel";
            this.sharedColorComboLabel.Size = new System.Drawing.Size(152, 38);
            this.sharedColorComboLabel.TabIndex = 8;
            this.sharedColorComboLabel.Text = "Shared telemetry";
            this.sharedColorComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sharedColorCombo
            // 
            this.sharedColorCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sharedColorCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sharedColorCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sharedColorCombo.ForeColor = System.Drawing.Color.Black;
            this.sharedColorCombo.Items.AddRange(new object[] {
            "WhiteSmoke"});
            this.sharedColorCombo.Location = new System.Drawing.Point(160, 140);
            this.sharedColorCombo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.sharedColorCombo.Name = "sharedColorCombo";
            this.sharedColorCombo.Size = new System.Drawing.Size(161, 23);
            this.sharedColorCombo.TabIndex = 9;
            // 
            // yRangeGroup
            // 
            this.yRangeGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.yRangeGroup.Controls.Add(this.yRangeFields);
            this.yRangeGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.yRangeGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.yRangeGroup.Location = new System.Drawing.Point(4, 222);
            this.yRangeGroup.Margin = new System.Windows.Forms.Padding(4, 5, 7, 5);
            this.yRangeGroup.Name = "yRangeGroup";
            this.yRangeGroup.Padding = new System.Windows.Forms.Padding(7, 12, 7, 5);
            this.yRangeGroup.Size = new System.Drawing.Size(337, 259);
            this.yRangeGroup.TabIndex = 1;
            this.yRangeGroup.TabStop = false;
            this.yRangeGroup.Text = "Optional Y-axis ranges (per plot)";
            // 
            // yRangeFields
            // 
            this.yRangeFields.ColumnCount = 4;
            this.yRangeFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.yRangeFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.yRangeFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yRangeFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yRangeFields.Controls.Add(this.yHeader0, 0, 0);
            this.yRangeFields.Controls.Add(this.yHeader1, 1, 0);
            this.yRangeFields.Controls.Add(this.yHeader2, 2, 0);
            this.yRangeFields.Controls.Add(this.yHeader3, 3, 0);
            this.yRangeFields.Controls.Add(this.plotLabel1, 0, 1);
            this.yRangeFields.Controls.Add(this.plot1AutoY, 1, 1);
            this.yRangeFields.Controls.Add(this.plot1YMin, 2, 1);
            this.yRangeFields.Controls.Add(this.plot1YMax, 3, 1);
            this.yRangeFields.Controls.Add(this.plotLabel2, 0, 2);
            this.yRangeFields.Controls.Add(this.plot2AutoY, 1, 2);
            this.yRangeFields.Controls.Add(this.plot2YMin, 2, 2);
            this.yRangeFields.Controls.Add(this.plot2YMax, 3, 2);
            this.yRangeFields.Controls.Add(this.plotLabel3, 0, 3);
            this.yRangeFields.Controls.Add(this.plot3AutoY, 1, 3);
            this.yRangeFields.Controls.Add(this.plot3YMin, 2, 3);
            this.yRangeFields.Controls.Add(this.plot3YMax, 3, 3);
            this.yRangeFields.Controls.Add(this.plotLabel4, 0, 4);
            this.yRangeFields.Controls.Add(this.plot4AutoY, 1, 4);
            this.yRangeFields.Controls.Add(this.plot4YMin, 2, 4);
            this.yRangeFields.Controls.Add(this.plot4YMax, 3, 4);
            this.yRangeFields.Controls.Add(this.plotLabel5, 0, 5);
            this.yRangeFields.Controls.Add(this.plot5AutoY, 1, 5);
            this.yRangeFields.Controls.Add(this.plot5YMin, 2, 5);
            this.yRangeFields.Controls.Add(this.plot5YMax, 3, 5);
            this.yRangeFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yRangeFields.Location = new System.Drawing.Point(7, 28);
            this.yRangeFields.Name = "yRangeFields";
            this.yRangeFields.RowCount = 6;
            this.yRangeFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.yRangeFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.yRangeFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.yRangeFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.yRangeFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.yRangeFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.yRangeFields.Size = new System.Drawing.Size(323, 226);
            this.yRangeFields.TabIndex = 0;
            // 
            // yHeader0
            // 
            this.yHeader0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yHeader0.ForeColor = System.Drawing.Color.Gainsboro;
            this.yHeader0.Location = new System.Drawing.Point(3, 0);
            this.yHeader0.Name = "yHeader0";
            this.yHeader0.Size = new System.Drawing.Size(57, 33);
            this.yHeader0.TabIndex = 0;
            this.yHeader0.Text = "Plot";
            this.yHeader0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yHeader1
            // 
            this.yHeader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yHeader1.ForeColor = System.Drawing.Color.Gainsboro;
            this.yHeader1.Location = new System.Drawing.Point(66, 0);
            this.yHeader1.Name = "yHeader1";
            this.yHeader1.Size = new System.Drawing.Size(69, 33);
            this.yHeader1.TabIndex = 1;
            this.yHeader1.Text = "Auto Y";
            this.yHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yHeader2
            // 
            this.yHeader2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yHeader2.ForeColor = System.Drawing.Color.Gainsboro;
            this.yHeader2.Location = new System.Drawing.Point(141, 0);
            this.yHeader2.Name = "yHeader2";
            this.yHeader2.Size = new System.Drawing.Size(86, 33);
            this.yHeader2.TabIndex = 2;
            this.yHeader2.Text = "Minimum";
            this.yHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yHeader3
            // 
            this.yHeader3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yHeader3.ForeColor = System.Drawing.Color.Gainsboro;
            this.yHeader3.Location = new System.Drawing.Point(233, 0);
            this.yHeader3.Name = "yHeader3";
            this.yHeader3.Size = new System.Drawing.Size(87, 33);
            this.yHeader3.TabIndex = 3;
            this.yHeader3.Text = "Maximum";
            this.yHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plotLabel1
            // 
            this.plotLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotLabel1.Location = new System.Drawing.Point(3, 33);
            this.plotLabel1.Name = "plotLabel1";
            this.plotLabel1.Size = new System.Drawing.Size(57, 33);
            this.plotLabel1.TabIndex = 4;
            this.plotLabel1.Text = "Plot 1";
            this.plotLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plot1AutoY
            // 
            this.plot1AutoY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.plot1AutoY.Checked = true;
            this.plot1AutoY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plot1AutoY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1AutoY.ForeColor = System.Drawing.Color.Gainsboro;
            this.plot1AutoY.Location = new System.Drawing.Point(66, 36);
            this.plot1AutoY.Name = "plot1AutoY";
            this.plot1AutoY.Size = new System.Drawing.Size(69, 27);
            this.plot1AutoY.TabIndex = 5;
            this.plot1AutoY.Text = "Auto";
            this.plot1AutoY.UseVisualStyleBackColor = false;
            // 
            // plot1YMin
            // 
            this.plot1YMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot1YMin.DecimalPlaces = 3;
            this.plot1YMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1YMin.ForeColor = System.Drawing.Color.White;
            this.plot1YMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot1YMin.Location = new System.Drawing.Point(140, 36);
            this.plot1YMin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot1YMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot1YMin.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot1YMin.Name = "plot1YMin";
            this.plot1YMin.Size = new System.Drawing.Size(88, 23);
            this.plot1YMin.TabIndex = 6;
            this.plot1YMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // plot1YMax
            // 
            this.plot1YMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot1YMax.DecimalPlaces = 3;
            this.plot1YMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1YMax.ForeColor = System.Drawing.Color.White;
            this.plot1YMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot1YMax.Location = new System.Drawing.Point(232, 36);
            this.plot1YMax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot1YMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot1YMax.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot1YMax.Name = "plot1YMax";
            this.plot1YMax.Size = new System.Drawing.Size(89, 23);
            this.plot1YMax.TabIndex = 7;
            this.plot1YMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // plotLabel2
            // 
            this.plotLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotLabel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotLabel2.Location = new System.Drawing.Point(3, 66);
            this.plotLabel2.Name = "plotLabel2";
            this.plotLabel2.Size = new System.Drawing.Size(57, 33);
            this.plotLabel2.TabIndex = 8;
            this.plotLabel2.Text = "Plot 2";
            this.plotLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plot2AutoY
            // 
            this.plot2AutoY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.plot2AutoY.Checked = true;
            this.plot2AutoY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plot2AutoY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot2AutoY.ForeColor = System.Drawing.Color.Gainsboro;
            this.plot2AutoY.Location = new System.Drawing.Point(66, 69);
            this.plot2AutoY.Name = "plot2AutoY";
            this.plot2AutoY.Size = new System.Drawing.Size(69, 27);
            this.plot2AutoY.TabIndex = 9;
            this.plot2AutoY.Text = "Auto";
            this.plot2AutoY.UseVisualStyleBackColor = false;
            // 
            // plot2YMin
            // 
            this.plot2YMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot2YMin.DecimalPlaces = 3;
            this.plot2YMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot2YMin.ForeColor = System.Drawing.Color.White;
            this.plot2YMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot2YMin.Location = new System.Drawing.Point(140, 69);
            this.plot2YMin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot2YMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot2YMin.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot2YMin.Name = "plot2YMin";
            this.plot2YMin.Size = new System.Drawing.Size(88, 23);
            this.plot2YMin.TabIndex = 10;
            this.plot2YMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // plot2YMax
            // 
            this.plot2YMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot2YMax.DecimalPlaces = 3;
            this.plot2YMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot2YMax.ForeColor = System.Drawing.Color.White;
            this.plot2YMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot2YMax.Location = new System.Drawing.Point(232, 69);
            this.plot2YMax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot2YMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot2YMax.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot2YMax.Name = "plot2YMax";
            this.plot2YMax.Size = new System.Drawing.Size(89, 23);
            this.plot2YMax.TabIndex = 11;
            this.plot2YMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // plotLabel3
            // 
            this.plotLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotLabel3.Location = new System.Drawing.Point(3, 99);
            this.plotLabel3.Name = "plotLabel3";
            this.plotLabel3.Size = new System.Drawing.Size(57, 33);
            this.plotLabel3.TabIndex = 12;
            this.plotLabel3.Text = "Plot 3";
            this.plotLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plot3AutoY
            // 
            this.plot3AutoY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.plot3AutoY.Checked = true;
            this.plot3AutoY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plot3AutoY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot3AutoY.ForeColor = System.Drawing.Color.Gainsboro;
            this.plot3AutoY.Location = new System.Drawing.Point(66, 102);
            this.plot3AutoY.Name = "plot3AutoY";
            this.plot3AutoY.Size = new System.Drawing.Size(69, 27);
            this.plot3AutoY.TabIndex = 13;
            this.plot3AutoY.Text = "Auto";
            this.plot3AutoY.UseVisualStyleBackColor = false;
            // 
            // plot3YMin
            // 
            this.plot3YMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot3YMin.DecimalPlaces = 3;
            this.plot3YMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot3YMin.ForeColor = System.Drawing.Color.White;
            this.plot3YMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot3YMin.Location = new System.Drawing.Point(140, 102);
            this.plot3YMin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot3YMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot3YMin.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot3YMin.Name = "plot3YMin";
            this.plot3YMin.Size = new System.Drawing.Size(88, 23);
            this.plot3YMin.TabIndex = 14;
            this.plot3YMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // plot3YMax
            // 
            this.plot3YMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot3YMax.DecimalPlaces = 3;
            this.plot3YMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot3YMax.ForeColor = System.Drawing.Color.White;
            this.plot3YMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot3YMax.Location = new System.Drawing.Point(232, 102);
            this.plot3YMax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot3YMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot3YMax.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot3YMax.Name = "plot3YMax";
            this.plot3YMax.Size = new System.Drawing.Size(89, 23);
            this.plot3YMax.TabIndex = 15;
            this.plot3YMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // plotLabel4
            // 
            this.plotLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotLabel4.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotLabel4.Location = new System.Drawing.Point(3, 132);
            this.plotLabel4.Name = "plotLabel4";
            this.plotLabel4.Size = new System.Drawing.Size(57, 33);
            this.plotLabel4.TabIndex = 16;
            this.plotLabel4.Text = "Plot 4";
            this.plotLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plot4AutoY
            // 
            this.plot4AutoY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.plot4AutoY.Checked = true;
            this.plot4AutoY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plot4AutoY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot4AutoY.ForeColor = System.Drawing.Color.Gainsboro;
            this.plot4AutoY.Location = new System.Drawing.Point(66, 135);
            this.plot4AutoY.Name = "plot4AutoY";
            this.plot4AutoY.Size = new System.Drawing.Size(69, 27);
            this.plot4AutoY.TabIndex = 17;
            this.plot4AutoY.Text = "Auto";
            this.plot4AutoY.UseVisualStyleBackColor = false;
            // 
            // plot4YMin
            // 
            this.plot4YMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot4YMin.DecimalPlaces = 3;
            this.plot4YMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot4YMin.ForeColor = System.Drawing.Color.White;
            this.plot4YMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot4YMin.Location = new System.Drawing.Point(140, 135);
            this.plot4YMin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot4YMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot4YMin.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot4YMin.Name = "plot4YMin";
            this.plot4YMin.Size = new System.Drawing.Size(88, 23);
            this.plot4YMin.TabIndex = 18;
            this.plot4YMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // plot4YMax
            // 
            this.plot4YMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot4YMax.DecimalPlaces = 3;
            this.plot4YMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot4YMax.ForeColor = System.Drawing.Color.White;
            this.plot4YMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot4YMax.Location = new System.Drawing.Point(232, 135);
            this.plot4YMax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot4YMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot4YMax.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot4YMax.Name = "plot4YMax";
            this.plot4YMax.Size = new System.Drawing.Size(89, 23);
            this.plot4YMax.TabIndex = 19;
            this.plot4YMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // plotLabel5
            // 
            this.plotLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotLabel5.ForeColor = System.Drawing.Color.Gainsboro;
            this.plotLabel5.Location = new System.Drawing.Point(3, 165);
            this.plotLabel5.Name = "plotLabel5";
            this.plotLabel5.Size = new System.Drawing.Size(57, 61);
            this.plotLabel5.TabIndex = 20;
            this.plotLabel5.Text = "Plot 5";
            this.plotLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plot5AutoY
            // 
            this.plot5AutoY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.plot5AutoY.Checked = true;
            this.plot5AutoY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plot5AutoY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot5AutoY.ForeColor = System.Drawing.Color.Gainsboro;
            this.plot5AutoY.Location = new System.Drawing.Point(66, 168);
            this.plot5AutoY.Name = "plot5AutoY";
            this.plot5AutoY.Size = new System.Drawing.Size(69, 55);
            this.plot5AutoY.TabIndex = 21;
            this.plot5AutoY.Text = "Auto";
            this.plot5AutoY.UseVisualStyleBackColor = false;
            // 
            // plot5YMin
            // 
            this.plot5YMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot5YMin.DecimalPlaces = 3;
            this.plot5YMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot5YMin.ForeColor = System.Drawing.Color.White;
            this.plot5YMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot5YMin.Location = new System.Drawing.Point(140, 168);
            this.plot5YMin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot5YMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot5YMin.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot5YMin.Name = "plot5YMin";
            this.plot5YMin.Size = new System.Drawing.Size(88, 23);
            this.plot5YMin.TabIndex = 22;
            this.plot5YMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // plot5YMax
            // 
            this.plot5YMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.plot5YMax.DecimalPlaces = 3;
            this.plot5YMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot5YMax.ForeColor = System.Drawing.Color.White;
            this.plot5YMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.plot5YMax.Location = new System.Drawing.Point(232, 168);
            this.plot5YMax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.plot5YMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.plot5YMax.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.plot5YMax.Name = "plot5YMax";
            this.plot5YMax.Size = new System.Drawing.Size(89, 23);
            this.plot5YMax.TabIndex = 23;
            this.plot5YMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // FormLiveTimeChartSettings
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(720, 760);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(720, 530);
            this.Name = "FormLiveTimeChartSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Live Time Chart Settings";
            this.rootLayout.ResumeLayout(false);
            this.headerLayout.ResumeLayout(false);
            this.actionButtons.ResumeLayout(false);
            this.SettingsProfilesHost.ResumeLayout(false);
            this.contentColumns.ResumeLayout(false);
            this.leftScroll.ResumeLayout(false);
            this.leftScroll.PerformLayout();
            this.leftStack.ResumeLayout(false);
            this.generalGroup.ResumeLayout(false);
            this.generalFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.historyLengthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSamplesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerSizeNumeric)).EndInit();
            this.appearanceGroup.ResumeLayout(false);
            this.appearanceFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axisFontSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorGridWidthNumeric)).EndInit();
            this.rightScroll.ResumeLayout(false);
            this.rightScroll.PerformLayout();
            this.rightStack.ResumeLayout(false);
            this.wheelColorGroup.ResumeLayout(false);
            this.wheelColorFields.ResumeLayout(false);
            this.yRangeGroup.ResumeLayout(false);
            this.yRangeFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plot1YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot1YMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot2YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot2YMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot3YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot3YMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot4YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot4YMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot5YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot5YMax)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
