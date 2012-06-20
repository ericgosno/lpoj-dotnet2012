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
            if (IsPostBack) return;

            clarificationList.Items.Clear();
            Entity = new lpojEntities();
            IEnumerable<lpoj_clarification> clarifications = from c in Entity.lpoj_clarification
                                                             where c.CONTEST_ID == contest_id
                                                             select c;
            foreach (lpoj_clarification clarification in clarifications)
            {
                clarificationList.Items.Add(clarification.CLARIFICATION_ID.ToString() + " - " + clarification.CLARIFICATION_TITLE);
            }
            idAsker.Text = "0";
            refreshClarificationForm(null);
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

        private void refreshClarificationForm(lpoj_clarification clarification)
        {

            if (clarification == null)
            {
                Asker.Text = "-";
                Question.Text = "-";
                answerText.Text = "-";
                
                return;
            }
            Entity = new lpojEntities();
            IEnumerable<int> userID = from c in Entity.lpoj_contestant
                                      where c.CONTESTANT_ID == clarification.CONTESTANT_ID
                                      select c.USERS_ID;
            int UID = userID.First<int>();
            IEnumerable<string> username = from c in Entity.lpoj_users
                                           where c.USERS_ID == UID
                                           select c.USERS_USERNAME;
            Asker.Text = username.First<string>();
            Question.Text = clarification.CLARIFICATION_DESCRIPTION;
            if (clarification.CLARIFICATION_ANSWER == null)
            {
                answerText.Enabled = true;
                answerText.Text = "-";
            }
            else
            {
                answerText.Text = clarification.CLARIFICATION_ANSWER;
            }

            
        }
        protected void clarificationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            string clarificationTitle = clarificationList.SelectedValue;
            string clarificationID = "";
            foreach (char ch in clarificationTitle)
            {
                if (ch == ' ') break;
                clarificationID += ch.ToString();
            }
            int CID = Convert.ToInt32(clarificationID);
            IEnumerable<lpoj_clarification> clarifications = from c in Entity.lpoj_clarification
                                                             where c.CLARIFICATION_ID == CID
                                                             select c;


            idAsker.Text = CID.ToString();

            refreshClarificationForm(clarifications.First<lpoj_clarification>());

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