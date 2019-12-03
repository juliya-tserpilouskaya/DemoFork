using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Presentations.Logic.Services;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Swashbuckle.Swagger.Annotations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    public class FavoritePresentationsController : ApiController
    {
        private readonly IFavoritePresentationsService _favoritePresentationsService;
        private readonly IStudentBaseService _studentService;
        private readonly IPresentationsBaseService _presentationsBaseService;

        public FavoritePresentationsController(IFavoritePresentationsService favoritePresentationsService, IStudentBaseService studentService, IPresentationsBaseService presentationsBase)
        {
            _favoritePresentationsService = favoritePresentationsService;
            _studentService = studentService;
            _presentationsBaseService = presentationsBase;
        }

        /// <summary>
        /// Get all Presentations from the Favorite Presentations list from Student with the same Id
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
                Student student = _studentService.GetById(id);

                if (student != null)
                {
                    var result = _favoritePresentationsService.GetAll(student);
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
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
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
                Student student = _studentService.GetById(idStudent);

                if (student != null)
                {
                    var result = _favoritePresentationsService.GetById(student, idPresentation);
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
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(Presentation))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
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
                Presentation presentationToAdd = _presentationsBaseService.GetById(idPresentation);
                Student student = _studentService.GetById(idStudent);

                if (student != null && presentationToAdd != null)
                {
                    var result = _favoritePresentationsService.Add(student, presentationToAdd);
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
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(Boolean))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
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
                Presentation presentationToDelete = _presentationsBaseService.GetById(idPresentation);
                Student student = _studentService.GetById(idStudent);

                if (student != null && presentationToDelete != null)
                {
                    var result = _favoritePresentationsService.DeleteById(student, presentationToDelete.Id);
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
