using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.BaseService;
using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.AnswerVariants.Realization
{
    public class Service_AnswerVariant_SetIntoMissingElements : Service_Base, IService_AnswerVariant
    {
        protected Service_AnswerVariant_SetIntoMissingElements(DbContext_Test context) : base(context)
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
