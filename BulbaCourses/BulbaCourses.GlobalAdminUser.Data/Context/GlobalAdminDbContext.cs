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

        //public DbSet<UserDb> Users { get; set; }

        public DbSet<UserAdditionalInfoDb> UsersAdditionalInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Comment Users table
            //modelBuilder.Entity<UserDb>().ToTable("Users");
            //var entity = modelBuilder.Entity<UserDb>();

            //entity.HasKey(x => x.Id);
            //entity.Property(x => x.Username).IsRequired()
            //    .HasMaxLength(30).IsUnicode();
            //entity.Property(x => x.Password).IsRequired().HasMaxLength(50).IsUnicode();
            //entity.Property(x => x.Email).IsRequired().HasMaxLength(50).IsUnicode();
            #endregion


            modelBuilder.Entity<UserAdditionalInfoDb>().ToTable("UsersAdditionalInfo");
            var userProfileEntity = modelBuilder.Entity<UserAdditionalInfoDb>();

            userProfileEntity.HasKey(x => x.UserProfileId);
            userProfileEntity.Property(x => x.UserId); //from UserDB.dbo.ASPNetUsers
            userProfileEntity.Property(x => x.Sex).HasMaxLength(10).IsUnicode();
            userProfileEntity.Property(x => x.Age).IsRequired();
            userProfileEntity.Property(x => x.City).IsRequired().HasMaxLength(50).IsRequired();
            userProfileEntity.Property(x => x.ProfilePictureUrl).IsOptional();
        }
    }
}
