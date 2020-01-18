using BulbaCourses.Video.Web.App_Start;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BulbaCourses.Video.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));

            // Web API configuration and services
            //FluentValidationModelValidatorProvider.Configure(config,
            //    cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            //IValidator<User>
            //AssemblyScanner.FindValidatorsInAssemblyContaining<UserProfileView>()
            //    .ForEach(result => kernel.Bind(result.InterfaceType)
            //    .To(result.ValidatorType));
            //AssemblyScanner.FindValidatorsInAssemblyContaining<CourseView>()
            //    .ForEach(result => kernel.Bind(result.InterfaceType)
            //        .To(result.ValidatorType));

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
