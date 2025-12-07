using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    public enum WF_PrefixMain : int// don't add anything in the first 4 zeroes. So everyone of these end with 00000, to support Prefix+ValueName ID calculation.
    {
        Body = 0,
        FL = 100000000,
        FR = 200000000,
        RL = 300000000,
        RR = 400000000,
        Powertrain = 500000000,
    }
    public enum WF_PrefixSecondary : int
    {
        None,
        Aero,
        Tires,
        Suspension,
        Engine,
        Differential,
        Transmission,
    }
    public enum AllValueNames : int
    {
        None = 0,

        RaceTime,

        /// <summary>
        /// Body rotation
        /// </summary>
        BodyM11,
        BodyM12,
        BodyM13,
        BodyM14,
        BodyM21,
        BodyM22,
        BodyM23,
        BodyM24,
        BodyM31,
        BodyM32,
        BodyM33,
        BodyM34,
        BodyM41,
        BodyM42,
        BodyM43,
        BodyM44,

        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        PitchRad,
        PitchDeg,
        YawRad,
        YawDeg,
        RollRad,
        RollDeg,

        /// <summary>
        /// Body accel etc.
        /// </summary>
        XAccelerationWorld,
        YAccelerationWorld,
        ZAccelerationWorld,

        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        Body_XAccelerationLocal,
        Body_YAccelerationLocal,
        Body_ZAccelerationLocal,
        Body_XZAccelerationAngleRad,
        Body_XZAccelerationAngleDeg,
        Body_XZAcceleration,
        Body_XYZAcceleration,
        Body_XG,
        Body_YG,
        Body_ZG,
        Body_XZG,
        Body_XYZG,
        Body_XZGAngleRad,
        Body_XZGAngleDeg,

        /// <summary>
        /// Tire & suspension stuff
        /// </summary>

        MomentOfInertia,// Tire static per part values
        AngularVelocity,

        TireMass,// Tire static per part value
        TireRadius,// Tire static per part value
        TireWidth,// Tire static per part value
        TireSpringRate,// Tire static per part value
        TireDamperRate,// Tire static per part value
        TireMaxDeflection,// Tire static per part value
        ThermalAirTransfer,// Tire static per part value
        ThermalInnerTransfer,// Tire static per part value
        TreadTemperature,
        InnerTemperature,
        VerticalDeflection,
        LoadedRadius,
        EffectiveRadius,
        LongitudinalSlipSpeed,
        LateralSlipSpeed,
        RadiansTireMoved,
        CurrentContactBrakeTorque,
        CurrentContactHandBrakeTorque,
        CurrentContactBrakeTorqueMax,
        VerticalLoad,

        TireX,
        TireY,
        TireZ,

        LateralLoad,
        LongitudinalLoad,
        SlipAngleRad,
        SlipRatio,
        LateralResistance,
        LongitudinalResistance,

        TirePivotX,
        TirePivotY,
        TirePivotZ,
        TireM11,
        TireM12,
        TireM13,
        TireM14,
        TireM21,
        TireM22,
        TireM23,
        TireM24,
        TireM31,
        TireM32,
        TireM33,
        TireM34,
        TireM41,
        TireM42,
        TireM43,
        TireM44,

        ContactLength,
        TravelSpeed,


        /// <summary>
        /// These are not read from memory, but calculations based on values from above raw values.
        /// </summary>
        CasterAngleRad,
        CasterAngleDeg,
        CamberAngleRad,
        CamberAngleDeg,
        SteerAngleRad,
        SteerAngleDeg,

        LateralFriction,
        LongitudinalFriction,
        TotalFriction,
        TotalFrictionAngleDeg,

        SlipAngleDeg,

        TirePitchRad,
        TirePitchDeg,
        TireYawRad,
        TireYawDeg,
        TireRollRad,
        TireRollDeg,

        /// <summary>
        /// Suspension static per part values
        /// </summary>
        SpringRate,
        ProgresiveRate,
        BumbLimitsX,
        BumpLimitsY,
        ReboundLimitsX,
        ReboundLimitsY,
        BumpDampX,
        ReboundDampX,
        BumpDampY,
        ReboundDampY,
        ExpandLimitFromZero,
        CompressionLimitFromZero,
        RideHeight_BumpStopDown_ReboundLength,
        SuspensionLength,
        SuspensionVelocity,
        BumpStopLength,
        RideHeight_BumpStopDown,
        BumpStopRate,
        ReboundRate,
        BumpStopDamp,
        BumpStopRateGainDeflectionSquared,
        BumpStopDampGainDeflectionSquared,
    }
    public enum TireValueName : int
    {
        MomentOfInertia,// Tire static per part values
        AngularVelocity,

        Mass,// Tire static per part value
        Radius,// Tire static per part value
        Width,// Tire static per part value
        TireSpringRate,// Tire static per part value
        TireDamperRate,// Tire static per part value
        MaxDeflection,// Tire static per part value
        ThermalAirTransfer,// Tire static per part value
        ThermalInnerTransfer,// Tire static per part value
        TreadTemperature,
        InnerTemperature,
        VerticalDeflection,
        LoadedRadius,
        EffectiveRadius,
        LongitudinalSlipSpeed,
        LateralSlipSpeed,
        RadiansTireMoved,
        CurrentContactBrakeTorque,
        CurrentContactHandBrakeTorque,
        CurrentContactBrakeTorqueMax,
        VerticalLoad,

        X,
        Y,
        Z,

        LateralLoad,
        LongitudinalLoad,
        SlipAngleRad,
        SlipRatio,
        LateralResistance,
        LongitudinalResistance,

        PivotX,
        PivotY,
        PivotZ,
        TireM11,
        TireM12,
        TireM13,
        TireM14,
        TireM21,
        TireM22,
        TireM23,
        TireM24,
        TireM31,
        TireM32,
        TireM33,
        TireM34,
        TireM41,
        TireM42,
        TireM43,
        TireM44,

        ContactLength,
        TravelSpeed,

        /// <summary>
        /// These are not read from memory, but calculations based on values from above raw values.
        /// </summary>
        CasterAngleRad,
        CasterAngleDeg,
        CamberAngleRad,
        CamberAngleDeg,
        SteerAngleRad,
        SteerAngleDeg,

        LateralFriction,
        LongitudinalFriction,
        TotalFriction,
        TotalFrictionAngleDeg,

        SlipAngleDeg,
    }
    public enum SuspensionValueName
    {
        SpringRate,
        ProgresiveRate,
        BumbLimitsX,
        BumpLimitsY,
        ReboundLimitsX,
        ReboundLimitsY,
        BumpDampX,
        ReboundDampX,
        BumpDampY,
        ReboundDampY,
        ExpandLimitFromZero,
        CompressionLimitFromZero,
        RideHeight_BumpStopDown_ReboundLength,
        SuspensionLength,
        SuspensionVelocity,
        BumpStopLength,
        RideHeight_BumpStop_Down,
        BumpStopRate,
        ReboundRate,
        BumpStopDamp,
        BumpStopRateGainDeflectionSquared,
        BumpStopDampGainDeflectionSquared,
    }
    public enum CalculatedTireValueName
    {
        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        CasterAngleRad,
        CasterAngleDeg,
        CamberAngleRad,
        CamberAngleDeg,
        SteerAngleRad,
        SteerAngleDeg,

        LateralFriction,
        LongitudinalFriction,
        TotalFriction,
        TotalFrictionAngleDeg,

        SlipAngleDeg,
    }
    public enum BaseAddress : ulong
    {
        Tire = 0x18324C8,
        Suspension = Tire,
        Aero = Tire,
        Differential = Tire,
        BodyLocationHeading = Tire,
        Engine = 0x18327C8,
        Speed = Engine,
        RaceTime = 0x1832648,
        Acceleration = 0x1832B88,
        SuspensionGeometry = 0x184B118,
    }
    public enum BaseAddressUpdate : long
    {
        V1_285308 = 0x0,
        V1_308408 = 0x9E00,

        //Every update offsets the base address of the memory points. 99% of the time forwards.
        //-0x6DF8D8; //was some very old?
        //0x0;// April 2022 version 1.285308
        //0x4650;// May 2022
        //0x5710// October 2022
        // 0x67A0 November 2022 1838680 vs 1831EE0
        // 0x7DF0 April 2023
        // 0x9E00; March 2024 { get; set; } = 7DF0+2010 { get; set; } = 9E00
    }
    public enum WF_TireDataChunks : int
    {
        DataStart = WF_TireDataOffset.MomentOfInertia,//
        Offset1 = 0xE78,
        ChunkSize = 0xC4C,
    }
    public enum WF_TireSide : int
    {
        FL = 0x0,
        FR = 0xC50,//Next tire offset from FL
        RL = FR + FR,//Next tire offset from FL
        RR = FR + FR + FR,//Next tire offset from FL
    }
    public enum WF_TireDataOffset : int
    {
        MomentOfInertia = 0x28,
        AngularVelocity = 0x2C,

        TirePivotX = 0x380,
        TirePivotY = 0x384,
        TirePivotZ = 0x388,
        TireM11 = 0x390,
        TireM12 = 0x394,
        TireM13 = 0x398,
        TireM14 = 0x39C,
        TireM21 = 0x3A0,
        TireM22 = 0x3A4,
        TireM23 = 0x3A8,
        TireM24 = 0x3AC,
        TireM31 = 0x3B0,
        TireM32 = 0x3B4,
        TireM33 = 0x3B8,
        TireM34 = 0x3BC,
        TireM41 = 0x3C0,
        TireM42 = 0x3C4,
        TireM43 = 0x3C8,
        TireM44 = 0x3CC,

        //CamberAngleRad = 0x394,
        //TireSteerAngleRad = 0x398,
        TireMass = 0x410,
        TireRadius = 0x414,
        TireWidth = 0x418,
        TireSpringRate = 0x41C,
        TireDamperRate = 0x420,
        TireMaxDeflection = 0x424,
        ThermalAirTransfer = 0x428,
        ThermalInnerTransfer = 0x42C,
        TreadTemperature = 0x434,
        InnerTemperature = 0x438,
        VerticalDeflection = 0x43C,
        LoadedRadius = 0x44C,
        EffectiveRadius = 0x450,
        LongitudinalSlipSpeed = 0x454,
        LateralSlipSpeed = 0x458,
        RadiansTireMoved = 0x45C,//Not angular but compared to the contact surface.

        CurrentContactBrakeTorque = 0x484,
        CurrentContactHandBrakeTorque = 0x484,
        CurrentContactBrakeTorqueMax = 0x48C,
        VerticalLoad = 0x490,

        TireX = 0x4AC,
        TireY = 0x4B0,
        TireZ = 0x4B4,

        LateralLoad = 0x4B8,
        LongitudinalLoad = 0x4C0,

        SlipAngleRad = 0xBF0,
        SlipRatio = 0xBF4,
        LateralResistance = 0xBF8,
        LongitudinalResistance = 0xBFC,

        ContactLength = 0xC1C,
        TravelSpeed = 0xC20,
        
        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        CasterAngleRad = WF_TireDataChunks.DataStart + WF_TireDataChunks.ChunkSize,
        CasterAngleDeg = CasterAngleRad + 0x4,
        CamberAngleRad = CasterAngleDeg + 0x4,
        CamberAngleDeg = CamberAngleRad + 0x4,
        SteerAngleRad = CamberAngleDeg + 0x4,
        SteerAngleDeg = SteerAngleRad + 0x4,

        LateralFriction = SteerAngleDeg + 0x4,
        LongitudinalFriction = LateralFriction + 0x4,
        TotalFriction = LongitudinalFriction + 0x4,
        TotalFrictionAngleDeg = TotalFriction + 0x4,

        SlipAngleDeg = TotalFrictionAngleDeg + 0x4,
    }
    public enum WF_SuspensionDataChunks : int
    {
        DataStart = WF_SuspensionDataOffset.SpringRate,
        ChunkSize = 0x58,
    }
    public enum WF_SuspensionSideOffset : int
    {
        FL = 0x0,
        FR = 0x60,//Next tire offset from FL
        RL = FR + FR,//Next tire offset from FL
        RR = FR + FR + FR,//Next tire offset from FL
    }
    public enum WF_SuspensionDataOffset : int
    {
        SpringRate = 0xE80,//0
        ProgressiveRate = 0xE84,//1
        BumpLimitsX = 0xE88,//2
        BumpLimitsY = 0xE8C,//3
        ReboundLimitsX = 0xE90,//4
        ReboundLimitsY = 0xE94,//5
        BumpDampX = 0xE98,//6
        ReboundDampX = 0xE9C,//7
        BumpDampY = 0xEA0,//8
        ReboundDampY = 0xEA4,//9
        ExpansionLimitFromZero = 0xEA8,//10
        CompressionLimitFromZero = 0xEAC,//11
        ReboundEndPosition = 0xEB0,//12 RideHeight + BumpStopDown + ReboundLength
        SuspensionLength = 0xEB4,//13
        SuspensionVelocity = 0xEB8,//14
        BumpStopLength = 0xEBC,//15
        ReboundStartPosition = 0xEC0,//16 RideHeight + BumpStopDown
        BumpStopRate = 0xEC4,//17
        ReboundRate = 0xEC8,//18
        BumpStopDamp = 0xECC,//19
        BumpStopRateGainDeflectionSquared = 0xED0,//21
        BumpStopDampGainDeflectionSquared = 0xED4,//22
    }
    public enum WF_SuspensionGeometryDataChunks : int
    {
        DataStart = WF_SuspensionGeometryDataOffset.UpperFrontArmSpindleX,
        ChunkSize = 0x43C,//Need more cheking. Too much empty stuff here likely
    }
    public enum WF_SuspensionGeometrySideOffsets : int
    {
        FL = 0x0,
        RL = FL + 0x55DC0,
        FR = 0x0 + 0x2AAEE0,
        RR = FR + 0x55DC0,
    }
    public enum WF_SuspensionGeometryDataOffset : int
    {
        //XYZW coordinates
        //Upper Front Arm
        UpperFrontArmSpindleX = 0x12A0,
        UpperFrontArmSpindleY = UpperFrontArmSpindleX + 0x4,
        UpperFrontArmSpindleZ = UpperFrontArmSpindleY + 0x4,
        UpperFrontArmSpindleW = UpperFrontArmSpindleZ + 0x4,

        UpperFrontArmBodyX = UpperFrontArmSpindleW + 0x4,
        UpperFrontArmBodyY = UpperFrontArmBodyX + 0x4,
        UpperFrontArmBodyZ = UpperFrontArmBodyY + 0x4,
        UpperFrontArmBodyW = UpperFrontArmBodyZ + 0x4,

        UpperFrontArmUnknownX = UpperFrontArmBodyW + 0x4,
        UpperFrontArmUnknownY = UpperFrontArmUnknownX + 0x4,
        UpperFrontArmUnknownZ = UpperFrontArmUnknownY + 0x4,
        UpperFrontArmUnknownW = UpperFrontArmUnknownZ + 0x4, 


        UpperRearArmSpindleX = 0x1340,
        UpperRearArmSpindleY = UpperRearArmSpindleX + 0x4,
        UpperRearArmSpindleZ = UpperRearArmSpindleY + 0x4,
        UpperRearArmSpindleW = UpperRearArmSpindleZ + 0x4,

        UpperRearArmBodyX = UpperRearArmSpindleW + 0x4,
        UpperRearArmBodyY = UpperRearArmBodyX + 0x4,
        UpperRearArmBodyZ = UpperRearArmBodyY + 0x4,
        UpperRearArmBodyW = UpperRearArmBodyZ + 0x4,

        UpperRearArmUnknownX = UpperRearArmBodyW + 0x4,
        UpperRearArmUnknownY = UpperRearArmUnknownX + 0x4,
        UpperRearArmUnknownZ = UpperRearArmUnknownY + 0x4,
        UpperRearArmUnknownW = UpperRearArmUnknownZ + 0x4,

        //Lower Front Arm
        LowerFrontArmSpindleX = 0x13E0,
        LowerFrontArmSpindleY = LowerFrontArmSpindleX + 0x4,
        LowerFrontArmSpindleZ = LowerFrontArmSpindleY + 0x4,
        LowerFrontArmSpindleW = LowerFrontArmSpindleZ + 0x4,

        LowerFrontArmBodyX = LowerFrontArmSpindleW + 0x4,
        LowerFrontArmBodyY = LowerFrontArmBodyX + 0x4,
        LowerFrontArmBodyZ = LowerFrontArmBodyY + 0x4,
        LowerFrontArmBodyW = LowerFrontArmBodyZ + 0x4,

        LowerFrontArmUnknownX = LowerFrontArmBodyW + 0x4,
        LowerFrontArmUnknownY = LowerFrontArmUnknownX + 0x4,
        LowerFrontArmUnknownZ = LowerFrontArmUnknownY + 0x4,
        LowerFrontArmUnknownW = LowerFrontArmUnknownZ + 0x4,


        LowerRearArmSpindleX = 0x1480,
        LowerRearArmSpindleY = LowerRearArmSpindleX + 0x4,
        LowerRearArmSpindleZ = LowerRearArmSpindleY + 0x4,
        LowerRearArmSpindleW = LowerRearArmSpindleZ + 0x4,

        LowerRearArmBodyX = LowerRearArmSpindleW + 0x4,
        LowerRearArmBodyY = LowerRearArmBodyX + 0x4,
        LowerRearArmBodyZ = LowerRearArmBodyY + 0x4,
        LowerRearArmBodyW = LowerRearArmBodyZ + 0x4,

        LowerRearArmUnknownX = LowerRearArmBodyW + 0x4,
        LowerRearArmUnknownY = LowerRearArmUnknownX + 0x4,
        LowerRearArmUnknownZ = LowerRearArmUnknownY + 0x4,
        LowerRearArmUnknownW = LowerRearArmUnknownZ + 0x4,

        //Steering Rod
        SteeringRodSpindleX = 0x1520,
        SteeringRodSpindleY = SteeringRodSpindleX + 0x4,
        SteeringRodSpindleZ = SteeringRodSpindleY + 0x4,
        SteeringRodSpindleW = SteeringRodSpindleZ + 0x4,

        SteeringRodBodyX = SteeringRodSpindleW + 0x4,
        SteeringRodBodyY = SteeringRodBodyX + 0x4,
        SteeringRodBodyZ = SteeringRodBodyY + 0x4,
        SteeringRodBodyW = SteeringRodBodyZ + 0x4,

        SteeringRodUnknownX = SteeringRodBodyW + 0x4,
        SteeringRodUnknownY = SteeringRodUnknownX + 0x4,
        SteeringRodUnknownZ = SteeringRodUnknownY + 0x4,
        SteeringRodUnknownW = SteeringRodUnknownZ + 0x4,

        //XYZ Coordinates
        //Upper Front Arm
        XYZUpperFrontArmSpindleX = 0x1550,
        XYZUpperFrontArmSpindleY = XYZUpperFrontArmSpindleX + 0x4,
        XYZUpperFrontArmSpindleZ = XYZUpperFrontArmSpindleY + 0x4,

        XYZUpperFrontArmBodyX = XYZUpperFrontArmSpindleZ + 0x4,
        XYZUpperFrontArmBodyY = XYZUpperFrontArmBodyX + 0x4,
        XYZUpperFrontArmBodyZ = XYZUpperFrontArmBodyY + 0x4,

        XYZUpperRearArmSpindleX = XYZUpperFrontArmBodyZ + 0x4,
        XYZUpperRearArmSpindleY = XYZUpperRearArmSpindleX + 0x4,
        XYZUpperRearArmSpindleZ = XYZUpperRearArmSpindleY + 0x4,

        XYZUpperRearArmBodyX = XYZUpperRearArmSpindleZ + 0x4,
        XYZUpperRearArmBodyY = XYZUpperRearArmBodyX + 0x4,
        XYZUpperRearArmBodyZ = XYZUpperRearArmBodyY + 0x4,

        //Lower Front Arm
        XYZLowerFrontArmSpindleX = XYZUpperRearArmBodyZ + 0x4,
        XYZLowerFrontArmSpindleY = XYZLowerFrontArmSpindleX + 0x4,
        XYZLowerFrontArmSpindleZ = XYZLowerFrontArmSpindleY + 0x4,

        XYZLowerFrontArmBodyX = XYZLowerFrontArmSpindleZ + 0x4,
        XYZLowerFrontArmBodyY = XYZLowerFrontArmBodyX + 0x4,
        XYZLowerFrontArmBodyZ = XYZLowerFrontArmBodyY + 0x4,

        XYZLowerRearArmSpindleX = XYZLowerFrontArmBodyZ,
        XYZLowerRearArmSpindleY = XYZLowerRearArmSpindleX + 0x4,
        XYZLowerRearArmSpindleZ = XYZLowerRearArmSpindleY + 0x4,

        XYZLowerRearArmBodyX = XYZLowerRearArmSpindleZ + 0x4,
        XYZLowerRearArmBodyY = XYZLowerRearArmBodyX + 0x4,
        XYZLowerRearArmBodyZ = XYZLowerRearArmBodyY + 0x4,

        //Steering Rod
        XYZSteeringRodSpindleX = XYZLowerRearArmBodyZ + 0x4,
        XYZSteeringRodSpindleY = XYZSteeringRodSpindleX + 0x4,
        XYZSteeringRodSpindleZ = XYZSteeringRodSpindleY + 0x4,

        XYZSteeringRodBodyX = XYZSteeringRodSpindleZ + 0x4,
        XYZSteeringRodBodyY = XYZSteeringRodBodyX + 0x4,
        XYZSteeringRodBodyZ = XYZSteeringRodBodyY + 0x4,

        XYZSteeringRodUnknownX = XYZSteeringRodBodyZ + 0x4,
        XYZSteeringRodUnknownY = XYZSteeringRodUnknownX + 0x4,
        XYZSteeringRodUnknownZ = XYZSteeringRodUnknownY + 0x4,
        XYZSteeringRodUnknownW = XYZSteeringRodUnknownZ + 0x4,

        //XYZW coordinates
        //Push Rod
        PushRodSpindleX = 0x1640,
        PushRodSpindleY = PushRodSpindleX + 0x4,
        PushRodSpindleZ = PushRodSpindleY + 0x4,
        PushRodSpindleW = PushRodSpindleZ + 0x4,

        PushRodBodyX = PushRodSpindleW + 0x4,
        PushRodBodyY = PushRodBodyX + 0x4,
        PushRodBodyZ = PushRodBodyY + 0x4,
        PushRodBodyW = PushRodBodyZ + 0x4,

        PushRodUnkown1 = PushRodBodyW + 0x4,
        PushRodUnkown2 = PushRodUnkown1 + 0x4,
        PushRodUnkown3 = PushRodUnkown2 + 0x4,
        PushRodUnkown4 = PushRodUnkown3 + 0x4,
        PushRodUnkown5 = PushRodUnkown4 + 0x4,
        PushRodUnkown6 = PushRodUnkown5 + 0x4,
        PushRodUnkown7 = PushRodUnkown6 + 0x4,
        //XYZ Coordinates
        XYZPushRodSpindleX = PushRodUnkown7 + 0x4,
        XYZPushRodSpindleY = XYZPushRodSpindleX + 0x4,
        XYZPushRodSpindleZ = XYZPushRodSpindleY + 0x4,

        XYZPushRodBodyX = XYZPushRodSpindleZ + 0x4,
        XYZPushRodBodyY = XYZPushRodBodyX + 0x4,
        XYZPushRodBodyZ = XYZPushRodBodyY + 0x4,

        XYZPushRodUnkown1 = XYZPushRodBodyZ + 0x4,
        XYZPushRodUnkown2 = XYZPushRodUnkown1 + 0x4,
        XYZPushRodUnkown3 = XYZPushRodUnkown2 + 0x4,
        XYZPushRodUnkown4 = XYZPushRodUnkown3 + 0x4,
        XYZPushRodUnkown5 = XYZPushRodUnkown4 + 0x4,
        XYZPushRodUnkown6 = XYZPushRodUnkown5 + 0x4,
        XYZPushRodUnkown7 = XYZPushRodUnkown6 + 0x4,
        XYZPushRodUnkown8 = XYZPushRodUnkown7 + 0x4,
        XYZPushRodUnkown9 = XYZPushRodUnkown8 + 0x4,
        XYZPushRodUnkown10 = XYZPushRodUnkown9 + 0x4,
        XYZPushRodUnkown11 = XYZPushRodUnkown10 + 0x4,
        XYZPushRodUnkown12 = XYZPushRodUnkown11 + 0x4,
        XYZPushRodUnkown13 = XYZPushRodUnkown12 + 0x4,
        XYZPushRodUnkown14 = XYZPushRodUnkown13 + 0x4,
        XYZPushRodUnkown15 = XYZPushRodUnkown14 + 0x4,
        XYZPushRodUnkown16 = XYZPushRodUnkown15 + 0x4,
        XYZPushRodUnkown17 = XYZPushRodUnkown16 + 0x4,
        XYZPushRodUnkown18 = XYZPushRodUnkown17 + 0x4,
    }
    public enum WF_BodyAccelDataChunks : int
    {
        DataStart = 0x0,
        ChunkSize = 0x54,
    }
    public enum WF_BodyAccelSide : int
    {
        AllSides = 0x0,
    }
    public enum WF_BodyAccelDataOffset : int
    {
        XAccelerationWorld = 0x48,
        YAccelerationWorld = 0x4C,
        ZAccelerationWorld = 0x50,

        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        XAccelerationLocal = WF_BodyAccelDataOffset.ZAccelerationWorld + 0x4,
        YAccelerationLocal = XAccelerationLocal + 0x4,
        Body_ZAccelerationLocal = YAccelerationLocal + 0x4,

        XZAccelerationAngleRad = Body_ZAccelerationLocal + 0x4,
        XZAccelerationAngleDeg = XZAccelerationAngleRad + 0x4,
        XZAcceleration = XZAccelerationAngleDeg + 0x4,
        XYZAcceleration = XZAcceleration + 0x4,
        XG = XYZAcceleration + 0x4,
        YG = XG + 0x4,
        ZG = YG + 0x4,
        XZG = ZG + 0x4,
        XYZG = XZG + 0x4,
        XZGAngleRad = XYZG + 0x4,
        Body_XZGAngleDeg = XZGAngleRad + 0x4,
    }
    public enum WF_BodyRotationChunks : int
    {
        DataStart = WF_BodyRotationDataOffset.BodyM11,
        Offset1 = 0x970,
        ChunkSize = 0x40,
    }
    public enum WF_BodyRotationSide : int
    {
        AllSides = 0x0,
    }
    public enum WF_BodyRotationDataOffset : int
    {
        BodyM11 = 0x0,
        BodyM12 = 0x4,
        BodyM13 = 0x8,
        BodyM14 = 0xC,
        BodyM21 = 0x10,
        BodyM22 = 0x14,
        BodyM23 = 0x18,
        BodyM24 = 0x1C,
        BodyM31 = 0x20,
        BodyM32 = 0x24,
        BodyM33 = 0x28,
        BodyM34 = 0x2C,
        BodyM41 = 0x30,
        BodyM42 = 0x34,
        BodyM43 = 0x38,
        BodyM44 = 0x3C,

        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        PitchRad = WF_BodyRotationDataOffset.BodyM44 + 0x4,
        PitchDeg = PitchRad + 0x4,
        YawRad = PitchDeg + 0x4,
        YawDeg = YawRad + 0x4,
        RollRad = YawDeg + 0x4,
        RollDeg = RollRad + 0x4,
    }
    public enum WF_AeroDataChunks : int
    {
        DataStart = WF_AeroDataOffset.XDragWorld,
        ChunkSize = 0x14,
    }
    public enum WF_AeroSide : int
    {
        AllSides = 0x0,
    }
    public enum WF_AeroDataOffset : int
    {
        XDragWorld = 0xAACF20,
        YDragWorld = 0xAACF24,
        ZDragWorld = 0xAACF28,
        FrontLift = 0xAACF2C,
        RearLift = 0xAACF30,

        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        XDragLocal = WF_AeroDataOffset.RearLift + 0x4,
        YDragLocal = XDragLocal + 0x4,
        ZDragLocal = YDragLocal + 0x4,
    }
    public enum WF_EngineDataChunks : int
    {
        DataStart = 0x0,
        ChunkSize = 0x74
    }
    public enum WF_EngineSide : int
    {
        AllSides = 0x0,
    }
    public enum WF_EngineDataOffset : int
    {
        EngineRPM = 0x38,
        EngineRPMAxle = 0x3C,
        EngineTorqueNm = 0x44,
        Speed = 0x70,

        /// <summary>
        /// These are not read from memory, but calculations based on values from memory.
        /// </summary>
        EngineTorqueLbFt = Speed + 0x4,
        EnginePowerKW = EngineTorqueLbFt + 0x4,
        EnginePowerHP = EnginePowerKW + 0x4,
        EnginePowerPS = EnginePowerHP + 0x4,
        EnginePowerBHP = EnginePowerPS + 0x4,
    }
    public enum WF_DifferentialDataChunks : int
    {
        DataStart = WF_DifferentialDataOffset.DifferentialOpenPrimaryLeft,
        ChunkSize = 0x6C
    }
    public enum WF_DifferentialSide : int
    {
        Left = 0x0,
        Right = 0x60,
    }
    public enum WF_DifferentialDataOffset : int
    {
        DifferentialOpenPrimaryLeft = 0xD94,// !=0 means differential is locked. ==0 means it's open
        DifferentialVelocityRadPrimaryLeft = 0xD98,
        DifferentialTorquePrimaryLeft = 0xD9C,

        DifferentialOpenPrimaryRight = DifferentialOpenPrimaryLeft + WF_DifferentialSide.Right,// !=0 means differential is locked. ==0 means it's open
        DifferentialVelocityRadPrimaryRight = DifferentialVelocityRadPrimaryLeft + WF_DifferentialSide.Right,
        DifferentialTorquePrimaryRight = DifferentialTorquePrimaryLeft + WF_DifferentialSide.Right,
    }
    public enum WF_TimeDataOffset : int
    {
        RaceTime = 0x14,
    }
    public class WreckfestEnums
    {
        public static List<string> AllValueNames = new List<string>();
        public static void AddNames()
        {
            foreach (string names in Enum.GetNames(typeof(AllValueNames)))
            {
                AllValueNames.Add(names);
            }
        }

        public static List<string> DataNameStringsAbsoluteValues { get; set; } = new List<string>
            (
                new string[]
                {
                    nameof(Physics_Data_Debug.AllValueNames.None),// "None",
                    nameof(Physics_Data_Debug.AllValueNames.TravelSpeed),// "Tire Travel Speed",
                    nameof(Physics_Data_Debug.AllValueNames.AngularVelocity),// "Angular Velocity",
                    nameof(Physics_Data_Debug.AllValueNames.CasterAngleRad),//"Caster Angle",
                    nameof(Physics_Data_Debug.AllValueNames.CasterAngleDeg),//"Caster Angle",
                    nameof(Physics_Data_Debug.AllValueNames.SteerAngleRad),//"Steer Angle",
                    nameof(Physics_Data_Debug.AllValueNames.SteerAngleDeg),//"Steer Angle",
                    nameof(Physics_Data_Debug.AllValueNames.CamberAngleRad),//"Camber Angle",
                    nameof(Physics_Data_Debug.AllValueNames.CamberAngleDeg),//"Camber Angle",
                    nameof(Physics_Data_Debug.AllValueNames.LateralLoad),//"Lateral Load",
                    nameof(Physics_Data_Debug.AllValueNames.SlipAngleRad),//"Slip Angle",
                    nameof(Physics_Data_Debug.AllValueNames.SlipAngleDeg),//"Slip Angle",
                    nameof(Physics_Data_Debug.AllValueNames.LateralFriction),//"Lateral Friction",
                    nameof(Physics_Data_Debug.AllValueNames.LateralSlipSpeed),//"Lateral Slip Speed",
                    nameof(Physics_Data_Debug.AllValueNames.LongitudinalLoad),//"Longitudinal Load",
                    nameof(Physics_Data_Debug.AllValueNames.SlipRatio),//"Slip Ratio",
                    nameof(Physics_Data_Debug.AllValueNames.LongitudinalFriction),//"Longitudinal Friction",
                    nameof(Physics_Data_Debug.AllValueNames.LongitudinalSlipSpeed),//"Longitudinal Slip Speed",
                    nameof(Physics_Data_Debug.AllValueNames.SuspensionVelocity),//"Suspension Velocity"
                }
            );
    }
}
