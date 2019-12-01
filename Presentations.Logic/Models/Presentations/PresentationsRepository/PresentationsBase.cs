using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Models.Presentations
{/// <summary>
/// The list of all Presentations, static, CRUD operations
/// </summary>
    public static class PresentationsBase
    {
        private static List<Presentation> _presentations = new List<Presentation>();

        /// <summary>
        /// Get all Presentations from the all Presentations list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Presentation> GetAll()
        {
            return _presentations.AsReadOnly();
        }

        /// <summary>
        /// Get Presentation from the all Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Presentation GetById(string id)
        {
            return _presentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Presentation to the all Presentations list, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public static Presentation Add(Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            _presentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Find the Presentation whis the same Id from the all Presentations list delete it and add new, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete by Id Presentation from the all Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(string id)
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