using BulbaCourses.DiscountAggregator.Logic.Models;
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
            return FakerCourseBookmarks.Add(courseBookmark);
        }

        public IEnumerable<CourseBookmark> Delete(string id)
        {
            return FakerCourseBookmarks.Delete(id);
        }

        public IEnumerable<CourseBookmark> GetAll()
        {
            return FakerCourseBookmarks.GetAll();
        }

    }
}
