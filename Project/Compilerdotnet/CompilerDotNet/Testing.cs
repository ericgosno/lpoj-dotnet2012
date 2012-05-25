using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;


namespace CompilerDotNet
{
    public class Testing
    {
        private string filename;
        private lpoj_testcase testcase;
        private lpoj_submission submission;
        private lpoj_nctestcase nctestcase;
        private lpoj_ncsubmission ncsubmission;
        private lpoj_problem problem;
        private lpoj_ncproblem ncproblem;
        private bool isContest;
        private Queue<string> MessageQueue;
        private string ExtName;
        private lpojEntities Entity;
        
        private const int WRONG_ANSWER = 1;
        private const int TIME_LIMIT = 2;
        private const int COMPILE_ERROR = 3;
        private const int RUNTIME_ERROR = 4;
        private const int ACCEPTED = 0;

        public Testing(string filename, lpoj_testcase testcase, lpoj_submission submission, ref Queue<string> MessageQueue,string ExtName,lpoj_problem problem)
        {
            this.filename = filename;
            this.testcase = testcase;
            this.submission = submission;
            isContest = true;
            this.MessageQueue = MessageQueue;
            this.ExtName = ExtName;
            this.problem = problem;
            this.Entity = new lpojEntities();
        }
        public Testing(string filename, lpoj_nctestcase nctestcase, lpoj_ncsubmission ncsubmission, ref Queue<string> MessageQueue, string ExtName,lpoj_ncproblem ncproblem)
        {
            this.filename = filename;
            this.nctestcase = nctestcase;
            this.ncsubmission = ncsubmission;
            isContest = false;
            this.MessageQueue = MessageQueue;
            this.ExtName = ExtName;
            this.ncproblem = ncproblem;
            this.Entity = new lpojEntities();
        }
        public void run()
        {
            string output;
            if(isContest == true)
            {
                //Compile Error
                if (!File.Exists(filename))
                {
                    lpoj_verdict news = lpoj_verdict.Createlpoj_verdict(submission.PROBLEM_ID, submission.CONTESTANT_ID, testcase.TESTCASE_ID, COMPILE_ERROR);
                    Entity.lpoj_verdict.AddObject(news);
                    MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Compile Error\n");
                    return;
                }
  
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                output = @"D:\dotnet\output-" + submission.CONTESTANT_ID + "-" + submission.PROBLEM_ID + "-" + testcase.TESTCASE_ID + "-c.out";
                if (ExtName == "cpp" || ExtName == "c" || ExtName == "pas")
                {
                    startInfo.Arguments = "/C " + filename + " < " + testcase.TESTCASE_INPUT + " > " + output;
                }
                else if (ExtName == "java")
                {
                    startInfo.Arguments = "/C java " + filename + " < " + testcase.TESTCASE_INPUT + " > " + output;
                }
                else if (ExtName == "py")
                {
                    startInfo.Arguments = "/C python " + filename + " < " + testcase.TESTCASE_INPUT + " > " + output; 
                }
                process.StartInfo = startInfo;
                process.Start();
                Thread.Sleep(problem.PROBLEM_TIMELIMIT);
                // Time Limit
                if (!process.HasExited)
                {
                    process.Kill();
                    lpoj_verdict news = lpoj_verdict.Createlpoj_verdict(submission.PROBLEM_ID, submission.CONTESTANT_ID, testcase.TESTCASE_ID, TIME_LIMIT);
                    Entity.lpoj_verdict.AddObject(news);
                    MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Wrong Answer\n");
                }
                else
                {
                    // Runtime Error
                    if (!File.Exists(output))
                    {
                        lpoj_verdict news = lpoj_verdict.Createlpoj_verdict(submission.PROBLEM_ID, submission.CONTESTANT_ID, testcase.TESTCASE_ID, RUNTIME_ERROR);
                        Entity.lpoj_verdict.AddObject(news);
                        MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Runtime Error\n");
                    }
                    else
                    {
                        try
                        {
                            List<string> col1 = new List<string>();
                            List<string> col2 = new List<string>();
                            using (StreamReader sr = new StreamReader(output))
                            {
                                String line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    string trail = " ";
                                    string[] kata = line.Split(trail.ToCharArray(0, 1)[0]);
                                    col1.AddRange(kata);
                                }
                            }
                            using (StreamReader sr2 = new StreamReader(testcase.TESTCASE_OUTPUT))
                            {
                                String line;
                                while ((line = sr2.ReadLine()) != null)
                                {
                                    string trail = " ";
                                    string[] kata = line.Split(trail.ToCharArray(0, 1)[0]);
                                    col2.AddRange(kata);
                                }
                            }
                            bool isAccepted = true;
                            if (col1.Count() == col2.Count())
                            {
                                for (int i = 0; i < col1.Count; i++)
                                {
                                    if (col1[i] != col2[i])
                                    {
                                        isAccepted = false;
                                        break;
                                    }
                                }
                            }
                            else isAccepted = false;
                            //Accepted
                            if (isAccepted)
                            {
                                lpoj_verdict news = lpoj_verdict.Createlpoj_verdict(submission.PROBLEM_ID, submission.CONTESTANT_ID, testcase.TESTCASE_ID, ACCEPTED);
                                Entity.lpoj_verdict.AddObject(news);
                                submission.SUBMISSION_SCORE += 1;
                                MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Accepted\n");
                            }
                            else
                            {
                                lpoj_verdict news = lpoj_verdict.Createlpoj_verdict(submission.PROBLEM_ID, submission.CONTESTANT_ID, testcase.TESTCASE_ID, WRONG_ANSWER);
                                Entity.lpoj_verdict.AddObject(news);
                                MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Wrong Answer\n");
                            }
                        }
                        catch (Exception e)
                        {
                            lpoj_verdict news = lpoj_verdict.Createlpoj_verdict(submission.PROBLEM_ID, submission.CONTESTANT_ID, testcase.TESTCASE_ID, RUNTIME_ERROR);
                            Entity.lpoj_verdict.AddObject(news);
                            MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Runtime Error\n");
                        }
                    }
                }
            }
            // Here for NC problem
            else
            {
                //Compile Error
                if (!File.Exists(filename))
                {
                    lpoj_ncverdict news = lpoj_ncverdict.Createlpoj_ncverdict(ncsubmission.NCPROBLEM_ID, nctestcase.NCTESTCASE_ID, COMPILE_ERROR, ncsubmission.NCPROBLEM_ID);
                    Entity.lpoj_ncverdict.AddObject(news);
                    MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Compile Error\n");
                    return;
                }
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                output = @"D:\dotnet\output-" + ncsubmission.USERS_ID + "-" + ncsubmission.NCPROBLEM_ID + "-" + nctestcase.NCTESTCASE_ID + "-c.out"; 
                if (ExtName == "cpp")
                {
                    startInfo.Arguments = "/C " + filename + " < " + nctestcase.NCTESTCASE_INPUT + " > " + output;
                }
                else if (ExtName == "java")
                {
                    startInfo.Arguments = "/C java " + filename + " < " + nctestcase.NCTESTCASE_INPUT + " > " + output;
                }
                process.StartInfo = startInfo;
                process.Start();
                Thread.Sleep(ncproblem.NCPROBLEM_TIMELIMIT);
                // Time Limit
                if (!process.HasExited)
                {
                    process.Kill();
                    lpoj_ncverdict news = lpoj_ncverdict.Createlpoj_ncverdict(ncsubmission.NCPROBLEM_ID, nctestcase.NCTESTCASE_ID, TIME_LIMIT, ncsubmission.NCPROBLEM_ID);
                    Entity.lpoj_ncverdict.AddObject(news);
                    MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Time Limit\n");
                }
                else
                {
                    // Runtime Error
                    if (!File.Exists(output))
                    {
                        lpoj_ncverdict news = lpoj_ncverdict.Createlpoj_ncverdict(ncsubmission.NCPROBLEM_ID, nctestcase.NCTESTCASE_ID, RUNTIME_ERROR, ncsubmission.NCPROBLEM_ID);
                        Entity.lpoj_ncverdict.AddObject(news);
                        MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Runtime Error\n");
                    }
                    else
                    {
                        try
                        {
                            List<string> col1 = new List<string>();
                            List<string> col2 = new List<string>();
                            using (StreamReader sr = new StreamReader(output))
                            {
                                String line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    string trail = " ";
                                    string[] kata = line.Split(trail.ToCharArray(0, 1)[0]);
                                    col1.AddRange(kata);
                                }
                            }
                            using (StreamReader sr2 = new StreamReader(nctestcase.NCTESTCASE_OUTPUT))
                            {
                                String line;
                                while ((line = sr2.ReadLine()) != null)
                                {
                                    string trail = " ";
                                    string[] kata = line.Split(trail.ToCharArray(0, 1)[0]);
                                    col2.AddRange(kata);
                                }
                            }
                            bool isAccepted = true;
                            if (col1.Count() == col2.Count())
                            {
                                for (int i = 0; i < col1.Count; i++)
                                {
                                    if (col1[i] != col2[i])
                                    {
                                        isAccepted = false;
                                        break;
                                    }
                                }
                            }
                            else isAccepted = false;
                            //Accepted
                            if (isAccepted)
                            {
                                lpoj_ncverdict news = lpoj_ncverdict.Createlpoj_ncverdict(ncsubmission.NCPROBLEM_ID, nctestcase.NCTESTCASE_ID, ACCEPTED, ncsubmission.NCPROBLEM_ID);
                                Entity.lpoj_ncverdict.AddObject(news);                                
                                ncsubmission.NCSUBMISSION_SCORE += 1;
                                MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Accepted\n");
                            }
                            else
                            {
                                lpoj_ncverdict news = lpoj_ncverdict.Createlpoj_ncverdict(ncsubmission.NCPROBLEM_ID, nctestcase.NCTESTCASE_ID, WRONG_ANSWER, ncsubmission.NCPROBLEM_ID);
                                Entity.lpoj_ncverdict.AddObject(news);
                                MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Wrong Answer\n");
                            }
                        }
                        catch (Exception e)
                        {
                            lpoj_ncverdict news = lpoj_ncverdict.Createlpoj_ncverdict(ncsubmission.NCPROBLEM_ID, nctestcase.NCTESTCASE_ID, RUNTIME_ERROR, ncsubmission.NCPROBLEM_ID);
                            Entity.lpoj_ncverdict.AddObject(news);
                            MessageQueue.Enqueue("Testing " + filename + " with Testcase#" + testcase.TESTCASE_ID.ToString() + " Result : Runtime Error\n");
                        }
                    }
                }
            }
            if (!File.Exists(output))
            {
                File.Delete(output);
            }
        }
    }
}
