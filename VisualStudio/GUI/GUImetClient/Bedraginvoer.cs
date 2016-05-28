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
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ArduinoData arduino = new ArduinoData();

            double bedrag = 0;
            String bedragString = "";
            String input;
            while (true)
            {
                input = arduino.getString();

                bedragString += input.ElementAt(0);

                bedrag = Double.Parse(bedragString);

                setDisplay(bedragString);
                //Convert.ToString(input);
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
            this.Hide();
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
            new Transactie().Show();
            Thread.Sleep(1);
            this.Hide();
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
    }
}
