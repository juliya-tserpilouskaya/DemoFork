using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Logic.Models
{
    public class SearchRequest
    {
        public int? Id { get; set; } 
        public string Title { get; set; }
        public string CacheId { get; set; }
        public DateTime? PublishedBefore { get; set; }
        public DateTime? PublishedAfter { get; set; }
        public string Definition { get; set; } = "Any";
        public string Dimension { get; set; } = "Any";
        public string Duration { get; set; } = "Any";
        public string VideoCaption { get; set; } = "Any";
        public ICollection<ResultVideo> Videos { get; set; }

    }
}