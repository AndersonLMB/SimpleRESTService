using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace EmployeeService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //RegisterRoutes(RouteTable.Routes);
            //RouteTable.Routes.Add(new ServiceRoute("MyService", new WebServiceHostFactory(), typeof(EmpInfoService)));

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new ServiceRoute("/MyEmpService", new WebServiceHostFactory(), typeof(EmployeeService.EmpInfoService)));
        }
    }
}