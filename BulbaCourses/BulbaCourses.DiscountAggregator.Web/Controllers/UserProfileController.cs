using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/profiles")]
    public class UserProfileController : ApiController
    {
        private readonly IUserProfileServices _userProfileService;

        public UserProfileController(IUserProfileServices userProfileService)
        {
            this._userProfileService = userProfileService;
        }

        [HttpGet, Route("")]
        [Description("Get all search Profiles")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Search profiles doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Search profiles found", typeof(IEnumerable<UserProfile>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        //public IHttpActionResult GetAll()
        //{
        //    var result = _userProfileService.GetAll();
        //    return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        //}
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _userProfileService.GetAllAsync();
            //var result = _mapper.Map<IEnumerable<UserInfo>, IEnumerable<UserProfileView>>(users);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{userId}")]//можно указать какой тип id
        [Description("Get profile by Id")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Profile doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Profile found", typeof(UserProfile))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string id)
        {
            //if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var _))
            //{
            //    return BadRequest();
            //}

            try
            {
                var result = _userProfileService.GetById(id);
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
            return Ok(_userProfileService.Add(userProfile));
        }
    }
}
