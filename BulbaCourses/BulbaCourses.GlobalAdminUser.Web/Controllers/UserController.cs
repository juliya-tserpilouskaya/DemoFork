using BulbaCourses.GlobalAdminUser.Logic.Models;
using BulbaCourses.GlobalAdminUser.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BulbaCourses.GlobalAdminUser.Web.Controllers
{

    [RoutePrefix("api/users")]
    [EnableCors("http://localhost:44382", "*","*")]    
    //[EnableCors("*", "*","*")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        /// <summary>
        /// Create User Controller
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all registered users
        /// </summary>
        /// <returns></returns>
        /// 
        //[EnableCors("http://localhost:44382", "*", "*")]
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Users doesn`t exist.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Users found.", typeof(IEnumerable<UserDTO>))]
        //[SwaggerResponseExample(HttpStatusCode.OK, typeof(DashboardShortExample))]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                var result = await _userService.GetAllAsync();
                if (result == null || result.Count() == 0)
                    return NotFound();
                return (IHttpActionResult)Ok(result);

            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }
        /// <summary>
        /// Receive User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserDTO))]
        public async Task<IHttpActionResult> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)||Guid.TryParse(id,out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _userService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get UserProfile data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[EnableCors("http://localhost:44382", "*", "*")]
        [HttpGet, Route("profile/{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        [SwaggerResponse(HttpStatusCode.OK, "User profile found", typeof(IEnumerable<UserProfileDTO>))]
        public async Task<IHttpActionResult> GetUserProfileByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
                              
            try
            {
                var profile = await _userService.GetUserProfileAsync(id);
                return profile == null ? NotFound() : (IHttpActionResult)Ok(profile);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //[EnableCors("http://localhost:44382", "*", "*")]
        [HttpPost, Route("register")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.OK, "User created", typeof(RegisterUserDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public async Task<IHttpActionResult> Create([FromBody]RegisterUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                string userId = await _userService.RegisterUser(user);
                if (string.IsNullOrEmpty(userId))
                    return BadRequest("");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="user">user model</param>
        /// <returns></returns>
        //[EnableCors("http://localhost:44382", "*", "*")]
        [HttpPost, Route("password")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad model or different passwords")]
        [SwaggerResponse(HttpStatusCode.OK, "Password changed", typeof(UserChangePasswordDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public async Task<IHttpActionResult> ChangePasswordAsync([FromBody]UserChangePasswordDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (user is null)
            {
                return BadRequest();
            }
            if (!user.NewPassword.Equals(user.NewPasswordConfirm))
                return BadRequest("New password different");
            try
            {                
               var result =  await _userService.ChangePassword(user);
                if (result.IsSuccess)
                    return Ok();
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public IHttpActionResult Update([FromBody]UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _userService.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Delete User from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid format")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Error")]
        public async Task<IHttpActionResult> DeleteByIdAsync(string id)
        {
            try
            {
                var result = await _userService.Delete(id);
                
                return result ? BadRequest() : (IHttpActionResult)Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}