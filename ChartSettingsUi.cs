using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>Shared option lists and owner drawing for chart settings Forms.</summary>
    internal static class ChartSettingsUi
    {
        public static void ConfigureFontFamilies(params ComboBox[] combos)
        {
            FontFamily[] families = FontFamily.Families;
            foreach (ComboBox combo in combos)
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                // Each list must have its own binding manager, so selecting a
                // font for X does not move the selection for Y.
                combo.DataSource = families.ToList();
                // Display the readable family name rather than FontFamily.ToString().
                combo.DisplayMember = nameof(FontFamily.Name);
                combo.DrawMode = DrawMode.OwnerDrawFixed;
            }
        }

        /// <summary>
        /// Data-bound font list entries and new FontFamily("Arial") objects are
        /// not necessarily the same object. Match their names instead of using
        /// ComboBox.SelectedItem, which can silently leave the first item active.
        /// </summary>
        public static bool SelectFontFamily(ComboBox combo, FontFamily family)
        {
            if (family == null) return false;
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is FontFamily candidate &&
                    string.Equals(candidate.Name, family.Name, StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        public static void ConfigureOwnerDraw(bool selectionOnly, params ComboBox[] combos)
        {
            foreach (ComboBox combo in combos)
            {
                combo.DrawMode = DrawMode.OwnerDrawFixed;
                if (selectionOnly) combo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public static void AddFontSizes(int minimum, int maximum, int incrementsPerPoint,
                                        params ComboBox[] combos)
        {
            for (int step = minimum * incrementsPerPoint;
                 step <= maximum * incrementsPerPoint; step++)
            {
                float size = step / (float)incrementsPerPoint;
                foreach (ComboBox combo in combos) combo.Items.Add(size);
            }
        }

        public static void AddEnums<T>(params ComboBox[] combos) where T : struct
        {
            foreach (T value in Enum.GetValues(typeof(T)))
                foreach (ComboBox combo in combos) combo.Items.Add(value);
        }

        public static void AddColors(params ComboBox[] combos)
        {
            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                Color color = Color.FromKnownColor(knownColor);
                foreach (ComboBox combo in combos) combo.Items.Add(color);
            }
            foreach (ComboBox combo in combos)
                combo.SelectedIndexChanged += UpdateSelectedColorPreview;
        }

        public static void AddIntegers(int minimum, int maximum, params ComboBox[] combos)
        {
            for (int i = minimum; i <= maximum; i++)
                foreach (ComboBox combo in combos) combo.Items.Add(i);
        }

        public static void AddOptions(ComboBox combo, params string[] options)
        {
            combo.Items.AddRange(options);
        }

        /// <summary>
        /// Each dropdown option owns its background, independent of the currently
        /// selected color. The closed/editable portion previews that selection.
        /// </summary>
        public static void SetContrast(ComboBox combo, Color color)
        {
            // The editable/closed portion is painted natively. Give it the
            // selected color too; DrawColor independently paints each list row.
            Color preview = color.A == 0 ? Color.FromArgb(224, 224, 224) : PreviewColor(color);
            combo.BackColor = preview;
            combo.ForeColor = ReadableInk(preview);
            combo.Invalidate();
        }

        private static bool HasItem(ComboBox combo, DrawItemEventArgs e) =>
            e.Index >= 0 && e.Index < combo.Items.Count;

        /// <summary>
        /// Also used for color dropdowns storing KnownColor names as strings
        /// (Offline Chart and the live chart cursor). No changes to stored data.
        /// </summary>
        public static void ConfigureNamedColorCombos(params ComboBox[] combos)
        {
            foreach (ComboBox combo in combos)
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.DrawMode = DrawMode.OwnerDrawFixed;
                combo.DrawItem += (sender, e) => DrawColor((ComboBox)sender, e);
                combo.SelectedIndexChanged += UpdateSelectedColorPreview;
            }
        }

        private static void UpdateSelectedColorPreview(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (TryGetColor(combo.SelectedItem, out Color color, out string unused))
                SetContrast(combo, color);
        }

        private static bool TryGetColor(object item, out Color color, out string label)
        {
            color = Color.Empty;
            label = null;
            if (item is Color selected)
            {
                color = selected;
                label = selected.Name;
                return true;
            }
            if (!(item is string name) || string.IsNullOrWhiteSpace(name)) return false;
            try
            {
                color = name.StartsWith("#", StringComparison.Ordinal)
                    ? ColorTranslator.FromHtml(name) : Color.FromName(name);
                if (!color.IsKnownColor && !color.IsNamedColor && !name.StartsWith("#", StringComparison.Ordinal))
                    return false;
                label = name;
                return true;
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                return false;
            }
        }

        private static Color PreviewColor(Color color)
        {
            if (color.A == 255) return color;
            // Semi-transparent colors are composited over a neutral grey;
            // fully transparent colors are handled as a checkerboard below.
            const int backing = 120;
            return Color.FromArgb(
                (color.R * color.A + backing * (255 - color.A)) / 255,
                (color.G * color.A + backing * (255 - color.A)) / 255,
                (color.B * color.A + backing * (255 - color.A)) / 255);
        }

        private static double ChannelLuminance(byte channel)
        {
            double s = channel / 255.0;
            return s <= 0.04045 ? s / 12.92 : Math.Pow((s + 0.055) / 1.055, 2.4);
        }

        /// <summary>Choose the higher WCAG contrast of black and white text.</summary>
        public static Color ReadableInk(Color background)
        {
            double luminance = 0.2126 * ChannelLuminance(background.R)
                             + 0.7152 * ChannelLuminance(background.G)
                             + 0.0722 * ChannelLuminance(background.B);
            return (luminance + 0.05) / 0.05 >= 1.05 / (luminance + 0.05)
                ? Color.Black : Color.White;
        }

        private static void DrawColorCore(ComboBox combo, DrawItemEventArgs e, Font font)
        {
            if (!HasItem(combo, e)) return;
            if (!TryGetColor(combo.Items[e.Index], out Color color, out string label))
            {
                // Non-color option or temporary blank item; retain normal UI drawing.
                e.DrawBackground();
                TextRenderer.DrawText(e.Graphics, combo.GetItemText(combo.Items[e.Index]), font,
                    e.Bounds, e.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                return;
            }

            Color background = color.A == 0 ? Color.FromArgb(224, 224, 224) : PreviewColor(color);
            Color ink = ReadableInk(background);
            using (var fill = new SolidBrush(background))
                e.Graphics.FillRectangle(fill, e.Bounds);

            // A checker swatch distinguishes Transparent from an opaque gray.
            int textLeft = e.Bounds.Left + 5;
            if (color.A == 0)
            {
                int swatchWidth = Math.Min(21, Math.Max(0, e.Bounds.Width / 5));
                for (int y = e.Bounds.Top + 3; y < e.Bounds.Bottom - 3; y += 6)
                    for (int x = e.Bounds.Left + 3; x < e.Bounds.Left + 3 + swatchWidth; x += 6)
                    {
                        bool dark = (((x - e.Bounds.Left - 3) / 6 + (y - e.Bounds.Top - 3) / 6) & 1) == 0;
                        using (var patch = new SolidBrush(dark ? Color.Silver : Color.White))
                            e.Graphics.FillRectangle(patch, x, y, 6, 6);
                    }
                textLeft += swatchWidth + 3;
            }

            var textBounds = new Rectangle(textLeft, e.Bounds.Top,
                Math.Max(0, e.Bounds.Right - textLeft - 3), e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, label, font, textBounds, ink,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);

            if ((e.State & DrawItemState.Selected) != 0)
            {
                // Use a high-contrast outline rather than Windows' blue fill,
                // preserving the item's actual color even when highlighted.
                using (var pen = new Pen(ink))
                    e.Graphics.DrawRectangle(pen, e.Bounds.Left, e.Bounds.Top,
                        Math.Max(0, e.Bounds.Width - 1), Math.Max(0, e.Bounds.Height - 1));
            }
        }

        public static void DrawColor(ComboBox combo, DrawItemEventArgs e)
        {
            DrawColorCore(combo, e, combo.Font);
        }

        public static void DrawColor(ComboBox combo, DrawItemEventArgs e,
                                     FontFamily family, float size, FontStyle style)
        {
            if (!HasItem(combo, e)) return;
            FontStyle usable = family.IsStyleAvailable(style) ? style : FontStyle.Regular;
            if (!family.IsStyleAvailable(usable))
            {
                DrawColorCore(combo, e, combo.Font);
                return;
            }
            using (var font = new Font(family, size, usable))
                DrawColorCore(combo, e, font);
        }

        public static void DrawFontFamily(ComboBox combo, DrawItemEventArgs e,
                                          float size, FontStyle style)
        {
            if (!HasItem(combo, e) || !(combo.Items[e.Index] is FontFamily family)) return;
            e.DrawBackground();
            FontStyle usable = family.IsStyleAvailable(style) ? style : FontStyle.Regular;
            if (family.IsStyleAvailable(usable))
            {
                using (var font = new Font(family, size, usable))
                {
                    using (var ink = new SolidBrush(e.ForeColor))
                        e.Graphics.DrawString(family.Name, font, ink, e.Bounds.X, e.Bounds.Y);
                }
            }
            else
            {
                using (var ink = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(family.Name, combo.Font, ink, e.Bounds.X, e.Bounds.Y);
            }
            e.DrawFocusRectangle();
        }

        public static void DrawFontStyle(ComboBox combo, DrawItemEventArgs e,
                                         FontFamily family, float size)
        {
            if (!HasItem(combo, e) || !(combo.Items[e.Index] is FontStyle style)) return;
            e.DrawBackground();
            using (var font = new Font(family, size,
                       family.IsStyleAvailable(style) ? style : FontStyle.Regular))
            {
                using (var ink = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(style.ToString(), font, ink, e.Bounds.X, e.Bounds.Y);
            }
            e.DrawFocusRectangle();
        }

        public static void DrawFontSize(ComboBox combo, DrawItemEventArgs e,
                                        FontFamily family, float size, FontStyle style)
        {
            if (!HasItem(combo, e)) return;
            e.DrawBackground();
            using (var font = new Font(family, size, style))
            {
                using (var ink = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(), font,
                                          ink, e.Bounds.X, e.Bounds.Y);
            }
            e.DrawFocusRectangle();
        }

        public static void DrawScheme(ComboBox combo, DrawItemEventArgs e,
                                      FontFamily family, float size)
        {
            if (!HasItem(combo, e) || !(combo.Items[e.Index] is string scheme)) return;
            Color color = scheme == "Green Red" ? Color.Green :
                          scheme == "Blue Red" ? Color.Blue : Color.Black;
            e.DrawBackground();
            using (var font = new Font(family, size, FontStyle.Bold))
            using (var brush = new SolidBrush(color))
                e.Graphics.DrawString(scheme, font, brush, e.Bounds.X, e.Bounds.Y);
            e.DrawFocusRectangle();
        }
    }

    /// <summary>Only disposes fonts that a settings Form allocated itself.</summary>
    internal sealed class ComboBoxFontStore : IDisposable
    {
        private readonly Dictionary<ComboBox, Font> owned = new Dictionary<ComboBox, Font>();

        public void SetFont(ComboBox combo, FontFamily family, float size, FontStyle style)
        {
            FontStyle usable = family.IsStyleAvailable(style) ? style : FontStyle.Regular;
            var next = new Font(family, size, usable);
            combo.Font = next;
            if (owned.TryGetValue(combo, out Font previous)) previous.Dispose();
            owned[combo] = next;
        }

        public void Dispose()
        {
            foreach (Font font in owned.Values) font.Dispose();
            owned.Clear();
        }
    }
}
