using BulbaCourses.PracticalMaterialsTests.Logic.TestAPI;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.Web.Controllers
{
    public class TestAPIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult TesatMethod()
        {
            TestAPIClass dd = new TestAPIClass();

            string ss = dd.GetQuestionById(4);

            return Ok(ss);
        }
    }
}