using BulbaCourses.Analytics.Infrastructure.DAL;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface IDataBase
    {
        IReportRepository Reports { get; set; }

        IReportRepository Dashboards { get; }        

        void Dispose();
    }
}
