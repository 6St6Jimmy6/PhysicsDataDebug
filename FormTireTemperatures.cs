using System;
using System.Windows.Forms;
using System.Threading;

namespace Physics_Data_Debug
{
    public partial class FormTireTemperatures : Form
    {
        #region Fields variables
        private Thread update;
        private int sleep = 50;
        private bool updatedStartedOnce = false;

        // How long array is.
        private readonly double[] flsTempArray = new double[300];
        private readonly double[] fliTempArray = new double[300];
        private readonly double[] frsTempArray = new double[300];
        private readonly double[] friTempArray = new double[300];
        private readonly double[] rlsTempArray = new double[300];
        private readonly double[] rliTempArray = new double[300];
        private readonly double[] rrsTempArray = new double[300];
        private readonly double[] rriTempArray = new double[300];
        #endregion

        public FormTireTemperatures()
        {
            InitializeComponent();
            update = new Thread(new ThreadStart(getData));
            update.IsBackground = true;
        }

        #region Methods
        private void getData()
        {
            while (true)
            {
                

                if (temperaturesFL.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { TemperatureSeries(); });
                }
                else
                {
                    //....
                }
                Thread.Sleep(sleep);
            }
        }
        private void TemperatureSeries()
        {
            flsTempArray[flsTempArray.Length - 1] = Math.Round(FormLiveData.FL_TreadTemperature, 10);//Bigger round value gives smoother drawing.
            fliTempArray[fliTempArray.Length - 1] = Math.Round(FormLiveData.FL_InnerTemperature, 10);
            frsTempArray[frsTempArray.Length - 1] = Math.Round(FormLiveData.FR_TreadTemperature, 10);
            friTempArray[friTempArray.Length - 1] = Math.Round(FormLiveData.FR_InnerTemperature, 10);
            rlsTempArray[rlsTempArray.Length - 1] = Math.Round(FormLiveData.RL_TreadTemperature, 10);
            rliTempArray[rliTempArray.Length - 1] = Math.Round(FormLiveData.RL_InnerTemperature, 10);
            rrsTempArray[rrsTempArray.Length - 1] = Math.Round(FormLiveData.RR_TreadTemperature, 10);
            rriTempArray[rriTempArray.Length - 1] = Math.Round(FormLiveData.RR_InnerTemperature, 10);

            Array.Copy(flsTempArray, 1, flsTempArray, 0, flsTempArray.Length - 1);
            Array.Copy(fliTempArray, 1, fliTempArray, 0, fliTempArray.Length - 1);
            Array.Copy(frsTempArray, 1, frsTempArray, 0, frsTempArray.Length - 1);
            Array.Copy(friTempArray, 1, friTempArray, 0, friTempArray.Length - 1);
            Array.Copy(rlsTempArray, 1, rlsTempArray, 0, rlsTempArray.Length - 1);
            Array.Copy(rliTempArray, 1, rliTempArray, 0, rliTempArray.Length - 1);
            Array.Copy(rrsTempArray, 1, rrsTempArray, 0, rrsTempArray.Length - 1);
            Array.Copy(rriTempArray, 1, rriTempArray, 0, rriTempArray.Length - 1);

            temperaturesFL.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < flsTempArray.Length - 1; ++i)
            {
                temperaturesFL.Series["Tread °C"].Points.AddY(flsTempArray[i]);
            }

            temperaturesFL.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < fliTempArray.Length - 1; ++i)
            {
                temperaturesFL.Series["Inner °C"].Points.AddY(fliTempArray[i]);
            }

            temperaturesFR.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < frsTempArray.Length - 1; ++i)
            {
                temperaturesFR.Series["Tread °C"].Points.AddY(frsTempArray[i]);
            }

            temperaturesFR.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < friTempArray.Length - 1; ++i)
            {
                temperaturesFR.Series["Inner °C"].Points.AddY(friTempArray[i]);
            }

            temperaturesRL.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < rlsTempArray.Length - 1; ++i)
            {
                temperaturesRL.Series["Tread °C"].Points.AddY(rlsTempArray[i]);
            }

            temperaturesRL.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < rliTempArray.Length - 1; ++i)
            {
                temperaturesRL.Series["Inner °C"].Points.AddY(rliTempArray[i]);
            }

            temperaturesRR.Series["Tread °C"].Points.Clear();

            for (int i = 0; i < rrsTempArray.Length - 1; ++i)
            {
                temperaturesRR.Series["Tread °C"].Points.AddY(rrsTempArray[i]);
            }

            temperaturesRR.Series["Inner °C"].Points.Clear();

            for (int i = 0; i < rriTempArray.Length - 1; ++i)
            {
                temperaturesRR.Series["Inner °C"].Points.AddY(rriTempArray[i]);
            }
            textBox_FL_TreadTemperature.Text = Math.Round(FormLiveData.FL_TreadTemperature, 2).ToString();
            textBox_FL_InnerTemperature.Text = Math.Round(FormLiveData.FL_InnerTemperature, 2).ToString();
            textBox_FR_TreadTemperature.Text = Math.Round(FormLiveData.FR_TreadTemperature, 2).ToString();
            textBox_FR_InnerTemperature.Text = Math.Round(FormLiveData.FR_InnerTemperature, 2).ToString();
            textBox_RL_TreadTemperature.Text = Math.Round(FormLiveData.RL_TreadTemperature, 2).ToString();
            textBox_RL_InnerTemperature.Text = Math.Round(FormLiveData.RL_InnerTemperature, 2).ToString();
            textBox_RR_TreadTemperature.Text = Math.Round(FormLiveData.RR_TreadTemperature, 2).ToString();
            textBox_RR_InnerTemperature.Text = Math.Round(FormLiveData.RR_InnerTemperature, 2).ToString();
        }
        #endregion

        #region Form buttons etc
        private void TireTemperatures_Load(object sender, EventArgs e)
        {
            updatedStartedOnce = false;
            //update.Start();
        }
        private void TireTemperatures_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updatedStartedOnce == true)
            {
                update.Suspend();
            }
            updatedStartedOnce = false;

        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            //First_All_Data_Logger_Page fadlp = new First_All_Data_Logger_Page();
            //fadlp.Show();
            this.Close();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            if(updatedStartedOnce == false)
            {
                update.Start();
                updatedStartedOnce = true;
            }
            else
            {
                update.Resume();
            }
            
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            if(updatedStartedOnce == true)
            {
                update.Suspend();
            }
            
            //update.Abort();
        }
        #endregion
    }
}
