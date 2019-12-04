using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Pepositories
{
    public class CourseBase
    {
        private static List<Course> _courses = new List<Course>();

        /// <summary>
        /// Get all Courses from the all Courses list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Course> GetAll()
        {
            return _courses.AsReadOnly();
        }

        /// <summary>
        /// Get Course by Id from the all Courses list, returns Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Course GetById(string id)
        {
            return _courses.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Course in the all Courses list, returns added Course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static Course Add(Course course)
        {
            course.Id = Guid.NewGuid().ToString();
            _courses.Add(course);
            return course;
        }

        /// <summary>
        /// Update Course in the all Courses list, returns updated Course or null if isn't course whis the same Id
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static Course Update(Course course)
        {
            Course deletedCourse = _courses.SingleOrDefault(p => p.Id.Equals(course.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedCourse != null)
            {
                _courses.Remove(deletedCourse);
                course.Id = Guid.NewGuid().ToString();
                _courses.Add(course);
            }
            else
            {
                return deletedCourse;
            }

            return course;
        }

        /// <summary>
        /// Delete by Id Course from the all Courses list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(string id)
        {
            Course deletedCourse = _courses.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedCourse != null)
            {
                _courses.Remove(deletedCourse);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}