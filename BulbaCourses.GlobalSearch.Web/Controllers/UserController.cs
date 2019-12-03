using BulbaCourses.GlobalSearch.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no users in list")]
        [SwaggerResponse(HttpStatusCode.OK, "Users were found", typeof(IEnumerable<RegisteredUser>))]
        public IHttpActionResult GetAll()
        {
            var result = RegisteredUserStorage.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User was found", typeof(RegisteredUser))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = RegisteredUserStorage.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "User added")]
        public IHttpActionResult Create([FromBody]RegisteredUser registeredUser)
        {
            //validate here
            return Ok(RegisteredUserStorage.Add(registeredUser));
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid ID")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public IHttpActionResult RemoveById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || RegisteredUserStorage.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                RegisteredUserStorage.RemoveById(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Users removed")]
        public IHttpActionResult ClearAll()
        {
            RegisteredUserStorage.RemoveAll();
            return Ok();
        }
    }
}
