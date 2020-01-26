using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    /// <summary>
    /// Represents a RESTful Comment service.
    /// </summary>
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ICommentService service;
        private readonly IBus bus;
        private readonly IUserService Uservice;

        /// <summary>
        /// Creates Comment controller.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        /// <param name="user"></param>
        public CommentController(IMapper mapper, ICommentService service, IBus bus, IUserService user)
        {
            this.mapper = mapper;
            this.service = service;
            this.Uservice = user;
            this.bus = bus;
        }

        /// <summary>
        /// Gets comment by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet, Route("Get/{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Comment doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment found", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var result = await service.GetByIdAsync(id);
                if (result.IsSuccess == true)
                {
                    var commentWeb = result.Data;
                    var commentlogic = mapper.Map<CommentLogic, CommentWeb>(commentWeb);
                    return Ok(commentlogic);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Gets all comments for course in the database
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("GetFor/{courseId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all comments", typeof(IEnumerable<CommentWeb>))]
        public async Task<IHttpActionResult> GetAll(string courseId)
        {
            try
            {
                var result = await service.GetAllAsync(courseId);
                if (result.IsSuccess == true)
                {
                    var commentLogic = result.Data;
                    var commentWeb = mapper.Map<IEnumerable<CommentLogic>, IEnumerable<CommentWeb>>(commentLogic);
                    return commentWeb == null ? NotFound() : (IHttpActionResult)Ok(commentWeb);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Adds comment to the database
        /// </summary>
        /// <param name="commentWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Create")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment post", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddComment, default")] CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                    commentlogic.User = userId;
                    var result = await service.AddAsync(commentlogic);
                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Added Comment to {commentlogic.Course.Name} by {userId.Name}");
                        return Ok(commentlogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates comment in the database
        /// </summary>
        /// <param name="commentWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut, Route("Update")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment updated", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update(string id, [FromBody, CustomizeValidator(RuleSet = "UpdateComment, default")]CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                    var result = await service.UpdateAsync(commentlogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(commentlogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes comment in the database
        /// </summary>
        /// <param name="commentWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete, Route("Delete")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment deleted", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete([FromBody, CustomizeValidator(RuleSet = "DeleteComment, default")]CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                    var result = service.DeleteAsync(commentlogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(commentlogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
