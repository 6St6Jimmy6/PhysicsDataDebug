using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLiveData
    {
        // Main layout, sidebar sections, wheel cards and individual measurement
        // rows are now real controls in FormLiveData.Designer.cs. The Designer
        // shows them and can edit their positions and dimensions.
        private const int DebugInitialWidth = 360;
        private const int WheelGap = 6;

        private void InitializeDesignerLayoutBehavior()
        {
            // These bindings change positions/sizes within the existing
            // Designer-owned row panels; they never create or reparent labels.
            foreach (Panel wheel in new[] { panel1, panel2, panel3, panel4 })
                FormRowLayout.BindDesignerTelemetryRows(wheel,
                    captionWidth: 248,
                    rowHeight: FormRowLayout.WheelRowHeight,
                    rowSpacing: FormRowLayout.WheelRowSpacing);

            openOfflineChartButton.Click += (sender, args) =>
            {
                var open = Application.OpenForms.OfType<FormOfflineChart>().FirstOrDefault();
                if (open != null) { open.BringToFront(); open.Activate(); }
                else new FormOfflineChart().Show(this);
            };
#if DEBUG
            toggleDebugWorkspaceButton.Click += (sender, args) =>
                SetDebugWorkspaceVisible(!debugEnabled);
#else
            toggleDebugWorkspaceButton.Visible = false;
#endif

            debugWorkspacePanel.SizeChanged += (sender, args) => FitDebugSections();

            GroupBox[] wheelCards = {
                panel1TelemetryCard, panel2TelemetryCard,
                panel3TelemetryCard, panel4TelemetryCard
            };
            // Respect the wheel-card row height set in the WinForms Designer.
            // Editing fourWheelGrid -> Edit Rows and Columns now changes both
            // the design-time preview and the running application.
            int cellHeight = Math.Max(1,
                (int)Math.Round(fourWheelGrid.RowStyles[0].Height));
            Action fitWheelGrid = () =>
            {
                int width = Math.Max(320, fourWheelScrollPanel.ClientSize.Width - 6);
                int columns = width >= 950 ? 2 : 1;
                if (fourWheelGrid.ColumnCount != columns)
                {
                    fourWheelGrid.SuspendLayout();
                    fourWheelGrid.Controls.Clear();
                    fourWheelGrid.ColumnStyles.Clear();
                    fourWheelGrid.RowStyles.Clear();
                    fourWheelGrid.ColumnCount = columns;
                    fourWheelGrid.RowCount = 4 / columns;
                    for (int c = 0; c < columns; c++)
                        fourWheelGrid.ColumnStyles.Add(
                            new ColumnStyle(SizeType.Percent, 100f / columns));
                    for (int r = 0; r < fourWheelGrid.RowCount; r++)
                        fourWheelGrid.RowStyles.Add(
                            new RowStyle(SizeType.Absolute, cellHeight));
                    for (int i = 0; i < wheelCards.Length; i++)
                        fourWheelGrid.Controls.Add(wheelCards[i],
                            i % columns, i / columns);
                    fourWheelGrid.ResumeLayout(true);
                }
                fourWheelGrid.Size = new Size(width, (4 / columns) * cellHeight);
            };
            fourWheelScrollPanel.SizeChanged += (sender, args) => fitWheelGrid();

            Shown += (sender, args) =>
            {
                // Respect SplitterDistance and Panel1MinSize configured in
                // FormLiveData.Designer.cs (Visual Studio Properties window).
                FitDebugSections();
                SetDebugWorkspaceVisible(debugEnabled);
                fitWheelGrid();
                foreach (Panel wheel in new[] { panel1, panel2, panel3, panel4 })
                    wheel.AutoScrollPosition = Point.Empty;
                fourWheelScrollPanel.AutoScrollPosition = Point.Empty;
            };
        }

        // Sidebar widths now come entirely from the Designer:
        // telemetrySidebarSplitter.SplitterDistance / Panel1MinSize,
        // and sidebarSectionsLayout.Dock = Top.
        // No runtime width overrides or horizontal-scroll adjustments.

        private void FitDebugSections()
        {
            int width = Math.Max(215, debugWorkspacePanel.ClientSize.Width - 22);
            foreach (Control section in debugWorkspacePanel.Controls)
                if (section.Width != width) section.Width = width;
        }

        /// <summary>Show or hide the entire scratch/test workspace.</summary>
        public void SetDebugWorkspaceVisible(bool visible)
        {
            debugEnabled = visible;
            toggleDebugWorkspaceButton.Text = visible ? "Hide debug output" : "Show debug output";
            debugWorkspaceSplitter.Panel2Collapsed = !visible;
            if (visible)
            {
                int desired = debugWorkspaceSplitter.Width - DebugInitialWidth - debugWorkspaceSplitter.SplitterWidth;
                int maximum = debugWorkspaceSplitter.Width - debugWorkspaceSplitter.Panel2MinSize - debugWorkspaceSplitter.SplitterWidth;
                if (maximum >= debugWorkspaceSplitter.Panel1MinSize)
                    debugWorkspaceSplitter.SplitterDistance = Math.Max(debugWorkspaceSplitter.Panel1MinSize,
                        Math.Min(maximum, desired));
            }
            foreach (Control control in new Control[]
            {
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6,
                label16, label17, label22, label23, label37
            })
            {
                // The original heading labels are kept hidden: GroupBox.Text
                // now supplies the visible heading, including at design time.
                if (control is TextBox box)
                {
                    control.Visible = visible;
                    box.Enabled = visible;
                }
            }
        }
    }
}
