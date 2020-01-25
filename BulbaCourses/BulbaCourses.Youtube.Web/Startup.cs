using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Ninject;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.Common.OwinHost;
using FluentValidation;
using FluentValidation.WebApi;
using BulbaCourses.Youtube.Logic;
using BulbaCourses.Youtube.Web.App_Start;
using BulbaCourses.Youtube.Logic.Models;
using IdentityServer3.AccessTokenValidation;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Swashbuckle.Application;
using System.Reflection;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Collections.Concurrent;
using Microsoft.Owin.Cors;
using System.Web.Cors;
using Microsoft.Owin.Security;
using System.Web.Http.Description;
using Swashbuckle.Examples;
using Microsoft.Web.Http.Routing;
using System.Web.Http.Routing;

[assembly: OwinStartup(typeof(BulbaCourses.Youtube.Web.Startup))]

namespace BulbaCourses.Youtube.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();

            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = request => Task.FromResult(new CorsPolicy()
                    {
                        AllowAnyHeader = true,
                        AllowAnyMethod = true,
                        Origins = { "http://localhost:4200" },
                        SupportsCredentials = true
                    })
                },
                CorsEngine = new CorsEngine()
            });


            var path = Path.Combine(
                new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath
                , "bulbacourses.pfx");
            var cert = File.ReadAllBytes(path);


            //config.EnableSwagger(c => { c.SingleApiVersion("v1", "BulbaCourses.Youtube.Web"); })
            //    .EnableSwaggerUi();

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

            JwtSecurityTokenHandler.InboundClaimTypeMap = new ConcurrentDictionary<string, string>();
            JwtSecurityTokenHandler.InboundClaimFilter = new HashSet<string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,

                IssuerName = "http://localhost:44382",
                Authority = "https://localhost:44382",
                ValidationMode = ValidationMode.Local,
                SigningCertificate = new X509Certificate2(cert, "123")
            });

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            var kernel = new StandardKernel(new LogicModule());

            //FluentValidation configuration
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            //EasyNetQ
            kernel.RegisterEasyNetQ("host=localhost");

            return kernel;
        }
    }
}
