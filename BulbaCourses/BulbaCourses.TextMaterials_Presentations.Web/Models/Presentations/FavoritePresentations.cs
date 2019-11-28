using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{/// <summary>
/// The list of Favorite Presentations, GetAll, GetById, Add, DeletById methods
/// </summary>
    public class FavoritePresentations
    {
        private List<Presentation> _favoritePresentations = new List<Presentation>();

        /// <summary>
        /// Get all Presentations from the Favorite Presentations list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Presentation> GetAll()
        {
            return _favoritePresentations.AsReadOnly();
        }

        /// <summary>
        ///  Get Presentation from the Favorite Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Presentation GetById(string id)
        {
            return _favoritePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///  Add Presentation to the Favorite Presentations list, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public Presentation Add(Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            _favoritePresentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Favorite Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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