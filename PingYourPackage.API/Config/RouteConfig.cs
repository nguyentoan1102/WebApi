using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using System.Web.Routing;

namespace PingYourPackage.API.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            var routes = config.Routes;
            routes.MapHttpRoute(
                "DefaultHttpRoute",
                "api/{controller}/{key}",
                defaults: new { key = RouteParameter.Optional },
                constraints: new { key = new GuidRouteConstraint() }
                );
        }
    }
}