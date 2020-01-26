using BulbaCourses.Analytics.BLL.Ensure.Validators;
using BulbaCourses.Analytics.Web.Ensure;
using BulbaCourses.Analytics.Web.Properties;
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
        private const string API_VERSION = "apiVersion";
        private const string GROUP_NAME_FORMAT = "'v'VVV";
        private const string ROUT_TEMPLATE = "swagger/{apiVersion}";
        private const string O_AUTH2 = "oauth2";
        private const string O_AUTH2_FLOW = "implicit";
        private const string OPEN_ID = "openid";
        private const string PROFILE = "profile";
        private const string CLIENT_ID = "external_app";
        private const string REALM = "test-realm";
        private const string APP_NAME = "Swagger UI";

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
                            [API_VERSION] = typeof( ApiVersionRouteConstraint )
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
                    options.GroupNameFormat = GROUP_NAME_FORMAT;

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            configuration.EnableSwagger(
                    ROUT_TEMPLATE,
                swagger =>
                {
                    // build a swagger document and endpoint for each discovered API version
                    swagger.MultipleApiVersions(
                        (apiDescription, version) => apiDescription.GetGroupName() == version,
                        info =>
                        {
                            foreach (var group in apiExplorer.ApiDescriptions)
                            {
                                var description = Resources.NameDomain;
                                description += Resources.DescriptionDomain;

                                if (group.IsDeprecated)
                                {
                                    description += Resources.DeprecatedAPI;
                                }

                                info.Version(group.Name, $"{Resources.API} {group.ApiVersion}")
                                    .Contact(c => c.Name(Resources.NameDeveloper).Email(Resources.NameDeveloper))
                                    .Description(description)
                                    .License(l => l.Name(Resources.MIT).Url(Resources.UrlMIT))
                                    .TermsOfService(Resources.TermsOfService);
                            }
                        });

                    // add a custom operation filter which sets default values
                    swagger.OperationFilter<SwaggerDefaultValues>();
                    swagger.OperationFilter<ExamplesOperationFilter>();

                    // integrate xml comments
                    swagger.IncludeXmlComments(Paths.XmlCommentsFilePath);
                    
                    swagger.OAuth2(O_AUTH2)
                        .Description(Resources.OAuth2Description)
                        .Flow(O_AUTH2_FLOW)
                        .AuthorizationUrl(Resources.AuthorizationUrl)
                        .TokenUrl(Resources.TokenUrl)
                        .Scopes(scopes =>
                        {
                            scopes.Add(OPEN_ID, Resources.OpenIdDescription);
                            scopes.Add(PROFILE, Resources.ProfileDescription);
                        });

                })
                .EnableSwaggerUi(swagger =>
                {
                    swagger.EnableDiscoveryUrlSelector();
                    swagger.EnableOAuth2Support(
                        clientId: CLIENT_ID,
                        clientSecret: null,
                        realm: REALM,
                        appName: APP_NAME
                    );
                });

            return configuration;
        }
    }
}