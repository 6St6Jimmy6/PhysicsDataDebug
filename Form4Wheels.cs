using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public partial class Form4Wheels : Form
    {
        bool PauseUpdate;
        public static bool LimitersEnabled { get; set; } = false;
        public static bool NoTireContactLimiterEnabled { get; set; } = false;
        public static string X1LimiterSelection { get; set; } = _4WheelsSettings.X1Selection;
        public static string Y1LimiterSelection { get; set; } = _4WheelsSettings.Y1Selection;
        public static string Z1LimiterSelection { get; set; } = _4WheelsSettings.Z1Selection;

        public static double X1LimiterDefaultMin { get; set; } = _4WheelsSettings.X1DefaultMin;
        public static double Y1LimiterDefaultMin { get; set; } = _4WheelsSettings.Y1DefaultMin;
        public static double Z1LimiterDefaultMin { get; set; } = _4WheelsSettings.Z1DefaultMin;

        public static double X1LimiterDefaultMax { get; set; } = _4WheelsSettings.X1DefaultMax;
        public static double Y1LimiterDefaultMax { get; set; } = _4WheelsSettings.Y1DefaultMax;
        public static double Z1LimiterDefaultMax { get; set; } = _4WheelsSettings.Z1DefaultMax;

        public static double X1LimiterMin { get; set; } = _4WheelsSettings.X1DefaultMin;
        public static double Y1LimiterMin { get; set; } = _4WheelsSettings.Y1DefaultMin;
        public static double Z1LimiterMin { get; set; } = _4WheelsSettings.Z1DefaultMin;

        public static double X1LimiterMax { get; set; } = _4WheelsSettings.X1DefaultMax;
        public static double Y1LimiterMax { get; set; } = _4WheelsSettings.Y1DefaultMax;
        public static double Z1LimiterMax { get; set; } = _4WheelsSettings.Z1DefaultMax;
        public static List<string> xyzAxisSelection { get; set; } = new List<string> { _4WheelsSettings.X1Selection, _4WheelsSettings.Y1Selection, _4WheelsSettings.Z1Selection };
        public static List<string> xyzAxisLimiterSelection { get; set; } = new List<string> { X1LimiterSelection, Y1LimiterSelection, Z1LimiterSelection };

        public Form4Wheels()
        {
            InitializeComponent();
            PauseUpdate = false;
            timer1.Interval = 50;

            customChoiceCheckBox.Checked = false;
            enableLimitersCheckBox.Checked = false;
            /*
            customChoiceCheckBox.Enabled = false;
            enableLimitersCheckBox.Enabled = false;
            label17.Enabled = false;
            */
            X1LimiterComboBox.Enabled = false;
            Y1LimiterComboBox.Enabled = false;
            Z1LimiterComboBox.Enabled = false;
            X1MinLimitTextBox.Enabled = false;
            X1MaxLimitTextBox.Enabled = false;
            Y1MinLimitTextBox.Enabled = false;
            Y1MaxLimitTextBox.Enabled = false;
            Z1MinLimitTextBox.Enabled = false;
            Z1MaxLimitTextBox.Enabled = false;
            AddInComboBoxes();
            LoadDefaults();
            UpdateAllLimiters();
            SetComboBoxAxisLimiterTexts();
            GetSetComboBoxAxisLimiter();
            SetChartsForForm();
        }
        private void AddInComboBoxes()
        {
            Form4WheelsSettings.AxisSelectionComboboxAdd(X1LimiterComboBox);
            Form4WheelsSettings.AxisSelectionComboboxAdd(Y1LimiterComboBox);
            Form4WheelsSettings.AxisSelectionComboboxAdd(Z1LimiterComboBox);
        }
        private void LoadDefaultTextMin(TextBox tBMin, double minValue)
        {
            tBMin.Text = minValue.ToString();
        }
        private void LoadDefaultTextMax(TextBox tBMax, double maxValue)
        {
            tBMax.Text = maxValue.ToString();
        }
        private void LoadDefaultTextBoxTexts(ComboBox cBSelection, TextBox tBMin, double minValue, TextBox tBMax, double maxValue)
        {
            if (WreckfestEnums.DataNameStringsAbsoluteValues.Contains((string)cBSelection.SelectedItem) == true)
            {
                minValue = 0;
            }
            LoadDefaultTextMin(tBMin, minValue);
            LoadDefaultTextMax(tBMax, maxValue);
        }
        private string LimiterDefaultToSelectedAxis(ComboBox cBLimiter, string selection)
        {
            cBLimiter.SelectedItem = selection;
            cBLimiter.Text = selection;
            return selection;
        }
        private void LoadDefaults()
        {
            LoadDefaultTextBoxTexts(X1LimiterComboBox, X1MinLimitTextBox, X1LimiterDefaultMin, X1MaxLimitTextBox, X1LimiterDefaultMax);
            X1LimiterSelection = LimiterDefaultToSelectedAxis(X1LimiterComboBox, X1LimiterSelection);
            LoadDefaultTextBoxTexts(Y1LimiterComboBox, Y1MinLimitTextBox, Y1LimiterDefaultMin, Y1MaxLimitTextBox, Y1LimiterDefaultMax);
            Y1LimiterSelection = LimiterDefaultToSelectedAxis(Y1LimiterComboBox, Y1LimiterSelection);
            LoadDefaultTextBoxTexts(Z1LimiterComboBox, Z1MinLimitTextBox, Z1LimiterDefaultMin, Z1MaxLimitTextBox, Z1LimiterDefaultMax);
            Z1LimiterSelection = LimiterDefaultToSelectedAxis(Z1LimiterComboBox, Z1LimiterSelection);
        }

        private void GetColorSchemeColors()
        {

            if (_4WheelsSettings.Scheme == "Colorblind")
            {
                // Colors from https://jacksonlab.agronomy.wisc.edu/2016/05/23/15-level-colorblind-friendly-palette/
                //Color color5 = Color.FromArgb(historyalpha, 255, 182, 219);// color5
                _4Wheels.MarkerColors.Insert(1, Color.FromArgb(_4Wheels.HistoryAlpha, 0, 73, 73));// color 2;
                _4Wheels.MarkerColors[2] = Color.FromArgb(_4Wheels.HistoryAlpha, 0, 146, 146);// color 3
                _4Wheels.MarkerColors[3] = Color.FromArgb(_4Wheels.HistoryAlpha, 255, 109, 182);// color 4
                _4Wheels.MarkerColors[4] = Color.FromArgb(_4Wheels.HistoryAlpha, 73, 0, 146);// color 6
                _4Wheels.MarkerColors[5] = Color.FromArgb(_4Wheels.HistoryAlpha, 0, 109, 219);// color 7
                _4Wheels.MarkerColors[6] = Color.FromArgb(_4Wheels.HistoryAlpha, 182, 109, 255);// color 8
                _4Wheels.MarkerColors[7] = Color.FromArgb(_4Wheels.HistoryAlpha, 109, 182, 255);// color 9
                _4Wheels.MarkerColors[8] = Color.FromArgb(_4Wheels.HistoryAlpha, 255, 255, 109);// color 15
                _4Wheels.MarkerColors[9] = Color.FromArgb(_4Wheels.HistoryAlpha, 36, 255, 36);// color 14
                _4Wheels.MarkerColors[10] = Color.FromArgb(_4Wheels.HistoryAlpha, 219, 109, 0);// color 13
            }
            else if (_4WheelsSettings.Scheme == "Green Red")
            {
                _4Wheels.MarkerColors[1] = Color.FromArgb(_4Wheels.HistoryAlpha, 0 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[2] = Color.FromArgb(_4Wheels.HistoryAlpha, 64 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[3] = Color.FromArgb(_4Wheels.HistoryAlpha, 128 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[4] = Color.FromArgb(_4Wheels.HistoryAlpha, 192 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[5] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[6] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 128 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[7] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 64 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[8] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[9] = Color.FromArgb(_4Wheels.HistoryAlpha, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[10] = Color.FromArgb(_4Wheels.HistoryAlpha, 128 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
            }
            else
            {
                _4Wheels.MarkerColors[1] = Color.FromArgb(_4Wheels.HistoryAlpha, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[2] = Color.FromArgb(_4Wheels.HistoryAlpha, 64 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[3] = Color.FromArgb(_4Wheels.HistoryAlpha, 128 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[4] = Color.FromArgb(_4Wheels.HistoryAlpha, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[5] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 192 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[6] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 128 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[7] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 64 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[8] = Color.FromArgb(_4Wheels.HistoryAlpha, 255 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[9] = Color.FromArgb(_4Wheels.HistoryAlpha, 192 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
                _4Wheels.MarkerColors[10] = Color.FromArgb(_4Wheels.HistoryAlpha, 128 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider, 0 / _4Wheels.HistoryColorDivider);
            }
        }
        public List<object> SelectionDefaults(string axisSelection, bool isAbsolute)
        {
            var AxisSelectionList = new List<object>();
            ///
            /// [0] = defaultMax
            /// [1] = defaultMin
            /// [2] = defaultMajorInterval
            /// [3] = defaultDecimals
            /// [4] = defaultMinorDecimals
            /// [5] = defaultMinorIntervalFraction
            /// 
            float dMax = 0; float dMin = 0; double dMajorInterval = 0; int dDecimals = 0; bool dMinorEnabled = true; int dMinorIntervalFraction = 0;
            AxisSelectionList.Add(dMax); AxisSelectionList.Add(dMin); AxisSelectionList.Add(dMajorInterval); AxisSelectionList.Add(dDecimals); AxisSelectionList.Add(dMinorEnabled); AxisSelectionList.Add(dMinorIntervalFraction);

            if (axisSelection == nameof(WF_TimeDataOffset.RaceTime))//LogSettings.sRaceTime)
            {
                dMax = (float)double.NaN;
                dMin = 0;
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = false;
                dMinorIntervalFraction = 60;
            }
            else if (axisSelection == nameof(AllValueNames.None))//LogSettings.sNone)
            {
                dMax = 2;
                dMin = 0;
                dMajorInterval = 0;
                dDecimals = 0;
                dMinorEnabled = false;
                dMinorIntervalFraction = 1;
            }
            else if (axisSelection == nameof(AllValueNames.TravelSpeed))//LogSettings.sTireTravelSpeed)
            {
                dMax = 400;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax / 2;
                }
                dMajorInterval = 100;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.AngularVelocity))//LogSettings.sAngularVelocity)
            {
                dMax = 400;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax / 2;
                }
                dMajorInterval = 100;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.VerticalLoad))//LogSettings.sVerticalLoad)
            {
                dMax = 10000;
                dMin = 0;
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.VerticalDeflection))//LogSettings.sVerticalDeflection)
            {
                dMax = (float)0.15;
                dMin = 0;
                dMajorInterval = 0.03;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LoadedRadius))//LogSettings.sLoadedRadius)
            {
                dMax = (float)0.5;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LoadedRadius))//LogSettings.sEffectiveRadius)
            {
                dMax = (float)0.5;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.ContactLength))//LogSettings.sContactLength)
            {
                dMax = (float)0.5;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 3;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.CurrentContactBrakeTorque))//LogSettings.sBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;
                dMajorInterval = 500;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.CurrentContactBrakeTorqueMax))//LogSettings.sMaxBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;
                dMajorInterval = 500;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.SteerAngleDeg))//LogSettings.sSteerAngle)
            {
                dMax = 45;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 15;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.CamberAngleDeg))//LogSettings.sCamberAngle)
            {
                dMax = 10;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 4;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LateralLoad))//LogSettings.sLateralLoad)
            {
                dMax = 10000;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.SlipAngleDeg))//LogSettings.sSlipAngle)
            {
                dMax = 45;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 15;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LateralFriction))//LogSettings.sLateralFriction)
            {
                dMax = 2;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.5;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LateralSlipSpeed))//LogSettings.sLateralSlipSpeed)
            {
                dMax = 20;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 5;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LongitudinalLoad))//LogSettings.sLongitudinalLoad)
            {
                dMax = 10000;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 1000;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.SlipRatio))//LogSettings.sSlipRatio)
            {
                dMax = 1;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.2;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LongitudinalFriction))//LogSettings.sLongitudinalFriction)
            {
                dMax = 2;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 0.5;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.LongitudinalSlipSpeed))//LogSettings.sLongitudinalSlipSpeed)
            {
                dMax = 20;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 5;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.TreadTemperature))//LogSettings.sTreadTemperature)
            {
                dMax = 380;
                dMin = -20;
                dMajorInterval = 20;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.InnerTemperature))//LogSettings.sInnerTemperature)
            {
                dMax = 380;
                dMin = -20;
                dMajorInterval = 20;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.TotalFriction))//LogSettings.sTotalFriction)
            {
                dMax = 2;
                dMin = -dMax;
                dMajorInterval = 0.5;
                dDecimals = 2;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.TotalFrictionAngleDeg))//LogSettings.sTotalFrictionAngle)
            {
                dMax = 360;
                dMin = 0;
                dMajorInterval = 90;
                dDecimals = 0;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.SuspensionLength))//LogSettings.sSuspensionLength)
            {
                dMax = 1;
                dMin = 0;
                dMajorInterval = 0.1;
                dDecimals = 4;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else if (axisSelection == nameof(AllValueNames.SuspensionVelocity))//LogSettings.sSuspensionVelocity)
            {
                dMax = 10;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = -dMax;
                }
                dMajorInterval = 2;
                dDecimals = 4;
                dMinorEnabled = true;
                dMinorIntervalFraction = 2;
            }
            else
            {
                // Defaults auto scale
                dMax = (float)double.NaN;
                if (isAbsolute == true)
                {
                    dMin = 0;
                }
                else
                {
                    dMin = (float)double.NaN;
                }
                dMajorInterval = 0;
                dDecimals = 2;
                dMinorEnabled = false;
                dMinorIntervalFraction = 2;
            }

            AxisSelectionList[0] = dMax;
            AxisSelectionList[1] = dMin;
            AxisSelectionList[2] = dMajorInterval;
            AxisSelectionList[3] = dDecimals;
            AxisSelectionList[4] = dMinorEnabled;
            AxisSelectionList[5] = dMinorIntervalFraction;

            return AxisSelectionList;
        }
        public List<object> AbsoluteZAxisSelectionDefaults(string axisSelection)
        {
            var AxisSelectionList = new List<object>();
            ///
            /// [0] = defaultMax
            /// [1] = defaultMin
            /// [2] = defaultMajorInterval
            /// [3] = defaultDecimals
            /// [4] = defaultMinorDecimals
            /// [5] = defaultMinorIntervalFraction
            /// 
            float dMax = 0; float dMin = 0;// double dMajorInterval = 0; int dDecimals = 0; bool dMinorEnabled = true; int dMinorIntervalFraction = 0;
            AxisSelectionList.Add(dMax); AxisSelectionList.Add(dMin);// AxisSelectionList.Add(dMajorInterval); AxisSelectionList.Add(dDecimals); AxisSelectionList.Add(dMinorEnabled); AxisSelectionList.Add(dMinorIntervalFraction);


            if (axisSelection == nameof(WF_TimeDataOffset.RaceTime))//LogSettings.sRaceTime)
            {
                dMax = (float)double.NaN;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.None))//LogSettings.sNone)
            {
                dMax = 2;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.TravelSpeed))//LogSettings.sTireTravelSpeed)
            {
                dMax = 400;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.AngularVelocity))//LogSettings.sAngularVelocity)
            {
                dMax = 400;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.VerticalLoad))//LogSettings.sVerticalLoad)
            {
                dMax = 10000;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.VerticalDeflection))//LogSettings.sVerticalDeflection)
            {
                dMax = (float)0.15;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LoadedRadius))//LogSettings.sLoadedRadius)
            {
                dMax = (float)0.5;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.EffectiveRadius))//LogSettings.sEffectiveRadius)
            {
                dMax = (float)0.5;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.ContactLength))//LogSettings.sContactLength)
            {
                dMax = (float)0.5;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.CurrentContactBrakeTorque))//LogSettings.sBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.CurrentContactBrakeTorqueMax))//LogSettings.sMaxBrakeTorque)
            {
                dMax = 5000;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.SteerAngleDeg))//LogSettings.sSteerAngle)
            {
                dMax = 45;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.CamberAngleDeg))//LogSettings.sCamberAngle)
            {
                dMax = 10;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LateralLoad))//LogSettings.sLateralLoad)
            {
                dMax = 10000;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.SlipAngleDeg))//LogSettings.sSlipAngle)
            {
                dMax = 45;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LateralFriction))//LogSettings.sLateralFriction)
            {
                dMax = 2;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LateralSlipSpeed))//LogSettings.sLateralSlipSpeed)
            {
                dMax = 20;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LongitudinalLoad))//LogSettings.sLongitudinalLoad)
            {
                dMax = 10000;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.SlipRatio))//LogSettings.sSlipRatio)
            {
                dMax = 1;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LongitudinalFriction))//LogSettings.sLongitudinalFriction)
            {
                dMax = 2;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.LongitudinalSlipSpeed))//LogSettings.sLongitudinalSlipSpeed)
            {
                dMax = 20;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.TreadTemperature))//LogSettings.sTreadTemperature)
            {
                dMax = 380;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.InnerTemperature))//LogSettings.sInnerTemperature)
            {
                dMax = 380;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.TotalFriction))//LogSettings.sTotalFriction)
            {
                dMax = 2;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.TotalFrictionAngleDeg))//LogSettings.sTotalFrictionAngle)
            {
                dMax = 360;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.SuspensionLength))//LogSettings.sSuspensionLength)
            {
                dMax = 1;
                dMin = 0;
            }
            else if (axisSelection == nameof(AllValueNames.SuspensionVelocity))//LogSettings.sSuspensionVelocity)
            {
                dMax = 10;
                dMin = 0;
            }
            else
            {
                // Defaults auto scale
                dMax = (float)double.NaN;
                dMin = (float)double.NaN;
            }

            AxisSelectionList[0] = dMax;
            AxisSelectionList[1] = dMin;
            //AxisSelectionList[2] = dMajorInterval;
            //AxisSelectionList[3] = dDecimals;
            //AxisSelectionList[4] = dMinorEnabled;
            //AxisSelectionList[5] = dMinorIntervalFraction;

            return AxisSelectionList;
        }
        private void X1AxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == true)
            {
                _4WheelsSettings.X1Max = (float)axisDefaultSelectionDefaults[0];
                _4WheelsSettings.X1Min = (float)axisDefaultSelectionDefaults[1];
                _4WheelsSettings.X1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                _4WheelsSettings.X1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                _4WheelsSettings.X1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                _4WheelsSettings.X1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void Y1AxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == true)
            {
                _4WheelsSettings.Y1Max = (float)axisDefaultSelectionDefaults[0];
                _4WheelsSettings.Y1Min = (float)axisDefaultSelectionDefaults[1];
                _4WheelsSettings.Y1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                _4WheelsSettings.Y1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                _4WheelsSettings.Y1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                _4WheelsSettings.Y1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void Z1AxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == true)
            {
                _4WheelsSettings.Z1Max = (float)axisDefaultSelectionDefaults[0];
                _4WheelsSettings.Z1Min = (float)axisDefaultSelectionDefaults[1];
                //_4WheelsSettings.Z1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                //_4WheelsSettings.Z1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                //_4WheelsSettings.Z1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                //_4WheelsSettings.Z1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void X1LimiterAxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == false)
            {
                X1LimiterMax = (float)axisDefaultSelectionDefaults[0];
                X1LimiterMin = (float)axisDefaultSelectionDefaults[1];
                //_4WheelsSettings.X1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                //_4WheelsSettings.X1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                //_4WheelsSettings.X1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                //_4WheelsSettings.X1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void Y1LimiterAxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == false)
            {
                Y1LimiterMax = (float)axisDefaultSelectionDefaults[0];
                Y1LimiterMin = (float)axisDefaultSelectionDefaults[1];
                //_4WheelsSettings.X1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                //_4WheelsSettings.X1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                //_4WheelsSettings.X1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                //_4WheelsSettings.X1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        private void Z1LimiterAxisToDefaults(bool defaultsSelected, List<object> axisDefaultSelectionDefaults)
        {
            if (defaultsSelected == false)
            {
                Z1LimiterMax = (float)axisDefaultSelectionDefaults[0];
                Z1LimiterMin = (float)axisDefaultSelectionDefaults[1];
                //_4WheelsSettings.X1MajorInterval = (double)axisDefaultSelectionDefaults[2];
                //_4WheelsSettings.X1MajorDecimals = (int)axisDefaultSelectionDefaults[3];
                //_4WheelsSettings.X1MinorEnabled = (bool)axisDefaultSelectionDefaults[4];
                //_4WheelsSettings.X1MinorIntervalFraction = (int)axisDefaultSelectionDefaults[5];
            }
        }
        public static void AddChart(Chart chartName, string chartAreaName)
        {
            if (chartName.ChartAreas.IsUniqueName(chartAreaName))
            {
                chartName.ChartAreas.Add(chartAreaName);
            }

            chartName.ChartAreas[chartAreaName].BackColor = _4WheelsSettings.BackgroundColor;

            // X Axis
            chartName.ChartAreas[chartAreaName].AxisX.Maximum = _4WheelsSettings.X1Max;
            chartName.ChartAreas[chartAreaName].AxisX.Minimum = _4WheelsSettings.X1Min;

            chartName.ChartAreas[chartAreaName].AxisX.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.Interval = _4WheelsSettings.X1MajorInterval;
            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.Format = "F" + _4WheelsSettings.X1MajorDecimals;// decimals

            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.Font = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisX.LabelStyle.ForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas[chartAreaName].AxisX.Title = _4WheelsSettings.X1Selection;
            chartName.ChartAreas[chartAreaName].AxisX.TitleFont = new Font(_4WheelsSettings.X1FontFamily, _4WheelsSettings.X1FontSize, _4WheelsSettings.X1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisX.TitleForeColor = _4WheelsSettings.X1FontColor;

            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.LineWidth = _4WheelsSettings.X1MajorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisX.MajorGrid.LineColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.LineColor = Color.Transparent;// Need to do this for this specific line, because it's over the X axis lines.

            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.Enabled = _4WheelsSettings.X1MinorEnabled;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineDashStyle = _4WheelsSettings.X1MinorDashStyle;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineWidth = _4WheelsSettings.X1MinorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.Interval = chartName.ChartAreas[chartAreaName].AxisX.Interval / _4WheelsSettings.X1MinorIntervalFraction;
            chartName.ChartAreas[chartAreaName].AxisX.MinorGrid.LineColor = _4WheelsSettings.X1MinorColor;

            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.ButtonColor = _4WheelsSettings.X1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.LineColor = _4WheelsSettings.X1FontColor;
            chartName.ChartAreas[chartAreaName].AxisX.ScaleView.Zoomable = true;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.Enabled = true;
            chartName.ChartAreas[chartAreaName].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartName.ChartAreas[chartAreaName].CursorX.AutoScroll = true;
            chartName.ChartAreas[chartAreaName].CursorX.IsUserEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorX.IsUserSelectionEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorX.Interval = 0.01;
            chartName.ChartAreas[chartAreaName].CursorX.LineColor = _4WheelsSettings.MarkerColor;

            // Y Axis
            chartName.ChartAreas[chartAreaName].AxisY.Title = _4WheelsSettings.Y1Selection;
            chartName.ChartAreas[chartAreaName].AxisY.Minimum = _4WheelsSettings.Y1Min;
            chartName.ChartAreas[chartAreaName].AxisY.Maximum = _4WheelsSettings.Y1Max;

            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.Font = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.ForeColor = _4WheelsSettings.Y1FontColor;

            chartName.ChartAreas[chartAreaName].AxisY.Title = _4WheelsSettings.Y1Selection;
            chartName.ChartAreas[chartAreaName].AxisY.TitleFont = new Font(_4WheelsSettings.Y1FontFamily, _4WheelsSettings.Y1FontSize, _4WheelsSettings.Y1FontStyle);
            chartName.ChartAreas[chartAreaName].AxisY.TitleForeColor = _4WheelsSettings.Y1FontColor;

            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.LineWidth = _4WheelsSettings.Y1MajorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.Format = "F" + _4WheelsSettings.Y1MajorDecimals;// decimals
            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.LineColor = _4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.Interval = _4WheelsSettings.Y1MajorInterval; // TickMark Interval
            chartName.ChartAreas[chartAreaName].AxisY.MajorGrid.Interval = _4WheelsSettings.Y1MajorInterval; // Major Grid Interval
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.Interval = _4WheelsSettings.Y1MajorInterval; // Major Grid Label Interval
            chartName.ChartAreas[chartAreaName].AxisY.LabelStyle.IntervalOffset = 0;

            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.Enabled = _4WheelsSettings.Y1MinorEnabled;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineDashStyle = _4WheelsSettings.Y1MinorDashStyle;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineWidth = _4WheelsSettings.Y1MinorLineWidth;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.Interval = chartName.ChartAreas[chartAreaName].AxisY.Interval / _4WheelsSettings.Y1MinorIntervalFraction;
            chartName.ChartAreas[chartAreaName].AxisY.MinorGrid.LineColor = _4WheelsSettings.Y1MinorColor;

            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.ButtonColor = _4WheelsSettings.Y1MajorColor;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.LineColor = _4WheelsSettings.Y1FontColor;
            chartName.ChartAreas[chartAreaName].AxisY.ScaleView.Zoomable = true;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.Enabled = true;
            chartName.ChartAreas[chartAreaName].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartName.ChartAreas[chartAreaName].CursorY.AutoScroll = true;
            chartName.ChartAreas[chartAreaName].CursorY.IsUserEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorY.IsUserSelectionEnabled = true;
            chartName.ChartAreas[chartAreaName].CursorY.Interval = 0.01;
            chartName.ChartAreas[chartAreaName].CursorY.LineColor = _4WheelsSettings.MarkerColor;

            // Series marker stuff

        }
        private static void AddHistoryColorSeries(Chart chartName, string chartAreaName, string seriesName, Color color)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].ChartArea = chartAreaName;
            chartName.Series[seriesName].MarkerColor = color;
            chartName.Series[seriesName].ChartType = _4Wheels.ChartType;
            chartName.Series[seriesName].MarkerStyle = _4Wheels.MarkerStyle;
            chartName.Series[seriesName].MarkerSize = _4Wheels.MarkerSizeHistory;
        }
        private static void AddSeries(Chart chartName, string chartAreaName, string seriesName)
        {
            chartName.Series.Add(seriesName);
            chartName.Series[seriesName].ChartArea = chartAreaName;
            chartName.Series[seriesName].MarkerColor = Color.FromArgb(_4Wheels.HistoryAlpha, 128, 0, 0);//Color.Transparent;//
            chartName.Series[seriesName].ChartType = _4Wheels.ChartType;
            chartName.Series[seriesName].MarkerStyle = _4Wheels.MarkerStyle;
            chartName.Series[seriesName].MarkerSize = _4Wheels.MarkerSizeHistory;
            chartName.Series[seriesName].SmartLabelStyle.Enabled = false;
            chartName.Series[seriesName].LabelBackColor = chartName.ChartAreas[chartAreaName].BackColor;
        }
        public void SetChart(Chart chartName, string seriesName, string chartAreaName)
        {
            // New Marker color stuff
            chartName.BackColor = Color.Transparent;

            GetColorSchemeColors();

            //var X1AxisSelectionDefaults = new List<object>();
            //var Y1AxisSelectionDefaults = new List<object>();
            //var Z1AxisSelectionDefaults = new List<object>();

            //XYAxisDefaults("X", _4WheelsSettings.X1Selection, _4WheelsSettings.X1Defaults);
            var X1AxisSelectionDefaults = SelectionDefaults(_4WheelsSettings.X1Selection, _4WheelsSettings.AbsoluteValues);

            _4WheelsSettings.X1DefaultMax = (float)X1AxisSelectionDefaults[0];
            _4WheelsSettings.X1DefaultMin = (float)X1AxisSelectionDefaults[1];
            _4WheelsSettings.X1DefaultMajorInterval = (double)X1AxisSelectionDefaults[2];
            _4WheelsSettings.X1DefaultMajorDecimals = (int)X1AxisSelectionDefaults[3];
            _4WheelsSettings.X1DefaultMinorEnabled = (bool)X1AxisSelectionDefaults[4];
            _4WheelsSettings.X1DefaultMinorIntervalFraction = (int)X1AxisSelectionDefaults[5];
            X1AxisToDefaults(_4WheelsSettings.X1Defaults, X1AxisSelectionDefaults);

            //XYAxisDefaults("Y", _4WheelsSettings.Y1Selection, _4WheelsSettings.Y1Defaults);
            var Y1AxisSelectionDefaults = SelectionDefaults(_4WheelsSettings.Y1Selection, _4WheelsSettings.AbsoluteValues);

            _4WheelsSettings.Y1DefaultMax = (float)Y1AxisSelectionDefaults[0];
            _4WheelsSettings.Y1DefaultMin = (float)Y1AxisSelectionDefaults[1];
            _4WheelsSettings.Y1DefaultMajorInterval = (double)Y1AxisSelectionDefaults[2];
            _4WheelsSettings.Y1DefaultMajorDecimals = (int)Y1AxisSelectionDefaults[3];
            _4WheelsSettings.Y1DefaultMinorEnabled = (bool)Y1AxisSelectionDefaults[4];
            _4WheelsSettings.Y1DefaultMinorIntervalFraction = (int)Y1AxisSelectionDefaults[5];
            Y1AxisToDefaults(_4WheelsSettings.Y1Defaults, Y1AxisSelectionDefaults);

            //ZAxisDefaults(_4WheelsSettings.Z1Selection, _4WheelsSettings.Z1Defaults);
            var Z1AxisSelectionDefaults = AbsoluteZAxisSelectionDefaults(_4WheelsSettings.Z1Selection);

            _4WheelsSettings.Z1DefaultMax = (float)Z1AxisSelectionDefaults[0];
            _4WheelsSettings.Z1DefaultMin = (float)Z1AxisSelectionDefaults[1];
            //_4WheelsSettings.Z1DefaultMajorInterval = (double)Z1AxisSelectionDefaults[2];
            //_4WheelsSettings.Z1DefaultMajorDecimals = (int)Z1AxisSelectionDefaults[3];
            //_4WheelsSettings.Z1DefaultMinorEnabled = (bool)Z1AxisSelectionDefaults[4];
            //_4WheelsSettings.Z1DefaultMinorIntervalFraction = (int)Z1AxisSelectionDefaults[5];
            Z1AxisToDefaults(_4WheelsSettings.Z1Defaults, Z1AxisSelectionDefaults);

            AddChart(chartName, chartAreaName);
            // New Marker color stuff
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor10, _4Wheels.MarkerColors[10]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor9, _4Wheels.MarkerColors[9]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor8, _4Wheels.MarkerColors[8]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor7, _4Wheels.MarkerColors[7]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor6, _4Wheels.MarkerColors[6]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor5, _4Wheels.MarkerColors[5]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor4, _4Wheels.MarkerColors[4]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor3, _4Wheels.MarkerColors[3]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor2, _4Wheels.MarkerColors[2]);
            AddHistoryColorSeries(chartName, chartAreaName, seriesName + _4Wheels.seriesColor1, _4Wheels.MarkerColors[1]);
            AddSeries(chartName, chartAreaName, seriesName);
        }
        public void SetUpDownChart(Chart chartName)
        {
            double maxmin = _4WheelsSettings.Z1Max - _4WheelsSettings.Z1Min;
            double interval = maxmin / _4Wheels.Steps;
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = _4WheelsSettings.Z1Min;

            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = 1;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = _4WheelsSettings.Z1Max;
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = interval;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = interval;
            chartName.Series["Series1"].Color = Color.Transparent;
            chartName.Series["Series1"].LabelBackColor = Color.Transparent;

            chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Clear();
            if (_4WheelsSettings.Scheme == "Green Red")
            {
                for (double i = _4WheelsSettings.Z1Min * _4Wheels.Steps; i <= _4WheelsSettings.Z1Max * _4Wheels.Steps; i += maxmin)
                {

                    double iminsteps = i - _4WheelsSettings.Z1Min * _4Wheels.Steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == maxmin * 10)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 128 / _4Wheels.Divider, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 64 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 128 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 192 / _4Wheels.Divider, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 128 / _4Wheels.Divider, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 64 / _4Wheels.Divider, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 0 / _4Wheels.Divider, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / _4Wheels.Steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / _4Wheels.Steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }
            else if (_4WheelsSettings.Scheme == "Colorblind")
            {
                Color color2 = Color.FromArgb(_4Wheels.HistoryAlpha, 0, 73, 73);
                Color color3 = Color.FromArgb(_4Wheels.HistoryAlpha, 0, 146, 146);
                Color color4 = Color.FromArgb(_4Wheels.HistoryAlpha, 255, 109, 182);
                //Color color5 = Color.FromArgb(historyalpha, 255, 182, 219);
                Color color6 = Color.FromArgb(_4Wheels.HistoryAlpha, 73, 0, 146);
                Color color7 = Color.FromArgb(_4Wheels.HistoryAlpha, 0, 109, 219);
                Color color8 = Color.FromArgb(_4Wheels.HistoryAlpha, 182, 109, 255);
                Color color9 = Color.FromArgb(_4Wheels.HistoryAlpha, 109, 182, 255);
                Color color15 = Color.FromArgb(_4Wheels.HistoryAlpha, 255, 255, 109);
                Color color14 = Color.FromArgb(_4Wheels.HistoryAlpha, 36, 255, 36);
                Color color13 = Color.FromArgb(_4Wheels.HistoryAlpha, 219, 109, 0);

                for (double i = _4WheelsSettings.Z1Min * _4Wheels.Steps; i <= _4WheelsSettings.Z1Max * _4Wheels.Steps; i += maxmin)
                {

                    double iminsteps = i - _4WheelsSettings.Z1Min * _4Wheels.Steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == maxmin * 10)
                    {
                        sl.BackColor = color13;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = color14;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = color15;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = color9;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = color8;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = color7;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = color6;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = color4;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = color3;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = color2;
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / _4Wheels.Steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / _4Wheels.Steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }
            else
            {
                for (double i = _4WheelsSettings.Z1Min * _4Wheels.Steps; i <= _4WheelsSettings.Z1Max * _4Wheels.Steps; i += maxmin)
                {
                    double iminsteps = i - _4WheelsSettings.Z1Min * _4Wheels.Steps;
                    StripLine sl = new StripLine();
                    if (Math.Abs(iminsteps) == _4WheelsSettings.Z1Max * 10)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 128 / _4Wheels.Divider, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 9)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 8)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 7)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 0 / _4Wheels.Divider, 64 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 6)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 0 / _4Wheels.Divider, 128 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 5)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 255 / _4Wheels.Divider, 0 / _4Wheels.Divider, 192 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 4)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 192 / _4Wheels.Divider, 0 / _4Wheels.Divider, 192 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 3)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 128 / _4Wheels.Divider, 0 / _4Wheels.Divider, 192 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 2)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 64 / _4Wheels.Divider, 0 / _4Wheels.Divider, 192 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 1)
                    {
                        sl.BackColor = Color.FromArgb(_4Wheels.Alpha, 0 / _4Wheels.Divider, 0 / _4Wheels.Divider, 192 / _4Wheels.Divider);
                    }
                    if (Math.Abs(iminsteps) == maxmin * 0)
                    {

                    }
                    if (i < 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / _4Wheels.Steps;
                    }
                    else if (i > 0)
                    {
                        sl.StripWidth = interval;
                        sl.IntervalOffset = ((double)i) / _4Wheels.Steps - interval;
                    }
                    chartName.ChartAreas["ChartArea1"].AxisY.StripLines.Add(sl);
                }
            }

        }
        public void SetChartsForForm()
        {
            string chartAllWheels = "ChartAreaAllWheels";
            string chartFrontWheels = "ChartAreaFront";
            string chartRearWheels = "ChartAreaRear";
            string chartFL = "ChartAreaFL";
            string chartFR = "ChartAreaFR";
            string chartRL = "ChartAreaRL";
            string chartRR = "ChartAreaRR";
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            // WORKS WRONG! Clears the chart series also
            if (_4WheelsSettings.WheelChartsSelect == "All In One")
            {
                SetChart(chart1, _4Wheels.FL_SeriesString, chartAllWheels);
                SetChart(chart1, _4Wheels.RL_SeriesString, chartAllWheels);
                SetChart(chart1, _4Wheels.FR_SeriesString, chartAllWheels);
                SetChart(chart1, _4Wheels.RR_SeriesString, chartAllWheels);
            }
            if (_4WheelsSettings.WheelChartsSelect == "Front/Rear")
            {
                // Add first front then rear
                SetChart(chart1, _4Wheels.FL_SeriesString, chartFrontWheels);
                SetChart(chart1, _4Wheels.FR_SeriesString, chartFrontWheels);
                SetChart(chart1, _4Wheels.RL_SeriesString, chartRearWheels);
                SetChart(chart1, _4Wheels.RR_SeriesString, chartRearWheels);

            }
            if (_4WheelsSettings.WheelChartsSelect == "Separate")
            {
                // Add first left and then right sides because the order of the ChartAreas is like that when there are four
                SetChart(chart1, _4Wheels.FL_SeriesString, chartFL);
                SetChart(chart1, _4Wheels.RL_SeriesString, chartRL);
                SetChart(chart1, _4Wheels.FR_SeriesString, chartFR);
                SetChart(chart1, _4Wheels.RR_SeriesString, chartRR);
            }
            SetUpDownChart(GradientChart);
        }
        public void ClearAllSeriesHistory()
        {
            _4Wheels.ClearListDataHistory();
        }
        private void ButtonLabelVisibilities()
        {
            if (_4WheelsSettings.WheelChartsSelect == "Separate")
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
            else if (_4WheelsSettings.WheelChartsSelect == "All In One")
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
            }
            else if (_4WheelsSettings.WheelChartsSelect == "Front/Rear")
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            if (_4WheelsSettings.SettingsOpen == true)
            {
                toSettingsButton.Visible = false;
            }
            if (_4WheelsSettings.SettingsOpen == false)
            {
                toSettingsButton.Visible = true;
            }
            labelUpDownChart.Text = _4WheelsSettings.Z1Selection;
        }
        private void Form4Wheels_Load(object sender, EventArgs e)
        {

            LiveData._4WheelsOpen = true;
        }
        private void Form4Wheels_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiveData._4WheelsOpen = false;
        }
        //GOOD
        private void ComboBoxAxisLimiterText(ComboBox cb, string axis, string defaultSelection)
        {
            if (cb.SelectedItem != null)
            {
                if ((string)cb.SelectedItem == defaultSelection)
                {
                    cb.Text = axis + ": " + cb.SelectedItem.ToString();
                }
                else
                {
                    cb.Text = cb.SelectedItem.ToString();
                }
            }
        }
        private string GetComboBoxAxisLimiter(ComboBox cb)
        {
            return cb.SelectedItem.ToString();
        }
        //GOOD
        private void SetComboBoxAxisLimiterTexts()
        {
            ComboBoxAxisLimiterText(X1LimiterComboBox, "X", _4WheelsSettings.X1Selection);
            ComboBoxAxisLimiterText(Y1LimiterComboBox, "Y", _4WheelsSettings.Y1Selection);
            ComboBoxAxisLimiterText(Z1LimiterComboBox, "Z", _4WheelsSettings.Z1Selection);
        }
        private void GetSetComboBoxAxisLimiter()
        {
            if (X1LimiterComboBox.SelectedItem != null)
            {
                X1LimiterSelection = GetComboBoxAxisLimiter(X1LimiterComboBox);
            }
            if (Y1LimiterComboBox.SelectedItem != null)
            {
                Y1LimiterSelection = GetComboBoxAxisLimiter(Y1LimiterComboBox);
            }
            if (Z1LimiterComboBox.SelectedItem != null)
            {
                Z1LimiterSelection = GetComboBoxAxisLimiter(Z1LimiterComboBox);
            }
        }
        /*private void GetSetDefaults(string selection, bool defaults)
        {
            var axisSelectionDefaults = AxisSelectionDefaults(X1LimiterSelection);

            X1LimiterDefaultMax = (double)axisSelectionDefaults[0];
            X1LimiterDefaultMin = (double)axisSelectionDefaults[1];
            X1AxisToDefaults(enableLimitersCheckBox.Checked, axisSelectionDefaults);
        }*/
        public void UpdateAllLimiters()
        {
            if (customChoiceCheckBox.Checked == false)
            {
                X1LimiterSelection = LimiterDefaultToSelectedAxis(X1LimiterComboBox, _4WheelsSettings.X1Selection);
                Y1LimiterSelection = LimiterDefaultToSelectedAxis(Y1LimiterComboBox, _4WheelsSettings.Y1Selection);
                Z1LimiterSelection = LimiterDefaultToSelectedAxis(Z1LimiterComboBox, _4WheelsSettings.Z1Selection);
            }
            if (customChoiceCheckBox.Checked == true)
            {
                X1LimiterSelection = LimiterSelection(X1LimiterComboBox);
            }

            var X1LimiterSelectionDefaults = SelectionDefaults(X1LimiterSelection, true);

            X1LimiterDefaultMax = (float)X1LimiterSelectionDefaults[0];
            X1LimiterDefaultMin = (float)X1LimiterSelectionDefaults[1];
            X1LimiterAxisToDefaults(enableLimitersCheckBox.Checked, X1LimiterSelectionDefaults);

            double[] X1MinMax = UpdateLimiterMinMaxArray(X1LimiterComboBox, X1MinLimitTextBox, X1LimiterDefaultMin, X1MaxLimitTextBox, X1LimiterDefaultMax);
            X1LimiterMin = X1MinMax[0];
            X1LimiterMax = X1MinMax[1];

            if (customChoiceCheckBox.Checked == true) { Y1LimiterSelection = LimiterSelection(Y1LimiterComboBox); }

            var Y1LimiterSelectionDefaults = SelectionDefaults(Y1LimiterSelection, true);

            Y1LimiterDefaultMax = (float)Y1LimiterSelectionDefaults[0];
            Y1LimiterDefaultMin = (float)Y1LimiterSelectionDefaults[1];
            Y1LimiterAxisToDefaults(enableLimitersCheckBox.Checked, Y1LimiterSelectionDefaults);

            double[] Y1MinMax = UpdateLimiterMinMaxArray(Y1LimiterComboBox, Y1MinLimitTextBox, Y1LimiterDefaultMin, Y1MaxLimitTextBox, Y1LimiterDefaultMax);
            Y1LimiterMin = Y1MinMax[0];
            Y1LimiterMax = Y1MinMax[1];

            if (customChoiceCheckBox.Checked == true) { Z1LimiterSelection = LimiterSelection(Z1LimiterComboBox); }

            var Z1LimiterSelectionDefaults = SelectionDefaults(Z1LimiterSelection, true);

            Z1LimiterDefaultMax = (float)Z1LimiterSelectionDefaults[0];
            Z1LimiterDefaultMin = (float)Z1LimiterSelectionDefaults[1];
            Z1LimiterAxisToDefaults(enableLimitersCheckBox.Checked, Z1LimiterSelectionDefaults);

            double[] Z1MinMax = UpdateLimiterMinMaxArray(Z1LimiterComboBox, Z1MinLimitTextBox, Z1LimiterDefaultMin, Z1MaxLimitTextBox, Z1LimiterDefaultMax);
            Z1LimiterMin = Z1MinMax[0];
            Z1LimiterMax = Z1MinMax[1];

            string[] x1Limiter = LimitersLabelText(X1LimiterComboBox, X1LimiterSelection);
            string[] y1Limiter = LimitersLabelText(Y1LimiterComboBox, Y1LimiterSelection);
            string[] z1Limiter = LimitersLabelText(Z1LimiterComboBox, Z1LimiterSelection);
            label17.Text = "Use only positive values on " + x1Limiter[0] + y1Limiter[0] + z1Limiter[0] + ". They get automatically also negative opposite. On " + x1Limiter[1] + y1Limiter[1] + z1Limiter[1] + " the limit works normally.";
        }
        public string[] LimitersLabelText(ComboBox cb, string limiter)
        {
            string[] arrayString = new string[2];
            if (WreckfestEnums.DataNameStringsAbsoluteValues.Contains((string)cb.SelectedItem) == true)
            {
                arrayString[0] = "/" + limiter + "/";
                arrayString[1] = "";
            }
            else
            {
                arrayString[0] = "";
                arrayString[1] = "/" + limiter + "/";
            }
            return arrayString;
        }
        private double[] UpdateLimiterMinMaxArray(ComboBox cBLimiter, TextBox tBMin, double defaultMin, TextBox tBMax, double defaultMax)
        {
            double[] limiterArray = new double[2];
            bool absoluteValueCheck = AbsoluteValueCheck(cBLimiter, tBMin, defaultMin, tBMax, defaultMax);
            //Make it so minimum if it's absolute it's 0 at the minimum.
            if (WreckfestEnums.DataNameStringsAbsoluteValues.Contains((string)cBLimiter.SelectedItem) == true)
            {
                defaultMin = 0;
            }

            limiterArray[0] = Limiter(tBMin, defaultMin, absoluteValueCheck);
            limiterArray[1] = Limiter(tBMax, defaultMax, absoluteValueCheck);
            return limiterArray;
        }
        private string LimiterSelection(ComboBox cBLimiter)
        {
            return (string)cBLimiter.SelectedItem;
        }
        private bool AbsoluteValueCheck(ComboBox cb, TextBox tBMin, double defaultMin, TextBox tBMax, double defaultMax)
        {
            bool enableCustomLimiter = EnableCustomLimiter(cb, tBMin, defaultMin, tBMax, defaultMax);
            if (enableCustomLimiter == true)
            {
                return WreckfestEnums.DataNameStringsAbsoluteValues.Contains((string)cb.SelectedItem);
            }
            else
            {
                return false;
            }
        }
        private bool EnableCustomLimiter(ComboBox cb, TextBox tBMin, double defaultMin, TextBox tBMax, double defaultMax)
        {
            if (customChoiceCheckBox.Checked == true)
            {
                cb.Enabled = true;
                if (enableLimitersCheckBox.Checked == false)
                {
                    LoadDefaultTextBoxTexts(cb, tBMin, defaultMin, tBMax, defaultMax);
                }
                return true;
            }
            else
            {
                if (enableLimitersCheckBox.Checked == false)
                {
                    LoadDefaultTextBoxTexts(cb, tBMin, defaultMin, tBMax, defaultMax);
                }
                //LimiterDefaultToSelectedAxis(cb, selection);//Needed?

                cb.Enabled = false;
                return false;
            }
        }
        /* Need to make parser and/or/checker that Max Value TextBox value can't be smaller than Min Value Textbox value */
        private double Limiter(TextBox tB, double defaultValue, bool abloluteValueCheck)
        {
            //defaultMin is either 0 when it's absolute or if it's not then it's _4WheelsSettings.xxDefaultMin
            if (enableLimitersCheckBox.Checked == true)
            {
                tB.Enabled = true;
                return TextBoxBaseParsers.Parser(tB, defaultValue, abloluteValueCheck);
            }
            else
            {
                tB.Enabled = false;
                return defaultValue;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonLabelVisibilities();
            if (enableLimitersCheckBox.Checked == true)
            {
                LimitersEnabled = true;
            }
            else
            {
                LimitersEnabled = false;
            }
            if (noTireContactLimiterEnabledCheckBox.Checked == true)
            {
                NoTireContactLimiterEnabled = true;
            }
            else
            {
                NoTireContactLimiterEnabled = false;
            }
            SetComboBoxAxisLimiterTexts();
            GetSetComboBoxAxisLimiter();
            //UpdateLimiters();
            if (LiveData.ElapsedTime > 0 && PauseUpdate == false)
            {
                xyzAxisSelection = new List<string> { _4WheelsSettings.X1Selection, _4WheelsSettings.Y1Selection, _4WheelsSettings.Z1Selection };
                List<float> FL_xyzValues = _4Wheels.ListSelections(xyzAxisSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.FL);//, LiveData.FL_LiveDataList);
                List<float> FR_xyzValues = _4Wheels.ListSelections(xyzAxisSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.FR);//,, LiveData.FR_LiveDataList);
                List<float> RL_xyzValues = _4Wheels.ListSelections(xyzAxisSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.RL);//,, LiveData.RL_LiveDataList);
                List<float> RR_xyzValues = _4Wheels.ListSelections(xyzAxisSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.RR);//,, LiveData.RR_LiveDataList);

                xyzAxisLimiterSelection = new List<string> { X1LimiterSelection, Y1LimiterSelection, Z1LimiterSelection };
                List<float> FL_limiter = _4Wheels.ListSelections(xyzAxisLimiterSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.FL);//,, LiveData.FL_LiveDataList);
                List<float> FR_limiter = _4Wheels.ListSelections(xyzAxisLimiterSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.FR);//,, LiveData.FR_LiveDataList);
                List<float> RL_limiter = _4Wheels.ListSelections(xyzAxisLimiterSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.RL);//,, LiveData.RL_LiveDataList);
                List<float> RR_limiter = _4Wheels.ListSelections(xyzAxisLimiterSelection, LiveData.None, LiveData.RaceTime, WF_Prefix.RR);//,, LiveData.RR_LiveDataList);

                _4Wheels.ListSeries(chart1, _4Wheels.FL_SeriesString, FL_xyzValues, FL_limiter, LiveData.GetFullListDataValue(WF_Prefix.FL, WF_TireDataOffset.VerticalLoad),
                    _4Wheels.FL_X1ValuesChart, _4Wheels.FL_Y1ValuesChart, _4Wheels.FL_Z1ValuesChart,
                    _4Wheels.FL_X1ValuesChartColor1, _4Wheels.FL_Y1ValuesChartColor1,
                    _4Wheels.FL_X1ValuesChartColor2, _4Wheels.FL_Y1ValuesChartColor2,
                    _4Wheels.FL_X1ValuesChartColor3, _4Wheels.FL_Y1ValuesChartColor3,
                    _4Wheels.FL_X1ValuesChartColor4, _4Wheels.FL_Y1ValuesChartColor4,
                    _4Wheels.FL_X1ValuesChartColor5, _4Wheels.FL_Y1ValuesChartColor5,
                    _4Wheels.FL_X1ValuesChartColor6, _4Wheels.FL_Y1ValuesChartColor6,
                    _4Wheels.FL_X1ValuesChartColor7, _4Wheels.FL_Y1ValuesChartColor7,
                    _4Wheels.FL_X1ValuesChartColor8, _4Wheels.FL_Y1ValuesChartColor8,
                    _4Wheels.FL_X1ValuesChartColor9, _4Wheels.FL_Y1ValuesChartColor9,
                    _4Wheels.FL_X1ValuesChartColor10, _4Wheels.FL_Y1ValuesChartColor10);

                _4Wheels.ListSeries(chart1, _4Wheels.FR_SeriesString, FR_xyzValues, FR_limiter, LiveData.GetFullListDataValue(WF_Prefix.FR, WF_TireDataOffset.VerticalLoad),
                    _4Wheels.FR_X1ValuesChart, _4Wheels.FR_Y1ValuesChart, _4Wheels.FR_Z1ValuesChart,
                    _4Wheels.FR_X1ValuesChartColor1, _4Wheels.FR_Y1ValuesChartColor1,
                    _4Wheels.FR_X1ValuesChartColor2, _4Wheels.FR_Y1ValuesChartColor2,
                    _4Wheels.FR_X1ValuesChartColor3, _4Wheels.FR_Y1ValuesChartColor3,
                    _4Wheels.FR_X1ValuesChartColor4, _4Wheels.FR_Y1ValuesChartColor4,
                    _4Wheels.FR_X1ValuesChartColor5, _4Wheels.FR_Y1ValuesChartColor5,
                    _4Wheels.FR_X1ValuesChartColor6, _4Wheels.FR_Y1ValuesChartColor6,
                    _4Wheels.FR_X1ValuesChartColor7, _4Wheels.FR_Y1ValuesChartColor7,
                    _4Wheels.FR_X1ValuesChartColor8, _4Wheels.FR_Y1ValuesChartColor8,
                    _4Wheels.FR_X1ValuesChartColor9, _4Wheels.FR_Y1ValuesChartColor9,
                    _4Wheels.FR_X1ValuesChartColor10, _4Wheels.FR_Y1ValuesChartColor10);

                _4Wheels.ListSeries(chart1, _4Wheels.RL_SeriesString, RL_xyzValues, RL_limiter, LiveData.GetFullListDataValue(WF_Prefix.RL, WF_TireDataOffset.VerticalLoad),
                    _4Wheels.RL_X1ValuesChart, _4Wheels.RL_Y1ValuesChart, _4Wheels.RL_Z1ValuesChart,
                    _4Wheels.RL_X1ValuesChartColor1, _4Wheels.RL_Y1ValuesChartColor1,
                    _4Wheels.RL_X1ValuesChartColor2, _4Wheels.RL_Y1ValuesChartColor2,
                    _4Wheels.RL_X1ValuesChartColor3, _4Wheels.RL_Y1ValuesChartColor3,
                    _4Wheels.RL_X1ValuesChartColor4, _4Wheels.RL_Y1ValuesChartColor4,
                    _4Wheels.RL_X1ValuesChartColor5, _4Wheels.RL_Y1ValuesChartColor5,
                    _4Wheels.RL_X1ValuesChartColor6, _4Wheels.RL_Y1ValuesChartColor6,
                    _4Wheels.RL_X1ValuesChartColor7, _4Wheels.RL_Y1ValuesChartColor7,
                    _4Wheels.RL_X1ValuesChartColor8, _4Wheels.RL_Y1ValuesChartColor8,
                    _4Wheels.RL_X1ValuesChartColor9, _4Wheels.RL_Y1ValuesChartColor9,
                    _4Wheels.RL_X1ValuesChartColor10, _4Wheels.RL_Y1ValuesChartColor10);

                _4Wheels.ListSeries(chart1, _4Wheels.RR_SeriesString, RR_xyzValues, RR_limiter, LiveData.GetFullListDataValue(WF_Prefix.RR, WF_TireDataOffset.VerticalLoad),
                    _4Wheels.RR_X1ValuesChart, _4Wheels.RR_Y1ValuesChart, _4Wheels.RR_Z1ValuesChart,
                    _4Wheels.RR_X1ValuesChartColor1, _4Wheels.RR_Y1ValuesChartColor1,
                    _4Wheels.RR_X1ValuesChartColor2, _4Wheels.RR_Y1ValuesChartColor2,
                    _4Wheels.RR_X1ValuesChartColor3, _4Wheels.RR_Y1ValuesChartColor3,
                    _4Wheels.RR_X1ValuesChartColor4, _4Wheels.RR_Y1ValuesChartColor4,
                    _4Wheels.RR_X1ValuesChartColor5, _4Wheels.RR_Y1ValuesChartColor5,
                    _4Wheels.RR_X1ValuesChartColor6, _4Wheels.RR_Y1ValuesChartColor6,
                    _4Wheels.RR_X1ValuesChartColor7, _4Wheels.RR_Y1ValuesChartColor7,
                    _4Wheels.RR_X1ValuesChartColor8, _4Wheels.RR_Y1ValuesChartColor8,
                    _4Wheels.RR_X1ValuesChartColor9, _4Wheels.RR_Y1ValuesChartColor9,
                    _4Wheels.RR_X1ValuesChartColor10, _4Wheels.RR_Y1ValuesChartColor10);
            }
        }
        #region BUTTONS, BOXES etc.
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toSettingsButton.Visible = false;
            _4WheelsSettings.SettingsOpen = true;
            Form4WheelsSettings s1 = new Form4WheelsSettings();
            s1.Show();
        }
        private void refreshAndApplyButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //timer2.Enabled = false;
            _4Wheels.ClearListDataHistory();
            SetUpDownChart(GradientChart);
            UpdateAllLimiters();
            if (PauseUpdate == false)
            {
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (PauseUpdate == false)
            {
                PauseUpdate = true;
                buttonPause.Text = "Continue Update";
            }
            else
            {
                PauseUpdate = false;
                buttonPause.Text = "Pause Update";
            }
        }
        private void customChoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //UpdateLimiters();
        }
        private void enableLimitersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAllLimiters();
        }
        private void xLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetComboBoxAxisLimiterTexts();
            GetSetComboBoxAxisLimiter();
        }
        private void yLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetComboBoxAxisLimiterTexts();
            GetSetComboBoxAxisLimiter();
        }
        private void zLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetComboBoxAxisLimiterTexts();
            GetSetComboBoxAxisLimiter();
        }
        // Disables keypresses, but can still modify the text with code, by keeping the ComboBox DropDownStyle as DropDown and not using the DropDownList
        private void xLimiterComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void yLimiterComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void zLimiterComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void customChoiceCheckBox_Click(object sender, EventArgs e)
        {
            UpdateAllLimiters();
        }

        private void enableLimitersCheckBox_Click(object sender, EventArgs e)
        {
            //UpdateAllLimiters();
        }

        private void noTireContactLimiterEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void applyLimitersButton_Click(object sender, EventArgs e)
        {
            UpdateAllLimiters();
        }
        #endregion
    }
}
