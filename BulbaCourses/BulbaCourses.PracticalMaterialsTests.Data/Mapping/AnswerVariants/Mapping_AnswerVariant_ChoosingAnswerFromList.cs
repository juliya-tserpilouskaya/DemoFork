using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.AnswerVariants
{   
    public class Mapping_AnswerVariant_ChoosingAnswerFromList : EntityTypeConfiguration<MAnswerVariant_ChoosingAnswerFromListDb>
    {
        public Mapping_AnswerVariant_ChoosingAnswerFromList()
        {
            ToTable("AnswerVariant_ChoosingAnswerFromList");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(i => i.AnswerText)
                .HasColumnName("AnswerText")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            Property(i => i.SortKey)
                .HasColumnName("SortKey")                
                .IsRequired();

            Property(i => i.IsCorrectAnswer)
                .HasColumnName("IsCorrectAnswer")                
                .IsRequired();
        }
    }
}