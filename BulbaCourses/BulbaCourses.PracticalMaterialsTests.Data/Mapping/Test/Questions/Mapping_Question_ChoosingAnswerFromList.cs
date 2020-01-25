using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test.Questions
{
    public class Mapping_Question_ChoosingAnswerFromList : EntityTypeConfiguration<MQuestion_ChoosingAnswerFromListDb>
    {
        public Mapping_Question_ChoosingAnswerFromList()
        {
            ToTable("Question_ChoosingAnswerFromList");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(i => i.QuestionText)
                .HasColumnName("QuestionText")
                .HasMaxLength(50)                
                .IsRequired();

            Property(i => i.SortKey)
                .HasColumnName("SortKey")                
                .IsRequired();

            this.HasMany(g => g.AnswerVariants)
                .WithRequired(s => s.Question_ChoosingAnswerFromListDb)
                .HasForeignKey<int>(s => s.Question_ChoosingAnswerFromListDb_Id)
                .WillCascadeOnDelete();
        }
    }
}
