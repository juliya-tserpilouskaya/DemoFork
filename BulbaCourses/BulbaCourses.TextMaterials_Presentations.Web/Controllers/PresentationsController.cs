using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Presentations.Logic.Models.Presentations;
using Presentations.Logic.Models.Presentations.InterfacesPresentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Controllers
{/// <summary>
/// The controller of all Presentations list
/// </summary>
    [RoutePrefix("api/presentations")]
    public class PresentationsController : ApiController
    {
        private readonly IPresentationsBaseService _presentationsBase;

        public PresentationsController(IPresentationsBaseService presentationsBase)
        {
            _presentationsBase = presentationsBase;
        }

        /// <summary>
        /// Get all Presentations from the all Presentations list
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = _presentationsBase.GetAll();
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Presentation from the all Presentations list by Id
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
                var result = _presentationsBase.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add Presentation to the all Presentations list
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody]Presentation presentation)
        {
            if (presentation is null)
            {
                return BadRequest();
            }

            try
            {
                var result = _presentationsBase.Add(presentation);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Find the Presentation whis the same Id from the all Presentations list delete it and add new
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public IHttpActionResult Update([FromBody]Presentation presentation)
        {
            if (presentation is null)
            {
                return BadRequest();
            }

            try
            {
                var result = _presentationsBase.Update(presentation);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete by Id Presentation from the all Presentations list
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
                var result = _presentationsBase.DeleteById(id);
                return (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
