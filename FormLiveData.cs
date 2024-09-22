using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace Physics_Data_Debug
{
    public partial class FormLiveData : Form
    {
        #region Field variables

        public static bool SettingsOpen = false;
        public static bool TireSettingsOpen = false;
        public static bool SuspensionSettingsOpen = false;

        public static bool FiltersOn = false;

        public static bool TireTravelSpeedLogEnabled = true;//0
        public static bool AngularVelocityLogEnabled = true;//1
        public static bool VerticalLoadLogEnabled = true;//2
        public static bool VerticalDeflectionLogEnabled = true;//3
        public static bool LoadedRadiusLogEnabled = true;//4
        public static bool EffectiveRadiusLogEnabled = true;//5
        public static bool ContactLengthLogEnabled = true;//6
        public static bool BrakeTorqueLogEnabled = true;//7
        public static bool SteerAngleLogEnabled = true;//8
        public static bool CamberAngleLogEnabled = true;//9
        public static bool LateralLoadLogEnabled = true;//10
        public static bool SlipAngleLogEnabled = true;//11
        public static bool LateralFrictionLogEnabled = true;//12
        public static bool LateralSlipSpeedLogEnabled = true;//13
        public static bool LongitudinalLoadLogEnabled = true;//14
        public static bool SlipRatioLogEnabled = true;//15
        public static bool LongitudinalFrictionLogEnabled = true;//16
        public static bool LongitudinalSlipSpeedLogEnabled = true;//17
        public static bool TreadTemperatureLogEnabled = true;//18
        public static bool InnerTemperatureLogEnabled = true;//19
        public static bool RaceTimeLogEnabled = true;//20
        public static bool TotalFrictionLogEnabled = true;//21
        public static bool TotalFrictionAngleLogEnabled = true;//22
        public static bool SuspensionLengthLogEnabled = true;//23
        public static bool SuspensionVelocityLogEnabled = true;//24

        public static string LogFileSaveLocationFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\PhysicsDebugger\";

        public static string ChartPlotterLocation = "";

        public static string sTireTravelSpeed = "Tire Travel Speed";
        public static string sAngularVelocity = "Angular Velocity";
        public static string sVerticalLoad = "Vertical Load";
        public static string sVerticalDeflection = "Vertical Deflection";
        public static string sLoadedRadius = "Loaded Radius";
        public static string sEffectiveRadius = "Effective Radius";
        public static string sContactLength = "Contact Length";
        public static string sBrakeTorque = "Brake Torque";
        public static string sMaxBrakeTorque = "Max Brake Torque";
        public static string sSteerAngle = "Steer Angle";
        public static string sCamberAngle = "Camber Angle";
        public static string sLateralLoad = "Lateral Load";
        public static string sSlipAngle = "Slip Angle";
        public static string sLateralFriction = "Lateral Friction";
        public static string sLateralSlipSpeed = "Lateral Slip Speed";
        public static string sLongitudinalLoad = "Longitudinal Load";
        public static string sSlipRatio = "Slip Ratio";
        public static string sLongitudinalFriction = "Longitudinal Friction";
        public static string sLongitudinalSlipSpeed = "Longitudinal Slip Speed";
        public static string sTreadTemperature = "Tread Temperature";
        public static string sInnerTemperature = "Inner Temperature";
        public static string sRaceTime = "Race Time";
        public static string sTotalFriction = "Total Friction";
        public static string sTotalFrictionAngle = "Total Friction Angle";
        public static string sSuspensionLength = "Suspension Length";
        public static string sSuspensionVelocity = "Suspension Velocity";

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
            RectangleF circleFL = new RectangleF(0, 0, 10, 10);//Small Circle
            RectangleF circleRR = new RectangleF(0, 0, 10, 10);//Small Circle

            PointF locFL = PointF.Empty;
            PointF locRR = PointF.Empty;
            PointF img = new PointF(0, 0);// Move picture more from draw point. Basically nothing because can already do that through translate.

            fG.Clear(Color.Black);

            while(drawing)
            {
                g.Clear(Color.Black);

                g.DrawEllipse(pen, areaFL);
                g.DrawEllipse(pen, areaRR);

                locFL = CirclePoint(radFL, angleInDegreesFL, orgFL);
                locRR = CirclePoint(radRR, angleInDegreesRR, orgRR);

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

        public PointF CirclePoint(float radius, float angleInDegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;

            return new PointF(x, y);
        }

        ***************************/

        private Thread update;

        private bool logging = false;

        private double radToDeg = 180 / Math.PI;

        private int sleep = 50;

        // How long array is.
        private readonly double[] flsTempArray = new double[300];
        private readonly double[] fliTempArray = new double[300];
        private readonly double[] frsTempArray = new double[300];
        private readonly double[] friTempArray = new double[300];
        private readonly double[] rlsTempArray = new double[300];
        private readonly double[] rliTempArray = new double[300];
        private readonly double[] rrsTempArray = new double[300];
        private readonly double[] rriTempArray = new double[300];
        /*
        private double TempCorrectionValue = 0.0000000000;
        private double TempCorrectionValueA = 0.0000000000;
        private double TempCorrectionValueB = 0.0000000000;
        private double TempCorrectionValueC = 0.0000000000;
        private double TempCorrectionValueD = 0.0000000000;
        */

        public static double speed = 0.00;
        public static double frontLift = 0.00;
        public static double rearLift = 0.00;
        public static double engineRPM = 0.00;
        public static double engineRPMAxle = 0.00;
        public static double engineTorque = 0.00;

        public static double enginePower = 0.00;
        public static byte differentialLocked = 0;
        public static double differentialVelocityRad = 0.00;
        public static double differentialTorque = 0.00;


        //Basest of the basest
        public static ulong baseAddrTiresSuspensionLiftsDifferential = 0x1831EE0;
        public static ulong baseAddrEngineSpeed = 0x18327C8;
        public static ulong baseAddrRacetime = 0x1832648;
        //Every update offsets the base address of the memory points. 99% of the time forwards.
        public static ulong baseAddrUpdt = 0x9E00;
        //0x0;// April 2022
        //0x4650;// May 2022
        //0x5710// October 2022
        // 0x67A0 November 2022 1838680 vs 1831EE0
        // 0x7DF0 April 2023
        // 0x9E00; March 2024 = 7DF0+2010 = 9E00

        // Older builds go backwards, so this is for them. Above should be 0x0 then.
        public static ulong baseAddrDodt = 0x0;//0x6DF8D8

        //Time offsets
        public static int OffsetRaceTime = 0x14;

        // Other offsets
        public static int OffsetSpeed = 0x70;
        public static int OffsetFrontLift = 0xAACF2C;
        public static int OffsetRearLift = 0xAACF30;
        public static int OffsetEngineRPM = 0x38;
        public static int OffsetEngineRPMAxle = 0x3C;
        public static int OffsetEngineTorque = 0x44;
        public static int OffsetDifferentialOpen = 0xD94;
        public static int OffsetDifferentialVelocityRad = 0xD98;
        public static int OffsetDifferentialTorque = 0xD9C;

        // Suspension offsets
        public static int OffsetSpringRate = 0xE80;
        public static int OffsetProgresiveRate = 0xE84;
        public static int OffsetBumbLimitsX = 0xE88;
        public static int OffsetBumpLimitsY = 0xE8C;
        public static int OffsetReboundLimitsX = 0xE90;
        public static int OffsetReboundLimitsY = 0xE94;
        public static int OffsetBumpDampX = 0xE98;
        public static int OffsetReboundDampX = 0xE9C;
        public static int OffsetBumpDampY = 0xEA0;
        public static int OffsetReboundDampY = 0xEA4;
        public static int OffsetExpandLimitFromZero = 0xEA8;
        public static int OffsetCompressionLimitFromZero = 0xEAC;
        public static int OffsetRideHeightBumpStopDownReboundLength = 0xEB0;
        public static int OffsetSuspensionLength = 0xEB4;
        public static int OffsetSuspensionVelocity = 0xEB8;
        public static int OffsetBumpStopLength = 0xEBC;
        public static int OffsetRideHeightBumpStopDown = 0xEC0;
        public static int OffsetBumpStopRate = 0xEC4;
        public static int OffsetReboundRate = 0xEC8;
        public static int OffsetBumpStopDamp = 0xECC;
        public static int OffsetBumpStopRateGainDeflectionSquared = 0xED0;
        public static int OffsetBumpStopDampGainDeflectionSquared = 0xED4;

        public static int OffsetFRSuspension = 0x60;
        public static int OffsetRLSuspension = OffsetFRSuspension + OffsetFRSuspension;
        public static int OffsetRRSuspension = OffsetFRSuspension + OffsetFRSuspension + OffsetFRSuspension;

        //0x3E4
        //0xAE8

        //Tire data offsets
        public static int OffsetTireData = 0xE78;
        public static int OffsetFRTire = 0xC50;//Next tire offset from FL
        public static int OffsetRLTire = 0xC50 + 0xC50;//Next tire offset from FL
        public static int OffsetRRTire = 0xC50 + 0xC50 + 0xC50;//Next tire offset from FL

        public static int OffsetMomentOfInertia = 0x28;//
        public static int OffsetAngularVelocity = 0x2C;
        public static int OffsetCamberAngleRad = 0x394;
        public static int OffsetTireSteerAngleRad = 0x398;
        public static int OffsetTireMass = 0x410;//
        public static int OffsetTireRadius = 0x414;//
        public static int OffsetTireWidth = 0x418;//
        public static int OffsetTireSpringRate = 0x41C;//
        public static int OffsetTireDamperRate = 0x420;//
        public static int OffsetTireMaxDeflection = 0x424;//
        public static int OffsetThermalAirTransfer = 0x428;//
        public static int OffsetThermalInnerTransfer = 0x42C;//
        public static int OffsetTreadTemperature = 0x434;
        public static int OffsetInnerTemperature = 0x438;
        public static int OffsetDeflection = 0x43C;
        public static int OffsetLoadedRadius = 0x44C;
        public static int OffsetEffectiveRadius = 0x450;
        public static int OffsetLongitudinalSlipSpeed = 0x454;
        public static int OffsetLateralSlipSpeed = 0x458;
        public static int OffsetRadOfTireMoved = 0x45C;//Not angular but compared to the contact surface.
        public static int OffsetCurrentContactBrakeTorque = 0x484;
        public static int OffsetCurrentContactBrakeTorqueMax = 0x48C;
        public static int OffsetVerticalLoad = 0x490;

        public static int OffsetLateralLoad = 0x4B8;
        public static int OffsetLongitudinalLoad = 0x4C0;
        public static int OffsetSlipAngleRad = 0xBF0;
        public static int OffsetSlipRatio = 0xBF4;
        public static int OffsetLateralResistance = 0xBF8;//
        public static int OffsetLongitudinalResistance = 0xBFC;//

        public static int OffsetContactLength = 0xC1C;
        public static int OffsetTravelSpeed = 0xC20;
        /*
                 
                 */

        //Time Data
        public static int RaceTime;

        //Tire Data

        //Font Left
        public static double FL_MomentOfInertia;//
        public static double FL_AngularVelocity;
        public static double FL_CamberAngleRad;//
        public static double FL_CamberAngleDeg;//
        public static double FL_SteerAngleRad;//
        public static double FL_SteerAngleDeg;//
        public static double FL_TireMass;//
        public static double FL_TireRadius;//
        public static double FL_TireWidth;//
        public static double FL_TireSpringRate;//
        public static double FL_TireDamperRate;//
        public static double FL_TireMaxDeflection;//
        public static double FL_ThermalAirTransfer;
        public static double FL_ThermalInnerTransfer;
        public static double FL_TreadTemperature = 0.0;
        public static double FL_InnerTemperature = 0.0;
        public static double FL_VerticalDeflection;
        public static double FL_LoadedRadius;
        public static double FL_EffectiveRadius;
        public static double FL_LongitudinalSlipSpeed;//
        public static double FL_LateralSlipSpeed;//
        public static double FL_RadOfTireMoved;//
        public static double FL_CurrentContactBrakeTorque;
        public static double FL_CurrentContactBrakeTorqueMax;
        public static double FL_VerticalLoad;

        public static double FL_LateralLoad;
        public static double FL_LongitudinalLoad;
        public static double FL_SlipAngleRad;
        public static double FL_SlipAngleDeg;
        public static double FL_SlipRatio;
        public static double FL_LateralResistance;//
        public static double FL_LongitudinalResistance;//

        public static double FL_ContactLength;
        public static double FL_TravelSpeed;
        //----------------------------------------//
        public static double FL_LateralFriction;
        public static double FL_LongitudinalFriction;
        public static double FL_TotalFriction;//
        public static double FL_TotalFrictionAngle;//

        public static double FL_SuspensionLength;
        public static double FL_SuspensionVelocity;
        /*
                 
                 */

        //Front Right
        public static double FR_MomentOfInertia;//
        public static double FR_AngularVelocity;
        public static double FR_CamberAngleRad;//
        public static double FR_CamberAngleDeg;//
        public static double FR_SteerAngleRad;//
        public static double FR_SteerAngleDeg;//
        public static double FR_TireMass;//
        public static double FR_TireRadius;//
        public static double FR_TireWidth;//
        public static double FR_TireSpringRate;//
        public static double FR_TireDamperRate;//
        public static double FR_TireMaxDeflection;//
        public static double FR_ThermalAirTransfer;
        public static double FR_ThermalInnerTransfer;
        public static double FR_TreadTemperature = 0.0;
        public static double FR_InnerTemperature = 0.0;
        public static double FR_VerticalDeflection;
        public static double FR_LoadedRadius;
        public static double FR_EffectiveRadius;
        public static double FR_LongitudinalSlipSpeed;//
        public static double FR_LateralSlipSpeed;//
        public static double FR_RadOfTireMoved;//
        public static double FR_CurrentContactBrakeTorque;
        public static double FR_CurrentContactBrakeTorqueMax;
        public static double FR_VerticalLoad;

        public static double FR_LateralLoad;
        public static double FR_LongitudinalLoad;
        public static double FR_SlipAngleRad;
        public static double FR_SlipAngleDeg;
        public static double FR_SlipRatio;
        public static double FR_LateralResistance;//
        public static double FR_LongitudinalResistance;//

        public static double FR_ContactLength;
        public static double FR_TravelSpeed;
        //----------------------------------------//
        public static double FR_LateralFriction;
        public static double FR_LongitudinalFriction;
        public static double FR_TotalFriction;//
        public static double FR_TotalFrictionAngle;//

        public static double FR_SuspensionLength;
        public static double FR_SuspensionVelocity;
        /*
                 
                 */

        //Rear Left
        public static double RL_MomentOfInertia;//
        public static double RL_AngularVelocity;
        public static double RL_CamberAngleRad;//
        public static double RL_CamberAngleDeg;//
        public static double RL_SteerAngleRad;//
        public static double RL_SteerAngleDeg;//
        public static double RL_TireMass;//
        public static double RL_TireRadius;//
        public static double RL_TireWidth;//
        public static double RL_TireSpringRate;//
        public static double RL_TireDamperRate;//
        public static double RL_TireMaxDeflection;//
        public static double RL_ThermalAirTransfer;
        public static double RL_ThermalInnerTransfer;
        public static double RL_TreadTemperature = 0.0;
        public static double RL_InnerTemperature = 0.0;
        public static double RL_VerticalDeflection;
        public static double RL_LoadedRadius;
        public static double RL_EffectiveRadius;
        public static double RL_LongitudinalSlipSpeed;//
        public static double RL_LateralSlipSpeed;//
        public static double RL_RadOfTireMoved;//
        public static double RL_CurrentContactBrakeTorque;
        public static double RL_CurrentContactBrakeTorqueMax;
        public static double RL_VerticalLoad;

        public static double RL_LateralLoad;
        public static double RL_LongitudinalLoad;
        public static double RL_SlipAngleRad;
        public static double RL_SlipAngleDeg;
        public static double RL_SlipRatio;
        public static double RL_LateralResistance;//
        public static double RL_LongitudinalResistance;//

        public static double RL_ContactLength;
        public static double RL_TravelSpeed;
        //----------------------------------------//
        public static double RL_LateralFriction;
        public static double RL_LongitudinalFriction;
        public static double RL_TotalFriction;//
        public static double RL_TotalFrictionAngle;//

        public static double RL_SuspensionLength;
        public static double RL_SuspensionVelocity;
        /*
                 
                 */

        //Rear Right
        public static double RR_MomentOfInertia;//
        public static double RR_AngularVelocity;
        public static double RR_CamberAngleRad;//
        public static double RR_CamberAngleDeg;//
        public static double RR_SteerAngleRad;//
        public static double RR_SteerAngleDeg;//
        public static double RR_TireMass;//
        public static double RR_TireRadius;//
        public static double RR_TireWidth;//
        public static double RR_TireSpringRate;//
        public static double RR_TireDamperRate;//
        public static double RR_TireMaxDeflection;//
        public static double RR_ThermalAirTransfer;
        public static double RR_ThermalInnerTransfer;
        public static double RR_TreadTemperature = 0.0;
        public static double RR_InnerTemperature = 0.0;
        public static double RR_VerticalDeflection;
        public static double RR_LoadedRadius;
        public static double RR_EffectiveRadius;
        public static double RR_LongitudinalSlipSpeed;//
        public static double RR_LateralSlipSpeed;//
        public static double RR_RadOfTireMoved;//
        public static double RR_CurrentContactBrakeTorque;
        public static double RR_CurrentContactBrakeTorqueMax;
        public static double RR_VerticalLoad;

        public static double RR_LateralLoad;
        public static double RR_LongitudinalLoad;
        public static double RR_SlipAngleRad;
        public static double RR_SlipAngleDeg;
        public static double RR_SlipRatio;
        public static double RR_LateralResistance;//
        public static double RR_LongitudinalResistance;//

        public static double RR_ContactLength;
        public static double RR_TravelSpeed;
        //----------------------------------------//
        public static double RR_LateralFriction;
        public static double RR_LongitudinalFriction;
        public static double RR_TotalFriction;//
        public static double RR_TotalFrictionAngle;//

        public static double RR_SuspensionLength;
        public static double RR_SuspensionVelocity;
        /*
                 
                 */

        string Header0;
        string Header1;
        string Header2;
        string Header3;
        string Header4;
        string Header5;
        string Header6;
        string Header7;
        string Header7_1;
        string Header8;
        string Header9;
        string Header10;
        string Header11;
        string Header12;
        string Header13;
        string Header14;
        string Header15;
        string Header16;
        string Header17;
        string Header18;
        string Header19;
        string Header20;
        string Header21;
        string Header22;
        string Header23;
        string Header24;

        string flParameter0;
        string flParameter1;
        string flParameter2;
        string flParameter3;
        string flParameter4;
        string flParameter5;
        string flParameter6;
        string flParameter7;
        string flParameter7_1;
        string flParameter8;
        string flParameter9;
        string flParameter10;
        string flParameter11;
        string flParameter12;
        string flParameter13;
        string flParameter14;
        string flParameter15;
        string flParameter16;
        string flParameter17;
        string flParameter18;
        string flParameter19;
        string flParameter20;
        string flParameter21;
        string flParameter22;
        string flParameter23;
        string flParameter24;

        string frParameter0;
        string frParameter1;
        string frParameter2;
        string frParameter3;
        string frParameter4;
        string frParameter5;
        string frParameter6;
        string frParameter7;
        string frParameter7_1;
        string frParameter8;
        string frParameter9;
        string frParameter10;
        string frParameter11;
        string frParameter12;
        string frParameter13;
        string frParameter14;
        string frParameter15;
        string frParameter16;
        string frParameter17;
        string frParameter18;
        string frParameter19;
        string frParameter20;
        string frParameter21;
        string frParameter22;
        string frParameter23;
        string frParameter24;

        string rlParameter0;
        string rlParameter1;
        string rlParameter2;
        string rlParameter3;
        string rlParameter4;
        string rlParameter5;
        string rlParameter6;
        string rlParameter7;
        string rlParameter7_1;
        string rlParameter8;
        string rlParameter9;
        string rlParameter10;
        string rlParameter11;
        string rlParameter12;
        string rlParameter13;
        string rlParameter14;
        string rlParameter15;
        string rlParameter16;
        string rlParameter17;
        string rlParameter18;
        string rlParameter19;
        string rlParameter20;
        string rlParameter21;
        string rlParameter22;
        string rlParameter23;
        string rlParameter24;

        string rrParameter0;
        string rrParameter1;
        string rrParameter2;
        string rrParameter3;
        string rrParameter4;
        string rrParameter5;
        string rrParameter6;
        string rrParameter7;
        string rrParameter7_1;
        string rrParameter8;
        string rrParameter9;
        string rrParameter10;
        string rrParameter11;
        string rrParameter12;
        string rrParameter13;
        string rrParameter14;
        string rrParameter15;
        string rrParameter16;
        string rrParameter17;
        string rrParameter18;
        string rrParameter19;
        string rrParameter20;
        string rrParameter21;
        string rrParameter22;
        string rrParameter23;
        string rrParameter24;

        //Speed and Lift pointers
        int[] speedOffsets = { OffsetSpeed };
        int[] frontLiftOffsets = { OffsetFrontLift };
        int[] rearLiftOffsets = { OffsetRearLift };

        //Engine and diff pointers 
        int[] engineRPMOffests = { OffsetEngineRPM };
        int[] engineRPMAxleOffests = { OffsetEngineRPMAxle };
        int[] engineTorqueOffsets = { OffsetEngineTorque };
        int[] differentialOpenOffsets = { OffsetDifferentialOpen };
        int[] differentialVelocityRadOffsets = { OffsetDifferentialVelocityRad };
        int[] differentialTorqueOffsets = { OffsetDifferentialTorque };

        //Race time pointer
        int[] raceTimerOffsets = { OffsetRaceTime };

        //Tire & Suspension Data pointers
        //Front Left
        int[] flsOffsets = { OffsetTireData, OffsetTreadTemperature };
        int[] fliOffsets = { OffsetTireData, OffsetInnerTemperature };
        int[] FL_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity };
        int[] FL_DeflectionOffsets = { OffsetTireData, OffsetDeflection };
        int[] FL_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius };
        int[] FL_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius };
        int[] FL_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque };
        int[] FL_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax };
        int[] FL_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad };
        int[] FL_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad };
        int[] FL_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad };
        int[] FL_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad };
        int[] FL_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio };
        int[] FL_ContactLengthOffsets = { OffsetTireData, OffsetContactLength };
        int[] FL_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed };
        int[] FL_LateralSlipSpeedOffsets = { OffsetTireData, OffsetLateralSlipSpeed };//
        int[] FL_LongitudinalSlipSpeedOffsets = { OffsetTireData, OffsetLongitudinalSlipSpeed };// 
        int[] FL_CamberAngleRadOffsets = { OffsetTireData, OffsetCamberAngleRad };//
        int[] FL_TireSteerAngleRadOffsets = { OffsetTireData, OffsetTireSteerAngleRad };//

        int[] FL_MomentOfInertiaOffsets = { OffsetTireData, OffsetMomentOfInertia };//
        int[] FL_TireMassOffsets = { OffsetTireData, OffsetTireMass };//
        int[] FL_TireRadiusOffsets = { OffsetTireData, OffsetTireRadius };//
        int[] FL_TireWidthOffsets = { OffsetTireData, OffsetTireWidth };//
        int[] FL_TireSpringRateOffsets = { OffsetTireData, OffsetTireSpringRate };//
        int[] FL_TireDamperRateOffsets = { OffsetTireData, OffsetTireDamperRate };//
        int[] FL_TireMaxDeflectionOffsets = { OffsetTireData, OffsetTireMaxDeflection };//
        int[] FL_ThermalAirTransferOffsets = { OffsetTireData, OffsetThermalAirTransfer };
        int[] FL_ThermalInnerTransferOffsets = { OffsetTireData, OffsetThermalInnerTransfer };

        int[] FL_SuspensionLengthOffsets = { OffsetSuspensionLength };
        int[] FL_SuspensionVelocityOffsets = { OffsetSuspensionVelocity };
        /*

         */

        //Front Right
        int[] frsOffsets = { OffsetTireData, OffsetTreadTemperature + OffsetFRTire };
        int[] friOffsets = { OffsetTireData, OffsetInnerTemperature + OffsetFRTire };
        int[] FR_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity + OffsetFRTire };
        int[] FR_DeflectionOffsets = { OffsetTireData, OffsetDeflection + OffsetFRTire };
        int[] FR_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius + OffsetFRTire };
        int[] FR_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius + OffsetFRTire };
        int[] FR_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetFRTire };
        int[] FR_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetFRTire };
        int[] FR_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad + OffsetFRTire };
        int[] FR_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad + OffsetFRTire };
        int[] FR_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad + OffsetFRTire };
        int[] FR_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad + OffsetFRTire };
        int[] FR_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio + OffsetFRTire };
        int[] FR_ContactLengthOffsets = { OffsetTireData, OffsetContactLength + OffsetFRTire };
        int[] FR_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed + OffsetFRTire };
        int[] FR_LateralSlipSpeedOffsets = { OffsetTireData, OffsetLateralSlipSpeed + OffsetFRTire };//
        int[] FR_LongitudinalSlipSpeedOffsets = { OffsetTireData, OffsetLongitudinalSlipSpeed + OffsetFRTire };//
        int[] FR_MomentOfInertiaOffsets = { OffsetTireData, OffsetMomentOfInertia + OffsetFRTire };//
        int[] FR_CamberAngleRadOffsets = { OffsetTireData, OffsetCamberAngleRad + OffsetFRTire };//
        int[] FR_TireSteerAngleRadOffsets = { OffsetTireData, OffsetTireSteerAngleRad + OffsetFRTire };//
        int[] FR_TireMassOffsets = { OffsetTireData, OffsetTireMass + OffsetFRTire };//
        int[] FR_TireRadiusOffsets = { OffsetTireData, OffsetTireRadius + OffsetFRTire };//
        int[] FR_TireWidthOffsets = { OffsetTireData, OffsetTireWidth + OffsetFRTire };//
        int[] FR_TireSpringRateOffsets = { OffsetTireData, OffsetTireSpringRate + OffsetFRTire };//
        int[] FR_TireDamperRateOffsets = { OffsetTireData, OffsetTireDamperRate + OffsetFRTire };//
        int[] FR_TireMaxDeflectionOffsets = { OffsetTireData, OffsetTireMaxDeflection + OffsetFRTire };//
        int[] FR_ThermalAirTransferOffsets = { OffsetTireData, OffsetThermalAirTransfer + OffsetFRTire };
        int[] FR_ThermalInnerTransferOffsets = { OffsetTireData, OffsetThermalInnerTransfer + OffsetFRTire };

        int[] FR_SuspensionLengthOffsets = { OffsetSuspensionLength + OffsetFRSuspension };
        int[] FR_SuspensionVelocityOffsets = { OffsetSuspensionVelocity + OffsetFRSuspension };
        /*

         */

        //Rear Left
        int[] rlsOffsets = { OffsetTireData, OffsetTreadTemperature + OffsetRLTire };
        int[] rliOffsets = { OffsetTireData, OffsetInnerTemperature + OffsetRLTire };
        int[] RL_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity + OffsetRLTire };
        int[] RL_DeflectionOffsets = { OffsetTireData, OffsetDeflection + OffsetRLTire };
        int[] RL_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius + OffsetRLTire };
        int[] RL_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius + OffsetRLTire };
        int[] RL_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetRLTire };
        int[] RL_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetRLTire };
        int[] RL_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad + OffsetRLTire };
        int[] RL_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad + OffsetRLTire };
        int[] RL_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad + OffsetRLTire };
        int[] RL_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad + OffsetRLTire };
        int[] RL_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio + OffsetRLTire };
        int[] RL_ContactLengthOffsets = { OffsetTireData, OffsetContactLength + OffsetRLTire };
        int[] RL_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed + OffsetRLTire };
        int[] RL_LateralSlipSpeedOffsets = { OffsetTireData, OffsetLateralSlipSpeed + OffsetRLTire };//
        int[] RL_LongitudinalSlipSpeedOffsets = { OffsetTireData, OffsetLongitudinalSlipSpeed + OffsetRLTire };//
        int[] RL_MomentOfInertiaOffsets = { OffsetTireData, OffsetMomentOfInertia + OffsetRLTire };//
        int[] RL_CamberAngleRadOffsets = { OffsetTireData, OffsetCamberAngleRad + OffsetRLTire };//
        int[] RL_TireSteerAngleRadOffsets = { OffsetTireData, OffsetTireSteerAngleRad + OffsetRLTire };//
        int[] RL_TireMassOffsets = { OffsetTireData, OffsetTireMass + OffsetRLTire };//
        int[] RL_TireRadiusOffsets = { OffsetTireData, OffsetTireRadius + OffsetRLTire };//
        int[] RL_TireWidthOffsets = { OffsetTireData, OffsetTireWidth + OffsetRLTire };//
        int[] RL_TireSpringRateOffsets = { OffsetTireData, OffsetTireSpringRate + OffsetRLTire };//
        int[] RL_TireDamperRateOffsets = { OffsetTireData, OffsetTireDamperRate + OffsetRLTire };//
        int[] RL_TireMaxDeflectionOffsets = { OffsetTireData, OffsetTireMaxDeflection + OffsetRLTire };//
        int[] RL_ThermalAirTransferOffsets = { OffsetTireData, OffsetThermalAirTransfer + OffsetRLTire };//
        int[] RL_ThermalInnerTransferOffsets = { OffsetTireData, OffsetThermalInnerTransfer + OffsetRLTire };//

        int[] RL_SuspensionLengthOffsets = { OffsetSuspensionLength + OffsetRLSuspension };
        int[] RL_SuspensionVelocityOffsets = { OffsetSuspensionVelocity + OffsetRLSuspension };
        /*

         */

        //Rear Right
        int[] rrsOffsets = { OffsetTireData, OffsetTreadTemperature + OffsetRRTire };
        int[] rriOffsets = { OffsetTireData, OffsetInnerTemperature + OffsetRRTire };
        int[] RR_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity + OffsetRRTire };
        int[] RR_DeflectionOffsets = { OffsetTireData, OffsetDeflection + OffsetRRTire };
        int[] RR_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius + OffsetRRTire };
        int[] RR_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius + OffsetRRTire };
        int[] RR_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetRRTire };
        int[] RR_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetRRTire };
        int[] RR_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad + OffsetRRTire };
        int[] RR_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad + OffsetRRTire };
        int[] RR_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad + OffsetRRTire };
        int[] RR_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad + OffsetRRTire };
        int[] RR_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio + OffsetRRTire };
        int[] RR_ContactLengthOffsets = { OffsetTireData, OffsetContactLength + OffsetRRTire };
        int[] RR_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed + OffsetRRTire };
        int[] RR_LateralSlipSpeedOffsets = { OffsetTireData, OffsetLateralSlipSpeed + OffsetRRTire };//
        int[] RR_LongitudinalSlipSpeedOffsets = { OffsetTireData, OffsetLongitudinalSlipSpeed + OffsetRRTire };//
        int[] RR_MomentOfInertiaOffsets = { OffsetTireData, OffsetMomentOfInertia + OffsetRRTire };//
        int[] RR_CamberAngleRadOffsets = { OffsetTireData, OffsetCamberAngleRad + OffsetRRTire };//
        int[] RR_TireSteerAngleRadOffsets = { OffsetTireData, OffsetTireSteerAngleRad + OffsetRRTire };//
        int[] RR_TireMassOffsets = { OffsetTireData, OffsetTireMass + OffsetRRTire };//
        int[] RR_TireRadiusOffsets = { OffsetTireData, OffsetTireRadius + OffsetRRTire };//
        int[] RR_TireWidthOffsets = { OffsetTireData, OffsetTireWidth + OffsetRRTire };//
        int[] RR_TireSpringRateOffsets = { OffsetTireData, OffsetTireSpringRate + OffsetRRTire };//
        int[] RR_TireDamperRateOffsets = { OffsetTireData, OffsetTireDamperRate + OffsetRRTire };//
        int[] RR_TireMaxDeflectionOffsets = { OffsetTireData, OffsetTireMaxDeflection + OffsetRRTire };//
        int[] RR_ThermalAirTransferOffsets = { OffsetTireData, OffsetThermalAirTransfer + OffsetRRTire };//
        int[] RR_ThermalInnerTransferOffsets = { OffsetTireData, OffsetThermalInnerTransfer + OffsetRRTire };//

        int[] RR_SuspensionLengthOffsets = { OffsetSuspensionLength + OffsetRRSuspension };
        int[] RR_SuspensionVelocityOffsets = { OffsetSuspensionVelocity + OffsetRRSuspension };
        /*

         */
        #endregion
        public FormLiveData()
        {
            InitializeComponent();
            logInterval_textBox.Text = sleep.ToString();
        }

        #region Methods
        private void getData()
        {
            while (true)
            {
                Process p = Process.GetProcessesByName("Wreckfest_x64").FirstOrDefault();
                if (p == null) return;

                Memory.Win64.MemoryHelper64 helper = new Memory.Win64.MemoryHelper64(p);

                //Base Addres for Tire data
                ulong baseAddrUpdtTiresSuspensionLiftsDifferential = helper.GetBaseAddress(baseAddrTiresSuspensionLiftsDifferential + baseAddrUpdt - baseAddrDodt);
                //Base Address for Speed and Lifts
                ulong baseAddrUpdtEngineSpeed = helper.GetBaseAddress(baseAddrEngineSpeed + baseAddrUpdt - baseAddrDodt);
                //Base Address for Race Timer
                ulong baseAddrUpdtRacetimer = helper.GetBaseAddress(baseAddrRacetime + baseAddrUpdt - baseAddrDodt);

                //Race time pointer reader

                ulong raceTimerTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtRacetimer, raceTimerOffsets);
                //Speed, Lifts, Engine Torque and DIfferential pointer reader
                ulong speedTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtEngineSpeed, speedOffsets);
                ulong frontLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, frontLiftOffsets);
                ulong rearLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rearLiftOffsets);
                ulong engineRPMTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtEngineSpeed, engineRPMOffests);
                ulong engineRPMAxleTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtEngineSpeed, engineRPMAxleOffests);
                ulong engineTorqueTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtEngineSpeed, engineTorqueOffsets);
                ulong differentialOpenTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, differentialOpenOffsets);
                ulong differentialVelocityRadTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, differentialVelocityRadOffsets);
                ulong differentialTorqueTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, differentialTorqueOffsets);

                //Tire Data pointer readers
                //Front Left
                ulong flsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, flsOffsets);
                ulong fliTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, fliOffsets);
                ulong FL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_AngularVelocityOffsets);
                ulong FL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_DeflectionOffsets);
                ulong FL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LoadedRadiusOffsets);
                ulong FL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_EffectiveRadiusOffsets);
                ulong FL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_CurrentContactBrakeTorqueOffsets);
                ulong FL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_CurrentContactBrakeTorqueMaxOffsets);
                ulong FL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_VerticalLoadOffsets);
                ulong FL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LateralLoadOffsets);
                ulong FL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LongitudinalLoadOffsets);
                ulong FL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SlipAngleRadOffsets);
                ulong FL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SlipRatioOffsets);
                ulong FL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ContactLengthOffsets);
                ulong FL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TravelSpeedOffsets);
                ulong FL_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LateralSlipSpeedOffsets);//
                ulong FL_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LongitudinalSlipSpeedOffsets);//
                ulong FL_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_CamberAngleRadOffsets);//
                ulong FL_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireSteerAngleRadOffsets);//

                ulong FL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireMassOffsets);//
                ulong FL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireRadiusOffsets);//
                ulong FL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireWidthOffsets);//
                ulong FL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireSpringRateOffsets);//
                ulong FL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireDamperRateOffsets);//
                ulong FL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireMaxDeflectionOffsets);//
                ulong FL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ThermalAirTransferOffsets);//
                ulong FL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ThermalInnerTransferOffsets);//
                ulong FL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_MomentOfInertiaOffsets);//

                ulong FL_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SuspensionLengthOffsets);
                ulong FL_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SuspensionVelocityOffsets);
                /*
                 
                 */

                //Front Right
                ulong frsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, frsOffsets);
                ulong friTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, friOffsets);
                ulong FR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_AngularVelocityOffsets);
                ulong FR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_DeflectionOffsets);
                ulong FR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LoadedRadiusOffsets);
                ulong FR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_EffectiveRadiusOffsets);
                ulong FR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_CurrentContactBrakeTorqueOffsets);
                ulong FR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_CurrentContactBrakeTorqueMaxOffsets);
                ulong FR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_VerticalLoadOffsets);
                ulong FR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LateralLoadOffsets);
                ulong FR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LongitudinalLoadOffsets);
                ulong FR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SlipAngleRadOffsets);
                ulong FR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SlipRatioOffsets);
                ulong FR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ContactLengthOffsets);
                ulong FR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TravelSpeedOffsets);
                ulong FR_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LateralSlipSpeedOffsets);//
                ulong FR_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LongitudinalSlipSpeedOffsets);//
                ulong FR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_MomentOfInertiaOffsets);//
                ulong FR_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_CamberAngleRadOffsets);//
                ulong FR_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireSteerAngleRadOffsets);//
                ulong FR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireMassOffsets);//
                ulong FR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireRadiusOffsets);//
                ulong FR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireWidthOffsets);//
                ulong FR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireSpringRateOffsets);//
                ulong FR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireDamperRateOffsets);//
                ulong FR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireMaxDeflectionOffsets);//
                ulong FR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ThermalAirTransferOffsets);//
                ulong FR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ThermalInnerTransferOffsets);//

                ulong FR_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SuspensionLengthOffsets);
                ulong FR_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SuspensionVelocityOffsets);
                /*
                 
                 */

                //Rear Left
                ulong rlsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rlsOffsets);
                ulong rliTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rliOffsets);
                ulong RL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_AngularVelocityOffsets);
                ulong RL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_DeflectionOffsets);
                ulong RL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LoadedRadiusOffsets);
                ulong RL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_EffectiveRadiusOffsets);
                ulong RL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_CurrentContactBrakeTorqueOffsets);
                ulong RL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_CurrentContactBrakeTorqueMaxOffsets);
                ulong RL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_VerticalLoadOffsets);
                ulong RL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LateralLoadOffsets);
                ulong RL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LongitudinalLoadOffsets);
                ulong RL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SlipAngleRadOffsets);
                ulong RL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SlipRatioOffsets);
                ulong RL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ContactLengthOffsets);
                ulong RL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TravelSpeedOffsets);
                ulong RL_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LateralSlipSpeedOffsets);//
                ulong RL_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LongitudinalSlipSpeedOffsets);//
                ulong RL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_MomentOfInertiaOffsets);//
                ulong RL_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_CamberAngleRadOffsets);//
                ulong RL_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireSteerAngleRadOffsets);//
                ulong RL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireMassOffsets);//
                ulong RL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireRadiusOffsets);//
                ulong RL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireWidthOffsets);//
                ulong RL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireSpringRateOffsets);//
                ulong RL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireDamperRateOffsets);//
                ulong RL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireMaxDeflectionOffsets);//
                ulong RL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ThermalAirTransferOffsets);//
                ulong RL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ThermalInnerTransferOffsets);//

                ulong RL_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SuspensionLengthOffsets);
                ulong RL_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SuspensionVelocityOffsets);
                /*
                 
                 */

                //Rear Right
                ulong rrsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rrsOffsets);
                ulong rriTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rriOffsets);
                ulong RR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_AngularVelocityOffsets);
                ulong RR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_DeflectionOffsets);
                ulong RR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LoadedRadiusOffsets);
                ulong RR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_EffectiveRadiusOffsets);
                ulong RR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_CurrentContactBrakeTorqueOffsets);
                ulong RR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_CurrentContactBrakeTorqueMaxOffsets);
                ulong RR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_VerticalLoadOffsets);
                ulong RR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LateralLoadOffsets);
                ulong RR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LongitudinalLoadOffsets);
                ulong RR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SlipAngleRadOffsets);
                ulong RR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SlipRatioOffsets);
                ulong RR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ContactLengthOffsets);
                ulong RR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TravelSpeedOffsets);
                ulong RR_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LateralSlipSpeedOffsets);//
                ulong RR_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LongitudinalSlipSpeedOffsets);//
                ulong RR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_MomentOfInertiaOffsets);//
                ulong RR_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_CamberAngleRadOffsets);//
                ulong RR_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireSteerAngleRadOffsets);//
                ulong RR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireMassOffsets);//
                ulong RR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireRadiusOffsets);//
                ulong RR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireWidthOffsets);//
                ulong RR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireSpringRateOffsets);//
                ulong RR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireDamperRateOffsets);//
                ulong RR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireMaxDeflectionOffsets);//
                ulong RR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ThermalAirTransferOffsets);//
                ulong RR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ThermalInnerTransferOffsets);//

                ulong RR_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SuspensionLengthOffsets);
                ulong RR_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SuspensionVelocityOffsets);
                /*
                 
                 */

                //Read race time
                RaceTime = helper.ReadMemory<int>(raceTimerTargetAddr);

                //Read Speed, Lifts, Engine Torque and Differential stuff
                speed = Math.Round(helper.ReadMemory<float>(speedTargetAddr), 2);
                frontLift = Math.Round(helper.ReadMemory<float>(frontLiftTargetAddr), 2);
                rearLift = Math.Round(helper.ReadMemory<float>(rearLiftTargetAddr), 2);
                engineRPM = Math.Round(helper.ReadMemory<float>(engineRPMTargetAddr), 2);
                engineRPMAxle = Math.Round(helper.ReadMemory<float>(engineRPMAxleTargetAddr), 2);
                engineTorque = Math.Round(helper.ReadMemory<float>(engineTorqueTargetAddr), 2);
                enginePower = Math.Round(engineTorque * engineRPM / 9549, 2);
                differentialLocked = helper.ReadMemory<byte>(differentialOpenTargetAddr);
                differentialVelocityRad = Math.Round(helper.ReadMemory<float>(differentialVelocityRadTargetAddr), 2);
                differentialTorque = Math.Round(helper.ReadMemory<float>(differentialTorqueTargetAddr), 2);

                //Read Tire Data
                //Font Left
                FL_AngularVelocity = Math.Round(helper.ReadMemory<float>(FL_AngularVelocity_TargetAddr), 2);
                FL_VerticalDeflection = Math.Round(helper.ReadMemory<float>(FL_Deflection_TargetAddr), 5);
                FL_LoadedRadius = Math.Round(helper.ReadMemory<float>(FL_LoadedRadius_TargetAddr), 5);
                FL_EffectiveRadius = Math.Round(helper.ReadMemory<float>(FL_EffectiveRadius_TargetAddr), 5);
                FL_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(FL_CurrentContactBrakeTorque_TargetAddr), 2);
                FL_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(FL_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                FL_VerticalLoad = Math.Round(helper.ReadMemory<float>(FL_VerticalLoad_TargetAddr), 2);
                FL_LateralLoad = Math.Round(helper.ReadMemory<float>(FL_LateralLoad_TargetAddr), 2);
                FL_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(FL_LongitudinalLoad_TargetAddr), 2);
                FL_SlipAngleRad = Math.Round(helper.ReadMemory<float>(FL_SlipAngleRad_TargetAddr), 5);
                FL_SlipAngleDeg = Math.Round(FL_SlipAngleRad * radToDeg, 2);
                FL_SlipRatio = Math.Round(helper.ReadMemory<float>(FL_SlipRatio_TargetAddr), 5);
                FL_ContactLength = Math.Round(helper.ReadMemory<float>(FL_ContactLength_TargetAddr), 5);
                FL_TravelSpeed = Math.Round(helper.ReadMemory<float>(FL_TravelSpeed_TargetAddr), 2);
                //
                if (FL_VerticalLoad == 0)
                {
                    FL_LateralFriction = 0;
                    FL_LongitudinalFriction = 0;
                    FL_LateralSlipSpeed = 0;//
                    FL_LongitudinalSlipSpeed = 0;//
                }
                else
                {
                    FL_LateralFriction = Math.Round(FL_LateralLoad / FL_VerticalLoad, 5);
                    FL_LongitudinalFriction = Math.Round(FL_LongitudinalLoad / FL_VerticalLoad, 5);
                    FL_LateralSlipSpeed = Math.Round(helper.ReadMemory<float>(FL_LateralSlipSpeed_TargetAddr), 3);//
                    FL_LongitudinalSlipSpeed = Math.Round(helper.ReadMemory<float>(FL_LongitudinalSlipSpeed_TargetAddr), 3);//
                }
                FL_TotalFriction = Math.Round(Math.Sqrt(Math.Pow(FL_LateralFriction, 2) + Math.Pow(FL_LongitudinalFriction, 2)), 5);//
                if (FL_LateralFriction > 0)
                {
                    if (FL_LongitudinalFriction > 0)
                    {
                        // FL_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(FL_LongitudinalFriction) / Math.Abs(FL_LateralFriction)) * radToDeg), 2);// Opposite
                        FL_TotalFrictionAngle = Math.Round(90 - (Math.Atan(FL_LongitudinalFriction / FL_LateralFriction) * radToDeg), 2);
                    }
                    else if (FL_LongitudinalFriction < 0)
                    {
                        //FL_TotalFrictionAngle = Math.Round(90 - (Math.Atan(Math.Abs(FL_LongitudinalFriction) / Math.Abs(FL_LateralFriction)) * radToDeg), 2);// Opposite
                        //FL_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(FL_LongitudinalFriction) / FL_LateralFriction) * radToDeg), 2);//Same as below
                        FL_TotalFrictionAngle = Math.Round(90 - (Math.Atan(FL_LongitudinalFriction / FL_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        FL_TotalFrictionAngle = 90;
                    }
                }
                else if (FL_LateralFriction < 0)
                {
                    if (FL_LongitudinalFriction > 0)
                    {
                        //FL_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(FL_LongitudinalFriction) / Math.Abs(FL_LateralFriction)) * radToDeg), 2);// Opposite
                        //FL_TotalFrictionAngle = Math.Round(270 + (Math.Atan(FL_LongitudinalFriction / Math.Abs(FL_LateralFriction)) * radToDeg), 2);//Same as below
                        FL_TotalFrictionAngle = Math.Round(270 + (Math.Atan(FL_LongitudinalFriction / Math.Abs(FL_LateralFriction)) * radToDeg), 2);
                    }
                    else if (FL_LongitudinalFriction < 0)
                    {
                        //FL_TotalFrictionAngle = Math.Round(270 + (Math.Atan(Math.Abs(FL_LongitudinalFriction) / Math.Abs(FL_LateralFriction)) * radToDeg), 2);// Opposite
                        //FL_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(FL_LongitudinalFriction) / Math.Abs(FL_LateralFriction)) * radToDeg), 2);//Same as below
                        FL_TotalFrictionAngle = Math.Round(270 - (Math.Atan(FL_LongitudinalFriction / FL_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        FL_TotalFrictionAngle = 270;// G-Force
                    }
                }
                else
                {
                    if (FL_LongitudinalFriction > 0)
                    {
                        FL_TotalFrictionAngle = 360;
                    }
                    else if (FL_LongitudinalFriction < 0)
                    {
                        FL_TotalFrictionAngle = 180;
                    }
                    else
                    {
                        FL_TotalFrictionAngle = 0;
                    }
                }

                FL_CamberAngleRad = Math.Round(helper.ReadMemory<float>(FL_CamberAngleRad_TargetAddr), 5);//
                FL_SteerAngleRad = Math.Round(helper.ReadMemory<float>(FL_TireSteerAngleRad_TargetAddr), 5);//
                FL_CamberAngleDeg = Math.Round(FL_CamberAngleRad * radToDeg, 2);//
                FL_SteerAngleDeg = Math.Round(FL_SteerAngleRad * radToDeg, 2);//

                FL_MomentOfInertia = Math.Round(helper.ReadMemory<float>(FL_MomentOfInertia_TargetAddr), 3);//
                FL_TireMass = Math.Round(helper.ReadMemory<float>(FL_TireMass_TargetAddr), 3);//
                FL_TireRadius = Math.Round(helper.ReadMemory<float>(FL_TireRadius_TargetAddr), 3);//
                FL_TireWidth = Math.Round(helper.ReadMemory<float>(FL_TireWidth_TargetAddr), 3);//
                FL_TireSpringRate = Math.Round(helper.ReadMemory<float>(FL_TireSpringRate_TargetAddr), 3);//
                FL_TireDamperRate = Math.Round(helper.ReadMemory<float>(FL_TireDamperRate_TargetAddr), 3);//
                FL_TireMaxDeflection = Math.Round(helper.ReadMemory<float>(FL_TireMaxDeflection_TargetAddr), 2);//
                FL_ThermalAirTransfer = Math.Round(helper.ReadMemory<float>(FL_ThermalAirTransfer_TargetAddr), 3);//
                FL_ThermalInnerTransfer = Math.Round(helper.ReadMemory<float>(FL_ThermalInnerTransfer_TargetAddr), 3);//

                FL_SuspensionLength = Math.Round(helper.ReadMemory<float>(FL_SuspensionLenght_TargetAddr), 4);
                FL_SuspensionVelocity = Math.Round(helper.ReadMemory<float>(FL_SuspensionVelocity_TargetAddr), 4);
                /*

                 */

                //Font Right
                FR_AngularVelocity = Math.Round(helper.ReadMemory<float>(FR_AngularVelocity_TargetAddr), 2);
                FR_VerticalDeflection = Math.Round(helper.ReadMemory<float>(FR_Deflection_TargetAddr), 5);
                FR_LoadedRadius = Math.Round(helper.ReadMemory<float>(FR_LoadedRadius_TargetAddr), 5);
                FR_EffectiveRadius = Math.Round(helper.ReadMemory<float>(FR_EffectiveRadius_TargetAddr), 5);
                FR_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(FR_CurrentContactBrakeTorque_TargetAddr), 2);
                FR_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(FR_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                FR_VerticalLoad = Math.Round(helper.ReadMemory<float>(FR_VerticalLoad_TargetAddr), 2);
                FR_LateralLoad = Math.Round(helper.ReadMemory<float>(FR_LateralLoad_TargetAddr), 2);
                FR_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(FR_LongitudinalLoad_TargetAddr), 2);
                FR_SlipAngleRad = Math.Round(helper.ReadMemory<float>(FR_SlipAngleRad_TargetAddr), 5);
                FR_SlipAngleDeg = Math.Round(FR_SlipAngleRad * radToDeg, 2);
                FR_SlipRatio = Math.Round(helper.ReadMemory<float>(FR_SlipRatio_TargetAddr), 5);
                FR_ContactLength = Math.Round(helper.ReadMemory<float>(FR_ContactLength_TargetAddr), 2);
                FR_TravelSpeed = Math.Round(helper.ReadMemory<float>(FR_TravelSpeed_TargetAddr), 2);
                if (FR_VerticalLoad == 0)
                {
                    FR_LateralFriction = 0;
                    FR_LongitudinalFriction = 0;
                    FR_LateralSlipSpeed = 0;//
                    FR_LongitudinalSlipSpeed = 0;//
                }
                else
                {
                    FR_LateralFriction = Math.Round(FR_LateralLoad / FR_VerticalLoad, 5);
                    FR_LongitudinalFriction = Math.Round(FR_LongitudinalLoad / FR_VerticalLoad, 5);
                    FR_LateralSlipSpeed = Math.Round(helper.ReadMemory<float>(FR_LateralSlipSpeed_TargetAddr), 3);//
                    FR_LongitudinalSlipSpeed = Math.Round(helper.ReadMemory<float>(FR_LongitudinalSlipSpeed_TargetAddr), 3);//
                }
                FR_TotalFriction = Math.Round(Math.Sqrt(Math.Pow(FR_LateralFriction, 2) + Math.Pow(FR_LongitudinalFriction, 2)), 5);//
                if (FR_LateralFriction > 0)
                {
                    if (FR_LongitudinalFriction > 0)
                    {
                        // FR_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(FR_LongitudinalFriction) / Math.Abs(FR_LateralFriction)) * radToDeg), 2);// Opposite
                        FR_TotalFrictionAngle = Math.Round(90 - (Math.Atan(FR_LongitudinalFriction / FR_LateralFriction) * radToDeg), 2);
                    }
                    else if (FR_LongitudinalFriction < 0)
                    {
                        //FR_TotalFrictionAngle = Math.Round(90 - (Math.Atan(Math.Abs(FR_LongitudinalFriction) / Math.Abs(FR_LateralFriction)) * radToDeg), 2);// Opposite
                        //FR_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(FR_LongitudinalFriction) / FR_LateralFriction) * radToDeg), 2);//Same as below
                        FR_TotalFrictionAngle = Math.Round(90 - (Math.Atan(FR_LongitudinalFriction / FR_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        FR_TotalFrictionAngle = 90;
                    }
                }
                else if (FR_LateralFriction < 0)
                {
                    if (FR_LongitudinalFriction > 0)
                    {
                        //FR_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(FR_LongitudinalFriction) / Math.Abs(FR_LateralFriction)) * radToDeg), 2);// Opposite
                        //FR_TotalFrictionAngle = Math.Round(270 + (Math.Atan(FR_LongitudinalFriction / Math.Abs(FR_LateralFriction)) * radToDeg), 2);//Same as below
                        FR_TotalFrictionAngle = Math.Round(270 + (Math.Atan(FR_LongitudinalFriction / Math.Abs(FR_LateralFriction)) * radToDeg), 2);
                    }
                    else if (FR_LongitudinalFriction < 0)
                    {
                        //FR_TotalFrictionAngle = Math.Round(270 + (Math.Atan(Math.Abs(FR_LongitudinalFriction) / Math.Abs(FR_LateralFriction)) * radToDeg), 2);// Opposite
                        //FR_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(FR_LongitudinalFriction) / Math.Abs(FR_LateralFriction)) * radToDeg), 2);//Same as below
                        FR_TotalFrictionAngle = Math.Round(270 - (Math.Atan(FR_LongitudinalFriction / FR_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        FR_TotalFrictionAngle = 270;// G-Force
                    }
                }
                else
                {
                    if (FR_LongitudinalFriction > 0)
                    {
                        FR_TotalFrictionAngle = 360;
                    }
                    else if (FR_LongitudinalFriction < 0)
                    {
                        FR_TotalFrictionAngle = 180;
                    }
                    else
                    {
                        FR_TotalFrictionAngle = 0;
                    }
                }
                FR_MomentOfInertia = Math.Round(helper.ReadMemory<float>(FR_MomentOfInertia_TargetAddr), 3);//
                FR_CamberAngleRad = Math.Round(helper.ReadMemory<float>(FR_CamberAngleRad_TargetAddr), 5);//
                FR_SteerAngleRad = Math.Round(helper.ReadMemory<float>(FR_TireSteerAngleRad_TargetAddr), 5);//
                FR_CamberAngleDeg = Math.Round(FR_CamberAngleRad * radToDeg, 2);//
                FR_SteerAngleDeg = Math.Round(FR_SteerAngleRad * radToDeg, 2);//
                FR_TireMass = Math.Round(helper.ReadMemory<float>(FR_TireMass_TargetAddr), 3);//
                FR_TireRadius = Math.Round(helper.ReadMemory<float>(FR_TireRadius_TargetAddr), 3);//
                FR_TireWidth = Math.Round(helper.ReadMemory<float>(FR_TireWidth_TargetAddr), 3);//
                FR_TireSpringRate = Math.Round(helper.ReadMemory<float>(FR_TireSpringRate_TargetAddr), 3);//
                FR_TireDamperRate = Math.Round(helper.ReadMemory<float>(FR_TireDamperRate_TargetAddr), 3);//
                FR_TireMaxDeflection = Math.Round(helper.ReadMemory<float>(FR_TireMaxDeflection_TargetAddr), 2);//
                FR_ThermalAirTransfer = Math.Round(helper.ReadMemory<float>(FR_ThermalAirTransfer_TargetAddr), 3);//
                FR_ThermalInnerTransfer = Math.Round(helper.ReadMemory<float>(FR_ThermalInnerTransfer_TargetAddr), 3);//

                FR_SuspensionLength = Math.Round(helper.ReadMemory<float>(FR_SuspensionLenght_TargetAddr), 4);
                FR_SuspensionVelocity = Math.Round(helper.ReadMemory<float>(FR_SuspensionVelocity_TargetAddr), 4);
                /*
                 
                 */

                //Rear Left
                RL_AngularVelocity = Math.Round(helper.ReadMemory<float>(RL_AngularVelocity_TargetAddr), 2);
                RL_VerticalDeflection = Math.Round(helper.ReadMemory<float>(RL_Deflection_TargetAddr), 5);
                RL_LoadedRadius = Math.Round(helper.ReadMemory<float>(RL_LoadedRadius_TargetAddr), 5);
                RL_EffectiveRadius = Math.Round(helper.ReadMemory<float>(RL_EffectiveRadius_TargetAddr), 5);
                RL_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(RL_CurrentContactBrakeTorque_TargetAddr), 2);
                RL_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(RL_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                RL_VerticalLoad = Math.Round(helper.ReadMemory<float>(RL_VerticalLoad_TargetAddr), 2);
                RL_LateralLoad = Math.Round(helper.ReadMemory<float>(RL_LateralLoad_TargetAddr), 2);
                RL_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(RL_LongitudinalLoad_TargetAddr), 2);
                RL_SlipAngleRad = Math.Round(helper.ReadMemory<float>(RL_SlipAngleRad_TargetAddr), 5);
                RL_SlipAngleDeg = Math.Round(RL_SlipAngleRad * radToDeg, 2);
                RL_SlipRatio = Math.Round(helper.ReadMemory<float>(RL_SlipRatio_TargetAddr), 5);
                RL_ContactLength = Math.Round(helper.ReadMemory<float>(RL_ContactLength_TargetAddr), 2);
                RL_TravelSpeed = Math.Round(helper.ReadMemory<float>(RL_TravelSpeed_TargetAddr), 2);
                if (RL_VerticalLoad == 0)
                {
                    RL_LateralFriction = 0;
                    RL_LongitudinalFriction = 0;
                    RL_LateralSlipSpeed = 0;//
                    RL_LongitudinalSlipSpeed = 0;//
                }
                else
                {
                    RL_LateralFriction = Math.Round(RL_LateralLoad / RL_VerticalLoad, 5);
                    RL_LongitudinalFriction = Math.Round(RL_LongitudinalLoad / RL_VerticalLoad, 5);
                    RL_LateralSlipSpeed = Math.Round(helper.ReadMemory<float>(RL_LateralSlipSpeed_TargetAddr), 3);//
                    RL_LongitudinalSlipSpeed = Math.Round(helper.ReadMemory<float>(RL_LongitudinalSlipSpeed_TargetAddr), 3);//
                }
                RL_TotalFriction = Math.Round(Math.Sqrt(Math.Pow(RL_LateralFriction, 2) + Math.Pow(RL_LongitudinalFriction, 2)), 5);//
                if (RL_LateralFriction > 0)
                {
                    if (RL_LongitudinalFriction > 0)
                    {
                        // RL_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(RL_LongitudinalFriction) / Math.Abs(RL_LateralFriction)) * radToDeg), 2);// Opposite
                        RL_TotalFrictionAngle = Math.Round(90 - (Math.Atan(RL_LongitudinalFriction / RL_LateralFriction) * radToDeg), 2);
                    }
                    else if (RL_LongitudinalFriction < 0)
                    {
                        //RL_TotalFrictionAngle = Math.Round(90 - (Math.Atan(Math.Abs(RL_LongitudinalFriction) / Math.Abs(RL_LateralFriction)) * radToDeg), 2);// Opposite
                        //RL_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(RL_LongitudinalFriction) / RL_LateralFriction) * radToDeg), 2);//Same as below
                        RL_TotalFrictionAngle = Math.Round(90 - (Math.Atan(RL_LongitudinalFriction / RL_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        RL_TotalFrictionAngle = 90;
                    }
                }
                else if (RL_LateralFriction < 0)
                {
                    if (RL_LongitudinalFriction > 0)
                    {
                        //RL_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(RL_LongitudinalFriction) / Math.Abs(RL_LateralFriction)) * radToDeg), 2);// Opposite
                        //RL_TotalFrictionAngle = Math.Round(270 + (Math.Atan(RL_LongitudinalFriction / Math.Abs(RL_LateralFriction)) * radToDeg), 2);//Same as below
                        RL_TotalFrictionAngle = Math.Round(270 + (Math.Atan(RL_LongitudinalFriction / Math.Abs(RL_LateralFriction)) * radToDeg), 2);
                    }
                    else if (RL_LongitudinalFriction < 0)
                    {
                        //RL_TotalFrictionAngle = Math.Round(270 + (Math.Atan(Math.Abs(RL_LongitudinalFriction) / Math.Abs(RL_LateralFriction)) * radToDeg), 2);// Opposite
                        //RL_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(RL_LongitudinalFriction) / Math.Abs(RL_LateralFriction)) * radToDeg), 2);//Same as below
                        RL_TotalFrictionAngle = Math.Round(270 - (Math.Atan(RL_LongitudinalFriction / RL_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        RL_TotalFrictionAngle = 270;// G-Force
                    }
                }
                else
                {
                    if (RL_LongitudinalFriction > 0)
                    {
                        RL_TotalFrictionAngle = 360;
                    }
                    else if (RL_LongitudinalFriction < 0)
                    {
                        RL_TotalFrictionAngle = 180;
                    }
                    else
                    {
                        RL_TotalFrictionAngle = 0;
                    }
                }
                RL_MomentOfInertia = Math.Round(helper.ReadMemory<float>(RL_MomentOfInertia_TargetAddr), 3);//
                RL_CamberAngleRad = Math.Round(helper.ReadMemory<float>(RL_CamberAngleRad_TargetAddr), 5);//
                RL_SteerAngleRad = Math.Round(helper.ReadMemory<float>(RL_TireSteerAngleRad_TargetAddr), 5);//
                RL_CamberAngleDeg = Math.Round(RL_CamberAngleRad * radToDeg, 2);//
                RL_SteerAngleDeg = Math.Round(RL_SteerAngleRad * radToDeg, 2);//
                RL_TireMass = Math.Round(helper.ReadMemory<float>(RL_TireMass_TargetAddr), 3);//
                RL_TireRadius = Math.Round(helper.ReadMemory<float>(RL_TireRadius_TargetAddr), 3);//
                RL_TireWidth = Math.Round(helper.ReadMemory<float>(RL_TireWidth_TargetAddr), 3);//
                RL_TireSpringRate = Math.Round(helper.ReadMemory<float>(RL_TireSpringRate_TargetAddr), 3);//
                RL_TireDamperRate = Math.Round(helper.ReadMemory<float>(RL_TireDamperRate_TargetAddr), 3);//
                RL_TireMaxDeflection = Math.Round(helper.ReadMemory<float>(RL_TireMaxDeflection_TargetAddr), 2);//
                RL_ThermalAirTransfer = Math.Round(helper.ReadMemory<float>(RL_ThermalAirTransfer_TargetAddr), 3);//
                RL_ThermalInnerTransfer = Math.Round(helper.ReadMemory<float>(RL_ThermalInnerTransfer_TargetAddr), 3);//

                RL_SuspensionLength = Math.Round(helper.ReadMemory<float>(RL_SuspensionLenght_TargetAddr), 4);
                RL_SuspensionVelocity = Math.Round(helper.ReadMemory<float>(RL_SuspensionVelocity_TargetAddr), 4);
                /*
                 
                 */

                //Rear Right
                RR_AngularVelocity = Math.Round(helper.ReadMemory<float>(RR_AngularVelocity_TargetAddr), 2);
                RR_VerticalDeflection = Math.Round(helper.ReadMemory<float>(RR_Deflection_TargetAddr), 5);
                RR_LoadedRadius = Math.Round(helper.ReadMemory<float>(RR_LoadedRadius_TargetAddr), 5);
                RR_EffectiveRadius = Math.Round(helper.ReadMemory<float>(RR_EffectiveRadius_TargetAddr), 5);
                RR_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(RR_CurrentContactBrakeTorque_TargetAddr), 2);
                RR_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(RR_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                RR_VerticalLoad = Math.Round(helper.ReadMemory<float>(RR_VerticalLoad_TargetAddr), 2);
                RR_LateralLoad = Math.Round(helper.ReadMemory<float>(RR_LateralLoad_TargetAddr), 2);
                RR_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(RR_LongitudinalLoad_TargetAddr), 2);
                RR_SlipAngleRad = Math.Round(helper.ReadMemory<float>(RR_SlipAngleRad_TargetAddr), 5);
                RR_SlipAngleDeg = Math.Round(RR_SlipAngleRad * radToDeg, 2);
                RR_SlipRatio = Math.Round(helper.ReadMemory<float>(RR_SlipRatio_TargetAddr), 5);
                RR_ContactLength = Math.Round(helper.ReadMemory<float>(RR_ContactLength_TargetAddr), 2);
                RR_TravelSpeed = Math.Round(helper.ReadMemory<float>(RR_TravelSpeed_TargetAddr), 2);
                RR_LateralFriction = Math.Round(RR_LateralLoad / RR_VerticalLoad, 5);
                if (RR_VerticalLoad == 0)
                {
                    RR_LongitudinalFriction = 0;
                    RR_LateralFriction = 0;
                    RR_LateralSlipSpeed = 0;//
                    RR_LongitudinalSlipSpeed = 0;//
                }
                else
                {
                    RR_LateralFriction = Math.Round(RR_LateralLoad / RR_VerticalLoad, 5);
                    RR_LongitudinalFriction = Math.Round(RR_LongitudinalLoad / RR_VerticalLoad, 5);
                    RR_LateralSlipSpeed = Math.Round(helper.ReadMemory<float>(RR_LateralSlipSpeed_TargetAddr), 3);//
                    RR_LongitudinalSlipSpeed = Math.Round(helper.ReadMemory<float>(RR_LongitudinalSlipSpeed_TargetAddr), 3);//
                }
                RR_TotalFriction = Math.Round(Math.Sqrt(Math.Pow(RR_LateralFriction, 2) + Math.Pow(RR_LongitudinalFriction, 2)), 5);//
                if (RR_LateralFriction > 0)
                {
                    if (RR_LongitudinalFriction > 0)
                    {
                        // RR_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(RR_LongitudinalFriction) / Math.Abs(RR_LateralFriction)) * radToDeg), 2);// Opposite
                        RR_TotalFrictionAngle = Math.Round(90 - (Math.Atan(RR_LongitudinalFriction / RR_LateralFriction) * radToDeg), 2);
                    }
                    else if (RR_LongitudinalFriction < 0)
                    {
                        //RR_TotalFrictionAngle = Math.Round(90 - (Math.Atan(Math.Abs(RR_LongitudinalFriction) / Math.Abs(RR_LateralFriction)) * radToDeg), 2);// Opposite
                        //RR_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(RR_LongitudinalFriction) / RR_LateralFriction) * radToDeg), 2);//Same as below
                        RR_TotalFrictionAngle = Math.Round(90 - (Math.Atan(RR_LongitudinalFriction / RR_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        RR_TotalFrictionAngle = 90;
                    }
                }
                else if (RR_LateralFriction < 0)
                {
                    if (RR_LongitudinalFriction > 0)
                    {
                        //RR_TotalFrictionAngle = Math.Round(90 + (Math.Atan(Math.Abs(RR_LongitudinalFriction) / Math.Abs(RR_LateralFriction)) * radToDeg), 2);// Opposite
                        //RR_TotalFrictionAngle = Math.Round(270 + (Math.Atan(RR_LongitudinalFriction / Math.Abs(RR_LateralFriction)) * radToDeg), 2);//Same as below
                        RR_TotalFrictionAngle = Math.Round(270 + (Math.Atan(RR_LongitudinalFriction / Math.Abs(RR_LateralFriction)) * radToDeg), 2);
                    }
                    else if (RR_LongitudinalFriction < 0)
                    {
                        //RR_TotalFrictionAngle = Math.Round(270 + (Math.Atan(Math.Abs(RR_LongitudinalFriction) / Math.Abs(RR_LateralFriction)) * radToDeg), 2);// Opposite
                        //RR_TotalFrictionAngle = Math.Round(270 - (Math.Atan(Math.Abs(RR_LongitudinalFriction) / Math.Abs(RR_LateralFriction)) * radToDeg), 2);//Same as below
                        RR_TotalFrictionAngle = Math.Round(270 - (Math.Atan(RR_LongitudinalFriction / RR_LateralFriction) * radToDeg), 2);
                    }
                    else
                    {
                        RR_TotalFrictionAngle = 270;
                    }
                }
                else
                {
                    if (RR_LongitudinalFriction > 0)
                    {
                        RR_TotalFrictionAngle = 360;
                    }
                    else if (RR_LongitudinalFriction < 0)
                    {
                        RR_TotalFrictionAngle = 180;
                    }
                    else
                    {
                        RR_TotalFrictionAngle = 0;
                    }
                }
                RR_MomentOfInertia = Math.Round(helper.ReadMemory<float>(RR_MomentOfInertia_TargetAddr), 3);//
                RR_CamberAngleRad = Math.Round(helper.ReadMemory<float>(RR_CamberAngleRad_TargetAddr), 5);//
                RR_SteerAngleRad = Math.Round(helper.ReadMemory<float>(RR_TireSteerAngleRad_TargetAddr), 5);//
                RR_CamberAngleDeg = Math.Round(RR_CamberAngleRad * radToDeg, 2);//
                RR_SteerAngleDeg = Math.Round(RR_SteerAngleRad * radToDeg, 2);//
                RR_TireMass = Math.Round(helper.ReadMemory<float>(RR_TireMass_TargetAddr), 3);//
                RR_TireRadius = Math.Round(helper.ReadMemory<float>(RR_TireRadius_TargetAddr), 3);//
                RR_TireWidth = Math.Round(helper.ReadMemory<float>(RR_TireWidth_TargetAddr), 3);//
                RR_TireSpringRate = Math.Round(helper.ReadMemory<float>(RR_TireSpringRate_TargetAddr), 3);//
                RR_TireDamperRate = Math.Round(helper.ReadMemory<float>(RR_TireDamperRate_TargetAddr), 3);//
                RR_TireMaxDeflection = Math.Round(helper.ReadMemory<float>(RR_TireMaxDeflection_TargetAddr), 2);//
                RR_ThermalAirTransfer = Math.Round(helper.ReadMemory<float>(RR_ThermalAirTransfer_TargetAddr), 3);//
                RR_ThermalInnerTransfer = Math.Round(helper.ReadMemory<float>(RR_ThermalInnerTransfer_TargetAddr), 3);//

                RR_SuspensionLength = Math.Round(helper.ReadMemory<float>(RR_SuspensionLenght_TargetAddr), 4);
                RR_SuspensionVelocity = Math.Round(helper.ReadMemory<float>(RR_SuspensionVelocity_TargetAddr), 4);
                /*
                 
                 */


                //Read Temperatures
                var flsTempHelper = helper.ReadMemory<float>(flsTargetAddr);
                var fliTempHelper = helper.ReadMemory<float>(fliTargetAddr);
                var frsTempHelper = helper.ReadMemory<float>(frsTargetAddr);
                var friTempHelper = helper.ReadMemory<float>(friTargetAddr);
                var rlsTempHelper = helper.ReadMemory<float>(rlsTargetAddr);
                var rliTempHelper = helper.ReadMemory<float>(rliTargetAddr);
                var rrsTempHelper = helper.ReadMemory<float>(rrsTargetAddr);
                var rriTempHelper = helper.ReadMemory<float>(rriTargetAddr);

                /*
                // y = (Ax^3 + Bx^2 + Cx + D) - Temperature correction

                var flsTempFit = ((((flsTempHelper * flsTempHelper * flsTempHelper) * TempCorrectionValueA) + ((flsTempHelper * flsTempHelper) * TempCorrectionValueB) + (flsTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var fliTempFit = ((((fliTempHelper * fliTempHelper * fliTempHelper) * TempCorrectionValueA) + ((fliTempHelper * fliTempHelper) * TempCorrectionValueB) + (fliTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var frsTempFit = ((((frsTempHelper * frsTempHelper * frsTempHelper) * TempCorrectionValueA) + ((frsTempHelper * frsTempHelper) * TempCorrectionValueB) + (frsTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var friTempFit = ((((friTempHelper * friTempHelper * friTempHelper) * TempCorrectionValueA) + ((friTempHelper * friTempHelper) * TempCorrectionValueB) + (friTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var rlsTempFit = ((((rlsTempHelper * rlsTempHelper * rlsTempHelper) * TempCorrectionValueA) + ((rlsTempHelper * rlsTempHelper) * TempCorrectionValueB) + (rlsTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var rliTempFit = ((((rliTempHelper * rliTempHelper * rliTempHelper) * TempCorrectionValueA) + ((rliTempHelper * rliTempHelper) * TempCorrectionValueB) + (rliTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var rrsTempFit = ((((rrsTempHelper * rrsTempHelper * rrsTempHelper) * TempCorrectionValueA) + ((rrsTempHelper * rrsTempHelper) * TempCorrectionValueB) + (rrsTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);
                var rriTempFit = ((((rriTempHelper * rriTempHelper * rriTempHelper) * TempCorrectionValueA) + ((rriTempHelper * rriTempHelper) * TempCorrectionValueB) + (rriTempHelper * TempCorrectionValueC) + TempCorrectionValueD) - TempCorrectionValue);


                

                if (String.IsNullOrEmpty(tempCorrectionA.Text) || String.IsNullOrEmpty(tempCorrectionB.Text) || String.IsNullOrEmpty(tempCorrectionC.Text) || String.IsNullOrEmpty(tempCorrectionD.Text))// If A, B, C & D boxes are empty, use only temperature correction
                {
                    flsTemp = (Convert.ToDouble(flsTempHelper) - TempCorrectionValue);
                    fliTemp = (Convert.ToDouble(fliTempHelper) - TempCorrectionValue);
                    frsTemp = (Convert.ToDouble(frsTempHelper) - TempCorrectionValue);
                    friTemp = (Convert.ToDouble(friTempHelper) - TempCorrectionValue);
                    rlsTemp = (Convert.ToDouble(rlsTempHelper) - TempCorrectionValue);
                    rliTemp = (Convert.ToDouble(rliTempHelper) - TempCorrectionValue);
                    rrsTemp = (Convert.ToDouble(rrsTempHelper) - TempCorrectionValue);
                    rriTemp = (Convert.ToDouble(rriTempHelper) - TempCorrectionValue);
                }

                else// else use formula y = (Ax^3 + Bx^2 + Cx + D) - Temperature correction
                {
                    flsTemp = flsTempFit;
                    fliTemp = fliTempFit;
                    frsTemp = frsTempFit;
                    friTemp = friTempFit;
                    rlsTemp = rlsTempFit;
                    rliTemp = rliTempFit;
                    rrsTemp = rrsTempFit;
                    rriTemp = rriTempFit;
                }
                */
                FL_TreadTemperature = Convert.ToDouble(flsTempHelper);
                FL_InnerTemperature = Convert.ToDouble(fliTempHelper);
                FR_TreadTemperature = Convert.ToDouble(frsTempHelper);
                FR_InnerTemperature = Convert.ToDouble(friTempHelper);
                RL_TreadTemperature = Convert.ToDouble(rlsTempHelper);
                RL_InnerTemperature = Convert.ToDouble(rliTempHelper);
                RR_TreadTemperature = Convert.ToDouble(rrsTempHelper);
                RR_InnerTemperature = Convert.ToDouble(rriTempHelper);


                


                CheckWhatToLogInFile();

                if (logging == true)
                {
                    // SA, SR, Speed and Vertical Load filters for logging

                    if (FiltersOn == true)
                    {
                        if ((FL_SlipRatio <= (0 + FormLogSettings.Z1) && FL_SlipRatio >= (0 - FormLogSettings.Z1))
                            && (FL_SlipAngleDeg <= (0 + FormLogSettings.Z2) && FL_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                            && (FL_TravelSpeed >= (0 + FormLogSettings.Z3) || FL_TravelSpeed <= (0 - FormLogSettings.Z3))
                            && (FL_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && FL_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                        {
                            FLLogFileWriter();
                        }
                        if ((FR_SlipRatio <= (0 + FormLogSettings.Z1) && FR_SlipRatio >= (0 - FormLogSettings.Z1))
                            && (FR_SlipAngleDeg <= (0 + FormLogSettings.Z2) && FR_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                            && (FR_TravelSpeed >= (0 + FormLogSettings.Z3) || FR_TravelSpeed <= (0 - FormLogSettings.Z3))
                            && (FR_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && FR_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                        {
                            FRLogFileWriter();
                        }
                        if ((RL_SlipRatio <= (0 + FormLogSettings.Z1) && RL_SlipRatio >= (0 - FormLogSettings.Z1))
                            && (RL_SlipAngleDeg <= (0 + FormLogSettings.Z2) && RL_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                            && (RL_TravelSpeed >= (0 + FormLogSettings.Z3) || RL_TravelSpeed <= (0 - FormLogSettings.Z3))
                            && (RL_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && RL_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
                        {
                            RLLogFileWriter();
                        }
                        if ((RR_SlipRatio <= (0 + FormLogSettings.Z1) && RR_SlipRatio >= (0 - FormLogSettings.Z1))
                            && (RR_SlipAngleDeg <= (0 + FormLogSettings.Z2) && RR_SlipAngleDeg >= (0 - FormLogSettings.Z2))
                            && (RR_TravelSpeed >= (0 + FormLogSettings.Z3) || RR_TravelSpeed <= (0 - FormLogSettings.Z3))
                            && (RR_VerticalLoad <= (FormLogSettings.W4 + FormLogSettings.Z4) && RR_VerticalLoad >= (FormLogSettings.W4 - FormLogSettings.Z4)))
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

                /*if (temperaturesFL.IsHandleCreated)
                {*/
                this.Invoke((MethodInvoker)delegate { UpdateFormData(); });
                /*}
                else
                {
                    //....
                }*/
                Thread.Sleep(sleep);
            }
        }
        private void CheckWhatToLogInFile()
        {
            if (/*Settings1.*/
                TireTravelSpeedLogEnabled == true)
            {
                Header0 = /*Settings1.*/sTireTravelSpeed + FormLogSettings.Delimiter;
                flParameter0 = FL_TravelSpeed.ToString() + FormLogSettings.Delimiter;
                frParameter0 = FR_TravelSpeed.ToString() + FormLogSettings.Delimiter;
                rlParameter0 = RL_TravelSpeed.ToString() + FormLogSettings.Delimiter;
                rrParameter0 = RR_TravelSpeed.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header0 = "";
                flParameter0 = "";
                frParameter0 = "";
                rlParameter0 = "";
                rrParameter0 = "";
            }
            if (/*Settings1.*/AngularVelocityLogEnabled == true)
            {
                Header1 = /*Settings1.*/sAngularVelocity + FormLogSettings.Delimiter;
                flParameter1 = FL_AngularVelocity.ToString() + FormLogSettings.Delimiter;
                frParameter1 = FR_AngularVelocity.ToString() + FormLogSettings.Delimiter;
                rlParameter1 = RL_AngularVelocity.ToString() + FormLogSettings.Delimiter;
                rrParameter1 = RR_AngularVelocity.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header1 = "";
                flParameter1 = "";
                frParameter1 = "";
                rlParameter1 = "";
                rrParameter1 = "";
            }
            if (/*Settings1.*/VerticalLoadLogEnabled == true)
            {
                Header2 = /*Settings1.*/sVerticalLoad + FormLogSettings.Delimiter;
                flParameter2 = FL_VerticalLoad.ToString() + FormLogSettings.Delimiter;
                frParameter2 = FR_VerticalLoad.ToString() + FormLogSettings.Delimiter;
                rlParameter2 = RL_VerticalLoad.ToString() + FormLogSettings.Delimiter;
                rrParameter2 = RR_VerticalLoad.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header2 = "";
                flParameter2 = "";
                frParameter2 = "";
                rlParameter2 = "";
                rrParameter2 = "";
            }
            if (/*Settings1.*/VerticalDeflectionLogEnabled == true)
            {
                Header3 = /*Settings1.*/sVerticalDeflection + FormLogSettings.Delimiter;
                flParameter3 = FL_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
                frParameter3 = FR_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
                rlParameter3 = RL_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
                rrParameter3 = RR_VerticalDeflection.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header3 = "";
                flParameter3 = "";
                frParameter3 = "";
                rlParameter3 = "";
                rrParameter3 = "";
            }
            if (/*Settings1.*/LoadedRadiusLogEnabled == true)
            {
                Header4 = /*Settings1.*/sLoadedRadius + FormLogSettings.Delimiter;
                flParameter4 = FL_LoadedRadius.ToString() + FormLogSettings.Delimiter;
                frParameter4 = FR_LoadedRadius.ToString() + FormLogSettings.Delimiter;
                rlParameter4 = RL_LoadedRadius.ToString() + FormLogSettings.Delimiter;
                rrParameter4 = RR_LoadedRadius.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header4 = "";
                flParameter4 = "";
                frParameter4 = "";
                rlParameter4 = "";
                rrParameter4 = "";
            }
            if (/*Settings1.*/EffectiveRadiusLogEnabled == true)
            {
                Header5 = /*Settings1.*/sEffectiveRadius + FormLogSettings.Delimiter;
                flParameter5 = FL_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
                frParameter5 = FR_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
                rlParameter5 = RL_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
                rrParameter5 = RR_EffectiveRadius.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header5 = "";
                flParameter5 = "";
                frParameter5 = "";
                rlParameter5 = "";
                rrParameter5 = "";
            }
            if (/*Settings1.*/ContactLengthLogEnabled == true)
            {
                Header6 = /*Settings1.*/sContactLength + FormLogSettings.Delimiter;
                flParameter6 = FL_ContactLength.ToString() + FormLogSettings.Delimiter;
                frParameter6 = FR_ContactLength.ToString() + FormLogSettings.Delimiter;
                rlParameter6 = RL_ContactLength.ToString() + FormLogSettings.Delimiter;
                rrParameter6 = RR_ContactLength.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header6 = "";
                flParameter6 = "";
                frParameter6 = "";
                rlParameter6 = "";
                rrParameter6 = "";
            }
            if (/*Settings1.*/BrakeTorqueLogEnabled == true)
            {
                Header7 = /*Settings1.*/sBrakeTorque + FormLogSettings.Delimiter;
                flParameter7 = FL_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;
                frParameter7 = FR_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;
                rlParameter7 = RL_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;
                rrParameter7 = RR_CurrentContactBrakeTorque.ToString() + FormLogSettings.Delimiter;

                Header7_1 = /*Settings1.*/sMaxBrakeTorque + FormLogSettings.Delimiter;
                flParameter7_1 = FL_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
                frParameter7_1 = FR_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
                rlParameter7_1 = RL_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
                rrParameter7_1 = RR_CurrentContactBrakeTorqueMax.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header7 = "";
                flParameter7 = "";
                frParameter7 = "";
                rlParameter7 = "";
                rrParameter7 = "";

                Header7_1 = "";
                flParameter7_1 = "";
                frParameter7_1 = "";
                rlParameter7_1 = "";
                rrParameter7_1 = "";
            }
            if (/*Settings1.*/SteerAngleLogEnabled == true)
            {
                Header8 = /*Settings1.*/sSteerAngle + FormLogSettings.Delimiter;
                flParameter8 = FL_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
                frParameter8 = FR_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
                rlParameter8 = RL_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
                rrParameter8 = RR_SteerAngleDeg.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header8 = "";
                flParameter8 = "";
                frParameter8 = "";
                rlParameter8 = "";
                rrParameter8 = "";
            }
            if (/*Settings1.*/CamberAngleLogEnabled == true)
            {
                Header9 = /*Settings1.*/sCamberAngle + FormLogSettings.Delimiter;
                flParameter9 = FL_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
                frParameter9 = FR_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
                rlParameter9 = RL_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
                rrParameter9 = RR_CamberAngleDeg.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header9 = "";
                flParameter9 = "";
                frParameter9 = "";
                rlParameter9 = "";
                rrParameter9 = "";
            }
            if (/*Settings1.*/LateralLoadLogEnabled == true)
            {
                Header10 = /*Settings1.*/sLateralLoad + FormLogSettings.Delimiter;
                flParameter10 = FL_LateralLoad.ToString() + FormLogSettings.Delimiter;
                frParameter10 = FR_LateralLoad.ToString() + FormLogSettings.Delimiter;
                rlParameter10 = RL_LateralLoad.ToString() + FormLogSettings.Delimiter;
                rrParameter10 = RR_LateralLoad.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header10 = "";
                flParameter10 = "";
                frParameter10 = "";
                rlParameter10 = "";
                rrParameter10 = "";
            }
            if (/*Settings1.*/SlipAngleLogEnabled == true)
            {
                Header11 = /*Settings1.*/sSlipAngle + FormLogSettings.Delimiter;
                flParameter11 = FL_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
                frParameter11 = FR_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
                rlParameter11 = RL_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
                rrParameter11 = RR_SlipAngleDeg.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header11 = "";
                flParameter11 = "";
                frParameter11 = "";
                rlParameter11 = "";
                rrParameter11 = "";
            }
            if (/*Settings1.*/LateralFrictionLogEnabled == true)
            {
                Header12 = /*Settings1.*/sLateralFriction + FormLogSettings.Delimiter;
                flParameter12 = FL_LateralFriction.ToString() + FormLogSettings.Delimiter;
                frParameter12 = FR_LateralFriction.ToString() + FormLogSettings.Delimiter;
                rlParameter12 = RL_LateralFriction.ToString() + FormLogSettings.Delimiter;
                rrParameter12 = RR_LateralFriction.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header12 = "";
                flParameter12 = "";
                frParameter12 = "";
                rlParameter12 = "";
                rrParameter12 = "";
            }
            if (/*Settings1.*/LateralSlipSpeedLogEnabled == true)
            {
                Header13 = /*Settings1.*/sLateralSlipSpeed + FormLogSettings.Delimiter;
                flParameter13 = FL_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
                frParameter13 = FR_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
                rlParameter13 = RL_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
                rrParameter13 = RR_LateralSlipSpeed.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header13 = "";
                flParameter13 = "";
                frParameter13 = "";
                rlParameter13 = "";
                rrParameter13 = "";
            }
            if (/*Settings1.*/LongitudinalLoadLogEnabled == true)
            {
                Header14 = /*Settings1.*/sLongitudinalLoad + FormLogSettings.Delimiter;
                flParameter14 = FL_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
                frParameter14 = FR_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
                rlParameter14 = RL_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
                rrParameter14 = RR_LongitudinalLoad.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header14 = "";
                flParameter14 = "";
                frParameter14 = "";
                rlParameter14 = "";
                rrParameter14 = "";
            }
            if (/*Settings1.*/SlipRatioLogEnabled == true)
            {
                Header15 = /*Settings1.*/sSlipRatio + FormLogSettings.Delimiter;
                flParameter15 = FL_SlipRatio.ToString() + FormLogSettings.Delimiter;
                frParameter15 = FR_SlipRatio.ToString() + FormLogSettings.Delimiter;
                rlParameter15 = RL_SlipRatio.ToString() + FormLogSettings.Delimiter;
                rrParameter15 = RR_SlipRatio.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header15 = "";
                flParameter15 = "";
                frParameter15 = "";
                rlParameter15 = "";
                rrParameter15 = "";
            }
            if (/*Settings1.*/LongitudinalFrictionLogEnabled == true)
            {
                Header16 = /*Settings1.*/sLongitudinalFriction + FormLogSettings.Delimiter;
                flParameter16 = FL_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
                frParameter16 = FR_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
                rlParameter16 = RL_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
                rrParameter16 = RR_LongitudinalFriction.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header16 = "";
                flParameter16 = "";
                frParameter16 = "";
                rlParameter16 = "";
                rrParameter16 = "";
            }
            if (/*Settings1.*/LongitudinalSlipSpeedLogEnabled == true)
            {
                Header17 = /*Settings1.*/sLongitudinalSlipSpeed + FormLogSettings.Delimiter;
                flParameter17 = FL_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
                frParameter17 = FR_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
                rlParameter17 = RL_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
                rrParameter17 = RR_LongitudinalSlipSpeed.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header17 = "";
                flParameter17 = "";
                frParameter17 = "";
                rlParameter17 = "";
                rrParameter17 = "";
            }
            if (/*Settings1.*/TreadTemperatureLogEnabled == true)
            {
                Header18 = /*Settings1.*/sTreadTemperature + FormLogSettings.Delimiter;
                flParameter18 = FL_TreadTemperature.ToString() + FormLogSettings.Delimiter;
                frParameter18 = FR_TreadTemperature.ToString() + FormLogSettings.Delimiter;
                rlParameter18 = RL_TreadTemperature.ToString() + FormLogSettings.Delimiter;
                rrParameter18 = RR_TreadTemperature.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header18 = "";
                flParameter18 = "";
                frParameter18 = "";
                rlParameter18 = "";
                rrParameter18 = "";
            }
            if (/*Settings1.*/InnerTemperatureLogEnabled == true)
            {
                Header19 = /*Settings1.*/sInnerTemperature + FormLogSettings.Delimiter;
                flParameter19 = FL_InnerTemperature.ToString() + FormLogSettings.Delimiter;
                frParameter19 = FR_InnerTemperature.ToString() + FormLogSettings.Delimiter;
                rlParameter19 = RL_InnerTemperature.ToString() + FormLogSettings.Delimiter;
                rrParameter19 = RR_InnerTemperature.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header19 = "";
                flParameter19 = "";
                frParameter19 = "";
                rlParameter19 = "";
                rrParameter19 = "";
            }
            if (/*Settings1.*/RaceTimeLogEnabled == true)
            {
                Header20 = /*Settings1.*/sRaceTime + FormLogSettings.Delimiter;
                flParameter20 = RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
                frParameter20 = RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
                rlParameter20 = RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
                rrParameter20 = RaceTime.ToString().ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header20 = "";
                flParameter20 = "";
                frParameter20 = "";
                rlParameter20 = "";
                rrParameter20 = "";
            }
            if (/*Settings1.*/TotalFrictionLogEnabled == true)
            {
                Header21 = /*Settings1.*/sTotalFriction + FormLogSettings.Delimiter;
                flParameter21 = FL_TotalFriction.ToString() + FormLogSettings.Delimiter;
                frParameter21 = FR_TotalFriction.ToString() + FormLogSettings.Delimiter;
                rlParameter21 = RL_TotalFriction.ToString() + FormLogSettings.Delimiter;
                rrParameter21 = RR_TotalFriction.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header21 = "";
                flParameter21 = "";
                frParameter21 = "";
                rlParameter21 = "";
                rrParameter21 = "";
            }
            if (/*Settings1.*/TotalFrictionAngleLogEnabled == true)
            {
                Header22 = /*Settings1.*/sTotalFrictionAngle + FormLogSettings.Delimiter;
                flParameter22 = FL_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
                frParameter22 = FR_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
                rlParameter22 = RL_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
                rrParameter22 = RR_TotalFrictionAngle.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header22 = "";
                flParameter22 = "";
                frParameter22 = "";
                rlParameter22 = "";
                rrParameter22 = "";
            }
            if (/*Settings1.*/SuspensionLengthLogEnabled == true)
            {
                Header23 = /*Settings1.*/sSuspensionLength + FormLogSettings.Delimiter;
                flParameter23 = FL_SuspensionLength.ToString() + FormLogSettings.Delimiter;
                frParameter23 = FR_SuspensionLength.ToString() + FormLogSettings.Delimiter;
                rlParameter23 = RL_SuspensionLength.ToString() + FormLogSettings.Delimiter;
                rrParameter23 = RR_SuspensionLength.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header23 = "";
                flParameter23 = "";
                frParameter23 = "";
                rlParameter23 = "";
                rrParameter23 = "";
            }
            if (/*Settings1.*/SuspensionVelocityLogEnabled == true)
            {
                Header24 = /*Settings1.*/sSuspensionVelocity + FormLogSettings.Delimiter;
                flParameter24 = FL_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
                frParameter24 = FR_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
                rlParameter24 = RL_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
                rrParameter24 = RR_SuspensionVelocity.ToString() + FormLogSettings.Delimiter;
            }
            else
            {
                Header24 = "";
                flParameter24 = "";
                frParameter24 = "";
                rlParameter24 = "";
                rrParameter24 = "";
            }
        }
        private string WriteHeaderLine()
        {
            return Header20 + Header0 + Header1 + Header2 + Header3 + Header4 + Header5 + Header6 + Header7 + Header7_1 + Header8 + Header9 + Header10 + Header11 + Header12 + Header13 + Header14 + Header15 + Header16 + Header17 + Header18 + Header19 + Header21 + Header22 + Header23 + Header24;
        }
        private void WriteFLHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogFileSaveLocationFolder + "FrontLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteFRHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogFileSaveLocationFolder + "FrontRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteRLHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogFileSaveLocationFolder + "RearLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteRRHeadersLine()
        {
            using (StreamWriter sw = File.CreateText(LogFileSaveLocationFolder + "RearRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(WriteHeaderLine());
            }
        }
        private void WriteFLParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogFileSaveLocationFolder + "FrontLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(flParameter20 + flParameter0 + flParameter1 + flParameter2 + flParameter3 + flParameter4 + flParameter5 + flParameter6 + flParameter7 + flParameter7_1 + flParameter8 + flParameter9 + flParameter10 + flParameter11 + flParameter12 + flParameter13 + flParameter14 + flParameter15 + flParameter16 + flParameter17 + flParameter18 + flParameter19 + flParameter21 + flParameter22 + flParameter23 + flParameter24);
            }
        }
        private void WriteFRParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogFileSaveLocationFolder + "FrontRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(frParameter20 + frParameter0 + frParameter1 + frParameter2 + frParameter3 + frParameter4 + frParameter5 + frParameter6 + frParameter7 + frParameter7_1 + frParameter8 + frParameter9 + frParameter10 + frParameter11 + frParameter12 + frParameter13 + frParameter14 + frParameter15 + frParameter16 + frParameter17 + frParameter18 + frParameter19 + frParameter21 + frParameter22 + frParameter23 + frParameter24);
            }
        }
        private void WriteRLParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogFileSaveLocationFolder + "RearLeftWreckfestDebugLog.txt"))
            {
                sw.WriteLine(rlParameter20 + rlParameter0 + rlParameter1 + rlParameter2 + rlParameter3 + rlParameter4 + rlParameter5 + rlParameter6 + rlParameter7 + rlParameter7_1 + rlParameter8 + rlParameter9 + rlParameter10 + rlParameter11 + rlParameter12 + rlParameter13 + rlParameter14 + rlParameter15 + rlParameter16 + rlParameter17 + rlParameter18 + rlParameter19 + rlParameter21 + rlParameter22 + rlParameter23 + rlParameter24);
            }
        }
        private void WriteRRParametersLine()
        {
            using (StreamWriter sw = File.AppendText(LogFileSaveLocationFolder + "RearRightWreckfestDebugLog.txt"))
            {
                sw.WriteLine(rrParameter20 + rrParameter0 + rrParameter1 + rrParameter2 + rrParameter3 + rrParameter4 + rrParameter5 + rrParameter6 + rrParameter7 + rrParameter7_1 + rrParameter8 + rrParameter9 + rrParameter10 + rrParameter11 + rrParameter12 + rrParameter13 + rrParameter14 + rrParameter15 + rrParameter16 + rrParameter17 + rrParameter18 + rrParameter19 + rrParameter21 + rrParameter22 + rrParameter23 + rrParameter24);
            }
        }
        private void FLLogFileWriter()
        {
            if (!File.Exists(LogFileSaveLocationFolder + "FrontLeftWreckfestDebugLog.txt"))
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
            if (!File.Exists(LogFileSaveLocationFolder + "FrontRightWreckfestDebugLog.txt"))
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
            if (!File.Exists(LogFileSaveLocationFolder + "RearLeftWreckfestDebugLog.txt"))
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
            if (!File.Exists(LogFileSaveLocationFolder + "RearRightWreckfestDebugLog.txt"))
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
            if (SettingsOpen == false && logging == false)
            {
                toLogSettingsButton.Visible = true;
            }
            if (SettingsOpen == true)
            {
                toLogSettingsButton.Visible = false;
                startFileLoggingButton.Visible = false;
            }
            if (SettingsOpen == false)
            {
                startFileLoggingButton.Visible = true;
            }
            if (TireSettingsOpen == true)
            {
                toTireSettingsButton.Visible = false;
            }
            if (TireSettingsOpen == false)
            {
                toTireSettingsButton.Visible = true;
            }
        }
        private void TextBoxUpdates()
        {
            // Chassis, Engine and Differential stuff
            CurrentSpeed.Text = speed.ToString();
            CurrentFrontLift.Text = frontLift.ToString();
            CurrentRearLift.Text = rearLift.ToString();
            CurrentEngineRPM.Text = engineRPM.ToString() + " RPM";
            CurrentEngineRPMAxle.Text = "(" + engineRPMAxle.ToString() + ") RPM";
            CurrentEngineTorque.Text = engineTorque.ToString() + " Nm";
            CurrentEnginePower.Text = enginePower.ToString() + " kW";
            if (differentialLocked == 1)
            {
                CurrentDifferentialOpen.Text = "Locked";
            }
            else
            {
                CurrentDifferentialOpen.Text = "Open";
            }
            CurrentDifferentialSpeedRad.Text = differentialVelocityRad.ToString() + " rad/s";
            CurrentDifferentialTorque.Text = differentialTorque.ToString() + " Nm";


            //Tire and Suspension data
            //Front left
            textBox_FL_AngularVelocity.Text = FL_AngularVelocity.ToString();
            textBox_FL_ContactLength.Text = FL_ContactLength.ToString();
            textBox_FL_CurrentContactBrakeTorque.Text = FL_CurrentContactBrakeTorque.ToString();
            textBox_FL_MaxCurrentContactBrakeTorque.Text = FL_CurrentContactBrakeTorqueMax.ToString();
            textBox_FL_Deflection.Text = FL_VerticalDeflection.ToString();
            textBox_FL_EffectiveRadius.Text = FL_EffectiveRadius.ToString();
            textBox_FL_LateralLoad.Text = FL_LateralLoad.ToString();
            textBox_FL_LoadedRadius.Text = FL_LoadedRadius.ToString();
            textBox_FL_LongitudinalLoad.Text = FL_LongitudinalLoad.ToString();
            //textBox_FL_SlipAngleRad.Text = FL_SlipAngleRad.ToString();
            textBox_FL_SlipRatio.Text = FL_SlipRatio.ToString();
            textBox_FL_TravelSpeed.Text = FL_TravelSpeed.ToString();
            textBox_FL_VerticalLoad.Text = FL_VerticalLoad.ToString();
            textBox_FL_LateralFriction.Text = FL_LateralFriction.ToString();
            textBox_FL_LongitudinalFriction.Text = FL_LongitudinalFriction.ToString();
            textBox_FL_TreadTemperature.Text = Math.Round(FL_TreadTemperature, 2).ToString();
            textBox_FL_InnerTemperature.Text = Math.Round(FL_InnerTemperature, 2).ToString();
            textBox_FL_SlipAngleDeg.Text = FL_SlipAngleDeg.ToString();
            textBox_FL_TotalFriction.Text = FL_TotalFriction.ToString();//
            textBox_FL_TotalFrictionAngle.Text = FL_TotalFrictionAngle.ToString();//
            textBox_FL_LateralSlipSpeed.Text = FL_LateralSlipSpeed.ToString();//
            textBox_FL_LongitudinalSlipSpeed.Text = FL_LongitudinalSlipSpeed.ToString();//
            textBox_FL_CamberAngle.Text = FL_CamberAngleDeg.ToString();//
            textBox_FL_TireSteerAngle.Text = FL_SteerAngleDeg.ToString();//

            textBox_FL_SuspensionLength.Text = FL_SuspensionLength.ToString();
            textBox_FL_SuspensionVelocity.Text = FL_SuspensionVelocity.ToString();

            //Front right
            textBox_FR_AngularVelocity.Text = FR_AngularVelocity.ToString();
            textBox_FR_ContactLength.Text = FR_ContactLength.ToString();
            textBox_FR_CurrentContactBrakeTorque.Text = FR_CurrentContactBrakeTorque.ToString();
            textBox_FR_MaxCurrentContactBrakeTorque.Text = FR_CurrentContactBrakeTorqueMax.ToString();
            textBox_FR_Deflection.Text = FR_VerticalDeflection.ToString();
            textBox_FR_EffectiveRadius.Text = FR_EffectiveRadius.ToString();
            textBox_FR_LateralLoad.Text = FR_LateralLoad.ToString();
            textBox_FR_LoadedRadius.Text = FR_LoadedRadius.ToString();
            textBox_FR_LongitudinalLoad.Text = FR_LongitudinalLoad.ToString();
            //textBox_FR_SlipAngleRad.Text = FR_SlipAngleRad.ToString();
            textBox_FR_SlipRatio.Text = FR_SlipRatio.ToString();
            textBox_FR_TravelSpeed.Text = FR_TravelSpeed.ToString();
            textBox_FR_VerticalLoad.Text = FR_VerticalLoad.ToString();
            textBox_FR_LateralFriction.Text = FR_LateralFriction.ToString();
            textBox_FR_LongitudinalFriction.Text = FR_LongitudinalFriction.ToString();
            textBox_FR_TreadTemperature.Text = Math.Round(FR_TreadTemperature, 2).ToString();
            textBox_FR_InnerTemperature.Text = Math.Round(FR_InnerTemperature, 2).ToString();
            textBox_FR_SlipAngleDeg.Text = FR_SlipAngleDeg.ToString();
            textBox_FR_TotalFriction.Text = FR_TotalFriction.ToString();//
            textBox_FR_TotalFrictionAngle.Text = FR_TotalFrictionAngle.ToString();//
            textBox_FR_LateralSlipSpeed.Text = FR_LateralSlipSpeed.ToString();//
            textBox_FR_LongitudinalSlipSpeed.Text = FR_LongitudinalSlipSpeed.ToString();//
            textBox_FR_CamberAngle.Text = FR_CamberAngleDeg.ToString();//
            textBox_FR_TireSteerAngle.Text = FR_SteerAngleDeg.ToString();//

            textBox_FR_SuspensionLength.Text = FR_SuspensionLength.ToString();
            textBox_FR_SuspensionVelocity.Text = FR_SuspensionVelocity.ToString();

            //Rear left
            textBox_RL_AngularVelocity.Text = RL_AngularVelocity.ToString();
            textBox_RL_ContactLength.Text = RL_ContactLength.ToString();
            textBox_RL_CurrentContactBrakeTorque.Text = RL_CurrentContactBrakeTorque.ToString();
            textBox_RL_MaxCurrentContactBrakeTorque.Text = RL_CurrentContactBrakeTorqueMax.ToString();
            textBox_RL_Deflection.Text = RL_VerticalDeflection.ToString();
            textBox_RL_EffectiveRadius.Text = RL_EffectiveRadius.ToString();
            textBox_RL_LateralLoad.Text = RL_LateralLoad.ToString();
            textBox_RL_LoadedRadius.Text = RL_LoadedRadius.ToString();
            textBox_RL_LongitudinalLoad.Text = RL_LongitudinalLoad.ToString();
            //textBox_RL_SlipAngleRad.Text = RL_SlipAngleRad.ToString();
            textBox_RL_SlipRatio.Text = RL_SlipRatio.ToString();
            textBox_RL_TravelSpeed.Text = RL_TravelSpeed.ToString();
            textBox_RL_VerticalLoad.Text = RL_VerticalLoad.ToString();
            textBox_RL_LateralFriction.Text = RL_LateralFriction.ToString();
            textBox_RL_LongitudinalFriction.Text = RL_LongitudinalFriction.ToString();
            textBox_RL_TreadTemperature.Text = Math.Round(RL_TreadTemperature, 2).ToString();
            textBox_RL_InnerTemperature.Text = Math.Round(RL_InnerTemperature, 2).ToString();
            textBox_RL_SlipAngleDeg.Text = RL_SlipAngleDeg.ToString();
            textBox_RL_TotalFriction.Text = RL_TotalFriction.ToString();//
            textBox_RL_TotalFrictionAngle.Text = RL_TotalFrictionAngle.ToString();//
            textBox_RL_LateralSlipSpeed.Text = RL_LateralSlipSpeed.ToString();//
            textBox_RL_LongitudinalSlipSpeed.Text = RL_LongitudinalSlipSpeed.ToString();//
            textBox_RL_CamberAngle.Text = RL_CamberAngleDeg.ToString();//
            textBox_RL_TireSteerAngle.Text = RL_SteerAngleDeg.ToString();//

            textBox_RL_SuspensionLength.Text = RL_SuspensionLength.ToString();
            textBox_RL_SuspensionVelocity.Text = RL_SuspensionVelocity.ToString();

            //Rear right
            textBox_RR_AngularVelocity.Text = RR_AngularVelocity.ToString();
            textBox_RR_ContactLength.Text = RR_ContactLength.ToString();
            textBox_RR_CurrentContactBrakeTorque.Text = RR_CurrentContactBrakeTorque.ToString();
            textBox_RR_MaxCurrentContactBrakeTorque.Text = RR_CurrentContactBrakeTorqueMax.ToString();
            textBox_RR_Deflection.Text = RR_VerticalDeflection.ToString();
            textBox_RR_EffectiveRadius.Text = RR_EffectiveRadius.ToString();
            textBox_RR_LateralLoad.Text = RR_LateralLoad.ToString();
            textBox_RR_LoadedRadius.Text = RR_LoadedRadius.ToString();
            textBox_RR_LongitudinalLoad.Text = RR_LongitudinalLoad.ToString();
            //textBox_RR_SlipAngleRad.Text = RR_SlipAngleRad.ToString();
            textBox_RR_SlipRatio.Text = RR_SlipRatio.ToString();
            textBox_RR_TravelSpeed.Text = RR_TravelSpeed.ToString();
            textBox_RR_VerticalLoad.Text = RR_VerticalLoad.ToString();
            textBox_RR_LateralFriction.Text = RR_LateralFriction.ToString();
            textBox_RR_LongitudinalFriction.Text = RR_LongitudinalFriction.ToString();
            textBox_RR_TreadTemperature.Text = Math.Round(RR_TreadTemperature, 2).ToString();
            textBox_RR_InnerTemperature.Text = Math.Round(RR_InnerTemperature, 2).ToString();
            textBox_RR_SlipAngleDeg.Text = RR_SlipAngleDeg.ToString();
            textBox_RR_TotalFriction.Text = RR_TotalFriction.ToString();//
            textBox_RR_TotalFrictionAngle.Text = RR_TotalFrictionAngle.ToString();//
            textBox_RR_LateralSlipSpeed.Text = RR_LateralSlipSpeed.ToString();//
            textBox_RR_LongitudinalSlipSpeed.Text = RR_LongitudinalSlipSpeed.ToString();//
            textBox_RR_CamberAngle.Text = RR_CamberAngleDeg.ToString();//
            textBox_RR_TireSteerAngle.Text = RR_SteerAngleDeg.ToString();//

            textBox_RR_SuspensionLength.Text = RR_SuspensionLength.ToString();
            textBox_RR_SuspensionVelocity.Text = RR_SuspensionVelocity.ToString();
        }
        private void UpdateFormData()
        {
            ButtonVisibilities();
            TextBoxUpdates();
            //string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
#endregion
        #region Form and Buttons stuff
        /*
        private void setTemperatureCorrection_Click(object sender, EventArgs e)
        {
           
        }

        private void setTempCorr_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(tempCorrectionBox.Text))
            {
                TempCorrectionValue = 0.0000000000;
            }
            else
            {
                string sTempBoxRead = tempCorrectionBox.Text;
                //label8.Text = sTempBoxRead;
                double dTempBoxRead = Convert.ToDouble(sTempBoxRead);
                //label9.Text = dTempBoxRead.ToString();
                TempCorrectionValue = dTempBoxRead;
            }


            if (String.IsNullOrEmpty(tempCorrectionA.Text))
            {
                TempCorrectionValueA = 0.0000000000;
            }
            else 
            {
                string sTempValueARead = tempCorrectionA.Text;
                double dTempValueARead = Convert.ToDouble(sTempValueARead);
                TempCorrectionValueA = dTempValueARead;
            }


            if (String.IsNullOrEmpty(tempCorrectionB.Text))
            {
                TempCorrectionValueB = 0.0000000000;
            }
            else
            {
                string sTempValueBRead = tempCorrectionB.Text;
                double dTempValueBRead = Convert.ToDouble(sTempValueBRead);
                TempCorrectionValueB = dTempValueBRead;
            }


            if (String.IsNullOrEmpty(tempCorrectionC.Text))
            {
                TempCorrectionValueC = 0.0000000000;
            }
            else
            {
                string sTempValueCRead = tempCorrectionC.Text;
                double dTempValueCRead = Convert.ToDouble(sTempValueCRead);
                TempCorrectionValueC = dTempValueCRead;
            }


            if (String.IsNullOrEmpty(tempCorrectionD.Text))
            {
                TempCorrectionValueC = 0.0000000000;
            }
            else
            {
                string sTempValueDRead = tempCorrectionD.Text;
                double dTempValueDRead = Convert.ToDouble(sTempValueDRead);
                TempCorrectionValueD = dTempValueDRead;
            }
            
        }
        */
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
            if (int.TryParse(textbox.Text, out sleep))
            {
                if (sleep > 2000)
                    textbox.Text = "2000";
                else if (sleep < 1)
                    textbox.Text = "1";
            }
            /*
            int readlogbox = Convert.ToInt32(logInterval_textBox.Text);

            if (String.IsNullOrEmpty(logInterval_textBox.Text) || readlogbox < 1)
            {
                sleep = 1;
            }
            else
            {
                sleep = Math.Min(Math.Max(readlogbox, 1), 2000);
            }*/
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

        private void tempCorrectionA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch2 = e.KeyChar;

            if (ch2 == 44 && tempCorrectionA.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch2) && ch2 != 8 && ch2 != 44 && ch2 != 45)
            {
                e.Handled = true;
            }
        }

        private void tempCorrectionA_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tempCorrectionA.Text))
            {
                TempCorrectionValueA = 0;
            }
            else
            {
                TempCorrectionValueA = Convert.ToDouble(tempCorrectionA.Text);
            }
        }


        private void tempCorrectionB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch3 = e.KeyChar;

            if (ch3 == 44 && tempCorrectionB.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch3) && ch3 != 8 && ch3 != 44 && ch3 != 45)
            {
                e.Handled = true;
            }
        }

        private void tempCorrectionB_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tempCorrectionB.Text))
            {
                TempCorrectionValueB = 0;
            }
            else
            {
                TempCorrectionValueB = Convert.ToDouble(tempCorrectionB.Text);
            }
        }

        private void tempCorrectionC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch4 = e.KeyChar;

            if (ch4 == 44 && tempCorrectionC.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch4) && ch4 != 8 && ch4 != 44 && ch4 != 45)
            {
                e.Handled = true;
            }
        }

        private void tempCorrectionC_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tempCorrectionC.Text))
            {
                TempCorrectionValueC = 0;
            }
            else
            {
                TempCorrectionValueC = Convert.ToDouble(tempCorrectionC.Text);
            }
        }

        private void tempCorrectionD_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch5 = e.KeyChar;

            if (ch5 == 44 && tempCorrectionD.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch5) && ch5 != 8 && ch5 != 44 && ch5 != 45)
            {
                e.Handled = true;
            }
        }

        private void tempCorrectionD_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tempCorrectionD.Text))
            {
                TempCorrectionValueD = 0;
            }
            else
            {
                TempCorrectionValueD = Convert.ToDouble(tempCorrectionD.Text);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void PirelliSButton_Click(object sender, EventArgs e)
        {
            
            //tempCorrectionBox.Text = "0,0";
            //tempCorrectionA.Text = "0,0002";
            //tempCorrectionB.Text = "-0,002";
            //tempCorrectionC.Text = "1,8315";
            //tempCorrectionD.Text = "-21,246";
            

            tempCorrectionBox.Text = "0,0";
            tempCorrectionA.Text = "0,0007";
            tempCorrectionB.Text = "-0,0542";
            tempCorrectionC.Text = "4,2435";
            tempCorrectionD.Text = "-59,058";

            TempCorrectionValue = 0.0;
            TempCorrectionValueA = 0.0007;
            TempCorrectionValueB = -0.0542;
            TempCorrectionValueC = 4.2435;
            TempCorrectionValueD = -59.058;
    }

        private void BFGoodrich168Button_Click(object sender, EventArgs e)
        {
            tempCorrectionBox.Text = "0,0";
            tempCorrectionA.Text = "0,0002";
            tempCorrectionB.Text = "0,0043";
            tempCorrectionC.Text = "1,7973";
            tempCorrectionD.Text = "-26,203";

            TempCorrectionValue = 0.0;
            TempCorrectionValueA = 0.0002;
            TempCorrectionValueB = 0.0043;
            TempCorrectionValueC = 1.7973;
            TempCorrectionValueD = -26.203;
        }

        private void BFGoodrich376Button_Click(object sender, EventArgs e)
        {
            tempCorrectionBox.Text = "0,0";
            tempCorrectionA.Text = "0,0007";
            tempCorrectionB.Text = "-0,0244";
            tempCorrectionC.Text = "2,7767";
            tempCorrectionD.Text = "-38,779";

            TempCorrectionValue = 0.0;
            TempCorrectionValueA = 0.0007;
            TempCorrectionValueB = -0.0244;
            TempCorrectionValueC = 2.7767;
            TempCorrectionValueD = -38.779;
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
                System.IO.Directory.CreateDirectory(LogFileSaveLocationFolder);
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
            ofd.InitialDirectory = LogFileSaveLocationFolder;
            ofd.Filter = "Executable files (*exe)|*.exe|All files (*.*)|*.*";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                ChartPlotterLocation = ofd.FileName;
                try
                {
                    Process.Start(ChartPlotterLocation);
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

            update = new Thread(new ThreadStart(getData));
            update.IsBackground = true;
            update.Start();
        }

        #endregion
    }
}