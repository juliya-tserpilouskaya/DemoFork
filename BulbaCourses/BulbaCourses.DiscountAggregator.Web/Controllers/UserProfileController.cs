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
    [RoutePrefix("api/profiles")]
    public class UserProfileController : ApiController
    {
        private readonly IUserProfileServices userProfileService;

        public UserProfileController(IUserProfileServices userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        [HttpGet, Route("")]
        [Description("Get all search Profiles")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Search profiles doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Search profiles found", typeof(IEnumerable<UserProfile>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll()
        {
            var result = userProfileService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{userId}")]//можно указать какой тип id
        [Description("Get profile by UserId")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Profile doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Profile found", typeof(UserProfile))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetByUserId(string userId)
        {
            //if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var _))
            //{
            //    return BadRequest();
            //}

            try
            {
                var result = userProfileService.GetByUserId(userId);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut, Route("")]
        [Description("Add new profile")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Search profile added", typeof(IEnumerable<UserProfile>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Add([FromBody]UserProfile userProfile)
        {
            return Ok(userProfileService.Add(userProfile));
        }
    }
}
