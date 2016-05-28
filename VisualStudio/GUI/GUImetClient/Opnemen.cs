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
    public partial class Opnemen : Form
    {
        public Opnemen()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            String caseString = ad.getString();

            switch (caseString)
            {
                case "1KEY": //10 euro ---> httppost -10euro
                    new Bon().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "3KEY": //20 euro
                    new Bon().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "4KEY": //50 euro
                    new Bon().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "6KEY": //70 euro
                    new Bon().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "7KEY": //bedrag invoer
                    new Bedraginvoer().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "#KEY": //afbreken
                    new Stoppen().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI_Project_periode_3.Home.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Transactie().Show();
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
            new Transactie().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Transactie().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Transactie().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Bedraginvoer().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new DankU().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
