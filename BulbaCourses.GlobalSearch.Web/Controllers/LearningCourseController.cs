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
        [HttpGet, Route("{id}")]
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
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var result = LearningCourseStorage.GetAllCourses();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("category/{domain}")]
        public IHttpActionResult GetByCategory(string domain)
        {
            var result = LearningCourseStorage.GetByCategory(domain);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("author/{id:int}")]
        public IHttpActionResult GetByAuthor(int id)
        {
            var result = LearningCourseStorage.GetByAuthorId(id);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}/items")]
        public IHttpActionResult GetItems(string id)
        {
            var result = LearningCourseStorage.GetLearningItemsByCourseId(id);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("complexity/{level}")]
        public IHttpActionResult GetByComplexity(string level)
        {
            var result = LearningCourseStorage.GetCourseByComplexity(level);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("language/{lang}")]
        public IHttpActionResult GetByLanguage(string lang)
        {
            var result = LearningCourseStorage.GetCourseByLanguage(lang);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

    }
}
