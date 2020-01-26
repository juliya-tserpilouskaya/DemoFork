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

        /// <summary>
        /// Get all user profiles
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [Description("Get all Profiles")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Search profiles doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Search profiles found", typeof(IEnumerable<UserProfile>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _userProfileService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get user profile by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [Description("Get profile by Id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Profile doesn't exist")]
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

        /// <summary>
        /// Add user profile
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [Description("Add new profile")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User profile added", typeof(UserProfile))]
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

        /// <summary>
        /// Update user profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete user profile by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
