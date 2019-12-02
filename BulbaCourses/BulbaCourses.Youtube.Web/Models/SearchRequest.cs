using System;
using System.Collections.Generic;
using System.Linq;
using BulbaCourses.Youtube.Web.App_Start;

namespace BulbaCourses.Youtube.Web.Models
{
    public class SearchRequest
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string VideoId { get; set; }
        [SwaggerDefaultValue("doggie")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Channel { get; set; }
        public string PlayList { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Url { get; set; }
    }
}