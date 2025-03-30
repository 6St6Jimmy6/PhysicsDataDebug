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
    public partial class FormTester : Form
    {
        public FormTester()
        {
            InitializeComponent();
        }

        public void loadForm(object Form)
        {
            try
            {
                /*
                if (panelMain.Controls.Count > 0)
                {
                    panelMain.Controls.Clear();
                }*/
                for (int i = panelMain.Controls.Count - 1; i >= 0; --i)
                {
                    panelMain.Controls[i].Dispose();
                }
                Form f = Form as Form;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                panelMain.Controls.Add(f);
                panelMain.Tag = f;
                f.Show();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new FormLiveData());
        }
    }
}
