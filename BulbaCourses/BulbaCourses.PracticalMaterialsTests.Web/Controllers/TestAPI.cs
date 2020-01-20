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
    [RoutePrefix("api/Tests")]
    public class TestAPIController : ApiController
    {
        private readonly IService_Test _service_Test;

        private readonly IBus _bus;

        Validator_Test_MainInfo VTest_MainInfo = new Validator_Test_MainInfo();

        public TestAPIController(IService_Test service_Test, IBus bus)
        {
            _service_Test = service_Test;

            _bus = bus;
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Error")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not find")]
        [SwaggerResponse(HttpStatusCode.OK, "Test find", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult TestMethod()
        {
            var Test_MainInfo = _service_Test.GetById(1);

            return Ok(Test_MainInfo.Data.Name);
        }

        [HttpGet, Route("")]
        public IHttpActionResult TestMethod_2()
        {
            return Ok("jjjj");
        }

        [HttpPost, Route("add")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Test not added")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't existing")]
        [SwaggerResponse(HttpStatusCode.OK, "Test added", typeof(MTest_MainInfo))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult AddNewTest([FromBody, CustomizeValidator(RuleSet = "Insert_New_Test_MainInfo")]MTest_MainInfo Test_MainInfo)
        {
            var Rez = _service_Test.Add(Test_MainInfo);

            var VResult = VTest_MainInfo.Validate(Test_MainInfo);

            string ErrorMessage = "";

            if (!VResult.IsValid)
            {
                foreach (var fail in VResult.Errors)
                {
                    ErrorMessage = $"{fail.PropertyName} : {fail.ErrorMessage}";
                }
                return BadRequest(ErrorMessage);
            }
            else
            {
                return Ok(Rez.Message);
            }
        }

        [HttpDelete, Route("{Id}")]
        public IHttpActionResult DeleteTestById(int Id)
        {
            var Test_MainInfo = _service_Test.DeleteById(Id);

            return Ok(Test_MainInfo.Message);
        }
    }
}