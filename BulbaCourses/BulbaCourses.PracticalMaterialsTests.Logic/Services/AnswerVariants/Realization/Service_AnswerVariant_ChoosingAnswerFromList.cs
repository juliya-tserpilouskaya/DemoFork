using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.BaseService;
using System;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Realization
{
    public class Service_AnswerVariant_ChoosingAnswerFromList : Service_Base, IService_AnswerVariant
    {
        protected Service_AnswerVariant_ChoosingAnswerFromList(DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public void AddAnswer()
        {
            throw new NotImplementedException();
        }

        public void DropAnswerById(int Id)
        {
            throw new NotImplementedException();
        }

        public void GetAnswerById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
