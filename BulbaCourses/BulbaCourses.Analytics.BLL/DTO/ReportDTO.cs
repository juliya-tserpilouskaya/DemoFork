using System;

namespace BulbaCourses.Analytics.BLL.DTO
{
    public class ReportDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }

        public int NumberOfDashboards { get; set; }
    }
}
