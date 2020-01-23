using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ICourseBookmarkServices
    {
        Task<IEnumerable<CourseBookmark>> GetByUserIdAsync(string userId);
        Task<Result<CourseBookmark>> AddAsync(CourseBookmark courseBookmark);
        Task<Result<CourseBookmark>> DeleteAsync(CourseBookmark courseBookmark);
    }
}
