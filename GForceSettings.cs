﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    class GForceSettings
    {
        public static bool SettingsOpen { get; set; } = false;
        /// <summary>
        /// X and Y values
        /// </summary>
        public static List<double> X1Values { get; set; } = new List<double>();
        public static List<double> Y1Values { get; set; } = new List<double>();
        /// <summary>
        /// Later stuff
        /// </summary>
        public static int Interval { get; set; } = 50;
        public static bool updatedStartedOnce { get; set; } = false;
        public static bool plotted { get; set; } = false;
        // How long array is.
        public static double[] flsTempArray { get; set; } = new double[300];
        public static double[] fliTempArray { get; set; } = new double[300];

        /// <summary>
        /// Some Font size max mins
        /// </summary>
        public static int FontSizeMin { get; } = 4;
        public static int FontSizeMax { get; } = 28;
        public static int FontSizeDivided { get; } = 4;

        // Default values
        /// <summary>
        /// Background
        /// </summary>
        public static Color DefaultBackgroundColor { get; set; } = Color.Black;
        public static Color DefaultLegendColor { get; set; } = Color.White;
        public static bool OtherDefaults { get; set; } = true;

        /// <summary>
        /// Something
        /// </summary>
        public static int DefaultHistoryAmountPoints { get; set; } = 100;
        public static bool DefaultInfiniteHistoryEnabled { get; set; } = false;
        public static int DefaultMarkerSize { get; set; } = 5;
        public static string DefaultScheme { get; set; } = "Green Red";
        public static Color DefaultMarkerColor { get; set; } = Color.Red;


        public static readonly int historyalpha = 255;
        public static readonly int historycolordivider = 2;

        /// <summary>
        /// X1 defaults
        /// </summary>
        public static bool X1Defaults { get; set; } = true;
        // Angle Type
        public static string X1DefaultAngleType { get; set; } = "Degrees";
        // Font
        public static int X1DefaultFontIndex { get; set; } = 153;//"Microsoft Sans Serif";
        public static FontFamily X1DefaultFontFamily { get; set; } = FontFamily.Families[X1DefaultFontIndex];
        public static float X1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle X1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color X1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool X1DefaultIsLog { get; set; } = false;
        public static double X1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color X1DefaultMajorColor { get; set; } = Color.Maroon;
        public static int X1DefaultMajorDecimals { get; set; } = 0;
        public static int X1DefaultMajorIntervalFraction { get; set; } = 4;
        public static int X1DefaultMajorLineWidth { get; set; } = 2;
        public static double X1DefaultMin { get; set; } = 0;//
        public static double X1DefaultMax { get; set; } = 360;//
        // Minor grid
        public static bool X1DefaultMinorEnabled { get; set; } = false;
        public static int X1DefaultMinorIntervalFraction { get; set; } = 2;
        public static int X1DefaultMinorLineWidth { get; set; } = 1;
        public static Color X1DefaultMinorColor { get; set; } = Color.Maroon;
        public static ChartDashStyle X1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dash;

        public static bool Y1Defaults { get; set; } = true;
        /// <summary>
        /// Y1 defaults
        /// </summary>
        // Marker stuff
        public static MarkerStyle Y1DefaultMarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int Y1DefaultMarkerSize { get; set; } = 3;
        public static Color Y1DefaultMarkerColor { get; set; } = Color.Blue;
        public static int Y1DefaultMarkerBorderSize { get; set; } = 1;
        public static Color Y1DefaultMarkerBorderColor { get; set; } = Color.Blue;

        // Font
        public static int Y1DefaultFontIndex { get; set; } = 153;//"Microsoft Sans Serif"
        public static FontFamily Y1DefaultFontFamily { get; set; } = FontFamily.Families[Y1DefaultFontIndex];
        public static float Y1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle Y1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color Y1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool Y1DefaultIsLog { get; set; } = false;
        public static double Y1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color Y1DefaultMajorColor { get; set; } = Color.Maroon;
        public static int Y1DefaultMajorDecimals { get; set; } = 2;
        public static int Y1DefaultIntervalDivider { get; set; } = 5;//
        public static int Y1DefaultMajorLineWidth { get; set; } = 2;
        public static double Y1DefaultMin { get; set; } = 0;//
        public static double Y1DefaultMax { get; set; } = 2;//
        // Minor grid
        public static bool Y1DefaultMinorEnabled { get; set; } = false;
        public static int Y1DefaultMinorIntervalFraction { get; set; } = 2;
        public static int Y1DefaultMinorLineWidth { get; set; } = 1;
        public static Color Y1DefaultMinorColor { get; set; } = Color.Maroon;
        public static ChartDashStyle Y1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dash;


        ///////////////////////////////////////////////////////////////////////////////////

        // Changable values

        /// <summary>
        /// Background
        /// </summary>
        public static Color BackgroundColor { get; set; } = DefaultBackgroundColor;
        public static Color LegendColor { get; set; } = DefaultLegendColor;

        /// <summary>
        /// Something
        /// </summary>
        public static int HistoryAmountPoints { get; set; } = DefaultHistoryAmountPoints;
        public static bool InfiniteHistoryEnabled { get; set; } = DefaultInfiniteHistoryEnabled;
        public static int MarkerSize { get; set; } = DefaultMarkerSize;
        public static string Scheme { get; set; } = DefaultScheme;
        public static Color MarkerColor { get; set; } = DefaultMarkerColor;
        /// <summary>
        /// X1 Axis
        /// </summary>
        /// // Angle Type
        public static string X1AngleType { get; set; } = X1DefaultAngleType;
        // Font
        public static int X1FontIndex { get; set; } = X1DefaultFontIndex;
        public static FontFamily X1FontFamily { get; set; } = X1DefaultFontFamily;
        public static float X1FontSize { get; set; } = X1DefaultFontSize;
        public static FontStyle X1FontStyle { get; set; } = X1DefaultFontStyle;
        public static Color X1FontColor { get; set; } = X1DefaultFontColor;
        // Logaritmic
        public static bool X1IsLog { get; set; } = X1DefaultIsLog;
        public static double X1LogBase { get; set; } = X1DefaultLogBase;
        // Major Grid
        public static Color X1MajorColor { get; set; } = X1DefaultMajorColor;
        public static int X1MajorDecimals { get; set; } = X1DefaultMajorDecimals;
        public static int X1MajorIntervalFraction { get; set; } = X1DefaultMajorIntervalFraction;
        public static int X1MajorLineWidth { get; set; } = X1DefaultMajorLineWidth;
        public static double X1Min { get; set; } = X1DefaultMin;
        public static double X1MaxDegrees { get; set; } = X1DefaultMax;
        // Minor grid
        public static bool X1MinorEnabled { get; set; } = X1DefaultMinorEnabled;
        public static int X1MinorIntervalFraction { get; set; } = X1DefaultMinorIntervalFraction;
        public static int X1MinorLineWidth { get; set; } = X1DefaultMinorLineWidth;
        public static Color X1MinorColor { get; set; } = X1DefaultMinorColor;
        public static ChartDashStyle X1MinorDashStyle { get; set; } = X1DefaultMinorDashStyle;

        /// <summary>
        /// Y1 Axis
        /// </summary>
        // Marker stuff
        public static MarkerStyle Y1MarkerStyle { get; set; } = Y1DefaultMarkerStyle;
        public static int Y1MarkerSize { get; set; } = Y1DefaultMarkerSize;
        public static Color Y1MarkerColor { get; set; } = Y1DefaultMarkerColor;
        public static int Y1MarkerBorderSize { get; set; } = Y1DefaultMarkerBorderSize;
        public static Color Y1MarkerBorderColor { get; set; } = Y1DefaultMarkerBorderColor;

        // Font
        public static int Y1FontIndex { get; set; } = Y1DefaultFontIndex;
        public static FontFamily Y1FontFamily { get; set; } = Y1DefaultFontFamily;
        public static float Y1FontSize { get; set; } = Y1DefaultFontSize;
        public static FontStyle Y1FontStyle { get; set; } = Y1DefaultFontStyle;
        public static Color Y1FontColor { get; set; } = Y1DefaultFontColor;
        // Logaritmic
        public static bool Y1IsLog { get; set; } = Y1DefaultIsLog;
        public static double Y1LogBase { get; set; } = Y1DefaultLogBase;
        // Major Grid
        public static Color Y1MajorColor { get; set; } = Y1DefaultMajorColor;
        public static int Y1MajorDecimals { get; set; } = Y1DefaultMajorDecimals;
        public static int Y1IntervalDivider { get; set; } = Y1DefaultIntervalDivider;
        public static int Y1MajorLineWidth { get; set; } = Y1DefaultMajorLineWidth;
        public static double Y1Min { get; set; } = Y1DefaultMin;
        public static double Y1Max { get; set; } = Y1DefaultMax;
        // Minor grid
        public static bool Y1MinorEnabled { get; set; } = Y1DefaultMinorEnabled;
        public static int Y1MinorIntervalFraction { get; set; } = Y1DefaultMinorIntervalFraction;
        public static int Y1MinorLineWidth { get; set; } = Y1DefaultMinorLineWidth;
        public static Color Y1MinorColor { get; set; } = Y1DefaultMinorColor;
        public static ChartDashStyle Y1MinorDashStyle { get; set; } = Y1DefaultMinorDashStyle;

    }
}
