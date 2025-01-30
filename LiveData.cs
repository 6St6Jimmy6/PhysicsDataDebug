using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.IO;

namespace Physics_Data_Debug
{
    class LiveData
    {
        public static bool logging { get; set; } = false;
        public static bool LogSettingsOpen { get; set; } = false;
        public static bool TireSettingsOpen { get; set; } = false;
        public static bool TemperaturesChartOpen { get; set; } = false;
        public static bool SuspensionSettingsOpen { get; set; } = false;
        public static bool GForceOpen { get; set; } = false;
        public static bool _4WheelsOpen { get; set; } = false;
        #region Data Name Strings Reference
        /*
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
        public static string sSuspensionVelocity { get; set; } = "Suspension Velocity";*/
        #endregion
        public static float fRadToDeg { get; } = Convert.ToSingle(180 / Math.PI);
        public static double dRadToDeg { get; } = 180 / Math.PI;

        public static float fKilometersPerHourToMetersPerSec { get; } = 1 / 3.6f;
        public static double dKilometersPerHourToMetersPerSec { get; } = 1 / 3.6d;

        public static int tickInterval = 50;

        #region Basest of the basest adresses
        public static ulong baseAddrTiresSuspensionLiftsDifferentialLocation { get; set; } = 0x18324C8;//0x1831EE0;//this was changing between cars, the new adrdess is only for the player
        public static ulong baseAddrEngineSpeed { get; set; } = 0x18327C8;
        public static ulong baseAddrRacetime { get; set; } = 0x1832648;
        public static ulong baseAddrLocationHeading { get; set; } = 0x1832B88;
        //Every update offsets the base address of the memory points. 99% of the time forwards.
        public static ulong baseAddrUpdt { get; set; } = 0x0;//0x9E00;
        //0x0;// April 2022 version 1.285308
        //0x4650;// May 2022
        //0x5710// October 2022
        // 0x67A0 November 2022 1838680 vs 1831EE0
        // 0x7DF0 April 2023
        // 0x9E00; March 2024 { get; set; } = 7DF0+2010 { get; set; } = 9E00

        // Older builds go backwards, so this is for them. Above should be 0x0 then.
        public static ulong baseAddrDodt { get; set; } = 0x0;//0x6DF8D8;
        #endregion
        #region Offsets
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
        #endregion

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


        #region Tire Data
        #region Font Left data
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
#endregion
        #region Front Right data
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
#endregion
        #region Rear Left data
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
#endregion
        #region Rear Right data
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
#endregion
#endregion
        #region Base Addresses
        //Base Addres for Tire data
        public static ulong baseAddrUpdtTiresSuspensionLiftsDifferential { get; set; }
        //Base Address for Speed and Lifts
        public static ulong baseAddrUpdtEngineSpeed { get; set; }
        //Base Address for Race Timer
        public static ulong baseAddrUpdtRacetimer { get; set; }
        //Base Address for Location and heading
        public static ulong baseAddrUpdtLocationHeading { get; set; }
        #endregion
        #region Pointer readers
        #region Race time pointer reader
        public static ulong raceTimerTargetAddr { get; set; }
#endregion
        #region Speed, Lifts, Engine Torque and DIfferential pointer reader
        //public static ulong speedTargetAddr { get; set; }
        public static ulong frontLiftTargetAddr { get; set; }
        public static ulong rearLiftTargetAddr { get; set; }
        public static ulong engineRPMTargetAddr { get; set; }
        public static ulong engineRPMAxleTargetAddr { get; set; }
        public static ulong engineTorqueTargetAddr { get; set; }
        public static ulong differentialOpenTargetAddr { get; set; }
        public static ulong differentialVelocityRadTargetAddr { get; set; }
        public static ulong differentialTorqueTargetAddr { get; set; }
#endregion
        #region Location and heading pointer reader
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
        #endregion
        #region Tire Data pointer readers
        #region Front Left pointers reader
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
#endregion
        #region Front Right pointers reader
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
#endregion
        #region Rear Left pointer reader
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
#endregion
        #region Rear Right pointer reader
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
        #endregion
        #endregion
        #endregion
        #region Pointers
        #region Speed and Lift pointers
        public static int[] speedOffsets { get; set; } = { OffsetSpeed };
        public static int[] frontLiftOffsets { get; set; } = { OffsetFrontLift };
        public static int[] rearLiftOffsets { get; set; } = { OffsetRearLift };
#endregion
        #region Engine and diff pointers 
        public static int[] engineRPMOffests { get; set; } = { OffsetEngineRPM };
        public static int[] engineRPMAxleOffests { get; set; } = { OffsetEngineRPMAxle };
        public static int[] engineTorqueOffsets { get; set; } = { OffsetEngineTorque };
        public static int[] differentialOpenOffsets { get; set; } = { OffsetDifferentialOpen };
        public static int[] differentialVelocityRadOffsets { get; set; } = { OffsetDifferentialVelocityRad };
        public static int[] differentialTorqueOffsets { get; set; } = { OffsetDifferentialTorque };
#endregion
        #region Race time pointer
        public static int[] raceTimerOffsets { get; set; } = { OffsetRaceTime };
#endregion
        #region Location and heading pointers
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
#endregion
        #region Tire & Suspension Data pointers
        #region Front Left
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
        #endregion
        #region Front Right
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
#endregion
        #region Rear Left
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
#endregion
        #region Rear Right
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
        #endregion
        #endregion
        #endregion
        public static Process process;
        public static Memory.Win64.MemoryHelper64 Helper { get; set; }


        public static readonly int[] raceTimeArray = new int[3];
        public static readonly int[] tickTimeArray = new int[3];
        public static int elapsedTime = 0;

        public static float GetFloatData(ulong baseAddr, int[] offsets)
        {
            Helper = new Memory.Win64.MemoryHelper64(process);

            ulong bAU = Helper.GetBaseAddress(baseAddr + baseAddrUpdt - baseAddrDodt);

            return Helper.ReadMemory<float>(Memory.Utils.MemoryUtils.OffsetCalculator(Helper, bAU, offsets));
        }
        public static int GetIntData(ulong baseAddr, int[] offsets)
        {
            Helper = new Memory.Win64.MemoryHelper64(process);

            ulong bAU = Helper.GetBaseAddress(baseAddr + baseAddrUpdt - baseAddrDodt);

            return Helper.ReadMemory<int>(Memory.Utils.MemoryUtils.OffsetCalculator(Helper, bAU, offsets));
        }
        public static void GetData()
        {
            if (process == null) return;

            Helper = new Memory.Win64.MemoryHelper64(process);
            #region Base Addresses
            //Base Addres for Tire data
            baseAddrUpdtTiresSuspensionLiftsDifferential = Helper.GetBaseAddress(baseAddrTiresSuspensionLiftsDifferentialLocation + baseAddrUpdt - baseAddrDodt);
            //Base Address for Speed and Lifts
            baseAddrUpdtEngineSpeed = Helper.GetBaseAddress(baseAddrEngineSpeed + baseAddrUpdt - baseAddrDodt);
            //Base Address for Race Timer
            baseAddrUpdtRacetimer = Helper.GetBaseAddress(baseAddrRacetime + baseAddrUpdt - baseAddrDodt);
            //Base Address for Location and Heading
            baseAddrUpdtLocationHeading = Helper.GetBaseAddress(baseAddrLocationHeading + baseAddrUpdt - baseAddrDodt);
            #endregion

            #region Target Addresses
            //Race time pointer reader
            raceTimerTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtRacetimer, raceTimerOffsets);
            //Speed, Lifts, Engine Torque and DIfferential pointer reader
            //speedTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtEngineSpeed, speedOffsets);
            frontLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, frontLiftOffsets);
            rearLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rearLiftOffsets);
            engineRPMTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtEngineSpeed, engineRPMOffests);
            engineRPMAxleTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtEngineSpeed, engineRPMAxleOffests);
            engineTorqueTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtEngineSpeed, engineTorqueOffsets);
            differentialOpenTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, differentialOpenOffsets);
            differentialVelocityRadTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, differentialVelocityRadOffsets);
            differentialTorqueTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, differentialTorqueOffsets);

            //Location and header pointer reader
            /*
            TXTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, TXOffsets);
            TYTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, TYOffsets);
            TZTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, TZOffsets);
            */
            R11TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R11Offsets);
            R12TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R12Offsets);
            R13TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R13Offsets);
            /*
            R21TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R21Offsets);
            R22TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R22Offsets);
            R23TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R23ffsets);
            R31TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R31Offsets);
            R32TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R32Offsets);
            R33TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, R33Offsets);
            Q1TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, Q1Offsets);
            Q2TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, Q2Offsets);
            Q3TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, Q3Offsets);
            Q4TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, Q4Offsets);
            */
            XAccelerationTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, XAccelerationOffsets);
            YAccelerationTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, YAccelerationOffsets);
            ZAccelerationTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtLocationHeading, ZAccelerationOffsets);

            //Tire Data pointer readers
            //Front Left
            FL_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, flsOffsets);
            FL_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, fliOffsets);
            FL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_AngularVelocityOffsets);
            FL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_DeflectionOffsets);
            FL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LoadedRadiusOffsets);
            FL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_EffectiveRadiusOffsets);
            FL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_CurrentContactBrakeTorqueOffsets);
            FL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_CurrentContactBrakeTorqueMaxOffsets);
            FL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_VerticalLoadOffsets);
            FL_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_XOffsets);
            FL_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_YOffsets);
            FL_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ZOffsets);
            FL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LateralLoadOffsets);
            FL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LongitudinalLoadOffsets);
            FL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SlipAngleRadOffsets);
            FL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SlipRatioOffsets);
            FL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ContactLengthOffsets);
            FL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TravelSpeedOffsets);
            FL_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LateralSlipSpeedOffsets);//
            FL_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_LongitudinalSlipSpeedOffsets);//
            FL_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_CamberAngleRadOffsets);//
            FL_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireSteerAngleRadOffsets);//

            FL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireMassOffsets);//
            FL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireRadiusOffsets);//
            FL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireWidthOffsets);//
            FL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireSpringRateOffsets);//
            FL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireDamperRateOffsets);//
            FL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_TireMaxDeflectionOffsets);//
            FL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ThermalAirTransferOffsets);//
            FL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_ThermalInnerTransferOffsets);//
            FL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_MomentOfInertiaOffsets);//

            FL_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SuspensionLengthOffsets);
            FL_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FL_SuspensionVelocityOffsets);
            /*

             */

            //Front Right
            FR_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, frsOffsets);
            FR_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, friOffsets);
            FR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_AngularVelocityOffsets);
            FR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_DeflectionOffsets);
            FR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LoadedRadiusOffsets);
            FR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_EffectiveRadiusOffsets);
            FR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_CurrentContactBrakeTorqueOffsets);
            FR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_CurrentContactBrakeTorqueMaxOffsets);
            FR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_VerticalLoadOffsets);
            FR_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_XOffsets);
            FR_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_YOffsets);
            FR_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ZOffsets);
            FR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LateralLoadOffsets);
            FR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LongitudinalLoadOffsets);
            FR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SlipAngleRadOffsets);
            FR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SlipRatioOffsets);
            FR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ContactLengthOffsets);
            FR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TravelSpeedOffsets);
            FR_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LateralSlipSpeedOffsets);//
            FR_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_LongitudinalSlipSpeedOffsets);//
            FR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_MomentOfInertiaOffsets);//
            FR_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_CamberAngleRadOffsets);//
            FR_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireSteerAngleRadOffsets);//
            FR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireMassOffsets);//
            FR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireRadiusOffsets);//
            FR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireWidthOffsets);//
            FR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireSpringRateOffsets);//
            FR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireDamperRateOffsets);//
            FR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_TireMaxDeflectionOffsets);//
            FR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ThermalAirTransferOffsets);//
            FR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_ThermalInnerTransferOffsets);//

            FR_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SuspensionLengthOffsets);
            FR_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, FR_SuspensionVelocityOffsets);
            /*

             */

            //Rear Left
            RL_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rlsOffsets);
            RL_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rliOffsets);
            RL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_AngularVelocityOffsets);
            RL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_DeflectionOffsets);
            RL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LoadedRadiusOffsets);
            RL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_EffectiveRadiusOffsets);
            RL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_CurrentContactBrakeTorqueOffsets);
            RL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_CurrentContactBrakeTorqueMaxOffsets);
            RL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_VerticalLoadOffsets);
            RL_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_XOffsets);
            RL_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_YOffsets);
            RL_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ZOffsets);
            RL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LateralLoadOffsets);
            RL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LongitudinalLoadOffsets);
            RL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SlipAngleRadOffsets);
            RL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SlipRatioOffsets);
            RL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ContactLengthOffsets);
            RL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TravelSpeedOffsets);
            RL_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LateralSlipSpeedOffsets);//
            RL_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_LongitudinalSlipSpeedOffsets);//
            RL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_MomentOfInertiaOffsets);//
            RL_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_CamberAngleRadOffsets);//
            RL_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireSteerAngleRadOffsets);//
            RL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireMassOffsets);//
            RL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireRadiusOffsets);//
            RL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireWidthOffsets);//
            RL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireSpringRateOffsets);//
            RL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireDamperRateOffsets);//
            RL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_TireMaxDeflectionOffsets);//
            RL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ThermalAirTransferOffsets);//
            RL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_ThermalInnerTransferOffsets);//

            RL_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SuspensionLengthOffsets);
            RL_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RL_SuspensionVelocityOffsets);
            /*

             */

            //Rear Right
            RR_TreadTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rrsOffsets);
            RR_InnerTemperatureTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, rriOffsets);
            RR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_AngularVelocityOffsets);
            RR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_DeflectionOffsets);
            RR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LoadedRadiusOffsets);
            RR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_EffectiveRadiusOffsets);
            RR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_CurrentContactBrakeTorqueOffsets);
            RR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_CurrentContactBrakeTorqueMaxOffsets);
            RR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_VerticalLoadOffsets);
            RR_X_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_XOffsets);
            RR_Y_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_YOffsets);
            RR_Z_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ZOffsets);
            RR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LateralLoadOffsets);
            RR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LongitudinalLoadOffsets);
            RR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SlipAngleRadOffsets);
            RR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SlipRatioOffsets);
            RR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ContactLengthOffsets);
            RR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TravelSpeedOffsets);
            RR_LateralSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LateralSlipSpeedOffsets);//
            RR_LongitudinalSlipSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_LongitudinalSlipSpeedOffsets);//
            RR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_MomentOfInertiaOffsets);//
            RR_CamberAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_CamberAngleRadOffsets);//
            RR_TireSteerAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireSteerAngleRadOffsets);//
            RR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireMassOffsets);//
            RR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireRadiusOffsets);//
            RR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireWidthOffsets);//
            RR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireSpringRateOffsets);//
            RR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireDamperRateOffsets);//
            RR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_TireMaxDeflectionOffsets);//
            RR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ThermalAirTransferOffsets);//
            RR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_ThermalInnerTransferOffsets);//

            RR_SuspensionLenght_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SuspensionLengthOffsets);
            RR_SuspensionVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(Helper, baseAddrUpdtTiresSuspensionLiftsDifferential, RR_SuspensionVelocityOffsets);
            /*

             */
            #endregion

            //Read race time
            #region Race Time
            RaceTime = Helper.ReadMemory<int>(raceTimerTargetAddr);
            //Time interval between the last tick. It only naturally works when the race is going but pretty accurate then and no interference every second.
            raceTimeArray[raceTimeArray.Length - 1] = RaceTime;
            Array.Copy(raceTimeArray, 1, raceTimeArray, 0, raceTimeArray.Length - 1);
            elapsedTime = raceTimeArray[1] - raceTimeArray[0];

            #endregion

            //Read Speed, Lifts, Engine Torque and Differential stuff
            #region Speed, Lifts, Engine Torque and Differential
            speed = GetFloatData(baseAddrEngineSpeed, speedOffsets);

            //speed = Helper.ReadMemory<float>(speedTargetAddr);
            frontLift = Helper.ReadMemory<float>(frontLiftTargetAddr);
            rearLift = Helper.ReadMemory<float>(rearLiftTargetAddr);
            engineRPM = Helper.ReadMemory<float>(engineRPMTargetAddr);
            engineRPMAxle = Helper.ReadMemory<float>(engineRPMAxleTargetAddr);
            engineTorque = Helper.ReadMemory<float>(engineTorqueTargetAddr);
            enginePower = engineTorque * engineRPM / 9549;
            differentialLocked = Helper.ReadMemory<byte>(differentialOpenTargetAddr);
            differentialVelocityRad = Helper.ReadMemory<float>(differentialVelocityRadTargetAddr);
            differentialTorque = Helper.ReadMemory<float>(differentialTorqueTargetAddr);
            #endregion

            //Read Location and heading
            #region Location, heading, acceleration and g-force
            // Most of these not needed for now
            /*
            TX = Helper.ReadMemory<float>(TXTargetAddr);
            TY = Helper.ReadMemory<float>(TYTargetAddr);
            TZ = Helper.ReadMemory<float>(TZTargetAddr);*/
            R11 = Helper.ReadMemory<float>(R11TargetAddr);
            R12 = Helper.ReadMemory<float>(R12TargetAddr);
            R13 = Helper.ReadMemory<float>(R13TargetAddr);
            /*
            R21 = Helper.ReadMemory<float>(A2TargetAddr);
            R22 = Helper.ReadMemory<float>(B2TargetAddr);
            R23 = Helper.ReadMemory<float>(C2TargetAddr);
            R31 = Helper.ReadMemory<float>(A3TargetAddr);
            R32 = Helper.ReadMemory<float>(B3TargetAddr);
            R33 = Helper.ReadMemory<float>(C3TargetAddr);
            Q1 = Helper.ReadMemory<float>(Q1TargetAddr);
            Q2 = Helper.ReadMemory<float>(Q2TargetAddr);
            Q3 = Helper.ReadMemory<float>(Q3TargetAddr);
            Q4 = Helper.ReadMemory<float>(Q4TargetAddr);
            */
            XAcceleration = Helper.ReadMemory<float>(XAccelerationTargetAddr);
            YAcceleration = Helper.ReadMemory<float>(YAccelerationTargetAddr);
            ZAcceleration = Helper.ReadMemory<float>(ZAccelerationTargetAddr);

            // Getting rid of too big or low values when the pointer is changing or something odd happens, so it won't crash the math for Int32 later.
            if (XAcceleration > 10000 || XAcceleration < -10000)
            {
                XAcceleration = 10000;
            }
            if (YAcceleration > 10000 || YAcceleration < -10000)
            {
                YAcceleration = 10000;
            }
            if (ZAcceleration > 10000 || ZAcceleration < -10000)
            {
                ZAcceleration = 10000;
            }

            // Getting the XZ direction where in the world the car is going.

            if (XAcceleration > 0)
            {
                if (ZAcceleration > 0)
                {
                    XZAccelerationAngleDeg = (float)(180 + (Math.Atan(XAcceleration / ZAcceleration) * fRadToDeg));
                    XZAccelerationAngleRad = (Math.PI + (Math.Atan(XAcceleration / ZAcceleration)));
                }
                else if (ZAcceleration < 0)
                {
                    XZAccelerationAngleDeg = (360 + (Math.Atan(XAcceleration / ZAcceleration) * fRadToDeg));
                    XZAccelerationAngleRad = (2 * Math.PI + (Math.Atan(XAcceleration / ZAcceleration)));
                }
                else
                {
                    //XZAccelerationAngleDeg = 270f;
                    XZAccelerationAngleRad = 1.5 * Math.PI;
                }
            }
            else if (XAcceleration < 0)
            {
                if (ZAcceleration > 0)
                {
                    XZAccelerationAngleDeg = (float)(180 + (Math.Atan(XAcceleration / ZAcceleration) * fRadToDeg));
                    XZAccelerationAngleRad = (Math.PI + (Math.Atan(XAcceleration / ZAcceleration)));
                }
                else if (ZAcceleration < 0)
                {
                    XZAccelerationAngleDeg = (float)(0d + (Math.Atan(XAcceleration / ZAcceleration) * fRadToDeg));
                    XZAccelerationAngleRad = (0d + (Math.Atan(XAcceleration / ZAcceleration)));
                }
                else
                {
                    XZAccelerationAngleDeg = 90f;
                    XZAccelerationAngleRad = 0.5 * Math.PI;
                }
            }
            else
            {
                if (ZAcceleration > 0f)
                {
                    XZAccelerationAngleDeg = 180f;
                    XZAccelerationAngleRad = Math.PI;
                }
                else if (ZAcceleration < 0f)
                {
                    XZAccelerationAngleDeg = 360f;
                    XZAccelerationAngleRad = 2 * Math.PI;
                }
                else
                {
                    XZAccelerationAngleDeg = 0f;
                    XZAccelerationAngleRad = 0d;
                }
            }

            XZAcceleration = Math.Sqrt(Math.Pow(XAcceleration, 2) + Math.Pow(ZAcceleration, 2));
            XYZAcceleration = Math.Sqrt(Math.Pow(XZAcceleration, 2) + Math.Pow(YAcceleration, 2));

            XG = XAcceleration / g;
            YG = YAcceleration / g;
            ZG = ZAcceleration / g;

            // Get normalized heading, so it's easy to draw for example the g-forces in the right direction compared to the car pivot point.
            playerRotation = new Matrix4x4(R11, R12, R13, 0, R21, R22, R23, 0, R31, R32, R33, 0, 0, 0, 0, 1);
            Angle3D.GetAngles(playerRotation);
            XZG = Math.Sqrt(Math.Pow(XG, 2) + Math.Pow(ZG, 2));
            XYZG = Math.Sqrt(Math.Pow(YG, 2) + Math.Pow(XZG, 2));

            if (rotationYRad < 3 * Math.PI &&
                rotationYRad > -3 * Math.PI &&
                XZAccelerationAngleRad < 3 * Math.PI &&
                XZAccelerationAngleRad > -3 * Math.PI)// These are to make sure if there's some huge or almost small value, that it won't get calculated, because those throw errors. Usually can happen when changing car or track etc.
            {
                if (rotationYRad > XZAccelerationAngleRad)
                {
                    if (XZAccelerationAngleRad - rotationYRad > 2 * Math.PI)
                    {
                        XZGAngleRad = XZAccelerationAngleRad - rotationYRad - 2 * Math.PI;
                    }
                    else
                    {
                        XZGAngleRad = 2 * Math.PI + XZAccelerationAngleRad - rotationYRad;
                    }
                }
                else
                {
                    if (XZAccelerationAngleRad - rotationYRad > 2 * Math.PI)
                    {
                        XZGAngleRad = XZAccelerationAngleRad - rotationYRad - 2 * Math.PI;
                    }
                    else
                    {
                        XZGAngleRad = XZAccelerationAngleRad - rotationYRad;
                    }
                }
            }
            XZGAngleDeg = XZGAngleRad * dRadToDeg; // radians to degrees if needed.

            // These are rotated to the heading, so you want to use these likely

            XGRotated = Math.Sin(XZGAngleRad) * XZG;
            ZGRotated = Math.Cos(XZGAngleRad) * XZG;
            YGRotated = YG;// Y axis isn't ever rotated
            #endregion

            //Read Tire Data
            #region Tire Data
            //Front Left
            #region Front Left
            FL_TreadTemperature = Helper.ReadMemory<float>(FL_TreadTemperatureTargetAddr);
            FL_InnerTemperature = Helper.ReadMemory<float>(FL_InnerTemperatureTargetAddr);
            FL_AngularVelocity = Helper.ReadMemory<float>(FL_AngularVelocity_TargetAddr);
            FL_VerticalDeflection = Helper.ReadMemory<float>(FL_Deflection_TargetAddr);
            FL_LoadedRadius = Helper.ReadMemory<float>(FL_LoadedRadius_TargetAddr);
            FL_EffectiveRadius = Helper.ReadMemory<float>(FL_EffectiveRadius_TargetAddr);
            FL_CurrentContactBrakeTorque = Helper.ReadMemory<float>(FL_CurrentContactBrakeTorque_TargetAddr);
            FL_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(FL_CurrentContactBrakeTorqueMax_TargetAddr);
            FL_VerticalLoad = Helper.ReadMemory<float>(FL_VerticalLoad_TargetAddr);
            FL_X = Helper.ReadMemory<float>(FL_X_TargetAddr);
            FL_Y = Helper.ReadMemory<float>(FL_Y_TargetAddr);
            FL_Z = Helper.ReadMemory<float>(FL_Z_TargetAddr);
            FL_LateralLoad = Helper.ReadMemory<float>(FL_LateralLoad_TargetAddr);
            FL_LongitudinalLoad = Helper.ReadMemory<float>(FL_LongitudinalLoad_TargetAddr);
            FL_SlipAngleRad = Helper.ReadMemory<float>(FL_SlipAngleRad_TargetAddr);
            FL_SlipAngleDeg = FL_SlipAngleRad * fRadToDeg;
            FL_SlipRatio = Helper.ReadMemory<float>(FL_SlipRatio_TargetAddr);
            FL_ContactLength = Helper.ReadMemory<float>(FL_ContactLength_TargetAddr);
            FL_TravelSpeed = Helper.ReadMemory<float>(FL_TravelSpeed_TargetAddr);
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
                FL_LateralFriction = FL_LateralLoad / FL_VerticalLoad;
                FL_LongitudinalFriction = FL_LongitudinalLoad / FL_VerticalLoad;
                FL_LateralSlipSpeed = Helper.ReadMemory<float>(FL_LateralSlipSpeed_TargetAddr);
                FL_LongitudinalSlipSpeed = Helper.ReadMemory<float>(FL_LongitudinalSlipSpeed_TargetAddr);
            }
            FL_TotalFriction = (float)Math.Sqrt(Math.Pow(FL_LateralFriction, 2) + Math.Pow(FL_LongitudinalFriction, 2));//
            if (FL_LateralFriction > 0)
            {
                if (FL_LongitudinalFriction > 0)
                {
                    FL_TotalFrictionAngle = (float)(90 - (Math.Atan(FL_LongitudinalFriction / FL_LateralFriction) * fRadToDeg));
                }
                else if (FL_LongitudinalFriction < 0)
                {
                    FL_TotalFrictionAngle = (float)(90 - (Math.Atan(FL_LongitudinalFriction / FL_LateralFriction) * fRadToDeg));
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
                    FL_TotalFrictionAngle = (float)(270 + (Math.Atan(FL_LongitudinalFriction / Math.Abs(FL_LateralFriction)) * fRadToDeg));
                }
                else if (FL_LongitudinalFriction < 0)
                {
                    FL_TotalFrictionAngle = (float)(270 - (Math.Atan(FL_LongitudinalFriction / FL_LateralFriction) * fRadToDeg));
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

            FL_CamberAngleRad = Helper.ReadMemory<float>(FL_CamberAngleRad_TargetAddr);
            FL_SteerAngleRad = Helper.ReadMemory<float>(FL_TireSteerAngleRad_TargetAddr);
            FL_CamberAngleDeg = FL_CamberAngleRad * fRadToDeg;
            FL_SteerAngleDeg = FL_SteerAngleRad * fRadToDeg;

            FL_MomentOfInertia = Helper.ReadMemory<float>(FL_MomentOfInertia_TargetAddr);
            FL_TireMass = Helper.ReadMemory<float>(FL_TireMass_TargetAddr);
            FL_TireRadius = Helper.ReadMemory<float>(FL_TireRadius_TargetAddr);
            FL_TireWidth = Helper.ReadMemory<float>(FL_TireWidth_TargetAddr);
            FL_TireSpringRate = Helper.ReadMemory<float>(FL_TireSpringRate_TargetAddr);
            FL_TireDamperRate = Helper.ReadMemory<float>(FL_TireDamperRate_TargetAddr);
            FL_TireMaxDeflection = Helper.ReadMemory<float>(FL_TireMaxDeflection_TargetAddr);
            FL_ThermalAirTransfer = Helper.ReadMemory<float>(FL_ThermalAirTransfer_TargetAddr);
            FL_ThermalInnerTransfer = Helper.ReadMemory<float>(FL_ThermalInnerTransfer_TargetAddr);

            FL_SuspensionLength = Helper.ReadMemory<float>(FL_SuspensionLenght_TargetAddr);
            FL_SuspensionVelocity = Helper.ReadMemory<float>(FL_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion

            //Font Right
            #region Front Right
            FR_TreadTemperature = Helper.ReadMemory<float>(FR_TreadTemperatureTargetAddr);
            FR_InnerTemperature = Helper.ReadMemory<float>(FR_InnerTemperatureTargetAddr);
            FR_AngularVelocity = Helper.ReadMemory<float>(FR_AngularVelocity_TargetAddr);
            FR_VerticalDeflection = Helper.ReadMemory<float>(FR_Deflection_TargetAddr);
            FR_LoadedRadius = Helper.ReadMemory<float>(FR_LoadedRadius_TargetAddr);
            FR_EffectiveRadius = Helper.ReadMemory<float>(FR_EffectiveRadius_TargetAddr);
            FR_CurrentContactBrakeTorque = Helper.ReadMemory<float>(FR_CurrentContactBrakeTorque_TargetAddr);
            FR_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(FR_CurrentContactBrakeTorqueMax_TargetAddr);
            FR_VerticalLoad = Helper.ReadMemory<float>(FR_VerticalLoad_TargetAddr);
            FR_X = Helper.ReadMemory<float>(FR_X_TargetAddr);
            FR_Y = Helper.ReadMemory<float>(FR_Y_TargetAddr);
            FR_Z = Helper.ReadMemory<float>(FR_Z_TargetAddr);
            FR_LateralLoad = Helper.ReadMemory<float>(FR_LateralLoad_TargetAddr);
            FR_LongitudinalLoad = Helper.ReadMemory<float>(FR_LongitudinalLoad_TargetAddr);
            FR_SlipAngleRad = Helper.ReadMemory<float>(FR_SlipAngleRad_TargetAddr);
            FR_SlipAngleDeg = FR_SlipAngleRad * fRadToDeg;
            FR_SlipRatio = Helper.ReadMemory<float>(FR_SlipRatio_TargetAddr);
            FR_ContactLength = Helper.ReadMemory<float>(FR_ContactLength_TargetAddr);
            FR_TravelSpeed = Helper.ReadMemory<float>(FR_TravelSpeed_TargetAddr);
            if (FR_VerticalLoad == 0)
            {
                FR_LateralFriction = 0;
                FR_LongitudinalFriction = 0;
                FR_LateralSlipSpeed = 0;//
                FR_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                FR_LateralFriction = FR_LateralLoad / FR_VerticalLoad;
                FR_LongitudinalFriction = FR_LongitudinalLoad / FR_VerticalLoad;
                FR_LateralSlipSpeed = Helper.ReadMemory<float>(FR_LateralSlipSpeed_TargetAddr);
                FR_LongitudinalSlipSpeed = Helper.ReadMemory<float>(FR_LongitudinalSlipSpeed_TargetAddr);
            }
            FR_TotalFriction = (float)Math.Sqrt(Math.Pow(FR_LateralFriction, 2) + Math.Pow(FR_LongitudinalFriction, 2));//
            if (FR_LateralFriction > 0)
            {
                if (FR_LongitudinalFriction > 0)
                {
                    FR_TotalFrictionAngle = (float)(90 - (Math.Atan(FR_LongitudinalFriction / FR_LateralFriction) * fRadToDeg));
                }
                else if (FR_LongitudinalFriction < 0)
                {
                    FR_TotalFrictionAngle = (float)(90 - (Math.Atan(FR_LongitudinalFriction / FR_LateralFriction) * fRadToDeg));
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
                    FR_TotalFrictionAngle = (float)(270 + (Math.Atan(FR_LongitudinalFriction / Math.Abs(FR_LateralFriction)) * fRadToDeg));
                }
                else if (FR_LongitudinalFriction < 0)
                {
                    FR_TotalFrictionAngle = (float)(270 - (Math.Atan(FR_LongitudinalFriction / FR_LateralFriction) * fRadToDeg));
                }
                else
                {
                    FR_TotalFrictionAngle = 270;
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
            FR_MomentOfInertia = Helper.ReadMemory<float>(FR_MomentOfInertia_TargetAddr);
            FR_CamberAngleRad = Helper.ReadMemory<float>(FR_CamberAngleRad_TargetAddr);
            FR_SteerAngleRad = Helper.ReadMemory<float>(FR_TireSteerAngleRad_TargetAddr);
            FR_CamberAngleDeg = FR_CamberAngleRad * fRadToDeg;
            FR_SteerAngleDeg = FR_SteerAngleRad * fRadToDeg;
            FR_TireMass = Helper.ReadMemory<float>(FR_TireMass_TargetAddr);
            FR_TireRadius = Helper.ReadMemory<float>(FR_TireRadius_TargetAddr);
            FR_TireWidth = Helper.ReadMemory<float>(FR_TireWidth_TargetAddr);
            FR_TireSpringRate = Helper.ReadMemory<float>(FR_TireSpringRate_TargetAddr);
            FR_TireDamperRate = Helper.ReadMemory<float>(FR_TireDamperRate_TargetAddr);
            FR_TireMaxDeflection = Helper.ReadMemory<float>(FR_TireMaxDeflection_TargetAddr);
            FR_ThermalAirTransfer = Helper.ReadMemory<float>(FR_ThermalAirTransfer_TargetAddr);
            FR_ThermalInnerTransfer = Helper.ReadMemory<float>(FR_ThermalInnerTransfer_TargetAddr);

            FR_SuspensionLength = Helper.ReadMemory<float>(FR_SuspensionLenght_TargetAddr);
            FR_SuspensionVelocity = Helper.ReadMemory<float>(FR_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion

            //Rear Left
            #region Rear Left
            RL_TreadTemperature = Helper.ReadMemory<float>(RL_TreadTemperatureTargetAddr);
            RL_InnerTemperature = Helper.ReadMemory<float>(RL_InnerTemperatureTargetAddr);
            RL_AngularVelocity = Helper.ReadMemory<float>(RL_AngularVelocity_TargetAddr);
            RL_VerticalDeflection = Helper.ReadMemory<float>(RL_Deflection_TargetAddr);
            RL_LoadedRadius = Helper.ReadMemory<float>(RL_LoadedRadius_TargetAddr);
            RL_EffectiveRadius = Helper.ReadMemory<float>(RL_EffectiveRadius_TargetAddr);
            RL_CurrentContactBrakeTorque = Helper.ReadMemory<float>(RL_CurrentContactBrakeTorque_TargetAddr);
            RL_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(RL_CurrentContactBrakeTorqueMax_TargetAddr);
            RL_VerticalLoad = Helper.ReadMemory<float>(RL_VerticalLoad_TargetAddr);
            RL_X = Helper.ReadMemory<float>(RL_X_TargetAddr);
            RL_Y = Helper.ReadMemory<float>(RL_Y_TargetAddr);
            RL_Z = Helper.ReadMemory<float>(RL_Z_TargetAddr);
            RL_LateralLoad = Helper.ReadMemory<float>(RL_LateralLoad_TargetAddr);
            RL_LongitudinalLoad = Helper.ReadMemory<float>(RL_LongitudinalLoad_TargetAddr);
            RL_SlipAngleRad = Helper.ReadMemory<float>(RL_SlipAngleRad_TargetAddr);
            RL_SlipAngleDeg = RL_SlipAngleRad * fRadToDeg;
            RL_SlipRatio = Helper.ReadMemory<float>(RL_SlipRatio_TargetAddr);
            RL_ContactLength = Helper.ReadMemory<float>(RL_ContactLength_TargetAddr);
            RL_TravelSpeed = Helper.ReadMemory<float>(RL_TravelSpeed_TargetAddr);
            if (RL_VerticalLoad == 0)
            {
                RL_LateralFriction = 0;
                RL_LongitudinalFriction = 0;
                RL_LateralSlipSpeed = 0;//
                RL_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                RL_LateralFriction = RL_LateralLoad / RL_VerticalLoad;
                RL_LongitudinalFriction = RL_LongitudinalLoad / RL_VerticalLoad;
                RL_LateralSlipSpeed = Helper.ReadMemory<float>(RL_LateralSlipSpeed_TargetAddr);
                RL_LongitudinalSlipSpeed = Helper.ReadMemory<float>(RL_LongitudinalSlipSpeed_TargetAddr);
            }
            RL_TotalFriction = (float)Math.Sqrt(Math.Pow(RL_LateralFriction, 2) + Math.Pow(RL_LongitudinalFriction, 2));//
            if (RL_LateralFriction > 0)
            {
                if (RL_LongitudinalFriction > 0)
                {
                    RL_TotalFrictionAngle = (float)(90 - (Math.Atan(RL_LongitudinalFriction / RL_LateralFriction) * fRadToDeg));
                }
                else if (RL_LongitudinalFriction < 0)
                {
                    RL_TotalFrictionAngle = (float)(90 - (Math.Atan(RL_LongitudinalFriction / RL_LateralFriction) * fRadToDeg));
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
                    RL_TotalFrictionAngle = (float)(270 + (Math.Atan(RL_LongitudinalFriction / Math.Abs(RL_LateralFriction)) * fRadToDeg));
                }
                else if (RL_LongitudinalFriction < 0)
                {
                    RL_TotalFrictionAngle = (float)(270 - (Math.Atan(RL_LongitudinalFriction / RL_LateralFriction) * fRadToDeg));
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
            RL_MomentOfInertia = Helper.ReadMemory<float>(RL_MomentOfInertia_TargetAddr);
            RL_CamberAngleRad = Helper.ReadMemory<float>(RL_CamberAngleRad_TargetAddr);
            RL_SteerAngleRad = Helper.ReadMemory<float>(RL_TireSteerAngleRad_TargetAddr);
            RL_CamberAngleDeg = RL_CamberAngleRad * fRadToDeg;
            RL_SteerAngleDeg = RL_SteerAngleRad * fRadToDeg;
            RL_TireMass = Helper.ReadMemory<float>(RL_TireMass_TargetAddr);
            RL_TireRadius = Helper.ReadMemory<float>(RL_TireRadius_TargetAddr);
            RL_TireWidth = Helper.ReadMemory<float>(RL_TireWidth_TargetAddr);
            RL_TireSpringRate = Helper.ReadMemory<float>(RL_TireSpringRate_TargetAddr);
            RL_TireDamperRate = Helper.ReadMemory<float>(RL_TireDamperRate_TargetAddr);
            RL_TireMaxDeflection = Helper.ReadMemory<float>(RL_TireMaxDeflection_TargetAddr);
            RL_ThermalAirTransfer = Helper.ReadMemory<float>(RL_ThermalAirTransfer_TargetAddr);
            RL_ThermalInnerTransfer = Helper.ReadMemory<float>(RL_ThermalInnerTransfer_TargetAddr);

            RL_SuspensionLength = Helper.ReadMemory<float>(RL_SuspensionLenght_TargetAddr);
            RL_SuspensionVelocity = Helper.ReadMemory<float>(RL_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion

            //Rear Right
            #region Rear Right
            RR_TreadTemperature = Helper.ReadMemory<float>(RR_TreadTemperatureTargetAddr);
            RR_InnerTemperature = Helper.ReadMemory<float>(RR_InnerTemperatureTargetAddr);
            RR_AngularVelocity = Helper.ReadMemory<float>(RR_AngularVelocity_TargetAddr);
            RR_VerticalDeflection = Helper.ReadMemory<float>(RR_Deflection_TargetAddr);
            RR_LoadedRadius = Helper.ReadMemory<float>(RR_LoadedRadius_TargetAddr);
            RR_EffectiveRadius = Helper.ReadMemory<float>(RR_EffectiveRadius_TargetAddr);
            RR_CurrentContactBrakeTorque = Helper.ReadMemory<float>(RR_CurrentContactBrakeTorque_TargetAddr);
            RR_CurrentContactBrakeTorqueMax = Helper.ReadMemory<float>(RR_CurrentContactBrakeTorqueMax_TargetAddr);
            RR_VerticalLoad = Helper.ReadMemory<float>(RR_VerticalLoad_TargetAddr);
            RR_X = Helper.ReadMemory<float>(RR_X_TargetAddr);
            RR_Y = Helper.ReadMemory<float>(RR_Y_TargetAddr);
            RR_Z = Helper.ReadMemory<float>(RR_Z_TargetAddr);
            RR_LateralLoad = Helper.ReadMemory<float>(RR_LateralLoad_TargetAddr);
            RR_LongitudinalLoad = Helper.ReadMemory<float>(RR_LongitudinalLoad_TargetAddr);
            RR_SlipAngleRad = Helper.ReadMemory<float>(RR_SlipAngleRad_TargetAddr);
            RR_SlipAngleDeg = RR_SlipAngleRad * fRadToDeg;
            RR_SlipRatio = Helper.ReadMemory<float>(RR_SlipRatio_TargetAddr);
            RR_ContactLength = Helper.ReadMemory<float>(RR_ContactLength_TargetAddr);
            RR_TravelSpeed = Helper.ReadMemory<float>(RR_TravelSpeed_TargetAddr);
            RR_LateralFriction = RR_LateralLoad / RR_VerticalLoad;
            if (RR_VerticalLoad == 0)
            {
                RR_LongitudinalFriction = 0;
                RR_LateralFriction = 0;
                RR_LateralSlipSpeed = 0;//
                RR_LongitudinalSlipSpeed = 0;//
            }
            else
            {
                RR_LateralFriction = RR_LateralLoad / RR_VerticalLoad;
                RR_LongitudinalFriction = RR_LongitudinalLoad / RR_VerticalLoad;
                RR_LateralSlipSpeed = Helper.ReadMemory<float>(RR_LateralSlipSpeed_TargetAddr);
                RR_LongitudinalSlipSpeed = Helper.ReadMemory<float>(RR_LongitudinalSlipSpeed_TargetAddr);
            }
            RR_TotalFriction = (float)Math.Sqrt(Math.Pow(RR_LateralFriction, 2) + Math.Pow(RR_LongitudinalFriction, 2));//
            if (RR_LateralFriction > 0)
            {
                if (RR_LongitudinalFriction > 0)
                {
                    RR_TotalFrictionAngle = (float)(90 - (Math.Atan(RR_LongitudinalFriction / RR_LateralFriction) * fRadToDeg));
                }
                else if (RR_LongitudinalFriction < 0)
                {
                    RR_TotalFrictionAngle = (float)(90 - (Math.Atan(RR_LongitudinalFriction / RR_LateralFriction) * fRadToDeg));
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
                    RR_TotalFrictionAngle = (float)(270 + (Math.Atan(RR_LongitudinalFriction / Math.Abs(RR_LateralFriction)) * fRadToDeg));
                }
                else if (RR_LongitudinalFriction < 0)
                {
                    RR_TotalFrictionAngle = (float)(270 - (Math.Atan(RR_LongitudinalFriction / RR_LateralFriction) * fRadToDeg));
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
            RR_MomentOfInertia = Helper.ReadMemory<float>(RR_MomentOfInertia_TargetAddr);
            RR_CamberAngleRad = Helper.ReadMemory<float>(RR_CamberAngleRad_TargetAddr);
            RR_SteerAngleRad = Helper.ReadMemory<float>(RR_TireSteerAngleRad_TargetAddr);
            RR_CamberAngleDeg = RR_CamberAngleRad * fRadToDeg;
            RR_SteerAngleDeg = RR_SteerAngleRad * fRadToDeg;
            RR_TireMass = Helper.ReadMemory<float>(RR_TireMass_TargetAddr);
            RR_TireRadius = Helper.ReadMemory<float>(RR_TireRadius_TargetAddr);
            RR_TireWidth = Helper.ReadMemory<float>(RR_TireWidth_TargetAddr);
            RR_TireSpringRate = Helper.ReadMemory<float>(RR_TireSpringRate_TargetAddr);
            RR_TireDamperRate = Helper.ReadMemory<float>(RR_TireDamperRate_TargetAddr);
            RR_TireMaxDeflection = Helper.ReadMemory<float>(RR_TireMaxDeflection_TargetAddr);
            RR_ThermalAirTransfer = Helper.ReadMemory<float>(RR_ThermalAirTransfer_TargetAddr);
            RR_ThermalInnerTransfer = Helper.ReadMemory<float>(RR_ThermalInnerTransfer_TargetAddr);

            RR_SuspensionLength = Helper.ReadMemory<float>(RR_SuspensionLenght_TargetAddr);
            RR_SuspensionVelocity = Helper.ReadMemory<float>(RR_SuspensionVelocity_TargetAddr);
            /*

             */
            #endregion
            #endregion

            CheckWhatToLogInFile(LogSettings.Delimiter);
            LogToFile();
        }
        private static void CheckWhatToLogInFile(char delimiter)
        {
                LogSettings.Header0 = LogSettings.sTireTravelSpeed + delimiter;
                LogSettings.flParameter0 = FL_TravelSpeed.ToString() + delimiter;
                LogSettings.frParameter0 = FR_TravelSpeed.ToString() + delimiter;
                LogSettings.rlParameter0 = RL_TravelSpeed.ToString() + delimiter;
                LogSettings.rrParameter0 = RR_TravelSpeed.ToString() + delimiter;

                LogSettings.Header1 = LogSettings.sAngularVelocity + delimiter;
                LogSettings.flParameter1 = FL_AngularVelocity.ToString() + delimiter;
                LogSettings.frParameter1 = FR_AngularVelocity.ToString() + delimiter;
                LogSettings.rlParameter1 = RL_AngularVelocity.ToString() + delimiter;
                LogSettings.rrParameter1 = RR_AngularVelocity.ToString() + delimiter;

                LogSettings.Header2 = LogSettings.sVerticalLoad + delimiter;
                LogSettings.flParameter2 = FL_VerticalLoad.ToString() + delimiter;
                LogSettings.frParameter2 = FR_VerticalLoad.ToString() + delimiter;
                LogSettings.rlParameter2 = RL_VerticalLoad.ToString() + delimiter;
                LogSettings.rrParameter2 = RR_VerticalLoad.ToString() + delimiter;

                LogSettings.Header3 = LogSettings.sVerticalDeflection + delimiter;
                LogSettings.flParameter3 = FL_VerticalDeflection.ToString() + delimiter;
                LogSettings.frParameter3 = FR_VerticalDeflection.ToString() + delimiter;
                LogSettings.rlParameter3 = RL_VerticalDeflection.ToString() + delimiter;
                LogSettings.rrParameter3 = RR_VerticalDeflection.ToString() + delimiter;
            
                LogSettings.Header4 = LogSettings.sLoadedRadius + delimiter;
                LogSettings.flParameter4 = FL_LoadedRadius.ToString() + delimiter;
                LogSettings.frParameter4 = FR_LoadedRadius.ToString() + delimiter;
                LogSettings.rlParameter4 = RL_LoadedRadius.ToString() + delimiter;
                LogSettings.rrParameter4 = RR_LoadedRadius.ToString() + delimiter;
            
                LogSettings.Header5 = LogSettings.sEffectiveRadius + delimiter;
                LogSettings.flParameter5 = FL_EffectiveRadius.ToString() + delimiter;
                LogSettings.frParameter5 = FR_EffectiveRadius.ToString() + delimiter;
                LogSettings.rlParameter5 = RL_EffectiveRadius.ToString() + delimiter;
                LogSettings.rrParameter5 = RR_EffectiveRadius.ToString() + delimiter;

                LogSettings.Header6 = LogSettings.sContactLength + delimiter;
                LogSettings.flParameter6 = FL_ContactLength.ToString() + delimiter;
                LogSettings.frParameter6 = FR_ContactLength.ToString() + delimiter;
                LogSettings.rlParameter6 = RL_ContactLength.ToString() + delimiter;
                LogSettings.rrParameter6 = RR_ContactLength.ToString() + delimiter;

                LogSettings.Header7 = LogSettings.sBrakeTorque + delimiter;
                LogSettings.flParameter7 = FL_CurrentContactBrakeTorque.ToString() + delimiter;
                LogSettings.frParameter7 = FR_CurrentContactBrakeTorque.ToString() + delimiter;
                LogSettings.rlParameter7 = RL_CurrentContactBrakeTorque.ToString() + delimiter;
                LogSettings.rrParameter7 = RR_CurrentContactBrakeTorque.ToString() + delimiter;

                LogSettings.Header7_1 = LogSettings.sMaxBrakeTorque + delimiter;
                LogSettings.flParameter7_1 = FL_CurrentContactBrakeTorqueMax.ToString() + delimiter;
                LogSettings.frParameter7_1 = FR_CurrentContactBrakeTorqueMax.ToString() + delimiter;
                LogSettings.rlParameter7_1 = RL_CurrentContactBrakeTorqueMax.ToString() + delimiter;
                LogSettings.rrParameter7_1 = RR_CurrentContactBrakeTorqueMax.ToString() + delimiter;

                LogSettings.Header8 = LogSettings.sSteerAngle + delimiter;
                LogSettings.flParameter8 = FL_SteerAngleDeg.ToString() + delimiter;
                LogSettings.frParameter8 = FR_SteerAngleDeg.ToString() + delimiter;
                LogSettings.rlParameter8 = RL_SteerAngleDeg.ToString() + delimiter;
                LogSettings.rrParameter8 = RR_SteerAngleDeg.ToString() + delimiter;

                LogSettings.Header9 = LogSettings.sCamberAngle + delimiter;
                LogSettings.flParameter9 = FL_CamberAngleDeg.ToString() + delimiter;
                LogSettings.frParameter9 = FR_CamberAngleDeg.ToString() + delimiter;
                LogSettings.rlParameter9 = RL_CamberAngleDeg.ToString() + delimiter;
                LogSettings.rrParameter9 = RR_CamberAngleDeg.ToString() + delimiter;

                LogSettings.Header10 = LogSettings.sLateralLoad + delimiter;
                LogSettings.flParameter10 = FL_LateralLoad.ToString() + delimiter;
                LogSettings.frParameter10 = FR_LateralLoad.ToString() + delimiter;
                LogSettings.rlParameter10 = RL_LateralLoad.ToString() + delimiter;
                LogSettings.rrParameter10 = RR_LateralLoad.ToString() + delimiter;

                LogSettings.Header11 = LogSettings.sSlipAngle + delimiter;
                LogSettings.flParameter11 = FL_SlipAngleDeg.ToString() + delimiter;
                LogSettings.frParameter11 = FR_SlipAngleDeg.ToString() + delimiter;
                LogSettings.rlParameter11 = RL_SlipAngleDeg.ToString() + delimiter;
                LogSettings.rrParameter11 = RR_SlipAngleDeg.ToString() + delimiter;

                LogSettings.Header12 = LogSettings.sLateralFriction + delimiter;
                LogSettings.flParameter12 = FL_LateralFriction.ToString() + delimiter;
                LogSettings.frParameter12 = FR_LateralFriction.ToString() + delimiter;
                LogSettings.rlParameter12 = RL_LateralFriction.ToString() + delimiter;
                LogSettings.rrParameter12 = RR_LateralFriction.ToString() + delimiter;

                LogSettings.Header13 = LogSettings.sLateralSlipSpeed + delimiter;
                LogSettings.flParameter13 = FL_LateralSlipSpeed.ToString() + delimiter;
                LogSettings.frParameter13 = FR_LateralSlipSpeed.ToString() + delimiter;
                LogSettings.rlParameter13 = RL_LateralSlipSpeed.ToString() + delimiter;
                LogSettings.rrParameter13 = RR_LateralSlipSpeed.ToString() + delimiter;

                LogSettings.Header14 = LogSettings.sLongitudinalLoad + delimiter;
                LogSettings.flParameter14 = FL_LongitudinalLoad.ToString() + delimiter;
                LogSettings.frParameter14 = FR_LongitudinalLoad.ToString() + delimiter;
                LogSettings.rlParameter14 = RL_LongitudinalLoad.ToString() + delimiter;
                LogSettings.rrParameter14 = RR_LongitudinalLoad.ToString() + delimiter;

                LogSettings.Header15 = LogSettings.sSlipRatio + delimiter;
                LogSettings.flParameter15 = FL_SlipRatio.ToString() + delimiter;
                LogSettings.frParameter15 = FR_SlipRatio.ToString() + delimiter;
                LogSettings.rlParameter15 = RL_SlipRatio.ToString() + delimiter;
                LogSettings.rrParameter15 = RR_SlipRatio.ToString() + delimiter;

                LogSettings.Header16 = LogSettings.sLongitudinalFriction + delimiter;
                LogSettings.flParameter16 = FL_LongitudinalFriction.ToString() + delimiter;
                LogSettings.frParameter16 = FR_LongitudinalFriction.ToString() + delimiter;
                LogSettings.rlParameter16 = RL_LongitudinalFriction.ToString() + delimiter;
                LogSettings.rrParameter16 = RR_LongitudinalFriction.ToString() + delimiter;

                LogSettings.Header17 = LogSettings.sLongitudinalSlipSpeed + delimiter;
                LogSettings.flParameter17 = FL_LongitudinalSlipSpeed.ToString() + delimiter;
                LogSettings.frParameter17 = FR_LongitudinalSlipSpeed.ToString() + delimiter;
                LogSettings.rlParameter17 = RL_LongitudinalSlipSpeed.ToString() + delimiter;
                LogSettings.rrParameter17 = RR_LongitudinalSlipSpeed.ToString() + delimiter;

                LogSettings.Header18 = LogSettings.sTreadTemperature + delimiter;
                LogSettings.flParameter18 = FL_TreadTemperature.ToString() + delimiter;
                LogSettings.frParameter18 = FR_TreadTemperature.ToString() + delimiter;
                LogSettings.rlParameter18 = RL_TreadTemperature.ToString() + delimiter;
                LogSettings.rrParameter18 = RR_TreadTemperature.ToString() + delimiter;

                LogSettings.Header19 = LogSettings.sInnerTemperature + delimiter;
                LogSettings.flParameter19 = FL_InnerTemperature.ToString() + delimiter;
                LogSettings.frParameter19 = FR_InnerTemperature.ToString() + delimiter;
                LogSettings.rlParameter19 = RL_InnerTemperature.ToString() + delimiter;
                LogSettings.rrParameter19 = RR_InnerTemperature.ToString() + delimiter;

                LogSettings.Header20 = LogSettings.sRaceTime + delimiter;
                LogSettings.flParameter20 = RaceTime.ToString().ToString() + delimiter;
                LogSettings.frParameter20 = RaceTime.ToString().ToString() + delimiter;
                LogSettings.rlParameter20 = RaceTime.ToString().ToString() + delimiter;
                LogSettings.rrParameter20 = RaceTime.ToString().ToString() + delimiter;

                LogSettings.Header21 = LogSettings.sTotalFriction + delimiter;
                LogSettings.flParameter21 = FL_TotalFriction.ToString() + delimiter;
                LogSettings.frParameter21 = FR_TotalFriction.ToString() + delimiter;
                LogSettings.rlParameter21 = RL_TotalFriction.ToString() + delimiter;
                LogSettings.rrParameter21 = RR_TotalFriction.ToString() + delimiter;

                LogSettings.Header22 = LogSettings.sTotalFrictionAngle + delimiter;
                LogSettings.flParameter22 = FL_TotalFrictionAngle.ToString() + delimiter;
                LogSettings.frParameter22 = FR_TotalFrictionAngle.ToString() + delimiter;
                LogSettings.rlParameter22 = RL_TotalFrictionAngle.ToString() + delimiter;
                LogSettings.rrParameter22 = RR_TotalFrictionAngle.ToString() + delimiter;

                LogSettings.Header23 = LogSettings.sSuspensionLength + delimiter;
                LogSettings.flParameter23 = FL_SuspensionLength.ToString() + delimiter;
                LogSettings.frParameter23 = FR_SuspensionLength.ToString() + delimiter;
                LogSettings.rlParameter23 = RL_SuspensionLength.ToString() + delimiter;
                LogSettings.rrParameter23 = RR_SuspensionLength.ToString() + delimiter;

                LogSettings.Header24 = LogSettings.sSuspensionVelocity + delimiter;
                LogSettings.flParameter24 = FL_SuspensionVelocity.ToString() + delimiter;
                LogSettings.frParameter24 = FR_SuspensionVelocity.ToString() + delimiter;
                LogSettings.rlParameter24 = RL_SuspensionVelocity.ToString() + delimiter;
                LogSettings.rrParameter24 = RR_SuspensionVelocity.ToString() + delimiter;

                LogSettings.Header25 = LogSettings.sXGRotated + delimiter;
                LogSettings.flParameter25 = XGRotated.ToString() + delimiter;
                LogSettings.frParameter25 = XGRotated.ToString() + delimiter;
                LogSettings.rlParameter25 = XGRotated.ToString() + delimiter;
                LogSettings.rrParameter25 = XGRotated.ToString() + delimiter;

                LogSettings.Header26 = LogSettings.sZGRotated + delimiter;
                LogSettings.flParameter26 = ZGRotated.ToString() + delimiter;
                LogSettings.frParameter26 = ZGRotated.ToString() + delimiter;
                LogSettings.rlParameter26 = ZGRotated.ToString() + delimiter;
                LogSettings.rrParameter26 = ZGRotated.ToString() + delimiter;

                LogSettings.Header27 = LogSettings.sYGRotated + delimiter;
                LogSettings.flParameter27 = YGRotated.ToString() + delimiter;
                LogSettings.frParameter27 = YGRotated.ToString() + delimiter;
                LogSettings.rlParameter27 = YGRotated.ToString() + delimiter;
                LogSettings.rrParameter27 = YGRotated.ToString() + delimiter;

                LogSettings.Header28 = LogSettings.sXYZG + delimiter;
                LogSettings.flParameter28 = XYZG.ToString() + delimiter;
                LogSettings.frParameter28 = XYZG.ToString() + delimiter;
                LogSettings.rlParameter28 = XYZG.ToString() + delimiter;
                LogSettings.rrParameter28 = XYZG.ToString() + delimiter;
        }
        private static void LogToFile()
        {

            if (logging == true)
            {
                // SA, SR, Speed and Vertical Load filters for logging
                if (LogSettings.FiltersOn == true)
                {
                    if ((FL_SlipRatio <= (0 + LogSettings.Z1) && FL_SlipRatio >= (0 - LogSettings.Z1))
                        && (FL_SlipAngleDeg <= (0 + LogSettings.Z2) && FL_SlipAngleDeg >= (0 - LogSettings.Z2))
                        && (FL_TravelSpeed >= (0 + LogSettings.Z3) || FL_TravelSpeed <= (0 - LogSettings.Z3))
                        && (FL_VerticalLoad <= (LogSettings.W4 + LogSettings.Z4) && FL_VerticalLoad >= (LogSettings.W4 - LogSettings.Z4)))
                    {
                        LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameFLTire, LogSettings.SaveFileName, LogSettings.Extension);
                    }
                    if ((FR_SlipRatio <= (0 + LogSettings.Z1) && FR_SlipRatio >= (0 - LogSettings.Z1))
                        && (FR_SlipAngleDeg <= (0 + LogSettings.Z2) && FR_SlipAngleDeg >= (0 - LogSettings.Z2))
                        && (FR_TravelSpeed >= (0 + LogSettings.Z3) || FR_TravelSpeed <= (0 - LogSettings.Z3))
                        && (FR_VerticalLoad <= (LogSettings.W4 + LogSettings.Z4) && FR_VerticalLoad >= (LogSettings.W4 - LogSettings.Z4)))
                    {
                        LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameFRTire, LogSettings.SaveFileName, LogSettings.Extension);
                    }
                    if ((RL_SlipRatio <= (0 + LogSettings.Z1) && RL_SlipRatio >= (0 - LogSettings.Z1))
                        && (RL_SlipAngleDeg <= (0 + LogSettings.Z2) && RL_SlipAngleDeg >= (0 - LogSettings.Z2))
                        && (RL_TravelSpeed >= (0 + LogSettings.Z3) || RL_TravelSpeed <= (0 - LogSettings.Z3))
                        && (RL_VerticalLoad <= (LogSettings.W4 + LogSettings.Z4) && RL_VerticalLoad >= (LogSettings.W4 - LogSettings.Z4)))
                    {
                        LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameRLTire, LogSettings.SaveFileName, LogSettings.Extension);
                    }
                    if ((RR_SlipRatio <= (0 + LogSettings.Z1) && RR_SlipRatio >= (0 - LogSettings.Z1))
                        && (RR_SlipAngleDeg <= (0 + LogSettings.Z2) && RR_SlipAngleDeg >= (0 - LogSettings.Z2))
                        && (RR_TravelSpeed >= (0 + LogSettings.Z3) || RR_TravelSpeed <= (0 - LogSettings.Z3))
                        && (RR_VerticalLoad <= (LogSettings.W4 + LogSettings.Z4) && RR_VerticalLoad >= (LogSettings.W4 - LogSettings.Z4)))
                    {
                        LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameRRTire, LogSettings.SaveFileName, LogSettings.Extension);
                    }
                }
                else
                {
                    LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameFLTire, LogSettings.SaveFileName, LogSettings.Extension);
                    LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameFRTire, LogSettings.SaveFileName, LogSettings.Extension);
                    LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameRLTire, LogSettings.SaveFileName, LogSettings.Extension);
                    LogFileWriter(LogSettings.LogFileSaveLocationFolder, LogSettings.FileNameRRTire, LogSettings.SaveFileName, LogSettings.Extension);
                }
            }
        }
        private static void LogFileWriter(string saveLocationFolder, string chooseTire, string saveFileName, string extension)
        {
            if (!File.Exists(saveLocationFolder + chooseTire + saveFileName + extension))
            {
                WriteHeadersLine(saveLocationFolder, chooseTire, saveFileName, extension);
            }
            else
            {
                WriteParametersLineEachTire(saveLocationFolder, chooseTire, saveFileName, extension);
            }
        }
        private static void WriteHeadersLine(string saveLocationFolder, string chooseTire, string saveFileName, string extension)
        {
            using (StreamWriter sw = File.CreateText(saveLocationFolder + chooseTire + saveFileName + extension))
            {
                sw.WriteLine(HeadersLine());
            }
        }
        private static string HeadersLine()
        {
            if (LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.Header20 +
                LogSettings.Header0 +
                LogSettings.Header1 +
                LogSettings.Header2 +
                LogSettings.Header3 +
                LogSettings.Header4 +
                LogSettings.Header5 +
                LogSettings.Header6 +
                LogSettings.Header7 +
                LogSettings.Header7_1 +
                LogSettings.Header8 +
                LogSettings.Header9 +
                LogSettings.Header10 +
                LogSettings.Header11 +
                LogSettings.Header12 +
                LogSettings.Header13 +
                LogSettings.Header14 +
                LogSettings.Header15 +
                LogSettings.Header16 +
                LogSettings.Header17 +
                LogSettings.Header18 +
                LogSettings.Header19 +
                LogSettings.Header21 +
                LogSettings.Header22 +
                LogSettings.Header23 +
                LogSettings.Header24 +
                LogSettings.Header25 +
                LogSettings.Header26 +
                LogSettings.Header27 +
                LogSettings.Header28;
            }
            else
            {
                return "";
            }
        }
        private static void WriteParametersLineEachTire(string saveLocationFolder, string chooseTire, string saveFileName, string extension)
        {
            using (StreamWriter sw = File.AppendText(saveLocationFolder + chooseTire + saveFileName + extension))
            {
                sw.WriteLine(ParametersLine(chooseTire));
            }
        }
        private static string ParametersLine(string chooseTire)
        {

            if (chooseTire == "FrontLeft" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.flParameter20 +
                        LogSettings.flParameter0 +
                        LogSettings.flParameter1 +
                        LogSettings.flParameter2 +
                        LogSettings.flParameter3 +
                        LogSettings.flParameter4 +
                        LogSettings.flParameter5 +
                        LogSettings.flParameter6 +
                        LogSettings.flParameter7 +
                        LogSettings.flParameter7_1 +
                        LogSettings.flParameter8 +
                        LogSettings.flParameter9 +
                        LogSettings.flParameter10 +
                        LogSettings.flParameter11 +
                        LogSettings.flParameter12 +
                        LogSettings.flParameter13 +
                        LogSettings.flParameter14 +
                        LogSettings.flParameter15 +
                        LogSettings.flParameter16 +
                        LogSettings.flParameter17 +
                        LogSettings.flParameter18 +
                        LogSettings.flParameter19 +
                        LogSettings.flParameter21 +
                        LogSettings.flParameter22 +
                        LogSettings.flParameter23 +
                        LogSettings.flParameter24 +
                        LogSettings.flParameter25 +
                        LogSettings.flParameter26 +
                        LogSettings.flParameter27 +
                        LogSettings.flParameter28;
            }
            else if(chooseTire == "FrontRight" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.frParameter20 +
                       LogSettings.frParameter0 +
                       LogSettings.frParameter1 +
                       LogSettings.frParameter2 +
                       LogSettings.frParameter3 +
                       LogSettings.frParameter4 +
                       LogSettings.frParameter5 +
                       LogSettings.frParameter6 +
                       LogSettings.frParameter7 +
                       LogSettings.frParameter7_1 +
                       LogSettings.frParameter8 +
                       LogSettings.frParameter9 +
                       LogSettings.frParameter10 +
                       LogSettings.frParameter11 +
                       LogSettings.frParameter12 +
                       LogSettings.frParameter13 +
                       LogSettings.frParameter14 +
                       LogSettings.frParameter15 +
                       LogSettings.frParameter16 +
                       LogSettings.frParameter17 +
                       LogSettings.frParameter18 +
                       LogSettings.frParameter19 +
                       LogSettings.frParameter21 +
                       LogSettings.frParameter22 +
                       LogSettings.frParameter23 +
                       LogSettings.frParameter24 +
                       LogSettings.frParameter25 +
                       LogSettings.frParameter26 +
                       LogSettings.frParameter27 +
                       LogSettings.frParameter28;
            }
            else if (chooseTire == "RearLeft" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.rlParameter20 +
                        LogSettings.rlParameter0 +
                        LogSettings.rlParameter1 +
                        LogSettings.rlParameter2 +
                        LogSettings.rlParameter3 +
                        LogSettings.rlParameter4 +
                        LogSettings.rlParameter5 +
                        LogSettings.rlParameter6 +
                        LogSettings.rlParameter7 +
                        LogSettings.rlParameter7_1 +
                        LogSettings.rlParameter8 +
                        LogSettings.rlParameter9 +
                        LogSettings.rlParameter10 +
                        LogSettings.rlParameter11 +
                        LogSettings.rlParameter12 +
                        LogSettings.rlParameter13 +
                        LogSettings.rlParameter14 +
                        LogSettings.rlParameter15 +
                        LogSettings.rlParameter16 +
                        LogSettings.rlParameter17 +
                        LogSettings.rlParameter18 +
                        LogSettings.rlParameter19 +
                        LogSettings.rlParameter21 +
                        LogSettings.rlParameter22 +
                        LogSettings.rlParameter23 +
                        LogSettings.rlParameter24 +
                        LogSettings.rlParameter25 +
                        LogSettings.rlParameter26 +
                        LogSettings.rlParameter27 +
                        LogSettings.rlParameter28;
            }
            else if (chooseTire == "RearRight" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.rrParameter20 +
                    LogSettings.rrParameter0 +
                    LogSettings.rrParameter1 +
                    LogSettings.rrParameter2 +
                    LogSettings.rrParameter3 +
                    LogSettings.rrParameter4 +
                    LogSettings.rrParameter5 +
                    LogSettings.rrParameter6 +
                    LogSettings.rrParameter7 +
                    LogSettings.rrParameter7_1 +
                    LogSettings.rrParameter8 +
                    LogSettings.rrParameter9 +
                    LogSettings.rrParameter10 +
                    LogSettings.rrParameter11 +
                    LogSettings.rrParameter12 +
                    LogSettings.rrParameter13 +
                    LogSettings.rrParameter14 +
                    LogSettings.rrParameter15 +
                    LogSettings.rrParameter16 +
                    LogSettings.rrParameter17 +
                    LogSettings.rrParameter18 +
                    LogSettings.rrParameter19 +
                    LogSettings.rrParameter21 +
                    LogSettings.rrParameter22 +
                    LogSettings.rrParameter23 +
                    LogSettings.rrParameter24 +
                    LogSettings.rrParameter25 +
                    LogSettings.rrParameter26 +
                    LogSettings.rrParameter27 +
                    LogSettings.rrParameter28;
            }
            else
            {
                return "";
            }
        }
        /*private static void WriteAllTiresParametersLine(string saveLocationFolder, string chooseTireFrontLeft, string chooseTireFrontRight, string chooseTireRearLeft, string chooseTireRearRight, string saveFileName)
        {
            using (StreamWriter sw = File.AppendText(saveLocationFolder + saveFileName))
            {
                sw.WriteLine(ParametersLine(chooseTireFrontLeft));
                sw.WriteLine(ParametersLine(chooseTireFrontRight));
                sw.WriteLine(ParametersLine(chooseTireRearLeft));
                sw.WriteLine(ParametersLine(chooseTireRearRight));
            }
        }*/
        /*private static void WriteFrontTiresParametersLine(string saveLocationFolder, string chooseTireFrontLeft, string chooseTireFrontRight, string saveFileName)
        {
            using (StreamWriter sw = File.AppendText(saveLocationFolder + saveFileName))
            {
                sw.WriteLine(ParametersLine(chooseTireFrontLeft));
                sw.WriteLine(ParametersLine(chooseTireFrontRight));
            }
        }*/
        /*private static void WriteRearTiresParametersLine(string saveLocationFolder, string chooseTireRearLeft, string chooseTireRearRight, string saveFileName)
        {
            using (StreamWriter sw = File.AppendText(saveLocationFolder + saveFileName))
            {
                sw.WriteLine(ParametersLine(chooseTireRearLeft));
                sw.WriteLine(ParametersLine(chooseTireRearRight));
            }
        }*/
    }
}
