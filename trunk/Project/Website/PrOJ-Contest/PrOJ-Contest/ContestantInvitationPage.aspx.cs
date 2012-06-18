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

        private void inviteUsers(string[] usernames, int contestantStatus)
        {
            foreach (string c in usernames)
            {
                string username;
                if (c.Contains('\n'))
                    username = c.Remove('\n');
                else if (c.Contains(Convert.ToChar(11)))
                    username = c.Remove(c.LastIndexOf(Convert.ToChar(11)));
                else if (c.Contains(Convert.ToChar(13)))
                    username = c.Remove(c.LastIndexOf(Convert.ToChar(13)));
                else
                    username = c;
                Entity = new lpojEntities();
                lpoj_users tempUser;
                IQueryable<lpoj_users> userQuery = from d in Entity.lpoj_users
                                                   where d.USERS_USERNAME == username
                                                   select d;
                if (userQuery.Count() <= 0)
                    continue;
                tempUser = userQuery.First<lpoj_users>();
                Entity.AddTolpoj_contestant(new lpoj_contestant
                {
                    CONTEST_ID = contest_id,
                    USERS_ID = tempUser.USERS_ID,
                    CONTESTANT_STATUS = contestantStatus
                });
            }
            Response.Redirect("AdminContestManagementPage.aspx?Id=" + contest_id.ToString());
        }

        protected void regularInviteParticipant_Click(object sender, EventArgs e)
        {
            inviteUsers(usernameList.Text.Split("\n".ToCharArray()), 1);
        }

        protected void regularInviteProblemSetter_Click(object sender, EventArgs e)
        {
            inviteUsers(usernameList.Text.Split("\n".ToCharArray()), 2);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminContestManagementPage.aspx?Id=" + contest_id.ToString());
        }
    }
}
