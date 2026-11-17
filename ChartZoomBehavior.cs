using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Shared X/Y drag-to-zoom behavior used by live and offline charts.
    /// Horizontal drags zoom X, vertical drags zoom Y.
    /// </summary>
    internal sealed class ChartZoomBehavior : IDisposable
    {
        private readonly Chart chart;
        private readonly Func<bool> canZoom;
        private Point? start;
        private ChartArea area;

        public ChartZoomBehavior(Chart chart, Func<bool> canZoom)
        {
            this.chart = chart ?? throw new ArgumentNullException(nameof(chart));
            this.canZoom = canZoom ?? throw new ArgumentNullException(nameof(canZoom));
            chart.MouseDown += OnDown;
            chart.MouseMove += OnMove;
            chart.MouseUp += OnUp;
        }

        private void OnDown(object sender, MouseEventArgs e)
        {
            start = null;
            area = null;
            if (!canZoom() || e.Button != MouseButtons.Left) return;
            var hit = chart.HitTest(e.X, e.Y);
            if (hit.ChartArea == null ||
                (hit.ChartElementType != ChartElementType.PlottingArea &&
                 hit.ChartElementType != ChartElementType.DataPoint)) return;
            start = e.Location;
            area = hit.ChartArea;
        }

        private void OnMove(object sender, MouseEventArgs e)
        {
            if (!start.HasValue || area == null || e.Button != MouseButtons.Left) return;
            int dx = Math.Abs(e.X - start.Value.X);
            int dy = Math.Abs(e.Y - start.Value.Y);
            if (Math.Max(dx, dy) < 8) return;
            try
            {
                PointF first = new PointF(start.Value.X, start.Value.Y);
                PointF last = new PointF(e.X, e.Y);
                if (dy > dx) area.CursorY.SetSelectionPixelPosition(first, last, false);
                else area.CursorX.SetSelectionPixelPosition(first, last, false);
            }
            catch (ArgumentException) { }
            catch (InvalidOperationException) { }
        }

        private void OnUp(object sender, MouseEventArgs e)
        {
            if (!start.HasValue || area == null || e.Button != MouseButtons.Left) return;
            Point first = start.Value;
            ChartArea current = area;
            start = null;
            area = null;
            if (!canZoom()) return;
            int dx = Math.Abs(e.X - first.X);
            int dy = Math.Abs(e.Y - first.Y);
            if (Math.Max(dx, dy) < 8) return;
            Axis target = dy > dx ? current.AxisY : current.AxisX;
            try
            {
                double from = target.PixelPositionToValue(dy > dx ? first.Y : first.X);
                double to = target.PixelPositionToValue(dy > dx ? e.Y : e.X);
                if (!double.IsNaN(from) && !double.IsNaN(to) &&
                    !double.IsInfinity(from) && !double.IsInfinity(to) &&
                    Math.Abs(from - to) > 1e-12)
                    target.ScaleView.Zoom(Math.Min(from, to), Math.Max(from, to));
            }
            catch (ArgumentException) { }
            catch (InvalidOperationException) { }
        }

        public void Dispose()
        {
            chart.MouseDown -= OnDown;
            chart.MouseMove -= OnMove;
            chart.MouseUp -= OnUp;
        }
    }
}
