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
        IEnumerable<CourseBookmark> GetAll();
        void Add(CourseBookmark courseBookmark);
        void DeleteById(string id);
    }
}
