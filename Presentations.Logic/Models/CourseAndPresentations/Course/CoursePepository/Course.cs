using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Pepositories
{
    /// <summary>
    /// Have id, name, Teachers and Presentations Lists
    /// </summary>
    public class Course
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Teacher> CourseTeachers { get; set; }

        public List<Presentation> CoursePresentations { get; set; }
    }
}