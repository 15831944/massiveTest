﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLoader.Service_References.DataManagementServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataManagementServiceReference.IDataManagementService")]
    public interface IDataManagementService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagementService/UploadNewData", ReplyAction="http://tempuri.org/IDataManagementService/UploadNewDataResponse")]
        int UploadNewData(Shared.Node[] nodesList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagementService/UploadNewData", ReplyAction="http://tempuri.org/IDataManagementService/UploadNewDataResponse")]
        System.Threading.Tasks.Task<int> UploadNewDataAsync(Shared.Node[] nodesList);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataManagementServiceChannel : IDataManagementService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataManagementServiceClient : System.ServiceModel.ClientBase<IDataManagementService>, IDataManagementService {
        
        public DataManagementServiceClient() {
        }
        
        public DataManagementServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataManagementServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataManagementServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataManagementServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int UploadNewData(Shared.Node[] nodesList) {
            return base.Channel.UploadNewData(nodesList);
        }
        
        public System.Threading.Tasks.Task<int> UploadNewDataAsync(Shared.Node[] nodesList) {
            return base.Channel.UploadNewDataAsync(nodesList);
        }
    }
}
