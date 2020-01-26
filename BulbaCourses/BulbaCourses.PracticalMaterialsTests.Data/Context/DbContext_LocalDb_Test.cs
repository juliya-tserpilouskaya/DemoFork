using BulbaCourses.PracticalMaterialsTests.Data.Config;
using BulbaCourses.PracticalMaterialsTests.Data.Initialization;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.Test;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using System.Data.Entity;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.User;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Data.Models.WorkWithResultTest;

namespace BulbaCourses.PracticalMaterialsTests.Data.Context
{
    [DbConfigurationType(typeof(DbConfig_LocalDb_Test))]
    public class DbContext_LocalDb_Test : DbContext
    {
        public DbContext_LocalDb_Test()
        {
            Database.SetInitializer(new DbUserInitialization_Test());
        }

        // ------------ Tests

        public DbSet<MTest_MainInfoDb> Test_MainInfo { get; set; }

        // ------------ Questions

        public DbSet<MQuestion_ChoosingAnswerFromListDb> Question_ChoosingAnswerFromList { get; set; }

        public DbSet<MQuestion_SetOrderDb> Question_SetOrder { get; set; }

        // ------------ AnswerVariants

        public DbSet<MAnswerVariant_ChoosingAnswerFromListDb> AnswerVariant_ChoosingAnswerFromList { get; set; }        

        public DbSet<MAnswerVariant_SetOrderDb> AnswerVariant_SetOrder { get; set; }

        // ------------ WorkWithResultTest

        public DbSet<MReaderChoice_MainInfoDb> ReaderChoice_MainInfo { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ------------ Tests

            modelBuilder.Configurations.Add(new Mapping_Test_MainInfo());

            // ------------ Questions

            modelBuilder.Configurations.Add(new Mapping_Question_ChoosingAnswerFromList());

            modelBuilder.Configurations.Add(new Mapping_Question_SetOrder());

            // ------------ AnswerVariants

            modelBuilder.Configurations.Add(new Mapping_AnswerVariant_ChoosingAnswerFromList());            

            modelBuilder.Configurations.Add(new Mapping_AnswerVariant_SetOrder());

            // ------------ WorkWithResultTest

            modelBuilder.Configurations.Add(new Mapping_ReaderChoice_MainInfoDb());

            modelBuilder.Configurations.Add(new Mapping_ReaderChoice_ChoosingAnswerFromListDb());

            modelBuilder.Configurations.Add(new Mapping_ReaderChoice_SetOrderDb());

            // ------------ User

            modelBuilder.Configurations.Add(new Mapping_User_TestAuthor());

            modelBuilder.Configurations.Add(new Mapping_User_TestReader());
        }
    }
}
