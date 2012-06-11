using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PrOJ_Contest
{
    public partial class UserContestManagementPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private int contest_id;
        private lpoj_contest contestDetail;
        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            try
            {
                contest_id = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch { contest_id = 1;}
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                            where g.CONTEST_ID == contest_id
                                            select g;
            if (con.Count() > 0)
            {
                contestDetail = con.ElementAt<lpoj_contest>(0);
                startTime.Text = contestDetail.CONTEST_BEGIN.ToString();
                finishTime.Text = contestDetail.CONTEST_END.ToString();
                freezeTime.Text = contestDetail.CONTEST_FREEZE.ToString();
            }
           
            var query = (from f in Entity.lpoj_problem
                        where f.CONTEST_ID == contest_id
                        select f).ToList<lpoj_problem>();
            for (int i = 0; i < query.Count; i++)
            {
                problemList.Items.Add(query[i].PROBLEM_ID + " - " + query[i].PROBLEM_TITLE);
            }
        }

        protected void viewClarification_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContestClarificationAnswerPage.aspx");
        }

        protected void addProblem_Click(object sender, EventArgs e)
        {
            lpoj_problem news = new lpoj_problem();
            news.CONTEST_ID = contest_id;
            news.PROBLEM_TITLE = problemName.Text;
            news.PROBLEM_STATUS = 0;
            news.PROBLEM_CREATETIME = DateTime.Now;
            news.PROBLEM_DESCRIPTION = "aaa";
            news.PROBLEM_MEMORYLIMIT = 1000;
            news.PROBLEM_TIMELIMIT = 500;
            Entity.lpoj_problem.AddObject(news);
            Entity.SaveChanges();
        }

        protected void setStartTime_Click(object sender, EventArgs e)
        {
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                where g.CONTEST_ID == contest_id
                                select g;
            if (con.Count() > 0)
            {
                contestDetail = con.ElementAt<lpoj_contest>(0);
                contestDetail.CONTEST_BEGIN = DateTime.Parse(startTime.Text);
                Entity.SaveChanges();
            }
        }

        protected void setFreezeTime_Click(object sender, EventArgs e)
        {
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                            where g.CONTEST_ID == contest_id
                                            select g;
            if (con.Count() > 0)
            {
                contestDetail = con.ElementAt<lpoj_contest>(0);
                contestDetail.CONTEST_FREEZE = DateTime.Parse(freezeTime.Text);
                Entity.SaveChanges();
            }
        }

        protected void setFinishTime_Click(object sender, EventArgs e)
        {
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                            where g.CONTEST_ID == contest_id
                                            select g;
            if (con.Count() > 0)
            {
                contestDetail = con.ElementAt<lpoj_contest>(0);
                contestDetail.CONTEST_END = DateTime.Parse(finishTime.Text);
                Entity.SaveChanges();
            }
        }
    }
}