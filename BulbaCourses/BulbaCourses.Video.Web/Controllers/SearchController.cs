using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Web.Models;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet, Route("{request}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Courses found", typeof(IEnumerable<CourseView>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetByName(string request, int variant)
        {
            var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null)
            {
                userId = "guest";
            }

            Logic.Models.Enums.SearchVariant searchVariant;
            if (variant == 1)
            {
                searchVariant = Logic.Models.Enums.SearchVariant.ByName;
            }
            else if (variant == 2)
            {
                searchVariant = Logic.Models.Enums.SearchVariant.ByTag;
            }
            else if (variant == 3)
            {
                searchVariant = Logic.Models.Enums.SearchVariant.ByAuthor;
            }
            else
            {
                return BadRequest();
            }

            try
            {
                var result = await _searchService.GetSearchCourses(request, searchVariant);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
