using BulbaCourses.Analytics.Infrastructure.DAL.Models;

namespace BulbaCourses.Analytics.DAL.Models
{
    public class ChartDb : IChartDb
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
