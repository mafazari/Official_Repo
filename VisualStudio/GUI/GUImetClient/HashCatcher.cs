using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUImetClient
{
    public partial class HashCatcher : Form
    {
        public HashCatcher()
        {
            InitializeComponent();
        }

        private void HashCatcher_Load(object sender, EventArgs e)
        {

        }

        public HashCatcher(string rek, string pin)
        {
            InitializeComponent();
            Hash hash = new Hash();
            textBox1.Text = hash.makeHash(rek, pin);
            //hash.makeHash(rek, pin);

        }
    }
}
