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
        IRepository _repo;
        public VideoController(IRepository repository)
        {
            _repo = repository;
        }

        public VideoController()
        {
            _repo = new VideoRepository();
        }

        [HttpGet,Route("{id}")]
        public IHttpActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest();
            try
            {
                var resultVideo = _repo.GetById(id);
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
                var resultVideo = _repo.GetAll();
                return resultVideo == null ? NotFound() : (IHttpActionResult)Ok(resultVideo);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }


        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}