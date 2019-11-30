using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{
    public class CoursePresentationsOperations
    {        /// <summary>
             /// Get all Presentations from the Course Presentations list, returns IEnumerable
             /// </summary>
             /// <returns></returns>
        public static IEnumerable<Presentation> GetAll(Course course)
        {
            return course.Presentations.AsReadOnly();
        }

        /// <summary>
        ///  Get Presentation from the Course Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Presentation GetById(Course course, string id)
        {
            return course.Presentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///  Add Presentation to the Course Presentations list, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public static Presentation Add(Course course, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            course.Presentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Course Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(Course course, string id)
        {
            Presentation deletedPresentation = course.Presentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                course.Presentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}