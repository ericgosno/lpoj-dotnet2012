using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
            Entity = new lpojEntities();
            IEnumerable<lpoj_testcase> testcases = from c in Entity.lpoj_testcase
                                                   where c.PROBLEM_ID == problem_id
                                                   orderby c.TESTCASE_ID ascending
                                                   select c;
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

            IEnumerable<lpoj_contest> con1 = from g in Entity.lpoj_contest
                                             where g.CONTEST_ID == problemDetail.CONTEST_ID
                                             select g;
            lpoj_contest contestnow = new lpoj_contest();
            if (con1.Count() > 0)
            {
                contestnow = con1.First();
            }
            else
            {
                Response.Redirect("UserPage.aspx");
            }
            IEnumerable<lpoj_contestant> con2 = from g in Entity.lpoj_contestant
                                                where g.USERS_ID == activeUser.USERS_ID && g.CONTEST_ID == contestnow.CONTEST_ID && g.CONTESTANT_STATUS == 2
                                                select g;
            lpoj_contestant contestantnow = new lpoj_contestant();
            if (con2.Count() > 0)
            {
                contestantnow = con2.First();
            }
            else
            {
                Response.Redirect("UserPage.aspx");
            }

            problemTitle.Text = problemDetail.PROBLEM_TITLE;

            fillTable();

            if (IsPostBack) return;
            if (problemDetail.PROBLEM_DESCRIPTION.Length > 0)
                problemDescription.Text = problemDetail.PROBLEM_DESCRIPTION;
            timeLimit.Text = problemDetail.PROBLEM_TIMELIMIT.ToString();
            memoryLimit.Text = problemDetail.PROBLEM_MEMORYLIMIT.ToString();
            updateTestcaseList();
        }

        protected void fillTable()
        {
            IEnumerable<lpoj_testcase> query2 = from g in Entity.lpoj_testcase
                                                where g.PROBLEM_ID == problem_id
                                                select g;
            for (int i = 0; i < query2.Count(); i++)
            {
                TableRow news = new TableRow();
                TableCell news2 = new TableCell();
                TableCell news3 = new TableCell();
                news2.Text = query2.ElementAt(i).TESTCASE_INPUT;
                news3.Text = query2.ElementAt(i).TESTCASE_OUTPUT;
                news.Cells.Add(news2);
                news.Cells.Add(news3);
                TblTestCase.Rows.Add(news);
            }
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

        protected void removeTestCase_Click(object sender, EventArgs e)
        {
            IEnumerable<lpoj_verdict> query1 = from g in Entity.lpoj_verdict
                                               where g.PROBLEM_ID == problem_id
                                               select g;
            for (int i = 0; i < query1.Count(); i++)
            {
                lpoj_verdict nows1 = query1.ElementAt(i);
                Entity.lpoj_verdict.DeleteObject(nows1);
            }

            IEnumerable<lpoj_testcase> query2 = from g in Entity.lpoj_testcase
                                                where g.PROBLEM_ID == problem_id
                                                select g;
            for (int i = 0; i < query2.Count(); i++)
            {
                lpoj_testcase nows2 = query2.ElementAt(i);
                Entity.lpoj_testcase.DeleteObject(nows2);
            }
            Entity.SaveChanges();
        }
    }
}
