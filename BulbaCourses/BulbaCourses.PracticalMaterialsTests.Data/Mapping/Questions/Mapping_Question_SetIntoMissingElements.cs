using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Questions
{
    public class Mapping_Question_SetIntoMissingElements : EntityTypeConfiguration<MQuestion_SetIntoMissingElementsDb>
    {
        public Mapping_Question_SetIntoMissingElements()
        {
            ToTable("Question_SetIntoMissingElements");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
