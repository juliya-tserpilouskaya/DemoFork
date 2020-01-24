using BulbaCourses.GlobalAdminUser.Logic.Models;
using BulbaCourses.GlobalAdminUser.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.GlobalAdminUser.Web.Controllers
{

    [RoutePrefix("api/userprofiles")]
    public class UserProfileController : ApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService=userProfileService;
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserDTO))]
        public async Task<IHttpActionResult> GetByIdAsync([FromBody]UserProfileDTO user)
        {
            try
            {
                var result = await _userProfileService.GetByIdAsync(user.Id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public IHttpActionResult Update([FromBody]UserProfileDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _userProfileService.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[HttpDelete, Route("{id}")]
        //[SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        //[SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        //[SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        //[SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        //public IHttpActionResult Remove(UserDTO user)
        //{
        //    //if (string.IsNullOrEmpty(user))
        //    //{
        //    //    return BadRequest();
        //    //}

        //    try
        //    {
        //        _userProfileServic.(user);
        //        return (IHttpActionResult)Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
    }
}