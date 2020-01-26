using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;
using Presentations.Logic.Services;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using System.Threading.Tasks;
using FluentValidation.WebApi;
using EasyNetQ;
using Presentations.Logic;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/presentations")]
    public class PresentationsController : ApiController
    {
        private readonly IPresentationsService _presentationsBase;
        private readonly IBus _bus;

        public PresentationsController(IPresentationsService presentationBase, IBus bus)
        {
            _presentationsBase = presentationBase;
            _bus = bus;
        }

        /// <summary>
        /// Get all presentations from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentations doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllPresentationsAsync()
        {
            try
            {
                var result = await _presentationsBase.GetAllPresentationsAsync();

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get presentation from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation found", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetPresentationByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _presentationsBase.GetPresentationByIdAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new presentation to the database
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation added", typeof(Presentation))]
        public async Task<IHttpActionResult> CreatePresentationAsync
            ([FromBody, CustomizeValidator(RuleSet = "AddPresentation, default")]PresentationAdd_DTO presentation)
        {
            if (presentation is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _presentationsBase.AddPresentationAsync(presentation);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update the presentation in the database (Title, IsAccessible, TeacherDB, CourseDB)
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation updated", typeof(Presentation))]
        public async Task<IHttpActionResult> UpdatePresentationAsync
            ([FromBody, CustomizeValidator(RuleSet = "UpdatePresentation, default")]Presentation presentation)
        {
            if (presentation is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _presentationsBase.UpdatePresentationAsync(presentation);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete the presentation from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeletePresentationByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _presentationsBase.DeletePresentationByIdAsync(id);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Get all students who watched this presentation by presentation ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/viewed")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Students found", typeof(IEnumerable<Student>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllWhoWatchedThisPresentationAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _presentationsBase.GetAllWhoWatchedThisPresentationAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get all students who like this presentation by presentation ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/like")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Students found", typeof(IEnumerable<Student>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllWhoLikeThisPresentationAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _presentationsBase.GetAllWhoLikeThisPresentationAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get all feedbacks for this presentation by presentation ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/feedbacks")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedbacks found", typeof(IEnumerable<Feedback>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllFeedbacksPresentationAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _presentationsBase.GetAllFeedbacksPresentationAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
