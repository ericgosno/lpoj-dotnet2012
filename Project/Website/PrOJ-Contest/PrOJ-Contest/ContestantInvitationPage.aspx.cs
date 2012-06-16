using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;

namespace PrOJ_Contest
{
    public partial class ContestantInvitationPage : System.Web.UI.Page
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

        private bool isMatching(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern, RegexOptions.CultureInvariant);
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string ans = "";
            Entity = new lpojEntities();
            IQueryable<lpoj_users> userQuery = from c in Entity.lpoj_users
                                               where isMatching(c.USERS_USERNAME, regexpText.Text)
                                               select c;
            lpoj_users[] users = userQuery.ToArray<lpoj_users>();
            for (int c = 0; c < users.Length; c++)
            {
                ans += users[c].USERS_USERNAME.ToString() + "\n";
            }
            usernameList.Text = ans;
        }

        protected void regularInviteParticipant_Click(object sender, EventArgs e)
        {
            string[] usernames = usernameList.Text.Split("\n".ToCharArray());
            for (int c = 0; c < usernames.Length; c++)
            {
                Entity = new lpojEntities();
                lpoj_contestant newContestant = new lpoj_contestant();
                IQueryable<lpoj_users> userQuery = from d in Entity.lpoj_users
                                                   where d.USERS_USERNAME == usernames[c]
                                                   select d;
                newContestant.CONTEST_ID = contestDetail.CONTEST_ID;
                newContestant.USERS_ID = userQuery.First<lpoj_users>().USERS_ID;
                //BACA :: mboh lali 1 itu PSetter ato Perticipant loh!!!
                newContestant.CONTESTANT_STATUS = 1;
                Entity.AddTolpoj_contestant(newContestant);
            }
        }

        protected void regularInviteProblemSetter_Click(object sender, EventArgs e)
        {
            string[] usernames = usernameList.Text.Split("\n".ToCharArray());
            for (int c = 0; c < usernames.Length; c++)
            {
                Entity = new lpojEntities();
                lpoj_contestant newContestant = new lpoj_contestant();
                IQueryable<lpoj_users> userQuery = from d in Entity.lpoj_users
                                                   where d.USERS_USERNAME == usernames[c]
                                                   select d;
                newContestant.CONTEST_ID = contestDetail.CONTEST_ID;
                newContestant.USERS_ID = userQuery.First<lpoj_users>().USERS_ID;
                //komentar sama dengan paragraf sebelumnya
                newContestant.CONTESTANT_STATUS = 2;
                Entity.AddTolpoj_contestant(newContestant);
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminContestManagementPage.aspx");
        }
    }
}
