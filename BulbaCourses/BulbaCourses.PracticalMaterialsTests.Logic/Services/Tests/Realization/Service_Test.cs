using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.BaseService;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe;
using System;
using System.Linq;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization
{
    public class Service_Test : Service_Base, IService_Test
    {
        public Service_Test(DbContext_Test context) : base (context)
        {

        }

        public MTest_MainInfo GetTestById(int Id)
        {
            MTest_MainInfoDb Test_MainInfoDb = 
                _context.Test_MainInfo.FirstOrDefault(c => c.Id == Id);

            return
                new MTest_MainInfo()
                {
                    Id = Test_MainInfoDb.Id,
                    Name = Test_MainInfoDb.Name
                };
        }

        public void AddTest()
        {
            throw new NotImplementedException();
        }

        public void DropTestById(int Id)
        {
            throw new NotImplementedException();
        } 
    }
}
