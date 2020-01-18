using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using EasyNetQ;
using Ninject;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.Web.Controllers
{
    // [Authorize]
    [RoutePrefix("api/tests")]
    public class TestAPIController : ApiController
    {
        private readonly IService_Test _service_Test;

        private readonly IBus _bus;

        public TestAPIController(IService_Test service_Test, IBus bus)
        {
            _service_Test = service_Test;

            _bus = bus;
        }

        public IHttpActionResult TestMethod()
        {
            var Test_MainInfo = _service_Test.GetById(1);

            return Ok(Test_MainInfo.Data.Name);
        }
    }
}