using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Summarization
{
    public partial class MainForm : XCoolForm.XCoolForm
    {
        public static MainForm obj = null;
        public MainForm()
        {
            InitializeComponent();
            obj = this;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().ShowDialog();
            
        }

        private void summarizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Summarization(dir).ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.obj.toolsToolStripMenuItem.Enabled = false;
            MainForm.obj.loginToolStripMenuItem.Enabled = true;
            MainForm.obj.exitToolStripMenuItem.Enabled = true;
            MainForm.obj.logoutToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project p = new Project();
            p.ShowDialog();
            if (p.dir != "")
            {
                new Summarization(p.dir).Show();
                
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectList p = new ProjectList();
            p.ShowDialog();
            if (p.dir != "")
            {
                new Summarization(p.dir).Show();

            }
        }
        public static string path = "c:/Project/";
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(path))
            {
                string dir = "c:/Project";
                Directory.CreateDirectory(dir);
                //MessageBox.Show("Project created");
            }
            
        }

    }
}
