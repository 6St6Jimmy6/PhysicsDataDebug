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

        public static string FL_Parameter0 { get; set; }
        public static string FL_Parameter1 { get; set; }
        public static string FL_Parameter2 { get; set; }
        public static string FL_Parameter3 { get; set; }
        public static string FL_Parameter4 { get; set; }
        public static string FL_Parameter5 { get; set; }
        public static string FL_Parameter6 { get; set; }
        public static string FL_Parameter7 { get; set; }
        public static string FL_Parameter7_1 { get; set; }
        public static string FL_Parameter8 { get; set; }
        public static string FL_Parameter9 { get; set; }
        public static string FL_Parameter10 { get; set; }
        public static string FL_Parameter11 { get; set; }
        public static string FL_Parameter12 { get; set; }
        public static string FL_Parameter13 { get; set; }
        public static string FL_Parameter14 { get; set; }
        public static string FL_Parameter15 { get; set; }
        public static string FL_Parameter16 { get; set; }
        public static string FL_Parameter17 { get; set; }
        public static string FL_Parameter18 { get; set; }
        public static string FL_Parameter19 { get; set; }
        public static string FL_Parameter20 { get; set; }
        public static string FL_Parameter21 { get; set; }
        public static string FL_Parameter22 { get; set; }
        public static string FL_Parameter23 { get; set; }
        public static string FL_Parameter24 { get; set; }
        public static string FL_Parameter25 { get; set; }
        public static string FL_Parameter26 { get; set; }
        public static string FL_Parameter27 { get; set; }
        public static string FL_Parameter28 { get; set; }

        public static string FR_Parameter0 { get; set; }
        public static string FR_Parameter1 { get; set; }
        public static string FR_Parameter2 { get; set; }
        public static string FR_Parameter3 { get; set; }
        public static string FR_Parameter4 { get; set; }
        public static string FR_Parameter5 { get; set; }
        public static string FR_Parameter6 { get; set; }
        public static string FR_Parameter7 { get; set; }
        public static string FR_Parameter7_1 { get; set; }
        public static string FR_Parameter8 { get; set; }
        public static string FR_Parameter9 { get; set; }
        public static string FR_Parameter10 { get; set; }
        public static string FR_Parameter11 { get; set; }
        public static string FR_Parameter12 { get; set; }
        public static string FR_Parameter13 { get; set; }
        public static string FR_Parameter14 { get; set; }
        public static string FR_Parameter15 { get; set; }
        public static string FR_Parameter16 { get; set; }
        public static string FR_Parameter17 { get; set; }
        public static string FR_Parameter18 { get; set; }
        public static string FR_Parameter19 { get; set; }
        public static string FR_Parameter20 { get; set; }
        public static string FR_Parameter21 { get; set; }
        public static string FR_Parameter22 { get; set; }
        public static string FR_Parameter23 { get; set; }
        public static string FR_Parameter24 { get; set; }
        public static string FR_Parameter25 { get; set; }
        public static string FR_Parameter26 { get; set; }
        public static string FR_Parameter27 { get; set; }
        public static string FR_Parameter28 { get; set; }

        public static string RL_Parameter0 { get; set; }
        public static string RL_Parameter1 { get; set; }
        public static string RL_Parameter2 { get; set; }
        public static string RL_Parameter3 { get; set; }
        public static string RL_Parameter4 { get; set; }
        public static string RL_Parameter5 { get; set; }
        public static string RL_Parameter6 { get; set; }
        public static string RL_Parameter7 { get; set; }
        public static string RL_Parameter7_1 { get; set; }
        public static string RL_Parameter8 { get; set; }
        public static string RL_Parameter9 { get; set; }
        public static string RL_Parameter10 { get; set; }
        public static string RL_Parameter11 { get; set; }
        public static string RL_Parameter12 { get; set; }
        public static string RL_Parameter13 { get; set; }
        public static string RL_Parameter14 { get; set; }
        public static string RL_Parameter15 { get; set; }
        public static string RL_Parameter16 { get; set; }
        public static string RL_Parameter17 { get; set; }
        public static string RL_Parameter18 { get; set; }
        public static string RL_Parameter19 { get; set; }
        public static string RL_Parameter20 { get; set; }
        public static string RL_Parameter21 { get; set; }
        public static string RL_Parameter22 { get; set; }
        public static string RL_Parameter23 { get; set; }
        public static string RL_Parameter24 { get; set; }
        public static string RL_Parameter25 { get; set; }
        public static string RL_Parameter26 { get; set; }
        public static string RL_Parameter27 { get; set; }
        public static string RL_Parameter28 { get; set; }

        public static string RR_Parameter0 { get; set; }
        public static string RR_Parameter1 { get; set; }
        public static string RR_Parameter2 { get; set; }
        public static string RR_Parameter3 { get; set; }
        public static string RR_Parameter4 { get; set; }
        public static string RR_Parameter5 { get; set; }
        public static string RR_Parameter6 { get; set; }
        public static string RR_Parameter7 { get; set; }
        public static string RR_Parameter7_1 { get; set; }
        public static string RR_Parameter8 { get; set; }
        public static string RR_Parameter9 { get; set; }
        public static string RR_Parameter10 { get; set; }
        public static string RR_Parameter11 { get; set; }
        public static string RR_Parameter12 { get; set; }
        public static string RR_Parameter13 { get; set; }
        public static string RR_Parameter14 { get; set; }
        public static string RR_Parameter15 { get; set; }
        public static string RR_Parameter16 { get; set; }
        public static string RR_Parameter17 { get; set; }
        public static string RR_Parameter18 { get; set; }
        public static string RR_Parameter19 { get; set; }
        public static string RR_Parameter20 { get; set; }
        public static string RR_Parameter21 { get; set; }
        public static string RR_Parameter22 { get; set; }
        public static string RR_Parameter23 { get; set; }
        public static string RR_Parameter24 { get; set; }
        public static string RR_Parameter25 { get; set; }
        public static string RR_Parameter26 { get; set; }
        public static string RR_Parameter27 { get; set; }
        public static string RR_Parameter28 { get; set; }
    }
}
