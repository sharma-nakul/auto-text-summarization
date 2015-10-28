using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using TextAnalysis.Summarizer;

namespace Summarization
{
    public partial class Summarization : Form
    {
        public string dir;

        public Summarization(string dir)
        {
            this.dir = dir;
            InitializeComponent();
            ProjectData.loadProject(dir, treeView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                textBox3.Text = op.FileName;
                //ProjectData.creteProject(textBox3.Text, dir);
                string name = new FileInfo(op.FileName).Name;
                name = name.Substring(0, name.IndexOf("."));
                Directory.CreateDirectory(ProjectData.parent + dir + "/" + name);
                ProjectData.creteFile(textBox3.Text, dir + "/" + name);
                textBox1.Text = ProjectData.openTextFile(textBox3.Text, dir + "/" + name);
                ProjectData.loadProject(dir, treeView1);
            }
            catch
            {
                MessageBox.Show("Upload a file");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text= new SimpleSummarizer().Summarize(textBox1.Text,Convert.ToInt32(textBox4.Text));
            
        }

        private void Summarization_Load(object sender, EventArgs e)
        {
            //System.IO.DirectoryInfo fi = new System.IO.DirectoryInfo("C:\\");
            //System.IO.DirectoryInfo[] di = fi.GetDirectories();
            ////System.IO.DirectoryInfo[] dis = di.GetDirectories();
            ////System.IO.FileSystemInfo[] fsi = di.GetFiles();
            //foreach (System.IO.DirectoryInfo info in di)
            //{
            //   String f=info.Name;
            //}
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String foldername = ""; 
            if (openproject.ShowDialog(this) != DialogResult.Cancel)
            {
                String d = openproject.SelectedPath;
                int start = d.LastIndexOf('\\')+2;
                foldername = d;
               foldername = d.Substring(start, d.Length-1);
                //MessageBox.Show(foldername);
            }
            //MessageBox.Show(foldername);
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = false;
            //ofd.Filter = "Windows Folder(*.*)";
            ////ofd.Filter = "Windows Bitmap (*.bmp)|*.bmp";
            //if (ofd.ShowDialog(this) != DialogResult.Cancel)
            //{
            //   String f=ofd.FileName;
               

            //}		
        }

        private void createNewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                String file = treeView1.SelectedNode.Text;
                if (file != dir)
                {

                    textBox1.Text = ProjectData.openTextFile(file + ".txt", dir + "/" + file);
                    textBox2.Text = ProjectData.openTextFile("sumrize_" + file + ".txt", dir + "/"+file);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String file = treeView1.SelectedNode.Text;
            //String file = treeView1.SelectedNode.FirstNode.Text;
            //ArrayList al = new ArrayList();
            //al.Add("sd");
            //al.Add("sd1");
            ProjectData.creteSumrizeFile(file + ".txt", dir + "/"+file, textBox2.Text);
            

        }

             
       
    }
}
