using BulbaCourses.PracticalMaterialsTests.Data.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.User
{
    public class Mapping_User_TestAuthor : EntityTypeConfiguration<MUser_TestAuthorDb>
    {
        public Mapping_User_TestAuthor()
        {
            ToTable("User_TestAuthor");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .IsRequired();

            this.HasMany(g => g.CreateTests)
                .WithRequired(c => c.User_TestAuthor)
                .HasForeignKey(c => c.User_TestAuthorDb_Id)
                .WillCascadeOnDelete();
        }
    }
}
