using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace InsertDataUsingWebAPI
{
    public class Global_asax : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           // WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }       
       
}