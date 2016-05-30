﻿using System;
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
    public partial class Transactie : Form
    {
        public Transactie()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void Transactie_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            String caseString = ad.getString();
            switch (caseString)
            {
                case "*KEY": //gaat naar bon scherm
                    new Bon().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
                case "#KEY": //geen bon
                    new DankU().Show();
                    Thread.Sleep(1);
                    this.Close();
                    break;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DankU().Show();
            Thread.Sleep(1);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DankU().Show();
            Thread.Sleep(1);
            this.Close();
        }
    }
}
