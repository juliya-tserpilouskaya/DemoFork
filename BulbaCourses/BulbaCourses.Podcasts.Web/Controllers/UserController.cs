using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using BulbaCourses.Video.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var user = mapper.Map<UserLogic, UserWeb>(userService.GetById(id));
                var result = userService.GetById(user.Id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<UserWeb>))]
        public IHttpActionResult GetAll()
        {
            var users = userService.GetAll();
            var result = mapper.Map<IEnumerable<UserLogic>, IEnumerable<UserWeb>>(users);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User post", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Create([FromBody]UserWeb user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var userlogic = mapper.Map<UserWeb, UserLogic>(user);
                userService.Add(userlogic);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Update([FromBody]UserWeb user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var userlogic = mapper.Map<UserWeb, UserLogic>(user);
                userService.Update(userlogic);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted", typeof(UserWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(UserWeb user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var userlogic = mapper.Map<UserWeb, UserLogic>(user);
                userService.Delete(userlogic);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
