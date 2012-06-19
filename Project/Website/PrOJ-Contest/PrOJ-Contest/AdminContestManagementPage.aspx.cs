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
            ParticipantList.Items.Clear();
            ProblemSetterList.Items.Clear();
            Entity = new lpojEntities();
            IEnumerable<lpoj_contestant> Participant = from c in Entity.lpoj_contestant
                                                       where (c.CONTEST_ID == contest_id) && (c.CONTESTANT_STATUS == 1)
                                                       select c;
            IEnumerable<lpoj_contestant> PSetters = from c in Entity.lpoj_contestant
                                                    where (c.CONTEST_ID == contest_id) && (c.CONTESTANT_STATUS == 2)
                                                    select c;
            lpoj_contestant[] ParticipantArray = Participant.ToArray<lpoj_contestant>();
            lpoj_contestant[] PSetterArray = PSetters.ToArray<lpoj_contestant>();
            for (int c = 0; c < ParticipantArray.Length; c++)
            {
                int userID = ParticipantArray[c].USERS_ID;
                IEnumerable<lpoj_users> user = from d in Entity.lpoj_users
                                               where d.USERS_ID == userID
                                               select d;
                ParticipantList.Items.Add(user.First<lpoj_users>().USERS_USERNAME);
            }
            for (int c = 0; c < PSetterArray.Length; c++)
            {
                int userID = PSetterArray[c].USERS_ID;
                IEnumerable<lpoj_users> user = from d in Entity.lpoj_users
                                               where d.USERS_ID == userID
                                               select d;
                ProblemSetterList.Items.Add(user.First<lpoj_users>().USERS_USERNAME);
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
                if (contestDetail.CONTEST_DESCRIPTION == null)
                    contestDescription.Text = "<No Description>";
                else contestDescription.Text = contestDetail.CONTEST_DESCRIPTION.ToString();
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
            contestnow.CONTEST_DESCRIPTION = contestDescription.Text;
            Entity.SaveChanges();
            contestDetail = contestnow;
            Response.Redirect("AdminContestManagementPage.aspx?Id=" + contestnow.CONTEST_ID);
        }

        protected void inviteContestant_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContestantInvitationPage.aspx?Id="+contest_id.ToString());
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

        private void removeContestant(string username)
        {
            Entity = new lpojEntities();
            IEnumerable<int> userID = from c in Entity.lpoj_users
                                      where c.USERS_USERNAME == username
                                      select c.USERS_ID;
            int UID = userID.First<int>();
            IEnumerable<lpoj_contestant> contestant = from c in Entity.lpoj_contestant
                                                      where (c.USERS_ID == UID) && (c.CONTEST_ID == contest_id)
                                                      select c;
            Entity.lpoj_contestant.DeleteObject(contestant.ElementAt<lpoj_contestant>(0));
            Entity.SaveChanges();
            updateContestantList();
        }

        protected void removeParticipant_Click(object sender, EventArgs e)
        {
            try
            {
                removeContestant(ParticipantList.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
        }

        protected void removeProblemSetter_Click(object sender, EventArgs e)
        {
            try
            {
                removeContestant(ProblemSetterList.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
        }
        
    }
}
