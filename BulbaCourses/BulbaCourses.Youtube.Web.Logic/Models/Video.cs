using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Logic.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseOwner Author { get; set; }
        public int ChannelId { get; set; }
        public int PlayListId { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Url { get; set; }
        public Course Course { get; set; }
    }
}