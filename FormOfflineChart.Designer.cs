using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    partial class FormOfflineChart
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Panel toolbarPanel, dataSelectPanel, SettingsProfilesHost;
        private TableLayoutPanel toolbarLayout;
        private FlowLayoutPanel toolbarButtonsFlow;
        private Button importFilesButton, removeFilesButton, settingsButton;
        private CheckedListBox importedFilesList;
        private Label statusLabel, datasetsLabel;
        private SplitContainer chartAndLegend;
        private Chart chart1, GradientChart;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.toolbarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarButtonsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.importFilesButton = new System.Windows.Forms.Button();
            this.removeFilesButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.dataSelectPanel = new System.Windows.Forms.Panel();
            this.importedFilesList = new System.Windows.Forms.CheckedListBox();
            this.datasetsLabel = new System.Windows.Forms.Label();
            this.chartAndLegend = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GradientChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.toolbarLayout.SuspendLayout();
            this.toolbarButtonsFlow.SuspendLayout();
            this.dataSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAndLegend)).BeginInit();
            this.chartAndLegend.Panel1.SuspendLayout();
            this.chartAndLegend.Panel2.SuspendLayout();
            this.chartAndLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.toolbarPanel, 0, 0);
            this.mainLayout.Controls.Add(this.chartAndLegend, 0, 1);
            this.mainLayout.Controls.Add(this.statusLabel, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(5);
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayout.Size = new System.Drawing.Size(1164, 1009);
            this.mainLayout.TabIndex = 0;
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolbarPanel.Controls.Add(this.toolbarLayout);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarPanel.Location = new System.Drawing.Point(8, 8);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(1148, 104);
            this.toolbarPanel.TabIndex = 0;
            // 
            // toolbarLayout
            // 
            this.toolbarLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolbarLayout.ColumnCount = 2;
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.toolbarLayout.Controls.Add(this.toolbarButtonsFlow, 0, 0);
            this.toolbarLayout.Controls.Add(this.dataSelectPanel, 0, 1);
            this.toolbarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarLayout.Location = new System.Drawing.Point(0, 0);
            this.toolbarLayout.Margin = new System.Windows.Forms.Padding(0);
            this.toolbarLayout.Name = "toolbarLayout";
            this.toolbarLayout.RowCount = 2;
            this.toolbarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.toolbarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolbarLayout.Size = new System.Drawing.Size(1148, 104);
            this.toolbarLayout.TabIndex = 0;
            // 
            // toolbarButtonsFlow
            // 
            this.toolbarButtonsFlow.AutoScroll = true;
            this.toolbarButtonsFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolbarButtonsFlow.Controls.Add(this.importFilesButton);
            this.toolbarButtonsFlow.Controls.Add(this.removeFilesButton);
            this.toolbarButtonsFlow.Controls.Add(this.settingsButton);
            this.toolbarButtonsFlow.Controls.Add(this.SettingsProfilesHost);
            this.toolbarButtonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarButtonsFlow.Location = new System.Drawing.Point(0, 0);
            this.toolbarButtonsFlow.Margin = new System.Windows.Forms.Padding(0);
            this.toolbarButtonsFlow.Name = "toolbarButtonsFlow";
            this.toolbarButtonsFlow.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolbarButtonsFlow.Size = new System.Drawing.Size(974, 47);
            this.toolbarButtonsFlow.TabIndex = 0;
            this.toolbarButtonsFlow.WrapContents = false;
            // 
            // importFilesButton
            // 
            this.importFilesButton.AutoSize = true;
            this.importFilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.importFilesButton.ForeColor = System.Drawing.Color.White;
            this.importFilesButton.Location = new System.Drawing.Point(8, 7);
            this.importFilesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 3);
            this.importFilesButton.Name = "importFilesButton";
            this.importFilesButton.Padding = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.importFilesButton.Size = new System.Drawing.Size(135, 34);
            this.importFilesButton.TabIndex = 0;
            this.importFilesButton.Text = "Load CSV / TXT...";
            this.importFilesButton.UseVisualStyleBackColor = false;
            this.importFilesButton.Click += new System.EventHandler(this.ImportFilesButton_Click);
            // 
            // removeFilesButton
            // 
            this.removeFilesButton.AutoSize = true;
            this.removeFilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.removeFilesButton.ForeColor = System.Drawing.Color.White;
            this.removeFilesButton.Location = new System.Drawing.Point(151, 7);
            this.removeFilesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 3);
            this.removeFilesButton.Name = "removeFilesButton";
            this.removeFilesButton.Padding = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.removeFilesButton.Size = new System.Drawing.Size(140, 34);
            this.removeFilesButton.TabIndex = 1;
            this.removeFilesButton.Text = "Remove selected";
            this.removeFilesButton.UseVisualStyleBackColor = false;
            this.removeFilesButton.Click += new System.EventHandler(this.RemoveFilesButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.AutoSize = true;
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(299, 7);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Padding = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.settingsButton.Size = new System.Drawing.Size(125, 34);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.Text = "Chart settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsProfilesHost.Location = new System.Drawing.Point(434, 5);
            this.SettingsProfilesHost.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Size = new System.Drawing.Size(162, 36);
            this.SettingsProfilesHost.TabIndex = 4;
            // 
            // dataSelectPanel
            // 
            this.toolbarLayout.SetColumnSpan(this.dataSelectPanel, 2);
            this.dataSelectPanel.Controls.Add(this.importedFilesList);
            this.dataSelectPanel.Controls.Add(this.datasetsLabel);
            this.dataSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSelectPanel.Location = new System.Drawing.Point(10, 47);
            this.dataSelectPanel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.dataSelectPanel.Name = "dataSelectPanel";
            this.dataSelectPanel.Size = new System.Drawing.Size(1128, 57);
            this.dataSelectPanel.TabIndex = 5;
            // 
            // importedFilesList
            // 
            this.importedFilesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.importedFilesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.importedFilesList.CheckOnClick = true;
            this.importedFilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importedFilesList.ForeColor = System.Drawing.Color.White;
            this.importedFilesList.HorizontalScrollbar = true;
            this.importedFilesList.IntegralHeight = false;
            this.importedFilesList.Location = new System.Drawing.Point(0, 20);
            this.importedFilesList.Name = "importedFilesList";
            this.importedFilesList.Size = new System.Drawing.Size(1128, 37);
            this.importedFilesList.TabIndex = 0;
            // 
            // datasetsLabel
            // 
            this.datasetsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.datasetsLabel.ForeColor = System.Drawing.Color.White;
            this.datasetsLabel.Location = new System.Drawing.Point(0, 0);
            this.datasetsLabel.Name = "datasetsLabel";
            this.datasetsLabel.Size = new System.Drawing.Size(1128, 20);
            this.datasetsLabel.TabIndex = 1;
            this.datasetsLabel.Text = "Imported files (check to display):";
            // 
            // chartAndLegend
            // 
            this.chartAndLegend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chartAndLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAndLegend.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.chartAndLegend.Location = new System.Drawing.Point(8, 118);
            this.chartAndLegend.Name = "chartAndLegend";
            // 
            // chartAndLegend.Panel1
            // 
            this.chartAndLegend.Panel1.Controls.Add(this.chart1);
            // 
            // chartAndLegend.Panel2
            // 
            this.chartAndLegend.Panel2.Controls.Add(this.GradientChart);
            this.chartAndLegend.Size = new System.Drawing.Size(1148, 851);
            this.chartAndLegend.SplitterDistance = 1044;
            this.chartAndLegend.SplitterWidth = 6;
            this.chartAndLegend.TabIndex = 3;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.MinimumSize = new System.Drawing.Size(10, 10);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1044, 851);
            this.chart1.TabIndex = 0;
            // 
            // GradientChart
            // 
            this.GradientChart.BackColor = System.Drawing.Color.Black;
            this.GradientChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GradientChart.Location = new System.Drawing.Point(0, 0);
            this.GradientChart.MinimumSize = new System.Drawing.Size(10, 10);
            this.GradientChart.Name = "GradientChart";
            this.GradientChart.Size = new System.Drawing.Size(98, 851);
            this.GradientChart.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.statusLabel.Location = new System.Drawing.Point(8, 972);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(1148, 32);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Load one or more delimited telemetry files to begin.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormOfflineChart
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(1164, 1009);
            this.Controls.Add(this.mainLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(880, 680);
            this.Name = "FormOfflineChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offline Four Wheels / CSV Chart";
            this.mainLayout.ResumeLayout(false);
            this.toolbarPanel.ResumeLayout(false);
            this.toolbarLayout.ResumeLayout(false);
            this.toolbarButtonsFlow.ResumeLayout(false);
            this.toolbarButtonsFlow.PerformLayout();
            this.dataSelectPanel.ResumeLayout(false);
            this.chartAndLegend.Panel1.ResumeLayout(false);
            this.chartAndLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAndLegend)).EndInit();
            this.chartAndLegend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradientChart)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
