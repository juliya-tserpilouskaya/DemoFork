using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{/// <summary>
/// Employee info
/// </summary>
    public class Teacher
    {
        public IEnumerable<Presentation> ChangedPresentatons { get; set; }
    }
}