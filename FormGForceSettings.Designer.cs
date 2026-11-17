
namespace Physics_Data_Debug
{
    partial class FormGForceSettings
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
            this.MarkerColorComboBox = new System.Windows.Forms.ComboBox();
            this.LoadCurrentValuesButton = new System.Windows.Forms.Button();
            this.DefaultsCheckBox = new System.Windows.Forms.CheckBox();
            this.BackgroundColorComboBox = new System.Windows.Forms.ComboBox();
            this.applyChartSettingsButton = new System.Windows.Forms.Button();
            this.applyAndClearChartsButton = new System.Windows.Forms.Button();

            this.X1MajorIntervalFractionTextBox = new System.Windows.Forms.TextBox();
            this.X1MinorLineWidthComboBox = new System.Windows.Forms.ComboBox();
            this.X1MajorColorComboBox = new System.Windows.Forms.ComboBox();
            this.X1MajorLineWidthComboBox = new System.Windows.Forms.ComboBox();
            this.X1MinorEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.X1MinorDashStyleComboBox = new System.Windows.Forms.ComboBox();
            this.X1MinorColorComboBox = new System.Windows.Forms.ComboBox();
            this.X1MinorIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.X1FontColorComboBox = new System.Windows.Forms.ComboBox();
            this.X1FontStyleComboBox = new System.Windows.Forms.ComboBox();
            this.X1FontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.X1ComboBoxFonts = new System.Windows.Forms.ComboBox();
            this.X1DefaultsCheckBox = new System.Windows.Forms.CheckBox();
            this.X1AngleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.Y1IntervalDividerTextBox = new System.Windows.Forms.TextBox();
            this.Y1MinorLineWidthComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MaxMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Y1MajorColorComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MajorLineWidthComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MinorEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.Y1MinorDashStyleComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MinorColorComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MinorIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MajorDecimalsComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MinMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Y1FontColorComboBox = new System.Windows.Forms.ComboBox();
            this.Y1FontStyleComboBox = new System.Windows.Forms.ComboBox();
            this.Y1FontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.Y1ComboBoxFonts = new System.Windows.Forms.ComboBox();
            this.Y1DefaultsCheckBox = new System.Windows.Forms.CheckBox();
            this.HistoryAmountPointsMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.InfiniteHistoryCheckBox = new System.Windows.Forms.CheckBox();
            this.SchemeComboBox = new System.Windows.Forms.ComboBox();
            this.Y1MajorIntervalDividerComboBox = new System.Windows.Forms.ComboBox();
            this.X1MajorIntervalFractionComboBox = new System.Windows.Forms.ComboBox();
            this.settingsSectionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.settingsSidebarGroup = new System.Windows.Forms.GroupBox();
            this.settingsSidebarPanel = new System.Windows.Forms.TableLayoutPanel();
            this.xAxisSettingsGroup = new System.Windows.Forms.GroupBox();
            this.xAxisSettingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.yAxisSettingsGroup = new System.Windows.Forms.GroupBox();
            this.yAxisSettingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // MarkerColorComboBox
            // 
            this.MarkerColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarkerColorComboBox.FormattingEnabled = true;
            this.MarkerColorComboBox.Location = new System.Drawing.Point(24, 448);
            this.MarkerColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MarkerColorComboBox.Name = "MarkerColorComboBox";
            this.MarkerColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.MarkerColorComboBox.TabIndex = 369;
            this.MarkerColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MarkerColorComboBox_DrawItem);
            this.MarkerColorComboBox.SelectionChangeCommitted += new System.EventHandler(this.MarkerColorComboBox_SelectionChangeCommitted);
            //
            // 
            // LoadCurrentValuesButton
            // 
            this.LoadCurrentValuesButton.Location = new System.Drawing.Point(24, 192);
            this.LoadCurrentValuesButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LoadCurrentValuesButton.Name = "LoadCurrentValuesButton";
            this.LoadCurrentValuesButton.Size = new System.Drawing.Size(178, 98);
            this.LoadCurrentValuesButton.TabIndex = 367;
            this.LoadCurrentValuesButton.Text = "Load Current Values";
            this.LoadCurrentValuesButton.UseVisualStyleBackColor = true;
            this.LoadCurrentValuesButton.Click += new System.EventHandler(this.LoadCurrentValuesButton_Click);
            // 
            // DefaultsCheckBox
            // 
            this.DefaultsCheckBox.AutoSize = true;
            this.DefaultsCheckBox.Checked = true;
            this.DefaultsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DefaultsCheckBox.Location = new System.Drawing.Point(24, 302);
            this.DefaultsCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DefaultsCheckBox.Name = "DefaultsCheckBox";
            this.DefaultsCheckBox.Size = new System.Drawing.Size(123, 29);
            this.DefaultsCheckBox.TabIndex = 366;
            this.DefaultsCheckBox.Text = "Defaults";
            this.DefaultsCheckBox.UseVisualStyleBackColor = true;
            this.DefaultsCheckBox.CheckedChanged += new System.EventHandler(this.DefaultsCheckBox_CheckedChanged);
            // 
            // BackgroundColorComboBox
            // 
            this.BackgroundColorComboBox.FormattingEnabled = true;
            this.BackgroundColorComboBox.Location = new System.Drawing.Point(24, 371);
            this.BackgroundColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BackgroundColorComboBox.Name = "BackgroundColorComboBox";
            this.BackgroundColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.BackgroundColorComboBox.TabIndex = 365;
            this.BackgroundColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.BackgroundColorComboBox_DrawItem);
            this.BackgroundColorComboBox.SelectionChangeCommitted += new System.EventHandler(this.BackgroundColorComboBox_SelectionChangeCommitted);
            //
            // 
            // applyChartSettingsButton -- apply without clearing history.
            // 
            this.applyChartSettingsButton.Name = "applyChartSettingsButton";
            this.applyChartSettingsButton.TabIndex = 362;
            this.applyChartSettingsButton.Text = "Apply Chart Settings";
            this.applyChartSettingsButton.UseVisualStyleBackColor = false;
            this.applyChartSettingsButton.Click += new System.EventHandler(this.applyChartSettingsButton_Click);
            // 
            // applyAndClearChartsButton
            // 
            this.applyAndClearChartsButton.Location = new System.Drawing.Point(24, 83);
            this.applyAndClearChartsButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.applyAndClearChartsButton.Name = "applyAndClearChartsButton";
            this.applyAndClearChartsButton.Size = new System.Drawing.Size(178, 98);
            this.applyAndClearChartsButton.TabIndex = 363;
            this.applyAndClearChartsButton.Text = "Apply and Clear Charts";
            this.applyAndClearChartsButton.UseVisualStyleBackColor = true;
            this.applyAndClearChartsButton.Click += new System.EventHandler(this.applyAndClearButton_Click);
            // 
            // X1MajorIntervalFractionTextBox
            // 
            this.X1MajorIntervalFractionTextBox.Location = new System.Drawing.Point(142, 481);
            this.X1MajorIntervalFractionTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MajorIntervalFractionTextBox.Name = "X1MajorIntervalFractionTextBox";
            this.X1MajorIntervalFractionTextBox.Size = new System.Drawing.Size(138, 31);
            this.X1MajorIntervalFractionTextBox.TabIndex = 399;
            this.X1MajorIntervalFractionTextBox.Visible = false;
            // 
            // X1MinorLineWidthComboBox
            // 
            this.X1MinorLineWidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MinorLineWidthComboBox.FormattingEnabled = true;
            this.X1MinorLineWidthComboBox.Location = new System.Drawing.Point(296, 583);
            this.X1MinorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MinorLineWidthComboBox.Name = "X1MinorLineWidthComboBox";
            this.X1MinorLineWidthComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1MinorLineWidthComboBox.TabIndex = 398;
            // 
            // X1MajorColorComboBox
            // 
            this.X1MajorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MajorColorComboBox.FormattingEnabled = true;
            this.X1MajorColorComboBox.Location = new System.Drawing.Point(296, 431);
            this.X1MajorColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MajorColorComboBox.Name = "X1MajorColorComboBox";
            this.X1MajorColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1MajorColorComboBox.TabIndex = 395;
            this.X1MajorColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.X1MajorColorComboBox_DrawItem);
            this.X1MajorColorComboBox.SelectedIndexChanged += new System.EventHandler(this.X1MajorColorComboBox_SelectedIndexChanged);
            // 
            // X1MajorLineWidthComboBox
            // 
            this.X1MajorLineWidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MajorLineWidthComboBox.FormattingEnabled = true;
            this.X1MajorLineWidthComboBox.Location = new System.Drawing.Point(26, 431);
            this.X1MajorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MajorLineWidthComboBox.Name = "X1MajorLineWidthComboBox";
            this.X1MajorLineWidthComboBox.Size = new System.Drawing.Size(100, 33);
            this.X1MajorLineWidthComboBox.TabIndex = 394;
            // 
            // X1MinorEnabledCheckBox
            // 
            this.X1MinorEnabledCheckBox.AutoSize = true;
            this.X1MinorEnabledCheckBox.Location = new System.Drawing.Point(26, 587);
            this.X1MinorEnabledCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MinorEnabledCheckBox.Name = "X1MinorEnabledCheckBox";
            this.X1MinorEnabledCheckBox.Size = new System.Drawing.Size(123, 29);
            this.X1MinorEnabledCheckBox.TabIndex = 393;
            this.X1MinorEnabledCheckBox.Text = "Enabled";
            this.X1MinorEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // X1MinorDashStyleComboBox
            // 
            this.X1MinorDashStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MinorDashStyleComboBox.FormattingEnabled = true;
            this.X1MinorDashStyleComboBox.Location = new System.Drawing.Point(296, 658);
            this.X1MinorDashStyleComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MinorDashStyleComboBox.Name = "X1MinorDashStyleComboBox";
            this.X1MinorDashStyleComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1MinorDashStyleComboBox.TabIndex = 392;
            // 
            // X1MinorColorComboBox
            // 
            this.X1MinorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MinorColorComboBox.FormattingEnabled = true;
            this.X1MinorColorComboBox.Location = new System.Drawing.Point(26, 658);
            this.X1MinorColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MinorColorComboBox.Name = "X1MinorColorComboBox";
            this.X1MinorColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1MinorColorComboBox.TabIndex = 391;
            this.X1MinorColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.X1MinorColorComboBox_DrawItem);
            this.X1MinorColorComboBox.SelectedIndexChanged += new System.EventHandler(this.X1MinorColorComboBox_SelectedIndexChanged);
            // 
            // X1MinorIntervalComboBox
            // 
            this.X1MinorIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MinorIntervalComboBox.FormattingEnabled = true;
            this.X1MinorIntervalComboBox.Location = new System.Drawing.Point(196, 583);
            this.X1MinorIntervalComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MinorIntervalComboBox.Name = "X1MinorIntervalComboBox";
            this.X1MinorIntervalComboBox.Size = new System.Drawing.Size(84, 33);
            this.X1MinorIntervalComboBox.TabIndex = 390;
            // 
            // X1FontColorComboBox
            // 
            this.X1FontColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1FontColorComboBox.FormattingEnabled = true;
            this.X1FontColorComboBox.Location = new System.Drawing.Point(296, 354);
            this.X1FontColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1FontColorComboBox.Name = "X1FontColorComboBox";
            this.X1FontColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1FontColorComboBox.TabIndex = 386;
            this.X1FontColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.X1FontColorComboBox_DrawItem);
            this.X1FontColorComboBox.SelectedIndexChanged += new System.EventHandler(this.X1FontColorComboBox_SelectedIndexChanged);
            //
            //
            //
            // 
            // X1FontStyleComboBox
            // 
            this.X1FontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1FontStyleComboBox.FormattingEnabled = true;
            this.X1FontStyleComboBox.Location = new System.Drawing.Point(296, 277);
            this.X1FontStyleComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1FontStyleComboBox.Name = "X1FontStyleComboBox";
            this.X1FontStyleComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1FontStyleComboBox.TabIndex = 382;
            this.X1FontStyleComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.X1FontStyleComboBox_DrawItem);
            this.X1FontStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.X1FontStyleComboBox_SelectedIndexChanged);
            // 
            // X1FontSizeComboBox
            // 
            this.X1FontSizeComboBox.FormattingEnabled = true;
            this.X1FontSizeComboBox.Location = new System.Drawing.Point(26, 200);
            this.X1FontSizeComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1FontSizeComboBox.Name = "X1FontSizeComboBox";
            this.X1FontSizeComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1FontSizeComboBox.TabIndex = 381;
            this.X1FontSizeComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.X1FontSizeComboBox_DrawItem);
            this.X1FontSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.X1FontSizeComboBox_SelectedIndexChanged);
            // 
            // X1ComboBoxFonts
            // 
            this.X1ComboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1ComboBoxFonts.FormattingEnabled = true;
            this.X1ComboBoxFonts.Location = new System.Drawing.Point(296, 200);
            this.X1ComboBoxFonts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1ComboBoxFonts.Name = "X1ComboBoxFonts";
            this.X1ComboBoxFonts.Size = new System.Drawing.Size(254, 33);
            this.X1ComboBoxFonts.TabIndex = 380;
            this.X1ComboBoxFonts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.X1ComboBoxFonts_DrawItem);
            this.X1ComboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.X1ComboBoxFonts_SelectedIndexChanged);
            //
            //
            //
            //
            //
            //
            // 
            // X1DefaultsCheckBox
            // 
            this.X1DefaultsCheckBox.AutoSize = true;
            this.X1DefaultsCheckBox.Checked = true;
            this.X1DefaultsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.X1DefaultsCheckBox.Location = new System.Drawing.Point(26, 48);
            this.X1DefaultsCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1DefaultsCheckBox.Name = "X1DefaultsCheckBox";
            this.X1DefaultsCheckBox.Size = new System.Drawing.Size(123, 29);
            this.X1DefaultsCheckBox.TabIndex = 370;
            this.X1DefaultsCheckBox.Text = "Defaults";
            this.X1DefaultsCheckBox.UseVisualStyleBackColor = true;
            this.X1DefaultsCheckBox.CheckedChanged += new System.EventHandler(this.X1DefaultsCheckBox_CheckedChanged);
            //
            // 
            // X1AngleTypeComboBox
            // 
            this.X1AngleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1AngleTypeComboBox.FormattingEnabled = true;
            this.X1AngleTypeComboBox.Location = new System.Drawing.Point(26, 123);
            this.X1AngleTypeComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1AngleTypeComboBox.Name = "X1AngleTypeComboBox";
            this.X1AngleTypeComboBox.Size = new System.Drawing.Size(254, 33);
            this.X1AngleTypeComboBox.TabIndex = 400;
            // 
            // Y1IntervalDividerTextBox
            // 
            this.Y1IntervalDividerTextBox.Location = new System.Drawing.Point(242, 481);
            this.Y1IntervalDividerTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1IntervalDividerTextBox.Name = "Y1IntervalDividerTextBox";
            this.Y1IntervalDividerTextBox.Size = new System.Drawing.Size(84, 31);
            this.Y1IntervalDividerTextBox.TabIndex = 430;
            this.Y1IntervalDividerTextBox.Visible = false;
            // 
            // Y1MinorLineWidthComboBox
            // 
            this.Y1MinorLineWidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MinorLineWidthComboBox.FormattingEnabled = true;
            this.Y1MinorLineWidthComboBox.Location = new System.Drawing.Point(312, 585);
            this.Y1MinorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MinorLineWidthComboBox.Name = "Y1MinorLineWidthComboBox";
            this.Y1MinorLineWidthComboBox.Size = new System.Drawing.Size(254, 33);
            this.Y1MinorLineWidthComboBox.TabIndex = 429;
            //
            // 
            // Y1MaxMaskedTextBox
            // 
            this.Y1MaxMaskedTextBox.Location = new System.Drawing.Point(312, 125);
            this.Y1MaxMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MaxMaskedTextBox.Name = "Y1MaxMaskedTextBox";
            this.Y1MaxMaskedTextBox.Size = new System.Drawing.Size(254, 31);
            this.Y1MaxMaskedTextBox.TabIndex = 427;
            // 
            // Y1MajorColorComboBox
            // 
            this.Y1MajorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MajorColorComboBox.FormattingEnabled = true;
            this.Y1MajorColorComboBox.Location = new System.Drawing.Point(342, 431);
            this.Y1MajorColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MajorColorComboBox.Name = "Y1MajorColorComboBox";
            this.Y1MajorColorComboBox.Size = new System.Drawing.Size(224, 33);
            this.Y1MajorColorComboBox.TabIndex = 426;
            this.Y1MajorColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Y1MajorColorComboBox_DrawItem);
            this.Y1MajorColorComboBox.SelectedIndexChanged += new System.EventHandler(this.Y1MajorColorComboBox_SelectedIndexChanged);
            // 
            // Y1MajorLineWidthComboBox
            // 
            this.Y1MajorLineWidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MajorLineWidthComboBox.FormattingEnabled = true;
            this.Y1MajorLineWidthComboBox.Location = new System.Drawing.Point(42, 431);
            this.Y1MajorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MajorLineWidthComboBox.Name = "Y1MajorLineWidthComboBox";
            this.Y1MajorLineWidthComboBox.Size = new System.Drawing.Size(84, 33);
            this.Y1MajorLineWidthComboBox.TabIndex = 425;
            // 
            // Y1MinorEnabledCheckBox
            // 
            this.Y1MinorEnabledCheckBox.AutoSize = true;
            this.Y1MinorEnabledCheckBox.Location = new System.Drawing.Point(42, 588);
            this.Y1MinorEnabledCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MinorEnabledCheckBox.Name = "Y1MinorEnabledCheckBox";
            this.Y1MinorEnabledCheckBox.Size = new System.Drawing.Size(123, 29);
            this.Y1MinorEnabledCheckBox.TabIndex = 424;
            this.Y1MinorEnabledCheckBox.Text = "Enabled";
            this.Y1MinorEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // Y1MinorDashStyleComboBox
            // 
            this.Y1MinorDashStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MinorDashStyleComboBox.FormattingEnabled = true;
            this.Y1MinorDashStyleComboBox.Location = new System.Drawing.Point(312, 660);
            this.Y1MinorDashStyleComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MinorDashStyleComboBox.Name = "Y1MinorDashStyleComboBox";
            this.Y1MinorDashStyleComboBox.Size = new System.Drawing.Size(254, 33);
            this.Y1MinorDashStyleComboBox.TabIndex = 423;
            // 
            // Y1MinorColorComboBox
            // 
            this.Y1MinorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MinorColorComboBox.FormattingEnabled = true;
            this.Y1MinorColorComboBox.Location = new System.Drawing.Point(42, 660);
            this.Y1MinorColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MinorColorComboBox.Name = "Y1MinorColorComboBox";
            this.Y1MinorColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.Y1MinorColorComboBox.TabIndex = 422;
            this.Y1MinorColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Y1MinorColorComboBox_DrawItem);
            this.Y1MinorColorComboBox.SelectedIndexChanged += new System.EventHandler(this.Y1MinorColorComboBox_SelectedIndexChanged);
            // 
            // Y1MinorIntervalComboBox
            // 
            this.Y1MinorIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MinorIntervalComboBox.FormattingEnabled = true;
            this.Y1MinorIntervalComboBox.Location = new System.Drawing.Point(212, 585);
            this.Y1MinorIntervalComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MinorIntervalComboBox.Name = "Y1MinorIntervalComboBox";
            this.Y1MinorIntervalComboBox.Size = new System.Drawing.Size(84, 33);
            this.Y1MinorIntervalComboBox.TabIndex = 421;
            // 
            // Y1MajorDecimalsComboBox
            // 
            this.Y1MajorDecimalsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MajorDecimalsComboBox.FormattingEnabled = true;
            this.Y1MajorDecimalsComboBox.Location = new System.Drawing.Point(142, 431);
            this.Y1MajorDecimalsComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MajorDecimalsComboBox.Name = "Y1MajorDecimalsComboBox";
            this.Y1MajorDecimalsComboBox.Size = new System.Drawing.Size(84, 33);
            this.Y1MajorDecimalsComboBox.TabIndex = 420;
            // 
            // Y1MinMaskedTextBox
            // 
            this.Y1MinMaskedTextBox.Location = new System.Drawing.Point(42, 125);
            this.Y1MinMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MinMaskedTextBox.Name = "Y1MinMaskedTextBox";
            this.Y1MinMaskedTextBox.Size = new System.Drawing.Size(254, 31);
            this.Y1MinMaskedTextBox.TabIndex = 419;
            // 
            // Y1FontColorComboBox
            // 
            this.Y1FontColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1FontColorComboBox.FormattingEnabled = true;
            this.Y1FontColorComboBox.Location = new System.Drawing.Point(312, 354);
            this.Y1FontColorComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1FontColorComboBox.Name = "Y1FontColorComboBox";
            this.Y1FontColorComboBox.Size = new System.Drawing.Size(254, 33);
            this.Y1FontColorComboBox.TabIndex = 417;
            this.Y1FontColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Y1FontColorComboBox_DrawItem);
            this.Y1FontColorComboBox.SelectedIndexChanged += new System.EventHandler(this.Y1FontColorComboBox_SelectedIndexChanged);
            //
            //
            //
            // 
            // Y1FontStyleComboBox
            // 
            this.Y1FontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1FontStyleComboBox.FormattingEnabled = true;
            this.Y1FontStyleComboBox.Location = new System.Drawing.Point(312, 277);
            this.Y1FontStyleComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1FontStyleComboBox.Name = "Y1FontStyleComboBox";
            this.Y1FontStyleComboBox.Size = new System.Drawing.Size(254, 33);
            this.Y1FontStyleComboBox.TabIndex = 413;
            this.Y1FontStyleComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Y1FontStyleComboBox_DrawItem);
            this.Y1FontStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.Y1FontStyleComboBox_SelectedIndexChanged);
            // 
            // Y1FontSizeComboBox
            // 
            this.Y1FontSizeComboBox.FormattingEnabled = true;
            this.Y1FontSizeComboBox.Location = new System.Drawing.Point(42, 200);
            this.Y1FontSizeComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1FontSizeComboBox.Name = "Y1FontSizeComboBox";
            this.Y1FontSizeComboBox.Size = new System.Drawing.Size(254, 33);
            this.Y1FontSizeComboBox.TabIndex = 412;
            this.Y1FontSizeComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Y1FontSizeComboBox_DrawItem);
            this.Y1FontSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.Y1FontSizeComboBox_SelectedIndexChanged);
            // 
            // Y1ComboBoxFonts
            // 
            this.Y1ComboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1ComboBoxFonts.FormattingEnabled = true;
            this.Y1ComboBoxFonts.Location = new System.Drawing.Point(312, 200);
            this.Y1ComboBoxFonts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1ComboBoxFonts.Name = "Y1ComboBoxFonts";
            this.Y1ComboBoxFonts.Size = new System.Drawing.Size(254, 33);
            this.Y1ComboBoxFonts.TabIndex = 411;
            this.Y1ComboBoxFonts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Y1ComboBoxFonts_DrawItem);
            this.Y1ComboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.Y1ComboBoxFonts_SelectedIndexChanged);
            //
            //
            //
            //
            //
            //
            //
            // 
            // Y1DefaultsCheckBox
            // 
            this.Y1DefaultsCheckBox.AutoSize = true;
            this.Y1DefaultsCheckBox.Checked = true;
            this.Y1DefaultsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Y1DefaultsCheckBox.Location = new System.Drawing.Point(42, 48);
            this.Y1DefaultsCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1DefaultsCheckBox.Name = "Y1DefaultsCheckBox";
            this.Y1DefaultsCheckBox.Size = new System.Drawing.Size(123, 29);
            this.Y1DefaultsCheckBox.TabIndex = 401;
            this.Y1DefaultsCheckBox.Text = "Defaults";
            this.Y1DefaultsCheckBox.UseVisualStyleBackColor = true;
            this.Y1DefaultsCheckBox.CheckedChanged += new System.EventHandler(this.Y1DefaultsCheckBox_CheckedChanged);
            // 
            // HistoryAmountPointsMaskedTextBox
            // 
            this.HistoryAmountPointsMaskedTextBox.Location = new System.Drawing.Point(24, 525);
            this.HistoryAmountPointsMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.HistoryAmountPointsMaskedTextBox.Name = "HistoryAmountPointsMaskedTextBox";
            this.HistoryAmountPointsMaskedTextBox.Size = new System.Drawing.Size(254, 31);
            this.HistoryAmountPointsMaskedTextBox.TabIndex = 436;
            //
            // 
            // InfiniteHistoryCheckBox
            // 
            this.InfiniteHistoryCheckBox.AutoSize = true;
            this.InfiniteHistoryCheckBox.Location = new System.Drawing.Point(24, 575);
            this.InfiniteHistoryCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.InfiniteHistoryCheckBox.Name = "InfiniteHistoryCheckBox";
            this.InfiniteHistoryCheckBox.Size = new System.Drawing.Size(265, 29);
            this.InfiniteHistoryCheckBox.TabIndex = 437;
            this.InfiniteHistoryCheckBox.Text = "Infinite History Enabled";
            this.InfiniteHistoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // SchemeComboBox
            // 
            this.SchemeComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.SchemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SchemeComboBox.FormattingEnabled = true;
            this.SchemeComboBox.Location = new System.Drawing.Point(24, 644);
            this.SchemeComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SchemeComboBox.Name = "SchemeComboBox";
            this.SchemeComboBox.Size = new System.Drawing.Size(254, 33);
            this.SchemeComboBox.TabIndex = 439;
            this.SchemeComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.SchemeComboBox_DrawItem);
            //
            // 
            // Y1MajorIntervalDividerComboBox
            // 
            this.Y1MajorIntervalDividerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1MajorIntervalDividerComboBox.FormattingEnabled = true;
            this.Y1MajorIntervalDividerComboBox.Location = new System.Drawing.Point(242, 431);
            this.Y1MajorIntervalDividerComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Y1MajorIntervalDividerComboBox.Name = "Y1MajorIntervalDividerComboBox";
            this.Y1MajorIntervalDividerComboBox.Size = new System.Drawing.Size(84, 33);
            this.Y1MajorIntervalDividerComboBox.TabIndex = 440;
            // 
            // X1MajorIntervalFractionComboBox
            // 
            this.X1MajorIntervalFractionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1MajorIntervalFractionComboBox.FormattingEnabled = true;
            this.X1MajorIntervalFractionComboBox.Location = new System.Drawing.Point(142, 431);
            this.X1MajorIntervalFractionComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.X1MajorIntervalFractionComboBox.Name = "X1MajorIntervalFractionComboBox";
            this.X1MajorIntervalFractionComboBox.Size = new System.Drawing.Size(138, 33);
            this.X1MajorIntervalFractionComboBox.TabIndex = 441;
            //
            // Designer-owned sections: edit the GroupBoxes, Panels and children in Document Outline.
            //
            this.settingsSectionsLayout.Name = "settingsSectionsLayout";
            this.settingsSectionsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsSectionsLayout.ColumnCount = 3;
            this.settingsSectionsLayout.RowCount = 1;
            this.settingsSectionsLayout.Padding = new System.Windows.Forms.Padding(2);
            this.settingsSectionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsSectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.settingsSectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.settingsSectionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.settingsSidebarGroup.Name = "settingsSidebarGroup";
            this.settingsSidebarGroup.Text = "Chart and Data Settings";
            this.settingsSidebarGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsSidebarGroup.Margin = new System.Windows.Forms.Padding(2);
            this.settingsSidebarGroup.Padding = new System.Windows.Forms.Padding(3);
            this.settingsSidebarPanel.Name = "settingsSidebarPanel";
            this.settingsSidebarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsSidebarPanel.AutoScroll = true;
            this.settingsSidebarGroup.Controls.Add(this.settingsSidebarPanel);
            this.settingsSectionsLayout.Controls.Add(this.settingsSidebarGroup, 0, 0);
            this.xAxisSettingsGroup.Name = "xAxisSettingsGroup";
            this.xAxisSettingsGroup.Text = "X Axis";
            this.xAxisSettingsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xAxisSettingsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.xAxisSettingsGroup.Padding = new System.Windows.Forms.Padding(3);
            this.xAxisSettingsPanel.Name = "xAxisSettingsPanel";
            this.xAxisSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xAxisSettingsPanel.AutoScroll = true;
            this.xAxisSettingsGroup.Controls.Add(this.xAxisSettingsPanel);
            this.settingsSectionsLayout.Controls.Add(this.xAxisSettingsGroup, 1, 0);
            this.yAxisSettingsGroup.Name = "yAxisSettingsGroup";
            this.yAxisSettingsGroup.Text = "Y Axis";
            this.yAxisSettingsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisSettingsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.yAxisSettingsGroup.Padding = new System.Windows.Forms.Padding(3);
            this.yAxisSettingsPanel.Name = "yAxisSettingsPanel";
            this.yAxisSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisSettingsPanel.AutoScroll = true;
            this.yAxisSettingsGroup.Controls.Add(this.yAxisSettingsPanel);
            this.settingsSectionsLayout.Controls.Add(this.yAxisSettingsGroup, 2, 0);
            // 
            // FormGForceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(1250, 730);
            // Shared dark WinForms Designer palette. No runtime-only recoloring.
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "G-Force chart settings";
            this.MinimumSize = new System.Drawing.Size(880, 530);
            this.settingsSectionsLayout.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.settingsSectionsLayout.Padding = new System.Windows.Forms.Padding(2);
            this.settingsSidebarGroup.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.settingsSidebarGroup.ForeColor = System.Drawing.Color.White;
            this.settingsSidebarGroup.Padding = new System.Windows.Forms.Padding(6);
            this.xAxisSettingsGroup.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.xAxisSettingsGroup.ForeColor = System.Drawing.Color.White;
            this.xAxisSettingsGroup.Padding = new System.Windows.Forms.Padding(6);
            this.yAxisSettingsGroup.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.yAxisSettingsGroup.ForeColor = System.Drawing.Color.White;
            this.yAxisSettingsGroup.Padding = new System.Windows.Forms.Padding(6);
            this.settingsSidebarPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.settingsSidebarPanel.ColumnCount = 1;
            this.settingsSidebarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsSidebarPanel.RowCount = 5;
            this.settingsSidebarPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.settingsSidebarPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.xAxisSettingsPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.xAxisSettingsPanel.ColumnCount = 1;
            this.xAxisSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xAxisSettingsPanel.RowCount = 10;
            this.xAxisSettingsPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.xAxisSettingsPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.yAxisSettingsPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.yAxisSettingsPanel.ColumnCount = 1;
            this.yAxisSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yAxisSettingsPanel.RowCount = 10;
            this.yAxisSettingsPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.yAxisSettingsPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MarkerColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.MarkerColorComboBox.ForeColor = System.Drawing.Color.White;
            this.LoadCurrentValuesButton.UseVisualStyleBackColor = false;
            this.LoadCurrentValuesButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LoadCurrentValuesButton.ForeColor = System.Drawing.Color.White;
            this.DefaultsCheckBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.DefaultsCheckBox.UseVisualStyleBackColor = false;
            this.DefaultsCheckBox.ForeColor = System.Drawing.Color.White;
            this.BackgroundColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.BackgroundColorComboBox.ForeColor = System.Drawing.Color.White;
            this.applyAndClearChartsButton.UseVisualStyleBackColor = false;
            this.applyAndClearChartsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.applyAndClearChartsButton.ForeColor = System.Drawing.Color.White;
            this.X1MajorIntervalFractionTextBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MajorIntervalFractionTextBox.ForeColor = System.Drawing.Color.White;
            this.X1MinorLineWidthComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MinorLineWidthComboBox.ForeColor = System.Drawing.Color.White;
            this.X1MajorColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MajorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.X1MajorLineWidthComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MajorLineWidthComboBox.ForeColor = System.Drawing.Color.White;
            this.X1MinorEnabledCheckBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MinorEnabledCheckBox.UseVisualStyleBackColor = false;
            this.X1MinorEnabledCheckBox.ForeColor = System.Drawing.Color.White;
            this.X1MinorDashStyleComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MinorDashStyleComboBox.ForeColor = System.Drawing.Color.White;
            this.X1MinorColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MinorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.X1MinorIntervalComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MinorIntervalComboBox.ForeColor = System.Drawing.Color.White;
            this.X1FontColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1FontColorComboBox.ForeColor = System.Drawing.Color.White;
            this.X1FontStyleComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1FontStyleComboBox.ForeColor = System.Drawing.Color.White;
            this.X1FontSizeComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1FontSizeComboBox.ForeColor = System.Drawing.Color.White;
            this.X1ComboBoxFonts.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1ComboBoxFonts.ForeColor = System.Drawing.Color.White;
            this.X1DefaultsCheckBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1DefaultsCheckBox.UseVisualStyleBackColor = false;
            this.X1DefaultsCheckBox.ForeColor = System.Drawing.Color.White;
            this.X1AngleTypeComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1AngleTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1IntervalDividerTextBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1IntervalDividerTextBox.ForeColor = System.Drawing.Color.White;
            this.Y1MinorLineWidthComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MinorLineWidthComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MaxMaskedTextBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MaxMaskedTextBox.ForeColor = System.Drawing.Color.White;
            this.Y1MajorColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MajorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MajorLineWidthComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MajorLineWidthComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MinorEnabledCheckBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinorEnabledCheckBox.UseVisualStyleBackColor = false;
            this.Y1MinorEnabledCheckBox.ForeColor = System.Drawing.Color.White;
            this.Y1MinorDashStyleComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MinorDashStyleComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MinorColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MinorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MinorIntervalComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MinorIntervalComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MajorDecimalsComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MajorDecimalsComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MinMaskedTextBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MinMaskedTextBox.ForeColor = System.Drawing.Color.White;
            this.Y1FontColorComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1FontColorComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1FontStyleComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1FontStyleComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1FontSizeComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1FontSizeComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1ComboBoxFonts.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1ComboBoxFonts.ForeColor = System.Drawing.Color.White;
            this.Y1DefaultsCheckBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1DefaultsCheckBox.UseVisualStyleBackColor = false;
            this.Y1DefaultsCheckBox.ForeColor = System.Drawing.Color.White;
            this.HistoryAmountPointsMaskedTextBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.HistoryAmountPointsMaskedTextBox.ForeColor = System.Drawing.Color.White;
            this.InfiniteHistoryCheckBox.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.InfiniteHistoryCheckBox.UseVisualStyleBackColor = false;
            this.InfiniteHistoryCheckBox.ForeColor = System.Drawing.Color.White;
            this.SchemeComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.SchemeComboBox.ForeColor = System.Drawing.Color.White;
            this.Y1MajorIntervalDividerComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.Y1MajorIntervalDividerComboBox.ForeColor = System.Drawing.Color.White;
            this.X1MajorIntervalFractionComboBox.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.X1MajorIntervalFractionComboBox.ForeColor = System.Drawing.Color.White;
            this.settingsSidebarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.DefaultsCheckBoxRow = new System.Windows.Forms.Panel();
            this.DefaultsCheckBoxRow.Name = "DefaultsCheckBoxRow";
            this.DefaultsCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultsCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.DefaultsCheckBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DefaultsCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.DefaultsCheckBox.Location = new System.Drawing.Point(5, 7);
            this.DefaultsCheckBox.AutoSize = false;
            this.DefaultsCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.DefaultsCheckBoxRow.Controls.Add(this.DefaultsCheckBox);
            this.settingsSidebarPanel.Controls.Add(this.DefaultsCheckBoxRow, 0, 0);
            this.settingsSidebarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gSidebarColorsRow = new System.Windows.Forms.TableLayoutPanel();
            this.gSidebarColorsRow.Name = "gSidebarColorsRow";
            this.gSidebarColorsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSidebarColorsRow.Margin = new System.Windows.Forms.Padding(0);
            this.gSidebarColorsRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gSidebarColorsRow.ColumnCount = 2;
            this.gSidebarColorsRow.RowCount = 1;
            this.gSidebarColorsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gSidebarColorsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gSidebarColorsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.BackgroundColorComboBoxRow = new System.Windows.Forms.Panel();
            this.BackgroundColorComboBoxRow.Name = "BackgroundColorComboBoxRow";
            this.BackgroundColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BackgroundColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.BackgroundColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.BackgroundColorComboBoxRowLabel.Name = "BackgroundColorComboBoxRowLabel";
            this.BackgroundColorComboBoxRowLabel.Text = "Background color";
            this.BackgroundColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.BackgroundColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.BackgroundColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.BackgroundColorComboBoxRowLabel.AutoEllipsis = true;
            this.BackgroundColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.BackgroundColorComboBoxRow.Controls.Add(this.BackgroundColorComboBoxRowLabel);
            this.BackgroundColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.BackgroundColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.BackgroundColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.BackgroundColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.BackgroundColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundColorComboBoxRow.Controls.Add(this.BackgroundColorComboBox);
            this.gSidebarColorsRow.Controls.Add(this.BackgroundColorComboBoxRow, 0, 0);
            this.MarkerColorComboBoxRow = new System.Windows.Forms.Panel();
            this.MarkerColorComboBoxRow.Name = "MarkerColorComboBoxRow";
            this.MarkerColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarkerColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.MarkerColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MarkerColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.MarkerColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.MarkerColorComboBoxRowLabel.Name = "MarkerColorComboBoxRowLabel";
            this.MarkerColorComboBoxRowLabel.Text = "Marker color";
            this.MarkerColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.MarkerColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.MarkerColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.MarkerColorComboBoxRowLabel.AutoEllipsis = true;
            this.MarkerColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.MarkerColorComboBoxRow.Controls.Add(this.MarkerColorComboBoxRowLabel);
            this.MarkerColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.MarkerColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.MarkerColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.MarkerColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.MarkerColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.MarkerColorComboBoxRow.Controls.Add(this.MarkerColorComboBox);
            this.gSidebarColorsRow.Controls.Add(this.MarkerColorComboBoxRow, 1, 0);
            this.settingsSidebarPanel.Controls.Add(this.gSidebarColorsRow, 0, 1);
            this.settingsSidebarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gSidebarHistoryRow = new System.Windows.Forms.TableLayoutPanel();
            this.gSidebarHistoryRow.Name = "gSidebarHistoryRow";
            this.gSidebarHistoryRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSidebarHistoryRow.Margin = new System.Windows.Forms.Padding(0);
            this.gSidebarHistoryRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gSidebarHistoryRow.ColumnCount = 2;
            this.gSidebarHistoryRow.RowCount = 1;
            this.gSidebarHistoryRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gSidebarHistoryRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gSidebarHistoryRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.HistoryAmountPointsMaskedTextBoxRow = new System.Windows.Forms.Panel();
            this.HistoryAmountPointsMaskedTextBoxRow.Name = "HistoryAmountPointsMaskedTextBoxRow";
            this.HistoryAmountPointsMaskedTextBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryAmountPointsMaskedTextBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.HistoryAmountPointsMaskedTextBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HistoryAmountPointsMaskedTextBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.HistoryAmountPointsMaskedTextBoxRowLabel = new System.Windows.Forms.Label();
            this.HistoryAmountPointsMaskedTextBoxRowLabel.Name = "HistoryAmountPointsMaskedTextBoxRowLabel";
            this.HistoryAmountPointsMaskedTextBoxRowLabel.Text = "History points";
            this.HistoryAmountPointsMaskedTextBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.HistoryAmountPointsMaskedTextBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.HistoryAmountPointsMaskedTextBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.HistoryAmountPointsMaskedTextBoxRowLabel.AutoEllipsis = true;
            this.HistoryAmountPointsMaskedTextBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.HistoryAmountPointsMaskedTextBoxRow.Controls.Add(this.HistoryAmountPointsMaskedTextBoxRowLabel);
            this.HistoryAmountPointsMaskedTextBox.Location = new System.Drawing.Point(5, 31);
            this.HistoryAmountPointsMaskedTextBox.Size = new System.Drawing.Size(190, 30);
            this.HistoryAmountPointsMaskedTextBox.Dock = System.Windows.Forms.DockStyle.None;
            this.HistoryAmountPointsMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.HistoryAmountPointsMaskedTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.HistoryAmountPointsMaskedTextBoxRow.Controls.Add(this.HistoryAmountPointsMaskedTextBox);
            this.gSidebarHistoryRow.Controls.Add(this.HistoryAmountPointsMaskedTextBoxRow, 0, 0);
            this.InfiniteHistoryCheckBoxRow = new System.Windows.Forms.Panel();
            this.InfiniteHistoryCheckBoxRow.Name = "InfiniteHistoryCheckBoxRow";
            this.InfiniteHistoryCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfiniteHistoryCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.InfiniteHistoryCheckBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InfiniteHistoryCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.InfiniteHistoryCheckBox.Location = new System.Drawing.Point(5, 7);
            this.InfiniteHistoryCheckBox.AutoSize = false;
            this.InfiniteHistoryCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfiniteHistoryCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.InfiniteHistoryCheckBoxRow.Controls.Add(this.InfiniteHistoryCheckBox);
            this.gSidebarHistoryRow.Controls.Add(this.InfiniteHistoryCheckBoxRow, 1, 0);
            this.settingsSidebarPanel.Controls.Add(this.gSidebarHistoryRow, 0, 2);
            this.settingsSidebarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.SchemeComboBoxRow = new System.Windows.Forms.Panel();
            this.SchemeComboBoxRow.Name = "SchemeComboBoxRow";
            this.SchemeComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchemeComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.SchemeComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SchemeComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.SchemeComboBoxRowLabel = new System.Windows.Forms.Label();
            this.SchemeComboBoxRowLabel.Name = "SchemeComboBoxRowLabel";
            this.SchemeComboBoxRowLabel.Text = "Color scheme";
            this.SchemeComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.SchemeComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.SchemeComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.SchemeComboBoxRowLabel.AutoEllipsis = true;
            this.SchemeComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.SchemeComboBoxRow.Controls.Add(this.SchemeComboBoxRowLabel);
            this.SchemeComboBox.Location = new System.Drawing.Point(5, 31);
            this.SchemeComboBox.Size = new System.Drawing.Size(190, 30);
            this.SchemeComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.SchemeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.SchemeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.SchemeComboBoxRow.Controls.Add(this.SchemeComboBox);
            this.settingsSidebarPanel.Controls.Add(this.SchemeComboBoxRow, 0, 3);
            this.settingsSidebarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.X1DefaultsCheckBoxRow = new System.Windows.Forms.Panel();
            this.X1DefaultsCheckBoxRow.Name = "X1DefaultsCheckBoxRow";
            this.X1DefaultsCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1DefaultsCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1DefaultsCheckBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1DefaultsCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1DefaultsCheckBox.Location = new System.Drawing.Point(5, 7);
            this.X1DefaultsCheckBox.AutoSize = false;
            this.X1DefaultsCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1DefaultsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1DefaultsCheckBoxRow.Controls.Add(this.X1DefaultsCheckBox);
            this.xAxisSettingsPanel.Controls.Add(this.X1DefaultsCheckBoxRow, 0, 0);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.X1AngleTypeComboBoxRow = new System.Windows.Forms.Panel();
            this.X1AngleTypeComboBoxRow.Name = "X1AngleTypeComboBoxRow";
            this.X1AngleTypeComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1AngleTypeComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1AngleTypeComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1AngleTypeComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1AngleTypeComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1AngleTypeComboBoxRowLabel.Name = "X1AngleTypeComboBoxRowLabel";
            this.X1AngleTypeComboBoxRowLabel.Text = "Angle type";
            this.X1AngleTypeComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1AngleTypeComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1AngleTypeComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1AngleTypeComboBoxRowLabel.AutoEllipsis = true;
            this.X1AngleTypeComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1AngleTypeComboBoxRow.Controls.Add(this.X1AngleTypeComboBoxRowLabel);
            this.X1AngleTypeComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1AngleTypeComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1AngleTypeComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1AngleTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1AngleTypeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1AngleTypeComboBoxRow.Controls.Add(this.X1AngleTypeComboBox);
            this.xAxisSettingsPanel.Controls.Add(this.X1AngleTypeComboBoxRow, 0, 1);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gXFontRow = new System.Windows.Forms.TableLayoutPanel();
            this.gXFontRow.Name = "gXFontRow";
            this.gXFontRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gXFontRow.Margin = new System.Windows.Forms.Padding(0);
            this.gXFontRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gXFontRow.ColumnCount = 2;
            this.gXFontRow.RowCount = 1;
            this.gXFontRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gXFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gXFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.X1FontSizeComboBoxRow = new System.Windows.Forms.Panel();
            this.X1FontSizeComboBoxRow.Name = "X1FontSizeComboBoxRow";
            this.X1FontSizeComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1FontSizeComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1FontSizeComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1FontSizeComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1FontSizeComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1FontSizeComboBoxRowLabel.Name = "X1FontSizeComboBoxRowLabel";
            this.X1FontSizeComboBoxRowLabel.Text = "Font size";
            this.X1FontSizeComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1FontSizeComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1FontSizeComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1FontSizeComboBoxRowLabel.AutoEllipsis = true;
            this.X1FontSizeComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1FontSizeComboBoxRow.Controls.Add(this.X1FontSizeComboBoxRowLabel);
            this.X1FontSizeComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1FontSizeComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1FontSizeComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1FontSizeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1FontSizeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1FontSizeComboBoxRow.Controls.Add(this.X1FontSizeComboBox);
            this.gXFontRow.Controls.Add(this.X1FontSizeComboBoxRow, 0, 0);
            this.X1ComboBoxFontsRow = new System.Windows.Forms.Panel();
            this.X1ComboBoxFontsRow.Name = "X1ComboBoxFontsRow";
            this.X1ComboBoxFontsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1ComboBoxFontsRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1ComboBoxFontsRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1ComboBoxFontsRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1ComboBoxFontsRowLabel = new System.Windows.Forms.Label();
            this.X1ComboBoxFontsRowLabel.Name = "X1ComboBoxFontsRowLabel";
            this.X1ComboBoxFontsRowLabel.Text = "Font name";
            this.X1ComboBoxFontsRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1ComboBoxFontsRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1ComboBoxFontsRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1ComboBoxFontsRowLabel.AutoEllipsis = true;
            this.X1ComboBoxFontsRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1ComboBoxFontsRow.Controls.Add(this.X1ComboBoxFontsRowLabel);
            this.X1ComboBoxFonts.Location = new System.Drawing.Point(5, 31);
            this.X1ComboBoxFonts.Size = new System.Drawing.Size(190, 30);
            this.X1ComboBoxFonts.Dock = System.Windows.Forms.DockStyle.None;
            this.X1ComboBoxFonts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1ComboBoxFonts.Margin = new System.Windows.Forms.Padding(0);
            this.X1ComboBoxFontsRow.Controls.Add(this.X1ComboBoxFonts);
            this.gXFontRow.Controls.Add(this.X1ComboBoxFontsRow, 1, 0);
            this.xAxisSettingsPanel.Controls.Add(this.gXFontRow, 0, 2);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gXFontStyleRow = new System.Windows.Forms.TableLayoutPanel();
            this.gXFontStyleRow.Name = "gXFontStyleRow";
            this.gXFontStyleRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gXFontStyleRow.Margin = new System.Windows.Forms.Padding(0);
            this.gXFontStyleRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gXFontStyleRow.ColumnCount = 2;
            this.gXFontStyleRow.RowCount = 1;
            this.gXFontStyleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gXFontStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gXFontStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.X1FontStyleComboBoxRow = new System.Windows.Forms.Panel();
            this.X1FontStyleComboBoxRow.Name = "X1FontStyleComboBoxRow";
            this.X1FontStyleComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1FontStyleComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1FontStyleComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1FontStyleComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1FontStyleComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1FontStyleComboBoxRowLabel.Name = "X1FontStyleComboBoxRowLabel";
            this.X1FontStyleComboBoxRowLabel.Text = "Font style";
            this.X1FontStyleComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1FontStyleComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1FontStyleComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1FontStyleComboBoxRowLabel.AutoEllipsis = true;
            this.X1FontStyleComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1FontStyleComboBoxRow.Controls.Add(this.X1FontStyleComboBoxRowLabel);
            this.X1FontStyleComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1FontStyleComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1FontStyleComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1FontStyleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1FontStyleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1FontStyleComboBoxRow.Controls.Add(this.X1FontStyleComboBox);
            this.gXFontStyleRow.Controls.Add(this.X1FontStyleComboBoxRow, 0, 0);
            this.X1FontColorComboBoxRow = new System.Windows.Forms.Panel();
            this.X1FontColorComboBoxRow.Name = "X1FontColorComboBoxRow";
            this.X1FontColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1FontColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1FontColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1FontColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1FontColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1FontColorComboBoxRowLabel.Name = "X1FontColorComboBoxRowLabel";
            this.X1FontColorComboBoxRowLabel.Text = "Font color";
            this.X1FontColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1FontColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1FontColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1FontColorComboBoxRowLabel.AutoEllipsis = true;
            this.X1FontColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1FontColorComboBoxRow.Controls.Add(this.X1FontColorComboBoxRowLabel);
            this.X1FontColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1FontColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1FontColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1FontColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1FontColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1FontColorComboBoxRow.Controls.Add(this.X1FontColorComboBox);
            this.gXFontStyleRow.Controls.Add(this.X1FontColorComboBoxRow, 1, 0);
            this.xAxisSettingsPanel.Controls.Add(this.gXFontStyleRow, 0, 3);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gXMajorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.gXMajorStrokeRow.Name = "gXMajorStrokeRow";
            this.gXMajorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gXMajorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.gXMajorStrokeRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gXMajorStrokeRow.ColumnCount = 2;
            this.gXMajorStrokeRow.RowCount = 1;
            this.gXMajorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gXMajorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gXMajorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.X1MajorLineWidthComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MajorLineWidthComboBoxRow.Name = "X1MajorLineWidthComboBoxRow";
            this.X1MajorLineWidthComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MajorLineWidthComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MajorLineWidthComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MajorLineWidthComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MajorLineWidthComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MajorLineWidthComboBoxRowLabel.Name = "X1MajorLineWidthComboBoxRowLabel";
            this.X1MajorLineWidthComboBoxRowLabel.Text = "Major grid width";
            this.X1MajorLineWidthComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MajorLineWidthComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MajorLineWidthComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MajorLineWidthComboBoxRowLabel.AutoEllipsis = true;
            this.X1MajorLineWidthComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MajorLineWidthComboBoxRow.Controls.Add(this.X1MajorLineWidthComboBoxRowLabel);
            this.X1MajorLineWidthComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MajorLineWidthComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MajorLineWidthComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MajorLineWidthComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MajorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MajorLineWidthComboBoxRow.Controls.Add(this.X1MajorLineWidthComboBox);
            this.gXMajorStrokeRow.Controls.Add(this.X1MajorLineWidthComboBoxRow, 0, 0);
            this.X1MajorIntervalFractionComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MajorIntervalFractionComboBoxRow.Name = "X1MajorIntervalFractionComboBoxRow";
            this.X1MajorIntervalFractionComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MajorIntervalFractionComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MajorIntervalFractionComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MajorIntervalFractionComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MajorIntervalFractionComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MajorIntervalFractionComboBoxRowLabel.Name = "X1MajorIntervalFractionComboBoxRowLabel";
            this.X1MajorIntervalFractionComboBoxRowLabel.Text = "Major interval fraction";
            this.X1MajorIntervalFractionComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MajorIntervalFractionComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MajorIntervalFractionComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MajorIntervalFractionComboBoxRowLabel.AutoEllipsis = true;
            this.X1MajorIntervalFractionComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MajorIntervalFractionComboBoxRow.Controls.Add(this.X1MajorIntervalFractionComboBoxRowLabel);
            this.X1MajorIntervalFractionComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MajorIntervalFractionComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MajorIntervalFractionComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MajorIntervalFractionComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MajorIntervalFractionComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MajorIntervalFractionComboBoxRow.Controls.Add(this.X1MajorIntervalFractionComboBox);
            this.gXMajorStrokeRow.Controls.Add(this.X1MajorIntervalFractionComboBoxRow, 1, 0);
            this.xAxisSettingsPanel.Controls.Add(this.gXMajorStrokeRow, 0, 4);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.X1MajorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MajorColorComboBoxRow.Name = "X1MajorColorComboBoxRow";
            this.X1MajorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MajorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MajorColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MajorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MajorColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MajorColorComboBoxRowLabel.Name = "X1MajorColorComboBoxRowLabel";
            this.X1MajorColorComboBoxRowLabel.Text = "Major grid color";
            this.X1MajorColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MajorColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MajorColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MajorColorComboBoxRowLabel.AutoEllipsis = true;
            this.X1MajorColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MajorColorComboBoxRow.Controls.Add(this.X1MajorColorComboBoxRowLabel);
            this.X1MajorColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MajorColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MajorColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MajorColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MajorColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MajorColorComboBoxRow.Controls.Add(this.X1MajorColorComboBox);
            this.xAxisSettingsPanel.Controls.Add(this.X1MajorColorComboBoxRow, 0, 5);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gXMinorOptionsRow = new System.Windows.Forms.TableLayoutPanel();
            this.gXMinorOptionsRow.Name = "gXMinorOptionsRow";
            this.gXMinorOptionsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gXMinorOptionsRow.Margin = new System.Windows.Forms.Padding(0);
            this.gXMinorOptionsRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gXMinorOptionsRow.ColumnCount = 2;
            this.gXMinorOptionsRow.RowCount = 1;
            this.gXMinorOptionsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gXMinorOptionsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gXMinorOptionsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.X1MinorEnabledCheckBoxRow = new System.Windows.Forms.Panel();
            this.X1MinorEnabledCheckBoxRow.Name = "X1MinorEnabledCheckBoxRow";
            this.X1MinorEnabledCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MinorEnabledCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorEnabledCheckBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MinorEnabledCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MinorEnabledCheckBox.Location = new System.Drawing.Point(5, 7);
            this.X1MinorEnabledCheckBox.AutoSize = false;
            this.X1MinorEnabledCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MinorEnabledCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorEnabledCheckBoxRow.Controls.Add(this.X1MinorEnabledCheckBox);
            this.gXMinorOptionsRow.Controls.Add(this.X1MinorEnabledCheckBoxRow, 0, 0);
            this.X1MinorIntervalComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MinorIntervalComboBoxRow.Name = "X1MinorIntervalComboBoxRow";
            this.X1MinorIntervalComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MinorIntervalComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorIntervalComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MinorIntervalComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MinorIntervalComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MinorIntervalComboBoxRowLabel.Name = "X1MinorIntervalComboBoxRowLabel";
            this.X1MinorIntervalComboBoxRowLabel.Text = "Minor interval fraction";
            this.X1MinorIntervalComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MinorIntervalComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MinorIntervalComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MinorIntervalComboBoxRowLabel.AutoEllipsis = true;
            this.X1MinorIntervalComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorIntervalComboBoxRow.Controls.Add(this.X1MinorIntervalComboBoxRowLabel);
            this.X1MinorIntervalComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MinorIntervalComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MinorIntervalComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MinorIntervalComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorIntervalComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorIntervalComboBoxRow.Controls.Add(this.X1MinorIntervalComboBox);
            this.gXMinorOptionsRow.Controls.Add(this.X1MinorIntervalComboBoxRow, 1, 0);
            this.xAxisSettingsPanel.Controls.Add(this.gXMinorOptionsRow, 0, 6);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gXMinorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.gXMinorStrokeRow.Name = "gXMinorStrokeRow";
            this.gXMinorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gXMinorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.gXMinorStrokeRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gXMinorStrokeRow.ColumnCount = 2;
            this.gXMinorStrokeRow.RowCount = 1;
            this.gXMinorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gXMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gXMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.X1MinorLineWidthComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MinorLineWidthComboBoxRow.Name = "X1MinorLineWidthComboBoxRow";
            this.X1MinorLineWidthComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MinorLineWidthComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorLineWidthComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MinorLineWidthComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MinorLineWidthComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MinorLineWidthComboBoxRowLabel.Name = "X1MinorLineWidthComboBoxRowLabel";
            this.X1MinorLineWidthComboBoxRowLabel.Text = "Minor grid width";
            this.X1MinorLineWidthComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MinorLineWidthComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MinorLineWidthComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MinorLineWidthComboBoxRowLabel.AutoEllipsis = true;
            this.X1MinorLineWidthComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorLineWidthComboBoxRow.Controls.Add(this.X1MinorLineWidthComboBoxRowLabel);
            this.X1MinorLineWidthComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MinorLineWidthComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MinorLineWidthComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MinorLineWidthComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorLineWidthComboBoxRow.Controls.Add(this.X1MinorLineWidthComboBox);
            this.gXMinorStrokeRow.Controls.Add(this.X1MinorLineWidthComboBoxRow, 0, 0);
            this.X1MinorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MinorColorComboBoxRow.Name = "X1MinorColorComboBoxRow";
            this.X1MinorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MinorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MinorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MinorColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MinorColorComboBoxRowLabel.Name = "X1MinorColorComboBoxRowLabel";
            this.X1MinorColorComboBoxRowLabel.Text = "Minor grid color";
            this.X1MinorColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MinorColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MinorColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MinorColorComboBoxRowLabel.AutoEllipsis = true;
            this.X1MinorColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorColorComboBoxRow.Controls.Add(this.X1MinorColorComboBoxRowLabel);
            this.X1MinorColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MinorColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MinorColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MinorColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorColorComboBoxRow.Controls.Add(this.X1MinorColorComboBox);
            this.gXMinorStrokeRow.Controls.Add(this.X1MinorColorComboBoxRow, 1, 0);
            this.xAxisSettingsPanel.Controls.Add(this.gXMinorStrokeRow, 0, 7);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.X1MinorDashStyleComboBoxRow = new System.Windows.Forms.Panel();
            this.X1MinorDashStyleComboBoxRow.Name = "X1MinorDashStyleComboBoxRow";
            this.X1MinorDashStyleComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X1MinorDashStyleComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorDashStyleComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X1MinorDashStyleComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.X1MinorDashStyleComboBoxRowLabel = new System.Windows.Forms.Label();
            this.X1MinorDashStyleComboBoxRowLabel.Name = "X1MinorDashStyleComboBoxRowLabel";
            this.X1MinorDashStyleComboBoxRowLabel.Text = "Minor grid dash style";
            this.X1MinorDashStyleComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.X1MinorDashStyleComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.X1MinorDashStyleComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.X1MinorDashStyleComboBoxRowLabel.AutoEllipsis = true;
            this.X1MinorDashStyleComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorDashStyleComboBoxRow.Controls.Add(this.X1MinorDashStyleComboBoxRowLabel);
            this.X1MinorDashStyleComboBox.Location = new System.Drawing.Point(5, 31);
            this.X1MinorDashStyleComboBox.Size = new System.Drawing.Size(190, 30);
            this.X1MinorDashStyleComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.X1MinorDashStyleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.X1MinorDashStyleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.X1MinorDashStyleComboBoxRow.Controls.Add(this.X1MinorDashStyleComboBox);
            this.xAxisSettingsPanel.Controls.Add(this.X1MinorDashStyleComboBoxRow, 0, 8);
            this.xAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.Y1DefaultsCheckBoxRow = new System.Windows.Forms.Panel();
            this.Y1DefaultsCheckBoxRow.Name = "Y1DefaultsCheckBoxRow";
            this.Y1DefaultsCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1DefaultsCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1DefaultsCheckBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1DefaultsCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1DefaultsCheckBox.Location = new System.Drawing.Point(5, 7);
            this.Y1DefaultsCheckBox.AutoSize = false;
            this.Y1DefaultsCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1DefaultsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1DefaultsCheckBoxRow.Controls.Add(this.Y1DefaultsCheckBox);
            this.yAxisSettingsPanel.Controls.Add(this.Y1DefaultsCheckBoxRow, 0, 0);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYLimitsRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYLimitsRow.Name = "gYLimitsRow";
            this.gYLimitsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYLimitsRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYLimitsRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYLimitsRow.ColumnCount = 2;
            this.gYLimitsRow.RowCount = 1;
            this.gYLimitsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1MinMaskedTextBoxRow = new System.Windows.Forms.Panel();
            this.Y1MinMaskedTextBoxRow.Name = "Y1MinMaskedTextBoxRow";
            this.Y1MinMaskedTextBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinMaskedTextBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinMaskedTextBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MinMaskedTextBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinMaskedTextBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MinMaskedTextBoxRowLabel.Name = "Y1MinMaskedTextBoxRowLabel";
            this.Y1MinMaskedTextBoxRowLabel.Text = "Minimum";
            this.Y1MinMaskedTextBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MinMaskedTextBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MinMaskedTextBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MinMaskedTextBoxRowLabel.AutoEllipsis = true;
            this.Y1MinMaskedTextBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinMaskedTextBoxRow.Controls.Add(this.Y1MinMaskedTextBoxRowLabel);
            this.Y1MinMaskedTextBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MinMaskedTextBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MinMaskedTextBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MinMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinMaskedTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinMaskedTextBoxRow.Controls.Add(this.Y1MinMaskedTextBox);
            this.gYLimitsRow.Controls.Add(this.Y1MinMaskedTextBoxRow, 0, 0);
            this.Y1MaxMaskedTextBoxRow = new System.Windows.Forms.Panel();
            this.Y1MaxMaskedTextBoxRow.Name = "Y1MaxMaskedTextBoxRow";
            this.Y1MaxMaskedTextBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MaxMaskedTextBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MaxMaskedTextBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MaxMaskedTextBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MaxMaskedTextBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MaxMaskedTextBoxRowLabel.Name = "Y1MaxMaskedTextBoxRowLabel";
            this.Y1MaxMaskedTextBoxRowLabel.Text = "Maximum";
            this.Y1MaxMaskedTextBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MaxMaskedTextBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MaxMaskedTextBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MaxMaskedTextBoxRowLabel.AutoEllipsis = true;
            this.Y1MaxMaskedTextBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MaxMaskedTextBoxRow.Controls.Add(this.Y1MaxMaskedTextBoxRowLabel);
            this.Y1MaxMaskedTextBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MaxMaskedTextBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MaxMaskedTextBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MaxMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MaxMaskedTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MaxMaskedTextBoxRow.Controls.Add(this.Y1MaxMaskedTextBox);
            this.gYLimitsRow.Controls.Add(this.Y1MaxMaskedTextBoxRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYLimitsRow, 0, 1);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYFontRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYFontRow.Name = "gYFontRow";
            this.gYFontRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYFontRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYFontRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYFontRow.ColumnCount = 2;
            this.gYFontRow.RowCount = 1;
            this.gYFontRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1FontSizeComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1FontSizeComboBoxRow.Name = "Y1FontSizeComboBoxRow";
            this.Y1FontSizeComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1FontSizeComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1FontSizeComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1FontSizeComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1FontSizeComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1FontSizeComboBoxRowLabel.Name = "Y1FontSizeComboBoxRowLabel";
            this.Y1FontSizeComboBoxRowLabel.Text = "Font size";
            this.Y1FontSizeComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1FontSizeComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1FontSizeComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1FontSizeComboBoxRowLabel.AutoEllipsis = true;
            this.Y1FontSizeComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1FontSizeComboBoxRow.Controls.Add(this.Y1FontSizeComboBoxRowLabel);
            this.Y1FontSizeComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1FontSizeComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1FontSizeComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1FontSizeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1FontSizeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1FontSizeComboBoxRow.Controls.Add(this.Y1FontSizeComboBox);
            this.gYFontRow.Controls.Add(this.Y1FontSizeComboBoxRow, 0, 0);
            this.Y1ComboBoxFontsRow = new System.Windows.Forms.Panel();
            this.Y1ComboBoxFontsRow.Name = "Y1ComboBoxFontsRow";
            this.Y1ComboBoxFontsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1ComboBoxFontsRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1ComboBoxFontsRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1ComboBoxFontsRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1ComboBoxFontsRowLabel = new System.Windows.Forms.Label();
            this.Y1ComboBoxFontsRowLabel.Name = "Y1ComboBoxFontsRowLabel";
            this.Y1ComboBoxFontsRowLabel.Text = "Font name";
            this.Y1ComboBoxFontsRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1ComboBoxFontsRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1ComboBoxFontsRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1ComboBoxFontsRowLabel.AutoEllipsis = true;
            this.Y1ComboBoxFontsRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1ComboBoxFontsRow.Controls.Add(this.Y1ComboBoxFontsRowLabel);
            this.Y1ComboBoxFonts.Location = new System.Drawing.Point(5, 31);
            this.Y1ComboBoxFonts.Size = new System.Drawing.Size(190, 30);
            this.Y1ComboBoxFonts.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1ComboBoxFonts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1ComboBoxFonts.Margin = new System.Windows.Forms.Padding(0);
            this.Y1ComboBoxFontsRow.Controls.Add(this.Y1ComboBoxFonts);
            this.gYFontRow.Controls.Add(this.Y1ComboBoxFontsRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYFontRow, 0, 2);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYFontStyleRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYFontStyleRow.Name = "gYFontStyleRow";
            this.gYFontStyleRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYFontStyleRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYFontStyleRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYFontStyleRow.ColumnCount = 2;
            this.gYFontStyleRow.RowCount = 1;
            this.gYFontStyleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYFontStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYFontStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1FontStyleComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1FontStyleComboBoxRow.Name = "Y1FontStyleComboBoxRow";
            this.Y1FontStyleComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1FontStyleComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1FontStyleComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1FontStyleComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1FontStyleComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1FontStyleComboBoxRowLabel.Name = "Y1FontStyleComboBoxRowLabel";
            this.Y1FontStyleComboBoxRowLabel.Text = "Font style";
            this.Y1FontStyleComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1FontStyleComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1FontStyleComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1FontStyleComboBoxRowLabel.AutoEllipsis = true;
            this.Y1FontStyleComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1FontStyleComboBoxRow.Controls.Add(this.Y1FontStyleComboBoxRowLabel);
            this.Y1FontStyleComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1FontStyleComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1FontStyleComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1FontStyleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1FontStyleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1FontStyleComboBoxRow.Controls.Add(this.Y1FontStyleComboBox);
            this.gYFontStyleRow.Controls.Add(this.Y1FontStyleComboBoxRow, 0, 0);
            this.Y1FontColorComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1FontColorComboBoxRow.Name = "Y1FontColorComboBoxRow";
            this.Y1FontColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1FontColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1FontColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1FontColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1FontColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1FontColorComboBoxRowLabel.Name = "Y1FontColorComboBoxRowLabel";
            this.Y1FontColorComboBoxRowLabel.Text = "Font color";
            this.Y1FontColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1FontColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1FontColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1FontColorComboBoxRowLabel.AutoEllipsis = true;
            this.Y1FontColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1FontColorComboBoxRow.Controls.Add(this.Y1FontColorComboBoxRowLabel);
            this.Y1FontColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1FontColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1FontColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1FontColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1FontColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1FontColorComboBoxRow.Controls.Add(this.Y1FontColorComboBox);
            this.gYFontStyleRow.Controls.Add(this.Y1FontColorComboBoxRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYFontStyleRow, 0, 3);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYMajorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYMajorStrokeRow.Name = "gYMajorStrokeRow";
            this.gYMajorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYMajorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYMajorStrokeRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYMajorStrokeRow.ColumnCount = 2;
            this.gYMajorStrokeRow.RowCount = 1;
            this.gYMajorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYMajorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYMajorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1MajorLineWidthComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MajorLineWidthComboBoxRow.Name = "Y1MajorLineWidthComboBoxRow";
            this.Y1MajorLineWidthComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MajorLineWidthComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorLineWidthComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MajorLineWidthComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MajorLineWidthComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MajorLineWidthComboBoxRowLabel.Name = "Y1MajorLineWidthComboBoxRowLabel";
            this.Y1MajorLineWidthComboBoxRowLabel.Text = "Major grid width";
            this.Y1MajorLineWidthComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MajorLineWidthComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MajorLineWidthComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MajorLineWidthComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MajorLineWidthComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorLineWidthComboBoxRow.Controls.Add(this.Y1MajorLineWidthComboBoxRowLabel);
            this.Y1MajorLineWidthComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MajorLineWidthComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MajorLineWidthComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MajorLineWidthComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorLineWidthComboBoxRow.Controls.Add(this.Y1MajorLineWidthComboBox);
            this.gYMajorStrokeRow.Controls.Add(this.Y1MajorLineWidthComboBoxRow, 0, 0);
            this.Y1MajorDecimalsComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MajorDecimalsComboBoxRow.Name = "Y1MajorDecimalsComboBoxRow";
            this.Y1MajorDecimalsComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MajorDecimalsComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorDecimalsComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MajorDecimalsComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MajorDecimalsComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MajorDecimalsComboBoxRowLabel.Name = "Y1MajorDecimalsComboBoxRowLabel";
            this.Y1MajorDecimalsComboBoxRowLabel.Text = "Major decimals";
            this.Y1MajorDecimalsComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MajorDecimalsComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MajorDecimalsComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MajorDecimalsComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MajorDecimalsComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorDecimalsComboBoxRow.Controls.Add(this.Y1MajorDecimalsComboBoxRowLabel);
            this.Y1MajorDecimalsComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MajorDecimalsComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MajorDecimalsComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MajorDecimalsComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorDecimalsComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorDecimalsComboBoxRow.Controls.Add(this.Y1MajorDecimalsComboBox);
            this.gYMajorStrokeRow.Controls.Add(this.Y1MajorDecimalsComboBoxRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYMajorStrokeRow, 0, 4);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYMajorStyleRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYMajorStyleRow.Name = "gYMajorStyleRow";
            this.gYMajorStyleRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYMajorStyleRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYMajorStyleRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYMajorStyleRow.ColumnCount = 2;
            this.gYMajorStyleRow.RowCount = 1;
            this.gYMajorStyleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYMajorStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYMajorStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1MajorIntervalDividerComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MajorIntervalDividerComboBoxRow.Name = "Y1MajorIntervalDividerComboBoxRow";
            this.Y1MajorIntervalDividerComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MajorIntervalDividerComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorIntervalDividerComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MajorIntervalDividerComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MajorIntervalDividerComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MajorIntervalDividerComboBoxRowLabel.Name = "Y1MajorIntervalDividerComboBoxRowLabel";
            this.Y1MajorIntervalDividerComboBoxRowLabel.Text = "Major interval divisor";
            this.Y1MajorIntervalDividerComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MajorIntervalDividerComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MajorIntervalDividerComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MajorIntervalDividerComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MajorIntervalDividerComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorIntervalDividerComboBoxRow.Controls.Add(this.Y1MajorIntervalDividerComboBoxRowLabel);
            this.Y1MajorIntervalDividerComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MajorIntervalDividerComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MajorIntervalDividerComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MajorIntervalDividerComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorIntervalDividerComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorIntervalDividerComboBoxRow.Controls.Add(this.Y1MajorIntervalDividerComboBox);
            this.gYMajorStyleRow.Controls.Add(this.Y1MajorIntervalDividerComboBoxRow, 0, 0);
            this.Y1MajorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MajorColorComboBoxRow.Name = "Y1MajorColorComboBoxRow";
            this.Y1MajorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MajorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MajorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MajorColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MajorColorComboBoxRowLabel.Name = "Y1MajorColorComboBoxRowLabel";
            this.Y1MajorColorComboBoxRowLabel.Text = "Major grid color";
            this.Y1MajorColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MajorColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MajorColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MajorColorComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MajorColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorColorComboBoxRow.Controls.Add(this.Y1MajorColorComboBoxRowLabel);
            this.Y1MajorColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MajorColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MajorColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MajorColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MajorColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MajorColorComboBoxRow.Controls.Add(this.Y1MajorColorComboBox);
            this.gYMajorStyleRow.Controls.Add(this.Y1MajorColorComboBoxRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYMajorStyleRow, 0, 5);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYMinorOptionsRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYMinorOptionsRow.Name = "gYMinorOptionsRow";
            this.gYMinorOptionsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYMinorOptionsRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYMinorOptionsRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYMinorOptionsRow.ColumnCount = 2;
            this.gYMinorOptionsRow.RowCount = 1;
            this.gYMinorOptionsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYMinorOptionsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYMinorOptionsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1MinorEnabledCheckBoxRow = new System.Windows.Forms.Panel();
            this.Y1MinorEnabledCheckBoxRow.Name = "Y1MinorEnabledCheckBoxRow";
            this.Y1MinorEnabledCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinorEnabledCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorEnabledCheckBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MinorEnabledCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinorEnabledCheckBox.Location = new System.Drawing.Point(5, 7);
            this.Y1MinorEnabledCheckBox.AutoSize = false;
            this.Y1MinorEnabledCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinorEnabledCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorEnabledCheckBoxRow.Controls.Add(this.Y1MinorEnabledCheckBox);
            this.gYMinorOptionsRow.Controls.Add(this.Y1MinorEnabledCheckBoxRow, 0, 0);
            this.Y1MinorIntervalComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MinorIntervalComboBoxRow.Name = "Y1MinorIntervalComboBoxRow";
            this.Y1MinorIntervalComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinorIntervalComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorIntervalComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MinorIntervalComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinorIntervalComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MinorIntervalComboBoxRowLabel.Name = "Y1MinorIntervalComboBoxRowLabel";
            this.Y1MinorIntervalComboBoxRowLabel.Text = "Minor interval fraction";
            this.Y1MinorIntervalComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MinorIntervalComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MinorIntervalComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MinorIntervalComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MinorIntervalComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorIntervalComboBoxRow.Controls.Add(this.Y1MinorIntervalComboBoxRowLabel);
            this.Y1MinorIntervalComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MinorIntervalComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MinorIntervalComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MinorIntervalComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorIntervalComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorIntervalComboBoxRow.Controls.Add(this.Y1MinorIntervalComboBox);
            this.gYMinorOptionsRow.Controls.Add(this.Y1MinorIntervalComboBoxRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYMinorOptionsRow, 0, 6);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.gYMinorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.gYMinorStrokeRow.Name = "gYMinorStrokeRow";
            this.gYMinorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gYMinorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.gYMinorStrokeRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.gYMinorStrokeRow.ColumnCount = 2;
            this.gYMinorStrokeRow.RowCount = 1;
            this.gYMinorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gYMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.gYMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0000F));
            this.Y1MinorLineWidthComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MinorLineWidthComboBoxRow.Name = "Y1MinorLineWidthComboBoxRow";
            this.Y1MinorLineWidthComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinorLineWidthComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorLineWidthComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MinorLineWidthComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinorLineWidthComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MinorLineWidthComboBoxRowLabel.Name = "Y1MinorLineWidthComboBoxRowLabel";
            this.Y1MinorLineWidthComboBoxRowLabel.Text = "Minor grid width";
            this.Y1MinorLineWidthComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MinorLineWidthComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MinorLineWidthComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MinorLineWidthComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MinorLineWidthComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorLineWidthComboBoxRow.Controls.Add(this.Y1MinorLineWidthComboBoxRowLabel);
            this.Y1MinorLineWidthComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MinorLineWidthComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MinorLineWidthComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MinorLineWidthComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorLineWidthComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorLineWidthComboBoxRow.Controls.Add(this.Y1MinorLineWidthComboBox);
            this.gYMinorStrokeRow.Controls.Add(this.Y1MinorLineWidthComboBoxRow, 0, 0);
            this.Y1MinorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MinorColorComboBoxRow.Name = "Y1MinorColorComboBoxRow";
            this.Y1MinorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorColorComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MinorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinorColorComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MinorColorComboBoxRowLabel.Name = "Y1MinorColorComboBoxRowLabel";
            this.Y1MinorColorComboBoxRowLabel.Text = "Minor grid color";
            this.Y1MinorColorComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MinorColorComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MinorColorComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MinorColorComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MinorColorComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorColorComboBoxRow.Controls.Add(this.Y1MinorColorComboBoxRowLabel);
            this.Y1MinorColorComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MinorColorComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MinorColorComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MinorColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorColorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorColorComboBoxRow.Controls.Add(this.Y1MinorColorComboBox);
            this.gYMinorStrokeRow.Controls.Add(this.Y1MinorColorComboBoxRow, 1, 0);
            this.yAxisSettingsPanel.Controls.Add(this.gYMinorStrokeRow, 0, 7);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.Y1MinorDashStyleComboBoxRow = new System.Windows.Forms.Panel();
            this.Y1MinorDashStyleComboBoxRow.Name = "Y1MinorDashStyleComboBoxRow";
            this.Y1MinorDashStyleComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y1MinorDashStyleComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorDashStyleComboBoxRow.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y1MinorDashStyleComboBoxRow.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Y1MinorDashStyleComboBoxRowLabel = new System.Windows.Forms.Label();
            this.Y1MinorDashStyleComboBoxRowLabel.Name = "Y1MinorDashStyleComboBoxRowLabel";
            this.Y1MinorDashStyleComboBoxRowLabel.Text = "Minor grid dash style";
            this.Y1MinorDashStyleComboBoxRowLabel.ForeColor = System.Drawing.Color.White;
            this.Y1MinorDashStyleComboBoxRowLabel.Location = new System.Drawing.Point(5, 4);
            this.Y1MinorDashStyleComboBoxRowLabel.Size = new System.Drawing.Size(190, 22);
            this.Y1MinorDashStyleComboBoxRowLabel.AutoEllipsis = true;
            this.Y1MinorDashStyleComboBoxRowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorDashStyleComboBoxRow.Controls.Add(this.Y1MinorDashStyleComboBoxRowLabel);
            this.Y1MinorDashStyleComboBox.Location = new System.Drawing.Point(5, 31);
            this.Y1MinorDashStyleComboBox.Size = new System.Drawing.Size(190, 30);
            this.Y1MinorDashStyleComboBox.Dock = System.Windows.Forms.DockStyle.None;
            this.Y1MinorDashStyleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.Y1MinorDashStyleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Y1MinorDashStyleComboBoxRow.Controls.Add(this.Y1MinorDashStyleComboBox);
            this.yAxisSettingsPanel.Controls.Add(this.Y1MinorDashStyleComboBoxRow, 0, 8);
            this.yAxisSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // Designer-owned action toolbar. Allow horizontal scroll on narrow windows / high DPI.
            this.settingsActionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.settingsActionsPanel.Name = "settingsActionsPanel";
            this.settingsActionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsActionsPanel.Height = 83;
            this.settingsActionsPanel.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            this.settingsActionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.settingsActionsPanel.WrapContents = false;
            this.settingsActionsPanel.AutoScroll = true;
            this.settingsActionsPanel.Padding = new System.Windows.Forms.Padding(8, 10, 8, 6);
            this.applyChartSettingsButton.Size = new System.Drawing.Size(190, 48);
            this.applyChartSettingsButton.MinimumSize = new System.Drawing.Size(190, 48);
            this.applyChartSettingsButton.AutoSize = false;
            this.applyChartSettingsButton.Margin = new System.Windows.Forms.Padding(4, 2, 8, 2);
            this.applyChartSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.applyChartSettingsButton.ForeColor = System.Drawing.Color.White;
            this.applyAndClearChartsButton.Size = new System.Drawing.Size(230, 48);
            this.applyAndClearChartsButton.MinimumSize = new System.Drawing.Size(230, 48);
            this.applyAndClearChartsButton.AutoSize = false;
            this.applyAndClearChartsButton.Text = "Clear Charts and Apply";
            this.applyAndClearChartsButton.Margin = new System.Windows.Forms.Padding(4, 2, 8, 2);
            this.LoadCurrentValuesButton.Size = new System.Drawing.Size(230, 48);
            this.LoadCurrentValuesButton.MinimumSize = new System.Drawing.Size(230, 48);
            this.LoadCurrentValuesButton.AutoSize = false;
            this.LoadCurrentValuesButton.Margin = new System.Windows.Forms.Padding(4, 2, 8, 2);
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            this.SettingsProfilesHost.Size = new System.Drawing.Size(165, 48);
            this.SettingsProfilesHost.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.settingsActionsPanel.Controls.Add(this.applyChartSettingsButton);
            this.settingsActionsPanel.Controls.Add(this.applyAndClearChartsButton);
            this.settingsActionsPanel.Controls.Add(this.LoadCurrentValuesButton);
            this.settingsActionsPanel.Controls.Add(this.SettingsProfilesHost);
            this.Controls.Add(this.settingsSectionsLayout);
            this.Controls.Add(this.settingsActionsPanel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormGForceSettings";
            this.Text = "FormGForceSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGForceSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormGForceSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // The top-level containers are intentionally declared in the Designer.
        // Open View > Other Windows > Document Outline to move controls between sections.
        private System.Windows.Forms.FlowLayoutPanel settingsActionsPanel;
        private System.Windows.Forms.Panel SettingsProfilesHost;
        private System.Windows.Forms.Panel DefaultsCheckBoxRow;
        private System.Windows.Forms.TableLayoutPanel gSidebarColorsRow;
        private System.Windows.Forms.Panel BackgroundColorComboBoxRow;
        private System.Windows.Forms.Label BackgroundColorComboBoxRowLabel;
        private System.Windows.Forms.Panel MarkerColorComboBoxRow;
        private System.Windows.Forms.Label MarkerColorComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gSidebarHistoryRow;
        private System.Windows.Forms.Panel HistoryAmountPointsMaskedTextBoxRow;
        private System.Windows.Forms.Label HistoryAmountPointsMaskedTextBoxRowLabel;
        private System.Windows.Forms.Panel InfiniteHistoryCheckBoxRow;
        private System.Windows.Forms.Panel SchemeComboBoxRow;
        private System.Windows.Forms.Label SchemeComboBoxRowLabel;
        private System.Windows.Forms.Panel X1DefaultsCheckBoxRow;
        private System.Windows.Forms.Panel X1AngleTypeComboBoxRow;
        private System.Windows.Forms.Label X1AngleTypeComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gXFontRow;
        private System.Windows.Forms.Panel X1FontSizeComboBoxRow;
        private System.Windows.Forms.Label X1FontSizeComboBoxRowLabel;
        private System.Windows.Forms.Panel X1ComboBoxFontsRow;
        private System.Windows.Forms.Label X1ComboBoxFontsRowLabel;
        private System.Windows.Forms.TableLayoutPanel gXFontStyleRow;
        private System.Windows.Forms.Panel X1FontStyleComboBoxRow;
        private System.Windows.Forms.Label X1FontStyleComboBoxRowLabel;
        private System.Windows.Forms.Panel X1FontColorComboBoxRow;
        private System.Windows.Forms.Label X1FontColorComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gXMajorStrokeRow;
        private System.Windows.Forms.Panel X1MajorLineWidthComboBoxRow;
        private System.Windows.Forms.Label X1MajorLineWidthComboBoxRowLabel;
        private System.Windows.Forms.Panel X1MajorIntervalFractionComboBoxRow;
        private System.Windows.Forms.Label X1MajorIntervalFractionComboBoxRowLabel;
        private System.Windows.Forms.Panel X1MajorColorComboBoxRow;
        private System.Windows.Forms.Label X1MajorColorComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gXMinorOptionsRow;
        private System.Windows.Forms.Panel X1MinorEnabledCheckBoxRow;
        private System.Windows.Forms.Panel X1MinorIntervalComboBoxRow;
        private System.Windows.Forms.Label X1MinorIntervalComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gXMinorStrokeRow;
        private System.Windows.Forms.Panel X1MinorLineWidthComboBoxRow;
        private System.Windows.Forms.Label X1MinorLineWidthComboBoxRowLabel;
        private System.Windows.Forms.Panel X1MinorColorComboBoxRow;
        private System.Windows.Forms.Label X1MinorColorComboBoxRowLabel;
        private System.Windows.Forms.Panel X1MinorDashStyleComboBoxRow;
        private System.Windows.Forms.Label X1MinorDashStyleComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1DefaultsCheckBoxRow;
        private System.Windows.Forms.TableLayoutPanel gYLimitsRow;
        private System.Windows.Forms.Panel Y1MinMaskedTextBoxRow;
        private System.Windows.Forms.Label Y1MinMaskedTextBoxRowLabel;
        private System.Windows.Forms.Panel Y1MaxMaskedTextBoxRow;
        private System.Windows.Forms.Label Y1MaxMaskedTextBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gYFontRow;
        private System.Windows.Forms.Panel Y1FontSizeComboBoxRow;
        private System.Windows.Forms.Label Y1FontSizeComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1ComboBoxFontsRow;
        private System.Windows.Forms.Label Y1ComboBoxFontsRowLabel;
        private System.Windows.Forms.TableLayoutPanel gYFontStyleRow;
        private System.Windows.Forms.Panel Y1FontStyleComboBoxRow;
        private System.Windows.Forms.Label Y1FontStyleComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1FontColorComboBoxRow;
        private System.Windows.Forms.Label Y1FontColorComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gYMajorStrokeRow;
        private System.Windows.Forms.Panel Y1MajorLineWidthComboBoxRow;
        private System.Windows.Forms.Label Y1MajorLineWidthComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1MajorDecimalsComboBoxRow;
        private System.Windows.Forms.Label Y1MajorDecimalsComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gYMajorStyleRow;
        private System.Windows.Forms.Panel Y1MajorIntervalDividerComboBoxRow;
        private System.Windows.Forms.Label Y1MajorIntervalDividerComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1MajorColorComboBoxRow;
        private System.Windows.Forms.Label Y1MajorColorComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gYMinorOptionsRow;
        private System.Windows.Forms.Panel Y1MinorEnabledCheckBoxRow;
        private System.Windows.Forms.Panel Y1MinorIntervalComboBoxRow;
        private System.Windows.Forms.Label Y1MinorIntervalComboBoxRowLabel;
        private System.Windows.Forms.TableLayoutPanel gYMinorStrokeRow;
        private System.Windows.Forms.Panel Y1MinorLineWidthComboBoxRow;
        private System.Windows.Forms.Label Y1MinorLineWidthComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1MinorColorComboBoxRow;
        private System.Windows.Forms.Label Y1MinorColorComboBoxRowLabel;
        private System.Windows.Forms.Panel Y1MinorDashStyleComboBoxRow;
        private System.Windows.Forms.Label Y1MinorDashStyleComboBoxRowLabel;

        private System.Windows.Forms.TableLayoutPanel settingsSectionsLayout;
        private System.Windows.Forms.GroupBox settingsSidebarGroup;
        internal System.Windows.Forms.TableLayoutPanel settingsSidebarPanel;
        private System.Windows.Forms.GroupBox xAxisSettingsGroup;
        private System.Windows.Forms.TableLayoutPanel xAxisSettingsPanel;
        private System.Windows.Forms.GroupBox yAxisSettingsGroup;
        private System.Windows.Forms.TableLayoutPanel yAxisSettingsPanel;

        public System.Windows.Forms.ComboBox MarkerColorComboBox;
        public System.Windows.Forms.Button LoadCurrentValuesButton;
        public System.Windows.Forms.CheckBox DefaultsCheckBox;
        public System.Windows.Forms.ComboBox BackgroundColorComboBox;
        public System.Windows.Forms.Button applyChartSettingsButton;
        public System.Windows.Forms.Button applyAndClearChartsButton;
        private System.Windows.Forms.TextBox X1MajorIntervalFractionTextBox;
        public System.Windows.Forms.ComboBox X1MinorLineWidthComboBox;
        public System.Windows.Forms.ComboBox X1MajorColorComboBox;
        public System.Windows.Forms.ComboBox X1MajorLineWidthComboBox;
        public System.Windows.Forms.CheckBox X1MinorEnabledCheckBox;
        public System.Windows.Forms.ComboBox X1MinorDashStyleComboBox;
        public System.Windows.Forms.ComboBox X1MinorColorComboBox;
        public System.Windows.Forms.ComboBox X1MinorIntervalComboBox;
        public System.Windows.Forms.ComboBox X1FontColorComboBox;
        public System.Windows.Forms.ComboBox X1FontStyleComboBox;
        public System.Windows.Forms.ComboBox X1FontSizeComboBox;
        public System.Windows.Forms.ComboBox X1ComboBoxFonts;
        public System.Windows.Forms.CheckBox X1DefaultsCheckBox;
        public System.Windows.Forms.ComboBox X1AngleTypeComboBox;
        private System.Windows.Forms.TextBox Y1IntervalDividerTextBox;
        public System.Windows.Forms.ComboBox Y1MinorLineWidthComboBox;
        public System.Windows.Forms.MaskedTextBox Y1MaxMaskedTextBox;
        public System.Windows.Forms.ComboBox Y1MajorColorComboBox;
        public System.Windows.Forms.ComboBox Y1MajorLineWidthComboBox;
        public System.Windows.Forms.CheckBox Y1MinorEnabledCheckBox;
        public System.Windows.Forms.ComboBox Y1MinorDashStyleComboBox;
        public System.Windows.Forms.ComboBox Y1MinorColorComboBox;
        public System.Windows.Forms.ComboBox Y1MinorIntervalComboBox;
        public System.Windows.Forms.ComboBox Y1MajorDecimalsComboBox;
        public System.Windows.Forms.MaskedTextBox Y1MinMaskedTextBox;
        public System.Windows.Forms.ComboBox Y1FontColorComboBox;
        public System.Windows.Forms.ComboBox Y1FontStyleComboBox;
        public System.Windows.Forms.ComboBox Y1FontSizeComboBox;
        public System.Windows.Forms.ComboBox Y1ComboBoxFonts;
        public System.Windows.Forms.CheckBox Y1DefaultsCheckBox;
        public System.Windows.Forms.MaskedTextBox HistoryAmountPointsMaskedTextBox;
        public System.Windows.Forms.CheckBox InfiniteHistoryCheckBox;
        public System.Windows.Forms.ComboBox SchemeComboBox;
        public System.Windows.Forms.ComboBox Y1MajorIntervalDividerComboBox;
        public System.Windows.Forms.ComboBox X1MajorIntervalFractionComboBox;
    }
}
