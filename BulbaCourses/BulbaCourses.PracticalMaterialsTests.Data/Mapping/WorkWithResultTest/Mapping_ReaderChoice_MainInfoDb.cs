using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BulbaCourses.PracticalMaterialsTests.Data.Mapping.WorkWithResultTest
{
    public class Mapping_ReaderChoice_MainInfoDb : EntityTypeConfiguration<MReaderChoice_MainInfoDb>
    {
        public Mapping_ReaderChoice_MainInfoDb()
        {
            ToTable("ReaderChoice_MainInfo");

            HasKey(i => i.Id);

            Property(i => i.NumberOfAttempt)
                .HasColumnName("NumberOfAttempt")
                .IsRequired();

            Property(i => i.ResultTest)
                .HasColumnName("ResultTest")
                .HasMaxLength(150)
                .IsRequired();

            Property(i => i.DatePassed)
                .HasColumnName("DatePassed")
                .HasColumnType("date")
                .IsRequired();

            this.HasMany(g => g.ReaderChoices_ChoosingAnswerFromListDb)
                .WithRequired(s => s.ReaderChoice_MainInfoDb)
                .HasForeignKey<int>(s => s.ReaderChoice_MainInfoDb_Id)
                .WillCascadeOnDelete();

            this.HasMany(g => g.ReaderChoices_SetOrderDb)
                .WithRequired(s => s.ReaderChoice_MainInfoDb)
                .HasForeignKey<int>(s => s.ReaderChoice_MainInfoDb_Id)
                .WillCascadeOnDelete();

        }
    }
}
