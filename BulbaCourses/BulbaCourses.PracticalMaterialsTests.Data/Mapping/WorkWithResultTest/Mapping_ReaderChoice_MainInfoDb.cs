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

            Property(i => i.ResultTest)
                .HasColumnName("ResultTest")                
                .HasMaxLength(150)
                .IsRequired();

            Property(i => i.Test_MainInfoDb_Id)
                .HasColumnName("Test_MainInfoDb_Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(i => i.User_TestReaderDb_Id)
                .HasColumnName("User_TestReaderDb_Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .IsRequired();

            this.HasMany(g => g.ReaderChoices_ChoosingAnswerFromListDb)
                .WithRequired(s => s.ReaderChoice_MainInfoDb)
                .HasForeignKey<int>(s => s.ReaderChoice_MainInfoDb_Id)
                .WillCascadeOnDelete();

            this.HasMany(g => g.MReaderChoices_SetOrderDb)
                .WithRequired(s => s.ReaderChoice_MainInfoDb)
                .HasForeignKey<int>(s => s.ReaderChoice_MainInfoDb_Id)
                .WillCascadeOnDelete();
        }
    }
}
