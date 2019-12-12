using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Web.Enums;
using BulbaCourses.Video.Web.Models;
//using BulbaCourses.Video.Web.SwaggerModels;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
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
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var course = mapper.Map<CourseInfo, CourseView>(courseService.GetCourseById(id));
                var result = courseService.GetCourseById(course.CourseId);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<CourseView>))]
        public IHttpActionResult GetAll()
        {
            var courses = courseService.GetAll();
            var result = mapper.Map<IEnumerable<CourseInfo>, IEnumerable<CourseView>>(courses);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }


        [HttpPost, Route("")]
        [SwaggerRequestExample(typeof(CourseView), typeof(SwaggerCourseView))]
        [SwaggerRequestExample(typeof(CourseViewInput), typeof(SwaggerCourseViewInput))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course post", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
       
        public IHttpActionResult Post([FromBody]CourseViewInput courseInput)
        {
            if (courseInput == null || !Enum.IsDefined(typeof(CourseLevel), courseInput.Level))
            {
                return BadRequest();
            }
            var course = new CourseView
            {
                CourseId = Guid.NewGuid().ToString(),
                Name = courseInput.Name,
                Description = courseInput.Description,
                Level = courseInput.Level
            };

            try
            {
                var courseInfo = mapper.Map<CourseView, CourseInfo>(course);
                courseService.AddCourse(courseInfo);
                return Ok(course);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        [SwaggerRequestExample(typeof(CourseView), typeof(SwaggerCourseView))]
        [SwaggerRequestExample(typeof(CourseViewInput), typeof(SwaggerCourseViewInput))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Put(string id, [FromBody]CourseView course)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            course.CourseId = id;

            if (course == null || !Enum.IsDefined(typeof(CourseLevel), course.Level))
            {
                return BadRequest();
            }

            try
            {
                var courseInfo = mapper.Map<CourseView, CourseInfo>(course);
                courseService.Update(courseInfo);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course deleted", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                courseService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
