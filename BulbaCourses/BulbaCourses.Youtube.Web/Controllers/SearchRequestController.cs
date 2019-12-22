using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.Logic.Services;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BulbaCourses.Youtube.Web.Controllers
{
    [RoutePrefix("api/SearchRequest")]
    public class SearchRequestController : ApiController
    {
        private readonly ILogicService _logicService;

        public SearchRequestController(ILogicService logicService)
        {
            _logicService = logicService;
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "SearchRequest validation failed")]
        [SwaggerResponse(HttpStatusCode.NotFound, "ResultVideo list not found")]
        [SwaggerResponse(HttpStatusCode.OK, "ResultVideo list found", typeof(IEnumerable<ResultVideo>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> SearchRun([FromBody]SearchRequest searchRequest)
        {
            User user = new User()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Petrov",
                FullName = "Ivan Petrov",
                Login = "Vano",
                Password = "123",
                NumberPhone = "+375 44 777 77 77",
                Email = "IPetrov@gmail.com",
                ReserveEmail = ""
            };
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultVideos = await _logicService.SearchRunAsync(searchRequest, user);
                return resultVideos == null ? NotFound() : (IHttpActionResult)Ok(resultVideos);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
