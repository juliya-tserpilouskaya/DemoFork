using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ICourseITAcademyServices
    {
        Task<IEnumerable<CoursesITAcademy>> GetAllAsync();
        Task<Result<IEnumerable<Course>>> AddRangeAsync();
    }
}
