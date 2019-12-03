using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.DatabaseContex
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext() : base("VideoDbConnection")
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

        }
    }
}
