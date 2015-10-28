using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextAnalysis;

namespace WindowsDocument
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PorterStemmer s = new PorterStemmer();
            s.setto(textBox1.Text);
            s.stem();
            textBox2.Text=s.ToString();
            
        }
    }
}
