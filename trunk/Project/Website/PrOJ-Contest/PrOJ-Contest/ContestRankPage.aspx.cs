using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrOJ_Contest
{
    public partial class ContestRankPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int contestid;
            try 
            {
                string tes = Request.QueryString["Id"].ToString();
                contestid = Convert.ToInt32(tes);
            }
            catch
            {
                contestid = 1;
            }
            generate(contestid);
            lpojEntities Ent = new lpojEntities();
            IEnumerable<lpoj_contest> contests = from c in Ent.lpoj_contest
                                                 where c.CONTEST_ID == contestid
                                                 select c;
            activeContestLabel.Text = contests.First<lpoj_contest>().CONTEST_TITLE;
            IEnumerable<lpoj_problem> problems = from c in Ent.lpoj_problem
                                                 where (c.CONTEST_ID == contestid) && (c.PROBLEM_STATUS == 0)
                                                 select c;
            maxScore.Text = (problems.Count<lpoj_problem>() * 100).ToString();
        }

        private class mboh : IComparable<mboh>
        {
            public string name { get; set; }
            public int totalScore { get; set; }
            public int totalTime { get; set; }

            public int CompareTo(mboh other)
            {
                if (this.totalScore < other.totalScore || (this.totalScore == other.totalScore && this.totalTime > other.totalTime))
                    return 1;
                else if (this.totalScore == other.totalScore && this.totalTime == other.totalTime)
                    return 0;
                else return -1;
            }

        };

        public void generate(int ContestID)
        {
            lpojEntities les = new lpojEntities();
            List<mboh> entitas = new List<mboh>();
            int contestID = ContestID; // ini idContest pake getString

            //ini banyaknya kontestan. ntar banyaknya ow
            IEnumerable<lpoj_contestant> lstContestant = from c in les.lpoj_contestant
                                                         where c.CONTEST_ID == contestID
                                                         select c;

            foreach (lpoj_contestant lc in lstContestant)
            {
                mboh a = new mboh();
                a = getRank(lc.CONTESTANT_ID);
                entitas.Add(a); // fungsi untuk menampilkan
                // ada pada table <contestan> 
                //add pada table <score>
                //add pada table <time?
            }
            entitas.Sort();
            foreach (mboh lc in entitas)
            {
                TableRow news = new TableRow();
                TableCell news2 = new TableCell();
                news2.Text = lc.name;
                news.Cells.Add(news2);
                TableCell news3 = new TableCell();
                news3.Text = lc.totalScore.ToString();
                news.Cells.Add(news3);
                TableCell news4 = new TableCell();
                news4.Text = lc.totalTime.ToString();
                news.Cells.Add(news4);
                TblScore.Rows.Add(news);
            }
        }

        private mboh getRank(int contestantID)
        {
            lpojEntities entity = new lpojEntities();
            lpoj_submission sub = new lpoj_submission();

            int csID = contestantID; // constestant

            int totScore = 0;
            int totTime = 0;

            IEnumerable<lpoj_submission> contestCheck = from c in entity.lpoj_submission
                                                        where c.CONTESTANT_ID == csID
                                                        select c;
            foreach (lpoj_submission ls in contestCheck)
            {
                totScore += ls.SUBMISSION_SCORE<0?0:ls.SUBMISSION_SCORE;
                totTime += ls.SUBMISSION_TIME;
            }


            IEnumerable<lpoj_contestant> constestants = from cs in entity.lpoj_contestant
                                                        where cs.CONTESTANT_ID == csID
                                                        select cs;

            int uID = constestants.First<lpoj_contestant>().USERS_ID;
            IEnumerable<lpoj_users> users = from us in entity.lpoj_users
                                            where us.USERS_ID == uID
                                            select us;
            string name = users.First<lpoj_users>().USERS_USERNAME;
            return new mboh
            {
                name = name,
                totalScore = totScore,
                totalTime = totTime
            };
        }

    }
}
