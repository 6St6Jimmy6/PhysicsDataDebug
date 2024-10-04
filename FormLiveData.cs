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
        private static System.Timers.Timer aTimer;

        public static bool SettingsOpen { get; set; } = false;

        private static DateTime previousTime;

        private string sTickTime = "Tick time: Nothing";

        private double dTickTime = 16;

        public static int GScale = 25;

        /*CODE FOR DRAWING G-Forces*
        Thread th;
        Graphics g;
        Graphics fG;
        Bitmap btm;

        bool drawing = true;
        ***************************/

        /*CODE FOR DRAWING G-Forces*
        public void Draw()
        {
            float angleInDegreesFL = 0.0f;
            float angleInDegreesRR = 0.0f;
            PointF orgFL = new PointF(75, 75);
            PointF orgRR = new PointF(75, 75);
            float radFL = 75;
            float radRR = 75;
            Pen pen = new Pen(Brushes.Azure, 3.0f);//Draw white
            RectangleF areaFL = new RectangleF(15, 15, 150, 150);
            RectangleF areaRR = new RectangleF(195, 195, 150, 150);
            RectangleF circleFL = new RectangleF(0, 0, 10, 10);//Small Line
            RectangleF circleRR = new RectangleF(0, 0, 10, 10);//Small Line

            PointF locFL = PointF.Empty;
            PointF locRR = PointF.Empty;
            PointF img = new PointF(0, 0);// Move picture more from draw point. Basically nothing because can already do that through translate.

            fG.Clear(Color.Black);

            while(drawing)
            {
                g.Clear(Color.Black);

                g.DrawEllipse(pen, areaFL);
                g.DrawEllipse(pen, areaRR);

                locFL = LinePoint(radFL, angleInDegreesFL, orgFL);
                locRR = LinePoint(radRR, angleInDegreesRR, orgRR);

                circleFL.X = locFL.X - (circleFL.Width / 2) + areaFL.X;
                circleFL.Y = locFL.Y - (circleFL.Width / 2) + areaFL.Y;
                circleRR.X = locRR.X - (circleRR.Width / 2) + areaRR.X;
                circleRR.Y = locRR.Y - (circleRR.Width / 2) + areaRR.Y;

                g.DrawEllipse(pen, circleFL);
                g.DrawEllipse(pen, circleRR);

                fG.DrawImage(btm, img);

                if (angleInDegreesFL < 360)
                {
                    angleInDegreesFL += 0.5f;
                }
                else
                {
                    angleInDegreesFL = 0;
                }
                if (angleInDegreesRR < 360)
                {
                    angleInDegreesRR += 1.0f;
                }
                else
                {
                    angleInDegreesRR = 0;
                }
                Thread.Sleep(50);
            }
        }

        public PointF LinePoint(float radius, float angleInDegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;

            return new PointF(x, y);
        }

        ***************************/

        //private Thread update;

        public static bool logging = false;

        private bool processGet = false;
        #endregion

        Process process;
        Memory.Win64.MemoryHelper64 Helper { get; set; }
        public FormLiveData()
        {
            InitializeComponent();
            logInterval_textBox.Text = LiveData.tickInterval.ToString();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel2.Paint += new PaintEventHandler(panel2_Paint);

        }
        #region Methods
        private void getData()
        {
            if (process == null) return;

            Helper = new Memory.Win64.MemoryHelper64(process);
            #region Base Addresses
            //Base Addres for Tire data
            LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential = Helper.GetBaseAddress(LiveData.baseAddrTiresSuspensionLiftsDifferentialLocation + LiveData.baseAddrUpdt - LiveData.baseAddrDodt);
            //Base Address for Speed and Lifts
            LiveData.baseAddrUpdtEngineSpeed = Helper.GetBaseAddress(LiveData.baseAddrEngineSpeed + LiveData.baseAddrUpdt - LiveData.baseAddrDodt);
            //Base Address for Race Timer
            LiveData.baseAddrUpdtRacetimer = Helper.GetBaseAddress(LiveData.baseAddrRacetime + LiveData.baseAddrUpdt - LiveData.baseAddrDodt);
            //Base Address for Location and Heading
            LiveData.baseAddrUpdtLocationHeading = Helper.GetBaseAddress(LiveData.baseAddrLocationHeading + LiveData.baseAddrUpdt - LiveData.baseAddrDodt);
            #endregion

            #region Target Addresses
            //Race time pointer reader
            LiveData.raceTimerTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtRacetimer, LiveData.raceTimerOffsets);
            //Speed, Lifts, Engine Torque and DIfferential pointer reader
            LiveData.speedTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtEngineSpeed, LiveData.speedOffsets);
            LiveData.frontLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.frontLiftOffsets);
            LiveData.rearLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.rearLiftOffsets);
            LiveData.engineRPMTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtEngineSpeed, LiveData.engineRPMOffests);
            LiveData.engineRPMAxleTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtEngineSpeed, LiveData.engineRPMAxleOffests);
            LiveData.engineTorqueTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtEngineSpeed, LiveData.engineTorqueOffsets);
            LiveData.differentialOpenTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.differentialOpenOffsets);
            LiveData.differentialVelocityRadTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.differentialVelocityRadOffsets);
            LiveData.differentialTorqueTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.differentialTorqueOffsets);

            //Location and header pointer reader
            /*
            LiveData.TXTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.TXOffsets);
            LiveData.TYTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.TYOffsets);
            LiveData.TZTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.TZOffsets);
            */
            LiveData.R11TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R11Offsets);
            LiveData.R12TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R12Offsets);
            LiveData.R13TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R13Offsets);
            /*
            LiveData.R21TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R21Offsets);
            LiveData.R22TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R22Offsets);
            LiveData.R23TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R23ffsets);
            LiveData.R31TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R31Offsets);
            LiveData.R32TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R32Offsets);
            LiveData.R33TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.R33Offsets);
            LiveData.Q1TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.Q1Offsets);
            LiveData.Q2TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.Q2Offsets);
            LiveData.Q3TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.Q3Offsets);
            LiveData.Q4TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.Q4Offsets);
            */
            LiveData.XAccelerationTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.XAccelerationOffsets);
            LiveData.YAccelerationTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.YAccelerationOffsets);
            LiveData.ZAccelerationTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtLocationHeading, LiveData.ZAccelerationOffsets);

            //Tire Data pointer readers
            //Front Left
            LiveData.FL_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.flsOffsets);
            LiveData.FL_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.fliOffsets);
            LiveData.FL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_AngularVelocityOffsets);
            LiveData.FL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_DeflectionOffsets);
            LiveData.FL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_LoadedRadiusOffsets);
            LiveData.FL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_EffectiveRadiusOffsets);
            LiveData.FL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_CurrentContactBrakeTorqueOffsets);
            LiveData.FL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_CurrentContactBrakeTorqueMaxOffsets);
            LiveData.FL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_VerticalLoadOffsets);
            LiveData.FL_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_XOffsets);
            LiveData.FL_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_YOffsets);
            LiveData.FL_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_ZOffsets);
            LiveData.FL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_LateralLoadOffsets);
            LiveData.FL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_LongitudinalLoadOffsets);
            LiveData.FL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_SlipAngleRadOffsets);
            LiveData.FL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_SlipRatioOffsets);
            LiveData.FL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_ContactLengthOffsets);
            LiveData.FL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TravelSpeedOffsets);
            LiveData.FL_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_LateralSlipSpeedOffsets);//
            LiveData.FL_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_LongitudinalSlipSpeedOffsets);//
            LiveData.FL_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_CamberAngleRadOffsets);//
            LiveData.FL_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireSteerAngleRadOffsets);//

            LiveData.FL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireMassOffsets);//
            LiveData.FL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireRadiusOffsets);//
            LiveData.FL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireWidthOffsets);//
            LiveData.FL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireSpringRateOffsets);//
            LiveData.FL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireDamperRateOffsets);//
            LiveData.FL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_TireMaxDeflectionOffsets);//
            LiveData.FL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_ThermalAirTransferOffsets);//
            LiveData.FL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_ThermalInnerTransferOffsets);//
            LiveData.FL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_MomentOfInertiaOffsets);//

            LiveData.FL_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_SuspensionLengthOffsets);
            LiveData.FL_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FL_SuspensionVelocityOffsets);
            /*

             */

            //Front Right
            LiveData.FR_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.frsOffsets);
            LiveData.FR_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.friOffsets);
            LiveData.FR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_AngularVelocityOffsets);
            LiveData.FR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_DeflectionOffsets);
            LiveData.FR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_LoadedRadiusOffsets);
            LiveData.FR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_EffectiveRadiusOffsets);
            LiveData.FR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_CurrentContactBrakeTorqueOffsets);
            LiveData.FR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_CurrentContactBrakeTorqueMaxOffsets);
            LiveData.FR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_VerticalLoadOffsets);
            LiveData.FR_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_XOffsets);
            LiveData.FR_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_YOffsets);
            LiveData.FR_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_ZOffsets);
            LiveData.FR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_LateralLoadOffsets);
            LiveData.FR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_LongitudinalLoadOffsets);
            LiveData.FR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_SlipAngleRadOffsets);
            LiveData.FR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_SlipRatioOffsets);
            LiveData.FR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_ContactLengthOffsets);
            LiveData.FR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TravelSpeedOffsets);
            LiveData.FR_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_LateralSlipSpeedOffsets);//
            LiveData.FR_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_LongitudinalSlipSpeedOffsets);//
            LiveData.FR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_MomentOfInertiaOffsets);//
            LiveData.FR_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_CamberAngleRadOffsets);//
            LiveData.FR_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireSteerAngleRadOffsets);//
            LiveData.FR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireMassOffsets);//
            LiveData.FR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireRadiusOffsets);//
            LiveData.FR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireWidthOffsets);//
            LiveData.FR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireSpringRateOffsets);//
            LiveData.FR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireDamperRateOffsets);//
            LiveData.FR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_TireMaxDeflectionOffsets);//
            LiveData.FR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_ThermalAirTransferOffsets);//
            LiveData.FR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_ThermalInnerTransferOffsets);//

            LiveData.FR_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_SuspensionLengthOffsets);
            LiveData.FR_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.FR_SuspensionVelocityOffsets);
            /*

             */

            //Rear Left
            LiveData.RL_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.rlsOffsets);
            LiveData.RL_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.rliOffsets);
            LiveData.RL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_AngularVelocityOffsets);
            LiveData.RL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_DeflectionOffsets);
            LiveData.RL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_LoadedRadiusOffsets);
            LiveData.RL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_EffectiveRadiusOffsets);
            LiveData.RL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_CurrentContactBrakeTorqueOffsets);
            LiveData.RL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_CurrentContactBrakeTorqueMaxOffsets);
            LiveData.RL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_VerticalLoadOffsets);
            LiveData.RL_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_XOffsets);
            LiveData.RL_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_YOffsets);
            LiveData.RL_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_ZOffsets);
            LiveData.RL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_LateralLoadOffsets);
            LiveData.RL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_LongitudinalLoadOffsets);
            LiveData.RL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_SlipAngleRadOffsets);
            LiveData.RL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_SlipRatioOffsets);
            LiveData.RL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_ContactLengthOffsets);
            LiveData.RL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TravelSpeedOffsets);
            LiveData.RL_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_LateralSlipSpeedOffsets);//
            LiveData.RL_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_LongitudinalSlipSpeedOffsets);//
            LiveData.RL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_MomentOfInertiaOffsets);//
            LiveData.RL_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_CamberAngleRadOffsets);//
            LiveData.RL_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireSteerAngleRadOffsets);//
            LiveData.RL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireMassOffsets);//
            LiveData.RL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireRadiusOffsets);//
            LiveData.RL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireWidthOffsets);//
            LiveData.RL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireSpringRateOffsets);//
            LiveData.RL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireDamperRateOffsets);//
            LiveData.RL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_TireMaxDeflectionOffsets);//
            LiveData.RL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_ThermalAirTransferOffsets);//
            LiveData.RL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_ThermalInnerTransferOffsets);//

            LiveData.RL_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_SuspensionLengthOffsets);
            LiveData.RL_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RL_SuspensionVelocityOffsets);
            /*

             */

            //Rear Right
            LiveData.RR_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.rrsOffsets);
            LiveData.RR_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.rriOffsets);
            LiveData.RR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_AngularVelocityOffsets);
            LiveData.RR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_DeflectionOffsets);
            LiveData.RR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_LoadedRadiusOffsets);
            LiveData.RR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_EffectiveRadiusOffsets);
            LiveData.RR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_CurrentContactBrakeTorqueOffsets);
            LiveData.RR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_CurrentContactBrakeTorqueMaxOffsets);
            LiveData.RR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_VerticalLoadOffsets);
            LiveData.RR_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_XOffsets);
            LiveData.RR_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_YOffsets);
            LiveData.RR_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_ZOffsets);
            LiveData.RR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_LateralLoadOffsets);
            LiveData.RR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_LongitudinalLoadOffsets);
            LiveData.RR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_SlipAngleRadOffsets);
            LiveData.RR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_SlipRatioOffsets);
            LiveData.RR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_ContactLengthOffsets);
            LiveData.RR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TravelSpeedOffsets);
            LiveData.RR_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_LateralSlipSpeedOffsets);//
            LiveData.RR_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_LongitudinalSlipSpeedOffsets);//
            LiveData.RR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_MomentOfInertiaOffsets);//
            LiveData.RR_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_CamberAngleRadOffsets);//
            LiveData.RR_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireSteerAngleRadOffsets);//
            LiveData.RR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireMassOffsets);//
            LiveData.RR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireRadiusOffsets);//
            LiveData.RR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireWidthOffsets);//
            LiveData.RR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireSpringRateOffsets);//
            LiveData.RR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireDamperRateOffsets);//
            LiveData.RR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_TireMaxDeflectionOffsets);//
            LiveData.RR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_ThermalAirTransferOffsets);//
            LiveData.RR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_ThermalInnerTransferOffsets);//

            LiveData.RR_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_SuspensionLengthOffsets);
            LiveData.RR_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, LiveData.baseAddrUpdtTiresSuspensionLiftsDifferential, LiveData.RR_SuspensionVelocityOffsets);
            /*

             */
            #endregion

            //Read race time
            #region Race Time
            LiveData.RaceTime = Helper.ReadMemory<int>(LiveData.raceTimerTargetAddr);
            #endregion

            //Read Speed, Lifts, Engine Torque and Differential stuff
            #region Speed, Lifts, Engine Torque and Differential
            LiveData.speed = Helper.ReadMemory<float>(LiveData.speedTargetAddr);
            LiveData.frontLift = Helper.ReadMemory<float>(LiveData.frontLiftTargetAddr);
            LiveData.rearLift = Helper.ReadMemory<float>(LiveData.rearLiftTargetAddr);
            LiveData.engineRPM = Helper.ReadMemory<float>(LiveData.engineRPMTargetAddr);
            LiveData.engineRPMAxle = Helper.ReadMemory<float>(LiveData.engineRPMAxleTargetAddr);
            LiveData.engineTorque = Helper.ReadMemory<float>(LiveData.engineTorqueTargetAddr);
            LiveData.enginePower = LiveData.engineTorque * LiveData.engineRPM / 9549;
            LiveData.differentialLocked = Helper.ReadMemory<byte>(LiveData.differentialOpenTargetAddr);
            LiveData.differentialVelocityRad = Helper.ReadMemory<float>(LiveData.differentialVelocityRadTargetAddr);
            LiveData.differentialTorque = Helper.ReadMemory<float>(LiveData.differentialTorqueTargetAddr);
            #endregion

            //Read Location and heading
            #region Location, heading, acceleration and g-force
            // Most of these not needed for now
            /*
            LiveData.TX = Helper.ReadMemory<float>(LiveData.TXTargetAddr);
            LiveData.TY = Helper.ReadMemory<float>(LiveData.TYTargetAddr);
            LiveData.TZ = Helper.ReadMemory<float>(LiveData.TZTargetAddr);*/
            LiveData.R11 = Helper.ReadMemory<float>(LiveData.R11TargetAddr);
            LiveData.R12 = Helper.ReadMemory<float>(LiveData.R12TargetAddr);
            LiveData.R13 = Helper.ReadMemory<float>(LiveData.R13TargetAddr);
            /*
            LiveData.R21 = Helper.ReadMemory<float>(LiveData.A2TargetAddr);
            LiveData.R22 = Helper.ReadMemory<float>(LiveData.B2TargetAddr);
            LiveData.R23 = Helper.ReadMemory<float>(LiveData.C2TargetAddr);
            LiveData.R31 = Helper.ReadMemory<float>(LiveData.A3TargetAddr);
            LiveData.R32 = Helper.ReadMemory<float>(LiveData.B3TargetAddr);
            LiveData.R33 = Helper.ReadMemory<float>(LiveData.C3TargetAddr);
            LiveData.Q1 = Helper.ReadMemory<float>(LiveData.Q1TargetAddr);
            LiveData.Q2 = Helper.ReadMemory<float>(LiveData.Q2TargetAddr);
            LiveData.Q3 = Helper.ReadMemory<float>(LiveData.Q3TargetAddr);
            LiveData.Q4 = Helper.ReadMemory<float>(LiveData.Q4TargetAddr);
            */
            LiveData.XAcceleration = Helper.ReadMemory<float>(LiveData.XAccelerationTargetAddr);
            LiveData.YAcceleration = Helper.ReadMemory<float>(LiveData.YAccelerationTargetAddr);
            LiveData.ZAcceleration = Helper.ReadMemory<float>(LiveData.ZAccelerationTargetAddr);

            // Getting rid of too big or low values when the pointr is changing or something odd happens, so it won't crash the math for Int32 later.
            if(LiveData.XAcceleration > 1000 || LiveData.XAcceleration < -1000)
            {
                LiveData.XAcceleration = 0;
            }
            if (LiveData.YAcceleration > 1000 || LiveData.YAcceleration < -1000)
            {
                LiveData.YAcceleration = 0;
            }
            if (LiveData.ZAcceleration > 1000 || LiveData.ZAcceleration < -1000)
            {
                LiveData.ZAcceleration = 0;
            }

            // Getting the XZ direction where in the world the car is going.

            if (LiveData.XAcceleration > 0)
            {
                if (LiveData.ZAcceleration > 0)
                {
                    //LiveData.RR_TotalFrictionAngle = (float)(270 - (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));// Opposite
                    //LiveData.XZAccelerationAngleDeg = (float)(90 - (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleDeg = (float)(180 + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleRad = (Math.PI + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration)));
                }
                else if (LiveData.ZAcceleration < 0)
                {
                    //LiveData.RR_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));// Opposite
                    //LiveData.RR_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / LiveData.RR_LateralFriction) * LiveData.radToDeg);//Same as below
                    //LiveData.XZAccelerationAngleDeg = (float)(90 - (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleDeg = (360 + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleRad = (2 * Math.PI + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration)));
                }
                else
                {
                    //LiveData.XZAccelerationAngleDeg = 270f;
                    LiveData.XZAccelerationAngleRad = 1.5 * Math.PI;
                }
            }
            else if (LiveData.XAcceleration < 0)
            {
                if (LiveData.ZAcceleration > 0)
                {
                    //LiveData.XZAccelerationAngleDeg = (float)(90 + (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));// Opposite
                    //LiveData.RR_TotalFrictionAngle = 270 + (Math.Atan(LiveData.RR_LongitudinalFriction / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg);//Same as below
                    //LiveData.XZAccelerationAngleDeg = (float)(270 + (Math.Atan(LiveData.ZAcceleration / Math.Abs(LiveData.XAcceleration)) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleDeg = (float)(180 + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleRad = (Math.PI + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration)));
                }
                else if (LiveData.ZAcceleration < 0)
                {
                    //LiveData.RR_TotalFrictionAngle = (float)(270 + (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));// Opposite
                    //LiveData.RR_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg);//Same as below
                    //LiveData.XZAccelerationAngleDeg = (float)(270 - (Math.Atan(LiveData.ZAcceleration / LiveData.XAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleDeg = (float)(0d + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration) * LiveData.fRadToDeg));
                    LiveData.XZAccelerationAngleRad = (0d + (Math.Atan(LiveData.XAcceleration / LiveData.ZAcceleration)));
                }
                else
                {
                    LiveData.XZAccelerationAngleDeg = 90f;
                    LiveData.XZAccelerationAngleRad = 0.5 * Math.PI;
                }
            }
            else
            {
                if (LiveData.ZAcceleration > 0f)
                {
                    LiveData.XZAccelerationAngleDeg = 180f;
                    LiveData.XZAccelerationAngleRad = Math.PI;
                }
                else if (LiveData.ZAcceleration < 0f)
                {
                    LiveData.XZAccelerationAngleDeg = 360f;
                    LiveData.XZAccelerationAngleRad = 2 * Math.PI;
                }
                else
                {
                    LiveData.XZAccelerationAngleDeg = 0f;
                    LiveData.XZAccelerationAngleRad = 0d;
                }
            }

            LiveData.XZAcceleration = Math.Sqrt(Math.Pow(LiveData.XAcceleration, 2) + Math.Pow(LiveData.ZAcceleration, 2));

            LiveData.XG = LiveData.XAcceleration / LiveData.g;
            LiveData.YG = LiveData.YAcceleration / LiveData.g;
            LiveData.ZG = LiveData.ZAcceleration / LiveData.g;

            // Get normalized heading, so it's easy to draw for example the g-forces in the right direction compared to the car pivot point.
            LiveData.playerRotation = new Matrix4x4(LiveData.R11, LiveData.R12, LiveData.R13, 0, LiveData.R21, LiveData.R22, LiveData.R23, 0, LiveData.R31, LiveData.R32, LiveData.R33, 0, 0, 0, 0, 1);
            Angle3D.GetAngles(LiveData.playerRotation);
            LiveData.XZG = /*Math.Sqrt(Math.Pow(LiveData.YG, 2) + Math.Pow*/(Math.Sqrt(Math.Pow(LiveData.XG, 2) + Math.Pow(LiveData.ZG, 2))/*, 2)*/); // Commented out would be XYZG length.

            if (LiveData.rotationYRad < 3 * Math.PI &&
                LiveData.rotationYRad > -3 * Math.PI &&
                LiveData.XZAccelerationAngleRad < 3 * Math.PI &&
                LiveData.XZAccelerationAngleRad > -3 * Math.PI)// These are to make sure if there's some huge or almost small value, that it won't get calculated, because those throw errors. Usually can happen when changing car or track etc.
            {
                if (LiveData.rotationYRad > LiveData.XZAccelerationAngleRad)
                {
                    if (LiveData.XZAccelerationAngleRad - LiveData.rotationYRad > 2 * Math.PI)
                    {
                        LiveData.XZGAngleRad = LiveData.XZAccelerationAngleRad - LiveData.rotationYRad - 2 * Math.PI;
                    }
                    else
                    {
                        LiveData.XZGAngleRad = 2 * Math.PI + LiveData.XZAccelerationAngleRad - LiveData.rotationYRad;
                    }
                }
                else
                {
                    if (LiveData.XZAccelerationAngleRad - LiveData.rotationYRad > 2 * Math.PI)
                    {
                        LiveData.XZGAngleRad = LiveData.XZAccelerationAngleRad - LiveData.rotationYRad - 2 * Math.PI;
                    }
                    else
                    {
                        LiveData.XZGAngleRad = LiveData.XZAccelerationAngleRad - LiveData.rotationYRad;
                    }
                }
            }
            LiveData.XZGAngleDeg = LiveData.XZGAngleRad * LiveData.dRadToDeg; // radians to degrees if needed.
            #endregion

            //Read Tire Data
            #region Tire Data
            //Front Left
            #region Front Left
            LiveData.FL_TreadTemperature = Helper.ReadMemory<float>(LiveData.FL_TreadTemperatureTargetAddr);
            LiveData.FL_InnerTemperature = Helper.ReadMemory<float>(LiveData.FL_InnerTemperatureTargetAddr);
            LiveData.FL_AngularVelocity = Helper.ReadMemory<float>(LiveData.FL_AngularVelocity_TargetAddr);
            LiveData.FL_VerticalDeflection = Helper.ReadMemory<float>(LiveData.FL_Deflection_TargetAddr);
            LiveData.FL_LoadedRadius = Helper.ReadMemory<float>(LiveData.FL_LoadedRadius_TargetAddr);
            LiveData.FL_EffectiveRadius = Helper.ReadMemory<float>(LiveData.FL_EffectiveRadius_TargetAddr);
            LiveData.FL_CurrentContactBrakeTorque = Helper.ReadMemory<float>(LiveData.FL_CurrentContactBrakeTorque_TargetAddr);
            LiveData.FL_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(LiveData.FL_CurrentContactBrakeTorqueMax_TargetAddr);
            LiveData.FL_VerticalLoad = Helper.ReadMemory<float>(LiveData.FL_VerticalLoad_TargetAddr);
            LiveData.FL_X = Helper.ReadMemory<float>(LiveData.FL_X_TargetAddr);
            LiveData.FL_Y = Helper.ReadMemory<float>(LiveData.FL_Y_TargetAddr);
            LiveData.FL_Z = Helper.ReadMemory<float>(LiveData.FL_Z_TargetAddr);
            LiveData.FL_LateralLoad = Helper.ReadMemory<float>(LiveData.FL_LateralLoad_TargetAddr);
            LiveData.FL_LongitudinalLoad = Helper.ReadMemory<float>(LiveData.FL_LongitudinalLoad_TargetAddr);
            LiveData.FL_SlipAngleRad = Helper.ReadMemory<float>(LiveData.FL_SlipAngleRad_TargetAddr);
            LiveData.FL_SlipAngleDeg = LiveData.FL_SlipAngleRad * LiveData.fRadToDeg;
            LiveData.FL_SlipRatio = Helper.ReadMemory<float>(LiveData.FL_SlipRatio_TargetAddr);
            LiveData.FL_ContactLength = Helper.ReadMemory<float>(LiveData.FL_ContactLength_TargetAddr);
            LiveData.FL_TravelSpeed = Helper.ReadMemory<float>(LiveData.FL_TravelSpeed_TargetAddr);
            //
            if (LiveData.FL_VerticalLoad == 0)
            {
                LiveData.FL_LateralFriction = 0;
                LiveData.FL_LongitudinalFriction = 0;
                LiveData.FL_LateralSlipSpeed = 0;//
                LiveData.FL_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                LiveData.FL_LateralFriction = LiveData.FL_LateralLoad / LiveData.FL_VerticalLoad;
                LiveData.FL_LongitudinalFriction = LiveData.FL_LongitudinalLoad / LiveData.FL_VerticalLoad;
                LiveData.FL_LateralSlipSpeed = Helper.ReadMemory<float>(LiveData.FL_LateralSlipSpeed_TargetAddr);
                LiveData.FL_LongitudinalSlipSpeed = Helper.ReadMemory<float>(LiveData.FL_LongitudinalSlipSpeed_TargetAddr);
            }
            LiveData.FL_TotalFriction = (float)Math.Sqrt(Math.Pow(LiveData.FL_LateralFriction, 2) + Math.Pow(LiveData.FL_LongitudinalFriction, 2));//
            if (LiveData.FL_LateralFriction > 0)
            {
                if (LiveData.FL_LongitudinalFriction > 0)
                {
                    // LiveData.FL_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.FL_LongitudinalFriction) / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    LiveData.FL_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.FL_LongitudinalFriction / LiveData.FL_LateralFriction) * LiveData.fRadToDeg));
                }
                else if (LiveData.FL_LongitudinalFriction < 0)
                {
                    //LiveData.FL_TotalFrictionAngle = 90 - (Math.Atan(Math.Abs(LiveData.FL_LongitudinalFriction) / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.FL_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.FL_LongitudinalFriction) / LiveData.FL_LateralFriction) * LiveData.radToDeg), 2);//Same as below
                    LiveData.FL_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.FL_LongitudinalFriction / LiveData.FL_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.FL_TotalFrictionAngle = 90;
                }
            }
            else if (LiveData.FL_LateralFriction < 0)
            {
                if (LiveData.FL_LongitudinalFriction > 0)
                {
                    //LiveData.FL_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.FL_LongitudinalFriction) / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.FL_TotalFrictionAngle = 270 + (Math.Atan(LiveData.FL_LongitudinalFriction / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.FL_TotalFrictionAngle = (float)(270 + (Math.Atan(LiveData.FL_LongitudinalFriction / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.fRadToDeg));
                }
                else if (LiveData.FL_LongitudinalFriction < 0)
                {
                    //LiveData.FL_TotalFrictionAngle = 270 + (Math.Atan(Math.Abs(LiveData.FL_LongitudinalFriction) / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.FL_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.FL_LongitudinalFriction) / Math.Abs(LiveData.FL_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.FL_TotalFrictionAngle = (float)(270 - (Math.Atan(LiveData.FL_LongitudinalFriction / LiveData.FL_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.FL_TotalFrictionAngle = 270;// G-Force
                }
            }
            else
            {
                if (LiveData.FL_LongitudinalFriction > 0)
                {
                    LiveData.FL_TotalFrictionAngle = 360;
                }
                else if (LiveData.FL_LongitudinalFriction < 0)
                {
                    LiveData.FL_TotalFrictionAngle = 180;
                }
                else
                {
                    LiveData.FL_TotalFrictionAngle = 0;
                }
            }

            LiveData.FL_CamberAngleRad = Helper.ReadMemory<float>(LiveData.FL_CamberAngleRad_TargetAddr);
            LiveData.FL_SteerAngleRad = Helper.ReadMemory<float>(LiveData.FL_TireSteerAngleRad_TargetAddr);
            LiveData.FL_CamberAngleDeg = LiveData.FL_CamberAngleRad * LiveData.fRadToDeg;
            LiveData.FL_SteerAngleDeg = LiveData.FL_SteerAngleRad * LiveData.fRadToDeg;

            LiveData.FL_MomentOfInertia = Helper.ReadMemory<float>(LiveData.FL_MomentOfInertia_TargetAddr);
            LiveData.FL_TireMass = Helper.ReadMemory<float>(LiveData.FL_TireMass_TargetAddr);
            LiveData.FL_TireRadius = Helper.ReadMemory<float>(LiveData.FL_TireRadius_TargetAddr);
            LiveData.FL_TireWidth = Helper.ReadMemory<float>(LiveData.FL_TireWidth_TargetAddr);
            LiveData.FL_TireSpringRate = Helper.ReadMemory<float>(LiveData.FL_TireSpringRate_TargetAddr);
            LiveData.FL_TireDamperRate = Helper.ReadMemory<float>(LiveData.FL_TireDamperRate_TargetAddr);
            LiveData.FL_TireMaxDeflection = Helper.ReadMemory<float>(LiveData.FL_TireMaxDeflection_TargetAddr);
            LiveData.FL_ThermalAirTransfer = Helper.ReadMemory<float>(LiveData.FL_ThermalAirTransfer_TargetAddr);
            LiveData.FL_ThermalInnerTransfer = Helper.ReadMemory<float>(LiveData.FL_ThermalInnerTransfer_TargetAddr);

            LiveData.FL_SuspensionLength = Helper.ReadMemory<float>(LiveData.FL_SuspensionLenght_TargetAddr);
            LiveData.FL_SuspensionVelocity = Helper.ReadMemory<float>(LiveData.FL_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion

            //Font Right
            #region Front Right
            LiveData.FR_TreadTemperature = Helper.ReadMemory<float>(LiveData.FR_TreadTemperatureTargetAddr);
            LiveData.FR_InnerTemperature = Helper.ReadMemory<float>(LiveData.FR_InnerTemperatureTargetAddr);
            LiveData.FR_AngularVelocity = Helper.ReadMemory<float>(LiveData.FR_AngularVelocity_TargetAddr);
            LiveData.FR_VerticalDeflection = Helper.ReadMemory<float>(LiveData.FR_Deflection_TargetAddr);
            LiveData.FR_LoadedRadius = Helper.ReadMemory<float>(LiveData.FR_LoadedRadius_TargetAddr);
            LiveData.FR_EffectiveRadius = Helper.ReadMemory<float>(LiveData.FR_EffectiveRadius_TargetAddr);
            LiveData.FR_CurrentContactBrakeTorque = Helper.ReadMemory<float>(LiveData.FR_CurrentContactBrakeTorque_TargetAddr);
            LiveData.FR_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(LiveData.FR_CurrentContactBrakeTorqueMax_TargetAddr);
            LiveData.FR_VerticalLoad = Helper.ReadMemory<float>(LiveData.FR_VerticalLoad_TargetAddr);
            LiveData.FR_X = Helper.ReadMemory<float>(LiveData.FR_X_TargetAddr);
            LiveData.FR_Y = Helper.ReadMemory<float>(LiveData.FR_Y_TargetAddr);
            LiveData.FR_Z = Helper.ReadMemory<float>(LiveData.FR_Z_TargetAddr);
            LiveData.FR_LateralLoad = Helper.ReadMemory<float>(LiveData.FR_LateralLoad_TargetAddr);
            LiveData.FR_LongitudinalLoad = Helper.ReadMemory<float>(LiveData.FR_LongitudinalLoad_TargetAddr);
            LiveData.FR_SlipAngleRad = Helper.ReadMemory<float>(LiveData.FR_SlipAngleRad_TargetAddr);
            LiveData.FR_SlipAngleDeg = LiveData.FR_SlipAngleRad * LiveData.fRadToDeg;
            LiveData.FR_SlipRatio = Helper.ReadMemory<float>(LiveData.FR_SlipRatio_TargetAddr);
            LiveData.FR_ContactLength = Helper.ReadMemory<float>(LiveData.FR_ContactLength_TargetAddr);
            LiveData.FR_TravelSpeed = Helper.ReadMemory<float>(LiveData.FR_TravelSpeed_TargetAddr);
            if (LiveData.FR_VerticalLoad == 0)
            {
                LiveData.FR_LateralFriction = 0;
                LiveData.FR_LongitudinalFriction = 0;
                LiveData.FR_LateralSlipSpeed = 0;//
                LiveData.FR_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                LiveData.FR_LateralFriction = LiveData.FR_LateralLoad / LiveData.FR_VerticalLoad;
                LiveData.FR_LongitudinalFriction = LiveData.FR_LongitudinalLoad / LiveData.FR_VerticalLoad;
                LiveData.FR_LateralSlipSpeed = Helper.ReadMemory<float>(LiveData.FR_LateralSlipSpeed_TargetAddr);
                LiveData.FR_LongitudinalSlipSpeed = Helper.ReadMemory<float>(LiveData.FR_LongitudinalSlipSpeed_TargetAddr);
            }
            LiveData.FR_TotalFriction = (float)Math.Sqrt(Math.Pow(LiveData.FR_LateralFriction, 2) + Math.Pow(LiveData.FR_LongitudinalFriction, 2));//
            if (LiveData.FR_LateralFriction > 0)
            {
                if (LiveData.FR_LongitudinalFriction > 0)
                {
                    // LiveData.FR_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.FR_LongitudinalFriction) / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    LiveData.FR_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.FR_LongitudinalFriction / LiveData.FR_LateralFriction) * LiveData.fRadToDeg));
                }
                else if (LiveData.FR_LongitudinalFriction < 0)
                {
                    //LiveData.FR_TotalFrictionAngle = 90 - (Math.Atan(Math.Abs(LiveData.FR_LongitudinalFriction) / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.FR_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.FR_LongitudinalFriction) / LiveData.FR_LateralFriction) * LiveData.radToDeg), 2);//Same as below
                    LiveData.FR_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.FR_LongitudinalFriction / LiveData.FR_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.FR_TotalFrictionAngle = 90;
                }
            }
            else if (LiveData.FR_LateralFriction < 0)
            {
                if (LiveData.FR_LongitudinalFriction > 0)
                {
                    //LiveData.FR_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.FR_LongitudinalFriction) / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.FR_TotalFrictionAngle = 270 + (Math.Atan(LiveData.FR_LongitudinalFriction / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.FR_TotalFrictionAngle = (float)(270 + (Math.Atan(LiveData.FR_LongitudinalFriction / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.fRadToDeg));
                }
                else if (LiveData.FR_LongitudinalFriction < 0)
                {
                    //LiveData.FR_TotalFrictionAngle = 270 + (Math.Atan(Math.Abs(LiveData.FR_LongitudinalFriction) / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.FR_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.FR_LongitudinalFriction) / Math.Abs(LiveData.FR_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.FR_TotalFrictionAngle = (float)(270 - (Math.Atan(LiveData.FR_LongitudinalFriction / LiveData.FR_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.FR_TotalFrictionAngle = 270;// G-Force
                }
            }
            else
            {
                if (LiveData.FR_LongitudinalFriction > 0)
                {
                    LiveData.FR_TotalFrictionAngle = 360;
                }
                else if (LiveData.FR_LongitudinalFriction < 0)
                {
                    LiveData.FR_TotalFrictionAngle = 180;
                }
                else
                {
                    LiveData.FR_TotalFrictionAngle = 0;
                }
            }
            LiveData.FR_MomentOfInertia = Helper.ReadMemory<float>(LiveData.FR_MomentOfInertia_TargetAddr);
            LiveData.FR_CamberAngleRad = Helper.ReadMemory<float>(LiveData.FR_CamberAngleRad_TargetAddr);
            LiveData.FR_SteerAngleRad = Helper.ReadMemory<float>(LiveData.FR_TireSteerAngleRad_TargetAddr);
            LiveData.FR_CamberAngleDeg = LiveData.FR_CamberAngleRad * LiveData.fRadToDeg;
            LiveData.FR_SteerAngleDeg = LiveData.FR_SteerAngleRad * LiveData.fRadToDeg;
            LiveData.FR_TireMass = Helper.ReadMemory<float>(LiveData.FR_TireMass_TargetAddr);
            LiveData.FR_TireRadius = Helper.ReadMemory<float>(LiveData.FR_TireRadius_TargetAddr);
            LiveData.FR_TireWidth = Helper.ReadMemory<float>(LiveData.FR_TireWidth_TargetAddr);
            LiveData.FR_TireSpringRate = Helper.ReadMemory<float>(LiveData.FR_TireSpringRate_TargetAddr);
            LiveData.FR_TireDamperRate = Helper.ReadMemory<float>(LiveData.FR_TireDamperRate_TargetAddr);
            LiveData.FR_TireMaxDeflection = Helper.ReadMemory<float>(LiveData.FR_TireMaxDeflection_TargetAddr);
            LiveData.FR_ThermalAirTransfer = Helper.ReadMemory<float>(LiveData.FR_ThermalAirTransfer_TargetAddr);
            LiveData.FR_ThermalInnerTransfer = Helper.ReadMemory<float>(LiveData.FR_ThermalInnerTransfer_TargetAddr);

            LiveData.FR_SuspensionLength = Helper.ReadMemory<float>(LiveData.FR_SuspensionLenght_TargetAddr);
            LiveData.FR_SuspensionVelocity = Helper.ReadMemory<float>(LiveData.FR_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion

            //Rear Left
            #region Rear Left
            LiveData.RL_TreadTemperature = Helper.ReadMemory<float>(LiveData.RL_TreadTemperatureTargetAddr);
            LiveData.RL_InnerTemperature = Helper.ReadMemory<float>(LiveData.RL_InnerTemperatureTargetAddr);
            LiveData.RL_AngularVelocity = Helper.ReadMemory<float>(LiveData.RL_AngularVelocity_TargetAddr);
            LiveData.RL_VerticalDeflection = Helper.ReadMemory<float>(LiveData.RL_Deflection_TargetAddr);
            LiveData.RL_LoadedRadius = Helper.ReadMemory<float>(LiveData.RL_LoadedRadius_TargetAddr);
            LiveData.RL_EffectiveRadius = Helper.ReadMemory<float>(LiveData.RL_EffectiveRadius_TargetAddr);
            LiveData.RL_CurrentContactBrakeTorque = Helper.ReadMemory<float>(LiveData.RL_CurrentContactBrakeTorque_TargetAddr);
            LiveData.RL_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(LiveData.RL_CurrentContactBrakeTorqueMax_TargetAddr);
            LiveData.RL_VerticalLoad = Helper.ReadMemory<float>(LiveData.RL_VerticalLoad_TargetAddr);
            LiveData.RL_X = Helper.ReadMemory<float>(LiveData.RL_X_TargetAddr);
            LiveData.RL_Y = Helper.ReadMemory<float>(LiveData.RL_Y_TargetAddr);
            LiveData.RL_Z = Helper.ReadMemory<float>(LiveData.RL_Z_TargetAddr);
            LiveData.RL_LateralLoad = Helper.ReadMemory<float>(LiveData.RL_LateralLoad_TargetAddr);
            LiveData.RL_LongitudinalLoad = Helper.ReadMemory<float>(LiveData.RL_LongitudinalLoad_TargetAddr);
            LiveData.RL_SlipAngleRad = Helper.ReadMemory<float>(LiveData.RL_SlipAngleRad_TargetAddr);
            LiveData.RL_SlipAngleDeg = LiveData.RL_SlipAngleRad * LiveData.fRadToDeg;
            LiveData.RL_SlipRatio = Helper.ReadMemory<float>(LiveData.RL_SlipRatio_TargetAddr);
            LiveData.RL_ContactLength = Helper.ReadMemory<float>(LiveData.RL_ContactLength_TargetAddr);
            LiveData.RL_TravelSpeed = Helper.ReadMemory<float>(LiveData.RL_TravelSpeed_TargetAddr);
            if (LiveData.RL_VerticalLoad == 0)
            {
                LiveData.RL_LateralFriction = 0;
                LiveData.RL_LongitudinalFriction = 0;
                LiveData.RL_LateralSlipSpeed = 0;//
                LiveData.RL_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                LiveData.RL_LateralFriction = LiveData.RL_LateralLoad / LiveData.RL_VerticalLoad;
                LiveData.RL_LongitudinalFriction = LiveData.RL_LongitudinalLoad / LiveData.RL_VerticalLoad;
                LiveData.RL_LateralSlipSpeed = Helper.ReadMemory<float>(LiveData.RL_LateralSlipSpeed_TargetAddr);
                LiveData.RL_LongitudinalSlipSpeed = Helper.ReadMemory<float>(LiveData.RL_LongitudinalSlipSpeed_TargetAddr);
            }
            LiveData.RL_TotalFriction = (float)Math.Sqrt(Math.Pow(LiveData.RL_LateralFriction, 2) + Math.Pow(LiveData.RL_LongitudinalFriction, 2));//
            if (LiveData.RL_LateralFriction > 0)
            {
                if (LiveData.RL_LongitudinalFriction > 0)
                {
                    // LiveData.RL_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.RL_LongitudinalFriction) / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    LiveData.RL_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.RL_LongitudinalFriction / LiveData.RL_LateralFriction) * LiveData.fRadToDeg));
                }
                else if (LiveData.RL_LongitudinalFriction < 0)
                {
                    //LiveData.RL_TotalFrictionAngle = 90 - (Math.Atan(Math.Abs(LiveData.RL_LongitudinalFriction) / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.RL_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.RL_LongitudinalFriction) / LiveData.RL_LateralFriction) * LiveData.radToDeg), 2);//Same as below
                    LiveData.RL_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.RL_LongitudinalFriction / LiveData.RL_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.RL_TotalFrictionAngle = 90;
                }
            }
            else if (LiveData.RL_LateralFriction < 0)
            {
                if (LiveData.RL_LongitudinalFriction > 0)
                {
                    //LiveData.RL_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.RL_LongitudinalFriction) / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.RL_TotalFrictionAngle = 270 + (Math.Atan(LiveData.RL_LongitudinalFriction / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.RL_TotalFrictionAngle = (float)(270 + (Math.Atan(LiveData.RL_LongitudinalFriction / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.fRadToDeg));
                }
                else if (LiveData.RL_LongitudinalFriction < 0)
                {
                    //LiveData.RL_TotalFrictionAngle = 270 + (Math.Atan(Math.Abs(LiveData.RL_LongitudinalFriction) / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.RL_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.RL_LongitudinalFriction) / Math.Abs(LiveData.RL_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.RL_TotalFrictionAngle = (float)(270 - (Math.Atan(LiveData.RL_LongitudinalFriction / LiveData.RL_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.RL_TotalFrictionAngle = 270;// G-Force
                }
            }
            else
            {
                if (LiveData.RL_LongitudinalFriction > 0)
                {
                    LiveData.RL_TotalFrictionAngle = 360;
                }
                else if (LiveData.RL_LongitudinalFriction < 0)
                {
                    LiveData.RL_TotalFrictionAngle = 180;
                }
                else
                {
                    LiveData.RL_TotalFrictionAngle = 0;
                }
            }
            LiveData.RL_MomentOfInertia = Helper.ReadMemory<float>(LiveData.RL_MomentOfInertia_TargetAddr);
            LiveData.RL_CamberAngleRad = Helper.ReadMemory<float>(LiveData.RL_CamberAngleRad_TargetAddr);
            LiveData.RL_SteerAngleRad = Helper.ReadMemory<float>(LiveData.RL_TireSteerAngleRad_TargetAddr);
            LiveData.RL_CamberAngleDeg = LiveData.RL_CamberAngleRad * LiveData.fRadToDeg;
            LiveData.RL_SteerAngleDeg = LiveData.RL_SteerAngleRad * LiveData.fRadToDeg;
            LiveData.RL_TireMass = Helper.ReadMemory<float>(LiveData.RL_TireMass_TargetAddr);
            LiveData.RL_TireRadius = Helper.ReadMemory<float>(LiveData.RL_TireRadius_TargetAddr);
            LiveData.RL_TireWidth = Helper.ReadMemory<float>(LiveData.RL_TireWidth_TargetAddr);
            LiveData.RL_TireSpringRate = Helper.ReadMemory<float>(LiveData.RL_TireSpringRate_TargetAddr);
            LiveData.RL_TireDamperRate = Helper.ReadMemory<float>(LiveData.RL_TireDamperRate_TargetAddr);
            LiveData.RL_TireMaxDeflection = Helper.ReadMemory<float>(LiveData.RL_TireMaxDeflection_TargetAddr);
            LiveData.RL_ThermalAirTransfer = Helper.ReadMemory<float>(LiveData.RL_ThermalAirTransfer_TargetAddr);
            LiveData.RL_ThermalInnerTransfer = Helper.ReadMemory<float>(LiveData.RL_ThermalInnerTransfer_TargetAddr);

            LiveData.RL_SuspensionLength = Helper.ReadMemory<float>(LiveData.RL_SuspensionLenght_TargetAddr);
            LiveData.RL_SuspensionVelocity = Helper.ReadMemory<float>(LiveData.RL_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion

            //Rear Right
            #region Rear Right
            LiveData.RR_TreadTemperature = Helper.ReadMemory<float>(LiveData.RR_TreadTemperatureTargetAddr);
            LiveData.RR_InnerTemperature = Helper.ReadMemory<float>(LiveData.RR_InnerTemperatureTargetAddr);
            LiveData.RR_AngularVelocity = Helper.ReadMemory<float>(LiveData.RR_AngularVelocity_TargetAddr);
            LiveData.RR_VerticalDeflection = Helper.ReadMemory<float>(LiveData.RR_Deflection_TargetAddr);
            LiveData.RR_LoadedRadius = Helper.ReadMemory<float>(LiveData.RR_LoadedRadius_TargetAddr);
            LiveData.RR_EffectiveRadius = Helper.ReadMemory<float>(LiveData.RR_EffectiveRadius_TargetAddr);
            LiveData.RR_CurrentContactBrakeTorque = Helper.ReadMemory<float>(LiveData.RR_CurrentContactBrakeTorque_TargetAddr);
            LiveData.RR_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(LiveData.RR_CurrentContactBrakeTorqueMax_TargetAddr);
            LiveData.RR_VerticalLoad = Helper.ReadMemory<float>(LiveData.RR_VerticalLoad_TargetAddr);
            LiveData.RR_X = Helper.ReadMemory<float>(LiveData.RR_X_TargetAddr);
            LiveData.RR_Y = Helper.ReadMemory<float>(LiveData.RR_Y_TargetAddr);
            LiveData.RR_Z = Helper.ReadMemory<float>(LiveData.RR_Z_TargetAddr);
            LiveData.RR_LateralLoad = Helper.ReadMemory<float>(LiveData.RR_LateralLoad_TargetAddr);
            LiveData.RR_LongitudinalLoad = Helper.ReadMemory<float>(LiveData.RR_LongitudinalLoad_TargetAddr);
            LiveData.RR_SlipAngleRad = Helper.ReadMemory<float>(LiveData.RR_SlipAngleRad_TargetAddr);
            LiveData.RR_SlipAngleDeg = LiveData.RR_SlipAngleRad * LiveData.fRadToDeg;
            LiveData.RR_SlipRatio = Helper.ReadMemory<float>(LiveData.RR_SlipRatio_TargetAddr);
            LiveData.RR_ContactLength = Helper.ReadMemory<float>(LiveData.RR_ContactLength_TargetAddr);
            LiveData.RR_TravelSpeed = Helper.ReadMemory<float>(LiveData.RR_TravelSpeed_TargetAddr);
            LiveData.RR_LateralFriction = LiveData.RR_LateralLoad / LiveData.RR_VerticalLoad;
            if (LiveData.RR_VerticalLoad == 0)
            {
                LiveData.RR_LongitudinalFriction = 0;
                LiveData.RR_LateralFriction = 0;
                LiveData.RR_LateralSlipSpeed = 0;//
                LiveData.RR_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                LiveData.RR_LateralFriction = LiveData.RR_LateralLoad / LiveData.RR_VerticalLoad;
                LiveData.RR_LongitudinalFriction = LiveData.RR_LongitudinalLoad / LiveData.RR_VerticalLoad;
                LiveData.RR_LateralSlipSpeed = Helper.ReadMemory<float>(LiveData.RR_LateralSlipSpeed_TargetAddr);
                LiveData.RR_LongitudinalSlipSpeed = Helper.ReadMemory<float>(LiveData.RR_LongitudinalSlipSpeed_TargetAddr);
            }
            LiveData.RR_TotalFriction = (float)Math.Sqrt(Math.Pow(LiveData.RR_LateralFriction, 2) + Math.Pow(LiveData.RR_LongitudinalFriction, 2));//
            if (LiveData.RR_LateralFriction > 0)
            {
                if (LiveData.RR_LongitudinalFriction > 0)
                {
                    // LiveData.RR_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    LiveData.RR_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.RR_LongitudinalFriction / LiveData.RR_LateralFriction) * LiveData.fRadToDeg));
                }
                else if (LiveData.RR_LongitudinalFriction < 0)
                {
                    //LiveData.RR_TotalFrictionAngle = 90 - (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.RR_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / LiveData.RR_LateralFriction) * LiveData.radToDeg), 2);//Same as below
                    LiveData.RR_TotalFrictionAngle = (float)(90 - (Math.Atan(LiveData.RR_LongitudinalFriction / LiveData.RR_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.RR_TotalFrictionAngle = 90;
                }
            }
            else if (LiveData.RR_LateralFriction < 0)
            {
                if (LiveData.RR_LongitudinalFriction > 0)
                {
                    //LiveData.RR_TotalFrictionAngle = 90 + (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.RR_TotalFrictionAngle = 270 + (Math.Atan(LiveData.RR_LongitudinalFriction / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.RR_TotalFrictionAngle = (float)(270 + (Math.Atan(LiveData.RR_LongitudinalFriction / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.fRadToDeg));
                }
                else if (LiveData.RR_LongitudinalFriction < 0)
                {
                    //LiveData.RR_TotalFrictionAngle = 270 + (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg), 2);// Opposite
                    //LiveData.RR_TotalFrictionAngle = 270 - (Math.Atan(Math.Abs(LiveData.RR_LongitudinalFriction) / Math.Abs(LiveData.RR_LateralFriction)) * LiveData.radToDeg), 2);//Same as below
                    LiveData.RR_TotalFrictionAngle = (float)(270 - (Math.Atan(LiveData.RR_LongitudinalFriction / LiveData.RR_LateralFriction) * LiveData.fRadToDeg));
                }
                else
                {
                    LiveData.RR_TotalFrictionAngle = 270;
                }
            }
            else
            {
                if (LiveData.RR_LongitudinalFriction > 0)
                {
                    LiveData.RR_TotalFrictionAngle = 360;
                }
                else if (LiveData.RR_LongitudinalFriction < 0)
                {
                    LiveData.RR_TotalFrictionAngle = 180;
                }
                else
                {
                    LiveData.RR_TotalFrictionAngle = 0;
                }
            }
            LiveData.RR_MomentOfInertia = Helper.ReadMemory<float>(LiveData.RR_MomentOfInertia_TargetAddr);
            LiveData.RR_CamberAngleRad = Helper.ReadMemory<float>(LiveData.RR_CamberAngleRad_TargetAddr);
            LiveData.RR_SteerAngleRad = Helper.ReadMemory<float>(LiveData.RR_TireSteerAngleRad_TargetAddr);
            LiveData.RR_CamberAngleDeg = LiveData.RR_CamberAngleRad * LiveData.fRadToDeg;
            LiveData.RR_SteerAngleDeg = LiveData.RR_SteerAngleRad * LiveData.fRadToDeg;
            LiveData.RR_TireMass = Helper.ReadMemory<float>(LiveData.RR_TireMass_TargetAddr);
            LiveData.RR_TireRadius = Helper.ReadMemory<float>(LiveData.RR_TireRadius_TargetAddr);
            LiveData.RR_TireWidth = Helper.ReadMemory<float>(LiveData.RR_TireWidth_TargetAddr);
            LiveData.RR_TireSpringRate = Helper.ReadMemory<float>(LiveData.RR_TireSpringRate_TargetAddr);
            LiveData.RR_TireDamperRate = Helper.ReadMemory<float>(LiveData.RR_TireDamperRate_TargetAddr);
            LiveData.RR_TireMaxDeflection = Helper.ReadMemory<float>(LiveData.RR_TireMaxDeflection_TargetAddr);
            LiveData.RR_ThermalAirTransfer = Helper.ReadMemory<float>(LiveData.RR_ThermalAirTransfer_TargetAddr);
            LiveData.RR_ThermalInnerTransfer = Helper.ReadMemory<float>(LiveData.RR_ThermalInnerTransfer_TargetAddr);

            LiveData.RR_SuspensionLength = Helper.ReadMemory<float>(LiveData.RR_SuspensionLenght_TargetAddr);
            LiveData.RR_SuspensionVelocity = Helper.ReadMemory<float>(LiveData.RR_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion
            #endregion

            CheckWhatToLogInFile();
            LogToFile();
            UpdateFormData();
        }

        private void CheckWhatToLogInFile()
        {
            if (LogSettings.TireTravelSpeedLogEnabled == true)
            {
                LogSettings.Header0 = LogSettings.sTireTravelSpeed + FormLogSettings.Delimiter;
                LogSettings.flParameter0 = LiveData.FL_TravelSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter0 = LiveData.FR_TravelSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter0 = LiveData.RL_TravelSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter0 = LiveData.RR_TravelSpeed.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header0 = "";
                LogSettings.flParameter0 = "";
                LogSettings.frParameter0 = "";
                LogSettings.rlParameter0 = "";
                LogSettings.rrParameter0 = "";
            }
            if (LogSettings.AngularVelocityLogEnabled == true)
            {
                LogSettings.Header1 = LogSettings.sAngularVelocity + FormLogSettings.Delimiter;
                LogSettings.flParameter1 = LiveData.FL_AngularVelocity.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter1 = LiveData.FR_AngularVelocity.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter1 = LiveData.RL_AngularVelocity.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter1 = LiveData.RR_AngularVelocity.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header1 = "";
                LogSettings.flParameter1 = "";
                LogSettings.frParameter1 = "";
                LogSettings.rlParameter1 = "";
                LogSettings.rrParameter1 = "";
            }
            if (LogSettings.VerticalLoadLogEnabled == true)
            {
                LogSettings.Header2 = LogSettings.sVerticalLoad + FormLogSettings.Delimiter;
                LogSettings.flParameter2 = LiveData.FL_VerticalLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter2 = LiveData.FR_VerticalLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter2 = LiveData.RL_VerticalLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter2 = LiveData.RR_VerticalLoad.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header2 = "";
                LogSettings.flParameter2 = "";
                LogSettings.frParameter2 = "";
                LogSettings.rlParameter2 = "";
                LogSettings.rrParameter2 = "";
            }
            if (LogSettings.VerticalDeflectionLogEnabled == true)
            {
                LogSettings.Header3 = LogSettings.sVerticalDeflection + FormLogSettings.Delimiter;
                LogSettings.flParameter3 = LiveData.FL_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter3 = LiveData.FR_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter3 = LiveData.RL_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter3 = LiveData.RR_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header3 = "";
                LogSettings.flParameter3 = "";
                LogSettings.frParameter3 = "";
                LogSettings.rlParameter3 = "";
                LogSettings.rrParameter3 = "";
            }
            if (LogSettings.LoadedRadiusLogEnabled == true)
            {
                LogSettings.Header4 = LogSettings.sLoadedRadius + FormLogSettings.Delimiter;
                LogSettings.flParameter4 = LiveData.FL_LoadedRadius.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter4 = LiveData.FR_LoadedRadius.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter4 = LiveData.RL_LoadedRadius.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter4 = LiveData.RR_LoadedRadius.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header4 = "";
                LogSettings.flParameter4 = "";
                LogSettings.frParameter4 = "";
                LogSettings.rlParameter4 = "";
                LogSettings.rrParameter4 = "";
            }
            if (LogSettings.EffectiveRadiusLogEnabled == true)
            {
                LogSettings.Header5 = LogSettings.sEffectiveRadius + FormLogSettings.Delimiter;
                LogSettings.flParameter5 = LiveData.FL_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter5 = LiveData.FR_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter5 = LiveData.RL_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter5 = LiveData.RR_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header5 = "";
                LogSettings.flParameter5 = "";
                LogSettings.frParameter5 = "";
                LogSettings.rlParameter5 = "";
                LogSettings.rrParameter5 = "";
            }
            if (LogSettings.ContactLengthLogEnabled == true)
            {
                LogSettings.Header6 = LogSettings.sContactLength + FormLogSettings.Delimiter;
                LogSettings.flParameter6 = LiveData.FL_ContactLength.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter6 = LiveData.FR_ContactLength.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter6 = LiveData.RL_ContactLength.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter6 = LiveData.RR_ContactLength.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header6 = "";
                LogSettings.flParameter6 = "";
                LogSettings.frParameter6 = "";
                LogSettings.rlParameter6 = "";
                LogSettings.rrParameter6 = "";
            }
            if (LogSettings.BrakeTorqueLogEnabled == true)
            {
                LogSettings.Header7 = LogSettings.sBrakeTorque + FormLogSettings.Delimiter;
                LogSettings.flParameter7 = LiveData.FL_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter7 = LiveData.FR_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter7 = LiveData.RL_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter7 = LiveData.RR_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;

                LogSettings.Header7_1 = LogSettings.sMaxBrakeTorque + FormLogSettings.Delimiter;
                LogSettings.flParameter7_1 = LiveData.FL_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter7_1 = LiveData.FR_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter7_1 = LiveData.RL_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter7_1 = LiveData.RR_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header7 = "";
                LogSettings.flParameter7 = "";
                LogSettings.frParameter7 = "";
                LogSettings.rlParameter7 = "";
                LogSettings.rrParameter7 = "";

                LogSettings.Header7_1 = "";
                LogSettings.flParameter7_1 = "";
                LogSettings.frParameter7_1 = "";
                LogSettings.rlParameter7_1 = "";
                LogSettings.rrParameter7_1 = "";
            }
            if (LogSettings.SteerAngleLogEnabled == true)
            {
                LogSettings.Header8 = LogSettings.sSteerAngle + FormLogSettings.Delimiter;
                LogSettings.flParameter8 = LiveData.FL_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter8 = LiveData.FR_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter8 = LiveData.RL_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter8 = LiveData.RR_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header8 = "";
                LogSettings.flParameter8 = "";
                LogSettings.frParameter8 = "";
                LogSettings.rlParameter8 = "";
                LogSettings.rrParameter8 = "";
            }
            if (LogSettings.CamberAngleLogEnabled == true)
            {
                LogSettings.Header9 = LogSettings.sCamberAngle + FormLogSettings.Delimiter;
                LogSettings.flParameter9 = LiveData.FL_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter9 = LiveData.FR_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter9 = LiveData.RL_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter9 = LiveData.RR_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header9 = "";
                LogSettings.flParameter9 = "";
                LogSettings.frParameter9 = "";
                LogSettings.rlParameter9 = "";
                LogSettings.rrParameter9 = "";
            }
            if (LogSettings.LateralLoadLogEnabled == true)
            {
                LogSettings.Header10 = LogSettings.sLateralLoad + FormLogSettings.Delimiter;
                LogSettings.flParameter10 = LiveData.FL_LateralLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter10 = LiveData.FR_LateralLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter10 = LiveData.RL_LateralLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter10 = LiveData.RR_LateralLoad.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header10 = "";
                LogSettings.flParameter10 = "";
                LogSettings.frParameter10 = "";
                LogSettings.rlParameter10 = "";
                LogSettings.rrParameter10 = "";
            }
            if (LogSettings.SlipAngleLogEnabled == true)
            {
                LogSettings.Header11 = LogSettings.sSlipAngle + FormLogSettings.Delimiter;
                LogSettings.flParameter11 = LiveData.FL_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter11 = LiveData.FR_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter11 = LiveData.RL_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter11 = LiveData.RR_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header11 = "";
                LogSettings.flParameter11 = "";
                LogSettings.frParameter11 = "";
                LogSettings.rlParameter11 = "";
                LogSettings.rrParameter11 = "";
            }
            if (LogSettings.LateralFrictionLogEnabled == true)
            {
                LogSettings.Header12 = LogSettings.sLateralFriction + FormLogSettings.Delimiter;
                LogSettings.flParameter12 = LiveData.FL_LateralFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter12 = LiveData.FR_LateralFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter12 = LiveData.RL_LateralFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter12 = LiveData.RR_LateralFriction.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header12 = "";
                LogSettings.flParameter12 = "";
                LogSettings.frParameter12 = "";
                LogSettings.rlParameter12 = "";
                LogSettings.rrParameter12 = "";
            }
            if (LogSettings.LateralSlipSpeedLogEnabled == true)
            {
                LogSettings.Header13 = LogSettings.sLateralSlipSpeed + FormLogSettings.Delimiter;
                LogSettings.flParameter13 = LiveData.FL_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter13 = LiveData.FR_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter13 = LiveData.RL_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter13 = LiveData.RR_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header13 = "";
                LogSettings.flParameter13 = "";
                LogSettings.frParameter13 = "";
                LogSettings.rlParameter13 = "";
                LogSettings.rrParameter13 = "";
            }
            if (LogSettings.LongitudinalLoadLogEnabled == true)
            {
                LogSettings.Header14 = LogSettings.sLongitudinalLoad + FormLogSettings.Delimiter;
                LogSettings.flParameter14 = LiveData.FL_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter14 = LiveData.FR_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter14 = LiveData.RL_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter14 = LiveData.RR_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header14 = "";
                LogSettings.flParameter14 = "";
                LogSettings.frParameter14 = "";
                LogSettings.rlParameter14 = "";
                LogSettings.rrParameter14 = "";
            }
            if (LogSettings.SlipRatioLogEnabled == true)
            {
                LogSettings.Header15 = LogSettings.sSlipRatio + FormLogSettings.Delimiter;
                LogSettings.flParameter15 = LiveData.FL_SlipRatio.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter15 = LiveData.FR_SlipRatio.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter15 = LiveData.RL_SlipRatio.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter15 = LiveData.RR_SlipRatio.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header15 = "";
                LogSettings.flParameter15 = "";
                LogSettings.frParameter15 = "";
                LogSettings.rlParameter15 = "";
                LogSettings.rrParameter15 = "";
            }
            if (LogSettings.LongitudinalFrictionLogEnabled == true)
            {
                LogSettings.Header16 = LogSettings.sLongitudinalFriction + FormLogSettings.Delimiter;
                LogSettings.flParameter16 = LiveData.FL_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter16 = LiveData.FR_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter16 = LiveData.RL_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter16 = LiveData.RR_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header16 = "";
                LogSettings.flParameter16 = "";
                LogSettings.frParameter16 = "";
                LogSettings.rlParameter16 = "";
                LogSettings.rrParameter16 = "";
            }
            if (LogSettings.LongitudinalSlipSpeedLogEnabled == true)
            {
                LogSettings.Header17 = LogSettings.sLongitudinalSlipSpeed + FormLogSettings.Delimiter;
                LogSettings.flParameter17 = LiveData.FL_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter17 = LiveData.FR_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter17 = LiveData.RL_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter17 = LiveData.RR_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header17 = "";
                LogSettings.flParameter17 = "";
                LogSettings.frParameter17 = "";
                LogSettings.rlParameter17 = "";
                LogSettings.rrParameter17 = "";
            }
            if (LogSettings.TreadTemperatureLogEnabled == true)
            {
                LogSettings.Header18 = LogSettings.sTreadTemperature + FormLogSettings.Delimiter;
                LogSettings.flParameter18 = LiveData.FL_TreadTemperature.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter18 = LiveData.FR_TreadTemperature.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter18 = LiveData.RL_TreadTemperature.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter18 = LiveData.RR_TreadTemperature.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header18 = "";
                LogSettings.flParameter18 = "";
                LogSettings.frParameter18 = "";
                LogSettings.rlParameter18 = "";
                LogSettings.rrParameter18 = "";
            }
            if (LogSettings.InnerTemperatureLogEnabled == true)
            {
                LogSettings.Header19 = LogSettings.sInnerTemperature + FormLogSettings.Delimiter;
                LogSettings.flParameter19 = LiveData.FL_InnerTemperature.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter19 = LiveData.FR_InnerTemperature.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter19 = LiveData.RL_InnerTemperature.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter19 = LiveData.RR_InnerTemperature.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header19 = "";
                LogSettings.flParameter19 = "";
                LogSettings.frParameter19 = "";
                LogSettings.rlParameter19 = "";
                LogSettings.rrParameter19 = "";
            }
            if (LogSettings.RaceTimeLogEnabled == true)
            {
                LogSettings.Header20 = LogSettings.sRaceTime + FormLogSettings.Delimiter;
                LogSettings.flParameter20 = LiveData.RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter20 = LiveData.RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter20 = LiveData.RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter20 = LiveData.RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header20 = "";
                LogSettings.flParameter20 = "";
                LogSettings.frParameter20 = "";
                LogSettings.rlParameter20 = "";
                LogSettings.rrParameter20 = "";
            }
            if (LogSettings.TotalFrictionLogEnabled == true)
            {
                LogSettings.Header21 = LogSettings.sTotalFriction + FormLogSettings.Delimiter;
                LogSettings.flParameter21 = LiveData.FL_TotalFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter21 = LiveData.FR_TotalFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter21 = LiveData.RL_TotalFriction.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter21 = LiveData.RR_TotalFriction.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header21 = "";
                LogSettings.flParameter21 = "";
                LogSettings.frParameter21 = "";
                LogSettings.rlParameter21 = "";
                LogSettings.rrParameter21 = "";
            }
            if (LogSettings.TotalFrictionAngleLogEnabled == true)
            {
                LogSettings.Header22 = LogSettings.sTotalFrictionAngle + FormLogSettings.Delimiter;
                LogSettings.flParameter22 = LiveData.FL_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter22 = LiveData.FR_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter22 = LiveData.RL_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter22 = LiveData.RR_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header22 = "";
                LogSettings.flParameter22 = "";
                LogSettings.frParameter22 = "";
                LogSettings.rlParameter22 = "";
                LogSettings.rrParameter22 = "";
            }
            if (LogSettings.SuspensionLengthLogEnabled == true)
            {
                LogSettings.Header23 = LogSettings.sSuspensionLength + FormLogSettings.Delimiter;
                LogSettings.flParameter23 = LiveData.FL_SuspensionLength.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter23 = LiveData.FR_SuspensionLength.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter23 = LiveData.RL_SuspensionLength.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter23 = LiveData.RR_SuspensionLength.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header23 = "";
                LogSettings.flParameter23 = "";
                LogSettings.frParameter23 = "";
                LogSettings.rlParameter23 = "";
                LogSettings.rrParameter23 = "";
            }
            if (LogSettings.SuspensionVelocityLogEnabled == true)
            {
                LogSettings.Header24 = LogSettings.sSuspensionVelocity + FormLogSettings.Delimiter;
                LogSettings.flParameter24 = LiveData.FL_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
                LogSettings.frParameter24 = LiveData.FR_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
                LogSettings.rlParameter24 = LiveData.RL_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
                LogSettings.rrParameter24 = LiveData.RR_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                LogSettings.Header24 = "";
                LogSettings.flParameter24 = "";
                LogSettings.frParameter24 = "";
                LogSettings.rlParameter24 = "";
                LogSettings.rrParameter24 = "";
            }
        }
        private void LogToFile()
        {

            if (logging == true)
            {
                // SA, SR, Speed and Vertical Load filters for logging

                if (LogSettings.FiltersOn == true)
                {
                    if ((LiveData.FL_SlipRatio <= (0 + FormLogSettings.Z1) && LiveData.FL_SlipRatio >= (0 - FormLogSettings.Z1))
                        && (LiveData.FL_SlipAngleDeg <= (0 + FormLogSettings.Z2) && LiveData.FL_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                        && (LiveData.FL_TravelSpeed >= (0 + FormLogSettings.Z3) || LiveData.FL_TravelSpeed <= (0 - FormLogSettings.Z3))
                        && (LiveData.FL_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && LiveData.FL_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                    {
                        FLLogFileWriter();
                    }
                    if ((LiveData.FR_SlipRatio <= (0 + FormLogSettings.Z1) && LiveData.FR_SlipRatio >= (0 - FormLogSettings.Z1))
                        && (LiveData.FR_SlipAngleDeg <= (0 + FormLogSettings.Z2) && LiveData.FR_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                        && (LiveData.FR_TravelSpeed >= (0 + FormLogSettings.Z3) || LiveData.FR_TravelSpeed <= (0 - FormLogSettings.Z3))
                        && (LiveData.FR_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && LiveData.FR_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                    {
                        FRLogFileWriter();
                    }
                    if ((LiveData.RL_SlipRatio <= (0 + FormLogSettings.Z1) && LiveData.RL_SlipRatio >= (0 - FormLogSettings.Z1))
                        && (LiveData.RL_SlipAngleDeg <= (0 + FormLogSettings.Z2) && LiveData.RL_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                        && (LiveData.RL_TravelSpeed >= (0 + FormLogSettings.Z3) || LiveData.RL_TravelSpeed <= (0 - FormLogSettings.Z3))
                        && (LiveData.RL_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && LiveData.RL_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                    {
                        RLLogFileWriter();
                    }
                    if ((LiveData.RR_SlipRatio <= (0 + FormLogSettings.Z1) && LiveData.RR_SlipRatio >= (0 - FormLogSettings.Z1))
                        && (LiveData.RR_SlipAngleDeg <= (0 + FormLogSettings.Z2) && LiveData.RR_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                        && (LiveData.RR_TravelSpeed >= (0 + FormLogSettings.Z3) || LiveData.RR_TravelSpeed <= (0 - FormLogSettings.Z3))
                        && (LiveData.RR_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && LiveData.RR_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                    {
                        RRLogFileWriter();
                    }
                }
                else
                {
                    FLLogFileWriter();
                    FRLogFileWriter();
                    RLLogFileWriter();
                    RRLogFileWriter();
                }
            }
        }

        private string WriteHeaderLine()
        {
            return LogSettings.Header20 + LogSettings.Header0 + LogSettings.Header1 + LogSettings.Header2 + LogSettings.Header3 + LogSettings.Header4 + LogSettings.Header5 + LogSettings.Header6 + LogSettings.Header7 + LogSettings.Header7_1 + LogSettings.Header8 + LogSettings.Header9 + LogSettings.Header10 + LogSettings.Header11 + LogSettings.Header12 + LogSettings.Header13 + LogSettings.Header14 + LogSettings.Header15 + LogSettings.Header16 + LogSettings.Header17 + LogSettings.Header18 + LogSettings.Header19 + LogSettings.Header21 + LogSettings.Header22 + LogSettings.Header23 + LogSettings.Header24;
        }
        private void WriteFLHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogSettings.LogFileSaveLocationFolder + "FrontLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteFRHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogSettings.LogFileSaveLocationFolder + "FrontRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteRLHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogSettings.LogFileSaveLocationFolder + "RearLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteRRHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogSettings.LogFileSaveLocationFolder + "RearRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteFLParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogSettings.LogFileSaveLocationFolder + "FrontLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(LogSettings.flParameter20 + LogSettings.flParameter0 + LogSettings.flParameter1 + LogSettings.flParameter2 + LogSettings.flParameter3 + LogSettings.flParameter4 + LogSettings.flParameter5 + LogSettings.flParameter6 + LogSettings.flParameter7 + LogSettings.flParameter7_1 + LogSettings.flParameter8 + LogSettings.flParameter9 + LogSettings.flParameter10 + LogSettings.flParameter11 + LogSettings.flParameter12 + LogSettings.flParameter13 + LogSettings.flParameter14 + LogSettings.flParameter15 + LogSettings.flParameter16 + LogSettings.flParameter17 + LogSettings.flParameter18 + LogSettings.flParameter19 + LogSettings.flParameter21 + LogSettings.flParameter22 + LogSettings.flParameter23 + LogSettings.flParameter24);
            }
        }
        private void WriteFRParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogSettings.LogFileSaveLocationFolder + "FrontRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(LogSettings.frParameter20 + LogSettings.frParameter0 + LogSettings.frParameter1 + LogSettings.frParameter2 + LogSettings.frParameter3 + LogSettings.frParameter4 + LogSettings.frParameter5 + LogSettings.frParameter6 + LogSettings.frParameter7 + LogSettings.frParameter7_1 + LogSettings.frParameter8 + LogSettings.frParameter9 + LogSettings.frParameter10 + LogSettings.frParameter11 + LogSettings.frParameter12 + LogSettings.frParameter13 + LogSettings.frParameter14 + LogSettings.frParameter15 + LogSettings.frParameter16 + LogSettings.frParameter17 + LogSettings.frParameter18 + LogSettings.frParameter19 + LogSettings.frParameter21 + LogSettings.frParameter22 + LogSettings.frParameter23 + LogSettings.frParameter24);
            }
        }
        private void WriteRLParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogSettings.LogFileSaveLocationFolder + "RearLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(LogSettings.rlParameter20 + LogSettings.rlParameter0 + LogSettings.rlParameter1 + LogSettings.rlParameter2 + LogSettings.rlParameter3 + LogSettings.rlParameter4 + LogSettings.rlParameter5 + LogSettings.rlParameter6 + LogSettings.rlParameter7 + LogSettings.rlParameter7_1 + LogSettings.rlParameter8 + LogSettings.rlParameter9 + LogSettings.rlParameter10 + LogSettings.rlParameter11 + LogSettings.rlParameter12 + LogSettings.rlParameter13 + LogSettings.rlParameter14 + LogSettings.rlParameter15 + LogSettings.rlParameter16 + LogSettings.rlParameter17 + LogSettings.rlParameter18 + LogSettings.rlParameter19 + LogSettings.rlParameter21 + LogSettings.rlParameter22 + LogSettings.rlParameter23 + LogSettings.rlParameter24);
            }
        }
        private void WriteRRParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogSettings.LogFileSaveLocationFolder + "RearRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(LogSettings.rrParameter20 + LogSettings.rrParameter0 + LogSettings.rrParameter1 + LogSettings.rrParameter2 + LogSettings.rrParameter3 + LogSettings.rrParameter4 + LogSettings.rrParameter5 + LogSettings.rrParameter6 + LogSettings.rrParameter7 + LogSettings.rrParameter7_1 + LogSettings.rrParameter8 + LogSettings.rrParameter9 + LogSettings.rrParameter10 + LogSettings.rrParameter11 + LogSettings.rrParameter12 + LogSettings.rrParameter13 + LogSettings.rrParameter14 + LogSettings.rrParameter15 + LogSettings.rrParameter16 + LogSettings.rrParameter17 + LogSettings.rrParameter18 + LogSettings.rrParameter19 + LogSettings.rrParameter21 + LogSettings.rrParameter22 + LogSettings.rrParameter23 + LogSettings.rrParameter24);
            }
        }
        private void FLLogFileWriter()
        {
            if (!File.Exists(LogSettings.LogFileSaveLocationFolder + "FrontLeftWreckfestDebugLog.txt"))
            {
                WriteFLHeadersLine();
            }
            else
            {
                WriteFLParametersLine();
            }
        }
        private void FRLogFileWriter()
        {
            if (!File.Exists(LogSettings.LogFileSaveLocationFolder + "FrontRightWreckfestDebugLog.txt"))
            {
                WriteFRHeadersLine();
            }
            else
            {
                WriteFRParametersLine();
            }
        }
        private void RLLogFileWriter()
        {
            if (!File.Exists(LogSettings.LogFileSaveLocationFolder + "RearLeftWreckfestDebugLog.txt"))
            {
                WriteRLHeadersLine();
            }
            else
            {
                WriteRLParametersLine();
            }
        }
        private void RRLogFileWriter()
        {
            if (!File.Exists(LogSettings.LogFileSaveLocationFolder + "RearRightWreckfestDebugLog.txt"))
            {
                WriteRRHeadersLine();
            }
            else
            {
                WriteRRParametersLine();
            }
        }
        private void ButtonVisibilities()
        {
            if (logging == true)
            {
                toLogSettingsButton.Visible = false;
            }
            if (LiveData.SettingsOpen == false && logging == false)
            {
                toLogSettingsButton.Visible = true;
            }
            if (LiveData.SettingsOpen == true)
            {
                toLogSettingsButton.Visible = false;
                startFileLoggingButton.Visible = false;
            }
            if (LiveData.SettingsOpen == false)
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
            CurrentAcceleration.Text = Math.Round(LiveData.XZAcceleration, 2).ToString();
            CurrentGForce.Text = Math.Round(LiveData.XZG, 2).ToString();
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

            TickTime.Text = sTickTime;

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
        private void pictureBoxMove()
        {
            int x = 197;
            int y = 197;
            int x2 = 192;
            int y2 = 208;
            int x3 = 60;
            int y3 = 208;

            /*
            if(LiveData.XZGAngleDeg <= 90d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }
            else if(LiveData.XZGAngleDeg <= 180d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }
            else if (LiveData.XZGAngleDeg <= 270d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }
            else if (LiveData.XZGAngleDeg <= 360d)
            {
                x = Convert.ToInt32((Math.Cos(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
                y = Convert.ToInt32((Math.Sin(LiveData.XZGAngleRad) / LiveData.XZYG) * 10);
            }*/
            if ((LiveData.XZG >= -0.001 && LiveData.XZG <= 0.001) || LiveData.XZG == double.NaN)
            {
                x = 197;
                y = 197;
                x2 = 192;
                y2 = 208;
            }
            else
            {
                x = 197 + Convert.ToInt32(Math.Round((Math.Sin(LiveData.XZGAngleRad) * LiveData.XZG) * GScale, 0));
                y = 197 - Convert.ToInt32(Math.Round((Math.Cos(LiveData.XZGAngleRad) * LiveData.XZG) * GScale, 0));
                x2 = 192 + Convert.ToInt32(Math.Round((Math.Sin(LiveData.XZGAngleRad) * LiveData.XZG) * GScale, 0));
                y2 = 208 - Convert.ToInt32(Math.Round((Math.Cos(LiveData.XZGAngleRad) * LiveData.XZG) * GScale, 0));
            }
            y3 = 193 - Convert.ToInt32(Math.Round(LiveData.YG * GScale, 0));
            
            //pictureBox1.Location = new Point(x, y);
            CurrentGForceXZMoving.Location = new Point(x2, y2);
            CurrentGForceXZMoving.Text = Math.Round(LiveData.XZG, 2).ToString() + " G";
            //textBox7.Text = "x: " + x.ToString() +"\r\n" + "y: " + y.ToString();
            CurrentGForceYMoving.Location = new Point(x3, y3);
            CurrentGForceYMoving.Text = Math.Round(Math.Abs(LiveData.YG), 2).ToString() + " G";
        }
        private void ProcessStart()
        {

            //gForceUpdate = new Thread(new ThreadStart(getGForce));
            //gForceUpdate.IsBackground = true;
            //gForceUpdate.Start();

            processGet = true;
            //update = new Thread(new ThreadStart(getData))
            //{
            //    IsBackground = true
            //};

            getProcessButton.Text = "Refresh Process";
            //update.Start();
            timer1.Enabled = true;

            aTimer = new System.Timers.Timer(LiveData.tickInterval);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            dTickTime = (e.SignalTime - previousTime).TotalMilliseconds;
            sTickTime = "Tick time " + dTickTime + " ms";
            previousTime = e.SignalTime;
            aTimer.Interval = LiveData.tickInterval;
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
            if (logging == true)
            {
                logging = false;
                startFileLoggingButton.Text = "Start Logging";
                //checkedListBoxFLLogging.Show();
                //selectFLAll.Show();
                //FLApplyLogSettings.Show();
                //LoggingSelectionsLabel.Show();
            }
            else
            {
                Directory.CreateDirectory(LogSettings.LogFileSaveLocationFolder);
                logging = true;
                startFileLoggingButton.Text = "Stop Logging";
                //checkedListBoxFLLogging.Hide();
                //selectFLAll.Hide();
                //FLApplyLogSettings.Hide();
                //LoggingSelectionsLabel.Hide();
            }
        }
        private void toSettingsButton_Click(object sender, EventArgs e)
        {

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

            FormTireSettings s = new FormTireSettings();
            s.Show();
            //this.Hide();

        }
        private void FirstAllDataLoggerPage_Closing(object sender, FormClosingEventArgs e)
        {
            //RegistryTools.SaveAllSettings(Application.ProductName, this);
            if (process != null && processGet == true)
            {
                timer1.Enabled = false;
                aTimer.Enabled = false;
                //update.Abort();
            }
        }
        private void OpenTemperaturesChart_Click(object sender, EventArgs e)
        {
            FormTireTemperatures s = new FormTireTemperatures();
            s.Show();
        }
        private void toSuspensionSettingsButton_Click(object sender, EventArgs e)
        {
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
            //toSettingsButton.Hide();
            //toTireSettingsButton.Hide();

            /*CODE FOR DRAWING G-Forces*
            btm = new Bitmap(360, 360);
            g = Graphics.FromImage(btm);
            fG = CreateGraphics();
            fG.TranslateTransform(795, 475);//Move the picture

            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();
            ***************************/
            /*
            // Load saved settings
            RegistryTools.LoadAllSettings(Application.ProductName, this);
            */
        }
        private void getProcessButton_Click(object sender, EventArgs e)
        {
            process = Process.GetProcessesByName("Wreckfest_x64").FirstOrDefault();


            if (process != null && processGet == false)
            {
                ProcessStart();
            }
            else if (process != null && processGet == true)
            {
                getProcessButton.Text = "Getting Process";
                //update.IsBackground = false;
                //update.Abort();
                timer1.Enabled = false;
                aTimer.Enabled = false;
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
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            getData();
            TextBoxUpdates();
            pictureBoxMove();
            panel1.Refresh();
            panel2.Refresh();
            timer1.Interval = LiveData.tickInterval;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen myPenWhite = new Pen(Color.White, 1);
            Pen myPenLightBlue = new Pen(Color.LightBlue, 1);
            Pen myPenBlue = new Pen(Color.Blue, 1);
            Pen myPenYellow = new Pen(Color.Yellow, 1);
            Pen myPenOrange = new Pen(Color.Orange, 1);
            Pen myPenOrangeRed = new Pen(Color.OrangeRed, 1);
            Pen myPenRed = new Pen(Color.Red, 1);
            Pen myPenDarkRed = new Pen(Color.DarkRed, 1);


            // 0 G circle
            float widthG0 = 2;
            float heightG0 = 2;
            float xG0 = (panel1.Size.Width / 2 - widthG0 / 2);
            float zG0 = (panel1.Size.Height / 2 - heightG0 / 2);
            RectangleF rectfG0 = new RectangleF(xG0, zG0, widthG0, heightG0);
            e.Graphics.DrawEllipse(myPenWhite, rectfG0);
            // 1 G circle
            float widthG1 = GScale * 2;
            float heightG1 = GScale * 2;
            float xG1 = (panel1.Size.Width / 2 - widthG1 / 2);
            float zG1 = (panel1.Size.Height / 2 - heightG1 / 2);
            RectangleF rectfG1 = new RectangleF(xG1, zG1, widthG1, heightG1);
            e.Graphics.DrawEllipse(myPenLightBlue, rectfG1);
            // 2 G circle
            float widthG2 = widthG1 * 2;
            float heightG2 = heightG1 * 2;
            float xG2 = (panel1.Size.Width / 2 - widthG2 / 2);
            float zG2 = (panel1.Size.Height / 2 - heightG2 / 2);
            RectangleF rectfG2 = new RectangleF(xG2, zG2, widthG2, heightG2);
            e.Graphics.DrawEllipse(myPenBlue, rectfG2);
            // 3 G circle
            float widthG3 = widthG1 * 3;
            float heightG3 = heightG1 * 3;
            float xG3 = (panel1.Size.Width / 2 - widthG3 / 2);
            float zG3 = (panel1.Size.Height / 2 - heightG3 / 2);
            RectangleF rectfG3 = new RectangleF(xG3, zG3, widthG3, heightG3);
            e.Graphics.DrawEllipse(myPenYellow, rectfG3);
            // 4 G circle
            float widthG4 = widthG1 * 4;
            float heightG4 = heightG1 * 4;
            float xG4 = (panel1.Size.Width / 2 - widthG4 / 2);
            float zG4 = (panel1.Size.Height / 2 - heightG4 / 2);
            RectangleF rectfG4 = new RectangleF(xG4, zG4, widthG4, heightG4);
            e.Graphics.DrawEllipse(myPenOrange, rectfG4);
            // 5 G circle
            float widthG5 = widthG1 * 5;
            float heightG5 = heightG1 * 5;
            float xG5 = (panel1.Size.Width / 2 - widthG5 / 2);
            float zG5 = (panel1.Size.Height / 2 - heightG5 / 2);
            RectangleF rectfG5 = new RectangleF(xG5, zG5, widthG5, heightG5);
            e.Graphics.DrawEllipse(myPenOrangeRed, rectfG5);
            // 6 G circle
            float widthG6 = widthG1 * 6;
            float heightG6 = heightG1 * 6;
            float xG6 = (panel1.Size.Width / 2 - widthG6 / 2);
            float zG6 = (panel1.Size.Height / 2 - heightG6 / 2);
            RectangleF rectfG6 = new RectangleF(xG6, zG6, widthG6, heightG6);
            e.Graphics.DrawEllipse(myPenRed, rectfG6);
            // 7 G circle
            float widthG7 = widthG1 * 7;
            float heightG7 = heightG1 * 7;
            float xG7 = (panel1.Size.Width / 2 - widthG7 / 2);
            float zG7 = (panel1.Size.Height / 2 - heightG7 / 2);
            RectangleF rectfG7 = new RectangleF(xG7, zG7, widthG7, heightG7);
            e.Graphics.DrawEllipse(myPenDarkRed, rectfG7);
            float xG = 197;
            float zG = 197;
            Color gColor = Color.White;
            Pen myPenG = new Pen(gColor, 1);
            Brush brush = new SolidBrush(gColor);
            float widthG = 6;
            float heightG = 6;

            if ((LiveData.XZG >= -0.001 && LiveData.XZG <= 0.001) || LiveData.XZG == double.NaN)
            {
                xG = 197;
                zG = 197;
            }
            else
            {
                xG = 197 + Convert.ToSingle((Math.Sin(LiveData.XZGAngleRad) * LiveData.XZG) * GScale);
                zG = 197 - Convert.ToSingle((Math.Cos(LiveData.XZGAngleRad) * LiveData.XZG) * GScale);
            }
            RectangleF rectfG = new RectangleF(xG, zG, widthG, heightG);
            e.Graphics.DrawEllipse(myPenG, rectfG);
            e.Graphics.FillEllipse(brush, rectfG);
            //textBox7.Text = "x: " + xG.ToString() + "\r\n" + "y: " + zG.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // YG location

            float x1 = 12;
            float x2 = 55;
            float yG = 199;
            Color gColor = Color.Gray;
            Pen myPenG = new Pen(gColor, 3);
            Brush brush = new SolidBrush(gColor);

            yG = 199f - Convert.ToSingle(LiveData.YG) * GScale;
            e.Graphics.DrawLine(myPenG, x1, yG, x2, yG);

            Pen myPenWhite = new Pen(Color.White, 3);
            Pen myPenLightBlue = new Pen(Color.LightBlue, 3);
            Pen myPenBlue = new Pen(Color.Blue, 3);
            Pen myPenYellow = new Pen(Color.Yellow, 3);
            Pen myPenOrange = new Pen(Color.Orange, 3);
            Pen myPenOrangeRed = new Pen(Color.OrangeRed, 3);
            Pen myPenRed = new Pen(Color.Red, 3);
            Pen myPenDarkRed = new Pen(Color.DarkRed, 3);


            // 0 G Line
            float xStart = 12;
            float xEnd = (50);
            float heightG0 = 2;
            float yG0 = (panel2.Size.Height / 2 - heightG0 / 2);
            G0.Location = new Point(0, Convert.ToInt32(yG0) - 7);
            e.Graphics.DrawLine(myPenWhite, xStart, yG0, xEnd, yG0);
            // 1 G Line
            float heightG1 = GScale * 2;
            float yG1 = (panel2.Size.Height / 2 - heightG1 / 2);
            float yG1b = (panel2.Size.Height / 2 + heightG1 / 2);
            G1.Location = new Point(0, Convert.ToInt32(yG1) - 7);
            G1m.Location = new Point(0, Convert.ToInt32(yG1b) - 7);
            e.Graphics.DrawLine(myPenLightBlue, xStart, yG1, xEnd, yG1);
            e.Graphics.DrawLine(myPenLightBlue, xStart, yG1b, xEnd, yG1b);
            // 2 G Line
            float heightG2 = heightG1 * 2;
            float yG2 = (panel2.Size.Height / 2 - heightG2 / 2);
            float yG2b = (panel2.Size.Height / 2 + heightG2 / 2);
            G2.Location = new Point(0, Convert.ToInt32(yG2) - 7);
            G2m.Location = new Point(0, Convert.ToInt32(yG2b) - 7);
            e.Graphics.DrawLine(myPenBlue, xStart, yG2, xEnd, yG2);
            e.Graphics.DrawLine(myPenBlue, xStart, yG2b, xEnd, yG2b);
            // 3 G Line
            float heightG3 = heightG1 * 3;
            float yG3 = (panel2.Size.Height / 2 - heightG3 / 2);
            float yG3b = (panel2.Size.Height / 2 + heightG3 / 2);
            G3.Location = new Point(0, Convert.ToInt32(yG3) - 7);
            G3m.Location = new Point(0, Convert.ToInt32(yG3b) - 7);
            e.Graphics.DrawLine(myPenYellow, xStart, yG3, xEnd, yG3);
            e.Graphics.DrawLine(myPenYellow, xStart, yG3b, xEnd, yG3b);
            // 4 G Line
            float heightG4 = heightG1 * 4;
            float yG4 = (panel2.Size.Height / 2 - heightG4 / 2);
            float yG4b = (panel2.Size.Height / 2 + heightG4 / 2);
            G4.Location = new Point(0, Convert.ToInt32(yG4) - 7);
            G4m.Location = new Point(0, Convert.ToInt32(yG4b) - 7);
            e.Graphics.DrawLine(myPenOrange, xStart, yG4, xEnd, yG4);
            e.Graphics.DrawLine(myPenOrange, xStart, yG4b, xEnd, yG4b);
            // 5 G Line
            float heightG5 = heightG1 * 5;
            float yG5 = (panel2.Size.Height / 2 - heightG5 / 2);
            float yG5b = (panel2.Size.Height / 2 + heightG5 / 2);
            G5.Location = new Point(0, Convert.ToInt32(yG5) - 7);
            G5m.Location = new Point(0, Convert.ToInt32(yG5b) - 7);
            e.Graphics.DrawLine(myPenOrangeRed, xStart, yG5, xEnd, yG5);
            e.Graphics.DrawLine(myPenOrangeRed, xStart, yG5b, xEnd, yG5b);
            // 6 G Line
            float heightG6 = heightG1 * 6;
            float yG6 = (panel2.Size.Height / 2 - heightG6 / 2);
            float yG6b = (panel2.Size.Height / 2 + heightG6 / 2);
            G6.Location = new Point(0, Convert.ToInt32(yG6) - 7);
            G6m.Location = new Point(0, Convert.ToInt32(yG6b) - 7);
            e.Graphics.DrawLine(myPenRed, xStart, yG6, xEnd, yG6);
            e.Graphics.DrawLine(myPenRed, xStart, yG6b, xEnd, yG6b);
            // 7 G Line
            float heightG7 = heightG1 * 7;
            float yG7 = (panel2.Size.Height / 2 - heightG7 / 2);
            float yG7b = (panel2.Size.Height / 2 + heightG7 / 2);
            G7.Location = new Point(0, Convert.ToInt32(yG7) - 7);
            G7m.Location = new Point(0, Convert.ToInt32(yG7b) - 7);
            e.Graphics.DrawLine(myPenDarkRed, xStart, yG7, xEnd, yG7);
            e.Graphics.DrawLine(myPenDarkRed, xStart, yG7b, xEnd, yG7b);
        }
    }
}