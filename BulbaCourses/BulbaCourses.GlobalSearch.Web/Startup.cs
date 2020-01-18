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
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Swashbuckle.Application;

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

            app.UseWebApi(config);

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

            //kernel.RegisterEasyNetQ("host=10.211.55.2");
            return kernel;
        }
    }
}
