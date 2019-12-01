using System;
using System.Collections.Generic;
using System.Text;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace Presentations.Logic.Models.Course.InterfacesCourse
{
    public interface ICourseTeachersService
    {
        IEnumerable<Teacher> GetAll(Course course);

        Teacher GetById(Course course, string id);

        Teacher Add(Course course, Teacher teacher);

        bool DeleteById(Course course, string id);
    }
}
