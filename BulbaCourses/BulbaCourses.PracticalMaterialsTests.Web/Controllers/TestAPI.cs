using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization;
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
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parametr format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't existing")]
        [SwaggerResponse(HttpStatusCode.OK, "Test found", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult TesatMethod()
        {
            IService_Test ServiceTest = new Service_Test();

            MTest_MainInfo Test_MainInfo = ServiceTest.GetTestById(1);            

            return Ok(Test_MainInfo.Name);
        }
    }
}