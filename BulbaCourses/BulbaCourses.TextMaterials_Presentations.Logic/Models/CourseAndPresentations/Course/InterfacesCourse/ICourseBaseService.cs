using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;

namespace Presentations.Logic.Interfaces
{
    public interface ICourseBaseService
    {
        IEnumerable<Course> GetAll();

        Course GetById(string id);
        
        Course Add(Course course);
        
        Course Update(Course course);
        
        bool DeleteById(string id);

    }
}
