using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Numerics;

namespace Physics_Data_Debug
{
    public partial class FormLiveData : Form
    {
        #region Field variables
        /*
        public static bool logging = false;

        private static System.Timers.Timer aTimer { get; set; }

        private readonly int[] raceTimeArray = new int[3];
        private readonly int[] tickTimeArray = new int[3];
        private int elapsedTime = 0;
        
        public static bool SettingsOpen { get; set; } = false;

        private static DateTime previousTime;
        private double dTickTime = 16;

        public static int GScale = 25;

        Process process;
        Memory.Win64.MemoryHelper64 Helper { get; set; }
        */
        private string sTickTime = "Tick time: Nothing";


        private bool processGet = false;

        #endregion
        public FormLiveData()
        {
            InitializeComponent();

            toSuspensionSettingsButton.Hide();// Not yet implemented

            logInterval_textBox.Text = LiveData.tickInterval.ToString();
            //panel1.Paint += new PaintEventHandler(panel1_Paint);
            //panel2.Paint += new PaintEventHandler(panel2_Paint);

        }
        #region Methods
        public void ButtonVisibilities()
        {
            if (LiveData.logging == true)
            {
                toLogSettingsButton.Visible = false;
            }
            if (LiveData.LogSettingsOpen == false && LiveData.logging == false)
            {
                toLogSettingsButton.Visible = true;
            }
            if (LiveData.LogSettingsOpen == true)
            {
                toLogSettingsButton.Visible = false;
                startFileLoggingButton.Visible = false;
            }
            if (LiveData.LogSettingsOpen == false)
            {
                startFileLoggingButton.Visible = true;
            }
            if (LiveData.TireSettingsOpen == true)
            {
                toTireSettingsButton.Visible = false;
            }
            if (LiveData.TireSettingsOpen == false)
            {
                toTireSettingsButton.Visible = true;
            }
            if (LiveData.TemperaturesChartOpen == true)
            {
                OpenTemperaturesChart.Visible = false;
            }
            if (LiveData.TemperaturesChartOpen == false)
            {
                OpenTemperaturesChart.Visible = true;
            }
            if (LiveData.GForceOpen == true)
            {
                toGForceButton.Visible = false;
            }
            if (LiveData.GForceOpen == false)
            {
                toGForceButton.Visible = true;
            }
            if (LiveData._4WheelsOpen == true)
            {
                to4WheelsButton.Visible = false;
            }
            if (LiveData._4WheelsOpen == false)
            {
                to4WheelsButton.Visible = true;
            }
        }

        private void TextBoxUpdates()
        {
            /*
            textBox1.Text = "X: " + LiveData.TX + "\r\n" + "Y: " + LiveData.TY + "\r\n" + "Z: " + LiveData.TZ;
            textBox2.Text = "R11: " + LiveData.R11 + "\r\n" + "R12: " + LiveData.R12 + "\r\n" + "R13: " + LiveData.R13;
            textBox3.Text = "R21: " + LiveData.R21 + "\r\n" + "R22: " + LiveData.R22 + "\r\n" + "R23: " + LiveData.R23;
            textBox4.Text = "R31: " + LiveData.R31 + "\r\n" + "R32: " + LiveData.R32 + "\r\n" + "R33: " + LiveData.R33;
            textBox5.Text = "X: " + LiveData.Q1 + "\r\n" + "Y: " + LiveData.Q2 + "\r\n" + "Z: " + LiveData.Q3 + "\r\n" + "W: " + LiveData.Q4;
            textBox6.Text = "RY°: " + Math.Round(LiveData.rotationYDeg, 2) + "\r\n" + "RY°r: " + Math.Round(LiveData.rotationYRad, 2) + "\r\n" + "gX: " + Math.Round(LiveData.XG, 2) + "\r\n" + "gY: " + Math.Round(LiveData.YG, 2) + "\r\n" + "gZ: " + Math.Round(LiveData.ZG, 2) + "\r\n" + "XZ°: " + Math.Round(LiveData.XZAccelerationAngleDeg, 2) + "\r\n" + "XZ°r: " + Math.Round(LiveData.XZAccelerationAngleRad, 2) + "\r\n" + "gXZ: " +
                Math.Round(LiveData.XZG, 2) + "\r\n" + "gXZ°: " + Math.Round(LiveData.XZGAngleDeg, 2) + "\r\n" + "gXZ°r: " + Math.Round(LiveData.XZGAngleRad, 2);
            */
            // Chassis, Engine and Differential stuff
            CurrentSpeed.Text = Math.Round(LiveData.speed, 2).ToString();
            CurrentAcceleration.Text = Math.Round(LiveData.XYZAcceleration, 2).ToString();
            CurrentGForce.Text = Math.Round(LiveData.XYZG, 2).ToString();
            CurrentFrontLift.Text = Math.Round(LiveData.frontLift, 2).ToString();
            CurrentRearLift.Text = Math.Round(LiveData.rearLift, 2).ToString();
            CurrentEngineRPM.Text = Math.Round(LiveData.engineRPM, 0).ToString() + " RPM";
            CurrentEngineRPMAxle.Text = "(" + Math.Round(LiveData.engineRPMAxle, 0).ToString() + ") RPM";
            CurrentEngineTorque.Text = Math.Round(LiveData.engineTorque, 2).ToString() + " Nm";
            CurrentEnginePower.Text = Math.Round(LiveData.enginePower, 2).ToString() + " kW";
            if (LiveData.differentialLocked == 1)
            {
                CurrentDifferentialOpen.Text = "Locked";
            }
            else
            {
                CurrentDifferentialOpen.Text = "Open";
            }
            CurrentDifferentialSpeedRad.Text = Math.Round(LiveData.differentialVelocityRad, 2).ToString() + " rad/s";
            CurrentDifferentialTorque.Text = Math.Round(LiveData.differentialTorque, 2).ToString() + " Nm";


            //Tire and Suspension data
            //Front left
            textBox_FL_AngularVelocity.Text = Math.Round(LiveData.FL_AngularVelocity, 2).ToString();
            textBox_FL_ContactLength.Text = Math.Round(LiveData.FL_ContactLength, 4).ToString();
            textBox_FL_CurrentContactBrakeTorque.Text = Math.Round(LiveData.FL_CurrentContactBrakeTorque, 2).ToString();
            textBox_FL_MaxCurrentContactBrakeTorque.Text = Math.Round(LiveData.FL_CurrentContactBrakeTorqueMax, 2).ToString();
            textBox_FL_Deflection.Text = Math.Round(LiveData.FL_VerticalDeflection, 4).ToString();
            textBox_FL_EffectiveRadius.Text = Math.Round(LiveData.FL_EffectiveRadius, 4).ToString();
            textBox_FL_LateralLoad.Text = Math.Round(LiveData.FL_LateralLoad, 2).ToString();
            textBox_FL_LoadedRadius.Text = Math.Round(LiveData.FL_LoadedRadius, 4).ToString();
            textBox_FL_LongitudinalLoad.Text = Math.Round(LiveData.FL_LongitudinalLoad, 2).ToString();
            //textBox_FL_SlipAngleRad.Text = Math.Round(LiveData.FL_SlipAngleRad, 2).ToString();
            textBox_FL_SlipRatio.Text = Math.Round(LiveData.FL_SlipRatio, 2).ToString();
            textBox_FL_TravelSpeed.Text = Math.Round(LiveData.FL_TravelSpeed, 2).ToString();
            textBox_FL_VerticalLoad.Text = Math.Round(LiveData.FL_VerticalLoad, 2).ToString();
            textBox_FL_LateralFriction.Text = Math.Round(LiveData.FL_LateralFriction, 2).ToString();
            textBox_FL_LongitudinalFriction.Text = Math.Round(LiveData.FL_LongitudinalFriction, 2).ToString();
            textBox_FL_TreadTemperature.Text = Math.Round(LiveData.FL_TreadTemperature, 2).ToString();
            textBox_FL_InnerTemperature.Text = Math.Round(LiveData.FL_InnerTemperature, 2).ToString();
            textBox_FL_SlipAngleDeg.Text = Math.Round(LiveData.FL_SlipAngleDeg, 2).ToString();
            textBox_FL_TotalFriction.Text = Math.Round(LiveData.FL_TotalFriction, 2).ToString();//
            textBox_FL_TotalFrictionAngle.Text = Math.Round(LiveData.FL_TotalFrictionAngle, 2).ToString();//
            textBox_FL_LateralSlipSpeed.Text = Math.Round(LiveData.FL_LateralSlipSpeed, 2).ToString();//
            textBox_FL_LongitudinalSlipSpeed.Text = Math.Round(LiveData.FL_LongitudinalSlipSpeed, 2).ToString();//
            textBox_FL_CamberAngle.Text = Math.Round(LiveData.FL_CamberAngleDeg, 2).ToString();//
            textBox_FL_TireSteerAngle.Text = Math.Round(LiveData.FL_SteerAngleDeg, 2).ToString();//

            textBox_FL_SuspensionLength.Text = Math.Round(LiveData.FL_SuspensionLength, 4).ToString();
            textBox_FL_SuspensionVelocity.Text = Math.Round(LiveData.FL_SuspensionVelocity, 4).ToString();

            //Front right
            textBox_FR_AngularVelocity.Text = Math.Round(LiveData.FR_AngularVelocity, 2).ToString();
            textBox_FR_ContactLength.Text = Math.Round(LiveData.FR_ContactLength, 4).ToString();
            textBox_FR_CurrentContactBrakeTorque.Text = Math.Round(LiveData.FR_CurrentContactBrakeTorque, 2).ToString();
            textBox_FR_MaxCurrentContactBrakeTorque.Text = Math.Round(LiveData.FR_CurrentContactBrakeTorqueMax, 2).ToString();
            textBox_FR_Deflection.Text = Math.Round(LiveData.FR_VerticalDeflection, 4).ToString();
            textBox_FR_EffectiveRadius.Text = Math.Round(LiveData.FR_EffectiveRadius, 4).ToString();
            textBox_FR_LateralLoad.Text = Math.Round(LiveData.FR_LateralLoad, 2).ToString();
            textBox_FR_LoadedRadius.Text = Math.Round(LiveData.FR_LoadedRadius, 4).ToString();
            textBox_FR_LongitudinalLoad.Text = Math.Round(LiveData.FR_LongitudinalLoad, 2).ToString();
            //textBox_FR_SlipAngleRad.Text = Math.Round(LiveData.FR_SlipAngleRad, 2).ToString();
            textBox_FR_SlipRatio.Text = Math.Round(LiveData.FR_SlipRatio, 2).ToString();
            textBox_FR_TravelSpeed.Text = Math.Round(LiveData.FR_TravelSpeed, 2).ToString();
            textBox_FR_VerticalLoad.Text = Math.Round(LiveData.FR_VerticalLoad, 2).ToString();
            textBox_FR_LateralFriction.Text = Math.Round(LiveData.FR_LateralFriction, 2).ToString();
            textBox_FR_LongitudinalFriction.Text = Math.Round(LiveData.FR_LongitudinalFriction, 2).ToString();
            textBox_FR_TreadTemperature.Text = Math.Round(LiveData.FR_TreadTemperature, 2).ToString();
            textBox_FR_InnerTemperature.Text = Math.Round(LiveData.FR_InnerTemperature, 2).ToString();
            textBox_FR_SlipAngleDeg.Text = Math.Round(LiveData.FR_SlipAngleDeg, 2).ToString();
            textBox_FR_TotalFriction.Text = Math.Round(LiveData.FR_TotalFriction, 2).ToString();//
            textBox_FR_TotalFrictionAngle.Text = Math.Round(LiveData.FR_TotalFrictionAngle, 2).ToString();//
            textBox_FR_LateralSlipSpeed.Text = Math.Round(LiveData.FR_LateralSlipSpeed, 2).ToString();//
            textBox_FR_LongitudinalSlipSpeed.Text = Math.Round(LiveData.FR_LongitudinalSlipSpeed, 2).ToString();//
            textBox_FR_CamberAngle.Text = Math.Round(LiveData.FR_CamberAngleDeg, 2).ToString();//
            textBox_FR_TireSteerAngle.Text = Math.Round(LiveData.FR_SteerAngleDeg, 2).ToString();//

            textBox_FR_SuspensionLength.Text = Math.Round(LiveData.FR_SuspensionLength, 4).ToString();
            textBox_FR_SuspensionVelocity.Text = Math.Round(LiveData.FR_SuspensionVelocity, 4).ToString();

            //Rear left
            textBox_RL_AngularVelocity.Text = Math.Round(LiveData.RL_AngularVelocity, 2).ToString();
            textBox_RL_ContactLength.Text = Math.Round(LiveData.RL_ContactLength, 4).ToString();
            textBox_RL_CurrentContactBrakeTorque.Text = Math.Round(LiveData.RL_CurrentContactBrakeTorque, 2).ToString();
            textBox_RL_MaxCurrentContactBrakeTorque.Text = Math.Round(LiveData.RL_CurrentContactBrakeTorqueMax, 2).ToString();
            textBox_RL_Deflection.Text = Math.Round(LiveData.RL_VerticalDeflection, 4).ToString();
            textBox_RL_EffectiveRadius.Text = Math.Round(LiveData.RL_EffectiveRadius, 4).ToString();
            textBox_RL_LateralLoad.Text = Math.Round(LiveData.RL_LateralLoad, 2).ToString();
            textBox_RL_LoadedRadius.Text = Math.Round(LiveData.RL_LoadedRadius, 4).ToString();
            textBox_RL_LongitudinalLoad.Text = Math.Round(LiveData.RL_LongitudinalLoad, 2).ToString();
            //textBox_RL_SlipAngleRad.Text = Math.Round(LiveData.RL_SlipAngleRad, 2).ToString();
            textBox_RL_SlipRatio.Text = Math.Round(LiveData.RL_SlipRatio, 2).ToString();
            textBox_RL_TravelSpeed.Text = Math.Round(LiveData.RL_TravelSpeed, 2).ToString();
            textBox_RL_VerticalLoad.Text = Math.Round(LiveData.RL_VerticalLoad, 2).ToString();
            textBox_RL_LateralFriction.Text = Math.Round(LiveData.RL_LateralFriction, 2).ToString();
            textBox_RL_LongitudinalFriction.Text = Math.Round(LiveData.RL_LongitudinalFriction, 2).ToString();
            textBox_RL_TreadTemperature.Text = Math.Round(LiveData.RL_TreadTemperature, 2).ToString();
            textBox_RL_InnerTemperature.Text = Math.Round(LiveData.RL_InnerTemperature, 2).ToString();
            textBox_RL_SlipAngleDeg.Text = Math.Round(LiveData.RL_SlipAngleDeg, 2).ToString();
            textBox_RL_TotalFriction.Text = Math.Round(LiveData.RL_TotalFriction, 2).ToString();//
            textBox_RL_TotalFrictionAngle.Text = Math.Round(LiveData.RL_TotalFrictionAngle, 2).ToString();//
            textBox_RL_LateralSlipSpeed.Text = Math.Round(LiveData.RL_LateralSlipSpeed, 2).ToString();//
            textBox_RL_LongitudinalSlipSpeed.Text = Math.Round(LiveData.RL_LongitudinalSlipSpeed, 2).ToString();//
            textBox_RL_CamberAngle.Text = Math.Round(LiveData.RL_CamberAngleDeg, 2).ToString();//
            textBox_RL_TireSteerAngle.Text = Math.Round(LiveData.RL_SteerAngleDeg, 2).ToString();//

            textBox_RL_SuspensionLength.Text = Math.Round(LiveData.RL_SuspensionLength, 4).ToString();
            textBox_RL_SuspensionVelocity.Text = Math.Round(LiveData.RL_SuspensionVelocity, 4).ToString();

            //Rear right
            textBox_RR_AngularVelocity.Text = Math.Round(LiveData.RR_AngularVelocity, 2).ToString();
            textBox_RR_ContactLength.Text = Math.Round(LiveData.RR_ContactLength, 4).ToString();
            textBox_RR_CurrentContactBrakeTorque.Text = Math.Round(LiveData.RR_CurrentContactBrakeTorque, 2).ToString();
            textBox_RR_MaxCurrentContactBrakeTorque.Text = Math.Round(LiveData.RR_CurrentContactBrakeTorqueMax, 2).ToString();
            textBox_RR_Deflection.Text = Math.Round(LiveData.RR_VerticalDeflection, 4).ToString();
            textBox_RR_EffectiveRadius.Text = Math.Round(LiveData.RR_EffectiveRadius, 4).ToString();
            textBox_RR_LateralLoad.Text = Math.Round(LiveData.RR_LateralLoad, 2).ToString();
            textBox_RR_LoadedRadius.Text = Math.Round(LiveData.RR_LoadedRadius, 4).ToString();
            textBox_RR_LongitudinalLoad.Text = Math.Round(LiveData.RR_LongitudinalLoad, 2).ToString();
            //textBox_RR_SlipAngleRad.Text = Math.Round(LiveData.RR_SlipAngleRad, 2).ToString();
            textBox_RR_SlipRatio.Text = Math.Round(LiveData.RR_SlipRatio, 2).ToString();
            textBox_RR_TravelSpeed.Text = Math.Round(LiveData.RR_TravelSpeed, 2).ToString();
            textBox_RR_VerticalLoad.Text = Math.Round(LiveData.RR_VerticalLoad, 2).ToString();
            textBox_RR_LateralFriction.Text = Math.Round(LiveData.RR_LateralFriction, 2).ToString();
            textBox_RR_LongitudinalFriction.Text = Math.Round(LiveData.RR_LongitudinalFriction, 2).ToString();
            textBox_RR_TreadTemperature.Text = Math.Round(LiveData.RR_TreadTemperature, 2).ToString();
            textBox_RR_InnerTemperature.Text = Math.Round(LiveData.RR_InnerTemperature, 2).ToString();
            textBox_RR_SlipAngleDeg.Text = Math.Round(LiveData.RR_SlipAngleDeg, 2).ToString();
            textBox_RR_TotalFriction.Text = Math.Round(LiveData.RR_TotalFriction, 2).ToString();//
            textBox_RR_TotalFrictionAngle.Text = Math.Round(LiveData.RR_TotalFrictionAngle, 2).ToString();//
            textBox_RR_LateralSlipSpeed.Text = Math.Round(LiveData.RR_LateralSlipSpeed, 2).ToString();//
            textBox_RR_LongitudinalSlipSpeed.Text = Math.Round(LiveData.RR_LongitudinalSlipSpeed, 2).ToString();//
            textBox_RR_CamberAngle.Text = Math.Round(LiveData.RR_CamberAngleDeg, 2).ToString();//
            textBox_RR_TireSteerAngle.Text = Math.Round(LiveData.RR_SteerAngleDeg, 2).ToString();//

            textBox_RR_SuspensionLength.Text = Math.Round(LiveData.RR_SuspensionLength, 4).ToString();
            textBox_RR_SuspensionVelocity.Text = Math.Round(LiveData.RR_SuspensionVelocity, 4).ToString();
        }
        private void UpdateFormData()
        {
            ButtonVisibilities();
            //TextBoxUpdates();
            //string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ProcessStart()
        {

            processGet = true;

            getProcessButton.Text = "Refresh Process";
            //update.Start();
            timer1.Enabled = true;
            /*
            aTimer = new System.Timers.Timer(LiveData.tickInterval);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            */
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            /*
            dTickTime = (e.SignalTime - previousTime).TotalMilliseconds;
            sTickTime = "Tick time " + dTickTime + " ms";
            previousTime = e.SignalTime;
            aTimer.Interval = LiveData.tickInterval;
            */
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
                LiveData.tickInterval = 1;
                textbox.Text = "1";
            }
            else if (int.TryParse(textbox.Text, out LiveData.tickInterval))
            {
                if (LiveData.tickInterval > 2000)
                {
                    LiveData.tickInterval = 2000;
                    textbox.Text = "2000";
                }
                else if (LiveData.tickInterval < 1 || LiveData.tickInterval == -1)
                {
                    LiveData.tickInterval = 1;
                    textbox.Text = "1";
                }
            }
        }
        /**********************************OUTDATED SUFF*****************************************
        private void tempCorrectionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if(ch1 == 44 && tempCorrectionBox.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch1) && ch1 != 8 && ch1 != 44 && ch1 != 45)
            {
                e.Handled = true;
            }
        }

        private void tempCorrectionBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tempCorrectionBox.Text))
            {
                TempCorrectionValue = 0;
            }
            else
            {
                TempCorrectionValue = Convert.ToDouble(tempCorrectionBox.Text);
            } 
        }

        */
        private void Start_Log_Click(object sender, EventArgs e)
        {
            if (LiveData.logging == true)
            {
                LiveData.logging = false;
                startFileLoggingButton.Text = "Start Logging";
                //checkedListBoxFLLogging.Show();
                //selectFLAll.Show();
                //FLApplyLogSettings.Show();
                //LoggingSelectionsLabel.Show();
            }
            else
            {
                Directory.CreateDirectory(LogSettings.LogFileSaveLocationFolder);
                LiveData.logging = true;
                startFileLoggingButton.Text = "Stop Logging";
                //checkedListBoxFLLogging.Hide();
                //selectFLAll.Hide();
                //FLApplyLogSettings.Hide();
                //LoggingSelectionsLabel.Hide();
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {
            toLogSettingsButton.Visible = false;
            LiveData.LogSettingsOpen = true;
            FormLogSettings s1 = new FormLogSettings();
            s1.Show();

            //Start_Log.Visible = false;
            /*
            this.Hide();
            */
        }
        private void exitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toTireSettingsButton_Click(object sender, EventArgs e)
        {
            toTireSettingsButton.Visible = false;
            LiveData.TireSettingsOpen = true;
            FormTireSettings s = new FormTireSettings();
            s.Show();
            //this.Hide();

        }
        private void FirstAllDataLoggerPage_Closing(object sender, FormClosingEventArgs e)
        {
            //RegistryTools.SaveAllSettings(Application.ProductName, this);
            if (LiveData.process != null && processGet == true)
            {
                timer1.Enabled = false;
                //aTimer.Enabled = false;
                //update.Abort();
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
            LiveData.process = Process.GetProcessesByName("Wreckfest_x64").FirstOrDefault();


            if (LiveData.process != null && processGet == false)
            {
                ProcessStart();
            }
            else if (LiveData.process != null && processGet == true)
            {
                getProcessButton.Text = "Getting Process";
                //update.IsBackground = false;
                //update.Abort();
                timer1.Enabled = false;
                //aTimer.Enabled = false;
                processGet = false;
                ProcessStart();

            }
            else
            {
                processGet = false;
                getProcessButton.Text = "Get Process";
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LiveData.GetData();
            //getData();

            //ButtonVisibilities();
            if (checkBox1.Checked == true)
            {
                TextBoxUpdates();
            }
            //No chart update for Form4Wheels and G-Force charts if race timer isn't ticking
            FormLiveData formlivedata = (FormLiveData)Application.OpenForms["FormLiveData"];
            Form4Wheels form4wheels = (Form4Wheels)Application.OpenForms["Form4Wheels"];
            FormGForce formgforce = (FormGForce)Application.OpenForms["FormGForce"];
            FormTireTemperatures formtiretemps = (FormTireTemperatures)Application.OpenForms["FormTireTemperatures"];
            var timerlivedata = formlivedata.timer1;
            var timer4wheels1 = form4wheels.timer1;
            var timer4wheels2 = form4wheels.timer2;
            var timergforce1 = formgforce.timer1;
            var timergforce2 = formgforce.timer2;
            var timertiretemps1 = formtiretemps.timer1;
            if (LiveData.elapsedTime == 0)
            {
                timer4wheels1.Enabled = false;
                timer4wheels2.Enabled = false;
                timergforce1.Enabled = false;
                timergforce2.Enabled = false;
                timertiretemps1.Enabled = false;
            }
            else
            {
                timer4wheels1.Enabled = true;
                timer4wheels2.Enabled = true;
                timergforce1.Enabled = true;
                timergforce2.Enabled = true;
                timertiretemps1.Enabled = true;
            }

            sTickTime = "Tick time " + LiveData.elapsedTime + " ms";
            TickTime.Text = sTickTime;
            timerlivedata.Interval = LiveData.tickInterval;
        }

        private void buttonUpdates_Tick(object sender, EventArgs e)
        {
            UpdateFormData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void toGForceButton_Click(object sender, EventArgs e)
        {
            toGForceButton.Visible = false;
            LiveData.GForceOpen = true;
            FormGForce s1 = new FormGForce();
            s1.Show();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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