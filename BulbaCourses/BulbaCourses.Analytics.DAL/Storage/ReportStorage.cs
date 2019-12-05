using Bogus;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.DAL.Storage
{
    public class ReportStorage : IReportStorage
    {
        private List<IReportDb> _reports = null;

        public List<IReportDb> Storage
        {
            get
            {
                if (_reports == null)
                {
                    _reports = GetReports();
                }
                return _reports;
            }
        }

        private static List<IReportDb> GetReports()
        {
            var generator = new Faker<ReportDb>()
                .StrictMode(true)
                .RuleFor(d => d.Id, _ => "")
                .RuleFor(d => d.Name, _ => _.Commerce.Department())
                .RuleFor(d => d.Description, _ => "Description Department. Stars " + _.Random.Int(1, 5).ToString())
                .RuleFor(d => d.Created, _ => DateTime.UtcNow)
                .RuleFor(d => d.Creator, _ => _.Name.FullName())
                .RuleFor(d => d.Dashboards, _ => null)
                .RuleFor(d => d.Modified, _ => DateTime.UtcNow)
                .RuleFor(d => d.Modifier, _ => _.Name.FullName());

            int count = 5;
            var reports = generator.Generate(count);

            List<IReportDb> ireports = new List<IReportDb>();

            int number = 1;
            foreach (var report in reports)
            {
                report.Id = number.ToString();
                ireports.Add(report);
                number++;
            }           

            return ireports;
        }
    }
}
