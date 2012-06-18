using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PrOJ_Contest
{
    public partial class ProblemPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private lpoj_contest contestnow;
        private lpoj_contestant contestantnow;
        private lpoj_problem problemnow;
        private lpoj_users activeUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            initialUserActive();
            int idcontest;
            int idproblem;
            try
            {
                idcontest = Convert.ToInt32(Request.QueryString["Id"]);
            }
            catch
            {
                idcontest = 1;
            }
            IEnumerable<lpoj_contest> query1 = from g in Entity.lpoj_contest
                                               where g.CONTEST_ID == idcontest
                                               select g;
            if (query1.Count() > 0)
            {
                contestnow = query1.First();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            IEnumerable<lpoj_contestant> query2 = from g in Entity.lpoj_contestant
                                                  where g.USERS_ID == activeUser.USERS_ID && g.CONTEST_ID == contestnow.CONTEST_ID
                                                  select g;
            if (query2.Count() > 0)
            {
                contestantnow = query2.First();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }


            try
            {
                idproblem = Convert.ToInt32(Request.QueryString["Problem"].ToString());
                IEnumerable<lpoj_problem> query4 = from g in Entity.lpoj_problem
                                                   where g.CONTEST_ID == contestnow.CONTEST_ID && g.PROBLEM_ID == idproblem && g.PROBLEM_STATUS == 0
                                                   select g;
                if (query4.Count() > 0)
                {
                    problemnow = query4.First();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch
            {
                IEnumerable<lpoj_problem> query3 = from g in Entity.lpoj_problem
                                        where g.CONTEST_ID == contestnow.CONTEST_ID && g.PROBLEM_STATUS == 0
                                        select g;
                if (query3.Count() > 0)
                {
                    problemnow = query3.First();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            IEnumerable<lpoj_problem> query5 = from g in Entity.lpoj_problem
                                               where g.CONTEST_ID == contestnow.CONTEST_ID && g.PROBLEM_STATUS == 0
                                               select g;
            for (int i = 0;i < query5.Count();i++)
            {
                TableRow news = new TableRow();
                TableCell news2 = new TableCell();
                news2.Text = "<a href=\"ProblemPage.aspx?Id=" + contestnow.CONTEST_ID.ToString() + "&Problem=" + query5.ElementAt(i).PROBLEM_ID.ToString() + "\">" + query5.ElementAt(i).PROBLEM_TITLE.ToString() + "</a>";
                news.Cells.Add(news2);
                TblBrowse.Rows.Add(news);
            }

            fillProblem();
        }

        protected void fillProblem()
        {
            problemTitle.Text = problemnow.PROBLEM_TITLE;
            problemDescription.Text = problemnow.PROBLEM_DESCRIPTION;
            timeLimit.Text = problemnow.PROBLEM_TIMELIMIT.ToString();
            memoryLimit.Text = problemnow.PROBLEM_MEMORYLIMIT.ToString();
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
    }
}