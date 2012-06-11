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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (cmbox_listContest.Items.Count == 0)
            {
                cmbox_listContest.Items.Add("Contest 1 - User");
                cmbox_listContest.Items.Add("Contest 2 - Manage");
               
            }
        }

        protected void cmbox_listContest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbox_listContest.SelectedItem.Text == "Contest 2 - Manage")
            {
                btn_manageContest.Visible = true;
            }
            else if (cmbox_listContest.SelectedItem.Text == "Contest 1 - User")
            {
                btn_manageContest.Visible = false;
            }
            
           
        }

        protected void btn_enterContest_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProblemPage.aspx");
        }

        protected void btn_manageContest_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserContestManagementPage.aspx");
        }
    }
}