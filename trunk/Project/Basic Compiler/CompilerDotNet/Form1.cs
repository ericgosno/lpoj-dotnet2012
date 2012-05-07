using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace CompilerDotNet
{
    public partial class Form1 : Form
    {
        private List<Thread> Compiles;
        private List<string> ExtApprove;
        private Queue<string> MessageLog;
       // private MySqlConnect konek;

        public Form1()
        {
            InitializeComponent();
            Compiles = new List<Thread>();
            ExtApprove = new List<string>();
            ExtApprove.Add("cpp");
            ExtApprove.Add("c");
            ExtApprove.Add("pas");
            ExtApprove.Add("java");
            ExtApprove.Add("py");
            MessageLog = new Queue<string>();
            //konek = new MySqlConnect();
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
            string[] FilePaths = Directory.GetFiles(@"D:\dotnet\Upload\");

            for (int i = 0; i < FilePaths.Length; i++)
            {
                string trail = "\\";
                string trail2 = ".";
                string fileName = FilePaths[i].Split(trail.ToCharArray(0, 1)[0]).Last();
                string ExtSplit = fileName.Split(trail2.ToCharArray(0,1)[0]).Last();
                
                // If Extension is Unknown
                if(!ExtApprove.Contains(ExtSplit.ToLower()))
                {
                    MessageLog.Enqueue(fileName + "Deleted(Have Unknown Extension)\n");
                    if(File.Exists(FilePaths[i]))File.Delete(FilePaths[i]);
                    continue;
                }

                string destPath = @"D:\dotnet\Execute\" + fileName;
                /* Move File to Execute Folder */
                if (File.Exists(destPath))File.Delete(destPath);
                File.Move(FilePaths[i], destPath);

                MessageLog.Enqueue("Making Thread for Judging " + fileName + "\n");
                Compile news =  new Compile(ExtSplit.ToLower(),fileName,ref MessageLog);
                Thread news1 = new Thread(news.Run);
                news1.Start();

                Thread.Sleep(1);
                Compiles.Add(news1);
            }
            
        }

        private void TmrCheckThread_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Compiles.Count; i++)
            {
                if (!Compiles[i].IsAlive)
                {
                    Compiles[i].Join();
                    MessageLog.Enqueue("A Thread is Closed\n");
                }
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
