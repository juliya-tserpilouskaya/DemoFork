using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/criterias")]
    public class SearchCriteriaController : ApiController
    {
        private readonly ISearchCriteriaServices searchCriteriaService;

        public SearchCriteriaController(ISearchCriteriaServices searchCriteriaServices)
        {
            this.searchCriteriaService = searchCriteriaServices;
        }

        [HttpGet, Route("")]
        [Description("Get all search criterias")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Search criterias doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Search criterias found", typeof(IEnumerable<SearchCriteria>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll()
        {
            var result = searchCriteriaService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{userId}")]//можно указать какой тип id
        [Description("Get criterias by UserId")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Criteria doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Criteria found", typeof(SearchCriteria))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = searchCriteriaService.GetByUserId(userId);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut, Route("")]
        [Description("Add new critria")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Search criteria added", typeof(IEnumerable<SearchCriteria>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Add([FromBody]SearchCriteria searchCriteria)
        {
            return Ok(searchCriteriaService.Add(searchCriteria));
        }
    }
}
