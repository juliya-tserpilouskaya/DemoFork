using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;

namespace Presentations.Logic.Models.Presentations
{ 
    public class Feedback
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public User User { get; set; }
    }
}