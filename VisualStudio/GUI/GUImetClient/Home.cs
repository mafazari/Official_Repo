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
    

    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            //ArduinoClass bootup = new ArduinoClass();
            //bootup.makePort("COM6");
            string pasID;
            string klantID;
            ArduinoData ad = new ArduinoData();
            PinInvoer pinInvoer = new PinInvoer();
            HTTPget httpget = new HTTPget();
            HTTPpost httppost = new HTTPpost();
            Executer exec = new Executer(pinInvoer.getRekID(), pinInvoer.getKlantID(), ad, pinInvoer.getPasID());
            String caseString = ad.getString();

            double amount;
            int rekID = Convert.ToInt16(pinInvoer.getRekID());
            pasID = pinInvoer.getPasID();
            klantID = pinInvoer.getKlantID();


            String caseSwitch = ad.getString();
            switch (caseSwitch)
            {
                case "AKEY": //Geld opnemen
                    new Opnemen().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
                case "BKEY": //Saldo opvragen
                    new Saldo().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
                case "CKEY": //Snel 70 euro
                    amount = 70;
                    httppost.UpdateBalans(rekID, (exec.saldo - amount));
                    new DankU().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
                case "#KEY" :
                    new Stoppen().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI_Project_periode_3.Home.ActiveForm.Close();
        }


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Opnemen().Show();
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
            new DankU().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new Stoppen().Show();
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
