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
    public partial class Storten : Form
    {
        public Storten()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Bon().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DankU().Show();
            Thread.Sleep(1);
            this.Close();
        }
    }
}
