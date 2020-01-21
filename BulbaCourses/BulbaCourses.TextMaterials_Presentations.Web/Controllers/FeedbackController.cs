using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Swashbuckle.Swagger.Annotations;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using FluentValidation.WebApi;
using EasyNetQ;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/feadbacks")]
    public class FeedbackController : ApiController
    {
        private readonly IFeedbacksService _feedbackBase;
        private readonly IBus _bus;

        public FeedbackController(IFeedbacksService feedbackBase, IBus bus)
        {
            _feedbackBase = feedbackBase;
            _bus = bus;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Feedbacks doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedbacks found", typeof(IEnumerable<Feedback>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllFeedbacksAsync()
        {
            try
            {
                var result = await _feedbackBase.GetAllFeedbacksAsync();

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Feedback doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback found", typeof(Feedback))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetFeedbackByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _feedbackBase.GetFeedbackByIdAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback added", typeof(Feedback))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> CreateFeedbackAsync
            ([FromBody, CustomizeValidator(RuleSet = "AddFeedback, default")]FeedbackAdd_DTO feedback)
        {
            if (feedback is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _feedbackBase.AddFeedbackAsync(feedback);

                return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback updated", typeof(Feedback))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> UpdateFeedbackAsync
            ([FromBody, CustomizeValidator(RuleSet = "UpdateFeedback, default")]Feedback feedback)
        {
            if (feedback is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _feedbackBase.UpdateFeedbackAsync(feedback);

                return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback deleted", typeof(Boolean))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> DeleteFeedbackAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _feedbackBase.DeleteFeedbackByIdAsync(id);

                return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}