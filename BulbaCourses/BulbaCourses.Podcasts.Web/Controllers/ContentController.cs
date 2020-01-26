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
using System.Security.Claims;

namespace BulbaCourses.Podcasts.Web.Controllers
{
    /// <summary>
    /// Represents a RESTful Content service.
    /// </summary>
    [RoutePrefix("api/contents")]
    public class ContentController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IContentService service;
        private readonly IUserService Uservice;

        /// <summary>
        /// Creates Content controller.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        /// <param name="userService"></param>
        public ContentController(IMapper mapper, IContentService service, IUserService userService)
        {
            this.mapper = mapper;
            this.service = service;
            this.Uservice = userService;
        }

        /// <summary>
        /// Gets audiofile by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("Get/{id}")]
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
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var result = await service.GetByIdAsync(id, userId);
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
                else
                {
                    return Unauthorized();
                }
                
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Adds audiofile to the database
        /// </summary>
        /// <param name="contentWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Create")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Content post", typeof(ContentWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddContent, default")]ContentWeb contentWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var contentLogic = mapper.Map<ContentWeb, ContentLogic>(contentWeb);
                    var result = await service.AddAsync(contentLogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(contentWeb);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates audiofile in the database
        /// </summary>
        /// <param name="contentWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut, Route("Update")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
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
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var contentLogic = mapper.Map<ContentWeb, ContentLogic>(contentWeb);
                    var result = await service.UpdateAsync(contentLogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(contentLogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes audiofile in the database
        /// </summary>
        /// <param name="contentWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete, Route("Delete")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
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
                var sub = (User as ClaimsPrincipal).FindFirst("sub");
                string subString = sub.Value;
                var user = (await Uservice.GetByIdAsync(subString));
                if (user.IsSuccess == true)
                {
                    var userId = user.Data;

                    var contentLogic = mapper.Map<ContentWeb, ContentLogic>(contentWeb);
                    var result = service.DeleteAsync(contentLogic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(contentLogic);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return Unauthorized();
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
