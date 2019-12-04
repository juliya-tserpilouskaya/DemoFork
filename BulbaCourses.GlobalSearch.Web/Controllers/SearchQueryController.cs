using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Web.Models;
using Swashbuckle.Swagger.Annotations;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/queries")]
    public class SearchQueryController : ApiController
    {
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no queries stored")]
        [SwaggerResponse(HttpStatusCode.OK, "Queries are found", typeof(IEnumerable<SearchQuery>))]
        public IHttpActionResult GetAll()
        {
            var result = SearchQueryStorage.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The query doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "The query is found", typeof(SearchQuery))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
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
        [SwaggerResponse(HttpStatusCode.OK, "The query is added")]
        public IHttpActionResult Create([FromBody]SearchQuery query)
        {
            //validate here
            return Ok(SearchQueryStorage.Add(query));
        }

        [HttpDelete, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "The queries are removed")]
        public IHttpActionResult ClearAll()
        {
            SearchQueryStorage.RemoveAll();
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The query doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "The query is deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
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
