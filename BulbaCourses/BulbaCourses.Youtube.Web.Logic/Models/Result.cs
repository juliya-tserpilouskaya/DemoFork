using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Logic.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string SearchRequestId { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public IEnumerable<Video> VideosList { get; set; }
    }
}