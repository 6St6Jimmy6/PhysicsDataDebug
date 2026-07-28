using Memory.Win64;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        public static bool ProcessGet { get; set; } = false;
        public static bool FirstTimeLoad = false;
        object SelectedVersion;

        #endregion
        public FormLiveData()
        {
            InitializeComponent();
            bool debugEnabled = false;

            textBox1.Visible = debugEnabled;
            textBox2.Visible = debugEnabled;
            textBox3.Visible = debugEnabled;
            textBox4.Visible = debugEnabled;
            textBox5.Visible = debugEnabled;
            textBox6.Visible = debugEnabled;
            label16.Visible = debugEnabled;
            label17.Visible = debugEnabled;
            label22.Visible = debugEnabled;
            label23.Visible = debugEnabled;
            label37.Visible = debugEnabled;

            textBox1.Enabled = debugEnabled;
            textBox2.Enabled = debugEnabled;
            textBox3.Enabled = debugEnabled;
            textBox4.Enabled = debugEnabled;
            textBox5.Enabled = debugEnabled;
            textBox6.Enabled = debugEnabled;

            logInterval_textBox.Text = LiveData.TickInterval.ToString();

            GameVersionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (long e in Enum.GetValues(typeof(BaseAddressUpdate)))
            {
                GameVersionComboBox.Items.Add((BaseAddressUpdate)e);
            }
            GameVersionComboBox.SelectedItem = BaseAddressUpdate.V1_308408;
            SelectedVersion = GameVersionComboBox.SelectedItem;

            foreach (Label l in this.Controls.OfType<Label>())
            {
                if(l.Name.Contains("FL_") || l.Name.Contains("FR_") || l.Name.Contains("RL_") || l.Name.Contains("RR_"))
                {
                    l.TextAlign = ContentAlignment.TopRight;
                    l.BackColor = Color.Transparent;
                    l.ForeColor = Color.White;
                    l.Enabled = true;
                }
            }

            if (FirstTimeLoad == false)
            {
                //Dictionary<WF_PrefixMain, Dictionary<WF_PrefixSecondary, DataItem>> DefaultWF1Dictionary = WF_Dictionary.DefaultWF1Dictionary;
                WreckfestEnums.AddNames();
                // Needs to be in order of WF_Prefix
                LiveData.GenerateBodyDataList(WF_PrefixMain.Body, LiveData.FullDataList);//0

                LiveData.GenerateTireDataList(WF_PrefixMain.FL, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_Suspension1DataChunks.DataStart);//1
                LiveData.GenerateTireDataList(WF_PrefixMain.FR, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_Suspension1DataChunks.DataStart);//2
                LiveData.GenerateTireDataList(WF_PrefixMain.RL, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_Suspension1DataChunks.DataStart);//3
                LiveData.GenerateTireDataList(WF_PrefixMain.RR, LiveData.FullDataList, WF_TireDataChunks.DataStart, WF_Suspension1DataChunks.DataStart);//4

                LiveData.GeneratePowertrainDataList(WF_PrefixMain.Powertrain, LiveData.FullDataList, WF_EngineDataChunks.DataStart, WF_DifferentialDataChunks.DataStart, WF_DifferentialDataChunks.DataStart);//5
                FirstTimeLoad = true;
            }
        }
        #region Methods
        public void ButtonVisibilities()
        {
            if (LiveData.Logging == true) { toLogSettingsButton.Visible = false; }
            if (LiveData.LogSettingsOpen == false && LiveData.Logging == false) { toLogSettingsButton.Visible = true; }
            if (LiveData.LogSettingsOpen == true) { toLogSettingsButton.Visible = false; startFileLoggingButton.Visible = false; }
            if (LiveData.LogSettingsOpen == false) { startFileLoggingButton.Visible = true; }
            if (LiveData.FormTireStaticValues == true) { toTireStaticValues.Visible = false; }
            if (LiveData.FormTireStaticValues == false) { toTireStaticValues.Visible = true; }
            if (LiveData.TemperaturesChartOpen == true) { OpenTemperaturesChart.Visible = false; }
            if (LiveData.TemperaturesChartOpen == false) { OpenTemperaturesChart.Visible = true; }
            if (LiveData.GForceOpen == true) { toGForceButton.Visible = false; }
            if (LiveData.GForceOpen == false) { toGForceButton.Visible = true; }
            if (LiveData._4WheelsOpen == true) { to4WheelsButton.Visible = false; }
            if (LiveData._4WheelsOpen == false) { to4WheelsButton.Visible = true; }
            if (LiveData.FormSuspensionStaticValuesOpen == true) { toSuspensionStaticValues.Visible = false; }
            if (LiveData.FormSuspensionStaticValuesOpen == false) { toSuspensionStaticValues.Visible = true; }
            if (LiveData.FormSuspensionGeometryOpen == true) { toSuspensionGeometry.Visible = false; }
            if (LiveData.FormSuspensionGeometryOpen == false) { toSuspensionGeometry.Visible = true; }



        }
        private void labelTireWriter(Enum prefix,
            Label angularVelocity, Label contactLength, Label currentContactBrakeTorque, Label maxCurrentContactBrakeTorque, Label deflection, Label effectiveRadius, Label lateralLoad, Label loadedRadius,
            Label longitudinalLoad, Label slipRatio, Label travelSpeed, Label verticalLoad, Label lateralFriction, Label longitudinalFriction, Label treadTemperature, Label innerTemperature,
            Label slipAngleDeg, Label totalFriction, Label totalFrictionAngle, Label lateralSlipSpeed, Label longitudinalSlipSpeed, Label camberAngle, Label steerAngle, Label suspensionLength, Label suspensionVelocity, Label mx, Label mz, Label my, Label pneumaticTrail, Label rollingResistance)
        {
            LiveData.SetValueInLabel(angularVelocity, prefix, WF_TireDataOffset.AngularVelocity, 2);
            LiveData.SetValueInLabel(contactLength, prefix, WF_TireDataOffset.ContactLength, 4);
            LiveData.SetValueInLabel(currentContactBrakeTorque, prefix, WF_TireDataOffset.CurrentContactBrakeTorque, 2);
            LiveData.SetValueInLabel(maxCurrentContactBrakeTorque, prefix, WF_TireDataOffset.CurrentContactBrakeTorqueMax, 2);
            LiveData.SetValueInLabel(deflection, prefix, WF_TireDataOffset.VerticalDeflection, 4);
            LiveData.SetValueInLabel(effectiveRadius, prefix, WF_TireDataOffset.EffectiveRadius, 4);
            LiveData.SetValueInLabel(lateralLoad, prefix, WF_TireDataOffset.LateralLoad, 2);
            LiveData.SetValueInLabel(loadedRadius, prefix, WF_TireDataOffset.LoadedRadius, 4);
            LiveData.SetValueInLabel(longitudinalLoad, prefix, WF_TireDataOffset.LongitudinalLoad, 2);
            LiveData.SetValueInLabel(slipRatio, prefix, WF_TireDataOffset.SlipRatio, 2);
            LiveData.SetValueInLabel(travelSpeed, prefix, WF_TireDataOffset.TravelSpeed, 2);
            LiveData.SetValueInLabel(verticalLoad, prefix, WF_TireDataOffset.VerticalLoad, 2);
            LiveData.SetValueInLabel(lateralFriction, prefix, WF_TireDataOffset.LateralFriction, 2);
            LiveData.SetValueInLabel(longitudinalFriction, prefix, WF_TireDataOffset.LongitudinalFriction, 2);
            LiveData.SetValueInLabel(treadTemperature, prefix, WF_TireDataOffset.TreadTemperature, 2);
            LiveData.SetValueInLabel(innerTemperature, prefix, WF_TireDataOffset.InnerTemperature, 2);
            LiveData.SetValueInLabel(slipAngleDeg, prefix, WF_TireDataOffset.SlipAngleDeg, 2);
            LiveData.SetValueInLabel(totalFriction, prefix, WF_TireDataOffset.TotalFriction, 2);
            LiveData.SetValueInLabel(totalFrictionAngle, prefix, WF_TireDataOffset.TotalFrictionAngleDeg, 2);
            LiveData.SetValueInLabel(lateralSlipSpeed, prefix, WF_TireDataOffset.LateralSlipSpeed, 2);
            LiveData.SetValueInLabel(longitudinalSlipSpeed, prefix, WF_TireDataOffset.LongitudinalSlipSpeed, 2);
            LiveData.SetValueInLabel(camberAngle, prefix, WF_TireDataOffset.CamberAngleDeg, 3);
            LiveData.SetValueInLabel(steerAngle, prefix, WF_TireDataOffset.SteerAngleDeg, 3);


            LiveData.SetValueInLabel(suspensionLength, prefix, WF_Suspension1DataOffset.SuspensionLength, 4);
            LiveData.SetValueInLabel(suspensionVelocity, prefix, WF_Suspension1DataOffset.SuspensionVelocity, 4);


            LiveData.SetValueInLabel(mx, prefix, WF_TireDataOffset.Mx, 2);
            LiveData.SetValueInLabel(mz, prefix, WF_TireDataOffset.Mz, 2);
            LiveData.SetValueInLabel(my, prefix, WF_TireDataOffset.My, 2);

            LiveData.SetValueInLabel(pneumaticTrail, prefix, WF_TireDataOffset.PneumaticTrail, 6);
            LiveData.SetValueInLabel(rollingResistance, prefix, WF_TireDataOffset.RollingResistance, 5);
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
            CurrentSpeed.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_EngineDataOffset.Speed, 2);
            CurrentAcceleration.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZAcceleration, 2);
            CurrentGForce.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZG, 2);
            CurrentXDrag.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_AeroDataOffset.XDragLocal, 2, "X: ");
            CurrentYDrag.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_AeroDataOffset.YDragLocal, 2, "Y: ");
            CurrentZDrag.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_AeroDataOffset.ZDragLocal, 2, "Z: ");
            CurrentTotalDrag.Text = "Total: " + Math.Round(Math.Sqrt(Math.Pow(LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_AeroDataOffset.XDragLocal), 2) + Math.Pow(Math.Sqrt(Math.Pow(LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_AeroDataOffset.YDragLocal), 2) + Math.Pow(LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_AeroDataOffset.ZDragLocal), 2)), 2)), 2).ToString();
            CurrentFrontLift.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_AeroDataOffset.FrontLift, 2, "Front: ");
            CurrentRearLift.Text = LiveData.ValueString(WF_PrefixMain.Body, WF_AeroDataOffset.RearLift, 2, "Rear: ");
            CurrentEngineRPM.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_EngineDataOffset.EngineRPM, 0, "", " RPM");
            CurrentEngineRPMAxle.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_EngineDataOffset.EngineRPMAxle, 0, "(", ") RPM");
            CurrentEngineTorque.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_EngineDataOffset.EngineTorqueNm, 2, "", " Nm");
            CurrentEnginePower.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_EngineDataOffset.EnginePowerKW, 2, "", " kW") + " kW";
            CurrentLeftDifferentialSpeedRad.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_DifferentialDataOffset.DifferentialVelocityRadPrimaryLeft, 2, "", " rad/s");
            CurrentLeftDifferentialTorque.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_DifferentialDataOffset.DifferentialTorquePrimaryLeft, 2, "", " Nm");
            int diffPrimClosed = LiveData.GetFullListDataValue(WF_PrefixMain.Powertrain, WF_DifferentialDataOffset.DifferentialOpenPrimaryLeft);
            if (diffPrimClosed != 0)
            {
                CurrentLeftDifferentialOpen.Text = "Locked";// !=0 means differential is locked. ==0 means it's open
            }
            else
            {
               CurrentLeftDifferentialOpen.Text = "Open";// !=0 means differential is locked. ==0 means it's open
            }

            CurrentRightDifferentialSpeedRad.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_DifferentialDataOffset.DifferentialVelocityRadPrimaryLeft, 2, "", " rad/s");
            CurrentRightDifferentialTorque.Text = LiveData.ValueString(WF_PrefixMain.Powertrain, WF_DifferentialDataOffset.DifferentialTorquePrimaryLeft, 2, "", " Nm");
            int diffSecClosed = LiveData.GetFullListDataValue(WF_PrefixMain.Powertrain, WF_DifferentialDataOffset.DifferentialOpenPrimaryRight);
            if (diffSecClosed != 0)
            {
                CurrentRightDifferentialOpen.Text = "Locked";// !=0 means differential is locked. ==0 means it's open
            }
            else
            {
                CurrentRightDifferentialOpen.Text = "Open";// !=0 means differential is locked. ==0 means it's open
            }
            labelTireWriter(WF_PrefixMain.FL, label_FL_AngularVelocity, label_FL_ContactLength, label_FL_CurrentContactBrakeTorque, label_FL_MaxCurrentContactBrakeTorque, label_FL_Deflection, label_FL_EffectiveRadius,
                label_FL_LateralLoad, label_FL_LoadedRadius, label_FL_LongitudinalLoad, label_FL_SlipRatio, label_FL_TravelSpeed, label_FL_VerticalLoad, label_FL_LateralFriction, label_FL_LongitudinalFriction, label_FL_TreadTemperature,
                label_FL_InnerTemperature, label_FL_SlipAngleDeg, label_FL_TotalFriction, label_FL_TotalFrictionAngle, label_FL_LateralSlipSpeed, label_FL_LongitudinalSlipSpeed, label_FL_CamberAngle, label_FL_TireSteerAngle,
                label_FL_SuspensionLength, label_FL_SuspensionVelocity, label_FL_Mx, label_FL_Mz, label_FL_My, label_FL_PneumaticTrail, label_FL_RollingResistance);
            labelTireWriter(WF_PrefixMain.FR, label_FR_AngularVelocity, label_FR_ContactLength, label_FR_CurrentContactBrakeTorque, label_FR_MaxCurrentContactBrakeTorque, label_FR_Deflection, label_FR_EffectiveRadius,
                label_FR_LateralLoad, label_FR_LoadedRadius, label_FR_LongitudinalLoad, label_FR_SlipRatio, label_FR_TravelSpeed, label_FR_VerticalLoad, label_FR_LateralFriction, label_FR_LongitudinalFriction, label_FR_TreadTemperature,
                label_FR_InnerTemperature, label_FR_SlipAngleDeg, label_FR_TotalFriction, label_FR_TotalFrictionAngle, label_FR_LateralSlipSpeed, label_FR_LongitudinalSlipSpeed, label_FR_CamberAngle, label_FR_TireSteerAngle,
                label_FR_SuspensionLength, label_FR_SuspensionVelocity, label_FR_Mx, label_FR_Mz, label_FR_My, label_FR_PneumaticTrail, label_FR_RollingResistance);
            labelTireWriter(WF_PrefixMain.RL, label_RL_AngularVelocity, label_RL_ContactLength, label_RL_CurrentContactBrakeTorque, label_RL_MaxCurrentContactBrakeTorque, label_RL_Deflection, label_RL_EffectiveRadius,
                label_RL_LateralLoad, label_RL_LoadedRadius, label_RL_LongitudinalLoad, label_RL_SlipRatio, label_RL_TravelSpeed, label_RL_VerticalLoad, label_RL_LateralFriction, label_RL_LongitudinalFriction, label_RL_TreadTemperature,
                label_RL_InnerTemperature, label_RL_SlipAngleDeg, label_RL_TotalFriction, label_RL_TotalFrictionAngle, label_RL_LateralSlipSpeed, label_RL_LongitudinalSlipSpeed, label_RL_CamberAngle, label_RL_TireSteerAngle,
                label_RL_SuspensionLength, label_RL_SuspensionVelocity, label_RL_Mx, label_RL_Mz, label_RL_My, label_RL_PneumaticTrail, label_RL_RollingResistance);
            labelTireWriter(WF_PrefixMain.RR, label_RR_AngularVelocity, label_RR_ContactLength, label_RR_CurrentContactBrakeTorque, label_RR_MaxCurrentContactBrakeTorque, label_RR_Deflection, label_RR_EffectiveRadius,
                label_RR_LateralLoad, label_RR_LoadedRadius, label_RR_LongitudinalLoad, label_RR_SlipRatio, label_RR_TravelSpeed, label_RR_VerticalLoad, label_RR_LateralFriction, label_RR_LongitudinalFriction, label_RR_TreadTemperature,
                label_RR_InnerTemperature, label_RR_SlipAngleDeg, label_RR_TotalFriction, label_RR_TotalFrictionAngle, label_RR_LateralSlipSpeed, label_RR_LongitudinalSlipSpeed, label_RR_CamberAngle, label_RR_TireSteerAngle,
                label_RR_SuspensionLength, label_RR_SuspensionVelocity, label_RR_Mx, label_RR_Mz, label_RR_My, label_RR_PneumaticTrail, label_RR_RollingResistance);
        }
        private void UpdateFormData()
        {
            ButtonVisibilities();
        }

        private void ProcessStart()
        {
            ProcessGet = true;
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
            if (LiveData.Logging == true)
            {
                LiveData.Logging = false;
                startFileLoggingButton.Text = "Start Logging";
            }
            else
            {
                Directory.CreateDirectory(LogSettings.LogFileSaveLocationFolder);
                LiveData.Logging = true;
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
        private void toTireStaticValues_Click(object sender, EventArgs e)
        {
            toTireStaticValues.Visible = false;
            LiveData.FormTireStaticValues = true;
            FormTireStaticValues s = new FormTireStaticValues();
            s.Show();
        }
        private void FirstAllDataLoggerPage_Closing(object sender, FormClosingEventArgs e)
        {
            //LiveData.Helper.Close();
            //RegistryTools.SaveAllSettings(Application.ProductName, this);
            if (LiveData.Process != null && ProcessGet == true)
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
        private void toSuspensionStaticValuesButton_Click(object sender, EventArgs e)
        {
            toSuspensionStaticValues.Visible = false;
            LiveData.FormSuspensionStaticValuesOpen = true;
            FormSuspensionStaticValues s = new FormSuspensionStaticValues();
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
            if (LiveData.Process != null && ProcessGet == false)
            {
                ProcessStart();
            }
            else if (LiveData.Process != null && ProcessGet == true)
            {
                getProcessButton.Text = "Getting Process";
                timer1.Enabled = false;
                ProcessGet = false;
                ProcessStart();
            }
            else
            {
                timer1.Enabled = false;
                ProcessGet = false;
                getProcessButton.Text = "Get Process";
                return;
            }
        }
        public static bool ValuesGet { get; set; } = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            LiveData.GetData((long)SelectedVersion);
            // Needs to be in order of WF_Prefix
            LiveData.UpdateBodyDataValues(WF_PrefixMain.Body, LiveData.FullDataList, WF_BodyRotationChunks.DataStart, LiveData.Body_RotationData, WF_BodyAccelDataChunks.DataStart, LiveData.Body_AccelData, WF_AeroDataChunks.DataStart, LiveData.Body_AeroData, WF_MassDataChunks.DataStart, LiveData.Body_MassData);//0

            LiveData.UpdateTireDataValues(WF_PrefixMain.FL, LiveData.FullDataList, WF_TireDataChunks.DataStart, LiveData.FL_TireData, WF_Suspension1DataChunks.DataStart, LiveData.FL_SuspensionData, WF_SuspensionGeometryDataChunks.DataStart, LiveData.FL_SuspensionGeometryData, WF_Suspension2DataChunks.DataStart, LiveData.FL_Suspension2Data);//1
            LiveData.UpdateTireDataValues(WF_PrefixMain.FR, LiveData.FullDataList, WF_TireDataChunks.DataStart, LiveData.FR_TireData, WF_Suspension1DataChunks.DataStart, LiveData.FR_SuspensionData, WF_SuspensionGeometryDataChunks.DataStart, LiveData.FR_SuspensionGeometryData, WF_Suspension2DataChunks.DataStart, LiveData.FR_Suspension2Data);//2
            LiveData.UpdateTireDataValues(WF_PrefixMain.RL, LiveData.FullDataList, WF_TireDataChunks.DataStart, LiveData.RL_TireData, WF_Suspension1DataChunks.DataStart, LiveData.RL_SuspensionData, WF_SuspensionGeometryDataChunks.DataStart, LiveData.RL_SuspensionGeometryData, WF_Suspension2DataChunks.DataStart, LiveData.RL_Suspension2Data);//3
            LiveData.UpdateTireDataValues(WF_PrefixMain.RR, LiveData.FullDataList, WF_TireDataChunks.DataStart, LiveData.RR_TireData, WF_Suspension1DataChunks.DataStart, LiveData.RR_SuspensionData, WF_SuspensionGeometryDataChunks.DataStart, LiveData.RR_SuspensionGeometryData, WF_Suspension2DataChunks.DataStart, LiveData.RR_Suspension2Data);//4

            LiveData.UpdatePowertrainDataValues(WF_PrefixMain.Powertrain, LiveData.FullDataList, WF_EngineDataChunks.DataStart, LiveData.Powertrain_EngineData, WF_DifferentialDataChunks.DataStart, LiveData.Powertrain_DifferentialPrimaryAxleData, WF_DifferentialDataChunks.DataStart, LiveData.Powertrain_DifferentialSecondaryAxleData);//5
            //LiveData.ConsoleTireData(LiveData.TireDataList);
            ValuesGet = true;
            DataLogger.LogToFile();
            //ButtonVisibilities();
            if (checkBox1.Checked == true)
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
        private void CheckFontColorAndSetBackGroundColor(ComboBox cb, Color fontColor)
        {
            if (fontColor == Color.White || fontColor == Color.WhiteSmoke || fontColor == Color.AntiqueWhite || fontColor == Color.FloralWhite || fontColor == Color.NavajoWhite)
            {
                cb.BackColor = Color.Black;
            }
            else
            {
                cb.BackColor = SystemColors.Window;
            }
            cb.ForeColor = fontColor;
        }

        private void GameVersionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectedVersion = GameVersionComboBox.SelectedItem;
        }

        private void toSuspensionGeometryOpen_Click(object sender, EventArgs e)
        {
            toSuspensionGeometry.Visible = false;
            LiveData.FormSuspensionGeometryOpen = true;
            FormSuspensionGeometry s = new FormSuspensionGeometry();
            s.Show();
        }
    }
}