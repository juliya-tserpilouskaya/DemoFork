using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentations.Logic.Models.Presentations;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{/// <summary>
/// Teacher info
/// </summary>
    public class Teacher : User
    {
        public List<Presentation> ChangedPresentatons { get; set; }
    }
}