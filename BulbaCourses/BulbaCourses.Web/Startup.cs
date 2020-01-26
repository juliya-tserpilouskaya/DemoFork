using System;
using System.Data.Entity;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using BulbaCourses.Web.Data;
using BulbaCourses.Web.Migrations;
using BulbaCourses.Web.Properties;
using BulbaCourses.Web.Security;
using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Jwt;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.Web.Startup))]

namespace BulbaCourses.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = request => Task.FromResult(new CorsPolicy()
                    {
                        AllowAnyHeader = true,
                        AllowAnyMethod = true,
                        Origins = { "http://localhost:4200" /*, "http://localhost:44352", "http://localhost:44382" */},
                        SupportsCredentials = true
                    })
                },
                CorsEngine = new CorsEngine()
            });

            ConfigSecurity(app);

            app.UseNinjectMiddleware(() => new StandardKernel(new InjectModule()))
                .UseNinjectWebApi(config);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
        }

        private void ConfigSecurity(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory();
            factory.UseInMemoryClients(SecurityConfig.LoadClients())
                .UseInMemoryScopes(SecurityConfig.LoadScopes());

            factory.Register(new Registration<UserManager<IdentityUser, string>>(resolver => new BulbaUserManager(new UserStore<IdentityUser>(new UserContext()))));
            factory.Register(new Registration<AspNetIdentityUserService<IdentityUser, string>>());
            factory.UserService = new Registration<IUserService, AspNetIdentityUserService<IdentityUser, string>>();

            var options = new IdentityServerOptions
            {
                Factory = factory,
                IssuerUri = "http://localhost:44382",
                RequireSsl = false,
                SiteName = "BulbaCourses SSO",
                SigningCertificate = new X509Certificate2(Resources.bulbacourses, "123")
            };

            app.UseIdentityServer(options);
        }
    }
}
