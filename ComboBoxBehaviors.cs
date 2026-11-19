using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Shared contains-text search for editable ComboBoxes.
    ///
    /// The suggestions are a single ordinary WinForms ListBox per Form, hosted
    /// INSIDE that Form. They are not a floating ToolStripDropDown window: the
    /// old popup could leave a painted, top-level window behind after a click.
    /// The original ComboBox.Items collections are never filtered or rebound.
    /// </summary>
    internal static class ComboBoxBehaviors
    {
        private static readonly ConditionalWeakTable<ComboBox, SearchBehavior> Behaviors =
            new ConditionalWeakTable<ComboBox, SearchBehavior>();
        private static readonly ConditionalWeakTable<Form, SearchOverlay> Overlays =
            new ConditionalWeakTable<Form, SearchOverlay>();

        // Custom suggestion selection should notify existing native
        // SelectionChangeCommitted subscribers once, just like a normal click.
        private static readonly MethodInfo RaiseNativeCommit = typeof(ComboBox).GetMethod(
            "OnSelectionChangeCommitted", BindingFlags.Instance | BindingFlags.NonPublic,
            null, new[] { typeof(EventArgs) }, null);

        public static void EnableSearch(Control container)
        {
            // Never alter controls while the Visual Studio Designer loads a form.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (container is Form form)
                form.Shown += (sender, args) => ClearEditSelections(form);

            foreach (Control control in container.Controls)
            {
                if (control is ComboBox combo)
                    Behaviors.GetValue(combo, source => new SearchBehavior(source));
                EnableSearch(control);
            }
        }

        private static void ClearEditSelections(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox combo &&
                    combo.DropDownStyle != ComboBoxStyle.DropDownList &&
                    !combo.IsDisposed)
                {
                    combo.SelectionStart = combo.Text.Length;
                    combo.SelectionLength = 0;
                }
                ClearEditSelections(control);
            }
        }

        private sealed class SearchResult
        {
            internal readonly object Value;
            internal readonly string Label;

            internal SearchResult(object value, string label)
            {
                Value = value;
                Label = label;
            }

            public override string ToString() => Label;
        }

        /// <summary>
        /// All searchable ComboBoxes in a Form share this one in-form suggestion
        /// list. Hiding it removes a normal child control from the display, so
        /// a separate topmost popup can never remain stuck above other windows.
        /// </summary>
        private sealed class SearchOverlay : IDisposable
        {
            private readonly Form form;
            private readonly ListBox results;
            private SearchBehavior active;
            private bool disposed;

            internal SearchOverlay(Form owner)
            {
                form = owner;
                results = new ListBox
                {
                    Visible = false,
                    IntegralHeight = false,
                    BorderStyle = BorderStyle.FixedSingle,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    ItemHeight = 22,
                    BackColor = Color.FromArgb(32, 32, 32),
                    ForeColor = Color.White,
                    TabStop = false,
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left
                };
                results.DrawItem += DrawResult;
                results.MouseUp += Results_MouseUp;
                results.KeyDown += Results_KeyDown;
                results.Leave += (sender, args) => active?.CheckFocusAfterEvent();
                form.Deactivate += Form_Deactivate;
                form.Resize += (sender, args) => Hide();
                form.FormClosed += (sender, args) => Dispose();
            }

            internal bool IsFor(SearchBehavior behavior) =>
                !disposed && ReferenceEquals(active, behavior) && results.Visible;

            internal bool ContainsFocus => !disposed && results.ContainsFocus;

            internal void ShowMatches(SearchBehavior behavior, string query)
            {
                if (disposed || form.IsDisposed || behavior.Source.IsDisposed ||
                    !behavior.Source.IsHandleCreated || string.IsNullOrWhiteSpace(query))
                {
                    Hide(behavior);
                    return;
                }

                if (active != null && !ReferenceEquals(active, behavior)) Hide();

                results.BeginUpdate();
                try
                {
                    results.Items.Clear();
                    // Never change the original ComboBox.Items collection: it can
                    // contain bound FontFamily objects, Color objects, or fields
                    // replaced when a chart layout or CSV source changes.
                    foreach (object item in behavior.Source.Items)
                    {
                        string label = behavior.ItemText(item);
                        if (label.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0)
                            results.Items.Add(new SearchResult(item, label));
                    }
                    if (results.Items.Count > 0) results.SelectedIndex = 0;
                }
                finally { results.EndUpdate(); }

                if (results.Items.Count == 0)
                {
                    Hide(behavior);
                    return;
                }

                ComboBox combo = behavior.Source;
                if (combo.DroppedDown) combo.DroppedDown = false;
                results.Font = combo.Font;
                results.ItemHeight = Math.Max(22, combo.Font.Height + 7);

                // Position in the FORM's client coordinates, never in the
                // scrolling group or TableLayoutPanel hosting the ComboBox.
                // This avoids clipping and works even when an inner panel scrolls.
                Rectangle anchor = form.RectangleToClient(
                    combo.RectangleToScreen(combo.ClientRectangle));
                const int edge = 3;
                int availableWidth = form.ClientSize.Width - edge * 2;
                if (availableWidth < 70) { Hide(behavior); return; }
                int width = Math.Min(Math.Max(combo.Width, combo.DropDownWidth), availableWidth);
                int x = Math.Max(edge, Math.Min(anchor.Left, form.ClientSize.Width - width - edge));
                int wanted = Math.Min(12, results.Items.Count) * results.ItemHeight + 2;
                int below = Math.Max(0, form.ClientSize.Height - anchor.Bottom - edge);
                int above = Math.Max(0, anchor.Top - edge);
                bool openAbove = below < wanted && above > below;
                int availableHeight = openAbove ? above : below;
                if (availableHeight < results.ItemHeight + 2)
                {
                    Hide(behavior);
                    return;
                }
                int height = Math.Min(wanted, availableHeight);
                int y = openAbove ? anchor.Top - height : anchor.Bottom;

                // Add lazily: mutating Form.Controls while EnableSearch is
                // enumerating its children could break initialization.
                if (results.Parent != form) form.Controls.Add(results);
                active = behavior;
                results.Bounds = new Rectangle(x, y, width, height);
                results.Visible = true;
                results.BringToFront();
            }

            internal void Hide(SearchBehavior behavior = null)
            {
                if (disposed || (behavior != null && !ReferenceEquals(active, behavior)))
                    return;
                if (!results.Visible)
                {
                    active = null;
                    return;
                }

                Rectangle oldBounds = results.Bounds;
                // Hide the child first, then invalidate the underlying form
                // and all its children. No owner-drawn window is left alive.
                results.Visible = false;
                active = null;
                results.Items.Clear();
                if (!form.IsDisposed && form.IsHandleCreated)
                {
                    form.Invalidate(oldBounds, true);
                    form.Update();
                }
            }

            internal void Cancel(SearchBehavior behavior)
            {
                if (!IsFor(behavior)) return;
                Hide(behavior);
                behavior.RestorePreviousSelection();
            }

            internal bool HandleKey(SearchBehavior behavior, KeyEventArgs e)
            {
                if (!IsFor(behavior) || results.Items.Count == 0) return false;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    int delta = e.KeyCode == Keys.Down ? 1 : -1;
                    results.SelectedIndex = Math.Max(0, Math.Min(results.Items.Count - 1,
                        results.SelectedIndex + delta));
                }
                else if (e.KeyCode == Keys.Enter)
                    CommitSelected();
                else if (e.KeyCode == Keys.Escape)
                    Cancel(behavior);
                else
                    return false;
                e.Handled = true;
                e.SuppressKeyPress = true;
                return true;
            }

            private void Results_MouseUp(object sender, MouseEventArgs e)
            {
                if (active == null || e.Button != MouseButtons.Left) return;
                if (results.Items.Count * results.ItemHeight > results.ClientSize.Height &&
                    e.X >= results.ClientSize.Width - SystemInformation.VerticalScrollBarWidth)
                    return; // Scrollbar interaction is not a selection.
                int index = results.IndexFromPoint(e.Location);
                if (index >= 0 && index < results.Items.Count)
                    CommitResult(results.Items[index] as SearchResult);
            }

            private void Results_KeyDown(object sender, KeyEventArgs e)
            {
                if (active != null) HandleKey(active, e);
            }

            private void CommitSelected()
            {
                CommitResult(results.SelectedItem as SearchResult);
            }

            private void CommitResult(SearchResult entry)
            {
                SearchBehavior behavior = active;
                if (behavior == null || entry == null) return;
                Hide(behavior);
                behavior.CommitResult(entry);
            }

            private void Form_Deactivate(object sender, EventArgs args)
            {
                SearchBehavior behavior = active;
                if (behavior == null) return;
                Hide();
                behavior.RestorePreviousSelection();
            }

            private void DrawResult(object sender, DrawItemEventArgs e)
            {
                if (e.Index < 0 || e.Index >= results.Items.Count) return;
                SearchResult entry = results.Items[e.Index] as SearchResult;
                if (entry == null) return;
                bool selected = (e.State & DrawItemState.Selected) != 0;
                Color background = selected ? Color.FromArgb(62, 62, 62) : results.BackColor;
                Color ink = Color.White;
                bool colorEntry = false;
                Color itemColor = Color.Empty;
                if (entry.Value is Color actual)
                {
                    itemColor = actual;
                    colorEntry = true;
                }
                else if (active != null && active.IsColorSelector && entry.Value is string name)
                {
                    Color candidate = Color.FromName(name);
                    if (candidate.IsKnownColor || candidate.IsNamedColor)
                    {
                        itemColor = candidate;
                        colorEntry = true;
                    }
                }
                if (colorEntry)
                {
                    if (itemColor.A == 0) background = Color.FromArgb(224, 224, 224);
                    else if (itemColor.A == 255) background = itemColor;
                    else background = Color.FromArgb(
                        (itemColor.R * itemColor.A + 120 * (255 - itemColor.A)) / 255,
                        (itemColor.G * itemColor.A + 120 * (255 - itemColor.A)) / 255,
                        (itemColor.B * itemColor.A + 120 * (255 - itemColor.A)) / 255);
                    ink = ChartSettingsUi.ReadableInk(background);
                }
                using (var brush = new SolidBrush(background))
                    e.Graphics.FillRectangle(brush, e.Bounds);
                int textLeft = e.Bounds.X + 5;
                if (colorEntry && itemColor.A == 0)
                {
                    for (int y = e.Bounds.Y + 4; y < e.Bounds.Bottom - 4; y += 6)
                        for (int x = e.Bounds.X + 4; x < e.Bounds.X + 22; x += 6)
                        {
                            bool dark = (((x - e.Bounds.X - 4) / 6 +
                                (y - e.Bounds.Y - 4) / 6) & 1) == 0;
                            using (var patch = new SolidBrush(dark ? Color.Silver : Color.White))
                                e.Graphics.FillRectangle(patch, x, y, 6, 6);
                        }
                    textLeft += 24;
                }
                TextRenderer.DrawText(e.Graphics, entry.Label, results.Font,
                    new Rectangle(textLeft, e.Bounds.Y,
                        Math.Max(0, e.Bounds.Right - textLeft - 4), e.Bounds.Height), ink,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
                if (selected)
                    using (var outline = new Pen(colorEntry ? ink : Color.Silver))
                        e.Graphics.DrawRectangle(outline, e.Bounds.X, e.Bounds.Y,
                            Math.Max(0, e.Bounds.Width - 1), Math.Max(0, e.Bounds.Height - 1));
            }

            public void Dispose()
            {
                if (disposed) return;
                Hide();
                disposed = true;
                results.Dispose();
            }
        }

        private sealed class SearchBehavior
        {
            private readonly ComboBox combo;
            private SearchOverlay overlay;
            private object lastSelectedItem;
            private bool committing;
            private bool disposed;

            internal ComboBox Source => combo;
            internal bool IsColorSelector =>
                combo.Name.IndexOf("color", StringComparison.OrdinalIgnoreCase) >= 0 ||
                (combo.Items.Count > 0 && combo.Items[0] is Color);

            internal SearchBehavior(ComboBox source)
            {
                combo = source;
                lastSelectedItem = combo.SelectedItem;
                combo.FormattingEnabled = true;
                combo.Format += FormatSpecialItems;
                combo.DropDownStyle = ComboBoxStyle.DropDown;
                combo.AutoCompleteMode = AutoCompleteMode.None;
                combo.AutoCompleteSource = AutoCompleteSource.None;
                combo.TextUpdate += Combo_TextUpdate;
                combo.KeyDown += Combo_KeyDown;
                combo.DropDown += (sender, args) => GetOverlay()?.Hide(this);
                combo.SelectedIndexChanged += (sender, args) =>
                {
                    if (combo.SelectedIndex >= 0)
                        lastSelectedItem = combo.SelectedItem;
                };
                combo.Validating += Combo_Validating;
                combo.Leave += (sender, args) => CheckFocusAfterEvent();
                combo.VisibleChanged += (sender, args) => GetOverlay()?.Hide(this);
                combo.SizeChanged += (sender, args) => GetOverlay()?.Hide(this);
                combo.LocationChanged += (sender, args) => GetOverlay()?.Hide(this);
                combo.Disposed += (sender, args) =>
                {
                    disposed = true;
                    overlay?.Hide(this);
                };

                // Inner, auto-scrolling layout panels can move a ComboBox
                // without changing the ComboBox's own Location property.
                for (Control parent = combo.Parent; parent != null; parent = parent.Parent)
                    if (parent is ScrollableControl scrolling)
                        scrolling.Scroll += (sender, args) => overlay?.Hide(this);
            }

            private SearchOverlay GetOverlay()
            {
                if (disposed || combo.IsDisposed) return null;
                if (overlay == null)
                {
                    Form form = combo.FindForm();
                    if (form != null && !form.IsDisposed)
                        overlay = Overlays.GetValue(form, owner => new SearchOverlay(owner));
                }
                return overlay;
            }

            private static void FormatSpecialItems(object sender, ListControlConvertEventArgs e)
            {
                if (e.ListItem is Color color)
                    e.Value = color.Name;
                else if (e.ListItem is FontFamily family)
                    e.Value = family.Name;
                else if (e.ListItem is GameVersionProfile version)
                    e.Value = version.DisplayName;
            }

            internal string ItemText(object item)
            {
                if (item is Color color) return color.Name;
                if (item is FontFamily family) return family.Name;
                if (item is GameVersionProfile version) return version.DisplayName;
                return combo.GetItemText(item);
            }

            private void Combo_TextUpdate(object sender, EventArgs e)
            {
                if (committing || disposed) return;
                SearchOverlay host = GetOverlay();
                if (host == null) return;
                host.ShowMatches(this, combo.Text);
            }

            private void Combo_KeyDown(object sender, KeyEventArgs e)
            {
                GetOverlay()?.HandleKey(this, e);
            }

            internal void CommitResult(SearchResult result)
            {
                if (result == null || disposed || combo.IsDisposed) return;
                committing = true;
                try
                {
                    // Use the original index; it also works for data-bound
                    // FontFamily lists, which require the original item object.
                    int index = combo.Items.IndexOf(result.Value);
                    if (index >= 0) combo.SelectedIndex = index;
                    else combo.SelectedItem = result.Value;
                    combo.Text = result.Label;
                    lastSelectedItem = combo.SelectedItem;
                    RaiseNativeCommit?.Invoke(combo, new object[] { EventArgs.Empty });
                    if (!combo.IsDisposed && combo.CanFocus) combo.Focus();
                    if (!combo.IsDisposed && combo.DropDownStyle == ComboBoxStyle.DropDown)
                    {
                        combo.SelectionStart = combo.Text.Length;
                        combo.SelectionLength = 0;
                    }
                }
                finally { committing = false; }
            }

            private void Combo_Validating(object sender, CancelEventArgs e)
            {
                if (committing || (overlay != null && overlay.IsFor(this))) return;
                if (combo.SelectedIndex >= 0 &&
                    string.Equals(combo.Text, ItemText(combo.SelectedItem),
                        StringComparison.CurrentCultureIgnoreCase)) return;
                string typed = combo.Text;
                foreach (object item in combo.Items)
                {
                    if (string.Equals(typed, ItemText(item),
                        StringComparison.CurrentCultureIgnoreCase))
                    {
                        combo.SelectedItem = item;
                        return;
                    }
                }
                RestorePreviousSelection();
            }

            internal void RestorePreviousSelection()
            {
                if (disposed || combo.IsDisposed) return;
                if (lastSelectedItem != null && combo.Items.Contains(lastSelectedItem))
                {
                    combo.SelectedItem = lastSelectedItem;
                    combo.Text = ItemText(lastSelectedItem);
                }
                else
                    combo.Text = string.Empty;
            }

            internal void CheckFocusAfterEvent()
            {
                if (disposed || combo.IsDisposed || !combo.IsHandleCreated) return;
                combo.BeginInvoke((MethodInvoker)(() =>
                {
                    if (disposed || combo.IsDisposed || combo.Focused ||
                        (overlay != null && overlay.IsFor(this) && overlay.ContainsFocus))
                        return;
                    overlay?.Hide(this);
                    if (combo.SelectedIndex < 0 ||
                        !string.Equals(combo.Text, ItemText(combo.SelectedItem),
                            StringComparison.CurrentCultureIgnoreCase))
                        RestorePreviousSelection();
                }));
            }
        }
    }

    /// <summary>
    /// Closed ComboBoxes no longer change their selection when the user merely
    /// scrolls a wheel over them. Wheel scrolling still works in an open list.
    /// A message filter also covers native edit children of WinForms ComboBoxes.
    /// </summary>
    internal sealed class ComboBoxWheelFilter : IMessageFilter
    {
        private const int WmMouseWheel = 0x020A;
        private const int WmMouseHorizontalWheel = 0x020E;

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg != WmMouseWheel && message.Msg != WmMouseHorizontalWheel)
                return false;

            Control target = Control.FromChildHandle(message.HWnd);
            while (target != null && !(target is ComboBox) && !(target is NumericUpDown))
                target = target.Parent;

            if (target is NumericUpDown) return true;
            return target is ComboBox combo && !combo.DroppedDown;
        }
    }
}
