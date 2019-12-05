using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class ReportDb : IReportDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }

        public ICollection<IDashboardDb> Dashboards { get; set; }
    }
}
