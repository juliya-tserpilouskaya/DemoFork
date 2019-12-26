using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using System.Linq;
using System.Threading.Tasks;
using BulbaCourses.Podcasts.Web.Models;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ICourseService courseService;
        private readonly IValidator<CourseWeb> validator;
        private readonly IBus bus;

        public CourseController(IMapper mapper, ICourseService courseService, IBus bus)
        {
            this.mapper = mapper;
            this.courseService = courseService;
            this.bus = bus;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var course = await courseService.GetById(id);
                var result = mapper.Map<CourseLogic, CourseWeb>(course));
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")] ///For Debug
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<CourseWeb>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var result = mapper.Map<IEnumerable<CourseLogic>, IEnumerable<CourseWeb>>(courses);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [Authorize]
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course post", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddCourse, default")]CourseWeb courseWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                var result = await courseService.AddCourse(courselogic);
                //await bus.SendAsync("Podcasts", course);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Put(string id, [FromBody, CustomizeValidator(RuleSet = "UpdateCourse, default")]CourseWeb courseWeb)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                var result = await courseService.Update(courselogic);

                return Ok(result);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course deleted", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete([FromBody, CustomizeValidator(RuleSet = "DeleteCourse, default")] CourseWeb courseWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
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
