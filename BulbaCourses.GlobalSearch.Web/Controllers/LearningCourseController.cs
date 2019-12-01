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
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
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
            if (string.IsNullOrEmpty(domain))
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetByCategory(domain);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("author/{id:int}")]
        public IHttpActionResult GetByAuthor(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetByAuthorId(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("{id}/items")]
        public IHttpActionResult GetItems(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetLearningItemsByCourseId(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("complexity/{level}")]
        public IHttpActionResult GetByComplexity(string level)
        {
            if (string.IsNullOrEmpty(level))
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetCourseByComplexity(level);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("language/{lang}")]
        public IHttpActionResult GetByLanguage(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetCourseByLanguage(lang);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("search/{query}")]
        public IHttpActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest();
            }
            try
            {
                var result = LearningCourseStorage.GetCourseByQuery(query);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
