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
    public partial class Form5 : Form
    {
        public Form5()
        {
            //aaaaaa
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            Thread.Sleep(1);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            Thread.Sleep(1);
            this.Hide();
        }
    }
}