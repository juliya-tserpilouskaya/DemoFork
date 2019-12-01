using Presentations.Logic.Models.Presentations;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/studentViewedPresentations")]
    public class ViewedPresentationsOperationsController : ApiController
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
                Student student = StudentsBase.GetById(id);

                if (student != null)
                {
                    var result = ViewedPresentationsOperations.GetAll(student);
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
                    var result = ViewedPresentationsOperations.GetById(student, idPresentation);
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
                    var result = ViewedPresentationsOperations.Add(student, presentationToAdd);
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
                    var result = ViewedPresentationsOperations.DeleteById(student, presentationToDelete.Id);
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