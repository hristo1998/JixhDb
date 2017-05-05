using System.Web.Mvc;
using System.Web.Routing;

namespace JixhDb.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Movies", action = "GetMovies", id = UrlParameter.Optional }
            );
        }
    }
}
