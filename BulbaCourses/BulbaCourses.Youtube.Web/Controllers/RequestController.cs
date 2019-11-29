using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.Youtube.Web.Models;

namespace BulbaCourses.Youtube.Web.Controllers
{
    [RoutePrefix("api/requests")]
    public class RequestController : ApiController
    {
        //FakeRequestsRepository fakedb = new FakeRequestsRepository();
        private IRequestsRepository fakedb;
        public RequestController(IRequestsRepository repo)
        {
            fakedb = repo;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult GetRequests()
        {
            var requests = fakedb.GetAllRequests();
            return requests == null ? NotFound() : (IHttpActionResult)Ok(requests);
        }

        // GET api/<controller>/5
        [HttpGet, Route("{id})")]
        public IHttpActionResult GetRequest(string id)
        {
            //validate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))  // empty or text
            {
                return BadRequest();
            }
            try
            {
                var request = fakedb.GetRequestById(id);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]SearchRequest request)
        {
            if(!ModelState.IsValid)//пока нет валидации
            {
                return BadRequest();
            }
            try
            {
                fakedb.SaveRequest(request);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut, Route("{id})")]
        public IHttpActionResult Put(string id, [FromBody]SearchRequest request)
        {
            //validate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))  // empty or text
            {
                return BadRequest();
            }
            try
            {
                request.Id = id;
                fakedb.SaveRequest(request);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("{id})")]
        public IHttpActionResult Delete(string id)
        {
            //validate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))  // empty or text
            {
                return BadRequest();
            }
            try
            {
                var request = fakedb.GetRequestById(id);
                fakedb.DeleteRequest(id);
                return request == null ? NotFound() : (IHttpActionResult)Ok(request);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }
    }
}