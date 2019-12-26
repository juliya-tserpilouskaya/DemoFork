using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using BulbaCourses.Video.Web.Models;
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
        private readonly ICommentService commentService;
        private readonly IValidator<CourseWeb> validator;
        private readonly IBus bus;

        public CommentController(IMapper mapper, ICommentService commentService, IBus bus)
        {
            this.mapper = mapper;
            this.commentService = commentService;
            this.bus = bus;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Comment doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment found", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var commentlogic = await commentService.GetById(id);
                var commentWeb = mapper.Map<CommentLogic, CommentWeb>(commentlogic);
                return commentWeb == null ? NotFound() : (IHttpActionResult)Ok(commentWeb);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")] // for debug
        [SwaggerResponse(HttpStatusCode.OK, "Found all comments", typeof(IEnumerable<CommentWeb>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var commentlogic = await commentService.GetAll();
            var commentWeb = mapper.Map<IEnumerable<CommentLogic>, IEnumerable<CommentWeb>>(commentlogic);
            return commentWeb == null ? NotFound() : (IHttpActionResult)Ok(commentWeb);

            //Ok(commentService.GetAll());
        }

        [Authorize]
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment post", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Post([FromBody, CustomizeValidator(RuleSet = "AddComment, default")] CommentWeb commentWeb, CourseWeb courseWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commentlogic = mapper.Map<CommentWeb, CommentLogic>(commentWebWeb);
                var courselogic = mapper.Map<CourseWeb, CourseLogic>(courseWeb);
                var result = await commentService.Add(commentlogic, courselogic);
                return Ok(result);
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
        public async Task<IHttpActionResult> Put(string id, [FromBody, CustomizeValidator(RuleSet = "UpdateComment, default")]CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commentLogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                var result = await commentService.Update(commentLogic);
                return Ok(result);
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
        public IHttpActionResult Delete([FromBody, CustomizeValidator(RuleSet = "DeleteComment, default")]CommentWeb commentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var commentLogic = mapper.Map<CommentWeb, CommentLogic>(commentWeb);
                commentService.Delete(commentLogic);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
