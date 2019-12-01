using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Models.Presentations;

namespace Presentations.Logic.Models.Course.InterfacesCourse
{
    interface ICoursePresentationsService
    {
        IEnumerable<Presentation> GetAll(Course course);

        Presentation GetById(Course course, string id);

        Presentation Add(Course course, Presentation presentation);

        bool DeleteById(Course course, string id);
    }
}
