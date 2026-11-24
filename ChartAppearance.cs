using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Shared drawing primitives used by the offline CSV chart and the live
    /// Four Wheels chart. WinForms chart line widths are integer pixels, even
    /// though the settings retain quarter-step decimal precision.
    /// </summary>
    internal static class ChartAppearance
    {
        public static int PixelWidth(decimal width) =>
            Math.Max(1, (int)Math.Round(width, MidpointRounding.AwayFromZero));

        public static Color WithAlpha(Color color, int alpha) =>
            Color.FromArgb(Math.Max(0, Math.Min(255, alpha)), color);

        public static void ConfigureGrid(Grid grid, Color color,
            int alpha, decimal width, ChartDashStyle dash)
        {
            Color tint = WithAlpha(color, alpha);
            int pixels = PixelWidth(width);
            grid.LineColor = tint;
            grid.LineWidth = pixels;
            grid.LineDashStyle = dash;
        }

        /// <summary>
        /// Cartesian axis lines run in the same direction as the opposite
        /// axis's grid. Keep them visually consistent and omit exterior ticks.
        /// </summary>
        public static void ConfigureCartesianAxisLines(ChartArea area)
        {
            ConfigureAxisLine(area.AxisX, area.AxisY.MajorGrid);
            ConfigureAxisLine(area.AxisY, area.AxisX.MajorGrid);
        }

        private static void ConfigureAxisLine(Axis axis, Grid parallelGrid)
        {
            axis.LineColor = parallelGrid.LineColor;
            axis.LineWidth = parallelGrid.LineWidth;
            axis.LineDashStyle = parallelGrid.LineDashStyle;
            axis.MajorTickMark.Enabled = false;
            axis.MinorTickMark.Enabled = false;
        }

        public static void ConfigureCursor(Cursor cursor, bool enabled, bool zoomable,
            Color color, int alpha, decimal width, ChartDashStyle dash)
        {
            cursor.IsUserEnabled = enabled;
            cursor.IsUserSelectionEnabled = enabled && zoomable;
            cursor.LineColor = WithAlpha(color, alpha);
            cursor.SelectionColor = Color.FromArgb(Math.Min(85, Math.Max(0, alpha)), color);
            cursor.LineWidth = PixelWidth(width);
            cursor.LineDashStyle = dash;
            cursor.Interval = 0;
            cursor.AutoScroll = zoomable;
        }

        /// <summary>Multi-series live charts have one X and one Y per point.</summary>
        public static bool CanDrawLiveXYZ(SeriesChartType type)
        {
            if (!FormOfflineChart.CanDrawWithXYZ(type)) return false;
            switch (type)
            {
                case SeriesChartType.Pie:
                case SeriesChartType.Doughnut:
                case SeriesChartType.Funnel:
                case SeriesChartType.Pyramid:
                case SeriesChartType.Bubble:
                    return false;
                default: return true;
            }
        }

        public static void ConfigureZoom(ChartArea area, bool enabled, bool zoomable,
            Color color, int alpha, decimal width, ChartDashStyle dash)
        {
            area.AxisX.ScaleView.Zoomable = enabled && zoomable;
            area.AxisY.ScaleView.Zoomable = enabled && zoomable;
            ConfigureCursor(area.CursorX, enabled, zoomable, color, alpha, width, dash);
            ConfigureCursor(area.CursorY, enabled, zoomable, color, alpha, width, dash);
        }
    }
}
