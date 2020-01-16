using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.PracticalMaterialsTests.SelfHosted.OwinStartup))]

namespace BulbaCourses.PracticalMaterialsTests.SelfHosted
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}

    


            
    
