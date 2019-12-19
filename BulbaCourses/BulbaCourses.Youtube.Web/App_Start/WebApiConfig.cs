using FluentValidation.WebApi;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BulbaCourses.Youtube.Web.Logic.Models;
using Ninject;
using BulbaCourses.Youtube.Web.App_Start;

namespace BulbaCourses.Youtube.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));

            // Web API configuration and services
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<SearchStory>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

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
