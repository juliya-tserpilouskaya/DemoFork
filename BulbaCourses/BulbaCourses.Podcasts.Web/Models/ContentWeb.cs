using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Web.Models
{
    public class ContentWeb
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public AudioWeb Audio { get; set; }
    }
    
}