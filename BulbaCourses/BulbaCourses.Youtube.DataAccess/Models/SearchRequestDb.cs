using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class SearchRequestDb
    {
        public int? Id { get; set; }
        public string CacheId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishedBefore { get; set; }
        public DateTime? PublishedAfter { get; set; }
        public string Definition { get; set; }
        public string Dimension { get; set; }
        public string Duration { get; set; }
        public string VideoCaption { get; set; }
        public ICollection<ResultVideoDb> Videos { get; set; } //reference
        public ICollection<SearchStoryDb> SearchStories { get; set; } //reference
    }
}