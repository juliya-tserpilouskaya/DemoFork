using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Logic.Models
{
    public class ResultVideo
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
        public Channel Channel { get; set; }//reference
        public string Channel_Id { get; set; } //reference

    }
}