using System;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class DashboardDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int ChartId { get; set; }

        public string ReportId { get; set; }

        public ReportDb Report { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }
    }
}
