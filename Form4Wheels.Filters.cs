using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class Form4Wheels
    {
        // Change this one list to change the displayed ordering of filter rows.
        // Their visual layout/spacing is defined in ChartLimiterRow.Designer.cs
        // and the containing FlowLayoutPanel in Form4Wheels.Designer.cs.
        private ChartLimiterRow[] filterRows;
        private bool refreshingFilters;

        private sealed class ChartLimit
        {
            public readonly string Selection;
            public readonly double Minimum;
            public readonly double Maximum;

            public ChartLimit(string selection, double minimum, double maximum)
            {
                Selection = selection;
                Minimum = minimum;
                Maximum = maximum;
            }
        }

        // Immutable snapshots: plotting never observes half-edited filter bounds.
        private static ChartLimit[] activeChartLimits = new ChartLimit[0];

        private void InitializeChartFilters()
        {
            filterRows = new[]
            {
                ChartLimiterRowHost.Mount(axisXFilterHost),
                ChartLimiterRowHost.Mount(axisYFilterHost),
                ChartLimiterRowHost.Mount(axisZFilterHost),
                ChartLimiterRowHost.Mount(extraFilterHost01),
                ChartLimiterRowHost.Mount(extraFilterHost02),
                ChartLimiterRowHost.Mount(extraFilterHost03),
                ChartLimiterRowHost.Mount(extraFilterHost04),
                ChartLimiterRowHost.Mount(extraFilterHost05),
                ChartLimiterRowHost.Mount(extraFilterHost06),
                ChartLimiterRowHost.Mount(extraFilterHost07),
                ChartLimiterRowHost.Mount(extraFilterHost08),
                ChartLimiterRowHost.Mount(extraFilterHost09),
                ChartLimiterRowHost.Mount(extraFilterHost10)
            };

            refreshingFilters = true;
            string[] followedAxisTitles =
            {
                "X axis (follows chart)",
                "Y axis (follows chart)",
                "Z axis (follows chart)"
            };
            for (int i = 0; i < filterRows.Length; i++)
            {
                var row = filterRows[i];
                bool axis = i < 3;
                row.Configure("ChartFilter" + (i + 1).ToString("00", CultureInfo.InvariantCulture),
                    axis, axis ? followedAxisTitles[i] : "Extra " + (i - 2));
                Form4WheelsSettings.AxisSelectionComboboxAdd(row.SelectionBox);
                row.EnabledBox.Checked = false;
                row.EnabledBox.CheckedChanged += (sender, args) => UpdateAllLimiters();
                row.MinimumBox.TextChanged += (sender, args) => UpdateAllLimiters();
                row.MaximumBox.TextChanged += (sender, args) => UpdateAllLimiters();
                row.SelectionBox.SelectionChangeCommitted += (sender, args) =>
                {
                    ResetFilterDefaults(row);
                    UpdateAllLimiters();
                };
                row.SelectionBox.Leave += (sender, args) =>
                {
                    if (!axis && row.SelectedField == null)
                    {
                        string typed = row.SelectionBox.Text;
                        if (row.SelectionBox.Items.Contains(typed)) row.SetField(typed);
                    }
                    UpdateAllLimiters();
                };
                row.ResetButton.Click += (sender, args) =>
                {
                    ResetFilterDefaults(row);
                    UpdateAllLimiters();
                };
                if (!axis)
                    row.SetField("None");
            }

            UpdateFollowedAxes(true);
            refreshingFilters = false;
            UpdateAllLimiters();
            this.Shown += (sender, args) => SizeFilterGroups();
            this.Resize += (sender, args) => SizeFilterGroups();
        }

        private void SizeFilterGroups()
        {
            if (filterRows == null || filterRows.Length != 13) return;

            // Keep all three followed axes visible even when DPI scaling or a
            // narrower window makes them wrap onto another line. The extra
            // filters have their own scrollbar so charts are never covered.
            int rowWidth = axisXFilterHost.Width + axisXFilterHost.Margin.Horizontal;
            int rowHeight = axisXFilterHost.Height + axisXFilterHost.Margin.Vertical;
            int usableWidth = Math.Max(1, axisFiltersGroup.ClientSize.Width -
                axisFiltersGroup.Padding.Horizontal - 20);
            int columns = Math.Max(1, usableWidth / Math.Max(1, rowWidth));
            int axisLines = (3 + columns - 1) / columns;
            axisFiltersGroup.Height = Math.Max(140,
                axisLines * rowHeight + axisFiltersGroup.Padding.Vertical + 16);
        }

        private void UpdateFollowedAxes(bool initial = false)
        {
            if (filterRows == null) return;

            string[] axes =
            {
                Form4WheelsSettings.X1Selection,
                Form4WheelsSettings.Y1Selection,
                Form4WheelsSettings.Z1Selection
            };

            bool changed = false;
            bool before = refreshingFilters;
            refreshingFilters = true;
            for (int i = 0; i < 3; i++)
            {
                ChartLimiterRow row = filterRows[i];
                if (!string.Equals(row.SelectedField, axes[i], StringComparison.Ordinal))
                {
                    row.SetField(axes[i]);
                    ResetFilterDefaults(row);
                    changed = true;
                }
                else if (initial && string.IsNullOrWhiteSpace(row.MinimumBox.Text))
                {
                    ResetFilterDefaults(row);
                }
            }
            refreshingFilters = before;
            if (changed && !before) UpdateAllLimiters();
        }

        private void ResetFilterDefaults(ChartLimiterRow row)
        {
            if (string.IsNullOrWhiteSpace(row.SelectedField)) return;

            // Only fields explicitly configured for absolute filtering use abs().
            // The remaining measurements retain their signed default bounds.
            bool absolute = GameMemoryConfig.AbsoluteValueFields.Contains(row.SelectedField);
            List<object> defaults = SelectionDefaults(row.SelectedField, absolute);
            double maximum = Convert.ToDouble(defaults[0]);
            double minimum = Convert.ToDouble(defaults[1]);

            bool before = refreshingFilters;
            refreshingFilters = true;
            row.MinimumBox.Text = double.IsNaN(minimum) ? "" : minimum.ToString(CultureInfo.CurrentCulture);
            row.MaximumBox.Text = double.IsNaN(maximum) ? "" : maximum.ToString(CultureInfo.CurrentCulture);
            refreshingFilters = before;
        }

        private static bool TryReadBound(TextBox textBox, bool minimum, out double value)
        {
            string text = textBox.Text.Trim();
            if (text.Length == 0)
            {
                value = minimum ? double.NegativeInfinity : double.PositiveInfinity;
                textBox.BackColor = SystemColors.Window;
                return true;
            }

            if ((double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                 double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value)) &&
                !double.IsNaN(value))
            {
                textBox.BackColor = SystemColors.Window;
                return true;
            }

            textBox.BackColor = Color.MistyRose;
            return false;
        }

        public void UpdateAllLimiters()
        {
            if (refreshingFilters || filterRows == null) return;

            var next = new List<ChartLimit>();
            for (int i = 0; i < filterRows.Length; i++)
            {
                var row = filterRows[i];
                if (!row.EnabledBox.Checked) continue;

                bool validMin = TryReadBound(row.MinimumBox, true, out double min);
                bool validMax = TryReadBound(row.MaximumBox, false, out double max);
                if (!validMin || !validMax || min > max)
                {
                    if (min > max)
                    {
                        row.MinimumBox.BackColor = Color.MistyRose;
                        row.MaximumBox.BackColor = Color.MistyRose;
                    }
                    continue;
                }

                string selected = row.SelectedField;
                if (!string.IsNullOrEmpty(selected) && selected != "None")
                    next.Add(new ChartLimit(selected, min, max));
            }

            activeChartLimits = next.ToArray();
            LimitersEnabled = next.Count != 0;
            NoTireContactLimiterEnabled = noTireContactLimiterEnabledCheckBox.Checked;

            // Preserve the old read-only public state for code that inspects it.
            X1LimiterSelection = filterRows[0].SelectedField;
            Y1LimiterSelection = filterRows[1].SelectedField;
            Z1LimiterSelection = filterRows[2].SelectedField;
            UpdateLegacyAxisBounds(filterRows[0], out double xMin, out double xMax);
            UpdateLegacyAxisBounds(filterRows[1], out double yMin, out double yMax);
            UpdateLegacyAxisBounds(filterRows[2], out double zMin, out double zMax);
            X1LimiterMin = xMin; X1LimiterMax = xMax;
            Y1LimiterMin = yMin; Y1LimiterMax = yMax;
            Z1LimiterMin = zMin; Z1LimiterMax = zMax;
            xyzAxisLimiterSelection = next.Select(f => f.Selection).ToList();
        }

        private static void UpdateLegacyAxisBounds(ChartLimiterRow row, out double min, out double max)
        {
            if (!TryReadBound(row.MinimumBox, true, out min)) min = double.NegativeInfinity;
            if (!TryReadBound(row.MaximumBox, false, out max)) max = double.PositiveInfinity;
        }
    }
}
