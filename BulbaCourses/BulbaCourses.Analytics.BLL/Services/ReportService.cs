using AutoMapper;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.BLL.Resources;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.Infrastructure.BLL.Models;
using BulbaCourses.Analytics.Infrastructure.BLL.Services;
using BulbaCourses.Analytics.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.BLL.Services
{
    internal partial class ReportService : IReportService
    {
        private readonly IDataBase _context;
        private readonly IMapper _mapper;

        public ReportService(IDataBase context, IReportRepository repositoryReport, IMapper mapper)
        {            
            _context = context;
            _context.Reports = repositoryReport;
            _mapper = mapper;
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

            var reportDb = _context.Reports.Find(_ => _.Id == id).FirstOrDefault();

            if (Validation.IsNull(reportDb, "Report", Resource.NotFoundReport))
                return null;

            var reportDto = _mapper.Map<IReportDto>(reportDb);

            return reportDto;
        }

        public IReportDto GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReportDto> GetAll()
        {
            var reportDbs = _context.Reports.Find(_ => true);
            var reportDtos = _mapper.Map<IEnumerable<IReportDto>>(reportDbs); // TODO: need refactoring!!
            return reportDtos;
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
