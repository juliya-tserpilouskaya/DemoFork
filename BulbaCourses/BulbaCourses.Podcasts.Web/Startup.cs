using BulbaCourses.Podcasts.Logic;
using BulbaCourses.Podcasts.Web.App_Start;
using BulbaCourses.Podcasts.Web.Infrastructure;
using BulbaCourses.Podcasts.Web.Properties;
using FluentValidation;
using FluentValidation.WebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Cors;
using System.Web.Http;
using System.IdentityModel.Tokens;
using System.Collections.Concurrent;

[assembly: OwinStartup(typeof(BulbaCourses.Podcasts.Web.Startup))]

namespace BulbaCourses.Podcasts.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = request => Task.FromResult(new CorsPolicy()
                    {
                        AllowAnyMethod = true,
                        AllowAnyOrigin = true,
                        AllowAnyHeader = true
                    })
                }
            });


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                IssuerName = "http://localhost:44382",
                SigningCertificate = new X509Certificate2(Resources.bulbacourses, "123"),
                ValidationMode = ValidationMode.Local,

            });

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            
            var kernel = new StandardKernel(new LogicModule(), new DataModule());
            kernel.Load<MapperLoadModule>();

            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<Models.CourseWeb>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            kernel.RegisterEasyNetQ("host=localhost");
            return kernel;
        }
    }
}
