using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using Presentations.Logic.Models.Presentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers.Students
{
    public static class ViewedPresentationsOperations
    {  /// <summary>
       /// Get all Presentations from the Viewed Presentations list, returns IEnumerable
       /// </summary>
       /// <param name="student"></param>
       /// <returns></returns>
        public static IEnumerable<Presentation> GetAll(Student student)
        {
            return student.ViewedPresentations.AsReadOnly();
        }

        /// <summary>
        /// Get Presentation from the Viewed Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Presentation GetById(Student student, string id)
        {
            return student.ViewedPresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Presentation to the Viewed Presentations list, returns added Presentation
        /// </summary>
        /// <param name="student"></param>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public static Presentation Add(Student student, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            student.ViewedPresentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Viewed Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(Student student, string id)
        {
            Presentation deletedPresentation = student.ViewedPresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                student.ViewedPresentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}