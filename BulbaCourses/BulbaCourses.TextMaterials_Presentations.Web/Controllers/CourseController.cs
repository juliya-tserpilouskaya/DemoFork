using System;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;
using System.Threading.Tasks;
using FluentValidation.WebApi;
using EasyNetQ;
using Presentations.Logic.Models;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly ICoursesService _courseBase;
        private readonly IBus _bus;

        public CourseController(ICoursesService courseBase, IBus bus)
        {
            _courseBase = courseBase;
            _bus = bus;
        }

        /// <summary>
        /// Get all courses from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses found", typeof(IEnumerable<Course>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllCoursesAsync()
        {
            try
            {
                var result = await _courseBase.GetAllCoursesAsync();

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);

            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get course from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(Course))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetCourseByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _courseBase.GetCourseByIdAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new course to the database
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course added", typeof(Course))]
        public async Task<IHttpActionResult> CreateCourseAsync
            ([FromBody, CustomizeValidator]CourseAdd_DTO course)
        {
            if (course is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseBase.AddCourseAsync(course);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update the course in the database (Name)
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(Course))]
        public async Task<IHttpActionResult> UpdateCourseAsync
            ([FromBody, CustomizeValidator(RuleSet = "UpdateCourse, default")]Course course)
        {
            if (course is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseBase.UpdateCourseAsync(course);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete the course from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeleteCourseByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _courseBase.DeleteCourseByIdAsync(id);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Get all presentations from the course by course ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/presentations")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllPresentationsFromCourseAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _courseBase.GetAllPresentationsFromCourseAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
