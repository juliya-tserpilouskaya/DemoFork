using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System.Collections.Generic;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Data.Initialization
{
    public class DbUserInitialization_Test : DropCreateDatabaseAlways<DbContext_Test>
    {
        protected override void Seed(DbContext_Test context)
        {
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

            // ------------ Questions

            IList<MQuestion_ChoosingAnswerFromListDb> default_Question_ChoosingAnswerFromListDb =
                new List<MQuestion_ChoosingAnswerFromListDb>()
                {
                    new MQuestion_ChoosingAnswerFromListDb()
                    {
                        QuestionText = "QuestionText_1",
                        AnswerVariants = 
                            new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                            {
                                new MAnswerVariant_ChoosingAnswerFromListDb()
                                {
                                    AnswerText = "AnswerText_1",
                                    SortKey = 1,
                                    IsCorrectAnswer = false
                                },
                                new MAnswerVariant_ChoosingAnswerFromListDb()
                                {
                                    AnswerText = "AnswerText_2",
                                    SortKey = 2,
                                    IsCorrectAnswer = false
                                },
                                new MAnswerVariant_ChoosingAnswerFromListDb()                    {
                                    AnswerText = "AnswerText_3",
                                    SortKey = 3,
                                    IsCorrectAnswer = true
                                }
                            }
                    },
                    new MQuestion_ChoosingAnswerFromListDb()
                    {
                        QuestionText = "QuestionText_2",
                        AnswerVariants =
                            new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                            {
                                new MAnswerVariant_ChoosingAnswerFromListDb()
                                {
                                    AnswerText = "AnswerText_1",
                                    SortKey = 1,
                                    IsCorrectAnswer = false
                                },
                                new MAnswerVariant_ChoosingAnswerFromListDb()
                                {
                                    AnswerText = "AnswerText_2",
                                    SortKey = 2,
                                    IsCorrectAnswer = false
                                },
                                new MAnswerVariant_ChoosingAnswerFromListDb()                    {
                                    AnswerText = "AnswerText_3",
                                    SortKey = 3,
                                    IsCorrectAnswer = true
                                }
                            }
                    },
                    new MQuestion_ChoosingAnswerFromListDb()
                    {
                        QuestionText = "QuestionText_3",
                        AnswerVariants =
                            new List<MAnswerVariant_ChoosingAnswerFromListDb>()
                            {
                                new MAnswerVariant_ChoosingAnswerFromListDb()
                                {
                                    AnswerText = "AnswerText_1",
                                    SortKey = 1,
                                    IsCorrectAnswer = false
                                },
                                new MAnswerVariant_ChoosingAnswerFromListDb()
                                {
                                    AnswerText = "AnswerText_2",
                                    SortKey = 2,
                                    IsCorrectAnswer = false
                                },
                                new MAnswerVariant_ChoosingAnswerFromListDb()                    {
                                    AnswerText = "AnswerText_3",
                                    SortKey = 3,
                                    IsCorrectAnswer = true
                                }
                            }
                    }
                };

            context.Question_ChoosingAnswerFromList.AddRange(default_Question_ChoosingAnswerFromListDb);

            // ------------ AnswerVariants

            // ------------ 

            base.Seed(context);
        }
    }
}
