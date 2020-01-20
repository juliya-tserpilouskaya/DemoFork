using BulbaCourses.Podcasts.Web.App_Start;
using BulbaCourses.Podcasts.Web.Models;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using System.Web.Http;

namespace BulbaCourses.Podcasts.Web
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));

            // Конфигурация и службы веб-API
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<CourseWeb>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));
            
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
