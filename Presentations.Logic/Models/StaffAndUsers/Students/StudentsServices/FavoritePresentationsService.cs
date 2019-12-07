using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentations.Logic.Pepositories;
using Presentations.Logic.Interfaces;

namespace Presentations.Logic.Services
{
    public class FavoritePresentationsService : IFavoritePresentationsService
    {
        /// <summary>
        /// Get all Presentations from the Favorite Presentations list, returns IEnumerable
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IEnumerable<Presentation> GetAll(Student student)
        {
            return student.FavoritePresentations.AsReadOnly();
        }

        /// <summary>
        /// Get Presentation from the Favorite Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Presentation GetById(Student student, string id)
        {
            return student.FavoritePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Presentation to the Favorite Presentations list, returns added Presentation
        /// </summary>
        /// <param name="student"></param>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public Presentation Add(Student student, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            student.FavoritePresentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Favorite Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(Student student, string id)
        {
            Presentation deletedPresentation = student.FavoritePresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                student.FavoritePresentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
