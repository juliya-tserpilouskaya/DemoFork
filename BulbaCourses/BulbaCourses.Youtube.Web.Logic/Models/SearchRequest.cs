using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Logic.Models
{
    public class SearchRequest
    {
        public int? Id { get; set; } 
        public int? UserId { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string ChannelTitle { get; set; }
        public DateTime? PublishedBefore { get; set; }
        public DateTime? PublishedAfter { get; set; }
        public string Definition { get; set; } = "Any";
        public string Dimension { get; set; } = "Any";
        public string Duration { get; set; } = "Any";
        public string VideoCaption { get; set; } = "Any";

    }
}