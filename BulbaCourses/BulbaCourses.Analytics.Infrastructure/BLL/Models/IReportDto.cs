namespace BulbaCourses.Analytics.Infrastructure.BLL.Models
{
    public interface IReportDto
    {
        string Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        int NumberOfDashboards { get; set; }
    }
}
