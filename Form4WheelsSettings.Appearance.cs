using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Live-only chart appearance settings. The setting controls and their rows
    /// are declared in Form4WheelsSettings.Designer.cs, with the same compact
    /// layout as FormOfflineChartSettings. Existing JSON control names remain stable.
    /// </summary>
    public partial class Form4WheelsSettings
    {
        public static decimal XMajorWidth { get; private set; } = 1m;
        public static decimal XMinorWidth { get; private set; } = 1m;
        public static decimal YMajorWidth { get; private set; } = 1m;
        public static decimal YMinorWidth { get; private set; } = 1m;
        public static ChartDashStyle XMajorDashStyle { get; private set; } = ChartDashStyle.Solid;
        public static ChartDashStyle YMajorDashStyle { get; private set; } = ChartDashStyle.Solid;
        public static int XMajorAlpha { get; private set; } = 255;
        public static int YMajorAlpha { get; private set; } = 255;
        public static int XMinorAlpha { get; private set; } = 255;
        public static int YMinorAlpha { get; private set; } = 255;
        public static bool LiveCursorEnabled { get; private set; } = true;
        public static bool LiveCursorZoomable { get; private set; } = true;
        public static Color CursorColor { get; private set; } = Color.DodgerBlue;
        public static int CursorAlpha { get; private set; } = 160;
        public static decimal CursorWidth { get; private set; } = 1m;
        public static ChartDashStyle CursorDash { get; private set; } = ChartDashStyle.Dash;

        private static void Select(ComboBox box, string value)
        {
            if (box.Items.Contains(value)) box.SelectedItem = value;
            else if (box.Items.Count > 0) box.SelectedIndex = 0;
        }

        private void InitializeLiveAppearance()
        {
            liveChartTypeBox.Items.AddRange(Enum.GetNames(typeof(System.Windows.Forms.DataVisualization.Charting.SeriesChartType)).Cast<object>().ToArray());
            liveHistoryMarkerBox.Items.AddRange(Enum.GetNames(typeof(MarkerStyle)).Cast<object>().ToArray());
            var dashes = Enum.GetNames(typeof(ChartDashStyle)).Cast<object>().ToArray();
            foreach (ComboBox combo in new[] { liveCursorDashBox, liveXMajorDashBox, liveYMajorDashBox })
                combo.Items.AddRange(dashes);
            liveCursorColorBox.Items.AddRange(Enum.GetNames(typeof(KnownColor)).Cast<object>().ToArray());
            ChartSettingsUi.ConfigureNamedColorCombos(liveCursorColorBox);
            Select(liveChartTypeBox, Form4WheelsSettings.SeriesChartType.ToString());
            Select(liveHistoryMarkerBox, Form4Wheels.HistoryMarkerStyle.ToString());
            ChartSettingsUi.SelectColor(liveCursorColorBox, CursorColor);
            Select(liveCursorDashBox, CursorDash.ToString());
            Select(liveXMajorDashBox, XMajorDashStyle.ToString());
            Select(liveYMajorDashBox, YMajorDashStyle.ToString());
            liveHistoryMarkerSize.Value = Math.Max(1, Math.Min(20, Form4Wheels.MarkerSizeHistory));
            livePaletteAlpha.Value = Math.Max(0, Math.Min(255, Form4Wheels.HistoryAlpha));
            livePaletteDivider.Value = Math.Max(1, Math.Min(8, Form4Wheels.HistoryColorDivider));
            liveXMajorWidthBox.Value = Math.Max(.25m, Math.Min(10m, X1MajorLineWidth));
            liveXMinorWidthBox.Value = Math.Max(.25m, Math.Min(10m, X1MinorLineWidth));
            liveYMajorWidthBox.Value = Math.Max(.25m, Math.Min(10m, Y1MajorLineWidth));
            liveYMinorWidthBox.Value = Math.Max(.25m, Math.Min(10m, Y1MinorLineWidth));
        }

        private void ApplyLiveAppearance()
        {
            if (!Enum.TryParse(liveChartTypeBox.Text, out System.Windows.Forms.DataVisualization.Charting.SeriesChartType type))
                type = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            // Live history holds one Y value. Multi-Y chart types cannot draw it.
            if (!ChartAppearance.CanDrawLiveXYZ(type))
                throw new ArgumentException(type + " needs more than one Y value per point.");
            SeriesChartType = type;
            Form4Wheels.ChartType = type;
            if (Enum.TryParse(liveHistoryMarkerBox.Text, out MarkerStyle marker))
                Form4Wheels.HistoryMarkerStyle = marker;
            Form4Wheels.MarkerSizeHistory = (int)liveHistoryMarkerSize.Value;
            Form4Wheels.HistoryAlpha = (int)livePaletteAlpha.Value;
            Form4Wheels.HistoryColorDivider = (int)livePaletteDivider.Value;
            if (Enum.TryParse(liveXMajorDashBox.Text, out ChartDashStyle xd)) XMajorDashStyle = xd;
            if (Enum.TryParse(liveYMajorDashBox.Text, out ChartDashStyle yd)) YMajorDashStyle = yd;
            XMajorWidth = liveXMajorWidthBox.Value;
            XMinorWidth = liveXMinorWidthBox.Value;
            YMajorWidth = liveYMajorWidthBox.Value;
            YMinorWidth = liveYMinorWidthBox.Value;
            X1MajorLineWidth = ChartAppearance.PixelWidth(XMajorWidth);
            X1MinorLineWidth = ChartAppearance.PixelWidth(XMinorWidth);
            Y1MajorLineWidth = ChartAppearance.PixelWidth(YMajorWidth);
            Y1MinorLineWidth = ChartAppearance.PixelWidth(YMinorWidth);
            XMajorAlpha = (int)liveXMajorAlphaBox.Value;
            YMajorAlpha = (int)liveYMajorAlphaBox.Value;
            XMinorAlpha = (int)liveXMinorAlphaBox.Value;
            YMinorAlpha = (int)liveYMinorAlphaBox.Value;
            LiveCursorEnabled = liveCursorEnabledBox.Checked;
            LiveCursorZoomable = liveCursorZoomBox.Checked;
            CursorColor = ChartSettingsUi.ReadColor(liveCursorColorBox);
            CursorAlpha = (int)liveCursorAlphaBox.Value;
            CursorWidth = liveCursorWidthBox.Value;
            if (Enum.TryParse(liveCursorDashBox.Text, out ChartDashStyle cd)) CursorDash = cd;
        }

    }
}
