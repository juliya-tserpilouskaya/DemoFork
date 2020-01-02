using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System.Collections.Generic;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Data.Initialization
{
    public class DbUserInitialization_Test : DropCreateDatabaseAlways<DbContext_Test>
    {
        protected override void Seed(DbContext_Test context)
        {
            // ------------ Test

            IList<MTest_MainInfoDb> default_Test_MainInfoDb =
                new List<MTest_MainInfoDb>()
                {
                    new MTest_MainInfoDb()
                    {
                        Name = "Test_Name_1",
                        Question_ChoosingAnswerFromList = 
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
                        Question_SetIntoMissingElements = 
                            new List<MQuestion_SetIntoMissingElementsDb>()
                            {
                                new MQuestion_SetIntoMissingElementsDb()
                                {
                                    QuestionText = "Question_SetIntoMissingElementsDb_Text_1",
                                    SortKey = 2
                                }
                            },
                        Question_SetOrder = 
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

            // ------------ Questions

            // ------------ AnswerVariants

            // ------------ User

            IList<MUserDb> default_UserList = 
                new List<MUserDb>()
                {
                    new MUserDb()
                    {
                        Login = "User_1",
                        Password = "User_1_Password",
                        Email = "User_1_Email"
                    },
                    new MUserDb()
                    {
                        Login = "User_2",
                        Password = "User_2_Password",
                        Email = "User_2_Email"
                    },
                    new MUserDb()
                    {
                        Login = "User_3",
                        Password = "User_3_Password",
                        Email = "User_3_Email"
                    }
                };
            
            context.User.AddRange(default_UserList);            

            // ------------ 

            base.Seed(context);
        }
    }
}
