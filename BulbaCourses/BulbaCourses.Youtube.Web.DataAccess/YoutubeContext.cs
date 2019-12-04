using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess
{
    public class YoutubeContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<SearchRequest> SearchRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StoryConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());
        }
    }

    public class StoryConfiguration : EntityTypeConfiguration<SearchStory>
    {
        public StoryConfiguration()
        {
            ToTable("SearchStories").HasKey(p => p.Id);           
        }
    }

    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            ToTable("SearchResults").HasKey(p => p.Id);
            HasRequired(r => r.SearchRequest);
   
        }
    }
}