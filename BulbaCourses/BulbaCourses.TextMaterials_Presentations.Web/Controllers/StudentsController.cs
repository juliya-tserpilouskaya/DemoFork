using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using Presentations.Logic;
using System.Threading.Tasks;
using FluentValidation.WebApi;
using EasyNetQ;
using Presentations.Logic.Models;
using System.Security.Claims;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/users")]
    public class StudentsController : ApiController
    {
        private readonly IStudentService _studentService;
        private readonly IBus _bus;

        public StudentsController(IStudentService studentService, IBus bus)
        {
            _studentService = studentService;
            _bus = bus;
        }

        /// <summary>
        /// Get all student presentation accounts from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Students doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Students found", typeof(IEnumerable<Student>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllStudentsAsync()
        {
            try
            {
                var result = await _studentService.GetAllStudentsAsync();

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get srudent presentation account from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Student doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Student found", typeof(Student))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetStudentByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _studentService.GetStudentByIdAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new student presentation account to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Student added", typeof(Student))]
        public async Task<IHttpActionResult> CreateStudentAsync
            ([FromBody]UserAdd_DTO user)
        {
            if (user is null)
            {
                return BadRequest();
            }

            var result = await _studentService.AddStudentAsync(user);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update the student presentation account in the database (PhoneNumber)
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Student found", typeof(Student))]
        public async Task<IHttpActionResult> UpdateStudentAsync
            ([FromBody, CustomizeValidator]Student student)
        {
            if (student is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentService.UpdateStudentAsync(student);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete the student presentation account from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Student deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeleteStudentByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _studentService.DeleteStudentByIdAsync(id);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Add the presentation to the list of favorite presentations
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpPut, Route("{idStudent}/{idPresentation}/likeAdd")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation added", typeof(Boolean))]
        public async Task<IHttpActionResult> AddLovedPresentationAsync(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _) 
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            var result = await _studentService.AddLovedPresentationAsync(idStudent, idPresentation);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Delete the presentation from the list of favorite presentations
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpPut, Route("{idStudent}/{idPresentation}/likeDel")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeleteLovedPresentationAsync(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            var result = await _studentService.DeleteLovedPresentationAsync(idStudent, idPresentation);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Get all presentations from the list of favorite presentations by the student presentation account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/like")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Student doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllLovedPresentationAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _studentService.GetAllLovedPresentationAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        ///  Add the presentation to the list of watched presentations
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpPut, Route("{idStudent}/{idPresentation}/viewAdd")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations added", typeof(Boolean))]
        public async Task<IHttpActionResult> AddWatchedPresentationAsync(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            var result = await _studentService.AddWatchedPresentationAsync(idStudent, idPresentation);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        ///  Delete the presentation from the list of watched presentations
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        [HttpPut, Route("{idStudent}/{idPresentation}/viewDel")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentation deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeleteWatchedPresentationAsync(string idStudent, string idPresentation)
        {
            if (string.IsNullOrEmpty(idStudent) || !Guid.TryParse(idStudent, out var _)
                || string.IsNullOrEmpty(idPresentation) || !Guid.TryParse(idPresentation, out var _))
            {
                return BadRequest();
            }

            var result = await _studentService.DeleteWatchedPresentationAsync(idStudent, idPresentation);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        ///  Get all presentations from the list of watched presentations by the student presentation account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/view")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Student doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllWatchedPresentationAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _studentService.GetAllWatchedPresentationAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Update the student payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hasPayment"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}/payment")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.OK, "Payment updated", typeof(Boolean))]
        public async Task<IHttpActionResult> UpdateIsPaidAsync(string id, bool hasPayment)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _studentService.UpdateIsPaidAsync(id, hasPayment);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Get all feedbacks of the student by the student presentation account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/feedbacks")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Student doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedbacks found", typeof(IEnumerable<Feedback>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllFeedbacksFromStudentAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _studentService.GetAllFeedbacksFromStudentAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
