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
using System.IO.Ports;
using System.Threading;
using GUImetClient;

namespace GUI_Project_periode_3
{
    public partial class PinInvoer : Form
    {
        public string pasID;
        public string rekeningID;
        public string klantID;

        public PinInvoer()
        {   
            InitializeComponent();
            Cursor.Hide();
        }

        public void giveInfo(string[] x)
        {
            pasID = x[0];
            rekeningID = x[1];
            klantID = x[2];
            //Error.show(rekeningID + "," + klantID + "," + pasID);
        }

        public string getRekID()
        {
            return rekeningID;
        }

        public string getPasID()
        {
            return pasID;
        }

        public string getKlantID()
        {
            return klantID;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Executer ex = new Executer();
            //Beginscherm bs = new Beginscherm();
            ArduinoData arduino = new ArduinoData();
            HTTPget httpget = new HTTPget();
            Hash security = new Hash();
            Boolean pinCorrect = false;
            int attempt = 0;
            
            //bool EE = true;

            this.Show();
            this.Refresh();
            String pincode = "";

            Label[] lblarr = new Label[4];
            fillarr(lblarr);
            while (pinCorrect == false) //while true
            {
                int insertedDigits = 0;
                Boolean confirmed = false;
                String input= "";

                    while (confirmed == false)
                    {
                        input = arduino.getString();
                        if (!input.Contains("NEWUID") && (input.Contains("1") || input.Contains("2") || input.Contains("3") || input.Contains("4KEY") || input.Contains("5KEY") || input.Contains("6KEY") || input.Contains("7KEY") || input.Contains("8KEY") || input.Contains("9KEY") || input.Contains("0KEY")))
                        {

                            if (checkInput(input) == true && insertedDigits < 4)
                            {
                                insertedDigits++;
                                switch (insertedDigits)
                                {
                                    case 1:
                                        label3.Text = "*";
                                        break;
                                    case 2:
                                        label4.Text = "*";
                                        break;
                                    case 3:
                                        label5.Text = "*";
                                        break;
                                    case 4:
                                        label6.Text = "*";
                                        break;
                                }
                                this.Refresh();
                                pincode += input.ElementAt(0);
                                //Error.show(pincode);
                            }

                            if (insertedDigits == 4)
                            {
                                if (input.Contains("*")) { confirmed = true; }
                                if (security.checkHash(rekeningID, pincode) == true)
                                {
                                    new Home().Show();
                                    Thread.Sleep(1);
                                    this.Close();
                                    break;
                                }
                            }
                            int rek = Convert.ToInt32(rekeningID);
                            int pin = Convert.ToInt32(pincode);
                        }
                        if (input.Contains("CKEY")) //Clear all KEY WORKS
                        {
                            pincode = "";                              // USED TO RESET PINCODE TO null WHEN CLEARED
                            clearall();
                            insertedDigits = 0;
                        }
                    }
            }
        }
        private void fillarr(Label[] lblarr)
        {
            lblarr[0] = label3;
            lblarr[1] = label4;
            lblarr[2] = label5;
            lblarr[3] = label6;
        }
        public void clearArr(Label[] lblarr)
        {
                for( int i = 0; i < lblarr.Length; i++)
                {
                    lblarr[i].Text = "";
                }
        }
        private void clearall()
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            this.Refresh();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = ArduinoClass.strInput();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = ArduinoClass.strInput();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = ArduinoClass.strInput();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = ArduinoClass.strInput();
        }


        private Boolean checkInput(String input)
        {

            Boolean result = false;
            for (int i = 0; i < 10; i++)
            {
                if (input.Contains(i.ToString()))
                {
                    result = true;
                    break;
                }
            }
            if (input.Length > 4)
            {
                result = false;
            }
            return result;
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {

        }
}
}
