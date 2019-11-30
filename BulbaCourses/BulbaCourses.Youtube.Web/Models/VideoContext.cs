using BulbaCourses.Youtube.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.Controllers
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}