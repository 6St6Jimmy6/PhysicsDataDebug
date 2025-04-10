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

        public string X1LimiterSelection = _4WheelsSettings.X1Selection;
        public string Y1LimiterSelection = _4WheelsSettings.Y1Selection;
        public string Z1LimiterSelection = _4WheelsSettings.Z1Selection;
        /*
        public double X1LimiterDefaultMin = _4WheelsSettings.X1DefaultMin;
        public double Y1LimiterDefaultMin = _4WheelsSettings.Y1DefaultMin;
        public double Z1LimiterDefaultMin = _4WheelsSettings.Z1DefaultMin;

        public double X1LimiterDefaultMax = _4WheelsSettings.X1DefaultMax;
        public double Y1LimiterDefaultMax = _4WheelsSettings.Y1DefaultMax;
        public double Z1LimiterDefaultMax = _4WheelsSettings.Z1DefaultMax;
        */
        public double X1LimiterMin = _4WheelsSettings.X1DefaultMin;
        public double Y1LimiterMin = _4WheelsSettings.Y1DefaultMin;
        public double Z1LimiterMin = _4WheelsSettings.Z1DefaultMin;

        public double X1LimiterMax = _4WheelsSettings.X1DefaultMax;
        public double Y1LimiterMax = _4WheelsSettings.Y1DefaultMax;
        public double Z1LimiterMax = _4WheelsSettings.Z1DefaultMax;

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
        private void LoadDefaultTexts(ComboBox cBSelection, TextBox tBMin, double minValue, TextBox tBMax, double maxValue)
        {
            if (IsAbsoluteValue(cBSelection) == true)
            {
                minValue = 0;
            }
            LoadDefaultTextMin(tBMin, minValue);
            LoadDefaultTextMax(tBMax, maxValue);
        }
        private void LimiterDefaultToSelectedAxis(ComboBox cBLimiter, string selection)
        {
            cBLimiter.SelectedItem = selection;
        }
        private void LoadDefaults()
        {
            LoadDefaultTexts(X1LimiterComboBox, X1MinLimitTextBox, X1LimiterDefaultMin, X1MaxLimitTextBox, X1LimiterDefaultMax);
            LimiterDefaultToSelectedAxis(X1LimiterComboBox, X1LimiterSelection);
            LoadDefaultTexts(Y1LimiterComboBox, Y1MinLimitTextBox, Y1LimiterDefaultMin, Y1MaxLimitTextBox, Y1LimiterDefaultMax);
            LimiterDefaultToSelectedAxis(Y1LimiterComboBox, Y1LimiterSelection);
            LoadDefaultTexts(Z1LimiterComboBox, Z1MinLimitTextBox, Z1LimiterDefaultMin, Z1MaxLimitTextBox, Z1LimiterDefaultMax);
            LimiterDefaultToSelectedAxis(Z1LimiterComboBox, Z1LimiterSelection);
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
                _4Wheels.SetChart(chart1, _4Wheels.SeriesFL, chartAllWheels);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesRL, chartAllWheels);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesFR, chartAllWheels);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesRR, chartAllWheels);
            }
            if (_4WheelsSettings.WheelChartsSelect == "Front/Rear")
            {
                // Add first front then rear
                _4Wheels.SetChart(chart1, _4Wheels.SeriesFL, chartFrontWheels);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesFR, chartFrontWheels);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesRL, chartRearWheels);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesRR, chartRearWheels);

            }
            if (_4WheelsSettings.WheelChartsSelect == "Separate")
            {
                // Add first left and then right sides because the order of the ChartAreas is like that when there are four
                _4Wheels.SetChart(chart1, _4Wheels.SeriesFL, chartFL);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesRL, chartRL);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesFR, chartFR);
                _4Wheels.SetChart(chart1, _4Wheels.SeriesRR, chartRR);
            }
            _4Wheels.SetUpDownChart(GradientChart);
        }
        public void ClearAllSeriesHistory()
        {
            _4Wheels.ClearSeriesHistory(chart1);
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
            else if(_4WheelsSettings.WheelChartsSelect == "Front/Rear")
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
        private float[] FL_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4WheelsSettings.Y1Selection, _4WheelsSettings.Z1Selection,
                                                    LiveData.RaceTime, LiveData.FL_TravelSpeed, LiveData.FL_AngularVelocity,
                                                    LiveData.FL_VerticalLoad, LiveData.FL_VerticalDeflection, LiveData.FL_LoadedRadius, LiveData.FL_EffectiveRadius, LiveData.FL_ContactLength,
                                                    LiveData.FL_CurrentContactBrakeTorque, LiveData.FL_CurrentContactBrakeTorqueMax,
                                                    LiveData.FL_SteerAngleDeg, LiveData.FL_CamberAngleDeg,
                                                    LiveData.FL_LateralLoad, LiveData.FL_SlipAngleDeg, LiveData.FL_LateralFriction, LiveData.FL_LateralSlipSpeed,
                                                    LiveData.FL_LongitudinalLoad, LiveData.FL_SlipRatio, LiveData.FL_LongitudinalFriction, LiveData.FL_LongitudinalSlipSpeed,
                                                    LiveData.FL_TreadTemperature, LiveData.FL_InnerTemperature,
                                                    LiveData.FL_TotalFriction, LiveData.FL_TotalFrictionAngle,
                                                    LiveData.FL_SuspensionLength, LiveData.FL_SuspensionVelocity);
        }
        private float[] FR_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4WheelsSettings.Y1Selection, _4WheelsSettings.Z1Selection,
                                                    LiveData.RaceTime, LiveData.FR_TravelSpeed, LiveData.FR_AngularVelocity,
                                                    LiveData.FR_VerticalLoad, LiveData.FR_VerticalDeflection, LiveData.FR_LoadedRadius, LiveData.FR_EffectiveRadius, LiveData.FR_ContactLength,
                                                    LiveData.FR_CurrentContactBrakeTorque, LiveData.FR_CurrentContactBrakeTorqueMax,
                                                    LiveData.FR_SteerAngleDeg, LiveData.FR_CamberAngleDeg,
                                                    LiveData.FR_LateralLoad, LiveData.FR_SlipAngleDeg, LiveData.FR_LateralFriction, LiveData.FR_LateralSlipSpeed,
                                                    LiveData.FR_LongitudinalLoad, LiveData.FR_SlipRatio, LiveData.FR_LongitudinalFriction, LiveData.FR_LongitudinalSlipSpeed,
                                                    LiveData.FR_TreadTemperature, LiveData.FR_InnerTemperature,
                                                    LiveData.FR_TotalFriction, LiveData.FR_TotalFrictionAngle,
                                                    LiveData.FR_SuspensionLength, LiveData.FR_SuspensionVelocity);
        }
        private float[] RL_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4WheelsSettings.Y1Selection, _4WheelsSettings.Z1Selection,
                                                    LiveData.RaceTime, LiveData.RL_TravelSpeed, LiveData.RL_AngularVelocity,
                                                    LiveData.RL_VerticalLoad, LiveData.RL_VerticalDeflection, LiveData.RL_LoadedRadius, LiveData.RL_EffectiveRadius, LiveData.RL_ContactLength,
                                                    LiveData.RL_CurrentContactBrakeTorque, LiveData.RL_CurrentContactBrakeTorqueMax,
                                                    LiveData.RL_SteerAngleDeg, LiveData.RL_CamberAngleDeg,
                                                    LiveData.RL_LateralLoad, LiveData.RL_SlipAngleDeg, LiveData.RL_LateralFriction, LiveData.RL_LateralSlipSpeed,
                                                    LiveData.RL_LongitudinalLoad, LiveData.RL_SlipRatio, LiveData.RL_LongitudinalFriction, LiveData.RL_LongitudinalSlipSpeed,
                                                    LiveData.RL_TreadTemperature, LiveData.RL_InnerTemperature,
                                                    LiveData.RL_TotalFriction, LiveData.RL_TotalFrictionAngle,
                                                    LiveData.RL_SuspensionLength, LiveData.RL_SuspensionVelocity);
        }
        private float[] RR_XYZValues()
        {
            return _4Wheels.XYZListSelections(_4WheelsSettings.X1Selection, _4WheelsSettings.Y1Selection, _4WheelsSettings.Z1Selection,
                                                    LiveData.RaceTime, LiveData.RR_TravelSpeed, LiveData.RR_AngularVelocity,
                                                    LiveData.RR_VerticalLoad, LiveData.RR_VerticalDeflection, LiveData.RR_LoadedRadius, LiveData.RR_EffectiveRadius, LiveData.RR_ContactLength,
                                                    LiveData.RR_CurrentContactBrakeTorque, LiveData.RR_CurrentContactBrakeTorqueMax,
                                                    LiveData.RR_SteerAngleDeg, LiveData.RR_CamberAngleDeg,
                                                    LiveData.RR_LateralLoad, LiveData.RR_SlipAngleDeg, LiveData.RR_LateralFriction, LiveData.RR_LateralSlipSpeed,
                                                    LiveData.RR_LongitudinalLoad, LiveData.RR_SlipRatio, LiveData.RR_LongitudinalFriction, LiveData.RR_LongitudinalSlipSpeed,
                                                    LiveData.RR_TreadTemperature, LiveData.RR_InnerTemperature,
                                                    LiveData.RR_TotalFriction, LiveData.RR_TotalFrictionAngle,
                                                    LiveData.RR_SuspensionLength, LiveData.RR_SuspensionVelocity);
        }
        //GOOD
        private void ComboBoxAxisLimiterText(ComboBox cb, string axis, string defaultSelection)
        {
            if(cb.SelectedItem != null)
            {
                if((string)cb.SelectedItem == defaultSelection)
                {
                    cb.Text = axis + ": " + cb.SelectedItem.ToString();
                }
                else
                {
                    cb.Text = cb.SelectedItem.ToString();
                }
            }
        }
        //GOOD
        private void SetComboBoxAxisLimiterTexts()
        {
            ComboBoxAxisLimiterText(X1LimiterComboBox, "X", _4WheelsSettings.X1Selection);
            ComboBoxAxisLimiterText(Y1LimiterComboBox, "Y", _4WheelsSettings.Y1Selection);
            ComboBoxAxisLimiterText(Z1LimiterComboBox, "Z", _4WheelsSettings.Z1Selection);
        }
        public void UpdateAllLimiters()
        {
            if (customChoiceCheckBox.Checked == true) { X1LimiterSelection = LimiterSelection(X1LimiterComboBox); }//GOOD
            //double[] X1MinMax = UpdateLimiterMinMaxArray(X1LimiterComboBox, _4WheelsSettings.X1Selection, X1MinLimitTextBox, _4WheelsSettings.X1DefaultMin, X1MaxLimitTextBox, _4WheelsSettings.X1DefaultMax);
            double[] X1MinMax = UpdateLimiterMinMaxArray(X1LimiterComboBox, X1MinLimitTextBox, X1LimiterDefaultMin, X1MaxLimitTextBox, X1LimiterDefaultMax);
            X1LimiterMin = X1MinMax[0];
            X1LimiterMax = X1MinMax[1];

            if (customChoiceCheckBox.Checked == true) { Y1LimiterSelection = LimiterSelection(Y1LimiterComboBox); }
            //double[] Y1MinMax = UpdateLimiterMinMaxArray(Y1LimiterComboBox, _4WheelsSettings.Y1Selection, Y1MinLimitTextBox, _4WheelsSettings.Y1DefaultMin, Y1MaxLimitTextBox, _4WheelsSettings.Y1DefaultMax);
            double[] Y1MinMax = UpdateLimiterMinMaxArray(Y1LimiterComboBox, Y1MinLimitTextBox, Y1LimiterDefaultMin, Y1MaxLimitTextBox, Y1LimiterDefaultMax);
            Y1LimiterMin = Y1MinMax[0];
            Y1LimiterMax = Y1MinMax[1];

            if (customChoiceCheckBox.Checked == true) { Z1LimiterSelection = LimiterSelection(Z1LimiterComboBox); }
            //double[] Z1MinMax = UpdateLimiterMinMaxArray(Z1LimiterComboBox, _4WheelsSettings.Z1Selection, Z1MinLimitTextBox, _4WheelsSettings.Z1DefaultMin, Z1MaxLimitTextBox, _4WheelsSettings.Z1DefaultMax);
            double[] Z1MinMax = UpdateLimiterMinMaxArray(Z1LimiterComboBox, Z1MinLimitTextBox, Z1LimiterDefaultMin, Z1MaxLimitTextBox, Z1LimiterDefaultMax);
            Z1LimiterMin = Z1MinMax[0];
            Z1LimiterMax = Z1MinMax[1];
            string first;
            string second;
            string third;
            string fourth;
            string fifth;
            string sixth;
            if(IsAbsoluteValue(X1LimiterComboBox) == true)
            {
                first = "/" + X1LimiterSelection + "/";
                fourth = "";
            }
            else
            {
                first = "";
                fourth = "/" + X1LimiterSelection + "/";
            }
            if (IsAbsoluteValue(Y1LimiterComboBox) == true)
            {
                second = "/" + Y1LimiterSelection + "/";
                fifth = "";
            }
            else
            {
                second = "";
                fifth = "/" + Y1LimiterSelection + "/";
            }
            if (IsAbsoluteValue(Z1LimiterComboBox) == true)
            {
                third = "/" + Z1LimiterSelection + "/";
                sixth = "";
            }
            else
            {
                third = "";
                sixth = "/" + Z1LimiterSelection + "/";
            }
            label17.Text = "Use only positive values on " + first + second + third + ". They get automatically also negative opposite. On " + fourth + fifth + sixth + " the limit works normally.";
        }
        private bool IsAbsoluteValue(ComboBox cb)
        {
            return _4Wheels.CBSelectionIsAbsoluteValue(cb);
        }
        private double[] UpdateLimiterMinMaxArray(ComboBox cBLimiter, TextBox tBMin, double defaultMin, TextBox tBMax, double defaultMax)
        {
            double[] limiterArray = new double[2];
            bool absoluteValueCheck = AbsoluteValueCheck(cBLimiter, tBMin, defaultMin, tBMax, defaultMax);
            //bool absoluteValueCheck = AbsoluteValueCheck(cBLimiter, selection, tBMin, defaultMin, tBMax, defaultMax);
            //Make it so minimum if it's absolute it's 0 at the minimum.
            if (IsAbsoluteValue(cBLimiter) == true)
            {
                defaultMin = 0;
            }
            limiterArray[0] = MinLimiter(tBMin, defaultMin, absoluteValueCheck);
            limiterArray[1] = MaxLimiter(tBMax, defaultMax, absoluteValueCheck);
            return limiterArray;
        }
        private string LimiterSelection(ComboBox cBLimiter)
        {
            return (string)cBLimiter.SelectedItem;
        }
        private bool AbsoluteValueCheck(ComboBox cb, TextBox tBMin, double defaultMin, TextBox tBMax, double defaultMax)
        {
            //bool enableCustomLimiter = EnableCustomLimiter(cb, selection, tBMin, defaultMin, tBMax, defaultMax);
            bool enableCustomLimiter = EnableCustomLimiter(cb, tBMin, defaultMin, tBMax, defaultMax);//Use this instead and remove the LimiterDefaultToSelectedAxis(cb, selection); from inside?
            if (enableCustomLimiter == true)
            {
                //return _4Wheels.CBSelectionCanBeAbsoluteValue(cb);
                return IsAbsoluteValue(cb);
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
                return true;
            }
            else
            {
                LoadDefaultTexts(cb, tBMin, defaultMin, tBMax, defaultMax);
                //LimiterDefaultToSelectedAxis(cb, selection);//Needed?

                cb.Enabled = false;
                return false;
            }
        }
        /* Need to make parser and/or/checker that Max Value TextBox value can't be smaller than Min Value Textbox value */
        private double MinLimiter(TextBox tBMin, double defaultMin, bool abloluteValueCheck)
        {
            //defaultMin is either 0 when it's absolute or if it's not then it's _4WheelsSettings.xxDefaultMin
            if (enableLimitersCheckBox.Checked == true)
            {
                tBMin.Enabled = true;
                return Parsers.TextBoxParserDouble(tBMin, defaultMin, abloluteValueCheck);
            }
            else
            {
                tBMin.Enabled = false;
                return defaultMin;
            }
        }
        private double MaxLimiter(TextBox tBMax, double defaultMax, bool abloluteValueCheck)
        {
            if (enableLimitersCheckBox.Checked == true)
            {
                tBMax.Enabled = true;
                return Parsers.TextBoxParserDouble(tBMax, defaultMax, abloluteValueCheck);
            }
            else
            {
                tBMax.Enabled = false;
                return defaultMax;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonLabelVisibilities();
            if (customChoiceCheckBox.Checked == false)
            {
            }
            SetComboBoxAxisLimiterTexts();
            //UpdateLimiters();
            if (LiveData.elapsedTime > 0 && PauseUpdate == false)
            {
                float[] xyzValuesFL = FL_XYZValues();
                float[] xyzValuesFR = FR_XYZValues();
                float[] xyzValuesRL = RL_XYZValues();
                float[] xyzValuesRR = RR_XYZValues();

                _4Wheels.ListSeries(chart1, _4Wheels.SeriesFL, xyzValuesFL[0], xyzValuesFL[1], xyzValuesFL[2]);
                _4Wheels.ListSeries(chart1, _4Wheels.SeriesFR, xyzValuesFR[0], xyzValuesFR[1], xyzValuesFR[2]);
                _4Wheels.ListSeries(chart1, _4Wheels.SeriesRL, xyzValuesRL[0], xyzValuesRL[1], xyzValuesRL[2]);
                _4Wheels.ListSeries(chart1, _4Wheels.SeriesRR, xyzValuesRR[0], xyzValuesRR[1], xyzValuesRR[2]);
            }
        }
        #region BUTTONS
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
            _4Wheels.ClearSeriesHistory(chart1);
            _4Wheels.SetUpDownChart(GradientChart);
            UpdateAllLimiters();
            if (PauseUpdate == false)
            {
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if(PauseUpdate == false)
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
            //UpdateLimiters();
        }
        #endregion
        private void xLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetComboBoxAxisLimiterTexts();
        }
        private void yLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetComboBoxAxisLimiterTexts();
        }
        private void zLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetComboBoxAxisLimiterTexts();
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
            UpdateAllLimiters();
        }
    }
}
