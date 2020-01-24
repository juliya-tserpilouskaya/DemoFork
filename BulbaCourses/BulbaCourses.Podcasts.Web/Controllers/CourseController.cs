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
using System.Security.Claims;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ICourseService service;
        private readonly IUserService Uservice;
        private readonly IBus bus;

        public CourseController(IMapper mapper, ICourseService courseService, IBus bus, IUserService userService)
        {
            this.mapper = mapper;
            this.service = courseService;
            this.Uservice = userService;
            this.bus = bus;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Course found", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await service.GetByIdAsync(id);
                if (result.IsSuccess == true)
                {
                    var course = result.Data;
                    var courseWeb = mapper.Map<CourseLogic, CourseWeb>(course);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(courseWeb);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<CourseWeb>))]
        public async Task<IHttpActionResult> GetAll(string filter)
        {
            try
            {
                var result = await service.GetAllAsync(filter);
                if (result.IsSuccess == true)
                {
                    var courses = result.Data;
                    var coursesWeb = mapper.Map<IEnumerable<CourseLogic>, IEnumerable<CourseWeb>>(courses);
                    return coursesWeb == null ? NotFound() : (IHttpActionResult)Ok(coursesWeb);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
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
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                    var result = await service.AddAsync(courselogic, userId);
                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Added Course {courseWeb.Name} by {userId.Name}");
                        return Ok(courselogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Course updated", typeof(CourseWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateCourse, default")]CourseWeb courseWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                    var result = await service.UpdateAsync(courselogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(courselogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }


               
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
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete([FromBody, CustomizeValidator(RuleSet = "DeleteCourse, default")] CourseWeb courseWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                    var result = service.DeleteAsync(courselogic, userId);
                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Deleted Course {courseWeb.Name} by {userId.Name}");
                        return Ok(courselogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
