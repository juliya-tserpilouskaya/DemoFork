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
                    //// build a swagger document and endpoint for each discovered API version
                    //swagger.MultipleApiVersions(
                    //    (apiDescription, version) => apiDescription.GetGroupName() == version,
                    //    info =>
                    //    {
                    //        foreach (var group in apiExplorer.ApiDescriptions)
                    //        {
                    //            var description = "Analytics.";

                    //            if (group.IsDeprecated)
                    //            {
                    //                description += " This API version has been deprecated.";
                    //            }

                    //            info.Version(group.Name, $"API {group.ApiVersion}")
                    //                .Contact(c => c.Name("Dmitriy Bulova").Email("dm.bu@lova.com"))
                    //                .Description(description)
                    //                .License(l => l.Name("MIT").Url("https://opensource.org/licenses/MIT"))
                    //                .TermsOfService("Shareware");
                    //        }
                    //    });

                    //// add a custom operation filter which sets default values
                    //swagger.OperationFilter<SwaggerDefaultValues>();
                    //swagger.OperationFilter<ExamplesOperationFilter>();

                    //// integrate xml comments
                    //swagger.IncludeXmlComments(Paths.XmlCommentsFilePath);

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