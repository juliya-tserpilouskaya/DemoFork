using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{/// <summary>
/// The controller of all Stuff list
/// </summary>
    [RoutePrefix("api/staff")]
    public class StaffController : ApiController
    {
        /// <summary>
        /// Get all Staff from the Staff list
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = Staff.GetAll();
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Employee from the Staff list by Id, returns Employee
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
                var result = Staff.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add Employee to the Staff list, returns added Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody]Employee employee)
        {
            if (employee is null)
            {
                return BadRequest();
            }

            try
            {
                var result = Staff.Add(employee);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Find the Employee whis the same Id from the Staff list and add new
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public IHttpActionResult Update([FromBody]Employee  employee)
        {
            if (employee is null)
            {
                return BadRequest();
            }

            try
            {
                var result = Staff.Update(employee);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete by Id Employee from the Staff list
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
                var result = Staff.DeleteById(id);
                return (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
