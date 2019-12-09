using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class SearchRequestDb
    {
        public int? Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ICollection<ResultVideoDb> Videos { get; set; } //reference
        public ICollection<SearchStoryDb> SearchStories { get; set; } //reference
    }
}