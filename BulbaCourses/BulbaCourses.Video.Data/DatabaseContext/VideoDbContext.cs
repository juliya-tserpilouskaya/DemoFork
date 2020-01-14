using BulbaCourses.Video.Data.Migrations;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.DatabaseContext
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext() : base("VideoConnect")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VideoDbContext, Configuration>());
        }
        public DbSet<UserDb> Users { get; set; }
        public virtual DbSet<AuthorDb> Authors { get; set; }
        public DbSet<VideoMaterialDb> VideoMaterials { get; set; }
        public virtual DbSet<CourseDb> Courses { get; set; }
        public virtual DbSet<TagDb> Tags { get; set; }
        public virtual DbSet<CommentDb> Comments { get; set; }
        public DbSet<TransactionDb> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDb>().ToTable("Users");
            var entityUser = modelBuilder.Entity<UserDb>();
            entityUser.HasKey(b => b.UserId);
            //entityUser.Property(b => b.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<AuthorDb>().ToTable("Authors");
            var entityAuthor = modelBuilder.Entity<AuthorDb>();
            entityAuthor.HasKey(b => b.AuthorId);
            entityAuthor.Property(b => b.Name).IsRequired().IsUnicode();
            entityAuthor.Property(b => b.Lastname).IsRequired().IsUnicode();
            entityAuthor.Property(b => b.Professions).IsRequired().IsUnicode();
            entityAuthor.Property(b => b.Annotation).IsRequired().HasMaxLength(1024);

            modelBuilder.Entity<TransactionDb>().ToTable("Transactions");
            var entityTransaction = modelBuilder.Entity<TransactionDb>();
            entityTransaction.HasKey(b => b.TransactionId);
            entityTransaction.Property(b => b.TransactionDate).IsRequired();
            entityTransaction.Property(b => b.TransactionAmount).IsRequired();

            modelBuilder.Entity<CourseDb>().ToTable("Courses");
            var entityCourses = modelBuilder.Entity<CourseDb>();
            entityCourses.HasKey(b => b.CourseId);
            entityCourses.Property(b => b.Name).IsRequired().IsUnicode();
            //entityCourses.HasIndex(b => b.Name).IsUnique(true);
            entityCourses.Property(b => b.Description).IsRequired().HasMaxLength(1024);
            entityCourses.Property(b => b.Duration).IsRequired();
            entityCourses.Property(b => b.Price).IsRequired();
            entityCourses.HasOptional<AuthorDb>(b => b.Author).WithMany(t => t.AuthorCourses).Map(m => m.MapKey("CourseAuthorId"));

            modelBuilder.Entity<VideoMaterialDb>().ToTable("Videos");
            var entityVideo = modelBuilder.Entity<VideoMaterialDb>();
            entityVideo.HasKey(b => b.VideoId);
            entityVideo.Property(b => b.Name).IsRequired().HasMaxLength(255).IsUnicode();
            entityVideo.Property(b => b.Duration).IsRequired();
            entityVideo.Property(b => b.Created).IsRequired();
            entityVideo.Property(b => b.Order).IsRequired();
            entityVideo.Property(b => b.CourseId).IsRequired();

            modelBuilder.Entity<CommentDb>().ToTable("Comments");
            var entityComment = modelBuilder.Entity<CommentDb>();
            entityComment.HasKey(b => b.CommentId);
            entityComment.Property(b => b.Text).IsRequired().HasMaxLength(255).IsUnicode();
            entityComment.Property(b => b.Date).IsRequired();
            entityComment.HasOptional<UserDb>(b => b.UserId).WithMany(t => t.Comments).Map(m => m.MapKey("UserCommentsId"));

            modelBuilder.Entity<TagDb>().ToTable("Tags");
            var entityTags = modelBuilder.Entity<TagDb>();
            entityTags.HasKey(b => b.TagId);
            entityTags.Property(b => b.Content).IsRequired().HasMaxLength(15).IsUnicode();
            entityTags.HasIndex(b => b.Content).IsUnique(true);
            entityTags.HasMany<CourseDb>(b => b.Courses).WithMany(t => t.Tags).Map(m => m.MapRightKey("CourseId").MapLeftKey("TagId").ToTable("CourseTag"));

        }
    }
}
