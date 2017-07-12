using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace EmployeeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserPost”。
    [ServiceContract]
    public interface IUserPost
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebGet(UriTemplate = "all")]
        IEnumerable<User> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        User Get(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/", Method = "POST")]
        void Create(User user);



    }

}
