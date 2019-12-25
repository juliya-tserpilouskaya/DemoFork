using BulbaCourses.PracticalMaterialsTests.Data.Models.Join;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.DbMapping.Join
{
    public class Mapping_Join_TestWithQuestions : EntityTypeConfiguration<MJoin_TestWithQuestionsDb>
    {
        public Mapping_Join_TestWithQuestions()
        {
            ToTable("Join_TestWithQuestions");

            Property(i => i.QuestionType).HasColumnName("QuestionType")
                               .HasColumnType("int")
                               .IsRequired();

            Property(i => i.SortKey).HasColumnName("SortKey")
                                  .HasColumnType("int")
                                  .IsRequired();           
        }
    }
}
