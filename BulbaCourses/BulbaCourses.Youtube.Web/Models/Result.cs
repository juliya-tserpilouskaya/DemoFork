using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int SearchRequestId { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public List<Video> VideosList { get; set; }
    }
}