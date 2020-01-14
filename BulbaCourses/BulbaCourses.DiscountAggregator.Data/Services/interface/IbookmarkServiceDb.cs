using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IBookmarkServiceDb
    {
        Task<IEnumerable<CourseBookmarkDb>> GetByUserIdAsync(string userId);
        Task<bool> AddAsync(CourseBookmarkDb bookmarkDb);
        Task<bool> DeleteAsync(CourseBookmarkDb bookmarkDb);
    }
}
