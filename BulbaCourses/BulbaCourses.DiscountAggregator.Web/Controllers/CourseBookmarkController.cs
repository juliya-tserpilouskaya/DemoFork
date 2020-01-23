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

        [HttpGet, Route("{userId}")]//можно указать какой тип id
        [Description("Get Bookmark by UserId")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Bookmark doesn't exists")]
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
