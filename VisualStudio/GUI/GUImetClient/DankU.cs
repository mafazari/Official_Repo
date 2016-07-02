using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using GUImetClient;
using System.Timers;

namespace GUI_Project_periode_3
{
    public partial class DankU : Form
    {
        ///System.Timers.Timer timer = new System.Windows.Forms.Timer(6000);

        public DankU()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void DankU_Load(object sender, EventArgs e)
        {
            gotoBeginScreen();
        }

        private void gotoBeginScreen()
        {
            ArduinoClass ac = new ArduinoClass();
            this.Refresh();
            this.Show();
            this.Refresh();
            System.Threading.Thread.Sleep(5000);
            ac.closePort("COM6");                   //CLOSE PORT
            for(int i = Application.OpenForms.Count -1; i >=0; i--)
            {
                //if (Application.OpenForms[i].Name != "DankU")
                    Application.OpenForms[i].Close();
            }
            new Beginscherm().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI_Project_periode_3.Home.ActiveForm.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            new Beginscherm().Show();
            Thread.Sleep(1);
            this.Close();
        }
    }
}
