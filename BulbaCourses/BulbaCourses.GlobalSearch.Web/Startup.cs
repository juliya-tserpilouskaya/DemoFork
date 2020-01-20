using System;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Logic;
using BulbaCourses.GlobalSearch.Logic.Validators;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Web.App_Start;
using FluentValidation;
using FluentValidation.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Swashbuckle.Application;
using IdentityServer3.AccessTokenValidation;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Web.Cors;
using System.Reflection;
using BulbaCourses.GlobalSearch.Web.Properties;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(BulbaCourses.GlobalSearch.Web.Startup))]

namespace BulbaCourses.GlobalSearch.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            SwaggerConfig.Register(config);

            config.EnableSwagger(c => { c.SingleApiVersion("v1", "BulbaCourses.GlobalSearch.Web"); })
                .EnableSwaggerUi();

            //app.UseWebApi(config);

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.InboundClaimFilter = new HashSet<string>();


            //JwtSecurityTokenHandler.InboundClaimTypeMap = new ConcurrentDictionary<string, string>();
            //JwtSecurityTokenHandler.InboundClaimFilter = new HashSet<string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {

                IssuerName = "https://localhost:44382",
                AuthenticationMode = AuthenticationMode.Active,
                ValidationMode = ValidationMode.Local,
                SigningCertificate = new X509Certificate2(Resources.bulbacourses, "123")

            }).UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = request => Task.FromResult(new CorsPolicy()
                    {
                        AllowAnyHeader = true,
                        AllowAnyMethod = true,
                        AllowAnyOrigin = true
                    })
                },
                CorsEngine = new CorsEngine()
            });

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            var kernel = new StandardKernel(new LogicModule());
            kernel.Load<AutoMapperModule>();

            FluentValidationModelValidatorProvider
                .Configure(config, cfg => cfg.ValidatorFactory =
                new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<SearchQueryDTO>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                .To(result.ValidatorType));

            kernel.RegisterEasyNetQ("host=127.0.0.1");
            return kernel;
        }
    }
}
