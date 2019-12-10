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
        }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<RoleDb> Roles { get; set; }
        public DbSet<VideoMaterialDb> VideoMaterials { get; set; }
        public DbSet<CourseDb> Courses { get; set; }
        public DbSet<TagDb> Tags { get; set; }
        public DbSet<CommentDb> Comments { get; set; }
        public DbSet<TransactionDb> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDb>().ToTable("Users");
            var entityUser = modelBuilder.Entity<UserDb>();
            entityUser.HasKey(b => b.UserId);
            entityUser.Property(b => b.Login).IsRequired().HasMaxLength(20).IsUnicode();
            entityUser.Property(b => b.Password).IsRequired().HasMaxLength(20).IsUnicode();
            entityUser.Property(b => b.Email).IsRequired().HasMaxLength(20).IsUnicode();

            modelBuilder.Entity<RoleDb>().ToTable("Roles");
            var entityRole = modelBuilder.Entity<RoleDb>();
            entityRole.HasKey(b => b.RoleId);
            entityRole.Property(b => b.RoleName).IsRequired().HasMaxLength(20).IsUnicode();

            modelBuilder.Entity<TransactionDb>().ToTable("Transactions");
            var entityTransaction = modelBuilder.Entity<TransactionDb>();
            entityTransaction.HasKey(b => b.TransactionId);
            entityTransaction.Property(b => b.TransactionDate).IsRequired();
            entityTransaction.Property(b => b.TransactionAmount).IsRequired();

            modelBuilder.Entity<CourseDb>().ToTable("Courses");
            var entityCourses = modelBuilder.Entity<CourseDb>();
            entityCourses.HasKey(b => b.CourseId);
            entityCourses.Property(b => b.Name).IsRequired().IsUnicode();
            entityCourses.Property(b => b.Description).IsRequired().HasMaxLength(1000);
            entityCourses.Property(b => b.Duration).IsRequired();
            entityCourses.Property(b => b.Price).IsRequired();
            entityCourses.HasOptional<UserDb>(b => b.Author).WithMany(t => t.Courses).Map(m => m.MapKey("CourseAuthorId"));

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
            entityTags.HasMany<CourseDb>(b => b.Courses).WithMany(t => t.Tags).Map(m => m.MapRightKey("CourseId").MapLeftKey("TagId").ToTable("CourseTag"));

        }
    }
}
