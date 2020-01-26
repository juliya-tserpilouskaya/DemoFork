using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Questions.Interfaсe;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Questions.Realization
{
    public class Service_Question_SetOrder : Service_Base, IService_Question
    {
        public Service_Question_SetOrder([AttributeDbContext_LocalDb]DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public int CheckQuestion(MTest_MainInfo Current_Test_MainInfo, MReaderChoice_MainInfo ReaderChoice_MainInfo)
        {
            int CorrectAnswerCount = 0;

            foreach (MQuestion_SetOrder CurrentQuestions_SetOrder in Current_Test_MainInfo.Questions_SetOrder)
            {
                IEnumerable<int> CorrectAnswerId =
                    CurrentQuestions_SetOrder.AnswerVariants
                        .Select(c => c.CorrectOrderKey);

                IEnumerable<int> ReaderAnswerId =
                    ReaderChoice_MainInfo.ReaderChoices_SetOrder
                        .Where(c => c.Question_SetOrderDb_Id == CurrentQuestions_SetOrder.Id)
                        .Select(c => c.AnswerVariant_SetOrderDb_Id);

                if (CorrectAnswerId.SequenceEqual(ReaderAnswerId))
                {
                    CorrectAnswerCount++;
                }
            }

            return
                CorrectAnswerCount;
        }
    }
}
