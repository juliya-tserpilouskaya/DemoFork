using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{
    public class CourseBase
    {
        private static List<Course> _courses = new List<Course>();

        /// <summary>
        /// Get all Presentations from the all Presentations list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Course> GetAll()
        {
            return _courses.AsReadOnly();
        }

        /// <summary>
        /// Get Presentation from the all Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Course GetById(string id)
        {
            return _courses.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Presentation to the all Presentations list, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public static Course Add(Course course)
        {
            course.Id = Guid.NewGuid().ToString();
            _courses.Add(course);
            return course;
        }

        /// <summary>
        /// Find the Presentation whis the same Id from the all Presentations list delete it and add new, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
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
        /// Delete by Id Presentation from the all Presentations list, returns true if was deleted
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