using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmployeeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“EmpInfoService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 EmpInfoService.svc 或 EmpInfoService.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmpInfoService : IEmpInfoService
    {
        public string GetEmpSalary(string EmpId)
        {
            return "Salary of " + EmpId + " is " + 2000;
        }
    }
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserInfoService : IUserInfoService
    {
        public UserInfoService()
        {
            refreshData();
        }
        private void refreshData()
        {
            MySqlConnection connenction = new MySqlConnection();
            connenction.ConnectionString = "Server=localhost;Database=test;Uid=lmb;Pwd=1234;";
            try
            {
                var list = connenction.Query<User>("select * from test.table1");
                users = list.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        List<User> users { set; get; }
        public string GetInfo(string id, string type)
        {
            refreshData();
            User user = new User();
            MySqlConnection connenction = new MySqlConnection();
            connenction.ConnectionString = "Server=localhost;Database=test;Uid=lmb;Pwd=1234;";
            string sqlstring = "select " + type.ToString() + " from test.table1 where id=" + id.ToString();
            try
            {
                user = connenction.QueryFirst<User>(sqlstring);
                string str = user.GetType().GetProperty(type).GetValue(user).ToString();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        public List<User> GetAll()
        {
            return this.users;
        }

        //public string GetAll()
        //{
        //    refreshData();
        //}
    }


}
