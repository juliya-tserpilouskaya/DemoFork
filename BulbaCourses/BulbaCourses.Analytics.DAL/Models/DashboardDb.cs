using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class DashboardDb : IAuditModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }

        public int ChartId { get; set; }

        public string ReportId { get; set; }

        public ReportDb Report { get; set; }
    }
}
