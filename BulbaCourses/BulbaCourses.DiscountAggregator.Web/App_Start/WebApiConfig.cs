using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Validators;
using BulbaCourses.DiscountAggregator.Web.App_Start;
using BulbaCourses.DiscountAggregator.Web.Filters;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel) config.DependencyResolver.GetService(typeof(IKernel));

            // Web API configuration and services
            FluentValidationModelValidatorProvider.Configure(config,
                 cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            //IValidator<Course> сканирует сборку и возвр список результатов, где вкачестве интерфейсов указан базовый тип
            // а в качестве типа валидатора - связанный с ним класс
            AssemblyScanner.FindValidatorsInAssemblyContaining<Course>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            config.Filters.Add(new BadRequestFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
