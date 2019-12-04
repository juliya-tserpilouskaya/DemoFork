//using BulbaCourse.Video.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourse.Video.Controllers
{
    [RoutePrefix("api/video")]
    public class VideoController : ApiController
    {
        [HttpGet, Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost, Route("")]
        //public IHttpActionResult Post(string courseId, [FromBody]Models.VideoItem videoItem)
        //{
        //    videoItem.VideoId = Guid.NewGuid().ToString();
        //    videoItem.Created = DateTime.Now;

        //    if (string.IsNullOrEmpty(courseId) || !Guid.TryParse(courseId, out var _))
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(Repositories.CoursesRep.AddVideo(courseId, videoItem));
        //}

        // PUT api/<controller>/5
        //public void Put(string courseId, [FromUri]string videoId, [FromBody]VideoItem videoItem)
        //{
        //}

        // DELETE api/<controller>/5
        public void Delete(string courseId, string videoId)
        {
        }
    }
}