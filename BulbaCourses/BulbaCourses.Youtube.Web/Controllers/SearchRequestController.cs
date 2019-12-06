using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace BulbaCourses.Youtube.Web.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchRequestController : ApiController
    {
        private readonly ISearchRequestService _searchRequestService;

        public SearchRequestController(ISearchRequestService searchRequestService)
        {
            _searchRequestService = searchRequestService;
        }

        // GET api/<controller>        
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.NotFound, "ResultVideo list not found")]
        [SwaggerResponse(HttpStatusCode.OK, "ResultVideo list found", typeof(IEnumerable<ResultVideoDb>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult SearchRun(SearchRequest searchRequest)
        {
            try
            {
                var resultVideos = _searchRequestService.SearchRun(searchRequest);
                return resultVideos == null ? NotFound() : (IHttpActionResult)Ok(resultVideos);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
