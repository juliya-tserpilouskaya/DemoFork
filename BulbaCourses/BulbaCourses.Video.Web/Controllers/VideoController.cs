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
    [RoutePrefix("api/courses/{courseId}/videos")]
    public class VideoController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IVideoService _videoService;

        public VideoController(IMapper mapper, IVideoService videoService)
        {
            _mapper = mapper;
            _videoService = videoService;
        }

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

        // GET api/<controller>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all videos", typeof(IEnumerable<VideoView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var videos = await _videoService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<VideoMaterialInfo>, IEnumerable<VideoView>>(videos);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        // POST api/<controller>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "video post", typeof(VideoView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Post([FromBody, CustomizeValidator(RuleSet = "AddVideo")]VideoView video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var videoInfo = _mapper.Map<VideoView, VideoMaterialInfo>(video);
            var result = await _videoService.AddAsync(videoInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        // PUT api/<controller>/5
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

        // DELETE api/<controller>/5
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
