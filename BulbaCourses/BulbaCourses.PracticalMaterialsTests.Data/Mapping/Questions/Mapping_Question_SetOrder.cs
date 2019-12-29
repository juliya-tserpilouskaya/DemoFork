using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.Questions
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

            this.Ignore(c => c.Author);
            this.Ignore(c => c.AnswerVariants);
        }
    }
}
