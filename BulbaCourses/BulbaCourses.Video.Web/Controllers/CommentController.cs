using AutoMapper;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
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
        [SwaggerResponse(HttpStatusCode.OK, "Comment found", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var comment = mapper.Map<CommentInfo, CommentView>(commentService.GetById(id));
                return comment == null ? NotFound() : (IHttpActionResult)Ok(comment);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all comments", typeof(IEnumerable<CommentView>))]
        public IHttpActionResult GetAll()
        {
            var comments = commentService.GetAll();
            var result = mapper.Map<IEnumerable<CommentInfo>, IEnumerable<CommentView>>(comments);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);

            //Ok(commentService.GetAll());
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment post", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Post([FromBody]CommentView comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            try
            {
                var commentInfo = mapper.Map<CommentView, CommentInfo>(comment);
                commentService.Add(commentInfo);
                return Ok(comment);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment updated", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Put(string id, [FromBody]CommentView comment)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            comment.CommentId = id;

            if (comment == null)
            {
                return BadRequest();
            }

            try
            {
                var commentInfo = mapper.Map<CommentView, CommentInfo>(comment);
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
        [SwaggerResponse(HttpStatusCode.OK, "Comment deleted", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                commentService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
