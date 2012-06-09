using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class AdminContestManagementPage : System.Web.UI.Page
    {
        private lpojEntities entity;
        private lpoj_users activeUser;
        private lpoj_contest activeContest;
        private lpoj_contest contestnow;
        protected void Page_Load(object sender, EventArgs e)
        {
            initialContestActive();
            initialUserActive();
            //initialContestDesc();
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
        protected void initialContestActive()
        {
            activeContest = new lpoj_contest();
            // error handling untuk menghitung session
            if (Session.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                activeContest = (lpoj_contest)Session["contestActive"];
                lb_contestActive.Text = activeContest.CONTEST_TITLE;
            }
        }
        protected void initialContestDesc()
        {
            contestDescription.Text = activeContest.CONTEST_DESCRIPTION;
        }

        protected void changeDescription_Click(object sender, EventArgs e)
        {
            entity = new lpojEntities();
            IQueryable<lpoj_contest> queryContest = from f in entity.lpoj_contest
                                                    where f.CONTEST_ID == activeContest.CONTEST_ID
                                                    select f;
            try { contestnow = queryContest.First<lpoj_contest>(); }
            catch (Exception ex) { return; }
            System.Windows.Forms.MessageBox.Show(contestDescription.Text);
            contestnow.CONTEST_DESCRIPTION = contestDescription.Text;

            entity.SaveChanges();
            Session["activeContest"] = contestnow;
            activeContest = contestnow;
            Response.Redirect("AdminContestManagementPage.aspx");

        }

        
    }
}