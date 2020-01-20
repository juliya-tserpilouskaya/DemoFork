using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
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
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no users in list")]
        [SwaggerResponse(HttpStatusCode.OK, "Users were found", typeof(IEnumerable<UserDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User was found", typeof(UserDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _userService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("{id}/bookmarks")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User is not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Users bookmarks are found", typeof(IEnumerable<BookmarkDTO>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetBookmarks(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _userService.GetBookmarksByUserIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("{id}/search_queries")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User is not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Users search queries are found", typeof(IEnumerable<SearchQueryDTO>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetSearchQueries(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _userService.GetSearchQueriesByUserIdAsync(id);
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
        public IHttpActionResult Create([FromBody]UserDTO user)
        {
            //validate here
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_userService.Add(user));
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid ID")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something goes wrong")]
        public IHttpActionResult RemoveById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || _userService.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                _userService.RemoveById(id);
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
            _userService.RemoveAll();
            return Ok();
        }
    }
}
