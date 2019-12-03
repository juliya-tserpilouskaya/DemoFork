using BulbaCourses.Youtube.Web.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
      
    }
}