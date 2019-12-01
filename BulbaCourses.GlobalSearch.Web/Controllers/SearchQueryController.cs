using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Web.Models;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/queries")]
    public class SearchQueryController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var result = SearchQueryStorage.GetAll();
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
                var result = SearchQueryStorage.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")] 
        public IHttpActionResult Create([FromBody]SearchQuery query)
        {
            //validate here
            return Ok(SearchQueryStorage.Add(query));
        }

        [HttpDelete, Route("")]
        public IHttpActionResult ClearAll()
        {
            SearchQueryStorage.RemoveAll();
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult DeleteById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || SearchQueryStorage.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                SearchQueryStorage.RemoveById(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
