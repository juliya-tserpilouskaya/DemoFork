using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Web.App_Start;
using BulbaCourses.PracticalMaterialsTests.Web.Configuration;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.Web
{
    public static class WebApiConfig
    {
        private static IBus bus;

        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));

            bus = kernel.Get<IBus>();

            bus.Receive("TestService", null);

            config
                .CreateSwagger()
                .MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
