using AutoMapper;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.Infrastructure.BLL.Models;
using BulbaCourses.Analytics.Infrastructure.BLL.Services;
using BulbaCourses.Analytics.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BulbaCourses.Analytics.Web.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Reports found", typeof(ReportShortVm))]
        public IHttpActionResult GetAll()
        {
            try
            {
                var reportDTOs = _reportService.GetAll();

                if (Validation.IsErrors)
                {
                    return NotFound();
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IReportDto, ReportShortVm>()).CreateMapper();
                var reports = mapper.Map<IEnumerable<IReportDto>, List<ReportShortVm>>(reportDTOs);

                return Ok(reports.Cast<ReportShortVm>().ToList());
            }
            catch (InvalidOperationException)
            {
                return InternalServerError();
            }

        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Report doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Report found", typeof(ReportVm))]
        public IHttpActionResult GetById(string Id)
        {
            try
            {
                var reportDto = _reportService.GetById(Id);

                if (Validation.IsErrors)
                {
                    return NotFound();
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IReportDto, ReportVm>()).CreateMapper();
                var reportView = mapper.Map<IReportDto, ReportVm>(reportDto);

                return Ok(reportView);
            }
            catch (InvalidOperationException)
            {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Report Delete", typeof(ReportVm))]
        public IHttpActionResult DeleteById(string Id)
        {
            try
            {
                _reportService.Remove(Id);

                if (Validation.IsErrors)
                {
                    return NotFound();
                }

                return Ok(Id);
            }
            catch (InvalidOperationException)
            {
                return InternalServerError();
            }
        }

    }
}
