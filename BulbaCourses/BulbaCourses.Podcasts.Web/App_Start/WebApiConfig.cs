using System.Text;
using System.Web.Http;
using BulbaCourses.Podcasts.Web.App_Start;
using BulbaCourses.Podcasts.Web.Models;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using Newtonsoft.Json;
using Ninject;

namespace BulbaCourses.Podcasts.Web
{
    public static class WebApiConfig
    {
        private static IBus bus;

        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = (IKernel)config.DependencyResolver.GetService(typeof(IKernel));

            // Конфигурация и службы веб-API
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            AssemblyScanner.FindValidatorsInAssemblyContaining<CourseWeb>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));

            bus = kernel.Get<IBus>();


            //bus.Receive<Book>("BookService", b => BookStorage.Add(b));
            ////bus.Advanced.Consume(bus.Advanced.QueueDeclare("BookService"), OnMessage); // turn into getting users


            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        //private static void OnMessage(byte[] arg1, MessageProperties arg2, MessageReceivedInfo arg3)
        //{
        //    var book = JsonConvert.DeserializeObject<Book>(Encoding.UTF8.GetString(arg1));
        //    BookStorage.Add(book);
        //}
    }
}
