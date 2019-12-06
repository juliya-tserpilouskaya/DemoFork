using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;

namespace Presentations.Logic.Interfaces
{
    public interface IPresentationsBaseService
    {
        IEnumerable<Presentation> GetAll();

        Presentation GetById(string id);

        Presentation Add(Presentation presentation);

        Presentation Update(Presentation presentation);

        bool DeleteById(string id);
    }
}
