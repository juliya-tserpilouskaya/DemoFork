using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Web.Models;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AuthorController(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Author doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Author found", typeof(AuthorView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _authorService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all authors", typeof(IEnumerable<AuthorView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<AuthorInfo>, IEnumerable<AuthorView>>(authors);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("courses")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all author courses", typeof(AuthorView))]
        public IHttpActionResult GetAllAuthorCourses(AuthorView author)
        {
            var authorInfo = _mapper.Map<AuthorView, AuthorInfo>(author);
            var courses = _authorService.GetAllCourses(authorInfo);
            var result = _mapper.Map<IEnumerable<CourseInfo>, IEnumerable<CourseView>>(courses);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Author post", typeof(AuthorView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator]AuthorView author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorInfo = _mapper.Map<AuthorView, AuthorInfo>(author);
            var result = await _authorService.AddAsync(authorInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Author updated", typeof(AuthorView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator]AuthorView author)
        {
            var authorInfo = _mapper.Map<AuthorView, AuthorInfo>(author);
            var result = await _authorService.UpdateAsync(authorInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Author deleted", typeof(AuthorView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                await _authorService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
