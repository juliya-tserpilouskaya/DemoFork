using BulbaCourses.Analytics.Web.App_Start;
using System.Web.Http;

namespace BulbaCourses.Analytics.Web
{
    /// <summary>
    /// Configure WebApiConfig
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registration Web API configuration
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void Register(HttpConfiguration config)
        {
            // Swagger should go after Versioning.
            // If Swagger - Swagger() is not needed just comment/delete it.
            config
                .CreateValidation()
                .CreateVersioning()
                .CreateSwagger();

            #region ConfigRoutes
            config.Routes.MapHttpRoute(
                    name: "ReportsRoute",
                    routeTemplate: "api/v{version:apiVersion}/reports/name/{name}",
                    defaults: new { controller = "reports", name = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v{version:apiVersion}/{controller}/id/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            #endregion
        }
    }
}
