using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{/// <summary>
/// Presentation info
/// </summary>
    public class Presentation
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsAccessible { get; set; }

        public string TeacherId { get; set; }

        public string CourseId { get; set; }

        public IEnumerable<Feedback> Feedback { get; set; }
    }
}