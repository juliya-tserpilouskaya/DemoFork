using BulbaCourses.GlobalAdminUser.Logic.Models;
using BulbaCourses.GlobalAdminUser.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Web.Http;

namespace BulbaCourses.GlobalAdminUser.Web.Controllers
{

    [RoutePrefix("api/userprofiles")]
    public class UserProfileController : ApiController
    {
        private readonly IUserService _userService;

        public UserProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var result = _userService.GetAllAsync();
            return result == null? NotFound():(IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserDTO))]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id)||Guid.TryParse(id,out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = _userService.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.OK, "User created", typeof(UserDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public IHttpActionResult Create([FromBody]UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _userService.Add(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public IHttpActionResult Update([FromBody]UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _userService.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public IHttpActionResult Remove(UserDTO user)
        {
            //if (string.IsNullOrEmpty(user))
            //{
            //    return BadRequest();
            //}

            try
            {
                _userService.Delete(user);
                return (IHttpActionResult)Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}