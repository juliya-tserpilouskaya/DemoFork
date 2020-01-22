using BulbaCourses.PracticalMaterialsTasks.BLL.Models;
using BulbaCourses.PracticalMaterialsTasks.WEB.App_Start;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTasks.WEB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));
            // Конфигурация и службы веб-API
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            //IValidator<Task> сканирует сборку и возвр список результатов, где вкачестве интерфейсов указан базовый тип
            // а в качестве типа валидатора - связанный с ним класс
            AssemblyScanner.FindValidatorsInAssemblyContaining<TaskDTO>()
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
