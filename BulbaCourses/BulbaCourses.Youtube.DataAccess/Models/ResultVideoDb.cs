using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class ResultVideoDb
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Definition { get; set; }
        public string Dimension { get; set; }
        public string Duration { get; set; }
        public string VideoCaption { get; set; }
        public string Thumbnail { get; set; }
        public ChannelDb Channel { get; set; } //reference
        public string Channel_Id { get; set; } //reference
        public ICollection<SearchRequestDb> SearchRequests { get; set; } //reference
    }
}