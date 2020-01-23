using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Logic.Models
{
    public class SearchStory
    {
        public int? Id { get; set; }
        public bool IsHideForUser { get; set; }
        public DateTime? SearchDate { get; set; }
        public string UserId { get; set; } 
        public SearchRequest SearchRequest { get; set; }//reference
        public int? SearchRequest_Id { get; set; } //reference
    }
}