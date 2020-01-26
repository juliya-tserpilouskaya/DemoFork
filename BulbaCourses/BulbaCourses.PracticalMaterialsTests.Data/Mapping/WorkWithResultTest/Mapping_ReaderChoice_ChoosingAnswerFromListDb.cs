using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.WorkWithResultTest
{
    public class Mapping_ReaderChoice_ChoosingAnswerFromListDb : EntityTypeConfiguration<MReaderChoice_ChoosingAnswerFromListDb>
    {
        public Mapping_ReaderChoice_ChoosingAnswerFromListDb()
        {
            ToTable("ReaderChoice_ChoosingAnswerFromList");

            HasKey(i => i.Id);

            Property(i => i.ReaderChoice_MainInfoDb_Id)
                .HasColumnName("ReaderChoice_MainInfoDb_Id")
                .IsRequired();   

            Property(i => i.Question_ChoosingAnswerFromList_Id)
                .HasColumnName("Question_ChoosingAnswerFromList_Id")
                .IsRequired();

            Property(i => i.AnswerVariant_ChoosingAnswerFromList_Id)
                .HasColumnName("AnswerVariant_ChoosingAnswerFromList_Id")
                .IsRequired();
        }
    }
}
