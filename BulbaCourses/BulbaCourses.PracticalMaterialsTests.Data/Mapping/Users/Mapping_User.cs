using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Users
{
    public class Mapping_User : EntityTypeConfiguration<MUserDb>
    {
        public Mapping_User()
        {
            ToTable("User");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(i => i.Login)
                .HasColumnName("Login")                
                .HasMaxLength(50)                
                .IsUnicode(false)
                .IsRequired();

            Property(i => i.Password)
                .HasColumnName("Password")
                .HasMaxLength(50)
                .IsRequired();

            Property(i => i.Email)
                .HasColumnName("Email")                
                .HasMaxLength(50)                
                .IsUnicode(false)
                .IsRequired();

            this.Ignore(c => c.UserRoles);
        }
    }
}
