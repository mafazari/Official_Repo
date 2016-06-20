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
        private String klantid;
        private int amount;
        private string rekeningID;

        public Bon()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        public Bon(int a, String k, string r)
        {
            this.klantid = k;
            this.amount = a;
            this.rekeningID = r;
            InitializeComponent();
            Cursor.Hide();
        }

        private void Bon_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            Printer print = new Printer(amount,klantid,rekeningID);                      
            
            while (true)
            {
                String input = ad.getString();
                if (input.Contains("*KEY") || input.Contains("#KEY") || input.Contains("0KEY"))
                {
                    String caseString = input;          // CAN ONLY BE * or #

                    switch (caseString)
                    {
                        case "*KEY":
                            print.printTicket();
                            new DankU().Show();
                            Thread.Sleep(1);
                            this.Hide();
                            break;
                        case "#KEY":
                            new DankU().Show();
                            Thread.Sleep(1);
                            this.Hide();
                            break;
                        case "0KEY":
                            Email email = new Email(amount, rekeningID, Convert.ToInt32(klantid));
                            email.sendEmail();
                            new DankU().Show();
                            Thread.Sleep(1);
                            this.Hide();
                            break;
                    }
                }
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
