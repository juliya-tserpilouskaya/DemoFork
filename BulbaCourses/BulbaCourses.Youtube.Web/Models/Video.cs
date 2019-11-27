using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Video
    {
        public int Id { get; set; }
        public CourseOwner Author { get; set; }
        public string ChannelId { get; set; }
        public string PlayListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime PablishedDate { get; set; }
        public string CourseName { get; set; }

        // public User Author { get; set; }
    }
}