using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    public class FavoritePresentationsOperationsController : ApiController
    {
        /// <summary>
        /// Get all Presentations from the FavoritePresentations list from Student with the same Id
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
                Student student  = StudentsBase.GetById(id);

                if (student != null)
                {
                    var result = FavoritePresentationsOperations.GetAll(student);
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
        /// Get Presentation by the Id from the FavoritePresentations list from Student by the Student Id
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpGet, Route("{idStudent}Student/{idPresentation}")]
        public IHttpActionResult GetById(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Student student = StudentsBase.GetById(idStudent);

                if (student != null)
                {
                    var result = FavoritePresentationsOperations.GetById(student, idPresentation);
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
        /// Add Presentation by the Id to the FavoritePresentations list from Student by the Student Id
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpPost, Route("{idStudent}Student/{idPresentation}")]
        public IHttpActionResult Create(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentationToAdd = PresentationsBase.GetById(idPresentation);
                Student student = StudentsBase.GetById(idStudent);

                if (student != null && presentationToAdd != null)
                {
                    var result = FavoritePresentationsOperations.Add(student, presentationToAdd);
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
        /// Delete Presentation by the Id from the FavoritePresentations list from Student by the Student Id
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpDelete, Route("{idStudent}Student/{idPresentation}")]
        public IHttpActionResult Delete(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentationToDelete = PresentationsBase.GetById(idPresentation);
                Student student = StudentsBase.GetById(idStudent);

                if (student != null && presentationToDelete != null)
                {
                    var result = FavoritePresentationsOperations.DeleteById(student, presentationToDelete.Id);
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
