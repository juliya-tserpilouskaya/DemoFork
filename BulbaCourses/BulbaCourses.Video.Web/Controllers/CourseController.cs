using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Web.Enums;
using BulbaCourses.Video.Web.Models.CourseViews;
using BulbaCourses.Video.Web.SwaggerModels;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        [SwaggerRequestExample(typeof(CourseInfo), typeof(SwaggerCourseInfo))]
        
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(CourseInfo))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await courseService.GetCourseByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        //[SwaggerRequestExample(typeof(CourseView), typeof(SwaggerCourseView))]
        
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<CourseView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAllAsync();
            var result = mapper.Map<IEnumerable<CourseInfo>, IEnumerable<CourseView>>(courses);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }


        [HttpPost, Route("")]
        //[SwaggerRequestExample(typeof(CourseView), typeof(SwaggerCourseView))]
        //[SwaggerRequestExample(typeof(CourseViewInput), typeof(SwaggerCourseViewInput))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course post", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Post([FromBody]CourseViewInput courseInput)
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
                Level = courseInput.Level,
                Price = courseInput.Price
            };

            try
            {
                var courseInfo = mapper.Map<CourseView, CourseInfo>(course);
                await courseService.AddCourseAsync(courseInfo);
                return Ok(courseInfo);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        
        //[SwaggerRequestExample(typeof(CourseViewInput), typeof(SwaggerCourseViewInput))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Put(string id, [FromBody]CourseViewInput courseInput)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var course = new CourseView()
            {
                CourseId = id,
                Name = courseInput.Name,
                Description = courseInput.Description
            };

            if (course == null || !Enum.IsDefined(typeof(CourseLevel), course.Level))
            {
                return BadRequest();
            }

            try
            {
                var courseInfo = mapper.Map<CourseView, CourseInfo>(course);
                await courseService.UpdateAsync(courseInfo);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                await courseService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
