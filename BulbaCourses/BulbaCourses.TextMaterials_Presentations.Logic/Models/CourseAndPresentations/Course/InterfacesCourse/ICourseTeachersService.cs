using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;

namespace Presentations.Logic.Interfaces
{
    public interface ICourseTeachersService
    {
        IEnumerable<Teacher> GetAll(Course course);

        Teacher GetById(Course course, string id);

        Teacher Add(Course course, Teacher teacher);

        bool DeleteById(Course course, string id);
    }
}
