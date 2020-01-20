using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.Youtube.DataAccess;
using IdentityServer3.AccessTokenValidation;
using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            //factory.UseInMemoryScopes(StandardScopes.All);
            //factory.UseInMemoryUsers(new List<InMemoryUser>()
            //{
            //    new InMemoryUser()
            //    {
            //        Username = "user",
            //        Password = "password",
            //        Subject = Guid.NewGuid().ToString()
            //        Claims = new Claim[]
            //        {
            //            new Claim("isAuthorized", "true")
            //        }
            //    }
            //});

            factory.UseInMemoryScopes(StandardScopes.All.Append(
                new Scope()
                {
                    Name = "auth_info",
                    Claims = new List<ScopeClaim>()
                    {
                        new ScopeClaim("isAuthorized", true)
                    },
                    Type = ScopeType.Identity
                }));

            factory.UserService = new Registration<IUserService>(resolver => 
            new AspNetIdentityUserService<IdentityUser, string>(
                new UserManager<IdentityUser, string>(
                    new UserStore<IdentityUser>(new YoutubeContext()))));

            options.Factory = factory;
            options.IssuerUri = "BulbaCourses security server";
            options.RequireSsl = false;

            var path = Path.Combine(
                            new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath
                            , "cert.pfx");

            var cert = File.ReadAllBytes(path);

            options.SigningCertificate = new X509Certificate2(cert, "123");

            app.UseIdentityServer(options);

            JwtSecurityTokenHandler.InboundClaimTypeMap = new ConcurrentDictionary<string, string>();
            JwtSecurityTokenHandler.InboundClaimFilter = new HashSet<string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                IssuerName = "BulbaCourses security server",
                Authority = "http://localhost:9000",
                ValidationMode = ValidationMode.Local,
                SigningCertificate = new X509Certificate2(cert, "123"),
                NameClaimType = "name",
                RoleClaimType = "role"
            });

            app.UseWebApi(config);
        }
    }
}
