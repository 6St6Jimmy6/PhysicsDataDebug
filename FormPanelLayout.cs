using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Shared, adjustable panels for the four-wheel static readouts.
    /// Existing Designer controls are moved, not recreated, so their names, event
    /// handlers, telemetry updates, and JSON profile keys remain unchanged.
    /// </summary>
    internal static class FormPanelLayout
    {
        // Wheel panels are still composed at runtime. Chart settings now have
        // explicit, editable sections in each settings form's Designer file.
        private const int WheelCardGap = 8;

        private sealed class Section
        {
            public string Title;
            public List<Control> Controls;
        }

        /// <summary>
        /// Put front-left/front-right above rear-left/rear-right. Each wheel
        /// has its own scrollable panel, and the full grid also scrolls when
        /// the window is smaller than the preferred two-column width.
        /// </summary>
        public static void OrganizeWheelValues(Form form, int rearRowStartsAt,
            int minimumCardWidth, int rowHeight)
        {
            var original = form.Controls.Cast<Control>().ToArray();
            var sections = new[]
            {
                new Section { Title = "Front Left", Controls = new List<Control>() },
                new Section { Title = "Front Right", Controls = new List<Control>() },
                new Section { Title = "Rear Left", Controls = new List<Control>() },
                new Section { Title = "Rear Right", Controls = new List<Control>() }
            };

            foreach (Control control in original)
            {
                int row = control.Top >= rearRowStartsAt ? 1 : 0;
                int column = control.Left >= 500 ? 1 : 0;
                sections[row * 2 + column].Controls.Add(control);
            }

            form.SuspendLayout();
            form.AutoScroll = false;

            var viewport = new Panel
            {
                Name = "WheelValuesViewport",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = form.BackColor
            };
            var grid = new TableLayoutPanel
            {
                Name = "WheelValuesGrid",
                Location = Point.Empty,
                ColumnCount = 2,
                RowCount = 2,
                Margin = Padding.Empty,
                Padding = new Padding(WheelCardGap / 2),
                Height = rowHeight * 2 + WheelCardGap,
                GrowStyle = TableLayoutPanelGrowStyle.FixedSize
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

            var wheelCards = new List<GroupBox>();
            for (int index = 0; index < sections.Length; index++)
            {
                GroupBox group = CreateGroup(form, "Wheel" + sections[index].Title.Replace(" ", ""),
                    sections[index].Title);
                var data = new List<Control>();
                foreach (Control control in sections[index].Controls)
                {
                    if (control is Label label && string.Equals(
                        label.Text.Trim(), sections[index].Title,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        control.Visible = false;
                        group.Controls.Add(control);
                    }
                    else data.Add(control);
                }
                FormRowLayout.AddTelemetryRows(group, data, captionWidth: 210,
                    rowHeight: FormRowLayout.StaticRowHeight,
                    rowSpacing: FormRowLayout.StaticRowSpacing);
                group.Margin = new Padding(WheelCardGap / 2);
                grid.Controls.Add(group, index % 2, index / 2);
                wheelCards.Add(group);
            }

            viewport.Controls.Add(grid);
            form.Controls.Add(viewport);
            viewport.BringToFront();
            Action fitWidth = () =>
            {
                int width = Math.Max(280, viewport.ClientSize.Width - 6);
                int columns = width >= 2 * minimumCardWidth + WheelCardGap ? 2 : 1;
                if (grid.ColumnCount != columns)
                {
                    grid.SuspendLayout();
                    grid.Controls.Clear();
                    grid.ColumnStyles.Clear();
                    grid.RowStyles.Clear();
                    grid.ColumnCount = columns;
                    grid.RowCount = 4 / columns;
                    for (int c = 0; c < columns; c++)
                        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
                    for (int r = 0; r < grid.RowCount; r++)
                        grid.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                    for (int i = 0; i < wheelCards.Count; i++)
                        grid.Controls.Add(wheelCards[i], i % columns, i / columns);
                    grid.ResumeLayout(true);
                }
                grid.Size = new Size(width, (4 / columns) * rowHeight + WheelCardGap);
            };
            viewport.Resize += (sender, args) => fitWidth();
            fitWidth();
            form.Shown += (sender, args) =>
            {
                viewport.AutoScrollPosition = Point.Empty;
                foreach (GroupBox card in wheelCards)
                    foreach (Panel scroll in card.Controls.OfType<Panel>().Where(p => p.AutoScroll))
                        scroll.AutoScrollPosition = Point.Empty;
            };

            form.MinimumSize = new Size(780, 520);
            form.ResumeLayout(true);
        }

        private static GroupBox CreateGroup(Form form, string name, string heading)
        {
            return new GroupBox
            {
                Name = name,
                Text = heading,
                Dock = DockStyle.Fill,
                BackColor = form.BackColor,
                ForeColor = form.BackColor == Color.Black ? Color.White : form.ForeColor
            };
        }
    }
}
