namespace Physics_Data_Debug
{
    partial class FormLogSettings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.TableLayoutPanel toolbarLayout;
        private System.Windows.Forms.TableLayoutPanel contentLayout;
        private System.Windows.Forms.TableLayoutPanel selectionsLayout;
        private System.Windows.Forms.TableLayoutPanel filterAndOutputLayout;
        private System.Windows.Forms.TableLayoutPanel filterRowsLayout;
        private System.Windows.Forms.TableLayoutPanel outputLayout;
        private System.Windows.Forms.GroupBox selectedFieldsGroup;
        private System.Windows.Forms.GroupBox filtersGroup;
        private System.Windows.Forms.GroupBox outputGroup;
        private System.Windows.Forms.Panel filtersScrollPanel;
        private System.Windows.Forms.Panel SettingsProfilesHost;
        private System.Windows.Forms.Button FLApplyLogSettings;
        private System.Windows.Forms.Label toolbarInfoLabel;
        private System.Windows.Forms.Label selectionCountLabel;
        private System.Windows.Forms.CheckBox selectAll;
        private System.Windows.Forms.TreeView logFieldsTreeView;
        private System.Windows.Forms.TextBox LogFolderTextBox;
        private System.Windows.Forms.Button BrowseLogFolderButton;
        private System.Windows.Forms.TextBox DelimiterTextBox;
        private System.Windows.Forms.NumericUpDown TimeLimitSecondsNumericUpDown;
        private System.Windows.Forms.NumericUpDown TotalSizeMiBNumericUpDown;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label delimiterLabel;
        private System.Windows.Forms.Label timeLimitLabel;
        private System.Windows.Forms.Label sizeLimitLabel;

        private System.Windows.Forms.TableLayoutPanel logFilter01;
        private System.Windows.Forms.Label logFilter01Heading;
        private System.Windows.Forms.Label logFilter01MinimumLabel;
        private System.Windows.Forms.Label logFilter01MaximumLabel;
        private System.Windows.Forms.TableLayoutPanel logFilter02;
        private System.Windows.Forms.Label logFilter02Heading;
        private System.Windows.Forms.CheckBox logFilter02Enabled;
        private System.Windows.Forms.ComboBox logFilter02Field;
        private System.Windows.Forms.ComboBox logFilter02Mode;
        private System.Windows.Forms.CheckBox logFilter02Absolute;
        private System.Windows.Forms.Label logFilter02MinimumLabel;
        private System.Windows.Forms.Label logFilter02MaximumLabel;
        private System.Windows.Forms.TextBox logFilter02Minimum;
        private System.Windows.Forms.TextBox logFilter02Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter03;
        private System.Windows.Forms.Label logFilter03Heading;
        private System.Windows.Forms.CheckBox logFilter03Enabled;
        private System.Windows.Forms.ComboBox logFilter03Field;
        private System.Windows.Forms.ComboBox logFilter03Mode;
        private System.Windows.Forms.CheckBox logFilter03Absolute;
        private System.Windows.Forms.Label logFilter03MinimumLabel;
        private System.Windows.Forms.Label logFilter03MaximumLabel;
        private System.Windows.Forms.TextBox logFilter03Minimum;
        private System.Windows.Forms.TextBox logFilter03Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter04;
        private System.Windows.Forms.Label logFilter04Heading;
        private System.Windows.Forms.CheckBox logFilter04Enabled;
        private System.Windows.Forms.ComboBox logFilter04Field;
        private System.Windows.Forms.ComboBox logFilter04Mode;
        private System.Windows.Forms.CheckBox logFilter04Absolute;
        private System.Windows.Forms.Label logFilter04MinimumLabel;
        private System.Windows.Forms.Label logFilter04MaximumLabel;
        private System.Windows.Forms.TextBox logFilter04Minimum;
        private System.Windows.Forms.TextBox logFilter04Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter05;
        private System.Windows.Forms.Label logFilter05Heading;
        private System.Windows.Forms.CheckBox logFilter05Enabled;
        private System.Windows.Forms.ComboBox logFilter05Field;
        private System.Windows.Forms.ComboBox logFilter05Mode;
        private System.Windows.Forms.CheckBox logFilter05Absolute;
        private System.Windows.Forms.Label logFilter05MinimumLabel;
        private System.Windows.Forms.Label logFilter05MaximumLabel;
        private System.Windows.Forms.TextBox logFilter05Minimum;
        private System.Windows.Forms.TextBox logFilter05Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter06;
        private System.Windows.Forms.Label logFilter06Heading;
        private System.Windows.Forms.CheckBox logFilter06Enabled;
        private System.Windows.Forms.ComboBox logFilter06Field;
        private System.Windows.Forms.ComboBox logFilter06Mode;
        private System.Windows.Forms.CheckBox logFilter06Absolute;
        private System.Windows.Forms.Label logFilter06MinimumLabel;
        private System.Windows.Forms.Label logFilter06MaximumLabel;
        private System.Windows.Forms.TextBox logFilter06Minimum;
        private System.Windows.Forms.TextBox logFilter06Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter07;
        private System.Windows.Forms.Label logFilter07Heading;
        private System.Windows.Forms.CheckBox logFilter07Enabled;
        private System.Windows.Forms.ComboBox logFilter07Field;
        private System.Windows.Forms.ComboBox logFilter07Mode;
        private System.Windows.Forms.CheckBox logFilter07Absolute;
        private System.Windows.Forms.Label logFilter07MinimumLabel;
        private System.Windows.Forms.Label logFilter07MaximumLabel;
        private System.Windows.Forms.TextBox logFilter07Minimum;
        private System.Windows.Forms.TextBox logFilter07Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter08;
        private System.Windows.Forms.Label logFilter08Heading;
        private System.Windows.Forms.CheckBox logFilter08Enabled;
        private System.Windows.Forms.ComboBox logFilter08Field;
        private System.Windows.Forms.ComboBox logFilter08Mode;
        private System.Windows.Forms.CheckBox logFilter08Absolute;
        private System.Windows.Forms.Label logFilter08MinimumLabel;
        private System.Windows.Forms.Label logFilter08MaximumLabel;
        private System.Windows.Forms.TextBox logFilter08Minimum;
        private System.Windows.Forms.TextBox logFilter08Maximum;
        private System.Windows.Forms.TableLayoutPanel logFilter09;
        private System.Windows.Forms.Label logFilter09Heading;
        private System.Windows.Forms.Label logFilter09MinimumLabel;
        private System.Windows.Forms.Label logFilter09MaximumLabel;
        private System.Windows.Forms.TableLayoutPanel logFilter10;
        private System.Windows.Forms.Label logFilter10Heading;
        private System.Windows.Forms.CheckBox logFilter10Enabled;
        private System.Windows.Forms.ComboBox logFilter10Field;
        private System.Windows.Forms.ComboBox logFilter10Mode;
        private System.Windows.Forms.CheckBox logFilter10Absolute;
        private System.Windows.Forms.Label logFilter10MinimumLabel;
        private System.Windows.Forms.Label logFilter10MaximumLabel;
        private System.Windows.Forms.TextBox logFilter10Minimum;
        private System.Windows.Forms.TextBox logFilter10Maximum;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FLApplyLogSettings = new System.Windows.Forms.Button();
            this.toolbarInfoLabel = new System.Windows.Forms.Label();
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.contentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.selectedFieldsGroup = new System.Windows.Forms.GroupBox();
            this.selectionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.selectAll = new System.Windows.Forms.CheckBox();
            this.selectionCountLabel = new System.Windows.Forms.Label();
            this.logFieldsTreeView = new System.Windows.Forms.TreeView();
            this.filterAndOutputLayout = new System.Windows.Forms.TableLayoutPanel();
            this.filtersGroup = new System.Windows.Forms.GroupBox();
            this.filtersScrollPanel = new System.Windows.Forms.Panel();
            this.filterRowsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter01 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter01Heading = new System.Windows.Forms.Label();
            this.logFilter01MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter01MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter01Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter01Field = new System.Windows.Forms.ComboBox();
            this.logFilter01Mode = new System.Windows.Forms.ComboBox();
            this.logFilter01Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter01Minimum = new System.Windows.Forms.TextBox();
            this.logFilter01Maximum = new System.Windows.Forms.TextBox();
            this.logFilter02 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter02Heading = new System.Windows.Forms.Label();
            this.logFilter02MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter02MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter02Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter02Field = new System.Windows.Forms.ComboBox();
            this.logFilter02Mode = new System.Windows.Forms.ComboBox();
            this.logFilter02Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter02Minimum = new System.Windows.Forms.TextBox();
            this.logFilter02Maximum = new System.Windows.Forms.TextBox();
            this.logFilter03 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter03Heading = new System.Windows.Forms.Label();
            this.logFilter03MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter03MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter03Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter03Field = new System.Windows.Forms.ComboBox();
            this.logFilter03Mode = new System.Windows.Forms.ComboBox();
            this.logFilter03Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter03Minimum = new System.Windows.Forms.TextBox();
            this.logFilter03Maximum = new System.Windows.Forms.TextBox();
            this.logFilter04 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter04Heading = new System.Windows.Forms.Label();
            this.logFilter04MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter04MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter04Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter04Field = new System.Windows.Forms.ComboBox();
            this.logFilter04Mode = new System.Windows.Forms.ComboBox();
            this.logFilter04Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter04Minimum = new System.Windows.Forms.TextBox();
            this.logFilter04Maximum = new System.Windows.Forms.TextBox();
            this.logFilter05 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter05Heading = new System.Windows.Forms.Label();
            this.logFilter05MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter05MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter05Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter05Field = new System.Windows.Forms.ComboBox();
            this.logFilter05Mode = new System.Windows.Forms.ComboBox();
            this.logFilter05Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter05Minimum = new System.Windows.Forms.TextBox();
            this.logFilter05Maximum = new System.Windows.Forms.TextBox();
            this.logFilter06 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter06Heading = new System.Windows.Forms.Label();
            this.logFilter06MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter06MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter06Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter06Field = new System.Windows.Forms.ComboBox();
            this.logFilter06Mode = new System.Windows.Forms.ComboBox();
            this.logFilter06Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter06Minimum = new System.Windows.Forms.TextBox();
            this.logFilter06Maximum = new System.Windows.Forms.TextBox();
            this.logFilter07 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter07Heading = new System.Windows.Forms.Label();
            this.logFilter07MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter07MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter07Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter07Field = new System.Windows.Forms.ComboBox();
            this.logFilter07Mode = new System.Windows.Forms.ComboBox();
            this.logFilter07Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter07Minimum = new System.Windows.Forms.TextBox();
            this.logFilter07Maximum = new System.Windows.Forms.TextBox();
            this.logFilter08 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter08Heading = new System.Windows.Forms.Label();
            this.logFilter08MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter08MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter08Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter08Field = new System.Windows.Forms.ComboBox();
            this.logFilter08Mode = new System.Windows.Forms.ComboBox();
            this.logFilter08Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter08Minimum = new System.Windows.Forms.TextBox();
            this.logFilter08Maximum = new System.Windows.Forms.TextBox();
            this.logFilter09 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter09Heading = new System.Windows.Forms.Label();
            this.logFilter09MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter09MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter09Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter09Field = new System.Windows.Forms.ComboBox();
            this.logFilter09Mode = new System.Windows.Forms.ComboBox();
            this.logFilter09Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter09Minimum = new System.Windows.Forms.TextBox();
            this.logFilter09Maximum = new System.Windows.Forms.TextBox();
            this.logFilter10 = new System.Windows.Forms.TableLayoutPanel();
            this.logFilter10Heading = new System.Windows.Forms.Label();
            this.logFilter10MinimumLabel = new System.Windows.Forms.Label();
            this.logFilter10MaximumLabel = new System.Windows.Forms.Label();
            this.logFilter10Enabled = new System.Windows.Forms.CheckBox();
            this.logFilter10Field = new System.Windows.Forms.ComboBox();
            this.logFilter10Mode = new System.Windows.Forms.ComboBox();
            this.logFilter10Absolute = new System.Windows.Forms.CheckBox();
            this.logFilter10Minimum = new System.Windows.Forms.TextBox();
            this.logFilter10Maximum = new System.Windows.Forms.TextBox();
            this.outputGroup = new System.Windows.Forms.GroupBox();
            this.outputLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pathLabel = new System.Windows.Forms.Label();
            this.LogFolderTextBox = new System.Windows.Forms.TextBox();
            this.BrowseLogFolderButton = new System.Windows.Forms.Button();
            this.delimiterLabel = new System.Windows.Forms.Label();
            this.DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.timeLimitLabel = new System.Windows.Forms.Label();
            this.TimeLimitSecondsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sizeLimitLabel = new System.Windows.Forms.Label();
            this.TotalSizeMiBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rootLayout.SuspendLayout();
            this.toolbarLayout.SuspendLayout();
            this.contentLayout.SuspendLayout();
            this.selectedFieldsGroup.SuspendLayout();
            this.selectionsLayout.SuspendLayout();
            this.filterAndOutputLayout.SuspendLayout();
            this.filtersGroup.SuspendLayout();
            this.filtersScrollPanel.SuspendLayout();
            this.filterRowsLayout.SuspendLayout();
            this.logFilter01.SuspendLayout();
            this.logFilter02.SuspendLayout();
            this.logFilter03.SuspendLayout();
            this.logFilter04.SuspendLayout();
            this.logFilter05.SuspendLayout();
            this.logFilter06.SuspendLayout();
            this.logFilter07.SuspendLayout();
            this.logFilter08.SuspendLayout();
            this.logFilter09.SuspendLayout();
            this.logFilter10.SuspendLayout();
            this.outputGroup.SuspendLayout();
            this.outputLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitSecondsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSizeMiBNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.toolbarLayout, 0, 0);
            this.rootLayout.Controls.Add(this.contentLayout, 0, 1);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.Padding = new System.Windows.Forms.Padding(4);
            this.rootLayout.RowCount = 2;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Size = new System.Drawing.Size(1270, 820);
            this.rootLayout.TabIndex = 0;
            // 
            // toolbarLayout
            // 
            this.toolbarLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.toolbarLayout.ColumnCount = 4;
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbarLayout.Controls.Add(this.FLApplyLogSettings, 0, 0);
            this.toolbarLayout.Controls.Add(this.toolbarInfoLabel, 1, 0);
            this.toolbarLayout.Controls.Add(this.SettingsProfilesHost, 2, 0);
            this.toolbarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarLayout.Location = new System.Drawing.Point(4, 4);
            this.toolbarLayout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.toolbarLayout.Name = "toolbarLayout";
            this.toolbarLayout.RowCount = 1;
            this.toolbarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbarLayout.Size = new System.Drawing.Size(1262, 46);
            this.toolbarLayout.TabIndex = 0;
            // 
            // FLApplyLogSettings
            // 
            this.FLApplyLogSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FLApplyLogSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLApplyLogSettings.ForeColor = System.Drawing.Color.White;
            this.FLApplyLogSettings.Location = new System.Drawing.Point(5, 6);
            this.FLApplyLogSettings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.FLApplyLogSettings.Name = "FLApplyLogSettings";
            this.FLApplyLogSettings.Size = new System.Drawing.Size(190, 34);
            this.FLApplyLogSettings.TabIndex = 0;
            this.FLApplyLogSettings.Text = "Apply Logging Settings";
            this.FLApplyLogSettings.UseVisualStyleBackColor = false;
            this.FLApplyLogSettings.Click += new System.EventHandler(this.ApplyLogSettings_Click);
            // 
            // toolbarInfoLabel
            // 
            this.toolbarInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarInfoLabel.ForeColor = System.Drawing.Color.LightGray;
            this.toolbarInfoLabel.Location = new System.Drawing.Point(203, 0);
            this.toolbarInfoLabel.Name = "toolbarInfoLabel";
            this.toolbarInfoLabel.Size = new System.Drawing.Size(294, 46);
            this.toolbarInfoLabel.TabIndex = 1;
            this.toolbarInfoLabel.Text = "Changes take effect when the next logging session starts";
            this.toolbarInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesHost.Location = new System.Drawing.Point(504, 4);
            this.SettingsProfilesHost.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Size = new System.Drawing.Size(130, 38);
            this.SettingsProfilesHost.TabIndex = 2;
            // 
            // contentLayout
            // 
            this.contentLayout.ColumnCount = 2;
            this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.contentLayout.Controls.Add(this.selectedFieldsGroup, 0, 0);
            this.contentLayout.Controls.Add(this.filterAndOutputLayout, 1, 0);
            this.contentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentLayout.Location = new System.Drawing.Point(7, 57);
            this.contentLayout.Name = "contentLayout";
            this.contentLayout.RowCount = 1;
            this.contentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentLayout.Size = new System.Drawing.Size(1256, 756);
            this.contentLayout.TabIndex = 1;
            // 
            // selectedFieldsGroup
            // 
            this.selectedFieldsGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.selectedFieldsGroup.Controls.Add(this.selectionsLayout);
            this.selectedFieldsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedFieldsGroup.ForeColor = System.Drawing.Color.White;
            this.selectedFieldsGroup.Location = new System.Drawing.Point(2, 2);
            this.selectedFieldsGroup.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.selectedFieldsGroup.Name = "selectedFieldsGroup";
            this.selectedFieldsGroup.Padding = new System.Windows.Forms.Padding(7, 9, 7, 7);
            this.selectedFieldsGroup.Size = new System.Drawing.Size(432, 752);
            this.selectedFieldsGroup.TabIndex = 0;
            this.selectedFieldsGroup.TabStop = false;
            this.selectedFieldsGroup.Text = "Log fields — parent checkbox selects all wheels";
            // 
            // selectionsLayout
            // 
            this.selectionsLayout.ColumnCount = 2;
            this.selectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.selectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.selectionsLayout.Controls.Add(this.selectAll, 0, 0);
            this.selectionsLayout.Controls.Add(this.selectionCountLabel, 1, 0);
            this.selectionsLayout.Controls.Add(this.logFieldsTreeView, 0, 1);
            this.selectionsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionsLayout.Location = new System.Drawing.Point(7, 22);
            this.selectionsLayout.Name = "selectionsLayout";
            this.selectionsLayout.RowCount = 2;
            this.selectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.selectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.selectionsLayout.Size = new System.Drawing.Size(418, 723);
            this.selectionsLayout.TabIndex = 0;
            // 
            // selectAll
            // 
            this.selectAll.AutoSize = true;
            this.selectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectAll.ForeColor = System.Drawing.Color.White;
            this.selectAll.Location = new System.Drawing.Point(4, 2);
            this.selectAll.Margin = new System.Windows.Forms.Padding(4, 2, 3, 0);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(69, 33);
            this.selectAll.TabIndex = 0;
            this.selectAll.Text = "Select all";
            this.selectAll.CheckedChanged += new System.EventHandler(this.selectAll_CheckedChanged);
            // 
            // selectionCountLabel
            // 
            this.selectionCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionCountLabel.ForeColor = System.Drawing.Color.LightGray;
            this.selectionCountLabel.Location = new System.Drawing.Point(118, 0);
            this.selectionCountLabel.Name = "selectionCountLabel";
            this.selectionCountLabel.Size = new System.Drawing.Size(297, 35);
            this.selectionCountLabel.TabIndex = 1;
            this.selectionCountLabel.Text = "0 selected";
            this.selectionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logFieldsTreeView
            // 
            this.logFieldsTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.logFieldsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logFieldsTreeView.CheckBoxes = true;
            this.selectionsLayout.SetColumnSpan(this.logFieldsTreeView, 2);
            this.logFieldsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFieldsTreeView.ForeColor = System.Drawing.Color.White;
            this.logFieldsTreeView.HideSelection = false;
            this.logFieldsTreeView.ItemHeight = 22;
            this.logFieldsTreeView.Location = new System.Drawing.Point(1, 36);
            this.logFieldsTreeView.Margin = new System.Windows.Forms.Padding(1);
            this.logFieldsTreeView.Name = "logFieldsTreeView";
            this.logFieldsTreeView.Size = new System.Drawing.Size(416, 686);
            this.logFieldsTreeView.TabIndex = 2;
            // 
            // filterAndOutputLayout
            // 
            this.filterAndOutputLayout.ColumnCount = 1;
            this.filterAndOutputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterAndOutputLayout.Controls.Add(this.filtersGroup, 0, 0);
            this.filterAndOutputLayout.Controls.Add(this.outputGroup, 0, 1);
            this.filterAndOutputLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterAndOutputLayout.Location = new System.Drawing.Point(442, 3);
            this.filterAndOutputLayout.Name = "filterAndOutputLayout";
            this.filterAndOutputLayout.RowCount = 2;
            this.filterAndOutputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterAndOutputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.filterAndOutputLayout.Size = new System.Drawing.Size(811, 750);
            this.filterAndOutputLayout.TabIndex = 1;
            // 
            // filtersGroup
            // 
            this.filtersGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.filtersGroup.Controls.Add(this.filtersScrollPanel);
            this.filtersGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersGroup.ForeColor = System.Drawing.Color.White;
            this.filtersGroup.Location = new System.Drawing.Point(2, 2);
            this.filtersGroup.Margin = new System.Windows.Forms.Padding(2);
            this.filtersGroup.Name = "filtersGroup";
            this.filtersGroup.Size = new System.Drawing.Size(807, 556);
            this.filtersGroup.TabIndex = 0;
            this.filtersGroup.TabStop = false;
            this.filtersGroup.Text = "10 optional range filters — all enabled filters must pass";
            // 
            // filtersScrollPanel
            // 
            this.filtersScrollPanel.AutoScroll = true;
            this.filtersScrollPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.filtersScrollPanel.Controls.Add(this.filterRowsLayout);
            this.filtersScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersScrollPanel.Location = new System.Drawing.Point(3, 16);
            this.filtersScrollPanel.Name = "filtersScrollPanel";
            this.filtersScrollPanel.Size = new System.Drawing.Size(801, 537);
            this.filtersScrollPanel.TabIndex = 0;
            // 
            // filterRowsLayout
            // 
            this.filterRowsLayout.AutoSize = true;
            this.filterRowsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterRowsLayout.ColumnCount = 1;
            this.filterRowsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterRowsLayout.Controls.Add(this.logFilter01, 0, 0);
            this.filterRowsLayout.Controls.Add(this.logFilter02, 0, 1);
            this.filterRowsLayout.Controls.Add(this.logFilter03, 0, 2);
            this.filterRowsLayout.Controls.Add(this.logFilter04, 0, 3);
            this.filterRowsLayout.Controls.Add(this.logFilter05, 0, 4);
            this.filterRowsLayout.Controls.Add(this.logFilter06, 0, 5);
            this.filterRowsLayout.Controls.Add(this.logFilter07, 0, 6);
            this.filterRowsLayout.Controls.Add(this.logFilter08, 0, 7);
            this.filterRowsLayout.Controls.Add(this.logFilter09, 0, 8);
            this.filterRowsLayout.Controls.Add(this.logFilter10, 0, 9);
            this.filterRowsLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterRowsLayout.Location = new System.Drawing.Point(0, 0);
            this.filterRowsLayout.MinimumSize = new System.Drawing.Size(590, 0);
            this.filterRowsLayout.Name = "filterRowsLayout";
            this.filterRowsLayout.RowCount = 10;
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.filterRowsLayout.Size = new System.Drawing.Size(801, 400);
            this.filterRowsLayout.TabIndex = 0;
            // 
            // logFilter01
            // 
            this.logFilter01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter01.ColumnCount = 6;
            this.logFilter01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter01.Controls.Add(this.logFilter01Heading, 0, 0);
            this.logFilter01.Controls.Add(this.logFilter01MinimumLabel, 4, 0);
            this.logFilter01.Controls.Add(this.logFilter01MaximumLabel, 5, 0);
            this.logFilter01.Controls.Add(this.logFilter01Enabled, 0, 1);
            this.logFilter01.Controls.Add(this.logFilter01Field, 1, 1);
            this.logFilter01.Controls.Add(this.logFilter01Mode, 2, 1);
            this.logFilter01.Controls.Add(this.logFilter01Absolute, 3, 1);
            this.logFilter01.Controls.Add(this.logFilter01Minimum, 4, 1);
            this.logFilter01.Controls.Add(this.logFilter01Maximum, 5, 1);
            this.logFilter01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01.ForeColor = System.Drawing.Color.White;
            this.logFilter01.Location = new System.Drawing.Point(1, 1);
            this.logFilter01.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter01.Name = "logFilter01";
            this.logFilter01.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter01.RowCount = 2;
            this.logFilter01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter01.Size = new System.Drawing.Size(799, 38);
            this.logFilter01.TabIndex = 0;
            // 
            // logFilter01Heading
            // 
            this.logFilter01Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter01Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter01Heading.Name = "logFilter01Heading";
            this.logFilter01Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter01Heading.TabIndex = 0;
            this.logFilter01Heading.Text = "Filter 1";
            // 
            // logFilter01MinimumLabel
            // 
            this.logFilter01MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter01MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter01MinimumLabel.Name = "logFilter01MinimumLabel";
            this.logFilter01MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter01MinimumLabel.TabIndex = 1;
            this.logFilter01MinimumLabel.Text = "Minimum";
            // 
            // logFilter01MaximumLabel
            // 
            this.logFilter01MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter01MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter01MaximumLabel.Name = "logFilter01MaximumLabel";
            this.logFilter01MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter01MaximumLabel.TabIndex = 2;
            this.logFilter01MaximumLabel.Text = "Maximum";
            // 
            // logFilter01Enabled
            // 
            this.logFilter01Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter01Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter01Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter01Enabled.Name = "logFilter01Enabled";
            this.logFilter01Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter01Enabled.TabIndex = 3;
            this.logFilter01Enabled.Text = "Enable";
            // 
            // logFilter01Field
            // 
            this.logFilter01Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter01Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter01Field.ForeColor = System.Drawing.Color.White;
            this.logFilter01Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter01Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter01Field.Name = "logFilter01Field";
            this.logFilter01Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter01Field.TabIndex = 4;
            // 
            // logFilter01Mode
            // 
            this.logFilter01Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter01Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter01Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter01Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter01Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter01Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter01Mode.Name = "logFilter01Mode";
            this.logFilter01Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter01Mode.TabIndex = 5;
            // 
            // logFilter01Absolute
            // 
            this.logFilter01Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter01Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter01Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter01Absolute.Name = "logFilter01Absolute";
            this.logFilter01Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter01Absolute.TabIndex = 6;
            this.logFilter01Absolute.Text = "Absolute";
            // 
            // logFilter01Minimum
            // 
            this.logFilter01Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter01Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter01Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter01Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter01Minimum.Name = "logFilter01Minimum";
            this.logFilter01Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter01Minimum.TabIndex = 7;
            // 
            // logFilter01Maximum
            // 
            this.logFilter01Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter01Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter01Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter01Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter01Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter01Maximum.Name = "logFilter01Maximum";
            this.logFilter01Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter01Maximum.TabIndex = 8;
            // 
            // logFilter02
            // 
            this.logFilter02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter02.ColumnCount = 6;
            this.logFilter02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter02.Controls.Add(this.logFilter02Heading, 0, 0);
            this.logFilter02.Controls.Add(this.logFilter02MinimumLabel, 4, 0);
            this.logFilter02.Controls.Add(this.logFilter02MaximumLabel, 5, 0);
            this.logFilter02.Controls.Add(this.logFilter02Enabled, 0, 1);
            this.logFilter02.Controls.Add(this.logFilter02Field, 1, 1);
            this.logFilter02.Controls.Add(this.logFilter02Mode, 2, 1);
            this.logFilter02.Controls.Add(this.logFilter02Absolute, 3, 1);
            this.logFilter02.Controls.Add(this.logFilter02Minimum, 4, 1);
            this.logFilter02.Controls.Add(this.logFilter02Maximum, 5, 1);
            this.logFilter02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02.ForeColor = System.Drawing.Color.White;
            this.logFilter02.Location = new System.Drawing.Point(1, 41);
            this.logFilter02.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter02.Name = "logFilter02";
            this.logFilter02.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter02.RowCount = 2;
            this.logFilter02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter02.Size = new System.Drawing.Size(799, 38);
            this.logFilter02.TabIndex = 1;
            // 
            // logFilter02Heading
            // 
            this.logFilter02Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter02Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter02Heading.Name = "logFilter02Heading";
            this.logFilter02Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter02Heading.TabIndex = 0;
            this.logFilter02Heading.Text = "Filter 2";
            // 
            // logFilter02MinimumLabel
            // 
            this.logFilter02MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter02MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter02MinimumLabel.Name = "logFilter02MinimumLabel";
            this.logFilter02MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter02MinimumLabel.TabIndex = 1;
            this.logFilter02MinimumLabel.Text = "Minimum";
            // 
            // logFilter02MaximumLabel
            // 
            this.logFilter02MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter02MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter02MaximumLabel.Name = "logFilter02MaximumLabel";
            this.logFilter02MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter02MaximumLabel.TabIndex = 2;
            this.logFilter02MaximumLabel.Text = "Maximum";
            // 
            // logFilter02Enabled
            // 
            this.logFilter02Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter02Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter02Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter02Enabled.Name = "logFilter02Enabled";
            this.logFilter02Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter02Enabled.TabIndex = 3;
            this.logFilter02Enabled.Text = "Enable";
            // 
            // logFilter02Field
            // 
            this.logFilter02Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter02Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter02Field.ForeColor = System.Drawing.Color.White;
            this.logFilter02Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter02Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter02Field.Name = "logFilter02Field";
            this.logFilter02Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter02Field.TabIndex = 4;
            // 
            // logFilter02Mode
            // 
            this.logFilter02Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter02Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter02Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter02Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter02Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter02Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter02Mode.Name = "logFilter02Mode";
            this.logFilter02Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter02Mode.TabIndex = 5;
            // 
            // logFilter02Absolute
            // 
            this.logFilter02Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter02Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter02Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter02Absolute.Name = "logFilter02Absolute";
            this.logFilter02Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter02Absolute.TabIndex = 6;
            this.logFilter02Absolute.Text = "Absolute";
            // 
            // logFilter02Minimum
            // 
            this.logFilter02Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter02Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter02Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter02Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter02Minimum.Name = "logFilter02Minimum";
            this.logFilter02Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter02Minimum.TabIndex = 7;
            // 
            // logFilter02Maximum
            // 
            this.logFilter02Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter02Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter02Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter02Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter02Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter02Maximum.Name = "logFilter02Maximum";
            this.logFilter02Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter02Maximum.TabIndex = 8;
            // 
            // logFilter03
            // 
            this.logFilter03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter03.ColumnCount = 6;
            this.logFilter03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter03.Controls.Add(this.logFilter03Heading, 0, 0);
            this.logFilter03.Controls.Add(this.logFilter03MinimumLabel, 4, 0);
            this.logFilter03.Controls.Add(this.logFilter03MaximumLabel, 5, 0);
            this.logFilter03.Controls.Add(this.logFilter03Enabled, 0, 1);
            this.logFilter03.Controls.Add(this.logFilter03Field, 1, 1);
            this.logFilter03.Controls.Add(this.logFilter03Mode, 2, 1);
            this.logFilter03.Controls.Add(this.logFilter03Absolute, 3, 1);
            this.logFilter03.Controls.Add(this.logFilter03Minimum, 4, 1);
            this.logFilter03.Controls.Add(this.logFilter03Maximum, 5, 1);
            this.logFilter03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03.ForeColor = System.Drawing.Color.White;
            this.logFilter03.Location = new System.Drawing.Point(1, 81);
            this.logFilter03.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter03.Name = "logFilter03";
            this.logFilter03.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter03.RowCount = 2;
            this.logFilter03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter03.Size = new System.Drawing.Size(799, 38);
            this.logFilter03.TabIndex = 2;
            // 
            // logFilter03Heading
            // 
            this.logFilter03Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter03Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter03Heading.Name = "logFilter03Heading";
            this.logFilter03Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter03Heading.TabIndex = 0;
            this.logFilter03Heading.Text = "Filter 3";
            // 
            // logFilter03MinimumLabel
            // 
            this.logFilter03MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter03MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter03MinimumLabel.Name = "logFilter03MinimumLabel";
            this.logFilter03MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter03MinimumLabel.TabIndex = 1;
            this.logFilter03MinimumLabel.Text = "Minimum";
            // 
            // logFilter03MaximumLabel
            // 
            this.logFilter03MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter03MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter03MaximumLabel.Name = "logFilter03MaximumLabel";
            this.logFilter03MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter03MaximumLabel.TabIndex = 2;
            this.logFilter03MaximumLabel.Text = "Maximum";
            // 
            // logFilter03Enabled
            // 
            this.logFilter03Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter03Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter03Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter03Enabled.Name = "logFilter03Enabled";
            this.logFilter03Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter03Enabled.TabIndex = 3;
            this.logFilter03Enabled.Text = "Enable";
            // 
            // logFilter03Field
            // 
            this.logFilter03Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter03Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter03Field.ForeColor = System.Drawing.Color.White;
            this.logFilter03Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter03Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter03Field.Name = "logFilter03Field";
            this.logFilter03Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter03Field.TabIndex = 4;
            // 
            // logFilter03Mode
            // 
            this.logFilter03Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter03Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter03Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter03Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter03Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter03Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter03Mode.Name = "logFilter03Mode";
            this.logFilter03Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter03Mode.TabIndex = 5;
            // 
            // logFilter03Absolute
            // 
            this.logFilter03Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter03Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter03Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter03Absolute.Name = "logFilter03Absolute";
            this.logFilter03Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter03Absolute.TabIndex = 6;
            this.logFilter03Absolute.Text = "Absolute";
            // 
            // logFilter03Minimum
            // 
            this.logFilter03Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter03Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter03Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter03Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter03Minimum.Name = "logFilter03Minimum";
            this.logFilter03Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter03Minimum.TabIndex = 7;
            // 
            // logFilter03Maximum
            // 
            this.logFilter03Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter03Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter03Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter03Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter03Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter03Maximum.Name = "logFilter03Maximum";
            this.logFilter03Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter03Maximum.TabIndex = 8;
            // 
            // logFilter04
            // 
            this.logFilter04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter04.ColumnCount = 6;
            this.logFilter04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter04.Controls.Add(this.logFilter04Heading, 0, 0);
            this.logFilter04.Controls.Add(this.logFilter04MinimumLabel, 4, 0);
            this.logFilter04.Controls.Add(this.logFilter04MaximumLabel, 5, 0);
            this.logFilter04.Controls.Add(this.logFilter04Enabled, 0, 1);
            this.logFilter04.Controls.Add(this.logFilter04Field, 1, 1);
            this.logFilter04.Controls.Add(this.logFilter04Mode, 2, 1);
            this.logFilter04.Controls.Add(this.logFilter04Absolute, 3, 1);
            this.logFilter04.Controls.Add(this.logFilter04Minimum, 4, 1);
            this.logFilter04.Controls.Add(this.logFilter04Maximum, 5, 1);
            this.logFilter04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04.ForeColor = System.Drawing.Color.White;
            this.logFilter04.Location = new System.Drawing.Point(1, 121);
            this.logFilter04.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter04.Name = "logFilter04";
            this.logFilter04.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter04.RowCount = 2;
            this.logFilter04.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter04.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter04.Size = new System.Drawing.Size(799, 38);
            this.logFilter04.TabIndex = 3;
            // 
            // logFilter04Heading
            // 
            this.logFilter04Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter04Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter04Heading.Name = "logFilter04Heading";
            this.logFilter04Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter04Heading.TabIndex = 0;
            this.logFilter04Heading.Text = "Filter 4";
            // 
            // logFilter04MinimumLabel
            // 
            this.logFilter04MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter04MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter04MinimumLabel.Name = "logFilter04MinimumLabel";
            this.logFilter04MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter04MinimumLabel.TabIndex = 1;
            this.logFilter04MinimumLabel.Text = "Minimum";
            // 
            // logFilter04MaximumLabel
            // 
            this.logFilter04MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter04MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter04MaximumLabel.Name = "logFilter04MaximumLabel";
            this.logFilter04MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter04MaximumLabel.TabIndex = 2;
            this.logFilter04MaximumLabel.Text = "Maximum";
            // 
            // logFilter04Enabled
            // 
            this.logFilter04Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter04Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter04Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter04Enabled.Name = "logFilter04Enabled";
            this.logFilter04Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter04Enabled.TabIndex = 3;
            this.logFilter04Enabled.Text = "Enable";
            // 
            // logFilter04Field
            // 
            this.logFilter04Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter04Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter04Field.ForeColor = System.Drawing.Color.White;
            this.logFilter04Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter04Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter04Field.Name = "logFilter04Field";
            this.logFilter04Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter04Field.TabIndex = 4;
            // 
            // logFilter04Mode
            // 
            this.logFilter04Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter04Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter04Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter04Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter04Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter04Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter04Mode.Name = "logFilter04Mode";
            this.logFilter04Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter04Mode.TabIndex = 5;
            // 
            // logFilter04Absolute
            // 
            this.logFilter04Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter04Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter04Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter04Absolute.Name = "logFilter04Absolute";
            this.logFilter04Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter04Absolute.TabIndex = 6;
            this.logFilter04Absolute.Text = "Absolute";
            // 
            // logFilter04Minimum
            // 
            this.logFilter04Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter04Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter04Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter04Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter04Minimum.Name = "logFilter04Minimum";
            this.logFilter04Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter04Minimum.TabIndex = 7;
            // 
            // logFilter04Maximum
            // 
            this.logFilter04Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter04Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter04Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter04Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter04Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter04Maximum.Name = "logFilter04Maximum";
            this.logFilter04Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter04Maximum.TabIndex = 8;
            // 
            // logFilter05
            // 
            this.logFilter05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter05.ColumnCount = 6;
            this.logFilter05.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter05.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter05.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter05.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter05.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter05.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter05.Controls.Add(this.logFilter05Heading, 0, 0);
            this.logFilter05.Controls.Add(this.logFilter05MinimumLabel, 4, 0);
            this.logFilter05.Controls.Add(this.logFilter05MaximumLabel, 5, 0);
            this.logFilter05.Controls.Add(this.logFilter05Enabled, 0, 1);
            this.logFilter05.Controls.Add(this.logFilter05Field, 1, 1);
            this.logFilter05.Controls.Add(this.logFilter05Mode, 2, 1);
            this.logFilter05.Controls.Add(this.logFilter05Absolute, 3, 1);
            this.logFilter05.Controls.Add(this.logFilter05Minimum, 4, 1);
            this.logFilter05.Controls.Add(this.logFilter05Maximum, 5, 1);
            this.logFilter05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05.ForeColor = System.Drawing.Color.White;
            this.logFilter05.Location = new System.Drawing.Point(1, 161);
            this.logFilter05.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter05.Name = "logFilter05";
            this.logFilter05.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter05.RowCount = 2;
            this.logFilter05.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter05.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter05.Size = new System.Drawing.Size(799, 38);
            this.logFilter05.TabIndex = 4;
            // 
            // logFilter05Heading
            // 
            this.logFilter05Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter05Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter05Heading.Name = "logFilter05Heading";
            this.logFilter05Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter05Heading.TabIndex = 0;
            this.logFilter05Heading.Text = "Filter 5";
            // 
            // logFilter05MinimumLabel
            // 
            this.logFilter05MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter05MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter05MinimumLabel.Name = "logFilter05MinimumLabel";
            this.logFilter05MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter05MinimumLabel.TabIndex = 1;
            this.logFilter05MinimumLabel.Text = "Minimum";
            // 
            // logFilter05MaximumLabel
            // 
            this.logFilter05MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter05MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter05MaximumLabel.Name = "logFilter05MaximumLabel";
            this.logFilter05MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter05MaximumLabel.TabIndex = 2;
            this.logFilter05MaximumLabel.Text = "Maximum";
            // 
            // logFilter05Enabled
            // 
            this.logFilter05Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter05Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter05Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter05Enabled.Name = "logFilter05Enabled";
            this.logFilter05Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter05Enabled.TabIndex = 3;
            this.logFilter05Enabled.Text = "Enable";
            // 
            // logFilter05Field
            // 
            this.logFilter05Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter05Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter05Field.ForeColor = System.Drawing.Color.White;
            this.logFilter05Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter05Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter05Field.Name = "logFilter05Field";
            this.logFilter05Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter05Field.TabIndex = 4;
            // 
            // logFilter05Mode
            // 
            this.logFilter05Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter05Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter05Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter05Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter05Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter05Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter05Mode.Name = "logFilter05Mode";
            this.logFilter05Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter05Mode.TabIndex = 5;
            // 
            // logFilter05Absolute
            // 
            this.logFilter05Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter05Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter05Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter05Absolute.Name = "logFilter05Absolute";
            this.logFilter05Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter05Absolute.TabIndex = 6;
            this.logFilter05Absolute.Text = "Absolute";
            // 
            // logFilter05Minimum
            // 
            this.logFilter05Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter05Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter05Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter05Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter05Minimum.Name = "logFilter05Minimum";
            this.logFilter05Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter05Minimum.TabIndex = 7;
            // 
            // logFilter05Maximum
            // 
            this.logFilter05Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter05Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter05Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter05Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter05Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter05Maximum.Name = "logFilter05Maximum";
            this.logFilter05Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter05Maximum.TabIndex = 8;
            // 
            // logFilter06
            // 
            this.logFilter06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter06.ColumnCount = 6;
            this.logFilter06.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter06.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter06.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter06.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter06.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter06.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter06.Controls.Add(this.logFilter06Heading, 0, 0);
            this.logFilter06.Controls.Add(this.logFilter06MinimumLabel, 4, 0);
            this.logFilter06.Controls.Add(this.logFilter06MaximumLabel, 5, 0);
            this.logFilter06.Controls.Add(this.logFilter06Enabled, 0, 1);
            this.logFilter06.Controls.Add(this.logFilter06Field, 1, 1);
            this.logFilter06.Controls.Add(this.logFilter06Mode, 2, 1);
            this.logFilter06.Controls.Add(this.logFilter06Absolute, 3, 1);
            this.logFilter06.Controls.Add(this.logFilter06Minimum, 4, 1);
            this.logFilter06.Controls.Add(this.logFilter06Maximum, 5, 1);
            this.logFilter06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06.ForeColor = System.Drawing.Color.White;
            this.logFilter06.Location = new System.Drawing.Point(1, 201);
            this.logFilter06.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter06.Name = "logFilter06";
            this.logFilter06.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter06.RowCount = 2;
            this.logFilter06.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter06.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter06.Size = new System.Drawing.Size(799, 38);
            this.logFilter06.TabIndex = 5;
            // 
            // logFilter06Heading
            // 
            this.logFilter06Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter06Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter06Heading.Name = "logFilter06Heading";
            this.logFilter06Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter06Heading.TabIndex = 0;
            this.logFilter06Heading.Text = "Filter 6";
            // 
            // logFilter06MinimumLabel
            // 
            this.logFilter06MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter06MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter06MinimumLabel.Name = "logFilter06MinimumLabel";
            this.logFilter06MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter06MinimumLabel.TabIndex = 1;
            this.logFilter06MinimumLabel.Text = "Minimum";
            // 
            // logFilter06MaximumLabel
            // 
            this.logFilter06MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter06MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter06MaximumLabel.Name = "logFilter06MaximumLabel";
            this.logFilter06MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter06MaximumLabel.TabIndex = 2;
            this.logFilter06MaximumLabel.Text = "Maximum";
            // 
            // logFilter06Enabled
            // 
            this.logFilter06Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter06Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter06Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter06Enabled.Name = "logFilter06Enabled";
            this.logFilter06Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter06Enabled.TabIndex = 3;
            this.logFilter06Enabled.Text = "Enable";
            // 
            // logFilter06Field
            // 
            this.logFilter06Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter06Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter06Field.ForeColor = System.Drawing.Color.White;
            this.logFilter06Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter06Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter06Field.Name = "logFilter06Field";
            this.logFilter06Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter06Field.TabIndex = 4;
            // 
            // logFilter06Mode
            // 
            this.logFilter06Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter06Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter06Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter06Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter06Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter06Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter06Mode.Name = "logFilter06Mode";
            this.logFilter06Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter06Mode.TabIndex = 5;
            // 
            // logFilter06Absolute
            // 
            this.logFilter06Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter06Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter06Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter06Absolute.Name = "logFilter06Absolute";
            this.logFilter06Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter06Absolute.TabIndex = 6;
            this.logFilter06Absolute.Text = "Absolute";
            // 
            // logFilter06Minimum
            // 
            this.logFilter06Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter06Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter06Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter06Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter06Minimum.Name = "logFilter06Minimum";
            this.logFilter06Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter06Minimum.TabIndex = 7;
            // 
            // logFilter06Maximum
            // 
            this.logFilter06Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter06Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter06Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter06Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter06Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter06Maximum.Name = "logFilter06Maximum";
            this.logFilter06Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter06Maximum.TabIndex = 8;
            // 
            // logFilter07
            // 
            this.logFilter07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter07.ColumnCount = 6;
            this.logFilter07.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter07.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter07.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter07.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter07.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter07.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter07.Controls.Add(this.logFilter07Heading, 0, 0);
            this.logFilter07.Controls.Add(this.logFilter07MinimumLabel, 4, 0);
            this.logFilter07.Controls.Add(this.logFilter07MaximumLabel, 5, 0);
            this.logFilter07.Controls.Add(this.logFilter07Enabled, 0, 1);
            this.logFilter07.Controls.Add(this.logFilter07Field, 1, 1);
            this.logFilter07.Controls.Add(this.logFilter07Mode, 2, 1);
            this.logFilter07.Controls.Add(this.logFilter07Absolute, 3, 1);
            this.logFilter07.Controls.Add(this.logFilter07Minimum, 4, 1);
            this.logFilter07.Controls.Add(this.logFilter07Maximum, 5, 1);
            this.logFilter07.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07.ForeColor = System.Drawing.Color.White;
            this.logFilter07.Location = new System.Drawing.Point(1, 241);
            this.logFilter07.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter07.Name = "logFilter07";
            this.logFilter07.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter07.RowCount = 2;
            this.logFilter07.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter07.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter07.Size = new System.Drawing.Size(799, 38);
            this.logFilter07.TabIndex = 6;
            // 
            // logFilter07Heading
            // 
            this.logFilter07Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter07Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter07Heading.Name = "logFilter07Heading";
            this.logFilter07Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter07Heading.TabIndex = 0;
            this.logFilter07Heading.Text = "Filter 7";
            // 
            // logFilter07MinimumLabel
            // 
            this.logFilter07MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter07MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter07MinimumLabel.Name = "logFilter07MinimumLabel";
            this.logFilter07MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter07MinimumLabel.TabIndex = 1;
            this.logFilter07MinimumLabel.Text = "Minimum";
            // 
            // logFilter07MaximumLabel
            // 
            this.logFilter07MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter07MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter07MaximumLabel.Name = "logFilter07MaximumLabel";
            this.logFilter07MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter07MaximumLabel.TabIndex = 2;
            this.logFilter07MaximumLabel.Text = "Maximum";
            // 
            // logFilter07Enabled
            // 
            this.logFilter07Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter07Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter07Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter07Enabled.Name = "logFilter07Enabled";
            this.logFilter07Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter07Enabled.TabIndex = 3;
            this.logFilter07Enabled.Text = "Enable";
            // 
            // logFilter07Field
            // 
            this.logFilter07Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter07Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter07Field.ForeColor = System.Drawing.Color.White;
            this.logFilter07Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter07Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter07Field.Name = "logFilter07Field";
            this.logFilter07Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter07Field.TabIndex = 4;
            // 
            // logFilter07Mode
            // 
            this.logFilter07Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter07Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter07Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter07Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter07Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter07Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter07Mode.Name = "logFilter07Mode";
            this.logFilter07Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter07Mode.TabIndex = 5;
            // 
            // logFilter07Absolute
            // 
            this.logFilter07Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter07Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter07Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter07Absolute.Name = "logFilter07Absolute";
            this.logFilter07Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter07Absolute.TabIndex = 6;
            this.logFilter07Absolute.Text = "Absolute";
            // 
            // logFilter07Minimum
            // 
            this.logFilter07Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter07Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter07Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter07Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter07Minimum.Name = "logFilter07Minimum";
            this.logFilter07Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter07Minimum.TabIndex = 7;
            // 
            // logFilter07Maximum
            // 
            this.logFilter07Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter07Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter07Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter07Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter07Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter07Maximum.Name = "logFilter07Maximum";
            this.logFilter07Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter07Maximum.TabIndex = 8;
            // 
            // logFilter08
            // 
            this.logFilter08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter08.ColumnCount = 6;
            this.logFilter08.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter08.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter08.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter08.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter08.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter08.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter08.Controls.Add(this.logFilter08Heading, 0, 0);
            this.logFilter08.Controls.Add(this.logFilter08MinimumLabel, 4, 0);
            this.logFilter08.Controls.Add(this.logFilter08MaximumLabel, 5, 0);
            this.logFilter08.Controls.Add(this.logFilter08Enabled, 0, 1);
            this.logFilter08.Controls.Add(this.logFilter08Field, 1, 1);
            this.logFilter08.Controls.Add(this.logFilter08Mode, 2, 1);
            this.logFilter08.Controls.Add(this.logFilter08Absolute, 3, 1);
            this.logFilter08.Controls.Add(this.logFilter08Minimum, 4, 1);
            this.logFilter08.Controls.Add(this.logFilter08Maximum, 5, 1);
            this.logFilter08.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08.ForeColor = System.Drawing.Color.White;
            this.logFilter08.Location = new System.Drawing.Point(1, 281);
            this.logFilter08.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter08.Name = "logFilter08";
            this.logFilter08.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter08.RowCount = 2;
            this.logFilter08.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter08.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter08.Size = new System.Drawing.Size(799, 38);
            this.logFilter08.TabIndex = 7;
            // 
            // logFilter08Heading
            // 
            this.logFilter08Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter08Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter08Heading.Name = "logFilter08Heading";
            this.logFilter08Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter08Heading.TabIndex = 0;
            this.logFilter08Heading.Text = "Filter 8";
            // 
            // logFilter08MinimumLabel
            // 
            this.logFilter08MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter08MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter08MinimumLabel.Name = "logFilter08MinimumLabel";
            this.logFilter08MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter08MinimumLabel.TabIndex = 1;
            this.logFilter08MinimumLabel.Text = "Minimum";
            // 
            // logFilter08MaximumLabel
            // 
            this.logFilter08MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter08MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter08MaximumLabel.Name = "logFilter08MaximumLabel";
            this.logFilter08MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter08MaximumLabel.TabIndex = 2;
            this.logFilter08MaximumLabel.Text = "Maximum";
            // 
            // logFilter08Enabled
            // 
            this.logFilter08Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter08Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter08Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter08Enabled.Name = "logFilter08Enabled";
            this.logFilter08Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter08Enabled.TabIndex = 3;
            this.logFilter08Enabled.Text = "Enable";
            // 
            // logFilter08Field
            // 
            this.logFilter08Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter08Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter08Field.ForeColor = System.Drawing.Color.White;
            this.logFilter08Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter08Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter08Field.Name = "logFilter08Field";
            this.logFilter08Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter08Field.TabIndex = 4;
            // 
            // logFilter08Mode
            // 
            this.logFilter08Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter08Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter08Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter08Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter08Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter08Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter08Mode.Name = "logFilter08Mode";
            this.logFilter08Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter08Mode.TabIndex = 5;
            // 
            // logFilter08Absolute
            // 
            this.logFilter08Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter08Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter08Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter08Absolute.Name = "logFilter08Absolute";
            this.logFilter08Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter08Absolute.TabIndex = 6;
            this.logFilter08Absolute.Text = "Absolute";
            // 
            // logFilter08Minimum
            // 
            this.logFilter08Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter08Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter08Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter08Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter08Minimum.Name = "logFilter08Minimum";
            this.logFilter08Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter08Minimum.TabIndex = 7;
            // 
            // logFilter08Maximum
            // 
            this.logFilter08Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter08Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter08Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter08Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter08Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter08Maximum.Name = "logFilter08Maximum";
            this.logFilter08Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter08Maximum.TabIndex = 8;
            // 
            // logFilter09
            // 
            this.logFilter09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter09.ColumnCount = 6;
            this.logFilter09.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter09.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter09.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter09.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter09.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter09.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter09.Controls.Add(this.logFilter09Heading, 0, 0);
            this.logFilter09.Controls.Add(this.logFilter09MinimumLabel, 4, 0);
            this.logFilter09.Controls.Add(this.logFilter09MaximumLabel, 5, 0);
            this.logFilter09.Controls.Add(this.logFilter09Enabled, 0, 1);
            this.logFilter09.Controls.Add(this.logFilter09Field, 1, 1);
            this.logFilter09.Controls.Add(this.logFilter09Mode, 2, 1);
            this.logFilter09.Controls.Add(this.logFilter09Absolute, 3, 1);
            this.logFilter09.Controls.Add(this.logFilter09Minimum, 4, 1);
            this.logFilter09.Controls.Add(this.logFilter09Maximum, 5, 1);
            this.logFilter09.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09.ForeColor = System.Drawing.Color.White;
            this.logFilter09.Location = new System.Drawing.Point(1, 321);
            this.logFilter09.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter09.Name = "logFilter09";
            this.logFilter09.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter09.RowCount = 2;
            this.logFilter09.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter09.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter09.Size = new System.Drawing.Size(799, 38);
            this.logFilter09.TabIndex = 8;
            // 
            // logFilter09Heading
            // 
            this.logFilter09Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter09Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter09Heading.Name = "logFilter09Heading";
            this.logFilter09Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter09Heading.TabIndex = 0;
            this.logFilter09Heading.Text = "Filter 9";
            // 
            // logFilter09MinimumLabel
            // 
            this.logFilter09MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter09MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter09MinimumLabel.Name = "logFilter09MinimumLabel";
            this.logFilter09MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter09MinimumLabel.TabIndex = 1;
            this.logFilter09MinimumLabel.Text = "Minimum";
            // 
            // logFilter09MaximumLabel
            // 
            this.logFilter09MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter09MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter09MaximumLabel.Name = "logFilter09MaximumLabel";
            this.logFilter09MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter09MaximumLabel.TabIndex = 2;
            this.logFilter09MaximumLabel.Text = "Maximum";
            // 
            // logFilter09Enabled
            // 
            this.logFilter09Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter09Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter09Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter09Enabled.Name = "logFilter09Enabled";
            this.logFilter09Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter09Enabled.TabIndex = 3;
            this.logFilter09Enabled.Text = "Enable";
            // 
            // logFilter09Field
            // 
            this.logFilter09Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter09Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter09Field.ForeColor = System.Drawing.Color.White;
            this.logFilter09Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter09Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter09Field.Name = "logFilter09Field";
            this.logFilter09Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter09Field.TabIndex = 4;
            // 
            // logFilter09Mode
            // 
            this.logFilter09Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter09Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter09Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter09Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter09Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter09Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter09Mode.Name = "logFilter09Mode";
            this.logFilter09Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter09Mode.TabIndex = 5;
            // 
            // logFilter09Absolute
            // 
            this.logFilter09Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter09Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter09Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter09Absolute.Name = "logFilter09Absolute";
            this.logFilter09Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter09Absolute.TabIndex = 6;
            this.logFilter09Absolute.Text = "Absolute";
            // 
            // logFilter09Minimum
            // 
            this.logFilter09Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter09Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter09Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter09Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter09Minimum.Name = "logFilter09Minimum";
            this.logFilter09Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter09Minimum.TabIndex = 7;
            // 
            // logFilter09Maximum
            // 
            this.logFilter09Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter09Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter09Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter09Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter09Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter09Maximum.Name = "logFilter09Maximum";
            this.logFilter09Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter09Maximum.TabIndex = 8;
            // 
            // logFilter10
            // 
            this.logFilter10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.logFilter10.ColumnCount = 6;
            this.logFilter10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.logFilter10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFilter10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.logFilter10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.logFilter10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.logFilter10.Controls.Add(this.logFilter10Heading, 0, 0);
            this.logFilter10.Controls.Add(this.logFilter10MinimumLabel, 4, 0);
            this.logFilter10.Controls.Add(this.logFilter10MaximumLabel, 5, 0);
            this.logFilter10.Controls.Add(this.logFilter10Enabled, 0, 1);
            this.logFilter10.Controls.Add(this.logFilter10Field, 1, 1);
            this.logFilter10.Controls.Add(this.logFilter10Mode, 2, 1);
            this.logFilter10.Controls.Add(this.logFilter10Absolute, 3, 1);
            this.logFilter10.Controls.Add(this.logFilter10Minimum, 4, 1);
            this.logFilter10.Controls.Add(this.logFilter10Maximum, 5, 1);
            this.logFilter10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10.ForeColor = System.Drawing.Color.White;
            this.logFilter10.Location = new System.Drawing.Point(1, 361);
            this.logFilter10.Margin = new System.Windows.Forms.Padding(1);
            this.logFilter10.Name = "logFilter10";
            this.logFilter10.Padding = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.logFilter10.RowCount = 2;
            this.logFilter10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.logFilter10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.logFilter10.Size = new System.Drawing.Size(799, 38);
            this.logFilter10.TabIndex = 9;
            // 
            // logFilter10Heading
            // 
            this.logFilter10Heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Heading.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter10Heading.Location = new System.Drawing.Point(8, 1);
            this.logFilter10Heading.Name = "logFilter10Heading";
            this.logFilter10Heading.Size = new System.Drawing.Size(63, 13);
            this.logFilter10Heading.TabIndex = 0;
            this.logFilter10Heading.Text = "Filter 10";
            // 
            // logFilter10MinimumLabel
            // 
            this.logFilter10MinimumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10MinimumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter10MinimumLabel.Location = new System.Drawing.Point(609, 1);
            this.logFilter10MinimumLabel.Name = "logFilter10MinimumLabel";
            this.logFilter10MinimumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter10MinimumLabel.TabIndex = 1;
            this.logFilter10MinimumLabel.Text = "Minimum";
            // 
            // logFilter10MaximumLabel
            // 
            this.logFilter10MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10MaximumLabel.ForeColor = System.Drawing.Color.LightGray;
            this.logFilter10MaximumLabel.Location = new System.Drawing.Point(703, 1);
            this.logFilter10MaximumLabel.Name = "logFilter10MaximumLabel";
            this.logFilter10MaximumLabel.Size = new System.Drawing.Size(88, 13);
            this.logFilter10MaximumLabel.TabIndex = 2;
            this.logFilter10MaximumLabel.Text = "Maximum";
            // 
            // logFilter10Enabled
            // 
            this.logFilter10Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Enabled.ForeColor = System.Drawing.Color.White;
            this.logFilter10Enabled.Location = new System.Drawing.Point(8, 14);
            this.logFilter10Enabled.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logFilter10Enabled.Name = "logFilter10Enabled";
            this.logFilter10Enabled.Size = new System.Drawing.Size(63, 26);
            this.logFilter10Enabled.TabIndex = 3;
            this.logFilter10Enabled.Text = "Enable";
            // 
            // logFilter10Field
            // 
            this.logFilter10Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter10Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter10Field.ForeColor = System.Drawing.Color.White;
            this.logFilter10Field.Location = new System.Drawing.Point(77, 16);
            this.logFilter10Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter10Field.Name = "logFilter10Field";
            this.logFilter10Field.Size = new System.Drawing.Size(341, 21);
            this.logFilter10Field.TabIndex = 4;
            // 
            // logFilter10Mode
            // 
            this.logFilter10Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter10Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logFilter10Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logFilter10Mode.ForeColor = System.Drawing.Color.White;
            this.logFilter10Mode.Location = new System.Drawing.Point(424, 16);
            this.logFilter10Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter10Mode.Name = "logFilter10Mode";
            this.logFilter10Mode.Size = new System.Drawing.Size(106, 21);
            this.logFilter10Mode.TabIndex = 5;
            // 
            // logFilter10Absolute
            // 
            this.logFilter10Absolute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Absolute.ForeColor = System.Drawing.Color.White;
            this.logFilter10Absolute.Location = new System.Drawing.Point(535, 14);
            this.logFilter10Absolute.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.logFilter10Absolute.Name = "logFilter10Absolute";
            this.logFilter10Absolute.Size = new System.Drawing.Size(71, 26);
            this.logFilter10Absolute.TabIndex = 6;
            this.logFilter10Absolute.Text = "Absolute";
            // 
            // logFilter10Minimum
            // 
            this.logFilter10Minimum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter10Minimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Minimum.ForeColor = System.Drawing.Color.White;
            this.logFilter10Minimum.Location = new System.Drawing.Point(609, 16);
            this.logFilter10Minimum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter10Minimum.Name = "logFilter10Minimum";
            this.logFilter10Minimum.Size = new System.Drawing.Size(88, 20);
            this.logFilter10Minimum.TabIndex = 7;
            // 
            // logFilter10Maximum
            // 
            this.logFilter10Maximum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logFilter10Maximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFilter10Maximum.ForeColor = System.Drawing.Color.White;
            this.logFilter10Maximum.Location = new System.Drawing.Point(703, 16);
            this.logFilter10Maximum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logFilter10Maximum.Name = "logFilter10Maximum";
            this.logFilter10Maximum.Size = new System.Drawing.Size(88, 20);
            this.logFilter10Maximum.TabIndex = 8;
            // 
            // outputGroup
            // 
            this.outputGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.outputGroup.Controls.Add(this.outputLayout);
            this.outputGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputGroup.ForeColor = System.Drawing.Color.White;
            this.outputGroup.Location = new System.Drawing.Point(2, 562);
            this.outputGroup.Margin = new System.Windows.Forms.Padding(2);
            this.outputGroup.Name = "outputGroup";
            this.outputGroup.Size = new System.Drawing.Size(807, 186);
            this.outputGroup.TabIndex = 1;
            this.outputGroup.TabStop = false;
            this.outputGroup.Text = "Output directory and session limits (0 = unlimited)";
            // 
            // outputLayout
            // 
            this.outputLayout.ColumnCount = 4;
            this.outputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.outputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.outputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.outputLayout.Controls.Add(this.pathLabel, 0, 0);
            this.outputLayout.Controls.Add(this.LogFolderTextBox, 1, 0);
            this.outputLayout.Controls.Add(this.BrowseLogFolderButton, 3, 0);
            this.outputLayout.Controls.Add(this.delimiterLabel, 0, 1);
            this.outputLayout.Controls.Add(this.DelimiterTextBox, 1, 1);
            this.outputLayout.Controls.Add(this.timeLimitLabel, 2, 1);
            this.outputLayout.Controls.Add(this.TimeLimitSecondsNumericUpDown, 3, 1);
            this.outputLayout.Controls.Add(this.sizeLimitLabel, 0, 2);
            this.outputLayout.Controls.Add(this.TotalSizeMiBNumericUpDown, 1, 2);
            this.outputLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputLayout.Location = new System.Drawing.Point(3, 16);
            this.outputLayout.Name = "outputLayout";
            this.outputLayout.Padding = new System.Windows.Forms.Padding(8, 6, 8, 5);
            this.outputLayout.RowCount = 4;
            this.outputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.outputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.outputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.outputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputLayout.Size = new System.Drawing.Size(801, 167);
            this.outputLayout.TabIndex = 0;
            // 
            // pathLabel
            // 
            this.pathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathLabel.Location = new System.Drawing.Point(11, 6);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(110, 32);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Save folder";
            this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogFolderTextBox
            // 
            this.LogFolderTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.outputLayout.SetColumnSpan(this.LogFolderTextBox, 2);
            this.LogFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogFolderTextBox.ForeColor = System.Drawing.Color.White;
            this.LogFolderTextBox.Location = new System.Drawing.Point(127, 9);
            this.LogFolderTextBox.Name = "LogFolderTextBox";
            this.LogFolderTextBox.Size = new System.Drawing.Size(537, 20);
            this.LogFolderTextBox.TabIndex = 1;
            // 
            // BrowseLogFolderButton
            // 
            this.BrowseLogFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrowseLogFolderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseLogFolderButton.ForeColor = System.Drawing.Color.White;
            this.BrowseLogFolderButton.Location = new System.Drawing.Point(669, 6);
            this.BrowseLogFolderButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BrowseLogFolderButton.Name = "BrowseLogFolderButton";
            this.BrowseLogFolderButton.Size = new System.Drawing.Size(122, 32);
            this.BrowseLogFolderButton.TabIndex = 2;
            this.BrowseLogFolderButton.Text = "Browse...";
            this.BrowseLogFolderButton.UseVisualStyleBackColor = false;
            this.BrowseLogFolderButton.Click += new System.EventHandler(this.BrowseLogFolderButton_Click);
            // 
            // delimiterLabel
            // 
            this.delimiterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delimiterLabel.Location = new System.Drawing.Point(11, 38);
            this.delimiterLabel.Name = "delimiterLabel";
            this.delimiterLabel.Size = new System.Drawing.Size(110, 35);
            this.delimiterLabel.TabIndex = 3;
            this.delimiterLabel.Text = "Delimiter";
            this.delimiterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DelimiterTextBox
            // 
            this.DelimiterTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.DelimiterTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.DelimiterTextBox.ForeColor = System.Drawing.Color.White;
            this.DelimiterTextBox.Location = new System.Drawing.Point(127, 41);
            this.DelimiterTextBox.MaxLength = 1;
            this.DelimiterTextBox.Name = "DelimiterTextBox";
            this.DelimiterTextBox.Size = new System.Drawing.Size(62, 20);
            this.DelimiterTextBox.TabIndex = 4;
            this.DelimiterTextBox.Text = ";";
            // 
            // timeLimitLabel
            // 
            this.timeLimitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLimitLabel.Location = new System.Drawing.Point(540, 38);
            this.timeLimitLabel.Name = "timeLimitLabel";
            this.timeLimitLabel.Size = new System.Drawing.Size(124, 35);
            this.timeLimitLabel.TabIndex = 5;
            this.timeLimitLabel.Text = "Time limit (s)";
            this.timeLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeLimitSecondsNumericUpDown
            // 
            this.TimeLimitSecondsNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.TimeLimitSecondsNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLimitSecondsNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.TimeLimitSecondsNumericUpDown.Location = new System.Drawing.Point(670, 41);
            this.TimeLimitSecondsNumericUpDown.Maximum = new decimal(new int[] {
            604800,
            0,
            0,
            0});
            this.TimeLimitSecondsNumericUpDown.Name = "TimeLimitSecondsNumericUpDown";
            this.TimeLimitSecondsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.TimeLimitSecondsNumericUpDown.TabIndex = 6;
            // 
            // sizeLimitLabel
            // 
            this.sizeLimitLabel.AutoSize = true;
            this.sizeLimitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeLimitLabel.Location = new System.Drawing.Point(11, 73);
            this.sizeLimitLabel.Name = "sizeLimitLabel";
            this.sizeLimitLabel.Size = new System.Drawing.Size(110, 35);
            this.sizeLimitLabel.TabIndex = 7;
            this.sizeLimitLabel.Text = "File size limit (MiB)";
            this.sizeLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalSizeMiBNumericUpDown
            // 
            this.TotalSizeMiBNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.TotalSizeMiBNumericUpDown.DecimalPlaces = 2;
            this.TotalSizeMiBNumericUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.TotalSizeMiBNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.TotalSizeMiBNumericUpDown.Location = new System.Drawing.Point(127, 76);
            this.TotalSizeMiBNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TotalSizeMiBNumericUpDown.Name = "TotalSizeMiBNumericUpDown";
            this.TotalSizeMiBNumericUpDown.Size = new System.Drawing.Size(115, 20);
            this.TotalSizeMiBNumericUpDown.TabIndex = 8;
            // 
            // FormLogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1270, 820);
            this.Controls.Add(this.rootLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(970, 600);
            this.Name = "FormLogSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logging Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_Closed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.rootLayout.ResumeLayout(false);
            this.toolbarLayout.ResumeLayout(false);
            this.contentLayout.ResumeLayout(false);
            this.selectedFieldsGroup.ResumeLayout(false);
            this.selectionsLayout.ResumeLayout(false);
            this.selectionsLayout.PerformLayout();
            this.filterAndOutputLayout.ResumeLayout(false);
            this.filtersGroup.ResumeLayout(false);
            this.filtersScrollPanel.ResumeLayout(false);
            this.filtersScrollPanel.PerformLayout();
            this.filterRowsLayout.ResumeLayout(false);
            this.logFilter01.ResumeLayout(false);
            this.logFilter01.PerformLayout();
            this.logFilter02.ResumeLayout(false);
            this.logFilter02.PerformLayout();
            this.logFilter03.ResumeLayout(false);
            this.logFilter03.PerformLayout();
            this.logFilter04.ResumeLayout(false);
            this.logFilter04.PerformLayout();
            this.logFilter05.ResumeLayout(false);
            this.logFilter05.PerformLayout();
            this.logFilter06.ResumeLayout(false);
            this.logFilter06.PerformLayout();
            this.logFilter07.ResumeLayout(false);
            this.logFilter07.PerformLayout();
            this.logFilter08.ResumeLayout(false);
            this.logFilter08.PerformLayout();
            this.logFilter09.ResumeLayout(false);
            this.logFilter09.PerformLayout();
            this.logFilter10.ResumeLayout(false);
            this.logFilter10.PerformLayout();
            this.outputGroup.ResumeLayout(false);
            this.outputLayout.ResumeLayout(false);
            this.outputLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitSecondsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSizeMiBNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.CheckBox logFilter09Enabled;
        private System.Windows.Forms.ComboBox logFilter09Field;
        private System.Windows.Forms.ComboBox logFilter09Mode;
        private System.Windows.Forms.CheckBox logFilter09Absolute;
        private System.Windows.Forms.TextBox logFilter09Minimum;
        private System.Windows.Forms.TextBox logFilter09Maximum;
        private System.Windows.Forms.CheckBox logFilter01Enabled;
        private System.Windows.Forms.ComboBox logFilter01Field;
        private System.Windows.Forms.ComboBox logFilter01Mode;
        private System.Windows.Forms.CheckBox logFilter01Absolute;
        private System.Windows.Forms.TextBox logFilter01Minimum;
        private System.Windows.Forms.TextBox logFilter01Maximum;
    }
}
