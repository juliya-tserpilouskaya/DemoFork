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
    [RoutePrefix("api/anonymous")]
    public class AnonymousUserController : ApiController
    {
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no users in list")]
        [SwaggerResponse(HttpStatusCode.OK, "Users were found", typeof(IEnumerable<AnonymousUser>))]
        public IHttpActionResult GetAll()
        {
            var result = AnonymousUserStorage.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User was found", typeof(AnonymousUser))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = AnonymousUserStorage.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "User added")]
        public IHttpActionResult Create([FromBody]AnonymousUser anonymousUser)
        {
            //validate here
            return Ok(AnonymousUserStorage.Add(anonymousUser));
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid ID")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public IHttpActionResult RemoveById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || AnonymousUserStorage.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                AnonymousUserStorage.RemoveById(id);
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
            AnonymousUserStorage.RemoveAll();
            return Ok();
        }
    }
}
