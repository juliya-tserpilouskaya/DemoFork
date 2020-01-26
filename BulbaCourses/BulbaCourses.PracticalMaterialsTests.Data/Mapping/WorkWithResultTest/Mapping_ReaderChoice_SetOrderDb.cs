using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.WorkWithResultTest
{
    public class Mapping_ReaderChoice_SetOrderDb : EntityTypeConfiguration<MReaderChoice_SetOrderDb>
    {
        public Mapping_ReaderChoice_SetOrderDb()
        {
            ToTable("ReaderChoice_SetOrder");

            HasKey(i => i.Id);

            Property(i => i.ReaderChoice_MainInfoDb_Id)
                .HasColumnName("ReaderChoice_MainInfoDb_Id")
                .IsRequired();

            Property(i => i.Test_MainInfoDb_Id)
                .HasColumnName("Test_MainInfoDb_Id")
                .IsRequired();

            Property(i => i.Question_SetOrderDb_Id)
                .HasColumnName("Question_SetOrderDb_Id")
                .IsRequired();

            Property(i => i.AnswerVariant_SetOrderDb_Id)
                .HasColumnName("AnswerVariant_SetOrderDb_Id")
                .IsRequired();

            Property(i => i.OrderKey)
                .HasColumnName("OrderKey")
                .IsRequired();
        }
    }
}
