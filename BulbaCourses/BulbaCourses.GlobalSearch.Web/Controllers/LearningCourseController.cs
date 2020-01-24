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
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Logic.DTO;
using System.Security.Claims;
using FluentValidation.WebApi;

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
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _learningCourseService.GetByIdAsync(id);
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
        public async Task<IHttpActionResult> GetAll()
        {
            if (User.Identity.IsAuthenticated)
                {
                    var sub = (User as ClaimsPrincipal).FindFirst("sub");

                }
            var result = await _learningCourseService.GetAllCoursesAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("category/{domain}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid domain")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no courses in that category")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses are found", typeof(IEnumerable<LearningCourse>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetByCategory(int domain)
        {
            //if (string.IsNullOrEmpty(domain))
            //{
            //    return BadRequest();
            //}
            try
            {
                var result = await _learningCourseService.GetByCategoryAsync(domain);
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
        public async Task<IHttpActionResult> GetByAuthor(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _learningCourseService.GetByAuthorIdAsync(id);
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
        public async Task<IHttpActionResult> GetItems(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            try
            {
                var result = await _learningCourseService.GetLearningItemsByCourseIdAsync(id);
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
        public async Task<IHttpActionResult> GetByComplexity(string level)
        {
            if (string.IsNullOrEmpty(level))
            {
                return BadRequest();
            }
            try
            {
                var result = await _learningCourseService.GetCourseByComplexityAsync(level);
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
        public async Task<IHttpActionResult> GetByLanguage(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                return BadRequest();
            }
            try
            {
                var result = await _learningCourseService.GetCourseByLanguageAsync(lang);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Update course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(LearningCourseDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "default,UpdateCourse")]LearningCourseDTO course)
        {

            if (course is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _learningCourseService.UpdateAsync(course);
                return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "The course is added")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator]LearningCourseDTO course)
        {
            if (course is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _learningCourseService.AddAsync(course);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course deleted", typeof(Boolean))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _learningCourseService.DeleteByIdAsync(id);
                return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
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
                //var result = _learningCourseService.GetCourseByQuery(query);
                //return result == null ? NotFound() : (IHttpActionResult)Ok(result);
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
