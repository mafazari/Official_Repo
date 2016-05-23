using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Threading;

namespace GUI_Project_periode_3
{
    public partial class BOOT : Form
    {
        public BOOT()
        {
            InitializeComponent();
        }

        private void BOOT_Load(object sender, EventArgs e)
        {

        }

      /*  public static void restart()
        {
            privateRestart();
        }*/


        private void button3_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
        }
    }
}
