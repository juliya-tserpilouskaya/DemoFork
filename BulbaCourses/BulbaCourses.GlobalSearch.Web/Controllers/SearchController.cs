using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using Swashbuckle.Swagger.Annotations;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {

        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses are found", typeof(IEnumerable<LearningCourse>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _searchService.SearchAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
    }
}