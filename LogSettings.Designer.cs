
namespace Physics_Data_Debug
{
    partial class Log_Settings
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
            this.closeLogSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectAll = new System.Windows.Forms.CheckBox();
            this.checkedListBoxLogging = new System.Windows.Forms.CheckedListBox();
            this.SelectedListBox = new System.Windows.Forms.ListBox();
            this.SelectedIndeciesListBox = new System.Windows.Forms.ListBox();
            this.FLApplyLogSettings = new System.Windows.Forms.Button();
            this.checkBoxFiltersOn = new System.Windows.Forms.CheckBox();
            this.textBox_Z1 = new System.Windows.Forms.TextBox();
            this.textBox_Z2 = new System.Windows.Forms.TextBox();
            this.textBox_Z3 = new System.Windows.Forms.TextBox();
            this.textBox_Z4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_W4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_W1 = new System.Windows.Forms.TextBox();
            this.textBox_W2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // closeLogSettings
            // 
            this.closeLogSettings.Location = new System.Drawing.Point(13, 13);
            this.closeLogSettings.Name = "closeLogSettings";
            this.closeLogSettings.Size = new System.Drawing.Size(75, 43);
            this.closeLogSettings.TabIndex = 0;
            this.closeLogSettings.Text = "Close Log Settings";
            this.closeLogSettings.UseVisualStyleBackColor = true;
            this.closeLogSettings.Click += new System.EventHandler(this.backToFirstAllDataLoggerPage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tire Logging Selections";
            // 
            // selectAll
            // 
            this.selectAll.AutoSize = true;
            this.selectAll.Location = new System.Drawing.Point(126, 39);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(70, 17);
            this.selectAll.TabIndex = 18;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.CheckedChanged += new System.EventHandler(this.selectFLAll_CheckedChanged);
            // 
            // checkedListBoxLogging
            // 
            this.checkedListBoxLogging.FormattingEnabled = true;
            this.checkedListBoxLogging.Items.AddRange(new object[] {
            "Tire Travel Speed",
            "Angular Velocity",
            "Vertical Load",
            "Vertical Deflection",
            "Loaded Radius",
            "Effective Radius",
            "Contact Length",
            "Braking Torque",
            "Steer Angle",
            "Camber Angle",
            "Lateral Load",
            "Slip Angle",
            "Lateral Friction",
            "Lateral Slip Speed",
            "Longitudinal Load",
            "Slip Ratio",
            "Longitudinal Friction",
            "Longitudinal Slip Speed",
            "Tread Temperature",
            "Inner Temperature",
            "Race Time",
            "Total Friction",
            "Total Friction Angle"});
            this.checkedListBoxLogging.Location = new System.Drawing.Point(126, 62);
            this.checkedListBoxLogging.Name = "checkedListBoxLogging";
            this.checkedListBoxLogging.Size = new System.Drawing.Size(203, 349);
            this.checkedListBoxLogging.TabIndex = 19;
            this.checkedListBoxLogging.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxFLLogging_SelectedIndexChanged);
            // 
            // SelectedListBox
            // 
            this.SelectedListBox.FormattingEnabled = true;
            this.SelectedListBox.Location = new System.Drawing.Point(126, 420);
            this.SelectedListBox.Name = "SelectedListBox";
            this.SelectedListBox.Size = new System.Drawing.Size(115, 56);
            this.SelectedListBox.TabIndex = 20;
            // 
            // SelectedIndeciesListBox
            // 
            this.SelectedIndeciesListBox.FormattingEnabled = true;
            this.SelectedIndeciesListBox.Location = new System.Drawing.Point(247, 420);
            this.SelectedIndeciesListBox.Name = "SelectedIndeciesListBox";
            this.SelectedIndeciesListBox.Size = new System.Drawing.Size(82, 56);
            this.SelectedIndeciesListBox.TabIndex = 21;
            // 
            // FLApplyLogSettings
            // 
            this.FLApplyLogSettings.Location = new System.Drawing.Point(13, 72);
            this.FLApplyLogSettings.Name = "FLApplyLogSettings";
            this.FLApplyLogSettings.Size = new System.Drawing.Size(75, 39);
            this.FLApplyLogSettings.TabIndex = 22;
            this.FLApplyLogSettings.Text = "Apply";
            this.FLApplyLogSettings.UseVisualStyleBackColor = true;
            this.FLApplyLogSettings.Click += new System.EventHandler(this.ApplyLogSettings_Click);
            // 
            // checkBoxFiltersOn
            // 
            this.checkBoxFiltersOn.AutoSize = true;
            this.checkBoxFiltersOn.Location = new System.Drawing.Point(378, 39);
            this.checkBoxFiltersOn.Name = "checkBoxFiltersOn";
            this.checkBoxFiltersOn.Size = new System.Drawing.Size(68, 17);
            this.checkBoxFiltersOn.TabIndex = 23;
            this.checkBoxFiltersOn.Text = "Filters on";
            this.checkBoxFiltersOn.UseVisualStyleBackColor = true;
            this.checkBoxFiltersOn.CheckedChanged += new System.EventHandler(this.checkBoxFiltersOn_CheckedChanged);
            // 
            // textBox_Z1
            // 
            this.textBox_Z1.Location = new System.Drawing.Point(703, 65);
            this.textBox_Z1.Name = "textBox_Z1";
            this.textBox_Z1.Size = new System.Drawing.Size(100, 20);
            this.textBox_Z1.TabIndex = 25;
            this.textBox_Z1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Z1_KeyPress);
            // 
            // textBox_Z2
            // 
            this.textBox_Z2.Location = new System.Drawing.Point(703, 91);
            this.textBox_Z2.Name = "textBox_Z2";
            this.textBox_Z2.Size = new System.Drawing.Size(100, 20);
            this.textBox_Z2.TabIndex = 26;
            this.textBox_Z2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Z2_KeyPress);
            // 
            // textBox_Z3
            // 
            this.textBox_Z3.Location = new System.Drawing.Point(703, 117);
            this.textBox_Z3.Name = "textBox_Z3";
            this.textBox_Z3.Size = new System.Drawing.Size(100, 20);
            this.textBox_Z3.TabIndex = 27;
            this.textBox_Z3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Z3_KeyPress);
            // 
            // textBox_Z4
            // 
            this.textBox_Z4.Location = new System.Drawing.Point(703, 143);
            this.textBox_Z4.Name = "textBox_Z4";
            this.textBox_Z4.Size = new System.Drawing.Size(100, 20);
            this.textBox_Z4.TabIndex = 28;
            this.textBox_Z4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Z4_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Slip Ratio (0-1) include only:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Slip Angle (°) include only:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Tire Travel Speed (m/s) exclude all:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Vertical Load (N) include only:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(657, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "up to ±";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(564, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "0                             up to ±";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(657, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "up to ±";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(657, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "up to ±";
            // 
            // textBox_W4
            // 
            this.textBox_W4.Location = new System.Drawing.Point(565, 143);
            this.textBox_W4.Name = "textBox_W4";
            this.textBox_W4.Size = new System.Drawing.Size(81, 20);
            this.textBox_W4.TabIndex = 37;
            this.textBox_W4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_W4_Keypress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(522, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "both ±";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(522, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "both ±";
            // 
            // textBox_W1
            // 
            this.textBox_W1.Location = new System.Drawing.Point(565, 65);
            this.textBox_W1.Name = "textBox_W1";
            this.textBox_W1.Size = new System.Drawing.Size(81, 20);
            this.textBox_W1.TabIndex = 41;
            this.textBox_W1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_W1_KeyPress);
            // 
            // textBox_W2
            // 
            this.textBox_W2.Location = new System.Drawing.Point(565, 91);
            this.textBox_W2.Name = "textBox_W2";
            this.textBox_W2.Size = new System.Drawing.Size(81, 20);
            this.textBox_W2.TabIndex = 42;
            this.textBox_W2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_W2_KeyPress);
            // 
            // Log_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 512);
            this.Controls.Add(this.textBox_W2);
            this.Controls.Add(this.textBox_W1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_W4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Z4);
            this.Controls.Add(this.textBox_Z3);
            this.Controls.Add(this.textBox_Z2);
            this.Controls.Add(this.textBox_Z1);
            this.Controls.Add(this.checkBoxFiltersOn);
            this.Controls.Add(this.FLApplyLogSettings);
            this.Controls.Add(this.SelectedIndeciesListBox);
            this.Controls.Add(this.SelectedListBox);
            this.Controls.Add(this.checkedListBoxLogging);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeLogSettings);
            this.Name = "Log_Settings";
            this.Text = "Log Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_Closed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeLogSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox selectAll;
        private System.Windows.Forms.CheckedListBox checkedListBoxLogging;
        private System.Windows.Forms.ListBox SelectedListBox;
        private System.Windows.Forms.ListBox SelectedIndeciesListBox;
        private System.Windows.Forms.Button FLApplyLogSettings;
        private System.Windows.Forms.CheckBox checkBoxFiltersOn;
        private System.Windows.Forms.TextBox textBox_Z1;
        private System.Windows.Forms.TextBox textBox_Z2;
        private System.Windows.Forms.TextBox textBox_Z3;
        private System.Windows.Forms.TextBox textBox_Z4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_W4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_W1;
        private System.Windows.Forms.TextBox textBox_W2;
    }
}