using AutoMapper;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.BLL.Resources;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.Infrastructure.BLL.Models;
using BulbaCourses.Analytics.Infrastructure.BLL.Services;
using BulbaCourses.Analytics.Infrastructure.DAL;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.BLL.Services
{
    internal partial class ReportService : IReportService
    {
        private readonly IDataBase _context;

        public ReportService(IDataBase context, IReportRepository repositoryReport)
        {            
            _context = context;
            _context.Reports = repositoryReport;
        }              

        public IReportDto Update(IReportDto reportDTO)
        {
            throw new NotImplementedException();
        }        

        public IReportDto Create(IReportDto reportDTO)
        {
            throw new NotImplementedException();
        }

        public IReportDto GetById(string id)
        {
            if (Validation.IsNull(id, "Id", Resource.NotFoundReportById))
                return null;

            var report = _context.Reports.Find(_ => _.Id == id).FirstOrDefault();

            if (Validation.IsNull(report, "Report", Resource.NotFoundReport))
                return null;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IReportDb, IReportDto>()).CreateMapper();
            return mapper.Map<IReportDb, IReportDto>(report);
        }

        public IReportDto GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReportDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IReportDb, IReportDto>()).CreateMapper();
            return mapper.Map<IEnumerable<IReportDb>, List<IReportDto>>(_context.Reports.Find(_ => true)); // TODO: need refactoring!!

        }

        public void Remove(string id)
        {
            if (Validation.IsNull(id, "Id", Resource.NotFoundReportById))
                return;

            var reports = _context.Reports.Find(_ => _.Id == id);

            if (Validation.IsEmty(!reports.Any(), "Report", Resource.NotFoundReportById))
                return;

            _context.Reports.Delete(reports.FirstOrDefault());
        }        
    }
}
