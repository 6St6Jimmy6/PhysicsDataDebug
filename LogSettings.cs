using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    class LogSettings
    {
        public static string ChartPlotterLocation { get; set; } = "";
        public static string LogFileSaveLocationFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\PhysicsDebugger\";
        public static string FileNameFLTire { get; set; } = "FrontLeft";
        public static string FileNameFRTire { get; set; } = "FrontRight";
        public static string FileNameRLTire { get; set; } = "RearLeft";
        public static string FileNameRRTire { get; set; } = "RearRight";
        public static string SaveFileName { get; set; } = "WreckfestDebugLog";
        public static string Extension { get; set; } = ".txt";
        public static char DefaultDelimiter { get; set; } = ';';
        public static char Delimiter { get; set; } = DefaultDelimiter;
        public static bool selectAll { get; set; } = true;
        public static bool FiltersOn { get; set; } = false;//

        public static double Z1 { get; set; } = 1d; // +/- from W1 slip ratio
        public static double W1 { get; set; } = 0d;

        public static double Z2 { get; set; } = 45d; // +/- from W2 slip angle degrees
        public static double W2 { get; set; } = 0d;

        public static double Z3 { get; set; } = 0d; // +/- from W3 speed filtered off (m/s)
        //public static double W3 = 0d;

        public static double Z4 { get; set; } = 500; // +/- from W4
        public static double W4 { get; set; } = 2500d; // vertical load filter

        public static bool TireTravelSpeedLogEnabled { get; set; } = true;//0
        public static bool AngularVelocityLogEnabled { get; set; } = true;//1
        public static bool VerticalLoadLogEnabled { get; set; } = true;//2
        public static bool VerticalDeflectionLogEnabled { get; set; } = true;//3
        public static bool LoadedRadiusLogEnabled { get; set; } = true;//4
        public static bool EffectiveRadiusLogEnabled { get; set; } = true;//5
        public static bool ContactLengthLogEnabled { get; set; } = true;//6
        public static bool BrakeTorqueLogEnabled { get; set; } = true;//7
        public static bool SteerAngleLogEnabled { get; set; } = true;//8
        public static bool CamberAngleLogEnabled { get; set; } = true;//9
        public static bool LateralLoadLogEnabled { get; set; } = true;//10
        public static bool SlipAngleLogEnabled { get; set; } = true;//11
        public static bool LateralFrictionLogEnabled { get; set; } = true;//12
        public static bool LateralSlipSpeedLogEnabled { get; set; } = true;//13
        public static bool LongitudinalLoadLogEnabled { get; set; } = true;//14
        public static bool SlipRatioLogEnabled { get; set; } = true;//15
        public static bool LongitudinalFrictionLogEnabled { get; set; } = true;//16
        public static bool LongitudinalSlipSpeedLogEnabled { get; set; } = true;//17
        public static bool TreadTemperatureLogEnabled { get; set; } = true;//18
        public static bool InnerTemperatureLogEnabled { get; set; } = true;//19
        public static bool RaceTimeLogEnabled { get; set; } = true;//20
        public static bool TotalFrictionLogEnabled { get; set; } = true;//21
        public static bool TotalFrictionAngleLogEnabled { get; set; } = true;//22
        public static bool SuspensionLengthLogEnabled { get; set; } = true;//23
        public static bool SuspensionVelocityLogEnabled { get; set; } = true;//24
        public static bool XGRotatedLogEnabled { get; set; } = true;//25
        public static bool ZGRotatedLogEnabled { get; set; } = true;//26
        public static bool YGRotatedLogEnabled { get; set; } = true;//27
        public static bool XYZGLogEnabled { get; set; } = true;//28

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
        public static string sXGRotated { get; set; } = "Lateral G-Force";
        public static string sZGRotated { get; set; } = "Longitudinal G-Force";
        public static string sYGRotated { get; set; } = "Vertical G-Force";
        public static string sXYZG { get; set; } = "G-Force";

        public static string Header0 { get; set; }
        public static string Header1 { get; set; }
        public static string Header2 { get; set; }
        public static string Header3 { get; set; }
        public static string Header4 { get; set; }
        public static string Header5 { get; set; }
        public static string Header6 { get; set; }
        public static string Header7 { get; set; }
        public static string Header7_1 { get; set; }
        public static string Header8 { get; set; }
        public static string Header9 { get; set; }
        public static string Header10 { get; set; }
        public static string Header11 { get; set; }
        public static string Header12 { get; set; }
        public static string Header13 { get; set; }
        public static string Header14 { get; set; }
        public static string Header15 { get; set; }
        public static string Header16 { get; set; }
        public static string Header17 { get; set; }
        public static string Header18 { get; set; }
        public static string Header19 { get; set; }
        public static string Header20 { get; set; }
        public static string Header21 { get; set; }
        public static string Header22 { get; set; }
        public static string Header23 { get; set; }
        public static string Header24 { get; set; }
        public static string Header25 { get; set; }
        public static string Header26 { get; set; }
        public static string Header27 { get; set; }
        public static string Header28 { get; set; }

        public static string flParameter0 { get; set; }
        public static string flParameter1 { get; set; }
        public static string flParameter2 { get; set; }
        public static string flParameter3 { get; set; }
        public static string flParameter4 { get; set; }
        public static string flParameter5 { get; set; }
        public static string flParameter6 { get; set; }
        public static string flParameter7 { get; set; }
        public static string flParameter7_1 { get; set; }
        public static string flParameter8 { get; set; }
        public static string flParameter9 { get; set; }
        public static string flParameter10 { get; set; }
        public static string flParameter11 { get; set; }
        public static string flParameter12 { get; set; }
        public static string flParameter13 { get; set; }
        public static string flParameter14 { get; set; }
        public static string flParameter15 { get; set; }
        public static string flParameter16 { get; set; }
        public static string flParameter17 { get; set; }
        public static string flParameter18 { get; set; }
        public static string flParameter19 { get; set; }
        public static string flParameter20 { get; set; }
        public static string flParameter21 { get; set; }
        public static string flParameter22 { get; set; }
        public static string flParameter23 { get; set; }
        public static string flParameter24 { get; set; }
        public static string flParameter25 { get; set; }
        public static string flParameter26 { get; set; }
        public static string flParameter27 { get; set; }
        public static string flParameter28 { get; set; }

        public static string frParameter0 { get; set; }
        public static string frParameter1 { get; set; }
        public static string frParameter2 { get; set; }
        public static string frParameter3 { get; set; }
        public static string frParameter4 { get; set; }
        public static string frParameter5 { get; set; }
        public static string frParameter6 { get; set; }
        public static string frParameter7 { get; set; }
        public static string frParameter7_1 { get; set; }
        public static string frParameter8 { get; set; }
        public static string frParameter9 { get; set; }
        public static string frParameter10 { get; set; }
        public static string frParameter11 { get; set; }
        public static string frParameter12 { get; set; }
        public static string frParameter13 { get; set; }
        public static string frParameter14 { get; set; }
        public static string frParameter15 { get; set; }
        public static string frParameter16 { get; set; }
        public static string frParameter17 { get; set; }
        public static string frParameter18 { get; set; }
        public static string frParameter19 { get; set; }
        public static string frParameter20 { get; set; }
        public static string frParameter21 { get; set; }
        public static string frParameter22 { get; set; }
        public static string frParameter23 { get; set; }
        public static string frParameter24 { get; set; }
        public static string frParameter25 { get; set; }
        public static string frParameter26 { get; set; }
        public static string frParameter27 { get; set; }
        public static string frParameter28 { get; set; }

        public static string rlParameter0 { get; set; }
        public static string rlParameter1 { get; set; }
        public static string rlParameter2 { get; set; }
        public static string rlParameter3 { get; set; }
        public static string rlParameter4 { get; set; }
        public static string rlParameter5 { get; set; }
        public static string rlParameter6 { get; set; }
        public static string rlParameter7 { get; set; }
        public static string rlParameter7_1 { get; set; }
        public static string rlParameter8 { get; set; }
        public static string rlParameter9 { get; set; }
        public static string rlParameter10 { get; set; }
        public static string rlParameter11 { get; set; }
        public static string rlParameter12 { get; set; }
        public static string rlParameter13 { get; set; }
        public static string rlParameter14 { get; set; }
        public static string rlParameter15 { get; set; }
        public static string rlParameter16 { get; set; }
        public static string rlParameter17 { get; set; }
        public static string rlParameter18 { get; set; }
        public static string rlParameter19 { get; set; }
        public static string rlParameter20 { get; set; }
        public static string rlParameter21 { get; set; }
        public static string rlParameter22 { get; set; }
        public static string rlParameter23 { get; set; }
        public static string rlParameter24 { get; set; }
        public static string rlParameter25 { get; set; }
        public static string rlParameter26 { get; set; }
        public static string rlParameter27 { get; set; }
        public static string rlParameter28 { get; set; }

        public static string rrParameter0 { get; set; }
        public static string rrParameter1 { get; set; }
        public static string rrParameter2 { get; set; }
        public static string rrParameter3 { get; set; }
        public static string rrParameter4 { get; set; }
        public static string rrParameter5 { get; set; }
        public static string rrParameter6 { get; set; }
        public static string rrParameter7 { get; set; }
        public static string rrParameter7_1 { get; set; }
        public static string rrParameter8 { get; set; }
        public static string rrParameter9 { get; set; }
        public static string rrParameter10 { get; set; }
        public static string rrParameter11 { get; set; }
        public static string rrParameter12 { get; set; }
        public static string rrParameter13 { get; set; }
        public static string rrParameter14 { get; set; }
        public static string rrParameter15 { get; set; }
        public static string rrParameter16 { get; set; }
        public static string rrParameter17 { get; set; }
        public static string rrParameter18 { get; set; }
        public static string rrParameter19 { get; set; }
        public static string rrParameter20 { get; set; }
        public static string rrParameter21 { get; set; }
        public static string rrParameter22 { get; set; }
        public static string rrParameter23 { get; set; }
        public static string rrParameter24 { get; set; }
        public static string rrParameter25 { get; set; }
        public static string rrParameter26 { get; set; }
        public static string rrParameter27 { get; set; }
        public static string rrParameter28 { get; set; }
    }
}
