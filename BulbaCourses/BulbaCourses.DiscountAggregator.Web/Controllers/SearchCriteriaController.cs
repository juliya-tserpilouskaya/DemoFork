using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/criterias")]
    public class SearchCriteriaController : ApiController
    {
        private readonly ISearchCriteriaServices _searchCriteriaService;

        public SearchCriteriaController(ISearchCriteriaServices searchCriteriaServices)
        {
            this._searchCriteriaService = searchCriteriaServices;
        }

        [HttpGet, Route("")]
        [Description("Get all search criterias")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Search criterias doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Search criterias found", typeof(IEnumerable<SearchCriteria>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _searchCriteriaService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]//можно указать какой тип id
        [Description("Get criterias by UserId")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Criteria doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Criteria found", typeof(SearchCriteria))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _searchCriteriaService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("User")]//можно указать какой тип id
        [Description("Get criterias for User")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Criteria doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Criteria found", typeof(SearchCriteria))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetByUser()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var sub = (User as ClaimsPrincipal).FindFirst("sub");
                    var result = await _searchCriteriaService.GetByUserIdAsync(sub.Value);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(result);
                }
                return BadRequest();
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost, Route("")]
        [Description("Add new critria")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Search criteria added", typeof(IEnumerable<SearchCriteria>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Add([FromBody, CustomizeValidator(RuleSet = "*")]SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
            {
                return BadRequest();
            }

            var result = await _searchCriteriaService.AddAsync(searchCriteria);
            return result.IsSuccess ? Ok(result.Data) : (IHttpActionResult)BadRequest(result.Message);
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Search criteria updated", typeof(SearchCriteria))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody]SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
            {
                return BadRequest();
            }

            var result = await _searchCriteriaService.UpdateAsync(searchCriteria);
            return result.IsSuccess ? Ok(result.Data) : (IHttpActionResult)BadRequest(result.Message);
        }

        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.OK, "Profile deleted", typeof(SearchCriteria))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _searchCriteriaService.DeleteByIdAsync(id);
            return result.IsSuccess ? Ok(result.Data) : (IHttpActionResult)BadRequest(result.Message);
        }
    }
}
