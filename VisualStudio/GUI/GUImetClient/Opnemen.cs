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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            String caseString = ad.getString();

            switch (caseString)
            {
                case "1KEY":
                    break;
                case "3KEY":
                    break;
                case "4KEY":
                    break;
                case "6KEY":
                    break;
                case "7KEY":
                    new Form3().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "#KEY":
                    new Form9().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI_Project_periode_3.Form1.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
