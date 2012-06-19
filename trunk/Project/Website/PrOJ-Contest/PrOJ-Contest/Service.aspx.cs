using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrOJ_Contest.AccountService;

namespace PrOJ_Contest
{
    public partial class Service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_service_Click(object sender, EventArgs e)
        {
            AccountService.IAccount service = new AccountService.AccountClient();
            int con = service.NumberContest(usernametxt.Text);
            if(con == -1)
            {
                JumAnswerResp.Text = "User Not Found!";
            }
            else
            {
                JumAnswerResp.Text = con.ToString();
            }
            KeyValuePair<int, int> prob = service.NumberProblem(usernametxt.Text);
            if (prob.Key == -1)
            {
                JumSubmission.Text = "User Not Found!";
            }
            else
            {
                JumSubmission.Text = prob.Value.ToString() + " (" + prob.Key.ToString() + " Accepted)";
            }
        }
    }
}