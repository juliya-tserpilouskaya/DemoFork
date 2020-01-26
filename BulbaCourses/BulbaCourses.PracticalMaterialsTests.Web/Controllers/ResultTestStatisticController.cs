using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.Web.Controllers
{
    [RoutePrefix("api/ResultTestStatistic")]
    public class ResultTestStatisticController : ApiController
    {
        public ResultTestStatisticController()
        {
            
        }

        [HttpGet, Route("GetTestById")]
        [SwaggerResponse(HttpStatusCode.OK, "Test found")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetTestById(int TestId)
        {           

            return Ok("dddd");
        }
    }
}