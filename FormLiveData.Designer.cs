namespace Physics_Data_Debug
{
    partial class FormLiveData
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Front Lift");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Rear Lift");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Aerodynamics", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Engine");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tire");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Suspension 1");
            this.liveDataMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.navigationPagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OpenTemperaturesChart = new System.Windows.Forms.Button();
            this.to4WheelsButton = new System.Windows.Forms.Button();
            this.toGForceButton = new System.Windows.Forms.Button();
            this.toTireStaticValues = new System.Windows.Forms.Button();
            this.toSuspensionStaticValues = new System.Windows.Forms.Button();
            this.toSuspensionGeometry = new System.Windows.Forms.Button();
            this.openOfflineChartButton = new System.Windows.Forms.Button();
            this.toggleDebugWorkspaceButton = new System.Windows.Forms.Button();
            this.telemetrySidebarSplitter = new System.Windows.Forms.SplitContainer();
            this.telemetrySidebarPanel = new System.Windows.Forms.Panel();
            this.sidebarSectionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gameVersionSection = new System.Windows.Forms.GroupBox();
            this.gameVersionFieldsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.GameVersionComboBox = new System.Windows.Forms.ComboBox();
            this.GameConfigurationProfilesButton = new System.Windows.Forms.Button();
            this.SettingsProfilesButton = new System.Windows.Forms.Button();
            this.versionDetectionStatus = new System.Windows.Forms.Label();
            this.sessionLoggingSection = new System.Windows.Forms.GroupBox();
            this.sessionFieldsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.getProcessButton = new System.Windows.Forms.Button();
            this.startFileLoggingButton = new System.Windows.Forms.Button();
            this.toLogSettingsButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.logInterval_textBox = new System.Windows.Forms.TextBox();
            this.TickTime = new System.Windows.Forms.Label();
            this.debugWorkspaceSplitter = new System.Windows.Forms.SplitContainer();
            this.monitorRoot = new System.Windows.Forms.TableLayoutPanel();
            this.monitorTitleLabel = new System.Windows.Forms.Label();
            this.monitorFieldsGroup = new System.Windows.Forms.GroupBox();
            this.monitorFieldTree = new System.Windows.Forms.TreeView();
            this.monitorRowsHost = new System.Windows.Forms.Panel();
            this.monitorFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.monitorPreviewGroup = new System.Windows.Forms.GroupBox();
            this.monitorPreviewRow = new System.Windows.Forms.Label();
            this.monitorEmptyHint = new System.Windows.Forms.Label();
            this.debugWorkspacePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.debug1Section = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.debug2Section = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.debug3Section = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.debug4Section = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.debug5Section = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.debug6Section = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonUpdates = new System.Windows.Forms.Timer(this.components);
            this.liveDataMainLayout.SuspendLayout();
            this.navigationPagesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telemetrySidebarSplitter)).BeginInit();
            this.telemetrySidebarSplitter.Panel1.SuspendLayout();
            this.telemetrySidebarSplitter.Panel2.SuspendLayout();
            this.telemetrySidebarSplitter.SuspendLayout();
            this.telemetrySidebarPanel.SuspendLayout();
            this.sidebarSectionsLayout.SuspendLayout();
            this.gameVersionSection.SuspendLayout();
            this.gameVersionFieldsLayout.SuspendLayout();
            this.sessionLoggingSection.SuspendLayout();
            this.sessionFieldsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debugWorkspaceSplitter)).BeginInit();
            this.debugWorkspaceSplitter.Panel1.SuspendLayout();
            this.debugWorkspaceSplitter.Panel2.SuspendLayout();
            this.debugWorkspaceSplitter.SuspendLayout();
            this.monitorRoot.SuspendLayout();
            this.monitorFieldsGroup.SuspendLayout();
            this.monitorRowsHost.SuspendLayout();
            this.monitorFlow.SuspendLayout();
            this.monitorPreviewGroup.SuspendLayout();
            this.debugWorkspacePanel.SuspendLayout();
            this.debug1Section.SuspendLayout();
            this.debug2Section.SuspendLayout();
            this.debug3Section.SuspendLayout();
            this.debug4Section.SuspendLayout();
            this.debug5Section.SuspendLayout();
            this.debug6Section.SuspendLayout();
            this.SuspendLayout();
            // 
            // liveDataMainLayout
            // 
            this.liveDataMainLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.liveDataMainLayout.ColumnCount = 1;
            this.liveDataMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.liveDataMainLayout.Controls.Add(this.navigationPagesPanel, 0, 0);
            this.liveDataMainLayout.Controls.Add(this.telemetrySidebarSplitter, 0, 1);
            this.liveDataMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveDataMainLayout.Location = new System.Drawing.Point(0, 0);
            this.liveDataMainLayout.Name = "liveDataMainLayout";
            this.liveDataMainLayout.RowCount = 2;
            this.liveDataMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.liveDataMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.liveDataMainLayout.Size = new System.Drawing.Size(1300, 800);
            this.liveDataMainLayout.TabIndex = 0;
            // 
            // navigationPagesPanel
            // 
            this.navigationPagesPanel.AutoScroll = true;
            this.navigationPagesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.navigationPagesPanel.Controls.Add(this.OpenTemperaturesChart);
            this.navigationPagesPanel.Controls.Add(this.to4WheelsButton);
            this.navigationPagesPanel.Controls.Add(this.toGForceButton);
            this.navigationPagesPanel.Controls.Add(this.toTireStaticValues);
            this.navigationPagesPanel.Controls.Add(this.toSuspensionStaticValues);
            this.navigationPagesPanel.Controls.Add(this.toSuspensionGeometry);
            this.navigationPagesPanel.Controls.Add(this.openOfflineChartButton);
            this.navigationPagesPanel.Controls.Add(this.toggleDebugWorkspaceButton);
            this.navigationPagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPagesPanel.Location = new System.Drawing.Point(3, 3);
            this.navigationPagesPanel.Name = "navigationPagesPanel";
            this.navigationPagesPanel.Padding = new System.Windows.Forms.Padding(6);
            this.navigationPagesPanel.Size = new System.Drawing.Size(1294, 50);
            this.navigationPagesPanel.TabIndex = 0;
            this.navigationPagesPanel.WrapContents = false;
            // 
            // OpenTemperaturesChart
            // 
            this.OpenTemperaturesChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.OpenTemperaturesChart.ForeColor = System.Drawing.Color.White;
            this.OpenTemperaturesChart.Location = new System.Drawing.Point(9, 9);
            this.OpenTemperaturesChart.Name = "OpenTemperaturesChart";
            this.OpenTemperaturesChart.Size = new System.Drawing.Size(138, 36);
            this.OpenTemperaturesChart.TabIndex = 0;
            this.OpenTemperaturesChart.Text = "Live Time Chart";
            this.OpenTemperaturesChart.UseVisualStyleBackColor = false;
            this.OpenTemperaturesChart.Click += new System.EventHandler(this.OpenTemperaturesChart_Click);
            // 
            // to4WheelsButton
            // 
            this.to4WheelsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.to4WheelsButton.ForeColor = System.Drawing.Color.White;
            this.to4WheelsButton.Location = new System.Drawing.Point(153, 9);
            this.to4WheelsButton.Name = "to4WheelsButton";
            this.to4WheelsButton.Size = new System.Drawing.Size(105, 36);
            this.to4WheelsButton.TabIndex = 1;
            this.to4WheelsButton.Text = "Four Wheels";
            this.to4WheelsButton.UseVisualStyleBackColor = false;
            this.to4WheelsButton.Click += new System.EventHandler(this.to4WheelsButton_Click);
            // 
            // toGForceButton
            // 
            this.toGForceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.toGForceButton.ForeColor = System.Drawing.Color.White;
            this.toGForceButton.Location = new System.Drawing.Point(264, 9);
            this.toGForceButton.Name = "toGForceButton";
            this.toGForceButton.Size = new System.Drawing.Size(90, 36);
            this.toGForceButton.TabIndex = 2;
            this.toGForceButton.Text = "G-Force";
            this.toGForceButton.UseVisualStyleBackColor = false;
            this.toGForceButton.Click += new System.EventHandler(this.toGForceButton_Click);
            // 
            // toTireStaticValues
            // 
            this.toTireStaticValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.toTireStaticValues.ForeColor = System.Drawing.Color.White;
            this.toTireStaticValues.Location = new System.Drawing.Point(360, 9);
            this.toTireStaticValues.Name = "toTireStaticValues";
            this.toTireStaticValues.Size = new System.Drawing.Size(145, 36);
            this.toTireStaticValues.TabIndex = 3;
            this.toTireStaticValues.Text = "Tire Static Values";
            this.toTireStaticValues.UseVisualStyleBackColor = false;
            this.toTireStaticValues.Click += new System.EventHandler(this.toTireStaticValues_Click);
            // 
            // toSuspensionStaticValues
            // 
            this.toSuspensionStaticValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.toSuspensionStaticValues.ForeColor = System.Drawing.Color.White;
            this.toSuspensionStaticValues.Location = new System.Drawing.Point(511, 9);
            this.toSuspensionStaticValues.Name = "toSuspensionStaticValues";
            this.toSuspensionStaticValues.Size = new System.Drawing.Size(188, 36);
            this.toSuspensionStaticValues.TabIndex = 4;
            this.toSuspensionStaticValues.Text = "Suspension Static Values";
            this.toSuspensionStaticValues.UseVisualStyleBackColor = false;
            this.toSuspensionStaticValues.Click += new System.EventHandler(this.toSuspensionStaticValuesButton_Click);
            // 
            // toSuspensionGeometry
            // 
            this.toSuspensionGeometry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.toSuspensionGeometry.ForeColor = System.Drawing.Color.White;
            this.toSuspensionGeometry.Location = new System.Drawing.Point(705, 9);
            this.toSuspensionGeometry.Name = "toSuspensionGeometry";
            this.toSuspensionGeometry.Size = new System.Drawing.Size(170, 36);
            this.toSuspensionGeometry.TabIndex = 5;
            this.toSuspensionGeometry.Text = "Suspension Geometry";
            this.toSuspensionGeometry.UseVisualStyleBackColor = false;
            this.toSuspensionGeometry.Click += new System.EventHandler(this.toSuspensionGeometryOpen_Click);
            // 
            // openOfflineChartButton
            // 
            this.openOfflineChartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.openOfflineChartButton.ForeColor = System.Drawing.Color.White;
            this.openOfflineChartButton.Location = new System.Drawing.Point(881, 9);
            this.openOfflineChartButton.Name = "openOfflineChartButton";
            this.openOfflineChartButton.Size = new System.Drawing.Size(115, 36);
            this.openOfflineChartButton.TabIndex = 6;
            this.openOfflineChartButton.Text = "Offline Chart";
            this.openOfflineChartButton.UseVisualStyleBackColor = false;
            // 
            // toggleDebugWorkspaceButton
            // 
            this.toggleDebugWorkspaceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.toggleDebugWorkspaceButton.ForeColor = System.Drawing.Color.White;
            this.toggleDebugWorkspaceButton.Location = new System.Drawing.Point(1002, 9);
            this.toggleDebugWorkspaceButton.Name = "toggleDebugWorkspaceButton";
            this.toggleDebugWorkspaceButton.Size = new System.Drawing.Size(160, 36);
            this.toggleDebugWorkspaceButton.TabIndex = 7;
            this.toggleDebugWorkspaceButton.Text = "Show debug output";
            this.toggleDebugWorkspaceButton.UseVisualStyleBackColor = false;
            // 
            // telemetrySidebarSplitter
            // 
            this.telemetrySidebarSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telemetrySidebarSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.telemetrySidebarSplitter.Location = new System.Drawing.Point(3, 59);
            this.telemetrySidebarSplitter.Name = "telemetrySidebarSplitter";
            // 
            // telemetrySidebarSplitter.Panel1
            // 
            this.telemetrySidebarSplitter.Panel1.Controls.Add(this.telemetrySidebarPanel);
            this.telemetrySidebarSplitter.Panel1MinSize = 220;
            // 
            // telemetrySidebarSplitter.Panel2
            // 
            this.telemetrySidebarSplitter.Panel2.Controls.Add(this.debugWorkspaceSplitter);
            this.telemetrySidebarSplitter.Size = new System.Drawing.Size(1294, 738);
            this.telemetrySidebarSplitter.SplitterDistance = 250;
            this.telemetrySidebarSplitter.TabIndex = 1;
            // 
            // telemetrySidebarPanel
            // 
            this.telemetrySidebarPanel.AutoScroll = true;
            this.telemetrySidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.telemetrySidebarPanel.Controls.Add(this.sidebarSectionsLayout);
            this.telemetrySidebarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telemetrySidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.telemetrySidebarPanel.Name = "telemetrySidebarPanel";
            this.telemetrySidebarPanel.Size = new System.Drawing.Size(250, 738);
            this.telemetrySidebarPanel.TabIndex = 0;
            // 
            // sidebarSectionsLayout
            // 
            this.sidebarSectionsLayout.AutoSize = true;
            this.sidebarSectionsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sidebarSectionsLayout.ColumnCount = 1;
            this.sidebarSectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sidebarSectionsLayout.Controls.Add(this.gameVersionSection, 0, 0);
            this.sidebarSectionsLayout.Controls.Add(this.sessionLoggingSection, 0, 1);
            this.sidebarSectionsLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidebarSectionsLayout.Location = new System.Drawing.Point(0, 0);
            this.sidebarSectionsLayout.Name = "sidebarSectionsLayout";
            this.sidebarSectionsLayout.RowCount = 2;
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.sidebarSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.sidebarSectionsLayout.Size = new System.Drawing.Size(250, 390);
            this.sidebarSectionsLayout.TabIndex = 0;
            // 
            // gameVersionSection
            // 
            this.gameVersionSection.Controls.Add(this.gameVersionFieldsLayout);
            this.gameVersionSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameVersionSection.ForeColor = System.Drawing.Color.White;
            this.gameVersionSection.Location = new System.Drawing.Point(3, 3);
            this.gameVersionSection.Name = "gameVersionSection";
            this.gameVersionSection.Padding = new System.Windows.Forms.Padding(8);
            this.gameVersionSection.Size = new System.Drawing.Size(244, 174);
            this.gameVersionSection.TabIndex = 0;
            this.gameVersionSection.TabStop = false;
            this.gameVersionSection.Text = "Game version and configuration";
            // 
            // gameVersionFieldsLayout
            // 
            this.gameVersionFieldsLayout.ColumnCount = 1;
            this.gameVersionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameVersionFieldsLayout.Controls.Add(this.GameVersionComboBox, 0, 0);
            this.gameVersionFieldsLayout.Controls.Add(this.GameConfigurationProfilesButton, 0, 1);
            this.gameVersionFieldsLayout.Controls.Add(this.SettingsProfilesButton, 0, 2);
            this.gameVersionFieldsLayout.Controls.Add(this.versionDetectionStatus, 0, 3);
            this.gameVersionFieldsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameVersionFieldsLayout.Location = new System.Drawing.Point(8, 21);
            this.gameVersionFieldsLayout.Name = "gameVersionFieldsLayout";
            this.gameVersionFieldsLayout.RowCount = 4;
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.gameVersionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.gameVersionFieldsLayout.Size = new System.Drawing.Size(228, 145);
            this.gameVersionFieldsLayout.TabIndex = 0;
            // 
            // GameVersionComboBox
            // 
            this.GameVersionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameVersionComboBox.Location = new System.Drawing.Point(3, 3);
            this.GameVersionComboBox.Name = "GameVersionComboBox";
            this.GameVersionComboBox.Size = new System.Drawing.Size(222, 21);
            this.GameVersionComboBox.TabIndex = 0;
            this.GameVersionComboBox.SelectionChangeCommitted += new System.EventHandler(this.GameVersionComboBox_SelectionChangeCommitted);
            // 
            // GameConfigurationProfilesButton
            // 
            this.GameConfigurationProfilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.GameConfigurationProfilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameConfigurationProfilesButton.ForeColor = System.Drawing.Color.White;
            this.GameConfigurationProfilesButton.Location = new System.Drawing.Point(3, 37);
            this.GameConfigurationProfilesButton.Name = "GameConfigurationProfilesButton";
            this.GameConfigurationProfilesButton.Size = new System.Drawing.Size(222, 30);
            this.GameConfigurationProfilesButton.TabIndex = 1;
            this.GameConfigurationProfilesButton.Text = "Config ▼";
            this.GameConfigurationProfilesButton.UseVisualStyleBackColor = false;
            // 
            // SettingsProfilesButton
            // 
            this.SettingsProfilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SettingsProfilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesButton.ForeColor = System.Drawing.Color.White;
            this.SettingsProfilesButton.Location = new System.Drawing.Point(3, 73);
            this.SettingsProfilesButton.Name = "SettingsProfilesButton";
            this.SettingsProfilesButton.Size = new System.Drawing.Size(222, 32);
            this.SettingsProfilesButton.TabIndex = 2;
            this.SettingsProfilesButton.TabStop = false;
            this.SettingsProfilesButton.Text = "Profiles ▼";
            this.SettingsProfilesButton.UseVisualStyleBackColor = false;
            // 
            // versionDetectionStatus
            // 
            this.versionDetectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionDetectionStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.versionDetectionStatus.Location = new System.Drawing.Point(3, 108);
            this.versionDetectionStatus.Name = "versionDetectionStatus";
            this.versionDetectionStatus.Size = new System.Drawing.Size(222, 44);
            this.versionDetectionStatus.TabIndex = 3;
            this.versionDetectionStatus.Text = "Auto: detects on Get Process";
            // 
            // sessionLoggingSection
            // 
            this.sessionLoggingSection.Controls.Add(this.sessionFieldsLayout);
            this.sessionLoggingSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionLoggingSection.ForeColor = System.Drawing.Color.White;
            this.sessionLoggingSection.Location = new System.Drawing.Point(3, 183);
            this.sessionLoggingSection.Name = "sessionLoggingSection";
            this.sessionLoggingSection.Padding = new System.Windows.Forms.Padding(8);
            this.sessionLoggingSection.Size = new System.Drawing.Size(244, 204);
            this.sessionLoggingSection.TabIndex = 1;
            this.sessionLoggingSection.TabStop = false;
            this.sessionLoggingSection.Text = "Session and logging";
            // 
            // sessionFieldsLayout
            // 
            this.sessionFieldsLayout.ColumnCount = 2;
            this.sessionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.sessionFieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.sessionFieldsLayout.Controls.Add(this.getProcessButton, 0, 0);
            this.sessionFieldsLayout.Controls.Add(this.startFileLoggingButton, 0, 1);
            this.sessionFieldsLayout.Controls.Add(this.toLogSettingsButton, 0, 2);
            this.sessionFieldsLayout.Controls.Add(this.label15, 0, 3);
            this.sessionFieldsLayout.Controls.Add(this.logInterval_textBox, 1, 3);
            this.sessionFieldsLayout.Controls.Add(this.TickTime, 0, 4);
            this.sessionFieldsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionFieldsLayout.Location = new System.Drawing.Point(8, 21);
            this.sessionFieldsLayout.Name = "sessionFieldsLayout";
            this.sessionFieldsLayout.RowCount = 5;
            this.sessionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.sessionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.sessionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.sessionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.sessionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.sessionFieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sessionFieldsLayout.Size = new System.Drawing.Size(228, 175);
            this.sessionFieldsLayout.TabIndex = 0;
            // 
            // getProcessButton
            // 
            this.getProcessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sessionFieldsLayout.SetColumnSpan(this.getProcessButton, 2);
            this.getProcessButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getProcessButton.ForeColor = System.Drawing.Color.White;
            this.getProcessButton.Location = new System.Drawing.Point(3, 3);
            this.getProcessButton.Name = "getProcessButton";
            this.getProcessButton.Size = new System.Drawing.Size(222, 31);
            this.getProcessButton.TabIndex = 0;
            this.getProcessButton.Text = "Get Process";
            this.getProcessButton.UseVisualStyleBackColor = false;
            this.getProcessButton.Click += new System.EventHandler(this.getProcessButton_Click);
            // 
            // startFileLoggingButton
            // 
            this.startFileLoggingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sessionFieldsLayout.SetColumnSpan(this.startFileLoggingButton, 2);
            this.startFileLoggingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startFileLoggingButton.ForeColor = System.Drawing.Color.White;
            this.startFileLoggingButton.Location = new System.Drawing.Point(3, 40);
            this.startFileLoggingButton.Name = "startFileLoggingButton";
            this.startFileLoggingButton.Size = new System.Drawing.Size(222, 31);
            this.startFileLoggingButton.TabIndex = 1;
            this.startFileLoggingButton.Text = "Start Logging";
            this.startFileLoggingButton.UseVisualStyleBackColor = false;
            this.startFileLoggingButton.Click += new System.EventHandler(this.Start_Log_Click);
            // 
            // toLogSettingsButton
            // 
            this.toLogSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sessionFieldsLayout.SetColumnSpan(this.toLogSettingsButton, 2);
            this.toLogSettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toLogSettingsButton.ForeColor = System.Drawing.Color.White;
            this.toLogSettingsButton.Location = new System.Drawing.Point(3, 77);
            this.toLogSettingsButton.Name = "toLogSettingsButton";
            this.toLogSettingsButton.Size = new System.Drawing.Size(222, 31);
            this.toLogSettingsButton.TabIndex = 2;
            this.toLogSettingsButton.Text = "Log Settings";
            this.toLogSettingsButton.UseVisualStyleBackColor = false;
            this.toLogSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 32);
            this.label15.TabIndex = 4;
            this.label15.Text = "Tick (ms)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logInterval_textBox
            // 
            this.logInterval_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.logInterval_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logInterval_textBox.ForeColor = System.Drawing.Color.White;
            this.logInterval_textBox.Location = new System.Drawing.Point(128, 114);
            this.logInterval_textBox.Name = "logInterval_textBox";
            this.logInterval_textBox.Size = new System.Drawing.Size(97, 20);
            this.logInterval_textBox.TabIndex = 5;
            this.logInterval_textBox.Text = "50";
            this.logInterval_textBox.TextChanged += new System.EventHandler(this.logInterval_textBox_TextChanged);
            this.logInterval_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logInterval_textBox_Keypress);
            // 
            // TickTime
            // 
            this.sessionFieldsLayout.SetColumnSpan(this.TickTime, 2);
            this.TickTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TickTime.ForeColor = System.Drawing.Color.Silver;
            this.TickTime.Location = new System.Drawing.Point(3, 143);
            this.TickTime.Name = "TickTime";
            this.TickTime.Size = new System.Drawing.Size(222, 43);
            this.TickTime.TabIndex = 6;
            this.TickTime.Text = "Tick time —";
            // 
            // debugWorkspaceSplitter
            // 
            this.debugWorkspaceSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugWorkspaceSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.debugWorkspaceSplitter.Location = new System.Drawing.Point(0, 0);
            this.debugWorkspaceSplitter.Name = "debugWorkspaceSplitter";
            // 
            // debugWorkspaceSplitter.Panel1
            // 
            this.debugWorkspaceSplitter.Panel1.Controls.Add(this.monitorRoot);
            this.debugWorkspaceSplitter.Panel1MinSize = 300;
            // 
            // debugWorkspaceSplitter.Panel2
            // 
            this.debugWorkspaceSplitter.Panel2.Controls.Add(this.debugWorkspacePanel);
            this.debugWorkspaceSplitter.Panel2MinSize = 220;
            this.debugWorkspaceSplitter.Size = new System.Drawing.Size(1040, 738);
            this.debugWorkspaceSplitter.SplitterDistance = 740;
            this.debugWorkspaceSplitter.TabIndex = 0;
            // 
            // monitorRoot
            // 
            this.monitorRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.monitorRoot.ColumnCount = 2;
            this.monitorRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.monitorRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73F));
            this.monitorRoot.Controls.Add(this.monitorTitleLabel, 0, 0);
            this.monitorRoot.Controls.Add(this.monitorFieldsGroup, 0, 1);
            this.monitorRoot.Controls.Add(this.monitorRowsHost, 1, 1);
            this.monitorRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorRoot.Location = new System.Drawing.Point(0, 0);
            this.monitorRoot.Name = "monitorRoot";
            this.monitorRoot.Padding = new System.Windows.Forms.Padding(6);
            this.monitorRoot.RowCount = 2;
            this.monitorRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.monitorRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.monitorRoot.Size = new System.Drawing.Size(740, 738);
            this.monitorRoot.TabIndex = 0;
            // 
            // monitorTitleLabel
            // 
            this.monitorTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.monitorRoot.SetColumnSpan(this.monitorTitleLabel, 2);
            this.monitorTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorTitleLabel.ForeColor = System.Drawing.Color.White;
            this.monitorTitleLabel.Location = new System.Drawing.Point(9, 6);
            this.monitorTitleLabel.Name = "monitorTitleLabel";
            this.monitorTitleLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.monitorTitleLabel.Size = new System.Drawing.Size(722, 42);
            this.monitorTitleLabel.TabIndex = 0;
            this.monitorTitleLabel.Text = "Live telemetry monitor  •  Choose measurements on the left";
            this.monitorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monitorFieldsGroup
            // 
            this.monitorFieldsGroup.Controls.Add(this.monitorFieldTree);
            this.monitorFieldsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorFieldsGroup.ForeColor = System.Drawing.Color.White;
            this.monitorFieldsGroup.Location = new System.Drawing.Point(9, 51);
            this.monitorFieldsGroup.Name = "monitorFieldsGroup";
            this.monitorFieldsGroup.Size = new System.Drawing.Size(190, 678);
            this.monitorFieldsGroup.TabIndex = 1;
            this.monitorFieldsGroup.TabStop = false;
            this.monitorFieldsGroup.Text = "Select categories and measurements";
            // 
            // monitorFieldTree
            // 
            this.monitorFieldTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.monitorFieldTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.monitorFieldTree.CheckBoxes = true;
            this.monitorFieldTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorFieldTree.ForeColor = System.Drawing.Color.White;
            this.monitorFieldTree.Location = new System.Drawing.Point(3, 16);
            this.monitorFieldTree.Name = "monitorFieldTree";
            treeNode1.Name = "";
            treeNode1.Text = "Front Lift";
            treeNode2.Name = "";
            treeNode2.Text = "Rear Lift";
            treeNode3.Name = "";
            treeNode3.Text = "Aerodynamics";
            treeNode4.Name = "";
            treeNode4.Text = "Engine";
            treeNode5.Name = "";
            treeNode5.Text = "Tire";
            treeNode6.Name = "";
            treeNode6.Text = "Suspension 1";
            this.monitorFieldTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.monitorFieldTree.Size = new System.Drawing.Size(184, 659);
            this.monitorFieldTree.TabIndex = 0;
            // 
            // monitorRowsHost
            // 
            this.monitorRowsHost.BackColor = System.Drawing.Color.Black;
            this.monitorRowsHost.Controls.Add(this.monitorFlow);
            this.monitorRowsHost.Controls.Add(this.monitorEmptyHint);
            this.monitorRowsHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorRowsHost.Location = new System.Drawing.Point(205, 51);
            this.monitorRowsHost.Name = "monitorRowsHost";
            this.monitorRowsHost.Size = new System.Drawing.Size(526, 678);
            this.monitorRowsHost.TabIndex = 2;
            // 
            // monitorFlow
            // 
            this.monitorFlow.AutoScroll = true;
            this.monitorFlow.BackColor = System.Drawing.Color.Black;
            this.monitorFlow.Controls.Add(this.monitorPreviewGroup);
            this.monitorFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.monitorFlow.Location = new System.Drawing.Point(0, 32);
            this.monitorFlow.Name = "monitorFlow";
            this.monitorFlow.Padding = new System.Windows.Forms.Padding(6);
            this.monitorFlow.Size = new System.Drawing.Size(526, 646);
            this.monitorFlow.TabIndex = 0;
            this.monitorFlow.WrapContents = false;
            // 
            // monitorPreviewGroup
            // 
            this.monitorPreviewGroup.Controls.Add(this.monitorPreviewRow);
            this.monitorPreviewGroup.ForeColor = System.Drawing.Color.White;
            this.monitorPreviewGroup.Location = new System.Drawing.Point(9, 9);
            this.monitorPreviewGroup.Name = "monitorPreviewGroup";
            this.monitorPreviewGroup.Size = new System.Drawing.Size(500, 70);
            this.monitorPreviewGroup.TabIndex = 0;
            this.monitorPreviewGroup.TabStop = false;
            this.monitorPreviewGroup.Text = "Selected telemetry (example)";
            // 
            // monitorPreviewRow
            // 
            this.monitorPreviewRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorPreviewRow.ForeColor = System.Drawing.Color.White;
            this.monitorPreviewRow.Location = new System.Drawing.Point(3, 16);
            this.monitorPreviewRow.Name = "monitorPreviewRow";
            this.monitorPreviewRow.Size = new System.Drawing.Size(494, 51);
            this.monitorPreviewRow.TabIndex = 0;
            this.monitorPreviewRow.Text = "Front Lift                     — N";
            this.monitorPreviewRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monitorEmptyHint
            // 
            this.monitorEmptyHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.monitorEmptyHint.ForeColor = System.Drawing.Color.Silver;
            this.monitorEmptyHint.Location = new System.Drawing.Point(0, 0);
            this.monitorEmptyHint.Name = "monitorEmptyHint";
            this.monitorEmptyHint.Size = new System.Drawing.Size(526, 32);
            this.monitorEmptyHint.TabIndex = 1;
            this.monitorEmptyHint.Text = "Select fields or categories to show their values.";
            this.monitorEmptyHint.Visible = false;
            // 
            // debugWorkspacePanel
            // 
            this.debugWorkspacePanel.AutoScroll = true;
            this.debugWorkspacePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.debugWorkspacePanel.Controls.Add(this.debug1Section);
            this.debugWorkspacePanel.Controls.Add(this.debug2Section);
            this.debugWorkspacePanel.Controls.Add(this.debug3Section);
            this.debugWorkspacePanel.Controls.Add(this.debug4Section);
            this.debugWorkspacePanel.Controls.Add(this.debug5Section);
            this.debugWorkspacePanel.Controls.Add(this.debug6Section);
            this.debugWorkspacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugWorkspacePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.debugWorkspacePanel.Location = new System.Drawing.Point(0, 0);
            this.debugWorkspacePanel.Name = "debugWorkspacePanel";
            this.debugWorkspacePanel.Size = new System.Drawing.Size(296, 738);
            this.debugWorkspacePanel.TabIndex = 0;
            this.debugWorkspacePanel.WrapContents = false;
            // 
            // debug1Section
            // 
            this.debug1Section.Controls.Add(this.textBox1);
            this.debug1Section.ForeColor = System.Drawing.Color.White;
            this.debug1Section.Location = new System.Drawing.Point(3, 3);
            this.debug1Section.Name = "debug1Section";
            this.debug1Section.Size = new System.Drawing.Size(330, 150);
            this.debug1Section.TabIndex = 0;
            this.debug1Section.TabStop = false;
            this.debug1Section.Text = "WLF multiplier";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(324, 131);
            this.textBox1.TabIndex = 0;
            // 
            // debug2Section
            // 
            this.debug2Section.Controls.Add(this.textBox2);
            this.debug2Section.ForeColor = System.Drawing.Color.White;
            this.debug2Section.Location = new System.Drawing.Point(3, 159);
            this.debug2Section.Name = "debug2Section";
            this.debug2Section.Size = new System.Drawing.Size(330, 150);
            this.debug2Section.TabIndex = 1;
            this.debug2Section.TabStop = false;
            this.debug2Section.Text = "Grip estimates";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(3, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(324, 131);
            this.textBox2.TabIndex = 0;
            // 
            // debug3Section
            // 
            this.debug3Section.Controls.Add(this.textBox3);
            this.debug3Section.ForeColor = System.Drawing.Color.White;
            this.debug3Section.Location = new System.Drawing.Point(3, 315);
            this.debug3Section.Name = "debug3Section";
            this.debug3Section.Size = new System.Drawing.Size(330, 150);
            this.debug3Section.TabIndex = 2;
            this.debug3Section.TabStop = false;
            this.debug3Section.Text = "Test results";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(3, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(324, 131);
            this.textBox3.TabIndex = 0;
            // 
            // debug4Section
            // 
            this.debug4Section.Controls.Add(this.textBox4);
            this.debug4Section.ForeColor = System.Drawing.Color.White;
            this.debug4Section.Location = new System.Drawing.Point(3, 471);
            this.debug4Section.Name = "debug4Section";
            this.debug4Section.Size = new System.Drawing.Size(330, 150);
            this.debug4Section.TabIndex = 3;
            this.debug4Section.TabStop = false;
            this.debug4Section.Text = "Calculation data";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(3, 16);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(324, 131);
            this.textBox4.TabIndex = 0;
            // 
            // debug5Section
            // 
            this.debug5Section.Controls.Add(this.textBox5);
            this.debug5Section.ForeColor = System.Drawing.Color.White;
            this.debug5Section.Location = new System.Drawing.Point(3, 627);
            this.debug5Section.Name = "debug5Section";
            this.debug5Section.Size = new System.Drawing.Size(330, 150);
            this.debug5Section.TabIndex = 4;
            this.debug5Section.TabStop = false;
            this.debug5Section.Text = "Quaternions";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(3, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(324, 131);
            this.textBox5.TabIndex = 0;
            // 
            // debug6Section
            // 
            this.debug6Section.Controls.Add(this.textBox6);
            this.debug6Section.ForeColor = System.Drawing.Color.White;
            this.debug6Section.Location = new System.Drawing.Point(3, 783);
            this.debug6Section.Name = "debug6Section";
            this.debug6Section.Size = new System.Drawing.Size(330, 150);
            this.debug6Section.TabIndex = 5;
            this.debug6Section.TabStop = false;
            this.debug6Section.Text = "Scratch / test output";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(3, 16);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox6.Size = new System.Drawing.Size(324, 131);
            this.textBox6.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonUpdates
            // 
            this.buttonUpdates.Enabled = true;
            this.buttonUpdates.Interval = 500;
            this.buttonUpdates.Tick += new System.EventHandler(this.buttonUpdates_Tick);
            // 
            // FormLiveData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.liveDataMainLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(950, 540);
            this.Name = "FormLiveData";
            this.Text = "Live Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirstAllDataLoggerPage_Closing);
            this.Load += new System.EventHandler(this.FirstAllDataLoggerPage_Load);
            this.liveDataMainLayout.ResumeLayout(false);
            this.navigationPagesPanel.ResumeLayout(false);
            this.telemetrySidebarSplitter.Panel1.ResumeLayout(false);
            this.telemetrySidebarSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.telemetrySidebarSplitter)).EndInit();
            this.telemetrySidebarSplitter.ResumeLayout(false);
            this.telemetrySidebarPanel.ResumeLayout(false);
            this.telemetrySidebarPanel.PerformLayout();
            this.sidebarSectionsLayout.ResumeLayout(false);
            this.gameVersionSection.ResumeLayout(false);
            this.gameVersionFieldsLayout.ResumeLayout(false);
            this.sessionLoggingSection.ResumeLayout(false);
            this.sessionFieldsLayout.ResumeLayout(false);
            this.sessionFieldsLayout.PerformLayout();
            this.debugWorkspaceSplitter.Panel1.ResumeLayout(false);
            this.debugWorkspaceSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.debugWorkspaceSplitter)).EndInit();
            this.debugWorkspaceSplitter.ResumeLayout(false);
            this.monitorRoot.ResumeLayout(false);
            this.monitorFieldsGroup.ResumeLayout(false);
            this.monitorRowsHost.ResumeLayout(false);
            this.monitorFlow.ResumeLayout(false);
            this.monitorPreviewGroup.ResumeLayout(false);
            this.debugWorkspacePanel.ResumeLayout(false);
            this.debug1Section.ResumeLayout(false);
            this.debug1Section.PerformLayout();
            this.debug2Section.ResumeLayout(false);
            this.debug2Section.PerformLayout();
            this.debug3Section.ResumeLayout(false);
            this.debug3Section.PerformLayout();
            this.debug4Section.ResumeLayout(false);
            this.debug4Section.PerformLayout();
            this.debug5Section.ResumeLayout(false);
            this.debug5Section.PerformLayout();
            this.debug6Section.ResumeLayout(false);
            this.debug6Section.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel liveDataMainLayout;
        private System.Windows.Forms.FlowLayoutPanel navigationPagesPanel;
        private System.Windows.Forms.SplitContainer telemetrySidebarSplitter;
        private System.Windows.Forms.Panel telemetrySidebarPanel;
        private System.Windows.Forms.TableLayoutPanel sidebarSectionsLayout;
        private System.Windows.Forms.GroupBox gameVersionSection;
        private System.Windows.Forms.TableLayoutPanel gameVersionFieldsLayout;
        private System.Windows.Forms.ComboBox GameVersionComboBox;
        private System.Windows.Forms.Button GameConfigurationProfilesButton;
        private System.Windows.Forms.Button SettingsProfilesButton;
        private System.Windows.Forms.Label versionDetectionStatus;
        private System.Windows.Forms.GroupBox sessionLoggingSection;
        private System.Windows.Forms.TableLayoutPanel sessionFieldsLayout;
        private System.Windows.Forms.Button getProcessButton;
        private System.Windows.Forms.Button startFileLoggingButton;
        private System.Windows.Forms.Button toLogSettingsButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox logInterval_textBox;
        private System.Windows.Forms.Label TickTime;
        private System.Windows.Forms.SplitContainer debugWorkspaceSplitter;
        private System.Windows.Forms.FlowLayoutPanel debugWorkspacePanel;
        private System.Windows.Forms.TableLayoutPanel monitorRoot;
        private System.Windows.Forms.Label monitorTitleLabel;
        private System.Windows.Forms.GroupBox monitorFieldsGroup;
        private System.Windows.Forms.TreeView monitorFieldTree;
        private System.Windows.Forms.Panel monitorRowsHost;
        private System.Windows.Forms.FlowLayoutPanel monitorFlow;
        private System.Windows.Forms.Label monitorEmptyHint;
        private System.Windows.Forms.GroupBox monitorPreviewGroup;
        private System.Windows.Forms.Label monitorPreviewRow;
        private System.Windows.Forms.Button toggleDebugWorkspaceButton;
        private System.Windows.Forms.Button OpenTemperaturesChart;
        private System.Windows.Forms.Button to4WheelsButton;
        private System.Windows.Forms.Button toGForceButton;
        private System.Windows.Forms.Button toTireStaticValues;
        private System.Windows.Forms.Button toSuspensionStaticValues;
        private System.Windows.Forms.Button toSuspensionGeometry;
        private System.Windows.Forms.Button openOfflineChartButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox debug1Section;
        private System.Windows.Forms.GroupBox debug2Section;
        private System.Windows.Forms.GroupBox debug3Section;
        private System.Windows.Forms.GroupBox debug4Section;
        private System.Windows.Forms.GroupBox debug5Section;
        private System.Windows.Forms.GroupBox debug6Section;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer buttonUpdates;
    }
}
