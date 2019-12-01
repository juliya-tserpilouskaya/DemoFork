using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Models.Course;

namespace Presentations.Logic.Models.Course.InterfacesCourse
{
    interface ICourseBaseService
    {
        IEnumerable<Course> GetAll();

        Course GetById(string id);
        
        Course Add(Course course);
        
        Course Update(Course course);
        
        bool DeleteById(string id);

    }
}
