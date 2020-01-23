using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using Newtonsoft.Json;
using Ninject;
using Presentations.Logic.Repositories;
using Presentations.Logic.Services;

namespace BulbaCourses.TextMaterials_Presentations.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel) config.DependencyResolver.GetService(typeof(IKernel));

            // Web API configuration and services
            FluentValidationModelValidatorProvider.Configure(config, cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<Presentation>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                .To(result.ValidatorType));

            //RabbitMQ configuration
            var bus = kernel.Get<IBus>();
            bus.Receive<Course>("Test", m => OnMessage(m));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void OnMessage(Course obj)
        {
            Console.WriteLine(obj.Update);
        }
    }
}
