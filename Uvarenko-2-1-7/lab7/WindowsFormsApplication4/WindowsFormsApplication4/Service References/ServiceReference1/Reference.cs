﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication4.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/F4", ReplyAction="http://tempuri.org/IService1/F4Response")]
        double F4(double x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/F4", ReplyAction="http://tempuri.org/IService1/F4Response")]
        System.Threading.Tasks.Task<double> F4Async(double x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllRows", ReplyAction="http://tempuri.org/IService1/GetAllRowsResponse")]
        System.Data.DataTable GetAllRows();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllRows", ReplyAction="http://tempuri.org/IService1/GetAllRowsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetAllRowsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetRowByID", ReplyAction="http://tempuri.org/IService1/GetRowByIDResponse")]
        System.Data.DataTable GetRowByID(int ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetRowByID", ReplyAction="http://tempuri.org/IService1/GetRowByIDResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetRowByIDAsync(int ID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WindowsFormsApplication4.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WindowsFormsApplication4.ServiceReference1.IService1>, WindowsFormsApplication4.ServiceReference1.IService1 {
        
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
        
        public double F4(double x) {
            return base.Channel.F4(x);
        }
        
        public System.Threading.Tasks.Task<double> F4Async(double x) {
            return base.Channel.F4Async(x);
        }
        
        public System.Data.DataTable GetAllRows() {
            return base.Channel.GetAllRows();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetAllRowsAsync() {
            return base.Channel.GetAllRowsAsync();
        }
        
        public System.Data.DataTable GetRowByID(int ID) {
            return base.Channel.GetRowByID(ID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetRowByIDAsync(int ID) {
            return base.Channel.GetRowByIDAsync(ID);
        }
    }
}
