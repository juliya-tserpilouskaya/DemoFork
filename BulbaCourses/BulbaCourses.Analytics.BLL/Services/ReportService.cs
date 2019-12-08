using AutoMapper;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.BLL.Resources;
using BulbaCourses.Analytics.DAL.Context;
using BulbaCourses.Analytics.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

namespace BulbaCourses.Analytics.BLL.Services
{
    public partial class ReportService : IReportService
    {
        private readonly AlfaContext _context = new AlfaContext();
        private readonly IMapper _mapper;
        private readonly IValidation _validation;

        public ReportService(IMapper mapper, IValidation validation)
        {
            _mapper = mapper;
            _validation = validation;
            // if need adding data to uncomment SeedDatabase(_context);
            Debug.WriteLine("+++++++++++++ReportService+++++++++++++++++++");
        }

        static void SeedDatabase(AlfaContext context)
        {
            
            var report = new ReportDb()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Основной отчет",
                Description = "Описание основного отчета",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Creator = "Создатель отчета",
                Modifier = "Модификатор отчета",
                Dashboards = new List<DashboardDb>() {
                    new DashboardDb()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ChartId = 1,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Creator = "Создатель дашборда",
                        Modifier = "Модификатор дашборда",
                        Name = "Дашборд 1"
                    } 
                }
            };
            context.Reports.Add(report);
            context.SaveChanges();
        }

        public ReportDto Update(ReportDto reportDTO)
        {
            throw new NotImplementedException();
        }

        public ReportDto Create(ReportDto reportDTO)
        {
            throw new NotImplementedException();
        }

        public ReportDto GetById(string id)
        {
            if (_validation.IsNull(id, "Id", Resource.NotFoundReportById))
                return null;

            var reportDb = _context.Reports.Where(_ => _.Id == id).FirstOrDefault();

            if (_validation.IsNull(reportDb, "Report", Resource.NotFoundReport))
                return null;

            var reportDto = _mapper.Map<ReportDto>(reportDb);

            return reportDto;
        }

        public ReportDto GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportShortDto> GetAll()
        {
            var reportShortDtos = _context.Reports.Where(_=>true).Select(_ => new ReportShortDto() { Id = _.Id, Name = _.Name }).ToList();

            if (_validation.IsZero(reportShortDtos.Count, "Reports", Resource.NotFoundReports))
                return null;

            return reportShortDtos;
        }

        public void Remove(string id)
        {
            if (_validation.IsNull(id, "Id", Resource.NotFoundReportById))
                return;

            var report = _context.Reports.Include(_ => _.Dashboards).Where(_ => _.Id == id).FirstOrDefault();

            if (_validation.IsNull(report, "Report", Resource.NotFoundReportById))
                return;

            _context.Reports.Remove(report);
            _context.SaveChanges();
        }
    }
}
