using BulbaCourses.Youtube.Logic.Models;
using BulbaCourses.Youtube.Logic.Services;
using EasyNetQ;
using EasyNetQ.Consumer;
using FluentValidation.WebApi;
using Newtonsoft.Json;
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
    [RoutePrefix("api/SearchRequest")]
    //[Authorize]
    public class SearchRequestController : ApiController
    {
        private readonly ILogicService _logicService;
        private IBus _bus;

        public SearchRequestController(ILogicService logicService,IBus bus)
        {
            _logicService = logicService;
            _bus = bus;
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "SearchRequest validation failed")]
        [SwaggerResponse(HttpStatusCode.NotFound, "ResultVideo list not found")]
        [SwaggerResponse(HttpStatusCode.OK, "ResultVideo list found", typeof(IEnumerable<ResultVideo>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> SearchRun([FromBody]SearchRequest searchRequest)
        {
            var userId = this.Request.Headers.GetValues("UserSub").FirstOrDefault();
            //var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if (userId == null)
                userId = "guest";

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bus.SendAsync("YoutubeQ", searchRequest);
            await _bus.SendAsync("YoutubeQ", JsonConvert.SerializeObject(userId));

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
