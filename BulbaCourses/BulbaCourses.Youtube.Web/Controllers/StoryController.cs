using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.Youtube.Web.Controllers
{
    [RoutePrefix("api/story")]
    public class StoryController : ApiController
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet, Route("{userId})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchStory doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchStory found", typeof(SearchStoryDb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetStoryByUserID(int? userId)
        {
            if (userId==null)
            {
                return BadRequest();
            }
            try
            {
                var request = _storyService.GetStoriesByUserId(userId);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{storyid})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid input format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchStory doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchStory deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult DeleteByStoryId(int? storyid)
        {
            if (storyid == null)
            {
                return BadRequest();
            }
            try
            {
                _storyService.DeleteByStoryId(storyid);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{userId})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchStory doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchStory deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult DeleteByUserId(int? userId)
        {
            if (userId==null)
            {
                return BadRequest();
            }
            try
            {
                _storyService.DeleteByUserId(userId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}