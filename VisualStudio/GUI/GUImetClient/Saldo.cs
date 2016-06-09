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
    public partial class Saldo : Form
    {
        public Saldo()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        public Saldo(double saldo)
        {
           InitializeComponent();
            textBox1.Text = saldo.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //PinInvoer getter = new PinInvoer();
            string rekeningID = Home.rekeningID;
            
            ArduinoData ad = new ArduinoData();
            HTTPget httpget = new HTTPget();
            int balans = httpget.getRekening(rekeningID).Balans;
            string balansString = Convert.ToString(balans);
            textBox1.Text = balansString + " €";

            String caseString = ad.getString();

            switch (caseString)
            {
                case "*KEY":
                    new Bedraginvoer().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
                case "#KEY":
                    new Stoppen().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Opnemen().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Stoppen().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
