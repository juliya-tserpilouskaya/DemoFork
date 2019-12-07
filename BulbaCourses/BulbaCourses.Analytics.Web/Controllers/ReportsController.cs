using AutoMapper;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.Infrastructure.BLL.Services;
using BulbaCourses.Analytics.Web.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace BulbaCourses.Analytics.Web.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportsController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.OK, "Reports found", typeof(ReportVm))]
        public IHttpActionResult GetAll()
        {
            Validation.Free();
            try
            {
                var reportDTOs = _reportService.GetAll();

                if (Validation.IsErrors)
                {
                    return NotFound();
                }

                var reportVms = _mapper.Map<IEnumerable<ReportVm>>(reportDTOs);
                return Ok(reportVms); 
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
            Validation.Free();
            try
            {
                var reportDto = _reportService.GetById(Id);

                if (Validation.IsErrors)
                {
                    return NotFound();
                }

                var reportView = _mapper.Map<ReportVm>(reportDto);

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
            Validation.Free();
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
