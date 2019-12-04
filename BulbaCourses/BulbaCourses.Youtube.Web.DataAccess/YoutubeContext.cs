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
        public YoutubeContext() : base("YoutubeDbConnection")
        {
        }

        public DbSet<VideoDb> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            var entity = modelBuilder.Entity<VideoDb>();
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Etag).IsRequired();
            entity.Property(x => x.Url).IsRequired().IsUnicode();
            entity.Property(x => x.Title).IsRequired().HasMaxLength(200).IsUnicode();
            entity.Property(x => x.Description).IsRequired().IsUnicode();
            entity.Property(x => x.ChannelId).IsRequired();
            entity.Property(x => x.PublishedAt).IsRequired();
            //entity.HasRequired<CourseOwner>(v => v.Author).WithRequiredDependent(co => co.Id).Map(v => v.MapKey("CourseOwnerId"));
           // entity.HasRequired<Course>(v => v.Course).WithRequiredDependent(co => co.Id).Map(v=>v.MapKey("CourseId"));
        }

        public DbSet<SearchRequest> SearchRequests { get; set; }
    }
}