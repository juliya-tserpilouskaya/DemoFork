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

        /// <summary>
        /// Get indexed courses
        /// </summary>
        /// <returns>Indexed courses</returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Indexed courses not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Indexed courses are found", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult GetAllIndexed()
        {
            var result = _searchService.GetIndexedCourses();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Add course to search index
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns>Indexed courses</returns>
        [HttpPost, Route("index")]
        [SwaggerResponse(HttpStatusCode.OK, "Course successfully indexed", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult IndexCourse([FromBody]LearningCourseDTO course)
        {
            var result = _searchService.IndexCourse(course);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get courses by search query
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>Finded courses</returns>
        [HttpGet, Route("{query}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Courses not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses are found", typeof(IEnumerable<LearningCourse>))]
        public IHttpActionResult SearchByString(string query)
        {
            var result = _searchService.Search(query);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get courses by search query model
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Finded courses</returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "The query succeeded")]
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