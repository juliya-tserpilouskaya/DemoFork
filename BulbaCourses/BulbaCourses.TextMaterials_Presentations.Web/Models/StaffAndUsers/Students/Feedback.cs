using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{
    public class Feedback
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public User User { get; set; }
    }
}