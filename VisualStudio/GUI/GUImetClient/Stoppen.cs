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
    public partial class Stoppen : Form
    {
        public Stoppen()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        public void Form9_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            while (true)
            {
                String input = ad.getString();
                if (input.Contains("*KEY") || input.Contains("#KEY"))
                {
                    String caseString = ad.getString();
                    switch (caseString)
                    {
                        case "*KEY":
                            new DankU().Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                        case "#KEY":
                            new Home().Show();
                            Thread.Sleep(1);
                            this.Close();
                            break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DankU().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Home().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
