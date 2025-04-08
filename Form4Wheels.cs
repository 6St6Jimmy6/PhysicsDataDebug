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
            xLimiterComboBox.Enabled = false;
            yLimiterComboBox.Enabled = false;
            zLimiterComboBox.Enabled = false;
            xMinLimitTextBox.Enabled = false;
            xMaxLimitTextBox.Enabled = false;
            yMinLimitTextBox.Enabled = false;
            yMaxLimitTextBox.Enabled = false;
            zMinLimitTextBox.Enabled = false;
            zMaxLimitTextBox.Enabled = false;
            AddInComboBoxes();
            LoadDefaults();
            UpdateLimiters();
            GetComboBoxAxisLimiterTexts();
            SetChartsForForm();
        }
        private void AddInComboBoxes()
        {
            Form4WheelsSettings.AxisSelectionComboboxAdd(xLimiterComboBox);
            Form4WheelsSettings.AxisSelectionComboboxAdd(yLimiterComboBox);
            Form4WheelsSettings.AxisSelectionComboboxAdd(zLimiterComboBox);
        }
        private void LoadDefaultTexts(ComboBox cBLimiter, string selection, TextBox tBMin, double minValue, TextBox tBMax, double maxValue)
        {
            cBLimiter.SelectedItem = selection;
            tBMin.Text = minValue.ToString();
            tBMax.Text = maxValue.ToString();
        }
        private void LoadDefaults()
        {
            LoadDefaultTexts(xLimiterComboBox, _4WheelsSettings.X1Selection, xMinLimitTextBox, _4WheelsSettings.X1DefaultMin, xMaxLimitTextBox, _4WheelsSettings.X1DefaultMax);
            LoadDefaultTexts(yLimiterComboBox, _4WheelsSettings.Y1Selection, yMinLimitTextBox, _4WheelsSettings.Y1DefaultMin, yMaxLimitTextBox, _4WheelsSettings.Y1DefaultMax);
            LoadDefaultTexts(zLimiterComboBox, _4WheelsSettings.Z1Selection, zMinLimitTextBox, _4WheelsSettings.Z1DefaultMin, zMaxLimitTextBox, _4WheelsSettings.Z1DefaultMax);
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
        private void GetComboBoxAxisLimiterTexts()
        {
            ComboBoxAxisLimiterText(xLimiterComboBox, "X", _4WheelsSettings.X1Selection);
            ComboBoxAxisLimiterText(yLimiterComboBox, "Y", _4WheelsSettings.Y1Selection);
            ComboBoxAxisLimiterText(zLimiterComboBox, "Z", _4WheelsSettings.Z1Selection);
        }
        public string LimiterSelectionX = _4WheelsSettings.X1Selection;
        public string LimiterSelectionY = _4WheelsSettings.Y1Selection;
        public string LimiterSelectionZ = _4WheelsSettings.Z1Selection;

        public void UpdateLimiters()
        {
            bool aboluteValueCheckX1 = false;
            bool aboluteValueCheckY1 = false;
            bool aboluteValueCheckZ1 = false;
            if (customChoiceCheckBox.Checked == true)
            {
                xLimiterComboBox.Enabled = true;
                LimiterSelectionX = (string)xLimiterComboBox.SelectedItem;
                aboluteValueCheckX1 = _4Wheels.CBSelectionCanBeAbsoluteValue(xLimiterComboBox);
                yLimiterComboBox.Enabled = true;
                LimiterSelectionY = (string)yLimiterComboBox.SelectedItem;
                aboluteValueCheckY1 = _4Wheels.CBSelectionCanBeAbsoluteValue(yLimiterComboBox);
                zLimiterComboBox.Enabled = true;
                LimiterSelectionZ = (string)zLimiterComboBox.SelectedItem;
                aboluteValueCheckZ1 = _4Wheels.CBSelectionCanBeAbsoluteValue(zLimiterComboBox);
            }
            else
            {
                LoadDefaults();
                xLimiterComboBox.Enabled = false;
                yLimiterComboBox.Enabled = false;
                zLimiterComboBox.Enabled = false;
            }

            if (enableLimitersCheckBox.Checked == true)
            {
                xMinLimitTextBox.Enabled = true;
                xMaxLimitTextBox.Enabled = true;
                LimiterMinX = Parsers.TextBoxParserDouble(xMinLimitTextBox, _4WheelsSettings.X1DefaultMin, aboluteValueCheckX1);
                LimiterMaxX = Parsers.TextBoxParserDouble(xMaxLimitTextBox, _4WheelsSettings.X1DefaultMax, aboluteValueCheckX1);
                yMinLimitTextBox.Enabled = true;
                yMaxLimitTextBox.Enabled = true;
                LimiterMinY = Parsers.TextBoxParserDouble(yMinLimitTextBox, _4WheelsSettings.Y1DefaultMin, aboluteValueCheckY1);
                LimiterMaxY = Parsers.TextBoxParserDouble(yMaxLimitTextBox, _4WheelsSettings.Y1DefaultMax, aboluteValueCheckY1);
                zMinLimitTextBox.Enabled = true;
                zMaxLimitTextBox.Enabled = true;
                LimiterMinZ = Parsers.TextBoxParserDouble(zMinLimitTextBox, _4WheelsSettings.Z1DefaultMin, aboluteValueCheckZ1);
                LimiterMaxZ = Parsers.TextBoxParserDouble(zMaxLimitTextBox, _4WheelsSettings.Z1DefaultMax, aboluteValueCheckZ1);
            }
            else
            {
                xMinLimitTextBox.Enabled = false;
                xMaxLimitTextBox.Enabled = false;
                yMinLimitTextBox.Enabled = false;
                yMaxLimitTextBox.Enabled = false;
                zMinLimitTextBox.Enabled = false;
                zMaxLimitTextBox.Enabled = false;
            }
            label17.Text = "Use only positive values on " + LimiterSelectionX + "/" + LimiterSelectionY + "/" + LimiterSelectionZ + ". They get automatically also negative opposite. On " + LimiterSelectionX + "/" + LimiterSelectionY + "/" + LimiterSelectionZ + " the limit works normally.";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ButtonLabelVisibilities();
            if (customChoiceCheckBox.Checked == false)
            {
            }
            GetComboBoxAxisLimiterTexts();
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
            UpdateLimiters();
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
        public double LimiterMinX = _4WheelsSettings.X1DefaultMin;
        public double LimiterMinY = _4WheelsSettings.Y1DefaultMin;
        public double LimiterMinZ = _4WheelsSettings.Z1DefaultMin;
        public double LimiterMaxX = _4WheelsSettings.X1DefaultMax;
        public double LimiterMaxY = _4WheelsSettings.Y1DefaultMax;
        public double LimiterMaxZ = _4WheelsSettings.Z1DefaultMax;
        private void enableLimitersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //UpdateLimiters();
        }
        #endregion
        private void xLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetComboBoxAxisLimiterTexts();
        }
        private void yLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetComboBoxAxisLimiterTexts();
        }
        private void zLimiterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetComboBoxAxisLimiterTexts();
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
            UpdateLimiters();
        }

        private void enableLimitersCheckBox_Click(object sender, EventArgs e)
        {
            UpdateLimiters();
        }
    }
}
