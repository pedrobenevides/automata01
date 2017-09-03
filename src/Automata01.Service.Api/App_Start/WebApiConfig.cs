using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;

namespace Automata01.Service.Api.App_Start
{
    public class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {

            app.UseCors(CorsOptions.AllowAll);
            var config = new HttpConfiguration();

            
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}