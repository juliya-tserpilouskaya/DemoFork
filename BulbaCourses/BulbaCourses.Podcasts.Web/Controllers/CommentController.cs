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

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ICommentService commentService;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Comment doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment found", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var comment = mapper.Map<CommentLogic, CommentWeb>(commentService.GetById(id));
                return comment == null ? NotFound() : (IHttpActionResult)Ok(comment);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")] // for debug
        [SwaggerResponse(HttpStatusCode.OK, "Found all comments", typeof(IEnumerable<CommentWeb>))]
        public IHttpActionResult GetAll()
        {
            var comments = commentService.GetAll();
            var result = mapper.Map<IEnumerable<CommentLogic>, IEnumerable<CommentWeb>>(comments);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);

            //Ok(commentService.GetAll());
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment post", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Post([FromBody]CommentWeb comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            try
            {
                var commentlogic = mapper.Map<CommentWeb, CommentLogic>(comment);
                commentService.Add(commentlogic);
                return Ok(comment);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment updated", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Put(string id, [FromBody]CommentWeb comment)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            comment.Id = id;

            if (comment == null)
            {
                return BadRequest();
            }

            try
            {
                var commentInfo = mapper.Map<CommentWeb, CommentLogic>(comment);
                commentService.Update(commentInfo);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment deleted", typeof(CommentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(CommentWeb comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }
            try
            {
                var commentInfo = mapper.Map<CommentWeb, CommentLogic>(comment);
                commentService.Delete(commentInfo);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
