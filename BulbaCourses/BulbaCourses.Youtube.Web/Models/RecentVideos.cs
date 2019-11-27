using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class RecentVideos //
    {
        public int Id { get; set; }
        public List<Video> Videos { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //public int SearchStoryId { get; set; }
        //public SearchStory SearchStory { get; set; }
    }
}