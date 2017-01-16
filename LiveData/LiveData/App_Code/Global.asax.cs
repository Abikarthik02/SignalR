using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using System.Configuration;

namespace LiveData.App_Code
{
    public class Global : System.Web.HttpApplication
    {
        string connectionString =
              ConfigurationManager.ConnectionStrings["SampleDBEntity"].ConnectionString;

        protected void Application_Start(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDependency.Start(connectionString);
        }
       

        protected void Session_Start(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDependency.Stop(connectionString);

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
    }
}