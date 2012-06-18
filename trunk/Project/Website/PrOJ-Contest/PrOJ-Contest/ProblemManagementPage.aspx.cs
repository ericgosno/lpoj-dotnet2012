using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class ProblemManagementPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private int problem_id;
        private lpoj_users activeUser;
        private lpoj_problem problemDetail;

        private void updateTestcaseList()
        {
            testCaseList.Items.Clear();
            Entity = new lpojEntities();
            IEnumerable<lpoj_testcase> testcases = from c in Entity.lpoj_testcase
                                                   where c.PROBLEM_ID == problem_id
                                                   orderby c.TESTCASE_ID ascending
                                                   select c;
            foreach (lpoj_testcase testcase in testcases)
            {
                testCaseList.Items.Add(testcase.TESTCASE_ID + " - " + testcase.TESTCASE_INPUT + " - " + testcase.TESTCASE_OUTPUT);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            initialUserActive();
            try
            {
                problem_id = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch { problem_id = 1; }
            IEnumerable<lpoj_problem> con = from g in Entity.lpoj_problem
                                            where g.PROBLEM_ID == problem_id
                                            select g;
            try
            {
                problemDetail = con.ElementAt<lpoj_problem>(0);
            }
            catch
            {
                Response.Redirect("UserPage.aspx");
            }
            problemTitle.Text = problemDetail.PROBLEM_TITLE;
            
            if (IsPostBack) return;
            if (problemDetail.PROBLEM_DESCRIPTION.Length > 0)
                problemDescription.Text = problemDetail.PROBLEM_DESCRIPTION;
            timeLimit.Text = problemDetail.PROBLEM_TIMELIMIT.ToString();
            memoryLimit.Text = problemDetail.PROBLEM_MEMORYLIMIT.ToString();
            updateTestcaseList();
        }

        protected void initialUserActive()
        {
            activeUser = new lpoj_users();
            // error handling untuk menghitung session
            if (Session.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                activeUser = (lpoj_users)Session["userActive"];
            }
        }

        protected void changeDescription_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            lpoj_problem problemnow;
            IQueryable<lpoj_problem> queryContest = from f in Entity.lpoj_problem
                                                    where f.PROBLEM_ID == problemDetail.PROBLEM_ID
                                                    select f;
            try { problemnow = queryContest.First<lpoj_problem>(); }
            catch { return; }
            problemnow.PROBLEM_DESCRIPTION = problemDescription.Text;
            Entity.SaveChanges();
            problemDetail = problemnow;
            Response.Redirect("ProblemManagementPage.aspx?Id=" + problemnow.PROBLEM_ID);
        }

        protected void changeTimeLimit_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            lpoj_problem problemnow;
            IQueryable<lpoj_problem> queryContest = from f in Entity.lpoj_problem
                                                    where f.PROBLEM_ID == problemDetail.PROBLEM_ID
                                                    select f;
            try { problemnow = queryContest.First<lpoj_problem>(); }
            catch { return; }
            problemnow.PROBLEM_TIMELIMIT = Convert.ToInt32(timeLimit.Text);
            Entity.SaveChanges();
            problemDetail = problemnow;
            Response.Redirect("ProblemManagementPage.aspx?Id=" + problemnow.PROBLEM_ID);
        }

        protected void changeMemoryLimit_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            lpoj_problem problemnow;
            IQueryable<lpoj_problem> queryContest = from f in Entity.lpoj_problem
                                                    where f.PROBLEM_ID == problemDetail.PROBLEM_ID
                                                    select f;
            try { problemnow = queryContest.First<lpoj_problem>(); }
            catch { return; }
            problemnow.PROBLEM_MEMORYLIMIT= Convert.ToInt32(memoryLimit.Text);
            Entity.SaveChanges();
            problemDetail = problemnow;
            Response.Redirect("ProblemManagementPage.aspx?Id=" + problemnow.PROBLEM_ID);
        }

        protected void uploadTestCase_Click(object sender, EventArgs e)
        {
            if (inputFile.HasFile && outputFile.HasFile)
            {
                if (inputFile.FileName.Contains("-") || outputFile.FileName.Contains("-"))
                {
                    System.Windows.Forms.MessageBox.Show("Input / Output File tidak valid!");
                    return;
                }
                Entity = new lpojEntities();
                IEnumerable<lpoj_testcase> testCases = from c in Entity.lpoj_testcase
                                                       where c.PROBLEM_ID == problem_id
                                                       select c;
                int vmax = 0;
                foreach (lpoj_testcase c in testCases)
                    vmax = vmax > c.TESTCASE_ID ? vmax : c.TESTCASE_ID;
                vmax++;
                string filePath = Server.MapPath("~/") + "System\\Testcase\\";
                string fileRenamer = problem_id.ToString() + "_" + vmax.ToString() + "_";
                string inputPath = fileRenamer + "input_" + inputFile.FileName;
                string outputPath = fileRenamer + "output_" + outputFile.FileName;
                inputFile.SaveAs(filePath + inputPath);
                outputFile.SaveAs(filePath + outputPath);
                Entity.AddTolpoj_testcase(new lpoj_testcase
                {
                    TESTCASE_ID = vmax,
                    PROBLEM_ID = problem_id,
                    TESTCASE_INPUT = inputPath,
                    TESTCASE_OUTPUT = outputPath
                });
                Entity.SaveChanges();
                updateTestcaseList();
            }
        }
    }
}
