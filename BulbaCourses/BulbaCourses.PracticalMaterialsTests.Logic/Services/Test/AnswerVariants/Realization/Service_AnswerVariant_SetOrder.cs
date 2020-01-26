using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.AnswerVariants.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using System;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.AnswerVariants.Realization
{
    public class Service_AnswerVariant_SetOrder : Service_Base, IService_AnswerVariant
    {
        protected Service_AnswerVariant_SetOrder(DbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
