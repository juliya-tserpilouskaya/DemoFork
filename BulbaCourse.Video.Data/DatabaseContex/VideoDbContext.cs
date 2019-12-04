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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<VideoMaterial> VideoMaterials { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
