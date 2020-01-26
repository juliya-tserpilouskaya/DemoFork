using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/domains")]
    public class DomainController : ApiController
    {
        private readonly IDomainServices _domainService;

        public DomainController(IDomainServices domainService)
        {
            this._domainService = domainService;
        }

        /// <summary>
        /// Get all domains
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [Description("Get all domains")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Domains doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Domains found", typeof(IEnumerable<Domain>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [Authorize]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var result = await _domainService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get domain by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [Description("Get domain by Id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Domains doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Domain found", typeof(Domain))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _domainService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new domain
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [Description("Add new domain")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Domain added", typeof(Domain))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "default")]Domain domain)
        {
            if (domain == null)
            {
                return BadRequest();
            }

            var result = await _domainService.AddAsync(domain);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete domain by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Domain deleted", typeof(Domain))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> DeleteByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
           
            var result = await _domainService.DeleteByIdAsync(id);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update domain by ID
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPut, Route("id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Domain updated", typeof(Domain))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "default")]Domain domain)
        {
            if (domain == null)
            {
                return BadRequest();
            }

            var result = await _domainService.UpdateAsync(domain);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }
    }
}
