using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using Swashbuckle.Swagger.Annotations;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {

        private readonly ISearchService _searchService;
        private readonly ISearchQueryService _searchQueryService;

        public SearchController(ISearchService searchService, ISearchQueryService searchQueryService)
        {
            _searchService = searchService;
            _searchQueryService = searchQueryService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Indexed courses not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Indexed courses are found", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult GetAllIndexed()
        {
            var result = _searchService.GetIndexedCourses();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("index")]
        [SwaggerResponse(HttpStatusCode.OK, "Course successfully indexed", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult IndexCourse([FromBody]LearningCourseDTO course)
        {
            var result = _searchService.IndexCourse(course);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{query}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "courses not found")]
        [SwaggerResponse(HttpStatusCode.OK, "courses are found", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult SearchByString(string query)
        {
            var result = _searchService.Search(query);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "The query is added")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query data")]
        public IHttpActionResult SearchByQuery([FromBody]SearchQueryDTO query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _searchQueryService.Add(query);
            var result = _searchService.Search(query.Query);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
    }
}