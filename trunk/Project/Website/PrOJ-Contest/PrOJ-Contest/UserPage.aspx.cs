using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class UserPage : System.Web.UI.Page
    {
        private lpojEntities entity;
        private lpoj_users activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            initialUserActive();
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
    }
}