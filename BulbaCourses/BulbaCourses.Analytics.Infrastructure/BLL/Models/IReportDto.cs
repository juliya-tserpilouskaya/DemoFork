using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.Infrastructure.BLL.Models
{
    public interface IReportDto
    {
        string Description { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        int NumberOfDashboards { get; set; }
    }
}
