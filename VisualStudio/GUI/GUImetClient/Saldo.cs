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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public Form6(double saldo)
        {
           //InitializeComponent();
            textBox1.Text = saldo.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ArduinoData ad = new ArduinoData();
            String caseString = ad.getString();

            switch (caseString)
            {
                case "*KEY":
                    new Form3().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
                case "#KEY":
                    new Form9().Show();
                    Thread.Sleep(1);
                    this.Hide();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form9().Show();
            Thread.Sleep(1);
            this.Hide();
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