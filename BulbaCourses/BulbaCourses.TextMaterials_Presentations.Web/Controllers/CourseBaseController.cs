using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseBaseController : ApiController
    {        /// <summary>
             /// Get all Courses from the all Courses list
             /// </summary>
             /// <returns></returns>
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = CourseBase.GetAll();
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Course from the all Courses list by Id
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
                var result = CourseBase.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add Course to the all Courses list
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody]Course course)
        {
            if (course is null)
            {
                return BadRequest();
            }

            try
            {
                var result = CourseBase.Add(course);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Find the Course whis the same Id from the all Courses list delete it and add new
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public IHttpActionResult Update([FromBody]Course course)
        {
            if (course is null)
            {
                return BadRequest();
            }

            try
            {
                var result = CourseBase.Update(course);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete by Id Course from the all Courses list
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
                var result = CourseBase.DeleteById(id);
                return (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
