using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class ReportDb: IAuditModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }

        public ICollection<DashboardDb> Dashboards { get; set; }
    }
}
