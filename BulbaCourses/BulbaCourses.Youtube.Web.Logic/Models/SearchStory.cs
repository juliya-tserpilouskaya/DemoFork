using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Logic.Models
{
    public class SearchStory
    {
        public int? Id { get; set; }
        public DateTime? SearchDate { get; set; }
        public User User { get; set; } //reference
        public SearchRequest SearchRequest { get; set; }//reference
    }
}