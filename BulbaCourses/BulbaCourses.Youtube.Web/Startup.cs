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

[assembly: OwinStartup(typeof(BulbaCourses.Youtube.Web.Startup))]

namespace BulbaCourses.Youtube.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            var cert = File.ReadAllBytes(
               @"D:\LearnASPNET\bulba-courses\BulbaCourses\BulbaCourses.Youtube.SelfHosted\bin\debug\cert.pfx");

            config.EnableSwagger(c => { c.SingleApiVersion("v1", "BulbaCourses.Youtube.Web"); })
                .EnableSwaggerUi();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                IssuerName = "BulbaCourses security server",
                Authority = "http://localhost:9000",
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
            
            //IValidator SearchStory
            AssemblyScanner.FindValidatorsInAssemblyContaining<SearchStory>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            //IValidator SearchRequest
            AssemblyScanner.FindValidatorsInAssemblyContaining<SearchRequest>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            //
            kernel.RegisterEasyNetQ("host=localhost");

            return kernel;
        }
    }
}
