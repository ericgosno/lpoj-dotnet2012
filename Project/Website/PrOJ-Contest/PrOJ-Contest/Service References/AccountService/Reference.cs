﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrOJ_Contest.AccountService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountService.IAccount")]
    public interface IAccount {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/NumberContest", ReplyAction="http://tempuri.org/IAccount/NumberContestResponse")]
        int NumberContest(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/Login", ReplyAction="http://tempuri.org/IAccount/LoginResponse")]
        bool Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/NumberProblem", ReplyAction="http://tempuri.org/IAccount/NumberProblemResponse")]
        System.Collections.Generic.KeyValuePair<int, int> NumberProblem(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountChannel : PrOJ_Contest.AccountService.IAccount, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountClient : System.ServiceModel.ClientBase<PrOJ_Contest.AccountService.IAccount>, PrOJ_Contest.AccountService.IAccount {
        
        public AccountClient() {
        }
        
        public AccountClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int NumberContest(string username) {
            return base.Channel.NumberContest(username);
        }
        
        public bool Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Collections.Generic.KeyValuePair<int, int> NumberProblem(string username) {
            return base.Channel.NumberProblem(username);
        }
    }
}