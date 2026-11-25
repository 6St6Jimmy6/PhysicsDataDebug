using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    // A lightweight 3D wireframe renderer. The geometry is real XYZ data; only
    // the final screen projection is two-dimensional. No additional libraries,
    // OpenGL drivers or native dependencies are required by the .NET 4.7.2 app.
    public sealed class Suspension3DScene
    {
        public sealed class Segment
        {
            public Vector3 A;
            public Vector3 B;
            public Color Color;
            public float Width;
            public string Name;
        }

        public sealed class Marker
        {
            public Vector3 Position;
            public Color Color;
            public string Name;
        }

        public readonly List<Segment> Segments = new List<Segment>();
        public readonly List<Marker> Markers = new List<Marker>();

        public void AddLine(Vector3 a, Vector3 b, Color color, string name, float width = 2f)
        {
            if (!Valid(a) || !Valid(b)) return;
            Segments.Add(new Segment { A = a, B = b, Color = color, Width = width, Name = name });
        }

        public void AddPoint(Vector3 position, Color color, string name)
        {
            if (!Valid(position)) return;
            Markers.Add(new Marker { Position = position, Color = color, Name = name });
        }

        public static bool Valid(Vector3 p) =>
            Finite(p.X) && Finite(p.Y) && Finite(p.Z) &&
            Math.Abs(p.X) < 100000f && Math.Abs(p.Y) < 100000f && Math.Abs(p.Z) < 100000f;

        private static bool Finite(float v) => !float.IsNaN(v) && !float.IsInfinity(v);

        public bool GetBounds(out Vector3 minimum, out Vector3 maximum)
        {
            minimum = new Vector3(float.MaxValue);
            maximum = new Vector3(float.MinValue);
            int count = 0;
            foreach (Segment segment in Segments)
            {
                minimum = Vector3.Min(minimum, Vector3.Min(segment.A, segment.B));
                maximum = Vector3.Max(maximum, Vector3.Max(segment.A, segment.B));
                count += 2;
            }
            foreach (Marker marker in Markers)
            {
                minimum = Vector3.Min(minimum, marker.Position);
                maximum = Vector3.Max(maximum, marker.Position);
                count++;
            }
            return count > 0;
        }
    }

    public sealed class SuspensionCameraChangedEventArgs : EventArgs
    {
        public decimal Azimuth { get; }
        public decimal Elevation { get; }
        public decimal Zoom { get; }

        public SuspensionCameraChangedEventArgs(decimal azimuth, decimal elevation, decimal zoom)
        {
            Azimuth = azimuth;
            Elevation = elevation;
            Zoom = zoom;
        }
    }

    /// <summary>
    /// Mouse left-drag: orbit; right/middle-drag: pan; wheel: zoom.
    /// Camera values can be edited in the Designer-owned form toolbar.
    /// </summary>
    public sealed class Suspension3DView : Control
    {
        private readonly ToolTip pointToolTip = new ToolTip();
        private Suspension3DScene scene = new Suspension3DScene();
        private bool dragging;
        private MouseButtons dragButton;
        private Point previousMouse;
        private PointF pan;
        private string lastTooltip = "";
        private float azimuth = 32f;
        private float elevation = 20f;
        private float zoom = 1f;

        // Keep the camera fixed in the vehicle's lateral reference frame.
        // Re-fitting to the live scene bounds every tick made the entire
        // suspension drift across the screen as the car steered/rolled.
        private Vector3 frameCenter;
        private float frameRadius = 1f;
        private bool frameLocked;

        public event EventHandler<SuspensionCameraChangedEventArgs> CameraChanged;

        public Suspension3DView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(12, 14, 18);
            ForeColor = Color.Gainsboro;
            Font = new Font("Arial", 9f);
            TabStop = true;
            pointToolTip.AutoPopDelay = 7500;
            pointToolTip.InitialDelay = 300;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                scene = MakeDesignerPreview();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Suspension3DScene Scene
        {
            get => scene;
            set { scene = value ?? new Suspension3DScene(); Invalidate(); }
        }

        [DefaultValue(false)]
        public bool Perspective { get; set; }

        [DefaultValue(true)]
        public bool ShowGrid { get; set; } = true;

        [DefaultValue(false)]
        public bool ShowPointNames { get; set; }

        [DefaultValue(true)]
        public bool ShowLegend { get; set; } = true;

        [DefaultValue(false)]
        public bool GroundFollowsTires { get; set; }

        // Fit a common lower supporting plane y = slope*x + offset to the
        // two rendered tire outlines, with no longitudinal pitch. A line
        // through the two vertically lowest vertices alone can cut into a
        // cambered tire after the plane tilts. Instead, equalize the minimum
        // of y - slope*x for each tire; every wireframe vertex is then on or
        // above the plane and each tire has at least one contact vertex.
        private void GetGroundPlane(out double slope, out double offset)
        {
            slope = 0d;
            offset = 0d;
            if (!GroundFollowsTires) return;

            var left = new List<Vector3>();
            var right = new List<Vector3>();
            foreach (var segment in scene.Segments)
            {
                if (segment.Name == null || !segment.Name.EndsWith(" tire", StringComparison.Ordinal))
                    continue;
                List<Vector3> points;
                if (segment.Name.StartsWith("FL ", StringComparison.Ordinal) ||
                    segment.Name.StartsWith("RL ", StringComparison.Ordinal)) points = left;
                else if (segment.Name.StartsWith("FR ", StringComparison.Ordinal) ||
                         segment.Name.StartsWith("RR ", StringComparison.Ordinal)) points = right;
                else continue;
                points.Add(segment.A);
                points.Add(segment.B);
            }

            if (left.Count == 0 && right.Count == 0) return;
            offset = Math.Min(TireSupport(left, 0d), TireSupport(right, 0d));
            if (left.Count == 0 || right.Count == 0) return;

            // Use actual lateral order, not an assumed sign convention.
            if (left.Min(p => p.X) > right.Min(p => p.X))
            {
                var swap = left;
                left = right;
                right = swap;
            }
            double gap = (double)right.Min(p => p.X) - left.Max(p => p.X);
            // Incomplete/corrupt or overlapping tire outlines cannot safely
            // use the monotonic two-tire fit. Retain a horizontal support.
            if (gap <= 0.001d) return;
            double minY = Math.Min(left.Min(p => p.Y), right.Min(p => p.Y));
            double maxY = Math.Max(left.Max(p => p.Y), right.Max(p => p.Y));
            double bound = (maxY - minY) / gap + 1d;
            double lo = -bound, hi = bound;
            for (int i = 0; i < 32; i++)
            {
                double mid = (lo + hi) * 0.5d;
                if (TireSupport(left, mid) < TireSupport(right, mid)) lo = mid;
                else hi = mid;
            }
            slope = (lo + hi) * 0.5d;
            offset = Math.Min(TireSupport(left, slope), TireSupport(right, slope));
        }

        private static double TireSupport(List<Vector3> points, double slope)
        {
            double support = double.PositiveInfinity;
            foreach (Vector3 p in points)
                support = Math.Min(support, p.Y - slope * p.X);
            return support;
        }

        private static Vector3 GroundPoint(float x, float z, double slope, double offset) =>
            new Vector3(x, (float)(slope * x + offset), z);

        [DefaultValue("SUSPENSION")]
        public string ViewTitle { get; set; } = "SUSPENSION";

        [Browsable(false)]
        public float Azimuth => azimuth;
        [Browsable(false)]
        public float Elevation => elevation;
        [Browsable(false)]
        public float Zoom => zoom;

        public void SetCamera(float newAzimuth, float newElevation, float newZoom)
        {
            azimuth = ((newAzimuth % 360f) + 360f) % 360f;
            elevation = Math.Max(-89f, Math.Min(89f, newElevation));
            zoom = Math.Max(0.20f, Math.Min(8f, newZoom));
            Invalidate();
        }

        public void ResetPan()
        {
            pan = PointF.Empty;
            Invalidate();
        }

        // Recalculate the one-time camera framing after a new car/session is
        // selected. Normal telemetry updates never move the camera center.
        public void ResetFraming()
        {
            frameLocked = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right &&
                e.Button != MouseButtons.Middle) return;
            Focus();
            dragging = true;
            dragButton = e.Button;
            previousMouse = e.Location;
            Capture = true;
            Cursor = Cursors.SizeAll;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != dragButton) return;
            dragging = false;
            Capture = false;
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragging)
            {
                int dx = e.X - previousMouse.X;
                int dy = e.Y - previousMouse.Y;
                previousMouse = e.Location;
                if (dragButton == MouseButtons.Left)
                {
                    SetCamera(azimuth + dx * 0.55f, elevation + dy * 0.55f, zoom);
                    RaiseCameraChanged();
                }
                else
                {
                    pan.X += dx;
                    pan.Y += dy;
                    Invalidate();
                }
                return;
            }
            Suspension3DScene.Marker nearest = null;
            float bestDistance = 110f;
            if (TryProjection(out Vector3 center, out float radius, out float pixelScale))
            {
                foreach (Suspension3DScene.Marker marker in scene.Markers)
                {
                    PointF screen = Project(marker.Position, center, radius, pixelScale);
                    float px = screen.X - e.X;
                    float py = screen.Y - e.Y;
                    float distSquared = px * px + py * py;
                    if (distSquared < bestDistance)
                    {
                        bestDistance = distSquared;
                        nearest = marker;
                    }
                }
            }
            string message = nearest == null ? "" :
                nearest.Name + "\nX: " + nearest.Position.X.ToString("F3") + " m" +
                "\nY: " + nearest.Position.Y.ToString("F3") + " m" +
                "\nZ: " + nearest.Position.Z.ToString("F3") + " m";
            if (message == lastTooltip) return;
            lastTooltip = message;
            pointToolTip.SetToolTip(this, message);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            SetCamera(azimuth, elevation, zoom * (float)Math.Pow(1.12, e.Delta / 120d));
            RaiseCameraChanged();
        }

        private void RaiseCameraChanged()
        {
            CameraChanged?.Invoke(this, new SuspensionCameraChangedEventArgs(
                (decimal)azimuth, (decimal)elevation, (decimal)(zoom * 100f)));
        }

        private bool TryProjection(out Vector3 center, out float radius, out float pixelScale)
        {
            center = Vector3.Zero;
            radius = 1f;
            pixelScale = 1f;
            if (ClientSize.Width <= 4 || ClientSize.Height <= 4 ||
                !scene.GetBounds(out Vector3 min, out Vector3 max)) return false;

            if (!frameLocked)
            {
                Vector3 midpoint = (min + max) * 0.5f;
                // Never follow the live lateral bounds: X = 0 is the fixed
                // vehicle centerline, including while the wheels are turning.
                frameCenter = new Vector3(0f, midpoint.Y, midpoint.Z);
                Vector3 extent = max - min;
                float lateralReach = Math.Max(Math.Abs(min.X), Math.Abs(max.X));
                frameRadius = Math.Max(0.3f,
                    Math.Max(lateralReach, Math.Max(extent.Y, extent.Z) * 0.5f));

                // While only part of the menu-time geometry is available,
                // keep fitting provisionally. Lock only once both wheel pivots
                // are present so temporary unreadable fields cannot fix a
                // misleading camera center or scale for the whole session.
                frameLocked = HasCompleteAxle(scene);
            }

            center = frameCenter;
            radius = frameRadius;
            pixelScale = (Math.Min(ClientSize.Width, ClientSize.Height) * 0.34f / radius) * zoom;
            return true;
        }

        private static bool HasCompleteAxle(Suspension3DScene geometry)
        {
            Vector3? firstPivot = null;
            foreach (Suspension3DScene.Marker marker in geometry.Markers)
            {
                if (marker.Name == null ||
                    !marker.Name.EndsWith(" wheel pivot", StringComparison.Ordinal))
                    continue;
                if (!firstPivot.HasValue)
                    firstPivot = marker.Position;
                else
                {
                    float distance = Vector3.Distance(firstPivot.Value, marker.Position);
                    return geometry.Segments.Count >= 8 && distance > 0.35f && distance < 8f;
                }
            }
            return false;
        }

        private float Depth(Vector3 p, Vector3 center)
        {
            float yaw = azimuth * (float)(Math.PI / 180d);
            float elev = elevation * (float)(Math.PI / 180d);
            Vector3 d = p - center;
            float z1 = d.X * (float)Math.Sin(yaw) + d.Z * (float)Math.Cos(yaw);
            return d.Y * (float)Math.Sin(elev) + z1 * (float)Math.Cos(elev);
        }

        private PointF Project(Vector3 p, Vector3 center, float radius, float pixelScale)
        {
            float yaw = azimuth * (float)(Math.PI / 180d);
            float elev = elevation * (float)(Math.PI / 180d);
            Vector3 d = p - center;
            float xx = d.X * (float)Math.Cos(yaw) - d.Z * (float)Math.Sin(yaw);
            float z1 = d.X * (float)Math.Sin(yaw) + d.Z * (float)Math.Cos(yaw);
            float yy = d.Y * (float)Math.Cos(elev) - z1 * (float)Math.Sin(elev);
            float depth = d.Y * (float)Math.Sin(elev) + z1 * (float)Math.Cos(elev);
            float persp = 1f;
            if (Perspective)
            {
                float cameraDistance = radius * 5f;
                persp = cameraDistance / Math.Max(radius * 0.5f, cameraDistance - depth);
            }
            return new PointF(ClientSize.Width * 0.5f + pan.X + xx * pixelScale * persp,
                              ClientSize.Height * 0.53f + pan.Y - yy * pixelScale * persp);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            using (var headerBrush = new SolidBrush(Color.FromArgb(230, 235, 239)))
                g.DrawString(ViewTitle, Font, headerBrush, 11f, 8f);

            if (!TryProjection(out Vector3 center, out float radius, out float scale))
            {
                using (var hintBrush = new SolidBrush(Color.FromArgb(155, 165, 178)))
                    g.DrawString("Waiting for suspension geometry data", Font, hintBrush, 12f, 36f);
                DrawHint(g);
                return;
            }

            if (ShowGrid) DrawGrid(g, center, radius, scale);

            // Painter's sorting gives an intuitive rear-to-front wireframe even
            // when arms overlap. It is not a solid-surface/occlusion renderer.
            foreach (Suspension3DScene.Segment segment in scene.Segments.OrderBy(s =>
                (Depth(s.A, center) + Depth(s.B, center)) * 0.5f))
            {
                PointF a = Project(segment.A, center, radius, scale);
                PointF b = Project(segment.B, center, radius, scale);
                if (!Finite(a) || !Finite(b)) continue;
                using (var pen = new Pen(segment.Color, segment.Width))
                    g.DrawLine(pen, a, b);
            }

            // Points and labels are drawn last for legibility.
            foreach (Suspension3DScene.Marker marker in scene.Markers.OrderBy(m => Depth(m.Position, center)))
            {
                PointF pt = Project(marker.Position, center, radius, scale);
                if (!Finite(pt)) continue;
                using (var brush = new SolidBrush(marker.Color))
                    g.FillEllipse(brush, pt.X - 3, pt.Y - 3, 6, 6);
                if (ShowPointNames)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(210, 225, 228, 234)))
                        g.DrawString(marker.Name, Font, brush, pt.X + 6, pt.Y - 8);
                }
            }

            if (ShowLegend) DrawLegend(g);
            DrawHint(g);
        }

        private static bool Finite(PointF p) =>
            !float.IsNaN(p.X) && !float.IsInfinity(p.X) &&
            !float.IsNaN(p.Y) && !float.IsInfinity(p.Y) &&
            Math.Abs(p.X) < 1000000f && Math.Abs(p.Y) < 1000000f;

        private void DrawGrid(Graphics g, Vector3 center, float radius, float scale)
        {
            // Fixed Y=0 by default, or a laterally tilted tire support plane.
            // The XYZ arrows retain their vehicle-relative directions.
            GetGroundPlane(out double slope, out double offset);
            float step = radius < 1.5f ? 0.25f : radius < 4f ? 0.5f : 1f;
            float half = Math.Min(12f, Math.Max(1.5f, radius * 1.4f));
            float minX = (float)Math.Floor((center.X - half) / step) * step;
            float minZ = (float)Math.Floor((center.Z - half) / step) * step;
            float maxX = center.X + half;
            float maxZ = center.Z + half;
            using (var pen = new Pen(Color.FromArgb(37, 82, 93, 112), 1f))
            {
                for (float x = minX; x <= maxX; x += step)
                    DrawSegment(g, pen, GroundPoint(x, minZ, slope, offset), GroundPoint(x, maxZ, slope, offset), center, radius, scale);
                for (float z = minZ; z <= maxZ; z += step)
                    DrawSegment(g, pen, GroundPoint(minX, z, slope, offset), GroundPoint(maxX, z, slope, offset), center, radius, scale);
            }
            Vector3 axisOrigin = GroundPoint(center.X, center.Z, slope, offset);
            DrawAxis(g, center, radius, scale, axisOrigin, Vector3.UnitX, Color.FromArgb(240, 120, 120), "X");
            DrawAxis(g, center, radius, scale, axisOrigin, Vector3.UnitY, Color.FromArgb(155, 235, 150), "Y");
            DrawAxis(g, center, radius, scale, axisOrigin, Vector3.UnitZ, Color.FromArgb(110, 170, 255), "Z");
        }

        private void DrawAxis(Graphics g, Vector3 center, float radius, float scale,
            Vector3 start, Vector3 direction, Color color, string name)
        {
            Vector3 end = start + direction * Math.Max(0.35f, radius * 0.55f);
            using (var pen = new Pen(color, 2f))
                DrawSegment(g, pen, start, end, center, radius, scale);
            PointF projected = Project(end, center, radius, scale);
            if (Finite(projected))
                using (var brush = new SolidBrush(color))
                    g.DrawString(name, Font, brush, projected.X + 3, projected.Y + 3);
        }

        private void DrawSegment(Graphics g, Pen pen, Vector3 a, Vector3 b,
            Vector3 center, float radius, float scale)
        {
            PointF aa = Project(a, center, radius, scale);
            PointF bb = Project(b, center, radius, scale);
            if (Finite(aa) && Finite(bb)) g.DrawLine(pen, aa, bb);
        }

        private void DrawLegend(Graphics g)
        {
            LegendEntry[] entries =
            {
                new LegendEntry("Upper arm", Color.FromArgb(73, 211, 178), true, false),
                new LegendEntry("Lower arm", Color.FromArgb(242, 173, 91), true, false),
                new LegendEntry("Steering rod", Color.FromArgb(238, 115, 126), true, false),
                new LegendEntry("Push rod", Color.FromArgb(192, 142, 242), true, false),
                new LegendEntry("Upright / hub", Color.FromArgb(219, 225, 233), true, false),
                new LegendEntry("Left wheel / tire", Color.FromArgb(120, 209, 120), true, false),
                new LegendEntry("Right wheel / tire", Color.FromArgb(102, 174, 251), true, false),
                new LegendEntry("Colored pickup point", Color.FromArgb(235, 235, 235), false, true),
                new LegendEntry("Wheel pivot", Color.FromArgb(120, 209, 120), false, true),
                new LegendEntry("XY instant center (projected)", Color.FromArgb(155, 170, 180), false, true),
                new LegendEntry("XY roll center (projected)", Color.LimeGreen, false, true),
                new LegendEntry("Vehicle CoM height", Color.FromArgb(124, 255, 117), false, true)
            };

            const string axisText = "Axes: X lateral, Y vertical, Z longitudinal";
            const float width = 245f;
            const float rowHeight = 17f;
            const float padding = 10f;
            const float swatchWidth = 22f;
            const float sectionGap = 7f;
            float height = padding * 2f + 18f + sectionGap +
                entries.Length * rowHeight + sectionGap + 18f + 16f;
            RectangleF box = new RectangleF(
                Math.Max(8f, ClientSize.Width - width - 10f),
                30f,
                width,
                Math.Min(height, Math.Max(120f, ClientSize.Height - 42f)));

            using (var background = new SolidBrush(Color.FromArgb(185, 10, 12, 18)))
            using (var borderPen = new Pen(Color.FromArgb(130, 86, 98, 114)))
            using (var titleBrush = new SolidBrush(Color.FromArgb(236, 240, 245)))
            using (var textBrush = new SolidBrush(Color.FromArgb(212, 221, 229)))
            using (var smallBrush = new SolidBrush(Color.FromArgb(165, 180, 194)))
            using (var fontBold = new Font(Font, FontStyle.Bold))
            using (var smallFont = new Font(Font.FontFamily, Math.Max(7f, Font.Size - 1f), FontStyle.Regular))
            {
                g.FillRectangle(background, box);
                g.DrawRectangle(borderPen, box.X, box.Y, box.Width, box.Height);

                float x = box.X + padding;
                float y = box.Y + padding;
                g.DrawString("Legend", fontBold, titleBrush, x, y);
                y += 18f + sectionGap * 0.5f;

                foreach (LegendEntry entry in entries)
                {
                    if (y + rowHeight > box.Bottom - 28f) break;
                    float midY = y + rowHeight * 0.5f;
                    using (var symbolPen = new Pen(entry.Color, entry.IsLine ? 2.2f : 1.6f))
                    using (var symbolBrush = new SolidBrush(entry.Color))
                    {
                        if (entry.IsLine)
                        {
                            g.DrawLine(symbolPen, x, midY, x + swatchWidth, midY);
                            if (entry.IsPoint)
                                g.FillEllipse(symbolBrush, x + swatchWidth * 0.5f - 3f, midY - 3f, 6f, 6f);
                        }
                        else
                        {
                            g.FillEllipse(symbolBrush, x + swatchWidth * 0.5f - 4f, midY - 4f, 8f, 8f);
                            g.DrawEllipse(symbolPen, x + swatchWidth * 0.5f - 4f, midY - 4f, 8f, 8f);
                        }
                    }
                    g.DrawString(entry.Text, Font, textBrush, x + swatchWidth + 8f, y - 1f);
                    y += rowHeight;
                }

                y += sectionGap * 0.35f;
                if (y + 28f < box.Bottom)
                {
                    g.DrawString(axisText, smallFont, smallBrush, x, y);
                    y += 14f;
                    g.DrawString("Hover any point for its name and XYZ position.", smallFont, smallBrush, x, y);
                }
            }
        }

        private sealed class LegendEntry
        {
            public string Text;
            public Color Color;
            public bool IsLine;
            public bool IsPoint;

            public LegendEntry(string text, Color color, bool isLine, bool isPoint)
            {
                Text = text;
                Color = color;
                IsLine = isLine;
                IsPoint = isPoint;
            }
        }

        private void DrawHint(Graphics g)
        {
            const string hint = "Drag: orbit   Right-drag: pan   Wheel: zoom   Hover: XYZ";
            SizeF size = g.MeasureString(hint, Font);
            using (var brush = new SolidBrush(Color.FromArgb(153, 164, 179)))
                g.DrawString(hint, Font, brush,
                    10f, Math.Max(30f, ClientSize.Height - size.Height - 6f));
        }

        private static Suspension3DScene MakeDesignerPreview()
        {
            var demo = new Suspension3DScene();
            Color upper = Color.FromArgb(73, 211, 178);
            Color lower = Color.FromArgb(242, 173, 91);
            Color steering = Color.FromArgb(238, 115, 126);
            foreach (int sign in new[] { -1, 1 })
            {
                float x = sign * 0.65f;
                Vector3 bodyUpperFront = new Vector3(x * 0.45f, 0.8f, -0.16f);
                Vector3 bodyUpperRear = new Vector3(x * 0.45f, 0.8f, 0.16f);
                Vector3 bodyLowerFront = new Vector3(x * 0.42f, 0.3f, -0.20f);
                Vector3 bodyLowerRear = new Vector3(x * 0.42f, 0.3f, 0.20f);
                Vector3 spindleUpper = new Vector3(x, 0.72f, 0f);
                Vector3 spindleLower = new Vector3(x, 0.22f, 0f);
                demo.AddLine(bodyUpperFront, spindleUpper, upper, "Upper front arm");
                demo.AddLine(bodyUpperRear, spindleUpper, upper, "Upper rear arm");
                demo.AddLine(bodyLowerFront, spindleLower, lower, "Lower front arm");
                demo.AddLine(bodyLowerRear, spindleLower, lower, "Lower rear arm");
                demo.AddLine(bodyUpperFront, bodyUpperRear, upper, "Upper chassis joints");
                demo.AddLine(bodyLowerFront, bodyLowerRear, lower, "Lower chassis joints");
                demo.AddLine(spindleLower, spindleUpper, Color.Gainsboro, "Upright");
                demo.AddLine(new Vector3(x * 0.4f, 0.52f, 0.16f), new Vector3(x, 0.5f, 0.13f),
                    steering, "Steering rod");
                for (int i = 0; i < 24; i++)
                {
                    double a = 2d * Math.PI * i / 24d;
                    double b = 2d * Math.PI * (i + 1) / 24d;
                    Vector3 p = new Vector3(x, 0.47f + 0.28f * (float)Math.Cos(a), 0.28f * (float)Math.Sin(a));
                    Vector3 q = new Vector3(x, 0.47f + 0.28f * (float)Math.Cos(b), 0.28f * (float)Math.Sin(b));
                    demo.AddLine(p, q, Color.FromArgb(117, 146, 172), sign < 0 ? "FL tire" : "FR tire", 1.4f);
                }
                demo.AddPoint(spindleUpper, Color.White, sign < 0 ? "FL upper spindle" : "FR upper spindle");
                demo.AddPoint(spindleLower, Color.White, sign < 0 ? "FL lower spindle" : "FR lower spindle");
            }
            return demo;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) pointToolTip.Dispose();
            base.Dispose(disposing);
        }
    }
}
