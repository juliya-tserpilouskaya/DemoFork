using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class SearchStory
    {
        public int Id { get; set; }
        public int SearchRequestId { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime SearchDate { get; set; }
    }
}