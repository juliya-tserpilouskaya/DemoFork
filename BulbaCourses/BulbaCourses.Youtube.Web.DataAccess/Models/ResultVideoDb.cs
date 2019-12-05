using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class ResultVideoDb
    {
        public int Id { get; set; }
        public string Etag { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Description { get; set; }
        public ChannelDb Channel { get; set; } //reference
        public ICollection<SearchRequestDb> SearchRequests { get; set; } //reference
        //public int PlayListId { get; set; }
        //public Course Course { get; set; }
    }
}