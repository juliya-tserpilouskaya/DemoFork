using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.Youtube.Web.Models;

namespace BulbaCourses.Youtube.Web.Controllers
{
    public class RequestController : ApiController
    {
        FakeRequestsRepository fakedb = new FakeRequestsRepository();
        
        // GET api/<controller>
        public IEnumerable<SearchRequest> GetRequests()
        {
            return fakedb.SearchRequests;
        }

        // GET api/<controller>/5
        public SearchRequest GetRequest(int id)
        {
            return fakedb.GetRequestById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}