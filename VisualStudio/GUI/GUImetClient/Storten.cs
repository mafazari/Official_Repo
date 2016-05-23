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
using System.Threading;

namespace GUI_Project_periode_3
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form8().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            Thread.Sleep(1);
            this.Close();
        }
    }
}
