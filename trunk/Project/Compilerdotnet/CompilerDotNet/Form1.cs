using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace CompilerDotNet
{
    public partial class Form1 : Form
    {
        private String DirectoryPath;
        private List<string> ExtApprove;
        private Queue<string> MessageLog;
        private MySqlConnect konek;
        private Compile news;

        public Form1()
        {
            InitializeComponent();
            DirectoryPath = @"D:\dotnet";
            ExtApprove = new List<string>();
            ExtApprove.Add("cpp");
            ExtApprove.Add("c");
            ExtApprove.Add("pas");
            ExtApprove.Add("java");
            ExtApprove.Add("py");
            MessageLog = new Queue<string>();
            konek = new MySqlConnect();
            news = new Compile();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (TmrRun.Enabled == true)
            {
                TmrRun.Enabled = false;
                BtnRun.Text = "&Run";
            }
            else
            {
                TmrRun.Enabled = true;
                BtnRun.Text = "&Stop";
            }
        }

        private void TxtLog_TextChanged(object sender, EventArgs e)
        {
            TxtLog.ScrollToCaret();
        }

        private void TmrRun_Tick(object sender, EventArgs e)
        {
            string[] FilePaths = Directory.GetFiles(DirectoryPath + @"\Upload\");

            if(FilePaths.Length != 0  && news.IsAlive == false)
            {
                string trail = "\\";
                string trail2 = ".";
                string fileName = FilePaths[0].Split(trail.ToCharArray(0, 1)[0]).Last();
                string ExtSplit;
                try
                {
                    ExtSplit = fileName.Split(trail2.ToCharArray(0, 1)[0])[1];
                }
                catch 
                {
                    MessageLog.Enqueue(fileName + "Deleted(Have Unknown Extension)\n");
                    if (File.Exists(FilePaths[0])) File.Delete(FilePaths[0]);
                    return; 
                } 
                // If Extension is Unknown
                if(!ExtApprove.Contains(ExtSplit.ToLower()))
                {
                    MessageLog.Enqueue(fileName + "Deleted(Have Unknown Extension)\n");
                    if(File.Exists(FilePaths[0]))File.Delete(FilePaths[0]);
                    return;
                }

               
                string destPath = DirectoryPath + @"\Execute\" + fileName;
                /* Move File to Execute Folder */
                if (File.Exists(destPath))File.Delete(destPath);
                File.Move(FilePaths[0], destPath);

                MessageLog.Enqueue("Judging Submission: " + fileName + "\n");
                news =  new Compile(ExtSplit.ToLower(),fileName,ref MessageLog);
                news.Run();
            }
            
        }

        private void TmrCheckLog_Tick(object sender, EventArgs e)
        {
            while (MessageLog.Count != 0)
            {
                string log = MessageLog.Dequeue();
                TxtLog.AppendText(log + "\n");
            }
        }
    }
}
