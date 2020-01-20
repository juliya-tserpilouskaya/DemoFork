using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.Enums;
using BulbaCourses.Video.Web.Models;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "User found", typeof(UserProfileView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await _userService.GetUserByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all courses", typeof(IEnumerable<UserProfileView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserInfo>, IEnumerable<UserProfileView>>(users);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User post", typeof(UserProfileView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator (RuleSet = "AddUser")]UserProfileView user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = _mapper.Map<UserProfileView, UserInfo>(user);
            var result = await _userService.AddAsync(userInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpPost, Route("buysub")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User post", typeof(UserProfileView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> BuySubscription([FromBody, CustomizeValidator(RuleSet = "UpdateUser")]UserProfileView user, Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = _mapper.Map<UserProfileView, UserInfo>(user);
            var result = await _userService.BuySubscription(userInfo, subscription);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok();
        }

        [HttpPost, Route("buycourse")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User post", typeof(UserProfileView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> BuySubscription([FromBody, CustomizeValidator(RuleSet = "UpdateUser")]UserProfileView user, CourseView course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = _mapper.Map<UserProfileView, UserInfo>(user);
            var courseInfo = _mapper.Map<CourseView, CourseInfo>(course);
            var result = await _userService.BuySingleCourse(userInfo, courseInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok();
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserProfileView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateUser")]UserProfileView user)
        {
            var userInfo = _mapper.Map<UserProfileView, UserInfo>(user);
            var result = await _userService.UpdateAsync(userInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "User deleted", typeof(UserProfileView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                await _userService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
