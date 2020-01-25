using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class TeacherDB
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PhoneNumber { get; set; }

        public string Position { get; set; }

        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;

        public ICollection<FeedbackDB> Feedbacks { get; set; }
        public ICollection<PresentationDB> ChangedPresentatons { get; set; }

        public TeacherDB()
        {
            Feedbacks = new List<FeedbackDB>();
            ChangedPresentatons = new List<PresentationDB>();
        }
    }
}