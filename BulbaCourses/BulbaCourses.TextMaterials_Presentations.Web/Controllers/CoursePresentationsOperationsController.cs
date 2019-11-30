using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/coursePresentations")]
    public class CoursePresentationsOperationsController : ApiController
    {
        /// <summary>
        /// Get all Presentations from the Course with the same Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
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
                    var result = CoursePresentationsOperations.GetAll(course);
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
                    var result = CoursePresentationsOperations.GetById(course, idPresentation);
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
                    var result = CoursePresentationsOperations.Add(course, presentationToAdd);
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
                    var result = CoursePresentationsOperations.DeleteById(course, presentationToDelete.Id);
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
