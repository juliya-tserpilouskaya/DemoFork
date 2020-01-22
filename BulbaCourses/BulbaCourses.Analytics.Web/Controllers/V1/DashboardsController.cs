using AutoMapper;
using BulbaCourses.Analytics.BLL.Ensure;
using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples;
using BulbaCourses.Analytics.Infrastructure.Models;
using BulbaCourses.Analytics.Models.V1;
using FluentValidation.WebApi;
using Microsoft.Web.Http;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Analytics.Web.Controllers.V1
{
    /// <summary>
    /// Represents a RESTful Dashboards service.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/Dashboards")]
    public class DashboardsController : ApiController
    {
        private readonly IDashboardsService _Dashboardservice;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates Dashboards controller.
        /// </summary>
        /// <param name="DashboardsService"></param>
        /// <param name="mapper"></param>
        public DashboardsController(
                                IDashboardsService DashboardsService,
                                IMapper mapper)
        {
            _Dashboardservice = DashboardsService;
            _mapper = mapper;
            Debug.WriteLine("+++++++++++++++ DashboardsController +++++++++++++++");
        }

        /// <summary>
        /// Gets all dashboards.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Dashboards doesn`t exist.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Dashboards found.", typeof(DashboardShort))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(DashboardShortExample))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var sub = (User as ClaimsPrincipal).FindFirst("sub");

                }

                var dashboardDtos = await _Dashboardservice.GetAllAsync();
                if (!dashboardDtos.Any()) { return NotFound(); }
                var Dashboardshorts = _mapper.Map<IEnumerable<DashboardShort>>(dashboardDtos);

                return Ok(Dashboardshorts);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Shows a dashboard details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("id/{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Dashboard doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Dashboard founds.", typeof(DashboardShort))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(DashboardShortExample))]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var dashboardDto = await _Dashboardservice.GetByIdAsync(id);
                if (dashboardDto == null) return NotFound();
                var dashboard = _mapper.Map<DashboardShort>(dashboardDto);

                return Ok(dashboard);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Deletes a dashboard by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("id/{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Dashboard doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> DeleteById(string id)
        {
            try
            {
                var isRemoved = await _Dashboardservice.RemoveAsync(id);
                if (!isRemoved) { return NotFound(); }

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Creates a new dashboard.
        /// </summary>
        /// <param name="dashboardNew"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Dashboard not created.")]
        [SwaggerResponse(HttpStatusCode.OK, "Dashboard created", typeof(DashboardNew))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(DashboardCreateExample))]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "Create")]DashboardNew dashboardNew)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var dashboardDto = _mapper.Map<DashboardDto>(dashboardNew);
                dashboardDto = await _Dashboardservice.CreateAsync(dashboardDto);
                if (dashboardDto == null) return BadRequest();
                dashboardNew = _mapper.Map<DashboardNew>(dashboardDto);

                return Ok(dashboardNew);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Updates a dashboard.
        /// </summary>
        /// <param name="dashboard"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Dashboard not updated.")]
        [SwaggerResponse(HttpStatusCode.OK, "Dashboard updated", typeof(DashboardShort))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(DashboardShortExample))]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "Update")]DashboardShort dashboard)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var dashboardDto = _mapper.Map<DashboardDto>(dashboard);
                dashboardDto = await _Dashboardservice.UpdateAsync(dashboardDto);
                if (dashboardDto == null) return BadRequest();
                dashboard = _mapper.Map<DashboardShort>(dashboardDto);

                return Ok(dashboard);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }
    }
}
