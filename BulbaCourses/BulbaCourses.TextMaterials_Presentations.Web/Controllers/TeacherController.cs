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
using System.Threading.Tasks;
using Presentations.Logic;
using FluentValidation.WebApi;
using EasyNetQ;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        private readonly ITeacherService _teacherService;
        private readonly IBus _bus;

        public TeacherController(ITeacherService teacherService, IBus bus)
        {
            _teacherService = teacherService;
            _bus = bus;
        }

        /// <summary>
        /// Get all teacher presentation accounts from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Teachers doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Teachers found", typeof(IEnumerable<Teacher>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllTeachersAsync()
        {
            try
            {
                var result = await _teacherService.GetAllTeachersAsync();

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get teacher presentation account from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Teacher doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher found", typeof(Teacher))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetTeacherByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _teacherService.GetTeacherByIdAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new teacher presentation account to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher added", typeof(Teacher))]
        public async Task<IHttpActionResult> CreateTeacherAsync
            ([FromBody]TeacherAdd_DTO user)
        {
            if (user is null)
            {
                return BadRequest();
            }

            var result = await _teacherService.AddTeacherAsync(user);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update the teacher presentation account in the database (PhoneNumber, Position)
        /// </summary>
        /// <param name="techer"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher found", typeof(Teacher))]
        public async Task<IHttpActionResult> UpdateTeacherAsync
            ([FromBody, CustomizeValidator]Teacher techer)
        {
            if (techer is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _teacherService.UpdateTeacherAsync(techer);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete the teacher presentation account from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher deleted", typeof(Boolean))]
        public async Task<IHttpActionResult> DeleteTeacherByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _teacherService.DeleteTeacherByIdAsync(id);

            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.IsSuccess);
        }

        /// <summary>
        /// Get all feedbacks of teacher by the teacher presentation account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/feedbacks")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Teacher doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Feedbacks found", typeof(IEnumerable<Feedback>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllFeedbacksFromTeacherAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _teacherService.GetAllFeedbacksFromTeacherAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get all added presentations of this teacher by the teacher presentation account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/presentations")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid parameter format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Teacher doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Presentations found", typeof(IEnumerable<Presentation>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllChangedPresentationsAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _teacherService.GetAllChangedPresentationsAsync(id);

                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
