using System.Collections.Generic;

namespace BulbaCourses.Analytics.Infrastructure.DAL.Models
{
    public interface IReportDb: IAuditModel
    {
        string Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        ICollection<IDashboardDb> Dashboards { get; set; }
    }
}
