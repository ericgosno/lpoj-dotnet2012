using System.Collections.Generic; 
using System.Text; 
using System;


namespace MVCLearning1
{
    
    public class lpoj_users {
    
        public virtual int USERS_ID { get; set; }
      //  public virtual lpoj_contestant lpoj_contestants { get; set; }
      //  public virtual lpoj_ncsubmission lpoj_ncsubmissions { get; set; }
        public virtual string USERS_USERNAME { get; set; }
        public virtual string USERS_PASSWORD { get; set; }
        public virtual int USERS_STATUS { get; set; }
        public virtual System.DateTime USERS_JOIN_DATE { get; set; }
    }
}
