using BulbaCourses.Podcasts.Data.Migrations;
using BulbaCourses.Podcasts.Data.Models;
using System.Data.Entity;

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

            modelBuilder.Entity<UserDb>().ToTable("Users");
            var entityUser = modelBuilder.Entity<UserDb>();
            entityUser.HasKey(b => b.Id);
            entityUser.Property(b => b.Description).IsOptional().HasMaxLength(510).IsUnicode();
            entityUser.HasIndex(b => b.Name).IsUnique(true);

            modelBuilder.Entity<CourseDb>().ToTable("Courses");
            var entityCourses = modelBuilder.Entity<CourseDb>();
            entityCourses.HasKey(b => b.Id);
            entityCourses.Property(b => b.Name).IsRequired().IsUnicode();
            entityCourses.HasIndex(b => b.Name).IsUnique(true);
            entityCourses.Property(b => b.Description).IsRequired().HasMaxLength(1000);
            entityCourses.Property(b => b.Price).IsRequired();
            entityCourses.HasOptional(b => b.Author).WithMany(t => t.UploadedCourses).Map(m => m.MapKey("CourseAuthorId"));

            modelBuilder.Entity<AudioDb>().ToTable("Audios");
            var entityAudio = modelBuilder.Entity<AudioDb>();
            entityAudio.HasKey(b => b.Id);
            entityAudio.Property(b => b.Name).IsRequired().HasMaxLength(255).IsUnicode();
            entityAudio.Property(b => b.Duration).IsRequired();
            entityAudio.Property(b => b.Content).IsRequired();

            modelBuilder.Entity<CommentDb>().ToTable("Comments");
            var entityComment = modelBuilder.Entity<CommentDb>();
            entityComment.HasKey(b => b.Id);
            entityComment.Property(b => b.Text).IsRequired().HasMaxLength(255).IsUnicode();
            entityComment.Property(b => b.PostDate).IsRequired();
        }
    }
}