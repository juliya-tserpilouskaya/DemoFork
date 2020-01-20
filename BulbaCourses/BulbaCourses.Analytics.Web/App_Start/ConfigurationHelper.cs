using BulbaCourses.Analytics.BLL.Ensure.Validators;
using BulbaCourses.Analytics.Web.Ensure;
using FluentValidation;
using FluentValidation.WebApi;
using Microsoft.Web.Http.Routing;
using Ninject;
using Swashbuckle.Application;
using Swashbuckle.Examples;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;

namespace BulbaCourses.Analytics.Web.App_Start
{
    /// <summary>
    /// Represents Versioning with Swagger configuration. Default uses in WebApiConfig.
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Creates Validators Configuration.
        /// </summary>
        /// <param name="configutation"></param>
        public static HttpConfiguration CreateValidation(this HttpConfiguration configutation)
        {
            IKernel kernel = (IKernel)configutation.DependencyResolver.GetService(typeof(IKernel));

            // Web API configuration and services
            FluentValidationModelValidatorProvider.Configure(configutation,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining(typeof(ReportCreateValidator))
                .ForEach(result => 
                    kernel.Bind(result.InterfaceType).To(result.ValidatorType)
                );

            return configutation;
        }

        /// <summary>
        /// Creates Versioning configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static HttpConfiguration CreateVersioning(this HttpConfiguration configuration)
        {
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                        {
                            ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                        }
            };
            // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
            configuration.AddApiVersioning(options => options.ReportApiVersions = true);
            configuration.MapHttpAttributeRoutes(constraintResolver);
            configuration.AddApiVersioning();

            return configuration;
        }

        /// <summary>
        /// Creates Swagger configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static HttpConfiguration CreateSwagger(this HttpConfiguration configuration)
        {
            // add the versioned IApiExplorer and capture the strongly-typed implementation (e.g. VersionedApiExplorer vs IApiExplorer)
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            var apiExplorer = configuration.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            configuration.EnableSwagger(
                "swagger/{apiVersion}",
                swagger =>
                {
                    // build a swagger document and endpoint for each discovered API version
                    swagger.MultipleApiVersions(
                        (apiDescription, version) => apiDescription.GetGroupName() == version,
                        info =>
                        {
                            foreach (var group in apiExplorer.ApiDescriptions)
                            {
                                var description = "Analytics.";

                                if (group.IsDeprecated)
                                {
                                    description += " This API version has been deprecated.";
                                }

                                info.Version(group.Name, $"API {group.ApiVersion}")
                                    .Contact(c => c.Name("Dmitriy Bulova").Email("dm.bu@lova.com"))
                                    .Description(description)
                                    .License(l => l.Name("MIT").Url("https://opensource.org/licenses/MIT"))
                                    .TermsOfService("Shareware");
                            }
                        });

                    // add a custom operation filter which sets default values
                    swagger.OperationFilter<SwaggerDefaultValues>();
                    swagger.OperationFilter<ExamplesOperationFilter>();

                    // integrate xml comments
                    swagger.IncludeXmlComments(Paths.XmlCommentsFilePath);
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
                    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                    );
                });

            return configuration;
        }
    }
}