using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public class Bookmark
    {
        //public List<ILearningMaterial> Items { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } //remove set?
        public string BookmarkDescription { get; set; }
    }
}