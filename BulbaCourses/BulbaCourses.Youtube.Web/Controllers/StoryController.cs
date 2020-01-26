using BulbaCourses.Youtube.Logic.Models;
using BulbaCourses.Youtube.Logic.Models.SwaggerExamples.SearchStories;
using BulbaCourses.Youtube.Logic.Services;
using Microsoft.Web.Http;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Youtube.Web.Controllers
{
    /// <summary>
    /// Represents a RESTful SearchStory service.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/story")]
    [Authorize]
    public class StoryController : ApiController
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        /// <summary>
        /// Get all search story for user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet, Route("{userId}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchStory doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchStory found", typeof(SearchStory))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetStoryByUserID(string userId)
        {
            if (userId==null)
            {
                return BadRequest();
            }
            try
            {
                var request = await _storyService.GetStoriesByUserIdAsync(userId);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Save search story
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "SearchStory validation failed")]
        [SwaggerResponse(HttpStatusCode.OK, "Search story saved", typeof(SearchStory))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(SearchStoryExample))]
        public async Task<IHttpActionResult> SaveStoryAsync([FromBody] SearchStory story)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _storyService.SaveAsync(story);
                if (result == null) return BadRequest();

                return Ok(result);
            }
            catch (InvalidOperationException exc)
            {
                return InternalServerError(exc);
            }
        }

        /// <summary>
        /// Delete search story by storyId
        /// </summary>
        /// <param name="storyid"></param>
        /// <returns></returns>
        [HttpDelete, Route("bystoryid/{storyid}")]
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

        /// <summary>
        /// Delete all user search story by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete, Route("byuserid/{userId}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchStory doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchStory deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult DeleteByUserId(string userId)
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

        /// <summary>
        /// Hide user search story by storyId if user needs to delete story
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        [HttpPut, Route("hide/")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchStory doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchStory hided")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult HideByStoryId([FromBody]int? storyId)
        {
            if (storyId == null)
            {
                return BadRequest();
            }
            try
            {
                _storyService.HideStoryForUser(storyId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}