using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using Presentations.Logic.Models.Course;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers.Staff;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using Presentations.Logic.Models.Course.InterfacesCourse;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/courseTeachers")]
    public class CourseTeachersController : ApiController
    {
        private readonly ICourseTeachersService _courseTeachers;

        public CourseTeachersController(ICourseTeachersService courseTeachers)
        {
            _courseTeachers = courseTeachers;
        }

        /// <summary>
        /// Get all Teachers from the Course with the same Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Teachers found", typeof(IEnumerable<Teacher>))]
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
                    var result = _courseTeachers.GetAll(course);
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
        /// Get Teacher by the Id from the Course by the Course Id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <param name="idTeacher"></param>
        /// <returns></returns>
        [HttpGet, Route("{idCourse}Course/{idTeacher}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course or Teacher doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher found", typeof(Teacher))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string idCourse, string idTeacher)
        {
            if (string.IsNullOrEmpty(idCourse) || !Guid.TryParse(idCourse, out var _)
                || string.IsNullOrEmpty(idTeacher) || !Guid.TryParse(idTeacher, out var _))
            {
                return BadRequest();
            }

            try
            {
                Course course = CourseBase.GetById(idCourse);

                if (course != null)
                {
                    var result = _courseTeachers.GetById(course, idTeacher);
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
        /// Add Teacher by the Id to the Course by the Course Id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <param name="idTeacher"></param>
        /// <returns></returns>
        [HttpPost, Route("{idCourse}Course/{idTeacher}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course or Teacher doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher added", typeof(Teacher))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Create(string idCourse, string idTeacher)
        {
            if (string.IsNullOrEmpty(idCourse) || !Guid.TryParse(idCourse, out var _)
                || string.IsNullOrEmpty(idTeacher) || !Guid.TryParse(idTeacher, out var _))
            {
                return BadRequest();
            }

            try
            {
                Teacher teacherToAdd = Staff.GetById(idTeacher);
                Course course = CourseBase.GetById(idCourse);

                if (course != null && teacherToAdd != null)
                {
                    var result = _courseTeachers.Add(course, teacherToAdd);
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
        /// Delete Teacher by the Id from the Course by the Course Id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <param name="idTeacher"></param>
        /// <returns></returns>
        [HttpDelete, Route("{idCourse}Course/{idTeacher}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Course or Teacher doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Teacher deleted", typeof(Boolean))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult Delete(string idCourse, string idTeacher)
        {
            if (string.IsNullOrEmpty(idCourse) || !Guid.TryParse(idCourse, out var _)
                || string.IsNullOrEmpty(idTeacher) || !Guid.TryParse(idTeacher, out var _))
            {
                return BadRequest();
            }

            try
            {
                Teacher teacherToDelete = Staff.GetById(idTeacher);
                Course course = CourseBase.GetById(idCourse);

                if (course != null && teacherToDelete != null)
                {
                    var result = _courseTeachers.DeleteById(course, teacherToDelete.Id);
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
