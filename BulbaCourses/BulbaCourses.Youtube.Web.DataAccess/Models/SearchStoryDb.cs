using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class SearchStoryDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime? SearchDate { get; set; }
        public UserDb User { get; set; } //reference
        public SearchRequestDb SearchRequest { get; set; } //reference
    }
}