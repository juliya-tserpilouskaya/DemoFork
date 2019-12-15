using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseBookmarkServices : ICourseBookmarkServices
    {
        public CourseBookmark Add(CourseBookmark courseBookmark)
        {
            return CourseBookmarksStorage.Add(courseBookmark);
        }

        public IEnumerable<CourseBookmark> Delete(string id)
        {
            return CourseBookmarksStorage.Delete(id);
        }

        public IEnumerable<CourseBookmark> GetAll()
        {
            return CourseBookmarksStorage.GetAll();
        }

    }
}
