using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;

namespace Presentations.Logic.Interfaces
{
    public interface ICoursePresentationsService
    {
        IEnumerable<Presentation> GetAll(Course course);

        Presentation GetById(Course course, string id);

        Presentation Add(Course course, Presentation presentation);

        bool DeleteById(Course course, string id);
    }
}
