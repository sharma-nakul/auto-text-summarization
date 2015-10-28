using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Summarization
{
    class ProjectData
    {
        public static string parent = "c:/Project/";
        public static bool creteProject(string filename, string dir)
        {
            bool flag = false;
            FileInfo f = new FileInfo(filename);


            if (!Directory.Exists(parent + dir + "/" + f.Name))
            {
                Directory.CreateDirectory(parent + dir + "/" + f.Name);
                flag = true;
                File.Copy(filename, parent + dir + "/" + f.Name);
            }
            return flag;

        }

        public static string openTextFile(string filename, string dir)
        {
            if (File.Exists(parent + dir + "/" + filename))
            {
                StreamReader fs = new StreamReader(parent + dir + "/" + filename);
                String strLine;
                String data = "";
                while ((strLine = fs.ReadLine()) != null)
                {
                    data += strLine + "\n";
                }
                fs.Close();

                return data;
            }
            else
            {
                return "";
            }
        }

        public static string saveTextFile(string filename, string dir,string data)
        {
            if (File.Exists( filename))
            {
                File.Delete( filename);
            }
            StreamWriter fs = new StreamWriter( filename);
            
            fs.Write(data);
            //String data = "";
          //for(int i=0;i<al.Count;i++)
          //  {
          //      fs.WriteLine(al[i].ToString());
                
          //  }
          fs.Close();
            return data;
        }

        public static bool creteSumrizeFile(string filename, string dir, String data)
        {
            bool flag = false;
            FileInfo f = new FileInfo(filename);
            string name = f.Name;
            //name = name.Substring(0, name.IndexOf('.'));

            //if (!Directory.Exists(parent + dir + "/" + name))
            {
              //  Directory.CreateDirectory(parent + dir + "/" + name);
                flag = true;
                saveTextFile(parent + dir + "/" + "sumarize_" + f.Name, dir, data);
                //File.Copy(filename, parent + dir + "/" + "sumrize_" + f.Name);
            }
            return flag;
        }

        public static bool creteFile(string filename, string dir)
        {
            bool flag = false;
            FileInfo f = new FileInfo(filename);
            string name = f.Name;
            name = name.Substring(0, name.IndexOf('.'));

            if (Directory.Exists(parent + dir ))
            {
                flag = true;
                File.Copy(filename, parent + dir + "/" + f.Name);
            }
            return flag;

        }

        public static void loadProject(string filename, TreeView tr)
        {
            tr.Nodes.Clear();
            TreeNode t = new TreeNode();
            t.Text = filename;
            tr.Nodes.Add(t);
            string[] dr = Directory.GetDirectories(parent+filename);
            for (int i = 0; i < dr.Length; i++)
            {
                DirectoryInfo dr1 = new DirectoryInfo(dr[i]);
                TreeNode t1 = new TreeNode();
                t1.Text = dr1.Name;
                t.Nodes.Add(t1);
                //string[] idir = Directory.GetDirectories(filename + "/" + dr[i]);
                //for (int j = 0; j < idir.Length; j++)
                //{
                //    TreeNode t2 = new TreeNode();
                //    t2.Text = idir[j];
                //    t1.Nodes.Add(t2);
                //}

            }
        }
    }
}
