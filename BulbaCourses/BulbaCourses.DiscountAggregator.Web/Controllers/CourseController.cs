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
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly ICourseServices courseService;

        //public CourseController()
        //{
        //    this.courseService = new CourseServices();

        //}

        public CourseController(ICourseServices courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet, Route("")]
        [Description("Get all courses")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses found", typeof(IEnumerable<Course>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll()
        {
            var result = courseService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]//можно указать какой тип id
        [Description("Get course by Id")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(Course))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string id)
        {
            //valideate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = courseService.GetById(id); //Courseware.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        //примеры для дальнейшего использования
        //[HttpPost, Route("")]
        //public IHttpActionResult Create([FromBody]Book book)
        //{
        //    // validate book here  //todo, обычно проводиться на стороне клиента
        //    //201 статус обычно и используют для Create, но там нужно описать, что он возвращает URL, по которому можно обратиться к книге
        //    return Ok(BookStorage.Add(book));
        //}

        //[HttpPut, Route("")]
        //public IHttpActionResult Update([FromBody]Book book)
        //{

        //}

        //[HttpDelete, Route("{id}")]
        //public IHttpActionResult Delete(string id)
        //{

        //}


    }
}
