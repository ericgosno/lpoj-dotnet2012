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
            catch { contest_id = 1; }
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                            where g.CONTEST_ID == contest_id
                                            select g;
            if (con.Count() > 0)
            {
                
                contestDetail = con.ElementAt<lpoj_contest>(0);
                if (IsPostBack) return;
                lb_contestActive.Text = contestDetail.CONTEST_TITLE.ToString();
                contestDescription.Text = contestDetail.CONTEST_DESCRIPTION.ToString();
                startTime.Text = contestDetail.CONTEST_BEGIN.ToString();
                finishTime.Text = contestDetail.CONTEST_END.ToString();
                freezeTime.Text = contestDetail.CONTEST_FREEZE.ToString();
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
        
        protected void changeDescription_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            lpoj_contest contestnow;
            IQueryable<lpoj_contest> queryContest = from f in Entity.lpoj_contest
                                                    where f.CONTEST_ID == contestDetail.CONTEST_ID
                                                    select f;
            try { contestnow = queryContest.First<lpoj_contest>(); }
            catch (Exception ex) { return; }
            System.Windows.Forms.MessageBox.Show(contestDescription.Text);
            contestnow.CONTEST_DESCRIPTION = contestDescription.Text;

            Entity.SaveChanges();

            contestDetail = contestnow;
            Response.Redirect("AdminContestManagementPage.aspx?Id="+contestnow.CONTEST_ID);

        }

        protected void inviteContestant_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContestantInvitationPage.aspx");
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
                System.Windows.Forms.MessageBox.Show(startTime.Text);
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
