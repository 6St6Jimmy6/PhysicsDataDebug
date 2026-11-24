using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class Form4Wheels
    {
        // Rows are ordered by the settings form, matching its Designer layout.
        // Their visual layout/spacing is defined in ChartLimiterRow.Designer.cs
        // and the containing FlowLayoutPanel in Form4WheelsSettings.Designer.cs.
        private ChartLimiterRow[] filterRows;
        private bool refreshingFilters;

        private readonly struct ChartLimit
        {
            public readonly string Selection;
            public readonly double Minimum;
            public readonly double Maximum;
            public readonly bool Absolute;

            public ChartLimit(string selection, double minimum, double maximum)
            {
                Selection = selection;
                Minimum = minimum;
                Maximum = maximum;
                Absolute = GameMemoryConfig.IsAbsoluteValueField(selection);
            }
        }

        // Immutable snapshots: plotting never observes half-edited filter bounds.
        private static ChartLimit[] activeChartLimits = Array.Empty<ChartLimit>();

        private void InitializeChartFilters()
        {
            filterRows = settingsForm.FilterRows;
            refreshingFilters = true;
            for (int i = 0; i < filterRows.Length; i++)
            {
                var row = filterRows[i];
                bool axis = i < 3;
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
            settingsForm.NoContactFilter.CheckedChanged += (sender, args) => UpdateAllLimiters();
        }

        /// <summary>
        /// Refresh all thirteen selectors when the chart layout changes.
        /// Preserve each extra filter's chosen measurement and numeric bounds.
        /// The first three selectors continue to follow the current X/Y/Z axes.
        /// </summary>
        public void RefreshFilterFieldChoices()
        {
            if (filterRows == null) return;
            bool wasRefreshing = refreshingFilters;
            refreshingFilters = true;
            try
            {
                foreach (ChartLimiterRow row in filterRows)
                    Form4WheelsSettings.AxisSelectionComboboxAdd(row.SelectionBox);
            }
            finally
            {
                refreshingFilters = wasRefreshing;
            }

            UpdateFollowedAxes();
            UpdateAllLimiters();
        }

        private void UpdateFollowedAxes(bool initial = false)
        {
            if (filterRows == null) return;

            bool changed = false;
            bool before = refreshingFilters;
            refreshingFilters = true;
            for (int i = 0; i < 3; i++)
            {
                ChartLimiterRow row = filterRows[i];
                string selection = i == 0 ? Form4WheelsSettings.X1Selection :
                    i == 1 ? Form4WheelsSettings.Y1Selection : Form4WheelsSettings.Z1Selection;
                if (!string.Equals(row.SelectedField, selection, StringComparison.Ordinal))
                {
                    row.SetField(selection);
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
            bool absolute = GameMemoryConfig.IsAbsoluteValueField(row.SelectedField);
            List<object> defaults = SelectionDefaults(row.SelectedField, absolute);
            double maximum = Convert.ToDouble(defaults[0]);
            double minimum = Convert.ToDouble(defaults[1]);

            bool before = refreshingFilters;
            refreshingFilters = true;
            row.MinimumBox.Text = double.IsNaN(minimum) ? "" : minimum.ToString(CultureInfo.CurrentCulture);
            row.MaximumBox.Text = double.IsNaN(maximum) ? "" : maximum.ToString(CultureInfo.CurrentCulture);
            refreshingFilters = before;
        }

        public void UpdateAllLimiters()
        {
            if (refreshingFilters || filterRows == null) return;

            var next = new List<ChartLimit>();
            for (int i = 0; i < filterRows.Length; i++)
            {
                var row = filterRows[i];
                if (!row.EnabledBox.Checked) continue;

                if (!row.TryGetBounds(out double min, out double max)) continue;

                string selected = row.SelectedField;
                if (!string.IsNullOrEmpty(selected) && selected != "None")
                    next.Add(new ChartLimit(selected, min, max));
            }

            activeChartLimits = next.ToArray();
            NoTireContactLimiterEnabled = settingsForm.NoContactFilter.Checked;
        }
    }
}
