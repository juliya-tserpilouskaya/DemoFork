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
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Video.Web.Controllers
{
    /// <summary>
    /// Represents a RESTful Comments service.
    /// </summary>
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        /// <summary>
        /// Creates Comments controller.
        /// </summary>
        /// <param name="commentService"></param>
        /// <param name="mapper"></param>
        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        /// <summary>
        /// Shows a comment details by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Comment doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment found", typeof(CommentInfo))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var comment = await _commentService.GetCommentByIdAsync(id);
                return comment == null ? NotFound() : (IHttpActionResult)Ok(comment);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Gets all comments from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all comments", typeof(IEnumerable<CommentView>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var comments = await _commentService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CommentInfo>, IEnumerable<CommentView>>(comments);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Add new comment to the database.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment post", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Post([FromBody]CommentView comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            var commentInfo = _mapper.Map<CommentView, CommentInfo>(comment);
            var result = await _commentService.AddAsync(commentInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update comment in the database.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment updated", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Put(string id, [FromBody]CommentView comment)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            if (comment == null)
            {
                return BadRequest();
            }

            var commentInfo = _mapper.Map<CommentView, CommentInfo>(comment);
            var result = await _commentService.UpdateAsync(commentInfo);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete comment by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Comment deleted", typeof(CommentView))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                await _commentService.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
