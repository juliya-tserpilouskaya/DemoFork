using Presentations.Logic.Pepositories;
using System.Collections.Generic;

namespace Presentations.Logic.Interfaces
{
    public interface IChangedPresentationsService
    {
        IEnumerable<Presentation> GetAll(Teacher teacher);

        Presentation GetById(Teacher teacher, string id);

        Presentation Add(Teacher teacher, Presentation presentation);

        bool DeleteById(Teacher teacher, string id);
    }
}