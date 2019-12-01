using Presentations.Logic.Models.Presentations;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Swashbuckle.Swagger.Annotations;
using System.Net.Http;
using System.Web.Http;
using Presentations.Logic.Models.Presentations.InterfacesPresentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/presentationFeadbacks")]
    public class FeedbackServiceController : ApiController
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackServiceController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedbacks found", typeof(IEnumerable<Feedback>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentation = PresentationsBase.GetById(id);

                if (presentation != null)
                {
                    var result = _feedbackService.GetAll(presentation);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("{idPresentation}Presentation/{idFeedback}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation or Feedback doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback found", typeof(Feedback))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string idPresentation, string idFeedback)
        {
            if (string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _)
                || string.IsNullOrEmpty(idFeedback) || !Guid.TryParse(idFeedback, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentation = PresentationsBase.GetById(idPresentation);

                if (presentation != null)
                {
                    var result = _feedbackService.GetById(presentation, idFeedback);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("{idPresentation}Presentation/{idFeedback}/{idUser}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation or Feedback doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback added", typeof(Feedback))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Create(string idPresentation, string idFeedback, string idUser)
        {
            if (string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _)
                || string.IsNullOrEmpty(idFeedback) || !Guid.TryParse(idFeedback, out var _)
                    || string.IsNullOrEmpty(idUser) || !Guid.TryParse(idUser, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentation = PresentationsBase.GetById(idPresentation);
                Feedback feedbackToAdd = _feedbackService.GetById(presentation, idFeedback);
                User user = StudentsBase.GetById(idUser);

                if (presentation != null && user != null && feedbackToAdd != null)
                {
                    var result = _feedbackService.Add(feedbackToAdd, presentation, user);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route("{idPresentation}Presentation/{idFeedback}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Presentation or Feedback doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedback deleted", typeof(Feedback))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string idPresentation, string idFeedback)
        {
            if (string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _)
                || string.IsNullOrEmpty(idFeedback) || !Guid.TryParse(idFeedback, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentation = PresentationsBase.GetById(idPresentation);
                Feedback feedbackToDelete = _feedbackService.GetById(presentation, idFeedback);

                if (presentation != null && feedbackToDelete != null)
                {
                    var result = _feedbackService.DeleteById(presentation, feedbackToDelete.Id);
                    return (IHttpActionResult)Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}