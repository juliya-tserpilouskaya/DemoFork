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

        /// <summary>
        /// Get all feedbacks from the database 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get feedback from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add new feedback to the database
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback added", typeof(Feedback))]
        public async Task<IHttpActionResult> CreateFeedbackAsync
            ([FromBody, CustomizeValidator]FeedbackAdd_DTO feedback)
        {
            if (feedback is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _feedbackBase.AddFeedbackAsync(feedback);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update the feedback in the database (Text, Title)
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback updated", typeof(Feedback))]
        public async Task<IHttpActionResult> UpdateFeedbackAsync
            ([FromBody, CustomizeValidator(RuleSet = "UpdateFeedback, default")]Feedback feedback)
        {
            if (feedback is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _feedbackBase.UpdateFeedbackAsync(feedback);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete the feedback from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeleteFeedbackByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _feedbackBase.DeleteFeedbackByIdAsync(id);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }
    }
}