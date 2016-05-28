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

namespace GUI_Project_periode_3
{
    public partial class PinInvoer : Form
    {
        public PinInvoer()
        {   
            InitializeComponent();
            
        }

        SerialPort pininv = ArduinoClass.getPort();

        private void Form2_Load(object sender, EventArgs e)
        {
            ArduinoData arduino = new ArduinoData();
            HTTPget httpget = new HTTPget();
            Hash security = new Hash();
            Boolean pinCorrect = false;
            //bool EE = true;

            this.Show();
            this.Refresh();
            String pincode = "";

            Label[] lblarr = new Label[4];
            fillarr(lblarr);
            while (pinCorrect == false)
            {
                int insertedDigits = 0;
                Boolean confirmed = false;
                while (confirmed == false)
                {
                    String input = arduino.getString();
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

                    else if (input.Contains("CKEY"))
                    {
                        clearall();
                        insertedDigits = 0;
                    }
                    else if (input.Contains("*KEY")) // NEEDS TO BE REMOVED WHEN if (PinCorrect == true) WORKS
                    {
                        Error.show(pincode);
                        new Home().Show();
                        Thread.Sleep(1);
                        this.Hide();
                        break;
                    }

                    if (insertedDigits == 4)
                    {
                        if (input.Contains("*")) { confirmed = true; }
                    }
                    String hashEmu = "MTEyNDg2NDkxMjM0";
                    int rekEmu = 11248649;
                    int pinEmu = Convert.ToInt32(pincode);

                    if (security.makeHash(rekEmu, pinEmu) == hashEmu)                  //missing pinCorrect checker
                    {
                        new Home().Show();
                        Thread.Sleep(1);
                        this.Hide();
                        break;
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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = ArduinoClass.strInput();
            new Home().Show();
            this.Hide();
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

        private void Start()
        {
            while (true)
            {
                ArduinoClass.getPort();
            }

        }

        private void label3_TextChanged(object sender, EventArgs e)
        {

        }

        private void accept(object sender, EventArgs e)
        {
            ArduinoClass.strInput();
            String read = pininv.ReadLine();

            if (read.Contains("*KEY"))
                {

                    new Home().Show();
                    Thread.Sleep(1);
                    this.Hide();  

                }
        }
}
}
