using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test.AnswerVariants
{
    public class Mapping_AnswerVariant_SetOrder : EntityTypeConfiguration<MAnswerVariant_SetOrderDb>
    {
        public Mapping_AnswerVariant_SetOrder()
        {
            ToTable("AnswerVariant_SetOrder");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(i => i.AnswerText)
                .HasColumnName("AnswerText")
                .HasMaxLength(250)
                .IsRequired();

            Property(i => i.SortKey)
                .HasColumnName("SortKey")
                .IsRequired();

            Property(i => i.CorrectOrderKey)
                .HasColumnName("CorrectOrderKey")
                .IsRequired();
        }
    }
}
