using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using IdentityServer3.Core.Models;

namespace BulbaCourses.Web.Security
{
    public static class SecurityConfig
    {
        public static IEnumerable<Client> LoadClients()
        {
            var testClient = new Client()
            {
                AllowAccessToAllScopes = true,
                AllowAccessTokensViaBrowser = true,
                ClientId = "external_test",
                ClientSecrets = new List<Secret>() { new Secret("secret".Sha256()) },
                Flow = Flows.ResourceOwner,
                AlwaysSendClientClaims = true
            };

            var angularClient = new Client()
            {
                AllowAccessToAllScopes = true,
                AllowAccessTokensViaBrowser = true,
                ClientId = "external_app",
                Flow = Flows.Implicit,
                RedirectUris = new List<string>()
                {
                    "http://localhost/test/data"    
                }
            };

            return new List<Client>() { testClient, angularClient };
        }

        public static IEnumerable<Scope> LoadScopes()
        {
            return new List<Scope>(StandardScopes.All.Append(new Scope()
            {
                Name = "api",
                DisplayName = "API access scope",
                Type = ScopeType.Resource
            }));
        }
    }
}