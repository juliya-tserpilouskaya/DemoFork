using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Tests
{ 
    public class Mapping_Test_MainInfo : EntityTypeConfiguration<MTest_MainInfoDb>
    {
        public Mapping_Test_MainInfo()
        {
            ToTable("Test_MainInfo");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();                

            Property(i => i.Name)
                .HasColumnName("Name")                
                .HasMaxLength(50)                
                .IsUnicode(false)
                .IsRequired();

            this.Ignore(c => c.Author);
            this.Ignore(c => c.Join_TestWithQuestions);
        }
    }
}
