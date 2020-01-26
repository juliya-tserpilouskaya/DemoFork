using BulbaCourses.PracticalMaterialsTests.Data.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.User
{
    public class Mapping_User_TestReader : EntityTypeConfiguration<MUser_TestReaderDb>
    {
        public Mapping_User_TestReader()
        {
            ToTable("User_TestReader");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .IsRequired();

            Property(i => i.FIO)
                .HasColumnName("FIO")
                .HasMaxLength(70)
                .IsRequired();

            this.HasMany(g => g.ResultsOfTheTest)
                .WithRequired(c => c.User_TestReader)
                .HasForeignKey(c => c.User_TestReaderDb_Id)
                .WillCascadeOnDelete();
        }
    }
}
