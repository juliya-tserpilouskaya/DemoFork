using System.Web.Mvc;
using System.Web.Routing;

namespace BulbaCourses.Analytics.Web
{
    /// <summary>
    /// Represents a web route configuration.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registers a web routes configuration.
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
