using BulbaCourses.Podcasts.Logic;
using BulbaCourses.Podcasts.Web.App_Start;
using FluentValidation;
using FluentValidation.WebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

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
            //config.Filters.Add(new BadRequestFilterAttribute());
            var data = File.ReadAllBytes(
                @"C:\Users\Master\source\repos\Sample.Web\Sample.SelfHosted\bin\Debug\cert.pfx");

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                IssuerName = "My Security Server",
                Authority = "http://localhost:5050",
                ValidationMode = ValidationMode.Local,
                SigningCertificate = new X509Certificate2(data, "123")
            });

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            var kernel = new StandardKernel(new LogicModule());

            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<Models.CourseWeb>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            return kernel;
        }
    }
}
