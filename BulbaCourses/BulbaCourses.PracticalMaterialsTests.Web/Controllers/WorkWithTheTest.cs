using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using BulbaCourses.PracticalMaterialsTests.Logic.Validators.Test;
using EasyNetQ;
using FluentValidation.WebApi;
using Ninject;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.Web.Controllers
{
    // [Authorize]
    [RoutePrefix("api/WorkWithTheTest")]
    public class WorkWithTheTestController : ApiController
    {
        private readonly IService_Test _service_Test;

        private readonly IBus _bus;

        Validator_Test_MainInfo VTest_MainInfo = new Validator_Test_MainInfo();

        public WorkWithTheTestController(IService_Test service_Test, IBus bus)
        {
            _service_Test = service_Test;

            _bus = bus;
        }

        [HttpGet, Route("getTestById")]
        [SwaggerResponse(HttpStatusCode.OK, "Test found")]        
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetTestById(int TestId)
        {
            var Test_MainInfo = _service_Test.GetById(TestId);

            return Ok(Test_MainInfo.Data);
        }

        [HttpPost, Route("addTest")]
        [SwaggerResponse(HttpStatusCode.OK, "Test added", typeof(MTest_MainInfo))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Test not added")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test doesn't existing")]        
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult AddNewTest([FromBody]MTest_MainInfo Test_MainInfo)
        {
            var Rez = 
                _service_Test.Add("5012f850-9c59-4fd9-9e50-4d93ecac03fb", Test_MainInfo);

            return Ok(Test_MainInfo.Name);            
        }

        [HttpPost, Route("updateTest")]
        [SwaggerResponse(HttpStatusCode.OK, "Test update", typeof(MTest_MainInfo))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Test not update")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test doesn't existing")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult UpdateTest([FromBody]MTest_MainInfo Test_MainInfo)
        {
            var Rez =
                _service_Test.Update("5012f850-9c59-4fd9-9e50-4d93ecac03fb", Test_MainInfo);

            return Ok(Test_MainInfo.Name);
        }

        [HttpDelete, Route("{Id}")]
        [SwaggerResponse(HttpStatusCode.OK, "Test delete")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult DeleteTestById(int TestId)
        {
            var Test_MainInfo = _service_Test.DeleteById(TestId);

            return Ok(Test_MainInfo.Message);
        }
    }
}