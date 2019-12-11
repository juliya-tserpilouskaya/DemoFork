using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Pepositories;

namespace Presentations.Logic.Services
{
    class PresentationsBaseService : IPresentationsBaseService
    {
        public Presentation Add(Presentation presentation)
        {
            return PresentationsBase.Add(presentation);
        }

        public bool DeleteById(string id)
        {
            return PresentationsBase.DeleteById(id);
        }

        public IEnumerable<Presentation> GetAll()
        {
            return PresentationsBase.GetAll();
        }

        public Presentation GetById(string id)
        {
            return PresentationsBase.GetById(id);
        }

        public Presentation Update(Presentation presentation)
        {
            return PresentationsBase.Update(presentation);
        }
    }
}
