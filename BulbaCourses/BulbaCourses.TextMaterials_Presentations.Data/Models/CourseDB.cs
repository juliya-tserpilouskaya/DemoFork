using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class CourseDB
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public DateTime? Update { get; set; } = DateTime.Now;

        public ICollection<PresentationDB> CoursePresentations { get; set; }
        public CourseDB()
        {
            CoursePresentations = new List<PresentationDB>();
        }
    }
}