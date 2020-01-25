using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test.Questions
{
    public class Mapping_Question_SetOrder : EntityTypeConfiguration<MQuestion_SetOrderDb>
    {
        public Mapping_Question_SetOrder()
        {
            ToTable("Question_SetOrder");

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
                .WithRequired(s => s.Question_SetOrderDb)
                .HasForeignKey<int>(s => s.Question_SetOrderDb_Id)
                .WillCascadeOnDelete();
        }
    }
}
