﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="ILogin")]
public interface ILogin
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ILogin/checkLogin", ReplyAction="http://Microsoft.ServiceModel.Samples/ILogin/checkLoginResponse")]
    string checkLogin(string usr, string passwd, string dbuser, string dbpasswd);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ILoginChannel : ILogin, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LoginClient : System.ServiceModel.ClientBase<ILogin>, ILogin
{
    
    public LoginClient()
    {
    }
    
    public LoginClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public LoginClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string checkLogin(string usr, string passwd, string dbuser, string dbpasswd)
    {
        return base.Channel.checkLogin(usr, passwd, dbuser, dbpasswd);
    }
}
