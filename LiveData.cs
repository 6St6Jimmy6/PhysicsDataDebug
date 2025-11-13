using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Physics_Data_Debug
{
    class LiveData
    {
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

        public static bool logging { get; set; } = false;
        public static bool LogSettingsOpen { get; set; } = false;
        public static bool TireSettingsOpen { get; set; } = false;
        public static bool TemperaturesChartOpen { get; set; } = false;
        public static bool SuspensionSettingsOpen { get; set; } = false;
        public static bool GForceOpen { get; set; } = false;
        public static bool _4WheelsOpen { get; set; } = false;
        public static float fRadToDeg { get; } = Convert.ToSingle(180 / Math.PI);
        public static double dRadToDeg { get; } = 180 / Math.PI;
        public static float fKilometersPerHourToMetersPerSec { get; } = 1 / 3.6f;
        public static double dKilometersPerHourToMetersPerSec { get; } = 1 / 3.6d;
        public static int tickInterval = 50;

        #region Data
        #region Other Data
        //Time Data
        public static int None = 1;
        public static int RaceTime;

        public static float speed = 0.00f;
        public static float speed2 = 0.00f;
        public static float speed3 = 0.00f;
        public static float acceleration = 0.00f;
        public static float gForce = 0.00f;
        public static float g = 9.80665f;

        public static float xDrag = 0.00f;
        public static float yDrag = 0.00f;
        public static float zDrag = 0.00f;

        public static float frontLift = 0.00f;
        public static float rearLift = 0.00f;

        public static float engineRPM = 0.00f;
        public static float engineRPMAxle = 0.00f;
        public static float engineTorque = 0.00f;

        public static float enginePower = 0.00f;
        public static byte differentialLocked = 0;
        public static float differentialVelocityRad = 0.00f;
        public static float differentialTorque = 0.00f;

        public static float pitchBody = 0.00f;
        public static float yawBody = 0.00f;
        public static float rollBody = 0.00f;

        public static float M11 { get; set; }
        public static float M12 { get; set; }
        public static float M13 { get; set; }
        public static float M14 { get; set; }
        public static float M21 { get; set; }
        public static float M22 { get; set; }
        public static float M23 { get; set; }
        public static float M24 { get; set; }
        public static float M31 { get; set; }
        public static float M32 { get; set; }
        public static float M33 { get; set; }
        public static float M34 { get; set; }
        public static float M41 { get; set; }
        public static float M42 { get; set; }
        public static float M43 { get; set; }
        public static float M44 { get; set; }


        public static float pitchFL = 0.00f;// caster
        public static float yawFL = 0.00f;// toe
        public static float rollFL = 0.00f;// camber
        public static float FL_TirePivotX { get; set; }
        public static float FL_TirePivotY { get; set; }
        public static float FL_TirePivotZ { get; set; }

        public static float FL_TireM11 { get; set; }
        public static float FL_TireM12 { get; set; }
        public static float FL_TireM13 { get; set; }
        public static float FL_TireM14 { get; set; }
        public static float FL_TireM21 { get; set; }
        public static float FL_TireM22 { get; set; }
        public static float FL_TireM23 { get; set; }
        public static float FL_TireM24 { get; set; }
        public static float FL_TireM31 { get; set; }
        public static float FL_TireM32 { get; set; }
        public static float FL_TireM33 { get; set; }
        public static float FL_TireM34 { get; set; }
        public static float FL_TireM41 { get; set; }
        public static float FL_TireM42 { get; set; }
        public static float FL_TireM43 { get; set; }
        public static float FL_TireM44 { get; set; }

        public static float pitchFR = 0.00f;
        public static float yawFR = 0.00f;
        public static float rollFR = 0.00f;
        public static float FR_TirePivotX { get; set; }
        public static float FR_TirePivotY { get; set; }
        public static float FR_TirePivotZ { get; set; }
        public static float FR_TireM11 { get; set; }
        public static float FR_TireM12 { get; set; }
        public static float FR_TireM13 { get; set; }
        public static float FR_TireM14 { get; set; }
        public static float FR_TireM21 { get; set; }
        public static float FR_TireM22 { get; set; }
        public static float FR_TireM23 { get; set; }
        public static float FR_TireM24 { get; set; }
        public static float FR_TireM31 { get; set; }
        public static float FR_TireM32 { get; set; }
        public static float FR_TireM33 { get; set; }
        public static float FR_TireM34 { get; set; }
        public static float FR_TireM41 { get; set; }
        public static float FR_TireM42 { get; set; }
        public static float FR_TireM43 { get; set; }
        public static float FR_TireM44 { get; set; }

        public static float pitchRL = 0.00f;
        public static float yawRL = 0.00f;
        public static float rollRL = 0.00f;
        public static float RL_TirePivotX { get; set; }
        public static float RL_TirePivotY { get; set; }
        public static float RL_TirePivotZ { get; set; }
        public static float RL_TireM11 { get; set; }
        public static float RL_TireM12 { get; set; }
        public static float RL_TireM13 { get; set; }
        public static float RL_TireM14 { get; set; }
        public static float RL_TireM21 { get; set; }
        public static float RL_TireM22 { get; set; }
        public static float RL_TireM23 { get; set; }
        public static float RL_TireM24 { get; set; }
        public static float RL_TireM31 { get; set; }
        public static float RL_TireM32 { get; set; }
        public static float RL_TireM33 { get; set; }
        public static float RL_TireM34 { get; set; }
        public static float RL_TireM41 { get; set; }
        public static float RL_TireM42 { get; set; }
        public static float RL_TireM43 { get; set; }
        public static float RL_TireM44 { get; set; }

        public static float pitchRR = 0.00f;
        public static float yawRR = 0.00f;
        public static float rollRR = 0.00f;
        public static float RR_TirePivotX { get; set; }
        public static float RR_TirePivotY { get; set; }
        public static float RR_TirePivotZ { get; set; }
        public static float RR_TireM11 { get; set; }
        public static float RR_TireM12 { get; set; }
        public static float RR_TireM13 { get; set; }
        public static float RR_TireM14 { get; set; }
        public static float RR_TireM21 { get; set; }
        public static float RR_TireM22 { get; set; }
        public static float RR_TireM23 { get; set; }
        public static float RR_TireM24 { get; set; }
        public static float RR_TireM31 { get; set; }
        public static float RR_TireM32 { get; set; }
        public static float RR_TireM33 { get; set; }
        public static float RR_TireM34 { get; set; }
        public static float RR_TireM41 { get; set; }
        public static float RR_TireM42 { get; set; }
        public static float RR_TireM43 { get; set; }
        public static float RR_TireM44 { get; set; }

        public static float TXAccel { get; set; }
        public static float TYAccel { get; set; }
        public static float TZAccel { get; set; }
        public static float R11Accel { get; set; }
        public static float R12Accel { get; set; }
        public static float R13Accel { get; set; }
        public static float R21Accel { get; set; }
        public static float R22Accel { get; set; }
        public static float R23Accel { get; set; }
        public static float R31Accel { get; set; }
        public static float R32Accel { get; set; }
        public static float R33Accel { get; set; }
        public static float Q1Accel { get; set; }
        public static float Q2Accel { get; set; }
        public static float Q3Accel { get; set; }
        public static float Q4Accel { get; set; }
        public static float A1Accel { get; set; }
        public static float A2Accel { get; set; }
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

        //public static Matrix4x4 playerRotation;
        //public static Quaternion playerQuaternion = new Quaternion(Q1Accel, Q2Accel, Q3Accel, Q4Accel);
        public static double XZAccelerationAngleRad { get; set; }
        public static double XZAccelerationAngleDeg { get; set; }
        public static double XZGAngleRad { get; set; }
        public static double XZGAngleDeg { get; set; }
        #endregion
        #region Tire Data
        #region Font Left data
        public static float FL_MomentOfInertia { get; set; }//
        public static float FL_AngularVelocity { get; set; }
        public static float FL_CasterAngleRad { get; set; }//
        public static float FL_CasterAngleDeg { get; set; }//
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
        public static float FL_RadiansTireMoved { get; set; }//
        public static float FL_CurrentContactBrakeTorque { get; set; }
        public static float FL_CurrentContactHandBrakeTorque { get; set; }
        public static float FL_CurrentContactBrakeTorqueMax { get; set; }
        public static float FL_VerticalLoad { get; set; }

        public static float FL_TireX { get; set; }
        public static float FL_TireY { get; set; }
        public static float FL_TireZ { get; set; }

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
        public static float FR_CasterAngleRad { get; set; }//
        public static float FR_CasterAngleDeg { get; set; }//
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
        public static float FR_RadiansTireMoved { get; set; }//
        public static float FR_CurrentContactBrakeTorque { get; set; }
        public static float FR_CurrentContactHandBrakeTorque { get; set; }
        public static float FR_CurrentContactBrakeTorqueMax { get; set; }
        public static float FR_VerticalLoad { get; set; }

        public static float FR_TireX { get; set; }
        public static float FR_TireY { get; set; }
        public static float FR_TireZ { get; set; }

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
        public static float RL_CasterAngleRad { get; set; }//
        public static float RL_CasterAngleDeg { get; set; }//
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
        public static float RL_RadiansTireMoved { get; set; }//
        public static float RL_CurrentContactBrakeTorque { get; set; }
        public static float RL_CurrentContactHandBrakeTorque { get; set; }
        public static float RL_CurrentContactBrakeTorqueMax { get; set; }
        public static float RL_VerticalLoad { get; set; }

        public static float RL_TireX { get; set; }
        public static float RL_TireY { get; set; }
        public static float RL_TireZ { get; set; }

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
        public static float RR_CasterAngleRad { get; set; }//
        public static float RR_CasterAngleDeg { get; set; }//
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
        public static float RR_RadiansTireMoved { get; set; }//
        public static float RR_CurrentContactBrakeTorque { get; set; }
        public static float RR_CurrentContactHandBrakeTorque { get; set; }
        public static float RR_CurrentContactBrakeTorqueMax { get; set; }
        public static float RR_VerticalLoad { get; set; }

        public static float RR_TireX { get; set; }
        public static float RR_TireY { get; set; }
        public static float RR_TireZ { get; set; }

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
        #endregion

        #region Basest of the basest adresses
        public static ulong baseAddrTiresSuspensionDragLiftsDifferentialLocationHeading { get; set; } = 0x18324C8;//0x1831EE0;//this was changing between cars, the new adrdess is only for the player
        public static ulong baseAddrEngineSpeed { get; set; } = 0x18327C8;
        public static ulong baseAddrRacetime { get; set; } = 0x1832648;
        public static ulong baseAddrAccel { get; set; } = 0x1832B88;
        //Every update offsets the base address of the memory points. 99% of the time forwards.
        public static ulong baseAddrUpdt { get; set; } = 0x9E00;
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
        #region Time offsets
        public static int OffsetRaceTime { get; set; } = 0x14;
        #endregion

        #region Other offsets
        public static int OffsetSpeed { get; set; } = 0x70;
        public static int OffsetXDrag { get; set; } = 0xAACF20;
        public static int OffsetYDrag { get; set; } = 0xAACF24;
        public static int OffsetZDrag { get; set; } = 0xAACF28;
        public static int OffsetFrontLift { get; set; } = 0xAACF2C;
        public static int OffsetRearLift { get; set; } = 0xAACF30;
        public static int OffsetEngineRPM { get; set; } = 0x38;
        public static int OffsetEngineRPMAxle { get; set; } = 0x3C;
        public static int OffsetEngineTorque { get; set; } = 0x44;
        public static int OffsetDifferentialOpen { get; set; } = 0xD94;
        public static int OffsetDifferentialVelocityRad { get; set; } = 0xD98;
        public static int OffsetDifferentialTorque { get; set; } = 0xD9C;
        // Offset for secondary axle is + 0x60
        #endregion

        #region Location, heading and acceleration pointers
        public static int OffsetLocationData { get; set; } = 0x970;
        public static int OffsetM11 { get; set; } = 0x0;
        public static int OffsetM12 { get; set; } = 0x4;
        public static int OffsetM13 { get; set; } = 0x8;
        public static int OffsetM14 { get; set; } = 0xC;
        public static int OffsetM21 { get; set; } = 0x10;
        public static int OffsetM22 { get; set; } = 0x14;
        public static int OffsetM23 { get; set; } = 0x18;
        public static int OffsetM24 { get; set; } = 0x1C;
        public static int OffsetM31 { get; set; } = 0x20;
        public static int OffsetM32 { get; set; } = 0x24;
        public static int OffsetM33 { get; set; } = 0x28;
        public static int OffsetM34 { get; set; } = 0x2C;
        public static int OffsetM41 { get; set; } = 0x20;
        public static int OffsetM42 { get; set; } = 0x24;
        public static int OffsetM43 { get; set; } = 0x28;
        public static int OffsetM44 { get; set; } = 0x2C;
        /*
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
        public static int OffsetA1 { get; set; } = 0x40;
        public static int OffsetA2 { get; set; } = 0x44;
        */
        public static int OffsetXAcceleration { get; set; } = 0x48;
        public static int OffsetYAcceleration { get; set; } = 0x4C;
        public static int OffsetZAcceleration { get; set; } = 0x50;
        #endregion

        #region Suspension offsets
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
        #endregion

        #region Tire data offsets
        public static int OffsetTireDataStart { get; set; } = 0x28;//
        public static int OffsetTireData { get; set; } = 0xE78;
        public static int TireDataChunkSize { get; set; } = 0xC4C;
        public static int OffsetFRTire { get; set; } = 0xC50;//Next tire offset from FL
        public static int OffsetRLTire { get; set; } = 0xC50 + 0xC50;//Next tire offset from FL
        public static int OffsetRRTire { get; set; } = 0xC50 + 0xC50 + 0xC50;//Next tire offset from FL

        public static int OffsetMomentOfInertia { get; set; } = 0x28;//0
        public static int OffsetAngularVelocity { get; set; } = 0x2C;//1

        public static int OffsetTirePivotX { get; set; } = 0x380;//214
        public static int OffsetTirePivotY { get; set; } = 0x384;//218
        public static int OffsetTirePivotZ { get; set; } = 0x388;//222
        public static int OffsetTireM11 { get; set; } = 0x390;//226
        public static int OffsetTireM12 { get; set; } = 0x394;//230
        public static int OffsetTireM13 { get; set; } = 0x398;//234
        public static int OffsetTireM14 { get; set; } = 0x39C;//238
        public static int OffsetTireM21 { get; set; } = 0x3A0;//242
        public static int OffsetTireM22 { get; set; } = 0x3A4;//246
        public static int OffsetTireM23 { get; set; } = 0x3A8;//250
        public static int OffsetTireM24 { get; set; } = 0x3AC;//250
        public static int OffsetTireM31 { get; set; } = 0x3B0;
        public static int OffsetTireM32 { get; set; } = 0x3B4;
        public static int OffsetTireM33 { get; set; } = 0x3B8;
        public static int OffsetTireM34 { get; set; } = 0x3BC;
        public static int OffsetTireM41 { get; set; } = 0x3C0;
        public static int OffsetTireM42 { get; set; } = 0x3C4;
        public static int OffsetTireM43 { get; set; } = 0x3C8;
        public static int OffsetTireM44 { get; set; } = 0x3CC;

        //public static int OffsetCamberAngleRad { get; set; } = 0x394;
        //public static int OffsetTireSteerAngleRad { get; set; } = 0x398;
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
        public static int OffsetVerticalDeflection { get; set; } = 0x43C;
        public static int OffsetLoadedRadius { get; set; } = 0x44C;
        public static int OffsetEffectiveRadius { get; set; } = 0x450;
        public static int OffsetLongitudinalSlipSpeed { get; set; } = 0x454;
        public static int OffsetLateralSlipSpeed { get; set; } = 0x458;
        public static int OffsetRadiansTireMoved { get; set; } = 0x45C;//Not angular but compared to the contact surface.

        public static int OffsetCurrentContactBrakeTorque { get; set; } = 0x484;
        public static int OffsetCurrentContactHandBrakeTorque { get; set; } = 0x484;
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
        #endregion

        #region Pointers
        #region Speed, Drag and Lift pointers
        public static int[] speedOffsets { get; set; } = { OffsetSpeed };
        public static int[] xDragOffsets { get; set; } = { OffsetXDrag };
        public static int[] yDragOffsets { get; set; } = { OffsetYDrag };
        public static int[] zDragOffsets { get; set; } = { OffsetZDrag };
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
        public static int[] M11Offsets { get; set; } = { OffsetLocationData, OffsetM11 };
        public static int[] M12Offsets { get; set; } = { OffsetLocationData, OffsetM12 };
        public static int[] M13Offsets { get; set; } = { OffsetLocationData, OffsetM13 };
        public static int[] M14Offsets { get; set; } = { OffsetLocationData, OffsetM14 };
        public static int[] M21Offsets { get; set; } = { OffsetLocationData, OffsetM21 };
        public static int[] M22Offsets { get; set; } = { OffsetLocationData, OffsetM22 };
        public static int[] M23Offsets { get; set; } = { OffsetLocationData, OffsetM23 };
        public static int[] M24Offsets { get; set; } = { OffsetLocationData, OffsetM24 };
        public static int[] M31Offsets { get; set; } = { OffsetLocationData, OffsetM31 };
        public static int[] M32Offsets { get; set; } = { OffsetLocationData, OffsetM32 };
        public static int[] M33Offsets { get; set; } = { OffsetLocationData, OffsetM33 };
        public static int[] M34Offsets { get; set; } = { OffsetLocationData, OffsetM34 };
        public static int[] M41Offsets { get; set; } = { OffsetLocationData, OffsetM41 };
        public static int[] M42Offsets { get; set; } = { OffsetLocationData, OffsetM42 };
        public static int[] M43Offsets { get; set; } = { OffsetLocationData, OffsetM43 };
        public static int[] M44Offsets { get; set; } = { OffsetLocationData, OffsetM44 };
        /*
        public static int[] TXOffsets { get; set; } = { OffsetTX };
        public static int[] TYOffsets { get; set; } = { OffsetTY };
        public static int[] TZOffsets { get; set; } = { OffsetTZ };
        public static int[] R11Offsets { get; set; } = { OffsetR11 };
        public static int[] R12Offsets { get; set; } = { OffsetR12 };
        public static int[] R13Offsets { get; set; } = { OffseR13 };
        public static int[] R21Offsets { get; set; } = { OffsetR21 };
        public static int[] R22Offsets { get; set; } = { OffsetR22 };
        public static int[] R23Offsets { get; set; } = { OffsetR23 };
        public static int[] R31Offsets { get; set; } = { OffsetR31 };
        public static int[] R32Offsets { get; set; } = { OffsetR32 };
        public static int[] R33Offsets { get; set; } = { OffsetR33 };
        public static int[] Q1Offsets { get; set; } = { OffsetQ1 };
        public static int[] Q2Offsets { get; set; } = { OffsetQ2 };
        public static int[] Q3Offsets { get; set; } = { OffsetQ3 };
        public static int[] Q4Offsets { get; set; } = { OffsetQ4 };
        public static int[] A1Offsets { get; set; } = { OffsetA1 };
        public static int[] A2Offsets { get; set; } = { OffsetA2 };
        */
        public static int[] XAccelerationOffsets { get; set; } = { OffsetXAcceleration };
        public static int[] YAccelerationOffsets { get; set; } = { OffsetYAcceleration };
        public static int[] ZAccelerationOffsets { get; set; } = { OffsetZAcceleration };
        #endregion

        #region Tire & Suspension Data pointers
        #region Front Left
        public static int[] FL_TireDataStartOffsets { get; set; } = { OffsetTireData, OffsetTireDataStart };//

        /* Old way not used anymore
        public static int[] flsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature };
        public static int[] fliOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature };
        public static int[] FL_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity };

        public static int[] FL_M11Offsets { get; set; } = { OffsetTireData, OffsetTireM11 };
        public static int[] FL_M12Offsets { get; set; } = { OffsetTireData, OffsetTireM12 };
        public static int[] FL_M13Offsets { get; set; } = { OffsetTireData, OffsetTireM13 };
        public static int[] FL_M14Offsets { get; set; } = { OffsetTireData, OffsetTireM14 };
        public static int[] FL_M21Offsets { get; set; } = { OffsetTireData, OffsetTireM21 };
        public static int[] FL_M22Offsets { get; set; } = { OffsetTireData, OffsetTireM22 };
        public static int[] FL_M23Offsets { get; set; } = { OffsetTireData, OffsetTireM23 };
        public static int[] FL_M24Offsets { get; set; } = { OffsetTireData, OffsetTireM24 };
        public static int[] FL_M31Offsets { get; set; } = { OffsetTireData, OffsetTireM31 };
        public static int[] FL_M32Offsets { get; set; } = { OffsetTireData, OffsetTireM32 };
        public static int[] FL_M33Offsets { get; set; } = { OffsetTireData, OffsetTireM33 };
        public static int[] FL_M34Offsets { get; set; } = { OffsetTireData, OffsetTireM34 };
        public static int[] FL_M41Offsets { get; set; } = { OffsetTireData, OffsetTireM41 };
        public static int[] FL_M42Offsets { get; set; } = { OffsetTireData, OffsetTireM42 };
        public static int[] FL_M43Offsets { get; set; } = { OffsetTireData, OffsetTireM43 };
        public static int[] FL_M44Offsets { get; set; } = { OffsetTireData, OffsetTireM44 };

        public static int[] FL_VerticalDeflectionOffsets { get; set; } = { OffsetTireData, OffsetVerticalDeflection };
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
        public static int[] FL_SteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad };//

        public static int[] FL_MomentOfInertiaOffsets { get; set; } = { OffsetTireData, OffsetMomentOfInertia };//
        public static int[] FL_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass };//
        public static int[] FL_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius };//
        public static int[] FL_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth };//
        public static int[] FL_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate };//
        public static int[] FL_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate };//
        public static int[] FL_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection };//
        public static int[] FL_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer };
        public static int[] FL_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer };
        */

        public static int[] FL_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength };
        public static int[] FL_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity };
        #endregion
        #region Front Right
        public static int[] FR_TireDataStartOffsets { get; set; } = { OffsetTireData, OffsetTireDataStart + OffsetFRTire };//
        /* Old way not used anymore
        public static int[] frsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature + OffsetFRTire };
        public static int[] friOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature + OffsetFRTire };
        public static int[] FR_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity + OffsetFRTire };

        public static int[] FR_M11Offsets { get; set; } = { OffsetTireData, OffsetTireM11 + OffsetFRTire };
        public static int[] FR_M12Offsets { get; set; } = { OffsetTireData, OffsetTireM12 + OffsetFRTire };
        public static int[] FR_M13Offsets { get; set; } = { OffsetTireData, OffsetTireM13 + OffsetFRTire };
        public static int[] FR_M14Offsets { get; set; } = { OffsetTireData, OffsetTireM14 + OffsetFRTire };
        public static int[] FR_M21Offsets { get; set; } = { OffsetTireData, OffsetTireM21 + OffsetFRTire };
        public static int[] FR_M22Offsets { get; set; } = { OffsetTireData, OffsetTireM22 + OffsetFRTire };
        public static int[] FR_M23Offsets { get; set; } = { OffsetTireData, OffsetTireM23 + OffsetFRTire };
        public static int[] FR_M24Offsets { get; set; } = { OffsetTireData, OffsetTireM24 + OffsetFRTire };
        public static int[] FR_M31Offsets { get; set; } = { OffsetTireData, OffsetTireM31 + OffsetFRTire };
        public static int[] FR_M32Offsets { get; set; } = { OffsetTireData, OffsetTireM32 + OffsetFRTire };
        public static int[] FR_M33Offsets { get; set; } = { OffsetTireData, OffsetTireM33 + OffsetFRTire };
        public static int[] FR_M34Offsets { get; set; } = { OffsetTireData, OffsetTireM34 + OffsetFRTire };
        public static int[] FR_M41Offsets { get; set; } = { OffsetTireData, OffsetTireM41 + OffsetFRTire };
        public static int[] FR_M42Offsets { get; set; } = { OffsetTireData, OffsetTireM42 + OffsetFRTire };
        public static int[] FR_M43Offsets { get; set; } = { OffsetTireData, OffsetTireM43 + OffsetFRTire };
        public static int[] FR_M44Offsets { get; set; } = { OffsetTireData, OffsetTireM44 + OffsetFRTire };

        public static int[] FR_VerticalDeflectionOffsets { get; set; } = { OffsetTireData, OffsetVerticalDeflection + OffsetFRTire };
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
        public static int[] FR_SteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad + OffsetFRTire };//
        public static int[] FR_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass + OffsetFRTire };//
        public static int[] FR_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius + OffsetFRTire };//
        public static int[] FR_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth + OffsetFRTire };//
        public static int[] FR_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate + OffsetFRTire };//
        public static int[] FR_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate + OffsetFRTire };//
        public static int[] FR_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection + OffsetFRTire };//
        public static int[] FR_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer + OffsetFRTire };
        public static int[] FR_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer + OffsetFRTire };
        */
        public static int[] FR_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength + OffsetFRSuspension };
        public static int[] FR_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity + OffsetFRSuspension };
        #endregion
        #region Rear Left
        public static int[] RL_TireDataStartOffsets { get; set; } = { OffsetTireData, OffsetTireDataStart + OffsetRLTire };//
        /*
        public static int[] rlsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature + OffsetRLTire };
        public static int[] rliOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature + OffsetRLTire };
        public static int[] RL_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity + OffsetRLTire };

        public static int[] RL_M11Offsets { get; set; } = { OffsetTireData, OffsetTireM11 + OffsetRLTire };
        public static int[] RL_M12Offsets { get; set; } = { OffsetTireData, OffsetTireM12 + OffsetRLTire };
        public static int[] RL_M13Offsets { get; set; } = { OffsetTireData, OffsetTireM13 + OffsetRLTire };
        public static int[] RL_M14Offsets { get; set; } = { OffsetTireData, OffsetTireM14 + OffsetRLTire };
        public static int[] RL_M21Offsets { get; set; } = { OffsetTireData, OffsetTireM21 + OffsetRLTire };
        public static int[] RL_M22Offsets { get; set; } = { OffsetTireData, OffsetTireM22 + OffsetRLTire };
        public static int[] RL_M23Offsets { get; set; } = { OffsetTireData, OffsetTireM23 + OffsetRLTire };
        public static int[] RL_M24Offsets { get; set; } = { OffsetTireData, OffsetTireM24 + OffsetRLTire };
        public static int[] RL_M31Offsets { get; set; } = { OffsetTireData, OffsetTireM31 + OffsetRLTire };
        public static int[] RL_M32Offsets { get; set; } = { OffsetTireData, OffsetTireM32 + OffsetRLTire };
        public static int[] RL_M33Offsets { get; set; } = { OffsetTireData, OffsetTireM33 + OffsetRLTire };
        public static int[] RL_M34Offsets { get; set; } = { OffsetTireData, OffsetTireM34 + OffsetRLTire };
        public static int[] RL_M41Offsets { get; set; } = { OffsetTireData, OffsetTireM41 + OffsetRLTire };
        public static int[] RL_M42Offsets { get; set; } = { OffsetTireData, OffsetTireM42 + OffsetRLTire };
        public static int[] RL_M43Offsets { get; set; } = { OffsetTireData, OffsetTireM43 + OffsetRLTire };
        public static int[] RL_M44Offsets { get; set; } = { OffsetTireData, OffsetTireM44 + OffsetRLTire };

        public static int[] RL_VerticalDeflectionOffsets { get; set; } = { OffsetTireData, OffsetVerticalDeflection + OffsetRLTire };
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
        public static int[] RL_SteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad + OffsetRLTire };//
        public static int[] RL_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass + OffsetRLTire };//
        public static int[] RL_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius + OffsetRLTire };//
        public static int[] RL_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth + OffsetRLTire };//
        public static int[] RL_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate + OffsetRLTire };//
        public static int[] RL_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate + OffsetRLTire };//
        public static int[] RL_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection + OffsetRLTire };//
        public static int[] RL_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer + OffsetRLTire };//
        public static int[] RL_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer + OffsetRLTire };//
        */
        public static int[] RL_SuspensionLengthOffsets { get; set; } = { OffsetSuspensionLength + OffsetRLSuspension };
        public static int[] RL_SuspensionVelocityOffsets { get; set; } = { OffsetSuspensionVelocity + OffsetRLSuspension };
        #endregion
        #region Rear Right
        public static int[] RR_TireDataStartOffsets { get; set; } = { OffsetTireData, OffsetTireDataStart + OffsetRRTire };//
        /*
        public static int[] rrsOffsets { get; set; } = { OffsetTireData, OffsetTreadTemperature + OffsetRRTire };
        public static int[] rriOffsets { get; set; } = { OffsetTireData, OffsetInnerTemperature + OffsetRRTire };
        public static int[] RR_AngularVelocityOffsets { get; set; } = { OffsetTireData, OffsetAngularVelocity + OffsetRRTire };

        public static int[] RR_M11Offsets { get; set; } = { OffsetTireData, OffsetTireM11 + OffsetRRTire };
        public static int[] RR_M12Offsets { get; set; } = { OffsetTireData, OffsetTireM12 + OffsetRRTire };
        public static int[] RR_M13Offsets { get; set; } = { OffsetTireData, OffsetTireM13 + OffsetRRTire };
        public static int[] RR_M14Offsets { get; set; } = { OffsetTireData, OffsetTireM14 + OffsetRRTire };
        public static int[] RR_M21Offsets { get; set; } = { OffsetTireData, OffsetTireM21 + OffsetRRTire };
        public static int[] RR_M22Offsets { get; set; } = { OffsetTireData, OffsetTireM22 + OffsetRRTire };
        public static int[] RR_M23Offsets { get; set; } = { OffsetTireData, OffsetTireM23 + OffsetRRTire };
        public static int[] RR_M24Offsets { get; set; } = { OffsetTireData, OffsetTireM24 + OffsetRRTire };
        public static int[] RR_M31Offsets { get; set; } = { OffsetTireData, OffsetTireM31 + OffsetRRTire };
        public static int[] RR_M32Offsets { get; set; } = { OffsetTireData, OffsetTireM32 + OffsetRRTire };
        public static int[] RR_M33Offsets { get; set; } = { OffsetTireData, OffsetTireM33 + OffsetRRTire };
        public static int[] RR_M34Offsets { get; set; } = { OffsetTireData, OffsetTireM34 + OffsetRRTire };
        public static int[] RR_M41Offsets { get; set; } = { OffsetTireData, OffsetTireM41 + OffsetRRTire };
        public static int[] RR_M42Offsets { get; set; } = { OffsetTireData, OffsetTireM42 + OffsetRRTire };
        public static int[] RR_M43Offsets { get; set; } = { OffsetTireData, OffsetTireM43 + OffsetRRTire };
        public static int[] RR_M44Offsets { get; set; } = { OffsetTireData, OffsetTireM44 + OffsetRRTire };

        public static int[] RR_VerticalDeflectionOffsets { get; set; } = { OffsetTireData, OffsetVerticalDeflection + OffsetRRTire };
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
        public static int[] RR_SteerAngleRadOffsets { get; set; } = { OffsetTireData, OffsetTireSteerAngleRad + OffsetRRTire };//
        public static int[] RR_TireMassOffsets { get; set; } = { OffsetTireData, OffsetTireMass + OffsetRRTire };//
        public static int[] RR_TireRadiusOffsets { get; set; } = { OffsetTireData, OffsetTireRadius + OffsetRRTire };//
        public static int[] RR_TireWidthOffsets { get; set; } = { OffsetTireData, OffsetTireWidth + OffsetRRTire };//
        public static int[] RR_TireSpringRateOffsets { get; set; } = { OffsetTireData, OffsetTireSpringRate + OffsetRRTire };//
        public static int[] RR_TireDamperRateOffsets { get; set; } = { OffsetTireData, OffsetTireDamperRate + OffsetRRTire };//
        public static int[] RR_TireMaxDeflectionOffsets { get; set; } = { OffsetTireData, OffsetTireMaxDeflection + OffsetRRTire };//
        public static int[] RR_ThermalAirTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalAirTransfer + OffsetRRTire };//
        public static int[] RR_ThermalInnerTransferOffsets { get; set; } = { OffsetTireData, OffsetThermalInnerTransfer + OffsetRRTire };//
        */
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

        public static string PathSource = @"F:\Program Files (x86)\Steam\steamapps\common\Wreckfest\Wreckfest_x64.exe";
        public static byte[] PatternToFind = { 0x00, 0x48, 0x0F, 0x44, 0xC2, 0x48 };
        //public static byte[] PatternToFind = { 0x48, 0xC2, 0x44, 0x0F, 0x48, 0x00 };
        public static IEnumerable<int> PatternAtOffset;

        //int matchIndex = toBeSearched.AsSpan().IndexOf(pattern);
        public static IEnumerable<int> PatternAt(byte[] source, byte[] pattern)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern))
                {
                    yield return i;
                }
            }
        }
        public static byte[] GetExeBytes(string pathSource)
        {
            // Specify a file to read from and to create.
            //string pathSource = @"F:\Program Files (x86)\Steam\steamapps\common\Wreckfest\Wreckfest_x64.exe";
            //string pathNew = @"c:\tests\newfile.txt";


            using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {

                // Read the source file into a byte array.
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                /*
                numBytesToRead = bytes.Length;

                // Write the byte array to the other FileStream.
                using (FileStream fsNew = new FileStream(pathNew,
                    FileMode.Create, FileAccess.Write))
                {
                    fsNew.Write(bytes, 0, numBytesToRead);
                }*/
                return bytes;
            }/*
            try
            {

            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }*/
        }

        public static List<float> FL_LiveDataList { get; set; }
        public static List<float> FR_LiveDataList { get; set; }
        public static List<float> RL_LiveDataList { get; set; }
        public static List<float> RR_LiveDataList { get; set; }
        public static void GetData()
        {
            if (process == null)
            { return; }
            Helper = new Memory.Win64.MemoryHelper64(process);
            #region Read Race Time
            RaceTime = GetData<int>(Helper, baseAddrRacetime, raceTimerOffsets);
            //Time interval between the last tick. It only naturally works when the race is going but pretty accurate then and no interference every second.
            raceTimeArray[raceTimeArray.Length - 1] = RaceTime;
            Array.Copy(raceTimeArray, 1, raceTimeArray, 0, raceTimeArray.Length - 1);
            elapsedTime = raceTimeArray[1] - raceTimeArray[0];
            #endregion
            #region Read Speed, lifts, drag, location, heading, Engine Torque and Differential
            GetDragLiftsDifferentialLocationHeadingData(Helper, baseAddrTiresSuspensionDragLiftsDifferentialLocationHeading);
            GetEngineSpeedData(Helper, baseAddrEngineSpeed);
            enginePower = engineTorque * engineRPM / 9549;
            #endregion
            #region Read Acceleration and g-force
            GetAccelData(Helper, baseAddrAccel);
            #region Some XYZ calculations that needs to be made as own methods later
            // Getting rid of too big or low values when the pointer is changing or something odd happens, so it won't crash the math for Int32 later.
            XAcceleration = BigValueReducerFloat(XAcceleration);
            YAcceleration = BigValueReducerFloat(YAcceleration);
            ZAcceleration = BigValueReducerFloat(ZAcceleration);
            AccelGForceXYZHeading();
            #endregion
            #endregion
            #region Read Tire Data
            // Front Left
            GetFLTireData(Helper, baseAddrTiresSuspensionDragLiftsDifferentialLocationHeading);
            // Front Right
            GetFRTireData(Helper, baseAddrTiresSuspensionDragLiftsDifferentialLocationHeading);
            // Rear Left
            GetRLTireData(Helper, baseAddrTiresSuspensionDragLiftsDifferentialLocationHeading);
            // Rear Right
            GetRRTireData(Helper, baseAddrTiresSuspensionDragLiftsDifferentialLocationHeading);
            #endregion
            /*#region Stiffness and Lon/Lat Forces
            RL_LonBristleStiffness = BristleStiffness(LonStiffness, RL_ContactLength);
            RL_LonStiffness = Stiffness(LonStiffness, RL_ContactLength);
            RL_LonForceStatic = ForceStatic(RL_ContactLength, RL_LonBristleStiffness, RL_LongitudinalFriction, RL_VerticalLoad, RL_SlipRatio, true);
            RL_LonForceSlide = ForceSlide(RL_ContactLength, RL_LonBristleStiffness, RL_LongitudinalFriction, RL_VerticalLoad, RL_SlipAngleRad, false);
            RL_LonForceTotal = ForceTotal(RL_LonForceStatic, RL_LonForceSlide);
            #endregion*/
            FL_LiveDataList = new List<float> {
                LiveData.FL_TravelSpeed, LiveData.FL_AngularVelocity,
                                LiveData.FL_VerticalLoad, LiveData.FL_VerticalDeflection, LiveData.FL_LoadedRadius, LiveData.FL_EffectiveRadius, LiveData.FL_ContactLength,
                                LiveData.FL_CurrentContactBrakeTorque, LiveData.FL_CurrentContactBrakeTorqueMax,
                                LiveData.FL_SteerAngleDeg, LiveData.FL_CamberAngleDeg,
                                LiveData.FL_LateralLoad, LiveData.FL_SlipAngleDeg, LiveData.FL_LateralFriction, LiveData.FL_LateralSlipSpeed,
                                LiveData.FL_LongitudinalLoad, LiveData.FL_SlipRatio, LiveData.FL_LongitudinalFriction, LiveData.FL_LongitudinalSlipSpeed,
                                LiveData.FL_TreadTemperature, LiveData.FL_InnerTemperature,
                                LiveData.FL_TotalFriction, LiveData.FL_TotalFrictionAngle,
                                LiveData.FL_SuspensionLength, LiveData.FL_SuspensionVelocity}
            ;
            FR_LiveDataList = new List<float> {
                LiveData.FR_TravelSpeed, LiveData.FR_AngularVelocity,
                                LiveData.FR_VerticalLoad, LiveData.FR_VerticalDeflection, LiveData.FR_LoadedRadius, LiveData.FR_EffectiveRadius, LiveData.FR_ContactLength,
                                LiveData.FR_CurrentContactBrakeTorque, LiveData.FR_CurrentContactBrakeTorqueMax,
                                LiveData.FR_SteerAngleDeg, LiveData.FR_CamberAngleDeg,
                                LiveData.FR_LateralLoad, LiveData.FR_SlipAngleDeg, LiveData.FR_LateralFriction, LiveData.FR_LateralSlipSpeed,
                                LiveData.FR_LongitudinalLoad, LiveData.FR_SlipRatio, LiveData.FR_LongitudinalFriction, LiveData.FR_LongitudinalSlipSpeed,
                                LiveData.FR_TreadTemperature, LiveData.FR_InnerTemperature,
                                LiveData.FR_TotalFriction, LiveData.FR_TotalFrictionAngle,
                                LiveData.FR_SuspensionLength, LiveData.FR_SuspensionVelocity}
            ;
            RL_LiveDataList = new List<float> {
                LiveData.RL_TravelSpeed, LiveData.RL_AngularVelocity,
                                LiveData.RL_VerticalLoad, LiveData.RL_VerticalDeflection, LiveData.RL_LoadedRadius, LiveData.RL_EffectiveRadius, LiveData.RL_ContactLength,
                                LiveData.RL_CurrentContactBrakeTorque, LiveData.RL_CurrentContactBrakeTorqueMax,
                                LiveData.RL_SteerAngleDeg, LiveData.RL_CamberAngleDeg,
                                LiveData.RL_LateralLoad, LiveData.RL_SlipAngleDeg, LiveData.RL_LateralFriction, LiveData.RL_LateralSlipSpeed,
                                LiveData.RL_LongitudinalLoad, LiveData.RL_SlipRatio, LiveData.RL_LongitudinalFriction, LiveData.RL_LongitudinalSlipSpeed,
                                LiveData.RL_TreadTemperature, LiveData.RL_InnerTemperature,
                                LiveData.RL_TotalFriction, LiveData.RL_TotalFrictionAngle,
                                LiveData.RL_SuspensionLength, LiveData.RL_SuspensionVelocity}
            ;
            RR_LiveDataList = new List<float> {
                LiveData.RR_TravelSpeed, LiveData.RR_AngularVelocity,
                                LiveData.RR_VerticalLoad, LiveData.RR_VerticalDeflection, LiveData.RR_LoadedRadius, LiveData.RR_EffectiveRadius, LiveData.RR_ContactLength,
                                LiveData.RR_CurrentContactBrakeTorque, LiveData.RR_CurrentContactBrakeTorqueMax,
                                LiveData.RR_SteerAngleDeg, LiveData.RR_CamberAngleDeg,
                                LiveData.RR_LateralLoad, LiveData.RR_SlipAngleDeg, LiveData.RR_LateralFriction, LiveData.RR_LateralSlipSpeed,
                                LiveData.RR_LongitudinalLoad, LiveData.RR_SlipRatio, LiveData.RR_LongitudinalFriction, LiveData.RR_LongitudinalSlipSpeed,
                                LiveData.RR_TreadTemperature, LiveData.RR_InnerTemperature,
                                LiveData.RR_TotalFriction, LiveData.RR_TotalFrictionAngle,
                                LiveData.RR_SuspensionLength, LiveData.RR_SuspensionVelocity}
            ;
            LogToFile();
        }
        /*
        public static float LonStiffness { get; set; } = 10000;
        public static float RL_LonStiffness { get; set; } = 0;
        public static float RL_LonBristleStiffness { get; set; } = 0;
        public static float RL_LonForceStatic { get; set; } = 0;
        public static float RL_LonForceSlide { get; set; } = 0;
        public static float RL_LonForceTotal { get; set; } = 0;
        public static float BristleStiffness(float stiffness, float tireContactLength)
        {
            return stiffness / (2 * (float)Math.Pow(tireContactLength/2, 2));
        }
        public static float Stiffness(float bristleStiffness, float tireContactLength)
        {
            return 2 * bristleStiffness * (float)Math.Pow(tireContactLength / 2, 2);
        }
        public static float LatStiffness { get; set; } = 5000;
        public static float RL_LatForceStatic { get; set; } = 0;
        public static float RL_LatForceSlide { get; set; } = 0;
        public static float RL_LatForceTotal { get; set; } = 0;
        public static float SelfAligningMomentStiffness(float latStiffness, float tireContactLength)
        {
            return 2/3 * latStiffness * (float)Math.Pow(tireContactLength / 2, 3);
        }
        public static float ForceStatic(float tireContactLength, float bristleStiffness, float friction, float verticalLoad, float slipRatioOrAngleRad, bool isSlipRatio)
        {
            float slip;

            if (isSlipRatio == true)
            {  
                slip = slipRatioOrAngleRad;
            }
            else
            {
                slip = (float)Math.Tan(slipRatioOrAngleRad);
            }
            return 2 * (float)(Math.Pow(tireContactLength / 2, 2) * bristleStiffness * slip - 8 / 3 * (Math.Pow(Math.Pow(tireContactLength / 2, 2) * bristleStiffness * slip, 2)) / (friction * verticalLoad) + 8 / 9 * Math.Pow(Math.Pow(tireContactLength / 2, 2) * bristleStiffness * slip, 3) / (Math.Pow(friction * verticalLoad, 2)));
        }
        public static float ForceSlide(float tireContactLength, float bristleStiffness, float friction, float verticalLoad, float slipRatioOrAngleRad, bool isSlipRatio)
        {
            float slip;

            if (isSlipRatio == true)
            {
                slip = slipRatioOrAngleRad;
            }
            else
            {
                slip = (float)Math.Tan(slipRatioOrAngleRad);
            }
            return 4 / 3 * (float)((Math.Pow(Math.Pow(tireContactLength / 2, 2) * bristleStiffness * slip, 2)) / (friction * verticalLoad) - 16 / 27 * (Math.Pow(Math.Pow(tireContactLength / 2, 2) * bristleStiffness * slip, 3)) / (Math.Pow(friction * verticalLoad, 2)));
        }
        public static float ForceTotal(float staticForce, float lonForce)
        { return staticForce + lonForce; }
        */
        public static float RadToDeg(float toConvert)
        {
            return toConvert * fRadToDeg;
        }
        public static double XZAngleRad(double x, double z)
        {
            if (x > 0)
            {
                if (z > 0)
                {
                    return (Math.PI + (Math.Atan(x / z)));
                }
                else if (z < 0)
                {
                    return (2 * Math.PI + (Math.Atan(x / z)));
                }
                else
                {
                    return 1.5 * Math.PI;
                }
            }
            else if (x < 0)
            {
                if (z > 0)
                {
                    return (Math.PI + (Math.Atan(x / z)));
                }
                else if (z < 0)
                {
                    return (0d + (Math.Atan(x / z)));
                }
                else
                {
                    return 0.5 * Math.PI;
                }
            }
            else
            {
                if (z > 0f)
                {
                    return Math.PI;
                }
                else if (z < 0f)
                {
                    return 2 * Math.PI;
                }
                else
                {
                    return 0d;
                }
            }
        }
        public static float[] GetFloatArrayData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr, int[] offsets, int arraySize)
        {
            ulong bAU = memoryHelper.GetBaseAddress(baseAddr + baseAddrUpdt - baseAddrDodt);

            return memoryHelper.ReadMemoryFloatArray<float[]>(Memory.Utils.MemoryUtils.OffsetCalculator(memoryHelper, bAU, offsets), arraySize);
        }
        public static T GetData<T>(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr, int[] offsets)
        {
            ulong bAU = memoryHelper.GetBaseAddress(baseAddr + baseAddrUpdt - baseAddrDodt);

            return memoryHelper.ReadMemory<T>(Memory.Utils.MemoryUtils.OffsetCalculator(memoryHelper, bAU, offsets));
        }
        private static void GetDragLiftsDifferentialLocationHeadingData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            M11 = GetData<float>(memoryHelper, baseAddr, M11Offsets);
            M12 = GetData<float>(memoryHelper, baseAddr, M12Offsets);
            M13 = GetData<float>(memoryHelper, baseAddr, M13Offsets);
            M14 = GetData<float>(memoryHelper, baseAddr, M14Offsets);
            M21 = GetData<float>(memoryHelper, baseAddr, M21Offsets);
            M22 = GetData<float>(memoryHelper, baseAddr, M22Offsets);
            M23 = GetData<float>(memoryHelper, baseAddr, M23Offsets);
            M24 = GetData<float>(memoryHelper, baseAddr, M24Offsets);
            M31 = GetData<float>(memoryHelper, baseAddr, M31Offsets);
            M32 = GetData<float>(memoryHelper, baseAddr, M32Offsets);
            M33 = GetData<float>(memoryHelper, baseAddr, M33Offsets);
            M34 = GetData<float>(memoryHelper, baseAddr, M34Offsets);
            M41 = GetData<float>(memoryHelper, baseAddr, M41Offsets);
            M42 = GetData<float>(memoryHelper, baseAddr, M42Offsets);
            M43 = GetData<float>(memoryHelper, baseAddr, M43Offsets);
            M44 = GetData<float>(memoryHelper, baseAddr, M44Offsets);

            xDrag = GetData<float>(memoryHelper, baseAddr, xDragOffsets);
            yDrag = GetData<float>(memoryHelper, baseAddr, yDragOffsets);
            zDrag = GetData<float>(memoryHelper, baseAddr, zDragOffsets);
            frontLift = GetData<float>(memoryHelper, baseAddr, frontLiftOffsets);
            rearLift = GetData<float>(memoryHelper, baseAddr, rearLiftOffsets);
            differentialLocked = GetData<byte>(memoryHelper, baseAddr, differentialOpenOffsets);
            differentialVelocityRad = GetData<float>(memoryHelper, baseAddr, differentialVelocityRadOffsets);
            differentialTorque = GetData<float>(memoryHelper, baseAddr, differentialTorqueOffsets);
        }
        private static void GetEngineSpeedData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            speed = GetData<float>(memoryHelper, baseAddr, speedOffsets);
            engineRPM = GetData<float>(memoryHelper, baseAddr, engineRPMOffests);
            engineRPMAxle = GetData<float>(memoryHelper, baseAddr, engineRPMAxleOffests);
            engineTorque = GetData<float>(memoryHelper, baseAddr, engineTorqueOffsets);
        }
        private static void GetAccelData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            // Most of these not needed for now
            /*
            TXAccel = GetData<float>(memoryHelper, baseAddr, TXOffsets);
            TYAccel = GetData<float>(memoryHelper, baseAddr, TYOffsets);
            TZAccel = GetData<float>(memoryHelper, baseAddr, TZOffsets);

            R11Accel = GetData<float>(memoryHelper, baseAddr, R11Offsets);
            R12Accel = GetData<float>(memoryHelper, baseAddr, R12Offsets);
            R13Accel = GetData<float>(memoryHelper, baseAddr, R13Offsets);
            
            R21Accel = GetData<float>(memoryHelper, baseAddr, R21Offsets);
            R22Accel = GetData<float>(memoryHelper, baseAddr, R22Offsets);
            R23Accel = GetData<float>(memoryHelper, baseAddr, R23Offsets);

            R31Accel = GetData<float>(memoryHelper, baseAddr, R31Offsets);
            R32Accel = GetData<float>(memoryHelper, baseAddr, R32Offsets);
            R33Accel = GetData<float>(memoryHelper, baseAddr, R33Offsets);

            Q1Accel = GetData<float>(memoryHelper, baseAddr, Q1Offsets);
            Q2Accel = GetData<float>(memoryHelper, baseAddr, Q2Offsets);
            Q3Accel = GetData<float>(memoryHelper, baseAddr, Q3Offsets);
            Q4Accel = GetData<float>(memoryHelper, baseAddr, Q4Offsets);

            A1Accel = GetData<float>(memoryHelper, baseAddr, A1Offsets);
            A2Accel = GetData<float>(memoryHelper, baseAddr, A1Offsets);
            */
            XAcceleration = GetData<float>(memoryHelper, baseAddr, XAccelerationOffsets);
            YAcceleration = GetData<float>(memoryHelper, baseAddr, YAccelerationOffsets);
            ZAcceleration = GetData<float>(memoryHelper, baseAddr, ZAccelerationOffsets);
        }
        public static Matrix4x4 TransformMatrixBody { get; set; }
        public static Matrix4x4 TransformMatrixFL;
        public static Matrix4x4 TransformMatrixFR;
        public static Matrix4x4 TransformMatrixRL;
        public static Matrix4x4 TransformMatrixRR;
        public static Vector3 WorldPositionBody { get; set; }
        public static Vector3 WorldAcceleration { get; set; }
        public static Matrix4x4 rotationInvertedBody = Matrix4x4.Identity;
        public static Vector3 PivotPositionFL { get; set; } = new Vector3((float)FL_TireM41, (float)FL_TireM42, (float)FL_TireM43);
        public static Vector3 PivotPositionTireFL = new Vector3((float)FL_TirePivotX, (float)FL_TirePivotY, (float)FL_TirePivotZ);
        public static Vector3 PivotPositionFR { get; set; } = new Vector3((float)FR_TireM41, (float)FR_TireM42, (float)FR_TireM43);
        public static Vector3 PivotPositionTireFR = new Vector3((float)FR_TirePivotX, (float)FR_TirePivotY, (float)FR_TirePivotZ);
        public static Vector3 PivotPositionRL { get; set; } = new Vector3((float)RL_TireM41, (float)RL_TireM42, (float)RL_TireM43);
        public static Vector3 PivotPositionTireRL = new Vector3((float)RL_TirePivotX, (float)RL_TirePivotY, (float)RL_TirePivotZ);
        public static Vector3 PivotPositionRR { get; set; } = new Vector3((float)RR_TireM41, (float)RR_TireM42, (float)RR_TireM43);
        public static Vector3 PivotPositionTireRR = new Vector3((float)RR_TirePivotX, (float)RR_TirePivotY, (float)RR_TirePivotZ);

        public static Vector3 GetPitchYawRollFromQuaternion(Quaternion rotation)
        {
            float yaw = (float)Math.Atan2(2.0f * (rotation.Y * rotation.W + rotation.X * rotation.Z), 1.0f - 2.0f * (rotation.X * rotation.X + rotation.Y * rotation.Y));
            float pitch = (float)Math.Asin(2.0f * (rotation.X * rotation.W - rotation.Y * rotation.Z));
            float roll = (float)Math.Atan2(2.0f * (rotation.X * rotation.Y + rotation.Z * rotation.W), 1.0f - 2.0f * (rotation.X * rotation.X + rotation.Z * rotation.Z));

            return new Vector3(pitch, yaw, roll);
        }
        public static Vector3 CalcAngles(Matrix4x4 transformMatrix)
        {
            Quaternion quat = Quaternion.CreateFromRotationMatrix(transformMatrix);

            Vector3 pitchyawroll = GetPitchYawRollFromQuaternion(quat);
            // Pitch Yaw and Roll or Caster Toe and Camber
            //pitch = -pitchyawroll.X;// caster angle
            //yaw = -pitchyawroll.Y;// toe angle
            //roll = LoopAngleRad(-pitchyawroll.Z, (float)Math.PI * 0.5f);// camber angle
            return pitchyawroll;
        }
        public static Vector3 WorldAccelToLocalAngle(Vector3 worldAcceleration, Vector3 worldPositionBody, Matrix4x4 transformMatrix)
        {
            transformMatrix.Translation = worldPositionBody;
            Matrix4x4 rotation = new Matrix4x4();
            rotation = transformMatrix;
            rotation.M41 = 0.0f;
            rotation.M42 = 0.0f;
            rotation.M43 = 0.0f;
            rotation.M44 = 1.0f;

            rotationInvertedBody = new Matrix4x4();
            Matrix4x4.Invert(rotation, out rotationInvertedBody);

            //transform world acceleration to local space
            Vector3 localAcceleration = Vector3.Transform(worldAcceleration, rotationInvertedBody);
            //Vector3 localAcceleration = worldAcceleration;
            return localAcceleration;
        }
        /*public static Vector3 TirePivotToLocalAngle(Vector3 pivotPositionTire, Vector3 pivotPosition, Matrix4x4 transforMatrixTire)
        {
            transforMatrixTire.Translation = pivotPosition;
            Matrix4x4 rotation = new Matrix4x4();
            rotation = transforMatrixTire;
            rotation.M41 = 0.0f;
            rotation.M42 = 0.0f;
            rotation.M43 = 0.0f;
            rotation.M44 = 1.0f;

            rotationInvertedBody = new Matrix4x4();
            Matrix4x4.Invert(rotation, out rotationInvertedBody);

            //transform world acceleration to local space
            Vector3 localLocation = Vector3.Transform(pivotPositionTire, rotationInvertedBody);
            //Vector3 localAcceleration = worldAcceleration;
            return localLocation;
        }*/
        public static float BigValueReducerFloat(float value)
        {
            if (value > 10000 || value < -10000)
            {
                return 10000;
            }
            else
            {
                return value;
            }
        }
        public static float LoopAngleRad(float angle, float minMag)
        {
            float absAngle = Math.Abs(angle);

            if (absAngle <= minMag)
            {
                return angle;
            }

            float direction = angle / absAngle;

            //(180.0f * 1) - 135 = 45
            //(180.0f *-1) - -135 = -45
            float loopedAngle = ((float)Math.PI * direction) - angle;

            return loopedAngle;
        }
        public static void AccelGForceXYZHeading()
        {
            TransformMatrixBody = new Matrix4x4(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
            WorldAcceleration = new Vector3((float)XAcceleration, (float)YAcceleration, (float)ZAcceleration);
            WorldPositionBody = new Vector3((float)M41, (float)M42, (float)M43);
            CalcAngles(TransformMatrixBody);// Needed?
            pitchBody = -CalcAngles(TransformMatrixBody).X;
            yawBody = -CalcAngles(TransformMatrixBody).Y;
            rollBody = LoopAngleRad(-(float)CalcAngles(TransformMatrixBody).Z, (float)Math.PI * 0.5f);
            Vector3 worldAccelToLocalAngle = WorldAccelToLocalAngle(WorldAcceleration, WorldPositionBody, TransformMatrixBody);
            XAcceleration = worldAccelToLocalAngle.X;
            YAcceleration = worldAccelToLocalAngle.Y;
            ZAcceleration = worldAccelToLocalAngle.Z;

            // Getting the XZ direction where in the world the car is going.
            XZAccelerationAngleRad = XZAngleRad(XAcceleration, ZAcceleration);
            XZAccelerationAngleDeg = RadToDeg((float)XZAccelerationAngleDeg);

            XZAcceleration = Math.Sqrt(Math.Pow(XAcceleration, 2) + Math.Pow(ZAcceleration, 2));
            XYZAcceleration = Math.Sqrt(Math.Pow(XZAcceleration, 2) + Math.Pow(YAcceleration, 2));

            // G-Force
            XG = XAcceleration / g;
            YG = YAcceleration / g;
            ZG = ZAcceleration / g;

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
            XZGAngleDeg = RadToDeg((float)XZGAngleRad); // radians to degrees if needed.
            // These are rotated to the heading, so you want to use these likely
            XGRotated = Math.Sin(XZGAngleRad) * XZG;
            ZGRotated = Math.Cos(XZGAngleRad) * XZG;
            YGRotated = YG;// Y axis isn't ever rotated
        }
        public static float[] FL_TireData { get; set; }
        private static void GetFLTireData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            // OLD WAY. Remaining as references

            //FL_MomentOfInertia = GetData<float>(memoryHelper, baseAddr, FL_MomentOfInertiaOffsets);
            //FL_AngularVelocity = GetData<float>(memoryHelper, baseAddr, FL_AngularVelocityOffsets);

            //FL_TirePivotX = GetData<float>(memoryHelper, baseAddr, FL_M11Offsets);
            //FL_TirePivotY = GetData<float>(memoryHelper, baseAddr, FL_M11Offsets);
            //FL_TirePivotZ = GetData<float>(memoryHelper, baseAddr, FL_M11Offsets);

            //FL_TireM11 = GetData<float>(memoryHelper, baseAddr, FL_M11Offsets);//FL_CasterAngleRad = GetData<float>(memoryHelper, baseAddr, FL_CasterAngleRadOffsets);
            //FL_TireM12 = GetData<float>(memoryHelper, baseAddr, FL_M12Offsets);//FL_CamberAngleRad = GetData<float>(memoryHelper, baseAddr, FL_CamberAngleRadOffsets);
            //FL_TireM13 = GetData<float>(memoryHelper, baseAddr, FL_M13Offsets);//FL_SteerAngleRad = GetData<float>(memoryHelper, baseAddr, FL_SteerAngleRadOffsets);
            //FL_TireM14 = GetData<float>(memoryHelper, baseAddr, FL_M14Offsets);
            //FL_TireM21 = GetData<float>(memoryHelper, baseAddr, FL_M21Offsets);
            //FL_TireM22 = GetData<float>(memoryHelper, baseAddr, FL_M22Offsets);
            //FL_TireM23 = GetData<float>(memoryHelper, baseAddr, FL_M23Offsets);
            //FL_TireM24 = GetData<float>(memoryHelper, baseAddr, FL_M24Offsets);
            //FL_TireM31 = GetData<float>(memoryHelper, baseAddr, FL_M31Offsets);
            //FL_TireM32 = GetData<float>(memoryHelper, baseAddr, FL_M32Offsets);
            //FL_TireM33 = GetData<float>(memoryHelper, baseAddr, FL_M33Offsets);
            //FL_TireM34 = GetData<float>(memoryHelper, baseAddr, FL_M34Offsets);
            //FL_TireM41 = GetData<float>(memoryHelper, baseAddr, FL_M41Offsets);
            //FL_TireM42 = GetData<float>(memoryHelper, baseAddr, FL_M42Offsets);
            //FL_TireM43 = GetData<float>(memoryHelper, baseAddr, FL_M43Offsets);
            //FL_TireM44 = GetData<float>(memoryHelper, baseAddr, FL_M44Offsets);

            //FL_TireMass = GetData<float>(memoryHelper, baseAddr, FL_TireMassOffsets);
            //FL_TireRadius = GetData<float>(memoryHelper, baseAddr, FL_TireRadiusOffsets);
            //FL_TireWidth = GetData<float>(memoryHelper, baseAddr, FL_TireWidthOffsets);
            //FL_TireSpringRate = GetData<float>(memoryHelper, baseAddr, FL_TireSpringRateOffsets);
            //FL_TireDamperRate = GetData<float>(memoryHelper, baseAddr, FL_TireDamperRateOffsets);
            //FL_TireMaxDeflection = GetData<float>(memoryHelper, baseAddr, FL_TireMaxDeflectionOffsets);
            //FL_ThermalAirTransfer = GetData<float>(memoryHelper, baseAddr, FL_ThermalAirTransferOffsets);
            //FL_ThermalInnerTransfer = GetData<float>(memoryHelper, baseAddr, FL_ThermalInnerTransferOffsets);

            //FL_TreadTemperature = GetData<float>(memoryHelper, baseAddr, flsOffsets);
            //FL_InnerTemperature = GetData<float>(memoryHelper, baseAddr, fliOffsets);
            //FL_VerticalDeflection = GetData<float>(memoryHelper, baseAddr, FL_VerticalDeflectionOffsets);
            //FL_LoadedRadius = GetData<float>(memoryHelper, baseAddr, FL_LoadedRadiusOffsets);
            //FL_EffectiveRadius = GetData<float>(memoryHelper, baseAddr, FL_EffectiveRadiusOffsets);
            //FL_LateralSlipSpeed = GetData<float>(memoryHelper, baseAddr, FL_LateralSlipSpeedOffsets);
            //FL_LongitudinalSlipSpeed = GetData<float>(memoryHelper, baseAddr, FL_LongitudinalSlipSpeedOffsets);

            //FL_CurrentContactBrakeTorque = GetData<float>(memoryHelper, baseAddr, FL_CurrentContactBrakeTorqueOffsets);

            //FL_CurrentContactBrakeTorqueMax = GetData<float>(memoryHelper, baseAddr, FL_CurrentContactBrakeTorqueMaxOffsets);

            //FL_VerticalLoad = GetData<float>(memoryHelper, baseAddr, FL_VerticalLoadOffsets);

            //FL_X = GetData<float>(memoryHelper, baseAddr, FL_XOffsets);
            //FL_Y = GetData<float>(memoryHelper, baseAddr, FL_YOffsets);
            //FL_Z = GetData<float>(memoryHelper, baseAddr, FL_ZOffsets);

            //FL_LateralLoad = GetData<float>(memoryHelper, baseAddr, FL_LateralLoadOffsets);

            //FL_LongitudinalLoad = GetData<float>(memoryHelper, baseAddr, FL_LongitudinalLoadOffsets);

            //FL_SlipAngleRad = GetData<float>(memoryHelper, baseAddr, FL_SlipAngleRadOffsets);
            //FL_SlipRatio = GetData<float>(memoryHelper, baseAddr, FL_SlipRatioOffsets);

            //FL_ContactLength = GetData<float>(memoryHelper, baseAddr, FL_ContactLengthOffsets);
            //FL_TravelSpeed = GetData<float>(memoryHelper, baseAddr, FL_TravelSpeedOffsets);

            // New way
            FL_TireData = GetFloatArrayData(memoryHelper, baseAddr, FL_TireDataStartOffsets, TireDataChunkSize);

            FL_MomentOfInertia = FL_TireData[(OffsetMomentOfInertia - OffsetTireDataStart) / Marshal.SizeOf(FL_MomentOfInertia)];
            FL_AngularVelocity = FL_TireData[(OffsetAngularVelocity - OffsetTireDataStart) / Marshal.SizeOf(FL_AngularVelocity)];

            FL_TirePivotX = FL_TireData[(OffsetTirePivotX - OffsetTireDataStart) / Marshal.SizeOf(FL_TirePivotX)];
            FL_TirePivotY = FL_TireData[(OffsetTirePivotY - OffsetTireDataStart) / Marshal.SizeOf(FL_TirePivotY)];
            FL_TirePivotZ = FL_TireData[(OffsetTirePivotZ - OffsetTireDataStart) / Marshal.SizeOf(FL_TirePivotZ)];
            FL_TireM11 = FL_TireData[(OffsetTireM11 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM11)];
            FL_TireM12 = FL_TireData[(OffsetTireM12 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM12)];
            FL_TireM13 = FL_TireData[(OffsetTireM13 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM13)];
            FL_TireM14 = FL_TireData[(OffsetTireM14 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM14)];
            FL_TireM21 = FL_TireData[(OffsetTireM21 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM21)];
            FL_TireM22 = FL_TireData[(OffsetTireM22 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM22)];
            FL_TireM23 = FL_TireData[(OffsetTireM23 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM23)];
            FL_TireM24 = FL_TireData[(OffsetTireM24 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM24)];
            FL_TireM31 = FL_TireData[(OffsetTireM31 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM31)];
            FL_TireM32 = FL_TireData[(OffsetTireM32 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM32)];
            FL_TireM33 = FL_TireData[(OffsetTireM33 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM33)];
            FL_TireM34 = FL_TireData[(OffsetTireM34 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM34)];
            FL_TireM41 = FL_TireData[(OffsetTireM41 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM41)];
            FL_TireM42 = FL_TireData[(OffsetTireM42 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM42)];
            FL_TireM43 = FL_TireData[(OffsetTireM43 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM43)];
            FL_TireM44 = FL_TireData[(OffsetTireM44 - OffsetTireDataStart) / Marshal.SizeOf(FL_TireM44)];
            //?? Some matrix likely again
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            FL_TireMass = FL_TireData[(OffsetTireMass - OffsetTireDataStart) / Marshal.SizeOf(FL_TireMass)];
            FL_TireRadius = FL_TireData[(OffsetTireRadius - OffsetTireDataStart) / Marshal.SizeOf(FL_TireRadius)];
            FL_TireWidth = FL_TireData[(OffsetTireWidth - OffsetTireDataStart) / Marshal.SizeOf(FL_TireWidth)];
            FL_TireSpringRate = FL_TireData[(OffsetTireSpringRate - OffsetTireDataStart) / Marshal.SizeOf(FL_TireSpringRate)];
            FL_TireDamperRate = FL_TireData[(OffsetTireDamperRate - OffsetTireDataStart) / Marshal.SizeOf(FL_TireDamperRate)];
            FL_TireMaxDeflection = FL_TireData[(OffsetTireMaxDeflection - OffsetTireDataStart) / Marshal.SizeOf(FL_TireMaxDeflection)];
            FL_ThermalAirTransfer = FL_TireData[(OffsetThermalAirTransfer - OffsetTireDataStart) / Marshal.SizeOf(FL_ThermalAirTransfer)];
            FL_ThermalInnerTransfer = FL_TireData[(OffsetThermalInnerTransfer - OffsetTireDataStart) / Marshal.SizeOf(FL_ThermalInnerTransfer)];
            //??
            FL_TreadTemperature = FL_TireData[(OffsetTreadTemperature - OffsetTireDataStart) / Marshal.SizeOf(FL_TreadTemperature)];
            FL_InnerTemperature = FL_TireData[(OffsetInnerTemperature - OffsetTireDataStart) / Marshal.SizeOf(FL_InnerTemperature)];
            FL_VerticalDeflection = FL_TireData[(OffsetVerticalDeflection - OffsetTireDataStart) / Marshal.SizeOf(FL_VerticalDeflection)];
            //??
            FL_LoadedRadius = FL_TireData[(OffsetLoadedRadius - OffsetTireDataStart) / Marshal.SizeOf(FL_LoadedRadius)];
            FL_EffectiveRadius = FL_TireData[(OffsetEffectiveRadius - OffsetTireDataStart) / Marshal.SizeOf(FL_EffectiveRadius)];
            FL_LongitudinalSlipSpeed = FL_TireData[(OffsetLongitudinalSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(FL_LongitudinalSlipSpeed)];
            FL_LateralSlipSpeed = FL_TireData[(OffsetLateralSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(FL_LateralSlipSpeed)];
            FL_RadiansTireMoved = FL_TireData[(OffsetRadiansTireMoved - OffsetTireDataStart) / Marshal.SizeOf(FL_RadiansTireMoved)];
            //??
            FL_CurrentContactBrakeTorque = FL_TireData[(OffsetCurrentContactBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(FL_CurrentContactBrakeTorque)];
            FL_CurrentContactHandBrakeTorque = FL_TireData[(OffsetCurrentContactHandBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(FL_CurrentContactHandBrakeTorque)];
            FL_CurrentContactBrakeTorqueMax = FL_TireData[(OffsetCurrentContactBrakeTorqueMax - OffsetTireDataStart) / Marshal.SizeOf(FL_CurrentContactBrakeTorqueMax)];
            FL_VerticalLoad = FL_TireData[(OffsetVerticalLoad - OffsetTireDataStart) / Marshal.SizeOf(FL_VerticalLoad)];
            //FL_VerticalLoadSomeOther = FL_TireData[(OffsetVerticalLoadSomeOther - OffsetTireDataStart) / Marshal.SizeOf(FL_VerticalLoadSomeOther)];
            //??
            //??
            //??
            //??
            //??
            FL_TireX = FL_TireData[(OffsetTireX - OffsetTireDataStart) / Marshal.SizeOf(FL_TireX)];
            FL_TireY = FL_TireData[(OffsetTireY - OffsetTireDataStart) / Marshal.SizeOf(FL_TireY)];
            FL_TireZ = FL_TireData[(OffsetTireZ - OffsetTireDataStart) / Marshal.SizeOf(FL_TireZ)];
            FL_LateralLoad = FL_TireData[(OffsetLateralLoad - OffsetTireDataStart) / Marshal.SizeOf(FL_LateralLoad)];
            //??
            FL_LongitudinalLoad = FL_TireData[(OffsetLongitudinalLoad - OffsetTireDataStart) / Marshal.SizeOf(FL_LongitudinalLoad)];
            //??
            //??
            //Rolling Resistance/SAT?
            //Rolling Resistance/SAT?
            //SAT?
            //SAT?
            //FL_SlipAngleRadALMOST = FL_TireData[(OffsetSlipAngleRadALMOST - OffsetTireDataStart) / Marshal.SizeOf(FL_SlipAngleRadALMOST)];
            FL_SlipAngleRad = FL_TireData[(OffsetSlipAngleRad - OffsetTireDataStart) / Marshal.SizeOf(FL_SlipAngleRad)];
            FL_SlipRatio = FL_TireData[(OffsetSlipRatio - OffsetTireDataStart) / Marshal.SizeOf(FL_SlipRatio)];
            FL_LateralResistance = FL_TireData[(OffsetLateralResistance - OffsetTireDataStart) / Marshal.SizeOf(FL_LateralResistance)];
            FL_LongitudinalResistance = FL_TireData[(OffsetLongitudinalResistance - OffsetTireDataStart) / Marshal.SizeOf(FL_LongitudinalResistance)];
            //??
            //??
            //??
            //Slip Ratio Again??
            //??
            //??
            //??
            FL_ContactLength = FL_TireData[(OffsetContactLength - OffsetTireDataStart) / Marshal.SizeOf(FL_ContactLength)];
            FL_TravelSpeed = FL_TireData[(OffsetTravelSpeed - OffsetTireDataStart) / Marshal.SizeOf(FL_TravelSpeed)];
            //?? 15 stuff of unknown
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??

            // These two just happen to be in the same offset, so they use the old method.
            FL_SuspensionLength = GetData<float>(memoryHelper, baseAddr, FL_SuspensionLengthOffsets);
            FL_SuspensionVelocity = GetData<float>(memoryHelper, baseAddr, FL_SuspensionVelocityOffsets);

            TransformMatrixFL = new Matrix4x4(FL_TireM11, FL_TireM12, FL_TireM13, FL_TireM14, FL_TireM21, FL_TireM22, FL_TireM23, FL_TireM24, FL_TireM31, FL_TireM32, FL_TireM33, FL_TireM34, FL_TireM41, FL_TireM42, FL_TireM43, FL_TireM44);
            CalcAngles(TransformMatrixFL);// Needed?
            pitchFL = -CalcAngles(TransformMatrixFL).X;// caster not really
            yawFL = -CalcAngles(TransformMatrixFL).Y;// toe close
            rollFL = LoopAngleRad(-(float)CalcAngles(TransformMatrixFL).Z, (float)Math.PI * 0.5f);// camber close

            FL_LateralFriction = GetLateralFriction(FL_LateralLoad, FL_VerticalLoad);
            FL_LongitudinalFriction = GetLongitudinalFriction(FL_LongitudinalLoad, FL_VerticalLoad);
            FL_TotalFriction = GetTotalFriction(FL_LateralFriction, FL_LongitudinalFriction);
            FL_TotalFrictionAngle = GetTotalFrictionAngle(FL_LateralFriction, FL_LongitudinalFriction);
            FL_SlipAngleDeg = RadToDeg(FL_SlipAngleRad);
            //FL_CamberAngleDeg = RadToDeg(FL_CamberAngleRad);
            //FL_SteerAngleDeg = RadToDeg(FL_SteerAngleRad);
            FL_CasterAngleDeg = RadToDeg(pitchFL);// RadToDeg(FL_TireM11);
            FL_SteerAngleDeg = RadToDeg(yawFL);// RadToDeg(FL_TireM13);
            FL_CamberAngleDeg = RadToDeg(rollFL);// RadToDeg(FL_TireM12);
        }
        public static float[] FR_TireData { get; set; }
        private static void GetFRTireData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            // New way
            FR_TireData = GetFloatArrayData(memoryHelper, baseAddr, FR_TireDataStartOffsets, TireDataChunkSize);

            FR_MomentOfInertia = FR_TireData[(OffsetMomentOfInertia - OffsetTireDataStart) / Marshal.SizeOf(FR_MomentOfInertia)];
            FR_AngularVelocity = FR_TireData[(OffsetAngularVelocity - OffsetTireDataStart) / Marshal.SizeOf(FR_AngularVelocity)];

            FR_TirePivotX = FR_TireData[(OffsetTirePivotX - OffsetTireDataStart) / Marshal.SizeOf(FR_TirePivotX)];
            FR_TirePivotY = FR_TireData[(OffsetTirePivotY - OffsetTireDataStart) / Marshal.SizeOf(FR_TirePivotY)];
            FR_TirePivotZ = FR_TireData[(OffsetTirePivotZ - OffsetTireDataStart) / Marshal.SizeOf(FR_TirePivotZ)];
            FR_TireM11 = FR_TireData[(OffsetTireM11 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM11)];
            FR_TireM12 = FR_TireData[(OffsetTireM12 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM12)];
            FR_TireM13 = FR_TireData[(OffsetTireM13 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM13)];
            FR_TireM14 = FR_TireData[(OffsetTireM14 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM14)];
            FR_TireM21 = FR_TireData[(OffsetTireM21 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM21)];
            FR_TireM22 = FR_TireData[(OffsetTireM22 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM22)];
            FR_TireM23 = FR_TireData[(OffsetTireM23 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM23)];
            FR_TireM24 = FR_TireData[(OffsetTireM24 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM24)];
            FR_TireM31 = FR_TireData[(OffsetTireM31 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM31)];
            FR_TireM32 = FR_TireData[(OffsetTireM32 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM32)];
            FR_TireM33 = FR_TireData[(OffsetTireM33 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM33)];
            FR_TireM34 = FR_TireData[(OffsetTireM34 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM34)];
            FR_TireM41 = FR_TireData[(OffsetTireM41 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM41)];
            FR_TireM42 = FR_TireData[(OffsetTireM42 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM42)];
            FR_TireM43 = FR_TireData[(OffsetTireM43 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM43)];
            FR_TireM44 = FR_TireData[(OffsetTireM44 - OffsetTireDataStart) / Marshal.SizeOf(FR_TireM44)];
            //?? Some matrix likely again
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            FR_TireMass = FR_TireData[(OffsetTireMass - OffsetTireDataStart) / Marshal.SizeOf(FR_TireMass)];
            FR_TireRadius = FR_TireData[(OffsetTireRadius - OffsetTireDataStart) / Marshal.SizeOf(FR_TireRadius)];
            FR_TireWidth = FR_TireData[(OffsetTireWidth - OffsetTireDataStart) / Marshal.SizeOf(FR_TireWidth)];
            FR_TireSpringRate = FR_TireData[(OffsetTireSpringRate - OffsetTireDataStart) / Marshal.SizeOf(FR_TireSpringRate)];
            FR_TireDamperRate = FR_TireData[(OffsetTireDamperRate - OffsetTireDataStart) / Marshal.SizeOf(FR_TireDamperRate)];
            FR_TireMaxDeflection = FR_TireData[(OffsetTireMaxDeflection - OffsetTireDataStart) / Marshal.SizeOf(FR_TireMaxDeflection)];
            FR_ThermalAirTransfer = FR_TireData[(OffsetThermalAirTransfer - OffsetTireDataStart) / Marshal.SizeOf(FR_ThermalAirTransfer)];
            FR_ThermalInnerTransfer = FR_TireData[(OffsetThermalInnerTransfer - OffsetTireDataStart) / Marshal.SizeOf(FR_ThermalInnerTransfer)];
            //??
            FR_TreadTemperature = FR_TireData[(OffsetTreadTemperature - OffsetTireDataStart) / Marshal.SizeOf(FR_TreadTemperature)];
            FR_InnerTemperature = FR_TireData[(OffsetInnerTemperature - OffsetTireDataStart) / Marshal.SizeOf(FR_InnerTemperature)];
            FR_VerticalDeflection = FR_TireData[(OffsetVerticalDeflection - OffsetTireDataStart) / Marshal.SizeOf(FR_VerticalDeflection)];
            //??
            FR_LoadedRadius = FR_TireData[(OffsetLoadedRadius - OffsetTireDataStart) / Marshal.SizeOf(FR_LoadedRadius)];
            FR_EffectiveRadius = FR_TireData[(OffsetEffectiveRadius - OffsetTireDataStart) / Marshal.SizeOf(FR_EffectiveRadius)];
            FR_LongitudinalSlipSpeed = FR_TireData[(OffsetLongitudinalSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(FR_LongitudinalSlipSpeed)];
            FR_LateralSlipSpeed = FR_TireData[(OffsetLateralSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(FR_LateralSlipSpeed)];
            FR_RadiansTireMoved = FR_TireData[(OffsetRadiansTireMoved - OffsetTireDataStart) / Marshal.SizeOf(FR_RadiansTireMoved)];
            //??
            FR_CurrentContactBrakeTorque = FR_TireData[(OffsetCurrentContactBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(FR_CurrentContactBrakeTorque)];
            FR_CurrentContactHandBrakeTorque = FR_TireData[(OffsetCurrentContactHandBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(FR_CurrentContactHandBrakeTorque)];
            FR_CurrentContactBrakeTorqueMax = FR_TireData[(OffsetCurrentContactBrakeTorqueMax - OffsetTireDataStart) / Marshal.SizeOf(FR_CurrentContactBrakeTorqueMax)];
            FR_VerticalLoad = FR_TireData[(OffsetVerticalLoad - OffsetTireDataStart) / Marshal.SizeOf(FR_VerticalLoad)];
            //FR_VerticalLoadSomeOther = FR_TireData[(OffsetVerticalLoadSomeOther - OffsetTireDataStart) / Marshal.SizeOf(FR_VerticalLoadSomeOther)];
            //??
            //??
            //??
            //??
            //??
            FR_TireX = FR_TireData[(OffsetTireX - OffsetTireDataStart) / Marshal.SizeOf(FR_TireX)];
            FR_TireY = FR_TireData[(OffsetTireY - OffsetTireDataStart) / Marshal.SizeOf(FR_TireY)];
            FR_TireZ = FR_TireData[(OffsetTireZ - OffsetTireDataStart) / Marshal.SizeOf(FR_TireZ)];
            FR_LateralLoad = FR_TireData[(OffsetLateralLoad - OffsetTireDataStart) / Marshal.SizeOf(FR_LateralLoad)];
            //??
            FR_LongitudinalLoad = FR_TireData[(OffsetLongitudinalLoad - OffsetTireDataStart) / Marshal.SizeOf(FR_LongitudinalLoad)];
            //??
            //??
            //Rolling Resistance/SAT?
            //Rolling Resistance/SAT?
            //SAT?
            //SAT?
            //FR_SlipAngleRadALMOST = FR_TireData[(OffsetSlipAngleRadALMOST - OffsetTireDataStart) / Marshal.SizeOf(FR_SlipAngleRadALMOST)];
            FR_SlipAngleRad = FR_TireData[(OffsetSlipAngleRad - OffsetTireDataStart) / Marshal.SizeOf(FR_SlipAngleRad)];
            FR_SlipRatio = FR_TireData[(OffsetSlipRatio - OffsetTireDataStart) / Marshal.SizeOf(FR_SlipRatio)];
            FR_LateralResistance = FR_TireData[(OffsetLateralResistance - OffsetTireDataStart) / Marshal.SizeOf(FR_LateralResistance)];
            FR_LongitudinalResistance = FR_TireData[(OffsetLongitudinalResistance - OffsetTireDataStart) / Marshal.SizeOf(FR_LongitudinalResistance)];
            //??
            //??
            //??
            //Slip Ratio Again??
            //??
            //??
            //??
            FR_ContactLength = FR_TireData[(OffsetContactLength - OffsetTireDataStart) / Marshal.SizeOf(FR_ContactLength)];
            FR_TravelSpeed = FR_TireData[(OffsetTravelSpeed - OffsetTireDataStart) / Marshal.SizeOf(FR_TravelSpeed)];
            //?? 15 stuff of unknown
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??

            // These two just happen to be in the same offset, so they use the old method.
            FR_SuspensionLength = GetData<float>(memoryHelper, baseAddr, FR_SuspensionLengthOffsets);
            FR_SuspensionVelocity = GetData<float>(memoryHelper, baseAddr, FR_SuspensionVelocityOffsets);

            TransformMatrixFR = new Matrix4x4(FR_TireM11, FR_TireM12, FR_TireM13, FR_TireM14, FR_TireM21, FR_TireM22, FR_TireM23, FR_TireM24, FR_TireM31, FR_TireM32, FR_TireM33, FR_TireM34, FR_TireM41, FR_TireM42, FR_TireM43, FR_TireM44);
            CalcAngles(TransformMatrixFR);// Needed?
            pitchFR = -CalcAngles(TransformMatrixFR).X;// caster not really
            yawFR = -CalcAngles(TransformMatrixFR).Y;// toe close
            rollFR = LoopAngleRad(-(float)CalcAngles(TransformMatrixFR).Z, (float)Math.PI * 0.5f);// camber close

            FR_LateralFriction = GetLateralFriction(FR_LateralLoad, FR_VerticalLoad);
            FR_LongitudinalFriction = GetLongitudinalFriction(FR_LongitudinalLoad, FR_VerticalLoad);
            FR_TotalFriction = GetTotalFriction(FR_LateralFriction, FR_LongitudinalFriction);
            FR_TotalFrictionAngle = GetTotalFrictionAngle(FR_LateralFriction, FR_LongitudinalFriction);
            FR_SlipAngleDeg = RadToDeg(FR_SlipAngleRad);
            //FR_CamberAngleDeg = RadToDeg(FR_CamberAngleRad);
            //FR_SteerAngleDeg = RadToDeg(FR_SteerAngleRad);
            FR_CasterAngleDeg = RadToDeg(pitchFR);//RadToDeg(FR_TireM11);
            FR_SteerAngleDeg = RadToDeg(yawFR);//RadToDeg(FR_TireM13);
            FR_CamberAngleDeg = RadToDeg(rollFR);//RadToDeg(FR_TireM12);
        }
        public static float[] RL_TireData { get; set; }
        private static void GetRLTireData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            // New way
            RL_TireData = GetFloatArrayData(memoryHelper, baseAddr, RL_TireDataStartOffsets, TireDataChunkSize);

            RL_MomentOfInertia = RL_TireData[(OffsetMomentOfInertia - OffsetTireDataStart) / Marshal.SizeOf(RL_MomentOfInertia)];
            RL_AngularVelocity = RL_TireData[(OffsetAngularVelocity - OffsetTireDataStart) / Marshal.SizeOf(RL_AngularVelocity)];

            RL_TirePivotX = RL_TireData[(OffsetTirePivotX - OffsetTireDataStart) / Marshal.SizeOf(RL_TirePivotX)];
            RL_TirePivotY = RL_TireData[(OffsetTirePivotY - OffsetTireDataStart) / Marshal.SizeOf(RL_TirePivotY)];
            RL_TirePivotZ = RL_TireData[(OffsetTirePivotZ - OffsetTireDataStart) / Marshal.SizeOf(RL_TirePivotZ)];
            RL_TireM11 = RL_TireData[(OffsetTireM11 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM11)];
            RL_TireM12 = RL_TireData[(OffsetTireM12 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM12)];
            RL_TireM13 = RL_TireData[(OffsetTireM13 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM13)];
            RL_TireM14 = RL_TireData[(OffsetTireM14 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM14)];
            RL_TireM21 = RL_TireData[(OffsetTireM21 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM21)];
            RL_TireM22 = RL_TireData[(OffsetTireM22 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM22)];
            RL_TireM23 = RL_TireData[(OffsetTireM23 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM23)];
            RL_TireM24 = RL_TireData[(OffsetTireM24 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM24)];
            RL_TireM31 = RL_TireData[(OffsetTireM31 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM31)];
            RL_TireM32 = RL_TireData[(OffsetTireM32 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM32)];
            RL_TireM33 = RL_TireData[(OffsetTireM33 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM33)];
            RL_TireM34 = RL_TireData[(OffsetTireM34 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM34)];
            RL_TireM41 = RL_TireData[(OffsetTireM41 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM41)];
            RL_TireM42 = RL_TireData[(OffsetTireM42 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM42)];
            RL_TireM43 = RL_TireData[(OffsetTireM43 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM43)];
            RL_TireM44 = RL_TireData[(OffsetTireM44 - OffsetTireDataStart) / Marshal.SizeOf(RL_TireM44)];
            //?? Some matrix likely again
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            RL_TireMass = RL_TireData[(OffsetTireMass - OffsetTireDataStart) / Marshal.SizeOf(RL_TireMass)];
            RL_TireRadius = RL_TireData[(OffsetTireRadius - OffsetTireDataStart) / Marshal.SizeOf(RL_TireRadius)];
            RL_TireWidth = RL_TireData[(OffsetTireWidth - OffsetTireDataStart) / Marshal.SizeOf(RL_TireWidth)];
            RL_TireSpringRate = RL_TireData[(OffsetTireSpringRate - OffsetTireDataStart) / Marshal.SizeOf(RL_TireSpringRate)];
            RL_TireDamperRate = RL_TireData[(OffsetTireDamperRate - OffsetTireDataStart) / Marshal.SizeOf(RL_TireDamperRate)];
            RL_TireMaxDeflection = RL_TireData[(OffsetTireMaxDeflection - OffsetTireDataStart) / Marshal.SizeOf(RL_TireMaxDeflection)];
            RL_ThermalAirTransfer = RL_TireData[(OffsetThermalAirTransfer - OffsetTireDataStart) / Marshal.SizeOf(RL_ThermalAirTransfer)];
            RL_ThermalInnerTransfer = RL_TireData[(OffsetThermalInnerTransfer - OffsetTireDataStart) / Marshal.SizeOf(RL_ThermalInnerTransfer)];
            //??
            RL_TreadTemperature = RL_TireData[(OffsetTreadTemperature - OffsetTireDataStart) / Marshal.SizeOf(RL_TreadTemperature)];
            RL_InnerTemperature = RL_TireData[(OffsetInnerTemperature - OffsetTireDataStart) / Marshal.SizeOf(RL_InnerTemperature)];
            RL_VerticalDeflection = RL_TireData[(OffsetVerticalDeflection - OffsetTireDataStart) / Marshal.SizeOf(RL_VerticalDeflection)];
            //??
            RL_LoadedRadius = RL_TireData[(OffsetLoadedRadius - OffsetTireDataStart) / Marshal.SizeOf(RL_LoadedRadius)];
            RL_EffectiveRadius = RL_TireData[(OffsetEffectiveRadius - OffsetTireDataStart) / Marshal.SizeOf(RL_EffectiveRadius)];
            RL_LongitudinalSlipSpeed = RL_TireData[(OffsetLongitudinalSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(RL_LongitudinalSlipSpeed)];
            RL_LateralSlipSpeed = RL_TireData[(OffsetLateralSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(RL_LateralSlipSpeed)];
            RL_RadiansTireMoved = RL_TireData[(OffsetRadiansTireMoved - OffsetTireDataStart) / Marshal.SizeOf(RL_RadiansTireMoved)];
            //??
            RL_CurrentContactBrakeTorque = RL_TireData[(OffsetCurrentContactBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(RL_CurrentContactBrakeTorque)];
            RL_CurrentContactHandBrakeTorque = RL_TireData[(OffsetCurrentContactHandBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(RL_CurrentContactHandBrakeTorque)];
            RL_CurrentContactBrakeTorqueMax = RL_TireData[(OffsetCurrentContactBrakeTorqueMax - OffsetTireDataStart) / Marshal.SizeOf(RL_CurrentContactBrakeTorqueMax)];
            RL_VerticalLoad = RL_TireData[(OffsetVerticalLoad - OffsetTireDataStart) / Marshal.SizeOf(RL_VerticalLoad)];
            //RL_VerticalLoadSomeOther = RL_TireData[(OffsetVerticalLoadSomeOther - OffsetTireDataStart) / Marshal.SizeOf(RL_VerticalLoadSomeOther)];
            //??
            //??
            //??
            //??
            //??
            RL_TireX = RL_TireData[(OffsetTireX - OffsetTireDataStart) / Marshal.SizeOf(RL_TireX)];
            RL_TireY = RL_TireData[(OffsetTireY - OffsetTireDataStart) / Marshal.SizeOf(RL_TireY)];
            RL_TireZ = RL_TireData[(OffsetTireZ - OffsetTireDataStart) / Marshal.SizeOf(RL_TireZ)];
            RL_LateralLoad = RL_TireData[(OffsetLateralLoad - OffsetTireDataStart) / Marshal.SizeOf(RL_LateralLoad)];
            //??
            RL_LongitudinalLoad = RL_TireData[(OffsetLongitudinalLoad - OffsetTireDataStart) / Marshal.SizeOf(RL_LongitudinalLoad)];
            //??
            //??
            //Rolling Resistance/SAT?
            //Rolling Resistance/SAT?
            //SAT?
            //SAT?
            //RL_SlipAngleRadALMOST = RL_TireData[(OffsetSlipAngleRadALMOST - OffsetTireDataStart) / Marshal.SizeOf(RL_SlipAngleRadALMOST)];
            RL_SlipAngleRad = RL_TireData[(OffsetSlipAngleRad - OffsetTireDataStart) / Marshal.SizeOf(RL_SlipAngleRad)];
            RL_SlipRatio = RL_TireData[(OffsetSlipRatio - OffsetTireDataStart) / Marshal.SizeOf(RL_SlipRatio)];
            RL_LateralResistance = RL_TireData[(OffsetLateralResistance - OffsetTireDataStart) / Marshal.SizeOf(RL_LateralResistance)];
            RL_LongitudinalResistance = RL_TireData[(OffsetLongitudinalResistance - OffsetTireDataStart) / Marshal.SizeOf(RL_LongitudinalResistance)];
            //??
            //??
            //??
            //Slip Ratio Again??
            //??
            //??
            //??
            RL_ContactLength = RL_TireData[(OffsetContactLength - OffsetTireDataStart) / Marshal.SizeOf(RL_ContactLength)];
            RL_TravelSpeed = RL_TireData[(OffsetTravelSpeed - OffsetTireDataStart) / Marshal.SizeOf(RL_TravelSpeed)];
            //?? 15 stuff of unknown
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??

            // These two just happen to be in the same offset, so they use the old method.
            RL_SuspensionLength = GetData<float>(memoryHelper, baseAddr, RL_SuspensionLengthOffsets);
            RL_SuspensionVelocity = GetData<float>(memoryHelper, baseAddr, RL_SuspensionVelocityOffsets);

            TransformMatrixRL = new Matrix4x4(RL_TireM11, RL_TireM12, RL_TireM13, RL_TireM14, RL_TireM21, RL_TireM22, RL_TireM23, RL_TireM24, RL_TireM31, RL_TireM32, RL_TireM33, RL_TireM34, RL_TireM41, RL_TireM42, RL_TireM43, RL_TireM44);
            CalcAngles(TransformMatrixRL);// Needed?
            pitchRL = -CalcAngles(TransformMatrixRL).X;// caster not really
            yawRL = -CalcAngles(TransformMatrixRL).Y;// toe close
            rollRL = LoopAngleRad(-(float)CalcAngles(TransformMatrixRL).Z, (float)Math.PI * 0.5f);// camber close

            RL_LateralFriction = GetLateralFriction(RL_LateralLoad, RL_VerticalLoad);
            RL_LongitudinalFriction = GetLongitudinalFriction(RL_LongitudinalLoad, RL_VerticalLoad);
            RL_TotalFriction = GetTotalFriction(RL_LateralFriction, RL_LongitudinalFriction);
            RL_TotalFrictionAngle = GetTotalFrictionAngle(RL_LateralFriction, RL_LongitudinalFriction);
            RL_SlipAngleDeg = RadToDeg(RL_SlipAngleRad);
            //RL_CamberAngleDeg = RadToDeg(RL_CamberAngleRad);
            //RL_SteerAngleDeg = RadToDeg(RL_SteerAngleRad);
            RL_CasterAngleDeg = RadToDeg(pitchRL);// RadToDeg(RL_TireM11);
            RL_SteerAngleDeg = RadToDeg(yawRL);// RadToDeg(RL_TireM13);
            RL_CamberAngleDeg = RadToDeg(rollRL);// RadToDeg(RL_TireM12);
        }
        public static float[] RR_TireData { get; set; }
        private static void GetRRTireData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr)
        {
            // New way
            RR_TireData = GetFloatArrayData(memoryHelper, baseAddr, RR_TireDataStartOffsets, TireDataChunkSize);

            RR_MomentOfInertia = RR_TireData[(OffsetMomentOfInertia - OffsetTireDataStart) / Marshal.SizeOf(RR_MomentOfInertia)];
            RR_AngularVelocity = RR_TireData[(OffsetAngularVelocity - OffsetTireDataStart) / Marshal.SizeOf(RR_AngularVelocity)];

            RR_TirePivotX = RR_TireData[(OffsetTirePivotX - OffsetTireDataStart) / Marshal.SizeOf(RR_TirePivotX)];
            RR_TirePivotY = RR_TireData[(OffsetTirePivotY - OffsetTireDataStart) / Marshal.SizeOf(RR_TirePivotY)];
            RR_TirePivotZ = RR_TireData[(OffsetTirePivotZ - OffsetTireDataStart) / Marshal.SizeOf(RR_TirePivotZ)];
            RR_TireM11 = RR_TireData[(OffsetTireM11 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM11)];
            RR_TireM12 = RR_TireData[(OffsetTireM12 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM12)];
            RR_TireM13 = RR_TireData[(OffsetTireM13 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM13)];
            RR_TireM14 = RR_TireData[(OffsetTireM14 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM14)];
            RR_TireM21 = RR_TireData[(OffsetTireM21 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM21)];
            RR_TireM22 = RR_TireData[(OffsetTireM22 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM22)];
            RR_TireM23 = RR_TireData[(OffsetTireM23 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM23)];
            RR_TireM24 = RR_TireData[(OffsetTireM24 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM24)];
            RR_TireM31 = RR_TireData[(OffsetTireM31 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM31)];
            RR_TireM32 = RR_TireData[(OffsetTireM32 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM32)];
            RR_TireM33 = RR_TireData[(OffsetTireM33 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM33)];
            RR_TireM34 = RR_TireData[(OffsetTireM34 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM34)];
            RR_TireM41 = RR_TireData[(OffsetTireM41 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM41)];
            RR_TireM42 = RR_TireData[(OffsetTireM42 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM42)];
            RR_TireM43 = RR_TireData[(OffsetTireM43 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM43)];
            RR_TireM44 = RR_TireData[(OffsetTireM44 - OffsetTireDataStart) / Marshal.SizeOf(RR_TireM44)];
            //?? Some matrix likely again
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            RR_TireMass = RR_TireData[(OffsetTireMass - OffsetTireDataStart) / Marshal.SizeOf(RR_TireMass)];
            RR_TireRadius = RR_TireData[(OffsetTireRadius - OffsetTireDataStart) / Marshal.SizeOf(RR_TireRadius)];
            RR_TireWidth = RR_TireData[(OffsetTireWidth - OffsetTireDataStart) / Marshal.SizeOf(RR_TireWidth)];
            RR_TireSpringRate = RR_TireData[(OffsetTireSpringRate - OffsetTireDataStart) / Marshal.SizeOf(RR_TireSpringRate)];
            RR_TireDamperRate = RR_TireData[(OffsetTireDamperRate - OffsetTireDataStart) / Marshal.SizeOf(RR_TireDamperRate)];
            RR_TireMaxDeflection = RR_TireData[(OffsetTireMaxDeflection - OffsetTireDataStart) / Marshal.SizeOf(RR_TireMaxDeflection)];
            RR_ThermalAirTransfer = RR_TireData[(OffsetThermalAirTransfer - OffsetTireDataStart) / Marshal.SizeOf(RR_ThermalAirTransfer)];
            RR_ThermalInnerTransfer = RR_TireData[(OffsetThermalInnerTransfer - OffsetTireDataStart) / Marshal.SizeOf(RR_ThermalInnerTransfer)];
            //??
            RR_TreadTemperature = RR_TireData[(OffsetTreadTemperature - OffsetTireDataStart) / Marshal.SizeOf(RR_TreadTemperature)];
            RR_InnerTemperature = RR_TireData[(OffsetInnerTemperature - OffsetTireDataStart) / Marshal.SizeOf(RR_InnerTemperature)];
            RR_VerticalDeflection = RR_TireData[(OffsetVerticalDeflection - OffsetTireDataStart) / Marshal.SizeOf(RR_VerticalDeflection)];
            //??
            RR_LoadedRadius = RR_TireData[(OffsetLoadedRadius - OffsetTireDataStart) / Marshal.SizeOf(RR_LoadedRadius)];
            RR_EffectiveRadius = RR_TireData[(OffsetEffectiveRadius - OffsetTireDataStart) / Marshal.SizeOf(RR_EffectiveRadius)];
            RR_LongitudinalSlipSpeed = RR_TireData[(OffsetLongitudinalSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(RR_LongitudinalSlipSpeed)];
            RR_LateralSlipSpeed = RR_TireData[(OffsetLateralSlipSpeed - OffsetTireDataStart) / Marshal.SizeOf(RR_LateralSlipSpeed)];
            RR_RadiansTireMoved = RR_TireData[(OffsetRadiansTireMoved - OffsetTireDataStart) / Marshal.SizeOf(RR_RadiansTireMoved)];
            //??
            RR_CurrentContactBrakeTorque = RR_TireData[(OffsetCurrentContactBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(RR_CurrentContactBrakeTorque)];
            RR_CurrentContactHandBrakeTorque = RR_TireData[(OffsetCurrentContactHandBrakeTorque - OffsetTireDataStart) / Marshal.SizeOf(RR_CurrentContactHandBrakeTorque)];
            RR_CurrentContactBrakeTorqueMax = RR_TireData[(OffsetCurrentContactBrakeTorqueMax - OffsetTireDataStart) / Marshal.SizeOf(RR_CurrentContactBrakeTorqueMax)];
            RR_VerticalLoad = RR_TireData[(OffsetVerticalLoad - OffsetTireDataStart) / Marshal.SizeOf(RR_VerticalLoad)];
            //RR_VerticalLoadSomeOther = RR_TireData[(OffsetVerticalLoadSomeOther - OffsetTireDataStart) / Marshal.SizeOf(RR_VerticalLoadSomeOther)];
            //??
            //??
            //??
            //??
            //??
            RR_TireX = RR_TireData[(OffsetTireX - OffsetTireDataStart) / Marshal.SizeOf(RR_TireX)];
            RR_TireY = RR_TireData[(OffsetTireY - OffsetTireDataStart) / Marshal.SizeOf(RR_TireY)];
            RR_TireZ = RR_TireData[(OffsetTireZ - OffsetTireDataStart) / Marshal.SizeOf(RR_TireZ)];
            RR_LateralLoad = RR_TireData[(OffsetLateralLoad - OffsetTireDataStart) / Marshal.SizeOf(RR_LateralLoad)];
            //??
            RR_LongitudinalLoad = RR_TireData[(OffsetLongitudinalLoad - OffsetTireDataStart) / Marshal.SizeOf(RR_LongitudinalLoad)];
            //??
            //??
            //Rolling Resistance/SAT?
            //Rolling Resistance/SAT?
            //SAT?
            //SAT?
            //RR_SlipAngleRadALMOST = RR_TireData[(OffsetSlipAngleRadALMOST - OffsetTireDataStart) / Marshal.SizeOf(RR_SlipAngleRadALMOST)];
            RR_SlipAngleRad = RR_TireData[(OffsetSlipAngleRad - OffsetTireDataStart) / Marshal.SizeOf(RR_SlipAngleRad)];
            RR_SlipRatio = RR_TireData[(OffsetSlipRatio - OffsetTireDataStart) / Marshal.SizeOf(RR_SlipRatio)];
            RR_LateralResistance = RR_TireData[(OffsetLateralResistance - OffsetTireDataStart) / Marshal.SizeOf(RR_LateralResistance)];
            RR_LongitudinalResistance = RR_TireData[(OffsetLongitudinalResistance - OffsetTireDataStart) / Marshal.SizeOf(RR_LongitudinalResistance)];
            //??
            //??
            //??
            //Slip Ratio Again??
            //??
            //??
            //??
            RR_ContactLength = RR_TireData[(OffsetContactLength - OffsetTireDataStart) / Marshal.SizeOf(RR_ContactLength)];
            RR_TravelSpeed = RR_TireData[(OffsetTravelSpeed - OffsetTireDataStart) / Marshal.SizeOf(RR_TravelSpeed)];
            //?? 15 stuff of unknown
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??
            //??

            // These two just happen to be in the same offset, so they use the old method.
            RR_SuspensionLength = GetData<float>(memoryHelper, baseAddr, RR_SuspensionLengthOffsets);
            RR_SuspensionVelocity = GetData<float>(memoryHelper, baseAddr, RR_SuspensionVelocityOffsets);

            TransformMatrixRR = new Matrix4x4(RR_TireM11, RR_TireM12, RR_TireM13, RR_TireM14, RR_TireM21, RR_TireM22, RR_TireM23, RR_TireM24, RR_TireM31, RR_TireM32, RR_TireM33, RR_TireM34, RR_TireM41, RR_TireM42, RR_TireM43, RR_TireM44);
            CalcAngles(TransformMatrixRR);// Needed?
            pitchRR = -CalcAngles(TransformMatrixRR).X;// caster not really
            yawRR = -CalcAngles(TransformMatrixRR).Y;// toe close
            rollRR = LoopAngleRad(-(float)CalcAngles(TransformMatrixRR).Z, (float)Math.PI * 0.5f);// camber close

            RR_LateralFriction = GetLateralFriction(RR_LateralLoad, RR_VerticalLoad);
            RR_LongitudinalFriction = GetLongitudinalFriction(RR_LongitudinalLoad, RR_VerticalLoad);
            RR_TotalFriction = GetTotalFriction(RR_LateralFriction, RR_LongitudinalFriction);
            RR_TotalFrictionAngle = GetTotalFrictionAngle(RR_LateralFriction, RR_LongitudinalFriction);
            RR_SlipAngleDeg = RadToDeg(RR_SlipAngleRad);
            //RR_CamberAngleDeg = RadToDeg(RR_CamberAngleRad);
            //RR_SteerAngleDeg = RadToDeg(RR_SteerAngleRad);
            RR_CasterAngleDeg = RadToDeg(pitchRR);// RadToDeg(RR_TireM11);
            RR_CamberAngleDeg = RadToDeg(yawRR);// RadToDeg(RR_TireM12);
            RR_SteerAngleDeg = RadToDeg(rollRR);// RadToDeg(RR_TireM13);
        }
        private static float GetLateralFriction(float latLoad, float vertLoad)
        {
            if (vertLoad != 0)
            {
                return latLoad / vertLoad;
            }
            else { return 0; }
        }
        private static float GetLongitudinalFriction(float lonLoad, float vertLoad)
        {
            if (vertLoad != 0)
            {
                return lonLoad / vertLoad;
            }
            else { return 0; }
        }
        private static float GetTotalFriction(float latFriction, float lonFriction)
        {
            return (float)Math.Sqrt(Math.Pow(latFriction, 2) + Math.Pow(lonFriction, 2));
        }
        private static float GetTotalFrictionAngle(float latFriction, float lonFriction)
        {
            if (latFriction > 0)
            {
                if (lonFriction > 0)
                {
                    return (float)(90 - (Math.Atan(lonFriction / latFriction) * fRadToDeg));
                }
                else if (lonFriction < 0)
                {
                    return (float)(90 - (Math.Atan(lonFriction / latFriction) * fRadToDeg));
                }
                else
                {
                    return 90;
                }
            }
            else if (latFriction < 0)
            {
                if (lonFriction > 0)
                {
                    return (float)(270 + (Math.Atan(lonFriction / Math.Abs(latFriction)) * fRadToDeg));
                }
                else if (lonFriction < 0)
                {
                    return (float)(270 - (Math.Atan(lonFriction / latFriction) * fRadToDeg));
                }
                else
                {
                    return 270;
                }
            }
            else
            {
                if (lonFriction > 0)
                {
                    return 360;
                }
                else if (lonFriction < 0)
                {
                    return 180;
                }
                else
                {
                    return 0;
                }
            }
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
        private static void FilterCheckAndLog(string tireFileName, float slipRatio, float slipAngleDeg, float travelSpeed, float verticalLoad)
        {
            if (LogSettings.FiltersOn == true)
            {
                if ((slipRatio <= (0 + LogSettings.Z1) && slipRatio >= (0 - LogSettings.Z1))
                        && (slipAngleDeg <= (0 + LogSettings.Z2) && slipAngleDeg >= (0 - LogSettings.Z2))
                        && (travelSpeed >= (0 + LogSettings.Z3) || travelSpeed <= (0 - LogSettings.Z3))
                        && (verticalLoad <= (LogSettings.W4 + LogSettings.Z4) && verticalLoad >= (LogSettings.W4 - LogSettings.Z4)))
                {
                    LogFileWriter(LogSettings.LogFileSaveLocationFolder, tireFileName, LogSettings.SaveFileName, LogSettings.Extension);
                }
                else
                {
                    LogFileWriter(LogSettings.LogFileSaveLocationFolder, tireFileName, LogSettings.SaveFileName, LogSettings.Extension);
                }
            }
        }
        private static void LogToFile()
        {
            CheckWhatToLogInFile(LogSettings.Delimiter);

            if (logging == true)
            {
                // SA, SR, Speed and Vertical Load filters for logging
                FilterCheckAndLog(LogSettings.FileNameFLTire, FL_SlipRatio, FL_SlipAngleDeg, FL_TravelSpeed, FL_VerticalLoad);
                FilterCheckAndLog(LogSettings.FileNameFRTire, FR_SlipRatio, FR_SlipAngleDeg, FR_TravelSpeed, FR_VerticalLoad);
                FilterCheckAndLog(LogSettings.FileNameRLTire, RL_SlipRatio, RL_SlipAngleDeg, RL_TravelSpeed, RL_VerticalLoad);
                FilterCheckAndLog(LogSettings.FileNameRRTire, RR_SlipRatio, RR_SlipAngleDeg, RR_TravelSpeed, RR_VerticalLoad);
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
            else if (chooseTire == "FrontRight" && LogSettings.TireTravelSpeedLogEnabled == true)
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
    }
}