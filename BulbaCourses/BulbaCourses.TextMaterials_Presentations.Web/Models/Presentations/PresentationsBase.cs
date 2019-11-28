using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{
    public static class PresentationsBase
    {
        private static List<Presentation> _presentations = new List<Presentation>();

        public static IEnumerable<Presentation> GetAll()
        {
            return _presentations.AsReadOnly();
        }

        public static Presentation GetById(string id)
        {
            return _presentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static Presentation Add(Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            _presentations.Add(presentation);
            return presentation;
        }

        public static Presentation Update(Presentation presentation)
        {
            Presentation deletedPresentation = _presentations.SingleOrDefault(p => p.Id.Equals(presentation.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                _presentations.Remove(deletedPresentation);
                presentation.Id = Guid.NewGuid().ToString();
                _presentations.Add(presentation);
            }
            else
            {
                return deletedPresentation;
            }

            return presentation;
        }

        public static bool DeletById(string id)
        {
            Presentation deletedPresentation = _presentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                _presentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}