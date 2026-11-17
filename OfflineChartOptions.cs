using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    internal sealed class OfflineChartOptions
    {
        public string X = "SlipAngleDeg";
        public string Y = "LateralFriction";
        public string Z = "VerticalLoad";
        public bool Absolute = true;
        public string Scheme = "Colorblind";
        public int Bands = 10;
        public int MarkerSize = 4;
        public int PaletteAlpha = 255;
        public int PaletteDivider = 2;
        public SeriesChartType ChartType = SeriesChartType.Point;
        public MarkerStyle Marker = MarkerStyle.Circle;
        public Color Background = Color.Black;
        public string Layout = "All In One";
        public bool ShowPointTooltips = true;
        public int PointTooltipDelayMs = 1000;
        public double? XMinimum, XMaximum, YMinimum, YMaximum, ZMinimum, ZMaximum;
        public double XGridInterval = 0, YGridInterval = 0;
        public bool XMinorGrid, YMinorGrid;
        public int XDecimals = 2, YDecimals = 2;
        public bool XLogarithmic, YLogarithmic;
        public double XLogBase = 10, YLogBase = 10;
        public decimal XFontSize = 9m, YFontSize = 9m;
        // WinForms Chart renders line widths in integer device pixels; fractional
        // values are retained in settings and rounded at rendering time.
        public decimal XGridWidth = 1m, YGridWidth = 1m;
        public decimal XMinorWidth = 1m, YMinorWidth = 1m;
        public int XGridAlpha = 255, YGridAlpha = 255;
        public int XMinorAlpha = 255, YMinorAlpha = 255;
        public ChartDashStyle XGridDashStyle = ChartDashStyle.Solid, YGridDashStyle = ChartDashStyle.Solid;
        public ChartDashStyle XMinorDashStyle = ChartDashStyle.Dash, YMinorDashStyle = ChartDashStyle.Dash;
        public bool CursorEnabled = true, CursorZoomable = true;
        public Color CursorColor = Color.DodgerBlue;
        public int CursorAlpha = 160;
        public decimal CursorWidth = 1m;
        public ChartDashStyle CursorDashStyle = ChartDashStyle.Dash;

        public string XFontFamily = "Segoe UI", YFontFamily = "Segoe UI";
        public Color XFontColor = Color.White, YFontColor = Color.White;
        public Color XGridColor = Color.FromArgb(75,75,75), YGridColor = Color.FromArgb(75,75,75);
        public Color XMinorColor = Color.FromArgb(42,42,42), YMinorColor = Color.FromArgb(42,42,42);

        public OfflineChartOptions Clone() => (OfflineChartOptions)MemberwiseClone();
    }
}
