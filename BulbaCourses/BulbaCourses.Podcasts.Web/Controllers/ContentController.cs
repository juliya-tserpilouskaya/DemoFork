using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    [RoutePrefix("api/contents")]
    public class ContentController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IContentService service;
        private readonly IBus bus;

        public ContentController(IMapper mapper, IContentService contentService, IBus bus)
        {
            this.mapper = mapper;
            this.service = contentService;
            this.bus = bus;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Content doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Content found", typeof(ContentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = await service.GetByIdAsync(id);
                if (result.IsSuccess == true)
                {
                    var content = result.Data;
                    var contentWeb = mapper.Map<ContentLogic, ContentWeb>(content);
                    return result == null ? NotFound() : (IHttpActionResult)Ok(contentWeb);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Content post", typeof(ContentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddContent, default")]ContentWeb contentWeb, AudioWeb audioWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var contentLogic = mapper.Map<ContentWeb, ContentLogic>(contentWeb);
                var audiologic = mapper.Map<AudioWeb, AudioLogic>(audioWeb);
                var result = await service.AddAsync(contentLogic, audiologic);
                if (result.IsSuccess == true)
                {
                    await bus.SendAsync("Podcasts", $"Added Content to {audioWeb.Name}");
                    return Ok(contentWeb);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Content updated", typeof(ContentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateContent, default")]ContentWeb contentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var contentLogic = mapper.Map<ContentWeb, ContentLogic>(contentWeb);
                var result = await service.UpdateAsync(contentLogic);
                if (result.IsSuccess == true)
                {
                    return Ok(contentLogic);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpDelete, Route("{id})")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Content deleted", typeof(ContentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Delete([FromBody, CustomizeValidator(RuleSet = "DeleteContent, default")] ContentWeb contentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var contentLogic = mapper.Map<ContentWeb, ContentLogic>(contentWeb);
                var result = await service.DeleteAsync(contentLogic);
                if (result.IsSuccess == true)
                {
                    return Ok(contentLogic);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
