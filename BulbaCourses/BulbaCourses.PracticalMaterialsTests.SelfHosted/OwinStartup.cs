using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.PracticalMaterialsTests.SelfHosted.OwinStartup))]

namespace BulbaCourses.PracticalMaterialsTests.SelfHosted
{
public class OwinStartup
{
    public void Configuration(IAppBuilder app)
    {
        var httpConfiguration = new HttpConfiguration();

        httpConfiguration.MapHttpAttributeRoutes();

        // ---------- IdentityServer3

        var identityServerOptions = new IdentityServerOptions();

        var factory = new IdentityServerServiceFactory()
            .UseInMemoryClients(new[]
            {
                new Client
                {                    
                    ClientId = "client1",

                    ClientSecrets = new List<Secret>()
                    {   
                        new Secret("secret".Sha256())
                    },                    
                    
                    Flow = Flows.ResourceOwner,
                    
                    AllowAccessToAllScopes = true
                }
            })            
            .UseInMemoryScopes(StandardScopes.All)            
            .UseInMemoryUsers(new List<InMemoryUser>()
            {
                new InMemoryUser()
                {
                    Username = "user",

                    Password = "password",
                    
                    Subject = Guid.NewGuid().ToString()
                }
            });
        
        identityServerOptions.Factory = factory;
        
        identityServerOptions.IssuerUri = "My Security Server";
        
        identityServerOptions.RequireSsl = false;            
                    
        var path = 
            Path.Combine(
                new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath,
                "SelfHostedRertificate.pfx");
        
        var data = File.ReadAllBytes(path);
        
        identityServerOptions.SigningCertificate = new X509Certificate2(data, "123");

        // ---------- AppUse

        app.UseIdentityServer(identityServerOptions);

        app.UseWebApi(httpConfiguration);
    }
}
}

    


            
    
