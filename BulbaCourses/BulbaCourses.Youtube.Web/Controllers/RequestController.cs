using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Services;
using Swashbuckle.Swagger.Annotations;

namespace BulbaCourses.Youtube.Web.Controllers
{/*
    [RoutePrefix("api/requests")]
    public class RequestController : ApiController
    {        
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET api/<controller>        
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchRequests list not found")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchRequests list found", typeof(IEnumerable<SearchRequestDb>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetRequests()
        {
            try
            {
                var requests = _requestService.GetAllRequests();
                return requests == null ? NotFound() : (IHttpActionResult)Ok(requests);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }           
        }

        [HttpGet, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchRequest doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchRequest found", typeof(SearchRequestDb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetRequestById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var request = _requestService.GetRequestById(id);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid input format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchRequest not created")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchRequest created", typeof(SearchRequestDb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Post([FromBody]SearchRequestDb request)
        {
            if(!ModelState.IsValid)//пока нет валидации
            {
                return BadRequest();
            }
            try
            {
                var savedRequest = _requestService.SaveRequest(request);
                return savedRequest == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid input format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchRequest not updated")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchRequest updated", typeof(SearchRequestDb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Put(string id, [FromBody]SearchRequestDb request)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))  // empty or text
            {
                return BadRequest();
            }
            try
            {
                var selectedRequest = _requestService.GetRequestById(id);
                if (selectedRequest == null)
                    return NotFound();

                var result = _requestService.SaveRequest(request);
                return result == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid input format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "SearchRequest not deleted")]
        [SwaggerResponse(HttpStatusCode.OK, "SearchRequest deleted", typeof(SearchRequestDb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var selectedRequest = _requestService.GetRequestById(id);
                if (selectedRequest == null)
                    return NotFound();

                var result = _requestService.DeleteRequest(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
    */
}