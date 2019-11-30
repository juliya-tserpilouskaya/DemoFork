using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Web.Models;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class LearningCourseController : ApiController
    {
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))//для ненужных _
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex) 
            {
                return InternalServerError(ex);
            }
        }
    }
}
