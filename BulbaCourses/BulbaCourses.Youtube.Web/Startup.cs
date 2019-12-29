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
using BulbaCourses.Youtube.Web.Logic;
using BulbaCourses.Youtube.Web.App_Start;
using BulbaCourses.Youtube.Web.Logic.Models;

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

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);

            app.UseWebApi(config);
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
            
            //
            kernel.RegisterEasyNetQ("host=localhost");

            return kernel;
        }
    }
}
