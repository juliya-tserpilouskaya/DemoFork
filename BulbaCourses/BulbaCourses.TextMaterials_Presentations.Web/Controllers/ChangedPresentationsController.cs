using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/teacherChangedPresentations")]
    public class ChangedPresentationsController : ApiController
    {
        private readonly IChangedPresentationsService _changedPresentationsService;
        private readonly IStaffService _staffService;
        private readonly IPresentationsBaseService _presentationsBaseService;

        public ChangedPresentationsController(IStaffService staffService, IPresentationsBaseService presentationsBaseService, IChangedPresentationsService changedPresentationsService)
        {
            _staffService = staffService;
            _presentationsBaseService = presentationsBaseService;
            _changedPresentationsService = changedPresentationsService;
        }

        /// <summary>
        /// Get all Presentations from the ChangedPresentations list from Student with the same Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]

        [HttpGet, Route("{id}")]
        public IHttpActionResult GetAll(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                Teacher teacher = _staffService.GetById(id);

                if (teacher != null)
                {
                    var result = _changedPresentationsService.GetAll(teacher);
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
        /// Get Presentation by the Id from the ChangedPresentations list from Teacher by the Teacher Id
        /// </summary>
        /// <param name="idTeacher"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
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
                Teacher teacher = _staffService.GetById(idTeacher);

                if (teacher != null)
                {
                    var result = _changedPresentationsService.GetById(teacher, idPresentation);
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
        /// Add Presentation by the Id to the ChangedPresentations list from Teacher by the Teacher Id
        /// </summary>
        /// <param name="idTeacher"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]

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
                Presentation presentationToAdd = _presentationsBaseService.GetById(idPresentation);
                Teacher teacher = _staffService.GetById(idTeacher);

                if (teacher != null && presentationToAdd != null)
                {
                    var result = _changedPresentationsService.Add(teacher, presentationToAdd);
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
        /// Delete Presentation by the Id from the ChangedPresentations list from Teacher by the Teacher Id
        /// </summary>
        /// <param name="idTeacher"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(Boolean))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]

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
                Presentation presentationToDelete = _presentationsBaseService.GetById(idPresentation);
                Teacher teacher = _staffService.GetById(idTeacher);

                if (teacher != null && presentationToDelete != null)
                {
                    var result = _changedPresentationsService.DeleteById(teacher, presentationToDelete.Id);
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