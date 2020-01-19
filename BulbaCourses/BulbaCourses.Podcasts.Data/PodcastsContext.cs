using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using BulbaCourses.Podcasts.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using BulbaCourses.Podcasts.Data.Migrations;

namespace BulbaCourses.Podcasts.Data
{
    public class PodcastsContext : DbContext
    {
        public PodcastsContext() : base("PodcastsDbConnection")
        {
            //Database.Log = s => Debug.WriteLine(s);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PodcastsContext, Configuration>());
        }

        public DbSet<AudioDb> Audios { get; set; }
        public DbSet<CommentDb> Comments { get; set; }
        public DbSet<CourseDb> Courses { get; set; }
        public DbSet<UserDb> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}