using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test.AnswerVariants
{
    public class Mapping_AnswerVariant_SetIntoMissingElements : EntityTypeConfiguration<MAnswerVariant_SetIntoMissingElementsDb>
    {
        public Mapping_AnswerVariant_SetIntoMissingElements()
        {
            ToTable("AnswerVariant_SetIntoMissingElements");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
