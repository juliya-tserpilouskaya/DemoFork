using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BulbaCourses.PracticalMaterialsTests.Tests.DataGenerators
{
    public static class Generator_TestModels
    {
        // ---------- TestModels

        public static ICollection<MTest_MainInfo> Generate_MTest_MainInfo(int countTest, int countQuestionInTest, int countAnswerVariantsFromQuestion)
        {
            ICollection<MTest_MainInfo> GenerateCollection = new Collection<MTest_MainInfo>();

            for (int i = 1; i <= countTest; i++)
            {
                GenerateCollection.Add(
                    new MTest_MainInfo()
                    {
                        Name = $"Test_Name_{i}",
                        Questions_ChoosingAnswerFromList = Generate_MQuestion_ChoosingAnswerFromList(i, countQuestionInTest, countAnswerVariantsFromQuestion),
                        Questions_SetIntoMissingElements = Generate_MQuestion_SetIntoMissingElements(i, countQuestionInTest, countAnswerVariantsFromQuestion),
                        Questions_SetOrder = Generate_MQuestion_SetOrder(i, countQuestionInTest, countAnswerVariantsFromQuestion)
                    });
            }

            return
                GenerateCollection;
        }

        // ---------- QuestionModels

        public static ICollection<MQuestion_ChoosingAnswerFromList> Generate_MQuestion_ChoosingAnswerFromList(int testId, int countQuestionInTest, int countAnswerVariantsFromQuestion)
        {
            ICollection<MQuestion_ChoosingAnswerFromList> GenerateCollection = new Collection<MQuestion_ChoosingAnswerFromList>();

            for (int i = 1; i <= countQuestionInTest; i++)
            {
                GenerateCollection.Add(
                    new MQuestion_ChoosingAnswerFromList()
                    {
                        QuestionText = $"QuestionText_ChoosingAnswerFromList_{testId}_{i}",
                        SortKey = i,
                        AnswerVariants = Generate_MAnswerVariant_ChoosingAnswerFromList(testId, i, countAnswerVariantsFromQuestion)
                    });
            }

            return
                GenerateCollection;
        }

        public static ICollection<MQuestion_SetIntoMissingElements> Generate_MQuestion_SetIntoMissingElements(int testId, int countQuestionInTest, int countAnswerVariantsFromQuestion)
        {
            ICollection<MQuestion_SetIntoMissingElements> GenerateCollection = new Collection<MQuestion_SetIntoMissingElements>();

            for (int i = 1; i <= countQuestionInTest; i++)
            {
                GenerateCollection.Add(
                    new MQuestion_SetIntoMissingElements()
                    {
                        QuestionText = $"QuestionText_SetIntoMissingElements_{testId}_{i}",
                        SortKey = i                        
                    });
            }

            return
                GenerateCollection;
        }

        public static ICollection<MQuestion_SetOrder> Generate_MQuestion_SetOrder(int testId, int countQuestionInTest, int countAnswerVariantsFromQuestion)
        {
            ICollection<MQuestion_SetOrder> GenerateCollection = new Collection<MQuestion_SetOrder>();

            for (int i = 1; i <= countQuestionInTest; i++)
            {
                GenerateCollection.Add(
                    new MQuestion_SetOrder()
                    {
                        QuestionText = $"QuestionText_SetOrder_{testId}_{i}",
                        SortKey = i,
                        AnswerVariants = Generate_MAnswerVariant_SetOrder(testId, i, countAnswerVariantsFromQuestion)
                    });
            }

            return
                GenerateCollection;
        }

        // ---------- AnswerVariantModels

        public static ICollection<MAnswerVariant_ChoosingAnswerFromList> Generate_MAnswerVariant_ChoosingAnswerFromList(int testId, int questionId, int countAnswerVariantsFromQuestion)
        {
            ICollection<MAnswerVariant_ChoosingAnswerFromList> GenerateCollection = new Collection<MAnswerVariant_ChoosingAnswerFromList>();

            int correctAnswerNumber = new Random().Next(1, countAnswerVariantsFromQuestion);            

            for (int i = 1; i <= countAnswerVariantsFromQuestion; i++)
            {
                GenerateCollection.Add(
                    new MAnswerVariant_ChoosingAnswerFromList()
                    {
                        AnswerText = $"AnswerText_ChoosingAnswerFromList_{testId}_{questionId}_{i}",
                        SortKey = i,
                        IsCorrectAnswer = (i == correctAnswerNumber ) ? true : false
                    });
            }

            return
                GenerateCollection;
        }

        public static ICollection<MAnswerVariant_SetIntoMissingElements> Generate_MAnswerVariant_SetIntoMissingElements(int testId, int questionId, int countAnswerVariantsFromQuestion)
        {
            ICollection<MAnswerVariant_SetIntoMissingElements> GenerateCollection = new Collection<MAnswerVariant_SetIntoMissingElements>();

            int correctAnswerNumber = new Random().Next(1, countAnswerVariantsFromQuestion);

            for (int i = 1; i <= countAnswerVariantsFromQuestion; i++)
            {
                GenerateCollection.Add(
                    new MAnswerVariant_SetIntoMissingElements()
                    {
                        
                    });
            }

            return
                GenerateCollection;
        }

        public static ICollection<MAnswerVariant_SetOrder> Generate_MAnswerVariant_SetOrder(int testId, int questionId, int countAnswerVariantsFromQuestion)
        {
            ICollection<MAnswerVariant_SetOrder> GenerateCollection = new Collection<MAnswerVariant_SetOrder>();

            int correctAnswerNumber = new Random().Next(1, countAnswerVariantsFromQuestion);

            for (int i = 1; i <= countAnswerVariantsFromQuestion; i++)
            {
                GenerateCollection.Add(
                    new MAnswerVariant_SetOrder()
                    {
                        AnswerText = $"AnswerText_SetOrder_{testId}_{questionId}_{i}",
                        SortKey = i,
                        CorrectOrderKey = i,                        
                    });
            }

            return
                GenerateCollection;
        }
    }
}
