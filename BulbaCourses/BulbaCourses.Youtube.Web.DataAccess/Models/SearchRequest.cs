using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class SearchRequest
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Channel { get; set; }
        public string PlayList { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Url { get; set; }
    }
}