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
    /// <summary>
    /// Represents a RESTful User service.
    /// </summary>
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IUserService service;
        private readonly IBus bus;

        /// <summary>
        /// Creates Audio controller.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="mapper"></param>
        /// <param name="userService"></param>
        public UserController(IMapper mapper, IUserService userService, IBus bus)
        {
            this.mapper = mapper;
            this.service = userService;
            this.bus = bus;
        }

        /// <summary>
        /// Gets user from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet, Route("Get/{id}")]
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


        /// <summary>
        /// Get all users from the database that have substring in name
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet, Route("Search/{substring}")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all users", typeof(IEnumerable<UserWeb>))]
        public async Task<IHttpActionResult> Search(string substring)
        {
            try
            {
                var result = await service.SearchAsync(substring);
                if (result.IsSuccess == true)
                {
                    var users = result.Data;
                    var usersWeb = mapper.Map<IEnumerable<UserLogic>, IEnumerable<UserWeb>>(users);
                    return usersWeb == null ? NotFound() : (IHttpActionResult)Ok(usersWeb);
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

        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("GetFor/{name}")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<UserWeb>))]
        public async Task<IHttpActionResult> GetAll(string name)
        {
            try
            {
                var result = await service.GetAllAsync(name);
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

        /// <summary>
        /// Adds user to the database
        /// </summary>
        /// <param name="userWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Create")]
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

        /// <summary>
        /// Updates user in the database
        /// </summary>
        /// <param name="userWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut, Route("Update")]
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

        /// <summary>
        /// Deletes user in the database
        /// </summary>
        /// <param name="userWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete, Route("Delete")]
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

        /// <summary>
        /// Gets current user from the database
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("GetMe")]
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
