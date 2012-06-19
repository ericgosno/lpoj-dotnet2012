using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace lpojWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Account : IAccount
    {
        private lpojEntities Entity;
        /*public Account()
        {
            Entity = new lpojEntities();
        }*/
        public int NumberContest(string username)
        {
            Entity = new lpojEntities();
            lpoj_users usernow = new lpoj_users();
            IEnumerable<lpoj_users> query2 = from g in Entity.lpoj_users
                                             where g.USERS_USERNAME == username
                                             select g;
            if (query2.Count() > 0)
            {
                usernow = query2.First();
            }
            else return -1;
            IEnumerable<lpoj_contestant> query = from g in Entity.lpoj_contestant
                                                 where g.CONTESTANT_STATUS == 1 && g.USERS_ID == usernow.USERS_ID
                                                 select g;
            return query.Count();
        }
        public KeyValuePair<int, int> NumberProblem(string username)
        {
            Entity = new lpojEntities();
            int ACAnswer = 0;
            int AllAnswer = 0;
            lpoj_users usernow = new lpoj_users();
            IEnumerable<lpoj_users> query2 = from g in Entity.lpoj_users
                                             where g.USERS_USERNAME == username
                                             select g;
            if (query2.Count() > 0)
            {
                usernow = query2.First();
            }
            else return new KeyValuePair<int, int>(-1, -1);
            IEnumerable<lpoj_contestant> query = from g in Entity.lpoj_contestant
                                                 where g.CONTESTANT_STATUS == 1 && g.USERS_ID == usernow.USERS_ID
                                                 select g;
            for (int i = 0; i < query.Count(); i++)
            {
                lpoj_contestant news = query.ElementAt(i);
                IEnumerable<lpoj_submission> query3 = from g in Entity.lpoj_submission
                                                      where g.CONTESTANT_ID == news.CONTESTANT_ID
                                                      select g;
                for (int j = 0; j < query3.Count(); j++)
                {
                    lpoj_submission news2 = query3.ElementAt(j);
                    if (news2.SUBMISSION_SCORE == 100) ACAnswer++;
                    AllAnswer++;
                }
            }
            return new KeyValuePair<int, int>(ACAnswer, AllAnswer);
        }

       public bool Login(string username, string password)
        {
            Entity = new lpojEntities();
            lpoj_users usernow = new lpoj_users();
            IEnumerable<lpoj_users> query2 = from g in Entity.lpoj_users
                                             where g.USERS_USERNAME == username && g.USERS_PASSWORD == password
                                             select g;
            if (query2.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
