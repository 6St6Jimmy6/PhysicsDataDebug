using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace MemHelperExample
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update = new Thread(new ThreadStart(getData));
            update.IsBackground = true;
            update.Start(); 
        }

        private void temperatures_Click(object sender, EventArgs e)
        {

        }

        private Thread update;

        private bool logging = false;

        private int sleep = 50;

        private readonly double[] flsTempArray = new double[300];
        private readonly double[] fliTempArray = new double[300];
        private readonly double[] frsTempArray = new double[300];
        private readonly double[] friTempArray = new double[300];
        private readonly double[] rlsTempArray = new double[300];
        private readonly double[] rliTempArray = new double[300];
        private readonly double[] rrsTempArray = new double[300];
        private readonly double[] rriTempArray = new double[300];
        
        private double TempCorrectionValue = 0.0000000000;
        private double TempCorrectionValueA = 0.0000000000;
        private double TempCorrectionValueB = 0.0000000000;
        private double TempCorrectionValueC = 0.0000000000;
        private double TempCorrectionValueD = 0.0000000000;

        
        private double speed = 0.00;
        private double frontLift = 0.00;
        private double rearLift = 0.00;

        //Time offsets
        private int OffsetRaceTime = 0x14;

        //0x3E4
        //0xAE8

        

        //Tire data offsets
        private int OffsetTireData = 0xE78;
        private int OffsetNextTire = 0xC50;

        private int OffsetAngularVelocity = 0x2C;
        private int OffsetTreadTemperature = 0x434;
        private int OffsetInnerTemperature = 0x438;
        private int OffsetDeflection = 0x43C;
        private int OffsetLoadedRadius = 0x44C;
        private int OffsetEffectiveRadius = 0x450;
        private int OffsetCurrentContactBrakeTorque = 0x484;
        private int OffsetCurrentContactBrakeTorqueMax = 0x48C;
        private int OffsetVerticalLoad = 0x490;
        private int OffsetLateralLoad = 0x4B8;
        private int OffsetLongitudinalLoad = 0x4C0;
        private int OffsetSlipAngleRad = 0xBF0;
        private int OffsetSlipRatio = 0xBF4;
        private int OffsetContactLength = 0xC1C;
        private int OffsetTravelSpeed = 0xC20;

        //Time Data
        private int RaceTime;

        //Tire Data
        private double flsTemp = 0.0;
        private double fliTemp = 0.0;
        private double frsTemp = 0.0;
        private double friTemp = 0.0;
        private double rlsTemp = 0.0;
        private double rliTemp = 0.0;
        private double rrsTemp = 0.0;
        private double rriTemp = 0.0;
        //Font Left
        private double FL_AngularVelocity;
        private double FL_Deflection;
        private double FL_LoadedRadius;
        private double FL_EffectiveRadius;
        private double FL_CurrentContactBrakeTorque;
        private double FL_CurrentContactBrakeTorqueMax;
        private double FL_VerticalLoad;
        private double FL_LateralLoad;
        private double FL_LongitudinalLoad;
        private double FL_SlipAngleRad;
        private double FL_SlipAngleDeg;
        private double FL_SlipRatio;
        private double FL_ContactLength;
        private double FL_TravelSpeed;
        //Font Right
        private double FR_AngularVelocity;
        private double FR_Deflection;
        private double FR_LoadedRadius;
        private double FR_EffectiveRadius;
        private double FR_CurrentContactBrakeTorque;
        private double FR_CurrentContactBrakeTorqueMax;
        private double FR_VerticalLoad;
        private double FR_LateralLoad;
        private double FR_LongitudinalLoad;
        private double FR_SlipAngleRad;
        private double FR_SlipAngleDeg;
        private double FR_SlipRatio;
        private double FR_ContactLength;
        private double FR_TravelSpeed;
        //Rear Left
        private double RL_AngularVelocity;
        private double RL_Deflection;
        private double RL_LoadedRadius;
        private double RL_EffectiveRadius;
        private double RL_CurrentContactBrakeTorque;
        private double RL_CurrentContactBrakeTorqueMax;
        private double RL_VerticalLoad;
        private double RL_LateralLoad;
        private double RL_LongitudinalLoad;
        private double RL_SlipAngleRad;
        private double RL_SlipAngleDeg;
        private double RL_SlipRatio;
        private double RL_ContactLength;
        private double RL_TravelSpeed;
        //Rear Right
        private double RR_AngularVelocity;
        private double RR_Deflection;
        private double RR_LoadedRadius;
        private double RR_EffectiveRadius;
        private double RR_CurrentContactBrakeTorque;
        private double RR_CurrentContactBrakeTorqueMax;
        private double RR_VerticalLoad;
        private double RR_LateralLoad;
        private double RR_LongitudinalLoad;
        private double RR_SlipAngleRad;
        private double RR_SlipAngleDeg;
        private double RR_SlipRatio;
        private double RR_ContactLength;
        private double RR_TravelSpeed;

        //Every update offsets the base address of the memory points. 99% of the time forwards.
        ulong baseAddrUpdt = 0x5710;
        //0x0;// April 2022
        //0x4650;// May 2022
        //0x5710// October 2022

        // Older builds go backwards, so this is for them. Above should be 0x0 then.
        ulong baseAddrDodt = 0x0;//0x6DF8D8

        private void getData()
        {
            while(true)
            {
                Process p = Process.GetProcessesByName("Wreckfest_x64").FirstOrDefault();
                if (p == null) return;

                Memory.Win64.MemoryHelper64 helper = new Memory.Win64.MemoryHelper64(p);

                //Base Addres for Tire data
                ulong baseAddr = helper.GetBaseAddress(0x1831EE0 + baseAddrUpdt - baseAddrDodt);
                //Base Address for Speed and Lifts
                ulong baseAddrSpeed = helper.GetBaseAddress(0x18327C8 + baseAddrUpdt - baseAddrDodt);
                ulong baseAddrLifts = helper.GetBaseAddress(0x184B118 + baseAddrUpdt - baseAddrDodt);
                //Base Address for Race Timer
                ulong BaseAddrRacetimer = helper.GetBaseAddress(0x1832648 + baseAddrUpdt - baseAddrDodt);
                //Race time pointer reader
                int[] RaceTimerOffsets = { OffsetRaceTime };
                ulong RaceTimer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, BaseAddrRacetimer, RaceTimerOffsets);
                
                
                //Temperature pointers
                int[] flsOffsets = { OffsetTireData, OffsetTreadTemperature };
                int[] fliOffsets = { OffsetTireData, OffsetInnerTemperature };
                int[] frsOffsets = { OffsetTireData, 0x1084 };
                int[] friOffsets = { OffsetTireData, 0x1088 };
                int[] rlsOffsets = { OffsetTireData, 0x1CD4 };
                int[] rliOffsets = { OffsetTireData, 0x1CD8 };
                int[] rrsOffsets = { OffsetTireData, 0x2924 };
                int[] rriOffsets = { OffsetTireData, 0x2928 };
                //Temperature pointer reader
                ulong flsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, flsOffsets);
                ulong fliTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, fliOffsets);
                ulong frsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, frsOffsets);
                ulong friTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, friOffsets);
                ulong rlsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, rlsOffsets);
                ulong rliTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, rliOffsets);
                ulong rrsTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, rrsOffsets);
                ulong rriTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, rriOffsets);
                //Speed and Lift pointers
                int[] speedOffsets = { 0x70 };
                int[] frontLiftOffsets = { 0xAACF2C };
                int[] rearLiftOffsets = { 0xAACF30 };
                //Speed and Lift pointer reader
                ulong speedTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrSpeed, speedOffsets);
                ulong frontLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrLifts, frontLiftOffsets);
                ulong rearLiftTargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddrLifts, rearLiftOffsets);
                //Read Speed and Lifts
                speed = Math.Round(helper.ReadMemory<float>(speedTargetAddr), 2);
                frontLift = Math.Round(helper.ReadMemory<float>(frontLiftTargetAddr), 2);
                rearLift = Math.Round(helper.ReadMemory<float>(rearLiftTargetAddr), 2);

                //Tire Data pointers
                //Front Left
                int[] FL_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity };
                int[] FL_DeflectionOffsets = { OffsetTireData, OffsetDeflection };
                int[] FL_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius};
                int[] FL_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius };
                int[] FL_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque};
                int[] FL_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax};
                int[] FL_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad};
                int[] FL_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad};
                int[] FL_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad};
                int[] FL_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad};
                int[] FL_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio};
                int[] FL_ContactLengthOffsets = { OffsetTireData, OffsetContactLength};
                int[] FL_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed};
                //Front Right
                int[] FR_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity + OffsetNextTire };
                int[] FR_DeflectionOffsets = { OffsetTireData, OffsetDeflection + OffsetNextTire };
                int[] FR_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius + OffsetNextTire };
                int[] FR_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius + OffsetNextTire };
                int[] FR_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetNextTire };
                int[] FR_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetNextTire };
                int[] FR_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad + OffsetNextTire };
                int[] FR_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad + OffsetNextTire };
                int[] FR_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad + OffsetNextTire };
                int[] FR_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad + OffsetNextTire };
                int[] FR_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio + OffsetNextTire };
                int[] FR_ContactLengthOffsets = { OffsetTireData, OffsetContactLength + OffsetNextTire };
                int[] FR_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed + OffsetNextTire };
                //Rear Left
                int[] RL_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity + OffsetNextTire + OffsetNextTire };
                int[] RL_DeflectionOffsets = { OffsetTireData, OffsetDeflection + OffsetNextTire + OffsetNextTire };
                int[] RL_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius + OffsetNextTire + OffsetNextTire };
                int[] RL_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius + OffsetNextTire + OffsetNextTire };
                int[] RL_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetNextTire + OffsetNextTire };
                int[] RL_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetNextTire + OffsetNextTire };
                int[] RL_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad + OffsetNextTire + OffsetNextTire };
                int[] RL_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad + OffsetNextTire + OffsetNextTire };
                int[] RL_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad + OffsetNextTire + OffsetNextTire };
                int[] RL_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad + OffsetNextTire + OffsetNextTire };
                int[] RL_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio + OffsetNextTire + OffsetNextTire };
                int[] RL_ContactLengthOffsets = { OffsetTireData, OffsetContactLength + OffsetNextTire + OffsetNextTire };
                int[] RL_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed + OffsetNextTire + OffsetNextTire };
                //Rear Right
                int[] RR_AngularVelocityOffsets = { OffsetTireData, OffsetAngularVelocity + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_DeflectionOffsets = { OffsetTireData, OffsetDeflection + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_LoadedRadiusOffsets = { OffsetTireData, OffsetLoadedRadius + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_EffectiveRadiusOffsets = { OffsetTireData, OffsetEffectiveRadius + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_CurrentContactBrakeTorqueOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorque + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_CurrentContactBrakeTorqueMaxOffsets = { OffsetTireData, OffsetCurrentContactBrakeTorqueMax + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_VerticalLoadOffsets = { OffsetTireData, OffsetVerticalLoad + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_LateralLoadOffsets = { OffsetTireData, OffsetLateralLoad + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_LongitudinalLoadOffsets = { OffsetTireData, OffsetLongitudinalLoad + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_SlipAngleRadOffsets = { OffsetTireData, OffsetSlipAngleRad + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_SlipRatioOffsets = { OffsetTireData, OffsetSlipRatio + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_ContactLengthOffsets = { OffsetTireData, OffsetContactLength + OffsetNextTire + OffsetNextTire + OffsetNextTire };
                int[] RR_TravelSpeedOffsets = { OffsetTireData, OffsetTravelSpeed + OffsetNextTire + OffsetNextTire + OffsetNextTire };


                //Tire Data pointer readers
                //Front Left
                ulong FL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_AngularVelocityOffsets);
                ulong FL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_DeflectionOffsets);
                ulong FL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_LoadedRadiusOffsets);
                ulong FL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_EffectiveRadiusOffsets);
                ulong FL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_CurrentContactBrakeTorqueOffsets);
                ulong FL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_CurrentContactBrakeTorqueMaxOffsets);
                ulong FL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_VerticalLoadOffsets);
                ulong FL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_LateralLoadOffsets);
                ulong FL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_LongitudinalLoadOffsets);
                ulong FL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_SlipAngleRadOffsets);
                ulong FL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_SlipRatioOffsets);
                ulong FL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_ContactLengthOffsets);
                ulong FL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TravelSpeedOffsets);
                //Front Right
                ulong FR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_AngularVelocityOffsets);
                ulong FR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_DeflectionOffsets);
                ulong FR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_LoadedRadiusOffsets);
                ulong FR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_EffectiveRadiusOffsets);
                ulong FR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_CurrentContactBrakeTorqueOffsets);
                ulong FR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_CurrentContactBrakeTorqueMaxOffsets);
                ulong FR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_VerticalLoadOffsets);
                ulong FR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_LateralLoadOffsets);
                ulong FR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_LongitudinalLoadOffsets);
                ulong FR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_SlipAngleRadOffsets);
                ulong FR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_SlipRatioOffsets);
                ulong FR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_ContactLengthOffsets);
                ulong FR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TravelSpeedOffsets);
                //Rear Left
                ulong RL_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_AngularVelocityOffsets);
                ulong RL_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_DeflectionOffsets);
                ulong RL_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_LoadedRadiusOffsets);
                ulong RL_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_EffectiveRadiusOffsets);
                ulong RL_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_CurrentContactBrakeTorqueOffsets);
                ulong RL_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_CurrentContactBrakeTorqueMaxOffsets);
                ulong RL_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_VerticalLoadOffsets);
                ulong RL_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_LateralLoadOffsets);
                ulong RL_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_LongitudinalLoadOffsets);
                ulong RL_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_SlipAngleRadOffsets);
                ulong RL_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_SlipRatioOffsets);
                ulong RL_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_ContactLengthOffsets);
                ulong RL_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TravelSpeedOffsets);
                //Rear Right
                ulong RR_AngularVelocity_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_AngularVelocityOffsets);
                ulong RR_Deflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_DeflectionOffsets);
                ulong RR_LoadedRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_LoadedRadiusOffsets);
                ulong RR_EffectiveRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_EffectiveRadiusOffsets);
                ulong RR_CurrentContactBrakeTorque_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_CurrentContactBrakeTorqueOffsets);
                ulong RR_CurrentContactBrakeTorqueMax_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_CurrentContactBrakeTorqueMaxOffsets);
                ulong RR_VerticalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_VerticalLoadOffsets);
                ulong RR_LateralLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_LateralLoadOffsets);
                ulong RR_LongitudinalLoad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_LongitudinalLoadOffsets);
                ulong RR_SlipAngleRad_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_SlipAngleRadOffsets);
                ulong RR_SlipRatio_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_SlipRatioOffsets);
                ulong RR_ContactLength_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_ContactLengthOffsets);
                ulong RR_TravelSpeed_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TravelSpeedOffsets);

                //Read Tire Data
                //Font Left
                FL_AngularVelocity = Math.Round(helper.ReadMemory<float>(FL_AngularVelocity_TargetAddr),2);
                FL_Deflection = Math.Round(helper.ReadMemory<float>(FL_Deflection_TargetAddr), 5);
                FL_LoadedRadius = Math.Round(helper.ReadMemory<float>(FL_LoadedRadius_TargetAddr), 5);
                FL_EffectiveRadius = Math.Round(helper.ReadMemory<float>(FL_EffectiveRadius_TargetAddr), 5);
                FL_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(FL_CurrentContactBrakeTorque_TargetAddr), 2);
                FL_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(FL_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                FL_VerticalLoad = Math.Round(helper.ReadMemory<float>(FL_VerticalLoad_TargetAddr), 2);
                FL_LateralLoad = Math.Round(helper.ReadMemory<float>(FL_LateralLoad_TargetAddr), 2);
                FL_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(FL_LongitudinalLoad_TargetAddr), 2);
                FL_SlipAngleRad = Math.Round(helper.ReadMemory<float>(FL_SlipAngleRad_TargetAddr), 5);
                FL_SlipAngleDeg = Math.Round(FL_SlipAngleRad, 5);
                FL_SlipRatio = Math.Round(helper.ReadMemory<float>(FL_SlipRatio_TargetAddr), 5);
                FL_ContactLength = Math.Round(helper.ReadMemory<float>(FL_ContactLength_TargetAddr), 5);
                FL_TravelSpeed = Math.Round(helper.ReadMemory<float>(FL_TravelSpeed_TargetAddr), 2);
                //Font Right
                FR_AngularVelocity = Math.Round(helper.ReadMemory<float>(FR_AngularVelocity_TargetAddr), 2);
                FR_Deflection = Math.Round(helper.ReadMemory<float>(FR_Deflection_TargetAddr), 5);
                FR_LoadedRadius = Math.Round(helper.ReadMemory<float>(FR_LoadedRadius_TargetAddr), 5);
                FR_EffectiveRadius = Math.Round(helper.ReadMemory<float>(FR_EffectiveRadius_TargetAddr), 5);
                FR_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(FR_CurrentContactBrakeTorque_TargetAddr), 2);
                FR_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(FR_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                FR_VerticalLoad = Math.Round(helper.ReadMemory<float>(FR_VerticalLoad_TargetAddr), 2);
                FR_LateralLoad = Math.Round(helper.ReadMemory<float>(FR_LateralLoad_TargetAddr), 2);
                FR_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(FR_LongitudinalLoad_TargetAddr), 2);
                FR_SlipAngleRad = Math.Round(helper.ReadMemory<float>(FR_SlipAngleRad_TargetAddr), 5);
                FR_SlipAngleDeg = Math.Round(FR_SlipAngleRad, 5);
                FR_SlipRatio = Math.Round(helper.ReadMemory<float>(FR_SlipRatio_TargetAddr), 5);
                FR_ContactLength = Math.Round(helper.ReadMemory<float>(FR_ContactLength_TargetAddr), 2);
                FR_TravelSpeed = Math.Round(helper.ReadMemory<float>(FR_TravelSpeed_TargetAddr), 2);
                //Rear Left
                RL_AngularVelocity = Math.Round(helper.ReadMemory<float>(RL_AngularVelocity_TargetAddr), 2);
                RL_Deflection = Math.Round(helper.ReadMemory<float>(RL_Deflection_TargetAddr), 5);
                RL_LoadedRadius = Math.Round(helper.ReadMemory<float>(RL_LoadedRadius_TargetAddr), 5);
                RL_EffectiveRadius = Math.Round(helper.ReadMemory<float>(RL_EffectiveRadius_TargetAddr), 5);
                RL_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(RL_CurrentContactBrakeTorque_TargetAddr), 2);
                RL_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(RL_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                RL_VerticalLoad = Math.Round(helper.ReadMemory<float>(RL_VerticalLoad_TargetAddr), 2);
                RL_LateralLoad = Math.Round(helper.ReadMemory<float>(RL_LateralLoad_TargetAddr), 2);
                RL_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(RL_LongitudinalLoad_TargetAddr), 2);
                RL_SlipAngleRad = Math.Round(helper.ReadMemory<float>(RL_SlipAngleRad_TargetAddr), 5);
                RL_SlipAngleDeg = Math.Round(RL_SlipAngleRad, 5);
                RL_SlipRatio = Math.Round(helper.ReadMemory<float>(RL_SlipRatio_TargetAddr), 5);
                RL_ContactLength = Math.Round(helper.ReadMemory<float>(RL_ContactLength_TargetAddr), 2);
                RL_TravelSpeed = Math.Round(helper.ReadMemory<float>(RL_TravelSpeed_TargetAddr), 2);
                //Rear Right
                RR_AngularVelocity = Math.Round(helper.ReadMemory<float>(RR_AngularVelocity_TargetAddr), 2);
                RR_Deflection = Math.Round(helper.ReadMemory<float>(RR_Deflection_TargetAddr), 5);
                RR_LoadedRadius = Math.Round(helper.ReadMemory<float>(RR_LoadedRadius_TargetAddr), 5);
                RR_EffectiveRadius = Math.Round(helper.ReadMemory<float>(RR_EffectiveRadius_TargetAddr), 5);
                RR_CurrentContactBrakeTorque = Math.Round(helper.ReadMemory<float>(RR_CurrentContactBrakeTorque_TargetAddr), 2);
                RR_CurrentContactBrakeTorqueMax = Math.Round(helper.ReadMemory<float>(RR_CurrentContactBrakeTorqueMax_TargetAddr), 2);
                RR_VerticalLoad = Math.Round(helper.ReadMemory<float>(RR_VerticalLoad_TargetAddr), 2);
                RR_LateralLoad = Math.Round(helper.ReadMemory<float>(RR_LateralLoad_TargetAddr), 2);
                RR_LongitudinalLoad = Math.Round(helper.ReadMemory<float>(RR_LongitudinalLoad_TargetAddr), 2);
                RR_SlipAngleRad = Math.Round(helper.ReadMemory<float>(RR_SlipAngleRad_TargetAddr), 5);
                RR_SlipAngleDeg = Math.Round(RR_SlipAngleRad, 5);
                RR_SlipRatio = Math.Round(helper.ReadMemory<float>(RR_SlipRatio_TargetAddr), 5);
                RR_ContactLength = Math.Round(helper.ReadMemory<float>(RR_ContactLength_TargetAddr), 2);
                RR_TravelSpeed = Math.Round(helper.ReadMemory<float>(RR_TravelSpeed_TargetAddr), 2);

                RaceTime = helper.ReadMemory<int>(RaceTimer_TargetAddr);

                //Read Temperatures
                var flsTempHelper = helper.ReadMemory<float>(flsTargetAddr);
                var fliTempHelper = helper.ReadMemory<float>(fliTargetAddr);
                var frsTempHelper = helper.ReadMemory<float>(frsTargetAddr);
                var friTempHelper = helper.ReadMemory<float>(friTargetAddr);
                var rlsTempHelper = helper.ReadMemory<float>(rlsTargetAddr);
                var rliTempHelper = helper.ReadMemory<float>(rliTargetAddr);
                var rrsTempHelper = helper.ReadMemory<float>(rrsTargetAddr);
                var rriTempHelper = helper.ReadMemory<float>(rriTargetAddr);

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

                flsTempArray[flsTempArray.Length - 1] = Math.Round(flsTemp, 10);//roundi oli 0. Saa sulavemman kuvaajan isommalla luvulla
                fliTempArray[fliTempArray.Length - 1] = Math.Round(fliTemp, 10);
                frsTempArray[frsTempArray.Length - 1] = Math.Round(frsTemp, 10);
                friTempArray[friTempArray.Length - 1] = Math.Round(friTemp, 10);
                rlsTempArray[rlsTempArray.Length - 1] = Math.Round(rlsTemp, 10);
                rliTempArray[rliTempArray.Length - 1] = Math.Round(rliTemp, 10);
                rrsTempArray[rrsTempArray.Length - 1] = Math.Round(rrsTemp, 10);
                rriTempArray[rriTempArray.Length - 1] = Math.Round(rriTemp, 10);

                Array.Copy(flsTempArray, 1, flsTempArray, 0, flsTempArray.Length - 1);
                Array.Copy(fliTempArray, 1, fliTempArray, 0, fliTempArray.Length - 1);
                Array.Copy(frsTempArray, 1, frsTempArray, 0, frsTempArray.Length - 1);
                Array.Copy(friTempArray, 1, friTempArray, 0, friTempArray.Length - 1);
                Array.Copy(rlsTempArray, 1, rlsTempArray, 0, rlsTempArray.Length - 1);
                Array.Copy(rliTempArray, 1, rliTempArray, 0, rliTempArray.Length - 1);
                Array.Copy(rrsTempArray, 1, rrsTempArray, 0, rrsTempArray.Length - 1);
                Array.Copy(rriTempArray, 1, rriTempArray, 0, rriTempArray.Length - 1);

                if (logging == true)
                {
                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "FrontLeftWreckfestDebugLog.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "FrontLeftWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine("Race Time;Angular Velocity;Contact Length;Current Contact Brake Torque;Max Current Contact Brake Torque;Vertical Deflection;Effective Radius;Lateral Load;Loaded Radius;Longitudinal Load;Slip Angle Radians;Slip Angle Degrees;Slip Ratio;Travel Speed;Vertical Load");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "FrontLeftWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine(RaceTime.ToString() + ";" + FL_AngularVelocity.ToString() + ";" + FL_ContactLength.ToString() + ";" + FL_CurrentContactBrakeTorque.ToString() + ";" + FL_CurrentContactBrakeTorqueMax + ";" + FL_Deflection.ToString() + ";" + FL_EffectiveRadius.ToString() + ";" + FL_LateralLoad.ToString() + ";" + FL_LoadedRadius.ToString() + ";" + FL_LongitudinalLoad.ToString() + ";" + FL_SlipAngleRad.ToString() + ";" + FL_SlipAngleDeg.ToString() + ";" + FL_SlipRatio.ToString() + ";" + FL_TravelSpeed.ToString() + ";" + FL_VerticalLoad.ToString());
                        }
                    }

                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "FrontRightWreckfestDebugLog.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "FrontRightWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine("Race Time;Angular Velocity;Contact Length;Current Contact Brake Torque;Max Current Contact Brake Torque;Vertical Deflection;Effective Radius;Lateral Load;Loaded Radius;Longitudinal Load;Slip Angle Radians;Slip Angle Degrees;Slip Ratio;Travel Speed;Vertical Load");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "FrontRightWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine(RaceTime.ToString() + ";" + FR_AngularVelocity.ToString() + ";" + FR_ContactLength.ToString() + ";" + FR_CurrentContactBrakeTorque.ToString() + ";" + FR_CurrentContactBrakeTorqueMax + ";" + FR_Deflection.ToString() + ";" + FR_EffectiveRadius.ToString() + ";" + FR_LateralLoad.ToString() + ";" + FR_LoadedRadius.ToString() + ";" + FR_LongitudinalLoad.ToString() + ";" + FR_SlipAngleRad.ToString() + ";" + FR_SlipAngleDeg.ToString() + ";" + FR_SlipRatio.ToString() + ";" + FR_TravelSpeed.ToString() + ";" + FR_VerticalLoad.ToString());
                        }
                    }

                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "RearLeftWreckfestDebugLog.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "RearLeftWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine("Race Time;Angular Velocity;Contact Length;Current Contact Brake Torque;Max Current Contact Brake Torque;Vertical Deflection;Effective Radius;Lateral Load;Loaded Radius;Longitudinal Load;Slip Angle Radians;Slip Angle Degrees;Slip Ratio;Travel Speed;Vertical Load");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "RearLeftWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine(RaceTime.ToString() + ";" + RL_AngularVelocity.ToString() + ";" + RL_ContactLength.ToString() + ";" + RL_CurrentContactBrakeTorque.ToString() + ";" + RL_CurrentContactBrakeTorqueMax + ";" + RL_Deflection.ToString() + ";" + RL_EffectiveRadius.ToString() + ";" + RL_LateralLoad.ToString() + ";" + RL_LoadedRadius.ToString() + ";" + RL_LongitudinalLoad.ToString() + ";" + RL_SlipAngleRad.ToString() + ";" + RL_SlipAngleDeg.ToString() + ";" + RL_SlipRatio.ToString() + ";" + RL_TravelSpeed.ToString() + ";" + RL_VerticalLoad.ToString());
                        }
                    }

                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "RearRightWreckfestDebugLog.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "RearRightWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine("Race Time;Angular Velocity;Contact Length;Current Contact Brake Torque;Max Current Contact Brake Torque;Vertical Deflection;Effective Radius;Lateral Load;Loaded Radius;Longitudinal Load;Slip Angle Radians;Slip Angle Degrees;Slip Ratio;Travel Speed;Vertical Load");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "RearRightWreckfestDebugLog.txt"))
                        {
                            sw.WriteLine(RaceTime.ToString() + ";" + RR_AngularVelocity.ToString() + ";" + RR_ContactLength.ToString() + ";" + RR_CurrentContactBrakeTorque.ToString() + ";" + RR_CurrentContactBrakeTorqueMax + ";" + RR_Deflection.ToString() + ";" + RR_EffectiveRadius.ToString() + ";" + RR_LateralLoad.ToString() + ";" + RR_LoadedRadius.ToString() + ";" + RR_LongitudinalLoad.ToString() + ";" + RR_SlipAngleRad.ToString() + ";" + RR_SlipAngleDeg.ToString() + ";" + RR_SlipRatio.ToString() + ";" + RR_TravelSpeed.ToString() + ";" + RR_VerticalLoad.ToString());
                        }
                    }
                }
                if (String.IsNullOrEmpty(logInterval_textBox.Text))
                {
                    sleep = 50;
                }
                else
                {
                    sleep = Convert.ToInt32(logInterval_textBox.Text);
                }

                if (temperaturesFL.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateData(); });
                }
                else
                {
                    //....
                }
                Thread.Sleep(sleep);
            }
        }

        private void UpdateData()
        {
            
            temperaturesFL.Series["FLSeriesSurface"].Points.Clear();

            for (int i = 0; i < flsTempArray.Length - 1; ++i)
            {
                temperaturesFL.Series["FLSeriesSurface"].Points.AddY(flsTempArray[i]);
            }

            temperaturesFL.Series["FLSeriesInner"].Points.Clear();

            for (int i = 0; i < fliTempArray.Length - 1; ++i)
            {
                temperaturesFL.Series["FLSeriesInner"].Points.AddY(fliTempArray[i]);
            }

            temperaturesFR.Series["FRSeriesSurface"].Points.Clear();

            for (int i = 0; i < frsTempArray.Length - 1; ++i)
            {
                temperaturesFR.Series["FRSeriesSurface"].Points.AddY(frsTempArray[i]);
            }

            temperaturesFR.Series["FRSeriesInner"].Points.Clear();

            for (int i = 0; i < friTempArray.Length - 1; ++i)
            {
                temperaturesFR.Series["FRSeriesInner"].Points.AddY(friTempArray[i]);
            }

            temperaturesRL.Series["RLSeriesSurface"].Points.Clear();

            for (int i = 0; i < rlsTempArray.Length - 1; ++i)
            {
                temperaturesRL.Series["RLSeriesSurface"].Points.AddY(rlsTempArray[i]);
            }

            temperaturesRL.Series["RLSeriesInner"].Points.Clear();

            for (int i = 0; i < rliTempArray.Length - 1; ++i)
            {
                temperaturesRL.Series["RLSeriesInner"].Points.AddY(rliTempArray[i]);
            }

            temperaturesRR.Series["RRSeriesSurface"].Points.Clear();

            for (int i = 0; i < rrsTempArray.Length - 1; ++i)
            {
                temperaturesRR.Series["RRSeriesSurface"].Points.AddY(rrsTempArray[i]);
            }

            temperaturesRR.Series["RRSeriesInner"].Points.Clear();

            for (int i = 0; i < rriTempArray.Length - 1; ++i)
            {
                temperaturesRR.Series["RRSeriesInner"].Points.AddY(rriTempArray[i]);
            }
            
            // Chassis stuff
            CurrentSpeed.Text = speed.ToString();
            CurrentFrontLift.Text = frontLift.ToString();
            CurrentRearLift.Text = rearLift.ToString();

            //Tire data
            //Front left
            textBox_FL_AngularVelocity.Text = FL_AngularVelocity.ToString();
            textBox_FL_ContactLength.Text = FL_ContactLength.ToString();
            textBox_FL_CurrentContactBrakeTorque.Text = FL_CurrentContactBrakeTorque.ToString();
            //textBox_FL_MaxContactBrakeTorque.Text = FL_CurrentContactBrakeTorqueMax.ToString();
            textBox_FL_Deflection.Text = FL_Deflection.ToString();
            textBox_FL_EffectiveRadius.Text = FL_EffectiveRadius.ToString();
            textBox_FL_LateralLoad.Text = FL_LateralLoad.ToString();
            textBox_FL_LoadedRadius.Text = FL_LoadedRadius.ToString();
            textBox_FL_LongitudinalLoad.Text = FL_LongitudinalLoad.ToString();
            //textBox_FL_SlipAngleRad.Text = FL_SlipAngleRad.ToString();
            textBox_FL_SlipRatio.Text = FL_SlipRatio.ToString();
            textBox_FL_TravelSpeed.Text = FL_TravelSpeed.ToString();
            textBox_FL_VerticalLoad.Text = FL_VerticalLoad.ToString();
            textBox_FL_LateralFriction.Text = Math.Round((FL_LateralLoad / FL_VerticalLoad),5).ToString();
            textBox_FL_LongitudinalFriction.Text = Math.Round((FL_LongitudinalLoad / FL_VerticalLoad),5).ToString();
            textBox_FL_TreadTemperature.Text = Math.Round(flsTemp,2).ToString();
            textBox_FL_InnerTemperature.Text = Math.Round(fliTemp,2).ToString();
            textBox_FL_SlipAngleDeg.Text = Math.Round((FL_SlipAngleRad * (180 / 3.14159)),5).ToString();

            //Front right
            textBox_FR_AngularVelocity.Text = FR_AngularVelocity.ToString();
            textBox_FR_ContactLength.Text = FR_ContactLength.ToString();
            textBox_FR_CurrentContactBrakeTorque.Text = FR_CurrentContactBrakeTorque.ToString();
            //textBox_FR_MaxContactBrakeTorque.Text = FR_CurrentContactBrakeTorqueMax.ToString();
            textBox_FR_Deflection.Text = FR_Deflection.ToString();
            textBox_FR_EffectiveRadius.Text = FR_EffectiveRadius.ToString();
            textBox_FR_LateralLoad.Text = FR_LateralLoad.ToString();
            textBox_FR_LoadedRadius.Text = FR_LoadedRadius.ToString();
            textBox_FR_LongitudinalLoad.Text = FR_LongitudinalLoad.ToString();
            //textBox_FR_SlipAngleRad.Text = FR_SlipAngleRad.ToString();
            textBox_FR_SlipRatio.Text = FR_SlipRatio.ToString();
            textBox_FR_TravelSpeed.Text = FR_TravelSpeed.ToString();
            textBox_FR_VerticalLoad.Text = FR_VerticalLoad.ToString();
            textBox_FR_LateralFriction.Text = Math.Round((FR_LateralLoad / FR_VerticalLoad), 5).ToString();
            textBox_FR_LongitudinalFriction.Text = Math.Round((FR_LongitudinalLoad / FR_VerticalLoad), 5).ToString();
            textBox_FR_TreadTemperature.Text = Math.Round(frsTemp, 2).ToString();
            textBox_FR_InnerTemperature.Text = Math.Round(friTemp, 2).ToString();
            textBox_FR_SlipAngleDeg.Text = Math.Round((FR_SlipAngleRad * (180 / 3.14159)), 5).ToString();

            //Rear left
            textBox_RL_AngularVelocity.Text = RL_AngularVelocity.ToString();
            textBox_RL_ContactLength.Text = RL_ContactLength.ToString();
            textBox_RL_CurrentContactBrakeTorque.Text = RL_CurrentContactBrakeTorque.ToString();
            //textBox_RL_MaxContactBrakeTorque.Text = RL_CurrentContactBrakeTorqueMax.ToString();
            textBox_RL_Deflection.Text = RL_Deflection.ToString();
            textBox_RL_EffectiveRadius.Text = RL_EffectiveRadius.ToString();
            textBox_RL_LateralLoad.Text = RL_LateralLoad.ToString();
            textBox_RL_LoadedRadius.Text = RL_LoadedRadius.ToString();
            textBox_RL_LongitudinalLoad.Text = RL_LongitudinalLoad.ToString();
            //textBox_RL_SlipAngleRad.Text = RL_SlipAngleRad.ToString();
            textBox_RL_SlipRatio.Text = RL_SlipRatio.ToString();
            textBox_RL_TravelSpeed.Text = RL_TravelSpeed.ToString();
            textBox_RL_VerticalLoad.Text = RL_VerticalLoad.ToString();
            textBox_RL_LateralFriction.Text = Math.Round((RL_LateralLoad / RL_VerticalLoad), 5).ToString();
            textBox_RL_LongitudinalFriction.Text = Math.Round((RL_LongitudinalLoad / RL_VerticalLoad), 5).ToString();
            textBox_RL_TreadTemperature.Text = Math.Round(rlsTemp, 2).ToString();
            textBox_RL_InnerTemperature.Text = Math.Round(rliTemp, 2).ToString();
            textBox_RL_SlipAngleDeg.Text = Math.Round((RL_SlipAngleRad * (180 / 3.14159)), 5).ToString();

            //Rear right
            textBox_RR_AngularVelocity.Text = RR_AngularVelocity.ToString();
            textBox_RR_ContactLength.Text = RR_ContactLength.ToString();
            textBox_RR_CurrentContactBrakeTorque.Text = RR_CurrentContactBrakeTorque.ToString();
            //textBox_RR_MaxContactBrakeTorque.Text = RR_CurrentContactBrakeTorqueMax.ToString();
            textBox_RR_Deflection.Text = RR_Deflection.ToString();
            textBox_RR_EffectiveRadius.Text = RR_EffectiveRadius.ToString();
            textBox_RR_LateralLoad.Text = RR_LateralLoad.ToString();
            textBox_RR_LoadedRadius.Text = RR_LoadedRadius.ToString();
            textBox_RR_LongitudinalLoad.Text = RR_LongitudinalLoad.ToString();
            //textBox_RR_SlipAngleRad.Text = RR_SlipAngleRad.ToString();
            textBox_RR_SlipRatio.Text = RR_SlipRatio.ToString();
            textBox_RR_TravelSpeed.Text = RR_TravelSpeed.ToString();
            textBox_RR_VerticalLoad.Text = RR_VerticalLoad.ToString();
            textBox_RR_LateralFriction.Text = Math.Round((RR_LateralLoad / RR_VerticalLoad), 5).ToString();
            textBox_RR_LongitudinalFriction.Text = Math.Round((RR_LongitudinalLoad / RR_VerticalLoad), 5).ToString();
            textBox_RR_TreadTemperature.Text = Math.Round(rrsTemp, 2).ToString();
            textBox_RR_InnerTemperature.Text = Math.Round(rriTemp, 2).ToString();
            textBox_RR_SlipAngleDeg.Text = Math.Round((RR_SlipAngleRad * (180 / 3.14159)), 5).ToString();

            

            //string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

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
            if (String.IsNullOrEmpty(logInterval_textBox.Text))
            {
                sleep = 50;
            }
            else
            {
                sleep = Convert.ToInt32(logInterval_textBox.Text);
            }
        }

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

        private void Start_Log_Click(object sender, EventArgs e)
        {
            logging = true;

            if (String.IsNullOrEmpty(logInterval_textBox.Text))
            {
                sleep = 50;
            }
            else
            {
                string sLogBoxRead = logInterval_textBox.Text;
                int iLogBoxRead = Convert.ToInt32(sLogBoxRead);
                sleep = iLogBoxRead;
            }
        }

        private void Stop_Log_Click(object sender, EventArgs e)
        {
            logging = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void SpeedPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox72_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_AngularVelocity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_TreadTemperature_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_InnerTemperature_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_TireDeflection_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_LoadedRadius_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_EffectiveRadius_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_CurrentContactBrakeTorque_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_MaxContactBrakeTorque_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_VerticalLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_LateralLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_LongitudinalLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_SlipAngleRad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_SlipAngleDeg_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_SlipRatio_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_ContactLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_TravelSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_LateralFriction_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_FL_LongitudinalFriction_TextChanged(object sender, EventArgs e)
        {

        }
    }
}