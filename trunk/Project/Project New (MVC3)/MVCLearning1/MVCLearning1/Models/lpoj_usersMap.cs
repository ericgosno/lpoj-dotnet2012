using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MVCLearning1
{
    
    
    public class lpoj_usersMap : ClassMap<lpoj_users> {
        
        public lpoj_usersMap() {
			//Table("lpoj_users");
			//LazyLoad();
			Id(x => x.USERS_ID);
			Map(x => x.USERS_USERNAME);
			Map(x => x.USERS_PASSWORD);
			Map(x => x.USERS_STATUS);
			Map(x => x.USERS_JOIN_DATE);
           // References(x => x.lpoj_contestants);
           // References(
            //HasMany(x => x.lpoj_contestants).KeyColumns.Add(new string[] {} );
			//HasMany(x => x.lpoj_ncsubmissions).KeyColumns.Add(new string[] {} );
        }
    }
}
