using BulbaCourses.Analytics.DAL.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using BulbaCourses.Analytics.DAL.Interfaces;

namespace BulbaCourses.Analytics.DAL.Storage
{
    public class ReportStorage: IReportStorage
    {
        private List<Report> _reports = null;

        public List<Report> Storage
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

        private static List<Report> GetReports()
        {
            var generator = new Faker<Report>()
                .StrictMode(true)
                .RuleFor(d => d.Id, _ => "")
                .RuleFor(d => d.Name, _ => _.Commerce.Department())
                .RuleFor(d => d.Description, _ => "Description Department. Stars " + _.Random.Int(1,5).ToString());

            int count = 5;
            var reports = generator.Generate(count);
            
            int number = 1;
            foreach (var report in reports)
            {
                report.Id = number.ToString();
                number++;
            }

            return reports;
        }
    }
}
