using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Data
{ 
    public class FeedbackDB
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Text { get; set; }

        public string StudentDBId { get; set; }
        public StudentDB StudentDB { get; set; }

        public string TeacherDBId { get; set; }
        public TeacherDB TeacherDB { get; set; }

        public string PresentationDBId { get; set; }
        public PresentationDB PresentationDB { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;
    }
}