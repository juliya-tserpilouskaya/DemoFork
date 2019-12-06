using System;
using System.Collections.Generic;
using System.Linq;
using Presentations.Logic.Pepositories;
using Presentations.Logic.Interfaces;

namespace Presentations.Logic.Services
{
    public class ViewedPresentationsService : IViewedPresentationsService
    {
        /// <summary>
        /// Get all Presentations from the Viewed Presentations list, returns IEnumerable
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IEnumerable<Presentation> GetAll(Student student)
        {
            return student.ViewedPresentations.AsReadOnly();
        }

        /// <summary>
        /// Get Presentation from the Viewed Presentations list by Id, returns Presentation
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Presentation GetById(Student student, string id)
        {
            return student.ViewedPresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Presentation to the Viewed Presentations list, returns added Presentation
        /// </summary>
        /// <param name="student"></param>
        /// <param name="presentation"></param>
        /// <returns></returns>
        public  Presentation Add(Student student, Presentation presentation)
        {
            presentation.Id = Guid.NewGuid().ToString();
            student.ViewedPresentations.Add(presentation);
            return presentation;
        }

        /// <summary>
        /// Delete by Id Presentation from the Viewed Presentations list, returns true if was deleted
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public  bool DeleteById(Student student, string id)
        {
            Presentation deletedPresentation = student.ViewedPresentations.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                student.ViewedPresentations.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
