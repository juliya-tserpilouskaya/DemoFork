using BulbaCourses.Analytics.Infrastructure.BLL.Models;

namespace BulbaCourses.Analytics.BLL.DTO
{
    public class ReportDto : IReportDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfDashboards { get; set; }
    }
}
