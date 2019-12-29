using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.Youtube.SelfHosted.Startup))]

namespace BulbaCourses.Youtube.SelfHosted
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var options = new IdentityServerOptions();
            var factory = new IdentityServerServiceFactory();
            factory.UseInMemoryClients(new[] {
                new Client()
                {
                    ClientId = "clientId",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.ResourceOwner,
                    AllowAccessToAllScopes = true
                }
            });
            factory.UseInMemoryScopes(StandardScopes.All);
            factory.UseInMemoryUsers(new List<InMemoryUser>()
            {
                new InMemoryUser()
                {
                    Username = "user",
                    Password = "password",
                    Subject = Guid.NewGuid().ToString()
                }
            });

            options.Factory = factory;
            options.IssuerUri = "BulbaCourses security server";
            options.RequireSsl = false;

            var path = Path.Combine(
                            new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath
                            , "cert.pfx");

            var cert = File.ReadAllBytes(path);

            options.SigningCertificate = new X509Certificate2(cert, "123");

            app.UseIdentityServer(options);
            app.UseWebApi(config);
        }
    }
}
