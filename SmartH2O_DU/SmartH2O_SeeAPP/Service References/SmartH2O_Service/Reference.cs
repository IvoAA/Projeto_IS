﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartH2O_SeeAPP.SmartH2O_Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SmartH2O_Service.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSumInformationAtDay", ReplyAction="http://tempuri.org/IService1/GetSumInformationAtDayResponse")]
        string[] GetSumInformationAtDay(string day, string elem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSumInformationAtDay", ReplyAction="http://tempuri.org/IService1/GetSumInformationAtDayResponse")]
        System.Threading.Tasks.Task<string[]> GetSumInformationAtDayAsync(string day, string elem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSumInformationBetweenDates", ReplyAction="http://tempuri.org/IService1/GetSumInformationBetweenDatesResponse")]
        System.Collections.Generic.Dictionary<System.DateTime, double[]> GetSumInformationBetweenDates(System.DateTime firstDate, System.DateTime secondDate, string elem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSumInformationBetweenDates", ReplyAction="http://tempuri.org/IService1/GetSumInformationBetweenDatesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<System.DateTime, double[]>> GetSumInformationBetweenDatesAsync(System.DateTime firstDate, System.DateTime secondDate, string elem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSumInformationByWeek", ReplyAction="http://tempuri.org/IService1/GetSumInformationByWeekResponse")]
        System.Collections.Generic.Dictionary<int, double[]> GetSumInformationByWeek(string elem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSumInformationByWeek", ReplyAction="http://tempuri.org/IService1/GetSumInformationByWeekResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, double[]>> GetSumInformationByWeekAsync(string elem);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : SmartH2O_SeeAPP.SmartH2O_Service.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<SmartH2O_SeeAPP.SmartH2O_Service.IService1>, SmartH2O_SeeAPP.SmartH2O_Service.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetSumInformationAtDay(string day, string elem) {
            return base.Channel.GetSumInformationAtDay(day, elem);
        }
        
        public System.Threading.Tasks.Task<string[]> GetSumInformationAtDayAsync(string day, string elem) {
            return base.Channel.GetSumInformationAtDayAsync(day, elem);
        }
        
        public System.Collections.Generic.Dictionary<System.DateTime, double[]> GetSumInformationBetweenDates(System.DateTime firstDate, System.DateTime secondDate, string elem) {
            return base.Channel.GetSumInformationBetweenDates(firstDate, secondDate, elem);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<System.DateTime, double[]>> GetSumInformationBetweenDatesAsync(System.DateTime firstDate, System.DateTime secondDate, string elem) {
            return base.Channel.GetSumInformationBetweenDatesAsync(firstDate, secondDate, elem);
        }
        
        public System.Collections.Generic.Dictionary<int, double[]> GetSumInformationByWeek(string elem) {
            return base.Channel.GetSumInformationByWeek(elem);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, double[]>> GetSumInformationByWeekAsync(string elem) {
            return base.Channel.GetSumInformationByWeekAsync(elem);
        }
    }
}