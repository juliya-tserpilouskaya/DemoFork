using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using Presentations.Logic.Models.Presentations;

namespace Presentations.Logic.Models.Course
{/// <summary>
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