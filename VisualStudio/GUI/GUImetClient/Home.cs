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
        
        public static string pasID;                                                                         //SOLUTION FOR STATIC SHIT-------> CONSTRUCTORS? vb. void Home(string pasID, string klantID, string rekeningID);
        public static string klantID;
        public static string rekeningID;
        ArduinoData ad = new ArduinoData();
        PinInvoer pinInvoer = new PinInvoer();
        HTTPget httpget = new HTTPget();
        HTTPpost httppost = new HTTPpost();
        int amount;
        //Error.show(rekeningID);

        public void giveInfo(string[] x)
        {
            Home.pasID = x[0];
            Home.rekeningID = x[1];
            Home.klantID = x[2];
            
            //Error.show("HOMESCREEN INFO"  + "\nRekeningID: " + rekeningID + "\nKlantID: " + klantID+ "\npasID: " + pasID);
        }

        public void setRekID(string r)
        {
            Home.rekeningID = r;
            //Error.show(Home.rekeningID);
        }

        public string getRekID()
        {
            return Home.rekeningID;
            //Error.show(rekeningID);
        }

        public string getPasID()
        {
            return Home.pasID;
            //Error.show(pasID);
        }

        public string getKlantID()
        {
            return Home.klantID;
            //Error.show(klantID);
        }




        public Home()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //int rekID = Convert.ToInt32(getRekID());
            //Error.show("HOMESCREEN Form1_Load INFO" + "\nRekeningID string: " + getRekID() + "\nRekeningID int: " + rekID + "\nKlantID: " + getKlantID() + "\npasID: " + getPasID());
            this.Refresh();
            Executer exec = new Executer(rekeningID, klantID, ad, pasID);
            while (true)
            {
                String input = ad.getString();
                if (input.Contains("AKEY") || input.Contains("BKEY") || input.Contains("CKEY") || input.Contains("#KEY"))
                {
                    String caseSwitch = input;    // CAN ONLY BE A, B, C or #

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
                            httppost.UpdateBalans(Home.rekeningID, (exec.saldo - amount));
                            new DankU().Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "#KEY": //stoppen
                            new Stoppen().Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                    }
                }
            }
        }
        /*whle(true)
        {
            String koekje = ad.getString();
            if(koekje.Contains("A"))
            {
                break;  
            }
            else if(koekje.Contains("B"))
                {
                break;
            }

        }*/

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
