using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using Owin;

[assembly: OwinStartup(typeof(LiveData.StartUp))]
namespace LiveData
{
    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            
            appBuilder.MapSignalR("", new HubConfiguration()
            {
                EnableJavaScriptProxies = true
            });
            // Configure the SignalR hosting    
            appBuilder.MapSignalR();

            appBuilder.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // EnableJSONP = true;  // I am not using as CORS is working just fine
                };
                map.RunSignalR(hubConfiguration);
            });

            //var config = new HubConfiguration();
            //config.EnableJSONP = true;
            //appBuilder.MapSignalR(config);

            //HttpConfiguration config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(
            //name: "DefaultApi",
            //routeTemplate: "{controller}/{action}");

            //// Configure the WebAPI hosting    
            //appBuilder.UseWebApi(config);
        }
    }
}