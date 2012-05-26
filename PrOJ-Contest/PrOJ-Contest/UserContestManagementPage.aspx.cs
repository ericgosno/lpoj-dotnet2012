using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class UserContestManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewClarification_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContestClarificationAnswerPage.aspx");
        }
    }
}