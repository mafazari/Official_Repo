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

namespace GUI_Project_periode_3
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        public void Form9_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            String caseString = ad.getString();

            switch (caseString)
            {
                case "*KEY":
                    new Form7().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "#KEY":
                    new Form1().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

       
    }
}
