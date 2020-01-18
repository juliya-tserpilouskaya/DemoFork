using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ICourseITAcademyServiceDb
    {
        Task<Result<IEnumerable<CourseDb>>> AddRangeAsync(IEnumerable<CourseDb> coursesDb);
    }
}
