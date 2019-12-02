using BulbaCourses.GlobalSearch.Web.Models;
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
        public IHttpActionResult GetAll()
        {
            var result = UserStorage.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = UserStorage.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody]RegisteredUser registeredUser)
        {
            //validate here
            return Ok(UserStorage.Add(registeredUser));
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult RemoveById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || UserStorage.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                UserStorage.RemoveById(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("")]
        public IHttpActionResult ClearAll()
        {
            UserStorage.RemoveAll();
            return Ok();
        }
    }
}
