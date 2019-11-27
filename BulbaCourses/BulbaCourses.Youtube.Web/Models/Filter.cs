using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Filter //
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ChannelId { get; set; }
        public int PlayListId { get; set; }
        public string Category { get; set; }
        public string PablishedAt { get; set; }
    }
}