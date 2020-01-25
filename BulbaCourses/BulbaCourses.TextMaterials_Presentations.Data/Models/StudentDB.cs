using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class StudentDB
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PhoneNumber { get; set; }

        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;

        public bool IsPaid { get; set; } = false;

        public ICollection<FeedbackDB> Feedbacks { get; set; }
        public ICollection<PresentationDB> FavoritePresentations { get; set; }
        public ICollection<PresentationDB> ViewedPresentations { get; set; }

        public StudentDB()
        {
            Feedbacks = new List<FeedbackDB>();
            FavoritePresentations = new List<PresentationDB>();
            ViewedPresentations = new List<PresentationDB>();
        }
    }
}