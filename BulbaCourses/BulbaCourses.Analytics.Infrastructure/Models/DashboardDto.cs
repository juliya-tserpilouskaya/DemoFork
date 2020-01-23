using System;

namespace BulbaCourses.Analytics.Infrastructure.Models
{
    public class DashboardDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int ChartId { get; set; }

        public string ReportId { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }
    }
}
