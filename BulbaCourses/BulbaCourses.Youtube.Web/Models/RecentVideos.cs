using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class RecentVideos //пока получается в точности как FavoritesVideos
    {
        public int Id { get; set; }
        public IEnumerable<Video> Videos { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //public int SearchStoryId { get; set; }
        //public SearchStory SearchStory { get; set; }
    }
}