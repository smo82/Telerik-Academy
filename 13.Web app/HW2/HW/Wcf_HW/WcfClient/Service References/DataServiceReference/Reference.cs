﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfClient.DataServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataServiceReference.IDateService")]
    public interface IDateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateService/GetWeekDayInBg", ReplyAction="http://tempuri.org/IDateService/GetWeekDayInBgResponse")]
        string GetWeekDayInBg(System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateService/GetWeekDayInBg", ReplyAction="http://tempuri.org/IDateService/GetWeekDayInBgResponse")]
        System.Threading.Tasks.Task<string> GetWeekDayInBgAsync(System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDateServiceChannel : WcfClient.DataServiceReference.IDateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DateServiceClient : System.ServiceModel.ClientBase<WcfClient.DataServiceReference.IDateService>, WcfClient.DataServiceReference.IDateService {
        
        public DateServiceClient() {
        }
        
        public DateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetWeekDayInBg(System.DateTime date) {
            return base.Channel.GetWeekDayInBg(date);
        }
        
        public System.Threading.Tasks.Task<string> GetWeekDayInBgAsync(System.DateTime date) {
            return base.Channel.GetWeekDayInBgAsync(date);
        }
    }
}