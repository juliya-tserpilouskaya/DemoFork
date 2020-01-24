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
    [RoutePrefix("api/audios")]
    public class AudioController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IAudioService service;
        private readonly IUserService Uservice;
        private readonly IBus bus;

        public AudioController(IMapper mapper, IAudioService service, IBus bus, IUserService userService)
        {
            this.mapper = mapper;
            this.service = service;
            this.Uservice = userService;
            this.bus = bus;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Audio doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Audio found", typeof(AudioWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var result = await service.GetByIdAsync(id);
                if (result.IsSuccess == true)
                {
                    var audioWeb = result.Data;
                    var audiologic = mapper.Map<AudioLogic, AudioWeb>(audioWeb);
                    return Ok(audiologic);
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
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all audios", typeof(IEnumerable<AudioWeb>))]
        public async Task<IHttpActionResult> GetAll(string filter)
        {
            try
            {
                var result = await service.GetAllAsync(filter);
                if (result.IsSuccess == true)
                {
                    var audioLogic = result.Data;
                    var audioWeb = mapper.Map<IEnumerable<AudioLogic>, IEnumerable<AudioWeb>>(audioLogic);
                    return audioWeb == null ? NotFound() : (IHttpActionResult)Ok(audioWeb);
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
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Audio post", typeof(AudioWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddAudio, default")] AudioWeb audioWeb)
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

                    var audiologic = mapper.Map<AudioWeb, AudioLogic>(audioWeb);
                    var result = await service.AddAsync(audiologic, userId);
                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Added Audio {audioWeb.Name} to {audioWeb.Course.Name} by {userId.Name}");
                        return Ok(audiologic);
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

        [Authorize]
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Audio updated", typeof(AudioWeb))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "UpdateAudio, default")]AudioWeb audioWeb)
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

                    var audiologic = mapper.Map<AudioWeb, AudioLogic>(audioWeb);
                    var result = await service.UpdateAsync(audiologic, userId);
                    if (result.IsSuccess == true)
                    {
                        return Ok(audiologic);
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

        [Authorize]
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Audio deleted", typeof(AudioWeb))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Unregistered User")]
        public async Task<IHttpActionResult> Delete([FromBody, CustomizeValidator(RuleSet = "DeleteAudio, default")]AudioWeb audioWeb)
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

                    var audiologic = mapper.Map<AudioWeb, AudioLogic>(audioWeb);
                    var result = service.DeleteAsync(audiologic, userId);
                    if (result.IsSuccess == true)
                    {
                        await bus.SendAsync("Podcasts", $"Deleted Audio {audioWeb.Name} from {audioWeb.Course.Name} by {userId.Name}");
                        return Ok(audiologic);
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
