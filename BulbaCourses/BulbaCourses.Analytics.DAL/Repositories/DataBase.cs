using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.Infrastructure.DAL;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class DataBase : IDataBase
    {
        public IReportRepository Reports { get; set; }

        public IReportRepository Dashboards { get; }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
