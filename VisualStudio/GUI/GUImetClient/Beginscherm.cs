using GUI_Project_periode_3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUImetClient
{
    public partial class Beginscherm : Form
    {
        public Beginscherm()
        {
            InitializeComponent();
        }

        private void Beginscherm_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Refresh();
            Extraladen();
        }

        private void Extraladen()
        {
            ArduinoClass bootup = new ArduinoClass();
            bootup.makePort("COM6");

            Form2 pinInvoer = new Form2();
            Form1 home = new Form1();
            ArduinoData arduino = new ArduinoData();
            Hash security = new Hash();
            Executer executer;
            Boolean reset = false;
            Boolean pinCorrect;
            String[] pasInformation;
            bool EE = true;
            while (true)
            {
                pinCorrect = false;
                pasInformation = new String[4];
                reset = false;
                executer = null;
                String KlantID;
                String rekeningID;
                String pasID;
                HTTPget httpget = new HTTPget();
                HTTPpost httppost = new HTTPpost();

                while (true)
                {
                    String s = arduino.getFirstString();
                    if (s.Contains(" ,NEWUID"))
                    {
                        pasInformation = s.Split('\n', '\n', '\n');
                        KlantID = pasInformation[2];
                        rekeningID = pasInformation[1];
                        pasID = pasInformation[0];
                        break;
                    }
                    pinInvoer.Show();
                }
                if (!httpget.getActiefStand(pasID))
                {
                    BlockScreen tmp = new BlockScreen();
                    break;
                }
                pinInvoer.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            //new Form1().Show();
            //Thread.Sleep(1);
            //this.Hide();

            new Form1().Show();
            Thread.Sleep(1);
            this.Close();
        }
    }
}
