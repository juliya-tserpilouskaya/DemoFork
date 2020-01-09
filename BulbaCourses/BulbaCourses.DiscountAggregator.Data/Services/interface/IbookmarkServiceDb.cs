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
        IEnumerable<CourseBookmarkDb> GetAll();
        void Add(CourseBookmarkDb courseDb);
        void Delete(CourseBookmarkDb courseDb);
        //Task<bool> ExistsAsync(string login);
    }
}
