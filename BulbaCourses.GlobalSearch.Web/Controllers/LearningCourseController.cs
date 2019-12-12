using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Web.Models;
using BulbaCourses.GlobalSearch.Logic.Models;
using Swashbuckle.Swagger.Annotations;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{

    [RoutePrefix("api/courses")]
    public class LearningCourseController : ApiController
    {
        private readonly ILearningCourseService _learningCourseService;
        public LearningCourseController(ILearningCourseService learningCourseService)
        {
            _learningCourseService = learningCourseService;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid course id format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "The course is found", typeof(LearningCourse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex) 
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no courses found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses are found", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult GetAll()
        {
            var result = _learningCourseService.GetAllCourses();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("category/{domain}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid domain")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no courses in that category")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses are found", typeof(IEnumerable<LearningCourse>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult GetByCategory(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetByCategory(domain);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("author/{id:int}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid author id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no courses of author found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses of author are found", typeof(IEnumerable<LearningCourse>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult GetByAuthor(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetByAuthorId(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("{id}/items")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid course id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The course is not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Items of the course are found", typeof(IEnumerable<LearningCourseItem>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult GetItems(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetLearningItemsByCourseId(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("complexity/{level}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid complexity level parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses are not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses with complexity level are found", typeof(IEnumerable<LearningCourse>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult GetByComplexity(string level)
        {
            if (string.IsNullOrEmpty(level))
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetCourseByComplexity(level);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("language/{lang}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid language parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses are not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses in specified language are found", typeof(IEnumerable<LearningCourse>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult GetByLanguage(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetCourseByLanguage(lang);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("search/{query}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses are not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses are found", typeof(IEnumerable<LearningCourse>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest();
            }
            try
            {
                var result = _learningCourseService.GetCourseByQuery(query);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
