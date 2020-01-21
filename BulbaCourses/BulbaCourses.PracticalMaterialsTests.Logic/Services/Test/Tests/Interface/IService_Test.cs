using BulbaCourses.PracticalMaterialsTests.Logic.Models.Common;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface
{
    public interface IService_Test : IDisposable
    {
        // ------------ CRUD

        Result<MTest_MainInfo> GetById(int Id);

        Task<Result<MTest_MainInfo>> GetByIdAsync(int Id);

        Result<MTest_MainInfo> Add(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo);

        Task<Result<MTest_MainInfo>> AddAsync(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo);

        Result<MTest_MainInfo> Update(MTest_MainInfo Test_MainInfo);

        Task<Result<MTest_MainInfo>> UpdateAsync(MTest_MainInfo Test_MainInfo);

        Result DeleteById(int Id);

        Task<Result> DeleteByIdAsync(int Id);

        // ------------ Check

        Result<MTest_MainInfo> CheckTest(MTest_MainInfo User_Test_MainInfo, MTest_MainInfo Curr_Test_MainInfo);
    }
}
