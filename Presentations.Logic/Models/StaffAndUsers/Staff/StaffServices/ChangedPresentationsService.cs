using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentations.Logic.Pepositories;
using Presentations.Logic.Interfaces;

namespace Presentations.Logic.Services
{
    public class ChangedPresentationsService : IChangedPresentationsService
    {
        /// <summary>
        /// Get all Presentations from the Changed Presentations list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Presentation> GetAll(Teacher teacher)
        {
            return teacher.ChangedPresentatons.AsReadOnly();
        }

        /// <summary>
        ///  Get Presentation from the Changed Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Presentation GetById(Teacher teacher, string id)
        {
            return teacher.ChangedPresentatons.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///  Add Presentation to the Changed Presentations list, returns added Presentation
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public Presentation Add(Teacher teacher, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            teacher.ChangedPresentatons.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Changed Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(Teacher teacher, string id)
        {
            Presentation deletedPresentation = teacher.ChangedPresentatons.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                teacher.ChangedPresentatons.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
