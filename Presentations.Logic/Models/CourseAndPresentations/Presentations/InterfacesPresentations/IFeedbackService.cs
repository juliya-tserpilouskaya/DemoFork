using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Pepositories;
using Presentations.Logic.Models;

namespace Presentations.Logic.Interfaces
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetAll(Presentation presentation);

        Feedback GetById(Presentation presentation, string id);

        Feedback Add(Feedback feedback, Presentation presentation, User user);

        bool DeleteById(Presentation presentation, string id);
    }
}
