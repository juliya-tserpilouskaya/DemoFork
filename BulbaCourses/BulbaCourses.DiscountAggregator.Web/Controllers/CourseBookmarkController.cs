using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation.WebApi;
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

        /// <summary>
        /// Get bookmark by user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet, Route("{userId}")]
        [Description("Get Bookmark by UserId")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Bookmark doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Bookmark found", typeof(CourseBookmark))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _courseBookmarkService.GetByUserIdAsync(userId);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new bookmark
        /// </summary>
        /// <param name="courseBookmark"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [Description("Add new bookmark")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Bookmark added", typeof(IEnumerable<CourseBookmark>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Add([FromBody, CustomizeValidator(RuleSet = "*")]CourseBookmark courseBookmark)
        {
            if (courseBookmark == null)
            {
                return BadRequest();
            }

            var result = await _courseBookmarkService.AddAsync(courseBookmark);
            return result.IsSuccess ? (IHttpActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        /// <summary>
        /// Delete bookmark
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        [HttpDelete, Route("")]
        [Description("Delete bookmark")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Bookmark deleted", typeof(CourseBookmark))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(CourseBookmark bookmark)
        {
            if (bookmark == null)
            {
                return BadRequest();
            }

            var result = await _courseBookmarkService.DeleteAsync(bookmark);
            return result.IsSuccess ? (IHttpActionResult)Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
