using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.DbMapping.Tests
{ 
    public class Mapping_Test_MainInfo : EntityTypeConfiguration<MTest_MainInfoDb>
    {
        public Mapping_Test_MainInfo()
        {
            ToTable("TestMain");/*.Map(m =>
            {
                m.Properties(p => new { Author = p.Author, Join_TestWithQuestions = p.Join_TestWithQuestions });
                m.ToTable("User");
            });*/

            HasKey(i => i.Id);

            Property(i => i.Id).HasColumnName("Id")
                               .HasColumnType("int")
                               .IsRequired()
                               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Name).HasColumnName("Name")
                                  .HasColumnType("nvarchar")
                                  .HasMaxLength(50)
                                  .IsRequired()
                                  .IsUnicode(false);            
        }
    }
}
