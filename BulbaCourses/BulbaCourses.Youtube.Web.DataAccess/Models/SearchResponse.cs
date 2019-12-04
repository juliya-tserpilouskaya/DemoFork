using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class SearchResponse
    {
        public int Id { get; set; }
        public string Etag { get; set; }
        public string SearchRequestId { get; set; }
        public SearchRequest SearchRequest { get; set; }
        public IEnumerable<VideoDb> VideosList { get; set; }
    }
}