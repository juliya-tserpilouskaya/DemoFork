using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Models.Course.InterfacesCourse;

namespace Presentations.Logic.Models.Course.CourseServices
{
    class CourseBaseService : ICourseBaseService
    {
        public Course Add(Course course)
        {
            return CourseBase.Add(course);
        }

        public bool DeleteById(string id)
        {
            return CourseBase.DeleteById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return CourseBase.GetAll();
        }

        public Course GetById(string id)
        {
            return CourseBase.GetById(id);
        }

        public Course Update(Course course)
        {
            return CourseBase.Update(course);
        }
    }
}
