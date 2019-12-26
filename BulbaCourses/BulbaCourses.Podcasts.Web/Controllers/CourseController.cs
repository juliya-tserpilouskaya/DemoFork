using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Video.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ICourseService courseService;

        public CourseController(IMapper mapper, ICourseService courseService)
        {
            this.mapper = mapper;
            this.courseService = courseService;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var course = mapper.Map<CourseLogic, CourseWeb>(courseService.GetById(id));
                var result = courseService.GetById(course.Id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")] ///For Debug
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<CourseWeb>))]
        public IHttpActionResult GetAll()
        {
            var courses = courseService.GetAll();
            var result = mapper.Map<IEnumerable<CourseLogic>, IEnumerable<CourseWeb>>(courses);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course post", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Post([FromBody]CourseWeb course)
        {
            if (course == null )
            {
                return BadRequest();
            }

            try
            {
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(course);
                courseService.AddCourse(courselogic);
                return Ok(course);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Put(string id, [FromBody]CourseWeb course)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            course.Id = id;

            if (course == null)
            {
                return BadRequest();
            }

            try
            {
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(course);
                courseService.Update(courselogic);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course deleted", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(CourseWeb course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            try
            {
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(course);
                courseService.Delete(courselogic);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
