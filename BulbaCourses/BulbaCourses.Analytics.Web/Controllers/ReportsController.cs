using AutoMapper;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.BLL.Interfaces;
using BulbaCourses.Analytics.BLL.Services;
using BulbaCourses.Analytics.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BulbaCourses.Analytics.Web.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        private IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Reports found", typeof(ReportViewModel))]
        public IHttpActionResult ShowAll()
        {
            IEnumerable<ReportShortDTO> reportDTOs = _reportService.GetReportsShort();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReportShortDTO, ReportViewModel>()).CreateMapper();
            var reports = mapper.Map<IEnumerable<ReportShortDTO>, List<ReportViewModel>>(reportDTOs);

            return reports == null ? NotFound() : (IHttpActionResult)Ok(reports);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Report doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Report found", typeof(ReportViewModel))]
        public IHttpActionResult ShowReportById(string Id)
        {   
            try
            {
                var reportDTO = _reportService.GetReportById(Id);
                return Ok(reportDTO);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Report Delete", typeof(ReportViewModel))]
        public IHttpActionResult DeleteReportById(string Id)
        {
            try
            {
                _reportService.RemoveReport(Id);
                return Ok(Id);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
        }

    }
}
