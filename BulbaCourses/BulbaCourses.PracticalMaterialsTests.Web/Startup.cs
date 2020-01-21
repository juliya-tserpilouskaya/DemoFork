using System.Web.Http;
using BulbaCourses.PracticalMaterialsTests.Logic.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using Microsoft.Owin;
using Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using IdentityServer3.AccessTokenValidation;
using System.Security.Cryptography.X509Certificates;
using BulbaCourses.PracticalMaterialsTests.Web.Properties;
using Microsoft.Owin.Security;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using Microsoft.Owin.Cors;
using System.Threading.Tasks;
using System.Web.Cors;
using FluentValidation.WebApi;
using FluentValidation;

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

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            JwtSecurityTokenHandler.InboundClaimFilter = new HashSet<string>();
                        
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
                {
                    AuthenticationMode = AuthenticationMode.Active,

                    IssuerName = "https://localhost:44382",

                    SigningCertificate = new X509Certificate2(Resources.bulbacourses, "123"),

                    ValidationMode = ValidationMode.Local,
                })
                .UseCors(new CorsOptions()
                {
                    PolicyProvider = new CorsPolicyProvider()
                    {
                        PolicyResolver = request => Task.FromResult(new CorsPolicy()
                        {
                            AllowAnyMethod = true,

                            AllowAnyOrigin = true,

                            AllowAnyHeader = true
                        })
                    }
                });

            // ---------- Swagger

            SwaggerConfig.Register(config);

            // ---------- AppUse

            app.UseNinjectMiddleware(() => ConfigureValidation(config))
               .UseNinjectWebApi(config);                    
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            StandardKernel kernel = new StandardKernel();

            // ---------- LayerLogic

            kernel.Bind<IService_Test>().To<Service_Test>();

            kernel.Load<ModuleNinject_LogicLayer>();

            // ---------- FluentValidation

            // ---------- EasyNetQ

            kernel.RegisterEasyNetQ("host=127.0.0.1");

            return kernel;
        }
    }
}
