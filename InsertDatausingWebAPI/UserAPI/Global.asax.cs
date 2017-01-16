using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Net.Http.Handlers;

namespace UserAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        void ConfigureApi(HttpConfiguration config)
        {
            
            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);
        }
    }
}
