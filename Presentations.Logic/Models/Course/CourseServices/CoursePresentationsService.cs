using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;
using Presentations.Logic.Models.Course.InterfacesCourse;

namespace Presentations.Logic.Models.Course
{
    public class CoursePresentationsService : ICoursePresentationsService
    {   /// <summary>
        /// Get all Presentations from the Course Presentations list, returns IEnumerable
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public IEnumerable<Presentation> GetAll(Course course)
        {
            return course.CoursePresentations.AsReadOnly();
        }

        /// <summary>
        /// Get Presentation from the Course Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="course"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Presentation GetById(Course course, string id)
        {
            return course.CoursePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Presentation to the Course Presentations list, returns added Presentation
        /// </summary>
        /// <param name="course"></param>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public Presentation Add(Course course, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            course.CoursePresentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Course Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="course"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(Course course, string id)
        {
            Presentation deletedPresentation = course.CoursePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                course.CoursePresentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}