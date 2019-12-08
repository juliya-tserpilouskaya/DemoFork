using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Http;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Tests")]

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/manage")]
    public class ManageController : ApiController
    {
        private readonly IManageService _manageservice;
        internal ManageController(IManageService manageService)
        {
            _manageservice = manageService;
        }
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Found", typeof(Course))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                Course result = _manageservice.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Found", typeof(Course))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Create([FromBody]Course course)
        {
            try
            {
                Course result = _manageservice.Add(course);
                if (result.Equals(null))
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(course);
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Found", typeof(Course))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Update([FromBody]Course course)
        {
            try
            {
                Course result = _manageservice.Edit(course);
                if (result.Equals(null))
                {
                    return BadRequest();
                }
                else
                {
                    return result == null ? NotFound() : (IHttpActionResult)Ok(result);
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Found", typeof(Course))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                _manageservice.Delete(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}