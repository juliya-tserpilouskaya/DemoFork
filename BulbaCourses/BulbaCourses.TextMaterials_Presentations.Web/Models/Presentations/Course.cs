using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{
    public class Course
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Presentation> Presentations { get; set; }
    }
}