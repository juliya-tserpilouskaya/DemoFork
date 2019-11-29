using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{/// <summary>
/// User info
/// </summary>
    public class Student : User
    {
        public bool IsPaid { get; set; }

        public IEnumerable<FavoritePresentations> FavoritePresentations { get; set; }
    }
}