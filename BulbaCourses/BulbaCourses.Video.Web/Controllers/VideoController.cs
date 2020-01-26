using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Web.Models;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    /// <summary>
    /// Represents a RESTful Videos service.
    /// </summary>
    [RoutePrefix("api/courses/{courseId}/videos")]
    public class VideoController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IVideoService _videoService;

        /// <summary>
        /// Creates Videos controller.
        /// </summary>
        /// <param name="videoService"></param>
        /// <param name="mapper"></param>
        public VideoController(IMapper mapper, IVideoService videoService)
        {
            _mapper = mapper;
            _videoService = videoService;
        }

        /// <summary>
        /// Shows a video details by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        // GET api/<controller>/5
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Video found", typeof(VideoMaterialInfo))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetVideoById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var video = await _videoService.GetByIdAsync(id);
                return video == null ? NotFound() : (IHttpActionResult)Ok(video);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets all videos from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all videos", typeof(IEnumerable<VideoView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var videos = await _videoService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<VideoMaterialInfo>, IEnumerable<VideoView>>(videos);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Add new video to the database.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "video post", typeof(VideoView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Post(string courseId ,[FromBody, CustomizeValidator(RuleSet = "AddVideo")]VideoView video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var videoInfo = _mapper.Map<VideoView, VideoMaterialInfo>(video);
            var result = await _videoService.AddAsync(videoInfo, courseId);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update video in the database.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Video updated", typeof(VideoView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Put(string id, [FromBody, CustomizeValidator(RuleSet = "UpdateVideo")]VideoView video)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var videoInfo = _mapper.Map<VideoView, VideoMaterialInfo>(video);
            var result = await _videoService.UpdateAsync(videoInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete video by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Video deleted", typeof(VideoView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                await _videoService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
