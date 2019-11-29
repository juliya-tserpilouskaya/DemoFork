using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{/// <summary>
/// The controller of all Users list
/// </summary>
    [RoutePrefix("api/users")]
    public class StudentsController : ApiController
    {/// <summary>
     /// Get all Users from the list of Users
     /// </summary>
     /// <returns></returns>
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = StudentsBase.GetAll();
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Get User from the list of Users by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = StudentsBase.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add User to the list of Users
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody]Student student)
        {
            if (student is null)
            {
                return BadRequest();
            }

            try
            {
                var result = StudentsBase.Add(student);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Find the User whis the same Id from the list of Users, delete it and add new
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public IHttpActionResult Update([FromBody]Student student)
        {
            if (student is null)
            {
                return BadRequest();
            }

            try
            {
                var result = StudentsBase.Update(student);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete by Id User from the list of Users, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = StudentsBase.DeleteById(id);
                return (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
