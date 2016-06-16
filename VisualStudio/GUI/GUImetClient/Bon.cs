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
using System.Threading;

namespace GUI_Project_periode_3
{
    public partial class Bon : Form
    {
        //private String userName;
        private int amount;

        public Bon()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        public Bon(int a)
        {
            //this.userName = u;
            this.amount = a;
            InitializeComponent();
            Cursor.Hide();
        }

        private void Bon_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            Printer print = new Printer(amount);                      //????????????????????
            String caseString = ad.getString();
            switch (caseString)
            {
                case "*KEY":                                    //print bon
                    //print.printTicket();
                    new DankU().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "#KEY":
                    new DankU().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Stoppen().Show();
            System.Threading.Thread.Sleep(1);
            this.Hide();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
