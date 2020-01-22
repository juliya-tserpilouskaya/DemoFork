using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.Enums;
using BulbaCourses.Video.Web.Models;
using BulbaCourses.Video.Web.SwaggerModels;
using EasyNetQ;
using FluentValidation.WebApi;
using Newtonsoft.Json;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        private IBus _bus;

        public CourseController(IMapper mapper, ICourseService courseService, IBus bus)
        {
            _mapper = mapper;
            _courseService = courseService;
            _bus = bus;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(SwaggerCourseView))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Get(string id)
        {
            var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null)
            {
                userId = "guest";
            }

            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            await _bus.SendAsync("VideoQ", id);
            await _bus.SendAsync("VideoQ", JsonConvert.SerializeObject(userId));

            try
            {
                var result = await _courseService.GetCourseByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(SwaggerCourseView))]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<CourseView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null)
            {
                userId = "guest";
            }

            await _bus.SendAsync("VideoQ", JsonConvert.SerializeObject(userId));

            var courses = await _courseService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CourseInfo>, IEnumerable<CourseView>>(courses);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(SwaggerCourseView))]
        [SwaggerRequestExample(typeof(CourseViewInput), typeof(SwaggerCourseViewInput))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course post", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [Authorize]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator (RuleSet = "AddCourse")]CourseView course)
        {
            var user = this.User as ClaimsPrincipal;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseInfo = _mapper.Map<CourseView, CourseInfo>(course);
            var result = await _courseService.AddCourseAsync(courseInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpPut, Route("{id}")]

        [SwaggerRequestExample(typeof(CourseViewInput), typeof(SwaggerCourseViewInput))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(CourseView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateCourse")]CourseView course)
        {
            if (course == null || !Enum.IsDefined(typeof(CourseLevel), course.Level))
            {
                return BadRequest();
            }

            var courseInfo = _mapper.Map<CourseView, CourseInfo>(course);
            var result = await _courseService.UpdateAsync(courseInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
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
                await _courseService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
