using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace EmployeeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IEmpInfoService”。

 

    [ServiceContract]
    public interface IEmpInfoService
    {
        [OperationContract]
        [WebInvoke
         (
            Method = "GET",
            UriTemplate = "EmpInfoDetail/{EmpId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped
            )]
        string GetEmpSalary(string EmpId);
    }

    [ServiceContract]
    public interface IUserInfoService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "UserInfo/{id}/{type}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetInfo(string id, string type);
    }

    [DataContract]
    public class User
    {
        [DataMember]

        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string password { get; set; }
    }

}
