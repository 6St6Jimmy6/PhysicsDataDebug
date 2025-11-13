using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    public class LogData
    {
        //To Do: Maybe later this needs to be more flexible, so it gets and sets the stuff that's actually logged.

        //Current List of logging stuff
        /*
    public static string sRaceTime = "RaceTime";
    public static string sTireTravelSpeed = "TireTravelSpeed";
    public static string sAngularVelocity = "AngularVelocity";
    public static string sVerticalLoad = "VerticalLoad";
    public static string sVerticalDeflection = "VerticalDeflection";
    public static string sLoadedRadius = "LoadedRadius";
    public static string sEffectiveRadius = "EffectiveRadius";
    public static string sContactLength = "ContactLength";
    public static string sBrakeTorque = "BrakeTorque";
    public static string sMaxBrakeTorque = "MaxBrakeTorque";
    public static string sSteerAngle = "SteerAngle";
    public static string sCamberAngle = "CamberAngle";
    public static string sLateralLoad = "LateralLoad";
    public static string sSlipAngle = "SlipAngle";
    public static string sLateralFriction = "LateralFriction";
    public static string sLateralSlipSpeed = "LateralSlipSpeed";
    public static string sLongitudinalLoad = "LongitudinalLoad";
    public static string sSlipRatio = "SlipRatio";
    public static string sLongitudinalFriction = "LongitudinalFriction";
    public static string sLongitudinalSlipSpeed = "LongitudinalSlipSpeed";
    public static string sTreadTemperature = "TreadTemperature";
    public static string sInnerTemperature = "InnerTemperature";
    public static string sTotalFriction = "TotalFriction";
    public static string sTotalFrictionAngle = "TotalFrictionAngle";
         */

        public int RaceTime { get; set; }
        public float TireTravelSpeed { get; set; }
        public float AngularVelocity { get; set; }
        public float VerticalLoad { get; set; }
        public float VerticalDeflection { get; set; }
        public float LoadedRadius { get; set; }
        public float EffectiveRadius { get; set; }
        public float ContactLength { get; set; }
        public float BrakeTorque { get; set; }
        public float MaxBrakeTorque { get; set; }
        public float SteerAngle { get; set; }
        public float CamberAngle { get; set; }
        public float LateralLoad { get; set; }
        public float SlipAngle { get; set; }
        public float LateralFriction { get; set; }
        public float LateralSlipSpeed { get; set; }
        public float LongitudinalLoad { get; set; }
        public float SlipRatio { get; set; }
        public float LongitudinalFriction { get; set; }
        public float LongitudinalSlipSpeed { get; set; }
        public float TreadTemperature { get; set; }
        public float InnerTemperature { get; set; }
        public float TotalFriction { get; set; }
        public float TotalFrictionAngle { get; set; }
        /*
         * public float a { get; set; }
         * public float a { get; set; }
         * public float a { get; set; }
         * public float a { get; set; }
         * public float a { get; set; }
         * public float a { get; set; }
         * public float a { get; set; }
         * */

        public LogData(int RaceTime,
            float TireTravelSpeed,
            float AngularVelocity,
            float VerticalLoad,
            float VerticalDeflection,
            float LoadedRadius,
            float EffectiveRadius,
            float ContactLength,
            float BrakeTorque,
            float MaxBrakeTorque,
            float SteerAngle,
            float CamberAngle,
            float LateralLoad,
            float SlipAngle,
            float LateralFriction,
            float LateralSlipSpeed,
            float LongitudinalLoad,
            float SlipRatio,
            float LongitudinalFriction,
            float LongitudinalSlipSpeed,
            float TreadTemperature,
            float InnerTemperature,
            float TotalFriction,
            float TotalFrictionAngle)
        {
            this.RaceTime = RaceTime;
            this.TireTravelSpeed = TireTravelSpeed;
            this.AngularVelocity = AngularVelocity;
            this.VerticalLoad = VerticalLoad;
            this.VerticalDeflection = VerticalDeflection;
            this.LoadedRadius = LoadedRadius;
            this.EffectiveRadius = EffectiveRadius;
            this.ContactLength = ContactLength;
            this.BrakeTorque = BrakeTorque;
            this.MaxBrakeTorque = MaxBrakeTorque;
            this.SteerAngle = SteerAngle;
            this.CamberAngle = CamberAngle;
            this.LateralLoad = LateralLoad;
            this.SlipAngle = SlipAngle;
            this.LateralFriction = LateralFriction;
            this.LateralSlipSpeed = LateralSlipSpeed;
            this.LongitudinalLoad = LongitudinalLoad;
            this.SlipRatio = SlipRatio;
            this.LongitudinalFriction = LongitudinalFriction;
            this.LongitudinalSlipSpeed = LongitudinalSlipSpeed;
            this.TreadTemperature = TreadTemperature;
            this.InnerTemperature = InnerTemperature;
            this.TotalFriction = TotalFriction;
            this.TotalFrictionAngle = TotalFrictionAngle;
        }
    }
}
