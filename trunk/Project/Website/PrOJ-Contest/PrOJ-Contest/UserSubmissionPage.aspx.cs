using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class UserSubmissionPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private lpoj_contest contest;
        private lpoj_contestant contestant;
        private lpoj_users activeUser;
        private IEnumerable<lpoj_problem> problems;

        protected void Page_Load(object sender, EventArgs e)
        {
            initialUserActive();
            int contestID = 1;
            try
            {
                contestID = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch
            {
                contestID = 1;
            }

            Entity = new lpojEntities();
            IEnumerable<lpoj_contest> contests = from c in Entity.lpoj_contest
                                                 where c.CONTEST_ID == contestID
                                                 select c;
            if (contests.Count() > 0)
            {
                contest = contests.First<lpoj_contest>();
            }
            else
            {
                Response.Redirect("UserPage.aspx");
            }

            IEnumerable<lpoj_contestant> contestants = from c in Entity.lpoj_contestant
                                                       where (c.USERS_ID == activeUser.USERS_ID) && (c.CONTEST_ID == contest.CONTEST_ID)
                                                       select c;
            if (contestants.Count() > 0)
            {
                contestant = contestants.First<lpoj_contestant>();
            }
            else
            {
                Response.Redirect("UserPage.aspx");
            }

            problems = from c in Entity.lpoj_problem
                        where c.CONTEST_ID == contestID && c.PROBLEM_STATUS == 0
                        select c;

            if (IsPostBack) return;
            problemList.Items.Clear();
            foreach (lpoj_problem problem in problems)
                problemList.Items.Add(problem.PROBLEM_ID.ToString() + " - " + problem.PROBLEM_TITLE);
            refreshSubmissionList();
        }

        private void refreshSubmissionList()
        {
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

        protected void submit_Click(object sender, EventArgs e)
        {
            if (sourceFile.HasFile)
            {
                int problemID = Convert.ToInt32(problemList.SelectedItem.ToString().Split(" ".ToCharArray())[0]);
                string extention = sourceFile.FileName.Split(".".ToCharArray()).Last<string>();
                string filePath = Server.MapPath("~/") + "System\\Upload\\";
                string fileName = problemID.ToString() + "_" + contestant.CONTESTANT_ID.ToString() + "_c." + extention;
                sourceFile.SaveAs(filePath + fileName);
                lpojEntities Entity = new lpojEntities();
                int deltaS = Convert.ToInt32((DateTime.Now - DateTime.Parse(contest.CONTEST_BEGIN.ToString())).TotalSeconds);
                Entity.AddTolpoj_submission(new lpoj_submission
                {
                    CONTESTANT_ID = contestant.CONTESTANT_ID,
                    PROBLEM_ID = problemID,
                    SUBMISSION_TIME = deltaS,
                    SUBMISSION_SCORE = 0
                });
                Entity.SaveChanges();
                refreshSubmissionList();
            }
        }
    }
}
