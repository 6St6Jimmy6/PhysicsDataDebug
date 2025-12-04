using Memory.Win64;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormLiveData : Form
    {
        #region Field variables
        private string sTickTime = "Tick time: Nothing";

        public static Process Process;
        private bool processGet = false;

        #endregion
        public FormLiveData()
        {
            InitializeComponent();

            toSuspensionSettingsButton.Hide();// Not yet implemented

            logInterval_textBox.Text = LiveData.TickInterval.ToString();
        }
        #region Methods
        public void ButtonVisibilities()
        {
            if (LiveData.logging == true) { toLogSettingsButton.Visible = false; }
            if (LiveData.LogSettingsOpen == false && LiveData.logging == false) { toLogSettingsButton.Visible = true; }
            if (LiveData.LogSettingsOpen == true) { toLogSettingsButton.Visible = false; startFileLoggingButton.Visible = false; }
            if (LiveData.LogSettingsOpen == false) { startFileLoggingButton.Visible = true; }
            if (LiveData.TireSettingsOpen == true) { toTireSettingsButton.Visible = false; }
            if (LiveData.TireSettingsOpen == false) { toTireSettingsButton.Visible = true; }
            if (LiveData.TemperaturesChartOpen == true) { OpenTemperaturesChart.Visible = false; }
            if (LiveData.TemperaturesChartOpen == false) { OpenTemperaturesChart.Visible = true; }
            if (LiveData.GForceOpen == true) { toGForceButton.Visible = false; }
            if (LiveData.GForceOpen == false) { toGForceButton.Visible = true; }
            if (LiveData._4WheelsOpen == true) { to4WheelsButton.Visible = false; }
            if (LiveData._4WheelsOpen == false) { to4WheelsButton.Visible = true; }
        }
        private string ValueString(Enum prefix, Enum dataValue, int roundDigits, string preText = "", string afterText = "")
        {
            return preText + Math.Round(LiveData.GetFullListDataValue(prefix, dataValue), roundDigits).ToString(CultureInfo.GetCultureInfo("en-US")) + afterText;
        }
        private void SetValueInTB(TextBox tB, Enum prefix, Enum dataValue, int roundDigits, string preText = "", string suffText = "")
        {
            tB.Text = ValueString(prefix, dataValue, roundDigits);
        }
        private void textBoxTireWriter(Enum prefix, 
            TextBox angularVelocity, TextBox contactLength, TextBox currentContactBrakeTorque, TextBox maxCurrentContactBrakeTorque, TextBox deflection, TextBox effectiveRadius, TextBox lateralLoad, TextBox loadedRadius, 
            TextBox longitudinalLoad, TextBox slipRatio, TextBox travelSpeed, TextBox verticalLoad, TextBox lateralFriction, TextBox longitudinalFriction, TextBox treadTemperature, TextBox innerTemperature, 
            TextBox slipAngleDeg, TextBox totalFriciton, TextBox totalFrictionAngle, TextBox lateralSlipSpeed, TextBox longitudinalSlipSpeed, TextBox camberAngle, TextBox steerAngle, TextBox suspensionLength, TextBox suspensionVelocity)
        {
            SetValueInTB(angularVelocity, prefix, WF_TireDataOffset.AngularVelocity, 2);
            SetValueInTB(contactLength, prefix, WF_TireDataOffset.ContactLength, 4);
            SetValueInTB(currentContactBrakeTorque, prefix, WF_TireDataOffset.CurrentContactBrakeTorque, 2);
            SetValueInTB(maxCurrentContactBrakeTorque, prefix, WF_TireDataOffset.CurrentContactBrakeTorqueMax, 2);
            SetValueInTB(deflection, prefix, WF_TireDataOffset.VerticalDeflection, 4);
            SetValueInTB(effectiveRadius, prefix, WF_TireDataOffset.EffectiveRadius, 4);
            SetValueInTB(lateralLoad, prefix, WF_TireDataOffset.LateralLoad, 2);
            SetValueInTB(loadedRadius, prefix, WF_TireDataOffset.LoadedRadius, 4);
            SetValueInTB(longitudinalLoad, prefix, WF_TireDataOffset.LongitudinalLoad, 2);
            SetValueInTB(slipRatio, prefix, WF_TireDataOffset.SlipRatio, 2);
            SetValueInTB(travelSpeed, prefix, WF_TireDataOffset.TravelSpeed, 2);
            SetValueInTB(verticalLoad, prefix, WF_TireDataOffset.VerticalLoad, 2);
            SetValueInTB(lateralFriction, prefix, WF_TireDataOffset.LateralFriction, 2);
            SetValueInTB(longitudinalFriction, prefix, WF_TireDataOffset.LongitudinalFriction, 2);
            SetValueInTB(treadTemperature, prefix, WF_TireDataOffset.TreadTemperature, 2);
            SetValueInTB(innerTemperature, prefix, WF_TireDataOffset.InnerTemperature, 2);
            SetValueInTB(slipAngleDeg, prefix, WF_TireDataOffset.SlipAngleDeg, 2);
            SetValueInTB(totalFriciton, prefix, WF_TireDataOffset.TotalFriction, 2);
            SetValueInTB(totalFrictionAngle, prefix, WF_TireDataOffset.TotalFrictionAngleDeg, 2);
            SetValueInTB(lateralSlipSpeed, prefix, WF_TireDataOffset.LateralSlipSpeed, 2);
            SetValueInTB(longitudinalSlipSpeed, prefix, WF_TireDataOffset.LongitudinalSlipSpeed, 2);
            SetValueInTB(camberAngle, prefix, WF_TireDataOffset.CamberAngleDeg, 3);
            SetValueInTB(steerAngle, prefix, WF_TireDataOffset.SteerAngleDeg, 3);


            SetValueInTB(suspensionLength, prefix, WF_SuspensionDataOffset.SuspensionLength, 4);
            SetValueInTB(suspensionVelocity, prefix, WF_SuspensionDataOffset.SuspensionVelocity, 4);
        }
        private void TextBoxUpdates()
        {
            /*
            textBox1.Text = "X: " + LiveData.TXAccel + "\r\n" + "Y: " + LiveData.TYAccel + "\r\n" + "Z: " + LiveData.TZAccel;
            textBox2.Text = "R11: " + LiveData.R11Accel + "\r\n" + "R12: " + LiveData.R12Accel + "\r\n" + "R13: " + LiveData.R13Accel;
            textBox3.Text = "R21: " + LiveData.R21Accel + "\r\n" + "R22: " + LiveData.R22Accel + "\r\n" + "R23: " + LiveData.R23Accel;
            textBox4.Text = "R31: " + LiveData.R31Accel + "\r\n" + "R32: " + LiveData.R32Accel + "\r\n" + "R33: " + LiveData.R33Accel;
            textBox5.Text = "X: " + LiveData.Q1Accel + "\r\n" + "Y: " + LiveData.Q2Accel + "\r\n" + "Z: " + LiveData.Q3Accel + "\r\n" + "W: " + LiveData.Q4Accel + "\r\n" + "A1: " + LiveData.A1Accel + "\r\n" + "A2: " + LiveData.A2Accel;
            textBox6.Text = "RY°: " + Math.Round(LiveData.rotationYDeg, 2) + "\r\n" + "RY°r: " + Math.Round(LiveData.rotationYRad, 2) + "\r\n" + "gX: " + Math.Round(LiveData.XG, 2) + "\r\n" + "gY: " + Math.Round(LiveData.YG, 2) + "\r\n" + "gZ: " + Math.Round(LiveData.ZG, 2) + "\r\n" + "XZ°: " + Math.Round(LiveData.XZAccelerationAngleDeg, 2) + "\r\n" + "XZ°r: " + Math.Round(LiveData.XZAccelerationAngleRad, 2) + "\r\n" + "gXZ: " +
                Math.Round(LiveData.XZG, 2) + "\r\n" + "gXZ°: " + Math.Round(LiveData.XZGAngleDeg, 2) + "\r\n" + "gXZ°r: " + Math.Round(LiveData.XZGAngleRad, 2);
            */
            //textBox1.Text = "Front Left Angles" + "\r\n" + "Caster: " + Math.Round(LiveData.RadToDeg(LiveData.FL_TirePitchAngleRad), 3) + " | " + Math.Round(LiveData.FL_CasterAngleDeg, 3) + "\r\n" + "Toe: " + Math.Round(LiveData.RadToDeg(LiveData.FL_TireYawAngleRad), 3) + " | " + Math.Round(LiveData.FL_SteerAngleDeg, 3) + "\r\n" + "Camber: " + Math.Round(LiveData.RadToDeg(LiveData.FL_TireRollAngleRad), 3) + " | " + Math.Round(LiveData.FL_CamberAngleDeg, 3);
            //textBox2.Text = "Front Right Angles" + "\r\n" + "Caster: " + Math.Round(LiveData.RadToDeg(LiveData.FR_TirePitchAngleRad), 3) + " | " + Math.Round(LiveData.FR_CasterAngleDeg, 3) + "\r\n" + "Toe: " + Math.Round(LiveData.RadToDeg(LiveData.FR_TireYawAngleRad), 3) + " | " + Math.Round(LiveData.FR_SteerAngleDeg, 3) + "\r\n" + "Camber: " + Math.Round(LiveData.RadToDeg(LiveData.FR_TireRollAngleRad), 3) + " | " + Math.Round(LiveData.FR_CamberAngleDeg, 3);
            //textBox3.Text = "Rear Left Angles" + "\r\n" + "Caster: " + Math.Round(LiveData.RadToDeg(LiveData.RL_TirePitchAngleRad), 3) + " | " + Math.Round(LiveData.RL_CasterAngleDeg, 3) + "\r\n" + "Toe: " + Math.Round(LiveData.RadToDeg(LiveData.RL_TireYawAngleRad), 3) + " | " + Math.Round(LiveData.RL_SteerAngleDeg, 3) + "\r\n" + "Camber: " + Math.Round(LiveData.RadToDeg(LiveData.RL_TireRollAngleRad), 3) + " | " + Math.Round(LiveData.RL_CamberAngleDeg, 3);
            //textBox4.Text = "Rear Right Angles" + "\r\n" + "Caster: " + Math.Round(LiveData.RadToDeg(LiveData.RR_TirePitchAngleRad), 3) + " | " + Math.Round(LiveData.RR_CasterAngleDeg, 3) + "\r\n" + "Toe: " + Math.Round(LiveData.RadToDeg(LiveData.RR_TireYawAngleRad), 3) + " | " + Math.Round(LiveData.RR_SteerAngleDeg, 3) + "\r\n" + "Camber: " + Math.Round(LiveData.RadToDeg(LiveData.RR_TireRollAngleRad), 3) + " | " + Math.Round(LiveData.RR_CamberAngleDeg, 3);
            //textBox5.Text = LiveData.FL_TireData[0].ToString() + "\r\n" + LiveData.FL_TireData[1].ToString() + "\r\n" + LiveData.FL_TireData[2].ToString() + "\r\n" + LiveData.FL_TireData[3].ToString();
            //textBox5.Text = "RL_LonBristleStiffness: " + Math.Round(LiveData.RL_LonBristleStiffness, 2) + "\r\n" + "RL_LonForceSlide: " + Math.Round(LiveData.RL_LonForceSlide, 2) + "\r\n" + "RL_LonForceStatic: " + Math.Round(LiveData.RL_LonForceStatic, 2) + "\r\n" + "RL_LonForceTotal: " + Math.Round(LiveData.RL_LonForceTotal, 2);

            // Chassis, Engine and Differential stuff
            CurrentSpeed.Text = ValueString(WF_Prefix.Powertrain, WF_EngineDataOffset.Speed, 2);
            CurrentAcceleration.Text = ValueString(WF_Prefix.Body, WF_BodyAccelDataOffset.XYZAcceleration, 2);
            CurrentGForce.Text = ValueString(WF_Prefix.Body, WF_BodyAccelDataOffset.XYZG, 2);
            CurrentXDrag.Text = ValueString(WF_Prefix.Body, WF_AeroDataOffset.XDragLocal, 2, "X: ");
            CurrentYDrag.Text = ValueString(WF_Prefix.Body, WF_AeroDataOffset.YDragLocal, 2, "Y: ");
            CurrentZDrag.Text = ValueString(WF_Prefix.Body, WF_AeroDataOffset.ZDragLocal, 2, "Z: ");
            CurrentTotalDrag.Text = "Total: " + Math.Round(Math.Sqrt(Math.Pow(LiveData.GetFullListDataValue(WF_Prefix.Body, WF_AeroDataOffset.XDragLocal), 2) + Math.Pow(Math.Sqrt(Math.Pow(LiveData.GetFullListDataValue(WF_Prefix.Body, WF_AeroDataOffset.YDragLocal), 2) + Math.Pow(LiveData.GetFullListDataValue(WF_Prefix.Body, WF_AeroDataOffset.ZDragLocal), 2)), 2)), 2).ToString();
            CurrentFrontLift.Text = ValueString(WF_Prefix.Body, WF_AeroDataOffset.FrontLift, 2, "Front: ");
            CurrentRearLift.Text = ValueString(WF_Prefix.Body, WF_AeroDataOffset.RearLift, 2, "Rear: ");
            CurrentEngineRPM.Text = ValueString(WF_Prefix.Powertrain, WF_EngineDataOffset.EngineRPM, 0, "", " RPM");
            CurrentEngineRPMAxle.Text = ValueString(WF_Prefix.Powertrain, WF_EngineDataOffset.EngineRPMAxle, 0, "(", ") RPM");
            CurrentEngineTorque.Text = ValueString(WF_Prefix.Powertrain, WF_EngineDataOffset.EngineTorqueNm, 2, "", " Nm");
            CurrentEnginePower.Text = ValueString(WF_Prefix.Powertrain, WF_EngineDataOffset.EnginePowerKW, 2, "", " kW") + " kW";
            CurrentDifferentialSpeedRad.Text = ValueString(WF_Prefix.Powertrain, WF_DifferentialDataOffset.DifferentialVelocityRad, 2, "", " rad/s");
            CurrentDifferentialTorque.Text = ValueString(WF_Prefix.Powertrain, WF_DifferentialDataOffset.DifferentialTorque, 2, "", " Nm");
            int diffClosed = LiveData.GetFullListDataValue(WF_Prefix.Powertrain, WF_DifferentialDataOffset.DifferentialOpen);
            if (diffClosed != 0)
            {
                CurrentDifferentialOpen.Text = "Locked";// !=0 means differential is locked. ==0 means it's open
            }
            else
            {
               CurrentDifferentialOpen.Text = "Open";// !=0 means differential is locked. ==0 means it's open
            }

            textBoxTireWriter(WF_Prefix.FL, textBox_FL_AngularVelocity, textBox_FL_ContactLength, textBox_FL_CurrentContactBrakeTorque, textBox_FL_MaxCurrentContactBrakeTorque, textBox_FL_Deflection, textBox_FL_EffectiveRadius,
                textBox_FL_LateralLoad, textBox_FL_LoadedRadius, textBox_FL_LongitudinalLoad, textBox_FL_SlipRatio, textBox_FL_TravelSpeed, textBox_FL_VerticalLoad, textBox_FL_LateralFriction, textBox_FL_LongitudinalFriction, textBox_FL_TreadTemperature,
                textBox_FL_InnerTemperature, textBox_FL_SlipAngleDeg, textBox_FL_TotalFriction, textBox_FL_TotalFrictionAngle, textBox_FL_LateralSlipSpeed, textBox_FL_LongitudinalSlipSpeed, textBox_FL_CamberAngle, textBox_FL_TireSteerAngle, 
                textBox_FL_SuspensionLength, textBox_FL_SuspensionVelocity);
            textBoxTireWriter(WF_Prefix.FR, textBox_FR_AngularVelocity, textBox_FR_ContactLength, textBox_FR_CurrentContactBrakeTorque, textBox_FR_MaxCurrentContactBrakeTorque, textBox_FR_Deflection, textBox_FR_EffectiveRadius,
                textBox_FR_LateralLoad, textBox_FR_LoadedRadius, textBox_FR_LongitudinalLoad, textBox_FR_SlipRatio, textBox_FR_TravelSpeed, textBox_FR_VerticalLoad, textBox_FR_LateralFriction, textBox_FR_LongitudinalFriction, textBox_FR_TreadTemperature,
                textBox_FR_InnerTemperature, textBox_FR_SlipAngleDeg, textBox_FR_TotalFriction, textBox_FR_TotalFrictionAngle, textBox_FR_LateralSlipSpeed, textBox_FR_LongitudinalSlipSpeed, textBox_FR_CamberAngle, textBox_FR_TireSteerAngle, 
                textBox_FR_SuspensionLength, textBox_FR_SuspensionVelocity);
            textBoxTireWriter(WF_Prefix.RL, textBox_RL_AngularVelocity, textBox_RL_ContactLength, textBox_RL_CurrentContactBrakeTorque, textBox_RL_MaxCurrentContactBrakeTorque, textBox_RL_Deflection, textBox_RL_EffectiveRadius,
                textBox_RL_LateralLoad, textBox_RL_LoadedRadius, textBox_RL_LongitudinalLoad, textBox_RL_SlipRatio, textBox_RL_TravelSpeed, textBox_RL_VerticalLoad, textBox_RL_LateralFriction, textBox_RL_LongitudinalFriction, textBox_RL_TreadTemperature,
                textBox_RL_InnerTemperature, textBox_RL_SlipAngleDeg, textBox_RL_TotalFriction, textBox_RL_TotalFrictionAngle, textBox_RL_LateralSlipSpeed, textBox_RL_LongitudinalSlipSpeed, textBox_RL_CamberAngle, textBox_RL_TireSteerAngle, 
                textBox_RL_SuspensionLength, textBox_RL_SuspensionVelocity);
            textBoxTireWriter(WF_Prefix.RR, textBox_RR_AngularVelocity, textBox_RR_ContactLength, textBox_RR_CurrentContactBrakeTorque, textBox_RR_MaxCurrentContactBrakeTorque, textBox_RR_Deflection, textBox_RR_EffectiveRadius,
                textBox_RR_LateralLoad, textBox_RR_LoadedRadius, textBox_RR_LongitudinalLoad, textBox_RR_SlipRatio, textBox_RR_TravelSpeed, textBox_RR_VerticalLoad, textBox_RR_LateralFriction, textBox_RR_LongitudinalFriction, textBox_RR_TreadTemperature,
                textBox_RR_InnerTemperature, textBox_RR_SlipAngleDeg, textBox_RR_TotalFriction, textBox_RR_TotalFrictionAngle, textBox_RR_LateralSlipSpeed, textBox_RR_LongitudinalSlipSpeed, textBox_RR_CamberAngle, textBox_RR_TireSteerAngle, 
                textBox_RR_SuspensionLength, textBox_RR_SuspensionVelocity);
        }
        private void UpdateFormData()
        {
            ButtonVisibilities();
        }

        private void ProcessStart()
        {
            processGet = true;
            getProcessButton.Text = "Refresh Process";
            timer1.Enabled = true;
        }
        #endregion
        #region Form and Buttons stuff
        private void logInterval_textBox_Keypress(object sender, KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if (!Char.IsDigit(ch1) && ch1 != 8)
            {
                e.Handled = true;
            }
        }
        private void logInterval_textBox_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            // Empty box makes it 1 and not 0 or less.
            if (textbox.Text == "")
            {
                LiveData.TickInterval = 1;
                textbox.Text = "1";
            }
            else if (int.TryParse(textbox.Text, out LiveData.TickInterval))
            {
                if (LiveData.TickInterval > 2000)
                {
                    LiveData.TickInterval = 2000;
                    textbox.Text = "2000";
                }
                else if (LiveData.TickInterval < 1 || LiveData.TickInterval == -1)
                {
                    LiveData.TickInterval = 1;
                    textbox.Text = "1";
                }
            }
        }
        private void Start_Log_Click(object sender, EventArgs e)
        {
            if (LiveData.logging == true)
            {
                LiveData.logging = false;
                startFileLoggingButton.Text = "Start Logging";
            }
            else
            {
                Directory.CreateDirectory(LogSettings.LogFileSaveLocationFolder);
                LiveData.logging = true;
                startFileLoggingButton.Text = "Stop Logging";
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toLogSettingsButton.Visible = false;
            LiveData.LogSettingsOpen = true;
            FormLogSettings s1 = new FormLogSettings();
            s1.Show();
        }
        private void exitApplication_Click(object sender, EventArgs e)
        {
            LiveData.Helper.Close();
            Application.Exit();
        }
        private void toTireSettingsButton_Click(object sender, EventArgs e)
        {
            toTireSettingsButton.Visible = false;
            LiveData.TireSettingsOpen = true;
            FormTireSettings s = new FormTireSettings();
            s.Show();
        }
        private void FirstAllDataLoggerPage_Closing(object sender, FormClosingEventArgs e)
        {
            //LiveData.Helper.Close();
            //RegistryTools.SaveAllSettings(Application.ProductName, this);
            if (LiveData.Process != null && processGet == true)
            {
                timer1.Enabled = false;
            }
        }
        private void OpenTemperaturesChart_Click(object sender, EventArgs e)
        {
            OpenTemperaturesChart.Visible = false;
            LiveData.TemperaturesChartOpen = true;
            FormTireTemperatures s = new FormTireTemperatures();
            s.Show();
        }
        private void toSuspensionSettingsButton_Click(object sender, EventArgs e)
        {
            toSuspensionSettingsButton.Visible = false;
            LiveData.SuspensionSettingsOpen = true;
            FormSuspensionSettings s = new FormSuspensionSettings();
            s.Show();
        }
        private void toTestChartPageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = LogSettings.LogFileSaveLocationFolder;
            ofd.Filter = "Executable files (*exe)|*.exe|All files (*.*)|*.*";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                LogSettings.ChartPlotterLocation = ofd.FileName;
                try
                {
                    Process.Start(LogSettings.ChartPlotterLocation);
                }
                catch (Exception)
                {
                }
            }
        }
        private void FirstAllDataLoggerPage_Load(object sender, EventArgs e)
        {
            /*
            // Load saved settings
            RegistryTools.LoadAllSettings(Application.ProductName, this);
            */
        }
        private void getProcessButton_Click(object sender, EventArgs e)
        {
            LiveData.Process = Process.GetProcessesByName("Wreckfest_x64").FirstOrDefault();
            if (LiveData.Process != null && processGet == false)
            {
                ProcessStart();
            }
            else if (LiveData.Process != null && processGet == true)
            {
                getProcessButton.Text = "Getting Process";
                timer1.Enabled = false;
                processGet = false;
                ProcessStart();
            }
            else
            {
                timer1.Enabled = false;
                processGet = false;
                getProcessButton.Text = "Get Process";
                return;
            }
        }

        public bool FirstTimeLoad = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FirstTimeLoad == false)
            {
                WreckfestEnums.AddNames();
                // Needs to be in order of WF_Prefix
                LiveData.GenerateBodyDataList(WF_Prefix.Body, LiveData.Body_DataList, LiveData.FullDataList, WF_BodyRotationChunks.DataStart, WF_BodyAccelDataChunks.DataStart, WF_AeroDataChunks.DataStart);//0

                LiveData.GenerateTireDataList(WF_Prefix.FL, LiveData.FL_TireDataList, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_SuspensionChunks.DataStart);//1
                LiveData.GenerateTireDataList(WF_Prefix.FR, LiveData.FR_TireDataList, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_SuspensionChunks.DataStart);//2
                LiveData.GenerateTireDataList(WF_Prefix.RL, LiveData.RL_TireDataList, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_SuspensionChunks.DataStart);//3
                LiveData.GenerateTireDataList(WF_Prefix.RR, LiveData.RR_TireDataList, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_SuspensionChunks.DataStart);//4

                LiveData.GeneratePowertrainDataList(WF_Prefix.Powertrain, LiveData.Powertrain_DataList, LiveData.FullDataList, WF_EngineDataChunks.DataStart, WF_DifferentialDataChunks.DataStart, WF_DifferentialDataChunks.DataStart);//5
                FirstTimeLoad = true;
            }
            LiveData.GetData((ulong)BaseAddressUpdate.V1_308408);
            // Needs to be in order of WF_Prefix
            LiveData.UpdateBodyDataValues(WF_Prefix.Body, LiveData.Body_DataList, LiveData.FullDataList, WF_BodyRotationChunks.DataStart, LiveData.Body_RotationData, WF_BodyAccelDataChunks.DataStart, LiveData.Body_AccelData, WF_AeroDataChunks.DataStart, LiveData.Body_AeroData);//0

            LiveData.UpdateTireDataValues(WF_TireDataChunks.DataStart, WF_Prefix.FL, LiveData.FL_TireDataList, LiveData.FullDataList, LiveData.FL_TireData, WF_SuspensionChunks.DataStart, LiveData.FL_SuspensionData);//1
            LiveData.UpdateTireDataValues(WF_TireDataChunks.DataStart, WF_Prefix.FR, LiveData.FR_TireDataList, LiveData.FullDataList, LiveData.FR_TireData, WF_SuspensionChunks.DataStart, LiveData.FR_SuspensionData);//2
            LiveData.UpdateTireDataValues(WF_TireDataChunks.DataStart, WF_Prefix.RL, LiveData.RL_TireDataList, LiveData.FullDataList, LiveData.RL_TireData, WF_SuspensionChunks.DataStart, LiveData.RL_SuspensionData);//3
            LiveData.UpdateTireDataValues(WF_TireDataChunks.DataStart, WF_Prefix.RR, LiveData.RR_TireDataList, LiveData.FullDataList, LiveData.RR_TireData, WF_SuspensionChunks.DataStart, LiveData.RR_SuspensionData);//4

            LiveData.UpdatePowertrainDataValues(WF_EngineDataChunks.DataStart, WF_Prefix.Powertrain, LiveData.Powertrain_DataList, LiveData.FullDataList, LiveData.Powertrain_EngineData, WF_DifferentialDataChunks.DataStart, LiveData.Powertrain_DifferentialPrimaryAxleData, WF_DifferentialDataChunks.DataStart, LiveData.Powertrain_DifferentialSecondaryAxleData);//5
            //LiveData.ConsoleTireData(LiveData.TireDataList);

            LiveData.LogToFile();
            //ButtonVisibilities();
            if (checkBox1.Checked == true && LiveData.ElapsedTime > 0)
            {
                TextBoxUpdates();
            }
            sTickTime = "Tick time " + LiveData.ElapsedTime + " ms";
            TickTime.Text = sTickTime;
            timer1.Interval = LiveData.TickInterval;
        }

        private void buttonUpdates_Tick(object sender, EventArgs e)
        {
            UpdateFormData();
        }
        private void toGForceButton_Click(object sender, EventArgs e)
        {
            toGForceButton.Visible = false;
            LiveData.GForceOpen = true;
            FormGForce s1 = new FormGForce();
            s1.Show();
        }
        #endregion
        private void to4WheelsButton_Click(object sender, EventArgs e)
        {
            to4WheelsButton.Visible = false;
            LiveData._4WheelsOpen = true;
            Form4Wheels s1 = new Form4Wheels();
            s1.Show();
        }
    }
}