using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using System.IdentityModel.Tokens;
using Owin;
using Microsoft.Owin.Cors;
using System.Web.Cors;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Security;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(BulbaCourses.GlobalAdminUser.Web.App_Start.Startup))]

namespace BulbaCourses.GlobalAdminUser.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.InboundClaimFilter = new HashSet<string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,
                IssuerName = "http://localhost:44382",
                SigningCertificate = new X509Certificate2(Properties.Resources.bulbacourses, "123"),
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
                            Origins = { "http://localhost:4200" },
                            AllowAnyHeader = true
                        })
                    }
                });

            //app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }
    }
}
