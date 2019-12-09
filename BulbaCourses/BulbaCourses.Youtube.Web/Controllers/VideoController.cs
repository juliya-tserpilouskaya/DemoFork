using BulbaCourses.Youtube.Web.Logic.Services;
using BulbaCourses.Youtube.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace BulbaCourses.Youtube.Web.Controllers
{
    [RoutePrefix("api/videos")]
    public class VideoController : ApiController
    {
        IVideoService _videoService;
        public VideoController(IVideoService repository)
        {
            _videoService = repository;
        }

        public VideoController()
        {
            _videoService = new VideoService();
        }

        [HttpGet,Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Video found", typeof(Video))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest();
            try
            {
                var resultVideo = _videoService.GetById(id);
                return resultVideo == null ? NotFound() : (IHttpActionResult)Ok(resultVideo);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet,Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Video found", typeof(Video))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var resultVideo = _videoService.GetAll();
                return resultVideo == null ? NotFound() : (IHttpActionResult)Ok(resultVideo);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Video found", typeof(List<string>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult SearchVideo(string searchTerm)
        {
            try
            {
                var resultVideo = _videoService.GetSearchListResponse(searchTerm);
                return resultVideo == null ? NotFound() : (IHttpActionResult)Ok(resultVideo);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}