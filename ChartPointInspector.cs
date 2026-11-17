using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Reusable point inspector for WinForms Chart. A normal tooltip appears after
    /// the configured hover interval; clicking a data point pins a closeable card.
    /// Only chart types/points that the Chart control can hit-test are inspected.
    /// </summary>
    internal sealed class ChartPointInspector : IDisposable
    {
        private readonly Chart chart;
        private readonly Func<Series, DataPoint, string> formatPoint;
        private readonly Timer hoverTimer;
        private readonly ToolTip hoverTip;
        private readonly Panel pinnedPanel;
        private readonly Label pinnedBody;
        private Series hoverSeries;
        private DataPoint hoverPoint;
        private Point hoverLocation;
        private bool disposed;
        private bool enabled = true;

        public ChartPointInspector(Chart chart, Func<Series, DataPoint, string> formatPoint)
        {
            if (chart == null) throw new ArgumentNullException(nameof(chart));
            if (formatPoint == null) throw new ArgumentNullException(nameof(formatPoint));
            this.chart = chart;
            this.formatPoint = formatPoint;

            hoverTimer = new Timer { Interval = 500 };
            hoverTimer.Tick += HoverTimer_Tick;
            hoverTip = new ToolTip { ShowAlways = false, UseAnimation = true,
                InitialDelay = 0, ReshowDelay = 0, AutoPopDelay = 15000 };

            pinnedPanel = new Panel
            {
                Name = "pointInspectorPinnedPanel", Size = new Size(290, 142),
                BackColor = Color.FromArgb(39, 43, 49), BorderStyle = BorderStyle.FixedSingle,
                Visible = false, TabStop = false
            };
            var title = new Label
            {
                Name = "pointInspectorTitle", Text = "Pinned data point",
                Location = new Point(10, 6), Size = new Size(235, 22),
                ForeColor = Color.White, Font = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold)
            };
            var close = new Button
            {
                Name = "pointInspectorCloseButton", Text = "×", Size = new Size(25, 25),
                Location = new Point(257, 4), FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White, BackColor = Color.FromArgb(65, 68, 72),
                TabStop = true, AccessibleName = "Close pinned point tooltip"
            };
            close.FlatAppearance.BorderSize = 0;
            close.Click += (sender, args) => pinnedPanel.Visible = false;
            pinnedBody = new Label
            {
                Name = "pointInspectorValues", Location = new Point(10, 33),
                Size = new Size(270, 101), ForeColor = Color.Gainsboro,
                AutoEllipsis = true, UseMnemonic = false
            };
            pinnedPanel.Controls.Add(title);
            pinnedPanel.Controls.Add(pinnedBody);
            pinnedPanel.Controls.Add(close);
            chart.Controls.Add(pinnedPanel);
            chart.MouseMove += Chart_MouseMove;
            chart.MouseLeave += Chart_MouseLeave;
            chart.MouseClick += Chart_MouseClick;
            chart.Resize += Chart_Resize;
        }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                if (!enabled) Clear();
            }
        }

        public int HoverDelayMilliseconds
        {
            get { return hoverTimer.Interval; }
            set { hoverTimer.Interval = Math.Max(1, Math.Min(10000, value)); }
        }

        private bool TryGetPoint(Point location, out Series series, out DataPoint point)
        {
            series = null;
            point = null;
            if (!enabled || disposed || chart.IsDisposed || chart.ChartAreas.Count == 0 ||
                chart.Series.Count == 0 || !chart.ClientRectangle.Contains(location)) return false;
            HitTestResult hit = chart.HitTest(location.X, location.Y);
            if (hit.ChartElementType != ChartElementType.DataPoint || hit.Series == null ||
                hit.PointIndex < 0 || hit.PointIndex >= hit.Series.Points.Count) return false;
            DataPoint candidate = hit.Series.Points[hit.PointIndex];
            if (candidate.IsEmpty || candidate.Tag == null) return false;
            series = hit.Series;
            point = candidate;
            return true;
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (!TryGetPoint(e.Location, out Series series, out DataPoint point))
            {
                CancelHover();
                return;
            }
            hoverLocation = e.Location;
            if (ReferenceEquals(hoverPoint, point) && ReferenceEquals(hoverSeries, series)) return;
            CancelHover();
            hoverPoint = point;
            hoverSeries = series;
            if (!pinnedPanel.Visible) hoverTimer.Start();
        }

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            hoverTimer.Stop();
            if (disposed || pinnedPanel.Visible || hoverPoint == null) return;
            // Recheck the mouse position: a timer may fire after scrolling, zooming,
            // a series redraw or a delayed mouse-leave event.
            Point location = chart.PointToClient(Control.MousePosition);
            if (!TryGetPoint(location, out Series series, out DataPoint point) ||
                !ReferenceEquals(point, hoverPoint) || !ReferenceEquals(series, hoverSeries))
            {
                CancelHover();
                return;
            }
            hoverLocation = location;
            string content = formatPoint(series, point);
            if (!string.IsNullOrWhiteSpace(content))
                hoverTip.Show(content, chart, hoverLocation.X + 15, hoverLocation.Y + 18, 12000);
        }

        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (!TryGetPoint(e.Location, out Series series, out DataPoint point)) return;
            string content = formatPoint(series, point);
            if (string.IsNullOrWhiteSpace(content)) return;
            CancelHover();
            pinnedBody.Text = content;
            PositionPinnedPanel(e.Location);
            pinnedPanel.Visible = true;
            pinnedPanel.BringToFront();
        }

        private void PositionPinnedPanel(Point anchor)
        {
            // Keep the card inside the plotting control, even near the right/bottom edges.
            int x = anchor.X + 18;
            int y = anchor.Y + 18;
            if (x + pinnedPanel.Width > chart.ClientSize.Width - 4)
                x = anchor.X - pinnedPanel.Width - 10;
            if (y + pinnedPanel.Height > chart.ClientSize.Height - 4)
                y = anchor.Y - pinnedPanel.Height - 10;
            pinnedPanel.Location = new Point(
                Math.Max(0, Math.Min(x, Math.Max(0, chart.ClientSize.Width - pinnedPanel.Width - 4))),
                Math.Max(0, Math.Min(y, Math.Max(0, chart.ClientSize.Height - pinnedPanel.Height - 4))));
        }

        private void Chart_Resize(object sender, EventArgs e)
        {
            if (!pinnedPanel.Visible) return;
            pinnedPanel.Location = new Point(
                Math.Max(0, Math.Min(pinnedPanel.Left, Math.Max(0, chart.ClientSize.Width - pinnedPanel.Width - 4))),
                Math.Max(0, Math.Min(pinnedPanel.Top, Math.Max(0, chart.ClientSize.Height - pinnedPanel.Height - 4))));
        }

        private void Chart_MouseLeave(object sender, EventArgs e) { CancelHover(); }

        private void CancelHover()
        {
            hoverTimer.Stop();
            if (!chart.IsDisposed) hoverTip.Hide(chart);
            hoverSeries = null;
            hoverPoint = null;
        }

        /// <summary>Call before replacing the chart's series or changing its axes.</summary>
        public void Clear()
        {
            CancelHover();
            pinnedPanel.Visible = false;
        }

        public void Dispose()
        {
            if (disposed) return;
            Clear();
            disposed = true;
            chart.MouseMove -= Chart_MouseMove;
            chart.MouseLeave -= Chart_MouseLeave;
            chart.MouseClick -= Chart_MouseClick;
            chart.Resize -= Chart_Resize;
            hoverTimer.Tick -= HoverTimer_Tick;
            hoverTimer.Dispose();
            hoverTip.Dispose();
            pinnedPanel.Dispose();
        }
    }
}
