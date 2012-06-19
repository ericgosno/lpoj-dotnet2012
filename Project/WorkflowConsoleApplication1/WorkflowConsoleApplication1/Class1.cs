using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkflowConsoleApplication1
{
    public static class Class1
    {

        public static string getUsername(string name)
        {
            lpojEntities entity = new lpojEntities();
            IQueryable<lpoj_users> orangs = from c in entity.lpoj_users
                                            where c.USERS_USERNAME == name
                                            select c;
            if (orangs.Count() <= 0)
            {
                return "drrt";
            }
            else
            {
                return orangs.First<lpoj_users>().USERS_USERNAME;
            }
        }

        public static string getPassword(string name)
        {
            lpojEntities entity = new lpojEntities();
            IQueryable<lpoj_users> orangs = from c in entity.lpoj_users
                                            where c.USERS_USERNAME == name
                                            select c;
            if (orangs.Count() <= 0)
            {
                return "asd";
            }
            else
            {
                return orangs.First<lpoj_users>().USERS_PASSWORD;
            }
        }
    }

    
}
