using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    class _4Wheels
    {
        public static int Alpha { get; set; } = 255;
        public static int Divider { get; set; } = 2;
        public static int HistoryAlpha { get; set; } = 255;
        public static int HistoryColorDivider { get; set; } = 2;
        public static int Steps { get; set; } = 10;

        public static string FL_SeriesString { get; set; } = "SeriesFL";
        public static List<float> FL_X1ValuesChart { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChart { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChart { get; set; } = new List<float>();

        public static string FR_SeriesString { get; set; } = "SeriesFR";
        public static List<float> FR_X1ValuesChart { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChart { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChart { get; set; } = new List<float>();

        public static string RL_SeriesString { get; set; } = "SeriesRL";
        public static List<float> RL_X1ValuesChart { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChart { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChart { get; set; } = new List<float>();

        public static string RR_SeriesString { get; set; } = "SeriesRR";
        public static List<float> RR_X1ValuesChart { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChart { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChart { get; set; } = new List<float>();
        #region Color Gradient list values.
        public static string seriesColor1 { get; set; } = "Color1";
        public static List<float> FL_X1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor1 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor1 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor1 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor1 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor1 { get; set; } = new List<float>();

        public static string seriesColor2 { get; set; } = "Color2";
        public static List<float> FL_X1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor2 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor2 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor2 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor2 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor2 { get; set; } = new List<float>();

        public static string seriesColor3 { get; set; } = "Color3";
        public static List<float> FL_X1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor3 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor3 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor3 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor3 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor3 { get; set; } = new List<float>();

        public static string seriesColor4 { get; set; } = "Color4";
        public static List<float> FL_X1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor4 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor4 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor4 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor4 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor4 { get; set; } = new List<float>();

        public static string seriesColor5 { get; set; } = "Color5";
        public static List<float> FL_X1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor5 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor5 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor5 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor5 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor5 { get; set; } = new List<float>();

        public static string seriesColor6 { get; set; } = "Color6";
        public static List<float> FL_X1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor6 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor6 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor6 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor6 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor6 { get; set; } = new List<float>();

        public static string seriesColor7 { get; set; } = "Color7";
        public static List<float> FL_X1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor7 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor7 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor7 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor7 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor7 { get; set; } = new List<float>();

        public static string seriesColor8 { get; set; } = "Color8";
        public static List<float> FL_X1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor8 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor8 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor8 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor8 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor8 { get; set; } = new List<float>();

        public static string seriesColor9 { get; set; } = "Color9";
        public static List<float> FL_X1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor9 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor9 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor9 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor9 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor9 { get; set; } = new List<float>();

        public static string seriesColor10 { get; set; } = "Color10";
        public static List<float> FL_X1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> FL_Y1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> FL_Z1ValuesChartColor10 { get; set; } = new List<float>();

        public static List<float> FR_X1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> FR_Y1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> FR_Z1ValuesChartColor10 { get; set; } = new List<float>();

        public static List<float> RL_X1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> RL_Y1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> RL_Z1ValuesChartColor10 { get; set; } = new List<float>();

        public static List<float> RR_X1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> RR_Y1ValuesChartColor10 { get; set; } = new List<float>();
        public static List<float> RR_Z1ValuesChartColor10 { get; set; } = new List<float>();
        #endregion

        public static SeriesChartType ChartType { get; set; } = _4WheelsSettings.SeriesChartType;
        public static MarkerStyle MarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int MarkerSizeHistory { get; set; } = 2;
        public static List<Color> MarkerColors { get; set; } = new List<Color>(new Color[11]);
        public static void ClearListDataHistory()
        {
            //while (chartName.Series.Count > 1) { chartName.Series.RemoveAt(0); }
            FL_X1ValuesChart.Clear();
            FL_Y1ValuesChart.Clear();
            FL_Z1ValuesChart.Clear();
            FR_X1ValuesChart.Clear();
            FR_Y1ValuesChart.Clear();
            FR_Z1ValuesChart.Clear();
            RL_X1ValuesChart.Clear();
            RL_Y1ValuesChart.Clear();
            RL_Z1ValuesChart.Clear();
            RR_X1ValuesChart.Clear();
            RR_Y1ValuesChart.Clear();
            RR_Z1ValuesChart.Clear();

            FL_X1ValuesChartColor1.Clear();
            FL_Y1ValuesChartColor1.Clear();
            FL_Z1ValuesChartColor1.Clear();
            FR_X1ValuesChartColor1.Clear();
            FR_Y1ValuesChartColor1.Clear();
            FR_Z1ValuesChartColor1.Clear();
            RL_X1ValuesChartColor1.Clear();
            RL_Y1ValuesChartColor1.Clear();
            RL_Z1ValuesChartColor1.Clear();
            RR_X1ValuesChartColor1.Clear();
            RR_Y1ValuesChartColor1.Clear();
            RR_Z1ValuesChartColor1.Clear();

            FL_X1ValuesChartColor2.Clear();
            FL_Y1ValuesChartColor2.Clear();
            FL_Z1ValuesChartColor2.Clear();
            FR_X1ValuesChartColor2.Clear();
            FR_Y1ValuesChartColor2.Clear();
            FR_Z1ValuesChartColor2.Clear();
            RL_X1ValuesChartColor2.Clear();
            RL_Y1ValuesChartColor2.Clear();
            RL_Z1ValuesChartColor2.Clear();
            RR_X1ValuesChartColor2.Clear();
            RR_Y1ValuesChartColor2.Clear();
            RR_Z1ValuesChartColor2.Clear();

            FL_X1ValuesChartColor3.Clear();
            FL_Y1ValuesChartColor3.Clear();
            FL_Z1ValuesChartColor3.Clear();
            FR_X1ValuesChartColor3.Clear();
            FR_Y1ValuesChartColor3.Clear();
            FR_Z1ValuesChartColor3.Clear();
            RL_X1ValuesChartColor3.Clear();
            RL_Y1ValuesChartColor3.Clear();
            RL_Z1ValuesChartColor3.Clear();
            RR_X1ValuesChartColor3.Clear();
            RR_Y1ValuesChartColor3.Clear();
            RR_Z1ValuesChartColor3.Clear();

            FL_X1ValuesChartColor4.Clear();
            FL_Y1ValuesChartColor4.Clear();
            FL_Z1ValuesChartColor4.Clear();
            FR_X1ValuesChartColor4.Clear();
            FR_Y1ValuesChartColor4.Clear();
            FR_Z1ValuesChartColor4.Clear();
            RL_X1ValuesChartColor4.Clear();
            RL_Y1ValuesChartColor4.Clear();
            RL_Z1ValuesChartColor4.Clear();
            RR_X1ValuesChartColor4.Clear();
            RR_Y1ValuesChartColor4.Clear();
            RR_Z1ValuesChartColor4.Clear();

            FL_X1ValuesChartColor5.Clear();
            FL_Y1ValuesChartColor5.Clear();
            FL_Z1ValuesChartColor5.Clear();
            FR_X1ValuesChartColor5.Clear();
            FR_Y1ValuesChartColor5.Clear();
            FR_Z1ValuesChartColor5.Clear();
            RL_X1ValuesChartColor5.Clear();
            RL_Y1ValuesChartColor5.Clear();
            RL_Z1ValuesChartColor5.Clear();
            RR_X1ValuesChartColor5.Clear();
            RR_Y1ValuesChartColor5.Clear();
            RR_Z1ValuesChartColor5.Clear();

            FL_X1ValuesChartColor6.Clear();
            FL_Y1ValuesChartColor6.Clear();
            FL_Z1ValuesChartColor6.Clear();
            FR_X1ValuesChartColor6.Clear();
            FR_Y1ValuesChartColor6.Clear();
            FR_Z1ValuesChartColor6.Clear();
            RL_X1ValuesChartColor6.Clear();
            RL_Y1ValuesChartColor6.Clear();
            RL_Z1ValuesChartColor6.Clear();
            RR_X1ValuesChartColor6.Clear();
            RR_Y1ValuesChartColor6.Clear();
            RR_Z1ValuesChartColor6.Clear();

            FL_X1ValuesChartColor7.Clear();
            FL_Y1ValuesChartColor7.Clear();
            FL_Z1ValuesChartColor7.Clear();
            FR_X1ValuesChartColor7.Clear();
            FR_Y1ValuesChartColor7.Clear();
            FR_Z1ValuesChartColor7.Clear();
            RL_X1ValuesChartColor7.Clear();
            RL_Y1ValuesChartColor7.Clear();
            RL_Z1ValuesChartColor7.Clear();
            RR_X1ValuesChartColor7.Clear();
            RR_Y1ValuesChartColor7.Clear();
            RR_Z1ValuesChartColor7.Clear();

            FL_X1ValuesChartColor8.Clear();
            FL_Y1ValuesChartColor8.Clear();
            FL_Z1ValuesChartColor8.Clear();
            FR_X1ValuesChartColor8.Clear();
            FR_Y1ValuesChartColor8.Clear();
            FR_Z1ValuesChartColor8.Clear();
            RL_X1ValuesChartColor8.Clear();
            RL_Y1ValuesChartColor8.Clear();
            RL_Z1ValuesChartColor8.Clear();
            RR_X1ValuesChartColor8.Clear();
            RR_Y1ValuesChartColor8.Clear();
            RR_Z1ValuesChartColor8.Clear();

            FL_X1ValuesChartColor9.Clear();
            FL_Y1ValuesChartColor9.Clear();
            FL_Z1ValuesChartColor9.Clear();
            FR_X1ValuesChartColor9.Clear();
            FR_Y1ValuesChartColor9.Clear();
            FR_Z1ValuesChartColor9.Clear();
            RL_X1ValuesChartColor9.Clear();
            RL_Y1ValuesChartColor9.Clear();
            RL_Z1ValuesChartColor9.Clear();
            RR_X1ValuesChartColor9.Clear();
            RR_Y1ValuesChartColor9.Clear();
            RR_Z1ValuesChartColor9.Clear();

            FL_X1ValuesChartColor10.Clear();
            FL_Y1ValuesChartColor10.Clear();
            FL_Z1ValuesChartColor10.Clear();
            FR_X1ValuesChartColor10.Clear();
            FR_Y1ValuesChartColor10.Clear();
            FR_Z1ValuesChartColor10.Clear();
            RL_X1ValuesChartColor10.Clear();
            RL_Y1ValuesChartColor10.Clear();
            RL_Z1ValuesChartColor10.Clear();
            RR_X1ValuesChartColor10.Clear();
            RR_Y1ValuesChartColor10.Clear();
            RR_Z1ValuesChartColor10.Clear();

        }
        /// <summary>
        /// THIS NEEDS TO BE CHANGED TO USE THE ENUMS INSTEAD OF INDEXES AND STRINGS!
        /// </summary>
        /// <param name="xyzSelection"></param>
        /// <param name="none"></param>
        /// <param name="raceTime"></param>
        /// <param name="liveDataList"></param>
        /// <returns></returns>
        public static List<float> ListSelections(List<string> xyzSelection, int none, int raceTime, Enum prefix)//, List<float> liveDataList)
        {
            List<float> xyzValues = new List<float>();

            for (int i = 0; i < xyzSelection.Count; i++)
            {
                if (xyzSelection[i] == nameof(AllValueNames.TravelSpeed))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TravelSpeed.GetType()), WF_TireDataOffset.TravelSpeed)].Value);//liveDataList[0]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.AngularVelocity))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value);//liveDataList[1]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.VerticalLoad))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.VerticalLoad.GetType()), WF_TireDataOffset.VerticalLoad)].Value);//liveDataList[2]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.VerticalDeflection))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.VerticalDeflection.GetType()), WF_TireDataOffset.VerticalDeflection)].Value);//liveDataList[3]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LoadedRadius))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LoadedRadius.GetType()), WF_TireDataOffset.LoadedRadius)].Value);//liveDataList[4]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.EffectiveRadius))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.EffectiveRadius.GetType()), WF_TireDataOffset.EffectiveRadius)].Value);//liveDataList[5]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.ContactLength))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.ContactLength.GetType()), WF_TireDataOffset.ContactLength)].Value);//liveDataList[6]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.CurrentContactBrakeTorque))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.CurrentContactBrakeTorque.GetType()), WF_TireDataOffset.CurrentContactBrakeTorque)].Value);//liveDataList[7]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.CurrentContactBrakeTorqueMax))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.CurrentContactBrakeTorqueMax.GetType()), WF_TireDataOffset.CurrentContactBrakeTorqueMax)].Value);//iveDataList[8]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.SteerAngleDeg))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.SteerAngleDeg.GetType()), WF_TireDataOffset.SteerAngleDeg)].Value);//liveDataList[9]);//WF_TireDataCalculated
                }
                else if (xyzSelection[i] == nameof(AllValueNames.CamberAngleDeg))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.CamberAngleDeg.GetType()), WF_TireDataOffset.CamberAngleDeg)].Value);//liveDataList[10]);//WF_TireDataCalculated
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LateralLoad))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LateralLoad.GetType()), WF_TireDataOffset.LateralLoad)].Value);//liveDataList[11]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.SlipAngleDeg))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.SlipAngleDeg.GetType()), WF_TireDataOffset.SlipAngleDeg)].Value);//liveDataList[12]);//WF_TireDataCalculated
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LateralFriction))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LateralFriction.GetType()), WF_TireDataOffset.LateralFriction)].Value);//liveDataList[13]);//WF_TireDataCalculated
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LateralSlipSpeed))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LateralSlipSpeed.GetType()), WF_TireDataOffset.LateralSlipSpeed)].Value);//liveDataList[14]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LongitudinalLoad))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LongitudinalLoad.GetType()), WF_TireDataOffset.LongitudinalLoad)].Value);//liveDataList[15]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.SlipRatio))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.SlipRatio.GetType()), WF_TireDataOffset.SlipRatio)].Value);//liveDataList[16]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LongitudinalFriction))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LongitudinalFriction.GetType()), WF_TireDataOffset.LongitudinalFriction)].Value);//liveDataList[17]);//WF_TireDataCalculated
                }
                else if (xyzSelection[i] == nameof(AllValueNames.LongitudinalSlipSpeed))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.LongitudinalSlipSpeed.GetType()), WF_TireDataOffset.LongitudinalSlipSpeed)].Value);//liveDataList[18]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.TreadTemperature))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TreadTemperature.GetType()), WF_TireDataOffset.TreadTemperature)].Value);//liveDataList[19]);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.InnerTemperature))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.InnerTemperature.GetType()), WF_TireDataOffset.InnerTemperature)].Value);//liveDataList[20]);
                }
                else if (xyzSelection[i] == nameof(WF_TimeDataOffset.RaceTime))//LogSettings.sRaceTime)
                {
                    xyzValues.Add(raceTime);
                }
                else if (xyzSelection[i] == nameof(AllValueNames.TotalFriction))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TotalFriction.GetType()), WF_TireDataOffset.TotalFriction)].Value);//liveDataList[21]);//WF_TireDataCalculated
                }
                else if (xyzSelection[i] == nameof(AllValueNames.TotalFrictionAngleDeg))
                {
                    xyzValues.Add(LiveData.FullDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TotalFrictionAngleDeg.GetType()), WF_TireDataOffset.TotalFrictionAngleDeg)].Value);//liveDataList[22]);//WF_TireDataCalculated
                }/*
                else if (xyzSelection[i] == nameof(AllValueName.SuspensionLength))
                {
                    xyzValues.Add(LiveData.TireDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.SuspensionLength.GetType()), WF_TireDataOffset.SuspensionLength)].Value);//liveDataList[23]);
                }
                else if (xyzSelection[i] == nameof(AllValueName.SuspensionVelocity))
                {
                    xyzValues.Add(LiveData.TireDataList[Array.IndexOf(Enum.GetValues(prefix.GetType()), prefix)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.SuspensionVelocity.GetType()), WF_TireDataOffset.SuspensionVelocity)].Value);//liveDataList[24]);
                }*/
                else//fallback to none
                {
                    xyzValues.Add(none);
                }
            }
            //Return the XYZ values array
            return xyzValues;
        }
        private static void AddColorDataAndHandleHistoryBuffer(List<float> colorValues, float data)
        {
            if (_4WheelsSettings.AbsoluteValues == true)
            {
                colorValues.Add(Math.Abs(data));
            }
            else
            {
                colorValues.Add(data);
            }
            if (colorValues.Count > _4WheelsSettings.HistoryAmountPoints)
            {
                colorValues.RemoveAt(0);
            }
        }
        private static void ColorGradient(List<float> xyzValues,
            List<float> xValuesColor1, List<float> yValuesColor1,
            List<float> xValuesColor2, List<float> yValuesColor2,
            List<float> xValuesColor3, List<float> yValuesColor3,
            List<float> xValuesColor4, List<float> yValuesColor4,
            List<float> xValuesColor5, List<float> yValuesColor5,
            List<float> xValuesColor6, List<float> yValuesColor6,
            List<float> xValuesColor7, List<float> yValuesColor7,
            List<float> xValuesColor8, List<float> yValuesColor8,
            List<float> xValuesColor9, List<float> yValuesColor9,
            List<float> xValuesColor10, List<float> yValuesColor10)
        {

            //float Xdata = Math.Abs(xyzValues[0]);
            //float Ydata = Math.Abs(xyzValues[1]);
            float Zdata = Math.Abs(xyzValues[2]);

            float minus = (float)(_4WheelsSettings.Z1Max - _4WheelsSettings.Z1Min) / Steps;
            float ten = (float)_4WheelsSettings.Z1Max;
            float nine = ten - minus;
            float eight = nine - minus;
            float seven = eight - minus;
            float six = seven - minus;
            float five = six - minus;
            float four = five - minus;
            float three = four - minus;
            float two = three - minus;
            float one = two - minus;
            float zero = one - minus;

            if (Zdata >= nine)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor10, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor10, xyzValues[1]);
            }
            else if (Zdata < nine && Zdata >= eight)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor9, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor9, xyzValues[1]);
            }
            else if (Zdata < eight && Zdata >= seven)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor8, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor8, xyzValues[1]);
            }
            else if (Zdata < seven && Zdata >= six)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor7, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor7, xyzValues[1]);
            }
            else if (Zdata < six && Zdata >= five)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor6, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor6, xyzValues[1]);
            }
            else if (Zdata < five && Zdata >= four)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor5, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor5, xyzValues[1]);
            }
            else if (Zdata < four && Zdata >= three)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor4, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor4, xyzValues[1]);
            }
            else if (Zdata < three && Zdata >= two)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor3, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor3, xyzValues[1]);
            }
            else if (Zdata < two && Zdata >= one)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor2, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor2, xyzValues[1]);
            }
            else if (Zdata < one && Zdata >= zero)
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor1, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor1, xyzValues[1]);
            }
            else
            {
                AddColorDataAndHandleHistoryBuffer(xValuesColor1, xyzValues[0]);
                AddColorDataAndHandleHistoryBuffer(yValuesColor1, xyzValues[1]);
            }
        }
        public static bool OverTheChosenLimiter(float limiter, string limiterSelection, double limiterMax, double limiterMin)
        {
            bool limiterIsAbsoluteValue = WreckfestEnums.DataNameStringsAbsoluteValues.Contains(limiterSelection);
            if (limiterIsAbsoluteValue == true)
            {
                if (Math.Abs(limiter) > limiterMax || Math.Abs(limiter) < limiterMin)
                {
                    return true;
                }
            }
            else if (limiter > limiterMax || limiter < limiterMin)
            {
                return true;
            }
            return false;
        }

        public static void ListSeries(Chart chartName, string seriesName, List<float> xyzValues, List<float> limiter, float noTireContactLimiter,
                                        List<float> X1Values, List<float> Y1Values, List<float> Z1Values,
                                        List<float> X1ValuesColor1, List<float> Y1ValuesColor1,
                                        List<float> X1ValuesColor2, List<float> Y1ValuesColor2,
                                        List<float> X1ValuesColor3, List<float> Y1ValuesColor3,
                                        List<float> X1ValuesColor4, List<float> Y1ValuesColor4,
                                        List<float> X1ValuesColor5, List<float> Y1ValuesColor5,
                                        List<float> X1ValuesColor6, List<float> Y1ValuesColor6,
                                        List<float> X1ValuesColor7, List<float> Y1ValuesColor7,
                                        List<float> X1ValuesColor8, List<float> Y1ValuesColor8,
                                        List<float> X1ValuesColor9, List<float> Y1ValuesColor9,
                                        List<float> X1ValuesColor10, List<float> Y1ValuesColor10)
        {
            if (_4WheelsSettings.AbsoluteValues == true)
            {
                xyzValues[0] = Math.Abs(xyzValues[0]);
                xyzValues[1] = Math.Abs(xyzValues[1]);
                xyzValues[2] = Math.Abs(xyzValues[2]);
            }
            // No tire contact, no data added
            if (Form4Wheels.NoTireContactLimiterEnabled == true)
            {
                if (noTireContactLimiter == 0)
                {
                    return;
                }
            }
            //Limiter filters
            if (Form4Wheels.LimitersEnabled == true)
            {
                bool isOverTheLimiterX1 = _4Wheels.OverTheChosenLimiter(limiter[0], Form4Wheels.X1LimiterSelection, Form4Wheels.X1LimiterMax, Form4Wheels.X1LimiterMin);
                bool isOverTheLimiterY1 = _4Wheels.OverTheChosenLimiter(limiter[1], Form4Wheels.Y1LimiterSelection, Form4Wheels.Y1LimiterMax, Form4Wheels.Y1LimiterMin);
                bool isOverTheLimiterZ1 = _4Wheels.OverTheChosenLimiter(limiter[2], Form4Wheels.Z1LimiterSelection, Form4Wheels.Z1LimiterMax, Form4Wheels.Z1LimiterMin);
                if (isOverTheLimiterX1 || isOverTheLimiterY1 || isOverTheLimiterZ1 == true)
                {
                    return;
                }
            }
            // Add data if the previous stuff didn't return back
            X1Values.Add(xyzValues[0]);
            Y1Values.Add(xyzValues[1]);
            Z1Values.Add(xyzValues[2]);

            if (X1Values.Count > 1)
            {
                X1Values.RemoveAt(0);
                Y1Values.RemoveAt(0);
                Z1Values.RemoveAt(0);
            }

            ColorGradient(xyzValues,
            X1ValuesColor1, Y1ValuesColor1,
            X1ValuesColor2, Y1ValuesColor2,
            X1ValuesColor3, Y1ValuesColor3,
            X1ValuesColor4, Y1ValuesColor4,
            X1ValuesColor5, Y1ValuesColor5,
            X1ValuesColor6, Y1ValuesColor6,
            X1ValuesColor7, Y1ValuesColor7,
            X1ValuesColor8, Y1ValuesColor8,
            X1ValuesColor9, Y1ValuesColor9,
            X1ValuesColor10, Y1ValuesColor10);

            chartName.Series[seriesName].Points.DataBindXY(X1Values, Y1Values);
            chartName.Series[seriesName + seriesColor1].Points.DataBindXY(X1ValuesColor1, Y1ValuesColor1);
            chartName.Series[seriesName + seriesColor2].Points.DataBindXY(X1ValuesColor2, Y1ValuesColor2);
            chartName.Series[seriesName + seriesColor3].Points.DataBindXY(X1ValuesColor3, Y1ValuesColor3);
            chartName.Series[seriesName + seriesColor4].Points.DataBindXY(X1ValuesColor4, Y1ValuesColor4);
            chartName.Series[seriesName + seriesColor5].Points.DataBindXY(X1ValuesColor5, Y1ValuesColor5);
            chartName.Series[seriesName + seriesColor6].Points.DataBindXY(X1ValuesColor6, Y1ValuesColor6);
            chartName.Series[seriesName + seriesColor7].Points.DataBindXY(X1ValuesColor7, Y1ValuesColor7);
            chartName.Series[seriesName + seriesColor8].Points.DataBindXY(X1ValuesColor8, Y1ValuesColor8);
            chartName.Series[seriesName + seriesColor9].Points.DataBindXY(X1ValuesColor9, Y1ValuesColor9);
            chartName.Series[seriesName + seriesColor10].Points.DataBindXY(X1ValuesColor10, Y1ValuesColor10);

            //ForLoopAxisList(chartName, 1, xValues, yValues, zValues);
            chartName.Series[seriesName].Points.Last().MarkerSize = 8;
            chartName.Series[seriesName].Points.Last().MarkerColor = _4WheelsSettings.MarkerColor;// Color.FromArgb(255, 255, 0, 0);
            chartName.Series[seriesName].Points.Last().IsValueShownAsLabel = false;//true;
        }
    }
}
