using System;
using System.Collections.Generic;
using System.Text;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace Presentations.Logic.Models.Presentations.InterfacesPresentations
{
    interface IFeedbackService
    {
        IEnumerable<Feedback> GetAll(Presentation presentation);

        Feedback GetById(Presentation presentation, string id);

        Feedback Add(Feedback feedback, Presentation presentation, User user);

        bool DeleteById(Presentation presentation, string id);
    }
}
