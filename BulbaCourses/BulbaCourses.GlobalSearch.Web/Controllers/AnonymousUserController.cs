using BulbaCourses.GlobalSearch.Logic.Models;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/anonymous")]
    public class AnonymousUserController : ApiController
    {
        private readonly IAnonymousUserService _anonymousUserService;
        public AnonymousUserController(IAnonymousUserService anonymousUserService)
        {
            _anonymousUserService = anonymousUserService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no users in list")]
        [SwaggerResponse(HttpStatusCode.OK, "Users were found", typeof(AnonymousUser))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _anonymousUserService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User was found", typeof(AnonymousUser))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _anonymousUserService.GetByIdAsync(id);
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
            if (anonymousUser == null)
            {
                return BadRequest();
            }
            return Ok(_anonymousUserService.Add(anonymousUser));
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid ID")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public IHttpActionResult RemoveById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || _anonymousUserService.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                _anonymousUserService.RemoveById(id);
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
            _anonymousUserService.RemoveAll();
            return Ok();
        }
    }
}
