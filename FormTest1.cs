using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public partial class FormTest1 : Form
    {
        public FormTest1()
        {
            InitializeComponent();
        }

        public static void Test()
        {
            /*
            foreach (int i in Enum.GetValues(typeof(WF_TireDataOffset)))
            {
                LiveData.FL_TireDataList.Add(new DataItem { Id = (int)WF_Prefix.FL + (int)(WF_TireDataOffset)i, Name = WF_Prefix.FL + "_" + (WF_TireDataOffset)i });
            }
            LiveData.FullDataList.Add(LiveData.FL_TireDataList);

            foreach (int i in Enum.GetValues(typeof(WF_TireDataOffset)))
            {
                LiveData.FR_TireDataList.Add(new DataItem { Id = (int)WF_Prefix.FR + (int)(WF_TireDataOffset)i, Name = WF_Prefix.FR + "_" + (WF_TireDataOffset)i });
            }
            LiveData.FullDataList.Add(LiveData.FR_TireDataList);

            foreach (int i in Enum.GetValues(typeof(WF_TireDataOffset)))
            {
                LiveData.RL_TireDataList.Add(new DataItem { Id = (int)WF_Prefix.RL + (int)(WF_TireDataOffset)i, Name = WF_Prefix.FR + "_" + (WF_TireDataOffset)i });
            }
            LiveData.FullDataList.Add(LiveData.RL_TireDataList);

            foreach (int i in Enum.GetValues(typeof(WF_TireDataOffset)))
            {
                LiveData.RR_TireDataList.Add(new DataItem { Id = (int)WF_Prefix.RR + (int)(WF_TireDataOffset)i, Name = WF_Prefix.FR + "_" + (WF_TireDataOffset)i });
            }
            LiveData.FullDataList.Add(LiveData.RR_TireDataList);
            */
            /*
            List<RawDataItem> body = new List<RawDataItem>();
            body.Add(new RawDataItem { Id = 1000, Name = "X_Acceleration", Value = 3.3f });
            LiveData.TireDataList.Add(body);
            */
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[0][0].Id, LiveData.TireDataList[0][0].Name, LiveData.TireDataList[0][0].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[0][1].Id, LiveData.TireDataList[0][1].Name, LiveData.TireDataList[0][1].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[0][2].Id, LiveData.TireDataList[0][2].Name, LiveData.TireDataList[0][2].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[0][3].Id, LiveData.TireDataList[0][3].Name, LiveData.TireDataList[0][3].Value);
            // etc.
            foreach (var subList in LiveData.FullDataList)
            {
                foreach (var item in subList)
                {
                    Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", item.Id, item.Name, item.Value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine("Values changed and written in different order in the console:");
            Console.WriteLine();

            //Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia);//gets index instead of the value
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value = 1.8f;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value = 16;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value = 36;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value = 0.320f;

            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value = 1.9f;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value = 17;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value = 37;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value = 0.321f;

            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value = 2.0f;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value = 18;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value = 38;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value = 0.322f;

            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value = 2.1f;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value = 19;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value = 39;
            LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value = 0.323f;


            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[0][0].Id, LiveData.TireDataList[0][0].Name, LiveData.TireDataList[0][0].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[1][0].Id, LiveData.TireDataList[1][0].Name, LiveData.TireDataList[1][0].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[2][0].Id, LiveData.TireDataList[2][0].Name, LiveData.TireDataList[2][0].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[3][0].Id, LiveData.TireDataList[3][0].Name, LiveData.TireDataList[3][0].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.MomentOfInertia.GetType()), WF_TireDataOffset.MomentOfInertia)].Value);

            Console.WriteLine();

            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[0][1].Id, LiveData.TireDataList[0][1].Name, LiveData.TireDataList[0][1].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[1][1].Id, LiveData.TireDataList[1][1].Name, LiveData.TireDataList[1][1].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[2][1].Id, LiveData.TireDataList[2][1].Name, LiveData.TireDataList[2][1].Value);
            //Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.TireDataList[3][1].Id, LiveData.TireDataList[3][1].Name, LiveData.TireDataList[3][1].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.AngularVelocity.GetType()), WF_TireDataOffset.AngularVelocity)].Value);

            Console.WriteLine();

            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireMass.GetType()), WF_TireDataOffset.TireMass)].Value);

            Console.WriteLine();

            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FL.GetType()), WF_Prefix.FL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.FR.GetType()), WF_Prefix.FR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RL.GetType()), WF_Prefix.RL)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value);
            Console.WriteLine("Id:{0}; Name:{1}; Value:{2};", LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Id, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Name, LiveData.FullDataList[Array.IndexOf(Enum.GetValues(WF_Prefix.RR.GetType()), WF_Prefix.RR)][Array.IndexOf(Enum.GetValues(WF_TireDataOffset.TireRadius.GetType()), WF_TireDataOffset.TireRadius)].Value);
        }
    }
}
