using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Physics_Data_Debug
{
    class LiveData
    {
        public static bool SettingsOpen { get; set; } = false;
        public static bool TireSettingsOpen { get; set; } = false;
        public static bool SuspensionSettingsOpen { get; set; } = false;
        public static bool GForceOpen { get; set; } = false;
        public static string sTireTravelSpeed { get; set; } = "Tire Travel Speed";
        public static string sAngularVelocity { get; set; } = "Angular Velocity";
        public static string sVerticalLoad { get; set; } = "Vertical Load";
        public static string sVerticalDeflection { get; set; } = "Vertical Deflection";
        public static string sLoadedRadius { get; set; } = "Loaded Radius";
        public static string sEffectiveRadius { get; set; } = "Effective Radius";
        public static string sContactLength { get; set; } = "Contact Length";
        public static string sBrakeTorque { get; set; } = "Brake Torque";
        public static string sMaxBrakeTorque { get; set; } = "Max Brake Torque";
        public static string sSteerAngle { get; set; } = "Steer Angle";
        public static string sCamberAngle { get; set; } = "Camber Angle";
        public static string sLateralLoad { get; set; } = "Lateral Load";
        public static string sSlipAngle { get; set; } = "Slip Angle";
        public static string sLateralFriction { get; set; } = "Lateral Friction";
        public static string sLateralSlipSpeed { get; set; } = "Lateral Slip Speed";
        public static string sLongitudinalLoad { get; set; } = "Longitudinal Load";
        public static string sSlipRatio { get; set; } = "Slip Ratio";
        public static string sLongitudinalFriction { get; set; } = "Longitudinal Friction";
        public static string sLongitudinalSlipSpeed { get; set; } = "Longitudinal Slip Speed";
        public static string sTreadTemperature { get; set; } = "Tread Temperature";
        public static string sInnerTemperature { get; set; } = "Inner Temperature";
        public static string sRaceTime { get; set; } = "Race Time";
        public static string sTotalFriction { get; set; } = "Total Friction";
        public static string sTotalFrictionAngle { get; set; } = "Total Friction Angle";
        public static string sSuspensionLength { get; set; } = "Suspension Length";
        public static string sSuspensionVelocity { get; set; } = "Suspension Velocity";

        public static bool logging { get; set; } = false;

        public static float fRadToDeg { get; } = Convert.ToSingle(180 / Math.PI);
        public static double dRadToDeg { get; } = 180 / Math.PI;

        public static float fKilometersPerHourToMetersPerSec { get; } = 1 / 3.6f;
        public static double dKilometersPerHourToMetersPerSec { get; } = 1 / 3.6d;

        public static int tickInterval = 50;


        //Basest of the basest
        public static ulong baseAddrTiresSuspensionLiftsDifferentialLocation { get; set; } = 0x18324C8;//0x1831EE0;//this was changing between cars, the new adrdess is only for the player
        public static ulong baseAddrEngineSpeed { get; set; } = 0x18327C8;
        public static ulong baseAddrRacetime { get; set; } = 0x1832648;
        public static ulong baseAddrLocationHeading { get; set; } = 0x1832B88;
        //Every update offsets the base address of the memory points. 99% of the time forwards.
        public static ulong baseAddrUpdt { get; set; } = 0x0;//0x9E00;
        //0x0;// April 2022
        //0x4650;// May 2022
        //0x5710// October 2022
        // 0x67A0 November 2022 1838680 vs 1831EE0
        // 0x7DF0 April 2023
        // 0x9E00; March 2024 { get; set; } = 7DF0+2010 { get; set; } = 9E00

        // Older builds go backwards, so this is for them. Above should be 0x0 then.
        public static ulong baseAddrDodt { get; set; } = 0x0;//0x6DF8D8

        //Time offsets
        public static int OffsetRaceTime { get; set; } = 0x14;

        // Other offsets
        public static int OffsetSpeed { get; set; } = 0x70;
        public static int OffsetFrontLift { get; set; } = 0xAACF2C;
        public static int OffsetRearLift { get; set; } = 0xAACF30;
        public static int OffsetEngineRPM { get; set; } = 0x38;
        public static int OffsetEngineRPMAxle { get; set; } = 0x3C;
        public static int OffsetEngineTorque { get; set; } = 0x44;
        public static int OffsetDifferentialOpen { get; set; } = 0xD94;
        public static int OffsetDifferentialVelocityRad { get; set; } = 0xD98;
        public static int OffsetDifferentialTorque { get; set; } = 0xD9C;
        // Offset for secondary axle is + 0x60

        public static int OffsetTX { get; set; } = 0x0;
        public static int OffsetTY { get; set; } = 0x4;
        public static int OffsetTZ { get; set; } = 0x8;
        public static int OffsetR11 { get; set; } = 0xC;
        public static int OffsetR12 { get; set; } = 0x10;
        public static int OffseR13 { get; set; } = 0x14;
        public static int OffsetR21 { get; set; } = 0x18;
        public static int OffsetR22 { get; set; } = 0x1C;
        public static int OffsetR23 { get; set; } = 0x20;
        public static int OffsetR31 { get; set; } = 0x24;
        public static int OffsetR32 { get; set; } = 0x28;
        public static int OffsetR33 { get; set; } = 0x2C;
        public static int OffsetQ1 { get; set; } = 0x30;
        public static int OffsetQ2 { get; set; } = 0x34;
        public static int OffsetQ3 { get; set; } = 0x38;
        public static int OffsetQ4 { get; set; } = 0x3C;

        public static int OffsetXAcceleration { get; set; } = 0x48;
        public static int OffsetYAcceleration { get; set; } = 0x4C;
        public static int OffsetZAcceleration { get; set; } = 0x50;

        // Suspension offsets
        public static int OffsetSpringRate { get; set; } = 0xE80;
        public static int OffsetProgresiveRate { get; set; } = 0xE84;
        public static int OffsetBumbLimitsX { get; set; } = 0xE88;
        public static int OffsetBumpLimitsY { get; set; } = 0xE8C;
        public static int OffsetReboundLimitsX { get; set; } = 0xE90;
        public static int OffsetReboundLimitsY { get; set; } = 0xE94;
        public static int OffsetBumpDampX { get; set; } = 0xE98;
        public static int OffsetReboundDampX { get; set; } = 0xE9C;
        public static int OffsetBumpDampY { get; set; } = 0xEA0;
        public static int OffsetReboundDampY { get; set; } = 0xEA4;
        public static int OffsetExpandLimitFromZero { get; set; } = 0xEA8;
        public static int OffsetCompressionLimitFromZero { get; set; } = 0xEAC;
        public static int OffsetRideHeightBumpStopDownReboundLength { get; set; } = 0xEB0;
        public static int OffsetSuspensionLength { get; set; } = 0xEB4;
        public static int OffsetSuspensionVelocity { get; set; } = 0xEB8;
        public static int OffsetBumpStopLength { get; set; } = 0xEBC;
        public static int OffsetRideHeightBumpStopDown { get; set; } = 0xEC0;
        public static int OffsetBumpStopRate { get; set; } = 0xEC4;
        public static int OffsetReboundRate { get; set; } = 0xEC8;
        public static int OffsetBumpStopDamp { get; set; } = 0xECC;
        public static int OffsetBumpStopRateGainDeflectionSquared { get; set; } = 0xED0;
        public static int OffsetBumpStopDampGainDeflectionSquared { get; set; } = 0xED4;

        public static int OffsetFRSuspension { get; set; } = 0x60;
        public static int OffsetRLSuspension { get; set; } = OffsetFRSuspension + OffsetFRSuspension;
        public static int OffsetRRSuspension { get; set; } = OffsetFRSuspension + OffsetFRSuspension + OffsetFRSuspension;

        //0x3E4
        //0xAE8

        //Location offsets


        //Tire data offsets
        public static int OffsetTireData { get; set; } = 0xE78;
        public static int OffsetFRTire { get; set; } = 0xC50;//Next tire offset from FL
        public static int OffsetRLTire { get; set; } = 0xC50 + 0xC50;//Next tire offset from FL
        public static int OffsetRRTire { get; set; } = 0xC50 + 0xC50 + 0xC50;//Next tire offset from FL

        public static int OffsetMomentOfInertia { get; set; } = 0x28;//
        public static int OffsetAngularVelocity { get; set; } = 0x2C;
        public static int OffsetCamberAngleRad { get; set; } = 0x394;
        public static int OffsetTireSteerAngleRad { get; set; } = 0x398;
        public static int OffsetTireMass { get; set; } = 0x410;//
        public static int OffsetTireRadius { get; set; } = 0x414;//
        public static int OffsetTireWidth { get; set; } = 0x418;//
        public static int OffsetTireSpringRate { get; set; } = 0x41C;//
        public static int OffsetTireDamperRate { get; set; } = 0x420;//
        public static int OffsetTireMaxDeflection { get; set; } = 0x424;//
        public static int OffsetThermalAirTransfer { get; set; } = 0x428;//
        public static int OffsetThermalInnerTransfer { get; set; } = 0x42C;//
        public static int OffsetTreadTemperature { get; set; } = 0x434;
        public static int OffsetInnerTemperature { get; set; } = 0x438;
        public static int OffsetDeflection { get; set; } = 0x43C;
        public static int OffsetLoadedRadius { get; set; } = 0x44C;
        public static int OffsetEffectiveRadius { get; set; } = 0x450;
        public static int OffsetLongitudinalSlipSpeed { get; set; } = 0x454;
        public static int OffsetLateralSlipSpeed { get; set; } = 0x458;
        public static int OffsetRadOfTireMoved { get; set; } = 0x45C;//Not angular but compared to the contact surface.
        public static int OffsetCurrentContactBrakeTorque { get; set; } = 0x484;
        public static int OffsetCurrentContactBrakeTorqueMax { get; set; } = 0x48C;
        public static int OffsetVerticalLoad { get; set; } = 0x490;

        public static int OffsetTireX { get; set; } = 0x4AC;
        public static int OffsetTireY { get; set; } = 0x4B0;
        public static int OffsetTireZ { get; set; } = 0x4B4;

        public static int OffsetLateralLoad { get; set; } = 0x4B8;
        public static int OffsetLongitudinalLoad { get; set; } = 0x4C0;
        public static int OffsetSlipAngleRad { get; set; } = 0xBF0;
        public static int OffsetSlipRatio { get; set; } = 0xBF4;
        public static int OffsetLateralResistance { get; set; } = 0xBF8;//
        public static int OffsetLongitudinalResistance { get; set; } = 0xBFC;//

        public static int OffsetContactLength { get; set; } = 0xC1C;
        public static int OffsetTravelSpeed { get; set; } = 0xC20;
        /*
                 
                 */

        //Time Data
        public static int RaceTime;

        // How long array is.
        /*
        private double[] flsTempArray { get; } = new double[300];
        private double[] fliTempArray { get; } = new double[300];
        private double[] frsTempArray { get; } = new double[300];
        private double[] friTempArray { get; } = new double[300];
        private double[] rlsTempArray { get; } = new double[300];
        private double[] rliTempArray { get; } = new double[300];
        private double[] rrsTempArray { get; } = new double[300];
        private double[] rriTempArray { get; } = new double[300];
        */

        /*
        private double TempCorrectionValue = 0.0000000000;
        private double TempCorrectionValueA = 0.0000000000;
        private double TempCorrectionValueB = 0.0000000000;
        private double TempCorrectionValueC = 0.0000000000;
        private double TempCorrectionValueD = 0.0000000000;
        */

        public static float speed = 0.00f;
        public static float speed2 = 0.00f;
        public static float speed3 = 0.00f;
        public static float acceleration = 0.00f;
        public static float acceleration2 = 0.00f;
        public static float gForce = 0.00f;
        public static float g = 9.80665f;

        public static float frontLift = 0.00f;
        public static float rearLift = 0.00f;
        public static float engineRPM = 0.00f;
        public static float engineRPMAxle = 0.00f;
        public static float engineTorque = 0.00f;

        public static float enginePower = 0.00f;
        public static byte differentialLocked = 0;
        public static float differentialVelocityRad = 0.00f;
        public static float differentialTorque = 0.00f;

        public static float TX { get; set; }
        public static float TY { get; set; }
        public static float TZ { get; set; }
        public static float R11 { get; set; }
        public static float R12 { get; set; }
        public static float R13 { get; set; }
        public static float R21 { get; set; }
        public static float R22 { get; set; }
        public static float R23 { get; set; }
        public static float R31 { get; set; }
        public static float R32 { get; set; }
        public static float R33 { get; set; }
        public static float Q1 { get; set; }
        public static float Q2 { get; set; }
        public static float Q3 { get; set; }
        public static float Q4 { get; set; }
        //public static double rotationX { get; set; }
        public static double rotationYRad { get; set; }
        public static double rotationYDeg { get; set; }
        //public static double rotationZ { get; set; }
        public static float XAcceleration { get; set; }
        public static float XG { get; set; }
        public static double XGRotated { get; set; }
        public static float YAcceleration { get; set; }
        public static float YG { get; set; }
        public static double YGRotated { get; set; }
        public static float ZAcceleration { get; set; }
        public static float ZG { get; set; }
        public static double ZGRotated { get; set; }
        public static double XZAcceleration { get; set; }
        public static double XZG { get; set; }
        public static double XYZAcceleration { get; set; }
        public static double XYZG { get; set; }

        public static Matrix4x4 playerRotation;
        public static Quaternion playerQuaternion = new Quaternion(Q1, Q2, Q3, Q4);
        public static double XZAccelerationAngleRad { get; set; }
        public static double XZAccelerationAngleDeg { get; set; }
        public static double XZGAngleRad { get; set; }
        public static double XZGAngleDeg { get; set; }


        //Tire Data

        //Font Left
        public static float FL_MomentOfInertia { get; set; }//
        public static float FL_AngularVelocity { get; set; }
        public static float FL_CamberAngleRad { get; set; }//
        public static float FL_CamberAngleDeg { get; set; }//
        public static float FL_SteerAngleRad { get; set; }//
        public static float FL_SteerAngleDeg { get; set; }//
        public static float FL_TireMass { get; set; }//
        public static float FL_TireRadius { get; set; }//
        public static float FL_TireWidth { get; set; }//
        public static float FL_TireSpringRate { get; set; }//
        public static float FL_TireDamperRate { get; set; }//
        public static float FL_TireMaxDeflection { get; set; }//
        public static float FL_ThermalAirTransfer { get; set; }
        public static float FL_ThermalInnerTransfer { get; set; }
        public static float FL_TreadTemperature { get; set; } = 0.0f;
        public static float FL_InnerTemperature { get; set; } = 0.0f;
        public static float FL_VerticalDeflection { get; set; }
        public static float FL_LoadedRadius { get; set; }
        public static float FL_EffectiveRadius { get; set; }
        public static float FL_LongitudinalSlipSpeed { get; set; }//
        public static float FL_LateralSlipSpeed { get; set; }//
        public static float FL_RadOfTireMoved { get; set; }//
        public static float FL_CurrentContactBrakeTorque { get; set; }
        public static float FL_CurrentContactBrakeTorqueMax { get; set; }
        public static float FL_VerticalLoad { get; set; }

        public static float FL_X { get; set; }
        public static float FL_Y { get; set; }
        public static float FL_Z { get; set; }

        public static float FL_LateralLoad { get; set; }
        public static float FL_LongitudinalLoad { get; set; }
        public static float FL_SlipAngleRad { get; set; }
        public static float FL_SlipAngleDeg { get; set; }
        public static float FL_SlipRatio { get; set; }
        public static float FL_LateralResistance { get; set; }//
        public static float FL_LongitudinalResistance { get; set; }//

        public static float FL_ContactLength { get; set; }
        public static float FL_TravelSpeed { get; set; }
        //----------------------------------------//
        public static float FL_LateralFriction { get; set; }
        public static float FL_LongitudinalFriction { get; set; }
        public static float FL_TotalFriction { get; set; }//
        public static float FL_TotalFrictionAngle { get; set; }//

        public static float FL_SuspensionLength { get; set; }
        public static float FL_SuspensionVelocity { get; set; }
        /*
                 
                 */

        //Front Right
        public static float FR_MomentOfInertia { get; set; }//
        public static float FR_AngularVelocity { get; set; }
        public static float FR_CamberAngleRad { get; set; }//
        public static float FR_CamberAngleDeg { get; set; }//
        public static float FR_SteerAngleRad { get; set; }//
        public static float FR_SteerAngleDeg { get; set; }//
        public static float FR_TireMass { get; set; }//
        public static float FR_TireRadius { get; set; }//
        public static float FR_TireWidth { get; set; }//
        public static float FR_TireSpringRate { get; set; }//
        public static float FR_TireDamperRate { get; set; }//
        public static float FR_TireMaxDeflection { get; set; }//
        public static float FR_ThermalAirTransfer { get; set; }
        public static float FR_ThermalInnerTransfer { get; set; }
        public static float FR_TreadTemperature { get; set; } = 0.0f;
        public static float FR_InnerTemperature { get; set; } = 0.0f;
        public static float FR_VerticalDeflection { get; set; }
        public static float FR_LoadedRadius { get; set; }
        public static float FR_EffectiveRadius { get; set; }
        public static float FR_LongitudinalSlipSpeed { get; set; }//
        public static float FR_LateralSlipSpeed { get; set; }//
        public static float FR_RadOfTireMoved { get; set; }//
        public static float FR_CurrentContactBrakeTorque { get; set; }
        public static float FR_CurrentContactBrakeTorqueMax { get; set; }
        public static float FR_VerticalLoad { get; set; }

        public static float FR_X { get; set; }
        public static float FR_Y { get; set; }
        public static float FR_Z { get; set; }

        public static float FR_LateralLoad { get; set; }
        public static float FR_LongitudinalLoad { get; set; }
        public static float FR_SlipAngleRad { get; set; }
        public static float FR_SlipAngleDeg { get; set; }
        public static float FR_SlipRatio { get; set; }
        public static float FR_LateralResistance { get; set; }//
        public static float FR_LongitudinalResistance { get; set; }//

        public static float FR_ContactLength { get; set; }
        public static float FR_TravelSpeed { get; set; }
        //----------------------------------------//
        public static float FR_LateralFriction { get; set; }
        public static float FR_LongitudinalFriction { get; set; }
        public static float FR_TotalFriction { get; set; }//
        public static float FR_TotalFrictionAngle { get; set; }//

        public static float FR_SuspensionLength { get; set; }
        public static float FR_SuspensionVelocity { get; set; }
        /*
                 
                 */

        //Rear Left
        public static float RL_MomentOfInertia { get; set; }//
        public static float RL_AngularVelocity { get; set; }
        public static float RL_CamberAngleRad { get; set; }//
        public static float RL_CamberAngleDeg { get; set; }//
        public static float RL_SteerAngleRad { get; set; }//
        public static float RL_SteerAngleDeg { get; set; }//
        public static float RL_TireMass { get; set; }//
        public static float RL_TireRadius { get; set; }//
        public static float RL_TireWidth { get; set; }//
        public static float RL_TireSpringRate { get; set; }//
        public static float RL_TireDamperRate { get; set; }//
        public static float RL_TireMaxDeflection { get; set; }//
        public static float RL_ThermalAirTransfer { get; set; }
        public static float RL_ThermalInnerTransfer { get; set; }
        public static float RL_TreadTemperature { get; set; } = 0.0f;
        public static float RL_InnerTemperature { get; set; } = 0.0f;
        public static float RL_VerticalDeflection { get; set; }
        public static float RL_LoadedRadius { get; set; }
        public static float RL_EffectiveRadius { get; set; }
        public static float RL_LongitudinalSlipSpeed { get; set; }//
        public static float RL_LateralSlipSpeed { get; set; }//
        public static float RL_RadOfTireMoved { get; set; }//
        public static float RL_CurrentContactBrakeTorque { get; set; }
        public static float RL_CurrentContactBrakeTorqueMax { get; set; }
        public static float RL_VerticalLoad { get; set; }

        public static float RL_X { get; set; }
        public static float RL_Y { get; set; }
        public static float RL_Z { get; set; }

        public static float RL_LateralLoad { get; set; }
        public static float RL_LongitudinalLoad { get; set; }
        public static float RL_SlipAngleRad { get; set; }
        public static float RL_SlipAngleDeg { get; set; }
        public static float RL_SlipRatio { get; set; }
        public static float RL_LateralResistance { get; set; }//
        public static float RL_LongitudinalResistance { get; set; }//

        public static float RL_ContactLength { get; set; }
        public static float RL_TravelSpeed { get; set; }
        //----------------------------------------//
        public static float RL_LateralFriction { get; set; }
        public static float RL_LongitudinalFriction { get; set; }
        public static float RL_TotalFriction { get; set; }//
        public static float RL_TotalFrictionAngle { get; set; }//

        public static float RL_SuspensionLength { get; set; }
        public static float RL_SuspensionVelocity { get; set; }
        /*
                 
                 */

        //Rear Right
        public static float RR_MomentOfInertia { get; set; }//
        public static float RR_AngularVelocity { get; set; }
        public static float RR_CamberAngleRad { get; set; }//
        public static float RR_CamberAngleDeg { get; set; }//
        public static float RR_SteerAngleRad { get; set; }//
        public static float RR_SteerAngleDeg { get; set; }//
        public static float RR_TireMass { get; set; }//
        public static float RR_TireRadius { get; set; }//
        public static float RR_TireWidth { get; set; }//
        public static float RR_TireSpringRate { get; set; }//
        public static float RR_TireDamperRate { get; set; }//
        public static float RR_TireMaxDeflection { get; set; }//
        public static float RR_ThermalAirTransfer { get; set; }
        public static float RR_ThermalInnerTransfer { get; set; }
        public static float RR_TreadTemperature { get; set; } = 0.0f;
        public static float RR_InnerTemperature { get; set; } = 0.0f;
        public static float RR_VerticalDeflection { get; set; }
        public static float RR_LoadedRadius { get; set; }
        public static float RR_EffectiveRadius { get; set; }
        public static float RR_LongitudinalSlipSpeed { get; set; }//
        public static float RR_LateralSlipSpeed { get; set; }//
        public static float RR_RadOfTireMoved { get; set; }//
        public static float RR_CurrentContactBrakeTorque { get; set; }
        public static float RR_CurrentContactBrakeTorqueMax { get; set; }
        public static float RR_VerticalLoad { get; set; }

        public static float RR_X { get; set; }
        public static float RR_Y { get; set; }
        public static float RR_Z { get; set; }

        public static float RR_LateralLoad { get; set; }
        public static float RR_LongitudinalLoad { get; set; }
        public static float RR_SlipAngleRad { get; set; }
        public static float RR_SlipAngleDeg { get; set; }
        public static float RR_SlipRatio { get; set; }
        public static float RR_LateralResistance { get; set; }//
        public static float RR_LongitudinalResistance { get; set; }//

        public static float RR_ContactLength { get; set; }
        public static float RR_TravelSpeed { get; set; }
        //----------------------------------------//
        public static float RR_LateralFriction { get; set; }
        public static float RR_LongitudinalFriction { get; set; }
        public static float RR_TotalFriction { get; set; }//
        public static float RR_TotalFrictionAngle { get; set; }//

        public static float RR_SuspensionLength { get; set; }
        public static float RR_SuspensionVelocity { get; set; }
        /*
                 
                 */
        //Base Addres for Tire data
        public static ulong baseAddrUpdtTiresSuspensionLiftsDifferential { get; set; }
        //Base Address for Speed and Lifts
        public static ulong baseAddrUpdtEngineSpeed { get; set; }
        //Base Address for Race Timer
        public static ulong baseAddrUpdtRacetimer { get; set; }
        //Base Address for Location and heading
        public static ulong baseAddrUpdtLocationHeading { get; set; }

        //Race time pointer reader
        public static ulong raceTimerTargetAddr { get; set; }

        //Speed, Lifts, Engine Torque and DIfferential pointer reader
        public static ulong speedTargetAddr { get; set; }
        public static ulong frontLiftTargetAddr { get; set; }
        public static ulong rearLiftTargetAddr { get; set; }
        public static ulong engineRPMTargetAddr { get; set; }
        public static ulong engineRPMAxleTargetAddr { get; set; }
        public static ulong engineTorqueTargetAddr { get; set; }
        public static ulong differentialOpenTargetAddr { get; set; }
        public static ulong differentialVelocityRadTargetAddr { get; set; }
        public static ulong differentialTorqueTargetAddr { get; set; }

        //Location and heading pointer reader
        public static ulong TXTargetAddr { get; set; }
        public static ulong TYTargetAddr { get; set; }
        public static ulong TZTargetAddr { get; set; }
        public static ulong R11TargetAddr { get; set; }
        public static ulong R12TargetAddr { get; set; }
        public static ulong R13TargetAddr { get; set; }
        public static ulong R21TargetAddr { get; set; }
        public static ulong R22TargetAddr { get; set; }
        public static ulong R23TargetAddr { get; set; }
        public static ulong R31TargetAddr { get; set; }
        public static ulong R32TargetAddr { get; set; }
        public static ulong R33TargetAddr { get; set; }
        public static ulong Q1TargetAddr { get; set; }
        public static ulong Q2TargetAddr { get; set; }
        public static ulong Q3TargetAddr { get; set; }
        public static ulong Q4TargetAddr { get; set; }
        public static ulong XAccelerationTargetAddr { get; set; }
        public static ulong YAccelerationTargetAddr { get; set; }
        public static ulong ZAccelerationTargetAddr { get; set; }

        //Tire Data pointer readers
        //Front Left
        public static ulong FL_TreadTemperatureTargetAddr { get; set; }
        public static ulong FL_InnerTemperatureTargetAddr { get; set; }
        public static ulong FL_AngularVelocity_TargetAddr { get; set; }
        public static ulong FL_Deflection_TargetAddr { get; set; }
        public static ulong FL_LoadedRadius_TargetAddr { get; set; }
        public static ulong FL_EffectiveRadius_TargetAddr { get; set; }
        public static ulong FL_CurrentContactBrakeTorque_TargetAddr { get; set; }
        public static ulong FL_CurrentContactBrakeTorqueMax_TargetAddr { get; set; }
        public static ulong FL_VerticalLoad_TargetAddr { get; set; }
        public static ulong FL_X_TargetAddr { get; set; }
        public static ulong FL_Y_TargetAddr { get; set; }
        public static ulong FL_Z_TargetAddr { get; set; }
        public static ulong FL_LateralLoad_TargetAddr { get; set; }
        public static ulong FL_LongitudinalLoad_TargetAddr { get; set; }
        public static ulong FL_SlipAngleRad_TargetAddr { get; set; }
        public static ulong FL_SlipRatio_TargetAddr { get; set; }
        public static ulong FL_ContactLength_TargetAddr { get; set; }
        public static ulong FL_TravelSpeed_TargetAddr { get; set; }
        public static ulong FL_LateralSlipSpeed_TargetAddr { get; set; }
        public static ulong FL_LongitudinalSlipSpeed_TargetAddr { get; set; }
        public static ulong FL_CamberAngleRad_TargetAddr { get; set; }
        public static ulong FL_TireSteerAngleRad_TargetAddr { get; set; }

        public static ulong FL_TireMass_TargetAddr { get; set; }
        public static ulong FL_TireRadius_TargetAddr { get; set; }
        public static ulong FL_TireWidth_TargetAddr { get; set; }
        public static ulong FL_TireSpringRate_TargetAddr { get; set; }
        public static ulong FL_TireDamperRate_TargetAddr { get; set; }
        public static ulong FL_TireMaxDeflection_TargetAddr { get; set; }
        public static ulong FL_ThermalAirTransfer_TargetAddr { get; set; }
        public static ulong FL_ThermalInnerTransfer_TargetAddr { get; set; }
        public static ulong FL_MomentOfInertia_TargetAddr { get; set; }

        public static ulong FL_SuspensionLenght_TargetAddr { get; set; }
        public static ulong FL_SuspensionVelocity_TargetAddr { get; set; }
        /*

         */

        //Front Right
        public static ulong FR_TreadTemperatureTargetAddr { get; set; }
        public static ulong FR_InnerTemperatureTargetAddr { get; set; }
        public static ulong FR_AngularVelocity_TargetAddr { get; set; }
        public static ulong FR_Deflection_TargetAddr { get; set; }
        public static ulong FR_LoadedRadius_TargetAddr { get; set; }
        public static ulong FR_EffectiveRadius_TargetAddr { get; set; }
        public static ulong FR_CurrentContactBrakeTorque_TargetAddr { get; set; }
        public static ulong FR_CurrentContactBrakeTorqueMax_TargetAddr { get; set; }
        public static ulong FR_VerticalLoad_TargetAddr { get; set; }
        public static ulong FR_X_TargetAddr { get; set; }
        public static ulong FR_Y_TargetAddr { get; set; }
        public static ulong FR_Z_TargetAddr { get; set; }
        public static ulong FR_LateralLoad_TargetAddr { get; set; }
        public static ulong FR_LongitudinalLoad_TargetAddr { get; set; }
        public static ulong FR_SlipAngleRad_TargetAddr { get; set; }
        public static ulong FR_SlipRatio_TargetAddr { get; set; }
        public static ulong FR_ContactLength_TargetAddr { get; set; }
        public static ulong FR_TravelSpeed_TargetAddr { get; set; }
        public static ulong FR_LateralSlipSpeed_TargetAddr { get; set; }
        public static ulong FR_LongitudinalSlipSpeed_TargetAddr { get; set; }
        public static ulong FR_MomentOfInertia_TargetAddr { get; set; }
        public static ulong FR_CamberAngleRad_TargetAddr { get; set; }
        public static ulong FR_TireSteerAngleRad_TargetAddr { get; set; }
        public static ulong FR_TireMass_TargetAddr { get; set; }
        public static ulong FR_TireRadius_TargetAddr { get; set; }
        public static ulong FR_TireWidth_TargetAddr { get; set; }
        public static ulong FR_TireSpringRate_TargetAddr { get; set; }
        public static ulong FR_TireDamperRate_TargetAddr { get; set; }
        public static ulong FR_TireMaxDeflection_TargetAddr { get; set; }
        public static ulong FR_ThermalAirTransfer_TargetAddr { get; set; }
        public static ulong FR_ThermalInnerTransfer_TargetAddr { get; set; }

        public static ulong FR_SuspensionLenght_TargetAddr { get; set; }
        public static ulong FR_SuspensionVelocity_TargetAddr { get; set; }
        /*

         */

        //Rear Left
        public static ulong RL_TreadTemperatureTargetAddr { get; set; }
        public static ulong RL_InnerTemperatureTargetAddr { get; set; }
        public static ulong RL_AngularVelocity_TargetAddr { get; set; }
        public static ulong RL_Deflection_TargetAddr { get; set; }
        public static ulong RL_LoadedRadius_TargetAddr { get; set; }
        public static ulong RL_EffectiveRadius_TargetAddr { get; set; }
        public static ulong RL_CurrentContactBrakeTorque_TargetAddr { get; set; }
        public static ulong RL_CurrentContactBrakeTorqueMax_TargetAddr { get; set; }
        public static ulong RL_VerticalLoad_TargetAddr { get; set; }
        public static ulong RL_X_TargetAddr { get; set; }
        public static ulong RL_Y_TargetAddr { get; set; }
        public static ulong RL_Z_TargetAddr { get; set; }
        public static ulong RL_LateralLoad_TargetAddr { get; set; }
        public static ulong RL_LongitudinalLoad_TargetAddr { get; set; }
        public static ulong RL_SlipAngleRad_TargetAddr { get; set; }
        public static ulong RL_SlipRatio_TargetAddr { get; set; }
        public static ulong RL_ContactLength_TargetAddr { get; set; }
        public static ulong RL_TravelSpeed_TargetAddr { get; set; }
        public static ulong RL_LateralSlipSpeed_TargetAddr { get; set; }
        public static ulong RL_LongitudinalSlipSpeed_TargetAddr { get; set; }
        public static ulong RL_MomentOfInertia_TargetAddr { get; set; }
        public static ulong RL_CamberAngleRad_TargetAddr { get; set; }
        public static ulong RL_TireSteerAngleRad_TargetAddr { get; set; }
        public static ulong RL_TireMass_TargetAddr { get; set; }
        public static ulong RL_TireRadius_TargetAddr { get; set; }
        public static ulong RL_TireWidth_TargetAddr { get; set; }
        public static ulong RL_TireSpringRate_TargetAddr { get; set; }
        public static ulong RL_TireDamperRate_TargetAddr { get; set; }
        public static ulong RL_TireMaxDeflection_TargetAddr { get; set; }
        public static ulong RL_ThermalAirTransfer_TargetAddr { get; set; }
        public static ulong RL_ThermalInnerTransfer_TargetAddr { get; set; }

        public static ulong RL_SuspensionLenght_TargetAddr { get; set; }
        public static ulong RL_SuspensionVelocity_TargetAddr { get; set; }
        /*

         */

        //Rear Right
        public static ulong RR_TreadTemperatureTargetAddr { get; set; }
        public static ulong RR_InnerTemperatureTargetAddr { get; set; }
        public static ulong RR_AngularVelocity_TargetAddr { get; set; }
        public static ulong RR_Deflection_TargetAddr { get; set; }
        public static ulong RR_LoadedRadius_TargetAddr { get; set; }
        public static ulong RR_EffectiveRadius_TargetAddr { get; set; }
        public static ulong RR_CurrentContactBrakeTorque_TargetAddr { get; set; }
        public static ulong RR_CurrentContactBrakeTorqueMax_TargetAddr { get; set; }
        public static ulong RR_VerticalLoad_TargetAddr { get; set; }
        public static ulong RR_X_TargetAddr { get; set; }
        public static ulong RR_Y_TargetAddr { get; set; }
        public static ulong RR_Z_TargetAddr { get; set; }
        public static ulong RR_LateralLoad_TargetAddr { get; set; }
        public static ulong RR_LongitudinalLoad_TargetAddr { get; set; }
        public static ulong RR_SlipAngleRad_TargetAddr { get; set; }
        public static ulong RR_SlipRatio_TargetAddr { get; set; }
        public static ulong RR_ContactLength_TargetAddr { get; set; }
        public static ulong RR_TravelSpeed_TargetAddr { get; set; }
        public static ulong RR_LateralSlipSpeed_TargetAddr { get; set; }
        public static ulong RR_LongitudinalSlipSpeed_TargetAddr { get; set; }
        public static ulong RR_MomentOfInertia_TargetAddr { get; set; }
        public static ulong RR_CamberAngleRad_TargetAddr { get; set; }
        public static ulong RR_TireSteerAngleRad_TargetAddr { get; set; }
        public static ulong RR_TireMass_TargetAddr { get; set; }
        public static ulong RR_TireRadius_TargetAddr { get; set; }
        public static ulong RR_TireWidth_TargetAddr { get; set; }
        public static ulong RR_TireSpringRate_TargetAddr { get; set; }
        public static ulong RR_TireDamperRate_TargetAddr { get; set; }
        public static ulong RR_TireMaxDeflection_TargetAddr { get; set; }
        public static ulong RR_ThermalAirTransfer_TargetAddr { get; set; }
        public static ulong RR_ThermalInnerTransfer_TargetAddr { get; set; }

        public static ulong RR_SuspensionLenght_TargetAddr { get; set; }
        public static ulong RR_SuspensionVelocity_TargetAddr { get; set; }
        /*

         */

        //Speed and Lift pointers
        public static int[] speedOffsets { get; set; } = { OffsetSpeed };
        public static int[] frontLiftOffsets { get; set; } = { OffsetFrontLift };
        public static int[] rearLiftOffsets { get; set; } = { OffsetRearLift };

        //Engine and diff pointers 
        public static int[] engineRPMOffests { get; set; } = { OffsetEngineRPM };
        public static int[] engineRPMAxleOffests { get; set; } = { OffsetEngineRPMAxle };
        public static int[] engineTorqueOffsets { get; set; } = { OffsetEngineTorque };
        public static int[] differentialOpenOffsets { get; set; } = { OffsetDifferentialOpen };
        public static int[] differentialVelocityRadOffsets { get; set; } = { OffsetDifferentialVelocityRad };
        public static int[] differentialTorqueOffsets { get; set; } = { OffsetDifferentialTorque };

        //Race time pointer
        public static int[] raceTimerOffsets { get; set; } = { OffsetRaceTime };

        // Location and heading offsets
        public static int[] TXOffsets { get; set; } = { OffsetTX };
        public static int[] TYOffsets { get; set; } = { OffsetTY };
        public static int[] TZOffsets { get; set; } = { OffsetTZ };
        public static int[] R11Offsets { get; set; } = { OffsetR11 };
        public static int[] R12Offsets { get; set; } = { OffsetR12 };
        public static int[] R13Offsets { get; set; } = { OffseR13 };
        public static int[] R21Offsets { get; set; } = { OffsetR21 };
        public static int[] R22Offsets { get; set; } = { OffsetR22 };
        public static int[] R23ffsets { get; set; } = { OffsetR23 };
        public static int[] R31Offsets { get; set; } = { OffsetR31 };
        public static int[] R32Offsets { get; set; } = { OffsetR32 };
        public static int[] R33Offsets { get; set; } = { OffsetR33 };
        public static int[] Q1Offsets { get; set; } = { OffsetQ1 };
        public static int[] Q2Offsets { get; set; } = { OffsetQ2 };
        public static int[] Q3Offsets { get; set; } = { OffsetQ3 };
        public static int[] Q4Offsets { get; set; } = { OffsetQ4 };
        public static int[] XAccelerationOffsets { get; set; } = { OffsetXAcceleration };
        public static int[] YAccelerationOffsets { get; set; } = { OffsetYAcceleration };
        public static int[] ZAccelerationOffsets { get; set; } = { OffsetZAcceleration };

        //Tire & Suspension Data pointers
        //Front Left
        public static int[] flsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature };
        public static int[] fliOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature };
        public static int[] FL_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity };
        public static int[] FL_DeflectionOffsets { get; set; } = { OffsetTireData, OffsetDeflection };
        public static int[] FL_LoadedRadiusOffsets { get; set; } = { OffsetTireData, OffsetLoadedRadius };
        public static int[] FL_EffectiveRadiusOffsets { get; set; } = { OffsetTireData, OffsetEffectiveRadius };
        public static int[] FL_CurrentContactBrakeTorqueOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorque };
        public static int[] FL_CurrentContactBrakeTorqueMaxOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax };
        public static int[] FL_VerticalLoadOffsets { get; set; } = { OffsetTireData, OffsetVerticalLoad };

        public static int[] FL_XOffsets { get; set; } = { OffsetTireData, OffsetTireX };
        public static int[] FL_YOffsets { get; set; } = { OffsetTireData, OffsetTireY };
        public static int[] FL_ZOffsets { get; set; } = { OffsetTireData, OffsetTireZ };

        public static int[] FL_LateralLoadOffsets { get; set; } = { OffsetTireData, OffsetLateralLoad };
        public static int[] FL_LongitudinalLoadOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalLoad };
        public static int[] FL_SlipAngleRadOffsets { get; set; } = { OffsetTireData, OffsetSlipAngleRad };
        public static int[] FL_SlipRatioOffsets { get; set; } = { OffsetTireData, OffsetSlipRatio };
        public static int[] FL_ContactLengthOffsets { get; set; } = { OffsetTireData, OffsetContactLength };
        public static int[] FL_TravelSpeedOffsets { get; set; } = { OffsetTireData, OffsetTravelSpeed };
        public static int[] FL_LateralSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLateralSlipSpeed };//
        public static int[] FL_LongitudinalSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalSlipSpeed };// 
        public static int[] FL_CamberAngleRadOffsets { get; set; } = { OffsetTireData, OffsetCamberAngleRad };//
        public static int[] FL_TireSteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad };//

        public static int[] FL_MomentOfInertiaOffsets { get; set; } = { OffsetTireData, OffsetMomentOfInertia };//
        public static int[] FL_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass };//
        public static int[] FL_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius };//
        public static int[] FL_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth };//
        public static int[] FL_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate };//
        public static int[] FL_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate };//
        public static int[] FL_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection };//
        public static int[] FL_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer };
        public static int[] FL_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer };

        public static int[] FL_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength };
        public static int[] FL_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity };
        /*

         */

        //Front Right
        public static int[] frsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature + OffsetFRTire };
        public static int[] friOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature + OffsetFRTire };
        public static int[] FR_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity + OffsetFRTire };
        public static int[] FR_DeflectionOffsets { get; set; } = { OffsetTireData, OffsetDeflection + OffsetFRTire };
        public static int[] FR_LoadedRadiusOffsets { get; set; } = { OffsetTireData, OffsetLoadedRadius + OffsetFRTire };
        public static int[] FR_EffectiveRadiusOffsets { get; set; } = { OffsetTireData, OffsetEffectiveRadius + OffsetFRTire };
        public static int[] FR_CurrentContactBrakeTorqueOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetFRTire };
        public static int[] FR_CurrentContactBrakeTorqueMaxOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetFRTire };
        public static int[] FR_VerticalLoadOffsets { get; set; } = { OffsetTireData, OffsetVerticalLoad + OffsetFRTire };

        public static int[] FR_XOffsets { get; set; } = { OffsetTireData, OffsetTireX + OffsetFRTire };
        public static int[] FR_YOffsets { get; set; } = { OffsetTireData, OffsetTireY + OffsetFRTire };
        public static int[] FR_ZOffsets { get; set; } = { OffsetTireData, OffsetTireZ + OffsetFRTire };

        public static int[] FR_LateralLoadOffsets { get; set; } = { OffsetTireData, OffsetLateralLoad + OffsetFRTire };
        public static int[] FR_LongitudinalLoadOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalLoad + OffsetFRTire };
        public static int[] FR_SlipAngleRadOffsets { get; set; } = { OffsetTireData, OffsetSlipAngleRad + OffsetFRTire };
        public static int[] FR_SlipRatioOffsets { get; set; } = { OffsetTireData, OffsetSlipRatio + OffsetFRTire };
        public static int[] FR_ContactLengthOffsets { get; set; } = { OffsetTireData, OffsetContactLength + OffsetFRTire };
        public static int[] FR_TravelSpeedOffsets { get; set; } = { OffsetTireData, OffsetTravelSpeed + OffsetFRTire };
        public static int[] FR_LateralSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLateralSlipSpeed + OffsetFRTire };//
        public static int[] FR_LongitudinalSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalSlipSpeed + OffsetFRTire };//
        public static int[] FR_MomentOfInertiaOffsets { get; set; } = { OffsetTireData, OffsetMomentOfInertia + OffsetFRTire };//
        public static int[] FR_CamberAngleRadOffsets { get; set; } = { OffsetTireData, OffsetCamberAngleRad + OffsetFRTire };//
        public static int[] FR_TireSteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad + OffsetFRTire };//
        public static int[] FR_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass + OffsetFRTire };//
        public static int[] FR_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius + OffsetFRTire };//
        public static int[] FR_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth + OffsetFRTire };//
        public static int[] FR_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate + OffsetFRTire };//
        public static int[] FR_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate + OffsetFRTire };//
        public static int[] FR_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection + OffsetFRTire };//
        public static int[] FR_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer + OffsetFRTire };
        public static int[] FR_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer + OffsetFRTire };

        public static int[] FR_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength + OffsetFRSuspension };
        public static int[] FR_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity + OffsetFRSuspension };
        /*

         */

        //Rear Left
        public static int[] rlsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature + OffsetRLTire };
        public static int[] rliOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature + OffsetRLTire };
        public static int[] RL_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity + OffsetRLTire };
        public static int[] RL_DeflectionOffsets { get; set; } = { OffsetTireData, OffsetDeflection + OffsetRLTire };
        public static int[] RL_LoadedRadiusOffsets { get; set; } = { OffsetTireData, OffsetLoadedRadius + OffsetRLTire };
        public static int[] RL_EffectiveRadiusOffsets { get; set; } = { OffsetTireData, OffsetEffectiveRadius + OffsetRLTire };
        public static int[] RL_CurrentContactBrakeTorqueOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetRLTire };
        public static int[] RL_CurrentContactBrakeTorqueMaxOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetRLTire };
        public static int[] RL_VerticalLoadOffsets { get; set; } = { OffsetTireData, OffsetVerticalLoad + OffsetRLTire };

        public static int[] RL_XOffsets { get; set; } = { OffsetTireData, OffsetTireX + OffsetRLTire };
        public static int[] RL_YOffsets { get; set; } = { OffsetTireData, OffsetTireY + OffsetRLTire };
        public static int[] RL_ZOffsets { get; set; } = { OffsetTireData, OffsetTireZ + OffsetRLTire };

        public static int[] RL_LateralLoadOffsets { get; set; } = { OffsetTireData, OffsetLateralLoad + OffsetRLTire };
        public static int[] RL_LongitudinalLoadOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalLoad + OffsetRLTire };
        public static int[] RL_SlipAngleRadOffsets { get; set; } = { OffsetTireData, OffsetSlipAngleRad + OffsetRLTire };
        public static int[] RL_SlipRatioOffsets { get; set; } = { OffsetTireData, OffsetSlipRatio + OffsetRLTire };
        public static int[] RL_ContactLengthOffsets { get; set; } = { OffsetTireData, OffsetContactLength + OffsetRLTire };
        public static int[] RL_TravelSpeedOffsets { get; set; } = { OffsetTireData, OffsetTravelSpeed + OffsetRLTire };
        public static int[] RL_LateralSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLateralSlipSpeed + OffsetRLTire };//
        public static int[] RL_LongitudinalSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalSlipSpeed + OffsetRLTire };//
        public static int[] RL_MomentOfInertiaOffsets { get; set; } = { OffsetTireData, OffsetMomentOfInertia + OffsetRLTire };//
        public static int[] RL_CamberAngleRadOffsets { get; set; } = { OffsetTireData, OffsetCamberAngleRad + OffsetRLTire };//
        public static int[] RL_TireSteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad + OffsetRLTire };//
        public static int[] RL_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass + OffsetRLTire };//
        public static int[] RL_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius + OffsetRLTire };//
        public static int[] RL_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth + OffsetRLTire };//
        public static int[] RL_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate + OffsetRLTire };//
        public static int[] RL_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate + OffsetRLTire };//
        public static int[] RL_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection + OffsetRLTire };//
        public static int[] RL_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer + OffsetRLTire };//
        public static int[] RL_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer + OffsetRLTire };//

        public static int[] RL_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength + OffsetRLSuspension };
        public static int[] RL_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity + OffsetRLSuspension };
        /*

         */

        //Rear Right
        public static int[] rrsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature + OffsetRRTire };
        public static int[] rriOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature + OffsetRRTire };
        public static int[] RR_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity + OffsetRRTire };
        public static int[] RR_DeflectionOffsets { get; set; } = { OffsetTireData, OffsetDeflection + OffsetRRTire };
        public static int[] RR_LoadedRadiusOffsets { get; set; } = { OffsetTireData, OffsetLoadedRadius + OffsetRRTire };
        public static int[] RR_EffectiveRadiusOffsets { get; set; } = { OffsetTireData, OffsetEffectiveRadius + OffsetRRTire };
        public static int[] RR_CurrentContactBrakeTorqueOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetRRTire };
        public static int[] RR_CurrentContactBrakeTorqueMaxOffsets { get; set; } = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetRRTire };
        public static int[] RR_VerticalLoadOffsets { get; set; } = { OffsetTireData, OffsetVerticalLoad + OffsetRRTire };

        public static int[] RR_XOffsets { get; set; } = { OffsetTireData, OffsetTireX + OffsetRRTire };
        public static int[] RR_YOffsets { get; set; } = { OffsetTireData, OffsetTireY + OffsetRRTire };
        public static int[] RR_ZOffsets { get; set; } = { OffsetTireData, OffsetTireZ + OffsetRRTire };

        public static int[] RR_LateralLoadOffsets { get; set; } = { OffsetTireData, OffsetLateralLoad + OffsetRRTire };
        public static int[] RR_LongitudinalLoadOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalLoad + OffsetRRTire };
        public static int[] RR_SlipAngleRadOffsets { get; set; } = { OffsetTireData, OffsetSlipAngleRad + OffsetRRTire };
        public static int[] RR_SlipRatioOffsets { get; set; } = { OffsetTireData, OffsetSlipRatio + OffsetRRTire };
        public static int[] RR_ContactLengthOffsets { get; set; } = { OffsetTireData, OffsetContactLength + OffsetRRTire };
        public static int[] RR_TravelSpeedOffsets { get; set; } = { OffsetTireData, OffsetTravelSpeed + OffsetRRTire };
        public static int[] RR_LateralSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLateralSlipSpeed + OffsetRRTire };//
        public static int[] RR_LongitudinalSlipSpeedOffsets { get; set; } = { OffsetTireData, OffsetLongitudinalSlipSpeed + OffsetRRTire };//
        public static int[] RR_MomentOfInertiaOffsets { get; set; } = { OffsetTireData, OffsetMomentOfInertia + OffsetRRTire };//
        public static int[] RR_CamberAngleRadOffsets { get; set; } = { OffsetTireData, OffsetCamberAngleRad + OffsetRRTire };//
        public static int[] RR_TireSteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad + OffsetRRTire };//
        public static int[] RR_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass + OffsetRRTire };//
        public static int[] RR_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius + OffsetRRTire };//
        public static int[] RR_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth + OffsetRRTire };//
        public static int[] RR_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate + OffsetRRTire };//
        public static int[] RR_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate + OffsetRRTire };//
        public static int[] RR_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection + OffsetRRTire };//
        public static int[] RR_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer + OffsetRRTire };//
        public static int[] RR_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer + OffsetRRTire };//

        public static int[] RR_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength + OffsetRRSuspension };
        public static int[] RR_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity + OffsetRRSuspension };
        /*

         */
    }
}
