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
        private IRequestRepository fakedb;
        public RequestController(IRequestRepository repo)
        {
            fakedb = repo;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<SearchRequest> GetRequests()
        {
            var requests = fakedb.GetAllRequests();
            return requests == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet, Route("{id})")]
        public SearchRequest GetRequest(int id)
        {
            //validate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))  // empty or text
            {
                return BadRequest();
            }
            try
            {
                var request = fakedb.GetRequestById(id);
                return request == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]SearchRequest request)
        {
            if(!SearchRequest.IsValid)//пока нет валидации
            {
                return BadRequest();
            }
            try
            {
                fakedb.SaveRequest(request);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut, Route("{id})")]
        public void Put(int id, [FromBody]SearchRequest request)
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
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("{id})")]
        public void Delete(int id)
        {
            //validate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))  // empty or text
            {
                return BadRequest();
            }
            try
            {
                fakedb.DeleteRequest(id);
            }
            catch (InvalidOperationException ex) //server error
            {
                return InternalServerError(ex);
            }
        }
    }
}