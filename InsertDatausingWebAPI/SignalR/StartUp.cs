using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

namespace RecordDataAPI
{
    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure the SignalR hosting    
            appBuilder.MapSignalR();

            //HttpConfiguration config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(
            //name: "DefaultApi",
            //routeTemplate: "{controller}/{action}");

            //// Configure the WebAPI hosting    
            //appBuilder.UseWebApi(config);
        }
    }
}