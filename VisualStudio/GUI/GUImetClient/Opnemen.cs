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
using GUI_Project_periode_3;
using System.IO.Ports;

namespace GUI_Project_periode_3
{
    public partial class Opnemen : Form
    {
        //public int rekID;
        public static string pasID;
        public string klantID;

        public Opnemen()
        {
            InitializeComponent();
            Cursor.Hide();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            HTTPget httpget = new HTTPget();
            HTTPpost httppost = new HTTPpost();
            Executer exec = new Executer(Home.rekeningID, Home.klantID, ad, Home.pasID);
            ArduinoDispenserClass adc = new ArduinoDispenserClass();
            

            int amount;
            //int rekID = Convert.ToInt32(Home.rekeningID);
            pasID = Home.pasID;
            klantID = Home.klantID;
            while(true)
            {
                String input = ad.getString();
                if (input.Contains("1KEY") || input.Contains("3KEY") || input.Contains("4KEY") || input.Contains("6KEY") || input.Contains("7KEY") || input.Contains("#KEY"))
                {
                    String caseString = input;
                    switch (caseString)
                    {
                        case "1KEY": //10 euro
                            adc.makePort("COM5");
                            amount = 10;
                            httppost.UpdateBalans(Home.rekeningID, (exec.saldo - amount*100));
                            adc.dispense(amount);
                            new Bon(amount,klantID, Home.rekeningID).Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "3KEY": //20 euro
                            adc.makePort("COM5");
                            amount = 20;
                            httppost.UpdateBalans(Home.rekeningID, (exec.saldo - amount * 100));
                            adc.dispense(amount);
                            new Bon(amount,klantID, Home.rekeningID).Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "4KEY": //50 euro
                            adc.makePort("COM5");
                            amount = 50;
                            httppost.UpdateBalans(Home.rekeningID, (exec.saldo - amount * 100));
                            adc.dispense(amount);
                            new Bon(amount,klantID, Home.rekeningID).Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "6KEY": //70 euro
                            adc.makePort("COM5");
                            amount = 70;
                            httppost.UpdateBalans(Home.rekeningID, (exec.saldo - amount * 100));
                            adc.dispense(amount);
                            new Bon(amount,klantID, Home.rekeningID).Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "7KEY": //bedrag invoer
                            new Bedraginvoer().Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "#KEY": //afbreken
                            new Stoppen().Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                    }
                }
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI_Project_periode_3.Home.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new Transactie().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //new Transactie().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //new Transactie().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //new Transactie().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Bedraginvoer().Show();
            Thread.Sleep(1);
            this.Close();
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
