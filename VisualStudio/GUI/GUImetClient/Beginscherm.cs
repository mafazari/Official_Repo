﻿using GUI_Project_periode_3;
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
        bool config = false;
        public Beginscherm()
        {
            InitializeComponent();
            Cursor.Hide();
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
            if (!config)
            {
                bootup.makePort("COM6");
                config = true;
            }

            PinInvoer pinInvoer = new PinInvoer();
            Home home = new Home();
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
                    //String emu = ("AAAAAA\n11248649\n1004\n,NEWUID");
                    String s = arduino.getFirstString();
                    if (s.Contains("NEWUID"))
                    {
                        pasInformation = s.Split('\n', '\n', '\n');
                        KlantID = pasInformation[2];
                        rekeningID = pasInformation[1];
                        pasID = pasInformation[0];
                        //Error.show("PasID: " + pasID + "\nRekID: " + rekeningID + "\nKlantID: " + KlantID);
                        pinInvoer.giveInfo(pasInformation);
                        break;
                    }
                    //pinInvoer.Show();
                }
                if (!httpget.getActiefStand(pasID))
                {
                    BlockScreen tmp = new BlockScreen();
                    break;
                } 
                pinInvoer.Show();
                
                Thread.Sleep(1);
                this.Close();
                break;
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

            new Home().Show();
            Thread.Sleep(1);
            this.Close();
        }
    }
}
