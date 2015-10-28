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
    public partial class Starting : Form
    {
        public static Starting obj1=null;
        public Starting()
        {
            InitializeComponent();
            obj1 = this;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value =progressBar1.Value+1;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                new MainForm().ShowDialog();
                Starting.obj1.Enabled = false;
                this.Hide();
                this.Dispose();
            }
        }

        private void Starting_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        
       
    }
}
