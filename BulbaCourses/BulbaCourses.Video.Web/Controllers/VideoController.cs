using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    [RoutePrefix("api/courses/{courseId}/videos")]
    public class VideoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("{id}")]
        // GET api/<controller>/5
        public string GetVideoById(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}