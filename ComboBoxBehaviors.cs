using System;
using System.Drawing;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Searchable ComboBoxes across the application. Typing suggests existing
    /// items, but leaving the control cannot silently commit an unknown value.
    /// SelectedItem remains the original Color, FontFamily, enum, number, etc.
    /// </summary>
    internal static class ComboBoxBehaviors
    {
        public static void EnableSearch(Control container)
        {
            // Profile load may update selections during Form.Load. Clear any native
            // text highlight once the settings window has actually appeared.
            if (container is Form form)
                form.Shown += (sender, e) => ClearEditSelections(form);
            foreach (Control control in container.Controls)
            {
                if (control is ComboBox combo)
                    Configure(combo);
                EnableSearch(control);
            }
        }

        private static void ClearEditSelections(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox combo &&
                    combo.DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    combo.SelectionStart = combo.Text.Length;
                    combo.SelectionLength = 0;
                }
                ClearEditSelections(control);
            }
        }

        private static void Configure(ComboBox combo)
        {
            int previousSelection = combo.SelectedIndex;

            // Format the displayed text without replacing the typed items.
            // This makes searching for "Red" or "Arial" work as expected.
            combo.FormattingEnabled = true;
            combo.Format += (sender, e) =>
            {
                if (e.ListItem is Color color)
                    e.Value = color.Name;
                else if (e.ListItem is FontFamily family)
                    e.Value = family.Name;
                else if (e.ListItem is GameVersionProfile version)
                    e.Value = version.DisplayName;
            };

            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            // Suggest still searches by typing but does not select the entire
            // displayed value (blue highlight) when the dropdown receives focus.
            combo.AutoCompleteMode = AutoCompleteMode.Suggest;

            // Some owner-drawn/editable native combo boxes retain highlighted
            // edit text after opening or committing. Place the caret at the end;
            // don't change the selected ITEM or the user's unfinished typing.
            EventHandler clearEditSelection = (sender, e) =>
            {
                if (combo.IsDisposed || combo.DropDownStyle == ComboBoxStyle.DropDownList)
                    return;
                // Defer until after WinForms' focus / dropdown selection updates.
                if (combo.IsHandleCreated)
                    combo.BeginInvoke((MethodInvoker)(() =>
                    {
                        if (!combo.IsDisposed &&
                            combo.DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            combo.SelectionStart = combo.Text.Length;
                            combo.SelectionLength = 0;
                        }
                    }));
            };
            combo.Enter += clearEditSelection;
            combo.SelectedIndexChanged += clearEditSelection;
            combo.DropDown += clearEditSelection;
            combo.DropDownClosed += clearEditSelection;
            combo.SelectionChangeCommitted += clearEditSelection;

            combo.SelectedIndexChanged += (sender, e) =>
            {
                if (combo.SelectedIndex >= 0)
                    previousSelection = combo.SelectedIndex;
            };
            combo.Validating += (sender, e) =>
            {
                if (combo.SelectedIndex >= 0)
                    return;

                for (int i = 0; i < combo.Items.Count; i++)
                {
                    if (string.Equals(combo.Text, combo.GetItemText(combo.Items[i]),
                        StringComparison.CurrentCultureIgnoreCase))
                    {
                        combo.SelectedIndex = i;
                        return;
                    }
                }
                if (previousSelection >= 0 && previousSelection < combo.Items.Count)
                    combo.SelectedIndex = previousSelection;
                else
                    combo.Text = string.Empty;
            };
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
            // A NumericUpDown's edit child otherwise receives mouse-wheel messages
            // even when the parent control is not focused. Never wheel-adjust numbers.
            while (target != null && !(target is ComboBox) && !(target is NumericUpDown))
                target = target.Parent;

            if (target is NumericUpDown) return true;
            return target is ComboBox combo && !combo.DroppedDown;
        }
    }
}
