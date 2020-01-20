using FluentValidation.WebApi;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BulbaCourses.Youtube.Logic.Models;
using Ninject;
using BulbaCourses.Youtube.Web.App_Start;
using EasyNetQ;

namespace BulbaCourses.Youtube.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));

            // Web API configuration and services
            //FluentValidation configuration
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<SearchStory>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            //RabbitMQ configuration
            var bus = kernel.Get<IBus>();
            bus.Receive<SearchRequest>("YoutubeQ", m => OnMessage(m));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void OnMessage(SearchRequest obj)
        {
            Console.WriteLine(obj.Title);
        }
    }
}
