﻿using System;
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
using System.Globalization;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace Physics_Data_Debug
{
    public partial class TireSettings : Form
    {
        public TireSettings()
        {
            InitializeComponent();
        }

        private float FL_TireRadius;
        private float FL_TireWidth;
        private float FL_ThermalAirTransfer;
        private float FL_ThermalInnerTransfer;
        private float FL_TireSpringRate;
        private float FL_TireDamperRate;
        private float FL_TireMaxDeflection;
        private float FL_TireMass;
        private float FL_MomentOfInertia;

        private float FR_TireRadius;
        private float FR_TireWidth;
        private float FR_ThermalAirTransfer;
        private float FR_ThermalInnerTransfer;
        private float FR_TireSpringRate;
        private float FR_TireDamperRate;
        private float FR_TireMaxDeflection;
        private float FR_TireMass;
        private float FR_MomentOfInertia;

        private float RL_TireRadius;
        private float RL_TireWidth;
        private float RL_ThermalAirTransfer;
        private float RL_ThermalInnerTransfer;
        private float RL_TireSpringRate;
        private float RL_TireDamperRate;
        private float RL_TireMaxDeflection;
        private float RL_TireMass;
        private float RL_MomentOfInertia;

        private float RR_TireRadius;
        private float RR_TireWidth;
        private float RR_ThermalAirTransfer;
        private float RR_ThermalInnerTransfer;
        private float RR_TireSpringRate;
        private float RR_TireDamperRate;
        private float RR_TireMaxDeflection;
        private float RR_TireMass;
        private float RR_MomentOfInertia;


        private void TireSettings_Load(object sender, EventArgs e)
        {
            Live_Data.TireSettingsOpen = true;
            readAndWriteData();
        }

        private void writeTireData()
        {
            Process p = Process.GetProcessesByName("Wreckfest_x64").FirstOrDefault();
            if (p == null) return;

            Memory.Win64.MemoryHelper64 helper = new Memory.Win64.MemoryHelper64(p);

            //Base Addres for Tire data
            ulong baseAddr = helper.GetBaseAddress(Live_Data.baseAddrTire + Live_Data.baseAddrUpdt - Live_Data.baseAddrDodt);

            //Tire Data pointers
            //Front Left
            int[] FL_MomentOfInertiaOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetMomentOfInertia };
            int[] FL_TireMassOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMass };
            int[] FL_TireRadiusOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireRadius };
            int[] FL_TireWidthOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireWidth };
            int[] FL_TireSpringRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireSpringRate };
            int[] FL_TireDamperRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireDamperRate };
            int[] FL_TireMaxDeflectionOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMaxDeflection };
            int[] FL_ThermalAirTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalAirTransfer };
            int[] FL_ThermalInnerTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalInnerTransfer };

            int[] FR_MomentOfInertiaOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetMomentOfInertia + Live_Data.OffsetFRTire };
            int[] FR_TireMassOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMass + Live_Data.OffsetFRTire };
            int[] FR_TireRadiusOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireRadius + Live_Data.OffsetFRTire };
            int[] FR_TireWidthOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireWidth + Live_Data.OffsetFRTire };
            int[] FR_TireSpringRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireSpringRate + Live_Data.OffsetFRTire };
            int[] FR_TireDamperRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireDamperRate + Live_Data.OffsetFRTire };
            int[] FR_TireMaxDeflectionOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMaxDeflection + Live_Data.OffsetFRTire };
            int[] FR_ThermalAirTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalAirTransfer + Live_Data.OffsetFRTire };
            int[] FR_ThermalInnerTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalInnerTransfer + Live_Data.OffsetFRTire };

            int[] RL_MomentOfInertiaOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetMomentOfInertia + Live_Data.OffsetRLTire };
            int[] RL_TireMassOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMass + Live_Data.OffsetRLTire };
            int[] RL_TireRadiusOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireRadius + Live_Data.OffsetRLTire };
            int[] RL_TireWidthOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireWidth + Live_Data.OffsetRLTire };
            int[] RL_TireSpringRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireSpringRate + Live_Data.OffsetRLTire };
            int[] RL_TireDamperRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireDamperRate + Live_Data.OffsetRLTire };
            int[] RL_TireMaxDeflectionOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMaxDeflection + Live_Data.OffsetRLTire };
            int[] RL_ThermalAirTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalAirTransfer + Live_Data.OffsetRLTire };
            int[] RL_ThermalInnerTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalInnerTransfer + Live_Data.OffsetRLTire };

            int[] RR_MomentOfInertiaOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetMomentOfInertia + Live_Data.OffsetRRTire };
            int[] RR_TireMassOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMass + Live_Data.OffsetRRTire };
            int[] RR_TireRadiusOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireRadius + Live_Data.OffsetRRTire };
            int[] RR_TireWidthOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireWidth + Live_Data.OffsetRRTire };
            int[] RR_TireSpringRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireSpringRate + Live_Data.OffsetRRTire };
            int[] RR_TireDamperRateOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireDamperRate + Live_Data.OffsetRRTire };
            int[] RR_TireMaxDeflectionOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetTireMaxDeflection + Live_Data.OffsetRRTire };
            int[] RR_ThermalAirTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalAirTransfer + Live_Data.OffsetRRTire };
            int[] RR_ThermalInnerTransferOffsets = { Live_Data.OffsetTireData, Live_Data.OffsetThermalInnerTransfer + Live_Data.OffsetRRTire };

            ulong FL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TireMassOffsets);
            ulong FL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TireRadiusOffsets);
            ulong FL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TireWidthOffsets);
            ulong FL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TireSpringRateOffsets);
            ulong FL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TireDamperRateOffsets);
            ulong FL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_TireMaxDeflectionOffsets);
            ulong FL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_ThermalAirTransferOffsets);
            ulong FL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_ThermalInnerTransferOffsets);
            ulong FL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FL_MomentOfInertiaOffsets);

            ulong FR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TireMassOffsets);
            ulong FR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TireRadiusOffsets);
            ulong FR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TireWidthOffsets);
            ulong FR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TireSpringRateOffsets);
            ulong FR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TireDamperRateOffsets);
            ulong FR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_TireMaxDeflectionOffsets);
            ulong FR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_ThermalAirTransferOffsets);
            ulong FR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_ThermalInnerTransferOffsets);
            ulong FR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, FR_MomentOfInertiaOffsets);

            ulong RL_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TireMassOffsets);
            ulong RL_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TireRadiusOffsets);
            ulong RL_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TireWidthOffsets);
            ulong RL_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TireSpringRateOffsets);
            ulong RL_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TireDamperRateOffsets);
            ulong RL_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_TireMaxDeflectionOffsets);
            ulong RL_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_ThermalAirTransferOffsets);
            ulong RL_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_ThermalInnerTransferOffsets);
            ulong RL_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RL_MomentOfInertiaOffsets);

            ulong RR_TireMass_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TireMassOffsets);
            ulong RR_TireRadius_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TireRadiusOffsets);
            ulong RR_TireWidth_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TireWidthOffsets);
            ulong RR_TireSpringRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TireSpringRateOffsets);
            ulong RR_TireDamperRate_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TireDamperRateOffsets);
            ulong RR_TireMaxDeflection_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_TireMaxDeflectionOffsets);
            ulong RR_ThermalAirTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_ThermalAirTransferOffsets);
            ulong RR_ThermalInnerTransfer_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_ThermalInnerTransferOffsets);
            ulong RR_MomentOfInertia_TargetAddr = Memory.Utils.MemoryUtils.OffsetCalculator(helper, baseAddr, RR_MomentOfInertiaOffsets);

            helper.WriteMemory<float>(FL_MomentOfInertia_TargetAddr, FL_MomentOfInertia);
            helper.WriteMemory<float>(FL_TireMass_TargetAddr, FL_TireMass);
            helper.WriteMemory<float>(FL_TireRadius_TargetAddr, FL_TireRadius);
            helper.WriteMemory<float>(FL_TireWidth_TargetAddr, FL_TireWidth);
            helper.WriteMemory<float>(FL_TireSpringRate_TargetAddr, FL_TireSpringRate);
            helper.WriteMemory<float>(FL_TireDamperRate_TargetAddr, FL_TireDamperRate);
            helper.WriteMemory<float>(FL_TireMaxDeflection_TargetAddr, FL_TireMaxDeflection);
            helper.WriteMemory<float>(FL_ThermalAirTransfer_TargetAddr, FL_ThermalAirTransfer);
            helper.WriteMemory<float>(FL_ThermalInnerTransfer_TargetAddr, FL_ThermalInnerTransfer);

            helper.WriteMemory<float>(FR_MomentOfInertia_TargetAddr, FR_MomentOfInertia);
            helper.WriteMemory<float>(FR_TireMass_TargetAddr, FR_TireMass);
            helper.WriteMemory<float>(FR_TireRadius_TargetAddr, FR_TireRadius);
            helper.WriteMemory<float>(FR_TireWidth_TargetAddr, FR_TireWidth);
            helper.WriteMemory<float>(FR_TireSpringRate_TargetAddr, FR_TireSpringRate);
            helper.WriteMemory<float>(FR_TireDamperRate_TargetAddr, FR_TireDamperRate);
            helper.WriteMemory<float>(FR_TireMaxDeflection_TargetAddr, FR_TireMaxDeflection);
            helper.WriteMemory<float>(FR_ThermalAirTransfer_TargetAddr, FR_ThermalAirTransfer);
            helper.WriteMemory<float>(FR_ThermalInnerTransfer_TargetAddr, FR_ThermalInnerTransfer);

            helper.WriteMemory<float>(RL_MomentOfInertia_TargetAddr, RL_MomentOfInertia);
            helper.WriteMemory<float>(RL_TireMass_TargetAddr, RL_TireMass);
            helper.WriteMemory<float>(RL_TireRadius_TargetAddr, RL_TireRadius);
            helper.WriteMemory<float>(RL_TireWidth_TargetAddr, RL_TireWidth);
            helper.WriteMemory<float>(RL_TireSpringRate_TargetAddr, RL_TireSpringRate);
            helper.WriteMemory<float>(RL_TireDamperRate_TargetAddr, RL_TireDamperRate);
            helper.WriteMemory<float>(RL_TireMaxDeflection_TargetAddr, RL_TireMaxDeflection);
            helper.WriteMemory<float>(RL_ThermalAirTransfer_TargetAddr, RL_ThermalAirTransfer);
            helper.WriteMemory<float>(RL_ThermalInnerTransfer_TargetAddr, RL_ThermalInnerTransfer);

            helper.WriteMemory<float>(RR_MomentOfInertia_TargetAddr, RR_MomentOfInertia);
            helper.WriteMemory<float>(RR_TireMass_TargetAddr, RR_TireMass);
            helper.WriteMemory<float>(RR_TireRadius_TargetAddr, RR_TireRadius);
            helper.WriteMemory<float>(RR_TireWidth_TargetAddr, RR_TireWidth);
            helper.WriteMemory<float>(RR_TireSpringRate_TargetAddr, RR_TireSpringRate);
            helper.WriteMemory<float>(RR_TireDamperRate_TargetAddr, RR_TireDamperRate);
            helper.WriteMemory<float>(RR_TireMaxDeflection_TargetAddr, RR_TireMaxDeflection);
            helper.WriteMemory<float>(RR_ThermalAirTransfer_TargetAddr, RR_ThermalAirTransfer);
            helper.WriteMemory<float>(RR_ThermalInnerTransfer_TargetAddr, RR_ThermalInnerTransfer);
        }

        private void readAndWriteData()
        {
            FL_MomentOfInertia = Convert.ToSingle(Live_Data.FL_MomentOfInertia/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_TireMass = Convert.ToSingle(Live_Data.FL_TireMass/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_TireRadius = Convert.ToSingle(Live_Data.FL_TireRadius/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_TireWidth = Convert.ToSingle(Live_Data.FL_TireWidth/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_TireSpringRate = Convert.ToSingle(Live_Data.FL_TireSpringRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_TireDamperRate = Convert.ToSingle(Live_Data.FL_TireDamperRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_TireMaxDeflection = Convert.ToSingle(Live_Data.FL_TireMaxDeflection/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_ThermalAirTransfer = Convert.ToSingle(Live_Data.FL_ThermalAirTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FL_ThermalInnerTransfer = Convert.ToSingle(Live_Data.FL_ThermalInnerTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);

            FR_MomentOfInertia = Convert.ToSingle(Live_Data.FR_MomentOfInertia/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_TireMass = Convert.ToSingle(Live_Data.FR_TireMass/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_TireRadius = Convert.ToSingle(Live_Data.FR_TireRadius/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_TireWidth = Convert.ToSingle(Live_Data.FR_TireWidth/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_TireSpringRate = Convert.ToSingle(Live_Data.FR_TireSpringRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_TireDamperRate = Convert.ToSingle(Live_Data.FR_TireDamperRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_TireMaxDeflection = Convert.ToSingle(Live_Data.FR_TireMaxDeflection/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_ThermalAirTransfer = Convert.ToSingle(Live_Data.FR_ThermalAirTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);
            FR_ThermalInnerTransfer = Convert.ToSingle(Live_Data.FR_ThermalInnerTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);

            RL_MomentOfInertia = Convert.ToSingle(Live_Data.RL_MomentOfInertia/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_TireMass = Convert.ToSingle(Live_Data.RL_TireMass/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_TireRadius = Convert.ToSingle(Live_Data.RL_TireRadius/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_TireWidth = Convert.ToSingle(Live_Data.RL_TireWidth/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_TireSpringRate = Convert.ToSingle(Live_Data.RL_TireSpringRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_TireDamperRate = Convert.ToSingle(Live_Data.RL_TireDamperRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_TireMaxDeflection = Convert.ToSingle(Live_Data.RL_TireMaxDeflection/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_ThermalAirTransfer = Convert.ToSingle(Live_Data.RL_ThermalAirTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RL_ThermalInnerTransfer = Convert.ToSingle(Live_Data.RL_ThermalInnerTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);

            RR_MomentOfInertia = Convert.ToSingle(Live_Data.RR_MomentOfInertia/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_TireMass = Convert.ToSingle(Live_Data.RR_TireMass/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_TireRadius = Convert.ToSingle(Live_Data.RR_TireRadius/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_TireWidth = Convert.ToSingle(Live_Data.RR_TireWidth/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_TireSpringRate = Convert.ToSingle(Live_Data.RR_TireSpringRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_TireDamperRate = Convert.ToSingle(Live_Data.RR_TireDamperRate/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_TireMaxDeflection = Convert.ToSingle(Live_Data.RR_TireMaxDeflection/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_ThermalAirTransfer = Convert.ToSingle(Live_Data.RR_ThermalAirTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);
            RR_ThermalInnerTransfer = Convert.ToSingle(Live_Data.RR_ThermalInnerTransfer/*, System.Globalization.CultureInfo.InvariantCulture*/);

            textBoxFLTireWrite();
            textBoxFRTireWrite();
            textBoxRLTireWrite();
            textBoxRRTireWrite();
        }

        private void textBoxFLTireWrite()
        {
            textBox_FL_Radius.Text = FL_TireRadius.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_Width.Text = FL_TireWidth.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_ThermalAirTransfer.Text = FL_ThermalAirTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_ThermalInnerTransfer.Text = FL_ThermalInnerTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_SpringRate.Text = FL_TireSpringRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_DamperRate.Text = FL_TireDamperRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_MaxDeflection.Text = FL_TireMaxDeflection.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_Mass.Text = FL_TireMass.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FL_MomentOfInertia.Text = FL_MomentOfInertia.ToString(CultureInfo.GetCultureInfo("en-US"));
        }
        private void textBoxFRTireWrite()
        {
            textBox_FR_Radius.Text = FR_TireRadius.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_Width.Text = FR_TireWidth.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_ThermalAirTransfer.Text = FR_ThermalAirTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_ThermalInnerTransfer.Text = FR_ThermalInnerTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_SpringRate.Text = FR_TireSpringRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_DamperRate.Text = FR_TireDamperRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_MaxDeflection.Text = FR_TireMaxDeflection.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_Mass.Text = FR_TireMass.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_FR_MomentOfInertia.Text = FR_MomentOfInertia.ToString(CultureInfo.GetCultureInfo("en-US"));
        }
        private void textBoxRLTireWrite()
        {
            textBox_RL_Radius.Text = RL_TireRadius.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_Width.Text = RL_TireWidth.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_ThermalAirTransfer.Text = RL_ThermalAirTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_ThermalInnerTransfer.Text = RL_ThermalInnerTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_SpringRate.Text = RL_TireSpringRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_DamperRate.Text = RL_TireDamperRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_MaxDeflection.Text = RL_TireMaxDeflection.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_Mass.Text = RL_TireMass.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RL_MomentOfInertia.Text = RL_MomentOfInertia.ToString(CultureInfo.GetCultureInfo("en-US"));
        }
        private void textBoxRRTireWrite()
        {
            textBox_RR_Radius.Text = RR_TireRadius.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_Width.Text = RR_TireWidth.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_ThermalAirTransfer.Text = RR_ThermalAirTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_ThermalInnerTransfer.Text = RR_ThermalInnerTransfer.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_SpringRate.Text = RR_TireSpringRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_DamperRate.Text = RR_TireDamperRate.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_MaxDeflection.Text = RR_TireMaxDeflection.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_Mass.Text = RR_TireMass.ToString(CultureInfo.GetCultureInfo("en-US"));
            textBox_RR_MomentOfInertia.Text = RR_MomentOfInertia.ToString(CultureInfo.GetCultureInfo("en-US"));
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //First_All_Data_Logger_Page fadlp = new First_All_Data_Logger_Page();
            //fadlp.Show();
            this.Close();
        }

        private void ReadValues_Click(object sender, EventArgs e)
        {
            readAndWriteData();
        }

        private void ParseTireValues()
        {
            float fls1;
            float fls2;
            float fls3;
            float fls4;
            float fls5;
            float fls6;
            float fls7;
            float fls8;
            float fls9;

            float frs1;
            float frs2;
            float frs3;
            float frs4;
            float frs5;
            float frs6;
            float frs7;
            float frs8;
            float frs9;

            float rls1;
            float rls2;
            float rls3;
            float rls4;
            float rls5;
            float rls6;
            float rls7;
            float rls8;
            float rls9;

            float rrs1;
            float rrs2;
            float rrs3;
            float rrs4;
            float rrs5;
            float rrs6;
            float rrs7;
            float rrs8;
            float rrs9;

            if (float.TryParse(textBox_FL_Radius.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls1) == true
                && float.TryParse(textBox_FL_Width.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls2) == true
                && float.TryParse(textBox_FL_ThermalAirTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls3) == true
                && float.TryParse(textBox_FL_ThermalInnerTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls4) == true
                && float.TryParse(textBox_FL_SpringRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls5) == true
                && float.TryParse(textBox_FL_DamperRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls6) == true
                && float.TryParse(textBox_FL_MaxDeflection.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls7) == true
                && float.TryParse(textBox_FL_Mass.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls8) == true
                && float.TryParse(textBox_FL_MomentOfInertia.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out fls9) == true)
            {
                FL_TireRadius = float.Parse(textBox_FL_Radius.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_TireWidth = float.Parse(textBox_FL_Width.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_ThermalAirTransfer = float.Parse(textBox_FL_ThermalAirTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_ThermalInnerTransfer = float.Parse(textBox_FL_ThermalInnerTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_TireSpringRate = float.Parse(textBox_FL_SpringRate.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_TireDamperRate = float.Parse(textBox_FL_DamperRate.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_TireMaxDeflection = float.Parse(textBox_FL_MaxDeflection.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_TireMass = float.Parse(textBox_FL_Mass.Text, CultureInfo.GetCultureInfo("en-US"));
                FL_MomentOfInertia = float.Parse(textBox_FL_MomentOfInertia.Text, CultureInfo.GetCultureInfo("en-US"));

                writeTireData();
                textBoxFLTireWrite();
            }

            if (float.TryParse(textBox_FR_Radius.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs1) == true
                && float.TryParse(textBox_FR_Width.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs2) == true
                && float.TryParse(textBox_FR_ThermalAirTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs3) == true
                && float.TryParse(textBox_FR_ThermalInnerTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs4) == true
                && float.TryParse(textBox_FR_SpringRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs5) == true
                && float.TryParse(textBox_FR_DamperRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs6) == true
                && float.TryParse(textBox_FR_MaxDeflection.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs7) == true
                && float.TryParse(textBox_FR_Mass.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs8) == true
                && float.TryParse(textBox_FR_MomentOfInertia.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frs9) == true)
            {
                FR_TireRadius = float.Parse(textBox_FR_Radius.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_TireWidth = float.Parse(textBox_FR_Width.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_ThermalAirTransfer = float.Parse(textBox_FR_ThermalAirTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_ThermalInnerTransfer = float.Parse(textBox_FR_ThermalInnerTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_TireSpringRate = float.Parse(textBox_FR_SpringRate.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_TireDamperRate = float.Parse(textBox_FR_DamperRate.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_TireMaxDeflection = float.Parse(textBox_FR_MaxDeflection.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_TireMass = float.Parse(textBox_FR_Mass.Text, CultureInfo.GetCultureInfo("en-US"));
                FR_MomentOfInertia = float.Parse(textBox_FR_MomentOfInertia.Text, CultureInfo.GetCultureInfo("en-US"));

                writeTireData();
                textBoxFRTireWrite();
            }

            if (float.TryParse(textBox_RL_Radius.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls1) == true
                && float.TryParse(textBox_RL_Width.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls2) == true
                && float.TryParse(textBox_RL_ThermalAirTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls3) == true
                && float.TryParse(textBox_RL_ThermalInnerTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls4) == true
                && float.TryParse(textBox_RL_SpringRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls5) == true
                && float.TryParse(textBox_RL_DamperRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls6) == true
                && float.TryParse(textBox_RL_MaxDeflection.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls7) == true
                && float.TryParse(textBox_RL_Mass.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls8) == true
                && float.TryParse(textBox_RL_MomentOfInertia.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rls9) == true)
            {
                RL_TireRadius = float.Parse(textBox_RL_Radius.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_TireWidth = float.Parse(textBox_RL_Width.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_ThermalAirTransfer = float.Parse(textBox_RL_ThermalAirTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_ThermalInnerTransfer = float.Parse(textBox_RL_ThermalInnerTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_TireSpringRate = float.Parse(textBox_RL_SpringRate.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_TireDamperRate = float.Parse(textBox_RL_DamperRate.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_TireMaxDeflection = float.Parse(textBox_RL_MaxDeflection.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_TireMass = float.Parse(textBox_RL_Mass.Text, CultureInfo.GetCultureInfo("en-US"));
                RL_MomentOfInertia = float.Parse(textBox_RL_MomentOfInertia.Text, CultureInfo.GetCultureInfo("en-US"));

                writeTireData();
                textBoxRLTireWrite();
            }

            if (float.TryParse(textBox_RR_Radius.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs1) == true
                && float.TryParse(textBox_RR_Width.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs2) == true
                && float.TryParse(textBox_RR_ThermalAirTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs3) == true
                && float.TryParse(textBox_RR_ThermalInnerTransfer.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs4) == true
                && float.TryParse(textBox_RR_SpringRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs5) == true
                && float.TryParse(textBox_RR_DamperRate.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs6) == true
                && float.TryParse(textBox_RR_MaxDeflection.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs7) == true
                && float.TryParse(textBox_RR_Mass.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs8) == true
                && float.TryParse(textBox_RR_MomentOfInertia.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out rrs9) == true)
            {
                RR_TireRadius = float.Parse(textBox_RR_Radius.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_TireWidth = float.Parse(textBox_RR_Width.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_ThermalAirTransfer = float.Parse(textBox_RR_ThermalAirTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_ThermalInnerTransfer = float.Parse(textBox_RR_ThermalInnerTransfer.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_TireSpringRate = float.Parse(textBox_RR_SpringRate.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_TireDamperRate = float.Parse(textBox_RR_DamperRate.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_TireMaxDeflection = float.Parse(textBox_RR_MaxDeflection.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_TireMass = float.Parse(textBox_RR_Mass.Text, CultureInfo.GetCultureInfo("en-US"));
                RR_MomentOfInertia = float.Parse(textBox_RR_MomentOfInertia.Text, CultureInfo.GetCultureInfo("en-US"));
                writeTireData();
                textBoxRRTireWrite();
            }
        }
        private void SetValues_Click(object sender, EventArgs e)
        {
            ParseTireValues();
        }

        private void CheckKeyIsNumberOrDecimalPoint(KeyPressEventArgs e)
        {
            char ch1 = e.KeyChar;

            if (!Char.IsDigit(ch1) && ch1 != 8 && ch1 != 46/* && ch1 != 44*/)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_FL_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FL_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void textBox_FR_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_FR_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_RL_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RL_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_RR_Radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_ThermalAirTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_ThermalInnerTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_SpringRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_DamperRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_MaxDeflection_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_Mass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void textBox_RR_MomentOfInertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyIsNumberOrDecimalPoint(e);
        }

        private void TireSettings_Close(object sender, FormClosedEventArgs e)
        {
            Live_Data.TireSettingsOpen = false;
        }
    }
}