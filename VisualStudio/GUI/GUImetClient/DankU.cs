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
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public DankU()
        {
            InitializeComponent();
            Cursor.Hide();
            //timer.Tick += new EventHandler();
            //timer.Interval = 6000;
            //timer.Start();

            // if (timer.Tick == true)

            //{

            //}
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
