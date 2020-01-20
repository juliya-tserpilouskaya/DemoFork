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

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ICommentService service;
        private readonly IBus bus;

        public CommentController(IMapper mapper, ICommentService service, IBus bus)
        {
            this.mapper = mapper;
            this.service = service;
            this.bus = bus;
        }

        [HttpGet, Route("{id}")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all comments", typeof(IEnumerable<CommentWeb>))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var result = await service.GetAllAsync();
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

        [Authorize]
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment post", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddComment, default")] CommentWeb commentWeb, CourseWeb courseWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                var result = await service.AddAsync(commentlogic, courselogic);
                if (result.IsSuccess == true)
                {
                    await bus.SendAsync("Podcasts", $"Added Comment to {courseWeb.Name}");
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

        [Authorize]
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment updated", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update(string id, [FromBody, CustomizeValidator(RuleSet = "UpdateComment, default")]CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                var result = await service.UpdateAsync(commentlogic);
                if (result.IsSuccess == true)
                {
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

        [Authorize]
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment deleted", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete([FromBody, CustomizeValidator(RuleSet = "DeleteComment, default")]CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                var result = await service.DeleteAsync(commentlogic);
                if (result.IsSuccess == true)
                {
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

    }
}
