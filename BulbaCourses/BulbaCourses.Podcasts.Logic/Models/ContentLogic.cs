using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class ContentLogic
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public AudioLogic Audio { get; set; }
    }
    
}