using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    public class DataLogger
    {
        public static void LogToFile()
        {
            CheckWhatToLogInFile(LogSettings.Delimiter);

            if (LiveData.Logging == true)
            {
                // SA, SR, Speed and Vertical Load filters for logging
                FilterCheckAndLog(LogSettings.FileNameFLTire, LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.SlipRatio), LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.SlipAngleDeg), LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TravelSpeed), LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.VerticalLoad));
                FilterCheckAndLog(LogSettings.FileNameFRTire, LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.SlipRatio), LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.SlipAngleDeg), LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TravelSpeed), LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.VerticalLoad));
                FilterCheckAndLog(LogSettings.FileNameRLTire, LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.SlipRatio), LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.SlipAngleDeg), LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.TravelSpeed), LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.VerticalLoad));
                FilterCheckAndLog(LogSettings.FileNameRRTire, LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.SlipRatio), LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.SlipAngleDeg), LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.TravelSpeed), LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.VerticalLoad));
            }
        }
        private static void CheckWhatToLogInFile(char delimiter)
        {
            LogSettings.Header0 = nameof(AllValueNames.TravelSpeed) + delimiter;//LogSettings.sTireTravelSpeed
            LogSettings.FL_Parameter0 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TravelSpeed).ToString() + delimiter;
            LogSettings.FR_Parameter0 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TravelSpeed).ToString() + delimiter;
            LogSettings.RL_Parameter0 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.TravelSpeed).ToString() + delimiter;
            LogSettings.RR_Parameter0 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.TravelSpeed).ToString() + delimiter;

            LogSettings.Header1 = nameof(AllValueNames.AngularVelocity) + delimiter;//LogSettings.sAngularVelocity
            LogSettings.FL_Parameter1 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.AngularVelocity).ToString() + delimiter;
            LogSettings.FR_Parameter1 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.AngularVelocity).ToString() + delimiter;
            LogSettings.RL_Parameter1 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.AngularVelocity).ToString() + delimiter;
            LogSettings.RR_Parameter1 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.AngularVelocity).ToString() + delimiter;

            LogSettings.Header2 = nameof(AllValueNames.VerticalLoad) + delimiter;//LogSettings.sVerticalLoad
            LogSettings.FL_Parameter2 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.VerticalLoad).ToString() + delimiter;
            LogSettings.FR_Parameter2 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.VerticalLoad).ToString() + delimiter;
            LogSettings.RL_Parameter2 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.VerticalLoad).ToString() + delimiter;
            LogSettings.RR_Parameter2 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.VerticalLoad).ToString() + delimiter;

            LogSettings.Header3 = nameof(AllValueNames.VerticalDeflection) + delimiter;//LogSettings.sVerticalDeflection
            LogSettings.FL_Parameter3 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.VerticalDeflection).ToString() + delimiter;
            LogSettings.FR_Parameter3 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.VerticalDeflection).ToString() + delimiter;
            LogSettings.RL_Parameter3 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.VerticalDeflection).ToString() + delimiter;
            LogSettings.RR_Parameter3 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.VerticalDeflection).ToString() + delimiter;

            LogSettings.Header4 = nameof(AllValueNames.LoadedRadius) + delimiter;//LogSettings.sLoadedRadius
            LogSettings.FL_Parameter4 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LoadedRadius).ToString() + delimiter;
            LogSettings.FR_Parameter4 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LoadedRadius).ToString() + delimiter;
            LogSettings.RL_Parameter4 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LoadedRadius).ToString() + delimiter;
            LogSettings.RR_Parameter4 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LoadedRadius).ToString() + delimiter;

            LogSettings.Header5 = nameof(AllValueNames.EffectiveRadius) + delimiter;//LogSettings.sEffectiveRadius
            LogSettings.FL_Parameter5 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.EffectiveRadius).ToString() + delimiter;
            LogSettings.FR_Parameter5 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.EffectiveRadius).ToString() + delimiter;
            LogSettings.RL_Parameter5 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.EffectiveRadius).ToString() + delimiter;
            LogSettings.RR_Parameter5 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.EffectiveRadius).ToString() + delimiter;

            LogSettings.Header6 = nameof(AllValueNames.ContactLength) + delimiter;//LogSettings.sContactLength
            LogSettings.FL_Parameter6 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.ContactLength).ToString() + delimiter;
            LogSettings.FR_Parameter6 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.ContactLength).ToString() + delimiter;
            LogSettings.RL_Parameter6 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.ContactLength).ToString() + delimiter;
            LogSettings.RR_Parameter6 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.ContactLength).ToString() + delimiter;

            LogSettings.Header7 = nameof(AllValueNames.CurrentContactBrakeTorque) + delimiter;//LogSettings.sBrakeTorque
            LogSettings.FL_Parameter7 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.CurrentContactBrakeTorque).ToString() + delimiter;
            LogSettings.FR_Parameter7 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.CurrentContactBrakeTorque).ToString() + delimiter;
            LogSettings.RL_Parameter7 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.CurrentContactBrakeTorque).ToString() + delimiter;
            LogSettings.RR_Parameter7 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.CurrentContactBrakeTorque).ToString() + delimiter;

            LogSettings.Header7_1 = nameof(AllValueNames.CurrentContactBrakeTorqueMax) + delimiter;//LogSettings.sMaxBrakeTorque
            LogSettings.FL_Parameter7_1 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.CurrentContactBrakeTorqueMax).ToString() + delimiter;
            LogSettings.FR_Parameter7_1 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.CurrentContactBrakeTorqueMax).ToString() + delimiter;
            LogSettings.RL_Parameter7_1 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.CurrentContactBrakeTorqueMax).ToString() + delimiter;
            LogSettings.RR_Parameter7_1 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.CurrentContactBrakeTorqueMax).ToString() + delimiter;

            LogSettings.Header8 = nameof(AllValueNames.SteerAngleDeg) + delimiter;//LogSettings.sSteerAngle
            LogSettings.FL_Parameter8 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.SteerAngleDeg).ToString() + delimiter;
            LogSettings.FR_Parameter8 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.SteerAngleDeg).ToString() + delimiter;
            LogSettings.RL_Parameter8 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.SteerAngleDeg).ToString() + delimiter;
            LogSettings.RR_Parameter8 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.SteerAngleDeg).ToString() + delimiter;

            LogSettings.Header9 = nameof(AllValueNames.CamberAngleDeg) + delimiter;//LogSettings.sCamberAngle
            LogSettings.FL_Parameter9 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.CamberAngleDeg).ToString() + delimiter;
            LogSettings.FR_Parameter9 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.CamberAngleDeg).ToString() + delimiter;
            LogSettings.RL_Parameter9 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.CamberAngleDeg).ToString() + delimiter;
            LogSettings.RR_Parameter9 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.CamberAngleDeg).ToString() + delimiter;

            LogSettings.Header10 = nameof(AllValueNames.LateralLoad) + delimiter;//LogSettings.sLateralLoad
            LogSettings.FL_Parameter10 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LateralLoad).ToString() + delimiter;
            LogSettings.FR_Parameter10 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LateralLoad).ToString() + delimiter;
            LogSettings.RL_Parameter10 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LateralLoad).ToString() + delimiter;
            LogSettings.RR_Parameter10 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LateralLoad).ToString() + delimiter;

            LogSettings.Header11 = nameof(AllValueNames.SlipAngleDeg) + delimiter;//LogSettings.sSlipAngle
            LogSettings.FL_Parameter11 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.SlipAngleDeg).ToString() + delimiter;
            LogSettings.FR_Parameter11 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.SlipAngleDeg).ToString() + delimiter;
            LogSettings.RL_Parameter11 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.SlipAngleDeg).ToString() + delimiter;
            LogSettings.RR_Parameter11 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.SlipAngleDeg).ToString() + delimiter;

            LogSettings.Header12 = nameof(AllValueNames.LateralFriction) + delimiter;//LogSettings.sLateralFriction
            LogSettings.FL_Parameter12 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LateralFriction).ToString() + delimiter;
            LogSettings.FR_Parameter12 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LateralFriction).ToString() + delimiter;
            LogSettings.RL_Parameter12 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LateralFriction).ToString() + delimiter;
            LogSettings.RR_Parameter12 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LateralFriction).ToString() + delimiter;

            LogSettings.Header13 = nameof(AllValueNames.LateralSlipSpeed) + delimiter;//LogSettings.sLateralSlipSpeed
            LogSettings.FL_Parameter13 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LateralSlipSpeed).ToString() + delimiter;
            LogSettings.FR_Parameter13 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LateralSlipSpeed).ToString() + delimiter;
            LogSettings.RL_Parameter13 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LateralSlipSpeed).ToString() + delimiter;
            LogSettings.RR_Parameter13 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LateralSlipSpeed).ToString() + delimiter;

            LogSettings.Header14 = nameof(AllValueNames.LongitudinalLoad) + delimiter;//LogSettings.sLongitudinalLoad
            LogSettings.FL_Parameter14 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LongitudinalLoad).ToString() + delimiter;
            LogSettings.FR_Parameter14 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LongitudinalLoad).ToString() + delimiter;
            LogSettings.RL_Parameter14 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LongitudinalLoad).ToString() + delimiter;
            LogSettings.RR_Parameter14 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LongitudinalLoad).ToString() + delimiter;

            LogSettings.Header15 = nameof(AllValueNames.SlipRatio) + delimiter;//LogSettings.sSlipRatio
            LogSettings.FL_Parameter15 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.SlipRatio).ToString() + delimiter;
            LogSettings.FR_Parameter15 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.SlipRatio).ToString() + delimiter;
            LogSettings.RL_Parameter15 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.SlipRatio).ToString() + delimiter;
            LogSettings.RR_Parameter15 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.SlipRatio).ToString() + delimiter;

            LogSettings.Header16 = nameof(AllValueNames.LongitudinalFriction) + delimiter;//LogSettings.sLongitudinalFriction
            LogSettings.FL_Parameter16 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LongitudinalFriction).ToString() + delimiter;
            LogSettings.FR_Parameter16 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LongitudinalFriction).ToString() + delimiter;
            LogSettings.RL_Parameter16 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LongitudinalFriction).ToString() + delimiter;
            LogSettings.RR_Parameter16 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LongitudinalFriction).ToString() + delimiter;

            LogSettings.Header17 = nameof(AllValueNames.LongitudinalSlipSpeed) + delimiter;//LogSettings.sLongitudinalSlipSpeed
            LogSettings.FL_Parameter17 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.LongitudinalSlipSpeed).ToString() + delimiter;
            LogSettings.FR_Parameter17 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.LongitudinalSlipSpeed).ToString() + delimiter;
            LogSettings.RL_Parameter17 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.LongitudinalSlipSpeed).ToString() + delimiter;
            LogSettings.RR_Parameter17 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.LongitudinalSlipSpeed).ToString() + delimiter;

            LogSettings.Header18 = nameof(AllValueNames.TreadTemperature) + delimiter;//LogSettings.sTreadTemperature
            LogSettings.FL_Parameter18 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TreadTemperature).ToString() + delimiter;
            LogSettings.FR_Parameter18 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TreadTemperature).ToString() + delimiter;
            LogSettings.RL_Parameter18 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.TreadTemperature).ToString() + delimiter;
            LogSettings.RR_Parameter18 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.TreadTemperature).ToString() + delimiter;

            LogSettings.Header19 = nameof(AllValueNames.InnerTemperature) + delimiter;//LogSettings.sInnerTemperature
            LogSettings.FL_Parameter19 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.InnerTemperature).ToString() + delimiter;
            LogSettings.FR_Parameter19 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.InnerTemperature).ToString() + delimiter;
            LogSettings.RL_Parameter19 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.InnerTemperature).ToString() + delimiter;
            LogSettings.RR_Parameter19 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.InnerTemperature).ToString() + delimiter;

            LogSettings.Header20 = nameof(AllValueNames.RaceTime) + delimiter;//LogSettings.sRaceTime
            LogSettings.FL_Parameter20 = LiveData.RaceTime.ToString().ToString() + delimiter;
            LogSettings.FR_Parameter20 = LiveData.RaceTime.ToString().ToString() + delimiter;
            LogSettings.RL_Parameter20 = LiveData.RaceTime.ToString().ToString() + delimiter;
            LogSettings.RR_Parameter20 = LiveData.RaceTime.ToString().ToString() + delimiter;

            LogSettings.Header21 = nameof(AllValueNames.TotalFriction) + delimiter;//LogSettings.sTotalFriction
            LogSettings.FL_Parameter21 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TotalFriction).ToString() + delimiter;
            LogSettings.FR_Parameter21 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TotalFriction).ToString() + delimiter;
            LogSettings.RL_Parameter21 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.TotalFriction).ToString() + delimiter;
            LogSettings.RR_Parameter21 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.TotalFriction).ToString() + delimiter;

            LogSettings.Header22 = nameof(AllValueNames.TotalFrictionAngleDeg) + delimiter;//LogSettings.sTotalFrictionAngle
            LogSettings.FL_Parameter22 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_TireDataOffset.TotalFrictionAngleDeg).ToString() + delimiter;
            LogSettings.FR_Parameter22 = LiveData.GetFullListDataValue(WF_PrefixMain.FR, WF_TireDataOffset.TotalFrictionAngleDeg).ToString() + delimiter;
            LogSettings.RL_Parameter22 = LiveData.GetFullListDataValue(WF_PrefixMain.RL, WF_TireDataOffset.TotalFrictionAngleDeg).ToString() + delimiter;
            LogSettings.RR_Parameter22 = LiveData.GetFullListDataValue(WF_PrefixMain.RR, WF_TireDataOffset.TotalFrictionAngleDeg).ToString() + delimiter;

            LogSettings.Header23 = nameof(AllValueNames.SuspensionLength) + delimiter;//LogSettings.sSuspensionLength
            LogSettings.FL_Parameter23 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionLength).ToString() + delimiter;
            LogSettings.FR_Parameter23 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionLength).ToString() + delimiter;
            LogSettings.RL_Parameter23 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionLength).ToString() + delimiter;
            LogSettings.RR_Parameter23 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionLength).ToString() + delimiter;

            LogSettings.Header24 = nameof(AllValueNames.SuspensionVelocity) + delimiter;//LogSettings.sSuspensionVelocity
            LogSettings.FL_Parameter24 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionVelocity).ToString() + delimiter;
            LogSettings.FR_Parameter24 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionVelocity).ToString() + delimiter;
            LogSettings.RL_Parameter24 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionVelocity).ToString() + delimiter;
            LogSettings.RR_Parameter24 = LiveData.GetFullListDataValue(WF_PrefixMain.FL, WF_SuspensionDataOffset.SuspensionVelocity).ToString() + delimiter;

            LogSettings.Header25 = nameof(AllValueNames.Body_XYZG) + delimiter;//LogSettings.sXGRotated
            LogSettings.FL_Parameter25 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZG).ToString() + delimiter;
            LogSettings.FR_Parameter25 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZG).ToString() + delimiter;
            LogSettings.RL_Parameter25 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZG).ToString() + delimiter;
            LogSettings.RR_Parameter25 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZG).ToString() + delimiter;

            LogSettings.Header26 = nameof(AllValueNames.Body_XZAccelerationAngleDeg) + delimiter;//LogSettings.sZGRotated
            LogSettings.FL_Parameter26 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAccelerationAngleDeg).ToString() + delimiter;
            LogSettings.FR_Parameter26 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAccelerationAngleDeg).ToString() + delimiter;
            LogSettings.RL_Parameter26 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAccelerationAngleDeg).ToString() + delimiter;
            LogSettings.RR_Parameter26 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAccelerationAngleDeg).ToString() + delimiter;

            LogSettings.Header27 = nameof(AllValueNames.Body_XZAcceleration) + delimiter;//LogSettings.sYGRotated
            LogSettings.FL_Parameter27 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAcceleration).ToString() + delimiter;
            LogSettings.FR_Parameter27 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAcceleration).ToString() + delimiter;
            LogSettings.RL_Parameter27 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAcceleration).ToString() + delimiter;
            LogSettings.RR_Parameter27 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XZAcceleration).ToString() + delimiter;

            LogSettings.Header28 = nameof(AllValueNames.Body_XYZAcceleration) + delimiter;//LogSettings.sXYZG
            LogSettings.FL_Parameter28 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZAcceleration).ToString() + delimiter;
            LogSettings.FR_Parameter28 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZAcceleration).ToString() + delimiter;
            LogSettings.RL_Parameter28 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZAcceleration).ToString() + delimiter;
            LogSettings.RR_Parameter28 = LiveData.GetFullListDataValue(WF_PrefixMain.Body, WF_BodyAccelDataOffset.XYZAcceleration).ToString() + delimiter;
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
                return LogSettings.FL_Parameter20 +
                        LogSettings.FL_Parameter0 +
                        LogSettings.FL_Parameter1 +
                        LogSettings.FL_Parameter2 +
                        LogSettings.FL_Parameter3 +
                        LogSettings.FL_Parameter4 +
                        LogSettings.FL_Parameter5 +
                        LogSettings.FL_Parameter6 +
                        LogSettings.FL_Parameter7 +
                        LogSettings.FL_Parameter7_1 +
                        LogSettings.FL_Parameter8 +
                        LogSettings.FL_Parameter9 +
                        LogSettings.FL_Parameter10 +
                        LogSettings.FL_Parameter11 +
                        LogSettings.FL_Parameter12 +
                        LogSettings.FL_Parameter13 +
                        LogSettings.FL_Parameter14 +
                        LogSettings.FL_Parameter15 +
                        LogSettings.FL_Parameter16 +
                        LogSettings.FL_Parameter17 +
                        LogSettings.FL_Parameter18 +
                        LogSettings.FL_Parameter19 +
                        LogSettings.FL_Parameter21 +
                        LogSettings.FL_Parameter22 +
                        LogSettings.FL_Parameter23 +
                        LogSettings.FL_Parameter24 +
                        LogSettings.FL_Parameter25 +
                        LogSettings.FL_Parameter26 +
                        LogSettings.FL_Parameter27 +
                        LogSettings.FL_Parameter28;
            }
            else if (chooseTire == "FrontRight" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.FR_Parameter20 +
                       LogSettings.FR_Parameter0 +
                       LogSettings.FR_Parameter1 +
                       LogSettings.FR_Parameter2 +
                       LogSettings.FR_Parameter3 +
                       LogSettings.FR_Parameter4 +
                       LogSettings.FR_Parameter5 +
                       LogSettings.FR_Parameter6 +
                       LogSettings.FR_Parameter7 +
                       LogSettings.FR_Parameter7_1 +
                       LogSettings.FR_Parameter8 +
                       LogSettings.FR_Parameter9 +
                       LogSettings.FR_Parameter10 +
                       LogSettings.FR_Parameter11 +
                       LogSettings.FR_Parameter12 +
                       LogSettings.FR_Parameter13 +
                       LogSettings.FR_Parameter14 +
                       LogSettings.FR_Parameter15 +
                       LogSettings.FR_Parameter16 +
                       LogSettings.FR_Parameter17 +
                       LogSettings.FR_Parameter18 +
                       LogSettings.FR_Parameter19 +
                       LogSettings.FR_Parameter21 +
                       LogSettings.FR_Parameter22 +
                       LogSettings.FR_Parameter23 +
                       LogSettings.FR_Parameter24 +
                       LogSettings.FR_Parameter25 +
                       LogSettings.FR_Parameter26 +
                       LogSettings.FR_Parameter27 +
                       LogSettings.FR_Parameter28;
            }
            else if (chooseTire == "RearLeft" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.RL_Parameter20 +
                        LogSettings.RL_Parameter0 +
                        LogSettings.RL_Parameter1 +
                        LogSettings.RL_Parameter2 +
                        LogSettings.RL_Parameter3 +
                        LogSettings.RL_Parameter4 +
                        LogSettings.RL_Parameter5 +
                        LogSettings.RL_Parameter6 +
                        LogSettings.RL_Parameter7 +
                        LogSettings.RL_Parameter7_1 +
                        LogSettings.RL_Parameter8 +
                        LogSettings.RL_Parameter9 +
                        LogSettings.RL_Parameter10 +
                        LogSettings.RL_Parameter11 +
                        LogSettings.RL_Parameter12 +
                        LogSettings.RL_Parameter13 +
                        LogSettings.RL_Parameter14 +
                        LogSettings.RL_Parameter15 +
                        LogSettings.RL_Parameter16 +
                        LogSettings.RL_Parameter17 +
                        LogSettings.RL_Parameter18 +
                        LogSettings.RL_Parameter19 +
                        LogSettings.RL_Parameter21 +
                        LogSettings.RL_Parameter22 +
                        LogSettings.RL_Parameter23 +
                        LogSettings.RL_Parameter24 +
                        LogSettings.RL_Parameter25 +
                        LogSettings.RL_Parameter26 +
                        LogSettings.RL_Parameter27 +
                        LogSettings.RL_Parameter28;
            }
            else if (chooseTire == "RearRight" && LogSettings.TireTravelSpeedLogEnabled == true)
            {
                return LogSettings.RR_Parameter20 +
                    LogSettings.RR_Parameter0 +
                    LogSettings.RR_Parameter1 +
                    LogSettings.RR_Parameter2 +
                    LogSettings.RR_Parameter3 +
                    LogSettings.RR_Parameter4 +
                    LogSettings.RR_Parameter5 +
                    LogSettings.RR_Parameter6 +
                    LogSettings.RR_Parameter7 +
                    LogSettings.RR_Parameter7_1 +
                    LogSettings.RR_Parameter8 +
                    LogSettings.RR_Parameter9 +
                    LogSettings.RR_Parameter10 +
                    LogSettings.RR_Parameter11 +
                    LogSettings.RR_Parameter12 +
                    LogSettings.RR_Parameter13 +
                    LogSettings.RR_Parameter14 +
                    LogSettings.RR_Parameter15 +
                    LogSettings.RR_Parameter16 +
                    LogSettings.RR_Parameter17 +
                    LogSettings.RR_Parameter18 +
                    LogSettings.RR_Parameter19 +
                    LogSettings.RR_Parameter21 +
                    LogSettings.RR_Parameter22 +
                    LogSettings.RR_Parameter23 +
                    LogSettings.RR_Parameter24 +
                    LogSettings.RR_Parameter25 +
                    LogSettings.RR_Parameter26 +
                    LogSettings.RR_Parameter27 +
                    LogSettings.RR_Parameter28;
            }
            else
            {
                return "";
            }
        }
    }
}
