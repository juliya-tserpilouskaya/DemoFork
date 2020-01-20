using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Youtube.SelfHosted.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult GetData()
        {
            return Ok("Test SelfHosted done!");
        }
    }
}
