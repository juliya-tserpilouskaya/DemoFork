using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.Infrastructure.DAL.Models
{
    public interface IDashboardDb: IAuditModel
    {
        int ChartId { get; set; }

        string Id { get; set; }

        string Name { get; set; }

        IReportDb Report { get; set; }

        string ReportId { get; set; }
    }
}
