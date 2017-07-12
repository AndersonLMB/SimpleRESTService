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
            UriTemplate = "EmpInfoDetail/{EmpId}?howmuch={money}&currency={currency}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped
            )]
        string GetEmpSalary(string EmpId, string money, string currency);
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

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UserInfo/all", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<User> GetAll();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UserInfo/AddUser?id={id}&name={name}&password={password}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddUser(string id, string name, string password);
    }

    [Serializable]
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "password")]
        public string password { get; set; }

        public override string ToString()
        {
            return id.ToString() + " " + name.ToString() + " " + password.ToString();
            //return base.ToString();
        }
    }
}
