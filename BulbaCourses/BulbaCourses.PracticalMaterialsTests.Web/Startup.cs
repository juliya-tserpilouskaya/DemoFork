using System.Web.Http;
using BulbaCourses.PracticalMaterialsTests.Logic.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using Microsoft.Owin;
using Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.IO;
using System.Reflection;
using System;
using IdentityServer3.AccessTokenValidation;
using System.Security.Cryptography.X509Certificates;
using BulbaCourses.PracticalMaterialsTests.Web.Properties;

[assembly: OwinStartup(typeof(BulbaCourses.PracticalMaterialsTests.Web.Startup))]

namespace BulbaCourses.PracticalMaterialsTests.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            // ---------- IdentityServer3            

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                IssuerName = "My Security Server",

                Authority = "http://localhost:5050",

                ValidationMode = ValidationMode.Local,

                SigningCertificate = new X509Certificate2(Resources.bulbacourses, "123")
            });

            // ---------- Swagger

            SwaggerConfig.Register(config);

            // ---------- AppUse

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);                    
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            StandardKernel kernel = new StandardKernel();

            // ---------- LayerLogic

            kernel.Bind<IService_Test>().To<Service_Test>();

            kernel.Load<ModuleNinject_LogicLayer>();

            // ---------- EasyNetQ

            kernel.RegisterEasyNetQ("host=127.0.0.1");

            return kernel;
        }
    }
}
