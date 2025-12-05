using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    public class RawTireData
    {
        public int RaceTime { get; set; }
        public float MomentOfInertia { get; set; }
        public float AngularVelocity { get; set; }

        public float TireMass { get; set; }
        public float TireRadius { get; set; }
        public float TireWidth { get; set; }
        public float TireSpringRate { get; set; }
        public float TireDamperRate { get; set; }
        public float TireMaxDeflection { get; set; }
        public float ThermalAirTransfer { get; set; }
        public float ThermalInnerTransfer { get; set; }
        public float TreadTemperature { get; set; }
        public float InnerTemperature { get; set; }
        public float VerticalDeflection { get; set; }
        public float LoadedRadius { get; set; }
        public float EffectiveRadius { get; set; }
        public float LongitudinalSlipSpeed { get; set; }
        public float LateralSlipSpeed { get; set; }
        public float RadiansTireMoved { get; set; }
        public float CurrentContactBrakeTorque { get; set; }
        public float CurrentContactHandBrakeTorque { get; set; }
        public float CurrentContactBrakeTorqueMax { get; set; }
        public float VerticalLoad { get; set; }

        public float TireX { get; set; }
        public float TireY { get; set; }
        public float TireZ { get; set; }

        public float LateralLoad { get; set; }
        public float LongitudinalLoad { get; set; }
        public float SlipAngleRad { get; set; }
        public float SlipAngleDeg { get; set; }
        public float SlipRatio { get; set; }
        public float LateralResistance { get; set; }
        public float LongitudinalResistance { get; set; }

        public float TirePivotX { get; set; }
        public float TirePivotY { get; set; }
        public float TirePivotZ { get; set; }
        public float TireM11 { get; set; }
        public float TireM12 { get; set; }
        public float TireM13 { get; set; }
        public float TireM14 { get; set; }
        public float TireM21 { get; set; }
        public float TireM22 { get; set; }
        public float TireM23 { get; set; }
        public float TireM24 { get; set; }
        public float TireM31 { get; set; }
        public float TireM32 { get; set; }
        public float TireM33 { get; set; }
        public float TireM34 { get; set; }
        public float TireM41 { get; set; }
        public float TireM42 { get; set; }
        public float TireM43 { get; set; }
        public float TireM44 { get; set; }

        public float ContactLength { get; set; }
        public float TravelSpeed { get; set; }

        public float SpringRate { get; set; }
        public float ProgresiveRate { get; set; }
        public float BumbLimitsX { get; set; }
        public float BumpLimitsY { get; set; }
        public float ReboundLimitsX { get; set; }
        public float ReboundLimitsY { get; set; }
        public float BumpDampX { get; set; }
        public float ReboundDampX { get; set; }
        public float BumpDampY { get; set; }
        public float ReboundDampY { get; set; }
        public float ExpandLimitFromZero { get; set; }
        public float CompressionLimitFromZero { get; set; }
        public float RideHeightBumpStopDownReboundLength { get; set; }
        public float SuspensionLength { get; set; }
        public float SuspensionVelocity { get; set; }
        public float BumpStopLength { get; set; }
        public float RideHeightBumpStopDown { get; set; }
        public float BumpStopRate { get; set; }
        public float ReboundRate { get; set; }
        public float BumpStopDamp { get; set; }
        public float BumpStopRateGainDeflectionSquared { get; set; }
        public float BumpStopDampGainDeflectionSquared { get; set; }// Adjust this as required
    }
}
