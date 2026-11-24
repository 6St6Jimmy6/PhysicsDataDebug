namespace Physics_Data_Debug
{
    partial class ChartLimiterRow
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label axisLabel;
        private System.Windows.Forms.CheckBox filterEnabledCheckBox;
        private System.Windows.Forms.ComboBox selectionComboBox;
        private System.Windows.Forms.TextBox minimumTextBox;
        private System.Windows.Forms.TextBox maximumTextBox;
        private System.Windows.Forms.Button defaultsButton;
        private System.Windows.Forms.Label minimumLabel;
        private System.Windows.Forms.Label maximumLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.axisLabel = new System.Windows.Forms.Label();
            this.filterEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.selectionComboBox = new System.Windows.Forms.ComboBox();
            this.minimumTextBox = new System.Windows.Forms.TextBox();
            this.maximumTextBox = new System.Windows.Forms.TextBox();
            this.defaultsButton = new System.Windows.Forms.Button();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // axisLabel
            // 
            this.axisLabel.AutoSize = true;
            this.axisLabel.ForeColor = System.Drawing.Color.White;
            this.axisLabel.Location = new System.Drawing.Point(3, 0);
            this.axisLabel.Name = "axisLabel";
            this.axisLabel.Size = new System.Drawing.Size(53, 13);
            this.axisLabel.TabIndex = 0;
            this.axisLabel.Text = "Extra filter";
            // 
            // filterEnabledCheckBox
            // 
            this.filterEnabledCheckBox.AutoSize = true;
            this.filterEnabledCheckBox.ForeColor = System.Drawing.Color.White;
            this.filterEnabledCheckBox.Location = new System.Drawing.Point(6, 17);
            this.filterEnabledCheckBox.Name = "filterEnabledCheckBox";
            this.filterEnabledCheckBox.Size = new System.Drawing.Size(59, 17);
            this.filterEnabledCheckBox.TabIndex = 1;
            this.filterEnabledCheckBox.Text = "Enable";
            this.filterEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectionComboBox
            // 
            this.selectionComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.selectionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectionComboBox.ForeColor = System.Drawing.Color.White;
            this.selectionComboBox.FormattingEnabled = true;
            this.selectionComboBox.Location = new System.Drawing.Point(76, 13);
            this.selectionComboBox.Name = "selectionComboBox";
            this.selectionComboBox.Size = new System.Drawing.Size(268, 21);
            this.selectionComboBox.TabIndex = 2;
            // 
            // minimumTextBox
            // 
            this.minimumTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.minimumTextBox.ForeColor = System.Drawing.Color.White;
            this.minimumTextBox.Location = new System.Drawing.Point(36, 39);
            this.minimumTextBox.Name = "minimumTextBox";
            this.minimumTextBox.Size = new System.Drawing.Size(76, 20);
            this.minimumTextBox.TabIndex = 4;
            // 
            // maximumTextBox
            // 
            this.maximumTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.maximumTextBox.ForeColor = System.Drawing.Color.White;
            this.maximumTextBox.Location = new System.Drawing.Point(155, 39);
            this.maximumTextBox.Name = "maximumTextBox";
            this.maximumTextBox.Size = new System.Drawing.Size(76, 20);
            this.maximumTextBox.TabIndex = 6;
            // 
            // defaultsButton
            // 
            this.defaultsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.defaultsButton.ForeColor = System.Drawing.Color.White;
            this.defaultsButton.Location = new System.Drawing.Point(242, 37);
            this.defaultsButton.Name = "defaultsButton";
            this.defaultsButton.Size = new System.Drawing.Size(102, 25);
            this.defaultsButton.TabIndex = 7;
            this.defaultsButton.Text = "Defaults";
            this.defaultsButton.UseVisualStyleBackColor = false;
            // 
            // minimumLabel
            // 
            this.minimumLabel.AutoSize = true;
            this.minimumLabel.ForeColor = System.Drawing.Color.White;
            this.minimumLabel.Location = new System.Drawing.Point(6, 43);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(24, 13);
            this.minimumLabel.TabIndex = 3;
            this.minimumLabel.Text = "Min";
            // 
            // maximumLabel
            // 
            this.maximumLabel.AutoSize = true;
            this.maximumLabel.ForeColor = System.Drawing.Color.White;
            this.maximumLabel.Location = new System.Drawing.Point(122, 43);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(27, 13);
            this.maximumLabel.TabIndex = 5;
            this.maximumLabel.Text = "Max";
            // 
            // ChartLimiterRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.axisLabel);
            this.Controls.Add(this.filterEnabledCheckBox);
            this.Controls.Add(this.selectionComboBox);
            this.Controls.Add(this.minimumLabel);
            this.Controls.Add(this.minimumTextBox);
            this.Controls.Add(this.maximumLabel);
            this.Controls.Add(this.maximumTextBox);
            this.Controls.Add(this.defaultsButton);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChartLimiterRow";
            this.Size = new System.Drawing.Size(355, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
