using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Data
{   
    public class PresentationDB
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }

        public bool IsAccessible { get; set; }

        public string TeacherDBId { get; set; }
        public TeacherDB TeacherDB { get; set; }

        public string CourseDBId { get; set; }
        public CourseDB CourseDB { get; set; }

        public DateTime? DateUpdate { get; set; } = DateTime.Now;

        public ICollection<FeedbackDB> Feedbacks { get; set; }
        public ICollection<StudentDB> Students { get; set; }
        public ICollection<StudentDB> ViewedByStudents { get; set; }

        public PresentationDB()
        {
            Feedbacks = new List<FeedbackDB>();
            Students = new List<StudentDB>();
            ViewedByStudents = new List<StudentDB>();
        }
    }
}