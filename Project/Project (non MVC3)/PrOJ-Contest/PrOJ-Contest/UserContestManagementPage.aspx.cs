using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class UserContestManagementPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private int contest_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            contest_id = Convert.ToInt32(Request.QueryString["Id"]);
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
            Entity.lpoj_problem.AddObject(news);
            Entity.SaveChanges();
        }
    }
}