using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using BulbaCourses.GlobalSearch.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/registeredusers")]
    public class RegisteredUserController : ApiController
    {
        private readonly IRegisteredUserService _registeredUserService;
        public RegisteredUserController(IRegisteredUserService registeredUserService)
        {
            _registeredUserService = registeredUserService;
        }
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no users in list")]
        [SwaggerResponse(HttpStatusCode.OK, "Users were found", typeof(IEnumerable<RegisteredUser>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _registeredUserService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User was found", typeof(RegisteredUser))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _registeredUserService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "User added")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater")]
        public async Task<IHttpActionResult> Create([FromBody]RegisteredUser registeredUser)
        {
            //validate here
            if (registeredUser == null)
            {
                return BadRequest();
            }
            return Ok(await _registeredUserService.AddAsync(registeredUser));
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid ID")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public async Task<IHttpActionResult> RemoveById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || _registeredUserService.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                await _registeredUserService.RemoveByIdAsync(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Users removed")]
        public async Task<IHttpActionResult> ClearAll()
        {
            await _registeredUserService.RemoveAllAsync();
            return Ok();
        }
    }
}
