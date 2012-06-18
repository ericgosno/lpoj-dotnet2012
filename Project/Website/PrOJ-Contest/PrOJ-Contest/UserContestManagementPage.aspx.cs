using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

namespace PrOJ_Contest
{
    public partial class UserContestManagementPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private int contest_id;
        private lpoj_users activeUser;
        private lpoj_contest contestDetail;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            initialUserActive();
            try
            {
                contest_id = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch { contest_id = 1;}
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                            where g.CONTEST_ID == contest_id
                                            select g;
            try
            {
                contestDetail = con.ElementAt<lpoj_contest>(0);
            }
            catch
            {
                Response.Redirect("UserPage.aspx");
            }

            IEnumerable<lpoj_contestant> par = from g in Entity.lpoj_contestant
                                            where g.CONTESTANT_STATUS == 2 && g.CONTEST_ID == contestDetail.CONTEST_ID && g.USERS_ID == activeUser.USERS_ID
                                            select g;
            if (par.Count() == 0)
            {
                Response.Redirect("UserPage.aspx");
            }
            if (IsPostBack) return;
            if (con.Count() > 0)
            {
                startTime.Text = contestDetail.CONTEST_BEGIN.ToString();
                finishTime.Text = contestDetail.CONTEST_END.ToString();
                freezeTime.Text = contestDetail.CONTEST_FREEZE.ToString();
            }
            fillProblem();
        }

        private void fillProblem()
        {
            var query = (from f in Entity.lpoj_problem
                        where f.CONTEST_ID == contest_id && f.PROBLEM_STATUS == 0
                        select f).ToList<lpoj_problem>();
            problemList.Items.Clear();
            for (int i = 0; i < query.Count; i++)
            {
                problemList.Items.Add(query[i].PROBLEM_ID + " - " + query[i].PROBLEM_TITLE);
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
                lb_userActive.Text = activeUser.USERS_USERNAME;
            }
        }

        protected void viewClarification_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContestClarificationAnswerPage.aspx?ContestID=" + contest_id.ToString());
        }

        protected void addProblem_Click(object sender, EventArgs e)
        {
            if (problemName.Text == "") return;
            lpoj_problem news = new lpoj_problem();
            news.CONTEST_ID = contest_id;
            news.PROBLEM_TITLE = problemName.Text;
            news.PROBLEM_STATUS = 0;
            news.PROBLEM_CREATETIME = DateTime.Now;
            news.PROBLEM_DESCRIPTION = "Insert Description Here...";
            news.PROBLEM_MEMORYLIMIT = 1000;
            news.PROBLEM_TIMELIMIT = 500;
            Entity.lpoj_problem.AddObject(news);
            Entity.SaveChanges();
            fillProblem();
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

        protected void removeProblem_Click(object sender, EventArgs e)
        {
            char[] separator = new char[1];
            separator[0] = ' ';
            int hasil = Convert.ToInt32(problemList.SelectedItem.Text.Split(separator).First<string>());
            IEnumerable<lpoj_problem> con = from g in Entity.lpoj_problem
                                            where g.PROBLEM_ID == hasil
                                            select g;
            con.First().PROBLEM_STATUS = 1;

            Entity.SaveChanges();
            fillProblem();
        }

        protected void editProblem_Click(object sender, EventArgs e)
        {
            char[] separator = new char[1];
            separator[0] = ' ';
            int hasil = Convert.ToInt32(problemList.SelectedItem.Text.Split(separator).First<string>());
            Response.Redirect("ProblemManagementPage.aspx?Id=" + hasil.ToString());
        }
    }
}
