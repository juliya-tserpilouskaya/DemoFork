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
    /// Represents a RESTful Audio service.
    /// </summary>
    [RoutePrefix("api/audios")]
    public class AudioController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IAudioService service;
        private readonly IUserService Uservice;
        private readonly IBus bus;

        /// <summary>
        /// Creates Audio controller.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        /// <param name="userService"></param>
        public AudioController(IMapper mapper, IAudioService service, IBus bus, IUserService userService)
        {
            this.mapper = mapper;
            this.service = service;
            this.Uservice = userService;
            this.bus = bus;
        }
        /// <summary>
        /// Gets audiodata from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet, Route("Get/{id}")]
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


        /// <summary>
        /// Get all audios from the database that have substring in name
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet, Route("Search/{substring}")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all audios", typeof(IEnumerable<AudioWeb>))]
        public async Task<IHttpActionResult> Search(string substring)
        {
            try
            {
                var result = await service.SearchAsync(substring);
                if (result.IsSuccess == true)
                {
                    var audios = result.Data;
                    var audiosWeb = mapper.Map<IEnumerable<AudioLogic>, IEnumerable<AudioWeb>>(audios);
                    return audiosWeb == null ? NotFound() : (IHttpActionResult)Ok(audiosWeb);
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
        /// <summary>
        /// Gets all audiodata for course from the database
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("GetFor/{courseId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all audios", typeof(IEnumerable<AudioWeb>))]
        public async Task<IHttpActionResult> GetAll(string courseId)
        {
            try
            {
                var result = await service.GetAllAsync(courseId);
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

        /// <summary>
        /// Adds audiodata to the database
        /// </summary>
        /// <param name="audioWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Create")]
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

        /// <summary>
        /// Updates audiodata in the database
        /// </summary>
        /// <param name="audioWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut, Route("Update")]
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

        /// <summary>
        /// Deletes audiodata in the database
        /// </summary>
        /// <param name="audioWeb"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete, Route("Delete")]
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
