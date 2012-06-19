using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CompilerDotNet
{
    public class Compile
    {
        private string DirectoryPath;
        private string ExtName;
        private string fileName;
        private string destPath;
        private string ExePath;
        private bool isAlive;
        private lpoj_submission submission;
        private lpoj_ncsubmission ncsubmission;
        private lpojEntities Entity;
        private lpoj_problem problem;
        private lpoj_ncproblem ncproblem;
        private lpoj_contestant contestant;
        private lpoj_users nccontestant;
        private bool isContest;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        private Queue<string> MessageQueue;

        public Compile()
        {
            isAlive = false;
            submission = null;
            ncsubmission = null;
        }
        public Compile(string ExtName, string DirectoryPath, string fileName, ref Queue<string> MessageQueue)
        {
            this.ExtName = ExtName;
            this.fileName = fileName;
            this.MessageQueue = MessageQueue;
            this.DirectoryPath = DirectoryPath;
            isAlive = true;
            submission = null;
            ncsubmission = null;
            Entity = new lpojEntities();
        }
        
        private bool Compile_Code()
        {
            MessageQueue.Enqueue("Compiling " + fileName);
            string trail = ".";
            string fileNameWithoutExt = fileName.Split(trail.ToCharArray(0,1)[0])[0];

            destPath = DirectoryPath + @"\Execute\" + fileName;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            if (ExtName == "cpp")
            {
                ExePath = DirectoryPath + @"\Execute\" + fileNameWithoutExt;
                startInfo.Arguments = "/C g++ -o \"" + ExePath + "\" \"" + destPath + "\"";
                ExePath += ".exe";
            }
            else if(ExtName == "c")
            {
                ExePath = DirectoryPath + @"\Execute\" + fileNameWithoutExt;
                startInfo.Arguments = "/C gcc -o \"" + ExePath + "\" \"" + destPath + "\"";
                ExePath += ".exe";
            }
            else if (ExtName == "java")
            {
                ExePath = DirectoryPath + @"\Execute\" + fileName;
                startInfo.Arguments = "/C javac \"" + ExePath + "\" ";
                ExePath = DirectoryPath + @"\Execute\" + fileNameWithoutExt + ".class";
            }
            else if (ExtName == "pas")
            {
                ExePath = DirectoryPath + @"\Execute\" + fileName;
                startInfo.Arguments = "/C fpc \"" + ExePath + "\" ";
            }
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit(10000);
            if (File.Exists(ExePath))
            {
                MessageQueue.Enqueue("Finishing Compiling " + fileName);
                return true;
            }
            return true;
        }

        private bool Testing_Code()
        {
            if (submission != null)
            {
                IEnumerable<lpoj_problem> result = from e in Entity.lpoj_problem
                                                  where e.PROBLEM_ID == submission.PROBLEM_ID
                                                  select e;
                try { problem = result.First<lpoj_problem>(); }
                catch { return false; }
                IEnumerable<lpoj_contestant> result2 = from e in Entity.lpoj_contestant
                                                       where e.CONTESTANT_ID == submission.CONTESTANT_ID
                                                       select e;
                try { contestant = result2.First<lpoj_contestant>(); }
                catch { return false; }
                IEnumerable<lpoj_testcase> result3 = from e in Entity.lpoj_testcase
                                                     where e.PROBLEM_ID == problem.PROBLEM_ID
                                                     select e;

                submission.SUBMISSION_SCORE = 0;
                int score = 0;
                foreach (lpoj_testcase i in result3)
                {
                    Testing tc = new Testing(ExePath,i,submission,ref MessageQueue,ExtName,problem,DirectoryPath);
                    score += tc.run();
                    Thread.Sleep(1000);
                }

                submission.SUBMISSION_SCORE = Convert.ToInt32(Convert.ToDouble(score) / Convert.ToDouble(result3.Count()) * 100);
                MessageQueue.Enqueue("Testing " + fileName + " finish, Result : " +  submission.SUBMISSION_SCORE);
            }
            else if (ncsubmission != null)
            {

                IEnumerable<lpoj_ncproblem> result = from e in Entity.lpoj_ncproblem
                                                  where e.NCPROBLEM_ID == ncsubmission.NCPROBLEM_ID
                                                  select e;
                try { ncproblem = result.First<lpoj_ncproblem>(); }
                catch { return false; }
                IEnumerable<lpoj_users> result2 = from e in Entity.lpoj_users
                                                  where e.USERS_ID == ncsubmission.USERS_ID
                                                  select e;
                try { nccontestant = result2.First<lpoj_users>(); }
                catch { return false; }
                IEnumerable<lpoj_nctestcase> result3 = from e in Entity.lpoj_nctestcase
                                                       where e.NCPROBLEM_ID == ncproblem.NCPROBLEM_ID
                                                       select e;
                ncsubmission.NCSUBMISSION_SCORE = 0;
                int score = 0;
                foreach (lpoj_nctestcase i in result3)
                {
                    Testing tc = new Testing(ExePath, i, ncsubmission, ref MessageQueue, ExtName,ncproblem,DirectoryPath);
                    score += tc.run();
                }
                ncsubmission.NCSUBMISSION_SCORE = Convert.ToInt32(Convert.ToDouble(score) / Convert.ToDouble(result3.Count()) * 100);
                MessageQueue.Enqueue("Testing " + fileName + " finish, Result : " + ncsubmission.NCSUBMISSION_SCORE);
            }
            else return false;
            Entity.SaveChanges();
            return true;
        }

        private void Process_Code()
        {
            /* Move File to Finished Folder */
            string nextPath = DirectoryPath + @"\Finished\" + fileName;
            if (File.Exists(nextPath)) File.Delete(nextPath);
            File.Move(destPath, nextPath);

            /* Delete Executable File */
            try
            {
                if (File.Exists(ExePath)) File.Delete(ExePath);
            }
            catch { }
        }

        private bool Detect_Submission()
        {
            string[] divInfo;
            int numProblem;
            int numContestant;
            string trail = ".";
            string fileNameWithoutExt = fileName.Split(trail.ToCharArray(0, 1)[0])[0];
            trail = "_";
            try 
            {
                divInfo = fileNameWithoutExt.Split(trail.ToCharArray(0, 1)[0]);
                if (divInfo.Length != 3) return false;
                numProblem = Convert.ToInt32(divInfo[0]);
                numContestant = Convert.ToInt32(divInfo[1]);
            }
            catch (Exception ex) 
            {
                MessageQueue.Enqueue(ex.ToString());    
                return false; 
            }

            if (divInfo[2] == "c")
            {
                isContest = true;
                IQueryable<lpoj_submission> result = from e in Entity.lpoj_submission
                                                     where e.PROBLEM_ID == numProblem && e.CONTESTANT_ID == numContestant
                                                     select e;
                try { submission = result.First<lpoj_submission>();}
                catch (Exception ex) 
                {
                    MessageQueue.Enqueue(ex.ToString());  
                    return false; 
                }
            }
            else if (divInfo[2] == "nc")
            {
                isContest = false;
                IQueryable<lpoj_ncsubmission> result = from e in Entity.lpoj_ncsubmission
                                                       where e.NCPROBLEM_ID == numProblem && e.USERS_ID == numContestant
                                                       select e;
                try { ncsubmission = result.First<lpoj_ncsubmission>(); }
                catch (Exception ex)
                {
                    MessageQueue.Enqueue(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;

            }
            return true;
        }

        public void Run()
        {
            System.Threading.Thread.Sleep(1000);
            if (!Detect_Submission())
            {
                MessageQueue.Enqueue("Error Submission " + fileName + " is Unknown\n");
                isAlive = false;
                return;
            }

            if (ExtName != "py")
            {
                if (!Compile_Code()) return;
            }
            else ExePath = DirectoryPath + @"\Execute\" + fileName;
            
            if (!Testing_Code())
            {
                MessageQueue.Enqueue("Error Submission " + fileName + " is Unknown\n");
                isAlive = false;
                return; 
            }
            
            Process_Code();
            isAlive = false;
            MessageQueue.Enqueue("Finish Judging Submission " + fileName + "\n");
        }


    }
}
