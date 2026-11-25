using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    // XYZ is projected in software. The WinForms Chart's built-in 3D mode
    // assigns depth by series, not by a numeric Z value for each point.
    internal sealed class OfflineScatter3D : Control
    {
        internal struct Sample
        {
            internal readonly double X, Y, Z, ColorValue;
            internal readonly Color Color;
            internal readonly string Dataset;
            internal Sample(double x, double y, double z, double colorValue, Color color, string dataset)
            { X = x; Y = y; Z = z; ColorValue = colorValue; Color = color; Dataset = dataset; }
        }

        internal sealed class Plot
        {
            internal readonly string Title;
            internal readonly List<Sample> Points = new List<Sample>();
            internal Plot(string title) { Title = title; }
        }

        private sealed class Bounds
        {
            internal double X0 = double.PositiveInfinity, X1 = double.NegativeInfinity;
            internal double Y0 = double.PositiveInfinity, Y1 = double.NegativeInfinity;
            internal double Z0 = double.PositiveInfinity, Z1 = double.NegativeInfinity;
        }

        private List<Plot> plots = new List<Plot>();
        private Bounds bounds = new Bounds();
        private OfflineChartOptions options = new OfflineChartOptions();
        private readonly ToolTip tooltip = new ToolTip();
        private float yaw = 35f, pitch = 23f, zoom = 1f;
        private Point lastMouse;
        private PointF pan;
        private MouseButtons drag;
        private readonly List<RectangleF> cells = new List<RectangleF>();
        private double cosYaw, sinYaw, cosPitch, sinPitch;

        internal OfflineScatter3D()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.Black;
            ForeColor = Color.White;
            Font = new Font("Arial", 9f);
            TabStop = true;
        }

        private double XValue(double x) => options.XLogarithmic ? Math.Log(x, options.XLogBase) : x;
        private double YValue(double y) => options.YLogarithmic ? Math.Log(y, options.YLogBase) : y;
        private static bool Finite(double x) => !double.IsNaN(x) && !double.IsInfinity(x);
        private static void Expand(ref double min, ref double max)
        {
            if (!Finite(min) || !Finite(max)) { min = 0; max = 1; }
            else if (max <= min) { double delta = Math.Max(0.5, Math.Abs(min) * 0.01); min -= delta; max += delta; }
        }
        internal void SetData(List<Plot> data, OfflineChartOptions settings)
        {
            plots = data;
            options = settings.Clone();
            bounds = new Bounds();
            foreach (Plot plot in plots)
                foreach (Sample p in plot.Points)
                {
                    double x = XValue(p.X), y = YValue(p.Y);
                    bounds.X0 = Math.Min(bounds.X0, x); bounds.X1 = Math.Max(bounds.X1, x);
                    bounds.Y0 = Math.Min(bounds.Y0, y); bounds.Y1 = Math.Max(bounds.Y1, y);
                    bounds.Z0 = Math.Min(bounds.Z0, p.Z); bounds.Z1 = Math.Max(bounds.Z1, p.Z);
                }
            if (options.XMinimum.HasValue && options.XMaximum.HasValue)
            { bounds.X0 = XValue(options.XMinimum.Value); bounds.X1 = XValue(options.XMaximum.Value); }
            if (options.YMinimum.HasValue && options.YMaximum.HasValue)
            { bounds.Y0 = YValue(options.YMinimum.Value); bounds.Y1 = YValue(options.YMaximum.Value); }
            // Z/color min/max always describe the color scale, not a geometry
            // clipping range; Z geometry uses the visible samples' own range.
            Expand(ref bounds.X0, ref bounds.X1); Expand(ref bounds.Y0, ref bounds.Y1); Expand(ref bounds.Z0, ref bounds.Z1);
            BackColor = options.Background;
            hoverTimer.Stop();
            tooltip.Hide(this);
            tooltip.SetToolTip(this, "");
            tooltip.InitialDelay = options.PointTooltipDelayMs;
            Invalidate();
        }

        private void UpdateProjection()
        {
            double a = yaw * Math.PI / 180, b = pitch * Math.PI / 180;
            cosYaw = Math.Cos(a); sinYaw = Math.Sin(a);
            cosPitch = Math.Cos(b); sinPitch = Math.Sin(b);
        }
        private PointF Project(double x, double y, double z, RectangleF cell)
        {
            double dx = x - 0.5, dy = y - 0.5, dz = z - 0.5;
            double xx = dx * cosYaw - dz * sinYaw;
            double zz = dx * sinYaw + dz * cosYaw;
            double yy = dy * cosPitch - zz * sinPitch;
            float scale = Math.Max(1, Math.Min(cell.Width - 48, cell.Height - 60) * 0.63f) * zoom;
            return new PointF(cell.X + cell.Width / 2 + pan.X + (float)xx * scale,
                cell.Y + cell.Height / 2 + pan.Y - (float)yy * scale);
        }
        private PointF Project(Sample p, RectangleF cell) => Project(
            (XValue(p.X) - bounds.X0) / (bounds.X1 - bounds.X0),
            (YValue(p.Y) - bounds.Y0) / (bounds.Y1 - bounds.Y0),
            (p.Z - bounds.Z0) / (bounds.Z1 - bounds.Z0), cell);

        private static bool Valid(PointF p) => Finite(p.X) && Finite(p.Y);
        private static Color Readable(Color color) => color.GetBrightness() > 0.6f ? Color.Black : Color.Gainsboro;
        private string AxisValue(double value, bool log, double logBase, int decimals)
        {
            double actual = log ? Math.Pow(logBase, value) : value;
            return actual.ToString("F" + decimals, CultureInfo.CurrentCulture);
        }
        private void Line(Graphics g, Pen pen, RectangleF cell, double x, double y, double z,
            double x2, double y2, double z2)
        { g.DrawLine(pen, Project(x, y, z, cell), Project(x2, y2, z2, cell)); }

        private void DrawAxes(Graphics g, RectangleF cell)
        {
            Color ink = Readable(BackColor);
            using (var grid = new Pen(Color.FromArgb(90, ink)))
            using (var xpen = new Pen(Color.FromArgb(235, 105, 105), 1.7f))
            using (var ypen = new Pen(Color.FromArgb(120, 220, 135), 1.7f))
            using (var zpen = new Pen(Color.FromArgb(105, 165, 255), 1.7f))
            using (var brush = new SolidBrush(ink))
            {
                for (int i = 0; i <= 5; i++)
                {
                    double t = i / 5d;
                    Line(g, grid, cell, t, 0, 0, t, 0, 1);
                    Line(g, grid, cell, 0, 0, t, 1, 0, t);
                    Line(g, grid, cell, 0, t, 0, 0, t, 1);
                }
                Line(g, xpen, cell, 0, 0, 0, 1, 0, 0);
                Line(g, ypen, cell, 0, 0, 0, 0, 1, 0);
                Line(g, zpen, cell, 0, 0, 0, 0, 0, 1);
                for (int i = 0; i <= 2; i++)
                {
                    double t = i / 2d;
                    if (i > 0)
                    {
                        g.DrawString(AxisValue(bounds.X0 + (bounds.X1 - bounds.X0) * t, options.XLogarithmic, options.XLogBase, options.XDecimals), Font, brush, Project(t, 0, 0, cell));
                        g.DrawString(AxisValue(bounds.Y0 + (bounds.Y1 - bounds.Y0) * t, options.YLogarithmic, options.YLogBase, options.YDecimals), Font, brush, Project(0, t, 0, cell));
                        g.DrawString((bounds.Z0 + (bounds.Z1 - bounds.Z0) * t).ToString("G5"), Font, brush, Project(0, 0, t, cell));
                    }
                }
                g.DrawString("X: " + options.X, Font, brush, Project(1.15, 0, 0, cell));
                g.DrawString("Y: " + options.Y, Font, brush, Project(0, 1.15, 0, cell));
                g.DrawString("Z: " + options.Z, Font, brush, Project(0, 0, 1.15, cell));
                g.DrawString("Min: " + AxisValue(bounds.X0, options.XLogarithmic, options.XLogBase, options.XDecimals) + " / " +
                    AxisValue(bounds.Y0, options.YLogarithmic, options.YLogBase, options.YDecimals) + " / " + bounds.Z0.ToString("G5"), Font, brush,
                    Project(0, 0, 0, cell));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            UpdateProjection();
            cells.Clear();
            using (var text = new SolidBrush(Readable(BackColor)))
            {
                if (plots.Count == 0)
                { g.DrawString("No matching 3D samples.", Font, text, 12, 12); return; }
                int columns = plots.Count > 2 ? 2 : 1;
                int rows = (plots.Count + columns - 1) / columns;
                float w = ClientSize.Width / (float)columns;
                float h = Math.Max(1, ClientSize.Height - 23) / (float)rows;
                var brushes = new Dictionary<Color, SolidBrush>();
                try
                {
                    for (int i = 0; i < plots.Count; i++)
                    {
                        var cell = new RectangleF((i % columns) * w, (i / columns) * h, w, h);
                        cells.Add(cell);
                        var state = g.Save();
                        g.SetClip(cell);
                        DrawAxes(g, cell);
                        float size = options.Marker == MarkerStyle.None ? 1 : Math.Max(1, options.MarkerSize);
                        float half = size / 2;
                        var polygon = new PointF[4];
                        // All filtered points are retained. Solid fills avoid creating a GDI object per sample.
                        foreach (Sample p in plots[i].Points)
                        {
                            PointF pt = Project(p, cell);
                            if (!Valid(pt) || !cell.Contains(pt)) continue;
                            if (!brushes.TryGetValue(p.Color, out SolidBrush brush))
                            { brush = new SolidBrush(p.Color); brushes.Add(p.Color, brush); }
                            switch (options.Marker)
                            {
                                case MarkerStyle.Circle:
                                    g.FillEllipse(brush, pt.X - half, pt.Y - half, size, size);
                                    break;
                                case MarkerStyle.Diamond:
                                    polygon[0] = new PointF(pt.X, pt.Y - half);
                                    polygon[1] = new PointF(pt.X + half, pt.Y);
                                    polygon[2] = new PointF(pt.X, pt.Y + half);
                                    polygon[3] = new PointF(pt.X - half, pt.Y);
                                    g.FillPolygon(brush, polygon);
                                    break;
                                case MarkerStyle.Triangle:
                                    polygon[0] = new PointF(pt.X, pt.Y - half);
                                    polygon[1] = new PointF(pt.X + half, pt.Y + half);
                                    polygon[2] = new PointF(pt.X - half, pt.Y + half);
                                    polygon[3] = polygon[0];
                                    g.FillPolygon(brush, polygon);
                                    break;
                                case MarkerStyle.Cross:
                                    float stroke = Math.Max(1, size / 3f);
                                    g.FillRectangle(brush, pt.X - stroke / 2, pt.Y - half, stroke, size);
                                    g.FillRectangle(brush, pt.X - half, pt.Y - stroke / 2, size, stroke);
                                    break;
                                default:
                                    g.FillRectangle(brush, pt.X - half, pt.Y - half, size, size);
                                    break;
                            }
                        }
                        g.DrawString(plots[i].Title, Font, text, cell.X + 8, cell.Y + 6);
                        g.Restore(state);
                    }
                }
                finally { foreach (SolidBrush brush in brushes.Values) brush.Dispose(); }
                g.DrawString("Drag: orbit   Right-drag: pan   Wheel: zoom   Double-click: reset   Hover: XYZ / color", Font, text, 8, Math.Max(0, ClientSize.Height - 19));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right && e.Button != MouseButtons.Middle) return;
            Focus(); drag = e.Button; lastMouse = e.Location; Capture = true;
            hoverTimer.Stop();
            tooltip.Hide(this);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        { base.OnMouseUp(e); drag = MouseButtons.None; Capture = false; }
        protected override void OnMouseCaptureChanged(EventArgs e)
        { base.OnMouseCaptureChanged(e); if (!Capture) drag = MouseButtons.None; }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        { base.OnMouseDoubleClick(e); yaw = 35; pitch = 23; zoom = 1; pan = PointF.Empty; Invalidate(); }
        protected override void OnMouseWheel(MouseEventArgs e)
        { base.OnMouseWheel(e); zoom = Math.Max(0.2f, Math.Min(8f, zoom * (float)Math.Pow(1.12, e.Delta / 120d))); Invalidate(); }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (drag != MouseButtons.None)
            {
                int dx = e.X - lastMouse.X, dy = e.Y - lastMouse.Y;
                lastMouse = e.Location;
                if (dx == 0 && dy == 0) return;
                if (drag == MouseButtons.Left)
                { yaw = (yaw + dx * 0.55f) % 360; pitch = Math.Max(-89, Math.Min(89, pitch + dy * 0.55f)); }
                else { pan.X += dx; pan.Y += dy; }
                Invalidate();
                return;
            }
            // Avoid an O(N) scan for every mouse message. Resolve after the
            // configured hover delay with a WinForms timer instead.
            if (!options.ShowPointTooltips) return;
            lastMouse = e.Location;
            hoverTimer.Stop(); hoverTimer.Interval = Math.Max(1, options.PointTooltipDelayMs); hoverTimer.Start();
        }
        private readonly Timer hoverTimer = new Timer();
        private void ShowNearest(object sender, EventArgs e)
        {
            hoverTimer.Stop();
            if (drag != MouseButtons.None || !options.ShowPointTooltips || !Visible) return;
            UpdateProjection();
            for (int i = 0; i < cells.Count && i < plots.Count; i++)
            {
                if (!cells[i].Contains(lastMouse)) continue;
                Sample? nearest = null;
                double distance = Math.Max(36, options.MarkerSize * options.MarkerSize);
                foreach (Sample p in plots[i].Points)
                {
                    PointF pt = Project(p, cells[i]);
                    double dx = pt.X - lastMouse.X, dy = pt.Y - lastMouse.Y, d = dx * dx + dy * dy;
                    if (d < distance) { nearest = p; distance = d; }
                }
                if (nearest.HasValue)
                {
                    Sample p = nearest.Value;
                    string message = "File: " + p.Dataset + "\n" + options.X + ": " + p.X.ToString("G9") + "\n" + options.Y + ": " + p.Y.ToString("G9") + "\n" + options.Z + ": " + p.Z.ToString("G9");
                    if (options.UseFourthColor) message += "\nColor (" + options.ColorField + "): " + p.ColorValue.ToString("G9");
                    tooltip.Show(message, this, lastMouse.X + 12, lastMouse.Y + 18, 5000);
                }
                else tooltip.Hide(this);
                break;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        { base.OnMouseLeave(e); hoverTimer.Stop(); tooltip.Hide(this); }
        protected override void OnHandleCreated(EventArgs e)
        { base.OnHandleCreated(e); hoverTimer.Tick -= ShowNearest; hoverTimer.Tick += ShowNearest; }
        protected override void Dispose(bool disposing)
        { if (disposing) { hoverTimer.Dispose(); tooltip.Dispose(); } base.Dispose(disposing); }
    }
}
