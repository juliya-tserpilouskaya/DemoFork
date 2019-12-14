using AutoMapper;
using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.Web.Infrastructure.SwaggerExamples.Reports;
using BulbaCourses.Analytics.Web.Models;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web.Http;

namespace BulbaCourses.Analytics.Web.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IValidation _validation;

        public ReportsController(IReportService reportService, IMapper mapper, IValidation validation)
        {
            _reportService = reportService;
            _mapper = mapper;
            _validation = validation;
            validation.Init();
            Debug.WriteLine("+++++++++++++++ ReportsController +++++++++++++++");
        }

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Reports doesn`t exist.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Reports found.", typeof(ReportShortVm))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportShortVmModelExample))]
        public IHttpActionResult GetAll()
        {            
            try
            {
                var reportDTOs = _reportService.GetAll();
                
                if (_validation.IsErrors)
                {
                    return Content(HttpStatusCode.NotFound, _validation.Errors);
                }

                var reportVms = _mapper.Map<IEnumerable<ReportShortVm>>(reportDTOs);
                return Ok(reportVms);
            }
            catch (InvalidOperationException)
            {
                return InternalServerError();
            }
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Report doesn`t exists.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Report founds.", typeof(ReportVm))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportVmModelExample))]
        public IHttpActionResult GetById(string Id)
        {           
            try
            {
                var reportDto = _reportService.GetById(Id);

                if (_validation.IsErrors)
                {
                    return Content(HttpStatusCode.NotFound, _validation.Errors);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        [SwaggerResponse(HttpStatusCode.OK, "Report Delete", typeof(ReportVm))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ReportVmModelExample))]
        public IHttpActionResult DeleteById(string Id)
        {            
            try
            {
                _reportService.Remove(Id);

                if (_validation.IsErrors)
                {
                    return Content(HttpStatusCode.NotFound, _validation.Errors);
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
