using System.Web.Http;

namespace InsertDataUsingWebAPI
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}