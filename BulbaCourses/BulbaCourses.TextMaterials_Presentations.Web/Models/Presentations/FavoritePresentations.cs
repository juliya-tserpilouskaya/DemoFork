using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{
    public class FavoritePresentations
    {
        private List<Presentation> _favoritePresentations = new List<Presentation>();

        public IEnumerable<Presentation> GetAll()
        {
            return _favoritePresentations.AsReadOnly();
        }

        public Presentation GetById(string id)
        {
            return _favoritePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public Presentation Add(Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            _favoritePresentations.Add(presentation);
            return presentation;
        }

        public bool DeletById(string id)
        {
            Presentation deletedPresentation = _favoritePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                _favoritePresentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}