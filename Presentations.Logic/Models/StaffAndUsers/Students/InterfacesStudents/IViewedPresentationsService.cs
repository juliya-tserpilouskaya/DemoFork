using Presentations.Logic.Pepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentations.Logic.Interfaces
{
    public interface IViewedPresentationsService
    {
        IEnumerable<Presentation> GetAll(Student student);
        Presentation GetById(Student student, string id);
        Presentation Add(Student student, Presentation presentation);
        bool DeleteById(Student student, string id);
    }
}
