using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.DataAccess
{
    public class YoutubeContext : DbContext
    {
        public YoutubeContext() : base("YoutubeDbConnection")
        {
            Database.Log = s => Debug.WriteLine(s);
            Database.SetInitializer(new DropCreateDatabaseAlways<YoutubeContext>());
        }

        public DbSet<ResultVideoDb> Videos { get; set; }
        public DbSet<ChannelDb> Channels { get; set; }
        public DbSet<MentorDb> Mentors { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<SearchRequestDb> SearchRequests { get; set; }
        public DbSet<SearchStoryDb> SearchStories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ResultVideoDb
            var ResultVideoDbEntity = modelBuilder.Entity<ResultVideoDb>();
            ResultVideoDbEntity.HasKey(x => x.Id);
            ResultVideoDbEntity.Property(x => x.Title).IsRequired().HasMaxLength(200).IsUnicode();
            ResultVideoDbEntity.Property(x => x.Description).IsRequired().IsUnicode();
            ResultVideoDbEntity.Property(x => x.PublishedAt).IsRequired();
            ResultVideoDbEntity.Property(x => x.Definition).IsRequired();
            ResultVideoDbEntity.Property(x => x.Dimension).IsRequired();
            ResultVideoDbEntity.Property(x => x.Duration).IsRequired();
            ResultVideoDbEntity.Property(x => x.VideoCaption).IsRequired();
            ResultVideoDbEntity.Property(x => x.Thumbnail).IsRequired();

            ResultVideoDbEntity.HasMany<SearchRequestDb>(x => x.SearchRequests).WithMany(x=>x.Videos);

            //ChannelDb
            var ChannelDbEentity = modelBuilder.Entity<ChannelDb>();
            ChannelDbEentity.HasKey(x => x.Id);
            ChannelDbEentity.Property(x => x.Name).IsRequired().HasMaxLength(200).IsUnicode();
            ChannelDbEentity.HasOptional<MentorDb>(x => x.Mentor);
            ChannelDbEentity.HasMany<ResultVideoDb>(x => x.Videos).WithRequired(x=>x.Channel);

            //MentorDb
            var MentorDbEentity = modelBuilder.Entity<MentorDb>();
            MentorDbEentity.HasMany<ChannelDb>(x => x.Channels).WithOptional(x=>x.Mentor);

            //UserDb
            var UserDbEentity = modelBuilder.Entity<UserDb>();
            UserDbEentity.HasKey(x => x.Id);
            UserDbEentity.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            UserDbEentity.Property(x => x.Login).IsRequired().HasMaxLength(100).IsUnicode();
            UserDbEentity.Property(x => x.Password).IsRequired().HasMaxLength(100).IsUnicode();
            UserDbEentity.Property(x => x.FirstName).IsRequired().HasMaxLength(100).IsUnicode();
            UserDbEentity.Property(x => x.LastName).IsRequired().HasMaxLength(100).IsUnicode();
            UserDbEentity.Property(x => x.FullName).IsRequired().HasMaxLength(100).IsUnicode();
            UserDbEentity.Property(x => x.NumberPhone).IsRequired().HasMaxLength(20).IsUnicode();
            UserDbEentity.Property(x => x.Email).IsRequired().HasMaxLength(200).IsUnicode();
            UserDbEentity.Property(x => x.ReserveEmail).IsRequired().HasMaxLength(200).IsUnicode();
            UserDbEentity.HasMany<SearchStoryDb>(x => x.SearchStories).WithRequired(x => x.User);

            //SearchStoryDb
            modelBuilder.Configurations.Add(new StoryConfiguration());

            //SearchRequestDb
            modelBuilder.Configurations.Add(new SearchRequestConfiguration());
        }
    }

    //SearchStoryDb
    public class StoryConfiguration : EntityTypeConfiguration<SearchStoryDb>
    {
        public StoryConfiguration()
        {
            ToTable("SearchStories").HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.SearchDate).IsRequired();
        }
    }

    //SearchRequestDb
    public class SearchRequestConfiguration : EntityTypeConfiguration<SearchRequestDb>
    {
        public SearchRequestConfiguration()
        {
            ToTable("SearchRequests").HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CacheId).IsRequired();
            Property(p => p.Title).IsRequired().HasMaxLength(200);
            Property(p => p.PublishedBefore).IsOptional();
            Property(p => p.PublishedAfter).IsOptional();
            Property(p => p.Definition).IsRequired();
            Property(p => p.Dimension).IsRequired();
            Property(p => p.Duration).IsRequired();
            Property(p => p.VideoCaption).IsRequired();
            HasMany<SearchStoryDb>(s => s.SearchStories).WithRequired(r => r.SearchRequest);
            HasMany<ResultVideoDb>(v => v.Videos).WithMany(r => r.SearchRequests);
        }
    }
}