using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Net;
using System.ServiceModel.Activation;

namespace EmployeeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserPost”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserPost.svc 或 UserPost.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserPost : IUserPost
    {
        public void DoWork()
        {
        }

        public static IList<User> users = new List<User>
        {
            new User{id="1926",name="JZM",password="haha"},  
            new User{id="1949",name="XJP",password="xixi"}
        };

        public User Get(string id)
        {
            User user = users.FirstOrDefault(f => f.id == id);
            if (null == user)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            return user;
        }

        public void Create(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }
    }
}
