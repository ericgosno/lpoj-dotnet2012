using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private lpojEntities entity;
        private lpoj_users activeUser;
        private lpoj_users users;
        private lpoj_contest contests;

        protected void Page_Load(object sender, EventArgs e)
        {
            initialUserActive();
            entity = new lpojEntities();
            IQueryable<lpoj_users> resu = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == activeUser.USERS_USERNAME
                                            select f;
            try { users = resu.First<lpoj_users>(); }
            catch (Exception ex) { return; }

            oldPassword.Text = users.USERS_PASSWORD;
            statusUser.Text = "None";
            
            //USER LIST
            if (userList.Items.Count == 0)
            {
                
                IQueryable<lpoj_users> result = from f in entity.lpoj_users
                                                select f;
                userList.Items.Add(" ");
                foreach (lpoj_users g in result)
                {
                    if (g.USERS_USERNAME != "admin")
                        userList.Items.Add(g.USERS_USERNAME);
                } 
            }

            //CONTEST LIST
            if (contestList.Items.Count == 0)
            {

                IQueryable<lpoj_contest> resultcontest = from f in entity.lpoj_contest
                                                         select f;
                //contestList.DataSource = resultcontest;
                //contestList.DataBind();
                //contestList.Items.Add("coba");
                //foreach (lpoj_contest h in resultcontest)
                //{
                //    contestList.Items.Add(h.CONTEST_TITLE);
                //}
                
            }

            refreshListBanned();
           
        }
        protected void initialUserActive()
        {
            activeUser = new lpoj_users();
            // error handling untuk menghitung session
            try
            {
                activeUser = (lpoj_users)Session["userActive"];
                lb_activeUser.Text = activeUser.USERS_USERNAME;
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void addUser_Click(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            entity = new lpojEntities();
            lpoj_users myNewUsers= new lpoj_users();
            myNewUsers.USERS_USERNAME = userName.Text;
            myNewUsers.USERS_PASSWORD = userPass.Text;
            myNewUsers.USERS_STATUS = 1;
            myNewUsers.USERS_JOIN_DATE = current;
            entity.lpoj_users.AddObject(myNewUsers);
            entity.SaveChanges();
            Response.Redirect("AdminPage.aspx");
        }

        protected void penalizeUser_Click(object sender, EventArgs e)
        {
            entity = new lpojEntities();
            IQueryable<lpoj_users> result = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == userList.SelectedItem.Text
                                            select f;
            foreach (lpoj_users g in result)
            {
                if (g.USERS_STATUS == 1) g.USERS_STATUS = 0;
                else if (g.USERS_STATUS == 0) g.USERS_STATUS = 1;
            }
            entity.SaveChanges();
            userList.SelectedValue = " ";
            statusUser.Text = "None";
            
        }

        

        protected void refreshListBanned()
        {
            entity = new lpojEntities();
            IQueryable<lpoj_users> result = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == userList.SelectedItem.Text
                                            select f;
            foreach (lpoj_users g in result)
            {
                if (g.USERS_STATUS == 1) statusUser.Text = "Active";
                else if (g.USERS_STATUS == 0) statusUser.Text = "Non-Active";
                else statusUser.Text = "None";
            }
        }

        protected void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshListBanned();
        }

        

        protected void btn_changeUserPass_Click(object sender, EventArgs e)
        {
            entity = new lpojEntities();

            IQueryable<lpoj_users> result = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == userList.SelectedItem.Text
                                            select f;
            try { users = result.First<lpoj_users>(); }
            catch (Exception ex) { return; }

            users.USERS_PASSWORD = users.USERS_USERNAME;
            
            entity.SaveChanges();
            Response.Redirect("AdminPage.aspx");
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            entity = new lpojEntities();
            IQueryable<lpoj_users> result = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == activeUser.USERS_USERNAME
                                            select f;
            try { users = result.First<lpoj_users>(); }
            catch (Exception ex) { return; }

                if (activeUser.USERS_PASSWORD == oldPassword.Text && newPassword.Text == confirmPassword.Text)
                {
                    users.USERS_PASSWORD = newPassword.Text;
                }
                
            entity.SaveChanges();
            Session["userActive"] = users;
            activeUser = users;
            Response.Redirect("AdminPage.aspx");
        }

        protected void addContest_Click(object sender, EventArgs e)
        {
            lpoj_contest myNewContest = new lpoj_contest();
            myNewContest.CONTEST_TITLE = contestName.Text;
            
            myNewContest.CONTEST_BEGIN = myNewContest.CONTEST_CREATE = myNewContest.CONTEST_END = myNewContest.CONTEST_FREEZE =(DateTime.Now);
            entity.lpoj_contest.AddObject(myNewContest);
            entity.SaveChanges();
            Response.Redirect("AdminPage.aspx");

        }

        protected void contestList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}