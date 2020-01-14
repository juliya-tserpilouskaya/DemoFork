using BulbaCourses.GlobalAdminUser.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Context
{
    public class GlobalAdminDbContext : DbContext
    {
        public GlobalAdminDbContext()
            :base("GlobalAdminUserConnection")
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public DbSet<UserDb> Users { get; set; }

        public DbSet<UserProfileDb> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDb>().ToTable("Users");
            var entity = modelBuilder.Entity<UserDb>();

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Username).IsRequired()
                .HasMaxLength(30).IsUnicode();
            entity.Property(x => x.Password).IsRequired().HasMaxLength(50).IsUnicode();
            entity.Property(x => x.Email).IsRequired().HasMaxLength(50).IsUnicode();

            modelBuilder.Entity<UserProfileDb>().ToTable("UserProfiles");
            var userProfileEntity = modelBuilder.Entity<UserProfileDb>();
            userProfileEntity.HasKey(x => x.User);
            userProfileEntity.Property(x => x.Surname).HasMaxLength(100).IsUnicode();
            userProfileEntity.Property(x => x.Name).HasMaxLength(100).IsUnicode();
            userProfileEntity.Property(x => x.ProfilePictureUrl).IsOptional();
            userProfileEntity.Property(x => x.TelephoneNumber).IsRequired().HasMaxLength(20).IsUnicode();
        }
    }
}
