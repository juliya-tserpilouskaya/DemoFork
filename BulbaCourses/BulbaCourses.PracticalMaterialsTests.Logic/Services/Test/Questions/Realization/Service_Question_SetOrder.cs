using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Questions.Interfaсe;
using System;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Questions.Realization
{
    public class Service_Question_SetOrder : Service_Base, IService_Question
    {
        public Service_Question_SetOrder([AttributeDbContext_LocalDb]DbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public int CheckQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
