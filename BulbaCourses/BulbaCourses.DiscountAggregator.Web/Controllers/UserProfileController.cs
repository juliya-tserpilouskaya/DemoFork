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
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _userProfileService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]//можно указать какой тип id
        [Description("Get profile by Id")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Profile doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Profile found", typeof(UserProfile))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _userProfileService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [Description("Add new profile")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Search profile added", typeof(UserProfile))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet="*")]UserProfile userProfile)
        {
            if (userProfile == null)
            {
                return BadRequest();
            }

            var result = await _userProfileService.AddAsync(userProfile);
            return result.IsSuccess ? (IHttpActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Profile updated", typeof(UserProfile))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]        
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateProfile,default")]UserProfile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }

            var result = await _userProfileService.UpdateAsync(profile);
            return result.IsSuccess ? (IHttpActionResult)Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.OK, "Profile deleted", typeof(UserProfile))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _userProfileService.DeleteByIdAsync(id);
            return result.IsSuccess ? (IHttpActionResult)Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
