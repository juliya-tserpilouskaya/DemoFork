using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;

namespace BulbaCourses.PracticalMaterialsTests.Web.Configuration
{
    public static class Configurtation_Swagger
    {
        /// <summary>
        /// Creates Swagger configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static HttpConfiguration CreateSwagger(this HttpConfiguration configuration)
        {
            configuration.EnableSwagger(
                "swagger/{apiVersion}",
                swagger =>
                {
                    swagger.OAuth2("oauth2")
                        .Description("OAuth2 Implicit Grant")
                        .Flow("implicit")
                        .AuthorizationUrl("http://localhost:44382/connect/authorize")
                        .TokenUrl("http://localhost:44382/connect/token")
                        .Scopes(scopes =>
                        {
                            scopes.Add("openid", "Read access to protected resources");
                            scopes.Add("profile", "Write access to protected resources");
                        });

                })
                .EnableSwaggerUi(swagger =>
                {
                    swagger.EnableDiscoveryUrlSelector();
                    swagger.EnableOAuth2Support(
                        clientId: "external_app",
                        clientSecret: null,
                        realm: "test-realm",
                        appName: "Swagger UI"                        
                    );
                });

            return configuration;
        }
    }
}