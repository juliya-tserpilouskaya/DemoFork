using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using BulbaCourses.PracticalMaterialsTests.Logic.Validators.Test;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTests.Web.Controllers
{
    // [Authorize]
    [RoutePrefix("api/WorkWithTest")]
    public class WorkWithTestController : ApiController
    {
        private readonly IService_Test _service_Test;

        private readonly IValidator<MTest_MainInfo> _validator;

        private readonly IBus _bus;        
        
        public WorkWithTestController(IService_Test service_Test, IValidator<MTest_MainInfo> validator, IBus bus)
        {
            _service_Test = service_Test;           

            _validator = validator;

            _bus = bus;
        }

        // ------------ CRUD

        [HttpGet, Route("GetTestById")]
        [SwaggerResponse(HttpStatusCode.OK, "Test found")]        
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetTestById(int TestId)
        {
            var Test_MainInfo = 
                _service_Test.GetByIdAsync(TestId);

            return
                Ok(Test_MainInfo.Result.Data);
        }

        [HttpPost, Route("addTest")]
        [SwaggerResponse(HttpStatusCode.OK, "Test added", typeof(MTest_MainInfo))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Test not added")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test doesn't existing")]        
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult AddNewTest([FromBody]MTest_MainInfo Test_MainInfo)
        {
            var result = _validator.Validate(Test_MainInfo);

            if (!result.IsValid)
            {
                return 
                    BadRequest(result.Errors.Select(_ => _.ErrorMessage).Aggregate((a,b) => $"{a} {b}"));
            }

            var Rez =
                _service_Test.Add("5012f850-9c59-4fd9-9e50-4d93ecac03fb", Test_MainInfo);

            return Ok(Rez.Data.Id);                     
        }

        [HttpPost, Route("updateTest")]
        [SwaggerResponse(HttpStatusCode.OK, "Test update", typeof(MTest_MainInfo))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Test not update")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test doesn't existing")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult UpdateTest([FromBody]MTest_MainInfo Test_MainInfo)
        {
            var result = _validator.Validate(Test_MainInfo);

            if (!result.IsValid)
            {
                return 
                    BadRequest(ModelState);
            }

            var Rez =
                _service_Test.Update("5012f850-9c59-4fd9-9e50-4d93ecac03fb", Test_MainInfo);

            return Ok(Test_MainInfo.Name);
        }

        [HttpDelete, Route("DeleteTestById")]
        [SwaggerResponse(HttpStatusCode.OK, "Test delete")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult DeleteTestById(int TestId)
        {
            var Test_MainInfo = _service_Test.DeleteById(TestId);

            return Ok(Test_MainInfo.Message);
        }

        // ------------ CheckTest

        [HttpGet, Route("ResultTestStructure")]
        [SwaggerResponse(HttpStatusCode.OK, "Test check")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult ResultTestStructure(int TestId)
        {
            MTest_MainInfo Test_MainInfo =
                _service_Test.GetById(TestId).Data;

            MReaderChoice_MainInfo ReaderChoice_MainInfo =
                new MReaderChoice_MainInfo()
                {
                    Test_MainInfo_Id = Test_MainInfo.Id,
                    ReaderChoices_ChoosingAnswerFromList = new List<MReaderChoice_ChoosingAnswerFromList>()
                };

            foreach (var x in Test_MainInfo.Questions_ChoosingAnswerFromList)
            {
                ReaderChoice_MainInfo.ReaderChoices_ChoosingAnswerFromList.Add(
                    new MReaderChoice_ChoosingAnswerFromList()
                    {
                        Question_ChoosingAnswerFromList_Id = x.Id
                    });
            }

            return
                Json(ReaderChoice_MainInfo);
        }

        [HttpPost, Route("CheckTest")]
        [SwaggerResponse(HttpStatusCode.OK, "Test check")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Test not found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult CheckTest([FromBody]MReaderChoice_MainInfo ReaderChoice_MainInf)
        {
            //var result = _validator.Validate(Test_MainInfo);

            //if (!result.IsValid)
            //{
            //    return
            //        BadRequest(result.Errors.Select(_ => _.ErrorMessage).Aggregate((a, b) => $"{a} {b}"));
            //}            

            var x = _service_Test.CheckTestAsync("5012f850-9c59-4fd9-9e50-4d93ecac03fb", ReaderChoice_MainInf).Data;

            return                
                Ok(_service_Test.CheckTestAsync("5012f850-9c59-4fd9-9e50-4d93ecac03fb", ReaderChoice_MainInf).Data);        
        }
    }
}