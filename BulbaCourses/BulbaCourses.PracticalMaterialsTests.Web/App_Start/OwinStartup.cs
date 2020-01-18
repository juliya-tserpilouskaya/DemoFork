using System.Web.Http;
using BulbaCourses.PracticalMaterialsTests.Logic.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization;
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

[assembly: OwinStartup(typeof(BulbaCourses.PracticalMaterialsTests.Web.App_Start.OwinStartup))]

namespace BulbaCourses.PracticalMaterialsTests.Web.App_Start
{
public class OwinStartup
{
    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();

        config.MapHttpAttributeRoutes();

        // ---------- IdentityServer3
        
        var path =
            Path.Combine(
                new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath,
                "SelfHostedRertificate.pfx");
        
        var data = File.ReadAllBytes(path);

        app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
        {            
            IssuerName = "My Security Server",
            
            Authority = "http://localhost:5050",
            
            ValidationMode = ValidationMode.Local,
            
            SigningCertificate = new X509Certificate2(data, "123")
        });

        // ---------- AppUse

        app.UseWebApi(config);

        app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);                       
    }

    private IKernel ConfigureValidation(HttpConfiguration config)
    {
        var kernel = new StandardKernel();

        // ---------- LayerLogic

        kernel.Bind<IService_Test>().To<Service_Test>();

        kernel.Load<ModuleNinject_Logic>();

        // ---------- EasyNetQ

        kernel.RegisterEasyNetQ("host=127.0.0.1");

        return kernel;
    }
}
}
