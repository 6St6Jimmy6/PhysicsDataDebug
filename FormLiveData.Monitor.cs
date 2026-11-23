using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLiveData
    {
        private sealed class MonitorItem
        {
            internal string Id;
            internal string Group;
            internal string Category;
            internal string Name;
            internal string Unit;
            internal string UnitTooltip;
            internal List<LogData.Column> Channels = new List<LogData.Column>();
        }
        private sealed class MonitorCell
        {
            internal Label Label;
            internal LogData.Column Column;
        }
        private readonly HashSet<string> monitorSelected =
            new HashSet<string>(StringComparer.Ordinal);
        private readonly List<MonitorCell> monitorCells = new List<MonitorCell>();
        private readonly List<MonitorItem> monitorItems = new List<MonitorItem>();
        private RapidMonitorCheckboxClicks monitorRapidClicks;
        private bool monitorUpdatingTree;
        private readonly ToolTip monitorUnitToolTip = new ToolTip();
        private string MonitorSelectionsPath => Path.Combine(
            JsonFormSettings.DirectoryPath, "LiveMonitorSelections.json");

        private static string CategoryCaption(string group)
        {
            switch (group)
            {
                case "WF_TireDataOffset": return "Tire";
                case "WF_Suspension1DataOffset": return "Suspension 1";
                case "WF_Suspension2DataOffset": return "Suspension 2";
                case "WF_SuspensionGeometryDataOffset": return "Suspension geometry";
                case "WF_EngineDataOffset": return "Engine";
                case "WF_DifferentialDataOffset": return "Differential";
                case "WF_BodyRotationDataOffset": return "Body rotation";
                case "WF_BodyAccelDataOffset": return "Acceleration";
                case "WF_MassDataOffset": return "Vehicle mass";
                case "WF_AeroDataOffset": return "Aerodynamics";
                case "WF_TimeDataOffset": return "Timing";
                default: return group;
            }
        }

        private void InitializeMonitor()
        {
            // The Designer owns monitorFlow and the empty/preview state.
            // RebuildMonitorRows removes the preview when selections are loaded.
            monitorFlow.SizeChanged += (sender, args) => FitMonitorGroups();
            monitorFieldTree.AfterCheck += MonitorTreeAfterCheck;
            monitorRapidClicks = new RapidMonitorCheckboxClicks(monitorFieldTree);
            FormClosed += (sender, args) =>
            {
                monitorRapidClicks.Dispose();
                monitorUnitToolTip.Dispose();
            };
            ReadMonitorSelections();
            RebuildMonitorFields();
        }

        private void ReadMonitorSelections()
        {
            if (!File.Exists(MonitorSelectionsPath)) return;
            try
            {
                var json = new JavaScriptSerializer();
                var root = json.DeserializeObject(File.ReadAllText(MonitorSelectionsPath)) as
                    IDictionary<string, object>;
                if (root != null && root.TryGetValue("selected", out object values) &&
                    values is object[] items)
                {
                    monitorSelected.Clear();
                    foreach (object item in items)
                        if (item is string id) monitorSelected.Add(id);
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                       ex is ArgumentException || ex is InvalidOperationException)
            {
                System.Diagnostics.Debug.WriteLine("Monitor choices could not be restored: " + ex.Message);
            }
        }

        private void SaveMonitorSelections()
        {
            try
            {
                Directory.CreateDirectory(JsonFormSettings.DirectoryPath);
                var json = new JavaScriptSerializer();
                File.WriteAllText(MonitorSelectionsPath, json.Serialize(new
                {
                    selected = monitorSelected.OrderBy(id => id, StringComparer.Ordinal).ToArray()
                }));
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                System.Diagnostics.Debug.WriteLine("Monitor choices could not be saved: " + ex.Message);
            }
        }

        private void RebuildMonitorFields()
        {
            monitorItems.Clear();
            // Different wheels of the same measurement are one row. All raw and
            // calculated definitions are discovered from the active JSON model.
            foreach (var group in LogData.AllColumns.GroupBy(c => c.Group + "." + c.Member))
            {
                var column = group.First();
                TelemetryMetadata.FieldInfo info = TelemetryMetadata.Get(column.Group, column.Member);
                monitorItems.Add(new MonitorItem
                {
                    Id = group.Key,
                    Group = column.Group,
                    Category = column.Header.StartsWith("VEH_", StringComparison.Ordinal)
                        ? "Vehicle" : CategoryCaption(column.Group),
                    Name = info.DisplayName,
                    Unit = info.Unit,
                    UnitTooltip = info.UnitName,
                    Channels = group.OrderBy(c => c.Wheel == null ? -1 :
                        Array.IndexOf(TelemetryNames.Wheels, c.Wheel)).ToList()
                });
            }
            if (monitorSelected.Count == 0 && !File.Exists(MonitorSelectionsPath))
            {
                // Useful first-run readout. Every other JSON-defined field is
                // still selectable via its category or individual checkbox.
                foreach (MonitorItem entry in monitorItems)
                    if (entry.Group == "WF_AeroDataOffset" ||
                        entry.Group == "WF_TimeDataOffset" ||
                        (entry.Group == "WF_EngineDataOffset" &&
                            (entry.Id.EndsWith(".EngineRPM") || entry.Id.EndsWith(".Speed"))) ||
                        (entry.Group == "WF_TireDataOffset" &&
                            (entry.Id.EndsWith(".SlipRatio") || entry.Id.EndsWith(".VerticalLoad"))))
                        monitorSelected.Add(entry.Id);
            }
            monitorUpdatingTree = true;
            monitorFieldTree.BeginUpdate();
            try
            {
                monitorFieldTree.Nodes.Clear();
                foreach (var category in monitorItems.GroupBy(item => item.Category))
                {
                    TreeNode parent = new TreeNode(category.Key) { Tag = null };
                    foreach (MonitorItem item in category.OrderBy(item => item.Name,
                        StringComparer.CurrentCultureIgnoreCase))
                    {
                        var child = new TreeNode(item.Name)
                        {
                            Tag = item.Id, Checked = monitorSelected.Contains(item.Id),
                            ToolTipText = item.Unit.Length == 0 ? item.Id :
                                item.Id + " (" + item.Unit + ": " + item.UnitTooltip + ")"
                        };
                        parent.Nodes.Add(child);
                    }
                    UpdateMonitorParent(parent);
                    monitorFieldTree.Nodes.Add(parent);
                    if (category.Key == "Aerodynamics") parent.Expand();
                }
            }
            finally
            {
                monitorFieldTree.EndUpdate();
                monitorUpdatingTree = false;
            }
            RebuildMonitorRows();
        }

        private static void UpdateMonitorParent(TreeNode node)
        {
            if (node.Nodes.Count == 0) return;
            int count = node.Nodes.Cast<TreeNode>().Count(child => child.Checked);
            string title = node.Text;
            int suffix = title.LastIndexOf(" (", StringComparison.Ordinal);
            if (suffix > 0) title = title.Substring(0, suffix);
            node.Text = title + " (" + count + "/" + node.Nodes.Count + ")";
            node.Checked = count == node.Nodes.Count;
        }

        private void MonitorTreeAfterCheck(object sender, TreeViewEventArgs e)
        {
            if (monitorUpdatingTree || e.Action == TreeViewAction.Unknown) return;
            monitorUpdatingTree = true;
            try
            {
                if (e.Node.Tag == null)
                {
                    foreach (TreeNode child in e.Node.Nodes)
                    {
                        child.Checked = e.Node.Checked;
                        if (e.Node.Checked) monitorSelected.Add((string)child.Tag);
                        else monitorSelected.Remove((string)child.Tag);
                    }
                    UpdateMonitorParent(e.Node);
                }
                else
                {
                    if (e.Node.Checked) monitorSelected.Add((string)e.Node.Tag);
                    else monitorSelected.Remove((string)e.Node.Tag);
                    if (e.Node.Parent != null) UpdateMonitorParent(e.Node.Parent);
                }
            }
            finally { monitorUpdatingTree = false; }
            RebuildMonitorRows();
            SaveMonitorSelections();
        }

        private void FitMonitorGroups()
        {
            if (monitorFlow == null) return;
            int width = Math.Max(180, monitorFlow.ClientSize.Width -
                SystemInformation.VerticalScrollBarWidth - monitorFlow.Padding.Horizontal - 4);
            foreach (Control item in monitorFlow.Controls)
                if (item.Width != width) item.Width = width;
        }

        private void RebuildMonitorRows()
        {
            if (monitorFlow == null) return;
            monitorCells.Clear();
            monitorFlow.SuspendLayout();
            try
            {
                monitorFlow.Controls.Clear();
                foreach (var category in monitorItems.Where(item => monitorSelected.Contains(item.Id))
                    .GroupBy(item => item.Category))
                {
                    List<MonitorItem> entries = category.ToList();
                    bool wheels = entries.Any(entry => entry.Channels.Any(c => c.Wheel != null));
                    var box = new GroupBox
                    {
                        Text = category.Key, BackColor = Color.FromArgb(24, 24, 24),
                        ForeColor = Color.White, Margin = new Padding(2, 2, 2, 6),
                        Height = 47 + entries.Count * 34
                    };
                    var rows = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill, BackColor = Color.FromArgb(24, 24, 24),
                        Padding = new Padding(5, 6, 5, 4),
                        RowCount = entries.Count + 1,
                        ColumnCount = wheels ? 5 : 2
                    };
                    if (wheels)
                    {
                        rows.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
                        for (int j = 0; j < 4; j++)
                            rows.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5F));
                    }
                    else
                    {
                        rows.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
                        rows.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
                    }
                    rows.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
                    AddMonitorLabel(rows, "Measurement", 0, 0, true);
                    if (wheels)
                        for (int j = 0; j < 4; j++)
                            AddMonitorLabel(rows, TelemetryNames.Wheels[j], j + 1, 0, true);
                    else AddMonitorLabel(rows, "Value", 1, 0, true);
                    for (int index = 0; index < entries.Count; index++)
                    {
                        MonitorItem entry = entries[index];
                        rows.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
                        Label name = AddMonitorLabel(rows, entry.Name, 0, index + 1, false);
                        name.TextAlign = ContentAlignment.MiddleLeft;
                        name.BackColor = index % 2 == 0 ? Color.FromArgb(34, 34, 34) :
                            Color.FromArgb(28, 28, 28);
                        monitorUnitToolTip.SetToolTip(name, entry.Id);
                        if (wheels)
                        {
                            for (int wheel = 0; wheel < 4; wheel++)
                            {
                                var column = entry.Channels.FirstOrDefault(c => c.Wheel == TelemetryNames.Wheels[wheel]);
                                AddMonitorValue(rows, column, entry, wheel + 1, index + 1);
                            }
                        }
                        else AddMonitorValue(rows, entry.Channels.FirstOrDefault(), entry, 1, index + 1);
                    }
                    box.Controls.Add(rows);
                    monitorFlow.Controls.Add(box);
                }
                FitMonitorGroups();
            }
            finally { monitorFlow.ResumeLayout(true); }
            monitorEmptyHint.Visible = monitorFlow.Controls.Count == 0;
            monitorFlow.Visible = monitorFlow.Controls.Count != 0;
            UpdateMonitorValues();
        }

        private Label AddMonitorLabel(TableLayoutPanel parent, string value,
            int column, int row, bool header)
        {
            var label = new Label
            {
                Text = value, Dock = DockStyle.Fill,
                ForeColor = header ? Color.LightSkyBlue : Color.White,
                TextAlign = header ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleRight,
                Font = new Font("Arial", header ? 9f : 8.5f, header ? FontStyle.Bold : FontStyle.Regular),
                Margin = new Padding(2, 1, 2, 1), AutoEllipsis = true,
                BackColor = Color.FromArgb(35, 35, 35)
            };
            parent.Controls.Add(label, column, row);
            return label;
        }

        private void AddMonitorValue(TableLayoutPanel parent, LogData.Column column,
            MonitorItem info, int columnIndex, int row)
        {
            // Unit text lives in its own label, so users can hover over the
            // symbol and see its fully expanded meaning.
            var holder = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = info.Unit.Length == 0 ? 1 : 2,
                RowCount = 1, Margin = new Padding(2, 1, 2, 1),
                BackColor = Color.Black
            };
            if (info.Unit.Length == 0) holder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            else
            {
                holder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
                holder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            }
            Label number = new Label
            {
                Name = "monitorValue", Dock = DockStyle.Fill,
                Text = "—", TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.White, BackColor = Color.Black,
                Font = new Font("Arial", 8.5f), AutoEllipsis = true
            };
            holder.Controls.Add(number, 0, 0);
            if (info.Unit.Length > 0)
            {
                var unit = new Label
                {
                    Name = "monitorUnit", Text = info.Unit,
                    Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft,
                    ForeColor = Color.Silver, BackColor = Color.Black,
                    Font = new Font("Arial", 8f), AutoEllipsis = true,
                    Padding = new Padding(3, 0, 0, 0)
                };
                holder.Controls.Add(unit, 1, 0);
                monitorUnitToolTip.SetToolTip(unit, string.IsNullOrEmpty(info.UnitTooltip) ?
                    info.Unit : info.UnitTooltip);
            }
            parent.Controls.Add(holder, columnIndex, row);
            if (column != null) monitorCells.Add(new MonitorCell { Label = number, Column = column });
        }

        // Keep WinForms checkbox double-clicks from being swallowed by the
        // native TreeView, matching the fix in FormLogSettings.
        private sealed class RapidMonitorCheckboxClicks : NativeWindow, IDisposable
        {
            private const int WM_LBUTTONDOWN = 0x0201;
            private const int WM_LBUTTONDBLCLK = 0x0203;
            private readonly TreeView tree;

            internal RapidMonitorCheckboxClicks(TreeView target)
            {
                tree = target;
                tree.HandleCreated += Created;
                tree.HandleDestroyed += Destroyed;
                if (tree.IsHandleCreated) AssignHandle(tree.Handle);
            }
            private void Created(object sender, EventArgs e)
            {
                if (Handle != IntPtr.Zero) ReleaseHandle();
                AssignHandle(tree.Handle);
            }
            private void Destroyed(object sender, EventArgs e)
            {
                if (Handle != IntPtr.Zero) ReleaseHandle();
            }
            protected override void WndProc(ref Message message)
            {
                if (message.Msg == WM_LBUTTONDBLCLK)
                {
                    long point = message.LParam.ToInt64();
                    int x = unchecked((short)(point & 0xffff));
                    int y = unchecked((short)((point >> 16) & 0xffff));
                    if ((tree.HitTest(x, y).Location & TreeViewHitTestLocations.StateImage) != 0)
                        message.Msg = WM_LBUTTONDOWN;
                }
                base.WndProc(ref message);
            }
            public void Dispose()
            {
                tree.HandleCreated -= Created;
                tree.HandleDestroyed -= Destroyed;
                if (Handle != IntPtr.Zero) ReleaseHandle();
            }
        }

        private void UpdateMonitorValues()
        {
            if (!ValuesGet || LiveData.FullDataList.Count == 0) return;
            foreach (MonitorCell cell in monitorCells)
            {
                try
                {
                    double value = cell.Column.ReadDouble();
                    cell.Label.Text = double.IsNaN(value) || double.IsInfinity(value)
                        ? "—" : value.ToString("G8", CultureInfo.CurrentCulture);
                }
                catch (Exception ex) when (ex is InvalidOperationException || ex is KeyNotFoundException ||
                                           ex is FormatException || ex is OverflowException || ex is ArgumentException)
                { cell.Label.Text = "—"; }
            }
        }
    }
}
