using System;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.Video.Logic.Infrastructure;
using BulbaCourses.Video.Web.Infrastructure;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.Video.Web.Startup))]

namespace BulbaCourses.Video.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            //config.Filters.Add(new BadRequestFilterAttribute());

            //var data = File.ReadAllBytes(
            //    @"C:\Users\Master\source\repos\Sample.Web\Sample.SelfHosted\bin\Debug\cert.pfx");

            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            //{
            //    IssuerName = "My Security Server",
            //    Authority = "http://localhost:5050",
            //    ValidationMode = ValidationMode.Local,
            //    SigningCertificate = new X509Certificate2(data, "123")
            //});
            SwaggerConfig.Register(config);
            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            var kernel = new StandardKernel(new LogicLoadModule());
            kernel.Load<MapperLoadModule>();
            //// Web API configuration and services
            //FluentValidationModelValidatorProvider.Configure(config,
            //    cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            ////IValidator<Book>
            //AssemblyScanner.FindValidatorsInAssemblyContaining<Book>()
            //    .ForEach(result => kernel.Bind(result.InterfaceType)
            //        .To(result.ValidatorType));

            //kernel.RegisterEasyNetQ("host=10.211.55.2");
            return kernel;
        }
    }
}
