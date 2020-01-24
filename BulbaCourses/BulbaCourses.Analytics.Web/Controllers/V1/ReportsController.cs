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
    /// Represents a RESTful reports service.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/reports")]
    public class ReportsController : ApiController
    {
        private readonly IReportsService _reportService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates reports controller.
        /// </summary>
        /// <param name="reportsService"></param>
        /// <param name="mapper"></param>
        public ReportsController(
                                IReportsService reportsService,
                                IMapper mapper)
        {
            _reportService = reportsService;
            _mapper = mapper;
            Debug.WriteLine("+++++++++++++++ ReportsController +++++++++++++++");
        }

        /// <summary>
        /// Gets all reports.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exist.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Reports found.", typeof(ReportShort))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportShortExample))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var sub = (User as ClaimsPrincipal).FindFirst("sub");

                }

                var reportDtos = await _reportService.GetAllAsync();
                if (!reportDtos.Any()) { return NotFound(); }
                var reportShorts = _mapper.Map<IEnumerable<ReportShort>>(reportDtos);

                return Ok(reportShorts);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Shows a report details by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet, Route("name/{name}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Report doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Report founds.", typeof(Report))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportExample))]
        public async Task<IHttpActionResult> GetAllByName(string name)
        {
            try
            {
                var reportDtos = await _reportService.GetAllByNameAsync(name, Search.StringOption.Contains);
                if (!reportDtos.Any()) { return NotFound(); }
                var report = _mapper.Map<List<Report>>(reportDtos);

                return Ok(report);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Shows a report details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("id/{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Report doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Report founds.", typeof(Report))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportExample))]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var reportDto = await _reportService.GetByIdAsync(id);
                if (reportDto == null) return NotFound();
                var report = _mapper.Map<Report>(reportDto);

                return Ok(report);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Deletes a report by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("id/{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Report doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> DeleteById(string id)
        {
            try
            {
                var isRemoved = await _reportService.RemoveAsync(id);
                if (!isRemoved) { return NotFound(); }

                return Ok();
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Creates a new report.
        /// </summary>
        /// <param name="reportNew"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Report not created.")]
        [SwaggerResponse(HttpStatusCode.OK, "Report created", typeof(ReportNew))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportCreateExample))]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "Create")]ReportNew reportNew)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var reportDto = _mapper.Map<ReportDto>(reportNew);
                reportDto = await _reportService.CreateAsync(reportDto);
                if (reportDto == null) return BadRequest();
                reportNew = _mapper.Map<ReportNew>(reportDto);

                return Ok(reportNew);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }

        /// <summary>
        /// Updates a report.
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Report not updated.")]
        [SwaggerResponse(HttpStatusCode.OK, "Report updated", typeof(Report))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportExample))]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "Update")]Report report)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var reportDto = _mapper.Map<ReportDto>(report);
                reportDto = await _reportService.UpdateAsync(reportDto);
                if (reportDto == null) return BadRequest();
                report = _mapper.Map<Report>(reportDto);

                return Ok(report);
            }
            catch (InvalidOperationException ioe)
            {
                return InternalServerError(ioe);
            }
        }
    }
}
