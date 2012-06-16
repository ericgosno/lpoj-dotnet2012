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

        private void updateContestantList()
        {
            Entity = new lpojEntities();
            IEnumerable<lpoj_contestant> PSetters = from c in Entity.lpoj_contestant
                                                   where (c.CONTEST_ID == contest_id) && (c.CONTESTANT_STATUS == 2)
                                                   select c;
            IEnumerable<lpoj_contestant> Participant = from c in Entity.lpoj_contestant
                                                   where (c.CONTEST_ID == contest_id) && (c.CONTESTANT_STATUS == 1)
                                                   select c;
            for (int c = 0; c < PSetters.Count<lpoj_contestant>(); c++)
            {
                int userID = PSetters.ElementAt<lpoj_contestant>(c).USERS_ID;
                IEnumerable<lpoj_users> user = from d in Entity.lpoj_users
                                               where d.USERS_ID == userID
                                               select d;
                ProblemSetterList.Items.Add(user.First<lpoj_users>().USERS_USERNAME);
            }
            for (int c = 0; c < Participant.Count<lpoj_contestant>(); c++)
            {
                int userID = Participant.ElementAt<lpoj_contestant>(c).USERS_ID;
                IEnumerable<lpoj_users> user = from d in Entity.lpoj_users
                                               where d.USERS_ID == userID
                                               select d;
                ParticipantList.Items.Add(user.First<lpoj_users>().USERS_USERNAME);
            }
        }

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
                updateContestantList();
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
            catch { return; }
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

        protected void removeParticipant_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            IEnumerable<int> userID = from c in Entity.lpoj_users
                                           where c.USERS_USERNAME == ParticipantList.SelectedItem.ToString()
                                           select c.USERS_ID;
            IEnumerable<lpoj_contestant> contestant = from c in Entity.lpoj_contestant
                                                      where (c.USERS_ID == userID.First<int>()) && (c.CONTEST_ID == contest_id)
                                                      select c;
            Entity.DeleteObject(contestant.First<lpoj_contestant>());
            updateContestantList();
        }

        protected void removeProblemSetter_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            IEnumerable<int> userID = from c in Entity.lpoj_users
                                      where c.USERS_USERNAME == ProblemSetterList.SelectedItem.ToString()
                                      select c.USERS_ID;
            IEnumerable<lpoj_contestant> contestant = from c in Entity.lpoj_contestant
                                                      where (c.USERS_ID == userID.First<int>()) && (c.CONTEST_ID == contest_id)
                                                      select c;
            Entity.DeleteObject(contestant.First<lpoj_contestant>());
            updateContestantList();
        }
        
    }
}
