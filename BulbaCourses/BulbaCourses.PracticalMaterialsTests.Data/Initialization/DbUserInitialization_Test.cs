using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Test;
using System.Collections.Generic;
using System.Data.Entity;
using BulbaCourses.PracticalMaterialsTests.Data.Models.User;

namespace BulbaCourses.PracticalMaterialsTests.Data.Initialization
{
    public class DbUserInitialization_Test : DropCreateDatabaseAlways<DbContext_LocalDb_Test>
    {
        protected override void Seed(DbContext_LocalDb_Test context)
        {
            // ------------ TestData

            ICollection<MTest_MainInfoDb> default_Test_MainInfoDb =
                new List<MTest_MainInfoDb>()
                {
                    new MTest_MainInfoDb()
                    {
                        Name = "Test_Name_1",
                        User_TestAuthor = new MUser_TestAuthorDb(),                        
                        Questions_ChoosingAnswerFromList =
                            new List<MQuestion_ChoosingAnswerFromListDb>()
                            {
                                 new MQuestion_ChoosingAnswerFromListDb()
                                 {
                                     QuestionText = "Question_ChoosingAnswerFromListDb_Text_1",
                                     SortKey = 1,
                                     AnswerVariants =
                                        new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                                        {
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "Ответ_1",
                                                SortKey = 1,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "AnswerText_2",
                                                SortKey = 2,
                                                IsCorrectAnswer = false
                                            },
                                            new MAnswerVariant_ChoosingAnswerFromListDb()
                                            {
                                                AnswerText = "AnswerText_3",
                                                SortKey = 3,
                                                IsCorrectAnswer = true
                                            }
                                        }
                                 }
                            },
                        Questions_SetIntoMissingElements =
                            new List<MQuestion_SetIntoMissingElementsDb>()
                            {
                                new MQuestion_SetIntoMissingElementsDb()
                                {
                                    QuestionText = "Question_SetIntoMissingElementsDb_Text_1",
                                    SortKey = 2
                                }
                            },
                        Questions_SetOrder =
                            new List<MQuestion_SetOrderDb>()
                            {
                                 new MQuestion_SetOrderDb()
                                 {
                                     QuestionText = "QuestionText_1",
                                     SortKey = 3,
                                     AnswerVariants =
                                     new List<MAnswerVariant_SetOrderDb>()
                                     {
                                         new MAnswerVariant_SetOrderDb()
                                         {
                                             AnswerText = "AnswerText_1",
                                             SortKey = 1,
                                             CorrectOrderKey = 1
                                         },
                                         new MAnswerVariant_SetOrderDb()
                                         {
                                             AnswerText = "AnswerText_2",
                                             SortKey = 2,
                                             CorrectOrderKey = 2
                                         },
                                         new MAnswerVariant_SetOrderDb()
                                         {
                                             AnswerText = "AnswerText_3",
                                             SortKey = 3,
                                             CorrectOrderKey = 3
                                         }
                                     }
                                 }
                            }
                    }
                };

            context.Test_MainInfo.AddRange(default_Test_MainInfoDb);


            // ------------ 

            base.Seed(context);
        }
    }
}
