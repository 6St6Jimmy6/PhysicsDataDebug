using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Live XYZ suspension wireframe. Body mount points and dynamic wheel pivots
    /// use the same frame/height offsets as the former XY geometry chart.
    /// Mouse orbit and zoom are shared by the Front/Rear viewport pair.
    /// </summary>
    public partial class FormSuspensionGeometry : Form
    {
        private bool restoringSettings;
        private bool updatingCamera;
        private bool started;

        private static readonly Color UpperColor = Color.FromArgb(70, 213, 177);
        private static readonly Color LowerColor = Color.FromArgb(243, 175, 88);
        private static readonly Color SteeringColor = Color.FromArgb(241, 109, 128);
        private static readonly Color PushRodColor = Color.FromArgb(192, 142, 242);
        private static readonly Color UprightColor = Color.FromArgb(219, 225, 233);
        private static readonly Color LeftWheelColor = Color.FromArgb(120, 209, 120);
        private static readonly Color RightWheelColor = Color.FromArgb(102, 174, 251);

        public FormSuspensionGeometry()
        {
            InitializeComponent();
            timer1.Enabled = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            front3DView.CameraChanged += View_CameraChanged;
            rear3DView.CameraChanged += View_CameraChanged;
            JsonFormSettings.EnsureFactoryDefaults(this);
            Shown += FormSuspensionGeometry_Shown;
        }

        private void FormSuspensionGeometry_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
            restoringSettings = true;
            try { JsonFormSettings.LoadAllSettings(this); }
            finally { restoringSettings = false; }
            ApplyViewSettings();
            LiveData.FormSuspensionGeometryOpen = true;
        }

        private void FormSuspensionGeometry_Shown(object sender, EventArgs e)
        {
            if (started) return;
            started = true;
            ApplyViewSettings();
            timer1.Enabled = true;
        }

        private void FormSuspensionGeometry_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            JsonFormSettings.SaveAllSettings(this);
            LiveData.FormSuspensionGeometryOpen = false;
        }

        private void SettingsValueChanged(object sender, EventArgs e)
        {
            if (!restoringSettings && !updatingCamera) ApplyViewSettings();
        }

        private void ApplyViewSettings()
        {
            if (restoringSettings) return;
            int ms = Decimal.ToInt32(updateIntervalNumericUpDown.Value);
            if (ms >= 10) timer1.Interval = ms;
            float azimuth = (float)azimuthNumericUpDown.Value;
            float elevation = (float)elevationNumericUpDown.Value;
            float zoom = (float)(zoomNumericUpDown.Value / 100m);
            foreach (Suspension3DView view in new[] { front3DView, rear3DView })
            {
                view.SetCamera(azimuth, elevation, zoom);
                view.Perspective = perspectiveCheckBox.Checked;
                view.ShowGrid = gridCheckBox.Checked;
                view.ShowPointNames = labelsCheckBox.Checked;
                view.Invalidate();
            }
        }

        private void View_CameraChanged(object sender, SuspensionCameraChangedEventArgs e)
        {
            if (updatingCamera || restoringSettings) return;
            updatingCamera = true;
            try
            {
                azimuthNumericUpDown.Value = Clamp(Math.Round(e.Azimuth, 1), azimuthNumericUpDown);
                elevationNumericUpDown.Value = Clamp(Math.Round(e.Elevation, 1), elevationNumericUpDown);
                zoomNumericUpDown.Value = Clamp(Math.Round(e.Zoom, 0), zoomNumericUpDown);
            }
            finally { updatingCamera = false; }
            ApplyViewSettings();
        }

        private static decimal Clamp(decimal value, NumericUpDown control) =>
            Math.Min(control.Maximum, Math.Max(control.Minimum, value));

        private void ViewPreset_Click(object sender, EventArgs e)
        {
            if (sender == frontViewButton) SetCamera(0, 0, 100);
            else if (sender == sideViewButton) SetCamera(90, 0, 100);
            else if (sender == topViewButton) SetCamera(0, 89, 100);
            else SetCamera(32, 20, 100);
            front3DView.ResetPan();
            rear3DView.ResetPan();
            if (sender == resetViewButton)
            {
                front3DView.ResetFraming();
                rear3DView.ResetFraming();
            }
        }

        private void SetCamera(decimal azimuth, decimal elevation, decimal zoom)
        {
            azimuthNumericUpDown.Value = Clamp(azimuth, azimuthNumericUpDown);
            elevationNumericUpDown.Value = Clamp(elevation, elevationNumericUpDown);
            zoomNumericUpDown.Value = Clamp(zoom, zoomNumericUpDown);
            ApplyViewSettings();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Unlike race charts, geometry may be inspected in the Wreckfest menu.
            // A missing/uninitialized telemetry section is skipped, not fatal.
            if (LiveData.Process == null || !FormLiveData.ProcessGet ||
                !FormLiveData.FirstTimeLoad || !FormLiveData.ValuesGet ||
                LiveData.FullDataList.Count == 0) return;

            try
            {
                front3DView.Scene = CaptureAxle("FL", "FR");
                rear3DView.Scene = CaptureAxle("RL", "RR");
            }
            catch (InvalidOperationException) { /* transient memory/config switch */ }
            catch (ArgumentOutOfRangeException) { /* incomplete memory snapshot */ }
            catch (KeyNotFoundException) { /* field unavailable in a custom config */ }
            // Other unexpected exceptions should remain visible to the debugger.
        }

        private sealed class ProjectedWheel
        {
            public Vector3 Pivot = new Vector3(float.NaN);
            public Vector3 TireContact = new Vector3(float.NaN);
            public Vector3 InstantCenter = new Vector3(float.NaN);
        }

        private Suspension3DScene CaptureAxle(string left, string right)
        {
            var scene = new Suspension3DScene();
            ProjectedWheel leftWheel = CaptureWheel(scene, left, LeftWheelColor);
            ProjectedWheel rightWheel = CaptureWheel(scene, right, RightWheelColor);
            if (Suspension3DScene.Valid(leftWheel.TireContact) &&
                Suspension3DScene.Valid(rightWheel.TireContact) &&
                Suspension3DScene.Valid(leftWheel.InstantCenter) &&
                Suspension3DScene.Valid(rightWheel.InstantCenter) &&
                TryIntersectionXY(leftWheel.InstantCenter, leftWheel.TireContact,
                    rightWheel.InstantCenter, rightWheel.TireContact, out Vector3 rollCenter))
            {
                // The original chart calculated roll center only in XY. Place
                // that XY projection on the axle's average Z plane; this is
                // NOT a mathematically derived 3D suspension roll axis.
                rollCenter.Z = (leftWheel.Pivot.Z + rightWheel.Pivot.Z) * 0.5f;
                if (Vector3.Distance(rollCenter, leftWheel.Pivot) < 10f)
                    scene.AddPoint(rollCenter, Color.LimeGreen, "XY roll center (projected)");
            }
            float centerOfMass = Read(TelemetryPrefix.Body, "WF_MassDataOffset", "CenterOfMassHeight");
            if (Finite(centerOfMass) && Math.Abs(centerOfMass) < 10f &&
                Suspension3DScene.Valid(leftWheel.Pivot) && Suspension3DScene.Valid(rightWheel.Pivot))
                scene.AddPoint(new Vector3(0f, centerOfMass,
                    (leftWheel.Pivot.Z + rightWheel.Pivot.Z) * 0.5f),
                    Color.FromArgb(124, 255, 117), "Vehicle center-of-mass height");
            return scene;
        }

        private ProjectedWheel CaptureWheel(Suspension3DScene scene, string prefix, Color wheelColor)
        {
            var projection = new ProjectedWheel();
            float height = Read(prefix, "WF_Suspension2DataOffset", "RideHeight") +
                           Read(TelemetryPrefix.Body, "WF_MassDataOffset", "CenterOfMassHeight");
            Vector3 pivot = ReadVector(prefix, "WF_TireDataOffset", "TireM4", "1", "2", "3");
            if (Suspension3DScene.Valid(pivot) && Finite(height))
                pivot.Y += height;
            else
                pivot = new Vector3(float.NaN);

            projection.Pivot = pivot;
            float[,] orientation = ReadWheelRotation(prefix);
            bool rotate = rotateSpindleCheckBox.Checked && orientation != null;

            // Body positions are fixed relative to the car; spindle positions
            // move with the tire pivot. The optional rotation handles camber/toe
            // when the tire matrix is valid. Disable it for legacy XYZ matching.
            var body = new Dictionary<string, Vector3>();
            var spindle = new Dictionary<string, Vector3>();
            string[] arms = { "UpperFrontArm", "UpperRearArm", "LowerFrontArm", "LowerRearArm", "SteeringRod", "PushRod" };
            foreach (string arm in arms)
            {
                Vector3 bodyPoint = ReadVector(prefix, "WF_SuspensionGeometryDataOffset", "Body" + arm, "X", "Y", "Z");
                Vector3 spindleOffset = ReadVector(prefix, "WF_SuspensionGeometryDataOffset", "Spindle" + arm, "X", "Y", "Z");
                if (Suspension3DScene.Valid(bodyPoint) && Finite(height)) bodyPoint.Y += height;
                else bodyPoint = new Vector3(float.NaN);
                if (Suspension3DScene.Valid(spindleOffset) && Suspension3DScene.Valid(pivot))
                    spindleOffset = pivot + (rotate ? Transform(spindleOffset, orientation) : spindleOffset);
                else spindleOffset = new Vector3(float.NaN);
                // In the menu, partially initialized structures can hold wild
                // coordinates. Exclude outliers instead of shrinking the view.
                if (Suspension3DScene.Valid(pivot) && Suspension3DScene.Valid(bodyPoint) &&
                    Vector3.Distance(bodyPoint, pivot) > 25f) bodyPoint = new Vector3(float.NaN);
                if (Suspension3DScene.Valid(pivot) && Suspension3DScene.Valid(spindleOffset) &&
                    Vector3.Distance(spindleOffset, pivot) > 25f) spindleOffset = new Vector3(float.NaN);
                body[arm] = bodyPoint;
                spindle[arm] = spindleOffset;

                Color color = arm.StartsWith("Upper", StringComparison.Ordinal) ? UpperColor :
                              arm.StartsWith("Lower", StringComparison.Ordinal) ? LowerColor :
                              arm == "SteeringRod" ? SteeringColor : PushRodColor;
                scene.AddLine(bodyPoint, spindleOffset, color, prefix + " " + arm, 2.3f);
                scene.AddPoint(bodyPoint, color, prefix + " body " + arm);
                scene.AddPoint(spindleOffset, color, prefix + " spindle " + arm);
            }

            // Wishbone outlines (front/rear pickups) and an upright between the
            // mean upper/lower joints make the assembly easier to interpret in 3D.
            Join(scene, body, "UpperFrontArm", "UpperRearArm", UpperColor, prefix + " upper chassis");
            Join(scene, spindle, "UpperFrontArm", "UpperRearArm", UpperColor, prefix + " upper spindle");
            Join(scene, body, "LowerFrontArm", "LowerRearArm", LowerColor, prefix + " lower chassis");
            Join(scene, spindle, "LowerFrontArm", "LowerRearArm", LowerColor, prefix + " lower spindle");
            Vector3 upper = Midpoint(spindle["UpperFrontArm"], spindle["UpperRearArm"]);
            Vector3 lower = Midpoint(spindle["LowerFrontArm"], spindle["LowerRearArm"]);
            scene.AddLine(upper, lower, UprightColor, prefix + " upright", 3f);
            scene.AddLine(lower, pivot, Color.FromArgb(146, 160, 173), prefix + " hub", 1.7f);
            scene.AddPoint(pivot, wheelColor, prefix + " wheel pivot");
            AddTireWireframe(scene, prefix, pivot, orientation, wheelColor);

            Vector3 upperBody = Midpoint(body["UpperFrontArm"], body["UpperRearArm"]);
            Vector3 lowerBody = Midpoint(body["LowerFrontArm"], body["LowerRearArm"]);
            if (TryIntersectionXY(spindle["LowerFrontArm"], lowerBody,
                                  spindle["UpperFrontArm"], upperBody, out Vector3 instantCenter) &&
                Suspension3DScene.Valid(pivot) &&
                Vector3.Distance(instantCenter, pivot) < 10f)
            {
                instantCenter.Z = pivot.Z;
                projection.InstantCenter = instantCenter;
                scene.AddPoint(instantCenter, Color.FromArgb(155, 170, 180),
                    prefix + " XY instant center (projected)");
            }
            float radius = Read(prefix, "WF_TireDataOffset", "TireRadius");
            if (Suspension3DScene.Valid(pivot) && Finite(radius) && radius > 0 && radius < 2f)
                projection.TireContact = pivot - new Vector3(0f, radius, 0f);
            return projection;
        }

        // The existing instant/roll-center construction is fundamentally a
        // 2D front-view operation; retain it as an explicitly labeled projection.
        private static bool TryIntersectionXY(Vector3 a, Vector3 b, Vector3 c, Vector3 d, out Vector3 intersection)
        {
            intersection = new Vector3(float.NaN);
            if (!Suspension3DScene.Valid(a) || !Suspension3DScene.Valid(b) ||
                !Suspension3DScene.Valid(c) || !Suspension3DScene.Valid(d)) return false;
            double dx1 = b.X - (double)a.X, dy1 = b.Y - (double)a.Y;
            double dx2 = d.X - (double)c.X, dy2 = d.Y - (double)c.Y;
            double det = dx1 * dy2 - dy1 * dx2;
            double len = Math.Sqrt((dx1 * dx1 + dy1 * dy1) * (dx2 * dx2 + dy2 * dy2));
            if (len < 1e-8 || Math.Abs(det) < 1e-7 * len) return false;
            double t = ((c.X - (double)a.X) * dy2 - (c.Y - (double)a.Y) * dx2) / det;
            double x = a.X + t * dx1, y = a.Y + t * dy1;
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsInfinity(x) ||
                double.IsInfinity(y) || Math.Abs(x) > 100f || Math.Abs(y) > 100f) return false;
            intersection = new Vector3((float)x, (float)y, (a.Z + b.Z) * 0.5f);
            return true;
        }

        private static void Join(Suspension3DScene scene, Dictionary<string, Vector3> items,
            string a, string b, Color color, string name)
        {
            scene.AddLine(items[a], items[b], color, name, 1.65f);
        }

        private static Vector3 Midpoint(Vector3 a, Vector3 b) =>
            Suspension3DScene.Valid(a) && Suspension3DScene.Valid(b) ?
            (a + b) * 0.5f : new Vector3(float.NaN);

        private void AddTireWireframe(Suspension3DScene scene, string prefix, Vector3 pivot,
            float[,] rotation, Color wheelColor)
        {
            if (!Suspension3DScene.Valid(pivot)) return;
            float radius = Read(prefix, "WF_TireDataOffset", "TireRadius");
            float width = Read(prefix, "WF_TireDataOffset", "TireWidth");
            if (!Finite(radius) || radius <= 0f || radius > 2f) return;
            if (!Finite(width) || width <= 0f || width > 1.5f) width = 0.20f;
            const int sections = 28;
            for (int i = 0; i < sections; i++)
            {
                float a = (float)(i * Math.PI * 2d / sections);
                float b = (float)((i + 1) * Math.PI * 2d / sections);
                foreach (int side in new[] { -1, 1 })
                {
                    Vector3 p = new Vector3(side * width * 0.5f, radius * (float)Math.Cos(a), radius * (float)Math.Sin(a));
                    Vector3 q = new Vector3(side * width * 0.5f, radius * (float)Math.Cos(b), radius * (float)Math.Sin(b));
                    if (rotation != null) { p = Transform(p, rotation); q = Transform(q, rotation); }
                    scene.AddLine(pivot + p, pivot + q, wheelColor, prefix + " tire", 1.25f);
                    if (i % 4 == 0 && side == -1)
                    {
                        Vector3 other = new Vector3(width * 0.5f, radius * (float)Math.Cos(a), radius * (float)Math.Sin(a));
                        if (rotation != null) other = Transform(other, rotation);
                        scene.AddLine(pivot + p, pivot + other, wheelColor, prefix + " tread", 1f);
                    }
                }
            }
        }

        private float[,] ReadWheelRotation(string prefix)
        {
            var matrix = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    float value = Read(prefix, "WF_TireDataOffset", "TireM" + (i + 1) + (j + 1));
                    if (!Finite(value) || Math.Abs(value) > 2f) return null;
                    matrix[i, j] = value;
                }
            // Reject zero/garbage matrices while the game is entering a session.
            for (int i = 0; i < 3; i++)
            {
                float length = 0;
                for (int j = 0; j < 3; j++) length += matrix[i, j] * matrix[i, j];
                if (length < 0.5f || length > 1.5f) return null;
            }
            return matrix;
        }

        // System.Numerics Matrix4x4 uses row-vector conventions, matching the
        // game's TireM11..TireM33 matrix layout used by the current model.
        private static Vector3 Transform(Vector3 p, float[,] m) =>
            new Vector3(
                p.X * m[0, 0] + p.Y * m[1, 0] + p.Z * m[2, 0],
                p.X * m[0, 1] + p.Y * m[1, 1] + p.Z * m[2, 1],
                p.X * m[0, 2] + p.Y * m[1, 2] + p.Z * m[2, 2]);

        private static bool Finite(float v) => !float.IsNaN(v) && !float.IsInfinity(v);

        private static Vector3 ReadVector(string prefix, string category, string baseName,
            string xSuffix, string ySuffix, string zSuffix) =>
            new Vector3(Read(prefix, category, baseName + xSuffix),
                        Read(prefix, category, baseName + ySuffix),
                        Read(prefix, category, baseName + zSuffix));

        private static float Read(string prefix, string category, string member)
        {
            try
            {
                return LiveData.GetFullListFloatValue(prefix, GameMemoryConfig.Field(category, member));
            }
            catch (KeyNotFoundException) { return float.NaN; }
            catch (ArgumentOutOfRangeException) { return float.NaN; }
            catch (IndexOutOfRangeException) { return float.NaN; }
            catch (ArgumentException) { return float.NaN; }
        }
    }
}
