using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PrOJ_Contest
{
    public partial class UserManagement : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private lpoj_users activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            initialUserActive();
            if (IsPostBack) return;
            initialContest();
        }
        private void initialContest()
        {
            IEnumerable<lpoj_contestant> query = from f in Entity.lpoj_contestant
                                           where f.USERS_ID == activeUser.USERS_ID
                                           select f;
            if (query.Count() == 0) btn_enterContest.Visible = false;
            DateTime now = DateTime.Now;
            for (int i = 0; i < query.Count<lpoj_contestant>(); i++)
            {
                int cek = query.ElementAt(i).CONTEST_ID;
                IEnumerable<lpoj_contest> query2 = from h in Entity.lpoj_contest
                                                   where h.CONTEST_ID == cek && h.CONTEST_BEGIN <= now && h.CONTEST_END >= now //tambahan
                                                   select h;
                string role;
                if (query2.Count() <= 0) continue;
                
                if (query.ElementAt(i).CONTESTANT_STATUS == 0)
                {
                    continue;
                }
                else if (query.ElementAt(i).CONTESTANT_STATUS == 1)
                {
                    role = "user";
                }
                else
                {
                    role = "manager";
                }
                ListItem tes = new ListItem();
                //tes.Attributes.Add("role", query.ElementAt<lpoj_contestant>(i).CONTESTANT_STATUS.ToString());
                tes.Text = query2.ElementAt(0).CONTEST_ID.ToString() + " - " + query2.ElementAt(0).CONTEST_TITLE + " - " + role;
                cmbox_listContest.Items.Add(tes);
                if (cmbox_listContest.Items.Count == 1)
                {
                    if (role == "manager")
                    {
                        btn_manageContest.Visible = true; 
                    }
                }
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

        protected void cmbox_listContest_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] separator = new char[1];
            separator[0] = ' ';
            string hasil = cmbox_listContest.SelectedItem.Text.Split(separator).Last<string>();
            if (hasil == "user")
            {
                btn_manageContest.Visible = false;
            }
            else if (hasil == "manager")
            {
                btn_manageContest.Visible = true;
            }
        }

        protected void btn_enterContest_Click(object sender, EventArgs e)
        {
            char[] separator = new char[1];
            separator[0] = ' ';
            string hasil = cmbox_listContest.SelectedItem.Text.Split(separator).First<string>();
            Response.Redirect("ProblemPage.aspx?Id=" + hasil);
        }

        protected void btn_manageContest_Click(object sender, EventArgs e)
        {
            char[] separator = new char[1];
            separator[0] = ' ';
            string hasil = cmbox_listContest.SelectedItem.Text.Split(separator).First<string>();
            Response.Redirect("UserContestManagementPage.aspx?Id="+hasil);
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            IEnumerable<lpoj_users> con = from g in Entity.lpoj_users
                                          where g.USERS_ID == activeUser.USERS_ID
                                          select g;
            if (con.Count() > 0)
            {
                activeUser = con.ElementAt<lpoj_users>(0);
                if (activeUser.USERS_PASSWORD == oldPassword.Text)
                {
                    activeUser.USERS_PASSWORD = newPassword.Text;
                    Entity.SaveChanges();
                    Session["userActive"] = activeUser;
                }
            }

        }
    }
}