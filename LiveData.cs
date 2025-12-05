using Memory.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Physics_Data_Debug
{
    class LiveData
    {
        public static bool Logging { get; set; } = false;
        public static bool LogSettingsOpen { get; set; } = false;
        public static bool TireSettingsOpen { get; set; } = false;
        public static bool TemperaturesChartOpen { get; set; } = false;
        public static bool SuspensionSettingsOpen { get; set; } = false;
        public static bool GForceOpen { get; set; } = false;
        public static bool _4WheelsOpen { get; set; } = false;
        public static double RadDeg { get; } = 180 / Math.PI;
        public static double KilometersPerHourToMetersPerSec { get; } = 1 / (double)3.6;
        public static float g { get; } = 9.80665f;
        public static int TickInterval = 50;

        #region Data
        public static int None { get; set; } = 1;
        public static int RaceTime { get; set; }
        public static List<byte[]> Body_RotationData { get; set; }
        public static List<byte[]> Body_AccelData { get; set; }
        public static List<byte[]> Body_AeroData { get; set; }
        public static List<byte[]> Powertrain_EngineData { get; set; }
        public static List<byte[]> Powertrain_DifferentialPrimaryAxleData { get; set; }
        public static List<byte[]> Powertrain_DifferentialSecondaryAxleData { get; set; }
        public static List<byte[]> FL_TireData { get; set; }
        public static List<byte[]> FL_SuspensionData { get; set; }
        public static List<byte[]> FR_TireData { get; set; }
        public static List<byte[]> FR_SuspensionData { get; set; }
        public static List<byte[]> RL_TireData { get; set; }
        public static List<byte[]> RL_SuspensionData { get; set; }
        public static List<byte[]> RR_TireData { get; set; }
        public static List<byte[]> RR_SuspensionData { get; set; }
        #endregion

        public static Process Process;
        public static Memory.Win64.MemoryHelper64 Helper { get; set; }

        public static readonly int[] RaceTimeArray = new int[3];
        public static readonly int[] TickTimeArray = new int[3];
        public static int ElapsedTime = 0;

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
        public static List<List<DataItem>> FullDataList { get; set; } = new List<List<DataItem>>();
        public static dynamic GetFullListDataValue(Enum prefix, Enum dataValueToFind)
        {
            //dynamic was float
            string s = prefix + "_";
            int index = Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix);
            return FullDataList[index][FullDataList[index].FindIndex(r => r.Name == s + dataValueToFind)].Value;
        }
        private static dynamic GetDataValue<T>(List<byte[]> data, Enum dataStart, Enum dataValueToFind)
        {
            //T was float
            int size = 4;//ObjectType.GetSize<T>();
            if(typeof(T) == typeof(float))//float
            { return BitConverter.ToSingle(data[(Convert.ToInt32(dataValueToFind) - Convert.ToInt32(dataStart)) / size], 0); }
            else//Int32
            { return BitConverter.ToInt32(data[(Convert.ToInt32(dataValueToFind) - Convert.ToInt32(dataStart)) / size], 0); }
        }
        public static string ValueString(Enum prefix, Enum dataValue, int roundDigits = 9, string preText = "", string afterText = "")
        {
            return preText + Math.Round(GetFullListDataValue(prefix, dataValue), roundDigits).ToString(CultureInfo.GetCultureInfo("en-US")) + afterText;
        }
        public static void SetValueInTB(TextBox tB, Enum prefix, Enum dataValue, int roundDigits = 9, string preText = "", string suffText = "")
        {
            tB.Text = ValueString(prefix, dataValue, roundDigits);
        }
        public static int GetElapsedTime()
        {
            RaceTimeArray[RaceTimeArray.Length - 1] = RaceTime;
            Array.Copy(RaceTimeArray, 1, RaceTimeArray, 0, RaceTimeArray.Length - 1);
            return RaceTimeArray[1] - RaceTimeArray[0];
        }
        public static void GetData(ulong baseAddrUpdt)
        {
            //Dictionary<WF_Prefix, DataItem> Dict = WF_Dictionary.DefaultWF1Dictionary;
            if (Process == null)
            { return; }
            Helper = new Memory.Win64.MemoryHelper64(Process);
            #region Read Race Time
            RaceTime = GetRawData<int>(Helper, (ulong)BaseAddress.RaceTime, baseAddrUpdt, new int[] { (int)WF_TimeDataOffset.RaceTime });
            //Time interval between the last tick. It only naturally works when the race is going but pretty accurate then and no interference every second.
            ElapsedTime = GetElapsedTime();
            #endregion

            #region Read Location, Heading, Accel, Lifts and Drag
            Body_RotationData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.BodyLocationHeading, baseAddrUpdt, (int)WF_BodyRotationSide.AllSides, new int[] { (int)WF_BodyRotationChunks.Offset1}, (int)WF_BodyRotationChunks.DataStart, (int)WF_BodyRotationChunks.ChunkSize);//Get raw data...
            Matrix4x4 transformMatrixBody = TransformMatrixBody(Body_RotationData, WF_BodyRotationChunks.DataStart);
            Body_RotationData = Body_RotationData.Concat(GetCalculatedRotationData(transformMatrixBody)).ToList();//...then Concat (expand) it with calculated data;
            Body_AccelData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Acceleration, baseAddrUpdt, (int)WF_BodyAccelSide.AllSides, new int[] { }, (int)WF_BodyAccelDataChunks.DataStart, (int)WF_BodyAccelDataChunks.ChunkSize);//Get raw data...
            Body_AccelData = Body_AccelData.Concat(GetCalculatedAccelData(transformMatrixBody, Body_AccelData)).ToList();//...then Concat (expand) it with calculated data;
            Body_AeroData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Aero, baseAddrUpdt, (int)WF_AeroSide.AllSides, new int[] { }, (int)WF_AeroDataChunks.DataStart, (int)WF_AeroDataChunks.ChunkSize);//Get raw data...
            Body_AeroData = Body_AeroData.Concat(GetCalculatedAeroData(transformMatrixBody)).ToList();//...then Concat (expand) it with calculated data;
            #endregion

            #region Read Speed, Engine Torque and Differential
            Powertrain_EngineData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Engine, baseAddrUpdt, (int)WF_EngineSide.AllSides, new int[] { }, (int)WF_EngineDataChunks.DataStart, (int)WF_EngineDataChunks.ChunkSize);//Get raw data...
            Powertrain_EngineData = Powertrain_EngineData.Concat(GetCalculatedEngineData(Powertrain_EngineData)).ToList();//...then Concat (expand) it with calculated data;
            Powertrain_DifferentialPrimaryAxleData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Differential, baseAddrUpdt, (int)WF_DifferentialSide.Left, new int[] { }, (int)WF_DifferentialDataChunks.DataStart, (int)WF_DifferentialDataChunks.ChunkSize);
            //Powertrain_DifferentialSecondaryAxleData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Differential, baseAddrUpdt, (int)WF_DifferentialSide.SecondaryAxle, new int[] { }, (int)WF_DifferentialDataChunks.DataStart, (int)WF_DifferentialDataChunks.ChunkSize);
            #endregion

            #region Read Tire Data
            FL_TireData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Tire, baseAddrUpdt, (int)WF_TireSide.FL, new int[] { (int)WF_TireDataChunks.Offset1}, (int)WF_TireDataChunks.DataStart, (int)WF_TireDataChunks.ChunkSize);//Get raw data...
            FL_TireData = FL_TireData.Concat(GetCalcuatedTireData(FL_TireData)).ToList();//...then Concat (expand) it with calculated data
            FL_SuspensionData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Suspension, baseAddrUpdt, (int)WF_SuspensionSideOffset.FL, new int[] { }, (int)WF_SuspensionChunks.DataStart, (int)WF_SuspensionChunks.ChunkSize);

            FR_TireData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Tire, baseAddrUpdt, (int)WF_TireSide.FR, new int [] { (int)WF_TireDataChunks.Offset1}, (int)WF_TireDataChunks.DataStart, (int)WF_TireDataChunks.ChunkSize);//Get raw data...
            FR_TireData = FR_TireData.Concat(GetCalcuatedTireData(FR_TireData)).ToList();//...then Concat (expand) it with calculated data
            FR_SuspensionData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Suspension, baseAddrUpdt, (int)WF_SuspensionSideOffset.FR, new int[] { }, (int)WF_SuspensionChunks.DataStart, (int)WF_SuspensionChunks.ChunkSize);

            RL_TireData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Tire, baseAddrUpdt, (int)WF_TireSide.RL, new int[] { (int)WF_TireDataChunks.Offset1 }, (int)WF_TireDataChunks.DataStart, (int)WF_TireDataChunks.ChunkSize);//Get raw data...
            RL_TireData = RL_TireData.Concat(GetCalcuatedTireData(RL_TireData)).ToList();//...then Concat (expand) it with calculated data
            RL_SuspensionData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Suspension, baseAddrUpdt, (int)WF_SuspensionSideOffset.RL, new int[] { }, (int)WF_SuspensionChunks.DataStart, (int)WF_SuspensionChunks.ChunkSize);

            RR_TireData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Tire, baseAddrUpdt, (int)WF_TireSide.RR, new int[] { (int)WF_TireDataChunks.Offset1 }, (int)WF_TireDataChunks.DataStart, (int)WF_TireDataChunks.ChunkSize);//Get raw data...
            RR_TireData = RR_TireData.Concat(GetCalcuatedTireData(RR_TireData)).ToList();//...then Concat (expand) it with calculated data
            RR_SuspensionData = GetRawFourBytesArrayData(Helper, (ulong)BaseAddress.Suspension, baseAddrUpdt, (int)WF_SuspensionSideOffset.RR, new int[] {  }, (int)WF_SuspensionChunks.DataStart, (int)WF_SuspensionChunks.ChunkSize);
            #endregion
            /*#region Stiffness and Lon/Lat Forces
            RL_LonBristleStiffness = BristleStiffness(LonStiffness, RL_ContactLength);
            RL_LonStiffness = Stiffness(LonStiffness, RL_ContactLength);
            RL_LonForceStatic = ForceStatic(RL_ContactLength, RL_LonBristleStiffness, RL_LongitudinalFriction, RL_VerticalLoad, RL_SlipRatio, true);
            RL_LonForceSlide = ForceSlide(RL_ContactLength, RL_LonBristleStiffness, RL_LongitudinalFriction, RL_VerticalLoad, RL_SlipAngleRad, false);
            RL_LonForceTotal = ForceTotal(RL_LonForceStatic, RL_LonForceSlide);
            #endregion*/
        }
        public static dynamic RadToDeg(double toConvert)
        {
            return toConvert * (float)(180 / Math.PI);
        }
        public static dynamic XZAngleRad(double x, double z)
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
        public static List<byte[]> GetRawFourBytesArrayData(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr, ulong baseAddrUpdt, int sideOffset, int[] extraOffsets, int dataStartOffset, int arraySize)
        {
            int[] numberOfExtraOffsets = new int[1 + extraOffsets.Length];
            int[] offsetList = numberOfExtraOffsets;

            if(extraOffsets == null || extraOffsets.Length == 0)
            {
                offsetList[0] = dataStartOffset + sideOffset;
            }
            else
            {
                int i = 0;
                foreach (int offset in extraOffsets) 
                {
                    offsetList[i] = offset;
                    i++;
                }
                offsetList[numberOfExtraOffsets.Count() -1] = dataStartOffset + sideOffset;
            }

            ulong bAU = memoryHelper.GetBaseAddress(baseAddr + baseAddrUpdt);
            List<byte[]> dataRaw = memoryHelper.ReadMemoryArray(MemoryUtils.OffsetCalculator(memoryHelper, bAU, offsetList), arraySize);
            return dataRaw;
        }
        public static List<byte[]> GetCalculatedEngineData(List<byte[]> engineData)
        {
            float helperEngineTorqueNm = GetDataValue<float>(engineData, WF_EngineDataChunks.DataStart, WF_EngineDataOffset.EngineTorqueNm);
            float helperEngineRPM = GetDataValue<float>(engineData, WF_EngineDataChunks.DataStart, WF_EngineDataOffset.EngineRPM);

            float engineTorqueLbFt = 0.7375621493f * helperEngineTorqueNm;

            float enginePowerKW = helperEngineTorqueNm * helperEngineRPM / 9548.8f;
            float enginePowerHP = engineTorqueLbFt * helperEngineRPM / 5252.1f;
            float enginePowerPS = enginePowerHP * 0.986f;
            float enginePowerBHP = enginePowerKW * 1.34102f;

            return new List<byte[]>() {
                BitConverter.GetBytes(engineTorqueLbFt),
                BitConverter.GetBytes(enginePowerKW),
                BitConverter.GetBytes(enginePowerHP),
                BitConverter.GetBytes(enginePowerPS),
                BitConverter.GetBytes(enginePowerBHP), };// Needs to be in the same order as in WF_EngineDataOffset enumerator
        }
        public static List<byte[]> GetCalcuatedTireData(List<byte[]> tireData)
        {
            var transformMatrix = new Matrix4x4(
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM11),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM12),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM13),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM14),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM21),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM22),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM23),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM24),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM31),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM32),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM33),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM34),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM41),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM42),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM43),
                (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.TireM44));

            float casterAngleRad = (float)-CalcAngles(transformMatrix).X;// caster not really
            float casterAngleDeg = (float)RadToDeg(casterAngleRad);// RadToDeg(RL_TireM11);
            float steerAngleRad = (float)-CalcAngles(transformMatrix).Y;// toe close
            float steerAngleDeg = (float)RadToDeg(steerAngleRad);// RadToDeg(RL_TireM13);
            float camberAngleRad = (float)LoopAngleRad(-CalcAngles(transformMatrix).Z, Math.PI * 0.5f);// camber close

            float camberAngleDeg = (float)RadToDeg(camberAngleRad);// RadToDeg(RL_TireM12);
            float lateralFriction = (float)GetFriction((float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.LateralLoad), (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.VerticalLoad));
            float longitudinalFriction = (float)GetFriction((float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.LongitudinalLoad), (float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.VerticalLoad));
            float totalFriction = (float)GetTotalFriction(lateralFriction, longitudinalFriction);
            float totalFrictionAngleDeg = (float)GetTotalFrictionAngle(lateralFriction, longitudinalFriction);

            float slipAngleDeg = (float)RadToDeg((float)GetDataValue<float>(tireData, WF_TireDataChunks.DataStart, WF_TireDataOffset.SlipAngleRad));

            return new List<byte[]>() { 
                BitConverter.GetBytes(casterAngleRad),
                BitConverter.GetBytes(casterAngleDeg), 
                BitConverter.GetBytes(steerAngleRad), 
                BitConverter.GetBytes(steerAngleDeg), 
                BitConverter.GetBytes(camberAngleRad), 
                BitConverter.GetBytes(camberAngleDeg), 
                BitConverter.GetBytes(lateralFriction), 
                BitConverter.GetBytes(longitudinalFriction), 
                BitConverter.GetBytes(totalFriction), 
                BitConverter.GetBytes(totalFrictionAngleDeg), 
                BitConverter.GetBytes(slipAngleDeg) };// Needs to be in the same order as in WF_TireDataOffset enumerator
        }
        public static T GetRawData<T>(Memory.Win64.MemoryHelper64 memoryHelper, ulong baseAddr, ulong baseAddrUpdt, int[] offsets)
        {
            ulong bAU = memoryHelper.GetBaseAddress(baseAddr + baseAddrUpdt);

            return memoryHelper.ReadMemory<T>(Memory.Utils.MemoryUtils.OffsetCalculator(memoryHelper, bAU, offsets));
        }
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
        public static Vector3 WorldTransformToLocal(Vector3 worldXYZ, Vector3 worldPositionBody, Matrix4x4 transformMatrixBody)
        {
            worldXYZ.X = BigValueReducerFloat(worldXYZ.X);
            worldXYZ.Y = BigValueReducerFloat(worldXYZ.Y);
            worldXYZ.Z = BigValueReducerFloat(worldXYZ.Z);

            Matrix4x4 rotationInvertedBody = Matrix4x4.Identity;
            transformMatrixBody.Translation = worldPositionBody;
            Matrix4x4 rotation = new Matrix4x4();
            rotation = transformMatrixBody;
            rotation.M41 = 0.0f;
            rotation.M42 = 0.0f;
            rotation.M43 = 0.0f;
            rotation.M44 = 1.0f;

            rotationInvertedBody = new Matrix4x4();
            Matrix4x4.Invert(rotation, out rotationInvertedBody);

            //transform world acceleration to local space
            Vector3 local = Vector3.Transform(worldXYZ, rotationInvertedBody);
            //Vector3 localAcceleration = worldAcceleration;
            return local;
        }
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
        public static double LoopAngleRad(double angle, double minMag)
        {
            double absAngle = Math.Abs(angle);

            if (absAngle <= minMag)
            {
                return angle;
            }

            double direction = angle / absAngle;

            //(180.0f * 1) - 135 = 45
            //(180.0f *-1) - -135 = -45
            double loopedAngle = (Math.PI * direction) - angle;

            return loopedAngle;
        }
        public static Vector3 WorldPositionBody(Matrix4x4 transformMatrixBody)
        {
            return new Vector3(transformMatrixBody.M41, transformMatrixBody.M42, transformMatrixBody.M43);
        }
        public static Matrix4x4 TransformMatrixBody(List<byte[]> bodyRotationData, Enum bodyDataStart)
        {
            return new Matrix4x4(
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM11),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM12),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM13),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM14),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM21),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM22),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM23),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM24),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM31),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM32),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM33),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM34),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM41),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM42),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM43),
                (float)GetDataValue<float>(bodyRotationData, bodyDataStart, WF_BodyRotationDataOffset.BodyM44));
        }
        public static T GetEnum<T>(int enumAsInt)
        {
            //https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            Type enumType = typeof(T);

            T value = (T)Enum.ToObject(enumType, enumAsInt);
            if (Enum.IsDefined(enumType, value) == false)
            {
                throw new NotSupportedException("Unable to convert value to the type: " + enumType.ToString());
            }

            return value;
        }
        public static int ForEachValueUpdate<T>(int ii, Enum prefix, List<List<DataItem>> fullList, List<byte[]> byteData, Enum dataStart)
        {
            int size = 4;// ObjectType.GetSize<T>();
            int indexOfInFullList = Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix);

            foreach (int i in Enum.GetValues(typeof(T)))
            {
                int test = Convert.ToInt32(GetEnum<T>(i));
                //int index = Array.IndexOf(Enum.GetValues(((WF_EngineDataOffset)i).GetType()), (WF_EngineDataOffset)i);
                //subList[index].Value = powertrainEngineData[((int)(WF_EngineDataOffset)i - Convert.ToInt32(powertrainEngineDataStart)) / size];//Needs all the offsets in the list...
                if (/*typeof(T) == typeof(WF_DifferentialDataOffset) && */i == (int)WF_DifferentialDataOffset.DifferentialOpenPrimaryLeft && Convert.ToInt32(prefix) == (int)WF_Prefix.Powertrain)
                    fullList[indexOfInFullList][ii].Value = BitConverter.ToInt32(byteData[(Convert.ToInt32(GetEnum<T>(i)) - Convert.ToInt32(dataStart)) / size], 0);
                else
                    fullList[indexOfInFullList][ii].Value = BitConverter.ToSingle(byteData[(Convert.ToInt32(GetEnum<T>(i)) - Convert.ToInt32(dataStart)) / size], 0);
                ii++;
            }
            return ii;
        }
        public static void GeneratePowertrainDataList(Enum prefix, List<List<DataItem>> fullList, Enum bodyRotationDataStart, Enum bodyAccelDataStart, Enum bodyAeroDataStart)
        {
            List<DataItem> subList = new List<DataItem>();
            foreach (int i in Enum.GetValues(typeof(WF_EngineDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)(WF_EngineDataOffset)i, Name = prefix + "_" + (WF_EngineDataOffset)i });
            }
            foreach (int i in Enum.GetValues(typeof(WF_DifferentialDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) +/* (int)WF_DifferentialSide.Left + */(int)(WF_DifferentialDataOffset)i, Name = prefix + "_" /*+ WF_DifferentialSide.PrimaryAxle*/ + (WF_DifferentialDataOffset)i });
            }
            //foreach (int i in Enum.GetValues(typeof(WF_DifferentialDataOffset)))
            //{
            //    subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)WF_DifferentialSide.SecondaryAxle + (int)(WF_DifferentialDataOffset)i, Name = prefix + "_" /*+ WF_DifferentialSide.SecondaryAxle*/ + (WF_DifferentialDataOffset)i });
            //}
            fullList.Add(subList);
        }
        public static void UpdatePowertrainDataValues(Enum prefix, List<List<DataItem>> fullList, Enum powertrainEngineDataStart, List<byte[]> powertrainEngineData, Enum powertrainDifferentailPrimaryAxleDataStart, List<byte[]> DifferentailPrimaryAxle, Enum powertrainDifferentialSecondaryAxleDataStart, List<byte[]> powertrainDifferentialSecondaryAxleData)
        {
            int ii = 0;
            ii = ForEachValueUpdate<WF_EngineDataOffset>(ii, prefix, fullList, powertrainEngineData, powertrainEngineDataStart);
            ii = ForEachValueUpdate<WF_DifferentialDataOffset>(ii, prefix, fullList, DifferentailPrimaryAxle, powertrainDifferentialSecondaryAxleDataStart);
            //ii = ForEachValueUpdate<WF_DifferentialDataOffset>(ii, prefix, fullList, powertrainDifferentialSecondaryAxleData, powertrainDifferentialSecondaryAxleDataStart);
        }
        public static List<byte[]> GetCalculatedRotationData(Matrix4x4 transformMatrixBody)
        {
            //Vector3 worldPositionBody = new Vector3(transformMatrixBody.M41, transformMatrixBody.M42, transformMatrixBody.M43);
            //CalcAngles(transformMatrixBody);// Needed?
            float body_PitchRad = -CalcAngles(transformMatrixBody).X;
            float body_PitchDeg = (float)RadToDeg(body_PitchRad);
            float body_YawRad = -CalcAngles(transformMatrixBody).Y;
            float body_YawDeg = (float)RadToDeg(body_YawRad);
            float body_RollRad = (float)LoopAngleRad(-CalcAngles(transformMatrixBody).Z, Math.PI * 0.5f);
            float body_RollDeg = (float)RadToDeg(body_RollRad);

            return new List<byte[]>()
            {
                BitConverter.GetBytes(body_PitchRad),
                BitConverter.GetBytes(body_PitchDeg),
                BitConverter.GetBytes(body_YawRad),
                BitConverter.GetBytes(body_YawDeg),
                BitConverter.GetBytes(body_RollRad),
                BitConverter.GetBytes(body_RollDeg),// Needs to be in the same order as in WF_BodyRotationDataOffset enumerator;
            };
        }
        public static List<byte[]> GetCalculatedAccelData(Matrix4x4 transformMatrixBody, List<byte[]> bodyAccelData)
        {
            float worldAccelX = (float)GetDataValue<float>(bodyAccelData, WF_BodyAccelDataChunks.DataStart, WF_BodyAccelDataOffset.XAccelerationWorld);
            float worldAccelY = (float)GetDataValue<float>(bodyAccelData, WF_BodyAccelDataChunks.DataStart, WF_BodyAccelDataOffset.YAccelerationWorld);
            float worldAccelZ = (float)GetDataValue<float>(bodyAccelData, WF_BodyAccelDataChunks.DataStart, WF_BodyAccelDataOffset.ZAccelerationWorld);
            Vector3 worldAcceleration = new Vector3(worldAccelX, worldAccelY, worldAccelZ);
            Vector3 localAccel = WorldTransformToLocal(worldAcceleration, WorldPositionBody(transformMatrixBody), transformMatrixBody);

            // Getting the XZ direction where in the world the car is going.
            float body_XZAccelerationAngleRad = (float)XZAngleRad(localAccel.X, localAccel.Z);
            float body_XZAccelerationAngleDeg = (float)RadToDeg(body_XZAccelerationAngleRad);

            float body_XZAcceleration = (float)Math.Sqrt(Math.Pow(localAccel.X, 2) + Math.Pow(localAccel.Z, 2));
            float body_XYZAcceleration = (float)Math.Sqrt(Math.Pow(body_XZAcceleration, 2) + Math.Pow(localAccel.Y, 2));

            // G-Force
            float body_XG = localAccel.X / g;
            float body_YG = localAccel.Y / g;
            float body_ZG = localAccel.Z / g;

            float body_XZG = (float)Math.Sqrt(Math.Pow(body_XG, 2) + Math.Pow(body_ZG, 2));
            float body_XYZG = (float)Math.Sqrt(Math.Pow(body_YG, 2) + Math.Pow(body_XZG, 2));

            float body_XZGAngleRad = 0;
            float body_XZGAngleDeg = 0;

            if (body_XZAccelerationAngleRad < 3 * Math.PI && body_XZAccelerationAngleRad > -3 * Math.PI)// These are to make sure if there's some huge or almost small value, that it won't get calculated, because those throw errors. Usually can happen when changing car or track etc.
            {
                if (0 > body_XZAccelerationAngleRad)
                {
                    if (body_XZAccelerationAngleRad > 2 * Math.PI)
                    {
                        body_XZGAngleRad = (float)(body_XZAccelerationAngleRad - 2 * Math.PI);
                        body_XZGAngleDeg = (float)RadToDeg(body_XZGAngleRad); // radians to degrees if needed.
                    }
                    else
                    {
                        body_XZGAngleRad = (float)(2 * Math.PI + body_XZAccelerationAngleRad);
                        body_XZGAngleDeg = (float)RadToDeg(body_XZGAngleRad); // radians to degrees if needed.
                    }
                }
                else
                {
                    if (body_XZAccelerationAngleRad - 0 > 2 * Math.PI)
                    {
                        body_XZGAngleRad = (float)(body_XZAccelerationAngleRad - 2 * Math.PI);
                        body_XZGAngleDeg = (float)RadToDeg(body_XZGAngleRad); // radians to degrees if needed.
                    }
                    else
                    {
                        body_XZGAngleRad = body_XZAccelerationAngleRad;
                        body_XZGAngleDeg = (float)RadToDeg(body_XZGAngleRad); // radians to degrees if needed.
                    }
                }
            }
            return new List<byte[]>() {
                BitConverter.GetBytes(localAccel.X),
                BitConverter.GetBytes(localAccel.Y),
                BitConverter.GetBytes(localAccel.Z),

                BitConverter.GetBytes((float)body_XZAccelerationAngleRad),
                BitConverter.GetBytes((float)body_XZAccelerationAngleDeg),
                BitConverter.GetBytes((float)body_XZAcceleration),
                BitConverter.GetBytes((float)body_XYZAcceleration),
                BitConverter.GetBytes((float)body_XG),
                BitConverter.GetBytes((float)body_YG),
                BitConverter.GetBytes((float)body_ZG),
                BitConverter.GetBytes((float)body_XZG),
                BitConverter.GetBytes((float)body_XYZG),
                BitConverter.GetBytes((float)body_XZGAngleRad),
                BitConverter.GetBytes(body_XZGAngleDeg) };// Needs to be in the same order as in WF_BodyAccelDataOffset enumerator;
        }
        public static List<byte[]> GetCalculatedAeroData(Matrix4x4 transformMatrixBody)
        {
            Vector3 worldAcceleration = new Vector3((float)GetDataValue<float>(Body_AeroData, WF_AeroDataChunks.DataStart, WF_AeroDataOffset.XDragWorld), (float)GetDataValue<float>(Body_AeroData, WF_AeroDataChunks.DataStart, WF_AeroDataOffset.YDragWorld), (float)GetDataValue<float>(Body_AeroData, WF_AeroDataChunks.DataStart, WF_AeroDataOffset.ZDragWorld));
            Vector3 localDrag = WorldTransformToLocal(worldAcceleration, WorldPositionBody(transformMatrixBody), transformMatrixBody);

            return new List<byte[]>() {
                BitConverter.GetBytes(localDrag.X),
                BitConverter.GetBytes(localDrag.Y),
                BitConverter.GetBytes(localDrag.Z),};// Needs to be in the same order as in WF_AeroDataOffset enumerator;
        }
        public static void ConsoleTireData(List<List<DataItem>> tireDataList)
        {
            Console.WriteLine("----- Data Update -----");
            foreach (var sublist in tireDataList)
            {
                foreach (var item in sublist)
                {
                    Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", item.Id, item.Name, item.Value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        public static void GenerateBodyDataList(Enum prefix, List<List<DataItem>> fullList, Enum bodyRotationDataStart, Enum bodyAccelDataStart, Enum bodyAeroDataStart)
        {
            List<DataItem> subList = new List<DataItem>();
            foreach (int i in Enum.GetValues(typeof(WF_BodyRotationDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)WF_BodyRotationChunks.Offset1 + (int)(WF_BodyRotationDataOffset)i, Name = prefix + "_" + (WF_BodyRotationDataOffset)i});
            }
            foreach (int i in Enum.GetValues(typeof(WF_BodyAccelDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)(WF_BodyAccelDataOffset)i, Name = prefix + "_" + (WF_BodyAccelDataOffset)i});
            }
            foreach (int i in Enum.GetValues(typeof(WF_AeroDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)(WF_AeroDataOffset)i, Name = prefix + "_" + (WF_AeroDataOffset)i });
            }
            fullList.Add(subList);
        }
        public static void UpdateBodyDataValues(Enum prefix, List<List<DataItem>> fullList, Enum bodyRotationDataStart, List<byte[]> bodyRotationData, Enum bodyAccelDataStart, List<byte[]> bodyAccelData, Enum bodyAeroDataStart, List<byte[]> bodyAeroData)
        {
            int ii = 0;
            ii = ForEachValueUpdate<WF_BodyRotationDataOffset>(ii, prefix, fullList, bodyRotationData, bodyRotationDataStart);
            ii = ForEachValueUpdate<WF_BodyAccelDataOffset>(ii, prefix, fullList, bodyAccelData, bodyAccelDataStart);
            ii = ForEachValueUpdate<WF_AeroDataOffset>(ii, prefix, fullList, bodyAeroData, bodyAeroDataStart);
        }
        public static void GenerateTireDataList(Enum prefix, List<List<DataItem>> fullList, Enum tireDataStart, Enum suspensionDataStart)
        {
            List<DataItem> subList = new List<DataItem>();
            //Tire data
            foreach (int i in Enum.GetValues(typeof(WF_TireDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)(WF_TireDataOffset)i, Name = prefix + "_" + (WF_TireDataOffset)i});
            }
            //Suspension data gets added also in
            foreach (int i in Enum.GetValues(typeof(WF_SuspensionDataOffset)))
            {
                subList.Add(new DataItem { Id = Convert.ToInt32(prefix) + (int)WF_TireDataOffset.SlipAngleDeg + 0x4 + (int)(WF_SuspensionDataOffset)i, Name = prefix + "_" + (WF_SuspensionDataOffset)i});
            }
            fullList.Add(subList);
        }
        public static void UpdateTireDataValues(Enum prefix, List<List<DataItem>> fullList, Enum tireDataStart, List<byte[]> tireData, Enum suspensionDataStart, List<byte[]> suspensionData)
        {
            int ii = 0;
            ii = ForEachValueUpdate<WF_TireDataOffset>(ii, prefix, fullList, tireData, tireDataStart);
            ii = ForEachValueUpdate<WF_SuspensionDataOffset>(ii, prefix, fullList, suspensionData, suspensionDataStart);
        }
        private static float GetFriction(float latORlonLoad, float vertLoad)
        {
            if (vertLoad != 0)
            {
                return latORlonLoad / vertLoad;
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
                    return (float)(90 - (Math.Atan(lonFriction / latFriction) * RadDeg));
                }
                else if (lonFriction < 0)
                {
                    return (float)(90 - (Math.Atan(lonFriction / latFriction) * RadDeg));
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
                    return (float)(270 + (Math.Atan(lonFriction / Math.Abs(latFriction)) * RadDeg));
                }
                else if (lonFriction < 0)
                {
                    return (float)(270 - (Math.Atan(lonFriction / latFriction) * RadDeg));
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
    }
}