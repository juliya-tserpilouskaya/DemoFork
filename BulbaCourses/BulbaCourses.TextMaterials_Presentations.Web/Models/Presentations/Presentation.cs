using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.Presentations
{/// <summary>
/// Presentation info
/// </summary>
    public class Presentation
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsAccessible { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsViewed { get; set; }
    }
}