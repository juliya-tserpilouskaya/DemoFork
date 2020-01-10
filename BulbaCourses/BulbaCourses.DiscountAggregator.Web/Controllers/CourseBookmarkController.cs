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
        private readonly ICourseBookmarkServices _courseBookmarkService;

        public CourseBookmarkController(ICourseBookmarkServices coursebookmarkService)
        {
            _courseBookmarkService = coursebookmarkService;
        }

        [HttpGet, Route("")]
        [Description("Get all bookmarks")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Bookmarks doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Bookmarks found", typeof(IEnumerable<CourseBookmark>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll()
        {
            var result = _courseBookmarkService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

            
        [HttpPut, Route("")]
        [Description("Add new bookmark")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Bookmark added", typeof(IEnumerable<CourseBookmark>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Add([FromBody]CourseBookmark courseBookmark)
        {
            if (courseBookmark == null)
            {
                return BadRequest();
            }

            try
            {
                courseBookmark.Id = Guid.NewGuid().ToString();
                _courseBookmarkService.Add(courseBookmark);
                return Ok(courseBookmark);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult DeleteById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                _courseBookmarkService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
