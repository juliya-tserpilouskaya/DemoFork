using BulbaCourses.PracticalMaterialsTests.Logic.Models.Base;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.WorkWithResultTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface
{
    public interface IService_Test : IDisposable
    {
        // ------------ CRUD

        MResultRequest<MTest_MainInfo> GetById(int Id);

        Task<MResultRequest<MTest_MainInfo>> GetByIdAsync(int Id);

        MResultRequest<MTest_MainInfo> Add(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo);

        Task<MResultRequest<MTest_MainInfo>> AddAsync(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo);

        MResultRequest<MTest_MainInfo> Update(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo);

        Task<MResultRequest<MTest_MainInfo>> UpdateAsync(string User_TestAuthor_Id, MTest_MainInfo Test_MainInfo);

        MResultRequest DeleteById(int Id);

        Task<MResultRequest> DeleteByIdAsync(int Id);

        // ------------ CheckCorrectAnswer

        MResultRequest<string> CheckTestAsync(string User_TestAuthor_Id, MReaderChoice_MainInfo ReaderChoice_MainInfo);        
    }
}
