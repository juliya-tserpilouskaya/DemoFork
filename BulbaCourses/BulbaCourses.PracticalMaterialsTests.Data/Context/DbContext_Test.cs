using BulbaCourses.PracticalMaterialsTests.Data.Config;
using BulbaCourses.PracticalMaterialsTests.Data.Initialization;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Mapping.Tests;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Data.Context
{
    [DbConfigurationType(typeof(DbConfig_Test))]
    public class DbContext_Test : DbContext
    {
        public DbContext_Test()
        {
            Database.SetInitializer(new DbUserInitialization_Test());
        }

        // ------------ Tests

        public DbSet<MTest_MainInfoDb> Test_MainInfo { get; set; }

        // ------------ Questions

        public DbSet<MQuestion_ChoosingAnswerFromListDb> Question_ChoosingAnswerFromList { get; set; }

        public DbSet<MQuestion_SetIntoMissingElementsDb> Question_SetIntoMissingElements { get; set; }

        public DbSet<MQuestion_SetOrderDb> Question_SetOrder { get; set; }

        // ------------ AnswerVariants

        public DbSet<MAnswerVariant_ChoosingAnswerFromListDb> AnswerVariant_ChoosingAnswerFromList { get; set; }

        public DbSet<MAnswerVariant_SetIntoMissingElementsDb> AnswerVariant_SetIntoMissingElements { get; set; }

        public DbSet<MAnswerVariant_SetOrderDb> AnswerVariant_SetOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ------------ Tests

            modelBuilder.Configurations.Add(new Mapping_Test_MainInfo());

            // ------------ Questions

            modelBuilder.Configurations.Add(new Mapping_Question_ChoosingAnswerFromList());

            modelBuilder.Configurations.Add(new Mapping_Question_SetIntoMissingElements());

            modelBuilder.Configurations.Add(new Mapping_Question_SetOrder());

            // ------------ AnswerVariants

            modelBuilder.Configurations.Add(new Mapping_AnswerVariant_ChoosingAnswerFromList());            

            modelBuilder.Configurations.Add(new Mapping_AnswerVariant_SetIntoMissingElements());

            modelBuilder.Configurations.Add(new Mapping_AnswerVariant_SetOrder());         
        }
    }
}
