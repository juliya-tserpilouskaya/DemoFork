using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/teacherChangedPresentations")]
    public class ChangedPresentationsOperationsController : ApiController
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
                Teacher teacher = Staff.GetById(id);

                if (teacher != null)
                {
                    var result = ChangedPresentationsOperations.GetAll(teacher);
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

        [HttpGet, Route("{idTeacher}Teacher/{idPresentation}")]
        public IHttpActionResult GetById(string idTeacher, string idPresentation)
        {
            if (string.IsNullOrEmpty(idTeacher) || !Guid.TryParse(idTeacher, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Teacher teacher = Staff.GetById(idTeacher);

                if (teacher != null)
                {
                    var result = ChangedPresentationsOperations.GetById(teacher, idPresentation);
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

        [HttpPost, Route("{idTeacher}Teacher/{idPresentation}")]
        public IHttpActionResult Create(string idTeacher, string idPresentation)
        {
            if (string.IsNullOrEmpty(idTeacher) || !Guid.TryParse(idTeacher, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentationToAdd = PresentationsBase.GetById(idPresentation);
                Teacher teacher = Staff.GetById(idTeacher);

                if (teacher != null && presentationToAdd != null)
                {
                    var result = ChangedPresentationsOperations.Add(teacher, presentationToAdd);
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

        [HttpDelete, Route("{idTeacher}Teacher/{idPresentation}")]
        public IHttpActionResult Delete(string idTeacher, string idPresentation)
        {
            if (string.IsNullOrEmpty(idTeacher) || !Guid.TryParse(idTeacher, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            try
            {
                Presentation presentationToDelete = PresentationsBase.GetById(idPresentation);
                Teacher teacher = Staff.GetById(idTeacher);

                if (teacher != null && presentationToDelete != null)
                {
                    var result = ChangedPresentationsOperations.DeleteById(teacher, presentationToDelete.Id);
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