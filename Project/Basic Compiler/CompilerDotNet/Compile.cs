using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace CompilerDotNet
{
    public class Compile
    {
        private string ExtName;
        private string fileName;
        private string destPath;
        private string ExePath;
        private Queue<string> MessageQueue;

        public Compile(string ExtName,string fileName, ref Queue<string> MessageQueue)
        {
            this.ExtName = ExtName;
            this.fileName = fileName;
            this.MessageQueue = MessageQueue;
        }
        
        public void Compile_Code()
        {
            MessageQueue.Enqueue("Compiling " + fileName);
            string trail = ".";
            string fileNameWithoutExt = fileName.Split(trail.ToCharArray(0,1)[0])[0];

            destPath = @"D:\dotnet\Execute\" + fileName;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            //extname : .CPP, .Java, .C, .pas
            
            if(ExtName == "cpp")
            {
                ExePath = @"D:\dotnet\Execute\" + fileNameWithoutExt;
                startInfo.Arguments = "/C g++ -o " + ExePath + " " + destPath;
                ExePath += ".exe";
            }
            
            else if (ExtName == "c")
            {
                ExePath = @"D:\dotnet\Execute\" + fileNameWithoutExt;
                startInfo.Arguments = "/C gcc -o " + ExePath + " " + destPath;
                ExePath += ".exe";
            }

            else if (ExtName == "java")
            {
                ExePath = @"D:\dotnet\Execute\" + fileNameWithoutExt;
                startInfo.Arguments = "/C javac " + fileName;
            }

            else if (ExtName == "pas")
            {
                ExePath = @"D:\dotnet\Execute\" + fileNameWithoutExt;
                startInfo.Arguments = "/C fpc " + destPath;
            }
            process.StartInfo = startInfo;
            process.Start();
            MessageQueue.Enqueue("Finishing Compiling " + fileName);
        }

        public void Testing_Code()
        {
               
        }

        public void Process_Code()
        {

        }
        public void Run()
        {
            if (ExtName != "py")
            {
                Compile_Code();
            }
            Testing_Code();
            Process_Code();
        }


    }
}
