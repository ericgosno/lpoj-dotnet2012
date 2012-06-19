using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace lpojWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAccount
    {
        [OperationContract]
        int NumberContest(string username);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        KeyValuePair<int, int> NumberProblem(string username);

        // TODO: Add your service operations here
    }
}
