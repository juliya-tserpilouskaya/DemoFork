using Presentations.Logic.Models.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers.Staff
{
    /// <summary>
    /// The list of Changed Presentations, GetAll, GetById, Add, DeletById methods
    /// </summary>
    public static class ChangedPresentationsOperations
    {
        /// <summary>
        /// Get all Presentations from the Changed Presentations list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Presentation> GetAll(Teacher teacher)
        {
            return teacher.ChangedPresentatons.AsReadOnly();
        }

        /// <summary>
        ///  Get Presentation from the Changed Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Presentation GetById(Teacher teacher, string id)
        {
            return teacher.ChangedPresentatons.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///  Add Presentation to the Changed Presentations list, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public static Presentation Add(Teacher teacher, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            teacher.ChangedPresentatons.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Changed Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(Teacher teacher, string id)
        {
            Presentation deletedPresentation = teacher.ChangedPresentatons.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                teacher.ChangedPresentatons.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}