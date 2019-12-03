using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/coursePresentations")]
    public class CoursePresentationsController : ApiController
    {
        private readonly ICoursePresentationsService _coursePresentationsService;

        public CoursePresentationsController(ICoursePresentationsService coursePresentations)
        {
            _coursePresentationsService = coursePresentations;
        }

        /// <summary>
        /// Get all Presentations from the Course with the same Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetAll(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                Course course = CourseBase.GetById(id);

                if (course != null)
                {
                    var result = _coursePresentationsService.GetAll(course);
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

        /// <summary>
        /// Get Presentation by the Id from the Course by the Course Id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpGet, Route("{idCourse}Course/{idPresentation}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course or Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation found", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string idCourse, string idPresentation)
        {
            if (string.IsNullOrEmpty(idCourse) || !Guid.TryParse(idCourse, out var _) 
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Course course = CourseBase.GetById(idCourse);

                if (course != null)
                {
                    var result = _coursePresentationsService.GetById(course, idPresentation);
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

        /// <summary>
        /// Add Presentation by the Id to the Course by the Course Id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpPost, Route("{idCourse}Course/{idPresentation}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course or Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation added", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Create(string idCourse, string idPresentation)
        {
            if (string.IsNullOrEmpty(idCourse) || !Guid.TryParse(idCourse, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentationToAdd = PresentationsBase.GetById(idPresentation);
                Course course = CourseBase.GetById(idCourse);

                if (course != null && presentationToAdd != null)
                {
                    var result = _coursePresentationsService.Add(course, presentationToAdd);
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

        /// <summary>
        /// Delete Presentation by the Id from the Course by the Course Id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpDelete, Route("{idCourse}Course/{idPresentation}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course or Presentation doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation deleted", typeof(Boolean))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string idCourse, string idPresentation)
        {
            if (string.IsNullOrEmpty(idCourse) || !Guid.TryParse(idCourse, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentationToDelete = PresentationsBase.GetById(idPresentation);
                Course course = CourseBase.GetById(idCourse);

                if (course != null && presentationToDelete != null)
                {
                    var result = _coursePresentationsService.DeleteById(course, presentationToDelete.Id);
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
