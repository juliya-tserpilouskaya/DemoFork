using System;
using System.Collections.Generic;
using System.Text;

namespace Presentations.Logic.Models.Presentations.InterfacesPresentations
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
