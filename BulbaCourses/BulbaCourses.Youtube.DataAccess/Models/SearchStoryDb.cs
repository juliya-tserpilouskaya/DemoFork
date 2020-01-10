using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class SearchStoryDb
    {
        public int? Id { get; set; }
        public DateTime? SearchDate { get; set; }
        public UserDb User { get; set; } //reference
        public SearchRequestDb SearchRequest { get; set; } //reference
    }
}