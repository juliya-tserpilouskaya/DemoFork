using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class SearchStoryDb
    {
        public int? Id { get; set; }
        public bool IsHideForUser { get; set; } = false;
        public DateTime? SearchDate { get; set; }
        public string UserId { get; set; } 
        public SearchRequestDb SearchRequest { get; set; } //reference

        public int? SearchRequest_Id { get; set; } //reference
    }
}