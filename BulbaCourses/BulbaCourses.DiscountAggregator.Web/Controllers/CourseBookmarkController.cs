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
    [RoutePrefix("api/bookmark")]
    public class CourseBookmarkController : ApiController
    {
        private readonly ICourseBookmarkServices courseBookmarkService;

        //public CourseBookmarkController()
        //{
        //    courseBookmarkService = new CourseBookmarkServices();
        //}

        public CourseBookmarkController(ICourseBookmarkServices coursebookmarkService)
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
        [Description("Insert ")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Bookmarks added", typeof(IEnumerable<CourseBookmark>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Add([FromBody]CourseBookmark courseBookmark)
        {
            return Ok(courseBookmarkService.Add(courseBookmark));
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(courseBookmarkService.Delete(id));
        }

        //[HttpPost, Route("")]
        //public IHttpActionResult Update([FromBody]Book book)
        //{

        //}
    }
}
