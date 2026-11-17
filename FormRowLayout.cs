using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Reusable logical rows: a caption, one or more values, and their unit
    /// labels form ONE row control. The same class also groups a settings
    /// caption with its associated inputs. Adjust the constants below to
    /// change spacing on all related forms at once.
    /// </summary>
    internal static class FormRowLayout
    {
        public const int WheelRowHeight = 24;
        public const int WheelRowSpacing = 0;
        public const int StaticRowHeight = 39;
        public const int StaticRowSpacing = 6;
        public const int SettingsRowSpacing = 10;
        // Below this available width a measurement uses two lines: the
        // caption first, then the values and units. No sideways scrolling.

        /*public const int InlineTelemetryMinimumWidth = 690;

        private const int RowHorizontalPadding = 6;
        private const int CaptionMinimumWidth = 90;
        private const int UnitMaximumWidth = 270;
        */
        public const int InlineTelemetryMinimumWidth = 400;
        public const int InlineCaptionMaximumWidth = 165;
        public const int InlineCaptionMinimumWidth = 0;
        public const int InlineValueMinimumWidth = 55;
        public const int InlineValueMaximumWidth = 220;
        public const int InlineUnitMaximumWidth = 60;

        private const int RowHorizontalPadding = 6;
        private const int ThreeValueCaptionMinimumWidth = 115;
        private const int ValueGap = 4;
        private sealed class ValueRow
        {
            public Panel Layout;
            public Control[] Fields;
            public int[] OriginalWidths;
            public int CaptionWidth;
            public bool? IsCompact;
        }

        /// <summary>
        /// Turn related labels into individually arranged rows. A single Panel
        /// contains each caption and all its values/units, avoiding dynamic
        /// TableLayoutPanel column or row creation when the window is resized.
        /// </summary>
        public static void AddTelemetryRows(Control parent, IEnumerable<Control> source,
            int captionWidth, int rowHeight, int rowSpacing)
        {
            Control[] controls = source.ToArray();
            var groups = ClusterByTop(controls, tolerance: 12);
            var viewport = new Panel
            {
                Name = parent.Name + "ValueViewport",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = parent.BackColor
            };
            var table = new TableLayoutPanel
            {
                Name = parent.Name + "ValueRows",
                Location = Point.Empty,
                ColumnCount = 1,
                RowCount = groups.Count,
                GrowStyle = TableLayoutPanelGrowStyle.FixedSize,
                BackColor = parent.BackColor,
                Padding = new Padding(2, 5, 2, 5),
                Margin = Padding.Empty
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            var rows = new List<ValueRow>();
            for (int index = 0; index < groups.Count; index++)
            {
                ValueRow item = NewValueRow(parent, groups[index], captionWidth,
                    rowHeight, rowSpacing, index);
                rows.Add(item);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight + rowSpacing));
                table.Controls.Add(item.Layout, 0, index);
            }
            viewport.Controls.Add(table);
            parent.Controls.Add(viewport);
            viewport.BringToFront();

            bool fitting = false;
            Action fit = () =>
            {
                if (fitting) return;
                fitting = true;
                try
                {
                    // Reserve vertical-scrollbar space from the beginning so
                    // adding rows cannot introduce a horizontal scrollbar.
                    /*int width = Math.Max(240, viewport.ClientSize.Width -
                        SystemInformation.VerticalScrollBarWidth - 4);
                    bool compact = width < InlineTelemetryMinimumWidth;*/
                    int width = Math.Max(1, viewport.ClientSize.Width -
    SystemInformation.VerticalScrollBarWidth - 4);

                    bool compact = width < InlineTelemetryMinimumWidth ||
                        rows.Any(item => RequiredInlineWidth(item) + 20 > width);
                    int totalHeight = table.Padding.Vertical;
                    table.SuspendLayout();
                    for (int index = 0; index < rows.Count; index++)
                    {
                        ValueRow item = rows[index];
                        int height = compact ? Math.Max(66, rowHeight * 2 - 4) : rowHeight;
                        table.RowStyles[index].Height = height + rowSpacing;
                        totalHeight += height + rowSpacing;
                    }
                    table.Size = new Size(width, totalHeight);
                    table.ResumeLayout(true);
                    foreach (ValueRow item in rows) PlaceValueRow(item, compact);
                }
                finally { fitting = false; }
            };
            viewport.SizeChanged += (sender, args) => fit();
            fit();
        }

        /// <summary>
        /// Bind the existing Designer-owned measurement row panels. This
        /// preserves all Designer control names/positions while allowing the
        /// same responsive width calculations as AddTelemetryRows.
        /// </summary>
        public static void BindDesignerTelemetryRows(Panel wheel,
            int captionWidth, int rowHeight, int rowSpacing)
        {
            Panel[] panels = wheel.Controls.OfType<Panel>()
                .Where(p => p.Name.StartsWith(wheel.Name + "TelemetryRow",
                    StringComparison.Ordinal))
                .OrderBy(p => p.Top).ToArray();
            var states = new List<ValueRow>();
            foreach (Panel panel in panels)
            {
                Control[] fields = panel.Controls.Cast<Control>()
                    .Where(c => !string.Equals(c.Tag as string,
                        "LayoutIgnoredDuplicate", StringComparison.Ordinal))
                    .OrderBy(c => c.Left).ToArray();
                if (fields.Length == 0) continue;
                var state = new ValueRow
                {
                    Layout = panel,
                    Fields = fields,
                    OriginalWidths = fields.Select(c => c.Width).ToArray(),
                    CaptionWidth = captionWidth
                };
                states.Add(state);
                panel.SizeChanged += (sender, args) =>
                    PlaceValueRow(state, state.IsCompact ?? false);
            }

            bool fitting = false;
            Action fit = () =>
            {
                if (fitting) return;
                fitting = true;
                try
                {
                    int width = Math.Max(1, wheel.ClientSize.Width -
                        SystemInformation.VerticalScrollBarWidth - 12);
                    bool compact = width < InlineTelemetryMinimumWidth ||
                        states.Any(item => RequiredInlineWidth(item) + 20 > width);
                    int y = 5;
                    foreach (ValueRow state in states)
                    {
                        int height = compact ? Math.Max(66, rowHeight * 2 - 4) : rowHeight;
                        state.Layout.Bounds = new Rectangle(4, y, width, height);
                        PlaceValueRow(state, compact);
                        y += height + rowSpacing;
                    }
                    //wheel.AutoScrollMinSize = new Size(0, y + 8);
                    int contentHeight = y + 8;

                    // Remove the previous forced scrollable area.
                    wheel.AutoScrollMinSize = Size.Empty;

                    // Only enable scrolling if the rows don't fit.
                    bool needsScroll = contentHeight > wheel.ClientSize.Height;

                    if (wheel.AutoScroll != needsScroll)
                        wheel.AutoScroll = needsScroll;

                    if (needsScroll)
                        wheel.AutoScrollMinSize = new Size(0, contentHeight);
                }
                finally { fitting = false; }
            };
            wheel.SizeChanged += (sender, args) => fit();
            fit();
        }

        /// <summary>
        /// Group a caption and any related buttons, checkboxes, dropdowns or
        /// text inputs into ONE movable row panel. Row starts are design-time
        /// band positions, not final screen coordinates. The rows are stacked
        /// automatically with the same configurable gap on every settings page.
        /// </summary>
        public static void AddSettingsRows(Control parent, IEnumerable<Control> source,
            int[] rowStarts, int minimumRowWidth)
        {
            Control[] controls = source.ToArray();
            var stack = NewStack(parent, parent.Name + "Rows");
            if (controls.Length == 0)
            {
                parent.Controls.Add(stack);
                return;
            }

            int sectionLeft = controls.Min(control => control.Left);
            var rowGroups = new SortedDictionary<int, List<Control>>();
            foreach (Control control in controls)
            {
                int row = 0;
                for (int i = 0; i < rowStarts.Length; i++)
                    if (control.Top >= rowStarts[i]) row = i;
                if (!rowGroups.TryGetValue(row, out List<Control> group))
                    rowGroups.Add(row, group = new List<Control>());
                group.Add(control);
            }

            foreach (KeyValuePair<int, List<Control>> entry in rowGroups)
            {
                List<Control> group = entry.Value;
                int top = group.Min(control => control.Top);
                int bottom = group.Max(control => control.Bottom);
                var row = new Panel
                {
                    Name = parent.Name + "Row" + entry.Key,
                    Height = bottom - top + 14,
                    Margin = new Padding(RowHorizontalPadding, 0,
                        RowHorizontalPadding, SettingsRowSpacing),
                    AutoScroll = true,
                    BackColor = parent.BackColor
                };

                row.SuspendLayout();
                foreach (Control control in group)
                {
                    Point position = control.Location;
                    control.Location = new Point(position.X - sectionLeft + 6,
                        position.Y - top + 6);
                    row.Controls.Add(control);
                }
                row.AutoScrollMinSize = new Size(
                    group.Max(control => control.Right) + 12, row.Height);
                row.ResumeLayout(true);
                stack.Controls.Add(row);
            }

            parent.Controls.Add(stack);
            stack.BringToFront();
            FitRowWidths(stack, minimumRowWidth);
        }

        private static FlowLayoutPanel NewStack(Control parent, string name)
        {
            return new FlowLayoutPanel
            {
                Name = name,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = parent.BackColor,
                Padding = new Padding(3, 8, 3, 8)
            };
        }

        private static void FitRowWidths(FlowLayoutPanel stack, int minimumRowWidth)
        {
            Action fit = () =>
            {
                int available = Math.Max(0, stack.ClientSize.Width - 18);
                int width = Math.Max(minimumRowWidth, available);
                foreach (Control row in stack.Controls)
                    if (row.Width != width) row.Width = width;
            };
            stack.SizeChanged += (sender, args) => fit();
            fit();
        }

        private static List<List<Control>> ClusterByTop(IEnumerable<Control> source, int tolerance)
        {
            var groups = new List<List<Control>>();
            foreach (Control control in source.OrderBy(c => c.Top).ThenBy(c => c.Left))
            {
                List<Control> previous = groups.LastOrDefault();
                if (previous == null ||
                    Math.Abs(control.Top - previous.Average(c => c.Top)) > tolerance)
                {
                    previous = new List<Control>();
                    groups.Add(previous);
                }
                previous.Add(control);
            }
            return groups;
        }

        private static ValueRow NewValueRow(Control parent, List<Control> group,
            int captionWidth, int height, int gap, int index)
        {
            // The leftmost label names the measurement. Remaining controls are
            // values, separators or units. Duplicate separators from older
            // Designer files do not become extra columns.
            List<Control> ordered = group.OrderBy(control => control.Left).ToList();
            var seenUnits = new List<Control>();
            var visible = new List<Control>();
            foreach (Control control in ordered)
            {
                bool duplicateUnit = control is Label label && label.BorderStyle == BorderStyle.None &&
                    seenUnits.Any(other => other is Label existing &&
                        existing.Text == label.Text && Math.Abs(other.Left - label.Left) <= 5);
                if (duplicateUnit)
                {
                    control.Visible = false;
                    continue;
                }
                visible.Add(control);
                if (control is Label unit && unit.BorderStyle == BorderStyle.None)
                    seenUnits.Add(control);
            }

            var row = new Panel
            {
                Name = parent.Name + "TelemetryRow" + index,
                Height = height,
                BackColor = parent.BackColor,
                Margin = new Padding(RowHorizontalPadding, 0, RowHorizontalPadding, gap),
                Padding = Padding.Empty,
                Dock = DockStyle.Fill
            };
            var state = new ValueRow
            {
                Layout = row,
                Fields = visible.ToArray(),
                OriginalWidths = visible.Select(control => control.Width).ToArray(),
                CaptionWidth = captionWidth
            };
            foreach (Control control in state.Fields)
            {
                control.Dock = DockStyle.None;
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                control.Margin = Padding.Empty;
                if (control is Label field) field.AutoSize = false;
                row.Controls.Add(control);
            }
            row.SizeChanged += (sender, args) =>
                PlaceValueRow(state, state.IsCompact ?? false);
            return state;
        }

        /// <summary>
        /// Position the existing controls directly within a single row Panel.
        /// Switching between compact and inline mode never adds table columns
        /// or reparents controls, so resizing cannot throw a FixedSize layout
        /// exception or lose a live telemetry label.
        /// </summary>
        /*private static void PlaceValueRow(ValueRow state, bool compact)
        {
            Panel row = state.Layout;
            Control[] fields = state.Fields;
            if (fields.Length == 0) return;
            int rowWidth = row.ClientSize.Width;
            int rowHeight = row.ClientSize.Height;
            if (rowWidth <= 0 || rowHeight <= 0) return;

            int valueCount = fields.Skip(1).Count(IsDataValue);
            int captionWidth = valueCount >= 3 ? CaptionMinimumWidth + 40 : state.CaptionWidth;
            int captionCellWidth = compact ? rowWidth - 8 : Math.Min(captionWidth, rowWidth / 2);
            int captionHeight = compact ? 25 : Math.Max(22, rowHeight - 5);
            SetControlBounds(fields[0], 4, compact ? 1 : 2,
                Math.Max(20, captionCellWidth - 7), captionHeight);
            if (fields[0] is Label caption) caption.AutoEllipsis = true;

            int firstValueX = compact ? 4 : captionCellWidth;
            int valueY = compact ? 29 : 2;
            int valueHeight = 18;//Math.Max(22, rowHeight - valueY - 3);
            int available = Math.Max(30, rowWidth - firstValueX - 4);
            int[] widths = new int[fields.Length];
            int fixedWidth = 0;
            for (int i = 1; i < fields.Length; i++)
            {
                if (IsDataValue(fields[i])) continue;
                int desired = Math.Min(UnitMaximumWidth,
                    Math.Max(22, state.OriginalWidths[i] + 3));
                // Long explanatory notes should not consume a narrow row.
                widths[i] = Math.Min(desired, Math.Max(38, available / 3));
                fixedWidth += widths[i];
            }
            int gap = 4;
            int dataWidth = valueCount == 0 ? 0 : Math.Max(22,
                (available - fixedWidth - gap * (fields.Length - 1)) / valueCount);
            int x = firstValueX;
            for (int i = 1; i < fields.Length; i++)
            {
                Control control = fields[i];
                int width = IsDataValue(control) ? dataWidth : widths[i];
                //int width = IsDataValue(control) ? Math.Min(dataWidth, 140) : widths[i];
                SetControlBounds(control, x, valueY, width, valueHeight);
                if (control is Label field && !IsDataValue(control) &&
                    state.OriginalWidths[i] > width)
                    field.AutoEllipsis = true;
                x += width + gap;
            }
            state.IsCompact = compact;
        }
        */
        private static int MinimumCaptionWidth(ValueRow state) =>
    state.Fields.Skip(1).Count(IsDataValue) >= 3
        ? ThreeValueCaptionMinimumWidth : InlineCaptionMinimumWidth;

        private static int UnitWidth(ValueRow state, int index) =>
            Math.Min(InlineUnitMaximumWidth,
                Math.Max(20, state.OriginalWidths[index] + 3));

        private static int RequiredInlineWidth(ValueRow state)
        {
            int valueCount = state.Fields.Skip(1).Count(IsDataValue);
            int unitWidths = 0;

            for (int i = 1; i < state.Fields.Length; i++)
            {
                if (!IsDataValue(state.Fields[i]))
                    unitWidths += UnitWidth(state, i);
            }

            return 8 + MinimumCaptionWidth(state) +
                valueCount * InlineValueMinimumWidth + unitWidths +
                ValueGap * Math.Max(0, state.Fields.Length - 2);
        }

        private static void PlaceValueRow(ValueRow state, bool compact)
        {
            Panel row = state.Layout;
            Control[] fields = state.Fields;

            if (fields.Length == 0)
                return;

            int rowWidth = row.ClientSize.Width;
            int rowHeight = row.ClientSize.Height;

            if (rowWidth <= 0 || rowHeight <= 0)
                return;

            int valueCount = fields.Skip(1).Count(IsDataValue);
            int[] widths = new int[fields.Length];
            int fixedWidth = 0;

            for (int i = 1; i < fields.Length; i++)
            {
                if (IsDataValue(fields[i]))
                    continue;

                widths[i] = UnitWidth(state, i);
                fixedWidth += widths[i];
            }

            int minimumValuesWidth =
                valueCount * InlineValueMinimumWidth +
                fixedWidth +
                ValueGap * Math.Max(0, fields.Length - 2);

            int captionCellWidth = compact ? rowWidth - 8 : 
                Math.Max(MinimumCaptionWidth(state),
                Math.Min(Math.Min(state.CaptionWidth, InlineCaptionMaximumWidth), 
                rowWidth - 8 - minimumValuesWidth));

            int captionHeight = compact
                ? 25
                : Math.Max(22, rowHeight - 5);

            SetControlBounds(
                fields[0],
                4,
                compact ? 1 : 2,
                Math.Max(20, captionCellWidth - 7),
                captionHeight
            );

            if (fields[0] is Label caption)
                caption.AutoEllipsis = true;

            int firstValueX = compact ? 4 : captionCellWidth;
            int valueY = compact ? 29 : 2;
            int valueHeight = Math.Max(22, rowHeight - valueY - 3);

            int available = Math.Max(1, rowWidth - firstValueX - 4);

            int perValueWidth = valueCount == 0
                ? 0
                : (available - fixedWidth -
                    ValueGap * (fields.Length - 2)) / valueCount;

            int dataWidth = valueCount == 0
                ? 0
                : Math.Min(
                    InlineValueMaximumWidth,
                    Math.Max(InlineValueMinimumWidth, perValueWidth)
                );

            int x = firstValueX;

            for (int i = 1; i < fields.Length; i++)
            {
                Control control = fields[i];

                int width = IsDataValue(control)
                    ? dataWidth
                    : widths[i];

                SetControlBounds(control, x, valueY, width, valueHeight);

                if (control is Label field &&
                    !IsDataValue(control) &&
                    state.OriginalWidths[i] > width)
                {
                    field.AutoEllipsis = true;
                }

                x += width + ValueGap;
            }

            state.IsCompact = compact;
        }
        private static void SetControlBounds(Control control, int x, int y, int width, int height)
        {
            var bounds = new Rectangle(x, y, Math.Max(1, width), Math.Max(1, height));
            if (control.Bounds != bounds) control.Bounds = bounds;
        }

        private static bool IsDataValue(Control control) =>
            (control is Label label && label.BorderStyle != BorderStyle.None) ||
            control is TextBoxBase || control is ComboBox || control is NumericUpDown;
    }
}
