using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class ContestClarificationAnswerPage : System.Web.UI.Page
    {
        private lpojEntities Entity;
        private int contest_id;
        private lpoj_users activeUser;
        private lpoj_contest contestDetail;
        

        private void refreshClarificationForm(lpoj_clarification clarification)
        {
            
            if (clarification == null)
            {
                Asker.Text = "-";
                Question.Text = "-";
                answerText.Enabled = false;
                answerButton.Enabled = false;
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
                answerText.Text = "<< unknown answer >>";
            }
            else
            {
                answerText.Text = clarification.CLARIFICATION_ANSWER;
            }
            
            answerButton.Enabled = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            initialUserActive();
            try
            {
                contest_id = Convert.ToInt32(Request.QueryString["ContestID"]);
            }
            catch { contest_id = 1; }
            IEnumerable<lpoj_contest> con = from g in Entity.lpoj_contest
                                            where g.CONTEST_ID == contest_id
                                            select g;
            try
            {
                contestDetail = con.ElementAt<lpoj_contest>(0);
            }
            catch
            {
                Response.Redirect("UserPage.aspx");
            }

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
            // error handling untuk menghitung session
            if (Session.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                activeUser = (lpoj_users)Session["userActive"];
            }
        }

        protected void clarificationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            string clarificationTitle = clarificationList.SelectedValue;
            string clarificationID = "";
            foreach(char ch in clarificationTitle)
            {
                if(ch==' ') break;
                clarificationID += ch.ToString();
            }
            int CID = Convert.ToInt32(clarificationID);
            IEnumerable<lpoj_clarification> clarifications = from c in Entity.lpoj_clarification
                                                             where c.CLARIFICATION_ID == CID
                                                             select c;


            idAsker.Text = CID.ToString();
 
            refreshClarificationForm(clarifications.First<lpoj_clarification>());
            
        }

        protected void answerButton_Click(object sender, EventArgs e)
        {
            Entity = new lpojEntities();
            lpoj_clarification tempClar;
            int idClarification = Convert.ToInt32(idAsker.Text);
            System.Windows.Forms.MessageBox.Show(idClarification.ToString());
            IEnumerable<lpoj_clarification> clarifications = from c in Entity.lpoj_clarification
                                                             where c.CLARIFICATION_ID == idClarification 
                                                             select c;
            tempClar = clarifications.ElementAt<lpoj_clarification>(0);
            tempClar.CLARIFICATION_ANSWER = answerText.Text;
            tempClar.CLARIFICATION_STATUS = 1;
           
            Entity.SaveChanges();
        }
    }
}
