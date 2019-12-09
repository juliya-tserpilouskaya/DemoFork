using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using Swashbuckle.Swagger.Annotations;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    public class CourseBookmarkController : ApiController
    {
        [RoutePrefix("api/bookmark")]
        public class CourseController : ApiController
        {
            private readonly ICourseBookmarkServices courseBookmarkService;

            public CourseController()
            {
                courseBookmarkService = new CourseBookmarkServices();
            }

            public CourseController(ICourseBookmarkServices coursebookmarkService)
            {
                courseBookmarkService = coursebookmarkService;
            }

            [HttpGet, Route("")]
            [Description("Get all bookmarks")]
            [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
            [SwaggerResponse(HttpStatusCode.NotFound, "Bookmarks doesn't exists")]
            [SwaggerResponse(HttpStatusCode.OK, "Bookmarks found", typeof(IEnumerable<CourseBookmark>))]
            [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
            public IHttpActionResult GetAll()
            {
                var result = courseBookmarkService.GetAll();
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }

            
            [HttpPut, Route("")]
            public IHttpActionResult Insert([FromBody]CourseBookmark courseBookmark)
            {
                // validate book here  //todo, обычно проводиться на стороне клиента
                //201 статус обычно и используют для Create, но там нужно описать, что он возвращает URL, по которому можно обратиться к книге
                return Ok(FakerCourseBookmarks.Add(courseBookmark));
            }

            //[HttpDelete, Route("{id}")]
            //public IHttpActionResult Delete(string id)
            //{
            //    return Ok(FakerCourseBookmarks.);
            //}


            //[HttpPost, Route("")]
            //public IHttpActionResult Update([FromBody]Book book)
            //{

            //}


        }
    }
}
