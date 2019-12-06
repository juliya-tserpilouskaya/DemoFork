using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/coursesITAcademy")]
    public class CourseITAcademyController : ApiController
    {
        private readonly ICourseITAcademyServices courseService;

        public CourseITAcademyController()
        {
            this.courseService = new CourseITAcademyServices();

        }

        public CourseITAcademyController(ICourseITAcademyServices courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet, Route("")]
        [Description("Get all courses")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses found", typeof(IEnumerable<CoursesITAcademy>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll()
        {
            var result = courseService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

    }
}
