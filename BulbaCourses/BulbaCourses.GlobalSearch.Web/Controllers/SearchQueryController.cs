using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.GlobalSearch.Web.Models;
using BulbaCourses.GlobalSearch.Logic.Models;
using BulbaCourses.GlobalSearch.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.DTO;
using System.Threading.Tasks;
using FluentValidation.WebApi;

namespace BulbaCourses.GlobalSearch.Web.Controllers
{
    [RoutePrefix("api/queries")]
    public class SearchQueryController : ApiController
    {
        private readonly ISearchQueryService _searchQueryService;
        public SearchQueryController(ISearchQueryService searchQueryService)
        {
            _searchQueryService = searchQueryService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "There are no queries stored")]
        [SwaggerResponse(HttpStatusCode.OK, "Queries are found", typeof(IEnumerable<SearchQuery>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _searchQueryService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The query doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "The query is found", typeof(SearchQuery))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _searchQueryService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("user/{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid user id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User is not found")]
        [SwaggerResponse(HttpStatusCode.OK, "Search queries are found", typeof(IEnumerable<SearchQueryDTO>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetByUserId(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _searchQueryService.GetByUserIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "The query is added")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query data")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator]SearchQueryDTO query)
        {
            if (query == null|| !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _searchQueryService.AddAsync(query);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpDelete, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "The queries are removed")]
        public IHttpActionResult ClearAll()
        {
            _searchQueryService.RemoveAll();
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid query id")]
        [SwaggerResponse(HttpStatusCode.NotFound, "The query doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "The query is deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public IHttpActionResult DeleteById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _) || _searchQueryService.GetById(id) == null)
            {
                return BadRequest();
            }
            try
            {
                _searchQueryService.RemoveById(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
