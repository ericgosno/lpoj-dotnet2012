﻿using System;
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
                foreach (lpoj_contest g in resultcontest)
                {
                    contestList.Items.Add(g.CONTEST_ID + "-" + g.CONTEST_TITLE);
                }
                //contestList.DataSource = resultcontest;
                //contestList.DataBind();
                //contestList.Items.Add("coba");
                //foreach (lpoj_contest h in resultcontest)
                //{
                //    contestList.Items.Add(h.CONTEST_TITLE);
                //}
                
            }
            
            refreshListBanned();
            clarContestAdd.Visible = true;
            
            if (IsPostBack) return;
            clarContestAdd.Visible = false;

           
        }
        protected void initialUserActive()
        {
            activeUser = new lpoj_users();
            if (Session.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            // error handling untuk menghitung session
            try
            {
                activeUser = (lpoj_users)Session["userActive"];
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }

            if (activeUser.USERS_USERNAME != "admin")
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
            if (contestName.Text == "" || contestName.Text == null)
            {
                clarContestAdd.Text = "**Not Submitted";
                return;
            }
            myNewContest.CONTEST_TITLE = contestName.Text;
            
            myNewContest.CONTEST_BEGIN = myNewContest.CONTEST_CREATE = myNewContest.CONTEST_END = myNewContest.CONTEST_FREEZE =(DateTime.Now);
            entity.lpoj_contest.AddObject(myNewContest);
            entity.SaveChanges();
            clarContestAdd.Text = "**Submitted!";
            Response.Redirect("AdminPage.aspx");


        }

        protected void editContest_Click(object sender, EventArgs e)
        {
            Session["userActive"] = activeUser;
            string ContestID = (contestList.SelectedItem.Text);
            string[] a = ContestID.Split('-');
            int idContest = int.Parse(a[0]);
            lpoj_contest c = new lpoj_contest();
            IQueryable<lpoj_contest> dbContest = from f in entity.lpoj_contest
                                                 where f.CONTEST_ID == idContest
                                                 select f;
            try { c = dbContest.First<lpoj_contest>(); }
            catch { return; }
            Session["contestActive"] = c;
            Response.Redirect("AdminContestManagementPage.aspx?Id=" + c.CONTEST_ID.ToString());
        }



    }
}
