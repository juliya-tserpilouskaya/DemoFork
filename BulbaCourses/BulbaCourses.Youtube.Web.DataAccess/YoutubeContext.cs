using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess
{
    public class YoutubeContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<SearchRequest> SearchRequests { get; set; }
    }
}