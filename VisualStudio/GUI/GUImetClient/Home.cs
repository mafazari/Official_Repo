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
using System.IO.Ports;
using GUImetClient;
using GUI_Project_periode_3;

namespace GUI_Project_periode_3
{

    public partial class Form1 : Form
    {

  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            ArduinoClass bootup = new ArduinoClass();
            bootup.makePort("COM6");
            ArduinoData ad = new ArduinoData();


            String caseSwitch = ad.getString();
            switch (caseSwitch)
            {
                case "AKEY":
                    new Form4().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "BKEY":
                    new Form6().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "CKEY":
                    new Form7().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "#KEY" :
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


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Form4().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            /*
            new Form6().Show();
            Thread.Sleep(1);
            this.Close();*/
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new Form7().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new Form9().Show();
            Thread.Sleep(1);
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
          //  new Form7().Show();
          //  Thread.Sleep(1);
          //  this.Close();
        }

        public void nextPageSaldo()
        {

            Executer ex = new Executer("11248648", "1", new ArduinoData(), "68,4,247,53,130");
            ex.checkSaldo();
        }
    }
}
