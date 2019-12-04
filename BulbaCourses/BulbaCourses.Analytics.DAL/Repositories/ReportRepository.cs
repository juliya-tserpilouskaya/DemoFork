using BulbaCourses.Analytics.DAL.Entities.Reports;
using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class ReportRepository : AbstractRepository<Report>
    {
        public ReportRepository(IReportStorage context) :
            base(context.Storage)
        { }
    }
}
