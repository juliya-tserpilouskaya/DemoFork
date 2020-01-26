using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.SelfHosted.Controller
{
    [RoutePrefix("api/test")]
    public class SelfHostedController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult GetData()
        {
            return Ok("Test Self-Hosted done!");
        }
    }
}
