using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private lpojEntities entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            entity = new lpojEntities();
            lpoj_users users;
            IQueryable<lpoj_users> dbPassword = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == textName.Text
                                            select f;

            try { users = dbPassword.First<lpoj_users>(); }
            catch (Exception ex) { return; }

            if (textName.Text != "admin" && textName.Text == users.USERS_USERNAME && users.USERS_PASSWORD == textPass.Text)
                {
                    Session["userActive"] = users;
                    Response.Redirect("UserPage.aspx");
                }
            else if (textName.Text == "admin" && textName.Text == users.USERS_USERNAME && users.USERS_PASSWORD == textPass.Text)
            {
                Session["userActive"] = users;
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                return;
            }

        }
    }
}