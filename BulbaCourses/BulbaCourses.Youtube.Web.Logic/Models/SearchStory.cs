using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Logic.Models
{
    public class SearchStory
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public DateTime SearchDate { get; set; }
        public SearchRequest SearchRequest { get; set; }
    }
}