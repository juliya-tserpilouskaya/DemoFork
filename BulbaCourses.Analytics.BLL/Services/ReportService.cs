using AutoMapper;
using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.BLL.Infrastructure;
using BulbaCourses.Analytics.BLL.Interfaces;
using BulbaCourses.Analytics.DAL.Entities.Reports;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.DAL.Repositories;
using BulbaCourses.Analytics.DAL.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Services
{
    internal partial class ReportService : IReportService
    {
        private IDataBase _context;

        public ReportService(IDataBase context, IDashboardService dashboardService, IRepository<Report> repositoryReport)
        {
            DashboardService = dashboardService;
            _context = context;
            _context.Reports = repositoryReport; 
        }

        public IDashboardService DashboardService { get; }

        public ReportDTO ChangeReport(ReportDTO reportDTO)
        {
            throw new NotImplementedException();
        }

        public void Checked(object obj)
        {
            if (obj == null)
                throw new ValidationException("Not fount Id Report", "Id");
        }

        public ReportDTO CreateReport(ReportDTO reportDTO)
        {
            throw new NotImplementedException();
        }

        public ReportDTO GetReportById(string Id)
        {
            Checked(Id);

            var report = _context.Reports.Read(_ => _.Id == Id);

            Checked(report);

            return new ReportDTO { Id = report.Id, Name = report.Name, Description = report.Description };
        }

        public ReportDTO GetReportByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportShortDTO> GetReportsShort()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportShortDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Report>, List<ReportShortDTO>>(_context.Reports.ReadAll());

        }

        public void RemoveReport(string Id)
        {
            Checked(Id);

            var reports = _context.Reports.Find(_ => _.Id == Id);

            if (reports.ToList().Count == 0)
                throw new ValidationException("Not fount Id Report", "Id");

            _context.Reports.Delete(_ => _.Id == Id);
        }
    }
}
