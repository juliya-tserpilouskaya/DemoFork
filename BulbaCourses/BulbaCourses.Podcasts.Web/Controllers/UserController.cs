using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IUserService service;
        private readonly IBus bus;

        public UserController(IMapper mapper, IUserService userService, IBus bus)
        {
            this.mapper = mapper;
            this.service = userService;
            this.bus = bus;
        }
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserWeb))]
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
                    var user = result.Data;
                    var userWeb = mapper.Map<UserLogic, UserWeb>(user);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(userWeb);
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

        [Authorize(Roles = "Admin")]
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<UserWeb>))]
        public async Task<IHttpActionResult> GetAll(string filter)
        {
            try
            {
                var result = await service.GetAllAsync(filter);
                if (result.IsSuccess == true)
                {
                    var userLogic = result.Data;
                    var userWeb = mapper.Map<IEnumerable<UserLogic>, IEnumerable<UserWeb>>(userLogic);
                    return userWeb == null ? NotFound() : (IHttpActionResult)Ok(userWeb);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User post", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddUser, default")]UserWeb userWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {   
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await service.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var userlogic = mapper.Map<UserWeb, UserLogic>(userWeb);
                    var result = await service.AddAsync(userlogic, userId);

                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Added User to {userWeb.Name} by {userId.Name}");
                        return Ok(userWeb);
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
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateUser, default")]UserWeb userWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await service.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var userLogic = mapper.Map<UserWeb, UserLogic>(userWeb);
                    var result = await service.UpdateAsync(userLogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(userLogic);
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
        [HttpDelete, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        public async Task<IHttpActionResult> Delete([FromBody, CustomizeValidator(RuleSet = "DeleteUser, default")] UserWeb userWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await service.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var userLogic = mapper.Map<UserWeb, UserLogic>(userWeb);
                    var result = service.DeleteAsync(userLogic, userId);
                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Deleted User {userWeb.Name} by {userId.Name}");
                        return Ok(userLogic);
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
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetMe()
        {
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await service.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userData = user.Data;

                    var audiologic = mapper.Map<UserLogic, UserWeb>(userData);
                    return Ok(userData);
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
    }
}
