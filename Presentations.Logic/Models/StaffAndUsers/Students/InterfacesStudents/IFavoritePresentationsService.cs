using Presentations.Logic.Pepositories;
using System.Collections.Generic;

namespace Presentations.Logic.Interfaces
{
    public interface IFavoritePresentationsService
    {
        IEnumerable<Presentation> GetAll(Student student);
        Presentation GetById(Student student, string id);
        Presentation Add(Student student, Presentation presentation);
        bool DeleteById(Student student, string id);
    }
}