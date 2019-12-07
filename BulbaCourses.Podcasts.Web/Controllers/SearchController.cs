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
    [RoutePrefix("Podcasts")]
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;
        internal SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet, Route("{searchString}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Empty Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Found", typeof(SearchResultList))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetSearchResults(string searchString, SearchMode mode)
        {
            if (string.IsNullOrEmpty(searchString))
                return BadRequest();
            try
            {
                var result = _searchService.GetSearchResults(searchString, mode);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}