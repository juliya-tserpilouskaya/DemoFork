using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/presentationFeadbacks")]
    public class FeedbackOperationsController : ApiController
    {

        [HttpGet, Route("{id}")]
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
                    var result = FeedbackOperations.GetAll(presentation);
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
                    var result = FeedbackOperations.GetById(presentation, idFeedback);
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
                Feedback feedbackToAdd = FeedbackOperations.GetById(presentation, idFeedback);
                User user = StudentsBase.GetById(idUser);

                if (presentation != null && user != null && feedbackToAdd != null)
                {
                    var result = FeedbackOperations.Add(feedbackToAdd, presentation, user);
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
                Feedback feedbackToDelete = FeedbackOperations.GetById(presentation, idFeedback);

                if (presentation != null && feedbackToDelete != null)
                {
                    var result = FeedbackOperations.DeleteById(presentation, feedbackToDelete.Id);
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