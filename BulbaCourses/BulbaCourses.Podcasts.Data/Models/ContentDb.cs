using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Data.Models
{
    public class ContentDb
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public AudioDb Audio { get; set; }
    }
    
}