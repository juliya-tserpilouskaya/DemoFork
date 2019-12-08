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
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;
        internal SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet, Route("{searchString}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Empty Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Not Found")]
        [SwaggerResponse(HttpStatusCode.OK, "Found", typeof(SearchResultList))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something Wrong")]
        public IHttpActionResult GetSearchResults(string searchString, SearchMode mode)
        {
            if (string.IsNullOrEmpty(searchString))
                return BadRequest();
            try
            {
                SearchResultList result = new SearchResultList();
                _searchService.GetSearchResults(searchString, mode, ref result);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}