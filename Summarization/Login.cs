using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Summarization
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "Admin")
            {
                MainForm.obj.toolsToolStripMenuItem.Enabled = true;
                MainForm.obj.logoutToolStripMenuItem.Enabled = true;
                MainForm.obj.loginToolStripMenuItem.Enabled = false;
                MainForm.obj.exitToolStripMenuItem.Enabled = false;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

               
    }
}
