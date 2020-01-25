using BulbaCourses.Youtube.Logic.Models;
using BulbaCourses.Youtube.Logic.Models.SwaggerExamples.SearchRequests;
using BulbaCourses.Youtube.Logic.Services;
using EasyNetQ;
using EasyNetQ.Consumer;
using FluentValidation.WebApi;
using Newtonsoft.Json;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BulbaCourses.Youtube.Web.Controllers
{
    /// <summary>
    /// Represents a RESTful YoutubeSearch service.
    /// </summary>
    /// [ApiVersion("1.0")]
    [RoutePrefix("api/SearchRequest")]
    public class SearchRequestController : ApiController
    {
        private readonly ILogicService _logicService;
        private IBus _bus;

        public SearchRequestController(ILogicService logicService,IBus bus)
        {
            _logicService = logicService;
            _bus = bus;
        }

        /// <summary>
        /// Search video in youtube
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "SearchRequest validation failed")]
        [SwaggerResponse(HttpStatusCode.NotFound, "ResultVideo list not found")]
        [SwaggerResponse(HttpStatusCode.OK, "ResultVideo list found", typeof(IEnumerable<ResultVideo>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(SearchRequestExample))]
        public async Task<IHttpActionResult> SearchRun([FromBody]SearchRequest searchRequest)
        {
            //var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var userId = String.Empty;
            if (this.Request.Headers.Contains("UserSub"))
                userId = this.Request.Headers.GetValues("UserSub").FirstOrDefault();
            else
                userId = "guest";


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //await _bus.SendAsync("YoutubeQ", searchRequest);
            //await _bus.SendAsync("YoutubeQ", JsonConvert.SerializeObject(userId));

            //_bus.Advanced.Consume("YoutubeQ", 
            //    (data,props,info) =>
            //    {
            //        user = JsonConvert.DeserializeObject<User>(Encoding.UTF8.GetString(data));
            //    });


            try
            {
                var resultVideos = await _logicService.SearchRunAsync(searchRequest, userId);
                return resultVideos == null ? NotFound() : (IHttpActionResult)Ok(resultVideos);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
