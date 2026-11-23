using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLiveData
    {
        private const int DebugInitialWidth = 360;

        private void InitializeDesignerLayoutBehavior()
        {
            // All visible UI is Designer-owned. The monitor rows are the only
            // dynamic portion, because they depend on the active JSON file.
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
            Shown += (sender, args) => SetDebugWorkspaceVisible(debugEnabled);
        }

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
        }
    }
}
