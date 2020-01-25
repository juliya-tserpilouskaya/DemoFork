using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using BulbaCourses.TextMaterials_Presentations.Web.Properties;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.TextMaterials_Presentations.Web.Startup))]

namespace BulbaCourses.TextMaterials_Presentations.Web
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
        }
    }
}
