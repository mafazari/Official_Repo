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
    public partial class Bedraginvoer : Form
    {
        public Bedraginvoer()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string pasID;
            string klantID;
            ArduinoData arduino = new ArduinoData();
            PinInvoer pinInvoer = new PinInvoer();
            HTTPget httpget = new HTTPget();
            HTTPpost httppost = new HTTPpost();
            Executer exec = new Executer(Home.rekeningID, Home.klantID, arduino, Home.pasID);
            //String caseString = arduino.getString();

            int amount;
            int rekID = Convert.ToInt32(Home.rekeningID);
            pasID = Home.pasID;
            klantID = Home.klantID;

            string ssaldo = Convert.ToString(exec.saldo);
            //Error.show(ssaldo);

            int bedrag = 0;
            String bedragString = "";
            String input;
            while (true)
            {
                input = arduino.getString();
                if(!input.Contains("*KEY")) //missing other buttons
                {
                    this.Refresh();
                    bedragString += input.ElementAt(0);
                }
                
                bool test;
                //this.Refresh();
                Int32.TryParse(bedragString, out bedrag);
                setDisplay(bedragString);
                //}//Convert.ToString(input);

                //String caseSwitch = arduino.getString();
                switch (input)
                {
                    case "*KEY":
                        amount = bedrag;
                        //Error.show(amount);
                        this.Refresh();
                        
                        httppost.UpdateBalans(rekID, (exec.saldo - amount));
                        new Bon().Show();
                        Thread.Sleep(1);
                        this.Close();
                        break;
                    case "#KEY": // stoppen
                        new Stoppen().Show();
                        Thread.Sleep(1);
                        this.Close();
                        break;
                }
            }
        }
        public void setDisplay(String value)
        {
            bedragInvoerlbl.Text = value + "€";
        }
        public void clearDisplay()
        {
            bedragInvoerlbl.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Opnemen().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI_Project_periode_3.Home.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new Transactie().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void bedragInvoerlbl_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
