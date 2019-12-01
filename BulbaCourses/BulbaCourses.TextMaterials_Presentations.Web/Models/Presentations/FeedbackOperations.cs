using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{
    /// <summary>
    /// The list of Feedbacks, GetAll, GetById, Add, DeletById methods
    /// </summary>
    /// 
    public class FeedbackOperations
    {
        /// <summary>
        /// Get all Feedbacks from the Presentation, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Feedback> GetAll(Presentation presentation)
        {
            return presentation.Feedback.AsReadOnly();
        }

        /// <summary>
        ///  Get Feedback from the Presentation Feedbacks List by Id, returns Feedback
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Feedback GetById(Presentation presentation, string id)
        {
            return presentation.Feedback.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///  Add Feedback to the Presentations Feedbacks list, returns added Feedback
        /// </summary>
        /// <returns></returns>
        public static Feedback Add(Feedback feedback, Presentation presentation, User user)
        {
            feedback.Id = Guid.NewGuid().ToString();
            feedback.User = user;
            presentation.Feedback.Add(feedback);
            return feedback;
        }

        /// <summary>
        /// Delete by Id Feedback from the Presentations Feedbacks list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(Presentation presentation, string id)
        {
            Feedback deletedPresentation = presentation.Feedback.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                presentation.Feedback.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }


    }
}