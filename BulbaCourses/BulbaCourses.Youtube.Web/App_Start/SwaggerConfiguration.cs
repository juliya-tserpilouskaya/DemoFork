using Microsoft.Web.Http.Routing;
using Swashbuckle.Application;
using Swashbuckle.Examples;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using System.IO;
using System.Reflection;
using System;
using Ninject;
using FluentValidation.WebApi;
using FluentValidation;
using BulbaCourses.Youtube.Logic.Models;
using EasyNetQ;

namespace BulbaCourses.Youtube.Web.App_Start
{
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Creates Swagger configuration.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static HttpConfiguration CreateSwagger(this HttpConfiguration config)
        {
            var apiExplorer = config.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    options.SubstituteApiVersionInUrl = true;
                });

            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                        {
                            ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                        }
            };
            config.AddApiVersioning(options => options.ReportApiVersions = true);
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning();

            config.EnableSwagger(
                "swagger/{apiVersion}",
                swagger =>
                {
                    swagger.MultipleApiVersions(
                        (apiDescription, version) => apiDescription.GetGroupName() == version,
                        info =>
                        {
                            foreach (var group in apiExplorer.ApiDescriptions)
                            {
                                var description = "Youtube search service";

                                if (group.IsDeprecated)
                                {
                                    description += " This API version has been deprecated.";
                                }

                                info.Version(group.Name, $"API {group.ApiVersion}")
                                    .Contact(c => c.Name("Eugene Patysh & Lyudmila Khomyakova").Email("y12@it.com"))
                                    .Description(description)
                                    .License(l => l.Name("MIT").Url("https://opensource.org/licenses/MIT"))
                                    .TermsOfService("Shareware");
                            }
                        });

                    swagger.OperationFilter<SwaggerDefaultValues>();
                    swagger.OperationFilter<ExamplesOperationFilter>();

                    var appDomain = AppDomain.CurrentDomain;
                    var contentRootPath = string.IsNullOrEmpty(appDomain.RelativeSearchPath) ? appDomain.BaseDirectory : appDomain.RelativeSearchPath;
                    var fileName = typeof(WebApiApplication).GetTypeInfo().Assembly.GetName().Name + ".xml";

                    swagger.IncludeXmlComments(Path.Combine(contentRootPath, fileName));

                    swagger.OAuth2("oauth2")
                        .Description("OAuth2 Implicit Grant")
                        .Flow("implicit")
                        .AuthorizationUrl("http://localhost:44382/connect/authorize")
                        .TokenUrl("http://localhost:44382/connect/token")
                        .Scopes(scopes =>
                        {
                            scopes.Add("api", "API access scope");
                            //scopes.Add("profile", "Write access to protected resources");
                        });
                    swagger.OperationFilter<AssignOAuth2SecurityRequirements>();

                })
                .EnableSwaggerUi(swagger =>
                {
                    swagger.EnableDiscoveryUrlSelector();
                    swagger.EnableOAuth2Support("external_app", "test_realm", "Swagger UI");

                });

            return config;
        }
        
    }
}