using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Questions.Interfaсe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Questions.Realization
{
    public class Service_Question_ChoosingAnswerFromList : Service_Base, IService_Question
    {
        public Service_Question_ChoosingAnswerFromList([AttributeDbContext_LocalDb]DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public int CheckQuestion(MTest_MainInfo Current_Test_MainInfo, MReaderChoice_MainInfo ReaderChoice_MainInfo)
        {
            int CorrectAnswerCount = 0;

            if (Current_Test_MainInfo.Questions_ChoosingAnswerFromList.Any())
            {
                foreach (MQuestion_ChoosingAnswerFromList CurrentQuestions_ChoosingAnswerFromList in Current_Test_MainInfo.Questions_ChoosingAnswerFromList)
                {
                    IEnumerable<int> CorrectAnswerId =
                        CurrentQuestions_ChoosingAnswerFromList.AnswerVariants
                            .Where(c => c.IsCorrectAnswer)
                            .Select(c => c.Id)
                            .OrderBy(c => c);

                    IEnumerable<int> ReaderAnswerId =
                        ReaderChoice_MainInfo.ReaderChoices_ChoosingAnswerFromList
                            .Where(c => c.Question_ChoosingAnswerFromList_Id == CurrentQuestions_ChoosingAnswerFromList.Id)
                            .Select(c => c.AnswerVariant_ChoosingAnswerFromList_Id)
                            .OrderBy(c => c);

                    if (CorrectAnswerId.SequenceEqual(ReaderAnswerId))
                    {
                        CorrectAnswerCount++;
                    }
                }
            }

            return
               CorrectAnswerCount;
        }
    }
}
