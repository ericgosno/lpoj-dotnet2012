using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class ClarificationPage : System.Web.UI.Page
    {
        private lpoj_users activeUser;
        private lpojEntities Entity;
        private int contest_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            initialUserActive();
            contest_id = Convert.ToInt32(Request.QueryString["Id"]);
        }

        protected void initialUserActive()
        {
            activeUser = new lpoj_users();
            if (Session.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                activeUser = (lpoj_users)Session["userActive"];
            }
        }

        protected void askButton_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            lpoj_clarification tempClar = new lpoj_clarification();

            IEnumerable<lpoj_contestant> contestant = from d in Entity.lpoj_contestant
                                                              where d.USERS_ID == activeUser.USERS_ID && d.CONTEST_ID==contest_id
                                                              select d;

            Entity.AddTolpoj_clarification(new lpoj_clarification
            {
            CLARIFICATION_TITLE = Clar_Title.Text.ToString(),
            CLARIFICATION_DESCRIPTION = Clar_Desc.Text.ToString(),
            CONTESTANT_ID = Int32.Parse(contestant.ElementAt(0).CONTESTANT_ID.ToString()),
            CONTEST_ID = contest_id,
            });
            Entity.SaveChanges();

            Response.Redirect("ClarificationPage.aspx?Id="+contest_id);
        }

    }
}